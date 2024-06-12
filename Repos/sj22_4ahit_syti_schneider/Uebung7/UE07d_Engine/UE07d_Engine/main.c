/*
 * UE07d_Engine.c
 *
 * Created: 4/14/2023 2:11:02 PM
 * Author : trueberryless
 */ 

#define F_CPU 16000000

#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>

#define MAX(x, y) (((x) > (y)) ? (x) : (y))
#define MIN(x, y) (((x) < (y)) ? (x) : (y))

int main(void)
{
	// PB1 als Ausgang konfigurieren
	DDRB |= (1<<DDB1);
	
	// PB0 für Motor EN / Disable
	DDRB |= (1<<DDB0);

	
	// WGM10 und WGM12: Fast PWM; 8-bit aktivieren (MAX -> 255)
	//TCCR1A |= (1<<WGM10);
	//TCCR1B |= (1<<WGM12);
	
	
	// WGM10: Phase Correct PWM; 8-bit aktivieren (MAX -> 255)
	TCCR1A |= (1<<WGM10);
	
	// CS12: 256er Prescaler setzen => PWM mit 122 Hz
	TCCR1B |= (1<<CS10) | (1<<CS11);
	
	// non-inverting Mode einstellen
	TCCR1A |= (1<<COM1A1);
	
	// REFS0: Aufgrund der Beschaltung des ADCs.
	// A3: Analoges Signal an PC3 => MUX0 | MUX1
	ADMUX |= (1<<REFS0) | (1<<MUX0) | (1<<MUX1);
	
	// ADEN => Enables ADC
	// ADPSx => Division Factor to get between 50kHz and 200kHz with our 60MHz Elegoo.
	ADCSRA |= (1<<ADEN) | (1<<ADPS0) | (1<<ADPS1) | (1<<ADPS2);
	
	ADCSRA |= (1<<ADIE);
	
	// ADSC => Start Conversion
	ADCSRA |= (1<<ADSC);
	
	sei();
	
    /* Replace with your application code */
    while (1) 
    {
		//OCR1A = 65;				// Pulsweite DC von ca. 25%
		//_delay_ms(2000);
		//OCR1A = 123;			// Pulsweite DC von ca. 50%
		//_delay_ms(2000);
		//OCR1A = 255;			// Pulsweite DC von ca. 100%
		//_delay_ms(2000);
    }
}

ISR(ADC_vect) {	
	double percent = ADCW / (1023 / 100);
	
	if (percent < 23)
	{
		PORTB &= ~(1<<PORTB0);		
	}
	else {
		PORTB |= (1<<PORTB0);		
	}
	
	OCR1A = MAX(ADCW / (1023 / 255), 255 / 100 * 23);
	
	// ADSC => Start Conversion
	ADCSRA |= (1<<ADSC);
}

