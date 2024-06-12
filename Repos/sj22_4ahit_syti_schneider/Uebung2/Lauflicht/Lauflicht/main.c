/*
 * Lauflicht.c
 *
 * Created: 23.09.2022 14:09:20
 * Author : Felix
 */ 

#define F_CPU 16000000

#include <avr/io.h>

#include <util/delay.h>

int main(void)
{
	// Data Direction Register => Logische Signalflussrichtung
	// 0 = Eingang (default), 1 = Ausgang
	
	// Port D (= PINS 0-7) auf Asugang setzen
	DDRD=0xff;	// 1111 1111 Register im Binärsystem
				// °°°° °°°° PINs des Ports D
				// 7654 3210 PIN-Bezeichnung
	
    /* Replace with your application code */
	
	while (1)
	{
		PORTD=0x01;
		_delay_ms(300);
		PORTD=0x02;
		_delay_ms(300);
		PORTD=0x04;
		_delay_ms(300);
		PORTD=0x08;
		_delay_ms(300);
		
		PORTD=0x10;
		_delay_ms(300);
		PORTD=0x20;
		_delay_ms(300);
		PORTD=0x40;
		_delay_ms(300);
		PORTD=0x80;
		_delay_ms(300);
	}
}

