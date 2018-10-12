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
using System.Reflection;

namespace GUILayer
{
    public partial class frmImportaciónRemanentesATMsCompletos : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<MontoRemanenteATM> _remanentes = new BindingList<MontoRemanenteATM>();

        #endregion Atributos


        #region Constructor

        public frmImportaciónRemanentesATMsCompletos()
        {
            InitializeComponent();
            dgvMontos.AutoGenerateColumns = false;
        }

        #endregion Constructor


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
            this.leerRemanentesAS400();
        }

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                _coordinacion.importarRegistrosRemanentesATMsCompletos(_remanentes);
                MessageBox.Show("Insercion exitosa");
                dgvMontos.DataSource = null;
                btnGuardar.Enabled = false;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Se selecciona otro ATM de la lista de montos remanentes de ATM's.
        /// </summary>
        private void dgvMontos_SelectionChanged(object sender, EventArgs e)
        {
            btnGuardar.Enabled = dgvMontos.RowCount > 0;
        }

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

        #endregion Eventos

        #region Métodos Privados

        private Dictionary<short, decimal> transacciones = new Dictionary<short, decimal>();
        private List<short> atms_cargados = new List<short>();

        /// <summary>
        /// Leer los montos remanentes del AS400.
        /// </summary>
        private void leerRemanentesAS400()
        {

            try
            {
                _remanentes.Clear();

                DataTable datos = _coordinacion.listarRemanentesATMsCompletos();
                BindingList<MontoRemanenteATM> listita = new BindingList<MontoRemanenteATM>();
                
                DateTime fecha = DateTime.Now;

                foreach (DataRow fila in datos.Rows)
                {
                    MontoRemanenteATM monto = new MontoRemanenteATM();
                   
                    monto.ATM = new CommonObjects.ATM();
                    

                    // Asignar el ATM
                    string idatm = fila["CAJLNO"].ToString();
                    short nuevito;
                    nuevito = short.Parse(idatm);
                    monto.ID = nuevito;

                    //string valor_numero_atm = (string)fila["CAJLNO"];
                    
                    //short numero_atm = short.Parse(valor_numero_atm);


                    // Asignar las fechas actuales y de ultima transaccion
                    decimal decimalito = (decimal)fila["CAJPFA"];
                    decimal decimalitofinal = (decimal) fila["CAJFUT"];
                    monto.Localizacion = (string)fila["CAJLOC"];

                    string nuevafecha = System.Convert.ToString(decimalito);
                    string fechafinal = System.Convert.ToString(decimalitofinal);

                    bool fechaactual = nuevafecha.Equals("0");
                    bool fechafinalb = fechafinal.Equals("0");



                    if (fechaactual != true && fechafinalb != true)
                    {
                        string cambio = nuevafecha.Insert(4, "/");
                        nuevafecha = cambio.Insert(7, "/");

                        cambio = fechafinal.Insert(4, "/");
                        fechafinal = cambio.Insert(7, "/");
                    }
                    else
                    {
                        nuevafecha = "01/01/0001";
                        fechafinal = "01/01/0001";
                    }
                    monto.FechaActual = Convert.ToDateTime(nuevafecha);
                    monto.FechaUltimaTransaccion = Convert.ToDateTime(fechafinal);
                    CommonObjects.ATM atm = new CommonObjects.ATM(numero: nuevito);
                    _mantenimiento.obtenerDatosATM(ref atm);

                    string codigos = (string)fila["CAJCDI"];
                    RegistroRemanentesATM nuevo = new RegistroRemanentesATM(atm: atm, fecha: fecha);
                    this.leerCantidadRemanenteCartucho(codigos[0].ToString(), (decimal)fila["CAJCB1"], nuevo, 1);
                    this.leerCantidadRemanenteCartucho(codigos[1].ToString(), (decimal)fila["CAJCB2"], nuevo, 2);
                    this.leerCantidadRemanenteCartucho(codigos[2].ToString(), (decimal)fila["CAJCB3"], nuevo, 3);
                    this.leerCantidadRemanenteCartucho(codigos[3].ToString(), (decimal)fila["CAJCB4"], nuevo, 4);


                    Denominacion denominaciong1 = new Denominacion(codigo: codigos[0].ToString().ToUpper());
                    Denominacion denominaciong2 = new Denominacion(codigo: codigos[1].ToString().ToUpper());
                    Denominacion denominaciong3 = new Denominacion(codigo: codigos[2].ToString().ToUpper());
                    Denominacion denominaciong4 = new Denominacion(codigo: codigos[3].ToString().ToUpper());


                    // Obtencion de las denominaciones con sus respectivos valores.

                    Denominacion dtotalgaveta1 = _mantenimiento.ObtenerValorDenominacionCodigo(ref denominaciong1);
                    Denominacion dtotalgaveta2 = _mantenimiento.ObtenerValorDenominacionCodigo(ref denominaciong2);
                    Denominacion dtotalgaveta3 = _mantenimiento.ObtenerValorDenominacionCodigo(ref denominaciong3);
                    Denominacion dtotalgaveta4 = _mantenimiento.ObtenerValorDenominacionCodigo(ref denominaciong4);
                  

                    _mantenimiento.verificarDenominacionCodigo(ref denominaciong1);
                    _mantenimiento.verificarDenominacionCodigo(ref denominaciong2);
                    _mantenimiento.verificarDenominacionCodigo(ref denominaciong3);
                    _mantenimiento.verificarDenominacionCodigo(ref denominaciong4);

                    monto.Montog1 = dtotalgaveta1.Valor * (decimal)fila["CAJCB1"];
                    monto.Montog2 = dtotalgaveta2.Valor * (decimal)fila["CAJCB2"];
                    monto.Montog3 = dtotalgaveta3.Valor * (decimal)fila["CAJCB3"];
                    monto.Montog4 = dtotalgaveta4.Valor * (decimal)fila["CAJCB4"];

                    

                    monto.Denominacion1 = Decimal.Floor(dtotalgaveta1.Valor);
                    monto.Denominacion2 = Decimal.Floor(dtotalgaveta2.Valor);
                    monto.Denominacion3 = Decimal.Floor(dtotalgaveta3.Valor);
                    monto.Denominacion4 = Decimal.Floor(dtotalgaveta4.Valor);

                    if (monto.Denominacion1 != 20)
                        monto.MontoTotalColones += monto.Montog1;
                    else
                        monto.MontoTotalDolares += monto.Montog1;
                    if (monto.Denominacion2 != 20)
                        monto.MontoTotalColones += monto.Montog2;
                    else
                        monto.MontoTotalDolares += monto.Montog2;
                    if (monto.Denominacion3 != 20)
                        monto.MontoTotalColones += monto.Montog3;
                    else
                        monto.MontoTotalDolares += monto.Montog3;
                    if (monto.Denominacion4 != 20)
                        monto.MontoTotalColones += monto.Montog4;
                    else
                        monto.MontoTotalDolares += monto.Montog4;


                    //if (denominacion.ID_Valido)
                    //{
                    //    short cantidad_remanente = (short)remanente;
                    //    MontoRemanenteATM monto = new MontoRemanenteATM(denominacion, cantidad_remanente, posicion);

                    //    registro.agregarMonto(monto);
                    //}
                    
                    listita.Add(monto);
                    _remanentes.Add(monto);
                    //CommonObjects.ATM atm = new CommonObjects.ATM(numero: nuevito);

                    //_mantenimiento.obtenerDatosATM(ref atm);

                    //if (atm.ID_Valido)
                    //{
                    //    RegistroRemanentesATM nuevo = new RegistroRemanentesATM(atm: atm, fecha: fecha);

                    //    // Asignar los remanentes de los cartuchos

                    //    string codigos = (string)fila["CAJCDI"];

                    //    this.leerCantidadRemanenteCartucho(codigos[0].ToString(), (decimal)fila["CAJCB1"], nuevo, 1);
                    //    this.leerCantidadRemanenteCartucho(codigos[1].ToString(), (decimal)fila["CAJCB2"], nuevo, 2);
                    //    this.leerCantidadRemanenteCartucho(codigos[2].ToString(), (decimal)fila["CAJCB3"], nuevo, 3);
                    //    this.leerCantidadRemanenteCartucho(codigos[3].ToString(), (decimal)fila["CAJCB4"], nuevo, 4);

                    //    _remanentes.Add(nuevo);
                    //}

                }

                dgvMontos.DataSource = listita;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Leer los montos remanentes por denominación de un ATM.
        /// </summary>
        private void leerCantidadRemanenteCartucho(string codigo, decimal remanente, RegistroRemanentesATM registro, byte posicion)
        {
            Denominacion denominacion = new Denominacion(codigo: codigo.ToUpper());

            _mantenimiento.verificarDenominacionCodigo(ref denominacion);

            if (denominacion.ID_Valido)
            {
                short cantidad_remanente = (short)remanente;
                MontoRemanenteATM monto = new MontoRemanenteATM(denominacion, cantidad_remanente, posicion);

                registro.agregarMonto(monto);
            }


        }

        private void dgvMontos_SelectionChanged_1(object sender, EventArgs e)
        {
            btnGuardar.Enabled = dgvMontos.RowCount > 0;
        }


        /// <summary>
        /// Exportar el reporte.
        /// </summary>
        private void exportar()
        {

            try
            {

                if (dgvMontos.RowCount > 0)
                {
                    DocumentoExcel documento = new DocumentoExcel();
                    //DataTable datos = new DataTable();
                    BindingList<MontoRemanenteATM> listita = dgvMontos.DataSource as BindingList<MontoRemanenteATM>;

                    DataTable datos = ConvertToDataTable(listita);
                    documento.seleccionarHoja(1);

                    int fila = 8;

                    // Dar formato al encabezado del reporte

                    documento.seleccionarCelda("B2");
                    documento.actualizarValorCelda("Registro de ATM´s");
                    documento.formatoCelda(subrayado: true, negrita: true, color_fuente: Color.Red);
                    documento.seleccionarSegundaCelda("F2");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);



                    //documento.seleccionarCelda("B4");
                    //if (checkVIP.Checked)
                    //    documento.actualizarValorCelda("Si es VIP");
                    //else
                    //    documento.actualizarValorCelda("No es VIP");
                    //documento.seleccionarSegundaCelda("F4");
                    //documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    //documento.seleccionarCelda("B5");
                    //documento.actualizarValorCelda("Montos Menores a:");
                    //documento.formatoCelda(negrita: true);
                    //documento.seleccionarSegundaCelda("F5");
                    //documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    //documento.seleccionarCelda("B6");
                    //documento.actualizarValorCelda(cmbMontos.Text);
                    //documento.seleccionarSegundaCelda("F6");
                    //documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    //documento.seleccionarCelda("B7");
                    //documento.actualizarValorCelda("");
                    //documento.seleccionarSegundaCelda("F7");
                    //documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    fila = 9;


                    documento.seleccionarCelda("B2");
                    documento.seleccionarSegundaCelda(fila - 2, 6);
                    documento.formatoTabla(false);

                    // Copiar los valores

                    int filas = dgvMontos.Rows.Count;

                    foreach (DataGridViewColumn columna in dgvMontos.Columns)
                    {
                        int numero_columna = columna.Index + 2;

                        documento.seleccionarCelda(fila, numero_columna);
                        documento.actualizarValorCelda(columna.HeaderText);
                        documento.formatoCelda(subrayado: true, color_fondo: Color.LightGray);
                        documento.seleccionarSegundaCelda(fila + filas, numero_columna);
                        documento.autoajustarTamanoColumnas();
                    }

                    documento.seleccionarCelda(fila + 1, 2);
                    documento.actualizarValoresTabla(datos);

                    documento.seleccionarCelda(fila, 2);
                    documento.seleccionarSegundaCelda(fila + filas, dgvMontos.Columns.Count + 1);
                    documento.formatoTabla(false);

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
        /// Converts Current Generic Collection to a DataTable
        /// </summary>
        /// <returns>DataTable Corresponding to the current collection.</returns>
        public DataTable ConvertToDataTable(BindingList<MontoRemanenteATM> atm)
        {

            DataTable dt = new DataTable();
            //Main Collection Loop
            for (int i = 0; i < atm.Count; i++)
            {

                //Define property object to list Columns by field name
                PropertyDescriptorCollection Classproperties = TypeDescriptor.GetProperties(atm[i]);

                if (i.Equals(0)) //Create Table Header
                {
                    //Create Columns
                    for (int x = 0; x < Classproperties.Count; x++)
                    {
                        DataColumn dtc = new DataColumn();
                        dtc.ColumnName = Classproperties[x].Name;

                        dt.Columns.Add(dtc);

                    }
                }
                DataRow dr = dt.NewRow(); //new datatable row
                //Fill in DataTable
                for (int x = 0; x < Classproperties.Count; x++)
                {
                    Type fieldtype = atm[i].GetType();
                     string fldname = Classproperties[x].Name.ToString();

                     if (fldname == "Monto" || fldname == "Denominacion" || fldname == "Cantidad" || fldname == "Posicion"  || fldname == "CargaEmergencia" || fldname == "DiasInventarioRequerido" || fldname == "Cantidad" || fldname == "DiasInventario" || fldname == "DB_ID" || fldname == "ID_Invalido" || fldname == "ID_Valido"
                         || fldname == "ATM")
                    { 
                    }
                    else
                    {
                        PropertyInfo prtinf = fieldtype.GetProperty(fldname) as PropertyInfo;
                        dr[x] = prtinf.GetValue(atm[i], null);
                        
                    }
                }

                dt.Rows.Add(dr);

            }
            //Return the datatable object
            return dt;
        }

        #endregion Métodos Privados


        private void frmImportaciónRemanentesATMsCompletos_Load(object sender, EventArgs e)
        {

        }

        


    }
}
