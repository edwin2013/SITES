using System;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;

namespace GUILayer
{

    static class Program
    {

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Establecer el separador de decimales

            CultureInfo anterior = Thread.CurrentThread.CurrentCulture;
            CultureInfo nueva = (CultureInfo)anterior.Clone();

            nueva.NumberFormat.NumberDecimalSeparator = ".";
            nueva.NumberFormat.NumberGroupSeparator = ",";
            Thread.CurrentThread.CurrentCulture = nueva;

            CultureInfo cultura = Thread.CurrentThread.CurrentCulture;

            // Ejecutar el menú principal

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMenuPrincipal());
        }

    }

}
