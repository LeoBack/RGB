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
#include "ports.h"

void iniPIC(void){

    // Interrupciones General
    INTCONbits.GIE = Disable;            // Global Interrupt Enable bit
    INTCONbits.PEIE = Disable;           // Peripheral Interrupt Enable bit

    // Configuracion Inicial
//    OPTION_REGbits.nRBPU = Enable;      // PORTB Pull-up Enable bit
//    OPTION_REGbits.INTEDG = Disable;    // Interrupt Edge Select bit

    //--------------------------------------------------------------------------
    // Enable/Disable - Interrupciones sobre regitros
//    INTCONbits.T0IE = Enable;           // TMR0 Overflow Interrupt Enable bit
//    INTCONbits.INTE = Disable;          // RB0/INT External Interrupt Enable bit
//    INTCONbits.RBIE = Disable;          // RB Port Change Interrupt Enable bit
//
//    // Flags - Interrupciones sobre registros
//    INTCONbits.T0IF = Low;              // TMR0 Overflow Interrupt Flag bit
//    INTCONbits.INTF = Low;              // RB0/INT External Interrupt Flag bit
//    INTCONbits.RBIF = Low;              // RB Port Change Interrupt Flag bit

    // Enable/Disable - Peripheral Interrupt
//    PIE1bits.PSPIE = Disable;           // Parallel Slave Port Read/Write Interrupt Enable bit
//    PIE1bits.ADIE = Enable;             // A/D Converter Interrupt Enable bit
//    PIE1bits.RCIE = Disable;            // USART Receive Interrupt Enable bit
//    PIE1bits.TXIE = Disable;            // USART Transmit Interrupt Enable bit
//    PIE1bits.SSPIE = Disable;           // Synchronous Serial Port Interrupt Enable bit
    PIE1bits.CCP1IE = Disable;          // CCP1 Interrupt Enable bit
//    PIE1bits.TMR2IE = Disable;          // TMR2 to PR2 Match Interrupt Enable bit
//    PIE1bits.TMR1IE = Disable;          // TMR1 Overflow Interrupt Enable bit

    // Flags - Peripheral Interrupt
//    PIR1bits.PSPIF = Disable;           // Parallel Slave Port Read/Write Interrupt Flag bit
//    PIR1bits.ADIF = Low;                // A/D Converter Interrupt Flag bit
//    PIR1bits.RCIF = Low;                // USART Receive Interrupt Flag bit
//    PIR1bits.TXIF = Low;                // USART Transmit Interrupt Flag bit
//    PIR1bits.SSPIF = Low;               // Synchronous Serial Port (SSP) Interrupt Flag
    PIR1bits.CCP1IF = Low;              // CCP1 Interrupt Flag bit
//    PIR1bits.TMR2IF = Low;              // TMR2 to PR2 Match Interrupt Flag bit
//    PIR1bits.TMR1IF = Low;              // TMR1 Overflow Interrupt Flag bit

    // Enable/Disable - Peripheral Interrupt
    //Bus collision, CCP and EEPROM
    PIE2bits.EEIE = Disable;            // EEPROM Write Operation Interrupt Enable
    PIE2bits.BCLIE = Disable;           // Bus Collision Interrupt Enable
    PIE2bits.CCP2IE = Disable;          // CCP2 Interrupt Enable bit

    // Flags - Peripheral Interrupt
    //Bus collision, CCP and EEPROM
    PIR2bits.EEIF = Low;                // EEPROM Write Operation Interrupt Flag bit
    PIR2bits.CCP2IF = Low;              // Bus Collision Interrupt Flag bit
    PIR2bits.CCP2IF = Low;              // CCP2 Interrupt Flag bit
}

// Cap 3.0
// I/O PORTS
void iniPorts(void){
    TRISA = 0b00011011;//0x0f;
//    TRISAbits.TRISA0 = In;
//    TRISAbits.TRISA1 = In;
//    TRISAbits.TRISA2 = In;
//    TRISAbits.TRISA3 = In;
//    TRISAbits.TRISA4 = Out;       // Digital Only Output
//    TRISAbits.TRISA5 = Out;

    TRISB = 0xff;
//    TRISBbits.TRISB0 = In;
//    TRISBbits.TRISB1 = In;
//    TRISBbits.TRISB2 = In;
//    TRISBbits.TRISB3 = In;
//    TRISBbits.TRISB4 = In;
//    TRISBbits.TRISB5 = In;
//    TRISBbits.TRISB6 = In;
//    TRISBbits.TRISB7 = In;

    TRISC= 0xff;
//    TRISCbits.TRISC0 = In;
//    TRISCbits.TRISC1 = In;
//    TRISCbits.TRISC2 = In;
//    TRISCbits.TRISC3 = In;
//    TRISCbits.TRISC4 = In;
//    TRISCbits.TRISC5 = In;
//    TRISCbits.TRISC6 = In;
//    TRISCbits.TRISC7 = In;

    OPTION_REGbits.nRBPU = Enable;      // PORTB Pull-up Enable bit
    OPTION_REGbits.INTEDG = Higt;    // Interrupt Edge Select bit

    INTCONbits.INTE = Disable;          // RB0/INT External Interrupt Enable bit
    INTCONbits.RBIE = Disable;          // RB Port Change Interrupt Enable bit

    INTCONbits.INTF = Low;              // RB0/INT External Interrupt Flag bit
    INTCONbits.RBIF = Low;              // RB Port Change Interrupt Flag bit
}

