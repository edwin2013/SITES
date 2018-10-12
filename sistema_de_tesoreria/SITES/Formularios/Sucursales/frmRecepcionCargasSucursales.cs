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

namespace GUILayer.Formularios.Sucursales
{
    public partial class frmRecepcionCargasSucursales : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<CargaSucursal> cargas_sucursales = new BindingList<CargaSucursal>();

        private List<Color> _colores = new List<Color>();
        private int _opcion = 0;
        private Colaborador _coordinador = null;

        #endregion Atributos

        #region Constructor

        public frmRecepcionCargasSucursales(Colaborador coordinador, int opcion)
        {
            InitializeComponent();

            _coordinador = coordinador;

            try
            {
               

                // Ordenar las columnas

                dgvManifiestoRecepcion.AutoGenerateColumns = false;


                // Asignar los colores

                _colores.Add(Color.Green);
                _colores.Add(Color.LightGreen);
                _colores.Add(Color.Yellow);
                _colores.Add(Color.Red);
                _opcion = opcion;

                //if(opcion == 1)
                //    dgvManifiestoRecepcion.DataSource = _coordinacion.listarCargasTotales(null);
                //if(opcion ==2)
                //    dgvManifiestoRecepcion.DataSource = _coordinacion.listarCargasTotales(null);

               
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

            this.Close();
        }

        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                //dgvManifiestoRecepcion.DataSource = _coordinacion.listarCargasTotales(estadoAtm: EstadoDescargadaATM.Descargada);
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Clic en actualizar la lista de las entregas
        /// </summary>
        private void boton_Click(object sender, EventArgs e)
        {
            try
            {
               // dgvManifiestoRecepcion.DataSource = _coordinacion.listarCargasTotales(null);
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Clic en el boton de exportar a Excel.
        /// </summary>
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {

            try
            {
                this.exportar();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }


        /// <summary>
        /// Enter en el campo de texto para buscar la serie o el marchamo
        /// </summary>
        private void txtNumeroMarchamoTula_Enter(object sender, EventArgs e)
        {
            string buscar = txtNumeroMarchamoTula.Text;

            this.buscar(buscar);
            
        }


        /// <summary>
        /// Lee las teclas digitadas por el usuario
        /// </summary>

        private void frmRecepcionEntregaTulas_KeyDown(object sender, KeyEventArgs e)
        {
            this.interpretarComando(e);
        }


        


        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Exportar el reporte.
        /// </summary>
        private void exportar()
        {

            try
            {

                if (dgvManifiestoRecepcion.RowCount > 0)
                {
                    DocumentoExcel documento = new DocumentoExcel();

                    // Copiar los valores
                    documento.seleccionarHoja(1);
                    documento.seleccionarCelda("A1");
                    documento.actualizarValoresTabla((DataTable)dgvManifiestoRecepcion.DataSource);

                    documento.seleccionarCelda("A1");
                    documento.seleccionarCelda(dgvManifiestoRecepcion.Rows.Count, 4);
                    documento.formatoTabla(false);

                    int fila = 1;

                    foreach (DataGridViewRow fila_datos in dgvManifiestoRecepcion.Rows)
                    {
                        documento.seleccionarCelda(fila, 1);
                        documento.seleccionarSegundaCelda(fila, 4);
                        documento.formatoCelda(color_fondo: fila_datos.DefaultCellStyle.BackColor);

                        fila++;
                    }

                    // Mostrar el libro y cerrarlo

                    documento.mostrar();
                    documento.cerrar();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

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
        private void buscar(string manfiestotula)
        {
            //cargas_sucursales = _coordinacion.listarCargasSucursales(string.Empty);

            //dgvManifiestoRecepcion.DataSource = cargas;
  
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
            else if (txtMarchamoTulados.Text != string.Empty)
            {
                this.ActualizarDatosEntrega(txtMarchamoTulados.Text);
            }


        }


        /// <summary>
        /// Actualiza los datos de la recepcion
        /// </summary>
        private void ActualizarDatosRecepcion(string tulamarchamo)
        {
          
            Buscar(tulamarchamo, "Tula", dgvManifiestoRecepcion);
        }



        private void ActualizarDatosEntrega(string tulamarchamo)
        {
            Buscar(tulamarchamo, "Tula", dgvCargasEntrega);
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

                    if (row.Cells[Columna].Value.Equals(TextoABuscar))
                    {
                        row.Selected = true;
                        row.DefaultCellStyle.BackColor = Color.Green;
                            ActualizarDatosRecepcionCarga();

                        return true;
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
            if (dgvManifiestoRecepcion.SelectedRows.Count > 0)
            {
                CargaSucursal carga = (CargaSucursal)dgvManifiestoRecepcion.SelectedRows[0].DataBoundItem;


                if (_opcion == 1) { }
                        //_coordinacion.actualizarDatosRecepcionCargaSucursal(carga, _coordinador, DateTime.Now, TipoEntregas.Recibido);
                        if (_opcion == 2) { }
                      //  _coordinacion.actualizarDatosEntregaCargaSucursal(carga, _coordinador, DateTime.Now, TipoEntregas.Entregado);
                
                

            }
        }
        #endregion Métodos Privados

       
    }
}
