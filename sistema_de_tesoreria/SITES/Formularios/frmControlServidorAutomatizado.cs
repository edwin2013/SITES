//
//  @ Project : 
//  @ File Name : frmControlServidorAutomatizado.cs
//  @ Date : 30/01/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

using LibreriaMensajes;
using LibreriaComunicacion;

namespace GUILayer
{

    public partial class frmControlServidorAutomatizado : Form
    {

        #region Atributos

        private Servidor _servidor = new Servidor();

        #endregion Atributos

        #region Contructor

        public frmControlServidorAutomatizado()
        {
            InitializeComponent();

            string ip = _servidor.optenerIP();

            _servidor.MessageReceived += recibirMensaje;
            _servidor.iniciar(ip, 8001);
        }

        #endregion Contructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de iniciar.
        /// </summary>
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string usuario = txtNombreUsuario.Text;
            string password = txtContrasena.Text;
            string servidor = txtServidor.Text;

            string mensaje = "Iniciar$" + usuario + "$" + password + "$" + servidor;

            this.enviarMensaje(mensaje);
        }

        /// <summary>
        /// Clic en el botón de terminar.
        /// </summary>
        private void btnTerminar_Click(object sender, EventArgs e)
        {
            string mensaje = "Terminar";

            this.enviarMensaje(mensaje);
        }

        /// <summary>
        /// Clic en el botón de mostrar estado.
        /// </summary>
        private void btnEstado_Click(object sender, EventArgs e)
        {
            string mensaje = "Estado";

            this.enviarMensaje(mensaje);
        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            _servidor.detener();

            this.Close();
        }

        /// <summary>
        /// Evento de recepción de mensajes del servidor.
        /// </summary>
        private void recibirMensaje(object sender, ServerEventArgs e)
        {
            string mensaje = e.Mensaje.TrimEnd('\0');

             switch (mensaje)
            {
                case "ServidorConectado":
                    Mensaje.mostrarMensaje("MensajeServidorAutomatizadoConexion");
                    break;
                case "ServidorDesconectado":
                    Mensaje.mostrarMensaje("MensajeServidorAutomatizadoDesconexion");
                    break;
                case "ErrorConexion":
                    Excepcion.mostrarMensaje("ErrorServidorAutomatizadoConexion");
                    break;
                case "EstadoConectado":
                    Mensaje.mostrarMensaje("MensajeServidorAutomatizadoEstadoConectado");
                    break;
                case "EstadoDesconectado":
                    Mensaje.mostrarMensaje("MensajeServidorAutomatizadoEstadoNoConectado");
                    break;
                case "EstadoError":
                    Mensaje.mostrarMensaje("MensajeServidorAutomatizadoEstadoError");
                    break;
                case "EstadoNoError":
                    Mensaje.mostrarMensaje("MensajeServidorAutomatizadoEstadoNoError");
                    break;
            }

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Enviar un mensaje por TCP.
        /// </summary>
        private void enviarMensaje(string mensaje)
        {

            try
            {
                string ip_servidor = txtIP.Text;
                int puerto = int.Parse(mtbPuerto.Text);

                _servidor.enviar(mensaje, ip_servidor, puerto);
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorConexionTCP");
            }

        }

        #endregion Métodos Privados

    }

}
