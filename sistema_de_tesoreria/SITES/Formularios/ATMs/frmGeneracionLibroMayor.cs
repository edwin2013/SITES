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
using System.Globalization;
using LibreriaReportesOffice;
using System.Collections;

namespace GUILayer
{

    public partial class frmGeneracionLibroMayor : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private DataTable _cierreCarga = new DataTable();
        private DataTable _cierreDescarga = new DataTable();

        #endregion Atributos

        #region Constructor

            public frmGeneracionLibroMayor()
            {
                InitializeComponent();
            }

        #endregion Contructor 


        #region Eventos


            /// <summary>
            /// Clic en el botón de salir.
            /// </summary>
            private void btnSalir_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            /// <summary>
            /// Clic en el botón de actualizar.
            /// </summary>
            private void btnActualizar_Click(object sender, EventArgs e)
            {

                try
                {
                   
                    DateTime fecha = dtpFecha.Value;

                    DataTable datos = _coordinacion.listarCargasATMsLibroMayorReporte(fecha);
                    DataTable datosdescargas = _coordinacion.listarDescargasATMsLibroMayorReporte(fecha);


                    _cierreCarga = _coordinacion.listarDatosCierreCargas(fecha);
                    _cierreDescarga = _coordinacion.listarDatosCierreDescargas(fecha);


                    dgvCargas.DataSource = datos;
                    dgvCargas.AutoResizeColumns();

                    dgvDescargas.DataSource = datosdescargas;
                    dgvDescargas.AutoResizeColumns();

                    dgvTotalCargas.Rows.Clear();
                    dgvTotalCargas.Columns.Clear();

                    dgvTotalDescargas.Rows.Clear();
                    dgvTotalDescargas.Columns.Clear();

                    //if (datos.Rows.Count == 0) return;

                    //if (datosdescargas.Rows.Count == 0) return;

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
                        //  dgvEsperados[columna.Index, 0].Value = esperado;
                    }


                    foreach (DataGridViewColumn columna in dgvCargas.Columns)
                    {

                        if (columna.ValueType == typeof(decimal))
                        {
                            dgvTotalCargas.Columns.Add("Total " + columna.Name, columna.HeaderText);
                          
                            columna.DefaultCellStyle.Format = "N2";
                        }

                    }
                    dgvTotalCargas.Rows.Add();

                   

                    foreach (DataGridViewColumn columna in dgvTotalCargas.Columns)
                    {
                        decimal total = 0;
                        string totalnuevo = "";
                      
                            total = (decimal)datos.Compute("Sum([" + columna.HeaderText + "])", "");

                            totalnuevo = total.ToString("C3", CultureInfo.InvariantCulture);  
                        
                        dgvTotalCargas[columna.Index, 0].Value = totalnuevo;
                    }

                    // Calcular la variación
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

            /// <summary>
            /// Clic en el botón de exportar a Excel
            /// </summary>
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
                    DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla formato libro mayor.xlt", true);

                    documento.seleccionarHoja(1);
                    int fila = 16;

                    // Escribir los datos

                    documento.seleccionarCelda("I3");
                    documento.actualizarValorCelda(dtpFecha.Value);
                    documento.autoajustarTamanoColumnas();

                    documento.seleccionarCelda("B15");
                    documento.actualizarValorCelda(dtpFecha.Value);
                    documento.autoajustarTamanoColumnas();

                    documento.seleccionarCelda("I215");
                    documento.actualizarValorCelda(dtpFecha.Value);
                    documento.autoajustarTamanoColumnas();

                    if (_cierreCarga.Rows.Count > 0)
                    {
                        documento.seleccionarCelda("F9");
                        documento.actualizarValorCelda(_cierreCarga.Rows[0][0].ToString());
                        documento.autoajustarTamanoColumnas();

                        documento.seleccionarCelda("F10");
                        documento.actualizarValorCelda(_cierreCarga.Rows[0][1].ToString());
                        documento.autoajustarTamanoColumnas();

                        documento.seleccionarCelda("F12");
                        documento.actualizarValorCelda(_cierreCarga.Rows[0][2].ToString());
                        documento.autoajustarTamanoColumnas();

                        documento.seleccionarCelda("F13");
                        documento.actualizarValorCelda(_cierreCarga.Rows[0][3].ToString());
                        documento.autoajustarTamanoColumnas();

                        documento.seleccionarCelda("F14");
                        documento.actualizarValorCelda(_cierreCarga.Rows[0][4].ToString());
                        documento.autoajustarTamanoColumnas();
                    }

                    int filas = dgvCargas.Rows.Count;

                    //documento.seleccionarCelda("I152");
                    //DataGridViewColumn columna = new DataGridViewColumn();

                    //columna = dgvCargas.Columns[2];

                    foreach (DataGridViewColumn columna in dgvCargas.Columns)
                    {
                        //Numero de ATM
                        if (columna.Index == 0)
                        {
                            int indicecolumna = columna.Index;
                            documento.seleccionarCelda("A16");
                            for(int i =0; i < dgvCargas.Rows.Count;i++)
                            {
                                 int numero_columna = columna.Index+1;

                                documento.seleccionarCelda(fila, numero_columna);
                                documento.actualizarValorCelda(dgvCargas.Rows[i].Cells[0].Value.ToString());
                                documento.seleccionarSegundaCelda(fila + 1, numero_columna);
                                documento.autoajustarTamanoColumnas();
                                fila = fila + 1;
                            }
                           
                        }

                        //Nombre
                        if (columna.Index == 1)
                        {
                            fila = 16;
                            documento.seleccionarCelda("C16");
                            for (int i = 0; i < dgvCargas.Rows.Count; i++)
                            {
                                int numero_columna = columna.Index;

                                documento.seleccionarCelda(fila, 3);
                                documento.actualizarValorCelda(dgvCargas[numero_columna,i].Value.ToString());
                                documento.seleccionarSegundaCelda(fila + 1, 3);
                                documento.autoajustarTamanoColumnas();
                                fila = fila + 1;
                            }

                        }

                        // Si es billete de 20.000
                        if (columna.Index == 2)
                        {
                            fila = 16;
                            documento.seleccionarCelda("H16");
                            for (int i = 0; i < dgvCargas.Rows.Count; i++)
                            {
                                int numero_columna = columna.Index;

                                documento.seleccionarCelda(fila, 8);
                                dgvCargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-CR"));
                                documento.actualizarValorCelda(dgvCargas[numero_columna, i].Value);
                                documento.seleccionarSegundaCelda(fila + 1, 8);
                                documento.autoajustarTamanoColumnas();
                                fila = fila + 1;
                            }

                        }


                        // Si es billete de 10.000
                        if (columna.Index == 3)
                        {
                            fila = 16;
                            documento.seleccionarCelda("I16");
                            for (int i = 0; i < dgvCargas.Rows.Count; i++)
                            {
                                int numero_columna = columna.Index;

                                documento.seleccionarCelda(fila, 9);
                                dgvCargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-CR"));
                                documento.actualizarValorCelda(dgvCargas[numero_columna, i].Value);
                                documento.seleccionarSegundaCelda(fila + 1, 9);
                                documento.autoajustarTamanoColumnas();
                                fila = fila + 1;
                            }

                        }

                        // Si es billete de 5.000
                        if (columna.Index == 4)
                        {
                            fila = 16;
                            documento.seleccionarCelda("J16");
                            for (int i = 0; i < dgvCargas.Rows.Count; i++)
                            {
                                int numero_columna = columna.Index;

                                documento.seleccionarCelda(fila, 10);
                                dgvCargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-CR"));
                                documento.actualizarValorCelda(dgvCargas[numero_columna, i].Value);
                                documento.seleccionarSegundaCelda(fila + 1, 10);
                                documento.autoajustarTamanoColumnas();
                                fila = fila + 1;
                            }

                        }

                        // Si es billete de 2.000
                        if (columna.Index == 5)
                        {
                            fila = 16;
                        //    documento.seleccionarCelda("J16");
                            for (int i = 0; i < dgvCargas.Rows.Count; i++)
                            {
                                int numero_columna = columna.Index;

                                documento.seleccionarCelda(fila, 11);
                                dgvCargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-CR"));
                                documento.actualizarValorCelda(dgvCargas[numero_columna, i].Value);
                                documento.seleccionarSegundaCelda(fila + 1, 11);
                                documento.autoajustarTamanoColumnas();
                                fila = fila + 1;
                            }

                        }

                        //Si es billete de 1.000
                        if (columna.Index == 6)
                        {
                            fila = 16;
                     //       documento.seleccionarCelda("J16");
                            for (int i = 0; i < dgvCargas.Rows.Count; i++)
                            {
                                int numero_columna = columna.Index;

                                documento.seleccionarCelda(fila, 12);
                                dgvCargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-CR"));
                                documento.actualizarValorCelda(dgvCargas[numero_columna, i].Value);
                                documento.seleccionarSegundaCelda(fila + 1, 12);
                                documento.autoajustarTamanoColumnas();
                                fila = fila + 1;
                            }

                        }


                        //Si es Efectivo Pagado
                        if (columna.Index == 8)
                        {
                 
                            fila = 16;
                            //       documento.seleccionarCelda("J16");
                            for (int i = 0; i < dgvCargas.Rows.Count; i++)
                            {
                                int numero_columna = columna.Index;

                                documento.seleccionarCelda(fila, 5);
                                dgvCargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-CR"));
                                documento.actualizarValorCelda(dgvCargas[numero_columna, i].Value);
                                documento.seleccionarSegundaCelda(fila + 1, 5);
                                documento.autoajustarTamanoColumnas();
                                fila = fila + 1;
                            }

                        }
                        
                        
                    }

                    
                     this.imprimirDescargas(documento);
                     this.imprimirCargasDolares(documento);
                     this.imprimirDescargasDolares(documento);
                  //   this.ImprimirTotalesCargas(documento);
                     
                  

                    documento.mostrar();
                    documento.cerrar();
                }
                catch (Exception)
                {
                    Excepcion.mostrarMensaje("ErrorExcel");
                }

            }


            /// <summary>
            /// Imprime las descargas de Atms
            /// </summary>
            /// <param name="documento"></param>
            private void imprimirDescargas(DocumentoExcel documento)
            {


                 documento.seleccionarHoja(1);

                 if (_cierreDescarga.Rows.Count > 0)
                 {
                     documento.seleccionarCelda("F109");
                     documento.actualizarValorCelda(_cierreDescarga.Rows[0][0].ToString());
                     documento.autoajustarTamanoColumnas();

                     documento.seleccionarCelda("F110");
                     documento.actualizarValorCelda(_cierreDescarga.Rows[0][1].ToString());
                     documento.autoajustarTamanoColumnas();

                     documento.seleccionarCelda("F111");
                     documento.actualizarValorCelda(_cierreDescarga.Rows[0][2].ToString());
                     documento.autoajustarTamanoColumnas();

                     documento.seleccionarCelda("F112");
                     documento.actualizarValorCelda(_cierreDescarga.Rows[0][3].ToString());
                     documento.autoajustarTamanoColumnas();

                     documento.seleccionarCelda("F113");
                     documento.actualizarValorCelda(_cierreDescarga.Rows[0][4].ToString());
                     documento.autoajustarTamanoColumnas();
                 }


                 int fila = 115;
                 foreach (DataGridViewColumn columna in dgvDescargas.Columns)
                    {
                        //Numero de ATM
                        if (columna.Index == 0)
                        {
                            int indicecolumna = columna.Index;
                            documento.seleccionarCelda("A16");
                            for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                            {
                                 int numero_columna = columna.Index+1;

                                documento.seleccionarCelda(fila, numero_columna);
                                documento.actualizarValorCelda(dgvDescargas.Rows[i].Cells[0].Value.ToString());
                                documento.seleccionarSegundaCelda(fila + 1, numero_columna);
                                documento.autoajustarTamanoColumnas();
                                fila = fila + 1;
                            }
                           
                        }

                        //Nombre
                        if (columna.Index == 1)
                        {
                            fila = 115;
                            documento.seleccionarCelda("C16");
                            for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                            {
                                int numero_columna = columna.Index;

                                documento.seleccionarCelda(fila, 3);
                                documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value.ToString());
                                documento.seleccionarSegundaCelda(fila + 1, 3);
                                documento.autoajustarTamanoColumnas();
                                fila = fila + 1;
                            }

                        }

                        // Si es billete de 20.000
                        if (columna.Index == 2)
                        {
                            fila = 115;
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


                        // Si es billete de 10.000
                        if (columna.Index == 3)
                        {
                            fila = 115;
                           // documento.seleccionarCelda("I16");
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

                        // Si es billete de 5.000
                        if (columna.Index == 4)
                        {
                            fila = 115;
                            documento.seleccionarCelda("J16");
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

                        // Si es billete de 2.000
                        if (columna.Index == 5)
                        {
                            fila = 115;
                        //    documento.seleccionarCelda("J16");
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

                        //Si es billete de 1.000
                        if (columna.Index == 6)
                        {
                            fila = 115;
                     //       documento.seleccionarCelda("J16");
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


                        //Si es Efectivo Recibido
                        if (columna.Index == 8)
                        {
                            fila = 115;
                            //       documento.seleccionarCelda("J16");
                           for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                            {
                                int numero_columna = columna.Index;

                                documento.seleccionarCelda(fila, 4);
                                dgvDescargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-CR"));
                                documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value);
                                documento.seleccionarSegundaCelda(fila + 1, 4);
                                documento.autoajustarTamanoColumnas();
                                fila = fila + 1;
                            }

                        }
                        if (columna.Index == 9)
                        {
                            fila = 115;
                            documento.seleccionarCelda("B16");
                            for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                            {
                                int numero_columna = columna.Index;

                                documento.seleccionarCelda(fila, 2);
                                dgvDescargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-CR"));
                                documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value.ToString());
                                documento.seleccionarSegundaCelda(fila + 1, 2);
                                documento.autoajustarTamanoColumnas();
                                fila = fila + 1;
                            }

                        }
                        
                    }
            }

            
            
            /// <summary>
            /// Imprime las Cargas en Dolares
            /// </summary>
            /// <param name="documento">Documento a exportar</param>
            private void imprimirCargasDolares(DocumentoExcel documento)
            {
                documento.seleccionarHoja(2);
                documento.seleccionarCelda("F3");
                documento.actualizarValorCelda(dtpFecha.Value);
                documento.autoajustarTamanoColumnas();

                documento.seleccionarCelda("C14");
                documento.actualizarValorCelda(dtpFecha.Value);
                documento.autoajustarTamanoColumnas();

                documento.seleccionarCelda("G170");
                documento.actualizarValorCelda(dtpFecha.Value);
                documento.autoajustarTamanoColumnas();

                if (_cierreCarga.Rows.Count > 0)
                {
                    documento.seleccionarCelda("G9");
                    documento.actualizarValorCelda(_cierreCarga.Rows[0][0].ToString());
                    documento.autoajustarTamanoColumnas();

                    documento.seleccionarCelda("G10");
                    documento.actualizarValorCelda(_cierreCarga.Rows[0][1].ToString());
                    documento.autoajustarTamanoColumnas();

                    documento.seleccionarCelda("G11");
                    documento.actualizarValorCelda(_cierreCarga.Rows[0][2].ToString());
                    documento.autoajustarTamanoColumnas();

                    documento.seleccionarCelda("G12");
                    documento.actualizarValorCelda(_cierreCarga.Rows[0][3].ToString());
                    documento.autoajustarTamanoColumnas();

                    documento.seleccionarCelda("G13");
                    documento.actualizarValorCelda(_cierreCarga.Rows[0][4].ToString());
                    documento.autoajustarTamanoColumnas();
                }

              //  documento.seleccionarHoja(1);
                int fila = 15;
                foreach (DataGridViewColumn columna in dgvCargas.Columns)
                {
                    //Numero de ATM
                    if (columna.Index == 0)
                    {
                        int indicecolumna = columna.Index;
                        documento.seleccionarCelda("A16");
                        for (int i = 0; i < dgvCargas.Rows.Count; i++)
                        {
                            int numero_columna = columna.Index + 2;

                            documento.seleccionarCelda(fila, numero_columna);
                            documento.actualizarValorCelda(dgvCargas.Rows[i].Cells[0].Value.ToString());
                            documento.seleccionarSegundaCelda(fila + 1, numero_columna);
                            documento.autoajustarTamanoColumnas();
                            fila = fila + 1;
                        }

                    }

                    //Nombre
                    if (columna.Index == 1)
                    {
                        fila = 15;
                       // documento.seleccionarCelda("C16");
                        for (int i = 0; i < dgvCargas.Rows.Count; i++)
                        {
                            int numero_columna = columna.Index;

                            documento.seleccionarCelda(fila, 4);
                            documento.actualizarValorCelda(dgvCargas[numero_columna, i].Value.ToString());
                            documento.seleccionarSegundaCelda(fila + 1, 4);
                            documento.autoajustarTamanoColumnas();
                            fila = fila + 1;
                        }

                    }

                    // Si es billete de 20
                    if (columna.Index == 7)
                    {
                        fila = 15;
                       // documento.seleccionarCelda("H16");
                        for (int i = 0; i < dgvCargas.Rows.Count; i++)
                        {
                            int numero_columna = columna.Index;

                            documento.seleccionarCelda(fila, 8);
                            dgvCargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-US"));
                            documento.actualizarValorCelda(dgvCargas[numero_columna, i].Value);
                            documento.seleccionarSegundaCelda(fila + 1, 8);
                            documento.autoajustarTamanoColumnas();
                            fila = fila + 1;
                        }

                    }


                    

                    //Si es Efectivo Pagado
                    if (columna.Index == 7)
                    {
                        fila = 15;
                        //       documento.seleccionarCelda("J16");
                        for (int i = 0; i < dgvCargas.Rows.Count; i++)
                        {
                            int numero_columna = columna.Index;

                            documento.seleccionarCelda(fila, 6);
                            dgvCargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-US"));
                            documento.actualizarValorCelda(dgvCargas[numero_columna, i].Value);
                            documento.seleccionarSegundaCelda(fila + 1, 6);
                            documento.autoajustarTamanoColumnas();
                            fila = fila + 1;
                        }

                    }


                }

            }


            /// <summary>
            /// Imprime las descargas en Dolares
            /// </summary>
            /// <param name="documento">Documento con los datos a exportar</param>
            private void imprimirDescargasDolares(DocumentoExcel documento)
            {
                documento.seleccionarHoja(2);
                documento.seleccionarCelda("F3");
                documento.actualizarValorCelda(dtpFecha.Value);
                documento.autoajustarTamanoColumnas();


                if (_cierreDescarga.Rows.Count > 0)
                {
                    documento.seleccionarCelda("G100");
                    documento.actualizarValorCelda(_cierreDescarga.Rows[0][5].ToString());
                    documento.autoajustarTamanoColumnas();

                    documento.seleccionarCelda("G101");
                    documento.actualizarValorCelda(_cierreDescarga.Rows[0][6].ToString());
                    documento.autoajustarTamanoColumnas();

                    documento.seleccionarCelda("G102");
                    documento.actualizarValorCelda(_cierreDescarga.Rows[0][7].ToString());
                    documento.autoajustarTamanoColumnas();

                    documento.seleccionarCelda("G103");
                    documento.actualizarValorCelda(_cierreDescarga.Rows[0][8].ToString());
                    documento.autoajustarTamanoColumnas();

                    documento.seleccionarCelda("G104");
                    documento.actualizarValorCelda(_cierreDescarga.Rows[0][9].ToString());
                    documento.autoajustarTamanoColumnas();
                }

              //  documento.seleccionarHoja(1);
                int fila = 106;
                foreach (DataGridViewColumn columna in dgvDescargas.Columns)
                {
                    //Numero de ATM
                    if (columna.Index == 0)
                    {
                        int indicecolumna = columna.Index;
                        documento.seleccionarCelda("A16");
                        for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                        {
                            int numero_columna = columna.Index + 2;

                            documento.seleccionarCelda(fila, numero_columna);
                            documento.actualizarValorCelda(dgvDescargas.Rows[i].Cells[0].Value.ToString());
                            documento.seleccionarSegundaCelda(fila + 1, numero_columna);
                            documento.autoajustarTamanoColumnas();
                            fila = fila + 1;
                        }

                    }

                    //Nombre
                    if (columna.Index == 1)
                    {
                        fila = 106;
                        // documento.seleccionarCelda("C16");
                        for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                        {
                            int numero_columna = columna.Index;

                            documento.seleccionarCelda(fila, 4);
                            documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value.ToString());
                            documento.seleccionarSegundaCelda(fila + 1, 4);
                            documento.autoajustarTamanoColumnas();
                            fila = fila + 1;
                        }

                    }

                    // Si es billete de 20
                    if (columna.Index == 7)
                    {
                        fila = 106;
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


                    //Si es Efectivo Recibido
                    if (columna.Index == 7)
                    {
                        fila = 106;
                        //       documento.seleccionarCelda("J16");
                        for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                        {
                            int numero_columna = columna.Index;

                            documento.seleccionarCelda(fila, 5);
                            dgvDescargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-US"));
                            documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value);
                            documento.seleccionarSegundaCelda(fila + 1, 5);
                            documento.autoajustarTamanoColumnas();
                            fila = fila + 1;
                        }

                    }

                    //Si es Carga Anterior
                    if (columna.Index == 10)
                    {
                        fila = 106;
                        //       documento.seleccionarCelda("J16");
                        for (int i = 0; i < dgvDescargas.Rows.Count; i++)
                        {
                            int numero_columna = columna.Index;

                            documento.seleccionarCelda(fila, 3);
                            dgvDescargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-US"));
                            documento.actualizarValorCelda(dgvDescargas[numero_columna, i].Value);
                            documento.seleccionarSegundaCelda(fila + 1, 3);
                            documento.autoajustarTamanoColumnas();
                            fila = fila + 1;
                        }

                    }
                }
            }


            /// <summary>
            /// Imprime los totales de las cargas
            /// </summary>
            /// <param name="documento">Documento con los datos a exportar</param>
            private void ImprimirTotalesCargas(DocumentoExcel documento)
            {
                documento.seleccionarHoja(1);
               
                int fila = 91;
                foreach (DataGridViewColumn columna in dgvTotalCargas.Columns)
                {
                    //Numero de ATM
                    if (columna.Index == 6)
                    {
                        int indicecolumna = columna.Index;
                       // documento.seleccionarCelda("A16");
                        for (int i = 0; i < dgvTotalCargas.Rows.Count; i++)
                        {
                            int numero_columna = columna.Index + 2;
                            documento.seleccionarCelda("E114");
                            dgvTotalCargas[numero_columna, i].Value.ToString().ToString(CultureInfo.CreateSpecificCulture("en-CR"));
                            documento.actualizarValorCelda(dgvTotalCargas.Rows[i].Cells[0].Value.ToString());
                
                            documento.autoajustarTamanoColumnas();
                            fila = fila + 1;
                        }

                    }

                  


                }
            }

            /// <summary>
            /// Imprime los totales de las descargas
            /// </summary>
            /// <param name="documento">Documento con los datos a exportar</param>
            private void ImprimirTotalesDescargas(DocumentoExcel documento)
            {

            }

            /// <summary>
            /// Imprime los totales de las cargas en dolares
            /// </summary>
            /// <param name="documento">Documento con los datos a exportar</param>
            private void ImprimirTotalesCargasDolares(DocumentoExcel documento)
            {

            }
            
            /// <summary>
            /// Imprime los totales de las descargas en dolares
            /// </summary>
            /// <param name="documento">Documento con los datos a exportar</param>
            private void ImprimirTotalesDescargasDolares(DocumentoExcel documento)
            {

            }

        #endregion Metodos Privados

            
    }
}
