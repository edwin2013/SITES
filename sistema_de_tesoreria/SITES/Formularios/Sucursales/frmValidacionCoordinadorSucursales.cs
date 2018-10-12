using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Sucursales
{
    public partial class frmValidacionCoordinadorSucursales : Form
    {
        #region Atributos

        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _colaborador = null;
        CargaSucursal _carga = null;

        #endregion Atributos

        #region Constructor

        public frmValidacionCoordinadorSucursales(ref CargaSucursal c)
        {
            InitializeComponent();
            _carga = c;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de verificar el código del colaborador.
        /// </summary>
        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Equals(string.Empty) || txtContrasena.Text.Equals(string.Empty))
                return;

            try
            {
                string codigo = txtCodigo.Text;
                string contrasena = txtContrasena.Text;

                _colaborador = _seguridad.validarCodigoColaborador(codigo, contrasena);

                txtNombre.Text = _colaborador.ToString();
                txtIdentificacion.Text = _colaborador.Identificacion;

                _carga.ColaboradorVerificadorTransportadora = _colaborador;

                btnAceptar.Enabled = _colaborador.Puestos.Contains(Puestos.Coordinador) ||
                                     _colaborador.Puestos.Contains(Puestos.Supervisor);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();

                _colaborador = null;

                txtNombre.Text = string.Empty;
                txtIdentificacion.Text = string.Empty;

                btnAceptar.Enabled = false;
            }

            txtCodigo.Text = string.Empty;
            txtContrasena.Text = string.Empty;
        }

        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            this.Close();

        }

        /// <summary>
        /// Clic en el botón de cancelar.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Eventos
    }
}
