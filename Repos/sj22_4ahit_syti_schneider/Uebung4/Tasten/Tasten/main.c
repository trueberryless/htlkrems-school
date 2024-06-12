/*
 * Tasten.c
 *
 * Created: 14.10.2022 15:09:24
 * Author : Felix
 */ 

#define F_CPU 16000000

#define __DELAY_BACKWARD_COMPATIBLE__

#include <avr/io.h>
#include <util/delay.h>


void delay(void);
void pushButtonAndLED(void);
void switchAndLED(void);
void highEndRunningLED(void);
void pullButton(void);

int8_t flag = 0;
int speed = 300;


int main(void)
{
	DDRD = 0xFF;
	
	DDRC &= ~(1<<DDC0);
	DDRC &= ~(1<<DDC1);
	DDRC &= ~(1<<DDC2);
	
	PORTD = 0x00;
	
	PORTC |= (1<<PORTC0);
	PORTC |= (1<<PORTC1);
	PORTC |= (1<<PORTC2);
	
	while (1)
	{
		pullButton();
	}
}

void delay(void) {
	_delay_ms(speed);
}

void pushButtonAndLED(void) {
	if (PINC & (1<<PINC0))
	{
		PORTD = 0xff;
	}
	else {		
		PORTD = 0x00;
	}
}

void switchAndLED(void) {
	
	if (PINC & (1<<PINC0))
	{		
		PORTD ^= (1<<PORTD1);
		while (PINC & (1<<PINC0))
		{
			_delay_ms(5);			
		}
	}
	
}

void highEndRunningLED(void) {
	PORTD = PORTD << 1;
	if (PORTD == 0x00)
	{
		PORTD = 0x01;
	}
}

void pullButton(void) {
	if (!(PINC & (1<<PINC0)))
	{
		speed = 700;
	}
	if (!(PINC & (1<<PINC1)))
	{
		speed = 400;
	}
	if (!(PINC & (1<<PINC2)))
	{
		speed = 100;
	}
	delay();
	highEndRunningLED();
}

