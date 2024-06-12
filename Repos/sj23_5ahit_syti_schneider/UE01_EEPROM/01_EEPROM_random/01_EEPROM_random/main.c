/*
 * 01_EEPROM_random.c
 *
 * Created: 19.09.2023 10:52:54
 * Author : trueberryless
 */ 

#define F_CPU 16000000

#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>
#include <stdlib.h>
#include <avr/eeprom.h>
#include "lcd.h";

#define RAND_MAX 0xFF


volatile uint8_t random_adc_value = 1;
volatile int random_value;

int main(void)
{
	// ADC config
	ADMUX |= (1<<REFS0);
	ADMUX |= (1<<MUX0) | (1<<MUX1);
	ADCSRA |= (1<<ADATE);
	ADCSRA |= (1<<ADEN) | (1<<ADIE);
	ADCSRA |= (1<<ADPS0) | (1<<ADPS1) | (1<<ADPS2);
	
	ADCSRA |= (1<<ADSC);
	
	// LCD
	lcd_init(LCD_DISP_ON);
	
	// Tasten
	DDRD &= ~((1<<DDD2) | (1<DDD3));
	PORTD |= (1<<PORTD2) | (1<<PORTD3);
	EIMSK |= (1<<INT0) | (1<<INT1);
	
	sei();
	
	uint16_t current_value = eeprom_read_word(0x00);
	random_value = current_value;
	
	char buffer[16];
	sprintf(buffer, "%u loaded!", current_value);
	lcd_clrscr();
	lcd_puts(buffer);
	_delay_ms(1000);
	
    /* Replace with your application code */
    while (1) 
    {
    }
}

ISR(ADC_vect) {
	random_adc_value = ADCW;
}

ISR (INT0_vect) {
	srand(random_adc_value);
	random_value = rand();
	
	char buffer[16];
	sprintf(buffer, "%u", random_value);
	lcd_clrscr();
	lcd_puts(buffer);
	_delay_ms(200);
}

ISR (INT1_vect) {
	eeprom_write_word(0x00, random_value);	
	
	char buffer[16];
	sprintf(buffer, "%u saved!", random_value);
	lcd_clrscr();
	lcd_puts(buffer);
	_delay_ms(1000);
}
