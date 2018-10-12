//
//  @ Project : 
//  @ File Name : frmLogin.cs
//  @ Date : 24/01/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaAccesoDatos;
using LibreriaMensajes;

using BussinessLayer;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer
{

    public partial class frmLogin : Form
    {

        #region Atributos

        private SeguridadBL _manejador = SeguridadBL.Instancia;

        private frmMenuPrincipal _padre = null;

        #endregion Atributos

        #region Constructor

        public frmLogin(frmMenuPrincipal padre)
        {
            InitializeComponent();

            _padre = padre;

            // Cargar el nombre de usuario

            txtNombreUsuario.Text = Environment.UserName;
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
                Excepcion.mostrarMensaje("ErrorInicioSesionDatos");
                return;
            }

            try
            {
                string usuario_colaborador = txtNombreUsuario.Text;
                string password = txtContrasena.Text;

                string usuario_base = Properties.Settings.Default.UsuarioBD;
                string password_base = Properties.Settings.Default.PassBD;
                string base_datos = Properties.Settings.Default.BaseDatos;
                string servidor = Properties.Settings.Default.ServidorBD;
                string dominio = Properties.Settings.Default.LPAD;

                // Realizar la conexión con la base de datos y verificar que el usuario este registrado

                ManejadorBD.Instancia.conectarse(servidor, base_datos, usuario_base, password_base);

                Colaborador usuario = null;

                usuario = _manejador.obtenerCuentaActiveDirectory(usuario_colaborador, password, dominio);

                // Salvar las configuración

                Properties.Settings.Default.Save();

                // Iniciar la sesion el la ventana principal

                if (usuario.ID > 0)
                {
                    _padre.iniciarSesion(usuario);
                    this.Close();
                }
                else
                {
                    Excepcion.mostrarMensaje("ErrorInicioSesionDatos");
                }

                
            }
            catch (Exception)
            {
                DialogResult boton = MessageBox.Show("Usuario o contraseña incorrectos,¿Desea intentarlo nuevamente?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (boton == DialogResult.Yes)
                    txtContrasena.Text = string.Empty;
                else
                    Application.Exit();
                //Excepcion.mostrarMensaje("ErrorDatosConexion");
            }
           
            //try
            //{
            //    //string usuario_colaborador = txtNombreUsuario.Text;
            //    //string password = txtContrasena.Text;

            //    //string usuario_base = Properties.Settings.Default.UsuarioBD;
            //    //string password_base = Properties.Settings.Default.PassBD;
            //    //string base_datos = txtBaseDatos.Text;
            //    //string servidor = txtServidor.Text;

            //    //// Realizar la conexión con la base de datos y verificar que el usuario este registrado

            //    //ManejadorBD.Instancia.conectarse(servidor, base_datos, usuario_base, password_base);

            //    //Colaborador usuario = _manejador.validarCuentaColaborador(usuario_colaborador, password);

            //    //// Salvar las configuración

            //    //Properties.Settings.Default.Save();

            //    //// Iniciar la sesion el la ventana principal

            //    //_padre.iniciarSesion(usuario);
            //    //this.Close();
            //}
            //catch (Excepcion ex)
            //{
            //    txtContrasena.Text = string.Empty;
            //    ex.mostrarMensaje();
            //}
            //catch (Exception)
            //{
            //    txtContrasena.Text = string.Empty;
            //    Excepcion.mostrarMensaje("ErrorDatosConexion");
            //}

        }

        #endregion Eventos

    }

}
