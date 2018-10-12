using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriaMensajes;
using CommonObjects;
using BussinessLayer;
using LibreriaReportesOffice;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmManifiestosPendientes : Form
    {

        #region Atributos
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private DataTable manPendientes = new DataTable();
        private Colaborador coordinador;
        #endregion Atributos

        #region Constructor

        public frmManifiestosPendientes(Colaborador coord)
        {
            InitializeComponent();
            this.coordinador = coord;
        }

        #endregion Constructor

        #region Eventos

        private void btnAsignarTula_Click(object sender, EventArgs e)
        {
            if (dgvManifiestos.Rows.Count > 0)
            {
                int index1 = dgvManifiestos.CurrentCell.RowIndex;
                dgvManifiestos.Rows[index1].Cells["Colones"].Value = nudColones.Value;
                int index2 = dgvManifiestos.CurrentCell.RowIndex;
                dgvManifiestos.Rows[index2].Cells["Dolares"].Value = nudDolar.Value;
                int index3 = dgvManifiestos.CurrentCell.RowIndex;
                dgvManifiestos.Rows[index3].Cells["Euros"].Value = nudEuro.Value;
                
            }
            clearNumerics();
        }

        private void clearNumerics()
        {
            nudColones.Value = 0;
            nudDolar.Value = 0;
            nudEuro.Value = 0;
        }

        private void dgvManifiestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            string message = "¿Está seguro que desea terminar?";
            string caption = "Continuar";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                insertManifiestosPendientes();
                this.Close();
            }

        }

        private void insertManifiestosPendientes()
        {
            try
            {
                foreach (DataGridViewRow row in dgvManifiestos.Rows)
                {
                    decimal colones = Decimal.Parse(row.Cells["Colones"].Value.ToString());
                    decimal dolares = Decimal.Parse(row.Cells["Dolares"].Value.ToString());
                    decimal euros = Decimal.Parse(row.Cells["Euros"].Value.ToString());
                    if (colones != 0 || dolares != 0 || euros != 0)
                    {
                        int idManifiesto = Int32.Parse(row.Cells["Id"].Value.ToString());
                        _mantenimiento.insertarMontoManifiestoPendiente(idManifiesto, coordinador, colones, dolares, euros);
                    }


                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }


        }

        #endregion Eventos

        private void btnVer_Click(object sender, EventArgs e)
        {
            clearComponents();
            manPendientes = new DataTable();
            dgvManifiestos.DataSource = null;
            DateTime fechaInicio = Convert.ToDateTime(dtpFechaInicio.Text);
            DateTime fechafin = Convert.ToDateTime(dtpFechaFinal.Text);
            try
            {
                manPendientes = _mantenimiento.manifiestosPendientes(fechaInicio, fechafin);
                dgvManifiestos.DataSource = manPendientes;
                txtCantidad.Text = dgvManifiestos.Rows.Count.ToString();

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("¿Deberia cargar información con el nuevo monto o sin el monto?", "Duda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (manPendientes.Rows.Count > 0)
                {

                    int filaExcel = 2;
                    DocumentoExcel documento = new DocumentoExcel();
                    documento.seleccionarHoja(1);
                    documento.seleccionarCelda("A1");
                    documento.actualizarValorCelda("Manifiesto");
                    documento.seleccionarCelda("B1");
                    documento.actualizarValorCelda("Colones");
                    documento.seleccionarCelda("C1");
                    documento.actualizarValorCelda("Dolares");
                    documento.seleccionarCelda("D1");
                    documento.actualizarValorCelda("Euros");
                    documento.seleccionarCelda("E1");
                    documento.actualizarValorCelda("Fecha de Recepción");
                    documento.seleccionarCelda("F1");
                    documento.actualizarValorCelda("Coordinador");

                    foreach (DataRow row in manPendientes.Rows)
                    {
                        documento.seleccionarCelda("A" + filaExcel);
                        documento.actualizarValorCelda(row["Manifiesto"]);
                        documento.seleccionarCelda("B" + filaExcel);
                        documento.actualizarValorCelda(row["Colones"]);
                        documento.seleccionarCelda("C" + filaExcel);
                        documento.actualizarValorCelda(row["Dolares"]);
                        documento.seleccionarCelda("D" + filaExcel);
                        documento.actualizarValorCelda(row["Euros"]);
                        documento.seleccionarCelda("E" + filaExcel);
                        documento.actualizarValorCelda(row["Fecha de Recepcion"]);
                        documento.seleccionarCelda("F" + filaExcel);
                        //documento.actualizarValorCelda(row["Coordinador"]);
                        filaExcel++;
                    }
                    documento.mostrar();
                    documento.cerrar();
                }
                else
                {
                    MessageBox.Show("No hay datos para mostrar", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch
            {
                MessageBox.Show("Error al generar el excel", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void clearComponents()
        {
            clearNumerics();
            txtCantidad.Clear();
        }

        private void dgvManifiestos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gbAsignacionMonto.Enabled = true;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void frmManifiestosPendientes_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
        #region Métodos Privados



        #endregion Métodos Privados

    }
}
