/*
 * UE05_RFID_UART.c
 *
 * Created: 27.02.2024 11:05:46
 * Author : trueberryless
 */ 

#define F_CPU 16000000UL

#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>
#include <stdio.h>
#include "lcd.h"

#include "mfrc522.h"
#include "spi.h"

#include "uart.h"

int main(void)
{
	lcd_init(LCD_DISP_ON);
	
	// DDD2 Ausgang
	DDRD |= (1<<DDD2);
	
	lcd_puts("starting...");
	_delay_ms(50);
	
	// Initialisierung des UART mit BAUD Rate 9600 (braucht unser ATMEGA so) + gleiche Taktrate 16MHz
	uart_init(UART_BAUD_SELECT(9600UL,F_CPU));
	
	spi_init();
	mfrc522_init();

	lcd_clrscr();
	lcd_puts("ready ...");
	_delay_ms(500);
	
	// Aktivierung Interrupts für UART
	sei();
	
	while (1) {
		uint8_t status;
		uint8_t card_str[MAX_LEN];
		uint8_t card_serial[5]; // Serial number is 5 bytes

		// Check for card presence
		status = mfrc522_request(PICC_REQIDL, card_str);
		if (status == CARD_FOUND) {

			lcd_clrscr();
			lcd_puts("found card ...");
			_delay_ms(500);

			// Get the card's serial number
			status = mfrc522_get_card_serial(card_serial);
			if (status == CARD_FOUND) {
				
				// make sound
				PORTD |= (1<<PORTD2);
				
				// If a card is found, display the serial number on the LCD
				char buffer[16];
				sprintf(buffer, "ID: %X%X%X%X%X\n", card_serial[0], card_serial[1], card_serial[2], card_serial[3], card_serial[4]);
				lcd_clrscr();
				lcd_puts(buffer);
				
				// Senden über UART
				uart_puts(buffer);
				
				_delay_ms(100);
				PORTD &= ~(1<<PORTD2);
			}
		}
		_delay_ms(500);
	}
}

