//
//  @ Project : 
//  @ File Name : Cliente.cs
//  @ Date : 18/08/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LibreriaComunicacion
{

    public class Cliente
    {

        #region Atributos

        private NetworkStream _stream_servidor;
        private TcpClient _cliente;

        private string _mensaje_chat;
        private string _nombre_usuario;

        #endregion Atributos

        #region Constructor
        /*
        public Chat(TcpClient cliente, string nombre_usuario)
        {
            _cliente = cliente;
            _nombre_usuario = nombre_usuario;

            Thread hilo_chat = new Thread(doChat);

            hilo_chat.Start();
        }

        /// <summary>
        /// Cicla el proceso indefinidamente para que el servidor quede a la espera de nuevos mensajes 
        /// por parte de los clientes.
        /// </summary>
        private void recibirMensaje()
        {
            byte[] bytes_desde = new byte[256];
            string mensaje_cliente = null;

            while ((true))
            {
                try
                {
                    NetworkStream network_stream = cliente_chat.GetStream();

                    network_stream.Read(bytes_desde, 0, bytes_desde.Length);

                    mensaje_cliente = System.Text.Encoding.ASCII.GetString(bytes_desde);
                    mensaje_cliente = mensaje_cliente.Substring(0, mensaje_cliente.IndexOf("$"));

                    frmServidor.difundirATodos(mensaje_cliente, nombre_usuario, true);
                }
                catch (Exception)
                {
            
                }
            }
        }

        /// <summary>
        /// Envía un mensaje al servidor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enviarMensaje(object sender, EventArgs e)
        {
            try
            {
                stream_servidor = cliente.GetStream();

                Byte[] datos = Encoding.ASCII.GetBytes(txtMensaje.Text + "$" + txtNombre.Text);

                stream_servidor.Write(datos, 0, datos.Length);
                stream_servidor.Flush();
            }
            catch (Exception ex)
            {
                txtChat.Text = ex.ToString();
            }
        }
        */
    }

#endregion
}
