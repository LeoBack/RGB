/*
 * File:   main.c
 * Author: i5k
 *
 * Created on 16 de enero de 2013, 15:24
 */

#include <stdio.h>
#include <stdlib.h>

/*
 *
 */

#include <xc.h>
#include <stdint.h>

#define _XTAL_FREQ 4000000      // Reloj 4Mhz

#pragma config MCLRE = ON       // Master Clear pin enabled
#pragma config CP = OFF         // Protecion lectura de codigo
#pragma config CPD = OFF
#pragma config BOREN = OFF
#pragma config WDTE = OFF       // Watch Dog Timer
#pragma config PWRTE = OFF      // Power Up Timer
#pragma config FOSC = INTRCIO   // Osilador Interno

uint8_t sGPIO = 0;  //Copy GPIO

int main(int argc, char** argv) {

    TRISIObits.TRISIO0 = 0;
    TRISIObits.TRISIO1 = 0;
    TRISIObits.TRISIO2 = 0;
    TRISIObits.TRISIO3 = 1;
    TRISIObits.TRISIO4 = 1;
    TRISIObits.TRISIO5 = 1;

    GPIO = 0;

    for( ;; ){

        if(GPIObits.GP5 == 1 && GPIObits.GP4 == 1){
            GPIO = 0b000110;
            __delay_ms(200);
            GPIO = 0b000101;
            __delay_ms(200);
        }
        else if(GPIObits.GP5 == 1){
            GPIO = 0b000010;
            __delay_ms(200);
            GPIO = 0b000001;
            __delay_ms(200);            
        }
        else if(GPIObits.GP4 == 1){
            GPIO = 0b000100;            
        }
        else{
            GPIO = 0;
        }
    }
}

