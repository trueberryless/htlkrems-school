/*
 * UE06d_Temperature.c
 *
 * Created: 2/24/2023 2:47:33 PM
 * Author : trueberryless
 */ 

#define F_CPU 16000000

#include <avr/io.h>
#include <stdio.h>
#include <stdlib.h>
#include <avr/io.h>
#include <avr/interrupt.h>

#define __DELAY_BACKWARD_COMPATIBLE__
#include <util/delay.h>

#include "lcd.h"
#include "dht.h"


int main(void)
{
    char buffer[16];

    int8_t temperature = 0;
    int8_t humidity = 0;
	
    lcd_init(LCD_DISP_ON);

    while(1) {
	    if(dht_gettemperaturehumidity(&temperature, &humidity) != -1) {
			sprintf(buffer, "T: %u C, H: %u", temperature, humidity);
			lcd_puts(buffer);
			lcd_puts("%");
		} else {
			lcd_puts("Error");
	    }
	    _delay_ms(2000);
		lcd_clrscr();
    }
}

