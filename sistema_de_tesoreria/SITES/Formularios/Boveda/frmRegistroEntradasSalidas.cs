//
//  @ Project : 
//  @ File Name : frmRegistroEntradasSalidas.cs
//  @ Date : 06/08/2011
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

    public enum Movimiento : byte
    {
        Entrada = 0,
        Salida = 1
    }

    public partial class frmRegistroEntradasSalidas : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmRegistroEntradasSalidas()
        {
            InitializeComponent();

            // Llenar el DataGridView

            dgvCierre.Rows.Add("Colones", 0);
            dgvCierre.Rows.Add("50.000", 0);
            dgvCierre.Rows.Add("20.000", 0);
            dgvCierre.Rows.Add("10.000", 0);
            dgvCierre.Rows.Add("5.000", 0);
            dgvCierre.Rows.Add("2.000", 0);
            dgvCierre.Rows.Add("1.000", 0);
            dgvCierre.Rows.Add("500", 0);
            dgvCierre.Rows.Add("100", 0);
            dgvCierre.Rows.Add("50", 0);
            dgvCierre.Rows.Add("25", 0);
            dgvCierre.Rows.Add("10", 0);
            dgvCierre.Rows.Add("2", 0);

            dgvCierre.Rows.Add("Dolares", 0);
            dgvCierre.Rows.Add("100", 0);
            dgvCierre.Rows.Add("50", 0);
            dgvCierre.Rows.Add("20", 0);
            dgvCierre.Rows.Add("10", 0);
            dgvCierre.Rows.Add("5", 0);
            dgvCierre.Rows.Add("1", 0);

            dgvCierre[1, 0].ReadOnly = true;
            dgvCierre[1, 0].Value = string.Empty;
            dgvCierre[1, 0].Style.BackColor = Denominacion.DefaultCellStyle.BackColor;

            dgvCierre[1, 13].ReadOnly = true;
            dgvCierre[1, 13].Value = string.Empty;
            dgvCierre[1, 13].Style.BackColor = Denominacion.DefaultCellStyle.BackColor;

            // Cargar los datos

            try
            {
                cboCliente.DataSource = _mantenimiento.listarClientes(string.Empty);
                cboCanal.DataSource = _mantenimiento.listarCanales();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Selección de un tipo de movimiento.
        /// </summary>
        private void cboMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCanal.Enabled = cboMovimiento.SelectedIndex == (byte)Movimiento.Entrada;
            cboCliente.Enabled = cboMovimiento.SelectedIndex == (byte)Movimiento.Salida;
        }

        #endregion Eventos

    }

}
