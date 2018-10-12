//
//  @ Project : 
//  @ File Name : frmServidorDatos.cs
//  @ Date : 30/01/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaAccesoDatos;
using LibreriaMensajes;
using LibreriaComunicacion;

namespace SiAut
{

    public partial class frmServidorDatos : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private BindingList<RegistroRemanentesATM> _remanentes = new BindingList<RegistroRemanentesATM>();

        private Servidor _servidor = new Servidor();

        private DateTime _hora_actualizacion;
        private DateTime _hora_inicio;
        private DateTime _hora_finalizacion;

        private bool _error;
        private bool _conectado;

        #endregion Atributos

        #region Contructor

        public frmServidorDatos()
        {
            InitializeComponent();

            string ip = _servidor.optenerIP();

            try
            {
                string usuario_base = Properties.Settings.Default.UsuarioBD;
                string password_base = Properties.Settings.Default.PassBD;
                string base_datos = Properties.Settings.Default.BaseDatos;
                string servidor = Properties.Settings.Default.ServidorBD;

                // Realizar la conexión con la base de datos SQL

                ManejadorBD.Instancia.conectarse(servidor, base_datos, usuario_base, password_base);
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorDatosConexion");
                this.Close();
            }

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

            if (txtNombreUsuario.Text.Equals(string.Empty) || txtContrasena.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorConexionAS400Datos");
                return;
            }

            try
            {
                string usuario = txtNombreUsuario.Text;
                string password = txtContrasena.Text;
                string servidor = txtServidor.Text;

                // Realizar la conexión con AS400

                ManejadorAS400.Instancia.conectarse(servidor, usuario, password);

                // Salvar la configuración

                Properties.Settings.Default.Save();

                // Iniciar la importación de datos

                this.iniciar();
            }
            catch (Excepcion ex)
            {
                txtContrasena.Text = string.Empty;
                ex.mostrarMensaje();
            }
            catch (Exception)
            {
                txtContrasena.Text = string.Empty;
                Excepcion.mostrarMensaje("ErrorConexionAS400");
            }

        }

        /// <summary>
        /// Clic en el botón de terminar.
        /// </summary>
        private void btnTerminar_Click(object sender, EventArgs e)
        {
            this.terminar();
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
        /// Tick del cronómetro.
        /// </summary>
        private void tmrCronometro_Tick(object sender, EventArgs e)
        {
            this.importarDatos();
        }

        /// <summary>
        /// Evento de recepción de mensajes del servidor.
        /// </summary>
        private void recibirMensaje(object sender, ServerEventArgs e)
        {
          
            try
            {
                string mensaje = e.Mensaje.TrimEnd('\0');

                string[] instrucciones = mensaje.Split('$');

                string comando = instrucciones[0];

                switch (comando)
                {
                    case "Iniciar":
                        string usuario = instrucciones[1];
                        string password = instrucciones[2];
                        string servidor = instrucciones[3];

                        // Realizar la conexión con AS400

                        ManejadorAS400.Instancia.conectarse(servidor, usuario, password);

                        this.iniciar();

                        _servidor.enviar("ServidorConectado", e.Cliente_tcp);

                        break;
                    case "Terminar":
                        this.terminar();

                        _servidor.enviar("ServidorDesconectado", e.Cliente_tcp);
                        break;
                    case "Estado":
                        _servidor.enviar(_conectado ? "EstadoConectado" : "EstadoDesconectado", e.Cliente_tcp);
                        _servidor.enviar(_error ? "EstadoError" : "EstadoNoError", e.Cliente_tcp);
                        break;
                }

            }
            catch (Exception ex)
            {
                txtEstado.Text += DateTime.Now.ToString() + ": " + ex.Message + '\n';
                _error = true;
            }

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Iniciar la actualización de datos.
        /// </summary>
        private void iniciar()
        {
            _hora_inicio = DateTime.Today.Add(dtpHoraInicio.Value.TimeOfDay);
            _hora_finalizacion = DateTime.Today.Add(dtpHoraFinalizacion.Value.TimeOfDay);

            this.importarDatos();

            tmrCronometro.Start();

            dtpHoraInicio.Enabled = false;
            dtpHoraFinalizacion.Enabled = false;

            txtNombreUsuario.Enabled = false;
            txtContrasena.Enabled = false;
            txtServidor.Enabled = false;

            btnIniciar.Enabled = false;
            btnTerminar.Enabled = true;

            _conectado = true;
        }

        /// <summary>
        /// Terminar la actualización de datos.
        /// </summary>
        private void terminar()
        {
            tmrCronometro.Stop();

            dtpHoraInicio.Enabled = true;
            dtpHoraFinalizacion.Enabled = true;

            txtNombreUsuario.Enabled = true;
            txtContrasena.Enabled = true;
            txtServidor.Enabled = true;

            btnIniciar.Enabled = true;
            btnTerminar.Enabled = false;

            _conectado = false;
        }

        /// <summary>
        /// Importar los datos desde AS400
        /// </summary>
        private void importarDatos()
        {
            DateTime fecha = DateTime.Now;

            try
            {
                _remanentes.Clear();

                DataTable datos = _coordinacion.listarRemanentesAS400();

                foreach (DataRow fila in datos.Rows)
                {
                    // Asignar el ATM

                    string valor_numero_atm = (string)fila["CAJLNO"];

                    short numero_atm = short.Parse(valor_numero_atm);

                    ATM atm = new ATM(numero: numero_atm);

                    _mantenimiento.obtenerDatosATM(ref atm);

                    if (atm.ID_Valido)
                    {
                        RegistroRemanentesATM nuevo = new RegistroRemanentesATM(atm: atm, fecha: fecha);

                        // Asignar los remanentes de los cartuchos

                        string codigos = (string)fila["CAJCDI"];

                        this.leerCantidadRemanenteCartucho(codigos[0].ToString(), (decimal)fila["CAJCB1"], nuevo, 1);
                        this.leerCantidadRemanenteCartucho(codigos[1].ToString(), (decimal)fila["CAJCB2"], nuevo, 2);
                        this.leerCantidadRemanenteCartucho(codigos[2].ToString(), (decimal)fila["CAJCB3"], nuevo, 3);
                        this.leerCantidadRemanenteCartucho(codigos[3].ToString(), (decimal)fila["CAJCB4"], nuevo, 4);

                        _remanentes.Add(nuevo);
                    }

                }

                _coordinacion.importarRegistrosRemanentesATMs(_remanentes);

                _error = false;
            }
            catch (Exception ex)
            {
                txtEstado.Text += DateTime.Now.ToString() + ": " + ex.Message + '\n';
                _error = true;
            }

            _hora_actualizacion = fecha;
        }

        /// <summary>
        /// Leer los montos remanentes por denominación de un ATM.
        /// </summary>
        private void leerCantidadRemanenteCartucho(string codigo, decimal remanente, RegistroRemanentesATM registro, byte posicion)
        {
            Denominacion denominacion = new Denominacion(codigo: codigo.ToUpper());

            _mantenimiento.verificarDenominacionCodigo(ref denominacion);

            if (denominacion.ID_Valido)
            {
                short cantidad_remanente = (short)remanente;
                MontoRemanenteATM monto = new MontoRemanenteATM(denominacion, cantidad_remanente, posicion);

                registro.agregarMonto(monto);
            }

        }

        #endregion Métodos Privados

    }

}
