using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUILayer.Formularios.ATMs;
using CommonObjects.Clases;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer.Formularios.Níquel
{
    public partial class frmAdministracionFallasCartuchos : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        
        private BindingList<FallaCartucho> _fallas = new BindingList<FallaCartucho>();

        #endregion Atributos
        
        #region Constructor

        public frmAdministracionFallasCartuchos()
        {
            InitializeComponent();

             try
            {
                
                // Generar la lista de fallas


                _fallas = _mantenimiento.listarFallasCartucho();

                dgvFallasCartuchos.AutoGenerateColumns = false;
                dgvFallasCartuchos.DataSource = _fallas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        
        }

        #endregion Constructor

        #region Eventos
        private void gbFallasCartuchos_Enter(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmMantenimientoFallasCartuchos formulario = new frmMantenimientoFallasCartuchos();

            formulario.ShowDialog(this);
        }

        private void dgvFallasCartuchos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFallasCartuchos.RowCount > 0)
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

        private void dgvFallasCartuchos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeFallaCartuchoEliminacion") == DialogResult.Yes)
                {
                    FallaCartucho falla = (FallaCartucho)dgvFallasCartuchos.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarFallaCartucho(falla);

                    this.eliminarFallaCartucho(falla);

                    Mensaje.mostrarMensaje("MensajeFallaCartuchoConfirmacionEliminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostarVentanaModificacion();
        }

        #endregion Eventos

        #region Metodos Publicos
        /// <summary>
        /// Actualizar las lista de fallas.
        /// </summary>
        public void actualizarLista()
        {
            dgvFallasCartuchos.Refresh();
            dgvFallasCartuchos.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar una falla a la lista.
        /// </summary>
        public void agregarFallaCartucho(FallaCartucho falla)
        {
            BindingList<FallaCartucho> fallas = (BindingList<FallaCartucho>)dgvFallasCartuchos.DataSource;
            fallas.Add(falla);
        }

        /// <summary>
        /// Eliminar una falla a la lista.
        /// </summary>
        public void eliminarFallaCartucho(FallaCartucho falla)
        {
            BindingList<FallaCartucho> fallas = (BindingList<FallaCartucho>)dgvFallasCartuchos.DataSource;

            fallas.Remove(falla);
            dgvFallasCartuchos.AutoResizeColumns();
        }

        #endregion Metodos Publicos

        #region Metodos Privados


        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        private void mostarVentanaModificacion()
        {

            try
            {
                FallaCartucho falla = (FallaCartucho)dgvFallasCartuchos.SelectedRows[0].DataBoundItem;

                frmMantenimientoFallasCartuchos formulario = new frmMantenimientoFallasCartuchos(falla);
                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Metodos Privados

    }
}
