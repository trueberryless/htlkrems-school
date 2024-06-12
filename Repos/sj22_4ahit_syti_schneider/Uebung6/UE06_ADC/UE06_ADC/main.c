/*
 * UE06_ADC.c
 *
 * Created: 1/13/2023 2:30:45 PM
 * Author : trueberryless
 */ 
#define F_CPU 16000000

#include <avr/io.h>
#include <string.h>
// #include <avr/interrupt.h>
#include <stdbool.h>
#include <stdio.h>
#include <avr/interrupt.h>
#include "lcd.h"

#define __DELAY_BACKWARD_COMPATIBLE__
#include <util/delay.h>

#define U_REF 5.0
#define ADC_RES 1024.0

float ConvertADCtoVolt(float adc);


int main(void)
{
	// REFS0: Aufgrund der Beschaltung des ADCs.
	// A3: Analoges Signal an PC3 => MUX0 | MUX1
    ADMUX |= (1<<REFS0) | (1<<MUX0) | (1<<MUX1);
	
	// ADEN => Enables ADC
	// ADPSx => Division Factor to get between 50kHz and 200kHz with our 60MHz Elegoo.
	ADCSRA |= (1<<ADEN) | (1<<ADPS0) | (1<<ADPS1) | (1<<ADPS2) | (1<<ADIE);
	
	DDRB |= (1<<PORTB0) | (1<<PORTB1) | (1<<PORTB2);
	
	sei();
	
	lcd_init(LCD_DISP_ON);
	
	// ADSC => Start Conversion
	ADCSRA |= (1<<ADSC);
	
    while (1) 
    {	
		// wait until ADSC-Bit is 0 again and the Conversion of the Analog Signal is over.
		// BIT Polling
		// while(ADCSRA & (1<<ADSC));	
    }
}

float ConvertADCtoVolt(float adc) {
	return (adc / ADC_RES) * U_REF;
}

ISR(ADC_vect) {
	float voltageA3 = ConvertADCtoVolt(ADCW);
	char* buffer[16];
	
	sprintf(buffer, "Volt: %.2f", voltageA3);
	
	lcd_clrscr();
	lcd_puts(buffer);
	
	PORTB &= ~((1<<PORTB0) | (1<<PORTB1) | (1<<PORTB2));
	if (voltageA3 > 4.0)
	{
		PORTB |= (1<<PORTB0);
	}
	else if (voltageA3 < 2.0)
	{
		PORTB |= (1<<PORTB1);
	}
	else
	{
		PORTB |= (1<<PORTB2);
	}
	
	_delay_ms(500);
	
	// ADSC => Start Conversion
	ADCSRA |= (1<<ADSC);
}

