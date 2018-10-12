using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace SistemaAyuda
{

    public class ExcepcionSistema : Exception
    {

        #region Constantes

        public const string ERROR_CONEXION = "ErrorConexion";
        public const string ERROR_NOMBRE_TEMA = "ErrorNombreTema";
        public const string ERROR_ELIMINACION_EJERCICIOS = "ErrorEliminacionEjercicio";
        public const string ERROR_CONTRASEÑA = "ErrorContraseña";
        public const string ERROR_IMPRESION = "ErrorImpresion";
        
        #endregion Constantes

        #region Propiedades y Atributos

        private string _identificador_mensaje;

        private string _mensaje;

        private string _titulo;

        #endregion Propiedades y Atributos

        #region Constructor de Clase

        public ExcepcionSistema(string id)
        {
            string[] mensaje_excepcion = leerExcepcion(id);

            _mensaje = mensaje_excepcion [0];
            _titulo = mensaje_excepcion[1];
        }

        #endregion Constructor de Clase

        #region Métodos Privados

        /// <summary>
        /// Leer los mensaje de error de un archivo xml.
        /// </summary>
        ///
        private string[] leerExcepcion(string id)
        {
            string[] mensaje_excepcion = new string[2];
            XmlDocument xDoc = new XmlDocument();

            xDoc.Load("errores.xml");
            XmlNodeList excepciones = xDoc.GetElementsByTagName("errores");
            XmlNodeList excepcion = ((XmlElement)excepciones[0]).GetElementsByTagName(id);

            mensaje_excepcion[0] = ((XmlElement)excepcion[0]).GetElementsByTagName("Mensaje")[0].InnerText;
            mensaje_excepcion[1] = ((XmlElement)excepcion[0]).GetElementsByTagName("Titulo")[0].InnerText;

            return mensaje_excepcion;
        }

        #endregion Métodos Privados

        #region Métodos Públicos

        public void mostrarMensaje()
        {
             MessageBox.Show (_mensaje,_titulo,MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        #endregion Métodos Públicos

    }

}
