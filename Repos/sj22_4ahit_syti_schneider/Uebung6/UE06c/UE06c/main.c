/*
 * UE06c.c
 *
 * Created: 2/17/2023 3:24:08 PM
 * Author : trueberryless
 */ 

#define F_CPU 16000000

#include <avr/io.h>
#include "lcd.h"
#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <math.h>

#define __DELAY_BACKWARD_COMPATIBLE__
#include <util/delay.h>

#define MAX(x, y) (((x) > (y)) ? (x) : (y))
#define MIN(x, y) (((x) < (y)) ? (x) : (y))


int main(void)
{
	// REFS0: VCC verwenden:
	//	AREF als Spannung verwenden:		REFS0 = 0 & REFS1 = 0
	//	VCC verwenden (5V):					REFS0 = 1 & REFS1 = 0
	//	interne Spannung (1.1V):			REFS0 = 1 & REFS1 = 1
	ADMUX |= (1<<REFS0);
	
	// ADEN => Enables ADC
	// ADPSx => Division Factor to get between 50kHz and 200kHz with our 60MHz Elegoo.
	ADCSRA |= (1<<ADEN) | (1<<ADPS0) | (1<<ADPS1) | (1<<ADPS2);
	
	ADMUX &= ~((1<<MUX2) | (1<<MUX3));
	ADMUX |= (1<<MUX0) | (1<<MUX1);
	
	lcd_init(LCD_DISP_ON);
	
    while (1) 
    {
	    
	    // ADSC => Start Conversion
	    ADCSRA |= (1<<ADSC);
	    while(ADCSRA & (1<<ADSC));
		
		double tempK = log(10000.0 * ((1024.0 / ADCW - 1)));
		tempK = 1 / (0.001129148 + (0.000234125 + (0.0000000876741 * tempK * tempK)) * tempK);
		float tempC = tempK - 273.15;
		
		// LCD Ausgabe
		uint8_t buffer[16];
		lcd_clrscr();
		
		sprintf(buffer, "%.3f Grad C", tempC);
		lcd_puts(buffer);
		
		
		_delay_ms(500);
    }
}

