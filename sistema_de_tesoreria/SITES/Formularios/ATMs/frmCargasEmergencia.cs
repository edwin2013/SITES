using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using LibreriaMensajes;
using CommonObjects;
using System.Collections;
using LibreriaReportesOffice;

namespace GUILayer
{
    public partial class frmCargasEmergencia : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        public DataRow r;
        private BindingList<MontoRemanenteATM> _remanentes = new BindingList<MontoRemanenteATM>();
        private BindingList<RegistroRemanentesATM> _remanentes2 = new BindingList<RegistroRemanentesATM>();
        private Decimal montomaximo = new Decimal();
        private Boolean vip = false;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private bool _coordinador = false;

        private Colaborador _colaborador = null;

        #endregion Atributos

        #region Constructor

        public frmCargasEmergencia(Colaborador colaborador)
        {
            InitializeComponent();

            try
            {
                cboATM.ListaMostrada = _mantenimiento.listarATMs();
                cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
                _colaborador = colaborador;
                _coordinador = _colaborador.Puestos.Contains(Puestos.Coordinador) || _colaborador.Puestos.Contains(Puestos.Supervisor) || _colaborador.Puestos.Contains(Puestos.Analista);
                if (_coordinador)
                    btnRevisarTablaTotal.Enabled = true;
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
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ValidateMonto())
                {

            try
            {
                //CommonObjects.ATM atm = cboATM.SelectedIndex == 0 ?
                //    null : (CommonObjects.ATM)cboATM.SelectedItem;
                //this.CargarDatosAS400();
                //this.GuardarDatosAS400();
                //this.CargarListaCargas();
                //this.GuardarCargas();

                ATM atm = cboATM.SelectedIndex == 0 ?
                    null : (ATM)cboATM.SelectedItem;
                EmpresaTransporte transportadora = cboTransportadora.SelectedIndex == 0 ?
                    null : (EmpresaTransporte)cboTransportadora.SelectedItem;

                cboMontos.Text = "10.000.000";
               
                DateTime fecha = dtpFecha.Value;
               

                DataTable datos = _coordinacion.listarCargasEmergencia(atm, fecha,transportadora);
                
                BindingList<MontoRemanenteATM> listita = new BindingList<MontoRemanenteATM>();
                Monedas moneda = (Monedas)0;

                BindingList<MontosRetirosATM> retiros = _coordinacion.listarMontosRetirosATMs(moneda); 
                ArrayList a = new ArrayList();

                for (int i = 0; i < datos.Rows.Count; i++)
                {
                   
                    MontoRemanenteATM monto = new MontoRemanenteATM();
                    monto.Denominacion = new Denominacion();

                    r = datos.Rows[i];
                    int id = Convert.ToInt32(r["fk_ID_ATM"]);
                    Decimal total = 0;
                    monto.Localizacion = r["Localizacion"].ToString();
                    monto.ID = Convert.ToInt32(r["fk_ID_ATM"]);
                    monto.FechaActual = Convert.ToDateTime(r["Fecha_Actual"]);
                    monto.FechaUltimaTransaccion = Convert.ToDateTime(r["Fecha_Ultima_Transaccion"]);
                    monto.Denominacion1 = Convert.ToDecimal(r["Den_Gav1"]);
                    monto.Denominacion2 = Convert.ToDecimal(r["Den_Gav2"]);
                    monto.Denominacion3 = Convert.ToDecimal(r["Den_Gav3"]);
                    monto.Denominacion4 = Convert.ToDecimal(r["Den_Gav4"]);
                    monto.Montog1 = Convert.ToDecimal(r["Monto_Gav1"]);
                    monto.Montog2 = Convert.ToDecimal(r["Monto_Gav2"]);
                    monto.Montog3 = Convert.ToDecimal(r["Monto_Gav3"]);
                    monto.Montog4 = Convert.ToDecimal(r["Monto_Gav4"]);
                    
                  //  monto.Denominacion.Valor nos vamos= Convert.ToDecimal(r["Den_Gav2"]);

                    if (monto.Denominacion1 != 20)
                    {
                        total = monto.Montog1;
                    }

                    if (monto.Denominacion2 != 20)
                    {
                        total = total + monto.Montog2;
                    }

                    if (monto.Denominacion3 != 20)
                    {
                        total = total + monto.Montog3;
                    }

                    if (monto.Denominacion4 != 20)
                    {
                        total = total + monto.Montog4;
                    }

                    monto.MontoTotalColones = total;
                    DateTime ahora = new DateTime();
                    ahora = fecha;

                    string annionuevo = "30/12/" + ahora.Year;
                    string batallasantarosa = "10/04/" + ahora.Year;
                    string trabajador = "30/04/" + ahora.Year;
                    string anexion = "24/07/" + ahora.Year;
                    string virgen = "01/08/" + ahora.Year;
                    string diamadre = "14/08/" + ahora.Year;
                    string independencia = "14/09/" + ahora.Year;
                    string diacultura = "11/10/" + ahora.Year;
                    string navidad = "24/12/" + ahora.Year;
                    //                  string finnnio =  "31/12/" + ahora.Year;




                    DateTime sabado2 = Convert.ToDateTime("15/06/2013");

                    if (ahora.DayOfWeek == DayOfWeek.Saturday || ahora.Date == Convert.ToDateTime(annionuevo) ||
                        ahora.Date == Convert.ToDateTime(trabajador) ||
                        ahora.Date == Convert.ToDateTime(anexion) || ahora.Date == Convert.ToDateTime(virgen) || ahora.Date == Convert.ToDateTime(independencia) ||
                        ahora.Date == Convert.ToDateTime(batallasantarosa) || ahora.Date == Convert.ToDateTime(diamadre) ||
                        ahora.Date == Convert.ToDateTime(diacultura) || ahora.Date == Convert.ToDateTime(navidad))
                        monto.DiasInventarioRequerido = 1;
                    else
                        monto.DiasInventarioRequerido = 0;


                    if (DateTime.Now.Hour <= 8)
                        monto.DiasInventarioRequerido = monto.DiasInventarioRequerido + 1;
                    else if (DateTime.Now.Hour <= 11)
                        monto.DiasInventarioRequerido = monto.DiasInventarioRequerido + (Decimal)0.8;
                    else if (DateTime.Now.Hour <= 13)
                        monto.DiasInventarioRequerido = monto.DiasInventarioRequerido + (Decimal)0.6;
                    else if (DateTime.Now.Hour <= 16)
                        monto.DiasInventarioRequerido = monto.DiasInventarioRequerido + (Decimal)0.3;
                    else if (DateTime.Now.Hour <= 19)
                        monto.DiasInventarioRequerido = monto.DiasInventarioRequerido + (Decimal)0.2;


                    Decimal auxiliar = Convert.ToDecimal(r["monto_dia_semana"]);


                    if (auxiliar != 0)
                    {
                        try
                        {
                            
                                if (((monto.MontoTotalColones-Convert.ToDecimal(txtMontoDisminucion.Text)) / Convert.ToDecimal(r["monto_dia_semana"])) < monto.DiasInventarioRequerido)
                                    monto.CargaEmergencia = "Si";
                                else
                                    monto.CargaEmergencia = "No";

                                monto.DiasInventario = (monto.MontoTotalColones-Convert.ToDecimal(txtMontoDisminucion.Text)) / Convert.ToDecimal(r["monto_dia_semana"]);
                            
                        }
                        catch (Excepcion ex2)
                        {
                            ex2.mostrarMensaje();
                        }
                    }
                    else
                    {
                        monto.CargaEmergencia = "Sin Registrar";
                        monto.DiasInventario = 0;
                    }


                    a.Add(monto);
                }

                try
                {
                    _coordinacion.ImportarDatosRegistroCargasEmergencia(a,fecha);

                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }


                

                if (cboMontos.Text == "5.000.000")
                    montomaximo = 5000000;
                if (cboMontos.Text == "10.000.000")
                    montomaximo = 10000000;
                if (cboMontos.Text == "15.000.000")
                    montomaximo = 15000000;
                if(cboMontos.Text == "20.000.000")
                    montomaximo = 20000000;


                if (checkCarga.Checked == true)
                    vip = true;
                else
                    vip = false;
                

                    DataTable resultado = _coordinacion.listarRegistrosCargasEmergencia(atm, fecha, transportadora, montomaximo, vip);
                    dgvRemanentes.DataSource = resultado;
                    dgvRemanentes.AutoResizeColumns();
                    MessageBox.Show("El proceso de cargas  ha finalizado Correctamente");
               
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
                }

        }


        /// <summary>
        /// Valida los campos 
        /// </summary>
        /// <returns>Si los campos estan correctos o no</returns>
        private bool ValidateMonto()
        {
            bool bStatus = true;
            if (cboMontos.Text == "")
            {
                errorProvider1.SetError(cboMontos, "Debe ingresar el Monto ");
                bStatus = false;
            }
            else
                errorProvider1.SetError(cboMontos, "");
            return bStatus;
        }



        /// <summary>
        /// Carga las listas de las cargas de emergencia.
        /// </summary>
        private void CargarListaCargas()
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
                    decimal decimalitofinal = (decimal)fila["CAJFUT"];
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


                   

                    listita.Add(monto);
                    _remanentes.Add(monto);
                    

                }

              
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Guarda las cargas de Emergencia
        /// </summary>

