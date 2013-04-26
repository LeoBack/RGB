/**
 * File:        configuration_bits.c
 * PIC:         PIC16F873
 * Author:      Back Leonardo
 *
 * Descripción:
 *
 */
#include <xc.h>

// Configuration word - pag:120
// C:\Program Files (x86)\Microchip\MPLABX\mpasmx\P16F873.INC
// ON = Habilitado; OFF = Deshabilitado;

#pragma config FOSC = XT        // Osilador Cristal Externo
#pragma config WDTE = OFF       // Watch Dog Timer
#pragma config PWRTE = OFF      // Power Up Timer
#pragma config CP = OFF         // Protecion lectura de codigo
#pragma config BOREN = OFF      //
#pragma config LVP = OFF        //
#pragma config CPD = OFF        // Data EEPROM memory code-protected
#pragma config WRT = OFF        // Unprotected program memory may not be written to by EECON control
#pragma config DEBUG = OFF      // In-Circuit Debugger disabled, RB6 and RB7 are general purpose I/O pins