/*
 * Testbeispiel.c
 *
 * Created: 12.10.2022 10:09:19
 * Author : Felix
 */ 

#define F_CPU 16000000

#include <avr/io.h>
#include <util/delay.h>

int main(void) {
	DDRD=0xFF;

	PORTD |= ((1<<0) | (1<<1));

	while(1) {
		PORTD <<= 1;
		if(PORTD == (1<<7)) {
			PORTD |= (1<<0);
		}
		if(PORTD == (1<<1)) {
			PORTD |= (1<<0);
		}
		
		_delay_ms(500);
	}
}

//#define F_CPU 16000000
//
//#include <avr/io.h>
//
//#define __DELAY_BACKWARD_COMPATIBLE__
//#include <util/delay.h>
//
//void delay(void);
//
//
//int main(void)
//{
	//DDRD = 0xFF;
	//
	//PORTD=0x01;
	//PORTD|= (1<<1);
	//PORTD<<=2;
	//PORTD&= ((1<<3) | (1<<4));
	//PORTD|=0x01;
	//
	//while (1)
	//{
		//
	//}
//}
//
//void delay(void) {
	//_delay_ms(300);
//}

