//
//  @ Project : 
//  @ File Name : Servidor.cs
//  @ Date : 20/09/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LibreriaComunicacion
{

    public class ServerEventArgs : EventArgs
    {
        private string mensaje;
        private TcpClient cliente_tcp;

        public ServerEventArgs(string mensaje, TcpClient cliente_tcp)
        {
            this.mensaje = mensaje;
            this.cliente_tcp = cliente_tcp;
        }

        public string Mensaje
        {
            get { return mensaje; }
        }

        public TcpClient Cliente_tcp
        {
            get { return cliente_tcp; }
        }

    }

    public class Servidor
    {

        #region Atributos

        private TcpListener _servidor;
        private Thread _hilo_servidor;

        private int _puerto;

        #endregion Atributos

        #region Contructor

        #endregion Contructor

        #region Eventos

        public delegate void MessageEventHandler(Object sender, ServerEventArgs e);

        public event MessageEventHandler MessageReceived;

        protected virtual void OnMessageReceived(ServerEventArgs e)
        {
            MessageReceived(this, e);
        }

        #endregion Eventos

        #region Métodos Públicos

        /// <summary>
        /// Iniciar el servidor.
        /// </summary>
        public void iniciar(string direccion_ip, int puerto)
        {
            _puerto = puerto;

            _servidor = new TcpListener(IPAddress.Parse(direccion_ip), _puerto);

            _hilo_servidor = new Thread(new ThreadStart(escuchar));
            _hilo_servidor.Start();
        }

        /// <summary>
        /// Escuchar si se recibe algún mensaje.
        /// </summary>
        private void escuchar()
        {

            try
            {
                _servidor.Start();

                while (true)
                {
                    TcpClient cliente_remitente = _servidor.AcceptTcpClient();
                    Byte[] bytes_cliente = new Byte[256];
                    NetworkStream stream_cliente = cliente_remitente.GetStream();

                    stream_cliente.Read(bytes_cliente, 0, bytes_cliente.Length);

                    string mensaje = Encoding.ASCII.GetString(bytes_cliente, 0, bytes_cliente.Length);

                    OnMessageReceived(new ServerEventArgs(mensaje, cliente_remitente));

                    cliente_remitente.Close();
                }
                
            }
            catch (Exception ex)
            {
                //throw ex;
            }

        }

        /// <summary>
        /// Detener el servidor.
        /// </summary>
        public void detener()
        {
            _hilo_servidor.Abort();
            _servidor.Stop();
        }

        /// <summary>
        /// Enviar un mensaje mediante una dirección ip y un puerto.
        /// </summary>
        public void enviar(string mensaje, string ip, int puerto)
        {

            try
            {
                TcpClient cliente_tcp = new TcpClient(ip, puerto);

                this.enviarMensaje(mensaje, cliente_tcp);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Enviar un mensaje mediante un cliente tcp.
        /// </summary>
        public void enviar(string mensaje, TcpClient cliente_tcp)
        {

            try
            {
                IPEndPoint endpoint = (IPEndPoint)cliente_tcp.Client.RemoteEndPoint;
                IPAddress ip = endpoint.Address;

                TcpClient cliente = new TcpClient(ip.ToString(), _puerto);

                this.enviarMensaje(mensaje, cliente);
            }
            catch (Exception ex)
            {
                //throw ex;
            }

        }

        /// <summary>
        /// Obtener la dirección ip de la computadora
        /// </summary>
        public string optenerIP()
        {
            string host = Dns.GetHostName();
            IPHostEntry ip = Dns.GetHostEntry(host);

            return ip.AddressList[0].ToString();
        }

        #endregion Métodos Públicos

        #region Métodos Privados

        /// <summary>
        /// Enviar un mensaje  a un cliente.
        /// </summary>
        private void enviarMensaje(string mensaje, TcpClient cliente_tcp)
        {

            try
            {
                Byte[] bytes = Encoding.ASCII.GetBytes(mensaje);
                NetworkStream stream_cliente = cliente_tcp.GetStream();

                stream_cliente.Write(bytes, 0, bytes.Length);
                stream_cliente.Flush();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Métodos Privados

    }

}
