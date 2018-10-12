using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Boveda
{
    public partial class frmAdministracionArqueoBoveda : Form
    {
         #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private Colaborador _usuario = null;

        #endregion Atributos

        #region Constructor

        public frmAdministracionArqueoBoveda(Colaborador usuario)
        {
            InitializeComponent();

            _usuario = usuario;

            dgvArqueos.AutoGenerateColumns = false;
            dgvArqueos.DataSource = _mantenimiento.listarArqueosBoveda(dtpInicio.Value);
        }

        #endregion Constructor

        #region Eventos
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoArqueoBoveda formulario = new frmMantenimientoArqueoBoveda(_usuario);

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

        private void dgvArqueos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArqueos.SelectedRows.Count > 0)
            {
                btnModificar.Enabled = true;
            }
            else
            {
                btnModificar.Enabled = false;
            }
        }
        #endregion Eventos

        #region Métodos Públicos

        /// <summary>
        /// Actualizar las lista de calidad de billetes.
        /// </summary>
        public void actualizarLista()
        {
            dgvArqueos.Refresh();
            dgvArqueos.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un arqueo a la lista.
        /// </summary>
        public void agregarArqueos(Arqueo arqueo)
        {
            BindingList<Arqueo> arqueos = (BindingList<Arqueo>)dgvArqueos.DataSource;
            arqueos.Add(arqueo);
        }

        #endregion Métodos Públicos

        #region Métodos Privados

        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        public void mostarVentanaModificacion()
        {
            try
            {
                //if (dgvArqueos.SelectedRows.Count > 0)
                //{
                //    Arqueo arqueo = (Arqueo)dgvArqueos.SelectedRows[0].DataBoundItem;
                //    frmMantenimientoArqueoBoveda formulario = new frmMantenimientoArqueoBoveda(_usuario, arqueo);
                //    formulario.ShowDialog(this);
                //}

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Métodos Privados


    }
}
