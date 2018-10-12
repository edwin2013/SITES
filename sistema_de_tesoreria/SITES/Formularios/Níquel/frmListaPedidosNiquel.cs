using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
using GUILayer.Formularios.Facturacion;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Níquel
{
    public partial class frmListaPedidosNiquel : Form
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

        public frmListaPedidosNiquel(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;
            _coordinador = _colaborador.Puestos.Contains(Puestos.Coordinador) || _colaborador.Puestos.Contains(Puestos.Supervisor);
            _analista = _colaborador.Puestos.Contains(Puestos.Analista);
            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();

           pnlOpcionesCoordinacion.Enabled = true;
                //pnlOpcionesCoordinacion.Enabled = _coordinador;
            
                btnActualizar.Enabled = true;
            
          

            try
            {
                dgvCargas.AutoGenerateColumns = false;

                cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);
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
                Cliente cl = cboCliente.SelectedIndex <= 0 ? null : (Cliente)cboCliente.SelectedItem;
                DateTime fecha = dtpFecha.Value;
                PuntoVenta atm = cboPuntoVenta.SelectedIndex == 0 ? null : (PuntoVenta)cboPuntoVenta.SelectedItem;
                EmpresaTransporte emp = cboTransportadora.SelectedIndex <= 0 ? null :  (EmpresaTransporte)cboTransportadora.SelectedItem;

                dgvCargas.DataSource = _coordinacion.listarPedidosNiquel(atm, fecha, cl, emp);
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
        /// Clic en el botón de revisar.
        /// </summary>
        private void btnRevisar_Click(object sender, EventArgs e)
        {
            this.mostrarVentanaRevision();
        }

        /// <summary>
        /// Clic en el botón de eliminar carga.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeCargaATMEliminacion") == DialogResult.Yes)
                {

                    foreach (DataGridViewRow fila in dgvCargas.SelectedRows)
                    {
                        PedidoNiquel carga = (PedidoNiquel)fila.DataBoundItem;

                        _coordinacion.eliminarPedidoNiquel(carga, _colaborador);

                       

                        dgvCargas.Rows.Remove(fila);
                    }

                    Mensaje.mostrarMensaje("MensajeCargaATMConfirmacionEliminacion");
                }

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
        /// Doble clic en la lista de cargas.
        /// </summary>
        private void dgvCargas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                DataGridViewRow fila = dgvCargas.SelectedRows[0];
                PedidoNiquel carga = (PedidoNiquel)fila.DataBoundItem;

                if (_coordinador)
                {

                    if (carga.Cierre == null)
                        this.mostrarVentanaModificacion();
                    else
                        this.mostrarVentanaRevision();

                }
                else
                {
                    this.mostrarVentanaRevision();
                }

            }

        }

        /// <summary>
        /// Se agrega una carga a la lista de cargas.
        /// </summary>
        private void dgvCargas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCargas.Rows[e.RowIndex + contador];
                PedidoNiquel carga = (PedidoNiquel)fila.DataBoundItem;

               

                if (carga.Colaborador_verificador != null)
                {

                    
                        fila.DefaultCellStyle.BackColor = Color.LightGreen;

                }
                else if (carga.Cajero != null && carga.Colaborador_verificador == null)
                {
                    fila.DefaultCellStyle.BackColor = Color.Khaki;
                }
                else if (carga.Cajero == null)
                {
                    fila.DefaultCellStyle.BackColor = Color.IndianRed;
                }

            }

        }

        /// <summary>
        /// Se selecciona otra carga de la lista de cargas.
        /// </summary>
        private void dgvCargas_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCargas.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvCargas.SelectedRows[0];
                PedidoNiquel carga = (PedidoNiquel)fila.DataBoundItem;


                btnRevisar.Enabled = true;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;

                if (carga.Cierre == null)
                {
                    btnEliminar.Enabled = true;
                    btnModificar.Enabled = true;
   
                }
                else
                {
                    btnEliminar.Enabled = true;
                    btnModificar.Enabled = true;
  
                }

            }
            else
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnRevisar.Enabled = false;

            }

        }

        /// <summary>
        /// LLena el combo de puntos de venta según el cliente a escoger
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente nuevo = cboCliente.SelectedIndex == 0 ?
                    null : (Cliente)cboCliente.SelectedItem;

            if(nuevo != null)
                cboPuntoVenta.ListaMostrada = nuevo.Puntos_venta;
        }

        #endregion Eventos
     
        #region Métodos Privados

       

        /// <summary>
        /// Mostrar la ventana de revisión de la carga.
        /// </summary>
        private void mostrarVentanaRevision()
        {
            PedidoNiquel carga = (PedidoNiquel)dgvCargas.SelectedRows[0].DataBoundItem;
            frmModificacionPedidoNiquel formulario = new frmModificacionPedidoNiquel(carga, _colaborador, true);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Mostrar la ventana de modificación de la carga.
        /// </summary>
        private void mostrarVentanaModificacion()
        {
            PedidoNiquel carga = (PedidoNiquel)dgvCargas.SelectedRows[0].DataBoundItem;
            frmModificacionPedidoNiquel formulario = new frmModificacionPedidoNiquel(carga, _colaborador, false);

            formulario.ShowDialog(this);

            carga.recalcularMontosCarga();

            dgvCargas.Refresh();
        }

        #endregion Métodos Privados

        private void lblATMDesconocido_Click(object sender, EventArgs e)
        {

        }


        
    }
}
