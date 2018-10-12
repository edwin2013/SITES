//
//  @ Project : 
//  @ File Name : frmAdministracionEmpresasTransporte.cs
//  @ Date : 01/06/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmAdministracionEmpresasTransporte : Form
    {

        #region Atributos

        private MantenimientoBL _manejador = MantenimientoBL.Instancia;
        
        #endregion Atributos

        #region Constructor

        public frmAdministracionEmpresasTransporte()
        {
            InitializeComponent();

            try
            {
                // Cargar la lista de empresas
                dgvEmpresas.AutoGenerateColumns = false;

                dgvEmpresas.DataSource = _manejador.listarEmpresasTransporte();

                
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
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                dgvEmpresas.DataSource = _manejador.listarEmpresasTransporte();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de nuevo usuario.
        /// </summary>
        private void btnNueva_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoEmpresasTransporte formulario = new frmMantenimientoEmpresasTransporte(this);
                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostarVentanaModificacion();      
        }

        /// <summary>
        /// Clic en el botón de eliminar.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Mensaje.mostrarMensajeConfirmacion("MensajeEmpresaTransporteEliminacion") == DialogResult.Yes)
                {
                    EmpresaTransporte empresa = (EmpresaTransporte)dgvEmpresas.SelectedRows[0].DataBoundItem;

                    _manejador.eliminarEmpresaTransporte(empresa);
                    dgvEmpresas.Rows.Remove(dgvEmpresas.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeEmpresaTransporteConfirmacionEliminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje(); ;
            }

        }

        /// <summary>
        /// Doble clic en la lista de empresas.
        /// </summary>
        private void dgvEmpresas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se agrega una fila en la lista.
        /// </summary>
        private void dgvEmpresas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }
        
        /// <summary>
        /// Se elimina una fila en la lista.
        /// </summary>
        private void dgvEmpresas_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

            if (dgvEmpresas.Rows.Count == 0)
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

                if (dgvEmpresas.SelectedRows.Count > 0)
                {
                    EmpresaTransporte empresa = (EmpresaTransporte)dgvEmpresas.SelectedRows[0].DataBoundItem;
                    frmMantenimientoEmpresasTransporte formulario = new frmMantenimientoEmpresasTransporte(empresa, this);
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
        /// Actualizar las lista de empresas de transporte.
        /// </summary>
        public void actualizarLista()
        {
            dgvEmpresas.Refresh();
            dgvEmpresas.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar una empresa de transporte a la lista.
        /// </summary>
        public void agregarEmpresa(EmpresaTransporte empresa)
        {
            BindingList<EmpresaTransporte> empresas = (BindingList<EmpresaTransporte>)dgvEmpresas.DataSource;
            empresas.Add(empresa);
        }

        #endregion Métodos Públicos

    }

}