        private void GuardarCargas()
        {
            try
            {
                _coordinacion.importarRegistrosRemanentesATMsCompletos(_remanentes);
                //MessageBox.Show("Insercion exitosa");
              
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



        /// <summary>
        /// Se marca o desmarca la opción de mostrar los ATM's con cargas programadas.
        /// </summary>
        private void chkProgramados_CheckedChanged(object sender, EventArgs e)
        {
           // cboTransportadora.Enabled = chkProgramados.Checked;
        }



        private void CargarDatosAS400()
        {
            try
            {
                _remanentes.Clear();

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

                        _remanentes2.Add(nuevo);
                    }

                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }




        private void GuardarDatosAS400()
        {
            try
            {
                _coordinacion.importarRegistrosRemanentesATMs(_remanentes2);

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Clic en el boton de Revision Total
        /// </summary>
        private void btnRevisarTablaTotal_Click(object sender, EventArgs e)
        {
            if (ValidateMonto())
            {

                try
                {
                    //CommonObjects.ATM atm = cboATM.SelectedIndex == 0 ?
                    //    null : (CommonObjects.ATM)cboATM.SelectedItem;
                    //this.CargarDatosAS400();
                    //this.GuardarDatosAS400();
                    //this.CargarListaCargas();
                    //this.GuardarCargas();

                    ATM atm = cboATM.SelectedIndex == 0 ?
                        null : (ATM)cboATM.SelectedItem;
                    EmpresaTransporte transportadora = cboTransportadora.SelectedIndex == 0 ?
                        null : (EmpresaTransporte)cboTransportadora.SelectedItem;



                    DateTime fecha = dtpFecha.Value;


                    DataTable datos = _coordinacion.listarCargasEmergencia(atm, fecha, transportadora);

                    BindingList<MontoRemanenteATM> listita = new BindingList<MontoRemanenteATM>();
                    Monedas moneda = (Monedas)0;

                    BindingList<MontosRetirosATM> retiros = _coordinacion.listarMontosRetirosATMs(moneda);
                    ArrayList a = new ArrayList();

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {

                        MontoRemanenteATM monto = new MontoRemanenteATM();
                        monto.Denominacion = new Denominacion();

                        r = datos.Rows[i];
                        Decimal total = 0;
                        monto.Localizacion = r["Localizacion"].ToString();
                        monto.ID = Convert.ToInt32(r["fk_ID_ATM"]);
                        monto.FechaActual = Convert.ToDateTime(r["Fecha_Actual"]);
                        monto.FechaUltimaTransaccion = Convert.ToDateTime(r["Fecha_Ultima_Transaccion"]);
                        monto.Denominacion1 = Convert.ToDecimal(r["Den_Gav1"]);
                        monto.Denominacion2 = Convert.ToDecimal(r["Den_Gav2"]);
                        monto.Denominacion3 = Convert.ToDecimal(r["Den_Gav3"]);
                        monto.Denominacion4 = Convert.ToDecimal(r["Den_Gav4"]);
                        monto.Montog1 = Convert.ToDecimal(r["Monto_Gav1"]);
                        monto.Montog2 = Convert.ToDecimal(r["Monto_Gav2"]);
                        monto.Montog3 = Convert.ToDecimal(r["Monto_Gav3"]);
                        monto.Montog4 = Convert.ToDecimal(r["Monto_Gav4"]);

                        //  monto.Denominacion.Valor nos vamos= Convert.ToDecimal(r["Den_Gav2"]);

                        if (monto.Denominacion1 != 20)
                        {
                            total = monto.Montog1;
                        }

                        if (monto.Denominacion2 != 20)
                        {
                            total = total + monto.Montog2;
                        }

                        if (monto.Denominacion3 != 20)
                        {
                            total = total + monto.Montog3;
                        }

                        if (monto.Denominacion4 != 20)
                        {
                            total = total + monto.Montog4;
                        }

                        monto.MontoTotalColones = total;
                        DateTime ahora = new DateTime();
                        ahora = fecha;

                        string annionuevo = "30/12/" + ahora.Year;
                        string batallasantarosa = "10/04/" + ahora.Year;
                        string trabajador = "30/04/" + ahora.Year;
                        string anexion = "24/07/" + ahora.Year;
                        string virgen = "01/08/" + ahora.Year;
                        string diamadre = "14/08/" + ahora.Year;
                        string independencia = "14/09/" + ahora.Year;
                        string diacultura = "11/10/" + ahora.Year;
                        string navidad = "24/12/" + ahora.Year;
                        //                  string finnnio =  "31/12/" + ahora.Year;



                     
                        DateTime sabado2 =  Convert.ToDateTime("15/06/2013");

                        if (ahora.DayOfWeek == DayOfWeek.Saturday || ahora.Date == Convert.ToDateTime(annionuevo) ||
                            ahora.Date == Convert.ToDateTime(trabajador) ||
                            ahora.Date == Convert.ToDateTime(anexion) || ahora.Date == Convert.ToDateTime(virgen) || ahora.Date == Convert.ToDateTime(independencia) ||
                            ahora.Date == Convert.ToDateTime(batallasantarosa) || ahora.Date == Convert.ToDateTime(diamadre) ||
                            ahora.Date == Convert.ToDateTime(diacultura) || ahora.Date == Convert.ToDateTime(navidad))
                            monto.DiasInventarioRequerido = 1;
                        else
                            monto.DiasInventarioRequerido = 0;


                        if (DateTime.Now.Hour <= 8)
                            monto.DiasInventarioRequerido = monto.DiasInventarioRequerido + 1;
                        else if (DateTime.Now.Hour <= 11)
                            monto.DiasInventarioRequerido = monto.DiasInventarioRequerido + (Decimal)0.8;
                        else if (DateTime.Now.Hour <= 13)
                            monto.DiasInventarioRequerido = monto.DiasInventarioRequerido + (Decimal)0.6;
                        else if (DateTime.Now.Hour <= 16)
                            monto.DiasInventarioRequerido = monto.DiasInventarioRequerido + (Decimal)0.3;
                        else if (DateTime.Now.Hour <= 19)
                            monto.DiasInventarioRequerido = monto.DiasInventarioRequerido + (Decimal)0.2;


                        Decimal auxiliar = Convert.ToDecimal(r["monto_dia_semana"]);


                        if (auxiliar != 0)
                        {
                            try
                            {

                                if (((monto.MontoTotalColones-Convert.ToDecimal(txtMontoDisminucion.Text)) / Convert.ToDecimal(r["monto_dia_semana"])) < monto.DiasInventarioRequerido)
                                    monto.CargaEmergencia = "Si";
                                else
                                    monto.CargaEmergencia = "No";

                                monto.DiasInventario = (monto.MontoTotalColones - Convert.ToDecimal(txtMontoDisminucion.Text)) / Convert.ToDecimal(r["monto_dia_semana"]);

                            }
                            catch (Excepcion ex2)
                            {
                                ex2.mostrarMensaje();
                            }
                        }
                        else
                        {
                            monto.CargaEmergencia = "Sin Registrar";
                            monto.DiasInventario = 0;
                        }


                        a.Add(monto);
                    }

                    try
                    {
                        _coordinacion.ImportarDatosRegistroCargasEmergencia(a,fecha);

                    }
                    catch (Excepcion ex)
                    {
                        ex.mostrarMensaje();
                    }




                    if (cboMontos.Text == "5.000.000")
                        montomaximo = 5000000;
                    if (cboMontos.Text == "10.000.000")
                        montomaximo = 10000000;
                    if (cboMontos.Text == "15.000.000")
                        montomaximo = 15000000;
                    if (cboMontos.Text == "20.000.000")
                        montomaximo = 20000000;


                    if (checkCarga.Checked == true)
                        vip = true;
                    else
                        vip = false;


                    DataTable resultado = _coordinacion.listarRegistrosCargasEmergenciaCompleto(atm, fecha, transportadora, montomaximo);
                    dgvRemanentes.DataSource = resultado;
                    dgvRemanentes.AutoResizeColumns();
                    MessageBox.Show("El proceso de cargas  ha finalizado Correctamente");

                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }
            }
        }


        /// <summary>
        /// Valida que solo se digiten numeros
        /// </summary>
        private void txtMontoDisminucion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48 && e.KeyChar != 8 && e.KeyChar != 44) || e.KeyChar > 57)
            {
                MessageBox.Show("Sólo se permiten Números");
                e.Handled = true;
            }
        }

    #endregion Eventos

        private void frmCargasEmergencia_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Clic en el boton de Exportar
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
        /// Exportar el reporte.
        /// </summary>
        private void exportar()
        {

            try
            {

                if (dgvRemanentes.RowCount > 0)
                {
                    DocumentoExcel documento = new DocumentoExcel();
                    DataTable datos = (DataTable)dgvRemanentes.DataSource;
                    documento.seleccionarHoja(1);

                    int fila = 8;

                    // Dar formato al encabezado del reporte

                    documento.seleccionarCelda("B2");
                    documento.actualizarValorCelda("Reporte de Cargas de Emergencia");
                    documento.formatoCelda(subrayado: true, negrita: true, color_fuente: Color.Red);
                    documento.seleccionarSegundaCelda("F2");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    documento.seleccionarCelda("B3");
                    documento.actualizarValorCelda("VIP:");
                    documento.formatoCelda(negrita: true);
                    documento.seleccionarSegundaCelda("F3");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);
                    

                    documento.seleccionarCelda("B4");
                    if (checkCarga.Checked)
                        documento.actualizarValorCelda("Si es VIP");
                    else
                        documento.actualizarValorCelda("No es VIP");
                    documento.seleccionarSegundaCelda("F4");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    documento.seleccionarCelda("B5");
                    documento.actualizarValorCelda("Montos Menores a:");
                    documento.formatoCelda(negrita: true);
                    documento.seleccionarSegundaCelda("F5");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    documento.seleccionarCelda("B6");
                    documento.actualizarValorCelda(cboMontos.Text);
                    documento.seleccionarSegundaCelda("F6");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    documento.seleccionarCelda("B7");
                    documento.actualizarValorCelda("");
                    documento.seleccionarSegundaCelda("F7");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    fila = 9;

                  
                    documento.seleccionarCelda("B2");
                    documento.seleccionarSegundaCelda(fila - 2, 6);
                    documento.formatoTabla(false);

                    // Copiar los valores

                    int filas = dgvRemanentes.Rows.Count;

                    foreach (DataGridViewColumn columna in dgvRemanentes.Columns)
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
                    documento.seleccionarSegundaCelda(fila + filas, dgvRemanentes.Columns.Count + 1);
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

        

       




    }
}
