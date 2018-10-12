//
//  @ Project : 
//  @ File Name : frmAdministracionGrupos.cs
//  @ Date : 30/05/2011
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
    public partial class frmAdministracionGrupos : Form
    {

        #region Atributos

        private MantenimientoBL _manejador = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionGrupos()
        {
            InitializeComponent();

            try
            {
                // Cargar la lista de grupos

                dgvGrupos.AutoGenerateColumns = false;
                dgvGrupos.DataSource = _manejador.listarGrupos();
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
                // Mostrar los grupos registrados en el sistema

                dgvGrupos.DataSource = _manejador.listarGrupos();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de eliminar grupo.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (Mensaje.mostrarMensajeConfirmacion("MensajeGrupoEliminacion") == DialogResult.Yes)
            {

                try
                {
                    Grupo grupo = (Grupo)dgvGrupos.SelectedRows[0].DataBoundItem;

                    _manejador.eliminarGrupo(grupo);
                    dgvGrupos.Rows.Remove(dgvGrupos.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeGrupoConfirmacionEliminacion");
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }


        /// <summary>
        /// Clic en el botón de agregar grupo.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoGrupos formulario = new frmMantenimientoGrupos(this);
                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar grupo.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
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
        /// Doble clic en la lista de grupos.
        /// </summary>
        private void dgvGrupos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se selecciona otro grupo de la lista.
        /// </summary>
        private void dgvGrupos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvGrupos.SelectedRows.Count > 0)
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

        /// <summary>
        /// Se agrega una fila en la lista.
        /// </summary>
        private void dgvGrupos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvGrupos.Rows[e.RowIndex + contador];

                this.actualizarArea(fila);
            }

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Actualizar el área de un grupo de la lista.
        /// </summary>
        public void actualizarArea(DataGridViewRow fila)
        {
            Grupo grupo = (Grupo)fila.DataBoundItem;
            string area = string.Empty;

            switch(grupo.Area)
            {
                case AreasManifiestos.Boveda: area = "Bóveda"; break;
                case AreasManifiestos.CentroEfectivo: area = "Centro de Efectivo"; break;
            }

            fila.Cells[Area.Index].Value = area;
        }

        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        public void mostarVentanaModificacion()
        {

            try
            {

                if (dgvGrupos.SelectedRows.Count > 0)
                {
                    Grupo grupo = (Grupo)dgvGrupos.SelectedRows[0].DataBoundItem;
                    frmMantenimientoGrupos formulario = new frmMantenimientoGrupos(grupo, this);
                    formulario.ShowDialog();
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
        /// Actualizar la lista de grupos.
        /// </summary>
        public void actualizarLista()
        {
            DataGridViewRow fila = dgvGrupos.SelectedRows[0];

            this.actualizarArea(fila);

            dgvGrupos.Refresh();
            dgvGrupos.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un grupo a la lista.
        /// </summary>
        public void agregarGrupo(Grupo grupo)
        {
            BindingList<Grupo> grupos = (BindingList<Grupo>)dgvGrupos.DataSource;
            grupos.Add(grupo);
        }

        #endregion Métodos Públicos

    }

}
