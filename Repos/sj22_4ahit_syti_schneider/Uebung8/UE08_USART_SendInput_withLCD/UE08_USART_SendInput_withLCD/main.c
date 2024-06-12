/*
 * UE08_USART_SendInput_withLCD.c
 *
 * Created: 5/5/2023 3:06:40 PM
 * Author : trueberryless
 */ 

#define F_CPU 16000000

#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>
#include "lcd.h"

void write_char(char str);
void write_string(char *arr);

volatile char message[16];
volatile int index = 0;

int main(void)
{
	// Baud Rate auf 9600 setzen
	UBRR0 = 103;
	
	// Senden aktivieren
	UCSR0B |= (1<<TXEN0) | (1<<RXEN0) | (1<<RXCIE0);
	
	// 8-Datenbit einstellen
	UCSR0C |= (1<<UCSZ00) | (1<<UCSZ01);
	
	// DDRC &= ~((1<<PORTC3) | (1<<PORTC4) | (1<<PORTC5));
	PORTC |= (1<<PORTC3) | (1<<PORTC4) | (1<<PORTC5);
	
	PCICR |= (1<<PCIE1);
	PCMSK1 |= (1<<PCINT11) | (1<<PCINT12) | (1<<PCINT13);
	
	sei();
	
	lcd_init(LCD_DISP_ON);
	lcd_clrscr();
	
	message[0] = 65;
	
	char* buffer[16];
	
	sprintf(buffer, "%s", message);
	lcd_clrscr();
	lcd_puts(buffer);
	
    /* Replace with your application code */
    while (1) 
    {
		
    }
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
	UDR0="\r\n";
}

ISR (PCINT1_vect) {	
	if (!(PINC & (1<<PINC5)))
	{
		message[index]++;
		if (message[index] > 90)
		{
			message[index] = 65;
		}
	}
	else if (!(PINC & (1<<PINC4)))
	{
		if (index < 16)
		{
			index++;
			message[index] = 65;
		}
	}
	else if (!(PINC & (1<<PINC3)))
	{
		write_string(message);
	}
	
	char* buffer[16];
	
	sprintf(buffer, "%s", message);
	lcd_clrscr();
	lcd_puts(buffer);
	
	_delay_ms(100);
}

