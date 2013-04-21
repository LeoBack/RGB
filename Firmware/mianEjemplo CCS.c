#include <16F873a.h>
#device adc=8

#FUSES NOWDT                    //No Watch Dog Timer
#FUSES XT                       //Cristal Osc (> 4mhz)
#FUSES NOPUT                    //No Power Up Timer
#FUSES NOPROTECT                //Code not protected from reading
#FUSES NOBROWNOUT               //No brownout reset
#FUSES LVP                      //Low Voltage Programming on B3(PIC16) or B5(PIC18)
#FUSES NOCPD                    //No EE protection
#FUSES NOWRT                    //Program memory not write protected
#FUSES NODEBUG                  //No Debug mode for ICD

#use delay(clock=4000000)
#use rs232(baud=9600, xmit=PIN_C6, rcv=PIN_C7)
#use fast_io(B)

#define LedAzul   PIN_B1
#define LedRojo  PIN_B2
#define LedVerde  PIN_B3
#define Retardo	1

char buffer[13];
int8 Rojo,Verde,Azul, Ticks;
int8 CaracteresRecibidos  = 0;
int1 ComandoRecibido;


#int_Timer0
void ActivaLed() {
	Ticks++;

	if (Ticks==0) {
		//LedAzul=1;
		OUTPUT_HIGH(LedAzul);
		//LedRojo=1;
		OUTPUT_HIGH(LedRojo);
		//LedVerde=1;
		OUTPUT_HIGH(LedVerde);
	};
	if (Ticks==Rojo)
			OUTPUT_LOW(LedRojo);
	if (Ticks==Verde)
			OUTPUT_LOW(LedVerde);
	if (Ticks==Azul)
			OUTPUT_LOW(LedAzul);
	set_timer0(140);
}

    #INT_RDA
    void serial_isr()
    {
        char c;

        c=getc();
        putchar(c);
    buffer[CaracteresRecibidos] = c;
        if (c==13)
                ComandoRecibido=true;
        else
        CaracteresRecibidos = (CaracteresRecibidos+1) % sizeof(buffer);
    }

    void Demo() {
        printf ("Ejecutando demo\n\r");
    Rojo=255;
    Verde=0;
    Azul=0;
    for (Verde=0;Verde<255;Verde++)
      delay_ms(Retardo);
    for (Rojo=255;Rojo>0;Rojo--)
      delay_ms(Retardo);
    for (Azul=0;Azul<255;Azul++)
      delay_ms(Retardo);
    for (Verde=255;Verde>0;Verde--)
      delay_ms(Retardo);
    for (Rojo=0;Rojo<255;Rojo++)
      delay_ms(Retardo);
    for (Azul=255;Azul>0;Azul--)
      delay_ms(Retardo);
        Rojo=0;
    }


    void ProcesaRGB() {
        int8 i=0;
        int1 CambiandoRojo, CambiandoVerde, CambiandoAzul;

        CambiandoRojo=false;
        CambiandoVerde=false;
        CambiandoAzul=false;

        while (i<CaracteresRecibidos) {
                if ((Buffer[i]=='r') || (Buffer[i]=='R')) {
                        CambiandoRojo=true;
                        CambiandoVerde=false;
                        CambiandoAzul=false;
                        Rojo=0;
                }
                if ((Buffer[i]=='g') || (Buffer[i]=='G')) {
                        CambiandoVerde=true;
                        CambiandoRojo=false;
                        CambiandoAzul=false;
                        Verde=0;
                }
                if ((Buffer[i]=='b') || (Buffer[i]=='B')) {
                        CambiandoAzul=true;
                        CambiandoRojo=false;
                        CambiandoVerde=false;
                        Azul=0;
                }
                if ((Buffer[i]>='0') && (Buffer[i]<='9')) {
                        if (CambiandoRojo)
                                Rojo=Rojo*10+Buffer[i]-48;
                        if (CambiandoVerde)
                                Verde=Verde*10+Buffer[i]-48;
                        if (CambiandoAzul)
                                Azul=Azul*10+Buffer[i]-48;
                }
                if ((Buffer[i]=='d') || (Buffer[i]=='D'))
                        Demo();
                i++;
        }
        printf ("Color establecido: Rojo = %u, Verde = %u, Azul = %u \n\r\n\r",Rojo,Verde,Azul);
        CaracteresRecibidos=0;
        ComandoRecibido=false;
    }


    void main() {

    //setup_adc_ports(NO_ANALOGS|VSS_VDD);
    //setup_adc(ADC_OFF|ADC_TAD_MUL_0);
    //setup_psp(PSP_DISABLED);
    //setup_spi(FALSE);
    //setup_wdt(WDT_OFF);
    setup_timer_0( RTCC_8_BIT|RTCC_DIV_1);
    setup_timer_1(T1_DISABLED);
    //setup_timer_2(T2_DISABLED,0,1);
    //setup_timer_3(T3_DISABLED|T3_DIV_BY_1);
    //setup_comparator(NC_NC_NC_NC);
    //setup_vref(VREF_LOW|-2);
    //setup_low_volt_detect(FALSE);
    //setup_oscillator(OSC_8MHZ);

        set_tris_b(0);

    Rojo=0;
    Verde=0;
    Azul=0;
        Ticks=0;
        ComandoRecibido=false;

        printf ("Jugando con LEDS RGB          Nocturno 2007 - www.micropic.es\n\r\n\r");
        printf ("Introduce el color deseado en formato RxxxGxxxBxxx\n\r");
        printf ("Puedes modificar sólo una componente del color con (R/G/B)xxx\n\r");
        printf ("Si escribes DEMO verás una secuencia de colores\n\r");

        enable_interrupts(INT_RDA);
        enable_interrupts(INT_TIMER0);
        enable_interrupts (GLOBAL);

        while (1) {
                if (ComandoRecibido)
                        ProcesaRGB();
        };

    }
