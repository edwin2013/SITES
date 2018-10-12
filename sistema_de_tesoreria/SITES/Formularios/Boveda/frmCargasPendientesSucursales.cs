using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects.Clases;
using BussinessLayer;
using LibreriaMensajes;
using GUILayer.Formularios.Boveda;

namespace GUILayer.Formularios.Blindados
{
    public partial class frmCargasPendientesSucursales : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private CierreCargaSucursal _cierre = null;

        private byte _ruta_valida = byte.MaxValue;

        #endregion Atributos

        #region Constructor

        public frmCargasPendientesSucursales(CierreCargaSucursal cierre)
        {
            InitializeComponent();

            _cierre = cierre;
     
            dgvCargasAsignadas.AutoGenerateColumns = false;
            //cargarPendientes();
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Se carga el formulario.
        /// </summary>
        private void frmCargasPendientes_Load(object sender, EventArgs e)
        {

            try
            {
                this.actualizarlista();
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                this.actualizarlista();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarPendientes();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }



        private void cargarPendientes()
        {
            try
            {
                frmRevisionCierreSucursales padre = (frmRevisionCierreSucursales)this.Owner;
                padre.Show();
                CargaSucursal carga = (CargaSucursal)dgvCargasAsignadas.SelectedRows[0].DataBoundItem;

                carga.Cierre = _cierre;

                _coordinacion.actualizarCargaSucursalCierreSucursal(carga);

                padre.agregarCarga(carga);

                this.Close();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Clic en el botón de revisar los cartuchos por denominación y tipo.
        /// </summary>
        private void btnCartuchos_Click(object sender, EventArgs e)
        {
            BindingList<CargaSucursal> cargas = (BindingList<CargaSucursal>)dgvCargasAsignadas.DataSource;
            frmCartuchosCarga formulario = new frmCartuchosCarga(cargas);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de revisar los montos por denominación de todas las cargas.
        /// </summary>
        private void btnMontos_Click(object sender, EventArgs e)
        {
            BindingList<CargaSucursal> cargas = (BindingList<CargaSucursal>)dgvCargasAsignadas.DataSource;
            frmMontosCajeroCargasSucursales formulario = new frmMontosCajeroCargasSucursales(cargas);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de revisar los montos por denominación de una carga.
        /// </summary>
        private void btnRevisar_Click(object sender, EventArgs e)
        {
            CargaSucursal carga = (CargaSucursal)dgvCargasAsignadas.SelectedRows[0].DataBoundItem;
            frmModificacionCargaSucursal formulario = new frmModificacionCargaSucursal(carga, _cierre.Cajero, true);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de cancelar.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se agrega una carga a la lista de cargas.
        /// </summary>
        private void dgvCargasAsignadas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCargasAsignadas.Rows[e.RowIndex + contador];
                CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;

                fila.Cells[SucursalCarga.Index].Value = carga.ToString();

                if (carga.Ruta != null)
                    _ruta_valida = Math.Min((byte)carga.Ruta, _ruta_valida);

            }

        }

        /// <summary>
        /// Se selecciona una carga de la lista de cargas asignadas.
        /// </summary>
        private void dgvCargasAsignadas_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCargasAsignadas.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvCargasAsignadas.SelectedRows[0];
                CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;

                btnMontos.Enabled = true;
                btnCartuchos.Enabled = true;

               
                    btnRevisar.Enabled = true;
                    btnAceptar.Enabled = true;
               

            }
            else
            {
                btnMontos.Enabled = false;
                btnRevisar.Enabled = false;
                btnAceptar.Enabled = false;
                btnCartuchos.Enabled = false;
            }

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Actualizar la lista de cargas asignadas.
        /// </summary>
        private void actualizarlista()
        {

            try
            {
                dgvCargasAsignadas.DataSource = _coordinacion.listarCargasSucursalesPorColaborador(_cierre.Cajero, false);

                foreach (DataGridViewRow fila in dgvCargasAsignadas.Rows)
                {
                    CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;

                    if (carga.Ruta == _ruta_valida || carga.Ruta == null)
                        fila.DefaultCellStyle.BackColor = Color.LightGreen;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Métodos Privados

    }
}
