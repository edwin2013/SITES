//
//  @ Project : 
//  @ File Name : frmRecordatorioGestiones.cs
//  @ Date : 25/08/2011
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

    public partial class frmRecordatorioGestiones : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmRecordatorioGestiones()
        {
            InitializeComponent();

            dgvGestiones.AutoGenerateColumns = false;

            this.actualizarLista();
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de terminar.
        /// </summary>
        private void btnTerminar_Click(object sender, EventArgs e)
        {

            try
            {
                Gestion gestion = (Gestion)dgvGestiones.SelectedRows[0].DataBoundItem;
                frmTerminacionGestiones formulario = new frmTerminacionGestiones(gestion);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!tmrCronometro.Enabled)
                tmrCronometro.Start();

            this.actualizarLista();
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

            if (dgvGestiones.RowCount > 0)
                btnTerminar.Enabled = true;
            else
                btnTerminar.Enabled = false;

        }

        /// <summary>
        /// Se da formato a las celdas.
        /// </summary>
        private void dgvGestiones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex == Fecha.Index)
            {
                Gestion gestion = (Gestion)dgvGestiones.Rows[e.RowIndex].DataBoundItem;
                DateTime fecha_vencimiento = gestion.Fecha.AddHours(gestion.Tipo.Tiempo_esperado);

                dgvGestiones[FechaVencimiento.Index, e.RowIndex].Value = fecha_vencimiento;
            }
            else if (e.ColumnIndex == FechaVencimiento.Index)
            {
                DateTime fecha_vencimiento = (DateTime)dgvGestiones[e.ColumnIndex, e.RowIndex].Value;

                Color color = fecha_vencimiento < DateTime.Now ? Color.Tomato : Color.Gold;

                dgvGestiones.Rows[e.RowIndex].DefaultCellStyle.BackColor = color;
                dgvGestiones.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = color;
            }
            else if (e.ColumnIndex == ID.Index)
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
        /// Ejecución del ciclo del timer.
        /// </summary>
        private void tmrCronometro_Tick(object sender, EventArgs e)
        {
            this.actualizarLista();
        }

        /// <summary>
        /// Se cierra la ventana.
        /// </summary>
        private void frmRecordatorioGestiones_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMenuPrincipal padre = (frmMenuPrincipal)this.Owner;

            padre.cerrarRecordatorioGestiones();
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Actualizar la lista de gestiones.
        /// </summary>
        private void actualizarLista()
        {

            try
            {
                dgvGestiones.DataSource = _coordinacion.listarGestionesPendientes();
            }
            catch (Excepcion ex)
            {
                tmrCronometro.Stop();
                ex.mostrarMensaje();
            }

        }

        #endregion Métodos Privados

        #region Métodos Públicos

        /// <summary>
        /// Eliminar una gestión a la lista.
        /// </summary>
        public void eliminarGestion(Gestion gestion)
        {
            BindingList<Gestion> gestiones = (BindingList<Gestion>)dgvGestiones.DataSource;

            gestiones.Remove(gestion);
            dgvGestiones.AutoResizeColumns();
        }

        #endregion Métodos Públicos

    }

}
