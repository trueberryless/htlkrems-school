/*
 * UE02_Messomat_7K
 *
 * Created: 9/29/2023 10:58:33 PM
 * Author : trueberryless
 */ 

#define F_CPU 16000000

#include <avr/io.h>
#include <stdio.h>
#include <stdlib.h>
#include <avr/io.h>
#include <avr/interrupt.h>
#include <avr/eeprom.h>
#include <string.h>
#include <stdbool.h>
#include <avr/wdt.h>

#define __DELAY_BACKWARD_COMPATIBLE__
#include <util/delay.h>

#include "lcd.h"
#include "dht.h"

#define MAX(a, b) ((a) > (b) ? (a) : (b))
#define MIN(a, b) ((a) < (b) ? (a) : (b))

volatile int timer_counter = 0;
volatile int8_t temperature = 0;
volatile int8_t humidity = 0;
volatile int8_t interval_sec = 4;
volatile uint32_t sequence_number = 0;

volatile bool acknowledged = true;
volatile int8_t error_count = 0;

volatile bool fan_running = false;

volatile bool reset_button = false;

void init_timer(void) {
	// Interrupt wird alle __250ms__ aufgerufen
	
	// Timer Modus auf CTC setzen
	TCCR1A &= ~((1<<WGM10) | (1<<WGM11));
	TCCR1B |= (1<<WGM12);
	TCCR1B &= ~(1<<WGM13);

	// Output Compare Register richtig einstellen
	OCR1A = 64000;

	// Output Compare Register Interrupt aktivieren
	TIMSK1 |= (1<<OCIE1A);
}

void init_lcd(void) {
	lcd_init(LCD_DISP_ON);	
}

void init_usart(void) {
	// Baud Rate auf 9600 setzen
	UBRR0 = 103;
	
	// Senden aktivieren
	UCSR0B |= (1<<TXEN0) | (1<<RXEN0) | (1<<RXCIE0);
	
	// 8-Datenbit einstellen
	UCSR0C |= (1<<UCSZ00) | (1<<UCSZ01);
}

void init_led(void) {
	DDRB |= (1<<DDB0) | (1<<DDB1);
	PORTB &= ~((1<<PORTB0) | (1<<PORTB1));
}

void init_fan(void) {
	DDRB |= (1<<DDB2);
	PORTB &= ~(1<<PORTB2);
}

void init_wdt(void) {
	wdt_enable(WDTO_1S);
}

void init_buttons(void) {
	PORTD |= (1<<PORTD2);
	EIMSK |= (1<<INT0);
	
	PORTD |= (1<<PORTD3);
	EIMSK |= (1<<INT1);
}

void start_fan(void) {
	PORTB |= (1<<PORTB2);	
	fan_running = true;
}

void stop_fan(void) {
	PORTB &= ~(1<<PORTB2);
	fan_running = false;
}

void init_sequence_number(void) {
	//sequence_number = eeprom_read_dword(0x00);
	sequence_number = 0;
	acknowledged = sequence_number;
}

void reset(void) {
	stop();
	
	init_timer();
	init_usart();
	init_lcd();
	init_sequence_number();
	init_led();
	init_fan();
	init_wdt();
	init_buttons();
	
	timer_counter = 0;
	temperature = 0;
	humidity = 0;
	interval_sec = 4;

	sequence_number = 0;
	acknowledged = 0;
	error_count = 0;
	
	reset_button = false;
	
	sei();
	
	lcd_clrscr();
	lcd_puts("Send d to start!");
}

void start(void) {
	eeprom_busy_wait();
	for (uint8_t i = 0x0F;; i--)
	{
		if (eeprom_read_byte(i) != 255)
		{
			char buffer[25];
			sprintf(buffer, "%cDATE%u|HU%u|SN%u|%c", 0x02, eeprom_read_byte(i), eeprom_read_byte(i + 0x10), generate_sequence_number(), 0x03);
			write_string(buffer);
		}
		
		if (i == 0x00)
		{
			break;
		}
	}
	
	// Prescaler einstellen - Beispiel 64 - Timer starten
	TCCR1B |= (1<<CS10) | (1<<CS11);
	TCCR1B &= ~(1<<CS12);
	
	acknowledged = true;
	start_fan();
}

