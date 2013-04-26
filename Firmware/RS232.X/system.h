/*
 * File:   system.h
 * PIC:    PIC16F873
 * Author: Back Leonardo
 */
/*******************************************************/
/* System Level #define Macros                         */
/*******************************************************/
/**
 * Indica que el pic funcionará a 8MHz.
 * Este macro es necesario para las funciones de delay.
 */
//#define _XTAL_FREQ       20000000
#define _XTAL_FREQ 10000000      // Reloj 10Mhz

/*******************************************************/
/* System Function Prototypes                          */
/*******************************************************/
/**
 * Función que debe configurar el Oscilador
 */
void ConfigureOscillator(void);