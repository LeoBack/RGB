using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
    public class classCodificador
    {
        /*
         * 1 - Recorto parametros.
         * 2 - Recorto nombre y valor.
         * 3 - Aplicar cambios.
         * 
         * Valore que decodifica:
         * r=100|g=50|b=255|
         * r=255
         */

        #region Atributos

        public char SeparadorInstrucciones { set; get; }
        public char SeparadorIdentificadorValor { set; get; }
        public StringBuilder BufferString { set; get; }

        private List<string> SetInstrucciones;
        private string Buffer;

        #endregion

        #region Constructores

        public classCodificador()
        {
            this.SeparadorInstrucciones = '|';
            this.SeparadorIdentificadorValor = '=';
            this.SetInstrucciones = new List<string>();
            this.BufferString = null;
            this.Buffer = string.Empty;
        }

        public classCodificador(char SeparadorInstrucciones, char SeparadorNombreValor)
        {
            this.SeparadorInstrucciones = SeparadorInstrucciones;
            this.SeparadorIdentificadorValor = SeparadorNombreValor;
            this.SetInstrucciones = new List<string>();
            this.BufferString = null;
            this.Buffer = string.Empty;
        }

        public classCodificador(StringBuilder BufferString, char SeparadorInstrucciones, char SeparadorNombreValor)
        {
            this.SeparadorInstrucciones = SeparadorInstrucciones;
            this.SeparadorIdentificadorValor = SeparadorNombreValor;
            this.SetInstrucciones = new List<string>();
            this.BufferString = BufferString;
            this.Buffer = string.Empty;
        }

        #endregion

        //----------------------------------------------------------

        /// <summary>
        /// Decodifica BufferString.
        /// </summary>
        /// <returns>Array de Intrucciones</returns>
        public classInstruccion[] DecodificarBuffer()
        {
            List<classInstruccion> lIns = new List<classInstruccion>();
            this.Buffer = BufferString.ToString();
            this.Buffer.Replace(' ', 'n');

            //------------------------------------------------------------
            // Si no coincida Agrega caracter final de insttruccion.
            if (this.Buffer.LastIndexOf(this.SeparadorInstrucciones) != (this.BufferString.Length - 1))
                this.Buffer += this.SeparadorInstrucciones;

            this.BufferString.Clear();
            //------------------------------------------------------------
            string PreInstruccion = string.Empty;

            foreach (char Letter in Buffer)
            {
                if (!char.Equals(this.SeparadorInstrucciones, Letter))
                {
                    PreInstruccion += Letter.ToString();
                    this.Buffer.Remove(0, 1);
                }
                else
                {
                    this.SetInstrucciones.Add(PreInstruccion);
                    PreInstruccion = string.Empty;
                }
            }
            //------------------------------------------------------------
            foreach (string Instruccion in SetInstrucciones)
            {
                if (Instruccion.Contains(this.SeparadorIdentificadorValor))
                {
                    classInstruccion Ins = new classInstruccion();
                    Ins.Identificador = Instruccion.Substring(0, Instruccion.IndexOf(this.SeparadorIdentificadorValor));
                    Ins.Valor = Instruccion.Substring(
                        (Instruccion.IndexOf(this.SeparadorIdentificadorValor) + 1), 
                        Instruccion.Length - (Instruccion.IndexOf(this.SeparadorIdentificadorValor) + 1));
                    lIns.Add(Ins);
                }
            }
            return lIns.ToArray();
        }

        //----------------------------------------------------------

        /// <summary>
        /// Construye intruccion.
        /// </summary>
        /// <param name="Instrucciones">Instruccion</param>
        /// <returns>Instruccion</returns>
        public string SetIntruccion(classInstruccion Instrucciones)
        {
            return Instrucciones.Identificador + this.SeparadorIdentificadorValor + Instrucciones.Valor + SeparadorInstrucciones;
        }

        //-------------------------------------------------------------
    }
}
