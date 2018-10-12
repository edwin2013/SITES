//
//  @ Project : 
//  @ File Name : frmGestionesTeminadas.cs
//  @ Date : 02/11/2011
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

    public partial class frmGestionesTeminadas : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private bool _supervisor = false;

        #endregion Atributos

        #region Constructor

        public frmGestionesTeminadas(Colaborador coordinador)
        {
            InitializeComponent();

            _supervisor = coordinador.Puestos.Contains(Puestos.Supervisor);

            DateTime ahora = DateTime.Now;
            DateTime inicio = new DateTime(ahora.Year, ahora.Month, ahora.Day, 0, 0, 0);
            DateTime fin = new DateTime(ahora.Year, ahora.Month, ahora.Day, 23, 59, 59);

            dtpInicio.Value = inicio.AddDays(-7);
            dtpFinalizacion.Value = fin;

            try
            {
                // Generar la lista de gestiones

                dgvGestiones.AutoGenerateColumns = false;

                this.filtrarPorFecha();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                this.filtrarPorFecha();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de revisar.
        /// </summary>
        private void btnRevisar_Click(object sender, EventArgs e)
        {
            this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se selecciona otra gestion.
        /// </summary>
        private void dgvGestiones_SelectionChanged(object sender, EventArgs e)
        {
            btnRevisar.Enabled = dgvGestiones.RowCount > 0;
        }

        /// <summary>
        /// Se da formato a las filas.
        /// </summary>
        private void dgvGestiones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex == ID.Index)
            {
                Gestion gestion = (Gestion)dgvGestiones.Rows[e.RowIndex].DataBoundItem;

                // Depositos

                String depositos = string.Empty;

                foreach (Deposito deposito in gestion.Depositos)
                    depositos += deposito.Referencia.ToString() + '\n';

                dgvGestiones[Depositos.Index, e.RowIndex].Value = depositos.TrimEnd('\n');

                // Manifiestos

                String manifiestos = string.Empty;

                foreach (Manifiesto manifiesto in gestion.Manifiestos)
                    manifiestos += manifiesto.Codigo + '\n';

                dgvGestiones[Manifiestos.Index, e.RowIndex].Value = manifiestos.TrimEnd('\n');

                // Tulas

                String tulas = string.Empty;

                foreach (Tula tula in gestion.Tulas)
                    tulas += tula.Codigo + '\n';

                dgvGestiones[Tulas.Index, e.RowIndex].Value = tulas.TrimEnd('\n');

                // Cliente

                string cliente = string.Empty;

                cliente = gestion.Punto_venta.Cliente.Nombre + ", " + gestion.Punto_venta.Nombre;

                dgvGestiones[Cliente.Index, e.RowIndex].Value = cliente;
            }

        }

        /// <summary>
        /// Se da doble clic en la lista de gestiones.
        /// </summary>
        private void dgvGestiones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.mostarVentanaModificacion();
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Filtrar las gestiones por fecha.
        /// </summary>
        private void filtrarPorFecha()
        {

            try
            {
                DateTime inicio = dtpInicio.Value;
                DateTime fin = dtpFinalizacion.Value;

                dgvGestiones.DataSource = _coordinacion.listarGestionesTerminadas(inicio, fin);
            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        private void mostarVentanaModificacion()
        {

            try
            {
                Gestion gestion = (Gestion)dgvGestiones.SelectedRows[0].DataBoundItem;
                frmTerminacionGestiones formulario = new frmTerminacionGestiones(gestion, _supervisor);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Métodos Privados

        #region Métodos Públicos

        /// <summary>
        /// Actualizar los valores de la lista.
        /// </summary>
        public void actualizarLista()
        {
            dgvGestiones.Refresh();
            dgvGestiones.AutoResizeColumns();
        }

        #endregion Métodos Públicos

    }

}
