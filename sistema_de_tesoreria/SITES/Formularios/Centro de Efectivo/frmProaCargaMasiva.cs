
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using LibreriaAccesoDatos;
using BussinessLayer;
using CommonObjects;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmProaCargaMasiva : Form
    {
        string path = "";
        private ManejadorBD bd = ManejadorBD.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private DataTable dtDepositos = new DataTable();
        private DataTable dtInconsistencias = new DataTable();
        string[] depositoHeader = { "CODIGO", "CUENTA", "CUENTA2", "", "MONTOS", "REFERENCIA", "", "", "CEDULA_GENERICA", "CLIENTE", "PUNTO_DE_VENTA", "MANIFIESTO", "TULA", "CUENTA3", "DEPOSITO", "COLONES_EFECTIVO", "DOLARES_EFECTIVO", "NIQUEL_CRC", "COMPRA_USD", "VENTA_USD", "FALTANTE_CRC", "SOBREANTE_CRC", "FALTANTE_USD", "SOBRANTE_USD", "CHEQUE_LOCAL_CRC", "CHEQUE_LOCAL_USD", "CHEQUE_PROPIO_CRC", "CHEQUE_PROPIO_USD", "CHEQUE_EXTERIOR_CRC", "CHEQUE_EXTERIOR_USD", "TOTAL_COLONES", "TOTAL_USD", "NUMERO_DEPOSITO", "CAJERO", "CAMARA" };
   
        string[] inconsHeader = { "DEPOSITO_#", "EMPRESA", "HORA_MESA", "CAMARA", "CAJERO", "FALTANTE_¢", "SOBRANTE_¢", "FALTANTE_$", "SOBRANTE_$", "FALSO", "Monto_depósito", "Monto_recibido", "Monto_planilla", "Suma de los depósitos", "VIDEO", "PLANILLA", "TULA", "SUPERVISOR", "ACTA_#", "OBSERVACIONES" };
        private Boolean excelModificado = false;
        private Colaborador colaborador = null;
        
        public DataTable leerExcel(int hoja)
        {
            DataTable dt = new DataTable();
            try
            {
                string sSheetName = "";
                string sConnection = "";
                DataTable dtTablesList = default(DataTable);
                OleDbConnection oleExcelConnection = default(OleDbConnection);
                System.Data.OleDb.OleDbDataAdapter cmd = default(System.Data.OleDb.OleDbDataAdapter);
                //sConnection = "Provider=Microsoft.ACE.OLEDB.12.0;data source=" & path & ";Extended Properties=""Excel 8.0;HDR=No;IMEX=1"""
                sConnection = "Provider=Microsoft.ACE.OLEDB.12.0;data source=" + path + ";Extended Properties=\"Excel 12.0;HDR=no;IMEX=1\"";
                oleExcelConnection = new OleDbConnection(sConnection);
                oleExcelConnection.Open();

                dtTablesList = oleExcelConnection.GetSchema("Tables");

                if (dtTablesList.Rows.Count > 0)
                {
                    sSheetName = dtTablesList.Rows[hoja]["TABLE_NAME"].ToString();
                }

                dtTablesList.Clear();
                dtTablesList.Dispose();

                if (!string.IsNullOrEmpty(sSheetName))
                {
                    cmd = new System.Data.OleDb.OleDbDataAdapter("select * from [" + sSheetName +"]", oleExcelConnection);
                    cmd.Fill(dt);
                    oleExcelConnection.Close();
                }

                oleExcelConnection.Close();
                //USAR EL dt PARA INSERTAR LOS DATOS NECESARIOS.
                return dt;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new DataTable();
            }
        }


        public frmProaCargaMasiva(Colaborador c) //recibir el colaborador por parametros
        {
            InitializeComponent();
            this.colaborador = c;
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            excelModificado = false;
            try
            {
                dgvDeposito.DataSource = null;
                dgvDeposito.Refresh();
                dgvIncosistencia.DataSource = null;
                dgvIncosistencia.Refresh();
                openFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx| Excel Files (*.xls)|*.xls";
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    lbMsj.Text = "Por Favor Espere Mientras el Excel se Lee ";
                    path = openFileDialog1.FileName;
                    if (cargaDepositosAlGrid())
                    {
                        btnAceptar.Enabled = true;
                    }
                    else
                    {
                        btnAceptar.Enabled = false;
                    }
                    cargaInconsistenciasAlGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el archivo. Detalle: " + ex.Message, "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbMsj.Text = "";
            }
            lbMsj.Text = "";
        }

        private bool cargaDepositosAlGrid()
        {
            try
            {
                dtDepositos = leerExcel(0);
                if (dtDepositos.Columns.Count >= depositoHeader.Length)
                {
                    if (dtDepositos.Rows.Count > 1)
                    {
                        //SI LA COLUMNA A NO TIENE NADA, OMITE LA FILA
                        dtDepositos = dtDepositos.Rows.Cast<DataRow>().Where(row => row.ItemArray.Any(x => !string.IsNullOrWhiteSpace(x.ToString()))).CopyToDataTable(); // verificar que las primer
                        dtDepositos.Rows.RemoveAt(0);//quitar encabezado
                        dtDepositos.AcceptChanges();
                        dgvDeposito.DataSource = dtDepositos;
                        setHeaderDepositos();
                        return true;
                    }
                    else //
                    {
                        MessageBox.Show("El sistema no encontró información en la pestaña de depositos (pestaña 1 del excel)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error al intentar cargar la pestaña de depositos, verifique que el excel posea las siguientes columnas:CODIGO, CUENTA, CUENTA,(vacio) , MONTOS, REFERENCIA,(vacio),(vacio) , CEDULA_GENERICA, CLIENTE, PUNTO_DE_VENTA, MANIFIESTO, TULA, CUENTA3, DEPOSITO, COLONES_EFECTIVO, DOLARES_EFECTIVO, NIQUEL_CRC, COMPRA_USD, VENTA_USD, FALTANTE_CRC, SOBREANTE_CRC, FALTANTE_USD, SOBRANTE_USD, CHEQUE_LOCAL_CRC, CHEQUE_LOCAL_USD, CHEQUE_PROPIO_CRC, CHEQUE_PROPIO_USD, CHEQUE_EXTERIOR_CRC, CHEQUE_EXTERIOR_USD, TOTAL_COLONES, TOTAL_USD, NUMERO_DEPOSITO, CAJERO ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        private bool cargaInconsistenciasAlGrid()
        {
            try
            {
                dtInconsistencias = leerExcel(1);
                if (dtInconsistencias.Columns.Count >= inconsHeader.Length)
                {
                    dtInconsistencias = dtInconsistencias.Rows.Cast<DataRow>().Where(row => row.ItemArray.Any(x => !string.IsNullOrWhiteSpace(x.ToString()))).CopyToDataTable(); // verificar que las primer
                    dtInconsistencias.Rows.RemoveAt(0);
                    dtInconsistencias.AcceptChanges();
                    dgvIncosistencia.DataSource = dtInconsistencias;
                    setHeaderInconisistencias();
                    return true;
                }
                else
                {
                    MessageBox.Show("La pestaña inconsistencias del excel no posee el formato correcto. Si el excel no posee inconsistencias omita este error, de lo contrario, verifique que posea datos en las siguientes columnas: DEPOSITO #,EMPRESA,HORA MESA,CAMARA,CAJERO,FALTANTE ¢,SOBRANTE ¢,FALTANTE $,SOBRANTE $,FALSO,Monto depósito,Monto recibido,Monto planilla,Suma de los depósitos,VIDEO,PLANILLA,TULA,SUPERVISOR,ACTA #,OBSERVACIONES. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setHeaderInconisistencias2();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error. Las inconsistencias deben encontrarse en la pestaña 2 del excel. Si no hay inconsistencias que cargar omita este error. Si desea cargar inconsistencias junto a los depósitos, verifique que el excel posea el formato correcto y vulélvalo a cargar. Otros posibles Errores : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void setHeaderInconisistencias()
        {
            for (int i = 0; i < inconsHeader.Length; i++)
            {
                dgvIncosistencia.Columns[i].Name = inconsHeader[i];
                dgvIncosistencia.Columns[i].HeaderCell.Value = inconsHeader[i];
            }
        }
        private void setHeaderInconisistencias2()
        {
            DataTable dt = new  DataTable();
            for (int i = 0; i < inconsHeader.Length; i++)
            {
                dt.Columns.Add(inconsHeader[i]);
            }
            dgvIncosistencia.DataSource = dt;
        }
        private void setHeaderDepositos()
        {
            for (int i = 0; i< depositoHeader.Length; i++)
            {
                dgvDeposito.Columns[i].Name = depositoHeader[i];
                dgvDeposito.Columns[i].HeaderCell.Value = depositoHeader[i];
            }        
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            lbMsj.Text = "Validando los Datos, Espere por Favor...";
            MessageBox.Show("Por favor espere mientras se validan los datos.","Información",MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dgvDeposito.DataSource != null && dgvIncosistencia.DataSource != null)
            {
                
                this.dgvDeposito.Sort(this.dgvDeposito.Columns[0], ListSortDirection.Ascending);
               // this.dgvIncosistencia.Sort(this.dgvIncosistencia.Columns[0], ListSortDirection.Ascending);
                Boolean inconsistCorrectas = true; // se supone true por si no hay
                                                   //btnAceptar.Enabled = false;
                if (!excelModificado) //arreglarlo
                {
                    eliminarColsDep();
                    addColsDep();
                    eliminarColsInc();
                    excelModificado = true;
                }
                tabControl1.SelectedIndex = 0;             
                if (validarDepositos()) //valida depositos
                {
                    if (dgvIncosistencia.Rows.Count >0)//si hay alguna inconsistencia
                    {
                        tabControl1.SelectedIndex = 1;
                        inconsistCorrectas = validarInconsistencias(); //validar las inconsistencias                  
                    }
                    if (inconsistCorrectas)
                    {
                        if (_mantenimiento.insertarManifiestoInconsistencia(dgvDeposito, dgvIncosistencia, colaborador) == true)
                        {
                            MessageBox.Show("Archivo insertado correctamente");
                            lbMsj.Text = "";
                            dgvDeposito.DataSource = null;
                            dgvIncosistencia.DataSource = null;
                            btnAceptar.Enabled = false;
                        }

                    }
                    else
                    {
                        lbMsj.Text = "Error al validar el archivo de inconsistencias";                      
                        MessageBox.Show("El sistema no puede cargar los datos, hay errores en la pestaña de INCONSISTENCIAS. Verifique las celdas coloreadas ya que poseen un formato incorrecto. Al presionar el botón Léeme, podrás ver el significado de los colores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    lbMsj.Text = "Error al cargar el archivo";
                    MessageBox.Show("El sistema no puede cargar los datos, hay errores en la pestaña de DÉPOSITOS. Verifique las celdas coloreadas ya que poseen un formato incorrecto. Al presionar el botón Léeme, podrás ver el significado de los colores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                lbMsj.Text = "Selecciona un archivo primero";
            }
        }

        private void addColsDep()
        {
            dtDepositos.Columns.Add("MONEDA");
            dtDepositos.Columns.Add("CLIENTE_ID");
            dtDepositos.Columns.Add("PUNTO_VENTA_ID");
            dtDepositos.Columns.Add("TIENE_ERROR");
            dtDepositos.Columns.Add("pk_ID");
            dgvDeposito.Columns["CLIENTE_ID"].Visible = false;
            dgvDeposito.Columns["PUNTO_VENTA_ID"].Visible = false;
            dgvDeposito.Columns["pk_ID"].Visible = false;
            dgvDeposito.Columns["MONEDA"].Visible = false;
        }

        private Boolean validarInconsistencias()
        {

            bool convertible = false, exist = false, pasar = true;
            decimal monto = 0;
            foreach (DataGridViewRow rw in dgvIncosistencia.Rows)
            {
                //rw.DefaultCellStyle.BackColor = Color.White;
                rw.Cells["TIENE_ERROR"].Value = "NO";
                for (int p = 4; p< rw.Cells.Count-3; p++)
                {
                    rw.Cells[p].Style.BackColor = Color.White;
                    if (celdaVacia(rw.Cells[p].Value))
                    {
                        rw.Cells[p].Value = 0;
                    }
                    else
                    {
                        convertible = Decimal.TryParse(rw.Cells[p].Value.ToString(), out monto);
                        if (!convertible)
                        {
                           // rw.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                            rw.Cells[p].Style.BackColor = Color.GreenYellow;
                            rw.Cells["TIENE_ERROR"].Value = "SI";
                            pasar = false;
                        }
                        else
                        {
                            if (p == 8 && monto != 0)//billetes falsos
                            {
                                int moneda = determinaMoneda(rw.Cells[4].Value.ToString(), rw.Cells[5].ToString());                              
                                if (moneda == 0 && !billetesCRCCorrectos(monto))
                                {
                                  //  rw.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                                    rw.Cells[p].Style.BackColor = Color.Yellow;
                                    rw.Cells["TIENE_ERROR"].Value = "SI";
                                    pasar = false;
                                }
                            }
                        }
                    }

                }

                //camara
                rw.Cells[2].Style.BackColor = Color.White;
                if (!Decimal.TryParse(rw.Cells[2].Value.ToString(), out monto) || _mantenimiento.verificaCamaraID(rw.Cells[2].Value.ToString())==0)//no existe
                {
                    //rw.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    rw.Cells[2].Style.BackColor = Color.HotPink;
                    rw.Cells["TIENE_ERROR"].Value = "SI";
                    pasar = false;
                }
                //valida cajero
                rw.Cells[3].Style.BackColor = Color.White;
                if (!Decimal.TryParse(rw.Cells[3].Value.ToString(), out monto) || !_mantenimiento.existeCajero(rw.Cells[3].Value.ToString()))//4=CAJERO
                {
                    //rw.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    rw.Cells[3].Style.BackColor = Color.HotPink;
                    rw.Cells["TIENE_ERROR"].Value = "SI";
                    pasar = false;
                }
                //valida fecha
                DateTime result;
                bool fechaCorrecta = DateTime.TryParse(rw.Cells[1].Value.ToString(), out result);
                rw.Cells[1].Style.BackColor = Color.White;
                if (!fechaCorrecta)
                {
                    //rw.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    rw.Cells[1].Style.BackColor = Color.Olive;
                    rw.Cells["TIENE_ERROR"].Value = "SI";
                    pasar = false;
                }
                else
                {
                    rw.Cells[1].Value = result;
                }
                rw.Cells[0].Style.BackColor = Color.White;
                DataTable dt = (DataTable)dgvDeposito.DataSource;//verificar que las inconsistencias pertenecen a los depositos
                if (rw.Cells[0].Value.ToString()!="") {//puede que venga en blanco si es inconsistencia de manifiesto
                    exist = dt.Select().ToList().Exists(row => row[3].ToString() == rw.Cells[0].Value.ToString());//verificar inconsistencia asociada con deposito
                    if (!exist)
                    {
                      //  rw.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                        rw.Cells[0].Style.BackColor = Color.Orange;
                        rw.Cells["TIENE_ERROR"].Value = "SI";
                        pasar = false;

                    }
                }
                else
                {
                    exist = dt.Select().ToList().Exists(row => row[7].ToString() == rw.Cells[13].Value.ToString());//valida que la planilla exista en el deposito
                    if (!exist)
                    {
                       // rw.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                        rw.Cells[13].Style.BackColor = Color.Cyan;
                        rw.Cells["TIENE_ERROR"].Value = "SI";
                        pasar = false;

                    }
                }

            }
            return pasar;
        }

        private bool billetesCRCCorrectos(decimal monto)//validar billetes 
        {
             return (monto % 50000 == 0 || monto % 20000 == 0 || monto % 10000 == 0 || monto % 5000 == 0 || monto % 5000 == 0 || monto % 1000 == 0);
        }

        private int determinaMoneda(string faltanteC, string SobranteC)
        {
            decimal result;
            if(Decimal.TryParse(faltanteC, out result))
            {
                if (result != 0) return 0; //colones
            }
            if(Decimal.TryParse(SobranteC, out result))
            {
                if (result != 0) return 0;
            }
            return 1;//dolares
        }

        private void eliminarColsInc()
        {
            DataTable dt = (DataTable)dgvIncosistencia.DataSource;
            for (int i = dgvIncosistencia.Columns.Count - 1; i >= inconsHeader.Length-3; i--)
            {
                dt.Columns.RemoveAt(i);
            }
            dt.Columns.RemoveAt(14);//video
            //dt.Columns.RemoveAt(4);//cajero
            dt.Columns.RemoveAt(1);//empresa
            dt.Columns.Add("TIENE_ERROR");
            dt.AcceptChanges();
            dgvIncosistencia.DataSource = dt;          
        }

        private Boolean validarDepositos()
        {
            bool result =true; //DETERMINA SI HAY ERRORES              
            bool convertible = false;
            //this.Refresh();
            int id =0;
            int moneda; 
            foreach (DataGridViewRow rw in dgvDeposito.Rows)
            {
                Decimal monto;
                Decimal x = 0;
               // rw.DefaultCellStyle.BackColor = Color.White;
                rw.Cells["TIENE_ERROR"].Value = "NO";

                for (int i = 0; i < 9; i++)
                {
                    rw.Cells[i].Style.BackColor = Color.White;
                    if (celdaVacia(rw.Cells[i].Value))
                    {
                      //  rw.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                        rw.Cells[i].Style.BackColor = Color.Red;
                        rw.Cells["TIENE_ERROR"].Value = "SI";
                        result = false;
                    }
                    
                }

                for (int i = 9; i < rw.Cells.Count-5; i++)//validar campos numericos, todos los ultimos EXEPTO MONEDA Y TIENE_ERROR y id
                {
                    convertible = Decimal.TryParse(rw.Cells[i].Value.ToString(), out monto);
                    rw.Cells[i].Style.BackColor = Color.White;
                    if (!convertible)
                    {
                       // rw.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                        rw.Cells[i].Style.BackColor = Color.GreenYellow;
                        rw.Cells["TIENE_ERROR"].Value = "SI";
                        result = false;
                    }
                }
                if (Decimal.TryParse(rw.Cells["COLONES_EFECTIVO"].Value.ToString(), out x))
                {
                    moneda = (x == 0) ? 1 : 0; //determina la moneda
                    rw.Cells["MONEDA"].Value = moneda.ToString();
                    convertible = Decimal.TryParse(rw.Cells[2].Value.ToString(), out monto); //monto
                    rw.Cells[2].Style.BackColor = Color.White;
                    if (!convertible)
                    {
                        rw.Cells[2].Style.BackColor = Color.GreenYellow;//monto
                        rw.Cells["TIENE_ERROR"].Value = "SI";
                        result = false;
                    }
                    else
                    {
                        if (monto != 0)//monto billete existe?
                        {
                            if (moneda == 0 && !monedasCRCCorrectos(monto))
                            {
                                rw.Cells[2].Style.BackColor = Color.Yellow;//monto
                                rw.Cells["TIENE_ERROR"].Value = "SI";
                                result = false;
                            }
                        }
                    }
                    convertible = Decimal.TryParse(rw.Cells[11].Value.ToString(), out monto);
                    if (!convertible)
                    {
                        rw.Cells[11].Style.BackColor = Color.GreenYellow;//niquel
                        rw.Cells["TIENE_ERROR"].Value = "SI";
                        result = false;
                    }
                    else
                    {
                        if (monto != 0)//monto billete existe?
                        {
                            if (!monedasCRCCorrectos(monto))
                            {
                                rw.Cells[11].Style.BackColor = Color.Yellow;//niquel
                                rw.Cells["TIENE_ERROR"].Value = "SI";
                                result = false;
                            }
                        }
                    }
                }
                else
                {
                   // MessageBox.Show("Error al convertir los caracteres a números, columna: COLONES_EFECTIVO");
                    result = false;
                }

                //validar cliente
                int cliente = _mantenimiento.getClienteID(rw.Cells[5].Value.ToString());//5
                rw.Cells[5].Style.BackColor = Color.White;
                if (cliente != 0)
                {  
                    //validar punto de venta
                    int punto_venta = _mantenimiento.getPuntoVentaID(cliente,rw.Cells[6].Value.ToString());//6
                    rw.Cells[6].Style.BackColor = Color.White;
                    if (punto_venta == 0)
                    {
                       // rw.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                        rw.Cells[6].Style.BackColor = Color.HotPink;
                        rw.Cells["TIENE_ERROR"].Value = "SI";
                        result = false;
                    }
                    else
                    {
                        rw.Cells["CLIENTE_ID"].Value = cliente;
                        rw.Cells["PUNTO_VENTA_ID"].Value = punto_venta;
                    }
                }
                else
                {
                   // rw.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    rw.Cells[5].Style.BackColor = Color.HotPink;
                    rw.Cells["TIENE_ERROR"].Value = "SI";
                    result = false;
                }
                //verificar camara 
                rw.Cells["CAMARA"].Style.BackColor = Color.White;
                if (!Decimal.TryParse(rw.Cells["CAMARA"].Value.ToString(), out monto) || _mantenimiento.existeCamara(rw.Cells["CAMARA"].Value.ToString()) == 0)
                {
                   // rw.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    rw.Cells["CAMARA"].Style.BackColor = Color.HotPink;
                    rw.Cells["TIENE_ERROR"].Value = "SI";
                    result = false;
                }//verifica cajero
                rw.Cells["CAJERO"].Style.BackColor = Color.White;
                if (!Decimal.TryParse(rw.Cells["CAJERO"].Value.ToString(), out monto) || !_mantenimiento.existeCajero(rw.Cells["CAJERO"].Value.ToString()))//4=CAJERO
                {
                   // rw.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    rw.Cells["CAJERO"].Style.BackColor = Color.HotPink;
                    result = false; 
                }
                rw.Cells["pk_ID"].Value = ++id;
            }

            return result;
        }

        private bool monedasCRCCorrectos(decimal monto)
        {
            return monto % 5 == 0;
        }

        private bool celdaVacia(object cell)
        {
            return cell == null || cell == DBNull.Value || String.IsNullOrWhiteSpace(cell.ToString());
        }

        private void eliminarColsDep()//ELIMINA COLUMNAS INNECESARIAS
        {
            DataTable dt = (DataTable)dgvDeposito.DataSource;
            for (int i = dgvDeposito.Columns.Count-1; i >= depositoHeader.Length; i--)
            {
                dt.Columns.RemoveAt(i);
            }
            dt.Columns.RemoveAt(32);//numero deposito
            dt.Columns.RemoveAt(14);//deposito
            dt.Columns.RemoveAt(13);//cuenta
            dt.Columns.RemoveAt(7);//vacio
            dt.Columns.RemoveAt(6);//vacio
            dt.Columns.RemoveAt(3);//vacio
            dt.Columns.RemoveAt(2);//cuenta
            dt.AcceptChanges();
            dgvDeposito.DataSource = dt;
        }
        private void frmProaCargaMasiva_Load(object sender, EventArgs e)
        {
            //bd.conectarse("10.120.201.56", "SISTEMA TESORERIA", "UsuarioST", "Credomatic");
           // bd.conectarse("CRICPPOPECOMEBD,3123", "INFOATMPLUS", "APL_INFOATM", "APL_INFOATM1!");
        }

        private void btnDrop_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage1"])//your specific tabname
            {
                foreach (DataGridViewRow item in this.dgvDeposito.SelectedRows)
                {
                    dgvDeposito.Rows.RemoveAt(item.Index);
                }
            }
            else
            {
                foreach (DataGridViewRow item in this.dgvIncosistencia.SelectedRows)
                {
                    dgvIncosistencia.Rows.RemoveAt(item.Index);
                }
            }

        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + "\\Plantillas\\ManualCargasMasivas.pdf");
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + "\\Plantillas\\DemoCargaMasiva.xlsx");
        }
    }
}
