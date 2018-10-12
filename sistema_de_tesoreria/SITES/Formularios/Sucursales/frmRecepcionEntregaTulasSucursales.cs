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
using CommonObjects;
using LibreriaMensajes;

namespace GUILayer.Formularios.Sucursales
{
    public partial class frmRecepcionEntregaTulasSucursales : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        //private BindingList<Carga> cargas = new BindingList<Carga>();
        
        private BindingList<CargaSucursal> cargasentrega = new BindingList<CargaSucursal>();
        private BindingList<CargaSucursal> cargas = new BindingList<CargaSucursal>();
        private List<Color> _colores = new List<Color>();
        private int _opcion = 0;
        private Colaborador _coordinador = null;

        #endregion Atributos

        #region Constructor
        public frmRecepcionEntregaTulasSucursales(Colaborador coordinador)
        {
            InitializeComponent();
            try
            {

                _coordinador = coordinador;

                // Ordenar las columnas
                dgvManifiestoRecepcion.AutoGenerateColumns = false;
                dgvCargasEntrega.AutoGenerateColumns = false;

                // Asignar los colores
                _colores.Add(Color.Green);
                _colores.Add(Color.LightGreen);
                _colores.Add(Color.Yellow);
                _colores.Add(Color.Red);

                BindingList<CargaSucursal> cargastemp = new BindingList<CargaSucursal>();
                BindingList<CargaSucursal> cargasentregatemp = new BindingList<CargaSucursal>();

                BindingList<Colaborador> Colaboradores = _seguridad.listarColaboradoresdeSucursal();
                EstadosCargasSucursales estado = EstadosCargasSucursales.Pedido_Boveda;
                EstadosCargasSucursales estadoentrega = EstadosCargasSucursales.Entrega_Boveda;

                Colaborador tesorero = new Colaborador();

                foreach (Colaborador colaborador in Colaboradores)
                {
                    if (_coordinador.ID == colaborador.ID)
                    {
                        _coordinador.Sucursal = colaborador.Sucursal;
                        tesorero = colaborador;
                    }

                }

                Puestos puesto = new Puestos();

                //foreach (Puestos puest in tesorero.Puestos)
                //{
                //    if (puest == Puestos.Tesorero)
                //    {
                //        puesto = puest;
                //    }

                //}

                //if ((puesto == Puestos.Tesorero) && (_coordinador.Sucursal.DB_ID == tesorero.Sucursal.DB_ID))
                //{
                //    cargastemp = _coordinacion.listarCargasSucursal(null, estado, _coordinador);
                //    foreach (CargaSucursal carga in cargastemp)
                //    {
                //        if (_coordinador.Sucursal != null)
                //        {

                //            if (carga.Nombre == tesorero.Sucursal.Nombre)
                //            {
                //                cargas.Add(carga);

                //            }
                //        }

                //    }

                //    cargasentregatemp = _coordinacion.listarCargasSucursal(null, estadoentrega,_coordinador);
                //    foreach (CargaSucursal cargaentrega in cargasentregatemp)
                //    {
                //        if (_coordinador.Sucursal != null)
                //        {
                //            if (cargaentrega.Nombre == tesorero.Sucursal.Nombre)
                //            {
                //                cargasentrega.Add(cargaentrega);
                //            }
                //        }
                //    }

                //}

                //if (cargasentrega.Count != 0) { btnActualizarEntrega.Enabled = true; } else btnActualizarEntrega.Enabled = false;
                //if (cargas.Count != 0) { btnActualizar.Enabled = true; } else btnActualizar.Enabled = false;

                //dgvCargasEntrega.DataSource = cargasentrega;
                //dgvManifiestoRecepcion.DataSource = cargas;

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
                EstadosCargasSucursales estado = EstadosCargasSucursales.Pedido_Boveda;
                EntregaRecibo nuevo = EntregaRecibo.Pedidos;

                 DateTime fecha = dtpFecha.Value;
                byte? ruta = chkRuta.Checked ?
                    (byte?)nudRuta.Value : null;

                cargas = new BindingList<CargaSucursal>();
                cargas = _coordinacion.listarCargasSucursal(null, estado, _coordinador, nuevo, fecha, ruta);
                
                dgvManifiestoRecepcion.DataSource = cargas;

                this.txtNumeroMarchamoTula_Enter(sender,e);

            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Clic en el botón de actualizar Entrega.
        /// </summary>
        
        private void btnActualizarEntrega_Click(object sender, EventArgs e)
        {
            try
            {
                EstadosCargasSucursales estado = EstadosCargasSucursales.Entrega_Boveda;
                EntregaRecibo entrega = EntregaRecibo.Entregas;

                DateTime fecha = dtpFecha.Value;

                 byte? ruta = chkRuta.Checked ?
                    (byte?)nudRuta.Value : null;
                cargasentrega = new BindingList<CargaSucursal>();
                cargasentrega = _coordinacion.listarCargasSucursal(null, estado, _coordinador, entrega, fecha, ruta);

               dgvCargasEntrega.DataSource = cargasentrega;

             
                txtMarchamoTula_Enter(sender,e);

            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Lee las teclas digitadas por el usuario
        /// </summary>
        private void txtMarchamoTula_KeyUp(object sender, KeyEventArgs e)
        {
            this.interpretarComando(e);

        }

        private void txtNumeroMarchamoTula_Enter(object sender, EventArgs e)
        {
            string buscar = txtNumeroMarchamoTula.Text;
            _opcion = 1;
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
        /// Enter en el campo de texto para buscar la serie o el marchamo
        /// </summary>
        private void txtMarchamoTula_Enter(object sender, EventArgs e)
        {
            string buscar = txtMarchamoTula.Text;
            _opcion = 2;
            if (buscar != "")
                 this.buscar(buscar);

        }

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
        /// Habilita o inhabilita los numeros de ruta
        /// </summary>
        private void chkRuta_CheckedChanged(object sender, EventArgs e)
        {
            nudRuta.Enabled = chkRuta.Checked;
        }

        #endregion Eventos

        #region Métodos Privados
        /// <summary>
        /// Actualizar el monitor.
        /// </summary>
        private void actualizarMonitor()
        {

            try
            {
                dgvManifiestoRecepcion.DataSource = null;

                // Determinar si se filtra el reporte por área
              //dgvManifiestos.DataSource = _coordinacion.obtenerDatosMonitoreoManifiestos(inicio, grupos);

                foreach (DataGridViewRow fila in dgvManifiestoRecepcion.Rows)
                {
                    //int t = Math.Min((int)fila.Cells[T.Name].Value, 3);
                    //Color color = _colores[t];

                    fila.DefaultCellStyle.BackColor = Color.LightGreen;

                }


            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }


        /// <summary>
        /// Busca la carga
        /// </summary>
        /// <param name="manfiestotula"></param>
        private void buscar(string manifiestotula)
        {
            EstadosCargasSucursales estado = 0;

            if (_opcion == 1)
            {
                cargas = new BindingList<CargaSucursal>();
                estado = EstadosCargasSucursales.Pedido_Boveda;
                EntregaRecibo entrega = EntregaRecibo.Pedidos;

                DateTime fecha = dtpFecha.Value;

                byte? ruta = chkRuta.Checked ?
                    (byte?)nudRuta.Value : null;

                cargas = _coordinacion.listarCargasSucursal(manifiestotula, estado, _coordinador, entrega, fecha, ruta);
            
               dgvManifiestoRecepcion.DataSource = cargas;
            }
            else
            {
                if (_opcion == 2)
                {
                    cargasentrega = new BindingList<CargaSucursal>();
                    estado = EstadosCargasSucursales.Entrega_Boveda;
                    EntregaRecibo entrega = EntregaRecibo.Entregas;
                    manifiestotula = txtMarchamoTula.Text;

                    DateTime fecha = dtpFecha.Value;

                    byte? ruta = chkRuta.Checked ?
                    (byte?)nudRuta.Value : null;

                    cargasentrega = _coordinacion.listarCargasSucursal(manifiestotula, estado, _coordinador, entrega, fecha, ruta);
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
                txtMarchamoTula.Text = "";
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
            else if (txtMarchamoTula.Text != string.Empty)
            {
                this.ActualizarDatosEntrega(txtMarchamoTula.Text);
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
                if (dgvManifiestoRecepcion.SelectedRows.Count > 0)
                {
                    CargaSucursal carga = (CargaSucursal)dgvManifiestoRecepcion.SelectedRows[0].DataBoundItem;
                    
                    _coordinacion.actualizarDatosRecepcionCargaSucursales(carga, _coordinador, DateTime.Now, TipoEntregas.Recibido);
                    
                }
            }
            else
            {
                if (_opcion == 2)
                {
                    if (dgvCargasEntrega.SelectedRows.Count > 0)
                    {
                        CargaSucursal cargaentrega = (CargaSucursal)dgvCargasEntrega.SelectedRows[0].DataBoundItem;

                        _coordinacion.actualizarDatosEntregaCargaSucursales(cargaentrega, _coordinador, DateTime.Now, TipoEntregas.Entregado);

                    }
                }

            }
        }

        #endregion Métodos Privados


        

       

    }
    
}
