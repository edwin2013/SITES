using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System;
using CommonObjects;

namespace GUILayer
{

    public class ManejadorInterfaz
    {

        /*private static string[,] _matriz = new string[CENTENA + 1, 10]
        {
            {" uno", " dos", " tres", " cuatro", " cinco", " seis", " siete", " ocho", " nueve"},
            {" diez"," once"," doce"," trece"," catorce"," quince"," dieciséis"," diecisiete"," dieciocho"," diecinueve"},
            {" veinte", " treinta"," cuarenta"," cincuenta"," sesenta"," setenta"," ochenta"," noventa"},
            {" cien", " doscientos", " trescientos", "cuatrocientos", " quinientos","seiscientos"," setecientos", "ochocientos"," novecientos"}
        };*/

        #region Métodos

        /// <summary>
        /// Eliminar la puntuacion de un string y pasarlo a mayuscula.
        /// </summary>
        /// <<param name="entrada">String al que se le desea dar formato</param>
        /// <returns>String con el formato dado</returns>
        public static string normalizar(string entrada)
        {
            Regex expresion = new Regex("[^a-zA-Z0-9 ]");

            entrada = entrada.Normalize(NormalizationForm.FormD);

            return expresion.Replace(entrada, "").ToUpper();
        }

        public static string numeroAPalabra(int numero)
        {
            if (numero == 0) return "cero";

            if (numero < 0) return "menos " + numeroAPalabra(Math.Abs(numero));

            string palabras = "";
            /*
            if ((numero / 1000000) > 0)
            {
                palabras += numeroAPalabra(numero / 1000000) + " million ";
                number %= 1000000;
            }

            if ((numero / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " mil ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " ciento ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }*/

            return palabras;
        }

        #endregion Métodos

    }

}
