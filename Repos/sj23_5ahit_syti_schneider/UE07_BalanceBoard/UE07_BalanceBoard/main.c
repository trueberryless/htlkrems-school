/*
 * UE07_BalanceBoard.c
 *
 * Created: 07.04.2024 09:58:29
 * Author : trueberryless
 */ 

#define F_CPU 16000000UL

#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>
#include "uart.h"

volatile uint8_t current_sensor = 0;
volatile float sensor_values[4] = { 0.0f, 0.0f, 0.0f, 0.0f };
volatile size_t sensor_count = sizeof(sensor_values) / sizeof(sensor_values[0]);

void timer_init(void) {
	// CTC Mode
	TCCR1B |= (1<<WGM12);
	TIMSK1 |= (1<<OCIE1A);
	
	if (sensor_count < 4)
	{
		// Prescaler 256
		TCCR1B |= (1<<CS12);
		OCR1A = (125 / sensor_count) * (F_CPU / 256);
	}
	else {
		// Prescaler 64
		TCCR1B |= (1<<CS10) | (1<<CS11);
		OCR1A = (0.125 / sensor_count) * (F_CPU / 64);
	}
}

void adc_init(void) {
	ADMUX |= (1<<REFS0);	
	ADCSRA |= (1<<ADPS0) | (1<<ADPS1) | (1<<ADPS2);
	ADCSRA |= (1<<ADEN) | (1<<ADIE);
}

void motor_init(void) {
	DDRB |= (1<<DDB0) | (1<<DDB1) | (1<<DDB2) | (1<<DDB3);
}


int main(void)
{
	uart_init(UART_BAUD_SELECT(9600, F_CPU));
	adc_init();
	timer_init();
	motor_init();
	
	sei();
	
    while (1) {
		unsigned int c = uart_getc();
		
		if ((unsigned char)c == "1")
		{
			PORTB |= (1<<PORTB0);
		}
		if ((unsigned char)c == "2")
		{
			PORTB |= (1<<PORTB1);
		}
		if ((unsigned char)c == "3")
		{
			PORTB |= (1<<PORTB2);
		}
		if ((unsigned char)c == "4")
		{
			PORTB |= (1<<PORTB3);
		}
		
		_delay_ms(500);
		
		PORTB &= ~((1<<PORTB0) | (1<<PORTB1) | (1<<PORTB2) | (1<<PORTB3));
	}
}

ISR(TIMER1_COMPA_vect) {
	for (int i = 0; i < sensor_count; i++)
	{
		if (current_sensor == i)
		{
			ADMUX &= ~((1<<MUX0) | (1<<MUX1) | (1<<MUX2) | (1<<MUX3));
			ADMUX |= current_sensor;
			ADCSRA |= (1<<ADSC);
		}
	}
}

ISR(ADC_vect) {
	sensor_values[current_sensor] = ADCW / 2 * 2.54;
	current_sensor++;
	current_sensor = current_sensor % sensor_count;
	
	char buffer[50];
	sprintf(buffer, "%cS1%.2f|S2%.2f|S3%.2f|S4%.2f%c", 0x02, sensor_values[0], sensor_values[1], sensor_values[2], sensor_values[3], 0x03);
	uart_puts(buffer);
}