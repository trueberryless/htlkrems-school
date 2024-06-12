/*
 * Kompetenzcheck.c
 *
 * Created: 12.09.2023 10:07:32
 * Author : trueberryless
 */ 

#define F_CPU 16000000

#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>

#include "lcd.h"

volatile int blinds_opened = 0;
volatile int direction_up = 1;
volatile int cntSec = 1;

int main(void)
{
	// LED config
	DDRB |= (1<<DDB0) | (1<<DDB1);
	
	// LCD config
	lcd_init(LCD_DISP_ON);
	
	// USART config
	// set Baud Rate 9600
	UBRR0 = 103;
	// activate receiving
	UCSR0B |= (1<<RXEN0) | (1<<RXCIE0);
	// setup 8-bit
	UCSR0C |= (1<<UCSZ00) | (1<<UCSZ01);
	
	// ADC config
	// REFS0: Aufgrund der Beschaltung des ADCs.
	// A3: Analoges Signal an PC5 => MUX0 | MUX2
	ADMUX |= (1<<REFS0) | (1<<MUX0) | (1<<MUX2);	
	// ADEN => Enables ADC
	// ADPSx => Division Factor to get between 50kHz and 200kHz with our 60MHz Elegoo.
	ADCSRA |= (1<<ADEN) | (1<<ADPS0) | (1<<ADPS1) | (1<<ADPS2);	
	// ADC Interrupt
	ADCSRA |= (1<<ADIE);
	
	// Button config
	PORTD |= (1<<PORTD2) | (1<<PORTD3);
	EIMSK |= (1<<INT0) | (1<<INT1);
	
	// Timer config
	// CTC Mode
	TCCR1A |= (1<<WGM12);
	
	// Output Compare A and B Interrupt
	TIMSK1 |= (1<<OCIE1A);
	
	sei();
	
	// ADSC => Start Conversion
	ADCSRA |= (1<<ADSC);
	
    /* Replace with your application code */
    while (1) 
    {
    }
}

ISR(TIMER1_COMPA_vect) {
	if (direction_up)
	{
		if (cntSec == 8)
		{
			lcd_putc('|');
			lcd_putc('|');
			PORTB |= (1<<PORTB0);
			PORTB &= ~(1<<PORTB1);
			blinds_opened = 1;
			
			TCCR1B &= ~(1<<CS12); // Timer stoppen
			TCNT1H = 0;
			TCNT1L = 0;
			
			cntSec = 1;
		}
		else {
			cntSec++;
			if (!blinds_opened)
			{
				lcd_putc('|');
				lcd_putc('|');
			}
		}
	}
	else {		
		if (cntSec == 8)
		{
			lcd_command(LCD_MOVE_DISP_LEFT);
			lcd_command(LCD_MOVE_DISP_LEFT);
			PORTB |= (1<<PORTB1);
			PORTB &= ~(1<<PORTB0);
			blinds_opened = 0;
			
			TCCR1B &= ~(1<<CS12); // Timer stoppen
			TCNT1 = 0;
			
			cntSec = 1;
		}
		else {
			cntSec++;
			if (blinds_opened)
			{
				lcd_command(LCD_MOVE_DISP_LEFT);
				lcd_command(LCD_MOVE_DISP_LEFT);
			}
		}
	}
}

ISR(INT0_vect) {
	direction_up = 0;
	OCR1A = 62500;
	// Prescaler 256: 1048.5ms + hiermit wird der Timer gestartet
	TCCR1B |= (1<<CS12);
}

ISR(INT1_vect) {
	direction_up = 1;
	OCR1A = 62500;
	// Prescaler 256: 1048.5ms + hiermit wird der Timer gestartet
	TCCR1B |= (1<<CS12);
}

ISR(ADC_vect) {
	if (blinds_opened == 1) {
		if (ADCW < 100)
		{
			PORTB |= (1<<PORTB1);
			PORTB &= ~(1<<PORTB0);
			blinds_opened = 0;
		}
	}
	
	//char* buffer[16];	
	//sprintf(buffer, "ADCW: %u\nT: %u", ADCW, TCNT1);
	//lcd_clrscr();
	//lcd_puts(buffer);
	
	// ADSC => Start Conversion
	ADCSRA |= (1<<ADSC);
}

ISR(USART_RX_vect) {
	uint8_t tmp;
	tmp = UDR0;
	
	if (tmp == 'd')
	{
		PORTB |= (1<<PORTB1);
		PORTB &= ~(1<<PORTB0);
		blinds_opened = 0;		
	}
	else if (tmp == 'u')
	{
		PORTB |= (1<<PORTB0);
		PORTB &= ~(1<<PORTB1);
		blinds_opened = 1;		
	}
}