// Cap 3.0
// I/O PORTS
void setDefaultPorts(void){

    PORTA = 0x00;
//    PORTAbits.RA0 = Low;
//    PORTAbits.RA1 = Low;
//    PORTAbits.RA2 = Low;
//    PORTAbits.RA3 = Low;
//    PORTAbits.RA4 = Low;
//    PORTAbits.RA5 = Low;
    PORTB = 0x00;
//    PORTBbits.RB0 = Low;
//    PORTBbits.RB1 = Low;
//    PORTBbits.RB2 = Low;
//    PORTBbits.RB3 = Low;
//    PORTBbits.RB4 = Low;
//    PORTBbits.RB5 = Low;
//    PORTBbits.RB6 = Low;
//    PORTBbits.RB7 = Low;
    PORTC = 0x00;
//    PORTCbits.RC0 = Low;
//    PORTCbits.RC1 = Low;
//    PORTCbits.RC2 = Low;
//    PORTCbits.RC3 = Low;
//    PORTCbits.RC4 = Low;
//    PORTCbits.RC5 = Low;
//    PORTCbits.RC6 = Low;
//    PORTCbits.RC7 = Low;
}

// Cap 5.0
// TIMER0 MODULE
void iniTMR0(void){
    // REGISTER 5-1: OPTION_REG REGISTER
    OPTION_REGbits.T0CS = Low;          // TMR0 Clock Source Select bit
    OPTION_REGbits.T0SE = Higt;         // TMR0 Source Edge Select bit
    OPTION_REGbits.PSA = Higt;          // Prescaler Assignment bit
    OPTION_REGbits.PS = 0x04;           // Prescaler Rate Select bits

    INTCONbits.T0IE = Low;              // TMR0 Overflow Interrupt Enable bit
    INTCONbits.T0IF = Low;              // TMR0 Overflow Interrupt Flag bit
}

// Cap 6.0
// TIMER1 MODULE
void iniTMR1(void){
    //REGISTER 6-1: T1CON: TIMER1 CONTROL REGISTER (ADDRESS 10h)
    T1CONbits.T1CKPS = 0x02;            // Timer1 Input Clock Prescale Select bits
    T1CONbits.T1OSCEN = Higt;           // Timer1 Oscillator Enable Control bit
    T1CONbits.nT1SYNC = Disable;        // Timer1 External Clock Input Synchronization Control bit
    T1CONbits.TMR1CS = Low;             // Timer1 Clock Source Select bit
    T1CONbits.TMR1ON = Low;             // Timer1 On bit

    PIE1bits.TMR1IE = Low;              // TMR1 Overflow Interrupt Enable bit
    PIR1bits.TMR1IF = Low;              // TMR1 Overflow Interrupt Flag bit
}

// Cap 7.0
// TIMER2 MODULE
void iniTMR2(void){
    //REGISTER 7-1: T2CON: TIMER2 CONTROL REGISTER (ADDRESS 12h)
    T2CONbits.TOUTPS = 0x00;            // Timer2 Output Postscale Select bits
    T2CONbits.TMR2ON = Disable;         // Timer2 On bit
    T2CONbits.T2CKPS = 0x00;            //Timer2 Clock Prescale Select bits

    PIE1bits.TMR2IE = Low;          // TMR2 to PR2 Match Interrupt Enable bit
    PIR1bits.TMR2IF = Low;              // TMR2 to PR2 Match Interrupt Flag bit
}

