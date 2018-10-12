using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriaMensajes;
using CommonObjects;
using BussinessLayer;
using LibreriaReportesOffice;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmConsultaFormularios : Form
    {


        #region Atributos
        /// <summary>
        /// Inicialización de clases seguridadBL y lista de Colaboradores.
        /// </summary>
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private BindingList<Colaborador> listacajero = new BindingList<Colaborador>();
        private DataTable datos = new DataTable();
        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Constructor del formulario. Inicializa el formulario y carga la lista de cajeros por área.
        /// </summary>
        public frmConsultaFormularios()
        {
            InitializeComponent();
            cboFormularios.SelectedIndex = 0;
            listacajero = _seguridad.listarColaboradores("");
            BindingList<Colaborador> cols = new BindingList<Colaborador>();
            cols.Add(new Colaborador(nombre: "Todos"));
            var cols2 = cols.Concat(_seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB, Puestos.CajeroC)).ToList();
            cboCajero.ListaMostrada = cols2;
            cboCajero.SelectedIndex = 0;

        }

        #endregion Constructor       

        #region Eventos
        /// <summary>
        /// Evento del botón de salir. Sale de la pantalla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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



        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFormularios.SelectedRows.Count > 0)
                {
                    imprimirExceles();
                }

            }
            catch (Excepcion ex)
            {
                throw new Excepcion(ex.Message);
            }

        }

        #endregion Eventos                


        private void obtenerFormularios()
        {
            int cajero = ((Colaborador)cboCajero.ListaMostrada[cboCajero.SelectedIndex]).ID;// id del cajero seleccionado en el cbo
            DateTime desde = dtpDesde.Value;
            DateTime hasta = dtpHasta.Value;
            int tipoFormulario = cboFormularios.SelectedIndex;
            DataTable dt = _mantenimiento.obtieneReporte(cajero, desde, hasta, tipoFormulario);
            if (dt.Rows.Count > 0)
            {
                dgvFormularios.DataSource = dt;
                dgvFormularios.Columns["Id"].Visible = false;
                dgvFormularios.Columns["tipoDoc"].Visible = false;
                if (dgvFormularios.ColumnCount == 9)
                {
                    dgvFormularios.Columns["moneda"].Visible = false;
                }
            }

            else
            {
                MessageBox.Show("No hay datos en ese periodo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvFormularios.DataSource = null;
            }
        }


        private void imprimirExceles()
        {
            DataGridViewRow tramite = dgvFormularios.SelectedRows[0];
            int tipo = Int32.Parse(tramite.Cells["tipoDoc"].Value.ToString()); //tipoTramite: indica que tipo de formulario es
            int id = Int32.Parse(tramite.Cells["Id"].Value.ToString()); //indica el id del tramite 
            DateTime fecha = DateTime.Parse(tramite.Cells["Fecha"].Value.ToString());

            switch (tipo)
            {
                case 0:
                    imprimirCntrlDiarioCierreCajero(id);
                    break;
                case 1:
                    imprimirDetalleInconsistenciasTesoreria(id);
                    break;
                case 2:
                    imprimirCntrlDiarioCierreCajeroNiquel(id);
                    break;
                case 3:
                    imprimirBoletaNikelEntregaCajero(id);
                    break;
                case 4:
                    imprimirBoletaNikelEntregaCola(id);
                    break;
                case 5:
                    imprimirInconsistenciasManifiesto(id);
                    break;
                case 6:
                    int moneda = Int32.Parse(tramite.Cells["moneda"].Value.ToString());
                    imprimiRecapBPS(id, moneda, fecha);
                    break;
                default:
                    break;
            }

        }


        private void imprimirBoletaNikelEntregaCajero(int id)
        {
            DataTable dt = _mantenimiento.obtieneExcelBoletaNikelEntregaCajero(id);
            if (dt.Rows.Count > 0)
                try
                {
                    DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla boleta_niquel_cajero_niquel.xlsx", false);
                    documento.seleccionarHoja(1);
                    documento.seleccionarCelda("D2");
                    documento.actualizarValorCelda("BOLETA DE EFECTIVO No. " + id);
                    documento.seleccionarCelda("C4");
                    documento.actualizarValorCelda(dt.Rows[0][0]);
                    documento.seleccionarCelda("C6");
                    documento.actualizarValorCelda(dt.Rows[0][1]);
                    documento.seleccionarCelda("C8");
                    documento.actualizarValorCelda(dt.Rows[0][2]);
                    documento.seleccionarCelda("C10");
                    documento.actualizarValorCelda(dt.Rows[0][3]);
                    documento.seleccionarCelda("C12");
                    documento.actualizarValorCelda(dt.Rows[0][4]);
                    documento.seleccionarCelda("F8");
                    documento.actualizarValorCelda(dt.Rows[0][5]);
                    documento.seleccionarCelda("F10");
                    documento.actualizarValorCelda(dt.Rows[0][6]);
                    documento.seleccionarCelda("F12");
                    documento.actualizarValorCelda(dt.Rows[0][7]);
                    documento.mostrar();
                    documento.cerrar();
                }
                catch
                {
                    Excepcion.mostrarMensaje("ErrorExel");
                }
            else
                MessageBox.Show("Ocurrio un error al obtener los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void imprimirCntrlDiarioCierreCajeroNiquel(int id)
        {
            DataTable dt = _mantenimiento.obtenerExcelCntrDiarioCierreCajeroNikel(id);
            if (dt.Rows.Count > 0)
                try
                {

                    DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla cierre_diario_cajero_niquel.xlsx", false);
                    documento.seleccionarHoja(1);
                    documento.seleccionarCelda("A6");
                    documento.actualizarValorCelda("FECHA: " + dt.Rows[0][0]);
                    documento.seleccionarCelda("A7");
                    documento.actualizarValorCelda("MANIFEISTOS PROCESADOS: " + dt.Rows[0][1]);
                    int y = 11;
                    for (int i = 2; i <= 8; i = i + 3)
                    {
                        documento.seleccionarCelda("C" + y);
                        documento.actualizarValorCelda(dt.Rows[0][i]);
                        documento.seleccionarCelda("D" + y);
                        documento.actualizarValorCelda(dt.Rows[0][i + 1]);
                        y++;
                    }

                    y = 19;
                    for (int i = 11; i <= 66; i = i + 3)
                    {
                        documento.seleccionarCelda("C" + y);
                        documento.actualizarValorCelda(dt.Rows[0][i]);
                        documento.seleccionarCelda("D" + y);
                        documento.actualizarValorCelda(dt.Rows[0][i + 1]);
                        documento.seleccionarCelda("F" + y);
                        documento.actualizarValorCelda(dt.Rows[0][i + 2]);
                        y++;
                    }
                    documento.seleccionarCelda("C39");
                    documento.actualizarValorCelda(dt.Rows[0][58]);
                    documento.seleccionarCelda("D39");
                    documento.actualizarValorCelda(dt.Rows[0][59]);
                    documento.seleccionarCelda("F39");
                    documento.actualizarValorCelda(dt.Rows[0][60]);
                    documento.mostrar();
                    documento.cerrar();

                }
                catch
                {
                    Excepcion.mostrarMensaje("ErrorExel");
                }
            else
                MessageBox.Show("Ocurrio un error al obtener los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void imprimirBoletaNikelEntregaCola(int id)
        {
            DataTable dt = _mantenimiento.obtieneExcelBoletaNikelEntregaCola(id);
            if (dt.Rows.Count > 0)
                try
                {

                    DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla boleta niquel_entrega_cola.xlsx", false);
                    documento.seleccionarHoja(1);
                    documento.seleccionarCelda("C4");
                    documento.actualizarValorCelda(dt.Rows[0][0]);
                    documento.seleccionarCelda("F4");
                    documento.actualizarValorCelda(dt.Rows[0][1]);
                    documento.seleccionarCelda("C6");
                    documento.actualizarValorCelda(dt.Rows[0][2]);
                    documento.seleccionarCelda("C8");
                    documento.actualizarValorCelda(dt.Rows[0][3]);
                    documento.seleccionarCelda("C10");
                    documento.actualizarValorCelda(dt.Rows[0][4]);
                    documento.mostrar();
                    documento.cerrar();
                }
                catch
                {
                    Excepcion.mostrarMensaje("Error Exel niquel entrega cola");
                }
            else
                MessageBox.Show("Ocurrio un error al obtener los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void imprimirDetalleInconsistenciasTesoreria(int id)
        {
            DataTable dt = _mantenimiento.obtieneExcelDetalleInconsistenciasTesoreria(id);
            if (dt.Rows.Count > 0)
                try
                {

                    DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla Detalle_Inconsistencias_Tesoreria.xlsx", false);
                    documento.seleccionarHoja(1);
                    if (Int32.Parse(dt.Rows[0][0].ToString()) == 0)
                    {
                        documento.seleccionarCelda("D9");
                    }
                    else
                    {
                        documento.seleccionarCelda("I9");
                    }
                    documento.actualizarValorCelda("X");
                    switch (Int32.Parse(dt.Rows[0][1].ToString()))
                    {
                        case 0:
                            documento.seleccionarCelda("D11");
                            break;
                        case 1:
                            documento.seleccionarCelda("I11");
                            break;
                        default:
                            break;

                    }
                    documento.actualizarValorCelda("X");


                    documento.llenarcuadrodetexto("Rectangle 13", dt.Rows[0][2].ToString());
                    documento.llenarcuadrodetexto("Rectangle 14", dt.Rows[0][3].ToString());
                    documento.llenarcuadrodetexto("Rectangle 17", dt.Rows[0][4].ToString());
                    documento.llenarcuadrodetexto("Rectangle 15", dt.Rows[0][5].ToString());
                    documento.llenarcuadrodetexto("Rectangle 18", dt.Rows[0][6].ToString());
                    documento.llenarcuadrodetexto("Rectangle 16", dt.Rows[0][7].ToString());
                    documento.llenarcuadrodetexto("Rectangle 19", dt.Rows[0][8].ToString());
                    documento.seleccionarCelda("G33");
                    documento.actualizarValorCelda(dt.Rows[0][9]);
                    documento.seleccionarCelda("C36");
                    documento.actualizarValorCelda("Monto declarado por cliente: " + dt.Rows[0][10]);
                    documento.seleccionarCelda("C37");
                    documento.actualizarValorCelda("Monto recibido: " + dt.Rows[0][11]);
                    string seriesVal = (dt.Rows[0][12]).ToString();
                    string[] series = seriesVal.Split(',');
                    int x = 38;
                    foreach (string element in series)
                    {
                        documento.seleccionarCelda("C" + x);
                        documento.actualizarValorCelda("Billete falso con No. Serie: " + element);
                        x++;
                    }
                    int z = Int32.Parse(dt.Rows[0][13].ToString());
                    switch (z)
                    {
                        case 0:
                            documento.seleccionarCelda("D26");
                            documento.actualizarValorCelda("X");
                            break;
                        case 1:
                            documento.seleccionarCelda("H26");
                            documento.actualizarValorCelda("X");
                            break;
                        case 2:
                            documento.seleccionarCelda("D28");
                            documento.actualizarValorCelda("X");
                            break;
                        case 3:
                            documento.seleccionarCelda("H28");
                            documento.actualizarValorCelda("X");
                            break;
                        case 4:
                            documento.seleccionarCelda("D30");
                            documento.actualizarValorCelda("X");
                            break;
                        default:
                            break;
                    }


                    documento.mostrar();
                    documento.cerrar();
                }
                catch
                {
                    Excepcion.mostrarMensaje("ErrorExel Detalle_Inconsistencias_Tesoreria");
                }
            else
                MessageBox.Show("Ocurrio un error al obtener los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void imprimirCntrlDiarioCierreCajero(int id)
        {
            DataTable dt = _mantenimiento.obtieneExcelCntrlDiarioCierreCajero(id);
            if (dt.Rows.Count > 0)
                try
                {

                    DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla cierre_diario_cajero.xlsx", false);
                    documento.seleccionarHoja(1);
                    documento.seleccionarCelda("A7");
                    documento.actualizarValorCelda("FECHA: " + dt.Rows[0][0]);
                    documento.seleccionarCelda("A8");
                    documento.actualizarValorCelda("MANIFIESTOS PROCESADOS: " + dt.Rows[0][1]);
                    int y = 12;
                    for (int i = 2; i <= 8; i = i + 3)
                    {
                        documento.seleccionarCelda("C" + y);
                        documento.actualizarValorCelda(dt.Rows[0][i]);
                        documento.seleccionarCelda("D" + y);
                        documento.actualizarValorCelda(dt.Rows[0][i + 1]);
                        y++;
                    }
                    y = 18;
                    for (int i = 11; i <= 53; i = i + 3)
                    {
                        documento.seleccionarCelda("C" + y);
                        documento.actualizarValorCelda(dt.Rows[0][i]);
                        documento.seleccionarCelda("D" + y);
                        documento.actualizarValorCelda(dt.Rows[0][i + 1]);
                        documento.seleccionarCelda("E" + y);
                        documento.actualizarValorCelda(dt.Rows[0][i + 2]);
                        y++;
                    }

                    documento.seleccionarCelda("C34");
                    documento.actualizarValorCelda(dt.Rows[0][56]);
                    documento.seleccionarCelda("D34");
                    documento.actualizarValorCelda(dt.Rows[0][57]);
                    documento.seleccionarCelda("E34");
                    documento.actualizarValorCelda(dt.Rows[0][58]);
                    documento.mostrar();
                    documento.cerrar();
                }
                catch
                {
                    Excepcion.mostrarMensaje("ErrorExel cierre_diario_cajero");
                }
            else
                MessageBox.Show("Ocurrio un error al obtener los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private int imprimirBoletaEntregaNiquel(int reg)
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\Planillas Inconsistencias clientes_manifiesto.xlsx", false);
                DateTime fecha = Convert.ToDateTime(datos.Rows[0]["Fecha_Inconsistencia"]);
                int registrosimpresion = 0;
                int procesoregistros = 0;
                string Cajero = datos.Rows[0]["Cajero"].ToString();
                DateTime thisDay = DateTime.Today;

                documento.seleccionarHoja(1);

                documento.seleccionarCelda("B5");
                documento.actualizarValorCelda("Fecha: " + fecha.ToShortDateString());

                documento.seleccionarCelda("B6");
                documento.actualizarValorCelda(Cajero);


                for (int i = reg; i < datos.Rows.Count; i++)
                {
                    if ((Convert.ToInt32(datos.Rows[i]["Monto_Diferencia"]) <= -1000) || (Convert.ToInt32(datos.Rows[i]["Monto_Diferencia"]) >= 1000))
                    {
                        DateTime hora = Convert.ToDateTime(datos.Rows[i]["Fecha_Inconsistencia"]);
                        documento.seleccionarCelda("B" + Convert.ToString(registrosimpresion + 10));
                        documento.actualizarValorCelda(datos.Rows[i]["Cliente"]);

                        documento.seleccionarCelda("C" + Convert.ToString(registrosimpresion + 10));
                        documento.actualizarValorCelda(datos.Rows[i]["Manifiesto"]);

                        if (Convert.ToByte(datos.Rows[i]["Tipo_Diferencia"]) == 1)
                        {
                            documento.seleccionarCelda("H" + Convert.ToString(registrosimpresion + 10));
                        }
                        else
                        {
                            documento.seleccionarCelda("G" + Convert.ToString(registrosimpresion + 10));
                        }

                        documento.actualizarValorCelda(datos.Rows[i]["Monto_Diferencia"]);

                        documento.seleccionarCelda("I" + Convert.ToString(registrosimpresion + 10));
                        documento.actualizarValorCelda(datos.Rows[i]["Monto_Declarado"]);
                        documento.seleccionarCelda("J" + Convert.ToString(registrosimpresion + 10));
                        documento.actualizarValorCelda(datos.Rows[i]["Monto_Recibido"]);
                        documento.seleccionarCelda("K" + Convert.ToString(registrosimpresion + 10));
                        documento.actualizarValorCelda(hora.ToShortTimeString());
                        documento.seleccionarCelda("L" + Convert.ToString(registrosimpresion + 10));
                        documento.actualizarValorCelda(datos.Rows[i]["Detalle"]);
                        registrosimpresion += 1;
                    }

                    if (registrosimpresion == 11)
                    {
                        break;
                    }
                    procesoregistros = i;
                }

                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
                return (procesoregistros + 1);
            }
            catch (Exception ex)
            {

                Excepcion.mostrarMensaje(ex.Message);
                return reg;
            }

        }


        private void imprimirInconsistenciasManifiesto(int id)
        {
            datos = _mantenimiento.obtieneExcelInconsistenciasManifiesto(id);
            int conteoregistros = 0;
            //int CantExcel = datos.Rows.Count / 11;
            if (datos.Rows.Count > 0)
            {
                while (conteoregistros < datos.Rows.Count)
                {
                    conteoregistros = imprimirBoletaEntregaNiquel(conteoregistros);
                }
                //_atencion.CerrarInfoFormularioInconsistenciasManifiesto(datos);
                MessageBox.Show("Fin de proceso de impresión de inconsistencias por manifiesto con diferencia mayor a 1000 colones o su equivalente");
            }
            else
            {
                MessageBox.Show("No hay inconsistencias por manifiesto para generar el formulario respectivo.");
            }
            //    if (dt.Rows.Count > 0)
            //        try
            //        {

            //            DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\Planillas Inconsistencias clientes_manifiesto.xlsx", false);
            //            documento.seleccionarHoja(1);
            //            if (dt.Rows.Count > 10) documento.duplicarHoja("h2");
            //            documento.seleccionarHoja(1);
            //            documento.seleccionarCelda("B5");
            //            documento.actualizarValorCelda("FECHA: " + dt.Rows[0][0]);
            //            documento.seleccionarCelda("B6");
            //            documento.actualizarValorCelda("CAJERO: " + dt.Rows[0][1]);
            //            int row = 10;
            //            for (int i = 0; i < dt.Rows.Count; i++)
            //            {
            //                documento.seleccionarCelda("B" + row);
            //                documento.actualizarValorCelda(dt.Rows[i][2]);
            //                documento.seleccionarCelda("C" + row);
            //                documento.actualizarValorCelda(dt.Rows[i][3]);
            //                documento.seleccionarCelda("G" + row);
            //                documento.actualizarValorCelda(dt.Rows[i][4]);
            //                documento.seleccionarCelda("H" + row);
            //                documento.actualizarValorCelda(dt.Rows[i][5]);
            //                documento.seleccionarCelda("I" + row);
            //                documento.actualizarValorCelda(dt.Rows[i][6]);
            //                documento.seleccionarCelda("J" + row);
            //                documento.actualizarValorCelda(dt.Rows[i][7]);
            //                documento.seleccionarCelda("K" + row);
            //                documento.actualizarValorCelda(dt.Rows[i][9]);
            //                //documento.seleccionarCelda("L" + row);
            //                //documento.actualizarValorCelda(dt.Rows[i][9]);
            //                row++;
            //                if (i == 10)
            //                {
            //                    documento.seleccionarHoja(2);
            //                    row = 10;
            //                }
            //            }


            //                documento.mostrar();
            //            documento.cerrar();
            //        }
            //        catch
            //        {
            //            Excepcion.mostrarMensaje("ErrorExel Planillas Inconsistencias clientes_manifiesto");
            //        }
            //    else
            //        MessageBox.Show("Ocurrio un error al obtener los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void imprimiRecapBPS(int id, int moneda, DateTime fecha)
        {
            DataTable dt = _mantenimiento.obtieneExcelRecapBPS(id, moneda, fecha);
            if (dt.Rows.Count > 0)
                try
                {
                    string ruta = "";
                    if (moneda == 0)
                    {
                        ruta = "\\Plantillas\\reporteFinDiaColon.xlsx";
                    }
                    else if (moneda == 1)
                    {
                        ruta = "\\Plantillas\\reporteFinDiaDolar.xlsx";
                    }
                    else
                    {
                        ruta = "\\Plantillas\\reporteFinDiaEuro.xlsx";
                    }
                    DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + ruta, false);

                    documento.seleccionarHoja(1);
                    documento.seleccionarCelda("H10");
                    documento.actualizarValorCelda(dt.Rows[0][0]);//fecha
                    documento.seleccionarCelda("H14");
                    documento.actualizarValorCelda(dt.Rows[0][1]);//num depositos
                    documento.seleccionarCelda("H12");
                    documento.actualizarValorCelda(dt.Rows[0][2]);// id contador
                    documento.seleccionarCelda("H16");
                    documento.actualizarValorCelda(dt.Rows[0][3]);// total
                    int row = 22;
                    for (int i = 4; i < dt.Columns.Count - 2; i += 3)
                    {
                        documento.seleccionarCelda("G" + row);
                        documento.actualizarValorCelda(dt.Rows[0][i]);//circulable
                        documento.seleccionarCelda("J" + row);
                        documento.actualizarValorCelda(dt.Rows[0][i + 1]);//no circulable
                        documento.seleccionarCelda("K" + row);
                        documento.actualizarValorCelda(dt.Rows[0][i + 2]);//total 
                        row++;
                    }
                    documento.mostrar();
                    documento.cerrar();
                }
                catch
                {
                    Excepcion.mostrarMensaje("ErrorExel Planillas Inconsistencias clientes_manifiesto");
                }
            else
                MessageBox.Show("Ocurrio un error al obtener los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void frmConsultaFormularios_Load(object sender, EventArgs e)
        {
            DateTime ahora = DateTime.Now;
            DateTime inicio = new DateTime(ahora.Year, ahora.Month, ahora.Day, 0, 0, 0);
            DateTime fin = new DateTime(ahora.Year, ahora.Month, ahora.Day, 23, 59, 59);
            dtpDesde.Value = inicio;
            dtpHasta.Value = fin;
        }

        private void gbConsulta_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Espere mientras se carga la información", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                obtenerFormularios();
            }
            catch (Excepcion ex)
            {
                throw new Excepcion(ex.Message);
            }

        }


        #region Métodos Privados



        #endregion Métodos Privados
    }
}
