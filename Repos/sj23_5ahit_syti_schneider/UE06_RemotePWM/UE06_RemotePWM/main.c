/*
 * UE06_RemotePWM.c
 *
 * Created: 12.03.2024 10:31:37
 * Author : trueberryless
 */ 

#define F_CPU 16000000UL

#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>
#include <stdio.h>
#include <stdlib.h>

#include "lcd.h"
#include "uart.h"

void pwm_init(void);
#define CALC_OCR1A(DC) ((int)(1.25 * (DC) + 1))
#define MIN(a, b) ((a) < (b) ? (a) : (b))
#define MAX(a, b) ((a) > (b) ? (a) : (b))


int read_string(unsigned char* input);
void wait_for_stx(void);

int main(void)
{
	lcd_init(LCD_DISP_ON);
	uart_init(UART_BAUD_SELECT(9600, F_CPU));
	pwm_init();
	
	sei();
	
	while (1)
	{
		unsigned char buffer[11] = {0};
		
		lcd_clrscr();
		lcd_puts("ready ...");

		wait_for_stx();
		int status = read_string(buffer);

		if (status == 0) {
			lcd_clrscr();
			lcd_puts("read message\n");

			uart_putc(0x06);
			
			double dc = atof(&buffer[5]);

			char b[10];
			sprintf(b, "%i", (int)dc);
			lcd_puts(b);

			OCR1A = CALC_OCR1A(MIN(100, MAX(0, dc)));
		}
		_delay_ms(2000);
	}
}

void pwm_init(void)
{
	// Fast PWM mit ICR1 als TOP Wert
	TCCR1A |= (1<<WGM11);
	TCCR1B |= (1<<WGM12) | (1<<WGM13);
	
	ICR1 = 124;
	
	// PB1 Ausgang
	DDRB |= (1<<DDB1);
	
	// Prescaler 64
	TCCR1B |= (1<<CS10) | (1<<CS11);
	
	// non-inverting Mode einstellen
	TCCR1A |= (1<<COM1A1);
}

// -1 == Error oder ETX
int read_string(unsigned char* buffer) {
	for	(int i = 0; i < 10;) {
		unsigned int c = uart_getc();

		if(c & UART_NO_DATA) {
			continue;
		}
		
		if (c & UART_FRAME_ERROR || c & UART_OVERRUN_ERROR || c & UART_BUFFER_OVERFLOW)
		return -1;
		
		if (c == 0x0003)
		return -1;
		
		buffer[i] = (unsigned char)c;
		i++;
	}
	
	return 0;
}

void wait_for_stx(void) {
	while(1) {
		unsigned int tmp = uart_getc();
		if(tmp == 0x0002)
		break;
	}
}