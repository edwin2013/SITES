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

namespace GUILayer.Formularios.Boveda
{
    public partial class frmRecepcionEntregaTulas : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<Carga> cargas = new BindingList<Carga>();
        private BindingList<Carga> cargasentrega = new BindingList<Carga>();
        //private BindingList<CargaSucursal> cargas_sucursales = new BindingList<CargaSucursal>();
        //private BindingList<PedidoBancos> pedido_bancos = new BindingList<PedidoBancos>();
        private List<Color> _colores = new List<Color>();
        private int _opcion = 0;
        private Colaborador _coordinador = null;

        #endregion Atributos

        #region Constructor

        public frmRecepcionEntregaTulas(Colaborador coordinador,int opcion)
        {
            InitializeComponent();

            _coordinador = coordinador;

            try
            {
               
                // Ordenar las columnas

                dgvManifiestoRecepcion.AutoGenerateColumns = false;
                dgvCargasEntrega.AutoGenerateColumns = false;

                // Asignar los colores

                _colores.Add(Color.Green);
                _colores.Add(Color.LightGreen);
                _colores.Add(Color.Yellow);
                _colores.Add(Color.Red);
                _opcion = opcion;

                byte? ruta = chkRuta.Checked ?
                   (byte?)nudRuta.Value : null;
               
                EstadosPedidoBanco estadobanco = EstadosPedidoBanco.Pedido_Boveda; 
                EstadosCargasSucursales estadosucursal = EstadosCargasSucursales.Pedido_Boveda;
                EntregaRecibo nuevo = EntregaRecibo.Entregas;
                EstadoDescargadaATM estadoAtm = EstadoDescargadaATM.Descargada;
                DateTime fecha = dtpFecha.Value;
                
                cargas = _coordinacion.listarCargasTotales(null, estadobanco,nuevo,estadoAtm,ruta,fecha,1);
                
                dgvManifiestoRecepcion.DataSource = cargas;

                if (cargas!=null) btnActualizar.Enabled = true;


                estadobanco = EstadosPedidoBanco.Entrega_a_Boveda;
                estadosucursal = EstadosCargasSucursales.Entrega_Boveda;
                nuevo = EntregaRecibo.Pedidos;
                estadoAtm = EstadoDescargadaATM.Pendiente;
    
                cargasentrega = _coordinacion.listarCargasTotales(null, estadobanco, nuevo,estadoAtm, ruta,fecha,0);

                BindingList<Carga> cargastemp = new BindingList<Carga>();
        
                dgvCargasEntrega.DataSource = cargasentrega;

                if (cargasentrega != null) btnActualizarEntrega.Enabled = true;

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
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

       }
       

        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                EstadosPedidoBanco estadobanco = EstadosPedidoBanco.Pedido_Boveda;
                EstadosCargasSucursales estadosucursal = EstadosCargasSucursales.Pedido_Boveda;
                EntregaRecibo nuevo = EntregaRecibo.Entregas;
                EstadoDescargadaATM estadoAtm = EstadoDescargadaATM.Descargada;
                DateTime fecha = dtpFecha.Value;
                byte? ruta = chkRuta.Checked ?
                    (byte?)nudRuta.Value : null;

                cargas = _coordinacion.listarDescargasTotales(null, estadobanco, nuevo, estadoAtm, ruta, fecha, 1);

                dgvManifiestoRecepcion.DataSource = cargas;
                txtNumeroMarchamoTula_Enter(sender,e);
           
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Clic en actualizar la lista de las entregas
        /// </summary>
        private void btnActualizarEntrega_Click(object sender, EventArgs e)
        {
           try
           {
              EstadosPedidoBanco estadobanco = EstadosPedidoBanco.Entrega_a_Boveda;
              EstadosCargasSucursales estadosucursal = EstadosCargasSucursales.Entrega_Boveda;
              EntregaRecibo nuevo = EntregaRecibo.Pedidos;
              EstadoDescargadaATM estadoAtm = EstadoDescargadaATM.Pendiente;
              DateTime fecha = dtpFecha.Value;

              byte? ruta = chkRuta.Checked ?
                  (byte?)nudRuta.Value : null;

               cargasentrega = _coordinacion.listarCargasTotales(null, estadobanco, nuevo,estadoAtm,ruta,fecha, 0);

               dgvCargasEntrega.DataSource = cargasentrega;

               txtMarchamoTulaEntrega_Enter(sender, e);
            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }
  

        
        /// <summary>
        /// Enter en el campo de texto para buscar la serie o el marchamo
        /// </summary>
        private void txtNumeroMarchamoTula_Enter(object sender, EventArgs e)
        {
            string buscar = txtNumeroMarchamoTula.Text;
            _opcion = 1;
            if (buscar != "")
                this.buscar(buscar);

        }
        
        /// <summary>
        /// Enter en el campo de texto para buscar la serie o el marchamo de la entrega
        /// </summary>
        private void txtMarchamoTulaEntrega_Enter(object sender, EventArgs e)
        {
            string buscar = txtMarchamoTulaEntrega.Text;
            _opcion = 2;
            if (buscar != "")
                this.buscar(buscar);
        }

        /// <summary>
        /// Lee las teclas digitadas por el usuario
        /// </summary>
        private void txtNumeroMarchamoTula_KeyUp(object sender, KeyEventArgs e)
        {
            this.interpretarComando(e);
        }

          /// <summary>
        /// Lee las teclas digitadas por el usuario
        /// </summary>
        private void txtMarchamoTulaEntrega_KeyUp(object sender, KeyEventArgs e)
        {
            this.interpretarComando(e);
        }


        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Busca la carga
        /// </summary>
        /// <param name="manfiestotula"></param>
        private void buscar(string manifiestotula)
        {
             EstadosCargasSucursales estadosucursal = 0;
             EstadosPedidoBanco estadobanco = 0;
             EstadoDescargadaATM estadoAtm = 0;
             EntregaRecibo nuevo = EntregaRecibo.Entregas;

             byte? ruta = chkRuta.Checked ?
                    (byte?)nudRuta.Value : null;

            if (_opcion == 1)
            {
                cargas = new BindingList<Carga>();
                estadosucursal = EstadosCargasSucursales.Pedido_Boveda;
                estadobanco = EstadosPedidoBanco.Pedido_Boveda;
                nuevo = EntregaRecibo.Entregas;
                estadoAtm = EstadoDescargadaATM.Descargada;
                DateTime fecha = dtpFecha.Value;
                

                cargas = _coordinacion.listarCargasTotales(null, estadobanco,nuevo,estadoAtm, ruta,fecha,1);
            
               dgvManifiestoRecepcion.DataSource = cargas;
            }
            else
            {
                if (_opcion == 2)
                {
                    cargasentrega = new BindingList<Carga>();
                    estadosucursal = EstadosCargasSucursales.Entrega_Boveda;
                    estadobanco = EstadosPedidoBanco.Entrega_a_Boveda;
                    estadoAtm = EstadoDescargadaATM.Pendiente;
                    nuevo = EntregaRecibo.Pedidos;
                    DateTime fecha = dtpFecha.Value;
                    manifiestotula = txtMarchamoTulaEntrega.Text;
                    cargasentrega = _coordinacion.listarCargasTotales(null, estadobanco, nuevo,estadoAtm, ruta, fecha,0);
                   
                    dgvCargasEntrega.DataSource = cargasentrega;
                }

            }
           
        }


        /// <summary>
        /// Interpretar una instruccion basado en una tecla presionada.
        /// </summary>
        private void interpretarComando(KeyEventArgs tecla)
        {

           if (tecla.KeyCode == Keys.Enter)
            {
                this.siguienteEtapa();
                this.txtNumeroMarchamoTula.Text = "";
                this.txtMarchamoTulaEntrega.Text = "";
            }
            
        }


        /// <summary>
        /// Continuar con la siguiente etapa de la lectura de la información.
        /// </summary>
        private void siguienteEtapa()
        {
            if (txtNumeroMarchamoTula.Text != string.Empty)
            {
                this.ActualizarDatosRecepcion(txtNumeroMarchamoTula.Text);

            }
            else if (txtMarchamoTulaEntrega.Text != string.Empty)
            {
                this.ActualizarDatosEntrega(txtMarchamoTulaEntrega.Text);
            }


        }


        /// <summary>
        /// Actualiza los datos de la recepcion
        /// </summary>
        private void ActualizarDatosRecepcion(string tulamarchamo)
        {
            Buscar(tulamarchamo, "Tula", dgvManifiestoRecepcion);
            _opcion = 1;
        }

        /// <summary>
        /// Actualiza los datos de la recepcion
        /// </summary>
        private void ActualizarDatosEntrega(string tulamarchamo)
        {
            Buscar(tulamarchamo, "TulaEntrega", dgvCargasEntrega);
            _opcion = 2;
        }


        /// <summary>
        /// Busca un texto en un datagrid y selecciona la fila con el dato
        /// </summary>
        /// <param name="TextoABuscar">Numero de marchamo adicional o serie de tula a buscar</param>
        /// <param name="Columna">Columna del datagrid a buscar</param>
        /// <param name="grid">DatagridView a buscar</param>
        /// <returns></returns>
        bool Buscar(string TextoABuscar, string Columna, DataGridView grid)
        {
            bool encontrado = false;
            if (TextoABuscar == string.Empty) return false;
            if (grid.RowCount == 0) return false;
            grid.ClearSelection();

            if (Columna == string.Empty)
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                        if (cell.Value.Equals(TextoABuscar))
                        {
                            row.Selected = true;
                            return true;
                        }
                }
            }
            else
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.Cells[Columna].Value != null)
                    {
                        if (row.Cells[Columna].Value.Equals(TextoABuscar))
                        {
                            row.Selected = true;
                            row.DefaultCellStyle.BackColor = Color.Green;
                            ActualizarDatosRecepcionCarga();

                            encontrado = true;
                        }
                    }
                }
            }

            return encontrado;
        }


        /// <summary>
        /// Actualiza los datos de la recepcion, de una carga especifica
        /// </summary>
        private void ActualizarDatosRecepcionCarga()
        {
            

            if (_opcion == 1)
            {
                Carga carga = (Carga)dgvManifiestoRecepcion.SelectedRows[0].DataBoundItem;
                if (dgvManifiestoRecepcion.SelectedRows.Count > 0)
                {
                    if (carga.TipoCargas == TipoCargas.ATM)
                    {
                        _coordinacion.actualizarDatosRecepcionCargaATM(carga, _coordinador, DateTime.Now, TipoEntregas.Recibido);
                    }
                    if (carga.TipoCargas == TipoCargas.Sucursal)
                    {
                        _coordinacion.actualizarDatosRecepcionCargaSucursal(carga, _coordinador, DateTime.Now, TipoEntregas.Recibido);
                    }
                    if (carga.TipoCargas == TipoCargas.Banco)
                    {
                        _coordinacion.actualizarDatosRecepcionPedidoBanco(carga, _coordinador, DateTime.Now, TipoEntregas.Recibido);
                    }

                }
            }
            else
            {

                if (_opcion == 2)
                {
                    Carga cargaentrega = (Carga)dgvCargasEntrega.SelectedRows[0].DataBoundItem;

                    if (dgvCargasEntrega.SelectedRows.Count > 0)
                    {
                        if (cargaentrega.TipoCargas == TipoCargas.ATM)
                        {
                            _coordinacion.actualizarDatosEntregaCargaATM(cargaentrega, _coordinador, DateTime.Now, TipoEntregas.Entregado);
                        }
                        if (cargaentrega.TipoCargas == TipoCargas.Sucursal)
                        {
                            _coordinacion.actualizarDatosEntregaCargaSucursal(cargaentrega, _coordinador, DateTime.Now, TipoEntregas.Entregado);
                        }
                        if (cargaentrega.TipoCargas == TipoCargas.Banco)
                        {
                            _coordinacion.actualizarDatosEntregaPedidoBanco(cargaentrega, _coordinador, DateTime.Now, TipoEntregas.Entregado);
                        }

                    }
                }
            }
        }

        #endregion Métodos Privados


        /// <summary>
        /// Cambia el estatus de la ruta
        /// </summary>
        private void chkRuta_CheckedChanged(object sender, EventArgs e)
        {
           
            nudRuta.Enabled = chkRuta.Checked;

        }


        /// <summary>
        /// Cambia el estatus de la ruta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }




   
      

   

      


   
    


       
        
    }
}
