//
//  @ Project : 
//  @ File Name : frmCambioContrasena.cs
//  @ Date : 13/10/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmCambioContrasena : Form
    {

        #region Atributos

        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private Colaborador _usuario = null;

        #endregion Atributos

        #region Constructor

        public frmCambioContrasena(Colaborador usuario)
        {
            InitializeComponent();

            _usuario = usuario;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Click en el bóton de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                string contrasena_anterior = txtContrasenaAnterior.Text;
                string contrasena_nueva = txtNuevaContrasena.Text;
                string contrasena_repetida = txtRepetirNuevaContrasena.Text;

                if (!contrasena_nueva.Equals(contrasena_repetida))
                    throw new Excepcion("ErrorColaboradorDatosActualizacionContrasena");

                _seguridad.actualizarColaboradorContrasena(_usuario, contrasena_nueva, contrasena_anterior);

                Mensaje.mostrarMensaje("MensajeColaboradorConfirmacionActualizacionContrasena");

                this.Close();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Click en el bóton de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se cambia el texto de las contraseñas.
        /// </summary>
        private void txtContrasenaAnterior_TextChanged(object sender, EventArgs e)
        {
            btnAceptar.Enabled = txtContrasenaAnterior.Text.Length > 0 &
                                 txtNuevaContrasena.Text.Length > 0 &
                                 txtRepetirNuevaContrasena.Text.Length > 0;
        }

        #endregion Eventos

    }

}
