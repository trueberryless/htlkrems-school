/*
 * UE05_RFID_VersionNr.c
 *
 * Created: 30.01.2024 10:38:17
 * Author : trueberryless
 */ 

#define F_CPU 16000000

#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>
#include <stdio.h>
#include "lcd.h"
#include "spi_commands.h"

#define CS_PIN PORTB2
#define CONTROLLER MSTR

void SPI_init(void)
{
	// CS, MOSI, Clock
	DDRB |= (1<<DDB2) | (1<<DDB3) | (1<<DDB5);
	PORTB |= (1<<CS_PIN);
	SPCR |= (1<<CONTROLLER) | (1<<SPE) | (1<<SPR0);
}

uint8_t SPI_talk(uint8_t cData)
{
	PORTB &= ~(1<<CS_PIN);
	
	SPDR = cData;
	while(!(SPSR & (1<<SPIF)));
	
	PORTB |= (1<<CS_PIN);
	
	return SPDR;
}

uint8_t ReadCommand(uint8_t command) {
	return ((1<<7) | (command<<1));
}

uint8_t WriteCommand(uint8_t command) {
	return (command<<1);
}

int main(void)
{
	lcd_init(LCD_DISP_ON);
	
	
	SPI_init();
	
	
	lcd_puts("starting...");
	_delay_ms(1000);
	
	
	uint8_t temp = SPI_talk(ReadCommand(VersionReg));
	uint8_t version_number = SPI_talk(0x00);
	
	
	_delay_ms(1000);
	
	char buffer[16];
	sprintf(buffer, "%x", version_number);
	
	lcd_clrscr();
	lcd_puts(buffer);
	
	while (1);
}


