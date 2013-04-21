/**
 * File:        ports.c
 * PIC:         PIC16F873
 * Author:      Back Leonardo
 *
 * Descripción:
 * Configuracion de puertos.
 *
 * Source
 * -----------------------------------------------------------------------------
 * PIN 8 = Vss  (-)                         ->
 * PIN 19 = Vss (-)                         ->
 * PIN 20 = Vdd (+)                         ->
 *
 * Clock
 * -----------------------------------------------------------------------------
 * PIN 9 = OSC1/CLKIN                       -> Cristal pin x1 y Capacitor 22nf
 * PIN 10 = OSC2/CLKOUT                     -> Cristal pin x2 y Capacitor 22nf
 *
 * PORTA
 * -----------------------------------------------------------------------------
 *      bit 0 = RA0/AN0         - PIN 2     -> POTred
 *      bit 1 = RA1/AN1         - PIN 3     -> POTgreen
 *      bit 2 = RA2/AN2/Vref-   - PIN 4     -> POTblue
 *      bit 3 = RA3/AN3/Vref+   - PIN 5     -> BTNauto
 *      bit 4 = RA4/T0CKI       - PIN 6     -> LEDauto      Led bicolor Green
 *      bit 5 = RA5/AN4/-(SS)   - PIN 7     -> LEDmanual    Led bicolor Red
 *
 * PORTB
 * -----------------------------------------------------------------------------
 *      bit 0 = RB0/INT         - PIN 21
 *      bit 1 = RB1             - PIN 22
 *      bit 2 = RB2             - PIN 23
 *      bit 3 = RB3/PGM         - PIN 24
 *      bit 4 = RB4             - PIN 25
 *      bit 5 = RB5             - PIN 26
 *      bit 6 = RB6/PGC         - PIN 27
 *      bit 7 = RB7/PGD         - PIN 28
 *
 * PORTC
 * -----------------------------------------------------------------------------
 *      bit 0 = RC0/T1OSO/T1CKI - PIN 11
 *      bit 1 = RC1/T1OSI/CCP2  - PIN 12
 *      bit 2 = RC2/CCP1        - PIN 13
 *      bit 3 = RC3/SCK/SCL     - PIN 14
 *      bit 4 = RC4/SDI/SDA     - PIN 15
 *      bit 5 = RC5/SDO         - PIN 16
 *      bit 6 = RC6/TX/CK       - PIN 17    -> MAX232
 *      bit 7 = RC7/RX/DT       - PIN 18    -> MAX232
 */

#include <xc.h>
#include "system.h"

//#define POTred      PORTAbits.RA0;
//#define POTgreen    PORTAbits.RA1;
//#define POTblue     PORTAbits.RA2;
//#define BTNauto     PORTAbits.RA3;
//#define LEDauto     PORTAbits.RA4;
//#define LEDmanual   PORTAbits.RA5;
//
//#define TX          PORTCbits.RC6;
//#define RX          PORTCbits.RC7;

// bit tris = 1 -> input
// bit tris = 0 -> output
void configurePorts(){
    
    TRISA = 0x0f;
//    TRISAbits.TRISA0 = 1;
//    TRISAbits.TRISA1 = 1;
//    TRISAbits.TRISA2 = 1;
//    TRISAbits.TRISA3 = 1;
//    TRISAbits.TRISA4 = 0;
//    TRISAbits.TRISA5 = 0;

    TRISB = 0xff;

    TRISC= 0xff;
}

void initializePorts(){

    PORTAbits.RA0 = 0;
    PORTAbits.RA1 = 0;
    PORTAbits.RA2 = 0;
    PORTAbits.RA3 = 0;
    PORTAbits.RA4 = 0;
    PORTAbits.RA5 = 0;
    //
    PORTBbits.RB0 = 1;
    PORTBbits.RB1 = 0;
    PORTBbits.RB2 = 0;
    PORTBbits.RB3 = 0;
    PORTBbits.RB4 = 0;
    PORTBbits.RB5 = 0;
    PORTBbits.RB6 = 0;
    PORTBbits.RB7 = 0;
    //
    PORTCbits.RC0 = 0;
    PORTCbits.RC1 = 0;
    PORTCbits.RC2 = 0;
    PORTCbits.RC3 = 0;
    PORTCbits.RC4 = 0;
    PORTCbits.RC5 = 0;
    PORTCbits.RC6 = 0;
    PORTCbits.RC7 = 0;
}