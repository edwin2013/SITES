using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace SistemaAyuda
{

    public class MensajeSistema
    {

        #region Constantes

        public const string ELIMINAR_TEMA = "MensajeEliminarTema";
        public const string ELIMINAR_EJERCICIO = "MensajeEliminarEjercicio";
        public const string ELIMINAR_PRACTICA = "MensajeEliminarPractica";

        public const string CONFIRMACION_ELIMINAR_TEMA = "MensajeConfirmacionEliminarTema";
        public const string CONFIRMACION_ELIMINAR_EJERCICIO = "MensajeConfirmacionEliminarEjercicio";
        public const string CONFIRMACION_ELIMINAR_PRACTICA = "MensajeConfirmacionEliminarPractica";
        public const string CONFIRMACION_GUARDAR_PRACTICA = "MensajeConfirmacionGuardadoPractica";
        public const string CONFIRMACION_IMPRESION = "MensajeConfirmacionImpresion";
      
        #endregion Constantes

        #region Propiedades y Atributos

        private string _identificador_mensaje;

        private string _mensaje;

        private string _titulo;

        #endregion Propiedades y Atributos

        #region Constructor de Clase

        public MensajeSistema(string id)
        {
            string[] mensaje_excepcion = leerMensaje(id);

            _mensaje = mensaje_excepcion [0];
            _titulo = mensaje_excepcion[1];
        }

        #endregion Constructor de Clase

        #region Métodos Privados

        /// <summary>
        /// Leer los mensaje de un archivo xml.
        /// </summary>
        ///
        private string[] leerMensaje(string id)
        {
            string[] mensaje_salida = new string[2];
            XmlDocument xDoc = new XmlDocument();

            xDoc.Load("mensajes.xml");
            XmlNodeList mensajes = xDoc.GetElementsByTagName("mensajes");
            XmlNodeList mensaje = ((XmlElement)mensajes[0]).GetElementsByTagName(id);

            mensaje_salida[0] = ((XmlElement)mensaje[0]).GetElementsByTagName("Mensaje")[0].InnerText;
            mensaje_salida[1] = ((XmlElement)mensaje[0]).GetElementsByTagName("Titulo")[0].InnerText;

            return mensaje_salida;
        }

        #endregion Métodos Privados

        #region Métodos Públicos

        public bool mostrarMensajeOKCancel()
        {
            DialogResult resultado =  MessageBox.Show (_mensaje,_titulo,MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if (resultado == DialogResult.OK) return true;
            else return false;

        }

        public void mostrarMensajeOK()
        {
            MessageBox.Show(_mensaje, _titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion Métodos Públicos

    }

}
