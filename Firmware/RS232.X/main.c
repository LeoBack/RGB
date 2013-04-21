/**
 * File:        main.c
 * PIC:         PIC16F873
 * Author:      Back Leonardo
 *
 * Descripción:
 * Created on 18 de abril de 2013, 10:45
 *
 */

#include <xc.h>
#include <stdio.h>
#include <stdint.h>
#include <stdbool.h>

#include "system.h"
#include "usart.h"
#include "ports.h"

//--------------------------------------------------------------------------
//#use rs232(baud=9600,parity=N,xmit=PIN_C6,rcv=PIN_C7,bits=8) // probe con 19200 y 9600
// http://programandopics.blogspot.com.ar/2013/03/enviar-datos-la-pc-mediante-usart.html
//--------------------------------------------------------------------------

/*
 * 
 */
int main(int argc, char** argv) {

    // Configura el oscilador
    ConfigureOscillator();

    // Configuro Puertos
    configurePorts();
    initializePorts();
    

    // BRGH = 1
    // SPBRG = 64 = // 19200 Bauds
    ConfigureUsart(1, 64);

//__delay_ms(80); // Delay que permite que se estabilice la configuración
//    y las interrupciones antes de comenzar a trabajar
//--------------------------------------------------------------------------
    
    PORTAbits.RA4 = 1;
    //LEDauto = 1;

    for(;;)
    {
        
    }
}



