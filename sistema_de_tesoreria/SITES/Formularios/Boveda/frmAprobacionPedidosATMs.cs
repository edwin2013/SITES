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
    public partial class frmAprobacionPedidosATMs : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _colaborador = null;

        private bool _coordinador = false;
        private bool _analista = false;

        #endregion Atributos

        #region Constructor

        public frmAprobacionPedidosATMs(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;
            
            
            try
            {
                dgvPedidoColones.AutoGenerateColumns = false;
                dgvPedidoDolares.AutoGenerateColumns = false;

                dgvPedidoColones.DataSource = _coordinacion.listarRecaptsporAprobar(EstadoRecapt.Por_Aprobar);
                //dgvPedidoDolares.DataSource = _coordinacion.listarRecaptsporAprobar(EstadoRecapt.Por_Aprobar);
               
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
                
                dgvPedidoColones.DataSource = _coordinacion.listarRecaptsporAprobar(EstadoRecapt.Por_Aprobar);
                dgvPedidoDolares.DataSource = _coordinacion.listarRecaptsporAprobar(EstadoRecapt.Por_Aprobar);
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
            this.mostrarVentanaModificacion();
        }

        

      
        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Doble clic en la lista de cargas.
        /// </summary>
        private void dgvCargas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                DataGridViewRow fila = dgvPedidoColones.SelectedRows[0];
                RecaptPreliminar carga = (RecaptPreliminar)fila.DataBoundItem;

               
                this.mostrarVentanaModificacion();
                    

            }

        }

      

        /// <summary>
        /// Se selecciona otra carga de la lista de cargas.
        /// </summary>
        private void dgvCargas_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvPedidoColones.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvPedidoColones.SelectedRows[0];
                RecaptPreliminar carga = (RecaptPreliminar)fila.DataBoundItem;

                btnAprobar.Enabled = true;
                btnRechazar.Enabled = true;
                btnValidarMontos.Enabled = true;

            }
            else
            {
                btnAprobar.Enabled = false;
                btnRechazar.Enabled = false;
                btnValidarMontos.Enabled = false;

            }

        }

        

        #endregion Eventos
     
        #region Métodos Privados

        
      

        /// <summary>
        /// Mostrar la ventana de modificación de la carga.
        /// </summary>
        private void mostrarVentanaModificacion()
        {
            RecaptPreliminar carga = (RecaptPreliminar)dgvPedidoColones.SelectedRows[0].DataBoundItem;
            frmVerificacionMontosRecapPreliminar formulario = new frmVerificacionMontosRecapPreliminar(carga);

            formulario.ShowDialog(this);

            carga.recalcularMontosCarga();

            dgvPedidoColones.Refresh();
        }

        #endregion Métodos Privados


        /// <summary>
        /// Clic en el botón de verificar montos del Recapt
        /// </summary>
        private void btnValidarMontos_Click(object sender, EventArgs e)
        {
            RecaptPreliminar r = (RecaptPreliminar)dgvPedidoColones.SelectedRows[0].DataBoundItem;

            frmVerificacionMontosRecapPreliminar formulario = new frmVerificacionMontosRecapPreliminar(r);
            formulario.ShowDialog();
        }
    }
}
