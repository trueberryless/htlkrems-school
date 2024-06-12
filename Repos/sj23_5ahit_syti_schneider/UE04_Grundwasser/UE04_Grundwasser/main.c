/*
 * UE04_Grundwasser.c
 *
 * Created: 16.01.2024 10:37:01
 * Author : trueberryless
 */ 

#define F_CPU 16000000UL

#define WATERLEVEL_ALARM_HEIGHT 3.5

#include <avr/io.h>
#include <util/delay.h>
#include <stdio.h>
#include "dbmanage.h"
#include "lcd.h"
#include "adc.h"

int main(void)
{
	float currentWaterLevel = 0;
	char txtbuffer[20];
	
	lcd_init(LCD_DISP_ON);

	acd_init();
	adc_start_conversion();
	
	/* Replace with your application code */
	while (1)
	{
		_delay_ms(1000); // Statt Timer verwenden wir die Delay, weil es in diesem Fall egal ist!

		// Your Code
		currentWaterLevel = adc_get_water_level();
		
		sprintf(txtbuffer, "%.2f", currentWaterLevel);
		lcd_clrscr();
		lcd_puts(txtbuffer);
		
		if (currentWaterLevel > WATERLEVEL_ALARM_HEIGHT)
		{
			lcd_gotoxy(0,1);
			lcd_puts("ALARM");			
		}
		
		dbmanageSend(currentWaterLevel, currentWaterLevel > WATERLEVEL_ALARM_HEIGHT ? 1 : 0);
	}
}

