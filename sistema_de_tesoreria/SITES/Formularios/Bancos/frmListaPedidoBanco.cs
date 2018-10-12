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
using LibreriaReportesOffice;
using CommonObjects.Clases;
using GUILayer.Formularios.Boveda;
using GUILayer.Formularios.Bancos;

namespace GUILayer.Formularios.Blindados
{
    public partial class frmListaPedidoBanco : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _colaborador = null;
        private PedidoBancos _pedido = null;
        private Canal _canal = null;

        private bool _coordinador = false;
        private bool _analista = false;

        #endregion Atributos

        #region Constructor

        public frmListaPedidoBanco(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;

            if (colaborador.Puestos.Contains(Puestos.Supervisor) || colaborador.Puestos.Contains(Puestos.Coordinador))
            {
                pnlOpcionesCoordinacion.Enabled = true;
            }
                btnActualizar.Enabled = true;

            try
            {
                dgvCargas.AutoGenerateColumns = false;

                cboTripulacion.ListaMostrada = _mantenimiento.listarTripulacion(string.Empty, dtpFecha.Value);
                cboCanal.ListaMostrada = _mantenimiento.listarCanales();
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
                DateTime fecha = dtpFecha.Value;
                Tripulacion tripulacion = cboTripulacion.SelectedIndex == 0 ?
                    null : (Tripulacion)cboTripulacion.SelectedItem;
                Canal canal = cboCanal.SelectedIndex == 0 ?
                    null : (Canal)cboCanal.SelectedItem;
                byte? ruta = chkRuta.Checked ?
                    (byte?)nudRuta.Value : null;

                //_coordinacion.ActualizarCargasBancosRoadnet(fecha);
                dgvCargas.DataSource = _coordinacion.listarPedidosBancos(tripulacion, canal, fecha, ruta);
                btnRevisar.Enabled = true;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de asignar ruta.
        /// </summary>
        private void btnAsignarRuta_Click(object sender, EventArgs e)
        {

            try
            {
                BindingList<PedidoBancos> cargas = new BindingList<PedidoBancos>();

                foreach (DataGridViewRow fila in dgvCargas.SelectedRows)
                    cargas.Add((PedidoBancos)fila.DataBoundItem);

                //frmAsignacionRutas formulario = new frmAsignacionRutas(cargas);

                //formulario.ShowDialog(this);

                dgvCargas.Refresh();
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

                if (Mensaje.mostrarMensajeConfirmacion("MensajePedidoBancosEliminacion") == DialogResult.Yes)
                {

                    foreach (DataGridViewRow fila in dgvCargas.SelectedRows)
                    {
                        PedidoBancos carga = (PedidoBancos)fila.DataBoundItem;

                        _coordinacion.eliminarPedidoBanco(carga);

                        dgvCargas.Rows.Remove(fila);
                    }

                    Mensaje.mostrarMensaje("MensajePedidoBancosConfirmacionEliminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón para crear un nuevo pedido a un banco
        /// </summary>
        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmPedidoBanco formulario = new frmPedidoBanco(_colaborador);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Clic en el botón de ordenar ruta.
        /// </summary>
        private void btnOrdenRutas_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Clic en el boton de Mirar la Tripulacion
        /// </summary>
        private void btnTripulacion_Click(object sender, EventArgs e)
        {
            this.mostrarVentanaTripulacion();
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
                PedidoBancos carga = (PedidoBancos)fila.DataBoundItem;

                if (_coordinador)
                {
                        this.mostrarVentanaModificacion();
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
                PedidoBancos carga = (PedidoBancos)fila.DataBoundItem;

                fila.Cells[Columna_Banco.Index].Value = carga.ToString();

                

                    if (carga.Modificada)
                        fila.DefaultCellStyle.BackColor = Color.Green;
                    else
                        fila.DefaultCellStyle.BackColor = Color.LightGreen;

              
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
                PedidoBancos carga = (PedidoBancos)fila.DataBoundItem;

                btnRevisar.Enabled = true;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;

               

            }
            else
            {

                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnRevisar.Enabled = false;

            }

        }

        /// <summary>
        /// Se marca o desmarca la opción de filtrar por ruta.
        /// </summary>
        private void chkRuta_CheckedChanged(object sender, EventArgs e)
        {
            nudRuta.Enabled = chkRuta.Checked;
        }
      
        private void btnManifiesto_Click(object sender, EventArgs e)
        {
            try
            {
                _pedido.Canal = (Canal)cboCanal.SelectedItem;

                frmManifiestoGeneral formulario = new frmManifiestoGeneral(_pedido);
                formulario.ShowDialog();
                formulario.mostrarDatosCargaSucursal();
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }

        #endregion Eventos
     
        #region Métodos Privados

        /// <summary>
        /// Mostrar la ventana de revisión de la carga.
        /// </summary>
        private void mostrarVentanaRevision()
        {
            PedidoBancos carga = (PedidoBancos)dgvCargas.SelectedRows[0].DataBoundItem;
            frmModificacionPedido formulario = new frmModificacionPedido(carga, _colaborador, true);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Mostrar la ventana de modificación de la carga.
        /// </summary>
        private void mostrarVentanaModificacion()
        {
            PedidoBancos carga = (PedidoBancos)dgvCargas.SelectedRows[0].DataBoundItem;
            frmModificacionPedidoBancos formulario = new frmModificacionPedidoBancos(carga, _colaborador, false);

            formulario.ShowDialog(this);

            carga.recalcularMontosCarga();

            dgvCargas.Refresh();
        }



        /// <summary>
        /// Mostrar la ventana de modificación de la carga.
        /// </summary>
        private void mostrarVentanaTripulacion()
        {
            PedidoBancos carga = (PedidoBancos)dgvCargas.SelectedRows[0].DataBoundItem;
            frmCargaTripulacion formulario = new frmCargaTripulacion(carga, _colaborador, false);

            formulario.ShowDialog(this);

            dgvCargas.Refresh();
        }

        #endregion Métodos Privados

    

       

        
    }
}
