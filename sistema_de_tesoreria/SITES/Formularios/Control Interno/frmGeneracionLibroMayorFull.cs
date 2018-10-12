using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using System.Globalization;
using LibreriaMensajes;
using LibreriaReportesOffice;

namespace GUILayer.Formularios.Control_Interno
{
    public partial class frmGeneracionLibroMayorFull : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private DataTable _cierreCarga = new DataTable();
        private DataTable _cierreDescarga = new DataTable();

        #endregion Atributos

        #region Constructor
        public frmGeneracionLibroMayorFull()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Eventos

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime fecha = dtpFecha.Value;

                DataTable datosdescargas = _coordinacion.listarDescargasATMsFullLibroMayorReporte(fecha);


                _cierreCarga = _coordinacion.listarDatosCierreCargas(fecha);
                _cierreDescarga = _coordinacion.listarDatosCierreDescargas(fecha);
                
                dgvDescargas.DataSource = datosdescargas;
                dgvDescargas.AutoResizeColumns();

                dgvTotalDescargas.Rows.Clear();
                dgvTotalDescargas.Columns.Clear();

               foreach (DataGridViewColumn columna in dgvDescargas.Columns)
                {

                    if (columna.ValueType == typeof(decimal))
                    {
                        dgvTotalDescargas.Columns.Add("Total " + columna.Name, columna.HeaderText);

                        columna.DefaultCellStyle.Format = "N2";
                    }

                }
                dgvTotalDescargas.Rows.Add();

                foreach (DataGridViewColumn columna in dgvTotalDescargas.Columns)
                {

                    decimal total = 0;
                    string totalnuevo = "";

                    total = (decimal)datosdescargas.Compute("Sum([" + columna.HeaderText + "])", "");

                    totalnuevo = total.ToString("C3", CultureInfo.InvariantCulture);


                    dgvTotalDescargas[columna.Index, 0].Value = totalnuevo;
                }
                
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.imprimirHoja();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        #endregion Eventos
            
        #region Metodos Privados

        /// <summary>
        /// Imprimir los datos de la hoja de la carga seleccionada.
        /// </summary>
        private void imprimirHoja()
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla ATMs Full.xlt", true);

                documento.seleccionarHoja(1);
                int fila = 14;

                // Escribir los datos

                documento.seleccionarCelda("G4");
                documento.actualizarValorCelda(dtpFecha.Value);
                documento.autoajustarTamanoColumnas();

                documento.seleccionarCelda("C13");
                documento.actualizarValorCelda(dtpFecha.Value);
                documento.autoajustarTamanoColumnas();


                documento.seleccionarCelda("D10");
                documento.actualizarValorCelda(dtpFecha.Value);
                documento.autoajustarTamanoColumnas();

                //documento.seleccionarCelda("B15");
                //documento.actualizarValorCelda(dtpFecha.Value);
                //documento.autoajustarTamanoColumnas();

                //documento.seleccionarCelda("I215");
                //documento.actualizarValorCelda(dtpFecha.Value);
                //documento.autoajustarTamanoColumnas();

