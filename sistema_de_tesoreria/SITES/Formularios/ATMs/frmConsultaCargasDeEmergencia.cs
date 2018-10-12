using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;

namespace GUILayer
{
    public partial class frmConsultaCargasDeEmergencia : Form
    {
        #region Constructor
        public frmConsultaCargasDeEmergencia()
        {
            InitializeComponent();

             try
            {
                cboATM.ListaMostrada = _mantenimiento.listarATMs();
                cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        #endregion Constructor

         #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Eventos

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    ATM atm = cboATM.SelectedIndex == 0 ?
            //        null : (ATM)cboATM.SelectedItem;
            //    EmpresaTransporte transportadora = !chkProgramados.Checked  || cboTransportadora.SelectedIndex == 0 ?
            //        null : (EmpresaTransporte)cboTransportadora.SelectedItem;
            //    DateTime fecha = dtpFecha.Value;
            //    decimal porcentaje = nudVariacion.Value / 100;
            //    bool programados = chkProgramados.Checked;
            //    bool cargados = chkCargados.Checked;

            //    DataTable datos = _coordinacion.listarRegistrosRemanentesATMsPorDenominacion(atm, fecha, transportadora, programados, cargados);

            //    dgvRemanentes.DataSource = datos;
            //    dgvRemanentes.AutoResizeColumns();

            //    dgvTotales.Rows.Clear();
            //    dgvTotales.Columns.Clear();
            //    dgvEsperados.Rows.Clear();
            //    dgvEsperados.Columns.Clear();

            //    if (datos.Rows.Count == 0) return;

            //    foreach (DataGridViewColumn columna in dgvRemanentes.Columns)
            //    {

            //        if (columna.ValueType == typeof(decimal))
            //        {
            //            dgvTotales.Columns.Add("Total " + columna.Name, columna.HeaderText);
            //            dgvEsperados.Columns.Add("Esperado " + columna.Name, columna.HeaderText);

            //            columna.DefaultCellStyle.Format = "N2";
            //        }

            //    }

            //    dgvTotales.Rows.Add();
            //    dgvEsperados.Rows.Add();

            //    foreach (DataGridViewColumn columna in dgvTotales.Columns)
            //    {
            //        decimal total = (decimal)datos.Compute("Sum([" + columna.HeaderText + "])", "");

            //        decimal esperado = columna.Index > 3 ?
            //            (decimal)datos.Compute("Sum([" + columna.HeaderText + "]) - " +
            //                                   "Sum([" + columna.HeaderText + "]) * " +
            //                                   porcentaje.ToString().Replace(",", "."), "") :
            //            (decimal)datos.Compute("Sum([" + columna.HeaderText + "])", "");

            //        dgvTotales[columna.Index, 0].Value = total;
            //        dgvEsperados[columna.Index, 0].Value = esperado;
            //    }

            //    // Calcular la variación

            //    decimal total_descargado_colones = (decimal)dgvTotales[2, 0].Value;
            //    decimal total_descargado_dolares = (decimal)dgvTotales[3, 0].Value;

            //    decimal total_esperado_colones = (decimal)datos.Compute("Sum([Esperado CRC])", "[Descargado] = True");
            //    decimal total_esperado_dolares = (decimal)datos.Compute("Sum([Esperado USD])", "[Descargado] = True");

            //    decimal diferencia_colones = total_descargado_colones - total_esperado_colones;
            //    decimal diferencia_dolares = total_descargado_dolares - total_esperado_dolares;

            //    decimal porcentaje_diferencia_colones = (diferencia_colones / total_esperado_colones) * 100;
            //    decimal porcentaje_diferencia_dolares = (diferencia_dolares / total_esperado_dolares) * 100;

            //    txtVariacionColones.Text = porcentaje_diferencia_colones.ToString("N2");
            //    txtVariacionDolares.Text = porcentaje_diferencia_dolares.ToString("N2"); 
            //}
            //catch (Excepcion ex)
            //{
            //    ex.mostrarMensaje();
            //}

        }

        /// <summary>
        /// Se marca o desmarca la opción de mostrar los ATM's con cargas programadas.
        /// </summary>
        private void chkProgramados_CheckedChanged(object sender, EventArgs e)
        {
            //cboTransportadora.Enabled = chkProgramados.Checked;
        }

        #endregion Eventos

        private void frmConsultaCargasDeEmergencia_Load(object sender, EventArgs e)
        {

        }
    }
}
