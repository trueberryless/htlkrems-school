/*
 * UE08_USART.c
 * Senden und empfangen eines Zeichens
 * Created: 4/28/2023 2:10:08 PM
 * Author : trueberryless
 */ 
#define F_CPU 16000000UL

#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>

void write_string(char *str);

int main(void)
{
	char arr[] = "Hello";
	
	// Baud Rate auf 9600 setzen
	UBRR0 = 103;
	
	// Senden aktivieren
	UCSR0B |= (1<<TXEN0) | (1<<RXEN0) | (1<<RXCIE0);
	
	// 8-Datenbit einstellen
	UCSR0C |= (1<<UCSZ00) | (1<<UCSZ01);
	
	sei();
	
	
    /* Replace with your application code */
    while (1) 
    {
    }
}


/************************************************************************/
/* Funktion zum Senden eines Strings                                    */
/************************************************************************/

void write_char(char str) {
	while (!(UCSR0A & (1<<UDRE0)));
	// Sendevorgang wird automatisch bei Zuweisung gestartet
	UDR0=str;
}

void write_string(char *arr) {
    while(*arr) {
        printf("%c", *arr++);
    }
    printf("\n");
}

ISR(USART_RX_vect) {
	uint8_t tmp;
	tmp = UDR0;
	tmp++;
	write_char(tmp);
}

