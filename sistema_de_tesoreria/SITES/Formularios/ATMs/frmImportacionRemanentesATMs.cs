//
//  @ Project : 
//  @ File Name : frmImportacionRemanentesATMs.cs
//  @ Date : 10/01/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

using System.Collections.Generic;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using LibreriaReportesOffice;
using System.Reflection;
using System.Drawing;

namespace GUILayer
{

    public partial class frmImportacionRemanentesATMs : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<RegistroRemanentesATM> _remanentes = new BindingList<RegistroRemanentesATM>();

        #endregion Atributos

        #region Constructor

        public frmImportacionRemanentesATMs()
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
                _coordinacion.importarRegistrosRemanentesATMs(_remanentes);

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

              //  DataTable datos = _coordinacion.listarRemanentesAS400();
                DataTable datos = _coordinacion.listarRemanentesATMsCompletos();
                DateTime fecha = DateTime.Now;
                
                foreach (DataRow fila in datos.Rows)
                {
                    // Asignar el ATM

                    string valor_numero_atm = (string)fila["CAJLNO"];

                    short numero_atm = short.Parse(valor_numero_atm);

                    ATM atm = new ATM(numero: numero_atm);

                    _mantenimiento.obtenerDatosATM(ref atm);

                    if (atm.ID_Valido)
                    {
                        RegistroRemanentesATM nuevo = new RegistroRemanentesATM(atm: atm, fecha: fecha);

                        // Asignar los remanentes de los cartuchos

                        string codigos = (string)fila["CAJCDI"];

                        this.leerCantidadRemanenteCartucho(codigos[0].ToString(), (decimal)fila["CAJCB1"], nuevo, 1);
                        this.leerCantidadRemanenteCartucho(codigos[1].ToString(), (decimal)fila["CAJCB2"], nuevo, 2);
                        this.leerCantidadRemanenteCartucho(codigos[2].ToString(), (decimal)fila["CAJCB3"], nuevo, 3);
                        this.leerCantidadRemanenteCartucho(codigos[3].ToString(), (decimal)fila["CAJCB4"], nuevo, 4);

                        _remanentes.Add(nuevo);
                    }

                }

                dgvMontos.DataSource = _remanentes;
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

        #endregion Métodos Privados

        private void frmImportacionRemanentesATMs_Load(object sender, EventArgs e)
        {

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

                    if (fldname == "Monto" || fldname == "Denominacion" || fldname == "Cantidad" || fldname == "Posicion" || fldname == "MontoTotalColones" || fldname == "CargaEmergencia" || fldname == "DiasInventarioRequerido" || fldname == "Cantidad" || fldname == "DiasInventario" || fldname == "DB_ID" || fldname == "ID_Invalido" || fldname == "DB_Valido"
                        || fldname == "ATM ")
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

    }

}
