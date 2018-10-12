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

namespace GUILayer.Formularios.Níquel
{
    public partial class frmEntregaTulasNiquel : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<BolsaNiquel> tulas = new BindingList<BolsaNiquel>();
        private BindingList<BolsaCompletaNiquel> bolsas = new BindingList<BolsaCompletaNiquel>();

        private Colaborador _coordinador = null;

        #endregion Atributos

        #region Constructor

        public frmEntregaTulasNiquel(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            try
            {

                cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
                // Ordenar las columnas

                dgvTulas.AutoGenerateColumns = false;
                dgvBolsasCompletas.AutoGenerateColumns = false;

              
                DateTime fecha = dtpFecha.Value;


                dgvTulas.DataSource = tulas;
                dgvBolsasCompletas.DataSource = bolsas;



                //cargasentrega = _coordinacion.listarCargasTotales(null, estadobanco, nuevo,estadoAtm, ruta,fecha,0);

                //BindingList<Carga> cargastemp = new BindingList<Carga>();
        
                //dgvTulas.DataSource = cargasentrega;

                //if (cargasentrega != null) btnActualizarEntrega.Enabled = true;

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
                
                DateTime fecha = dtpFecha.Value;
                 EmpresaTransporte empresa = cboTransportadora.SelectedIndex == 0 ?
                    null : (EmpresaTransporte)cboTransportadora.SelectedItem;



                 tulas = _coordinacion.listarBolsasNiquelEntrega(fecha, empresa);
                 bolsas = _coordinacion.listarBolsasCompletasNiquelEntrega(fecha, empresa);

                dgvTulas.DataSource = tulas;
                dgvBolsasCompletas.DataSource = bolsas;
    
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }

      
        
        
        /// <summary>
        /// Enter en el campo de texto para buscar la serie o el marchamo de la entrega
        /// </summary>
        private void txtMarchamoTulaEntrega_Enter(object sender, EventArgs e)
        {
            string buscar = txtMarchamoTulaEntrega.Text;

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

        /// <summary>
        /// Permite el enter del text box yo de registra la serie de la tula
        /// </summary>
        private void txtMarchamoTulaEntrega_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMarchamoTulaEntrega.Text != string.Empty)
                {
                    string tulamarchamo = txtMarchamoTulaEntrega.Text;
                    Buscar(tulamarchamo, dgvTulas);
                }
            }
        }



        /// <summary>
        /// Cambio en las celdas de 
        /// </summary>
        private void dgvBolsasCompletas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBolsasCompletas.SelectedRows.Count > 0)
            {
                BolsaCompletaNiquel bolsa = (BolsaCompletaNiquel)dgvBolsasCompletas.SelectedRows[0].DataBoundItem;

                DataGridViewRow fila = dgvBolsasCompletas.SelectedRows[0];

                if (Convert.ToBoolean(fila.Cells["clmSeleccionar"].Value) == true)
                {
                    fila.DefaultCellStyle.BackColor = Color.LightGreen;

                    bolsa.Receptor = _coordinador;
                    bolsa.FechaEntrega = DateTime.Now;
                }
                else
                {

                    fila.DefaultCellStyle.BackColor = Color.White;
                    bolsa.Receptor = null;
                    bolsa.FechaEntrega = DateTime.Now;
                }

                _coordinacion.actualizarEntregaBolsasCompletasPedidoNiquel(bolsa);

            }

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


            
               
                    //cargasentrega = new BindingList<Carga>();
                    //estadosucursal = EstadosCargasSucursales.Entrega_Boveda;
                    //estadobanco = EstadosPedidoBanco.Entrega_a_Boveda;
                    //estadoAtm = EstadoDescargadaATM.Pendiente;
                    //nuevo = EntregaRecibo.Pedidos;
                    //DateTime fecha = dtpFecha.Value;
                    //manifiestotula = txtMarchamoTulaEntrega.Text;
                    //cargasentrega = _coordinacion.listarCargasTotales(null, estadobanco, nuevo,estadoAtm, ruta, fecha,0);
                   
                    //dgvTulas.DataSource = cargasentrega;
                
           
        }


        /// <summary>
        /// Interpretar una instruccion basado en una tecla presionada.
        /// </summary>
        private void interpretarComando(KeyEventArgs tecla)
        {

           if (tecla.KeyCode == Keys.Enter)
            {
                this.siguienteEtapa();
                this.txtMarchamoTulaEntrega.Text = "";
            }
            
        }


        /// <summary>
        /// Continuar con la siguiente etapa de la lectura de la información.
        /// </summary>
        private void siguienteEtapa()
        {
             if (txtMarchamoTulaEntrega.Text != string.Empty)
            {
                this.ActualizarDatosEntrega(txtMarchamoTulaEntrega.Text);
            }


        }



        /// <summary>
        /// Actualiza los datos de la recepcion
        /// </summary>
        private void ActualizarDatosEntrega(string tulamarchamo)
        {
            Buscar(tulamarchamo, "TulaEntrega", dgvTulas);
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


            BolsaNiquel bolsa = (BolsaNiquel)dgvTulas.SelectedRows[0].DataBoundItem;
            bolsa.ColaboradorEntrega = _coordinador;
            bolsa.FechaEntrega = DateTime.Now;

            _coordinacion.actualizarEntregaTulasPedidoNiquel(bolsa);

           

        }



        /// <summary>
        /// Busca si la serie de la tula digitada se encuentra en el listado de tulas de entregas. 
        /// </summary>
        /// <param name="tula">Serie de la tula</param>
        /// <param name="dgvTulas">DataGridView donde se encuentran el listado de tulas</param>
        private bool Buscar(string TextoABuscar, DataGridView grid)
        {

            string Columna = "TulaEntrega";
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

        #endregion Métodos Privados


       
    }
}
