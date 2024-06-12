/*
 * UE06b.c
 *
 * Created: 2/3/2023 2:18:41 PM
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

struct Joystick {
	int x;
	int y;
	bool sw;
};

void OutputXY(void);
void MoveX(void);

int main(void)
{
	MoveX();
}

void OutputXY() {
	// REFS0: Aufgrund der Beschaltung des ADCs.
	ADMUX |= (1<<REFS0);
	
	// ADEN => Enables ADC
	// ADPSx => Division Factor to get between 50kHz and 200kHz with our 60MHz Elegoo.
	ADCSRA |= (1<<ADEN) | (1<<ADPS0) | (1<<ADPS1) | (1<<ADPS2);
	
	lcd_init(LCD_DISP_ON);
	
	struct Joystick joystick;
	
	while (1)
	{
		ADMUX &= ~((1<<MUX0) | (1<<MUX1) | (1<<MUX3));
		ADMUX |= (1<<MUX2);
		
		// ADSC => Start Conversion
		ADCSRA |= (1<<ADSC);
		while(ADCSRA & (1<<ADSC));
		
		joystick.x = ADCW;
		
		ADMUX &= ~((1<<MUX1) | (1<<MUX3));
		ADMUX |= (1<<MUX0) | (1<<MUX2);
		
		// ADSC => Start Conversion
		ADCSRA |= (1<<ADSC);
		while(ADCSRA & (1<<ADSC));
		
		joystick.y = ADCW;
		
		// LCD Ausgabe
		uint8_t buffer[16];
		lcd_clrscr();
		
		sprintf(buffer, "x: %u\ny: %u", joystick.x, joystick.y);
		lcd_puts(buffer);
		
		_delay_ms(500);
		
	}
}

void MoveX() {
	// REFS0: Aufgrund der Beschaltung des ADCs.
	ADMUX |= (1<<REFS0);
	
	// ADEN => Enables ADC
	// ADPSx => Division Factor to get between 50kHz and 200kHz with our 60MHz Elegoo.
	ADCSRA |= (1<<ADEN) | (1<<ADPS0) | (1<<ADPS1) | (1<<ADPS2);
	
	lcd_init(LCD_DISP_ON);
	
	struct Joystick joystick;
	int x = 8;
	int y = 0;
	
	bool inverted_controls = true;
	
	uint8_t ms = 150;
	
	while (1)
	{
		// GET VALUES FROM JOYSTICK
		ADMUX &= ~((1<<MUX0) | (1<<MUX1) | (1<<MUX3));
		ADMUX |= (1<<MUX2);
		
		// ADSC => Start Conversion
		ADCSRA |= (1<<ADSC);
		while(ADCSRA & (1<<ADSC));
		
		joystick.x = ADCW;
		
		ADMUX &= ~((1<<MUX1) | (1<<MUX3));
		ADMUX |= (1<<MUX0) | (1<<MUX2);
		
		// ADSC => Start Conversion
		ADCSRA |= (1<<ADSC);
		while(ADCSRA & (1<<ADSC));
		
		joystick.y = ADCW;
		
		// PROCESS VALUES
		
		if (joystick.x > 550)
		{
			x = ((inverted_controls == false) ? MIN(x + 1, 15) : MAX(x - 1, 0));
		}
		
		if (joystick.x < 450)
		{
			x = ((inverted_controls == false) ? MAX(x - 1, 0) : MIN(x + 1, 15));
		}
		
		if (joystick.y > 550)
		{
			y = ((inverted_controls == false) ? MIN(y + 1, 3) : MAX(y - 1, 0));
		}
		
		if (joystick.y < 450)
		{
			y = ((inverted_controls == false) ? MAX(y - 1, 0) : MIN(y + 1, 3));
		}
		
		lcd_clrscr();
		lcd_gotoxy(x, y / 2);
		if (y % 2 == 0)
		{
			lcd_putc('-');
		}
		else {
			lcd_putc('_');			
		}
		
		// ms = round(200000 / abs(500 - joystick.x));
		
		_delay_ms(ms);
	}
}



