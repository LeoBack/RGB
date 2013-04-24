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

//---Buffer Digital I/O PORTA
union {
    uint8_t     port;
    struct {
        unsigned    RA0 :   1;
        unsigned    RA1 :   1;
        unsigned    RA2 :   1;
        unsigned    RA3 :   1;
        unsigned    RA4 :   1;
        unsigned    RA5 :   1;
    };
}  sPORTA;
//---Buffer Digital I/O PORTB
union {
    uint8_t     port;
    struct {
        unsigned    RB0 :   1;
        unsigned    RB1 :   1;
        unsigned    RB2 :   1;
        unsigned    RB3 :   1;
        unsigned    RB4 :   1;
        unsigned    RB5 :   1;
        unsigned    RB6 :   1;
        unsigned    RB7 :   1;
    };
}  sPORTB;
//---Buffer Digital I/O PORTC
union {
    uint8_t     port;
    struct {
        unsigned    RC0 :   1;
        unsigned    RC1 :   1;
        unsigned    RC2 :   1;
        unsigned    RC3 :   1;
        unsigned    RC4 :   1;
        unsigned    RC5 :   1;
        unsigned    RC6 :   1;
        unsigned    RC7 :   1;
    };
}  sPORTC;
//---------------------

//OTRAS NOTAS---------------------------------------------------------------
//#use rs232(baud=9600,parity=N,xmit=PIN_C6,rcv=PIN_C7,bits=8) // probe con 19200 y 9600
// http://programandopics.blogspot.com.ar/2013/03/enviar-datos-la-pc-mediante-usart.html
// <<<  http://www.micros-designs.com.ar/  >>>
//--------------------------------------------------------------------------


/*
 * 
 */
int main(int argc, char** argv) {

    // Configura el oscilador
    ConfigureOscillator();

    iniPIC();
    iniPorts();
    iniTMR0();
    iniTMR1();
    iniTMR2();
    iniSerialPort();
    iniADC();

    // Set Puertos
    setDefaultPorts();
   
    // BRGH = 1
    // SPBRG = 64 = // 19200 Bauds
    //ConfigureUsart(1, 64);

//__delay_ms(80); // Delay que permite que se estabilice la configuración
//    y las interrupciones antes de comenzar a trabajar
//--------------------------------------------------------------------------

    for(;;)
    {
//        if(PORTAbits.RA3 == 1){
//            PORTA = 0x10;
//        }
//        else{
//            PORTA= 0x20;
//        }
//PROBAR
        if(sPORTA.RA3 == 1){
            sPORTA.RA4 = Higt;
        }
        else{
            sPORTA.RA3 = Low;
        }
        PORTA = sPORTA.port;
    }
}



