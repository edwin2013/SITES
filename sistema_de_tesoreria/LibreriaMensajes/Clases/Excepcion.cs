using System;
using System.Xml;
using System.Windows.Forms;

namespace LibreriaMensajes
{

    public class Excepcion: Exception
    {

        #region Propiedades y Atributos

        private static string _titulo;

        public static string str_titulo
        {
            get { return _titulo; }
        }

        #endregion Propiedades y Atributos

        #region Constructor de Clase

        public Excepcion(string id) : base(datos(id))
        {
            this.Source = _titulo;
        }

        /// <summary>
        /// Obtener los datos de la excepcion.
        /// </summary>
        public static string datos (string id)
        {
            XmlDocument xdc_documento = new XmlDocument();

            xdc_documento.Load(Application.StartupPath + "\\Xml\\excepciones.xml");
            XmlNodeList xnl_excepciones = xdc_documento.GetElementsByTagName("errores");
            XmlNodeList xnl_excepcion = ((XmlElement)xnl_excepciones[0]).GetElementsByTagName(id);

            _titulo = ((XmlElement)xnl_excepcion[0]).GetElementsByTagName("Titulo")[0].InnerText;
            return ((XmlElement)xnl_excepcion[0]).GetElementsByTagName("Mensaje")[0].InnerText;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Mostrar un mensaje con los datos de una excepción especificada.
        /// </summary>
        public static void mostrarMensaje(string id)
        {
            Excepcion excepcion = new Excepcion(id);
            excepcion.mostrarMensaje();
        }

        /// <summary>
        /// Mostrar un mensaje con los datos de la excepción.
        /// </summary>
        public void mostrarMensaje()
        {
            MessageBox.Show(this.Message, this.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion Métodos Públicos

    }

}
