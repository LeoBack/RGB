/*
 * File:   Ports.h
 * PIC:    PIC16F873
 * Author: Back Leonardo
 */
/*******************************************************/
/* Configuracion de Puertos                            */
/*******************************************************/

#define POTred      PORTAbits.RA0;
#define POTgreen    PORTAbits.RA1;
#define POTblue     PORTAbits.RA2;
#define BTNauto     PORTAbits.RA3;
#define LEDauto     PORTAbits.RA4;
#define LEDmanual   PORTAbits.RA5;

#define TX          PORTCbits.RC6;
#define RX          PORTCbits.RC7;

void configurePorts();

void initializePorts();