void stop(void) {
	// Timer stoppen - Prescaler = 0
	TCCR1B &= ~((1<<CS12) | (1<<CS10) | (1<<CS11));	
	stop_fan();
}

void write_char(char str) {
	while (!(UCSR0A & (1<<UDRE0)));
	UDR0=str;
}

void write_string(char *arr) {
	while(*arr) {
		while (!(UCSR0A & (1<<UDRE0)));
		UDR0=*arr++;
	}
	while (!(UCSR0A & (1<<UDRE0)));
}

void print_lcd(char *arr) {
	lcd_clrscr();
	while (*arr)
	{
		lcd_putc(*arr++);
	}
}

int generate_sequence_number() {
	//eeprom_write_dword(0x00, sequence_number++);
	sequence_number++;
	return sequence_number;
}

// every 250ms
ISR(TIMER1_COMPA_vect) {
	if (timer_counter >= interval_sec * 4)
	{
		char buffer[25];
		
		if (acknowledged)
		{
			acknowledged = false;
			
			if(dht_gettemperaturehumidity(&temperature, &humidity) != -1)
			{
				sprintf(buffer, "T: %u%cC; H: %u%c", temperature, 0xDF, humidity, 0x25);
				print_lcd(buffer);
				
				sprintf(buffer, "%cDATE%u|HU%u|SN%u|%c", 0x02, temperature, humidity, generate_sequence_number(), 0x03);
				write_string(buffer);
				
				for (uint8_t i = 0x0F; i > 0x00; i--)
				{
					eeprom_write_byte(i, eeprom_read_byte(i - 0x01));
				}
				eeprom_write_byte(0x00, temperature);
				
				for (uint8_t i = 0x1F; i > 0x10; i--)
				{
					eeprom_write_byte(i, eeprom_read_byte(i - 0x01));
				}
				eeprom_write_byte(0x10, humidity);
				
			}
			else
			{
				print_lcd("Error");
			}
			
			error_count = 0;
		}
		else if (error_count >= 2)
		{
			PORTB |= (1<<PORTB1);
			sprintf(buffer, "NOT ACKNOWLEDGED\r\nEMBEDDED STOPPED");
			print_lcd(buffer);
			stop();
		}
		else if (!acknowledged) {
			sprintf(buffer, "NOT ACKNOWLEDGED");
			print_lcd(buffer);
			
			sprintf(buffer, "%cDATE%u|HU%u|SN%u|%c", 0x02, temperature, humidity, sequence_number, 0x03);
			write_string(buffer);
			
			error_count++;
		}
		timer_counter = 0;
	}
	else
	{
		timer_counter++;
	}
}

ISR(USART_RX_vect) {
	uint8_t tmp;
	tmp = UDR0;
	
	if (tmp == '1')
	{
		interval_sec = 1;
	}
	else if (tmp == '4')
	{
		interval_sec = 4;
	}
	else if (tmp == 6) {
		print_lcd("ACK");
		acknowledged = true;
	}
	else if(tmp == 'r') {
		reset();
	}
	else if(tmp == 'd') {
		start();
	}
	else if(tmp == 'q') {
		stop();
	}
	else if(tmp == 'e') {
		if (error_count <= 2) {
			start_fan();			
		}
	}
	else if(tmp == 'a') {
		stop_fan();
	}
	else if(tmp == 's') {
		char buffer[16];
		sprintf(buffer, "%cSTFO%u|SN%u|%c", 0x02, fan_running ? 1 : 0, generate_sequence_number(), 0x03);
		write_string(buffer);
	}
}

ISR(INT0_vect) {
	while (1);
}

ISR(INT1_vect) {
	interval_sec = interval_sec == 4 ? 1 : 4;
	_delay_ms(70);
}

int main(void)
{	
	reset();	
	while(1) {
		wdt_reset();
	}
}