// Cap 9.0
// MASTER SYNCHRONOUS SERIAL PORT (MSSP) MODULE
void iniI2C(void){
    // REGISTER 9-1: SSPSTAT: SYNC SERIAL PORT STATUS REGISTER (ADDRESS: 94h)
    SSPSTATbits.SMP = Disable;          // Sample bit
    SSPSTATbits.CKE = Disable;          // SPI Clock Edge Select
// READ ONLY
//  SSPSTATbits.D_A = Disable;          // Data/nAddressbit
//  SSPSTATbits.P = Disable;            // STOP bit
//  SSPSTATbits.S = Disable;            // START bit
//  SSPSTATbits.R_W = Low;              // Read/Write bit Information (I2C mode only)
//  SSPSTATbits.UA = Disable;           // Update Address (10-bit I2C mode only
//  SSPSTATbits.BF = Disable;           // Buffer Full Status bit

    // REGISTER 9-2: SSPCON: SYNC SERIAL PORT CONTROL REGISTER (ADDRESS 14h)
    SSPCONbits.WCOL = Disable;          //Write Collision Detect bit
    SSPCONbits.SSPOV = Disable;         // Receive Overflow Indicator bit
    SSPCONbits.SSPEN = Disable;         //Synchronous Serial Port Enable bit
    SSPCONbits.CKP = Disable;           //Clock Polarity Select bit
    SSPCONbits.SSPM = 0x00;             // Synchronous Serial Port Mode Select bits

    // REGISTER 9-3: SSPCON2: SYNC SERIAL PORT CONTROL REGISTER2 (ADDRESS 91h)
    SSPCON2bits.GCEN = Disable;         // General Call Enable bit (In I2C Slave mode only)
    SSPCON2bits.ACKSTAT = Disable;      // Acknowledge Status bit (In I2C Master mode only)
    SSPCON2bits.ACKDT = Disable;        // Acknowledge Data bit (In I2C Master mode only)
    SSPCON2bits.ACKEN = Disable;        // Acknowledge Sequence Enable bit (In I2C Master mode only)
    SSPCON2bits.RCEN = Disable;         // Receive Enable bit (In I2C Master mode only)
    SSPCON2bits.PEN = Disable;          //STOP Condition Enable bit (In I2C Master mode only)
    SSPCON2bits.RSEN = Disable;         //Repeated START Condition Enable bit (In I2C Master mode only)
    SSPCON2bits.SEN = Disable;          // START Condition Enable bit (In I2C Master mode only)
}

// Cap 10.0
// ADDRESSABLE UNIVERSAL SYNCHRONOUS ASYNCHRONOUS RECEIVER TRANSMITTER (USART)
void iniSerialPort(void){
    // REGISTER 10-1: TXSTA: TRANSMIT STATUS AND CONTROL REGISTER (ADDRESS 98h)
    TXSTAbits.CSRC = Disable;           // Clock Source Select bit
    TXSTAbits.TX9 = Disable;            // 9-bit Transmit Enable bit
    TXSTAbits.TXEN = Disable;           // Transmit Enable bit
    TXSTAbits.SYNC = Disable;           // USART Mode Select bit
    TXSTAbits.BRGH = Disable;           // High Baud Rate Select bit
//  TXSTAbits.TRMT = Disable;           // Transmit Shift Register Status bit
    TXSTAbits.TX9D = Disable;           // 9th bit of Transmit Data, can be parity bit

    // REGISTER 10-2: RCSTA: RECEIVE STATUS AND CONTROL REGISTER (ADDRESS 18h)
    RCSTAbits.SPEN = Disable;           // Serial Port Enable bit
    RCSTAbits.RX9 = Disable;            // 9-bit Receive Enable bit
    RCSTAbits.SREN = Disable;           // Single Receive Enable bit
    RCSTAbits.CREN = Disable;           // Continuous Receive Enable bit
    RCSTAbits.ADDEN = Disable;          // Address Detect Enable bit
// READ ONLY
//  RCSTAbits.FERR = Disable;           // Framing Error bit
//  RCSTAbits.OERR = Disable;           // Overrun Error bit
//  RCSTAbits.RX9D = Disable;           // 9th bit of Received Data (can be parity bit,
                                        // but must be calculated by user firmware)

    PIE1bits.RCIE = Disable;            // USART Receive Interrupt Enable bit
    PIE1bits.TXIE = Disable;            // USART Transmit Interrupt Enable bit
    PIE1bits.SSPIE = Disable;           // Synchronous Serial Port Interrupt Enable bit

    PIR1bits.RCIF = Low;                // USART Receive Interrupt Flag bit
    PIR1bits.TXIF = Low;                // USART Transmit Interrupt Flag bit
    PIR1bits.SSPIF = Low;               // Synchronous Serial Port (SSP) Interrupt Flag
}

// Cap 11.0
// ANALOG-TO-DIGITAL CONVERTER (A/D) MODULE
void iniADC(){
    // ADCON0 REGISTER (ADDRESS: 1Fh)
    ADCON0bits.ADCS = 0x01;             // A/D Conversion Clock Select bits
//    ADCON0bits.CHS = 0x00;              // Analog Channel Select bits
    ADCON0bits.GO_nDONE = Low;          // A/D Conversion Status bit
    ADCON0bits.ADON = Enable;           // A/D On bit

    // ADCON1 REGISTER (ADDRESS 9Fh)
    ADCON1bits.ADFM = Enable;           // A/D Result Format Select bit
    ADCON1bits.PCFG = 0x04;             // A/D Port Configuration Control bit // 3ang/4dig

    PIE1bits.ADIE = Enable;             // A/D Converter Interrupt Enable bit
    PIR1bits.ADIF = Low;                // A/D Converter Interrupt Flag bit
}