                this.imprimirDescargas(documento);
                this.imprimirDescargasDolares(documento);

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }
        
        private void imprimirDescargas(DocumentoExcel documento)
        {
            documento.seleccionarHoja(1);
            
            int fila = 14;
            foreach (DataGridViewColumn columna in dgvDescargas.Columns)
            {
                //Numero de ATM
                if (columna.Index == 0)
                {
                    int indicecolumna = columna.Index;
                    documento.seleccionarCelda("D14");
                    for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                    {
                        int numero_columna = columna.Index + 1;

                        documento.seleccionarCelda(fila, 4);
                        documento.actualizarValorCelda(dgvDescargas.Rows[i].Cells[0].Value.ToString()  +' '+  dgvDescargas[numero_columna, i].Value.ToString());
                        documento.seleccionarSegundaCelda(fila + 1, 4);
                        documento.autoajustarTamanoColumnas();

                        //escribir la fecha seleccionada en el formulario
                        documento.seleccionarCelda(fila, 3);
                        documento.actualizarValorCelda(dtpFecha.Value);
                        documento.seleccionarSegundaCelda(fila + 1, 3);
                        documento.autoajustarTamanoColumnas();

                        fila = fila + 1;

                    }

                }

                // Si es billete de 50.000
                if (columna.Index == 2)
                {
                    fila = 14;
                    //documento.seleccionarCelda("H16");
                    for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                    {
                        int numero_columna = columna.Index;

                        documento.seleccionarCelda(fila, 8);
                        dgvDescargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-CR"));
                        documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value);
                        documento.seleccionarSegundaCelda(fila + 1, 8);
                        documento.autoajustarTamanoColumnas();
                        fila = fila + 1;
                    }

                }

                // Si es billete de 20.000
                if (columna.Index == 3)
                {
                    fila = 14;
                    //documento.seleccionarCelda("H16");
                    for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                    {
                        int numero_columna = columna.Index;

                        documento.seleccionarCelda(fila, 9);
                        dgvDescargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-CR"));
                        documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value);
                        documento.seleccionarSegundaCelda(fila + 1, 9);
                        documento.autoajustarTamanoColumnas();
                        fila = fila + 1;
                    }

                }

                // Si es billete de 10.000
                if (columna.Index == 4)
                {
                    fila = 14;
                    // documento.seleccionarCelda("I16");
                    for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                    {
                        int numero_columna = columna.Index;

                        documento.seleccionarCelda(fila, 10);
                        dgvDescargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-CR"));
                        documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value);
                        documento.seleccionarSegundaCelda(fila + 1, 10);
                        documento.autoajustarTamanoColumnas();
                        fila = fila + 1;
                    }

                }

                // Si es billete de 5.000
                if (columna.Index == 5)
                {
                    fila = 14;
                    documento.seleccionarCelda("J16");
                    for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                    {
                        int numero_columna = columna.Index;

                        documento.seleccionarCelda(fila, 11);
                        dgvDescargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-CR"));
                        documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value);
                        documento.seleccionarSegundaCelda(fila + 1, 11);
                        documento.autoajustarTamanoColumnas();
                        fila = fila + 1;
                    }

                }

                // Si es billete de 2.000
                if (columna.Index == 6)
                {
                    fila = 14;
                    //    documento.seleccionarCelda("J16");
                    for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                    {
                        int numero_columna = columna.Index;

                        documento.seleccionarCelda(fila, 12);
                        dgvDescargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-CR"));
                        documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value);
                        documento.seleccionarSegundaCelda(fila + 1, 12);
                        documento.autoajustarTamanoColumnas();
                        fila = fila + 1;
                    }

                }

                //Si es billete de 1.000
                if (columna.Index == 7)
                {
                    fila = 14;
                    //       documento.seleccionarCelda("J16");
                    for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                    {
                        int numero_columna = columna.Index;

                        documento.seleccionarCelda(fila, 13);
                        dgvDescargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-CR"));
                        documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value);
                        documento.seleccionarSegundaCelda(fila + 1, 13);
                        documento.autoajustarTamanoColumnas();
                        fila = fila + 1;
                    }

                }

                //if (columna.Index == 9)
                //{
                //    fila = 14;
                //    documento.seleccionarCelda("B16");
                //    for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                //    {
                //        int numero_columna = columna.Index;

                //        documento.seleccionarCelda(fila, 2);
                //        dgvDescargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-CR"));
                //        documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value);
                //        documento.seleccionarSegundaCelda(fila + 1, 2);
                //        documento.autoajustarTamanoColumnas();
                //        fila = fila + 1;
                //    }

                //}

            }
        }

        private void imprimirDescargasDolares(DocumentoExcel documento)
        {
            documento.seleccionarHoja(2);
            documento.seleccionarCelda("G4");
            documento.actualizarValorCelda(dtpFecha.Value);
            documento.autoajustarTamanoColumnas();

            documento.seleccionarHoja(2);
            documento.seleccionarCelda("D10");
            documento.actualizarValorCelda(dtpFecha.Value);
            documento.autoajustarTamanoColumnas();

            documento.seleccionarHoja(2);
            documento.seleccionarCelda("C101");
            documento.actualizarValorCelda(dtpFecha.Value);
            documento.autoajustarTamanoColumnas();

            documento.seleccionarCelda("C13");
            documento.actualizarValorCelda(dtpFecha.Value);
            documento.autoajustarTamanoColumnas();
            
            //  documento.seleccionarHoja(1);
            int fila = 14;
            foreach (DataGridViewColumn columna in dgvDescargas.Columns)
            {
                //Numero de ATM
                if (columna.Index == 0)
                {
                    int indicecolumna = columna.Index;
                    documento.seleccionarCelda("D14");
                    for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                    {
                        int numero_columna = columna.Index + 2;

                        documento.seleccionarCelda(fila, 4);
                        documento.actualizarValorCelda(dgvDescargas.Rows[i].Cells[0].Value.ToString() +' '+ dgvDescargas[1, i].Value.ToString());
                        documento.seleccionarSegundaCelda(fila + 1, numero_columna);
                        documento.autoajustarTamanoColumnas();
                        fila = fila + 1;
                    }

                }

                //Nombre
                //if (columna.Index == 1)
                //{
                //    fila = 106;
                //    // documento.seleccionarCelda("C16");
                //    for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                //    {
                //        int numero_columna = columna.Index;

                //        documento.seleccionarCelda(fila, 4);
                //        documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value.ToString());
                //        documento.seleccionarSegundaCelda(fila + 1, 4);
                //        documento.autoajustarTamanoColumnas();
                //        fila = fila + 1;
                //    }

                //}

                // Si es billete de 20
                if (columna.Index == 8)
                {
                    fila = 14;
                    // documento.seleccionarCelda("H16");
                    for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                    {
                        int numero_columna = columna.Index;

                        documento.seleccionarCelda(fila, 8);
                        dgvDescargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-US"));
                        documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value);
                        documento.seleccionarSegundaCelda(fila + 1, 8);
                        documento.autoajustarTamanoColumnas();
                        fila = fila + 1;
                    }

                }

                if (columna.Index == 9)
                {
                    fila = 14;
                    // documento.seleccionarCelda("H16");
                    for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                    {
                        int numero_columna = columna.Index;

                        documento.seleccionarCelda(fila, 9);
                        dgvDescargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-US"));
                        documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value);
                        documento.seleccionarSegundaCelda(fila + 1, 9);
                        documento.autoajustarTamanoColumnas();
                        fila = fila + 1;
                    }

                }

                if (columna.Index == 10)
                {
                    fila = 14;
                    // documento.seleccionarCelda("H16");
                    for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                    {
                        int numero_columna = columna.Index;

                        documento.seleccionarCelda(fila, 10);
                        dgvDescargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-US"));
                        documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value);
                        documento.seleccionarSegundaCelda(fila + 1, 10);
                        documento.autoajustarTamanoColumnas();
                        fila = fila + 1;
                    }

                }

                if (columna.Index == 11)
                {
                    fila = 14;
                    // documento.seleccionarCelda("H16");
                    for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                    {
                        int numero_columna = columna.Index;

                        documento.seleccionarCelda(fila, 11);
                        dgvDescargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-US"));
                        documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value);
                        documento.seleccionarSegundaCelda(fila + 1, 11);
                        documento.autoajustarTamanoColumnas();
                        fila = fila + 1;
                    }

                }

                if (columna.Index == 12)
                {
                    fila = 14;
                    // documento.seleccionarCelda("H16");
                    for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                    {
                        int numero_columna = columna.Index;

                        documento.seleccionarCelda(fila, 12);
                        dgvDescargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-US"));
                        documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value);
                        documento.seleccionarSegundaCelda(fila + 1, 12);
                        documento.autoajustarTamanoColumnas();
                        fila = fila + 1;
                    }

                }

                if (columna.Index == 13)
                {
                    fila = 14;
                    // documento.seleccionarCelda("H16");
                    for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                    {
                        int numero_columna = columna.Index;

                        documento.seleccionarCelda(fila, 13);
                        dgvDescargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-US"));
                        documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value);
                        documento.seleccionarSegundaCelda(fila + 1, 13);
                        documento.autoajustarTamanoColumnas();
                        fila = fila + 1;
                    }

                }

                if (columna.Index == 14)
                {
                    fila = 14;
                    // documento.seleccionarCelda("H16");
                    for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                    {
                        int numero_columna = columna.Index;

                        documento.seleccionarCelda(fila, 14);
                        dgvDescargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-US"));
                        documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value);
                        documento.seleccionarSegundaCelda(fila + 1, 14);
                        documento.autoajustarTamanoColumnas();
                        fila = fila + 1;
                    }

                }


                //Si es Efectivo Recibido
                //if (columna.Index == 7)
                //{
                //    fila = 14;
                //    //       documento.seleccionarCelda("J16");
                //    for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                //    {
                //        int numero_columna = columna.Index;

                //        documento.seleccionarCelda(fila, 5);
                //        dgvDescargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-US"));
                //        documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value.ToString());
                //        documento.seleccionarSegundaCelda(fila + 1, 5);
                //        documento.autoajustarTamanoColumnas();
                //        fila = fila + 1;
                //    }

                //}

                //Si es Carga Anterior
                if (columna.Index == 10)
                {
                    fila = 14;
                    //       documento.seleccionarCelda("J16");
                    for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                    {
                        int numero_columna = columna.Index;

                        documento.seleccionarCelda(fila, 3);
                        dgvDescargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-US"));
                        documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value.ToString());
                        documento.seleccionarSegundaCelda(fila + 1, 3);
                        documento.autoajustarTamanoColumnas();
                        fila = fila + 1;
                    }

                }
            }
        }

        #endregion Metodos Privados
    }
}
