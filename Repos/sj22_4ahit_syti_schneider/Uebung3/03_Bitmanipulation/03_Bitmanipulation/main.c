/*
 * 03_Bitmanipulation.c
 *
 * Created: 30.09.2022 14:49:05
 * Author : Felix
 */ 

#define F_CPU 16000000

#include <avr/io.h>
#include <util/delay.h>

void delay(void);
void lauflicht1(void);
void lauflicht2(void);
void lauflicht3(void);
void lauflicht4(void);
void lauflicht5(void);

uint8_t flag=0;

int main(void)
{
	DDRD = 0xFF;
	PORTD = 0x00;
	
	while (1)
	{
		lauflicht5();
	}
}

void lauflicht1(void) {
	// LED 0
	PORTD |= 0x01; // 0000 0001
	delay();
	PORTD &= 0xFE; // 1111 1110
	
	// LED 1
	PORTD |= 0x02; // 0000 0010
	delay();
	PORTD &= 0xFD; // 1111 1101
	
	// LED 2
	PORTD |= 0x04; // 0000 0100
	delay();
	PORTD &= 0xFB; // 1111 1011
	
	// LED 3
	PORTD |= 0x08; // 0000 1000
	delay();
	PORTD &= 0xF7; // 1111 0111	
}

void lauflicht2(void) {	
	// LED 0
	PORTD |= (1<<0); // 0000 0001
	delay();
	PORTD &= ~(1<<0); // 1111 1110
	
	// LED 1
	PORTD |= (1<<1); // 0000 0010
	delay();
	PORTD &= ~(1<<1); // 1111 1101
	
	// LED 2
	PORTD |= (1<<2); // 0000 0100
	delay();
	PORTD &= ~(1<<2); // 1111 1011
	
	// LED 3
	PORTD |= (1<<3); // 0000 1000
	delay();
	PORTD &= ~(1<<3); // 1111 0111
}

void lauflicht3(void) {
	// LED 0
	PORTD |= (1<<PORTD0); // 0000 0001
	delay();
	PORTD &= ~(1<<PORTD0); // 1111 1110
	
	// LED 1
	PORTD |= (1<<PORTD1); // 0000 0010
	delay();
	PORTD &= ~(1<<PORTD1); // 1111 1101
	
	// LED 2
	PORTD |= (1<<PORTD2); // 0000 0100
	delay();
	PORTD &= ~(1<<PORTD2); // 1111 1011
	
	// LED 3
	PORTD |= (1<<PORTD3); // 0000 1000
	delay();
	PORTD &= ~(1<<PORTD3); // 1111 0111
}

void lauflicht4(void) {
	PORTD = PORTD << 1;
	if (PORTD == 0x00)
	{
		PORTD = 0x01;
	}
	delay();
}

void lauflicht5(void) {
	if (flag == 1)
	{
		PORTD = PORTD<<1;
	}
	
	else
	{
		PORTD = PORTD>>1;
	} 
	
	if (PORTD == (1<<PORTD0) | PORTD == (1<<PORTD7))
	{
		flag = ~flag;
	}
	
	if (PORTD == (0<<0))
	{
		PORTD = (1<<PORTD0);
		flag=1;
	}
	delay();
}

void delay(void) {
	_delay_ms(100);
}


