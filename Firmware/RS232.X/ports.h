/*
 * File:   Ports.h
 * PIC:    PIC16F873
 * Author: Back Leonardo
 */
/*******************************************************/
/* Configuracion de Puertos                            */
/*******************************************************/

#define In          1;
#define Out         0;
//---------------------
#define Higt        1;
#define Low         0;
//---------------------
#define Enable      1;
#define Disable     0;

void iniPIC(void);

// Cap 3.0
// I/O PORTS
void iniPorts(void);

// Cap 3.0
// I/O PORTS
void setDefaultPorts(void);

// Cap 5.0
// TIMER0 MODULE
void iniTMR0(void);

// Cap 6.0
// TIMER1 MODULE
void iniTMR1(void);

// Cap 7.0
// TIMER2 MODULE
void iniTMR2(void);

// Cap 9.0
// MASTER SYNCHRONOUS SERIAL PORT (MSSP) MODULE
void iniI2C(void);

// Cap 10.0
// ADDRESSABLE UNIVERSAL SYNCHRONOUS ASYNCHRONOUS RECEIVER TRANSMITTER (USART)
void iniSerialPort(void);

// Cap 11.0
// ANALOG-TO-DIGITAL CONVERTER (A/D) MODULE
void iniADC(void);