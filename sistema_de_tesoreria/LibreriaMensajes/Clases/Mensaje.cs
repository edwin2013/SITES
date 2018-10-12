using System.Xml;
using System.Windows.Forms;

namespace LibreriaMensajes
{

    public class Mensaje
    {

        #region Propiedades y Atributos

        private string _mensaje;

        public string str_mensaje
        {
            get { return _mensaje; }
        }

        private string _titulo;

        public string str_titulo
        {
            get { return _titulo; }
        }

        #endregion Propiedades y Atributos

        #region Constructor de Clase

        public Mensaje(string id)
        {
            XmlDocument xdc_documento = new XmlDocument();

            xdc_documento.Load(Application.StartupPath + "\\Xml\\mensajes.xml");
            XmlNodeList xml_mensajes = xdc_documento.GetElementsByTagName("mensajes");
            XmlNodeList xml_mensaje = ((XmlElement)xml_mensajes[0]).GetElementsByTagName(id);

            _mensaje = ((XmlElement)xml_mensaje[0]).GetElementsByTagName("Mensaje")[0].InnerText;
            _titulo = ((XmlElement)xml_mensaje[0]).GetElementsByTagName("Titulo")[0].InnerText;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        /// <summary>
        /// Mostrar el mensaje.
        /// </summary>
        public static void mostrarMensaje(string id)
        {
            Mensaje mensaje = new Mensaje(id);

            MessageBox.Show(mensaje.str_mensaje, mensaje.str_titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Mostrar un mensaje de consulta.
        /// </summary>
        public static DialogResult mostrarMensajeConfirmacion(string id)
        {
            Mensaje mensaje = new Mensaje(id);

            return MessageBox.Show(mensaje.str_mensaje, mensaje.str_titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        #endregion Métodos Públicos

    }

}
