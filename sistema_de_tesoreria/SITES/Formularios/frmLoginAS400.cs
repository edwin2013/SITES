//
//  @ Project : 
//  @ File Name : frmLoginAS400.cs
//  @ Date : 10/01/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

using BussinessLayer;
using LibreriaAccesoDatos;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmLoginAS400 : Form
    {

        #region Atributos

        #endregion Atributos

        #region Constructor

        public frmLoginAS400()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            this.Close();
        }

        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
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

                // Salvar las configuración

                Properties.Settings.Default.Save();

                // Iniciar la sesion el la ventana principal

                this.Close();
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

        #endregion Eventos

    }

}
