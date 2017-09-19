using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ChangeString
    {
        private char[] Abecedario = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p',
                                       'q', 'r','s', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        public string build(string cadena)
        {
            string result="";
            for (int i = 0; i < cadena.Length; i++)
            {
                result += reemplazar(cadena[i]);
            }
            return result;
        }
        private char reemplazar(char caracter)
        {
            int posicion = Array.IndexOf(Abecedario,char.ToLower(caracter));
            if (posicion < 0)
                return caracter;
            else if (posicion == Abecedario.Count() - 1)
                posicion = 0;
            else
                posicion = posicion + 1;
            if (char.IsUpper(caracter))
                return char.ToUpper(Abecedario[posicion]);
            else
                return Abecedario[posicion];
        }
    }
}
