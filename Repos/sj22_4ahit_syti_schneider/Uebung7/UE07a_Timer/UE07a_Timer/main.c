/*
 * UE07a_Timer.c
 *
 * Created: 3/3/2023 2:07:35 PM
 * Author : trueberryless
 */ 

#define F_CPU 16000000

#include <avr/io.h>
#include <util/delay.h>
#define __DELAY_BACKWARD_COMPATIBLE__

#include <stdbool.h>

#include <avr/interrupt.h>
#include "lcd.h"

volatile int counter = 0;
volatile int offset = 11719;
volatile int mydelay = 750;


int main(void)
{
	DDRD &= ~(1<<PORTD2);
	PORTD |= (1<<PORTD2);
	
	EIMSK |= (1<<INT0);
	
	
	// normal Mode mit Vorladen
	// activate timer (TCNT1) -> set clock select
	// CS12 -> Prescaler = 1024 -> 4s intervals
	// TCCR1B |= (1<<CS12) | (1<<CS10);
	
	// activate timer 1 overflow interrupt
	// TIMSK1 |= (1<<TOIE1);
	
	// TCNT1=offset;
	
	// CTC Mode
	// activate timer (TCNT1) -> set clock select
	// CS12 -> Prescaler = 1024 -> 4s intervals
	TCCR1B |= (1<<CS12) | (1<<CS10);
	TCCR1B |= (1<<WGM12);
	
	// activate timer 1 output compare A interrupt
	TIMSK1 |= (1<<OCIE1A);	
	
	OCR1A = offset;
	
	sei();
	
	
	lcd_init(LCD_DISP_ON);
	
    /* Replace with your application code */
    while (1) 
    {
		
    }
}

// timer overflow ISR for timer 1
// will be executed when OCR1A == TCNT1 (-> TOP => BOTTOM / 11719 => 0) / around 1000ms

ISR(TIMER1_COMPA_vect) {
	OCR1A=offset;
	counter++;
	
	char buffer[16];
	lcd_clrscr();
	sprintf(buffer, "Value: %us\ndelay: %ums", counter, mydelay);
	lcd_puts(buffer);
}

// Button pressed
ISR(INT0_vect) {
	// EIFR |= (1<<INTF0);
	EIMSK &= ~(1<<INT0);
	_delay_ms(80);
	
	if(!(PIND & (1<<PIND2))) {
		if (mydelay >= 750 * 4)
		{
			mydelay = 750;
			offset = (65536 * mydelay / 4194);
		}
		else {
			mydelay += 750;
			offset = (65536 * mydelay / 4194);
		}
		
		while(!(PIND & (1<<PIND2)));
	}
	
	char buffer[16];
	lcd_clrscr();
	sprintf(buffer, "Value: %us\ndelay: %ums", counter, mydelay);
	lcd_puts(buffer);
	
	EIMSK |= (1<<INT0);
}

