/*
 * UE05_RFID.c
 *
 * Created: 30.01.2024 10:38:17
 * Author : trueberryless
 */ 

#define F_CPU 16000000UL

#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>
#include <stdio.h>
#include "lcd.h"

#include "spi.h"
#include "mfrc522.h"

int main(void)
{
	lcd_init(LCD_DISP_ON);
	
	lcd_puts("starting...");
	_delay_ms(50);
	
	spi_init();
	_delay_ms(500);
	mfrc522_init();

	lcd_clrscr();
	lcd_puts("ready ...");
	
	while (1) {
		uint8_t status;
		uint8_t card_str[MAX_LEN];
		uint8_t card_serial[5]; // Serial number is 5 bytes
		

		// Check for card presence
		status = mfrc522_request(PICC_REQIDL, card_str);	
		char buffer[16];
		sprintf(buffer, "%u", status);
		lcd_puts(buffer);
		if (status == CARD_FOUND) {

			lcd_clrscr();
			lcd_puts("found card ...");
			_delay_ms(500);

			// Get the card's serial number
			status = mfrc522_get_card_serial(card_serial);
			if (status == CARD_FOUND) {
				// If a card is found, display the serial number on the LCD
				char buffer[16];
				sprintf(buffer, "ID: %X%X%X%X%X", card_serial[0], card_serial[1], card_serial[2], card_serial[3], card_serial[4]);
				lcd_clrscr();
				lcd_puts(buffer);
			}
		}
		_delay_ms(500);
	}
}

