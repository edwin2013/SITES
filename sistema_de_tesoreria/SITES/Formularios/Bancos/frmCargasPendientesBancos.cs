using BussinessLayer;
using CommonObjects.Clases;
using GUILayer.Formularios.Boveda;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Bancos
{
    public partial class frmCargasPendientesBancos : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private CierreCargaBanco _cierre = null;

        private byte _ruta_valida = byte.MaxValue;

        #endregion Atributos

        #region Constructor

        public frmCargasPendientesBancos(CierreCargaBanco cierre)
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
                PedidoBancos carga = (PedidoBancos)dgvCargasAsignadas.SelectedRows[0].DataBoundItem;

                carga.Cierre = _cierre;

                _coordinacion.actualizarPedidoBancoCierreBanco(carga);

                padre.agregarCargaBancos(carga);

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
            BindingList<PedidoBancos> cargas = (BindingList<PedidoBancos>)dgvCargasAsignadas.DataSource;
            frmCartuchosCarga formulario = new frmCartuchosCarga(cargas);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de revisar los montos por denominación de todas las cargas.
        /// </summary>
        private void btnMontos_Click(object sender, EventArgs e)
        {
            BindingList<PedidoBancos> cargas = (BindingList<PedidoBancos>)dgvCargasAsignadas.DataSource;
            frmMontosCajerosPedidoBancos formulario = new frmMontosCajerosPedidoBancos(cargas);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de revisar los montos por denominación de una carga.
        /// </summary>
        private void btnRevisar_Click(object sender, EventArgs e)
        {
            PedidoBancos carga = (PedidoBancos)dgvCargasAsignadas.SelectedRows[0].DataBoundItem;
            frmModificacionPedidoBancos formulario = new frmModificacionPedidoBancos(carga, _cierre.Cajero, true);

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
                PedidoBancos carga = (PedidoBancos)fila.DataBoundItem;

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
                PedidoBancos carga = (PedidoBancos)fila.DataBoundItem;


               
                    btnRevisar.Enabled = true;
                    btnAceptar.Enabled = true;
               

            }
            else
            {

                btnRevisar.Enabled = false;
                btnAceptar.Enabled = false;
   
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
                dgvCargasAsignadas.DataSource = _coordinacion.listarPedidoBancoPorColaborador(_cierre.Cajero, false);

                foreach (DataGridViewRow fila in dgvCargasAsignadas.Rows)
                {
                    PedidoBancos carga = (PedidoBancos)fila.DataBoundItem;

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
