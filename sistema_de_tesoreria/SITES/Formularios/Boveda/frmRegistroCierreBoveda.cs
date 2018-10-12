//
//  @ Project : 
//  @ File Name : frmRegistroCierreBoveda.cs
//  @ Date : 19/03/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using LibreriaReportesOffice;

namespace GUILayer
{

    public partial class frmRegistroCierreBoveda : Form
    {

        #region Atributos

        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;


        private Colaborador _coordinador = null;

        private bool _supervisor = false;

        #endregion Atributos

        #region Constructor

        public frmRegistroCierreBoveda(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            try
            {
                //this.actualizarListaCierres();
                //this.actualizarListaManifiestos();

                cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.Boveda, Puestos.CajeroA, Puestos.CajeroB);
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

            // Crear las tablas

            this.crearTabla(dgvMontos);
            this.crearTabla(dgvMontosConsolidado);

            // Dar fomato a las filas

            this.formatoCeldaSoloLectura(dgvMontos, 13, 21);
            this.formatoCeldaSoloLectura(dgvMontosConsolidado, 13, 21);

            this.formatoCeldaSeparador(dgvMontos,0, 14);
            this.formatoCeldaSeparador(dgvMontosConsolidado, 0, 14);

            // Validar si el usuario puede cambiar la fecha del cierre

            _supervisor = coordinador.Puestos.Contains(Puestos.Supervisor);

            // Establecer el separador de decimales

            CultureInfo anterior = System.Threading.Thread.CurrentThread.CurrentCulture;
            CultureInfo nueva = (CultureInfo)anterior.Clone();

            nueva.NumberFormat.NumberDecimalSeparator = ".";
            nueva.NumberFormat.NumberGroupSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture = nueva;

            CultureInfo cultura = System.Threading.Thread.CurrentThread.CurrentCulture;
        }

        /// <summary>
        /// Crear las filas de los DataGridView's.
        /// </summary>
        private void crearTabla(DataGridView tabla)
        {
            tabla.Rows.Add("Colones", string.Empty);
            tabla.Rows.Add("50.000", 0);
            tabla.Rows.Add("20.000", 0);
            tabla.Rows.Add("10.000", 0);
            tabla.Rows.Add("5.000", 0);
            tabla.Rows.Add("2.000", 0);
            tabla.Rows.Add("1.000", 0);
            tabla.Rows.Add("500", 0);
            tabla.Rows.Add("100", 0);
            tabla.Rows.Add("50", 0);
            tabla.Rows.Add("25", 0);
            tabla.Rows.Add("10", 0);
            tabla.Rows.Add("5", 0);
            tabla.Rows.Add("Total", 0);
            tabla.Rows.Add("Dólares", string.Empty);
            tabla.Rows.Add("100", 0);
            tabla.Rows.Add("50", 0);
            tabla.Rows.Add("20", 0);
            tabla.Rows.Add("10", 0);
            tabla.Rows.Add("5", 0);
            tabla.Rows.Add("1", 0);
            tabla.Rows.Add("Total", 0);
        }

        /// <summary>
        /// Dar formato de solo lectura a las filas que lo requieran.
        /// </summary>
        private void formatoCeldaSoloLectura(DataGridView tabla, params int[] filas)
        {

            foreach (int fila in filas)
            {
                tabla.Rows[fila].ReadOnly = true;
                tabla.Rows[fila].DefaultCellStyle.BackColor = Denominacion.DefaultCellStyle.BackColor;
            }

        }

        /// <summary>
        /// Dar formato a las celdas que son separadoras.
        /// </summary>
        private void formatoCeldaSeparador(DataGridView tabla, params int[] filas)
        {

            foreach (int fila in filas)
            {
                tabla.Rows[fila].ReadOnly = true;
                tabla.Rows[fila].DefaultCellStyle.BackColor = tabla.GridColor;
            }

        }

        #endregion Constructor

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

    }

}
