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

namespace GUILayer.Formularios.Facturacion
{
    public partial class frmAdministracionRegistroPenalidades : Form
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

        public frmAdministracionRegistroPenalidades(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;
            _coordinador = _colaborador.Puestos.Contains(Puestos.Coordinador) || _colaborador.Puestos.Contains(Puestos.Supervisor);
            _analista = _colaborador.Puestos.Contains(Puestos.Analista);
            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();

  

            try
            {
                dgvCargas.AutoGenerateColumns = false;
                dgvCargas.DataSource = new BindingList<RegistroPenalidad>();
        

                cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);
                cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
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
                DateTime fechafin = dtpFechaFin.Value;
                
                PuntoVenta atm = cboPuntoVenta.SelectedIndex == 0 ?
                    null : (PuntoVenta)cboPuntoVenta.SelectedItem;

                EmpresaTransporte empresa = cboTransportadora.SelectedIndex == 0 ? 
                    null : (EmpresaTransporte)cboTransportadora.SelectedItem;

                
                dgvCargas.DataSource = _coordinacion.listarRegistroPenalidades(fecha, fechafin, atm, empresa);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }


        /// <summary>
        /// Clic en el boton de 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmIngresoRegistroPenalidades formulario = new frmIngresoRegistroPenalidades(_colaborador);
                formulario.ShowDialog(this);
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
                        RegistroPenalidad carga = (RegistroPenalidad)fila.DataBoundItem;

                        _coordinacion.eliminarRegistroPenalidad(carga);

                       

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
                RegistroPenalidad carga = (RegistroPenalidad)fila.DataBoundItem;

                this.mostrarVentanaModificacion();

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
                RegistroPenalidad carga = (RegistroPenalidad)fila.DataBoundItem;

                //fila.Cells[ATMCarga.Index].Value = carga.ToString();

                //if (carga.Colaborador_verificador != null)
                //{

                //    if (carga.Modificada)
                //        fila.DefaultCellStyle.BackColor = Color.Green;
                //    else
                //        fila.DefaultCellStyle.BackColor = Color.LightGreen;

                //}
                //else if (carga.Cierre != null)
                //{
                //    fila.DefaultCellStyle.BackColor = Color.Yellow;
                //}
                //else if (carga.Cajero != null)
                //{
                //    fila.DefaultCellStyle.BackColor = Color.LightCoral;
                //}

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
                RegistroPenalidad carga = (RegistroPenalidad)fila.DataBoundItem;

                
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;

                

            }
            else
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;

            }

        }

        
        #endregion Eventos
     
        #region Métodos Privados

        

        /// <summary>
        /// Mostrar la ventana de revisión de la carga.
        /// </summary>
        private void mostrarVentanaRevision()
        {
            RegistroPenalidad carga = (RegistroPenalidad)dgvCargas.SelectedRows[0].DataBoundItem;
            frmIngresoRegistroPenalidades formulario = new frmIngresoRegistroPenalidades(carga, _colaborador);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Mostrar la ventana de modificación de la carga.
        /// </summary>
        private void mostrarVentanaModificacion()
        {
            RegistroPenalidad carga = (RegistroPenalidad)dgvCargas.SelectedRows[0].DataBoundItem;
            frmIngresoRegistroPenalidades formulario = new frmIngresoRegistroPenalidades(carga, _colaborador);

            formulario.ShowDialog(this);


            dgvCargas.Refresh();
        }

        #endregion Métodos Privados


        #region Metodos Publicos

        #region Métodos Públicos

        /// <summary>
        /// Actualizar las lista de clientes.
        /// </summary>
        public void actualizarLista()
        {
            dgvCargas.Refresh();
            dgvCargas.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un registro a la lista.
        /// </summary>
        public void agregarRegistroPenalidad(RegistroPenalidad registro)
        {
            try 
            {
                BindingList<RegistroPenalidad> registros = (BindingList<RegistroPenalidad>)dgvCargas.DataSource;

                registros.Add(registro);
            }
            catch(Excepcion ex)
            {
                ex.mostrarMensaje();
            }
            
        }

        #endregion Métodos Públicos


        /// <summary>
        /// Carga la lista de puntos de venta de un cliente
        /// </summary>
        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboCliente.SelectedIndex > 0)
                {
                    Cliente nuevo = (Cliente)cboCliente.SelectedItem;

                    cboPuntoVenta.ListaMostrada = nuevo.Puntos_venta;
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        #endregion Metodos Publicos

    }
}
