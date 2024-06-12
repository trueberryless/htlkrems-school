/*
 * UE08.c
 *
 * Created: 18.11.2022 14:24:33
 * Author : trueberryless
 */ 

#define F_CPU 16000000

#include <avr/io.h>
#include <string.h>
#include <avr/interrupt.h>
#include <stdbool.h>
#include <stdio.h>
#include "lcd.h"

#define __DELAY_BACKWARD_COMPATIBLE__
#include <util/delay.h>

void delay(void);
void RunText(char* text);
void StopWatch(void);
void StopWatchInterrupts(void);

volatile uint32_t sec = 0;
volatile char* buffer[16];
volatile bool isWatching = false;



int main(void)
{	
	// RunText("Hello World!");
	// StopWatch();
	StopWatchInterrupts();
}

void RunText(char* text) {
	lcd_init(LCD_DISP_ON);
	
	lcd_command(LCD_MOVE_DISP_LEFT); // nach left moven
	lcd_command(LCD_ENTRY_INC_SHIFT); // ltr mode
	
	while (1)
	{
		lcd_clrscr();
		lcd_gotoxy(16, 0);
		for (int i = 0; i < strlen(text); i++)
		{
			lcd_putc(text[i]);
			delay();
		}
		
		for (int i = 0; i < 16; i++)
		{
			lcd_command(LCD_MOVE_DISP_LEFT);
			delay();
		}
	}
}

void StopWatch() {
	lcd_init(LCD_DISP_ON);
	lcd_clrscr();	
	
	DDRD &= ~(1<<PORTD2) | ~(1<<PORTD3);
	PORTD |= (1<<PORTD2) | (1<<PORTD3);
	
	
	while (1)
	{
		
		if(isWatching) {
			sec += 1;
		}
		
		if(!(PIND & (1<<PIND2))){
			
			sec = 0;			
			isWatching = true;
			
		}
		
		if (!(PIND & (1<<PIND3)))
		{
			
			isWatching = false;
			
		}
		
		_delay_ms(1000);
		
		sprintf(buffer, "time: %u sec", sec);
		lcd_clrscr();
		lcd_puts(buffer);
	}
}

void StopWatchInterrupts() {
	// direkt externe Interrupts	
	// EIMSK |= (1<<INT0) | (1<<INT1);
	
	// gruppenbasierte externe Interrupts
	PCICR |= (1<<PCIE2);
	PCMSK2 |= (1<<PCINT18) | (1<<PCINT19);
	
	sei();
	
	lcd_init(LCD_DISP_ON);
	lcd_clrscr();
	
	DDRD &= ~(1<<PORTD2) | ~(1<<PORTD3);
	PORTD |= (1<<PORTD2) | (1<<PORTD3);
	
	isWatching = true;
	sec = 0;
	
	while (1)
	{		
		_delay_ms(1000);
		
		if(isWatching) {
			sec += 1;
		}
		
		lcd_puts("Test");
		
		int d = sec/60/60/24;
		int h = sec/60/60-(d*24);
		int m = sec/60-(h*60)-(d*24*60);
		int s = sec-(m*60)-(h*60*60)-(d*24*60*60);
		
		char time[10];
		if(d < 100) {
			sprintf(time, "%02u:%02u:%02u:%02u", d, h, m, s);
		}
		else if(d < 100000) {
			sprintf(time, "%02u:%02u:%02u", d, h, m);			
		}
		else {
			sprintf(time, "%02u:%02u", d, h);			
		}
		sprintf(buffer, "time:%10s", time);
		lcd_clrscr();
		lcd_puts(buffer);
	}	
}

// direkte externe Interrupts PORTD / PIN2
ISR (INT0_vect) {
	sec = 0;
	isWatching = true;
}

// direkte externe Interrupts PORTD / PIN3
ISR (INT1_vect) {
	isWatching = false;
}

// gruppenbasierte externe Interrupts PORTD
ISR (PCINT2_vect) {
	if(!(PIND & (1<<PIND2))){
		sec = 0;
		isWatching = true;
		lcd_puts("Test");
	}
	else if (!(PIND & (1<<PIND3)))
	{
		isWatching = false;
	}
}

void delay(void) {
	_delay_ms(600);
}

