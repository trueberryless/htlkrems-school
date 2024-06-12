/*
 * adc.c
 *
 * Created: 15.01.2024 09:17:18
 *  Author: Homer Simpson
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/atomic.h>

// Variablen, die nur in dieser Datei gebraucht werden, mit static deklarieren
static volatile uint16_t adc = 0;

void acd_init(){
	ADMUX |= (1<<MUX0) | (1<<MUX2);
	ADMUX |= (1<<REFS0);
	
	ADCSRA |= (1<<ADEN) | (1<<ADIE) | (1<<ADATE);
	ADCSRA |= (1<<ADPS0) | (1<<ADPS1) | (1<<ADPS2);
	
	sei();
}

void adc_start_conversion(){
	ADCSRA |= (1<<ADSC);
}

float adc_get_water_level(){
	float water_level;
	ATOMIC_BLOCK(ATOMIC_FORCEON) {
		
		float voltage = adc * 5 / 1024;
		water_level = voltage * 0.5 + 2.5;
	}

	return water_level;
}

ISR(ADC_vect) {
	adc = ADCW;
}