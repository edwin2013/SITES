using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
using LibreriaMensajes;
using LibreriaReportesOffice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmCuadreDepositos : Form
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

        public frmCuadreDepositos(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;
           
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
                Cliente cliente = null;

                PuntoVenta atm = null;
              
                dgvCargas.DataSource = _coordinacion.listarCuadreDepositos(cliente,atm,fecha);
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
        /// Se agrega una carga a la lista de cargas.
        /// </summary>
        private void dgvCargas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {


            foreach (DataGridViewRow fila in dgvCargas.Rows)
            {
                CuadreDeposito carga = (CuadreDeposito)fila.DataBoundItem;
                if (carga.Diferencia > 10000 && carga.Moneda == Monedas.Colones)
                {
                    fila.Cells["clmDiferencia"].Style.BackColor = Color.IndianRed;
                    fila.Cells["clmMontoMacro"].Style.ForeColor = Color.White;
                }

                if (carga.Diferencia > 20 && carga.Moneda == Monedas.Dolares)
                {
                    fila.Cells["clmDiferencia"].Style.BackColor = Color.IndianRed;
                    fila.Cells["clmMontoMacro"].Style.ForeColor = Color.White;
                }

                if (carga.Diferencia == 0)
                {
                    fila.Cells["clmDiferencia"].Style.BackColor = Color.LightBlue;
                }
            }

            //for (int contador = 0; contador < e.RowCount; contador++)
            //{
            //    DataGridViewRow fila = dgvCargas.Rows[e.RowIndex + contador];
            //    CuadreDeposito carga = (CuadreDeposito)fila.DataBoundItem;
                                                                     
            //   // fila.Cells[ATMCarga.Index].Value = carga.ToString();

            //    //if (carga.MontoFisico != carga.MontoIBS && carga.MontoFisico != carga.MontoMacro)
            //    //{
            //    //    fila.Cells["clmMontoFisico"].Style.BackColor = Color.IndianRed;
            //    //    fila.Cells["clmMontoFisico"].Style.ForeColor = Color.White;
            //    //}
            //    //if (carga.MontoMacro != carga.MontoIBS && carga.MontoMacro != carga.MontoFisico)
            //    //{
            //    //    fila.Cells["clmMontoMacro"].Style.BackColor = Color.IndianRed;
            //    //    fila.Cells["clmMontoMacro"].Style.ForeColor = Color.White;
            //    //}
            //    //if (carga.MontoIBS != carga.MontoFisico && carga.MontoIBS != carga.MontoMacro)
            //    //{
            //    //    fila.Cells["clmMontoIBS"].Style.BackColor = Color.IndianRed;
            //    //    fila.Cells["clmMontoIBS"].Style.ForeColor = Color.White;
            //    //}



            //    if(carga.Diferencia > 10000 && carga.Moneda == Monedas.Colones)
            //        fila.Cells["clmDiferencia"].Style.BackColor = Color.Red;

            //    if(carga.Diferencia > 20 && carga.Moneda == Monedas.Dolares)
            //        fila.Cells["clmDiferencia"].Style.BackColor = Color.Red;

                
            //}

        }

        /// <summary>
        /// Se selecciona otra carga de la lista de cargas.
        /// </summary>
        private void dgvCargas_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCargas.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvCargas.SelectedRows[0];
        


                btnExportar.Enabled = true;


               
            }
            else
            {
               
                btnExportar.Enabled = false;

            }

        }

       

        #endregion Eventos

        /// <summary>
        /// Carga de puntos de venta dependiendo del cliente
        /// </summary>
        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        /// <summary>
        /// Clic en el botón de actualizar los datos de la lista
        /// </summary>
        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            Cliente cliente = null;

            PuntoVenta punto_venta = null;

            DateTime fecha = dtpFecha.Value;

            BindingList<CuadreDeposito> lista = _coordinacion.listarCuadreDepositos(cliente, punto_venta, fecha);

            if(lista.Count == 0)
               lista = _coordinacion.listarCuadreDepositosBD(cliente, punto_venta, fecha);

            dgvCargas.DataSource = lista;

            foreach (CuadreDeposito c in lista)
            {
                CuadreDeposito copia = c;
                _coordinacion.agregarCuadrDeposito(ref copia, _colaborador);
            }


        }

        private void dgvCargas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
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
     
        #region Métodos Privados



        /// <summary>
        /// Exportar el reporte.
        /// </summary>
        private void exportar()
        {

            try
            {

                if (dgvCargas.RowCount > 0)
                {
                    DocumentoExcel documento = new DocumentoExcel();

                    // Copiar los valores
                    documento.seleccionarHoja(1);
                    documento.seleccionarCelda("A1");
                    documento.actualizarValoresTabla((DataTable)dgvCargas.DataSource);

                    documento.seleccionarCelda("A1");
                    documento.seleccionarCelda(dgvCargas.Rows.Count, 4);
                    documento.formatoTabla(false);

                    int fila = 1;

                    foreach (DataGridViewRow fila_datos in dgvCargas.Rows)
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
        
        #endregion Métodos Privados

     
    }
}
