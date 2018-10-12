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
using CommonObjects.Clases;
using GUILayer.Formularios.Mantenimiento;

namespace GUILayer.Formularios.Blindados
{
    public partial class frmSucursalesPorAprobar : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _colaborador = null;

        private bool _coordinador = false;
        private bool _analista = false;

        private String _comentario = String.Empty;

        #endregion Atributos

        #region Constructor

        public frmSucursalesPorAprobar(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;


            if (_colaborador.Sucursal == null)
            {
                cboCanal.Text = "";
            }
            else
                cboCanal.Text = _colaborador.Sucursal.Nombre;

            //if (colaborador.Puestos.Contains(Puestos.Supervisor) || colaborador.Puestos.Contains(Puestos.Coordinador))
            //{
                pnlOpcionesCoordinacion.Enabled = true;
            //}
                btnActualizar.Enabled = true;

            try
            {
                dgvCargas.AutoGenerateColumns = false;

               
                cboCanal.ListaMostrada = _mantenimiento.listarSucursales();
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

                Sucursal sucursal = cboCanal.SelectedIndex == 0 ?
                    null : (Sucursal)cboCanal.SelectedItem;

                byte? ruta = chkRuta.Checked ?
                    (byte?)nudRuta.Value : null;

                sucursal = _colaborador.Sucursal;
                if (sucursal != null)
                {

                    if (sucursal.CajaEmpresarial)
                    {
                        dgvCargas.DataSource = _coordinacion.listarCajasEmpresarialesAprobar(_colaborador, sucursal, fecha, ruta, EstadoAprobacionCargas.Por_Aprobar);
                    }
                    else
                    {
                        //_coordinacion.ActualizarCargasSucursalesRoadnet(fecha);
                        dgvCargas.DataSource = _coordinacion.listarCargasSucursalesAprobar(_colaborador, sucursal, fecha, ruta, EstadoAprobacionCargas.Por_Aprobar);
                        //btnRevisar.Enabled = true;
                    }
                }
                else
                {
                    dgvCargas.DataSource = _coordinacion.listarCargasSucursalesAprobar(_colaborador, sucursal, fecha, ruta, EstadoAprobacionCargas.Por_Aprobar);
                }
             
                
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
                BindingList<CargaSucursal> cargas = new BindingList<CargaSucursal>();

                foreach (DataGridViewRow fila in dgvCargas.SelectedRows)
                    cargas.Add((CargaSucursal)fila.DataBoundItem);

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

                if (Mensaje.mostrarMensajeConfirmacion("MensajeCargaRechazoGerente") == DialogResult.Yes)
                {


                    frmObservaciones formulario = new frmObservaciones();
                    formulario.Padre2 = this;
                    formulario.ShowDialog();
                       
                            foreach (DataGridViewRow fila in dgvCargas.SelectedRows)
                            {
                                CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;
                                carga.Colaborador_Registro = _colaborador;
                                 carga.Comentacio_Rechazo = _comentario;

                                _coordinacion.actualizarCargaSucursalAprobacionGerente(carga, EstadoAprobacionCargas.Rechazada);

                                dgvCargas.Rows.Remove(fila);
                            }




                            Mensaje.mostrarMensaje("MensajeCargaConfirmacionRechazoGerente");
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

                if (Mensaje.mostrarMensajeConfirmacion("MensajeCargaAprobacionGerente") == DialogResult.Yes)
                {

                    foreach (DataGridViewRow fila in dgvCargas.SelectedRows)
                    {
                        CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;
                        carga.Colaborador_Registro = _colaborador;

                        _coordinacion.actualizarCargaSucursalAprobacionGerente(carga, EstadoAprobacionCargas.Aprobada);

                        dgvCargas.Rows.Remove(fila);
                    }

                    Mensaje.mostrarMensaje("MensajeCargaConfirmacionAprobacionGerente");
                }

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
            DateTime fecha = dtpFecha.Value;

        //    frmOrdenRutaSucursal formulario = new frmOrdenRutaSucursal(fecha);

          //  formulario.ShowDialog();
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
                CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;

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
                CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;

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
                CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;

                btnRevisar.Enabled = true;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                btnAgregar.Enabled = true;

            }
            else
            {
                btnAgregar.Enabled = false;
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

        #endregion Eventos
     
        #region Métodos Privados

        /// <summary>
        /// Mostrar la ventana de revisión de la carga.
        /// </summary>
        private void mostrarVentanaRevision()
        {
            CargaSucursal carga = (CargaSucursal)dgvCargas.SelectedRows[0].DataBoundItem;
            frmModificacionCargaSucursal formulario = new frmModificacionCargaSucursal(carga, _colaborador, true);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Mostrar la ventana de modificación de la carga.
        /// </summary>
        private void mostrarVentanaModificacion()
        {
            CargaSucursal carga = (CargaSucursal)dgvCargas.SelectedRows[0].DataBoundItem;
            frmModificacionCargaSucursal formulario = new frmModificacionCargaSucursal(carga, _colaborador, false);

            formulario.ShowDialog(this);

            carga.recalcularMontosCarga();

            dgvCargas.Refresh();
        }

        #endregion Métodos Privados

        #region Metodos Publicos
        /// <summary>
        /// Define el comentario del rechazo del pedido a sucursal
        /// </summary>
        /// <param name="comentario"></param>
        public void asignarComentario(String comentario)
        {
            _comentario = comentario;
        }
        #endregion Metodos Publicos


    }
}
