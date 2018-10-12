//
//  @ Project : 
//  @ File Name : frmAdministracionInconsistencias.cs
//  @ Date : 28/07/2011
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

    public partial class frmAdministracionInconsistenciasDigitadores : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private Colaborador _coordinador = null;

        #endregion Atributos

        #region Constructor

        public frmAdministracionInconsistenciasDigitadores(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            try
            {
                // Asignar los valores a las fechas

                DateTime ahora = DateTime.Now;
                DateTime inicio = new DateTime(ahora.Year, ahora.Month, ahora.Day, 0, 0, 0);
                DateTime fin = new DateTime(ahora.Year, ahora.Month, ahora.Day, 23, 59, 59);

                dtpInicio.Value = inicio;
                dtpFinalizacion.Value = fin;

                dgvInconsistencias.AutoGenerateColumns = false;

                this.actualizarListaInconsistencias();
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
        /// Clic en el botón de agregar inconsistencia de digitador.
        /// </summary>
        private void btnNueva_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoInconsistenciasDigitadores formulario = new frmMantenimientoInconsistenciasDigitadores(_coordinador);
                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar inconsistencia de digitador.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Clic en el botón de eliminar inconsistencia de digitador.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (Mensaje.mostrarMensajeConfirmacion("MensajeInconsistenciaEliminacion") == DialogResult.Yes)
            {
                InconsistenciaDigitador inconsistencia = (InconsistenciaDigitador)dgvInconsistencias.SelectedRows[0].DataBoundItem;

                _coordinacion.eliminarInconsistenciaDigitador(inconsistencia);
                dgvInconsistencias.Rows.Remove(dgvInconsistencias.SelectedRows[0]);
                Mensaje.mostrarMensaje("MensajeInconsistenciaConfirmacionEliminacion");
            }

        }

        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                this.actualizarListaInconsistencias();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Formato de la lista de inconsistencias en los depositos por causa del digitador.
        /// </summary>
        private void dgvInconsistencias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex == DepositoDigitador.Index)
            {
                InconsistenciaDigitador inconsistencia =
                    (InconsistenciaDigitador)dgvInconsistencias.Rows[e.RowIndex].DataBoundItem;

                if (inconsistencia.Moneda_erronea != null)
                {
                    String tipo = string.Empty;

                    switch (inconsistencia.Moneda_erronea)
                    {
                        case Monedas.Colones:
                            tipo = "Colones";
                            break;
                        case Monedas.Dolares:
                            tipo = "Dólares";
                            break;
                    }

                    dgvInconsistencias[MonedaErronea.Index, e.RowIndex].Value = tipo;
                }

            }
            else if (e.ColumnIndex == Sucursal.Index)
            {
                InconsistenciaDigitador inconsistencia =
                    (InconsistenciaDigitador)dgvInconsistencias.Rows[e.RowIndex].DataBoundItem;

                Cliente cliente = inconsistencia.Punto_venta.Cliente;

                dgvInconsistencias[Cliente.Index, e.RowIndex].Value = cliente;
            }


        }

        /// <summary>
        /// Doble clic en la lista de inconsistencias de digitadores.
        /// </summary>
        private void dgvInconsistencias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se selecciona otra inconsistencia causada por un digitador.
        /// </summary>
        private void dgvInconsistencias_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvInconsistencias.SelectedRows.Count == 0)
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }
            else
            {
                InconsistenciaDigitador inconsistencia =
                    (InconsistenciaDigitador)dgvInconsistencias.SelectedRows[0].DataBoundItem;
                bool estado = inconsistencia.Coordinador.Equals(_coordinador);

                btnEliminar.Enabled = estado;
                btnModificar.Enabled = estado;
            }

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Actualizar la listas de inconsistencias.
        /// </summary>
        private void actualizarListaInconsistencias()
        {
            try
            {
                DateTime fecha_inicio = dtpInicio.Value;
                DateTime fecha_final = dtpFinalizacion.Value;

                BindingList<InconsistenciaDigitador> inconsistencias_digitador =
                    _coordinacion.listarInconsistenciasDigitadores(fecha_inicio, fecha_final);

                dgvInconsistencias.DataSource = inconsistencias_digitador;

                dgvInconsistencias.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Mostrar la ventana de modificación de inconsistencias de digitadores.
        /// </summary>
        public void mostarVentanaModificacion()
        {

            try
            {
                InconsistenciaDigitador inconsistencia =
                    (InconsistenciaDigitador)dgvInconsistencias.SelectedRows[0].DataBoundItem;
                frmMantenimientoInconsistenciasDigitadores formulario = new frmMantenimientoInconsistenciasDigitadores(inconsistencia, _coordinador);

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
        /// Actualizar los valores de la lista de inconsistencias de digitadores.
        /// </summary>
        public void actualizarLista()
        {
            dgvInconsistencias.Refresh();
            dgvInconsistencias.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar una inconsistencia a la lista de inconsistencias de digitadores.
        /// </summary>
        public void agregarInconsistencia(InconsistenciaDigitador inconsistencia)
        {
            BindingList<InconsistenciaDigitador> inconsistencias = (BindingList<InconsistenciaDigitador>)dgvInconsistencias.DataSource;
            inconsistencias.Add(inconsistencia);
            dgvInconsistencias.AutoResizeColumns();
        }

        #endregion Métodos Públicos

    }

}
