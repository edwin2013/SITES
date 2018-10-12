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

namespace GUILayer.Formularios.Blindados
{
    public partial class frmHojaControlRuta : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _colaborador = null;

        private bool _coordinador = false;
        private BindingList<CargaATM> _auxiliar_atm = new BindingList<CargaATM>();
        private BindingList<PedidoBancos> _auxiliar_banco = new BindingList<PedidoBancos>();
        private BindingList<CargaSucursal> _auxiliar_sucursal = new BindingList<CargaSucursal>();
        private BindingList<Object> _lista_generica = new BindingList<Object>();

        #endregion Atributos

        #region Constructor

        public frmHojaControlRuta(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;
            _coordinador = _colaborador.Puestos.Contains(Puestos.Coordinador) || _colaborador.Puestos.Contains(Puestos.Supervisor);
              
            if (_coordinador)
            {
               // btnEliminar.Enabled = true;
                //cboTransportadora.Enabled = true;
                //btnActualizar.Enabled = false;
                //btnActualizarEspecial.Enabled = true;
                btnActualizar.Enabled = true;


            }
            

            try
            {
                dgvCargas.AutoGenerateColumns = false;

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
                decimal total = 0;
                decimal nuevototal = 0;
              
                byte? ruta = chkRuta.Checked ?
                    (byte?)nudRuta.Value : null;
                
                BindingList<Carga> cargas = new BindingList<Carga>();

                dgvCargas.DataSource =  _coordinacion.listarCargasTotales(null, fecha, ruta);
                cargas = _coordinacion.listarCargasTotales(null, fecha, ruta);

                Tripulacion t = new Tripulacion();

                if(chkRuta.Checked)
                {
                  t =   _mantenimiento.listarTripulacionRuta((int)ruta, fecha);

                  lblChofer.Text = "Chofer: " + t.Chofer.ToString();
                  lblCustodio.Text = "Custodio: " + t.Custodio.ToString();
                  lblPortavalor.Text = "Portavalor: " + t.Portavalor.ToString();
                  lblVehiculo.Text = "Vehículo: " + t.Vehiculo.ToString();
                }


                if (chkRuta.Checked == true)
                {
                    BindingList<Carga> cargarutas = new BindingList<Carga>();

                    foreach (Carga _carga in cargas)
                    {
                        if (_carga.Ruta == nudRuta.Value)
                        {
                            cargarutas.Add(_carga);

                            total = total + _carga.MontoColones;
                        }
                    }




                    foreach (Carga _carga in cargarutas)
                    {
                        if (_carga.Ruta == nudRuta.Value)
                        {
                          
                            if (_carga.HoraEntregaBoveda != null && (_carga.HoraInicioAtencionPunto != null || _carga.HoraRecibidoBoveda != null || _carga.HoraFinalAtencionPunto != null) && _carga.TipoPedido == false)
                            {
                                total = total - _carga.MontoColones;

                                if (_carga.TipoCargas == TipoCargas.ATM)
                                {
                                    CommonObjects.ATM atm = new CommonObjects.ATM (id:(short)_carga.ID_Canal);
                                    PromedioDescargaATM promedio = new PromedioDescargaATM(atm: atm);

                                    _mantenimiento.obtenerDatosPromedioDescargaATM(ref promedio);

                                    total = total + promedio.Monto;
                                }

                            }


                        }
                    }

                    nuevototal = total;

                    dgvCargas.DataSource = cargarutas;
                    lblMontoTotal.Text = "CRC "+ total.ToString("N2");
                    
                }
                else
                {
                    foreach (Carga _carga in cargas)
                    {
                        total = (total + _carga.MontoColones);
                    }

                    lblMontoTotal.Text = "CRC " + total.ToString("N2");
       
                }



                foreach (Carga _carga in cargas)
                {
                    if (_carga.Ruta == 0)
                    {
 
                    }
                }


                //DataTable datos = _coordinacion.listarCargasTotales(null, fecha, ruta);

                //foreach (DataGridViewColumn columna in dgvCargas.Columns)
                //    if (columna.ValueType == typeof(decimal))
                //        columna.DefaultCellStyle.Format = "N2";

                //dgvTotal.Columns.Clear();
                //dgvTotal.Columns.Add("Total " + dgvCargas.Columns["MontoTotalColones"], dgvCargas.Columns["MontoTotalColones"].HeaderText);

                //dgvCargas.Columns["MontoTotalColones"].DefaultCellStyle.Format = "N2";


                //dgvTotal.Rows.Add();


                //foreach (DataGridViewColumn columna in dgvTotal.Columns)
                //{

                //    //total = (decimal)datos.Compute("Sum([" + columna.HeaderText + "])", "");
                //    //columna.DefaultCellStyle.Format = "N2";
                //    //dgvTotal[columna.Index, 0].Value = total;

                //}

                

                //_auxiliar_atm = _coordinacion.listarCargasATMsEspeciales(null, atm, fecha, ruta, null);
                //_auxiliar_sucursal = _coordinacion.listarCargasSucursales(null, null, fecha, ruta);
                //_auxiliar_banco = _coordinacion.listarPedidosBancos(null, null, fecha, ruta);

                //_lista_generica.Clear();

                //foreach (PedidoBancos b in _auxiliar_banco)
                //{
                //    _lista_generica.Add(b);
                //}
                
                //foreach (CargaATM c in _auxiliar_atm)
                //{
                //    _lista_generica.Add(c);
                //}

                //foreach (CargaSucursal s in _auxiliar_sucursal)
                //{
                //    _lista_generica.Add(s);
                //}

                

                
               // dgvCargas.DataSource = _auxiliar_banco;
                
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
                BindingList<CargaATM> cargas = new BindingList<CargaATM>();

                foreach (DataGridViewRow fila in dgvCargas.SelectedRows)
                    cargas.Add((CargaATM)fila.DataBoundItem);

                frmAsignarRuta formulario = new frmAsignarRuta(cargas);

                formulario.ShowDialog(this);

                dgvCargas.Refresh();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

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
                        CargaATM carga = (CargaATM)fila.DataBoundItem;

                        _coordinacion.eliminarCargaATM(carga, _colaborador);

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
        /// Clic en el botón de revisar los cartuchos por denominación y tipo.
        /// </summary>
        private void btnCartuchos_Click(object sender, EventArgs e)
        {
            BindingList<CargaATM> cargas = (BindingList<CargaATM>)dgvCargas.DataSource;
            frmCartuchosCarga formulario = new frmCartuchosCarga(cargas);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de revisar los montos por denominación de todas las cargas.
        /// </summary>
        private void btnMontos_Click(object sender, EventArgs e)
        {
            BindingList<CargaATM> cargas = (BindingList<CargaATM>)dgvCargas.DataSource;
            frmMontosCajeroCargas formulario = new frmMontosCajeroCargas(cargas);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de ordenar ruta.
        /// </summary>
        private void btnOrdenRutas_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value;

            frmOrdenRuta formulario = new frmOrdenRuta(fecha);

            formulario.ShowDialog();
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

        }

        /// <summary>
        /// Se agrega una carga a la lista de cargas.
        /// </summary>
        private void dgvCargas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        /// <summary>
        /// Se selecciona otra carga de la lista de cargas.
        /// </summary>
        private void dgvCargas_SelectionChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Se marca o desmarca la opción de filtrar por ruta.
        /// </summary>
        private void chkRuta_CheckedChanged(object sender, EventArgs e)
        {
            nudRuta.Enabled = chkRuta.Checked;
        }



        /// <summary>
        /// Cambio en el estado de la tabla
        /// </summary>
        private void dgvCargas_SelectionChanged_1(object sender, EventArgs e)
        {

            btnRevisar.Enabled = dgvCargas.RowCount > 0;

            this.validaBotonesDesplazamientos();
        }



        /// <summary>
        /// Clic en el botón de arriba para cambiar el orden de las cargas.
        /// </summary>
        private void btnArriba_Click(object sender, EventArgs e)
        {
            this.cambiarOrdenCarga(-1);
        }

        /// <summary>
        /// Clic en el botón de abajo para cambiar el orden de las cargas.
        /// </summary>
        private void btnAbajo_Click(object sender, EventArgs e)
        {
            this.cambiarOrdenCarga(1);
        }

        private void dgvCargas_RowsAdded_1(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCargas.Rows[e.RowIndex + contador];
                Carga carga = (Carga)fila.DataBoundItem;

                fila.Cells[ID_Carga.Index].Value = carga.ID.ToString();

                if (carga.Ruta == 0)
                {

                    fila.DefaultCellStyle.BackColor = Color.Yellow;

                }

            }
        }

        #endregion Eventos
     
        #region Métodos Privados

      
        /// <summary>
        /// Mostrar la ventana de revisión de la carga.
        /// </summary>
        private void mostrarVentanaRevision()
        {
            Carga carga = (Carga)dgvCargas.SelectedRows[0].DataBoundItem;
            frmModificacionPedidoHojaDeRuta formulario = new frmModificacionPedidoHojaDeRuta(carga, _colaborador);

            formulario.ShowDialog(this);
        }

      

        private void CalcularTotales()
        {

            
        }



        /// <summary>
        /// Cambiar el orden de una carga en la lista de carga.
        /// </summary>
        private void cambiarOrdenCarga(int desplazamiento)
        {
            BindingList<Carga> cargas = (BindingList<Carga>)dgvCargas.DataSource;
            DataGridViewRow fila = dgvCargas.SelectedRows[0];
            Carga carga = (Carga)fila.DataBoundItem;
            int posicion = fila.Index + desplazamiento;

            cargas.Remove(carga);
            cargas.Insert(posicion, carga);

            dgvCargas.Rows[posicion].Selected = true;



            try
            {
                BindingList<Carga> lista = (BindingList<Carga>)dgvCargas.DataSource;

                for (byte orden = 1; orden <= lista.Count; orden++)
                {
                    Carga trip = lista[orden - 1];

                    trip.Orden_ruta = orden;
                }

                _coordinacion.actualizarCargasTotalesOrdenRuta(lista);
                
                
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Mostrar u ocultar los botones de desplazamiento dependiendo de la selección de una fila.
        /// </summary>
        private void validaBotonesDesplazamientos()
        {

            if (dgvCargas.SelectedRows.Count > 0)
            {
                BindingList<Carga> cargas = (BindingList<Carga>)dgvCargas.DataSource;
                DataGridViewRow fila = dgvCargas.SelectedRows[0];

              
               
            }
            else
            {
            }

        }
        #endregion Métodos Privados

       
    }
}
