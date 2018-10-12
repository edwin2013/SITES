//
//  @ Project : 
//  @ File Name : frmAdministracionDenominaciones.cs
//  @ Date : 16/12/2012
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

    public partial class frmAdministracionDenominaciones : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionDenominaciones()
        {
            InitializeComponent();

            try
            {
                // Cargar la lista de Denominaciones

                dgvDenominaciones.AutoGenerateColumns = false;
                dgvDenominaciones.DataSource = _mantenimiento.listarDenominaciones();
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
        /// Clic en el botón de agregar una denominación.
        /// </summary>
        private void btnNueva_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoDenominaciones formulario = new frmMantenimientoDenominaciones();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar una denominación.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Clic en el botón de eliminar una denominación.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Mensaje.mostrarMensajeConfirmacion("MensajeDenominacionEliminacion") == DialogResult.Yes)
                {
                    Denominacion denominacion = (Denominacion)dgvDenominaciones.SelectedRows[0].DataBoundItem;

                    //_mantenimiento.eliminarDenominacion(denominacion);

                    dgvDenominaciones.Rows.Remove(dgvDenominaciones.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeDenominacionConfirmacionEliminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de agregar ATM.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Doble clic en la lista de denominaciones.
        /// </summary>
        private void dgvDenominaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se agrega una denominación a la lista de denominaciones.
        /// </summary>
        private void dgvDenominaciones_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvDenominaciones.Rows[e.RowIndex + contador];
                Denominacion denominacion = (Denominacion)fila.DataBoundItem;

                string moneda = string.Empty;

                switch (denominacion.Moneda)
                {
                    case Monedas.Colones: moneda = "Colones"; break;
                    case Monedas.Dolares: moneda = "Dólares"; break;
                    case Monedas.Euros: moneda = "Euros"; break;
                }

                fila.Cells[Moneda.Index].Value = moneda;
            }

        }

        /// <summary>
        /// Se selecciona otra denominación de la lista de denominaciones.
        /// </summary>
        private void dgvDenominaciones_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvDenominaciones.SelectedRows.Count > 0)
            {
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        public void mostarVentanaModificacion()
        {

            try
            {
                if (dgvDenominaciones.SelectedRows.Count > 0)
                {
                    Denominacion denominacion = (Denominacion)dgvDenominaciones.SelectedRows[0].DataBoundItem;
                    frmMantenimientoDenominaciones formulario = new frmMantenimientoDenominaciones(denominacion);

                    formulario.ShowDialog(this);
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Métodos Privados

        #region Métodos Públicos

        /// <summary>
        /// Actualizar las lista de denominaciones.
        /// </summary>
        public void actualizarLista()
        {
            dgvDenominaciones.Refresh();
            dgvDenominaciones.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar una denominación a la lista.
        /// </summary>
        public void agregarDenominacion(Denominacion denominacion)
        {
            BindingList<Denominacion> denominaciones = (BindingList<Denominacion>)dgvDenominaciones.DataSource;

            denominaciones.Add(denominacion);
        }

        #endregion Métodos Públicos

    }

}
