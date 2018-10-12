//
//  @ Project : 
//  @ File Name : frmMontosRetiros.cs
//  @ Date : 30/01/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmMontosRetiros : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmMontosRetiros()
        {
            InitializeComponent();

            try
            {
                dgvMontos.AutoGenerateColumns = false;

                cboATM.ListaMostrada = _mantenimiento.listarATMs();

                cboMonedaLista.SelectedIndex = 0;

                this.actualizarLista();
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de agregar los montos esperados de un ATM.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (cboATM.SelectedItem == null) return;

            try
            {
                ATM atm = (ATM)cboATM.SelectedItem;
                Monedas moneda = (Monedas)cboMoneda.SelectedIndex;

                MontosRetirosATM montos = new MontosRetirosATM(atm, moneda);

                _coordinacion.agregarMontosRetirosATM(ref montos);

                BindingList<MontosRetirosATM> montos_atms = (BindingList<MontosRetirosATM>)dgvMontos.DataSource;

                montos_atms.Add(montos);

                dgvMontos.AutoResizeColumns();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de importar.
        /// </summary>
        private void btnImportar_Click(object sender, EventArgs e)
        {
            frmImportacionMontosEsperadosRetirosATM formulario = new frmImportacionMontosEsperadosRetirosATM();

            formulario.ShowDialog();
        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se modifican los montos esperados del ATM seleccionado.
        /// </summary
        private void dgvMontos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvMontos.RowCount > 0)
            {

                try
                {
                    DataGridViewRow fila = dgvMontos.Rows[e.RowIndex];
                    MontosRetirosATM montos = (MontosRetirosATM)fila.DataBoundItem;

                    _coordinacion.actualizarMontosRetirosATM(montos);

                    dgvMontos.AutoResizeColumns();
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }

        /// <summary>
        /// Se validan los montos digitados.
        /// </summary
        private void dgvMontos_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            decimal monto = 0;

            decimal.TryParse(e.Value.ToString(), out monto);

            e.Value = monto;
            e.ParsingApplied = true;
        }

        /// <summary>
        /// Se selecciona otra moneda para la lista de montos esperados.
        /// </summary
        private void cboMonedaLista_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                this.actualizarLista();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Actualizar las lista de los montos esperados a retirar.
        /// </summary
        private void actualizarLista()
        {

            try
            {
                Monedas moneda = (Monedas)cboMonedaLista.SelectedIndex;

                dgvMontos.DataSource = _coordinacion.listarMontosRetirosATMs(moneda);
            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }

        #endregion Métodos Privados

        private void frmMontosRetiros_Load(object sender, EventArgs e)
        {

        }

    }

}
