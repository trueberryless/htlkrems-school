/*
 * UE7b_Timer.c
 *
 * Created: 31.03.2023 14:17:18
 * Author : trueberryless
 */ 

#define F_CPU 16000000

#include <avr/io.h>
#include <util/delay.h>
#define _DELAY_BACKWARDCOMPATIBLE

#include <stdbool.h>

#include <avr/interrupt.h>
#include "lcd.h"

volatile int mydelay = 750;

int main(void)
{

    DDRD &= ~(1<<PORTD2);
    PORTD |= (1<<PORTD2);

    DDRB |= (1<<PORTB1);

    EIMSK |= (1<<INT0);


    // activate timer (TCNT1) -> set clock select
    // CS12 & CS10 -> Prescaler = 1024; im CTC Mode
    TCCR1B |= (1<<CS12) | (1<<CS10) | (1<<WGM12);

    TCCR1A |= (1<<COM1A0);

    // Timer 1 Output Compare Interrupt für Kanal A akivieren
    TIMSK1 |= (1<<OCIE1A);

    // Top-Wert für Timer 1, Kanal A auf 750ms gesetzt => ISR ausgeführt!
    OCR1A = 11719;

    sei();

    lcd_init(LCD_DISP_ON);

    while (1) 
    {
    }
}

ISR (TIMER1_COMPA_vect) {

    char buffer[16];
    lcd_clrscr();
    sprintf(buffer, "delay:%ums", (OCR1A/11719) 750);
    lcd_puts(buffer);
}

ISR (INT0_vect) {
    EIMSK &= ~(1<<INT0);
    _delay_ms(80);
    if (!(PIND & (1<<PIND2)))
    {
        OCR1A = OCR1A + 11719;
        if (OCR1A > 50000)
        {
            OCR1A = 11719;
        }
        while (!(PIND & (1<<PIND2)));
    }


    char buffer[16];
    lcd_clrscr();
    sprintf(buffer, "delay:%ums", (OCR1A/11719) * 750);
    lcd_puts(buffer);

    EIMSK |= (1<<INT0);

}