using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects.Clases;
using LibreriaMensajes;
using BussinessLayer;
using CommonObjects;

namespace GUILayer.Formularios.Boveda
{
    public partial class frmVerificacionPedidoSucursal : Form
    {
         
        #region Atributos

        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private CargaSucursal _carga = null;
        private Colaborador _colaborador = null;

        #endregion Atributos

        #region Constructor

        public frmVerificacionPedidoSucursal(CargaSucursal carga)
        {
            InitializeComponent();

            _carga = carga;

            dgvCartuchos.AutoGenerateColumns = false;
            dgvCartuchos.DataSource = _carga.Cartuchos;

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de verificar el código del empleado.
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

                this.verificarRevision();
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

            try
            {
                _carga.Colaborador_verificador = _colaborador;

                _coordinacion.actualizarCargaSucursalDatosVerificacion(_carga);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de cancelar.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se agregan cartuchos a la lista de cartuchos.
        /// </summary>
        private void dgvCartuchos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCartuchos.Rows[e.RowIndex + contador];
                CartuchoCargaSucursal cartucho = (CartuchoCargaSucursal)fila.DataBoundItem;
                Denominacion denominacion = cartucho.Denominacion;

              
            }

        }

        /// <summary>
        /// Se marca o desmarca un cartucho como revisado.
        /// </summary>
        private void dgvCartuchos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Revisado.Index) this.verificarRevision();
        }

        /// <summary>
        /// Actualizar el estado de las celdas.
        /// </summary>
        private void dgvCartuchos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCartuchos.IsCurrentCellDirty) dgvCartuchos.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

       
        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Validar que se hayan revisado todos los cartuchos y que el revisor se haya identificado.
        /// </summary>
        private void verificarRevision()
        {
            
            if (_colaborador == null)
            {
                btnAceptar.Enabled = false;
            }
            else
            {
                bool revisado = true;
                bool estado = false;

                foreach (DataGridViewRow fila in dgvCartuchos.Rows)
                {
                    DataGridViewCheckBoxCell celda_revisado = (DataGridViewCheckBoxCell)fila.Cells[Revisado.Index];
                    if(celda_revisado.Value == null)
                        estado = false; 
                    else
                        estado = (bool)celda_revisado.Value;

                    if (!estado)
                    {
                        revisado = false;
                        break;
                    }

                }


                btnAceptar.Enabled = revisado;
            }

        }

        #endregion Métodos Privados
    }
}
