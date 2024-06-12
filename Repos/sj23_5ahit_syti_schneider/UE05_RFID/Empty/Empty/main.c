/*
 * Empty.c
 *
 * Created: 27.02.2024 10:56:29
 * Author : trueberryless
 */ 

#include <avr/io.h>
#include "lcd.h"


int main(void)
{
	lcd_init(LCD_DISP_ON);
	lcd_puts("Works");
    /* Replace with your application code */
    while (1) 
    {
    }
}

