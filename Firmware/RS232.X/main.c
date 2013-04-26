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
#include "functions.h"

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

void UpdatePort(void){
    PORTA = sPORTA.port;
    PORTB = sPORTB.port;
    PORTC = sPORTC.port;
}

//--------------------------------------------------------------------------

/*
 * 
 */
    // Set Puertos
    //setDefaultPorts();
   
    // BRGH = 1
    // SPBRG = 64 = // 19200 Bauds
    //ConfigureUsart(1, 64);

//__delay_ms(80); // Delay que permite que se estabilice la configuración
//    y las interrupciones antes de comenzar a trabajar
//--------------------------------------------------------------------------

int main(int argc, char** argv){
    // Configura el oscilador
    ConfigureOscillator();

    iniPIC();
    iniPorts();
    iniTMR0();
    iniADC();
    //
    setDefaultPorts();
    INTCONbits.GIE = Enable;            // Global Interrupt Enable bit
    INTCONbits.PEIE = Enable;           // Peripheral Interrupt Enable bit

    while(1){
        // ADC Channel 0
            ADCON0bits.CHS = 0x00;
            ADCON0bits.GO_nDONE = Higt;

        if(PORTAbits.RA4 == 1){
            sPORTA.RA2 = Higt;
            sPORTA.RA5 = Higt;
            UpdatePort();    // Actualizar Puertos
        }
        else{
            sPORTA.RA2 = Higt;
            UpdatePort();        // Actualizar Puertos
            __delay_ms(100);
            sPORTA.RA2 = Low;
            UpdatePort();        // Actualizar Puertos
            __delay_ms(100);
            sPORTA.RA5 = Low;
            UpdatePort();        // Actualizar Puertos
        }
    }
}

void interrupt isr(void){
// ADC -------------------------------------------------------------------------
    if(PIR1bits.ADIF){
        PIR1bits.ADIF = Low;

        if(ADRESL < 0xC8){
            sPORTA.RA5 = Higt;
        }
        else{
             sPORTA.RA5 = Low;
        }
        UpdatePort();    // Actualizar Puertos
    }

// TIMER------------------------------------------------------------------------
    if (INTCONbits.T0IF){
        INTCONbits.T0IF = Low;
    }

    if(PIR1bits.TMR1IF){
        PIR1bits.TMR1IF = Low;
    }

    if(PIR1bits.TMR2IF){
        PIR1bits.TMR2IF = Low;
    }

// RB0 -------------------------------------------------------------------------
    if(INTCONbits.RBIF){
        INTCONbits.RBIF = Low;
    }

    if(INTCONbits.INTF){
        INTCONbits.INTF = Low;
    }

//------------------------------------------------------------------------------
}



