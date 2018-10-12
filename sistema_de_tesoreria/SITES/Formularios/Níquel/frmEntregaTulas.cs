using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using CommonObjects;
using LibreriaMensajes;
using GUILayer.Properties;


namespace GUILayer
{
    public partial class frmEntregaTulas : Form
    {
        
        #region Atributos

        private AtencionBL _atencion = AtencionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        List<Cliente> _grupos = new List<Cliente>();

        Colaborador _usuario = null;

        #endregion Atributos

        #region Constructor

        public frmEntregaTulas(Colaborador usuario)
        {
            InitializeComponent();

            _usuario = usuario;

            try
            {
                // Mostrar la lista de grupos, de usuarios y de empresas de transporte

                cboEmpresa.ListaMostrada = _mantenimiento.listarEmpresasTransporte();

                dgvGrupos.AutoGenerateColumns = false;
                dgvGrupos.DataSource = _mantenimiento.listarClientes(String.Empty);

                btnReiniciar.Enabled = dgvGrupos.Rows.Count > 0;

                // Agregar el evento CellValueChanged a la lista de gupos

                dgvGrupos.CellValueChanged += new DataGridViewCellEventHandler(this.dgvGrupos_CellValueChanged);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de continuar sesión.
        /// </summary>
        private void btnContinuar_Click(object sender, EventArgs e)
        {

            try
            {
                EmpresaTransporte empresa = (EmpresaTransporte)cboEmpresa.SelectedItem;

                // Mostrar la ventana de registro de tulas

                frmRegistroTulasNiquel formulario = new frmRegistroTulasNiquel(_grupos, empresa, _usuario);

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modoficar.
        /// </summary>
        /// 
        private void btnReiniciar_Click(object sender, EventArgs e)
        {

            if (dgvGrupos.SelectedRows.Count > 0)
            {
                //Grupo grupo = (Grupo)dgvGrupos.SelectedRows[0].DataBoundItem;
                //frmOpcionesGrupo formulario = new frmOpcionesGrupo(grupo, this);

                //formulario.ShowDialog();
            }

        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
            this.Close();
        }

        /// <summary>
        /// Se cambia el valor de una celda.
        /// </summary>
        private void dgvGrupos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgvGrupos.Rows[e.RowIndex];
            Cliente grupo = (Cliente)fila.DataBoundItem;

            bool disponible = (bool)(fila.Cells[Disponible.Index].Value ?? false);

            if (disponible)
                _grupos.Add(grupo);
            else
                _grupos.Remove(grupo);

            this.validarContinuar();
        }

        /// <summary>
        /// Se selecciona otro receptor.
        /// </summary>
        private void cboReceptor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.validarContinuar();
        }

        /// <summary>
        /// Se selecciona otra empresa de transporte.
        /// </summary>
        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.validarContinuar();
        }

        /// <summary>
        /// Se marca o desmarca la casilla de disponibilidad de un grupo.
        /// </summary>
        private void dgvGrupos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

            if (dgvGrupos.IsCurrentCellDirty)
                dgvGrupos.CommitEdit(DataGridViewDataErrorContexts.Commit);

        }

        /// <summary>
        /// Se agrega un grupo a la lista de grupos.
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

            switch (grupo.Area)
            {
                case AreasManifiestos.Boveda:
                    area = "Bóveda";
                    break;
                case AreasManifiestos.CentroEfectivo:
                    area = "Centro de Efectivo";
                    break;
            }

            fila.Cells[Area.Index].Value = area;
        }

        /// <summary>
        /// Validar si se habilita o no el botón de continuar.
        /// </summary>
        private void validarContinuar()
        {
            btnContinuar.Enabled = cboEmpresa.SelectedItem != null && _grupos.Count > 0 ;
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

        #endregion Métodos Públicos

       
    }
}
