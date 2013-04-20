/* 
 * File:   main.c
 * Author: Leo
 *
 * Created on 18 de abril de 2013, 10:45
 */

#include <stdio.h>
#include <stdlib.h>
#include <delays.h>

#define _XTAL_FREQ 4000000      // Reloj 4Mhz

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

//--------------------------------------------------------------------------
//#use rs232(baud=9600,parity=N,xmit=PIN_C6,rcv=PIN_C7,bits=8) // probe con 19200 y 9600
//#use rs232(baud=9600, xmit=PIN_C6, rcv=PIN_C7)
// http://www.todopic.com.ar/foros/index.php?topic=40588.0

// http://programandopics.blogspot.com.ar/2013/03/enviar-datos-la-pc-mediante-usart.html

//--------------------------------------------------------------------------
//#use fast_io(B)

/*
 * 
 */
int main(int argc, char** argv) {

//--------------------------------------------------------------------------
// Habilita la conexión serial
// Habilitar uart

TXSTAbits.TX9 = 0;  //  Transmisión de 8-bit
TXSTAbits.SYNC = 0; // Modo asincrónico
TXSTAbits.BRGH = 1; // BRGH en alta velocidad

RCSTAbits.RX9 = 0;  // Recepción de 8-bit
RCSTAbits.SPEN = 1; // Puerto serial habilitado
// (configura RB2/SDO/RX/DT y RB5/SS/TX/CK pins como puerto serial)

SPBRG = 64;       // 19200 baud

TXSTAbits.TXEN = 1; // Habilita la transmisión de datos
RCSTAbits.CREN = 1; // Habilita la recepción de datos
RCIE = 1;           // Habilita las interrupciones por recibo de datos

//__delay_ms(80); // Delay que permite que se estabilice la configuración y las interrupciones antes de comenzar a trabajar
//--------------------------------------------------------------------------
    return (EXIT_SUCCESS);
}



