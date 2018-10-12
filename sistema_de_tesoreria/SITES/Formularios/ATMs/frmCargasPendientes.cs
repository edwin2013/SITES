//
//  @ Project : 
//  @ File Name : frmCargasPendientes.cs
//  @ Date : 22/05/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmCargasPendientes : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private CierreATMs _cierre = null;

        private byte _ruta_valida = byte.MaxValue;

        #endregion Atributos

        #region Constructor

        public frmCargasPendientes(CierreATMs cierre)
        {
            InitializeComponent();

            _cierre = cierre;

            dgvCargasAsignadas.AutoGenerateColumns = false;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Se carga elo formulario.
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
                frmRegistroCierreATMs padre = (frmRegistroCierreATMs)this.Owner;

                CargaATM carga = (CargaATM)dgvCargasAsignadas.SelectedRows[0].DataBoundItem;

                carga.Cierre = _cierre;

                _coordinacion.actualizarCargaATMCierreATMs(carga);

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
            BindingList<CargaATM> cargas = (BindingList<CargaATM>)dgvCargasAsignadas.DataSource;
            frmCartuchosCarga formulario = new frmCartuchosCarga(cargas);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de revisar los montos por denominación de todas las cargas.
        /// </summary>
        private void btnMontos_Click(object sender, EventArgs e)
        {
            BindingList<CargaATM> cargas = (BindingList<CargaATM>)dgvCargasAsignadas.DataSource;
            frmMontosCajeroCargas formulario = new frmMontosCajeroCargas(cargas);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de revisar los montos por denominación de una carga.
        /// </summary>
        private void btnRevisar_Click(object sender, EventArgs e)
        {
            CargaATM carga = (CargaATM)dgvCargasAsignadas.SelectedRows[0].DataBoundItem;
            frmModificacionCarga formulario = new frmModificacionCarga(carga, _cierre.Cajero, true);

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
                CargaATM carga = (CargaATM)fila.DataBoundItem;

                fila.Cells[ATMCargaAsignada.Index].Value = carga.ToString();

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
                CargaATM carga = (CargaATM)fila.DataBoundItem;

                btnMontos.Enabled = true;
                btnCartuchos.Enabled = true;

                if (carga.Ruta == _ruta_valida || carga.Ruta == null)
                {
                    btnRevisar.Enabled = true;
                    btnAceptar.Enabled = true;
                }
                else
                {
                    btnRevisar.Enabled = false;
                    btnAceptar.Enabled = false;
                }

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
                dgvCargasAsignadas.DataSource = _coordinacion.listarCargasATMsPorCajero(_cierre.Cajero, false);

                foreach (DataGridViewRow fila in dgvCargasAsignadas.Rows)
                {
                    CargaATM carga = (CargaATM)fila.DataBoundItem;

                    if (carga.Ruta == _ruta_valida || carga.Ruta == null)
                        fila.DefaultCellStyle.BackColor = Color.LightGreen;

                    if (carga.TipoVisita == TipoVisitas.Carga_Descarga_Papel || carga.TipoVisita == TipoVisitas.Descarga_Papel || carga.TipoVisita == TipoVisitas.Papel)
                    {
                        fila.DefaultCellStyle.BackColor = Color.Plum;
                        fila.Cells["clmPapel"].Value = true; 
                    }

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
