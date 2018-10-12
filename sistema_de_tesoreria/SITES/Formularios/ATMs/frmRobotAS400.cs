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

namespace GUILayer
{
    public partial class frmRobotAS400 : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        public DataRow r;
        private BindingList<MontoRemanenteATM> _remanentes = new BindingList<MontoRemanenteATM>();
        private BindingList<RegistroRemanentesATM> _remanentes2 = new BindingList<RegistroRemanentesATM>();
        

     

        #endregion Atributos

        #region Constructor
        public frmRobotAS400(Colaborador colaborador)
        {
            InitializeComponent();

           
        }
        #endregion Constructor


        #region Eventos

        /// <summary>
        /// Clic en el boton actualizar
        /// </summary>
       
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.btnActualizar.Enabled = false;
            this.btnSalir.Enabled = false;
            this.btnTerminar.Enabled = true;
            this.InvocarProceso();
        }



        /// <summary>
        /// Clic en el boton de salir
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        /// <summary>
        /// Clic en el botón de Terminar el Proceso
        /// </summary>
        private void btnTerminar_Click(object sender, EventArgs e)
        {
            this.tmrActualizacionRemanentes.Stop();
            MessageBox.Show("Proceso finalizado");
            this.btnActualizar.Enabled = true;
            this.btnSalir.Enabled = true;
            this.btnTerminar.Enabled = false;
        }

        #endregion Eventos



        #region Metodos Privados

        private void InvocarProceso()
        {
            tmrActualizacionRemanentes.Tick += new EventHandler(timer_Tick); // Everytime timer ticks, timer_Tick will be called
            tmrActualizacionRemanentes.Interval = (1000) * (900);             // Timer will tick evert 10 seconds
            tmrActualizacionRemanentes.Enabled = true;                       // Enable the timer
            tmrActualizacionRemanentes.Start();  
        }



        private void InciarProceso()
        {
             
            this.CargarDatosAS400();
            this.GuardarDatosAS400();
            this.CargarListaCargas();
            this.GuardarCargas();
            
           // MessageBox.Show("Proceso Completo");
        }


        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                _remanentes2.Clear();
                this.CargarDatosAS400();
                this.GuardarDatosAS400();
                this.CargarListaCargas();
                this.GuardarCargas();
            }
            catch(Excepcion ex)
            {
                txtEstado.Text += DateTime.Now.ToString() + ": " + ex.Message + '\n';
            }
           // MessageBox.Show("Proceso Completo");                 // Alert the user
        }

        /// <summary>
        /// Cargar los datos de los remanentes del AS400
        /// </summary>
        private void CargarDatosAS400()
        {
            try
            {
                _remanentes.Clear();
                _remanentes2.Clear();
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
                throw ex;
            }
        }


        /// <summary>
        /// Guarda los datos de los remanentes de ATMs cargados del AS400
        /// </summary>
        private void GuardarDatosAS400()
        {
            try
            {
                _coordinacion.importarRegistrosRemanentesATMs(_remanentes2);

            }
            catch (Excepcion ex)
            {
                throw ex;
            }
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
                throw ex;
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
                throw ex;
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
        #endregion Metodos Privados

        private void frmRobotAS400_Load(object sender, EventArgs e)
        {

        }

       

        

       
    }
}
