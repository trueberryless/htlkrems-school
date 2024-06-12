/*
 * adc.h
 *
 * Created: 15.01.2024 09:17:40
 *  Author: Homer Simpson
 */ 


#ifndef ADC_H_
#define ADC_H_

// Initialisieurng des ADC
void acd_init();

// Startet den ADC bzw. dessen Messungen
void adc_start_conversion();

// Liefert den Pegelstand in Meter
float adc_get_water_level();


#endif /* ADC_H_ */