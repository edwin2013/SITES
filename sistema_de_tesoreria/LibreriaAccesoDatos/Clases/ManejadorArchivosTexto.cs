//
//  @ Project : 
//  @ File Name : ManejadorArchivosTexto.cs
//  @ Date : 15/02/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.IO;
using System.Collections.Generic;

namespace LibreriaAccesoDatos
{
    /// <summary>
    /// Clase para la lectura de archivos de texto.
    /// </summary>
    public class ManejadorArchivosTexto
    {

        #region Constantes

        #endregion Constantes

        #region Constructor

        private ManejadorArchivosTexto() { }

        #endregion Constructor

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ManejadorArchivosTexto _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ManejadorArchivosTexto Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ManejadorArchivosTexto();
                return _instancia;
            }
        }

        #endregion Atributos

        #region Métodos

        /// <summary>
        /// Leer un archivo de texto.
        /// </summary>
        /// <param name="archivo">Nombre y localización del archivo de texto</param>
        /// <returns>Cadena de texto con los el texto del archivo</returns>
        public string leerArchivo(string archivo)
        {
            string salida = string.Empty;

            try
            {

                if (File.Exists(archivo))
                {

                    using (StreamReader reader = File.OpenText(archivo))
                    {
                        string linea = string.Empty;

                        while ((linea = reader.ReadLine()) != null)
                            salida += linea + '\n'; 

                    }

                }
                else
                {
                    salida = string.Empty;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return salida.TrimEnd('\n');
        }


        /// <summary>
        /// Escribe los datos en un archivo de texto
        /// </summary>
        /// <param name="archivo">Ruta y nombre de archivo</param>
        /// <param name="separacion">Caracter de separacion por linea</param>
        /// <param name="datos">Lista con los dato a unir por linea</param>
        public bool escribirArchivo(string archivo, char separacion, List<String> datos)
        {
            bool correcto = true;


            FileStream fstream = new FileStream(archivo, FileMode.Append, FileAccess.Write);


            using (StreamWriter flujoEscritura = new StreamWriter(fstream))
            {
                foreach (String s in datos)
                {
                    flujoEscritura.Write(s + separacion);
                   
                    
                }
                flujoEscritura.Write(Environment.NewLine);
            }

           

            return correcto;
        }

        #endregion Métodos

    }

}
