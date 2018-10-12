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

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmAdministracionFichaTecnicaEquipos : Form
    {

        #region Atributos
        private MantenimientoBL _manejador = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor
        public frmAdministracionFichaTecnicaEquipos()
        {
            InitializeComponent();

            cboEquipo.ListaMostrada = _manejador.listarEquiposTesoreria();
            cboProveedor.ListaMostrada = _manejador.listarProveedorEquipo(string.Empty);

            dgvFichasTecnicas.AutoGenerateColumns = false;
            dgvFichasTecnicas.DataSource = _manejador.listarFichasTecnicas();

            
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
                if (dgvFichasTecnicas.SelectedRows.Count > 0)
                {
                    FichaTecnica ficha = (FichaTecnica)dgvFichasTecnicas.SelectedRows[0].DataBoundItem;
                    frmMantenimientoFichaTecnicaEquipos formulario = new frmMantenimientoFichaTecnicaEquipos(ficha, this);
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

        public void actualizarLista()
        {
            dgvFichasTecnicas.Refresh();
            dgvFichasTecnicas.AutoResizeColumns();
        }

        public void agregarFichaTecnica(FichaTecnica ficha)
        {
            BindingList<FichaTecnica> fichas = (BindingList<FichaTecnica>)dgvFichasTecnicas.DataSource;
            fichas.Add(ficha);
        }

        #endregion Métodos Públicos

        #region Eventos

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ProveedorEquipo prov = null;
                EquipoTesoreria equipo = null;
                if (cboProveedor.Text != "Todos")
                prov = (ProveedorEquipo)cboProveedor.SelectedItem;
                if(cboEquipo.Text != "Todos")
                equipo = (EquipoTesoreria)cboEquipo.SelectedItem;
                dgvFichasTecnicas.DataSource = _manejador.listarFichasTecnicas(dtpInicio.Value, dtpFin.Value, prov, equipo);
            } catch(Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoFichaTecnicaEquipos formulario = new frmMantenimientoFichaTecnicaEquipos(this);
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
                if (Mensaje.mostrarMensajeConfirmacion("MensajeEquipoEliminacion") == DialogResult.Yes)
                {
                    FichaTecnica ficha = (FichaTecnica)dgvFichasTecnicas.SelectedRows[0].DataBoundItem;

                    _manejador.eliminarFichaTecnica(ficha);
                    //dgvFichasTecnicas.Rows.Remove(dgvFichasTecnicas.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeEquipoConfirmacionEliminacion");
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje(); ;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvFichasTecnicas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }

        private void dgvFichasTecnicas_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvFichasTecnicas.Rows.Count == 0)
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }
        }
        
        #endregion Eventos
       
    }
}
