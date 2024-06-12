/*
 * UE08_USART_PingPong.c
 *
 * Created: 26.05.2023 14:14:44
 * Author : trueberryless
 */ 

#define F_CPU 16000000

#include <avr/io.h>

#include <avr/io.h>

#define __DELAY_BACKWARD_COMPATIBLE__
#include <util/delay.h>

#include <avr/interrupt.h>
#include <string.h>
#include <stdbool.h>

#include "lcd.h"

void write_char(char str);

volatile char status = 'n';

// status codes:
// n: new game; game has not started yet
// t: my turn, ball moves on the screen
// f: my first turn of the new game
// u: your turn, ball moves on your screen
// l: i lost the game
// w: i won the game

// e: ball exits my screen
// some number: speed of ball

volatile char screen[16];

volatile bool left_player;

volatile bool ball_changed_dir = false;

volatile uint8_t position = 0;


int main(void)
{
	// Baud Rate auf 9600 setzen
	UBRR0 = 103;
	
	// Senden aktivieren
	UCSR0B |= (1<<TXEN0) | (1<<RXEN0) | (1<<RXCIE0);
	
	// 8-Datenbit einstellen
	UCSR0C |= (1<<UCSZ00) | (1<<UCSZ01);
	
	PORTC |= (1<<PORTC5);
	
	PCICR |= (1<<PCIE1);
	PCMSK1 |= (1<<PCINT13);
	
	sei();
	
	lcd_init(LCD_DISP_ON);
	lcd_clrscr();
	
	
    /* Replace with your application code */
    while (1) 
    {
		if (status == 't')
		{
			if (ball_changed_dir) {
				if (left_player)
				{
					lcd_command(LCD_MOVE_DISP_RIGHT);
				} 
				else
				{
					lcd_command(LCD_MOVE_DISP_LEFT);
				}
				position--;
			}
			else 
			{
				if (left_player)
				{
					lcd_command(LCD_MOVE_DISP_LEFT);
				}
				else
				{
					lcd_command(LCD_MOVE_DISP_RIGHT);
				}	
				position++;		
			}
			
			if (position <= -1)
			{
				write_char('e');
				status = 'u';
			}
			
			if (position >= 16)
			{
				write_char('l');
				status = 'l';
			}
			
			_delay_ms(100);
		}
    }
}

void write_char(char str) {
	while (!(UCSR0A & (1<<UDRE0)));
	UDR0=str;
}

ISR (PCINT1_vect) {
	if (!(PINC & (1<<PINC5)))
	{
		switch(status) {
			case 'n':
				write_char('f');
				status = 't';
				lcd_puts("               0");
				left_player = true;
				break;
			case 't':
				ball_changed_dir = true;
				break;
		}
	}
	
	_delay_ms(500);
}

ISR(USART_RX_vect) {
	uint8_t tmp;
	tmp = UDR0;
	lcd_putc(tmp);
	_delay_ms(1000);
	
	switch(tmp) {
		case 'n':
			status = 'n'; 
			break;
		case 'f':
			status = 'u';
			left_player = false;
			break;
		case 't':
			status = 'u';
			break;
		case 'e':
			status = 't';
			lcd_puts("t");
			_delay_ms(1000);
			
			if (left_player)
			{
				lcd_puts("               0");
			} 
			else
			{
				lcd_puts("0               ");
			}
			break;
		case 'l':
			status = 'w';
			break;
			
	}
}

