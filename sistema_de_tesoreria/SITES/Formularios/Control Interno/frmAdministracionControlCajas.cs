using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using CommonObjects.Clases;
using LibreriaMensajes;
using CommonObjects;

namespace GUILayer.Formularios.Control_Interno
{
    public partial class frmAdministracionControlCajas : Form
    {
        #region Atributos

        private MantenimientoBL _manejador = MantenimientoBL.Instancia;

        private Colaborador _usuario = null;

        #endregion Atributos

        #region Constructor
        public frmAdministracionControlCajas(Colaborador usuario)
        {
            InitializeComponent();

            try
            {
                // Cargar la lista de empresas
                dgvCajas.AutoGenerateColumns = false;
                cboCaja.ListaMostrada = _manejador.listarCajas(0);
                dgvCajas.DataSource = _manejador.listarCajas(0);

                _usuario = usuario;

            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }
        }

        #endregion Constructor
        
        #region Métodos Privados

        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        public void mostarVentanaModificacion()
        {

            try
            {

                if (dgvCajas.SelectedRows.Count > 0)
                {
                    Caja caja = (Caja)dgvCajas.SelectedRows[0].DataBoundItem;
                    frmMantenimientoControlCajas formulario = new frmMantenimientoControlCajas(caja, this, _usuario);
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
        /// Actualizar las lista de cajas
        /// </summary>
        public void actualizarLista()
        {
            dgvCajas.Refresh();
            dgvCajas.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar una caja a la lista.
        /// </summary>
        public void agregarCaja(Caja caja)
        {
            BindingList<Caja> cajas = (BindingList<Caja>)dgvCajas.DataSource;
            cajas.Add(caja);
        }

        #endregion Métodos Públicos

        #region Eventos

        private void dgvCajas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCajas.SelectedRows.Count > 0)
            {
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else
            {
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoControlCajas formulario = new frmMantenimientoControlCajas(this, _usuario);
                formulario.ShowDialog(this);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Mensaje.mostrarMensajeConfirmacion("MensajeCajaEliminacion") == DialogResult.Yes)
                {
                    Caja caja = (Caja)dgvCajas.SelectedRows[0].DataBoundItem;

                    _manejador.eliminarCaja(caja);
                    dgvCajas.Rows.Remove(dgvCajas.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeCajaConfirmacionEliminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje(); ;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (cboCaja.SelectedIndex > 0)
            {
                Caja c = (Caja)cboCaja.SelectedItem;
                dgvCajas.DataSource = _manejador.listarCajas(c.Numero);
            }
            else
            {
                dgvCajas.DataSource = _manejador.listarCajas(0);
            }
        }

        #endregion Eventos

       


    }
}
