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
//---------------------

void iniPIC();

void iniTMR1();

void iniTMR2();

void iniSerialPort();

void iniADC();

void iniPorts();

void setDefaultPorts();