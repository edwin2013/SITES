//
//  @ Project : 
//  @ File Name : frmRevisionRemanentesATMs.cs
//  @ Date : 25/01/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.Data;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using CommonObjects.Clases;

namespace GUILayer
{

    public partial class frmRevisionRemanentesATMs : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmRevisionRemanentesATMs()
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

            try
            {
                ATM atm = cboATM.SelectedIndex == 0 ?
                    null : (ATM)cboATM.SelectedItem;
                EmpresaTransporte transportadora = !chkProgramados.Checked  || cboTransportadora.SelectedIndex == 0 ?
                    null : (EmpresaTransporte)cboTransportadora.SelectedItem;
                DateTime fecha = dtpFecha.Value;
                decimal porcentaje = nudVariacion.Value / 100;
                bool programados = chkProgramados.Checked;
                bool cargados = chkCargados.Checked;

                DataTable datos = _coordinacion.listarRegistrosRemanentesATMsPorDenominacion(atm, fecha, transportadora, programados, cargados);

                dgvRemanentes.DataSource = datos;
                dgvRemanentes.AutoResizeColumns();

                dgvTotales.Rows.Clear();
                dgvTotales.Columns.Clear();
                dgvEsperados.Rows.Clear();
                dgvEsperados.Columns.Clear();

                if (datos.Rows.Count == 0) return;

                foreach (DataGridViewColumn columna in dgvRemanentes.Columns)
                {

                    if (columna.ValueType == typeof(decimal))
                    {
                        dgvTotales.Columns.Add("Total " + columna.Name, columna.HeaderText);
                        dgvEsperados.Columns.Add("Esperado " + columna.Name, columna.HeaderText);

                        columna.DefaultCellStyle.Format = "N2";
                    }

                }

                dgvTotales.Rows.Add();
                dgvEsperados.Rows.Add();

                foreach (DataGridViewColumn columna in dgvTotales.Columns)
                {

                    decimal total = 0;
                    decimal esperado = 0;
                    if (columna.Index  < 6)
                    {
                        total = (decimal)datos.Compute("Sum([" + columna.HeaderText + "])", "");
                        
                        esperado = 

                            (decimal)datos.Compute("Sum([" + columna.HeaderText + "]) - " +
                                                   "Sum([" + columna.HeaderText + "]) * " +
                                                   porcentaje.ToString().Replace(",", "."), "") ;
                            
                    }
                    else if (columna.Index > 5)
                    {
                        //total = (decimal)datos.Compute("Sum([" + columna.HeaderText + "])", "");
                        //esperado = 

                        //(decimal)datos.Compute("Sum([" + columna.HeaderText + "]) - " +
                        //                       "Sum([" + columna.HeaderText + "]) * " +
                        //                       porcentaje.ToString().Replace(",", "."), "");

                        foreach (DataGridViewRow row in dgvRemanentes.Rows)
                        {
                            //
                            // Se selecciona la celda del checkbox
                            //
                            DataGridViewCheckBoxCell cellSelecion = row.Cells["Cargado"] as DataGridViewCheckBoxCell;

                            //
                            // Se valida si esta checkeada
                            //
                            //if (Convert.ToBoolean(cellSelecion.Value))
                            //{
                                //
                                // Se valida si el usuario ingreso un valor en la celda de pedido
                                //
                                // decimal pedido = 0;
                                //if (!decimal.TryParse(Convert.ToString(row.Cells[columna.HeaderText].Value), out pedido))
                                //    continue;

                                //
                                // Se realiza el calculo para la fila, asignado el total en la celda "Total"
                                // de la misma
                                //
                                decimal totalFila = Convert.ToDecimal(row.Cells[columna.HeaderText].Value);
                                    //*pedido;
                               // row.Cells["Total"].Value = totalFila;

                                //
                                // Se aumula el total de cada una de las filas
                                //
                                total += totalFila;
                                esperado += ( totalFila - (totalFila * porcentaje));
                                     
                              //  dgvTotales[columna.Index, 0].Value = totalFila;
                            //}

                        }
                    }
                    else
                    {
                        total=(decimal)datos.Compute("Sum([" + columna.HeaderText + "])", "");
                         esperado = 
                        (decimal)datos.Compute("Sum([" + columna.HeaderText + "])", "");
                    }

                  
                  dgvTotales[columna.Index, 0].Value = total;
                  dgvEsperados[columna.Index, 0].Value = esperado;
                }

                // Calcular la variación

                decimal total_descargado_colones = (decimal)dgvTotales[2, 0].Value;
                decimal total_descargado_dolares = (decimal)dgvTotales[3, 0].Value;

                decimal total_esperado_colones = (decimal)datos.Compute("Sum([Esperado CRC])", "[Descargado] = True");
                decimal total_esperado_dolares = (decimal)datos.Compute("Sum([Esperado USD])", "[Descargado] = True");


                decimal total_descargado_esperado_colones = (decimal)dgvEsperados[4, 0].Value;
                decimal total_descargado_esperado_dolares = (decimal)dgvEsperados[5, 0].Value;

                decimal diferencia_colones = total_descargado_colones - total_esperado_colones;
                decimal diferencia_dolares = total_descargado_dolares - total_esperado_dolares;

                decimal porcentaje_diferencia_colones = (diferencia_colones / total_esperado_colones) * 100;
                decimal porcentaje_diferencia_dolares = (diferencia_dolares / total_esperado_dolares) * 100;

                txtVariacionColones.Text = porcentaje_diferencia_colones.ToString("N2");
                txtVariacionDolares.Text = porcentaje_diferencia_dolares.ToString("N2");

                PromedioRemanenteATM nuevo = _mantenimiento.listarPromedioRemanenteATM();

                if (chkQuincena.Checked)
                {
                    if (total_descargado_esperado_colones > nuevo.MontoQuincena || total_descargado_esperado_dolares > nuevo.MontoQuincenaDolares)
                        lblAviso.Visible = true;
                    else
                        lblAviso.Visible = false;

                }
                else
                {
                    if (total_descargado_esperado_colones > nuevo.Monto || total_descargado_esperado_dolares > nuevo.MontoDolares)
                        lblAviso.Visible = true;
                    else
                        lblAviso.Visible = false;
                }



            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Se marca o desmarca la opción de mostrar los ATM's con cargas programadas.
        /// </summary>
        private void chkProgramados_CheckedChanged(object sender, EventArgs e)
        {
            cboTransportadora.Enabled = chkProgramados.Checked;
        }

        #endregion Eventos

        private void frmRevisionRemanentesATMs_Load(object sender, EventArgs e)
        {

        }

    }

}
