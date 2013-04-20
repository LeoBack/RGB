using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
    public class classInstruccion
    {
        public string Identificador { set; get; }
        public string Valor { set; get; }

        public classInstruccion()
        {
            this.Identificador = string.Empty;
            this.Valor = string.Empty;
        }

        public classInstruccion(string Identificador, string Valor)
        {
            this.Identificador = Identificador;
            this.Valor = Valor;
        }

        public override string ToString()
        {
            return "Identificador = " + this.Identificador + ", Valor = " + this.Valor + "\n";
        }
    }
}
