//
//  @ Project : 
//  @ File Name : MantenimientoBL.cs
//  @ Date : 28/04/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.ComponentModel;

using CommonObjects;
using DataLayer;
using LibreriaMensajes;
using System.Data;
using CommonObjects.Clases;
using DataLayer.Clases;
using System.Xml;
using CommonObjects.Clases.Reportes;
using System.Windows.Forms;

namespace BussinessLayer
{

    /// <summary>
    /// Clase de la capa de negocios que maneja los mantenimientos.
    /// </summary>
    public class MantenimientoBL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static MantenimientoBL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static MantenimientoBL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new MantenimientoBL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ColaboradoresDL _colaboradores = ColaboradoresDL.Instancia;
        private ClientesDL _clientes = ClientesDL.Instancia;
        private GruposDL _grupos = GruposDL.Instancia;
        private EmpresasTransporteDL _empresas = EmpresasTransporteDL.Instancia;
        private CamarasDL _camaras = CamarasDL.Instancia;
        private TipoCambioDL _tipos_cambio = TipoCambioDL.Instancia;
        private CanalesDL _canales = CanalesDL.Instancia;
        private TiposGestionDL _tipos_gestion = TiposGestionDL.Instancia;
        private CausasGestionDL _causas_gestion = CausasGestionDL.Instancia;
        private PuntosVentaDL _puntos_venta = PuntosVentaDL.Instancia;
        private ATMsDL _atms = ATMsDL.Instancia;
        private SucursalesDL _sucursales = SucursalesDL.Instancia;
        private UbicacionesDL _ubicaciones = UbicacionesDL.Instancia;
        private CiudadesDL _ciudades = CiudadesDL.Instancia;
        private TiposErrorCierreCajeroDL _tipos_error = TiposErrorCierreCajeroDL.Instancia;
        private DenominacionesDL _denominaciones = DenominacionesDL.Instancia;
        private CartuchosDL _cartuchos = CartuchosDL.Instancia;
        private VehiculoDL _vehiculos = VehiculoDL.Instancia;
        private TripulacionDL _tripulaciones = TripulacionDL.Instancia;
        private EsquemasManifiestosDL _esquemas = EsquemasManifiestosDL.Instancia;
        private FallaDL _fallas = FallaDL.Instancia;
        private DetalleFallaDL _detalle_fallas = DetalleFallaDL.Instancia;
        private InconsistenciaPlanillaDL _inconsistencia = InconsistenciaPlanillaDL.Instancia;
        private DispositivoDL _dispositivos = DispositivoDL.Instancia;
        private TipoEquipoDL _tipo_equipos = TipoEquipoDL.Instancia;
        private ManojoDL _manojos = ManojoDL.Instancia;
        private EquipoDL _equipos = EquipoDL.Instancia;
        private ManifiestosCEFDL _manifiesto_cef = ManifiestosCEFDL.Instancia;
        private FormulaDL _formula = FormulaDL.Instancia;
        private FeriadosDL _feriados = FeriadosDL.Instancia;
        private PuntoAtencionDL _punto_atencion = PuntoAtencionDL.Instancia;
        private InconsistenciaFacturacionDL _inconsistencia_facturacion = InconsistenciaFacturacionDL.Instancia;
        private TipoPenalidadDL _tipo_penalidad = TipoPenalidadDL.Instancia;
        private NivelTipoPenalidadDL _nivel_tipo_penalidad = NivelTipoPenalidadDL.Instancia;
        private PenalidadDL _penalidad = PenalidadDL.Instancia;
        private NivelServicioDL _nivel_servicio = NivelServicioDL.Instancia;
        private PromedioDescargaATMDL _promedios = PromedioDescargaATMDL.Instancia;
        private PromedioRemanenteATMDL _remanente = PromedioRemanenteATMDL.Instancia;
        private CantidadMonedasBolsaNiquelDL _cantidad_monedas_niquel = CantidadMonedasBolsaNiquelDL.Instancia;
        private ManifiestoPedidoNiquelDL _manifiesto_niquel = ManifiestoPedidoNiquelDL.Instancia;
        private GarantiaCartuchoDL _garantias = GarantiaCartuchoDL.Instancia;
        private ProveedorCartuchoDL _proveedores = ProveedorCartuchoDL.Instancia;
        private InventarioDL _inventario = InventarioDL.Instancia;
        private EsperaDL _espera = EsperaDL.Instancia;
        private TipoFallaBlindadosDL _tipo_falla = TipoFallaBlindadosDL.Instancia;
        private SaldoLibroBovedaDL _saldos_libros = SaldoLibroBovedaDL.Instancia;
        private SaldoLibroNiquelDL _saldos_niquel = SaldoLibroNiquelDL.Instancia;
        private EstadoCartuchoDL _estados = EstadoCartuchoDL.Instancia;
        private FallaCartuchoDL _fallas_cartuchos = FallaCartuchoDL.Instancia;
        private ProveedorEquipoDL _proveedoresEquipos = ProveedorEquipoDL.Instancia;
        private EquipoTesoreriaDL _equiposTesoreria = EquipoTesoreriaDL.Instancia;
        private FichaTecnicaDL _fichaTecnica = FichaTecnicaDL.Instancia;
        private RequerimientoMantenimientoDL _requerimientos = RequerimientoMantenimientoDL.Instancia;
        private CajaDL _cajas = CajaDL.Instancia;
        private ArqueosDL _arqueos = ArqueosDL.Instancia;
        private CalidadBilletesDL _calidad = CalidadBilletesDL.Instancia;



        //PROA
        private LimiteEfectivoDL _limite_efectivo = LimiteEfectivoDL.Instancia;
        private CajeroNiquel_DL _cajeroniquel = CajeroNiquel_DL.Instancia;
        private EntregaMesaNiquel_DL _entreganiquel = EntregaMesaNiquel_DL.Instancia;
        private ProcesamientoBajoVolumenDL _procesamiento_bajo_volumen = ProcesamientoBajoVolumenDL.Instancia;
        private ProcesamientoAltoVolumen_DL _procesamiento_alto_volumen = ProcesamientoAltoVolumen_DL.Instancia;
        private CierreCajeroPROA_DL _cierrecajero = CierreCajeroPROA_DL.Instancia;
        private InconsistenciasDepositosDL _inconsistencia_deposito = InconsistenciasDepositosDL.Instancia;





        #endregion Atributos

        #region Constructor

        public MantenimientoBL(){}

        #endregion Constructor

        #region Métodos Públicos

        public DataTable ObtenerInformacionCorteAcreditacionIBS(Colaborador col) //Cambio GZH 13092017
        {

            try
            {
                return _procesamiento_bajo_volumen.ObtenerInformacionCorteAcreditacionIBS(col);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #region cargaMasivaProa
        private cargaMasivaProaDL cargaMasiva = cargaMasivaProaDL.Instancia;
        public int getPuntoVentaID(int cliente, string nombre)
        {
            return cargaMasiva.getPuntoVentaID(cliente, nombre);
        }

        public int getClienteID(string nombre)
        {
            return cargaMasiva.getClienteID(nombre);
        }

        public int verificaCamaraID(string camara)
        {
            return cargaMasiva.verificaCamara(camara);
        }

        public void insertManifiestoTemp(DataTable dt)
        {
            throw new NotImplementedException();
        }



        public bool insertarManifiestoInconsistencia(DataGridView dtDepositos, DataGridView dtInconsistencias, Colaborador c)
        {
            try
            {
                DataTable dtInconsist = new DataTable();
                DataTable dtDeposit = (DataTable)(dtDepositos.DataSource);
                dtDeposit.Columns.RemoveAt(31);//tiene errores
                dtDeposit.Columns.RemoveAt(6);//pv
                dtDeposit.Columns.RemoveAt(5);//cliente
                dtDeposit.AcceptChanges();

                DataTable dtCloned = dtDeposit.Clone();
                dtCloned.Columns[1].DataType = typeof(string);
                dtCloned.Columns[3].DataType = typeof(string);
                dtCloned.Columns[4].DataType = typeof(string);
                foreach (DataRow row in dtDeposit.Rows)
                {
                    dtCloned.ImportRow(row);
                }

                dtInconsist = (DataTable)(dtInconsistencias.DataSource);
                dtInconsist.Columns.RemoveAt(15);//tiene error
                dtInconsist.AcceptChanges();

                DataTable dtDptsInsertados = cargaMasiva.insertaCargaMasiva(dtCloned, dtInconsist, c);
                insertaBilleteFalsoYNiquel(dtDptsInsertados, c);
                return true;
            }
            catch
            {
                return false;
            }

        }


        public void insertaBilleteFalsoYNiquel(DataTable dtDptsInsertados, Colaborador c)
        {
            decimal montoFalsos = 0, montoNiquel = 0;
            foreach (DataRow row in dtDptsInsertados.Rows)
            {
                Boolean result = Decimal.TryParse(row["falso"].ToString(), out montoFalsos);
                Boolean niquel = Decimal.TryParse(row["niquel"].ToString(), out montoNiquel);
                if (result && montoFalsos != 0)
                {
                    denominacionBillete((int)montoFalsos, Int32.Parse(row["moneda"].ToString()), Int32.Parse(row["pk_ID"].ToString()));
                }
                if (niquel && montoNiquel != 0)
                {
                    int id = cargaMasiva.insertaNiquel(row["niquel"].ToString());
                    cargaMasiva.insertProcesamientoNiquel(id, row["pk_ID"].ToString(), row["fk_Manifiesto"].ToString(), c, row["numero_deposito"].ToString(), row["niquel"].ToString());
                }
            }
        }

        public void denominacionBillete(decimal monto, int moneda, int id_deposito)//divide un monto en billetes
        {
            int denominacion = 0;
            if (moneda == 0) //si son colones
            {
                while (monto >= 1000)
                {
                    if (monto % 50000 == 0)
                    {
                        denominacion = 50000;
                        monto = monto - 50000;
                    }
                    else if (monto % 20000 == 0)
                    {
                        denominacion = 20000;
                        monto = monto - 20000;
                    }
                    else if (monto % 10000 == 0)
                    {
                        denominacion = 10000;
                        monto = monto - 10000;
                    }
                    else if (monto % 5000 == 0)
                    {
                        denominacion = 5000;
                        monto = monto - 5000;
                    }
                    else if (monto % 2000 == 0)
                    {
                        denominacion = 2000;
                        monto = monto - 2000;
                    }
                    else if (monto % 1000 == 0)
                    {
                        denominacion = 1000;
                        monto = monto - 1000;
                    }
                    cargaMasiva.insertaBillete(denominacion, moneda, id_deposito);
                }
            }
            else if (moneda == 1)//dolares
            {
                while (monto >= 1)
                {
                    if (monto % 100 == 0)
                    {
                        denominacion = 100;
                        monto = monto - 100;
                    }
                    else if (monto % 50 == 0)
                    {
                        denominacion = 50;
                        monto = monto - 50;
                    }
                    else if (monto % 20 == 0)
                    {
                        denominacion = 20;
                        monto = monto - 20;
                    }
                    else if (monto % 10 == 0)
                    {
                        denominacion = 10;
                        monto = monto - 10;
                    }
                    else if (monto % 5 == 0)
                    {
                        denominacion = 5;
                        monto = monto - 5;
                    }
                    else if (monto % 1 == 0)
                    {
                        denominacion = 1;
                        monto = monto - 1;
                    }
                    cargaMasiva.insertaBillete(denominacion, moneda, id_deposito);
                }
            }
        }

        public int existeCamara(string v)
        {
            return cargaMasiva.verificaCamara(v);
        }

        public bool existeCajero(string pk)
        {
            return cargaMasiva.existeCajero(pk);
        }

        #endregion cargaMasivaProa

        #region Inconsistencias
        public void actualizarInconsistencia(InconsistenciaPlanilla p, Colaborador c)
        {

            try
            {
                _inconsistencia.actualizarInconsistencia(p,c);
                //Mensaje.mostrarMensaje("MensajeActualizacionInconsistencias");
            }
            catch (Excepcion ex)
            {
                Excepcion.mostrarMensaje("ErrorActualizacionInconsistencia");
               //throw ex;
            }

        }

        public void actualizarInconsistenciaProcesamiento(InconsistenciaPlanilla p, Colaborador c)
        {

            try
            {
                _inconsistencia.actualizarInconsistenciaProcesamiento(p, c);
                //Mensaje.mostrarMensaje("MensajeActualizacionInconsistencias");
            }
            catch (Excepcion ex)
            {
                Excepcion.mostrarMensaje("ErrorActualizacionInconsistencia");
                //throw ex;
            }

        }

        #region PROA
        public void eliminaInfoFormularioBoletaNiquelEntregaCajeroNiquel(int iD)
        {
            try
            {
                _procesamiento_bajo_volumen.eliminaInfoFormularioBoletaNiquelEntregaCajeroNiquel(iD);
            }
            catch (Excepcion ex)
            {
                throw new Excepcion(ex.Message);
            }
        }
        public void updateMontoMesa(decimal montoNiquel, Colaborador cajero)
        {
            try
            {
                _procesamiento_bajo_volumen.updateMontoMesa(montoNiquel, cajero);
            }
            catch (Excepcion ex)
            {
                throw new Excepcion(ex.Message);
            }
        }

        public DataTable procesamientoBVPendiente(int IdBVM)
        {
            try
            {
                return _procesamiento_bajo_volumen.procesamientoBVPendiente(IdBVM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void UpdateInconsistencias(Deposito _depositoAnterior, Deposito _depositoNuevo, ProcesamientoBajoVolumenManifiesto _manifiesto, Tula tula, byte origenDiferencia, DateTime fprocesobajovolumendeposito, Colaborador col)
        {
            try
            {
                Decimal dif = _depositoNuevo.MontoDiferencia;
                Decimal cont = _depositoNuevo.Monto;


                if (_depositoAnterior.MontoDiferencia == 0)
                {
                    if (dif != 0)
                    {//agregar inconsistencia                       
                        _procesamiento_bajo_volumen.agregarInconsistenciaProcesamientoBajoVolumenDeposito(_manifiesto, tula, _depositoNuevo, _depositoNuevo.Moneda, origenDiferencia, fprocesobajovolumendeposito);
                        _procesamiento_bajo_volumen.updateInconsistenciaInfoProcesamientoBajoVolumenDeposito(_depositoNuevo, 1);
                    }
                }
                else
                {

                    if (dif == 0)
                    {//eliminar inconsistencia
                        _procesamiento_bajo_volumen.DeleteInconsistenciaDepositoProa(_depositoNuevo, col.ID);
                    }
                    else
                    {//actualizar inconsistencia
                        _procesamiento_bajo_volumen.UpdateInconsistenciasDepositoProa(_manifiesto, tula, _depositoNuevo, _depositoNuevo.Moneda, origenDiferencia, fprocesobajovolumendeposito, col);
                    }
                }
                _procesamiento_bajo_volumen.updateInconsistenciaInfoProcesamientoBajoVolumenDeposito(_depositoNuevo, 0);
            }
            catch (Excepcion ex)
            {
                throw new Excepcion(ex.Message);
            }

        }


        public void actualizarDeposito(Deposito _depositoNuevo, Colaborador _coordinador)
        {
            try
            {
                _procesamiento_bajo_volumen.actualizarDeposito(_depositoNuevo, _coordinador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void updateProaInconsistenciasManifiesto(ProcesamientoBajoVolumenManifiesto _manifiesto, Colaborador col)
        {
            try
            {
                DataTable dt = _procesamiento_bajo_volumen.SelectProaMontosDepositos(_manifiesto.ID); //obtener la suma de los montos de todos los depositos del manifiesto
                Boolean existeInconsistencia = _procesamiento_bajo_volumen.VerificaInconsistencia(_manifiesto.ID);
                Monedas moneda = determinaMoneda(_manifiesto);
                if (moneda == Monedas.Colones)
                {
                    _manifiesto.Monto_Diferencia_Colones = _manifiesto.Monto_Colones - Convert.ToDecimal(dt.Rows[0]["contado"]);
                    _manifiesto.Monto_Contado_Colones = Convert.ToDecimal(dt.Rows[0]["contado"]);
                }
                else if (moneda == Monedas.Dolares)
                {
                    _manifiesto.Monto_Diferencia_Dolares = _manifiesto.Monto_Dolares - Convert.ToDecimal(dt.Rows[0]["contado"]);
                    _manifiesto.Monto_Contado_Dolares = Convert.ToDecimal(dt.Rows[0]["contado"]);
                }
                else if (moneda == Monedas.Euros)
                {
                    _manifiesto.Monto_Diferencia_Euros = _manifiesto.Monto_Euros - Convert.ToDecimal(dt.Rows[0]["contado"]);
                    _manifiesto.Monto_Contado_Euros = Convert.ToDecimal(dt.Rows[0]["contado"]);
                }

                if (existeInconsistencia)//si había inconsistencia
                {   //eliminarla
                    if (Convert.ToDecimal(dt.Rows[0]["contado"]) == _manifiesto.Monto_Colones)
                    {
                        _procesamiento_bajo_volumen.EliminaInconsistenciaBajoVolumenManifiesto(ref _manifiesto);
                    }
                    else
                    {//actualizarla

                        _procesamiento_bajo_volumen.ActualizaInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref col, "", moneda);
                    }

                }
                else
                {// si se generó inconsistencia, insertarla nueva inc
                    if (Convert.ToDecimal(dt.Rows[0]["contado"]) != _manifiesto.Monto_Colones)
                    {
                        _procesamiento_bajo_volumen.agregarProaInconsistenciaManifiesto(_manifiesto, col, moneda, "");
                    }
                }

            }
            catch (Excepcion ex)
            {
                throw new Exception(ex.Message);
            }


        }

        private Monedas determinaMoneda(ProcesamientoBajoVolumenManifiesto _manifiesto)
        {
            if (_manifiesto.Monto_Colones != 0)
            {
                return Monedas.Colones;
            }
            else if (_manifiesto.Monto_Dolares != 0)
            {
                return Monedas.Dolares;
            }
            else
            {
                return Monedas.Euros;
            }
        }

        public void updateDepositoMonto(int idCoordinador, ConteoBillete anterior, ConteoBillete nuevo)
        {
            _entreganiquel.insertBitacoraConteoBillete(idCoordinador, anterior);
            _entreganiquel.updateDepositoMontos(idCoordinador, nuevo);
            // updateProcesamientoBajoVolumen(anterior, nuevo);
        }

        public void updateProcesamientoBajoVolumen(ConteoBillete anterior, ConteoBillete nuevo)
        {
            try
            {
                Decimal sumAltoVolAnt = anterior.CRC50000 + anterior.CRC20000 + anterior.CRC10000 + anterior.CRC5000;
                Decimal sumBajoVolAnt = anterior.CRC1000 + anterior.CRC2000;
                Decimal sumAltoVol = nuevo.CRC50000 + nuevo.CRC20000 + nuevo.CRC10000 + nuevo.CRC5000; ;
                Decimal sumBajoVol = nuevo.CRC1000 + nuevo.CRC2000;
                Decimal euroAnt = anterior.EUR5 + anterior.EUR10 + anterior.EUR20 + anterior.EUR50 + anterior.EUR100 + anterior.EUR200 + anterior.EUR500;
                Decimal euroNuevo = nuevo.EUR5 + nuevo.EUR10 + nuevo.EUR20 + nuevo.EUR50 + nuevo.EUR100 + nuevo.EUR200 + nuevo.EUR500;
                Decimal dolarAnt = anterior.USD1 + anterior.USD5 + anterior.USD10 + anterior.USD20 + anterior.USD50 + anterior.USD100;
                Decimal dolarNuevo = nuevo.USD1 + nuevo.USD5 + nuevo.USD10 + nuevo.USD20 + nuevo.USD50 + nuevo.USD100;
                _entreganiquel.updateProcesamientoBajoVolumen(sumAltoVolAnt - sumAltoVol, sumBajoVolAnt - sumBajoVol, euroAnt - euroNuevo, dolarAnt - dolarNuevo, anterior.id_PBV);
            }
            catch (Excepcion ex)
            {
                throw new Excepcion(ex.Message);
            }
        }

        public bool puedeModificarManifiesto(int idManifiesto)
        {
            try
            {
                return _procesamiento_bajo_volumen.puedeModificarManifiesto(idManifiesto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable obtieneExcelRecapBPS(int id, int moneda, DateTime fecha)
        {
            return _entreganiquel.obtieneExcelRecapBPS(id, moneda, fecha);
        }
        public DataTable ObtenerPROAInconsistenciaporResolver(int idcliente, byte estado)
        {

            try
            {
                return _inconsistencia_deposito.listarInconsistenciasPROA(idcliente, estado);
                //Mensaje.mostrarMensaje("MensajeActualizacionInconsistencias");
            }
            catch (Excepcion ex)
            {
                Excepcion.mostrarMensaje("ErrorActualizacionInconsistencia");
                return null;
                //throw ex;
            }

        }

        public InconsistenciaDepositoBajoVolumen ObtenerDetallePROAInconsistenciaporResolver(int idincons)
        {

            try
            {
                return _inconsistencia_deposito.listarDetalleInconsistenciasPROA(idincons);
                //Mensaje.mostrarMensaje("MensajeActualizacionInconsistencias");
            }
            catch (Excepcion ex)
            {
                Excepcion.mostrarMensaje("ErrorActualizacionInconsistencia");
                return null;
                //throw ex;
            }

        }

        public void ResolverPROAInconsistencia(ref InconsistenciaDepositoBajoVolumen c, ref Colaborador d)
        {

            try
            {
                _inconsistencia_deposito.actualizarInfoInconsistenciaDeposito(ref c, ref d);
                //Mensaje.mostrarMensaje("MensajeActualizacionInconsistencias");
            }
            catch (Excepcion ex)
            {
                Excepcion.mostrarMensaje("ResolverPROAInconsistencia");
                //throw ex;
            }

        }

        #endregion PROA

        #endregion Inconsistencias

        #region Clientes

        /// <summary>
        /// Registrar un nuevo cliente en el sistema.
        /// </summary>
        /// <param name="c">Objeto Cliente con los datos del nuevo cliente</param>
        public void agregarCliente(ref Cliente c)
        {

            try
            {

                if (_clientes.verificarCliente(ref c))
                    throw new Excepcion("ErrorClienteDuplicado");

                _clientes.agregarCliente(ref c);

                // Agregar los teléfonos, correos, nombres jurídicos y sucursales del cliente

                foreach (NombreJuridico nombre in c.Nombres_juridicos)
                {
                    NombreJuridico copia_nombre = nombre;

                    _clientes.agregarNombreJuridicoCliente(ref copia_nombre, c);

                    foreach (Cuenta cuenta in copia_nombre.Cuentas)
                    {
                        Cuenta copia_cuenta = cuenta;

                        _clientes.agregarCuentaNombreJuridicoCliente(ref copia_cuenta, copia_nombre);
                    }

                }

                foreach (Telefono telefono in c.Telefonos)
                {
                    Telefono copia = telefono;

                    _clientes.agregarTelefonoCliente(ref copia, c);
                }

                foreach (Correo correo in c.Correos)
                {
                    Correo copia = correo;

                    _clientes.agregarCorreoCliente(ref copia, c);
                }

                foreach (PuntoVenta punto_venta in c.Puntos_venta)
                {
                    PuntoVenta copia = punto_venta;

                    copia.Cliente = c;
                    _puntos_venta.agregarPuntoVenta(ref copia);

                    
                }


                

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Agrega una tarifa de una transportadora
        /// </summary>
        /// <param name="p">Objeto PuntoVenta con los datos a ingresar</param>
        public void agregarTarifaTransportadora(ref PuntoVenta p)
        {
            try
            {
                foreach (TarifaPuntoVentaTransportadora tarifa in p.Tarifas)
                {
                    
                        TarifaPuntoVentaTransportadora copia = tarifa;
                        copia.Cliente = p.Cliente;

                        _puntos_venta.agregarTarifaTransportadora(ref copia);
                    
                }
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
            
        }


        /// <summary>
        /// Agrega una tarifa de una transportadora
        /// </summary>
        /// <param name="p">Objeto PuntoVenta con los datos a ingresar</param>
        public void agregarTarifaTransportadoraImportacion(ref TarifaPuntoVentaTransportadora p)
        {
            try
            {
               

                    _puntos_venta.agregarTarifaTransportadora(ref p);

            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Actualizar una tarifa de una transportadora
        /// </summary>
        /// <param name="p">Objeto PuntoVenta con los datos a ingresar</param>
        public void actualizarTarifaTransportadoraImportacion(ref TarifaPuntoVentaTransportadora p)
        {
            try
            {

                _puntos_venta.actualizarTarifaTransportadora(p);

            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Agrega una tarifa de una transportadora
        /// </summary>
        /// <param name="p">Objeto PuntoVenta con los datos a ingresar</param>
        public void agregarCuentaPuntoVentaImportacion(ref Cuenta p)
        {
            try
            {


                _puntos_venta.agregarCuentaPuntoVenta(ref p);

            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Actualizar una tarifa de una transportadora
        /// </summary>
        /// <param name="p">Objeto PuntoVenta con los datos a ingresar</param>
        public void actualizarCuentaPuntoVentaImportacion(ref Cuenta p)
        {
            try
            {

                _puntos_venta.actualizarCuentaPuntoVenta(ref p);

            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Actualizar los datos de un cliente en el sistema.
        /// </summary>
        /// <param name="c">Objeto Cliente con los datos del cliente</param>
        public void actualizarCliente(Cliente c)
        {

            try
            {

                if (_clientes.verificarCliente(ref c))
                    throw new Excepcion("ErrorClienteDuplicado");

                _clientes.actualizarCliente(c);

                // Desligar los nombres jurídicos anteriores del cliente y registrar los nuevos

                Cliente anterior = new Cliente(c.Id);
                
                _clientes.obtenerNombresJuridicosCliente(ref anterior);

                foreach (NombreJuridico nombre in c.Nombres_juridicos)
                {

                    if (anterior.Nombres_juridicos.Contains(nombre))
                    {
                        anterior.quitarNombreJuridico(nombre);
                    }
                    else
                    {
                        NombreJuridico copia_nombre = nombre;

                        _clientes.agregarNombreJuridicoCliente(ref copia_nombre, c);
                    }

                    // Desligar las cuentas anteriores del nombre jurídico y registrar las nuevas

                    NombreJuridico nombre_anterior = new NombreJuridico(id: nombre.Id);

                    _clientes.obtenerCuentasNombreJuridicoCliente(ref nombre_anterior);

                    foreach (Cuenta cuenta in nombre.Cuentas)
                    {

                        if (nombre_anterior.Cuentas.Contains(cuenta))
                        {
                            nombre_anterior.quitarCuenta(cuenta);
                        }
                        else
                        {
                            Cuenta copia_cuenta = cuenta;

                            _clientes.agregarCuentaNombreJuridicoCliente(ref copia_cuenta, nombre);
                        }

                    }

                    foreach (Cuenta cuenta in nombre_anterior.Cuentas)
                        _clientes.eliminarCuentaNombreJuridicoCliente(cuenta);

                }

                foreach (NombreJuridico nombre in anterior.Nombres_juridicos)
                    _clientes.eliminarNombreJuridicoCliente(nombre);

                // Desligar las susursales anteriores del cliente y registrar las nuevas

                _puntos_venta.obtenerPuntosVentaCliente(ref anterior);

                foreach (PuntoVenta punto_venta in c.Puntos_venta)
                {
                    PuntoVenta copia = punto_venta;

                    copia.Cliente = c;

                    if (anterior.Puntos_venta.Contains(punto_venta))
                        anterior.quitarPuntoVenta(punto_venta);
                    else
                        _puntos_venta.agregarPuntoVenta(ref copia);



                    _puntos_venta.actualizarPuntoVenta(punto_venta);
                }

                foreach (PuntoVenta punto_venta in anterior.Puntos_venta)
                {
                    _puntos_venta.eliminarPuntoVenta(punto_venta);
                    
                }
                
                _puntos_venta.obtenerTarifaTransportadoraCliente(ref anterior);
                
                foreach (TarifaPuntoVentaTransportadora tarifa in c.Tarifas_Transportadoras)  //Tarifas_Transportadoras)
                {
                    TarifaPuntoVentaTransportadora copia = tarifa;

                    copia.Cliente = c;

                    if (anterior.Tarifas_Transportadoras.Contains(tarifa))
                        anterior.quitarTarifaTransportadora(tarifa);
                    else
                        _puntos_venta.agregarTarifaTransportadora(ref copia);

                }

              
                foreach (PuntoVenta punto_venta in c.puntos_cuentas)
                {
                    PuntoVenta copia = new PuntoVenta(id: punto_venta.Id);
                    PuntoVenta copia2 = punto_venta;


                    _puntos_venta.obtenerCuentasPuntoVenta(ref copia);

                    foreach (Cuenta tarifa in copia2.Cuentas)
                    {
                        Cuenta copia_taria = tarifa;

                        if (copia.Cuentas.Contains(copia_taria))
                            copia.quitarCuenta(tarifa);
                        else
                            _puntos_venta.agregarCuentaPuntoVenta(ref copia_taria);

                    }

                    foreach (Cuenta tar in copia.Cuentas)
                        _puntos_venta.quitarCuentaPuntoVenta(tar);
                    
                }

                foreach (PuntoVenta punto_venta in c.puntos_cuentas)
                {
                    PuntoVenta copia = new PuntoVenta(id: punto_venta.Id);
                    PuntoVenta copia2 = punto_venta;


                    _puntos_venta.obtenerDenominacionPuntoVenta(ref copia);

                    foreach (Denominacion tarifa in copia2.DenominacionEnsobrado)
                    {
                        Denominacion copia_taria = tarifa;

                        if (copia.DenominacionEnsobrado.Contains(copia_taria))
                            copia.quitarDenominacionPaqueteEnsobrado(tarifa);
                        else
                            _puntos_venta.agregarPaquetes(ref copia2, copia_taria, 1);

                    }

                    foreach (Denominacion tar in copia.DenominacionEnsobrado)
                        _puntos_venta.eliminarDenominacionPuntoVenta(ref copia2, tar, 1);



                    // Para los paquete chorreados
                    foreach (Denominacion tarifa in copia2.DenominacionChorreado)
                    {
                        Denominacion copia_taria = tarifa;

                        if (copia.DenominacionChorreado.Contains(copia_taria))
                            copia.quitarDenominacionPaqueteChorreado(tarifa);
                        else
                            _puntos_venta.agregarPaquetes(ref copia2, copia_taria, 2);

                    }


                    foreach (Denominacion tar in copia.DenominacionChorreado)
                        _puntos_venta.eliminarDenominacionPuntoVenta(ref copia2, tar, 2);


                }
                





                // Desligar los telefonos anteriores del cliente y registrar los nuevos

                _clientes.obtenerTelefonosCliente(ref anterior);

                foreach (Telefono telefono in c.Telefonos)
                {

                    if (anterior.Telefonos.Contains(telefono))
                    {
                        anterior.quitarTelefono(telefono);
                    }
                    else
                    {
                        Telefono copia = telefono;

                        _clientes.agregarTelefonoCliente(ref copia, c);
                    }

                }

                foreach (Telefono telefono in anterior.Telefonos)
                    _clientes.eliminarTelefonoCliente(telefono);

                // Desligar los correor anteriores del cliente y registrar los nuevos

                _clientes.obtenerCorreosCliente(ref anterior);

                foreach (Correo correo in c.Correos)
                {

                    if (anterior.Correos.Contains(correo))
                    {
                        anterior.quitarCorreo(correo);
                    }
                    else
                    {
                        Correo copia = correo;

                        _clientes.agregarCorreoCliente(ref copia, c);
                    }

                }

                foreach (Correo correo in anterior.Correos)
                    _clientes.eliminarCorreoCliente(correo);

                foreach (TarifaPuntoVentaTransportadora tar in anterior.Tarifas_Transportadoras)
                    _puntos_venta.eliminarTarifaTransportadora(tar);

            }
            catch (Exception ex)
            {
                throw ex;
            }


            foreach (Comision com in c.Comisiones)
                _clientes.actualizarPuntoVentacomision(com);

        }

        /// <summary>
        /// Marcar como inactivo a un cliente del sistema.
        /// </summary>
        /// <param name="c">Objeto Cliente con los datos del cliente a marcar</param>
        public void eliminarCliente(Cliente c)
        {

            try
            {
                _clientes.eliminarCliente(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar a los clientes del sistema.
        /// </summary>
        /// <param name="n">Parte del nombre de los clientes a listar</param>
        /// <returns>Lista de los cliente registrados en el sistema</returns>
        public BindingList<Cliente> listarClientes(string n)
        {

            try
            {
                BindingList<Cliente> clientes = _clientes.listarClientes(n);

                foreach (Cliente cliente in clientes)
                {
                    Cliente copia_cliente = cliente;

                    _clientes.obtenerNombresJuridicosCliente(ref copia_cliente);

                    foreach (NombreJuridico nombre in copia_cliente.Nombres_juridicos)
                    {
                        NombreJuridico copia_nombre = nombre;

                        _clientes.obtenerCuentasNombreJuridicoCliente(ref copia_nombre);
                    }

                    _puntos_venta.obtenerPuntosVentaCliente(ref copia_cliente);
                    _clientes.obtenerTelefonosCliente(ref copia_cliente);
                    _clientes.obtenerCorreosCliente(ref copia_cliente);

                    foreach (PuntoVenta p in copia_cliente.Puntos_venta)
                    {
                        PuntoVenta copia_punto = p;
                        _puntos_venta.obtenerTarifaTransportadoraPuntoVenta(ref copia_punto);
                        _puntos_venta.obtenerCuentasPuntoVenta(ref copia_punto);
                        _puntos_venta.obtenerDenominacionPuntoVenta(ref copia_punto);
                    }
                }

                return clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Obtener los puntos de venta de un cliente.
        /// </summary>
        /// <param name="c">Cliente para el cual se obtiene la lista de puntos de venta</param>
        public void obtenerPuntosVentaCliente(ref Cliente c)
        {

            try
            {
                _puntos_venta.obtenerPuntosVentaCliente(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Agregar un punto de venta para un cliente.
        /// </summary>
        /// <param name="p">Punto de venta que se agregará</param>
        public void agregarPuntoVenta(ref PuntoVenta p)
        {

            try
            {
                _puntos_venta.agregarPuntoVenta(ref p);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un punto de venta.
        /// </summary>
        /// <param name="s">Objeto PuntoVenta con los datos del punto de venta</param>
        public void actualizarPuntoVenta(PuntoVenta p)
        {

            try
            {
                _puntos_venta.actualizarPuntoVenta(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Valida si la tarifa ya existe
        /// </summary>
        /// <param name="t">TarifaPuntoVentaTransportadora con los datos de la tarifa a validar</param>
        /// <returns>Si la tarifa existe o no</returns>
        public bool validarTarifaTransportadora(ref TarifaPuntoVentaTransportadora t)
        {
            return _puntos_venta.verificarTarifaTransportadora(ref t);

        }



        /// <summary>
        /// Valida si la cuenta del punto de venta existe
        /// </summary>
        /// <param name="t">TarifaPuntoVentaTransportadora con los datos de la tarifa a validar</param>
        /// <returns>Si la tarifa existe o no</returns>
        public bool validarCuentaPuntoVenta(ref Cuenta t)
        {
            return _puntos_venta.verificarCuentaPuntoVenta(ref t);

        }

        #endregion Clientes

        #region Punto Venta

        /// <summary>
        /// Obtiene los datos de un punto de venta específico
        /// </summary>
        /// <param name="p">Objeto PuntoVenta con los datos del punto de venta</param>
        public void obtenerDatosPuntoVenta(ref PuntoVenta p)
        {
            _puntos_venta.obtenerDatosPuntoVenta(ref p);
        }

        #endregion Punto Venta

        #region Ciudades

        /// <summary>
        /// Registrar un nueva ciudad en el sistema.
        /// </summary>
        /// <param name="c">Objeto Ciudad con los datos de la nueva ciudad</param>
        public void agregarCiudad(ref Ciudad c)
        {

            try
            {
                _ciudades.agregarCiudad(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todos las ciudades registradas en el sistema.
        /// </summary>
        /// <returns>Lista de ciudades registradas en el sistema</returns>
        public BindingList<Ciudad> listarCiudades()
        {

            try
            {
                return _ciudades.listarCiudades();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Ciudades

        #region Grupos

        /// <summary>
        /// Registrar un nuevo grupo de cajas.
        /// </summary>
        /// <param name="g">Objeto Grupo con los datos del nuevo grupo</param>
        public void agregarGrupo(ref Grupo g)
        {

            try
            {
                _grupos.agregarGrupo(ref g);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un grupo de cajas.
        /// </summary>
        /// <param name="g">Objeto Grupo con los datos del grupo a actualizar</param>
        public void actualizarGrupo(Grupo g)
        {

            try
            {
                _grupos.actualizarGrupo(g);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un grupo.
        /// </summary>
        /// <param name="e">Objeto Grupo con los datos del grupo a eliminar</param>
        public void eliminarGrupo(Grupo g)
        {

            try
            {
                _grupos.eliminarGrupo(g);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todos los grupos de cajas registrados.
        /// </summary>
        /// <returns>Lista de grupos de cajas registrados en el sistema</returns>
        public BindingList<Grupo> listarGrupos()
        {

            try
            {
                return _grupos.listarGrupos();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Grupos

        #region Empresas de Trasporte

        /// <summary>
        /// Registrar una nueva empresa de transporte.
        /// </summary>
        /// <param name="e">Objeto EmpresaTransporte con los datos de la nueva empresa</param>
        public void agregarEmpresaTransporte(ref EmpresaTransporte e)
        {
 
            try
            {
                _empresas.agregarEmpresaTransporte(ref e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de una empresa de transporte.
        /// </summary>
        /// <param name="e">Objeto EmpresaTransporte con los datos de la empresa a actualizar</param>
        public void actualizarEmpresaTransporte(EmpresaTransporte e)
        {

            try
            {
                _empresas.actualizarEmpresaTransporte(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una empresa de transporte.
        /// </summary>
        /// <param name="e">Objeto EmpresaTransporte con los datos de la empresa a eliminar</param>
        public void eliminarEmpresaTransporte(EmpresaTransporte e)
        {

            try
            {
                _empresas.eliminarEmpresaTransporte(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todos los encargados registrados.
        /// </summary>
        /// <param name="n">Parte del nombre del encargado para el cual se genera la lista</param>
        /// <returns>Lista de encargados registrados en el sistema</returns>
        public BindingList<EmpresaTransporte> listarEmpresasTransporte()
        {

            try
            {
                return _empresas.listarEmpresasTransporte();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Listar las empresas transporte de los módulos de bancos. 
        /// </summary>
        /// <returns></returns>
        public BindingList<EmpresaTransporte> listarEmpresasTransporteBanco()
        {

            try
            {
                return _empresas.listarEmpresasTransporteBanco();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los datos de una Empresa de Transporte
        /// </summary>
        /// <param name="e">Empresa para el cual se obtienen los datos</param>
        /// <returns>Valor que indica si el ATM existe</returns>
        public EmpresaTransporte obtenerDatosEmpresa(ref EmpresaTransporte e)
        {

            try
            {
                return _empresas.obtenerDatosEmpresa(ref e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Empresas de Trasporte

        #region Camaras

        /// <summary>
        /// Registrar una nueva cámara.
        /// </summary>
        /// <param name="c">Objeto Camara con los datos de la nueva cámara</param>
        public void agregarCamara(ref Camara c)
        {

            try
            {
                _camaras.agregarCamara(ref c); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de una cámara.
        /// </summary>
        /// <param name="c">Objeto Camara con los datos de la cámara a actualizar</param>
        public void actualizarCamara(Camara c)
        {

            try
            {
                _camaras.actualizarCamara(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una cámara.
        /// </summary>
        /// <param name="c">Objeto Camara con los datos de la cámara a eliminar</param>
        public void eliminarCamara(Camara c)
        {

            try
            {
                _camaras.eliminarCamara(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todas las cámaras registradas.
        /// </summary>
        /// <returns>Lista de cámaras registradas en el sistema</returns>
        public BindingList<Camara> listarCamaras()
        {

            try
            {
                return _camaras.listarCamaras();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todas las cámaras registradas en una área específica.
        /// </summary>
        /// <param name="a">Área para la cual se genera la lista</param>
        /// <returns>Lista de cámaras registradas en el sistema que pertenecen al área especificada</returns>
        public BindingList<Camara> listarCamarasPorArea(Areas a)
        {

            try
            {
                return _camaras.listarCamarasPorArea(a);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Camaras

        #region Tipos de Cambio

        /// <summary>
        /// Registrar un tipo de cambio.
        /// </summary>
        /// <param name="u">Objeto TipoCambio con los datos del tipo de cambio</param>
        public void agregarTipoCambio(ref TipoCambio t)
        {

            try
            {

                if (_tipos_cambio.verificarTipoCambio(t))
                    throw new Excepcion("ErrorTipoCambioDuplicado");

                _tipos_cambio.agregarTipoCambio(ref t);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos del tipo de cambio de una fecha determinada.
        /// </summary>
        /// <param name="u">Objeto TipoCambio con los datos del tipo de cambio</param>
        public void actualizarTipoCambio(TipoCambio t)
        {

            try
            {
                _tipos_cambio.actualizarTipoCambio(t);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener el tipo de cambio de una fecha específica.
        /// </summary>
        /// <param name="f">Fecha para la cual se obtendrá el tipo de cambio</param>
        /// <returns>Objeto TipoCambio con los datos del tipo de cambio de la fecha especificada</returns>
        public TipoCambio obtenerTipoCambio(DateTime f)
        {

            try
            {
                return _tipos_cambio.obtenerTipoCambio(f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Tipos de Cambio

        #region Canales

        /// <summary>
        /// Registrar un nuevo canal.
        /// </summary>
        /// <param name="c">Objeto Canal con los datos del nuevo canal</param>
        public void agregarCanal(ref Canal c)
        {

            try
            {
                _canales.agregarCanal(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un canal.
        /// </summary>
        /// <param name="c">Objeto Canal con los datos del canal a actualizar</param>
        public void actualizarCanal(Canal c)
        {

            try
            {
                _canales.actualizarCanal(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un canal.
        /// </summary>
        /// <param name="c">Objeto Canal con los datos del canal a eliminar</param>
        public void eliminarCanal(Canal c)
        {

            try
            {
                _canales.eliminarCanal(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todos los canales registrados.
        /// </summary>
        /// <returns>Lista de canales registrados en el sistema</returns>
        public BindingList<Canal> listarCanales()
        {

            try
            {
                return _canales.listarCanales();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Canales

        #region Tipos de Gestión

        /// <summary>
        /// Registrar un nuevo tipo de gestión.
        /// </summary>
        /// <param name="t">Objeto TipoGestion con los datos del nuevo tipo de gestión</param>
        public void agregarTipoGestion(ref TipoGestion t)
        {

            try
            {
                _tipos_gestion.agregarTipoGestion(ref t);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un tipo de gestión.
        /// </summary>
        /// <param name="t">Objeto TipoGestion con los datos del tipo de gestión a actualizar</param>
        public void actualizarTipoGestion(TipoGestion t)
        {

            try
            {
                _tipos_gestion.actualizarTipoGestion(t);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un tipo de gestión.
        /// </summary>
        /// <param name="t">Objeto TipoGestion con los datos del tipo de gestión a eliminar</param>
        public void eliminarTipoGestion(TipoGestion t)
        {

            try
            {
                _tipos_gestion.eliminarTipoGestion(t);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todos los tipos de gestión registrados.
        /// </summary>
        /// <returns>Lista de los tipos de gestión registrados en el sistema</returns>
        public BindingList<TipoGestion> listarTiposGestion()
        {

            try
            {
                return _tipos_gestion.listarTiposGestion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Tipos de Gestión

        #region Causas de Gestión

        /// <summary>
        /// Registrar una nueva causa para las gestiones.
        /// </summary>
        /// <param name="c">Objeto CausaGestion con los datos de la nueva causa</param>
        public void agregarCausaGestion(ref CausaGestion c)
        {

            try
            {
                _causas_gestion.agregarCausaGestion(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de una causa de gestiones.
        /// </summary>
        /// <param name="c">Objeto CausaGestion con los datos de la causa a actualizar</param>
        public void actualizarCausaGestion(CausaGestion c)
        {

            try
            {
                _causas_gestion.actualizarCausaGestion(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una causa de gestiones.
        /// </summary>
        /// <param name="c">Objeto CausaGestion con los datos de la causa a eliminar</param>
        public void eliminarCausaGestion(CausaGestion c)
        {

            try
            {
                _causas_gestion.eliminarCausaGestion(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todas las causas de gestiones.
        /// </summary>
        /// <returns>Lista de causas de gestiones registradas en el sistema</returns>
        public BindingList<CausaGestion> listarCausasGestion()
        {

            try
            {
                return _causas_gestion.listarCausasGestion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Causas de Gestión

        #region Tipos de Errores de Cierres de Cajeros

        /// <summary>
        /// Registrar un nuevo tipo de error para los cierres.
        /// </summary>
        /// <param name="t">Objeto TipoErrorCierre con los datos del nuevo tipo de error</param>
        public void agregarTipoError(ref TipoErrorCierre t)
        {

            try
            {
                _tipos_error.agregarTipoError(ref t);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un tipo de error para los cierres.
        /// </summary>
        /// <param name="t">Objeto TipoErrorCierre con los datos del tipo de error a actualizar</param>
        public void actualizarTipoError(TipoErrorCierre t)
        {

            try
            {
                _tipos_error.actualizarTipoError(t);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un tipo de error para los cierres.
        /// </summary>
        /// <param name="t">Objeto TipoErrorCierre con los datos del tipo de error a eliminar</param>
        public void eliminarTipoError(TipoErrorCierre t)
        {

            try
            {
                _tipos_error.eliminarTipoError(t);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todos los tipos de errores para cierres registrados.
        /// </summary>
        /// <returns>Lista de los tipos de errores para cierres registrados en el sistema</returns>
        public BindingList<TipoErrorCierre> listarTiposErrores()
        {

            try
            {
                return _tipos_error.listarTiposErrores();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Tipos de Errores de Cierres de Cajeros

        #region Sucursales

        /// <summary>
        /// Registrar una nueva sucursal en el sistema.
        /// </summary>
        /// <param name="s">Objeto Sucursal con los datos de la nueva sucursal</param>
        public void agregarSucursal(ref Sucursal s)
        {

            try
            {
                if (!_sucursales.verificarSucursalCodigo(ref s))
                    throw new Excepcion("ErrorSucursalDuplicada");

                _sucursales.agregarSucursal(ref s);

                foreach (Dias dia in s.Dias_carga)
                    _sucursales.agregarDiaCargaSucursal(s, dia);


                foreach (TarifaPuntoVentaTransportadora t in s.Tarifas)
                {
                    TarifaPuntoVentaTransportadora copia = t;
                    copia.Sucursal = s;
                    _sucursales.agregarTarifaSucursal(ref copia);
                }   

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de una sucursal en el sistema.
        /// </summary>
        /// <param name="s">Objeto Sucursal con los datos de la sucursal</param>
        public void actualizarSucursal(Sucursal s)
        {

            try
            {
                if (_sucursales.verificarSucursalCodigo(ref s)==true)
                    throw new Excepcion("ErrorSucursalDuplicada");

                _sucursales.actualizarSucursal(s);

                Sucursal anterior = new Sucursal(id: s.ID);

                _sucursales.obtenerDiasCargaSucursal(ref anterior);

                foreach (Dias dia in s.Dias_carga)
                {

                    if (anterior.Dias_carga.Contains(dia))
                        anterior.quitarDiaCarga(dia);
                    else
                        _sucursales.agregarDiaCargaSucursal(s, dia);

                }

                foreach (Dias dia in anterior.Dias_carga)
                    _sucursales.eliminarDiaCargaSucursal(s, dia);


                _sucursales.obtenerTarifaTransportadoraSucursal(ref anterior);

                foreach (TarifaPuntoVentaTransportadora tarifa in s.Tarifas)
                {
                    TarifaPuntoVentaTransportadora copia = tarifa;

 
                    if (anterior.Tarifas.Contains(tarifa))
                        anterior.quitarTarifa(tarifa);
                    else
                        _sucursales.agregarTarifaSucursal(ref copia);

                }

                foreach (TarifaPuntoVentaTransportadora tar in anterior.Tarifas)
                    _sucursales.eliminarTarifaSucursal(tar);



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Marcar como inactiva una sucursal en el sistema.
        /// </summary>
        /// <param name="s">Objeto Sucursal con los datos de la sucursal a marcar</param>
        public void eliminarSucursal(Sucursal s)
        {

            try
            {
                _sucursales.eliminarSucursal(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar las sucursales registradas en el sistema.
        /// </summary>
        /// <returns>Lista de las sucursales registradas en el sistema</returns>
        public BindingList<Sucursal> listarSucursales()
        {

            try
            {
                BindingList<Sucursal> sucursales = _sucursales.listarSucursales();

                foreach (Sucursal sucursal in sucursales)
                {
                    Sucursal copia = sucursal;

                    _sucursales.obtenerDiasCargaSucursal(ref copia);
                }

                foreach (Sucursal sucursal in sucursales)
                {
                    Sucursal copia = sucursal;

                    _sucursales.obtenerTarifaTransportadoraSucursal(ref copia);
                }

                return sucursales;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Listar las sucursales registradas en el sistema.
        /// </summary>
        /// <returns>Lista de las sucursales registradas en el sistema</returns>
        public BindingList<Sucursal> listarSucursalesRecientes()
        {

            try
            {
                BindingList<Sucursal> sucursales = _sucursales.listarSucursalesBranche();

                foreach (Sucursal sucursal in sucursales)
                {
                    Sucursal copia = sucursal;

                    _sucursales.obtenerDiasCargaSucursal(ref copia);
                }

                return sucursales;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Obtiene los datos de una sucursal
        /// </summary>
        /// <param name="sucursal">Objeto sucursal con el numero a buscar</param>
        public bool obtenerDatosSucursal(ref Sucursal a)
        {

            try
            {
                return _sucursales.obtenerDatosSucursal(ref a);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Valida si la tarifa ya existe
        /// </summary>
        /// <param name="t">TarifaPuntoVentaTransportadora con los datos de la tarifa a validar</param>
        /// <returns>Si la tarifa existe o no</returns>
        public bool validarTarifaSucursal(ref TarifaPuntoVentaTransportadora t)
        {
            return _sucursales.verificarTarifaSucursal(ref t);

        }



        /// <summary>
        /// Agrega una tarifa de una transportadora
        /// </summary>
        /// <param name="p">Objeto PuntoVenta con los datos a ingresar</param>
        public void agregarTarifaSucursalImportacion(ref TarifaPuntoVentaTransportadora p)
        {
            try
            {


                _sucursales.agregarTarifaSucursal(ref p);

            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Actualizar una tarifa de una transportadora
        /// </summary>
        /// <param name="p">Objeto PuntoVenta con los datos a ingresar</param>
        public void actualizarTarifaSucursalImportacion(ref TarifaPuntoVentaTransportadora p)
        {
            try
            {

                _sucursales.actualizarTarifaSucursal(p);

            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }



        #endregion Sucursales

        #region Ubicaciones

        /// <summary>
        /// Registrar una ubicación de un ATM.
        /// </summary>
        /// <param name="u">Objeto Ubicacion con los datos de la ubicación</param>
        public void agregarUbicacion(ref Ubicacion u)
        {

            try
            {
                if (_ubicaciones.verificarUbicacion(ref u))
                    throw new Excepcion("ErrorUbicacionDuplicada");

                _ubicaciones.agregarUbicacion(ref u);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de la ubicación de un ATM en el sistema.
        /// </summary>
        /// <param name="u">Objeto Ubicacion con los datos de la ubicación</param>
        public void actualizarUbicacion(Ubicacion u)
        {

            try
            {
                if (_ubicaciones.verificarUbicacion(ref u))
                    throw new Excepcion("ErrorUbicacionDuplicada");

                _ubicaciones.actualizarUbicacion(u);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de la ubicación de un ATM.
        /// </summary>
        /// <param name="u">Objeto Ubicacion con los datos de la ubicación a eliminar</param>
        public void eliminarUbicacion(Ubicacion u)
        {

            try
            {
                _ubicaciones.eliminarUbicacion(u);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar las ubicaciones del sistema.
        /// </summary>
        /// <returns>Lista de las ubicaciones registradas en el sistema</returns>
        public BindingList<Ubicacion> listarUbicaciones()
        {

            try
            {
                return _ubicaciones.listarUbicaciones();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        #endregion Ubicaciones

        #region ATM's

        /// <summary>
        /// Registrar un ATM.
        /// </summary>
        /// <param name="a">Objeto ATM con los datos del ATM</param>
        public void agregarATM(ref ATM a)
        {

            try
            {
                if (_atms.verificarATM(ref a))
                    throw new Excepcion("ErrorATMDuplicado");

                _atms.agregarATM(ref a);

                foreach (Dias dia in a.Dias_carga)
                    _atms.agregarDiaCargaATM(a, dia);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un ATM en el sistema.
        /// </summary>
        /// <param name="a">Objeto ATM con los datos del ATM</param>
        public void actualizarATM(ATM a)
        {

            try
            {
                if (_atms.verificarATM(ref a))
                    throw new Excepcion("ErrorATMDuplicado");

                _atms.actualizarATM(a);

                // Desligar los días de carga anteriores del ATM y registrar los nuevos

                ATM anterior = new ATM(id: a.ID);

                _atms.obtenerDiasCargaATM(ref anterior);

                foreach (Dias dia in a.Dias_carga)
                {

                    if (anterior.Dias_carga.Contains(dia))
                        anterior.quitarDiaCarga(dia);
                    else
                        _atms.agregarDiaCargaATM(a, dia);

                }

                foreach (Dias dia in anterior.Dias_carga)
                    _atms.eliminarDiaCargaATM(a, dia);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un ATM.
        /// </summary>
        /// <param name="a">Objeto ATM con los datos del ATM a eliminar</param>
        public void eliminarATM(ATM a)
        {

            try
            {
                _atms.eliminarATM(a);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar los ATM's registrados en el sistema.
        /// </summary>
        /// <returns>Lista de los ATM's registrados en el sistema</returns>
        public BindingList<ATM> listarATMs()
        {

            try
            {
                BindingList<ATM> atms = _atms.listarATMs();

                foreach (ATM atm in atms)
                {
                    ATM copia = atm;

                    _atms.obtenerDiasCargaATM(ref copia);
                }

                return atms;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Listar los ATM's registrados en el sistema para exportar en Excel.
        /// </summary>
        /// <returns>Lista de los ATM's registrados en el sistema para exportar en Excel.</returns>
        public DataTable listarATMsExportar()
        {

            try
            {
                DataTable atms = _atms.listarATMsExportacion();

               
                return atms;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los datos de un ATM.
        /// </summary>
        /// <param name="a">ATM para el cual se obtienen los datos</param>
        /// <returns>Valor que indica si el ATM existe</returns>
        public bool obtenerDatosATM(ref ATM a)
        {

            try
            {
                return _atms.obtenerDatosATM(ref a);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        ///Actualizar Proveedor para un ATM
        /// </summary>
        /// <param name="a">ATM para el cual se obtienen los datos</param>
        /// <returns>Valor que indica si el ATM existe</returns>
        public void actualizarProveedorATM(ref ATM a)
        {

            try
            {
                 _atms.actualizarProveedorATM(ref a);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion ATM's

        #region Cartuchos

        /// <summary>
        /// Registrar un cartucho.
        /// </summary>
        /// <param name="c">Objeto Cartucho con los datos del cartucho</param>
        public void agregarCartucho(ref Cartucho c)
        {

            try
            {
                if (_cartuchos.verificarCartucho(ref c))
                    throw new Excepcion("ErrorCartuchoDuplicado");

                _cartuchos.agregarCartucho(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void agregarCartuchoMasivo(ref Cartucho c)
        {

            try
            {
                if (_cartuchos.verificarCartucho(ref c) == false)
                    // throw new Excepcion("ErrorCartuchoDuplicado");
                    _cartuchos.agregarCartucho(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un cartucho en el sistema.
        /// </summary>
        /// <param name="c">Objeto Cartucho con los datos del cartucho</param>
        public void actualizarCartucho(Cartucho c)
        {

            try
            {
                if (_cartuchos.verificarCartucho(ref c))
                    throw new Excepcion("ErrorCartuchoDuplicado");

                _cartuchos.actualizarCartucho(c);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar el estado de un cartucho en el sistema.
        /// </summary>
        /// <param name="c">Objeto Cartucho con los datos del cartucho</param>
        public string actualizarCartuchoEstado(Cartucho c, Colaborador usuario)
        {

            try
            {
                _cartuchos.actualizarCartuchoEstado(c, usuario);

                Cartucho anterior = new Cartucho();
                anterior.ID = c.ID;

                _cartuchos.obtenerFallasCartucho(ref anterior);

                foreach (FallaCartucho nombre in c.Fallas)
                {

                    if (anterior.Fallas.Contains(nombre))
                    {
                        anterior.quitarFalla(nombre);
                    }
                    else
                    {
                        FallaCartucho copia_nombre = nombre;

                        _cartuchos.agregarFallaCartucho(ref c, usuario, copia_nombre);
                    }

                }

                foreach (FallaCartucho falla in anterior.Fallas)
                    _cartuchos.eliminarFallaCartucho(ref c, usuario, falla);

                string mensaje = "Realizar pedido de ";
                if (c.Estado == EstadosCartuchos.NoRecuperable)
                {

                    switch (c.Tipo)
                    {
                        case TiposCartucho.Dispensador:
                            int disp = seleccionarAlertasInventario(TiposCartucho.Dispensador);
                            if (disp > 0)
                                mensaje = mensaje + Convert.ToString(disp) + " Cartuchos de Tipo Dispensador \n";
                            break;
                        case TiposCartucho.ENA:
                            int ena = seleccionarAlertasInventario(TiposCartucho.ENA);
                            if (ena > 0)
                                mensaje = mensaje + Convert.ToString(ena) + " Cartuchos de Tipo ENA \n";
                            break;
                        case TiposCartucho.Rechazo:
                            int rec = seleccionarAlertasInventario(TiposCartucho.Rechazo);
                            if (rec > 0)
                                mensaje = mensaje + Convert.ToString(rec) + " Cartuchos de Tipo Rechazo \n";
                            break;
                    }


                }
                return mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int seleccionarAlertasInventario(TiposCartucho c)
        {
            try
            {
                //ALERTAS INVENTARIO DE CARTUCHOS 
                return _inventario.seleccionarAlertasInventario(c);
            }
            catch (Excepcion ex)
            {
                Mensaje.mostrarMensaje(ex.Message);
                return 0;
            }
        }

        public void agregarCartuchoRecibido(Cartucho c, Colaborador usuario)
        {

            try
            {
                //if (_cartuchos.verificarCartucho(ref c))
                //    throw new Excepcion("ErrorCartuchoDuplicado");

                _cartuchos.agregarCartuchoRecibido(c, usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un cartucho.
        /// </summary>
        /// <param name="c">Objeto Cartucho con los datos del cartucho a eliminar</param>
        public void eliminarCartucho(Cartucho c)
        {

            try
            {
                _cartuchos.eliminarCartucho(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar los cartuchos registrados en el sistema.
        /// </summary>
        /// <returns>Lista de los cartuchos registrados en el sistema</returns>
        public BindingList<Cartucho> listarCartuchos()
        {

            try
            {
                return _cartuchos.listarCartuchos();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public BindingList<Cartucho> listarCartuchosEstado(EstadosCartuchos est, String c)
        {

            try
            {
                return _cartuchos.listarCartuchosEstado(est, c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public BindingList<RecepcionCartucho> listarCartuchosMaloTesoreria(BindingList<Cartucho> lista)
        {
            try
            {
                BindingList<RecepcionCartucho> recep = new BindingList<RecepcionCartucho>();

                foreach (Cartucho malo in lista)
                {
                    Cartucho copia_malo = malo;

                    _cartuchos.listarFallasCartuchoMalo(ref copia_malo);

                    for (int i = 0; i < copia_malo.Fallas.Count; i++)
                    {
                        FallaCartucho f = copia_malo.Fallas[i];

                        RecepcionCartucho r = new RecepcionCartucho();
                        r.Cartucho = copia_malo;
                        r.Falla = f;
                        r.Dias = 0;
                        r.Tipo = copia_malo.Tipo;

                        recep.Add(r);
                    }
                }

                return recep;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public BindingList<RecepcionCartucho> listarCartuchosMaloTaller(BindingList<Cartucho> lista)
        {

            try
            {
                BindingList<RecepcionCartucho> recep = new BindingList<RecepcionCartucho>();

                foreach (Cartucho malo in lista)
                {
                    Cartucho copia_malo = malo;

                    _cartuchos.listarFallasCartuchoMalo(ref copia_malo);

                    for (int i = 0; i < copia_malo.Fallas.Count; i++)
                    {
                        FallaCartucho f = copia_malo.Fallas[i];

                        RecepcionCartucho r = new RecepcionCartucho();
                        r.Cartucho = copia_malo;
                        r.Falla = f;

                        TimeSpan span = System.DateTime.Now.Subtract(f.Fecha);
                        r.Dias = span.Days;

                        recep.Add(r);
                    }
                }

                return recep;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public BindingList<RecepcionCartucho> listarCartuchosNoRecuperable(BindingList<Cartucho> lista)
        {

            try
            {
                BindingList<RecepcionCartucho> recep = new BindingList<RecepcionCartucho>();

                foreach (Cartucho malo in lista)
                {
                    Cartucho copia_malo = malo;

                    _cartuchos.listarFallasCartuchoNoRecuperable(ref copia_malo);

                    for (int i = 0; i < copia_malo.Fallas.Count; i++)
                    {
                        FallaCartucho f = copia_malo.Fallas[i];

                        RecepcionCartucho r = new RecepcionCartucho();
                        r.Cartucho = copia_malo;
                        r.Falla = f;
                        r.Dias = 0;

                        recep.Add(r);
                    }
                }

                return recep;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable ObtieneDatosRecepcion(Colaborador clbent, Colaborador clbrec, ProveedorCartucho prov, EstadosCartuchos est)
        {
            try
            {
                return _cartuchos.obtenerDatosRecepcion(clbent, clbrec, prov, est);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtieneDatosResumenRecepcion()
        {
            try
            {
                return _cartuchos.ObtenerDatosResumenRecepcion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Verificar si existe un cartucho y obtener los datos del mismo.
        /// </summary>
        /// <param name="c">Objeto Cartucho con los datos del cartucho a verificar</param>
        /// <returns>Valor que indica si el cartucho existe</returns>
        public bool verificarCartucho(ref Cartucho c)
        {
            bool existe = false;

            try
            {
                existe = _cartuchos.verificarCartucho(ref c);

                if (existe)
                {
                    _cartuchos.obtenerDatosCartucho(ref c);
                    _cartuchos.obtenerFallasCartucho(ref c);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return existe;
        }

        #endregion Cartuchos

        #region Denominaciones

        /// <summary>
        /// Obtener una lista de las denominaciones de monedas definidas en el sistema.
        /// </summary>
        /// <returns>Lista de las denominaciones definidas en el sistema</returns>
        public BindingList<Denominacion> listarDenominaciones()
        {

            try
            {
                return _denominaciones.listarDenominaciones();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        /// <summary>
        /// Obtener una lista de las denominaciones de monedas definidas en el sistema.
        /// </summary>
        /// <returns>Lista de las denominaciones definidas en el sistema</returns>
        public BindingList<Denominacion> listarDenominacionesMonedas()
        {

            try
            {
                return _denominaciones.listarDenominacionesMonedas();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Verificar si una denominación esta registrada en el sistema.
        /// </summary>
        /// <returns>valor que indica si la denominación existe</returns>
        public bool verificarDenominacion(ref Denominacion d)
        {
            bool existe = false;

            try
            {
                existe = _denominaciones.verificarDenominacion(ref d);

                if (existe)
                    _denominaciones.obtenerDatosDenominacion(ref d);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return existe;
        }

        /// <summary>
        /// Verificar si una denominación esta registrada en el sistema con base en su código.
        /// </summary>
        /// <returns>valor que indica si la denominación existe</returns>
        public bool verificarDenominacionCodigo(ref Denominacion d)
        {
            bool existe = false;

            try
            {
                existe = _denominaciones.verificarDenominacionCodigo(ref d);

                if (existe)
                    _denominaciones.obtenerDatosDenominacion(ref d);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return existe;
        }

        /// <summary>
        /// Verificar si una denominación esta registrada en el sistema con base en su código.
        /// </summary>
        /// <returns>Una denominacion </returns>
        public Denominacion ObtenerValorDenominacionCodigo(ref Denominacion d)
        {
            bool existe = false;

            try
            {
                existe = _denominaciones.verificarDenominacionCodigo(ref d);

                if (existe)
                    return _denominaciones.obtenerDatosDenominacion2(ref d);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return d;
        }

        /// <summary>
        /// Registrar un ATM.
        /// </summary>
        /// <param name="a">Objeto ATM con los datos del ATM</param>
        public void agregarDenominacion(ref Denominacion a)
        {

            try
            {
                if (_denominaciones.verificarDenominacion(ref a))
                    throw new Excepcion("ErrorATMDuplicado");

                _denominaciones.agregarDenominacion(ref a);

                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un Denominacion en el sistema.
        /// </summary>
        /// <param name="a">Objeto Denominacion con los datos del</param>
        public void actualizarDenominacion(Denominacion a)
        {

            try
            {
                if (_denominaciones.verificarDenominacion(ref a))
                    throw new Excepcion("ErrorATMDuplicado");

                _denominaciones.actualizarDenominacion(a);

               
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //PROA

        public void actualizarCierreCajero(ProcesamientoBajoVolumenManifiesto _manifiesto)
        {
            SeguridadBL _seguridad = SeguridadBL.Instancia;
            int tipocajero = 0;
            DataTable datoscierre = new DataTable();
            //validar si ya se hizo el cierre cajero
            CierreCajeroPROA cierrecajero = new CierreCajeroPROA(cajero: _manifiesto.Cajero);
            if (verificacierrecajero(ref cierrecajero) != 0)//hay que actualizar los datos
            {
                Colaborador cajeroinfo = _manifiesto.Cajero;
                _seguridad.obtenerPerfilesxColaborador(ref cajeroinfo);

                foreach (Perfil perfil in cajeroinfo.Perfiles)
                {
                    if (perfil.ID == 58)
                    {
                        tipocajero = 1;
                        break;
                    }
                }
                if (tipocajero == 0)
                {
                    _procesamiento_bajo_volumen.actualizarConsultaProaCierreCajero(cajeroinfo.ID);

                }
                else
                {
                    _procesamiento_bajo_volumen.actualizarConsultaProaCierreCajeroNiquel(cajeroinfo.ID);
                }
            }

        }
        public BindingList<Denominacion> listarDenominacionesxMonedas(byte moneda)
        {

            try
            {
                return _denominaciones.listarDenominacionesxmoneda(moneda);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       
        #endregion Denominaciones

        #region Esquemas de Manifiestos

        /// <summary>
        /// Registrar un nuevo esquema de un manifiesto.
        /// </summary>
        /// <param name="e">Objeto EsquemaManifiesto con los datos del nuevo esquema</param>
        public void agregarEsquemaManifiesto(ref EsquemaManifiesto e)
        {

            try
            {
                _esquemas.agregarEsquemaManifiesto(ref e);

                foreach (PosicionEsquema posicion in e.Posiciones)
                {
                    PosicionEsquema copia = posicion;

                    _esquemas.agregarPosicionEsquema(ref copia, e);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos del esquema de un manifiesto.
        /// </summary>
        /// <param name="e">Objeto EsquemaManifiesto con los datos del esquema</param>
        public void actualizarEsquemaManifiesto(EsquemaManifiesto e)
        {

            try
            {
                _esquemas.actualizarEsquemaManifiesto(e);

                // Desligar las posiciones anteriores del esquema y registrar las nuevas

                EsquemaManifiesto anterior = new EsquemaManifiesto(e.ID);

                _esquemas.obtenerPosicionesEsquema(ref anterior);

                foreach (PosicionEsquema posicion in e.Posiciones)
                {

                    if (anterior.Posiciones.Contains(posicion))
                    {
                        anterior.quitarPosicion(posicion);
                    }
                    else
                    {
                        PosicionEsquema copia = posicion;

                        _esquemas.agregarPosicionEsquema(ref copia, e);
                    }

                }

                foreach (PosicionEsquema posicion in anterior.Posiciones)
                    _esquemas.eliminarPosicionEsquema(posicion);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Marcar como inactivo el esquema de un manifiesto.
        /// </summary>
        /// <param name="e">Objeto EsquemaManifiesto con los datos del esquema</param>
        public void eliminarEsquemaManifiesto(EsquemaManifiesto e)
        {

            try
            {
                _esquemas.eliminarEsquemaManifiesto(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar los esquemas de manifiestos registrados en el sistema.
        /// </summary>
        /// <returns>Lista de esquemas de manifiestos registrados en el sistema</returns>
        public BindingList<EsquemaManifiesto> listarEsquemasManifiestos()
        {

            try
            {
                BindingList<EsquemaManifiesto> esquemas = _esquemas.listarEsquemasManifiestos();

                foreach (EsquemaManifiesto esquema in esquemas)
                {
                    EsquemaManifiesto actual = esquema;

                    _esquemas.obtenerPosicionesEsquema(ref actual);
                }

                return esquemas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Listar los esquemas de manifiestos registrados en el sistema.
        /// </summary>
        /// <returns>Lista de esquemas de manifiestos registrados en el sistema</returns>
        public EsquemaManifiesto listarEsquemasManifiestoEspecifico(int id)
        {

            try
            {
                EsquemaManifiesto esquemas = _esquemas.listarEsquemasManifiestoEspecifico(id);

                
                    EsquemaManifiesto actual = esquemas;

                    _esquemas.obtenerPosicionesEsquema(ref actual);
                

                return esquemas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }






        /// <summary>
        /// Listar los esquemas de manifiestos registrados en el sistema.
        /// </summary>
        /// <returns>Lista de esquemas de manifiestos registrados en el sistema</returns>
        public EsquemaManifiesto listarEsquemasManifiestoTransportadora(EmpresaTransporte transportadora)
        {

            try
            {
                EsquemaManifiesto esquemas = _esquemas.listarEsquemasManifiestoTransportadora(transportadora);


                EsquemaManifiesto actual = esquemas;

                _esquemas.obtenerPosicionesEsquema(ref actual);


                return esquemas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de una posición del esquema de un manifiesto.
        /// </summary>
        /// <param name="p">Objeto PosicionEsquema con los datos de la posición a actualizar</param>
        public void actualizarPosicionEsquema(PosicionEsquema p)
        {

            try
            {
                _esquemas.actualizarPosicionEsquema(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Esquemas de Manifiestos

        #region Tripulaciones

        /// <summary>
        /// Registrar una nueva tripulacion
        /// </summary>
        /// <param name="t">Objeto Tripulacion con los datos de la nueva Tripulacion</param>
        public void agregarTripulaciones(ref Tripulacion t,DateTime f)
        {

            try
            {
                if (_tripulaciones.verificarTripulacion(ref t,f))
                    this.actualizarTripulacion(ref t);
                else
                    _tripulaciones.agregarTripulacion(ref t,f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Actualizar los datos de una Tripulacion en el sistema.
        /// </summary>
        /// <param name="v">Objeto Tripulacion con los datos de la Tripulacion</param>
        public void actualizarTripulacion(ref Tripulacion t)
        {

            try
            {
                _tripulaciones.actualizarTripulacion(ref t);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Actualizar los valores de Sincronizacion de HH
        /// </summary>
        /// <param name="v">Objeto Tripulacion con los datos de la Tripulacion</param>
        public void actualizarDatosSincronizadosHH(ref Tripulacion t)
        {

            try
            {
                _tripulaciones.actualizarDatosSincronizacionHH(ref t);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Eliminar los datos de una tripulacion
        /// </summary>
        /// <param name="nuevo">Objeto Tripulacion con los datos de la tripulacion a eliminar</param>
        public void eliminarTripulacion(ref Tripulacion t)
        {
            try
            {
                _tripulaciones.eliminarTripulacion(ref t);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Listar las tripulaciones de un determinado dia
        /// </summary>
        /// <param name="b">descripcion a buscar</param>
        /// <param name="f">fecha del registro de la tripulacion</param>
        /// <returns>Lista con las tripulaciones de la fecha y la descripcion solicita</returns>
        public BindingList<Tripulacion> listarTripulacion(string b, DateTime f)
        {
            try
            {
                BindingList<Tripulacion> tripulaciones = _tripulaciones.listarTripulaciones(b,f);

                foreach (Tripulacion t in tripulaciones)
                {


                    if (t.Asignaciones == null)
                    {
                        t.Asignaciones = new AsignacionEquipo();
                    }
                    int id = t.Asignaciones.ID;
                    Colaborador chofer = t.Chofer;
                    Colaborador custodio = t.Custodio;
                    Colaborador portavalor = t.Portavalor;



                    _tripulaciones.listarEquiposColaborador(ref chofer, id);
                    _tripulaciones.listarEquiposColaboradorYaAsignados(ref chofer);
                    _tripulaciones.listarEquiposColaboradorYaAsignadosPorPuesto(ref chofer, Puestos.Chofer);
                    _tripulaciones.listarEquiposColaborador(ref custodio, id);
                    _tripulaciones.listarEquiposColaboradorYaAsignados(ref custodio);
                    _tripulaciones.listarEquiposColaboradorYaAsignadosPorPuesto(ref custodio, Puestos.Custodio);
                    _tripulaciones.listarEquiposColaborador(ref portavalor, id);
                    _tripulaciones.listarEquiposColaboradorYaAsignados(ref portavalor);
                    _tripulaciones.listarEquiposColaboradorYaAsignadosPorPuesto(ref portavalor, Puestos.Portavalor);
                }

                return tripulaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        /// <summary>
        /// Listar las tripulaciones de un determinado dia
        /// </summary>
        /// <param name="b">descripcion a buscar</param>
        /// <param name="f">fecha del registro de la tripulacion</param>
        /// <returns>Lista con las tripulaciones de la fecha y la descripcion solicita</returns>
        public Tripulacion listarTripulacionRuta(int ruta, DateTime f)
        {
            try
            {
                Tripulacion tripulaciones = _tripulaciones.listarTripulacionRuta(ruta, f);

                //foreach (Tripulacion t in tripulaciones)
                //{


                //    if (t.Asignaciones == null)
                //    {
                //        t.Asignaciones = new AsignacionEquipo();
                //    }
                //    int id = t.Asignaciones.ID;
                //    Colaborador chofer = t.Chofer;
                //    Colaborador custodio = t.Custodio;
                //    Colaborador portavalor = t.Portavalor;



                //    _tripulaciones.listarEquiposColaborador(ref chofer, id);
                //    _tripulaciones.listarEquiposColaboradorYaAsignados(ref chofer);
                //    _tripulaciones.listarEquiposColaboradorYaAsignadosPorPuesto(ref chofer, Puestos.Chofer);
                //    _tripulaciones.listarEquiposColaborador(ref custodio, id);
                //    _tripulaciones.listarEquiposColaboradorYaAsignados(ref custodio);
                //    _tripulaciones.listarEquiposColaboradorYaAsignadosPorPuesto(ref custodio, Puestos.Custodio);
                //    _tripulaciones.listarEquiposColaborador(ref portavalor, id);
                //    _tripulaciones.listarEquiposColaboradorYaAsignados(ref portavalor);
                //    _tripulaciones.listarEquiposColaboradorYaAsignadosPorPuesto(ref portavalor, Puestos.Portavalor);
                //}

                return tripulaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        /// <summary>
        /// Actualizar el orden de las cargas de ATM's de una ruta específica.
        /// </summary>
        /// <param name="c">Lista de cargas de una ruta específica</param>
        public void actualizarTripulacoinesOrdenSalida(BindingList<Tripulacion> c)
        {

            try
            {
                foreach (Tripulacion trip in c)
                    _tripulaciones.actualizarTripulacionOrdenSalida(trip);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Tripulaciones

        #region Vehiculos

        /// <summary>
        /// Registrar un Vehiculo.
        /// </summary>
        /// <param name="v">Objeto Vehiculo con los datos del Vehiculo</param>
        public void agregarVehiculo(ref Vehiculo v)
        {

            try
            {
                if (_vehiculos.verificarVehiculo(ref v))
                    throw new Excepcion("ErrorVerificarVehiculoDuplicado");

                _vehiculos.agregarVehiculo(ref v);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un Vehiculo en el sistema.
        /// </summary>
        /// <param name="f">Objeto Vehiculo con los datos del Vehiculo</param>
        public void actualizarVehiculo(Vehiculo v)
        {

            try
            {
                if (_vehiculos.verificarVehiculo(ref v))
                    throw new Excepcion("ErrorVerificarVehiculoDuplicado");

                _vehiculos.actualizarVehiculo(ref v);

                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un Vehiculo.
        /// </summary>
        /// <param name="v">Objeto Vehiculo con los datos del Vehiculo a eliminar</param>
        public void eliminarVehiculo(Vehiculo v)
        {

            try
            {
                _vehiculos.eliminarVehiculo(v);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar los Vehiculos registrados en el sistema.
        /// </summary>
        /// <returns>Lista de los Vehiculos registrados en el sistema</returns>
        public BindingList<Vehiculo> listarVehiculo(string b)
        {

            try
            {
                BindingList<Vehiculo> vehiculos = _vehiculos.listarVehiculos(b);
                return vehiculos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


       

        /// <summary>
        /// Obtener los datos de un Vehiculo.
        /// </summary>
        /// <param name="v">Vehiculo para el cual se obtienen los datos</param>
        /// <returns>Valor que indica si el Vehiculo existe</returns>
        public bool obtenerDatosVehiculo(ref Vehiculo v)
        {

            try
            {
                return _vehiculos.obtenerDatosVehiculoM(ref v);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


       #endregion Vehiculos

        #region Fallas

      
        /// <summary>
        /// Registrar una Falla.
        /// </summary>
        /// <param name="f">Objeto Falla con los datos de la Falla</param>
        public void agregarFalla(ref Falla f)
        {

            try
            {
                //if (_fallas.(ref f))
                //    throw new Excepcion("ErrorVerificarVehiculoDuplicado");

                _fallas.agregarFalla(ref f);

                foreach (DetalleFalla detalles in f.Detalle_falla)
                {
                    
                    DetalleFalla copia = detalles;

                    copia.Falla = f;
                    _detalle_fallas.agregarDetalleFalla(ref copia);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de una Falla en el sistema.
        /// </summary>
        /// <param name="f">Objeto Falla con los datos de la falla</param>
        public void actualizarFalla(Falla f)
        {

            try
            {
                //if (_fallas.actualizarFalla(ref f))
                //    throw new Excepcion("ErrorVerificarVehiculoDuplicado");

                _fallas.actualizarFalla(ref f);


                // Desligar las susursales anteriores del cliente y registrar las nuevas
                Falla anterior = new Falla(f.ID);

                _detalle_fallas.obtenerDetalleFallaFalla(ref anterior);

                foreach (DetalleFalla detalle in f.Detalle_falla)
                {
                    DetalleFalla copia = detalle;

                    copia.Falla = f;

                    if (anterior.Detalle_falla.Contains(detalle))
                        anterior.quitarDetalleFalla(detalle);
                    else
                        _detalle_fallas.agregarDetalleFalla(ref copia);

                }

                foreach (DetalleFalla detalle_falla in anterior.Detalle_falla)
                    _detalle_fallas.eliminarDetalleFalla(detalle_falla);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una falla.
        /// </summary>
        /// <param name="f">Objeto Falla con los datos de la falla a eliminar</param>
        public void eliminarFalla(Falla f)
        {

            try
            {
                _fallas.eliminarFalla(f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar las Fallas registrados en el sistema.
        /// </summary>
        /// <returns>Lista de las Fallas registrados en el sistema</returns>
        public BindingList<Falla> listarFalla(string b,TipoFallasBlindados t)
        {

            try
            {
                BindingList<Falla> fallas = _fallas.listarFallas(b, t);

                foreach (Falla f in fallas)
                {
                    Falla copia_fall = f;
                    _detalle_fallas.obtenerDetalleFallaFalla(ref copia_fall);
                }

                return fallas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los datos de una Falla.
        /// </summary>
        /// <param name="f">Falla para el cual se obtienen los datos</param>
        /// <returns>Valor que indica si el Falla existe</returns>
        public bool obtenerDatosFalla(ref Falla f)
        {

            try
            {
                return _fallas.obtenerDatosFalla(ref f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un detalle de una falla
        /// </summary>
        /// <param name="s">Objeto DetalleFalla con los datos del punto de venta</param>
        public void actualizarDetalleFalla(DetalleFalla d)
        {

            try
            {
                _detalle_fallas.actualizarDetalleFalla(d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion Fallas

        #region Dispositivo

        /// <summary>
        /// Registrar un nuevo dispositivo.
        /// </summary>
        /// <param name="c">Objeto Dispositivo con los datos del nuevo dispositivo</param>
        public void agregarDispositivo(ref Dispositivo c)
        {

            try
            {
                _dispositivos.agregarDispositivo(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un dispositivo.
        /// </summary>
        /// <param name="c">Objeto Dispositivo con los datos del dispositivo a actualizar</param>
        public void actualizarDispositivo(Dispositivo c)
        {

            try
            {
                _dispositivos.actualizarDispositivo(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un dispositivo.
        /// </summary>
        /// <param name="c">Objeto Dispositivo con los datos del dispositivo a eliminar</param>
        public void eliminarDispositivo(Dispositivo c)
        {

            try
            {
                _dispositivos.eliminarDispositivo(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todos los dispositivos registrados.
        /// </summary>
        /// <returns>Lista de dispositivos registrados en el sistema</returns>
        public BindingList<Dispositivo> listarDispositivos()
        {

            try
            {
                return _dispositivos.listarDispositivoes();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Dispositivo

        #region Tipo de Equipo

        /// <summary>
        /// Registrar un nuevo tipo de equipo.
        /// </summary>
        /// <param name="c">Objeto Dispositivo con los datos del nuevo tipo de equipo</param>
        public void agregarTipoEquipo(ref TipoEquipo c)
        {

            try
            {
                if (_tipo_equipos.verificarTipoEquipo(c))
                    throw new Excepcion("ErrorVerificarTipoEquipoDuplicado");

                _tipo_equipos.agregarTipoEquipo(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un tipo de equipo.
        /// </summary>
        /// <param name="c">Objeto Dispositivo con los datos del tipo de equipo a actualizar</param>
        public void actualizarTipoEquipo(TipoEquipo c)
        {

            try
            {
                if (_tipo_equipos.verificarTipoEquipo(c))
                    throw new Excepcion("ErrorVerificarTipoEquipoDuplicado");

                _tipo_equipos.actualizarTipoEquipo(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un tipo de equipo.
        /// </summary>
        /// <param name="c">Objeto TipoEquipo con los datos del tipo equipo a eliminar</param>
        public void eliminarTipoEquipo(TipoEquipo c)
        {

            try
            {
                _tipo_equipos.eliminarTipoEquipo(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todos los tipo de equipo registrados.
        /// </summary>
        /// <returns>Lista de dispositivos tipo de equipo en el sistema</returns>
        public BindingList<TipoEquipo> listarTipoEquipo()
        {

            try
            {
                return _tipo_equipos.listarTipoEquipos(string.Empty);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Tipo de Equipo

        #region Manojos

        /// <summary>
        /// Registrar un Manojo.
        /// </summary>
        /// <param name="v">Objeto Manojo con los datos del Manojo</param>
        public void agregarManojo(ref Manojo v)
        {

            try
            {
                if (_manojos.verificarManojo(v))
                    throw new Excepcion("ErrorVerificarManojoDuplicado");

                _manojos.agregarManojo(ref v);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un Manojo en el sistema.
        /// </summary>
        /// <param name="f">Objeto Manojo con los datos del Manojo</param>
        public void actualizarManojo(Manojo v)
        {

            try
            {
                if (_manojos.verificarManojo(v))
                    throw new Excepcion("ErrorVerificarManojoDuplicado");

                _manojos.actualizarManojo(v);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un Manojo.
        /// </summary>
        /// <param name="v">Objeto Manojo con los datos del Manojo a eliminar</param>
        public void eliminarManojo(Manojo v)
        {

            try
            {
                _manojos.eliminarManojo(v);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar los Manojos registrados en el sistema.
        /// </summary>
        /// <returns>Lista de los Manojos registrados en el sistema</returns>
        public BindingList<Manojo> listarManojo(string b)
        {

            try
            {
                BindingList<Manojo> manojos = _manojos.listarManojos(b);
                return manojos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        #endregion Manojos

        #region Equipo

        /// <summary>
        /// Registrar un Equipo.
        /// </summary>
        /// <param name="v">Objeto Equipo con los datos del Equipo</param>
        public void agregarEquipo(ref Equipo v)
        {

            try
            {
                if (_equipos.verificarEquipo(v))
                    throw new Excepcion("ErrorVerificarEquipoDuplicado");

                _equipos.agregarEquipo(ref v);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un Equipo en el sistema.
        /// </summary>
        /// <param name="e">Objeto Equipo con los datos del Equipo</param>
        public void actualizarEquipo(Equipo e)
        {

            try
            {
                if (_equipos.verificarEquipo(e))
                    throw new Excepcion("ErrorVerificarEquipoDuplicado");

                _equipos.actualizarEquipo(e);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un Equipo.
        /// </summary>
        /// <param name="e">Objeto Equipo con los datos del Equipo a eliminar</param>
        public void eliminarEquipo(Equipo e)
        {

            try
            {
                _equipos.eliminarEquipo(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar los Equipos registrados en el sistema.
        /// </summary>
        /// <returns>Lista de los Equipos registrados en el sistema</returns>
        public BindingList<Equipo> listarEquipo(string b)
        {

            try
            {
                BindingList<Equipo> equipos = _equipos.listarEquipos(b);
                return equipos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        #endregion Equipo

        #region ManifestosCajeros

        /// <summary>
        /// Listar a los cajeros asignados a la recepcion de tulas.
        /// </summary>
        /// <returns>Lista a los cajeros asignados a la recepcion de tulas</returns>
        public BindingList<Colaborador> listarCajerosAsignados()
        {

            try
            {
                BindingList<Colaborador> colaboradores = _manifiesto_cef.listarCajerosAsignados();

                return colaboradores;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// Listar las relaciones de los cajeros asignados a la recepcion de tulas
        /// </summary>
        /// <returns>Listar las relaciones de los cajeros asignados a la recepcion de tulas/// </returns>
        public BindingList<ManifiestoColaborador> listarRegistrosCajerosAsignados(Grupo grupo)
        {

            try
            {
                BindingList<ManifiestoColaborador> registros = _manifiesto_cef.listarRegistrosCajerosAsignados(grupo);

                return registros;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Registrar una relacion Manifiesto - Colaborador.
        /// </summary>
        /// <param name="m">Objeto  con los datos del cartucho</param>
        public void agregarAsignacionManifiestoCajero(ref ManifiestoColaborador m)
        {

            try
            {

                if (_manifiesto_cef.verificarAsignacionManifiestoCajero(ref m))
                {
                    _manifiesto_cef.actualizarAsignacionManifiestoCajero(ref m);
                }

                _manifiesto_cef.agregarAsignacionManifiestoCajero(ref m);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Registrar relacion manifiesto colaborador.
        /// </summary>
        /// <param name="m">Objeto ManifiestoColaborador con los datos del registro</param>
        public void actualizarManfiestoCajero(ref ManifiestoColaborador m)
        {
            try
            {
                if (_manifiesto_cef.verificarAsignacionManifiestoCajero(ref m))
                {
                    _manifiesto_cef.actualizarManifiestoCajero(ref m);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Registrar relacion manifiesto colaborador.
        /// </summary>
        /// <param name="m">Objeto ManifiestoColaborador con los datos del registro</param>
        public void reiniciarAsignacionManifiestoCajero(Grupo grupo)
        {
            try
            {
                _manifiesto_cef.reiniciarAsignacionManifiestoCajero(grupo);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }




        #endregion ManifestosCajeros

        #region Cantidad de Formulas

        /// <summary>
        /// Registrar un tipo de cambio.
        /// </summary>
        /// <param name="u">Objeto Formula con los datos del tipo de cambio</param>
        public void agregarFormula(ref Formula t)
        {

            try
            {

                _formula.agregarFormula(ref t);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos del tipo de cambio de una fecha determinada.
        /// </summary>
        /// <param name="u">Objeto Formula con los datos de la formula</param>
        public void actualizarFormula(Formula t)
        {

            try
            {
                _formula.actualizarFormula(t);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener la formula existente
        /// </summary>
        /// <returns>Objeto Formula con los datos de la formula existente</returns>
        public Formula obtenerFormula()
        {

            try
            {
                return _formula.obtenerFormula();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Cantidad de Formulas

        #region Feriados

        /// <summary>
        /// Registrar un feriado en el sistema.
        /// </summary>
        /// <param name="f">Objeto Feriado con los datos del nuevo feriado</param>
        public void agregarFeriado(ref Feriado f)
        {

            try
            {
                _feriados.agregarFeriado(ref f);

              
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un feriado en el sistema.
        /// </summary>
        /// <param name="f">Objeto Feriado con los datos del feriado</param>
        public void actualizarFeriado(Feriado f)
        {

            try
            {
                _feriados.actualizarFeriado(f);

                // Desligar las área anteriores del feriado y registrar las nuevas

                Feriado anterior = new Feriado(f.Id);

              

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Marcar un feriado como terminado.
        /// </summary>
        /// <param name="f">Objeto Feriado con los datos del feriado a terminar</param>
        public void terminarFeriado(Feriado f)
        {

            try
            {
                _feriados.terminarFeriado(f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar un feriado del sistema.
        /// </summary>
        /// <param name="f">Objeto Feriado con los datos del feriado a eliminar</param>
        public void eliminarFeriado(Feriado f)
        {

            try
            {
                _feriados.eliminarFeriado(f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar los feriados registradas en el sistema en las áreas de un usuario.
        /// </summary>
        /// <param name="u">Usuario para el cual se genera la lista</param>
        /// <returns>Lista de los feriados registrados en el sistema</returns>
        public BindingList<Feriado> listarFeriados(Colaborador u)
        {

            try
            {
                BindingList<Feriado> feriados = _feriados.listarFeriados(u);

               
                return feriados;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Feriados

        #region PuntoAtencion

        /// <summary>
        /// Obtener los datos del punto de atencion para un cliente
        /// </summary>
        /// <param name="p">Objeto Punto de Atencion con los datos del punto a atender</param>
        public void obtenerDatosClientePuntoAtencion(ref PuntoAtencion p)
        {
            _punto_atencion.obtenerPuntosAtencionCliente(ref p);
        }

        /// <summary>
        /// Obtener los datos del punto de atencion para una sucursal
        /// </summary>
        /// <param name="p">Objeto Punto de Atencion con los datos del punto a atender</param>
        public void obtenerDatosSucursalPuntoAtencion(ref PuntoAtencion p)
        {
            _punto_atencion.obtenerPuntosAtencionSucursales(ref p);
        }

        #endregion PuntoAtencion

        #region Inconsistencias Facturacion

        /// <summary>
        /// Registrar una nueva inconsistencia.
        /// </summary>
        /// <param name="c">Objeto Inconsistencia con los datos de la nueva inconsistencia</param>
        public void agregarInconsistenciaFacturacion(ref InconsistenciaFacturacion c)
        {

            try
            {
                _inconsistencia_facturacion.agregarInconsistenciaFacturacion(ref c); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de una inconsistencia facturacion.
        /// </summary>
        /// <param name="c">Objeto InconsistenciaFacturacion con los datos de la inconsistencia a actualizar</param>
        public void actualizarInconsistenciaFacturacion(InconsistenciaFacturacion c)
        {

            try
            {
                _inconsistencia_facturacion.actualizarInconsistenciaFacturacion(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una inconsistencia.
        /// </summary>
        /// <param name="c">Objeto InconsistenciaFacturacion con los datos de la inconsistencia a eliminar</param>
        public void eliminarInconsistenciaFacturacion(InconsistenciaFacturacion c)
        {

            try
            {
                _inconsistencia_facturacion.eliminarInconsistenciaFacturacion(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todas las inconsistencia de facturación registradas.
        /// </summary>
        /// <returns>Lista de inconsistencias registradas en el sistema</returns>
        public BindingList<InconsistenciaFacturacion> listarInconsistenciaFacturacion()
        {

            try
            {
                return _inconsistencia_facturacion.listarInconsistenciaFacturacions();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        


        #endregion Inconsistencias Facturacion
        
        #region Tipo Penalidad


        /// <summary>
        /// Registrar una TipoPenalidad.
        /// </summary>
        /// <param name="f">Objeto TipoPenalidad con los datos del Tipo de Penalidad</param>
        public void agregarTipoPenalidad(ref TipoPenalidad f)
        {

            try
            {
                //if (_fallas.(ref f))
                //    throw new Excepcion("ErrorVerificarVehiculoDuplicado");

                _tipo_penalidad.agregarTipoPenalidad(ref f);

                foreach (NivelTipoPenalidad detalles in f.Niveles)
                {

                    NivelTipoPenalidad copia = detalles;

                    copia.TipoPenalidad = f;
                    _nivel_tipo_penalidad.agregarNivelTipoPenalidad(ref copia);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de una TipoPenalidad en el sistema.
        /// </summary>
        /// <param name="f">Objeto TipoPenalidad con los datos del tipo de penalidad</param>
        public void actualizarTipoPenalidad(TipoPenalidad f)
        {

            try
            {


                _tipo_penalidad.actualizarTipoPenalidad(ref f);


                // Desligar los niveles anteriores del tipo de penalidad y registrar las nuevas
                TipoPenalidad anterior = new TipoPenalidad(f.Id);

                _nivel_tipo_penalidad.obtenerNivelTipoPenalidadFalla(ref anterior);

                foreach (NivelTipoPenalidad nivel in f.Niveles)
                {
                    NivelTipoPenalidad copia = nivel;

                    copia.TipoPenalidad = f;

                    if (anterior.Niveles.Contains(nivel))
                        anterior.quitarNivel(nivel);
                    else
                        _nivel_tipo_penalidad.agregarNivelTipoPenalidad(ref copia);

                }

                foreach (NivelTipoPenalidad nivel in anterior.Niveles)
                    _nivel_tipo_penalidad.eliminarNivelTipoPenalidad(nivel);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una TipoPenalidad.
        /// </summary>
        /// <param name="f">Objeto TipoPenalidad con los datos del tipo de penalidad a eliminar</param>
        public void eliminarTipoPenalidad(TipoPenalidad f)
        {

            try
            {
                _tipo_penalidad.eliminarTipoPenalidad(f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar los Tipos de Penalidades registrados en el sistema.
        /// </summary>
        /// <returns>Lista de las TipoPenalidad registrados en el sistema</returns>
        public BindingList<TipoPenalidad> listarTipoPenalidades(string b)
        {

            try
            {
                BindingList<TipoPenalidad> tipos = _tipo_penalidad.listarTipoPenalidads(b);

                foreach (TipoPenalidad f in tipos)
                {
                    TipoPenalidad copia_tipopen = f;
                    _nivel_tipo_penalidad.obtenerNivelTipoPenalidadFalla(ref copia_tipopen);
                }

                return tipos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los datos de un Tipo de Penalidad.
        /// </summary>
        /// <param name="f">Tipo Penalidad para el cual se obtienen los datos</param>
        /// <returns>Valor que indica si el Tipo de Penalidad existe</returns>
        public bool obtenerDatosTipoPenalidad(ref TipoPenalidad f)
        {

            try
            {
                return _tipo_penalidad.obtenerDatosTipoPenalidad(ref f);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un detalle de una falla
        /// </summary>
        /// <param name="s">Objeto DetalleFalla con los datos del punto de venta</param>
        public void actualizarNivelTipoPenalidad(NivelTipoPenalidad d)
        {

            try
            {
                _nivel_tipo_penalidad.actualizarNivelTipoPenalidad(d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion Tipo Penalidad

        #region Penalidades

        /// <summary>
        /// Registrar una nueva penalidad.
        /// </summary>
        /// <param name="c">Objeto Penalidad con los datos de la nueva penalidad</param>
        public void agregarPenalidad(ref Penalidad c)
        {

            try
            {
                _penalidad.agregarPenalidad(ref c); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de una Penalidad.
        /// </summary>
        /// <param name="c">Objeto Penalidad con los datos de la Penalidad a actualizar</param>
        public void actualizarPenalidad(Penalidad c)
        {

            try
            {
                _penalidad.actualizarPenalidad(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una penalidad.
        /// </summary>
        /// <param name="c">Objeto Penalidad con los datos de la penalidad a eliminar</param>
        public void eliminarPenalidad(Penalidad c)
        {

            try
            {
                _penalidad.eliminarPenalidad(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todas las penalidades registradas.
        /// </summary>
        /// <returns>Lista de Penalidades registradas en el sistema</returns>
        public BindingList<Penalidad> listarPenalidades()
        {

            try
            {
                return _penalidad.listarPenalidads();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        #endregion Penalidades

        #region Nivel de Servicio

        /// <summary>
        /// Registrar un nuevo nivel de Servicio.
        /// </summary>
        /// <param name="c">Objeto NivelServicio con los datos del nuevo nivel de Servicio</param>
        public void agregarNivelServicio(ref NivelServicio c)
        {

            try
            {
                _nivel_servicio.agregarNivelServicio(ref c); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un nivel de Servicio
        /// </summary>
        /// <param name="c">Objeto NivelServicio con los datos del Nivel de Servicio a actualizar</param>
        public void actualizarNivelServicio(NivelServicio c)
        {

            try
            {
                _nivel_servicio.actualizarNivelServicio(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un nivel de Servicio.
        /// </summary>
        /// <param name="c">Objeto NivelServicio con los datos del nivel de servicio eliminar</param>
        public void eliminarNivelServicio(NivelServicio c)
        {

            try
            {
                _nivel_servicio.eliminarNivelServicio(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todas los niveles de servicio registrados.
        /// </summary>
        /// <returns>Lista de Niveles de Servicio registrados en el sistema</returns>
        public BindingList<NivelServicio> listarNivelesServicio(DateTime fechai, DateTime fechaf)
        {

            try
            {
                return _nivel_servicio.obtenerNivelServicio(fechai, fechaf);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Valida si el nivel de Servicio
        /// </summary>
        /// <param name="t">NivelServicio con los datos de la tarifa a validar</param>
        /// <returns>Si la tarifa existe o no</returns>
        public bool validarNivelServicio(ref NivelServicio t)
        {
            return _nivel_servicio.verificarNivelServicio(ref t);

        }

        #endregion Nivel de Servicio

        #region Promedio Descargas ATM

        /// <summary>
        /// Registrar un nuevo promedio de ATM
        /// </summary>
        /// <param name="c">Objeto PromedioDescargaATM con los datos del nuevo promedio</param>
        public void agregarPromedioDescargaATM(ref PromedioDescargaATM c)
        {

            try
            {
                _promedios.agregarPromedioDescargaATM(ref c); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un promedio de descarga de ATM
        /// </summary>
        /// <param name="c">Objeto PromedioDescargaATM con los datos del promedio a actualizar</param>
        public void actualizarPromedioDescargaATM(PromedioDescargaATM c)
        {

            try
            {
                _promedios.actualizarPromedioDescargaATM(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un promedio de descarga de ATM
        /// </summary>
        /// <param name="c">Objeto PromedioDescargaATM con los datos del promedio a eliminar</param>
        public void eliminarPromedioDescargaATM(PromedioDescargaATM c)
        {

            try
            {
                _promedios.eliminarPromedioDescargaATM(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todas los promedios registrados.
        /// </summary>
        /// <returns>Lista de PromedioDescargaATM registrados en el sistema</returns>
        public BindingList<PromedioDescargaATM> listarPromedioDescargaATM()
        {

            try
            {
                return _promedios.obtenerPromedioDescargaATM();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Valida si el promedio de descarga de ATM existe
        /// </summary>
        /// <param name="t">PromedioDescargaATM con los datos del promedio a validar</param>
        /// <returns>Si el promedio existe o no</returns>
        public bool validarPromedioDescargaATM(ref PromedioDescargaATM t)
        {
            return _promedios.verificarPromedioDescargaATM(ref t);

        }


        /// <summary>
        /// Obtiene los datos
        /// </summary>
        /// <param name="t">PromedioDescargaATM con los datos del promedio a validar</param>
        /// <returns>Si el promedio existe o no</returns>
        public void obtenerDatosPromedioDescargaATM(ref PromedioDescargaATM t)
        {
            _promedios.obtenerDatosPromedioDescargaATM(ref t);

        }

        #endregion Promedio Descargas ATM

        #region Promedio Remanentes ATM

        /// <summary>
        /// Registrar un nuevo promedio de ATM
        /// </summary>
        /// <param name="c">Objeto PromedioDescargaATM con los datos del nuevo promedio</param>
        public void agregarRemanenteDescargaATM(ref PromedioRemanenteATM c)
        {

            try
            {
                _remanente.agregarPromedioRemanenteATM(ref c); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un promedio de descarga de ATM
        /// </summary>
        /// <param name="c">Objeto PromedioRemanenteATM con los datos del promedio a actualizar</param>
        public void actualizarRemanenteATM(PromedioRemanenteATM c)
        {

            try
            {
                _remanente.actualizarPromedioRemanenteATM(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       

        /// <summary>
        /// Listar todas los promedios registrados.
        /// </summary>
        /// <returns>Lista de PromedioRemanenteATM registrados en el sistema</returns>
        public PromedioRemanenteATM listarPromedioRemanenteATM()
        {

            try
            {
                return _remanente.obtenerPromedioRemanenteATM();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Valida si el promedio de descarga de ATM existe
        /// </summary>
        /// <param name="t">PromedioDescargaATM con los datos del promedio a validar</param>
        /// <returns>Si el promedio existe o no</returns>
        public bool validarPromedioRemanenteATM(ref PromedioDescargaATM t)
        {
            return _promedios.verificarPromedioDescargaATM(ref t);

        }


        ///// <summary>
        ///// Obtiene los datos
        ///// </summary>
        ///// <param name="t">PromedioDescargaATM con los datos del promedio a validar</param>
        ///// <returns>Si el promedio existe o no</returns>
        //public void obtenerDatosPromedioDescargaATM(ref PromedioDescargaATM t)
        //{
        //    _remanente.obtener(ref t);

        //}

        #endregion Promedio Descargas ATM

        #region Cantidad de Monedas por Bolsa

        /// <summary>
        /// Registrar una nueva cantidad de piezas por denominación
        /// </summary>
        /// <param name="c">Objeto CantidadMonedasBolsaNiquel con los datos de las piezas</param>
        public void agregarCantidadMonedasBolsa(ref CantidadMonedasBolsaNiquel c)
        {

            try
            {
                _cantidad_monedas_niquel.agregarCantidadMonedasBolsaNiquels(ref c); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de  una cantidad de piezas por denominación
        /// </summary>
        /// <param name="c">Objeto Camara con los datos de la cámara a actualizar</param>
        public void actualizarCantidadMonedasBolsa(CantidadMonedasBolsaNiquel c)
        {

            try
            {
                _cantidad_monedas_niquel.actualizarCantidadMonedasBolsaNiquel(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una cámara.
        /// </summary>
        /// <param name="c">Objeto Camara con los datos de la cámara a eliminar</param>
        public void eliminarCantidadMonedasBolsa(CantidadMonedasBolsaNiquel c)
        {

            try
            {
                _cantidad_monedas_niquel.eliminarCantidadMonedasBolsaNiquel(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todas la cantidad de bolsas registradas en 
        /// </summary>
        /// <returns>Lista de bolsas registradas en el sistema</returns>
        public BindingList<CantidadMonedasBolsaNiquel> listarCantidadMonedasBolsa()
        {

            try
            {
                return _cantidad_monedas_niquel.obtenerCantidadMonedasBolsaNiquel();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       

        #endregion Cantidad de Monedas por Bolsa

        #region Cantidad Tulas 

        /// <summary>
        /// Permite agregar una cantidad máxima de tulas y bolsas por manifiesto. 
        /// </summary>
        /// <param name="m"></param>
        public void agregarCantidadTulas(ref MaximasCantidades m)
        {
            try
            {
                _manifiesto_niquel.agregarMaximaCantidadTulas(ref m);
            }
            catch(Excepcion ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Actualiza la cantidad máxima de tulas y bolsas por manifiesto
        /// </summary>
        /// <param name="m">Objeto MaximasCantidades con los datos de las tulas y las bolsas</param>
        public void actualizarCantidadTulas(MaximasCantidades m)
        {
            try
            {
                _manifiesto_niquel.actualizarMaximaCantidadTulas(ref m);
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }




        /// <summary>
        /// Elimina la cantidad máxima de tulas y bolsas por manifiesto
        /// </summary>
        /// <param name="m">Objeto MaximasCantidades con los datos de las tulas y las bolsas</param>
        public void eliminarCantidadTulas(MaximasCantidades m)
        {
            try
            {
                _manifiesto_niquel.eliminarMaximaCantidadTulas(ref m);
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Obtiene las maximas cantidades de tulas y bosas por transportadora
        /// </summary>
        /// <returns>Lista de máximas cantidades. </returns>
        public BindingList<MaximasCantidades> obtenerCantidades()
        {
            try
            {
                return _manifiesto_niquel.listarMaximaCantidadTulas();
            }
            catch(Excepcion ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// Obtiene las maximas cantidades de tulas y bosas por transportadora
        /// </summary>
        /// <returns>Lista de máximas cantidades. </returns>
        public MaximasCantidades obtenerCantidadesTransportadora(EmpresaTransporte empresa)
        {
            try
            {
                return _manifiesto_niquel.obtenerMaximasCantidadTransportaodra(empresa);
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }
        #endregion Cantidad Tulas

        #region Inventario Cartuchos

        public void agregarInventarioCartucho(Inventario c, Colaborador usuario)
        {

            try
            {
                //if (_inventario.verificarInventario(c))
                //    throw new Excepcion("ErrorInventarioDuplicado");

                _inventario.agregarInventario(c, usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void actualizarInventarioCartucho(Inventario c, Colaborador usuario)
        {

            try
            {
                //if (_inventario.verificarInventario(c))
                //    throw new Excepcion("ErrorInventarioDuplicado");

                _inventario.actualizarInventario(ref c, usuario);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public BindingList<Inventario> listarInventarioCartuchos()
        {

            try
            {
                return _inventario.listarInventarioCartuchos();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion Inventario Cartuchos

        #region FallasPorCartucho

        public void verificarAlertaLimiteFallas()
        {
            try
            {
                if (_cartuchos.verificarLimiteFallas())
                    Mensaje.mostrarMensaje("MensajeLimiteFallas");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void agregarFallaPorCartucho(ref FallaCartucho g, ref Cartucho c, Colaborador usuario)
        {

            try
            {
                _cartuchos.agregarFallaCartucho(ref c, usuario, g);

                if (g.NoRecuperable == true)
                    c.Estado = EstadosCartuchos.NoRecuperable;
                else if (c.Estado == EstadosCartuchos.Bueno)
                    c.Estado = EstadosCartuchos.Malo;

                _cartuchos.actualizarCartuchoEstado(c, usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void eliminarFallaPorCartucho(FallaCartucho g, Cartucho c)
        {

            try
            {
                // _fallas.eliminarFallaPorCartucho(g,c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public BindingList<FallaCartucho> ObtenerFallasPorCartucho(Cartucho c)
        //{

        //    try
        //    {
        //       // BindingList<FallaCartucho> fallas = _fallas.listarFallaPorCartuchos(c);

        //      //  return fallas;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        #endregion FallasPorCartucho
        
        #region EstadoCartucho

        /// <summary>
        /// Registrar un nuevo estado de cartucho
        /// </summary>
        /// <param name="g">Objeto EstadoCartucho con los datos del nuevo estado</param>
        public void agregarEstadoCartucho(ref EstadoCartucho g)
        {

            try
            {
                _estados.agregarEstadoCartucho(ref g);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un estado
        /// </summary>
        /// <param name="g">Objeto Estado con los datos del estado a actualizar</param>
        public void actualizarEstadoCartucho(ref EstadoCartucho g)
        {

            try
            {
                _estados.actualizarEstadoCartucho(ref g);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un estado.
        /// </summary>
        /// <param name="t">Objeto Estado con los datos del estado a eliminar</param>
        public void eliminarEstadoCartucho(EstadoCartucho g)
        {

            try
            {
                _estados.eliminarEstadoCartucho(g);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todos los estados registradas en el sistema.
        /// </summary>
        /// <returns>Lista de los estados registrados en el sistema</returns>
        public BindingList<EstadoCartucho> listarEstadosCartucho(string nombre)
        {

            try
            {
                BindingList<EstadoCartucho> estados = _estados.listarEstadosCartucho(nombre);

                return estados;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion EstadoCartucho

        #region FallaCartucho

        /// <summary>
        /// Registrar una nueva falla de cartucho
        /// </summary>
        /// <param name="g">Objeto FallaCartucho con los datos de la nueva falla</param>
        public void agregarFallaCartucho(ref FallaCartucho g)
        {

            try
            {
                _fallas_cartuchos.agregarFallaCartucho(ref g);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de una falla
        /// </summary>
        /// <param name="g">Objeto Falla con los datos de la falla a actualizar</param>
        public void actualizarFallaCartucho(ref FallaCartucho g)
        {

            try
            {
                _fallas_cartuchos.actualizarFallaCartucho(ref g);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una falla.
        /// </summary>
        /// <param name="t">Objeto Falla con los datos de la falla a eliminar</param>
        public void eliminarFallaCartucho(FallaCartucho g)
        {

            try
            {
                _fallas_cartuchos.eliminarFallaCartucho(g);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todas las fallas registradas en el sistema.
        /// </summary>
        /// <returns>Lista de las fallas registrados en el sistema</returns>
        public BindingList<FallaCartucho> listarFallasCartucho()
        {

            try
            {
                BindingList<FallaCartucho> fallas = _fallas_cartuchos.listarFallaCartuchos(string.Empty);

                return fallas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void verificarFallaCartucho(ref FallaCartucho c)
        {
            _fallas_cartuchos.verificarFalla(ref c);
        }


        public bool verificarCartuchoFallas(ref Cartucho c)
        {
            bool existe = false;
            try
            {
                existe = _cartuchos.verificarCartuchoFallas(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return existe;
        }


        public DataTable ObtieneDatosFallasCartuchos(DateTime inicio, DateTime fin, FallaCartucho falla, int est, Cartucho c)
        {
            try
            {
                return _cartuchos.ObtenerDatosReporteFallas(inicio, fin, falla, est, c);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion FallaCartucho

        #region ProveedorCartucho

        /// <summary>
        /// Registrar un nuevo proveedor de cartucho
        /// </summary>
        /// <param name="g">Objeto ProveedorCartucho con los datos del nuevo proveedor</param>
        public void agregarProveedorCartucho(ref ProveedorCartucho g)
        {

            try
            {
                _proveedores.agregarProveedorCartucho(ref g);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un proveedor
        /// </summary>
        /// <param name="g">Objeto Proveedor con los datos del proveedor a actualizar</param>
        public void actualizarProveedorCartucho(ref ProveedorCartucho g)
        {

            try
            {
                _proveedores.actualizarProveedorCartucho(ref g);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un proveedor.
        /// </summary>
        /// <param name="t">Objeto Proveedor con los datos del proveedor a eliminar</param>
        public void eliminarProveedorCartucho(ProveedorCartucho g)
        {

            try
            {
                _proveedores.eliminarProveedorCartucho(g);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todos los proveedores registradas en el sistema.
        /// </summary>
        /// <returns>Lista de los proveedores registrados en el sistema</returns>
        public BindingList<ProveedorCartucho> listarProveedorCartucho(string nombre)
        {

            try
            {
                BindingList<ProveedorCartucho> proveedores = _proveedores.listarProveedorCartuchos(nombre);

                return proveedores;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public ProveedorCartucho obtenerDatosProveedor(ref ProveedorCartucho p)
        {

            try
            {
                return _proveedores.obtenerDatosProveedor(ref p);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        #endregion ProveedorCartucho

        #region GarantiaCartucho

        public BindingList<GarantiaCartucho> listarGarantiaCartucho()
        {

            try
            {
                BindingList<GarantiaCartucho> garantias = _garantias.listarGarantiaCartuchos(string.Empty);

                return garantias;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void agregarGarantiaCartucho(ref GarantiaCartucho g)
        {

            try
            {
                _garantias.agregarGarantiaCartucho(ref g);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void actualizarGarantiaCartucho(ref GarantiaCartucho g)
        {

            try
            {
                _garantias.actualizarGarantiaCartucho(ref g);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void eliminarGarantiaCartucho(GarantiaCartucho g)
        {

            try
            {
                _garantias.eliminarGarantiaCartucho(g);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion GarantiaCartucho

        #region CalidadBilletes

        public BindingList<CalidadBilletes> listarCalidadBilletes(string nombre)
        {

            try
            {
                BindingList<CalidadBilletes> calidad = _calidad.listarCalidadBilletes(nombre);

                return calidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Registrar una nueva calidad de billetes.
        /// </summary>
        /// <param name="e">Objeto CalidadBilletes con los datos de la nueva calidad</param>
        public void agregarCalidadBilletes(ref CalidadBilletes e)
        {

            try
            {
                _calidad.agregarCalidadBilletes(ref e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de una calidad de billetes.
        /// </summary>
        /// <param name="e">Objeto CalidadBilletes con los datos de la calidad a actualizar</param>
        public void actualizarCalidadBilletes(CalidadBilletes e)
        {

            try
            {
                _calidad.actualizarCalidadBilletes(ref e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void eliminarCalidadBilletes(CalidadBilletes e)
        {

            try
            {
                _calidad.eliminarCalidadBilletes(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion CalidadBilletes

        #region Esperas


        /// <summary>
        /// Registrar una nueva espera.
        /// </summary>
        /// <param name="c">Objeto Espera con los datos de la nueva espera</param>
        public void agregarEspera(ref Espera c)
        {

            try
            {
                _espera.agregarEspera(ref c); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de una espera.
        /// </summary>
        /// <param name="c">Objeto Espera con los datos de la espera a actualizar</param>
        public void actualizarEspera(Espera c)
        {

            try
            {
                _espera.actualizarEspera(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una espera.
        /// </summary>
        /// <param name="c">Objeto Espera con los datos de la espera a eliminar</param>
        public void eliminarEspera(Espera c)
        {

            try
            {
                _espera.eliminarEspera(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todas las esperas registradas.
        /// </summary>
        /// <returns>Lista de esperas registradas en el sistema</returns>
        public BindingList<Espera> listarEsperas()
        {

            try
            {
                return _espera.listarEsperas();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

     

        #endregion Esperas

        #region Tipo Fallas Blindados

        /// <summary>
        /// Registrar una nueva TipoFallasBlindados.
        /// </summary>
        /// <param name="c">Objeto TipoFallasBlindados con los datos de la nueva TipoFallasBlindados</param>
        public void agregarTipoFallasBlindados(ref TipoFallasBlindados c)
        {

            try
            {
                _tipo_falla.agregarTipoFallasBlindados(ref c); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de una TipoFallasBlindados.
        /// </summary>
        /// <param name="c">Objeto TipoFallasBlindados con los datos de la TipoFallasBlindados a actualizar</param>
        public void actualizarTipoFallasBlindados(TipoFallasBlindados c)
        {

            try
            {
                _tipo_falla.actualizarTipoFallasBlindados(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de una TipoFallasBlindados.
        /// </summary>
        /// <param name="c">Objeto TipoFallasBlindados con los datos de la TipoFallasBlindados a eliminar</param>
        public void eliminarTipoFallasBlindados(TipoFallasBlindados c)
        {

            try
            {
                _tipo_falla.eliminarTipoFallasBlindados(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todas las TipoFallasBlindadoss registradas.
        /// </summary>
        /// <returns>Lista de TipoFallasBlindadoss registradas en el sistema</returns>
        public BindingList<TipoFallasBlindados> listarTipoFallasBlindadoss()
        {

            try
            {
                return _tipo_falla.listarTipoFallasBlindadoss();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion Tipo Fallas Blindados

        #region Arqueos

        public void importarArqueo(Arqueo p, Colaborador usuario)
        {

            try
            {
                Arqueo copia_arqueo = p;

                _arqueos.agregarArqueo(ref copia_arqueo, usuario);

                foreach (DenominacionArqueo denominacion in copia_arqueo.Denominaciones)
                {
                    DenominacionArqueo copia_denominacion = denominacion;

                    _arqueos.agregarDenominacion(ref copia_denominacion, copia_arqueo);
                }
            }
            catch (Exception)
            {
                throw new Excepcion("ErrorArqueoImportacion");
            }

        }

        public BindingList<Arqueo> listarArqueos(DateTime? inicio = null, DateTime? fin = null)
        {

            try
            {
                BindingList<Arqueo> arqueos = _arqueos.listarArqueos(inicio, fin);
                foreach (Arqueo a in arqueos)
                {
                    Arqueo copia = a;
                    _arqueos.buscarDenominaciones(ref copia);
                }
                return arqueos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion Arqueos

        #region Arqueo Níquel

        public void importarArqueoNiquel(Arqueo p, Colaborador usuario)
        {

            try
            {
                Arqueo copia_arqueo = p;

                _arqueos.agregarArqueoNiquel(ref copia_arqueo, usuario);

                foreach (DenominacionArqueo denominacion in copia_arqueo.Denominaciones)
                {
                    DenominacionArqueo copia_denominacion = denominacion;

                    _arqueos.agregarDenominacionNiquel(ref copia_denominacion, copia_arqueo);
                }
            }
            catch (Exception)
            {
                throw new Excepcion("ErrorArqueoRegistro");
            }

        }

        public BindingList<Arqueo> listarArqueosNiquel(DateTime fecha)
        {

            try
            {
                BindingList<Arqueo> arqueos = _arqueos.listarArqueosNiquel(fecha);
                foreach (Arqueo a in arqueos)
                {
                    Arqueo copia = a;
                    _arqueos.buscarDenominacionesNiquel(ref copia, fecha);
                }
                return arqueos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion Arqueo Níquel 

        #region Arqueo Bóveda

        public void importarArqueoBoveda(Arqueo p, Colaborador usuario)
        {

            try
            {
                Arqueo copia_arqueo = p;

                _arqueos.agregarArqueoBoveda(ref copia_arqueo, usuario);

                foreach (DenominacionArqueo denominacion in copia_arqueo.Denominaciones)
                {
                    DenominacionArqueo copia_denominacion = denominacion;

                    _arqueos.agregarDenominacionBoveda(ref copia_denominacion, copia_arqueo);
                }
            }
            catch (Exception)
            {
                throw new Excepcion("ErrorArqueoRegistro");
            }

        }

        public BindingList<Arqueo> listarArqueosBoveda(DateTime fecha)
        {

            try
            {
                BindingList<Arqueo> arqueos = _arqueos.listarArqueosBoveda(fecha);
                foreach (Arqueo a in arqueos)
                {
                    Arqueo copia = a;
                    _arqueos.buscarDenominacionesBoveda(ref copia, fecha);
                }
                return arqueos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion Arqueo Bóveda
        
        #region Saldo Libro Bóveda

        /// <summary>
        /// Agrega un saldo en libro
        /// </summary>
        /// <param name="s">Objeto SaldoLibroBoveda con los datos del saldo</param>
        public void agregarSaldoLibro(ref SaldoLibroBoveda s)
        {
            try
            {
                _saldos_libros.agregarSaldoLibroBoveda(ref s);
            }
            catch(Excepcion ex)
            {
                throw ex; 
            }
        }


        /// <summary>
        /// Actualiza los saldos de los libros
        /// </summary>
        /// <param name="s"></param>
        public void actualizarSaldoLibros(SaldoLibroBoveda s)
        {
            try
            {
                _saldos_libros.actualizarSaldoLibroBoveda(s);
            }
            catch(Excepcion ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// Lista los saldos de los libros de alguna determinada fecha
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public BindingList<SaldoLibroBoveda> listarSaldosLibros(DateTime fecha)
        {

            try
            {
                BindingList<SaldoLibroBoveda> arqueos = _saldos_libros.listarSaldoLibroBoveda(fecha);
                return arqueos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Agrega un saldo en libro
        /// </summary>
        /// <param name="s">Objeto SaldoLibroBoveda con los datos del saldo</param>
        public void agregarSaldoLibroFinal(ref SaldoLibroBoveda s)
        {
            try
            {
                _saldos_libros.agregarSaldoLibroBovedaFinal(ref s);
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Actualiza los saldos de los libros
        /// </summary>
        /// <param name="s"></param>
        public void actualizarSaldoLibrosFinal(SaldoLibroBoveda s)
        {
            try
            {
                _saldos_libros.actualizarSaldoLibroBovedaFinal(s);
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// Lista los saldos de los libros de alguna determinada fecha
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public BindingList<SaldoLibroBoveda> listarSaldosLibrosFinal(DateTime fecha, Colaborador usuario)
        {

            try
            {
                BindingList<SaldoLibroBoveda> arqueos = _saldos_libros.listarSaldoLibroBovedaFinal(fecha, usuario);
                return arqueos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion Saldo Libro Bóveda

        #region Saldo Libro Níquel

        /// <summary>
        /// Agrega un saldo en libro
        /// </summary>
        /// <param name="s">Objeto SaldoLibroBoveda con los datos del saldo</param>
        public void agregarSaldoLibroNiquel(ref SaldoLibroBoveda s)
        {

            try
            {
                _saldos_niquel.agregarSaldoLibroNiquel(ref s);
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Actualiza los saldos de los libros
        /// </summary>
        /// <param name="s"></param>
        public void actualizarSaldoLibrosNiquel(SaldoLibroBoveda s)
        {
            try
            {
                _saldos_libros.actualizarSaldoLibroBoveda(s);
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// Lista los saldos de los libros de alguna determinada fecha
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public BindingList<SaldoLibroBoveda> listarSaldosLibrosNiquel(DateTime fecha)
        {

            try
            {
                BindingList<SaldoLibroBoveda> arqueos = _saldos_niquel.listarSaldoLibroNiquel(fecha);
                return arqueos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Agrega un saldo en libro
        /// </summary>
        /// <param name="s">Objeto SaldoLibroBoveda con los datos del saldo</param>
        public void agregarSaldoLibroFinalNiquel(ref SaldoLibroBoveda s)
        {
            try
            {
                _saldos_libros.agregarSaldoLibroBovedaFinal(ref s);
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Actualiza los saldos de los libros
        /// </summary>
        /// <param name="s"></param>
        public void actualizarSaldoLibrosFinalNiquel(SaldoLibroBoveda s)
        {
            try
            {
                _saldos_libros.actualizarSaldoLibroBovedaFinal(s);
            }
            catch (Excepcion ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Lista los saldos de los libros de alguna determinada fecha
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public BindingList<SaldoLibroBoveda> listarSaldosLibrosFinalNiquel(DateTime fecha, Colaborador usuario)
        {
            try
            {
                BindingList<SaldoLibroBoveda> arqueos = _saldos_niquel.listarSaldoLibroNiquelFinal(fecha, usuario);
                return arqueos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        

        #region ProveedorEquipo

        /// <summary>
        /// Registrar un nuevo proveedor de cartucho
        /// </summary>
        /// <param name="g">Objeto ProveedorCartucho con los datos del nuevo proveedor</param>
        public void agregarProveedorEquipo(ref ProveedorEquipo g)
        {

            try
            {
                _proveedoresEquipos.agregarProveedorEquipo(ref g);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un proveedor
        /// </summary>
        /// <param name="g">Objeto Proveedor con los datos del proveedor a actualizar</param>
        public void actualizarProveedorEquipo(ref ProveedorEquipo g)
        {

            try
            {
                _proveedoresEquipos.actualizarProveedorEquipo(ref g);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un proveedor.
        /// </summary>
        /// <param name="t">Objeto Proveedor con los datos del proveedor a eliminar</param>
        public void eliminarProveedorEquipo(ProveedorEquipo g)
        {

            try
            {
                _proveedoresEquipos.eliminarProveedorEquipo(g);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todos los proveedores registradas en el sistema.
        /// </summary>
        /// <returns>Lista de los proveedores registrados en el sistema</returns>
        public BindingList<ProveedorEquipo> listarProveedorEquipo(string nombre)
        {

            try
            {
                BindingList<ProveedorEquipo> proveedores = _proveedoresEquipos.listarProveedorEquipos(nombre);

                return proveedores;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ProveedorEquipo obtenerDatosProveedorEquipo(ref ProveedorEquipo p)
        {

            try
            {
                return _proveedoresEquipos.obtenerDatosProveedor(ref p);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion ProveedorCartucho

        #region Equipos de Tesoreria

        public void agregarEquipoTesoreria(ref EquipoTesoreria e)
        {

            try
            {
                _equiposTesoreria.agregarEquipoTesoreria(ref e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void actualizarEquipoTesoreria(EquipoTesoreria e)
        {

            try
            {
                _equiposTesoreria.actualizarEquipoTesoreria(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void eliminarEquipoTesoreria(EquipoTesoreria e)
        {
            try
            {
                _equiposTesoreria.eliminarEquipoTesoreria(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public BindingList<EquipoTesoreria> listarEquiposTesoreria()
        {

            try
            {
                return _equiposTesoreria.listarEquiposTesoreria(string.Empty);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public EquipoTesoreria obtenerDatosEquipoTesoreria(ref EquipoTesoreria e)
        //{
        //    try
        //    {
        //        return _equiposTesoreria.(ref e);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        #endregion Equipos de Tesoreria

        #region Ficha Tecnica

        public void agregarFichaTecnica(ref FichaTecnica e)
        {

            try
            {
                _fichaTecnica.agregarFichaTecnica(ref e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void actualizarFichaTecnica(FichaTecnica e)
        {

            try
            {
                _fichaTecnica.actualizarFichaTecnica(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void eliminarFichaTecnica(FichaTecnica e)
        {
            try
            {
                _fichaTecnica.eliminarFichaTecnica(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public BindingList<FichaTecnica> listarFichasTecnicas(DateTime? inicio = null, DateTime? fin = null, ProveedorEquipo prov = null, EquipoTesoreria equipo = null)
        {

            try
            {
                return _fichaTecnica.listarFichasTecnicas(inicio, fin, prov, equipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion Ficha Tecnica

        #region Requerimiento Mantenimiento

        public void agregarRequerimientoMantenimiento(ref RequerimientoMantenimiento e)
        {

            try
            {
                _requerimientos.agregarRequerimientoMantenimiento(ref e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void actualizarRequerimientoMantenimiento(RequerimientoMantenimiento e)
        {

            try
            {
                _requerimientos.actualizarRequerimientoMantenimiento(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void eliminarRequerimientoMantenimiento(RequerimientoMantenimiento e)
        {
            try
            {
                _requerimientos.eliminarRequerimientoMantenimiento(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public BindingList<RequerimientoMantenimiento> listarRequerimientosMantenimiento(DateTime? inicio = null, DateTime? fin = null)
        {

            try
            {
                return _requerimientos.listarRequerimientosMantenimiento(null, inicio, fin);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Requerimiento Mantenimiento

        #region Caja

        public void agregarCaja(ref Caja e, Colaborador usuario)
        {

            try
            {
                _cajas.agregarCaja(ref e, usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void actualizarCaja(Caja e)
        {

            try
            {
                _cajas.actualizarCaja(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void eliminarCaja(Caja e)
        {
            try
            {
                _cajas.eliminarCaja(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public BindingList<Caja> listarCajas(Decimal numero)
        {

            try
            {
                return _cajas.listarCajas(numero);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Caja



        #endregion Salido Libro Níquel


        //PROA
        #region LimiteEfectivo

        /// <summary>
        /// Registrar una nuevo límite de efectivo.
        /// </summary>
        /// <param name="c">Objeto LimiteEfectivo con los datos del nuevo límite de efectivo</param>
        public void agregarLimiteEfectivo(ref LimiteEfectivo c)
        {

            try
            {
                _limite_efectivo.agregarLimiteEfectivo(ref c); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un límite de efectivo.
        /// </summary>
        /// <param name="c">Objeto LimiteEfectivo con los datos del límite de efectivo a actualizar</param>
        public void actualizarLimiteEfectivo(LimiteEfectivo c)
        {

            try
            {
                _limite_efectivo.actualizarLimiteEfectivo(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un límite de efectivo.
        /// </summary>
        /// <param name="c">Objeto LimiteEfectivo con los datos del límite de efectivo a actualizar</param>
        public void actualizarLimiteEfectivo2(LimiteEfectivo c)
        {

            try
            {
                _limite_efectivo.actualizarLimiteEfectivoTodos(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todos los registros de límites de efectivo asociado a cajeros.
        /// </summary>
        /// <returns>Lista de registros de límites de efectivo asociado a cajeros en el sistema</returns>
        public BindingList<LimiteEfectivo> listarLimiteEfectivos(int c)
        {

            try
            {
                return _limite_efectivo.listarLimiteEfectivo(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable listarMonitoreoLimiteEfectivo(int c)
        {

            try
            {
                return _limite_efectivo.listarMonitoreoLimiteEfectivo(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion LimiteEfectivo

        #region ProcesamientoBajoVolumen

        /// <summary>
        /// Registrar un nuevo registro de procesamiento de bajo volumen.
        /// </summary>
        /// <param name="c">Objeto Procesamiento bajo volumen con los datos del nuevo registro de procesamiento</param>
        public void agregarProcesamientoBajoVolumen(ref ProcesamientoBajoVolumen c)
        {

            try
            {
                _procesamiento_bajo_volumen.agregarProcesamientoBajoVolumen(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void agregarPendienteProcesamientoBajoVolumenManifiesto(ref ProcesamientoBajoVolumenManifiesto c, ref Colaborador d)
        {

            try
            {
                _procesamiento_bajo_volumen.agregarPendienteProcesamientoBajoVolumenManifiesto(ref c, ref d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Boolean VerificaTulaAV(ProcesamientoAltoVolumenDetalle c) //Cambio GZH 23/11/2017
        {
            try
            {
                int conteotulas = _procesamiento_alto_volumen.verificaTulaAltoVolumen(c);
                if (conteotulas > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Boolean VerificaTulasManifiestoAV(ref Manifiesto d, int conteotulas2) //Cambio GZH 27/10/2017
        {
            try
            {
                int conteotulas = _procesamiento_alto_volumen.verificaTulasManifiesto(d);
                if (conteotulas == conteotulas2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void eliminarProcesamientoAltoVolumen(ProcesamientoAltoVolumen d, Colaborador e) //Cambios GZH 02/11/2017
        {

            try
            {
                _procesamiento_alto_volumen.eliminarProcesamientoAltoVolumen(d, e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ProcesamientoAltoVolumen obtenerProcesamientoAltoVolumenManifiesto(string manifiesto) //Cambios GZH 01/11/2017
        {

            try
            {
                return _procesamiento_alto_volumen.ObtenerInfoProcesoAltoVolumenManifiesto(manifiesto);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void actualizarProcesamientoAltoVolumenDetalle(ProcesamientoAltoVolumenDetalle c, Colaborador d) //Cambios GZH 02/11/2017
        {

            try
            {
                _procesamiento_alto_volumen.actualizarProcesamientoAltoVolumenDetalle(c, d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void actualizarProcesamientoAltoVolumen(ProcesamientoAltoVolumen c, Colaborador d) //Cambio GZH 02/11/2017
        {

            try
            {
                _procesamiento_alto_volumen.actualizarProcesamientoAltoVolumen(c, d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public int verificacierrecajero(ref CierreCajeroPROA cierrecajero)
        {
            _cierrecajero.VerificaCierreCajero(ref cierrecajero);
            return cierrecajero.ID;
        }

        public int verificacierrecajeroNiquel(ref CierreCajeroPROA cierrecajero)
        {
            _cierrecajero.VerificaCierreCajeroNiquel(ref cierrecajero);
            return cierrecajero.ID;
        }

        public void agregarinfocierrecajero(ref CierreCajeroPROA cierrecajero)
        {


            _cierrecajero.agregarCierre(ref cierrecajero);
        }

        public void agregarinfocierrecajero2(ref CierreCajeroPROA cierrecajero, int idcoordinador)
        {
            _cierrecajero.agregarCierre2(ref cierrecajero, idcoordinador);
        }

        public void agregarinfocierrecajeroNiquel(ref CierreCajeroPROA cierrecajero)
        {
            _cierrecajero.agregarCierreNiquel(ref cierrecajero);
        }

        public void agregarinfocierrecajeroNiquel2(ref CierreCajeroPROA cierrecajero, int idcoordinador)
        {
            _cierrecajero.agregarCierreNiquel2(ref cierrecajero, idcoordinador);
        }


        /// <summary>
        /// Actualizar los datos de un registro de procesamiento de bajo volumen.
        /// </summary>
        /// <param name="c">Objeto Procesamiento bajo volumen con los datos del procesamiento a actualizar</param>
        public void actualizarProcesamientoBajoVolumen(ref ProcesamientoBajoVolumen c)
        {

            try
            {
                _procesamiento_bajo_volumen.actualizarProcesamientoBajoVolumen(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public BindingList<ProcesamientoBajoVolumen> listarProcesamientoBajoVolumen()
        {

            try
            {
                return _procesamiento_bajo_volumen.listarProcesamientoBajoVolumen();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ProcesamientoBajoVolumen listarProcesamientoBajoVolumenCajero(ref Colaborador c)
        {

            try
            {
                return _procesamiento_bajo_volumen.listarProcesamientoBajoVolumenCajero(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public BindingList<ProcesamientoBajoVolumenDeposito> listarProcesamientoBajoVolumenDeposito(ProcesamientoBajoVolumenManifiesto c)
        {

            try
            {
                return _procesamiento_bajo_volumen.listarProcesamientoBajoVolumenDeposito(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Registrar una nueva relación de manifiesto con procesamiento de bajo volumen.
        /// </summary>
        /// <param name="c">Objeto Procesamiento bajo volumen con los datos del registro de procesamiento</param>
        /// <param name="d">Objeto Manifiesto con los datos del Manifiesto</param>
        public void agregarProcesamientoBajoVolumenManifiesto(ref ProcesamientoBajoVolumenManifiesto d, Colaborador col)
        {

            try
            {
                _procesamiento_bajo_volumen.agregarManifiestoProcesamientoBajoVolumenManifiesto(ref d, col);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void actualizarProcesamientoBajoVolumenManifiesto(ref ProcesamientoBajoVolumenManifiesto d)
        {

            try
            {
                _procesamiento_bajo_volumen.actualizarManifiestoProcesamientoBajoVolumenManifiesto(ref d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void cerrarProcesamientoBajoVolumenManifiesto(ref ProcesamientoBajoVolumenManifiesto d)
        {

            try
            {
                _procesamiento_bajo_volumen.cerrarManifiestoProcesamientoBajoVolumenManifiesto(d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void agregarPendienteProcesamientoBajoVolumenTula(ref ProcesamientoBajoVolumenManifiesto d, ref Tula e)
        {

            try
            {
                _procesamiento_bajo_volumen.agregarPendienteProcesamientoBajoVolumenTula(ref d, ref e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void EliminarPendienteProcesamientoBajoVolumenTula(ref Tula e)
        {

            try
            {
                _procesamiento_bajo_volumen.eliminarPendienteProcesamientoBajoVolumenTula(ref e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int agregarProcesamientoBajoVolumenDeposito(ref ProcesamientoBajoVolumen c, ref ProcesamientoBajoVolumenManifiesto d, ref Tula t, ref Deposito e, ref Monedas m, int coordinador)
        {

            try
            {
                return _procesamiento_bajo_volumen.agregarDepositoProcesamientoBajoVolumen(d, c, t, e, m, coordinador);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void agregarConteoBilleteBajoVolumenDeposito(ref ConteoBillete billete)
        {

            try
            {
                _procesamiento_bajo_volumen.agregarConteoBilleteProcesamientoBajoVolumen(ref billete);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void agregarInconsistenciaProcesamientoBajoVolumenDeposito(ref ProcesamientoBajoVolumenManifiesto d, ref Tula t, ref Deposito e, ref Monedas m, byte origendiferencia, DateTime finconsistencia)
        {

            try
            {
                _procesamiento_bajo_volumen.agregarInconsistenciaProcesamientoBajoVolumenDeposito(d, t, e, m, origendiferencia, finconsistencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void agregarInconsistenciaInfoProcesamientoBajoVolumenDeposito(ref Deposito e, ref Monedas m, DateTime finconsistencia)
        {

            try
            {
                _procesamiento_bajo_volumen.agregarInconsistenciaInfoProcesamientoBajoVolumenDeposito(e, m, finconsistencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DateTime obtenerProcesamientoBajoVolumenDeposito(int iddeposito)
        {

            try
            {
                return _procesamiento_bajo_volumen.obtenerProcesamientoBajoVolumenDeposito(iddeposito);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int agregarCompraVentaDeposito(ref CompraVenta c, ref Deposito d)
        {

            try
            {
                return _procesamiento_bajo_volumen.agregarCompraVentaDeposito(c, d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int agregarChequeDeposito(ref ChequeDeposito c, ref Deposito d)
        {

            try
            {
                return _procesamiento_bajo_volumen.agregarChequeDeposito(c, d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int agregarBilleteFalsoDeposito(ref BilleteFalso c, ref Deposito d)
        {

            try
            {
                return _procesamiento_bajo_volumen.agregarBilleteFalsoDeposito(c, d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ProcesamientoBajoVolumenManifiesto VerificaManifiestoPendiente(int cajero)
        {
            try
            {
                ProcesamientoBajoVolumenManifiesto manifiestopendiente = _procesamiento_bajo_volumen.verificaManifiestoPendiente(cajero);
                return manifiestopendiente;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int VerificaTulaPendiente(int idmanifiesto)
        {
            try
            {
                int manifiestopendiente = _procesamiento_bajo_volumen.verificaTulaPendiente(idmanifiesto);
                return manifiestopendiente;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Boolean VerificaTulasManifiesto(ref ProcesamientoBajoVolumenManifiesto d)
        {
            int conteotulas = 0;
            try
            {
                conteotulas = _procesamiento_bajo_volumen.verificaTulasManifiesto(d);
                if (conteotulas == d.Tulas.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int RegistrarInconsistenciaBajoVolumenManifiesto(ref ProcesamientoBajoVolumenManifiesto m, ref Colaborador c, String Detalle, Monedas moneda)
        {
            try
            {
                return _procesamiento_bajo_volumen.agregarProaInconsistenciaManifiesto(m, c, moneda, Detalle);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int VerificaCuentaReferenciaDeposito(String Cuenta, Monedas m, ProcesamientoBajoVolumenManifiesto ma)
        {
            try
            {
                return _procesamiento_bajo_volumen.VerificaCuentaReferenciaDeposito(Cuenta, m, ma);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Decimal VerificaMontoManifiesto(ref ProcesamientoBajoVolumenManifiesto d)
        {
            try
            {
                /*decimal MontoTotal = 0;
                decimal Diferencia = 0;*/
                BindingList<Tula> tulas = d.Tulas;
                TipoCambio _tipocambio = null;
                _tipocambio = obtenerTipoCambio(DateTime.Today);
                if (_tipocambio == null)
                {
                    _tipocambio = obtenerTipoCambio(DateTime.Today.AddDays(-1));
                }
                if (_tipocambio == null)
                {
                    Exception ex = new Exception("No se encontró tipo de cambio de hoy o de ayer, favor actualizar el tipo de cambio y volver a reiniciar la aplicación");
                    throw ex;
                }
                foreach (Tula tula in tulas)
                {
                    BindingList<Deposito> depositos = tula.Deposito;
                    foreach (Deposito deposito in depositos)
                    {
                        /*if (deposito.Moneda != d.Monedas)
                        {
                            TipoCambio _tipocambio = null;
                            _tipocambio = obtenerTipoCambio(DateTime.Today.AddDays(-1));
                            switch (d.Monedas)
                            {
                                case Monedas.Colones:
                                    switch (deposito.Moneda)
                                    {
                                        case Monedas.Dolares:
                                            MontoTotal += _tipocambio.Compra * deposito.Monto;
                                            break;
                                        case Monedas.Euros:
                                            MontoTotal += _tipocambio.CompraEuros * deposito.Monto;
                                            break;
                                    }
                                    break;
                                case Monedas.Dolares:
                                    switch (deposito.Moneda)
                                    {
                                        case Monedas.Colones:
                                            MontoTotal += deposito.Monto /_tipocambio.Venta;
                                            break;
                                        case Monedas.Euros:
                                            MontoTotal += (deposito.Monto *_tipocambio.CompraEuros) / _tipocambio.Venta;
                                            break;
                                    }
                                    break;
                                case Monedas.Euros:
                                    switch (deposito.Moneda)
                                    {
                                        case Monedas.Colones:
                                            MontoTotal += deposito.Monto / _tipocambio.VentaEuros;
                                            break;
                                        case Monedas.Dolares:
                                            MontoTotal += (deposito.Monto * _tipocambio.Compra) / _tipocambio.VentaEuros;
                                            break;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            MontoTotal += deposito.Monto;
                        }*/
                        switch (deposito.Moneda)
                        {
                            case Monedas.Colones:
                                d.Monto_Contado_Colones += deposito.MontoDeclarado;
                                d.Monto_Diferencia_Colones = d.Monto_Contado_Colones - d.Monto_Colones;
                                break;
                            case Monedas.Dolares:
                                /*d.Monto_Contado_Dolares += deposito.Monto;
                                d.Monto_Diferencia_Dolares = d.Monto_Contado_Dolares - d.Monto_Dolares;*/
                                d.Monto_Contado_Colones += _tipocambio.Compra * deposito.MontoDeclarado;
                                d.Monto_Diferencia_Colones = d.Monto_Contado_Colones - d.Monto_Colones;
                                break;
                            case Monedas.Euros:
                                d.Monto_Contado_Colones += _tipocambio.CompraEuros * deposito.MontoDeclarado;
                                d.Monto_Diferencia_Colones = d.Monto_Contado_Colones - d.Monto_Colones;
                                /*d.Monto_Contado_Euros += deposito.Monto;
                                d.Monto_Diferencia_Euros = d.Monto_Contado_Euros - d.Monto_Euros;*/
                                break;
                        }
                    }
                }

                /*if (d.Monto == MontoTotal)
                {
                    return Diferencia;   
                }
                else
                {
                    Diferencia = MontoTotal - d.Monto;
                    //_procesamiento_bajo_volumen.agregarProaInconsistenciaManifiesto(d, c, Diferencia, MontoTotal, "");
                    return Diferencia;  
                }*/
                if ((d.Monto_Diferencia_Colones != 0) || (d.Monto_Diferencia_Dolares != 0) || (d.Monto_Diferencia_Euros != 0))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public string GeneraInformacionMontoManifiesto(ref ProcesamientoBajoVolumenManifiesto d) //cambios GZH 25 AGOSTO 2017
        {
            try
            {
                //decimal MontoTotal = 0;
                //decimal diferencia = 0;
                DataTable datosdeposito = _procesamiento_bajo_volumen.ObtenerInformacionPantallaResumenManifiesto(d);
                //BindingList<Tula> tulas = d.Tulas;
                string tulaactual = "";
                string texto = "";
                d.Monto_Contado_Colones = 0;
                d.Monto_Diferencia_Colones = 0;
                d.Monto_Contado_Dolares = 0;
                d.Monto_Diferencia_Dolares = 0;
                d.Monto_Contado_Euros = 0;
                d.Monto_Diferencia_Euros = 0;
                for (int i = 0; i < datosdeposito.Rows.Count; i++)
                {
                    if (!tulaactual.Equals(datosdeposito.Rows[i]["Codigo"].ToString()))
                    {
                        tulaactual = datosdeposito.Rows[i]["Codigo"].ToString();
                        texto += "Tula " + datosdeposito.Rows[i]["Codigo"].ToString() + "\n\n";
                    }
                    TipoCambio _tipocambio = null;
                    switch (datosdeposito.Rows[i]["Moneda"].ToString())
                    {
                        case "Colones":
                            d.Monto_Contado_Colones += (Decimal)datosdeposito.Rows[i]["Monto_Declarado_Deposito"];
                            d.Monto_Diferencia_Colones = d.Monto_Contado_Colones - (Decimal)datosdeposito.Rows[i]["Monto_Declarado_Colones"];
                            break;
                        case "Dolares":
                            //d.Monto_Contado_Dolares += deposito.Monto;                                
                            _tipocambio = obtenerTipoCambio(DateTime.Today);
                            if (_tipocambio == null)
                                _tipocambio = obtenerTipoCambio(DateTime.Today.AddDays(-1));
                            d.Monto_Contado_Colones += (_tipocambio.Compra * (Decimal)datosdeposito.Rows[i]["Monto_Declarado_Deposito"]);
                            d.Monto_Diferencia_Colones = d.Monto_Contado_Colones - (Decimal)datosdeposito.Rows[i]["Monto_Declarado_Colones"];
                            //d.Monto_Diferencia_Dolares = d.Monto_Contado_Dolares - d.Monto_Dolares;
                            break;
                        case "Euros":
                            _tipocambio = obtenerTipoCambio(DateTime.Today);
                            if (_tipocambio == null)
                                _tipocambio = obtenerTipoCambio(DateTime.Today.AddDays(-1));
                            d.Monto_Contado_Colones += (_tipocambio.CompraEuros * (Decimal)datosdeposito.Rows[i]["Monto_Declarado_Deposito"]);
                            d.Monto_Diferencia_Colones = d.Monto_Contado_Colones - (Decimal)datosdeposito.Rows[i]["Monto_Declarado_Colones"];
                            //d.Monto_Contado_Euros += deposito.Monto;                                
                            //d.Monto_Diferencia_Euros = d.Monto_Contado_Euros - d.Monto_Euros;
                            break;
                    }
                    texto += "Depósito #" + datosdeposito.Rows[i]["Numero_deposito"].ToString() + ",Declarado: " + datosdeposito.Rows[i]["Monto_Declarado_Deposito"].ToString() + ", Contado: " + datosdeposito.Rows[i]["Monto_Contado_Deposito"].ToString() + ", Moneda: " + datosdeposito.Rows[i]["Moneda"].ToString() + "\n";
                }
                texto += "\n";
                //foreach (Tula tula in tulas)
                //{
                //    texto += "Tula " + tula.Codigo + "\n\n";
                //    BindingList<Deposito> depositos = tula.Deposito;
                //    TipoCambio _tipocambio = null;
                //    foreach (Deposito deposito in depositos)
                //    {
                //        switch (deposito.Moneda)
                //        {
                //            case Monedas.Colones:
                //                d.Monto_Contado_Colones += deposito.MontoDeclarado;
                //                d.Monto_Diferencia_Colones = d.Monto_Contado_Colones - d.Monto_Colones;
                //                break;
                //            case Monedas.Dolares:
                //                //d.Monto_Contado_Dolares += deposito.Monto;                                
                //                _tipocambio = obtenerTipoCambio(DateTime.Today);
                //                if (_tipocambio == null)
                //                    _tipocambio = obtenerTipoCambio(DateTime.Today.AddDays(-1));
                //                d.Monto_Contado_Colones += (_tipocambio.Compra * deposito.MontoDeclarado);
                //                d.Monto_Diferencia_Colones = d.Monto_Contado_Colones - d.Monto_Colones;
                //                //d.Monto_Diferencia_Dolares = d.Monto_Contado_Dolares - d.Monto_Dolares;
                //                break;
                //            case Monedas.Euros:
                //                _tipocambio = obtenerTipoCambio(DateTime.Today);
                //                if (_tipocambio == null)
                //                    _tipocambio = obtenerTipoCambio(DateTime.Today.AddDays(-1));
                //                d.Monto_Contado_Colones += (_tipocambio.CompraEuros * deposito.MontoDeclarado);
                //                d.Monto_Diferencia_Colones = d.Monto_Contado_Colones - d.Monto_Colones;
                //                //d.Monto_Contado_Euros += deposito.Monto;                                
                //                //d.Monto_Diferencia_Euros = d.Monto_Contado_Euros - d.Monto_Euros;
                //                break;
                //        }

                //    texto += "Depósito #" + deposito.NumeroDeposito + ",Declarado: " + deposito.MontoDeclarado + ", Contado: " + deposito.Monto.ToString() + ", Moneda: " + deposito.Moneda.ToString() + "\n";
                //}
                //    texto += "\n";
                //}
                //diferencia = MontoTotal - d.Monto;
                texto += "Monto Sumatoria de Depòsitos colonizados del manifiesto: " + d.Monto_Contado_Colones + "\n";
                texto += "Monto Declarado Manifiesto en Colones : " + d.Monto_Colones.ToString() + "\n";
                texto += "Diferencia contra el manifiesto: " + Convert.ToString(d.Monto_Diferencia_Colones) + "\n\n";

                /*texto += "Monto Sumatoria de Depòsitos en dólares del manifiesto: " + d.Monto_Contado_Dolares + "\n";
                texto += "Monto Declarado Manifiesto en Dólares : " + d.Monto_Dolares.ToString() + "\n";
                texto += "Diferencia en Dólares entre suma total de depósitos y monto declarado del manifiesto: " + Convert.ToString(d.Monto_Diferencia_Dolares) + "\n\n";

                texto += "Monto Sumatoria de Depòsitos en euros del manifiesto: " + d.Monto_Contado_Euros + "\n";
                texto += "Monto Declarado Manifiesto en Euros : " + d.Monto_Euros.ToString() + "\n";
                texto += "Diferencia en Euros entre suma total de depósitos y monto declarado del manifiesto: " + Convert.ToString(d.Monto_Diferencia_Euros);*/
                //MontoContadoManifiesto = MontoTotal;
                return texto;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //public string GeneraInformacionMontoManifiesto(ref ProcesamientoBajoVolumenManifiesto d)
        //{
        //    try
        //    {
        //        //decimal MontoTotal = 0;
        //        //decimal diferencia = 0;
        //        BindingList<Tula> tulas = d.Tulas;
        //        string texto = "";
        //        d.Monto_Contado_Colones = 0;
        //        d.Monto_Diferencia_Colones = 0;
        //        d.Monto_Contado_Dolares = 0;
        //        d.Monto_Diferencia_Dolares = 0;
        //        d.Monto_Contado_Euros = 0;
        //        d.Monto_Diferencia_Euros = 0;
        //        foreach (Tula tula in tulas)
        //        {
        //            texto += "Tula " + tula.Codigo + "\n\n";
        //            BindingList<Deposito> depositos = tula.Deposito;
        //            TipoCambio _tipocambio = null;
        //            foreach (Deposito deposito in depositos)
        //            {
        //                switch (deposito.Moneda)
        //                {
        //                    case Monedas.Colones:
        //                        d.Monto_Contado_Colones += deposito.MontoDeclarado;
        //                        d.Monto_Diferencia_Colones = d.Monto_Contado_Colones - d.Monto_Colones;
        //                        break;
        //                    case Monedas.Dolares:
        //                        //d.Monto_Contado_Dolares += deposito.Monto;                                
        //                        _tipocambio = obtenerTipoCambio(DateTime.Today.AddDays(-1));
        //                        d.Monto_Contado_Colones += (_tipocambio.Compra * deposito.MontoDeclarado);
        //                        d.Monto_Diferencia_Colones = d.Monto_Contado_Colones - d.Monto_Colones;
        //                        //d.Monto_Diferencia_Dolares = d.Monto_Contado_Dolares - d.Monto_Dolares;
        //                        break;
        //                    case Monedas.Euros:
        //                        _tipocambio = obtenerTipoCambio(DateTime.Today.AddDays(-1));
        //                        d.Monto_Contado_Colones += (_tipocambio.CompraEuros * deposito.MontoDeclarado);
        //                        d.Monto_Diferencia_Colones = d.Monto_Contado_Colones - d.Monto_Colones;
        //                        //d.Monto_Contado_Euros += deposito.Monto;                                
        //                        //d.Monto_Diferencia_Euros = d.Monto_Contado_Euros - d.Monto_Euros;
        //                        break;
        //                }
        //                /*if (deposito.Moneda != d.Monedas)
        //                {
        //                    TipoCambio _tipocambio = null;
        //                    _tipocambio = obtenerTipoCambio(DateTime.Today.AddDays(-1));
        //                    switch (d.Monedas)
        //                    {
        //                        case Monedas.Colones:
        //                            switch (deposito.Moneda)
        //                            {
        //                                case Monedas.Dolares:
        //                                    MontoTotal += _tipocambio.Compra * deposito.Monto;
        //                                    break;
        //                                case Monedas.Euros:
        //                                    MontoTotal += _tipocambio.CompraEuros * deposito.Monto;
        //                                    break;
        //                            }
        //                            break;
        //                        case Monedas.Dolares:
        //                            switch (deposito.Moneda)
        //                            {
        //                                case Monedas.Colones:
        //                                    MontoTotal += deposito.Monto / _tipocambio.Venta;
        //                                    break;
        //                                case Monedas.Euros:
        //                                    MontoTotal += (deposito.Monto * _tipocambio.CompraEuros) / _tipocambio.Venta;
        //                                    break;
        //                            }
        //                            break;
        //                        case Monedas.Euros:
        //                            switch (deposito.Moneda)
        //                            {
        //                                case Monedas.Colones:
        //                                    MontoTotal += deposito.Monto / _tipocambio.VentaEuros;
        //                                    break;
        //                                case Monedas.Dolares:
        //                                    MontoTotal += (deposito.Monto * _tipocambio.Compra) / _tipocambio.VentaEuros;
        //                                    break;
        //                            }
        //                            break;
        //                    }
        //                }
        //                else
        //                {
        //                    MontoTotal += deposito.Monto;
        //                }*/
        //                texto += "Depósito #" + deposito.NumeroDeposito + ",Declarado: " + deposito.MontoDeclarado + ", Contado: " + deposito.Monto.ToString() + ", Moneda: " + deposito.Moneda.ToString() + "\n";
        //            }
        //            texto += "\n";
        //        }
        //        //diferencia = MontoTotal - d.Monto;
        //        texto += "Monto Sumatoria de Depòsitos colonizados del manifiesto: " + d.Monto_Contado_Colones + "\n";
        //        texto += "Monto Declarado Manifiesto en Colones : " + d.Monto_Colones.ToString() + "\n";
        //        texto += "Diferencia contra el manifiesto: " + Convert.ToString(d.Monto_Diferencia_Colones) + "\n\n";

        //        /*texto += "Monto Sumatoria de Depòsitos en dólares del manifiesto: " + d.Monto_Contado_Dolares + "\n";
        //        texto += "Monto Declarado Manifiesto en Dólares : " + d.Monto_Dolares.ToString() + "\n";
        //        texto += "Diferencia en Dólares entre suma total de depósitos y monto declarado del manifiesto: " + Convert.ToString(d.Monto_Diferencia_Dolares) + "\n\n";

        //        texto += "Monto Sumatoria de Depòsitos en euros del manifiesto: " + d.Monto_Contado_Euros + "\n";
        //        texto += "Monto Declarado Manifiesto en Euros : " + d.Monto_Euros.ToString() + "\n";
        //        texto += "Diferencia en Euros entre suma total de depósitos y monto declarado del manifiesto: " + Convert.ToString(d.Monto_Diferencia_Euros);*/
        //        //MontoContadoManifiesto = MontoTotal;
        //        return texto;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        /*public byte setOrigenDiferenciaInconsistenciaDepositoBajoVolumen(byte origen)
        {
            try
            {
                InconsistenciaDepositoBajoVolumen inc = new InconsistenciaDepositoBajoVolumen();
                inc.OrigenDiferencia = origen;
                return inc.OrigenDiferencia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/

        public bool verificaNumDeposito(string NumDeposito)
        {
            return _procesamiento_bajo_volumen.VerificaNumeroDeposito(NumDeposito);
        }

        #endregion ProcesamientoBajoVolumen

        #region ProcesamientoAltoVolumen

        public void actualizarLimpiarDenominacionesBV() //Cambios GZH 13092017
        {

            try
            {
                _procesamiento_bajo_volumen.actualizarLimpiarDenominaciones();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void agregarProcesamientoAltoVolumen(ref ProcesamientoAltoVolumen c, ProcesamientoBajoVolumen d)
        {

            try
            {
                _procesamiento_alto_volumen.agregarProcesamientoAltoVolumen(ref c, d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void agregarProcesamientoAltoVolumenDetalle(ref ProcesamientoAltoVolumenDetalle c, ProcesamientoAltoVolumen d)
        {

            try
            {
                _procesamiento_alto_volumen.agregarProcesamientoAltoVolumenDetalle(ref c, d);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void agregarValidacionAltoVolumen(ref ValidacionAltoVolumen c)
        {

            try
            {
                _procesamiento_alto_volumen.agregarValidacionAltoVolumen(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void agregarBilleteRechazadoAltoVolumen(ref ValidacionAltoVolumen c)
        {

            try
            {
                _procesamiento_alto_volumen.agregarBilleteRechazadoAltoVolumen(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void agregarBilleteConteoAltoVolumen(ref ValidacionAltoVolumen c)
        {

            try
            {
                _procesamiento_alto_volumen.agregarBilleteConteoAltoVolumen(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ProcesamientoAltoVolumen obtenerProcesamientoAltoVolumen(string infoheadercard)
        {

            try
            {
                return _procesamiento_alto_volumen.ObtenerInfoProcesoAltoVolumen(infoheadercard);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public object[,] ObtenerArchivosBPS_Headercard(string infoheadercard)
        {

            try
            {
                string archivo = _procesamiento_alto_volumen.ObtenerArchivosBPS_Headercard(infoheadercard);
                return LecturaArchivoXML(archivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void agregarInconsistenciaAltoVolumen(ValidacionAltoVolumen c, Colaborador col)
        {

            try
            {
                _procesamiento_alto_volumen.agregarInconsistenciaAltoVolumen(c, col);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Object[,] LecturaArchivoXML(String nomArchivo)
        {
            Object[,] array = new Object[6, 4];
            bool newvalue = true;
            int i;
            //Creamos un documento y lo cargamos con los datos del XML.
            XmlDocument documento = new XmlDocument();
            documento.XmlResolver = null;
            documento.Load(nomArchivo);

            //Obtenemos una colección con todos los empleados.            
            XmlNodeList hdunit = documento.SelectNodes("BPS/Machine/ParameterSection");
            XmlNodeList xLista = ((XmlElement)hdunit[0]).GetElementsByTagName("HeadercardUnit");
            foreach (XmlElement nodo in xLista)
            {
                Console.WriteLine("header Card ID: {0}", nodo.GetAttribute("HeaderCardID"));
                /*string xEdad = nodo.GetAttribute("HeaderCardID");
                string xNombre = nodo.InnerText;*/

            }
            hdunit = documento.SelectNodes("BPS/Machine/ParameterSection/HeadercardUnit");
            xLista = ((XmlElement)hdunit[0]).GetElementsByTagName("Counter");
            foreach (XmlElement nodo in xLista)
            {
                newvalue = true;
                /*Console.WriteLine("Currency: {0}", nodo.GetAttribute("Currency"));
                Console.WriteLine("Denominacion: {0}", nodo.GetAttribute("Value"));
                Console.WriteLine("Cantidad: {0}", nodo.GetAttribute("Number")); */
                for (i = 0; i < 6; i++)
                {
                    if (Convert.ToInt64(nodo.GetAttribute("Value").Replace(",", "")) == Convert.ToInt64(array[i, 1]))
                    {
                        array[i, 2] = Convert.ToInt64(array[i, 2]) + Convert.ToInt64(nodo.GetAttribute("Number").Replace(",", ""));
                        array[i, 3] = (Convert.ToInt64(array[i, 1]) * Convert.ToInt64(array[i, 2]));
                        newvalue = false;
                        i = 6;
                    }
                }
                if (newvalue == true)
                {
                    for (i = 0; i < 6; i++)
                    {
                        if (Convert.ToString(array[i, 0]).Equals(""))
                        {
                            array[i, 0] = nodo.GetAttribute("Currency");
                            array[i, 1] = Convert.ToInt64(nodo.GetAttribute("Value").Replace(",", ""));
                            array[i, 2] = Convert.ToInt64(nodo.GetAttribute("Number").Replace(",", ""));
                            array[i, 3] = (Convert.ToInt64(array[i, 1]) * Convert.ToInt64(array[i, 2]));
                            i = 6;
                        }
                    }
                }
                /*string xEdad = nodo.GetAttribute("HeaderCardID");
                string xNombre = nodo.InnerText;*/

            }
            /*for (i = 0; i < 6; i++)
            {
                //MessageBox.Show("Elemento " + Convert.ToString(i) + " { Moneda: " + Convert.ToString(array[i, 0]) + ", Denominación: " + Convert.ToString(array[i, 1]) + ", Cantidad: " + Convert.ToString(array[i, 2]) + ", Monto: " + Convert.ToString(array[i, 3]));
            }*/
            return array;
            //XmlNodeList telefonos = unEmpleado.get;

        }

        #endregion ProcesamientoAltoVolumen

        #region BoletaCajeroNiquel

        public void agregarBoletaCajeroNiquel(ref BoletaCajeroNiquel c)
        {

            try
            {
                _cajeroniquel.agregarBoletaCajeroNiquel(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void agregarBoletaMesaNiquel(ref BoletaMesaNiquel c)
        {

            try
            {
                _cajeroniquel.agregarBoletaMesaNiquel(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void agregarProaInfoEnMesaNiquel(ref BoletaMesaNiquel c)
        {

            try
            {
                _cajeroniquel.agregarInfoEnMesaNiquel(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void agregarBoletaMesaEntregaNiquel(ref BoletaMesaEntregaNiquel c)
        {

            try
            {
                _entreganiquel.agregarBoletaEntregaMesaNiquel(ref c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion BoletaCajeroNiquel

        #region CierreCajero

        public DataTable ObtenerdatosFormularioMoneda(int idcajero, string fechaini, string fechafin)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = _cierrecajero.ObtenerInformacionDatosFormularioMoneda(idcajero, fechaini, fechafin);
            }
            catch (Excepcion ex)
            {
                throw ex;
                //MessageBox.Show(ex.Message);
            }
            return datos;
        }

        public DataTable ObtenerdatoscierreCajero(int idcajero, string fechaini, string fechafin)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = _cierrecajero.ObtenerInformacionDatosCierreCajero(idcajero, fechaini, fechafin);
            }
            catch (Excepcion ex)
            {
                throw ex;
                //MessageBox.Show(ex.Message);
            }
            return datos;
        }

        public DataTable ObtenerdatoscierreCajeroNiquel(int idcajero, string fechaini, string fechafin)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = _cierrecajero.ObtenerInformacionDatosCierreCajeroNiquel(idcajero, fechaini, fechafin);
            }
            catch (Excepcion ex)
            {
                throw ex;
                //MessageBox.Show(ex.Message);
            }
            return datos;
        }

        #endregion CierreCajero

        #region Procesamiento externo
        public Boolean insertMontosProcExternos(int colabID, short clienteID, byte empresaTID, decimal montoBilleteCRC, decimal montoBilleteUSD, decimal montoNiquel, decimal quinientos, decimal cien, decimal cincuenta, decimal veinticinco, decimal diez, decimal cinco, string montoPagUSD, string montoPagCRC)
        {
            return _entreganiquel.insertMontosProcExternos(colabID, clienteID, empresaTID, montoBilleteCRC, montoBilleteUSD, montoNiquel, quinientos, cien, cincuenta, veinticinco, diez, cinco, montoPagUSD, montoPagCRC);
        }

        public System.Collections.IList listarClientes2()
        {
            return _clientes.listarClientes("");
        }

        //manifiestos pendientes
        public DataTable manifiestosPendientes(DateTime fechaInicio, DateTime fechafin)
        {
            return _entreganiquel.manifiestosPendientes(fechaInicio, fechafin);
        }

        public void insertarMontoManifiestoPendiente(int idManifiesto, Colaborador c, decimal colones, decimal dolares, decimal euros)
        {
            _entreganiquel.insertaMontoManifiestoPendiente(idManifiesto, c, colones, dolares, euros);
        }

        #endregion Procesamiento externo

        //consulta formularios
        #region consulta formularios
        public DataTable obtieneReporte(int cajero, DateTime desde, DateTime hasta, int tipoFormulario)
        {
            DataTable dt = new DataTable();
            switch (tipoFormulario)
            {
                case 0:
                    dt = obtieneTodosFormularios(cajero, desde, hasta);
                    break;
                case 1:
                    dt = _entreganiquel.obtieneCntrlDiarioCierreCajero(cajero, desde, hasta);
                    break;
                case 2:
                    dt = _entreganiquel.obtieneDetalleInconsistenciasTesoreria(cajero, desde, hasta);
                    break;
                case 3:
                    dt = _entreganiquel.obtieneCntrlDiarioCierreCajeroNikel(cajero, desde, hasta);
                    break;
                case 4:
                    dt = _entreganiquel.obtieneBoletaNikelEntregaCajero(cajero, desde, hasta);
                    break;
                case 5:
                    dt = _entreganiquel.obtieneBoletaNikelEntregaCola(cajero, desde, hasta);
                    break;
                case 6:
                    dt = _entreganiquel.obtieneInconsistenciasManifiesto(cajero, desde, hasta);
                    break;
                case 7:
                    dt = _entreganiquel.obtieneRecapBPS(cajero, desde, hasta);
                    break;
                default:
                    break;
            }
            return dt;
        }

        public DataTable obtieneTodosFormularios(int cajero, DateTime desde, DateTime hasta)
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt6 = new DataTable();
            DataTable dt7 = new DataTable();
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            dt1 = _entreganiquel.obtieneCntrlDiarioCierreCajero(cajero, desde, hasta);
            dt2 = _entreganiquel.obtieneDetalleInconsistenciasTesoreria(cajero, desde, hasta);
            dt3 = _entreganiquel.obtieneCntrlDiarioCierreCajeroNikel(cajero, desde, hasta);
            dt4 = _entreganiquel.obtieneBoletaNikelEntregaCajero(cajero, desde, hasta);
            dt5 = _entreganiquel.obtieneBoletaNikelEntregaCola(cajero, desde, hasta);
            dt6 = _entreganiquel.obtieneInconsistenciasManifiesto(cajero, desde, hasta);
            dt7 = _entreganiquel.obtieneRecapBPS(cajero, desde, hasta);

            ds1.Tables.Add(dt1);
            ds2.Tables.Add(dt2);
            ds2.Tables.Add(dt3);
            ds2.Tables.Add(dt4);
            ds2.Tables.Add(dt5);
            ds2.Tables.Add(dt6);
            ds2.Tables.Add(dt7);

            ds1.Tables[0].Merge(ds2.Tables[0]);
            ds1.Tables[0].Merge(ds2.Tables[1]);
            ds1.Tables[0].Merge(ds2.Tables[2]);
            ds1.Tables[0].Merge(ds2.Tables[3]);
            ds1.Tables[0].Merge(ds2.Tables[4]);
            if (dt7.Rows.Count > 0)
            {
                ds1.Tables[0].Merge(ds2.Tables[5]);
            }


            return ds1.Tables[0];
        }


        public DataTable obtieneExcelBoletaNikelEntregaCajero(int id)
        {
            return _entreganiquel.obtieneBoletaNikelEntregaCajeroExcel(id);
        }

        public DataTable obtenerExcelCntrDiarioCierreCajeroNikel(int id)
        {
            return _entreganiquel.obtenerExcelCntrDiarioCierreCajeroNikel(id);
        }

        public DataTable obtieneExcelBoletaNikelEntregaCola(int id)
        {
            return _entreganiquel.obtieneExcelBoletaNikelEntregaCola(id);
        }

        public DataTable obtieneExcelDetalleInconsistenciasTesoreria(int id)
        {
            return _entreganiquel.obtieneExcelDetalleInconsistenciasTesoreria(id);
        }

        public DataTable obtieneExcelCntrlDiarioCierreCajero(int id)
        {
            return _entreganiquel.obtieneExcelCntrlDiarioCierreCajero(id);
        }

        public DataTable obtieneExcelInconsistenciasManifiesto(int id)
        {
            return _entreganiquel.obtieneExcelInconsistenciasManififesto(id);
        }
        #endregion

        //consulta manifiestos
        #region consulta manifiestos
        public int selectManifiestoId(string codigo)
        {
            return _entreganiquel.selectManifiestoId(codigo);
        }

        public ProcesamientoBajoVolumenManifiesto obtnProcesamientoBajoVolumenDeposito(int idManifiesto)
        {
            return _entreganiquel.obtnProcesamientoBajoVolumenManifiesto(idManifiesto);
        }

        public void eliminarTula(int tulaId, int idColaborador)
        {
            try

            {
                _entreganiquel.eliminarTula(tulaId, idColaborador);
            }
            catch (Excepcion ex)
            {
                throw new Excepcion(ex.Message);
            }

        }

        public void eliminarDeposto(int tulaId, int colaborador)
        {
            try
            {
                _entreganiquel.eliminarDepostio(tulaId, colaborador);
            }
            catch (Excepcion ex) { throw new Excepcion(ex.Message); }

        }

        public bool InsertBitacoraDeposito(Colaborador _coordinador, Deposito _deposito, Deposito _nuevo)
        {
            string datoAnterior = "";
            string datoNuevo = "";
            string tableName = "tblProcesamientoBajoVolumenDeposito";
            int idDeposito = _nuevo.ID;
            Boolean cambio = false;
            if (!_nuevo.CodigoVD.Equals(_deposito.CodigoVD))
            {
                datoAnterior = _deposito.CodigoVD;
                datoNuevo = _nuevo.CodigoVD;
                cambio = true;
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "Codigo_VD", tableName, datoAnterior, datoNuevo);

            }
            if (!_nuevo.NumeroDeposito.Equals(_deposito.NumeroDeposito))
            {
                datoAnterior = _deposito.NumeroDeposito;
                datoNuevo = _nuevo.NumeroDeposito;
                cambio = true;
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "Numero_deposito", tableName, datoAnterior, datoNuevo);

            }
            if (!_nuevo.CuentaReferencia.Equals(_deposito.CuentaReferencia))
            {
                datoAnterior = _deposito.CuentaReferencia;
                datoNuevo = _nuevo.CuentaReferencia;
                cambio = true;
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "Cuenta_Referencia", tableName, datoAnterior, datoNuevo);

            }
            if (_nuevo.Moneda != _deposito.Moneda)
            {
                datoAnterior = _deposito.Moneda.ToString();
                datoNuevo = _nuevo.Moneda.ToString();
                cambio = true;
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "Moneda", tableName, datoAnterior, datoNuevo);

            }
            if ((int)_deposito.TipomesaNiquel != 1)
            {
                if ((_nuevo.TipomesaNiquel == 0 && (int)_deposito.TipomesaNiquel == 2) || (_nuevo.TipomesaNiquel == 1 && (int)_deposito.TipomesaNiquel == 0))
                {
                    datoAnterior = _deposito.TipomesaNiquel.ToString();
                    datoNuevo = _nuevo.TipomesaNiquel.ToString();
                    cambio = true;
                    _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "TipoMesa_Niquel", tableName, datoAnterior, datoNuevo);

                }
            }

            if (!_nuevo.Cedula.Equals(_deposito.Cedula))
            {
                datoAnterior = _deposito.Cedula;
                datoNuevo = _nuevo.Cedula;
                cambio = true;
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "Cedula", tableName, datoAnterior, datoNuevo);


            }
            if (_nuevo.MontoDeclarado != _deposito.MontoDeclarado)
            {
                datoAnterior = _deposito.MontoDeclarado.ToString();
                datoNuevo = _nuevo.MontoDeclarado.ToString();
                cambio = true;
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "Monto_Declarado", tableName, datoAnterior, datoNuevo);

            }
            if (_nuevo.MontoNiquel != _deposito.MontoNiquel)
            {
                datoAnterior = _deposito.MontoNiquel.ToString();
                datoNuevo = _nuevo.MontoNiquel.ToString();
                cambio = true;
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "Monto_Niquel", tableName, datoAnterior, datoNuevo);

            }
            if (_nuevo.CodigoTransaccion != _deposito.CodigoTransaccion)
            {
                datoAnterior = _deposito.CodigoTransaccion;
                datoNuevo = _nuevo.CodigoTransaccion;
                cambio = true;
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "Codigo_Transaccion", tableName, datoAnterior, datoNuevo);

            }
            if (_nuevo.Monto != _deposito.Monto)
            {
                datoAnterior = _deposito.Monto.ToString();
                datoNuevo = _nuevo.Monto.ToString();
                cambio = true;
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "Monto_Contado", tableName, datoAnterior, datoNuevo);

            }
            if (_nuevo.MontoDiferencia != _deposito.MontoDiferencia)
            {
                datoAnterior = _deposito.MontoDiferencia.ToString();
                datoNuevo = _nuevo.MontoDiferencia.ToString();
                cambio = true;
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "Diferencia", tableName, datoAnterior, datoNuevo);

            }
            return cambio;
        }

        public void modificarCodigoTula(string codigo, int tulaId, Colaborador coordinador)
        {
            _entreganiquel.modificarCodigoTula(codigo, tulaId, coordinador);
        }

        public Deposito obtieneDeposito(int codigoDeposito)
        {
            return _entreganiquel.obtieneDeposito(codigoDeposito);
        }
        public ConteoBillete selectConteoBillete(int idDeposito)
        {
            return _entreganiquel.selectConteoBillete(idDeposito);
        }

        public BindingList<BilleteFalso> selectBilletesFalsos(int codigoDeposito)
        {
            return _entreganiquel.selectBilletesFalsos(codigoDeposito);
        }

        public BindingList<ChequeDeposito> SelectChequesDeposito(int codigoDeposito)
        {
            return _entreganiquel.SelectChequesDeposito(codigoDeposito);
        }

        public CompraVenta selectIngresoCompraVenta(int idDeposito)
        {
            return _entreganiquel.selctIngresoCompraVenta(idDeposito);
        }
        public ConteoNiquel selectConteoNiquel(int p)
        {
            return _entreganiquel.selectConteoNiquel(p);
        }

        public bool UpdateDeposito2(Colaborador _coordinador, Deposito _deposito, int idDeposito, string codigo, string numDeposito, string ctaReferencia, int moneda, int tipoMesaNiquel, string cedula, decimal montoDeclarado, decimal montoNiquel, string codigoTransaccion, string montoContado, string diferencia)
        {
            string datoAnterior = "";
            string datoNuevo = "";
            string tableName = "tblProcesamientoBajoVolumenDeposito";
            Boolean cambio = false;
            if (!codigo.Equals(_deposito.CodigoVD))
            {
                datoAnterior = _deposito.CodigoVD;
                datoNuevo = codigo;
                cambio = true;
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "Codigo_VD", tableName, datoAnterior, datoNuevo);
                _entreganiquel.UpdtProBVDpsito(idDeposito, "Codigo_VD", datoNuevo);
            }
            if (!numDeposito.Equals(_deposito.NumeroDeposito))
            {
                datoAnterior = _deposito.NumeroDeposito;
                datoNuevo = numDeposito;
                cambio = true;
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "Numero_deposito", tableName, datoAnterior, datoNuevo);
                _entreganiquel.UpdtProBVDpsito(idDeposito, "Numero_deposito", datoNuevo);
            }
            if (!ctaReferencia.Equals(_deposito.CuentaReferencia))
            {
                datoAnterior = _deposito.CuentaReferencia;
                datoNuevo = ctaReferencia;
                cambio = true;
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "Cuenta_Referencia", tableName, datoAnterior, datoNuevo);
                _entreganiquel.UpdtProBVDpsito(idDeposito, "Cuenta_Referencia", datoNuevo);
            }
            if (moneda != (int)_deposito.Moneda)
            {
                datoAnterior = _deposito.Moneda.ToString();
                datoNuevo = moneda.ToString();
                cambio = true;
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "Moneda", tableName, datoAnterior, datoNuevo);
                _entreganiquel.UpdtProBVDpsito(idDeposito, "Moneda", datoNuevo);
            }
            if ((int)_deposito.TipomesaNiquel != 1)
            {
                if ((tipoMesaNiquel == 0 && (int)_deposito.TipomesaNiquel == 2) || (tipoMesaNiquel == 1 && (int)_deposito.TipomesaNiquel == 0))
                {
                    datoAnterior = _deposito.TipomesaNiquel.ToString();
                    datoNuevo = "0";
                    cambio = true;
                    _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "TipoMesa_Niquel", tableName, datoAnterior, datoNuevo);
                    _entreganiquel.UpdtProBVDpsito(idDeposito, "TipoMesa_Niquel", datoNuevo);
                }
            }

            if (!cedula.Equals(_deposito.Cedula))
            {
                datoAnterior = _deposito.Cedula;
                datoNuevo = cedula;
                cambio = true;
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "Cedula", tableName, datoAnterior, datoNuevo);
                _entreganiquel.UpdtProBVDpsito(idDeposito, "Cedula", datoNuevo);

            }
            if (montoDeclarado != _deposito.MontoDeclarado)
            {
                datoAnterior = _deposito.MontoDeclarado.ToString();
                datoNuevo = montoDeclarado.ToString();
                cambio = true;
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "Monto_Declarado", tableName, datoAnterior, datoNuevo);
                _entreganiquel.UpdtProBVDpsito(idDeposito, "Monto_Declarado", datoNuevo);
            }
            if (montoNiquel != _deposito.MontoNiquel)
            {
                datoAnterior = _deposito.MontoNiquel.ToString();
                datoNuevo = montoNiquel.ToString();
                cambio = true;
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "Monto_Niquel", tableName, datoAnterior, datoNuevo);
                _entreganiquel.UpdtProBVDpsito(idDeposito, "Monto_Niquel", datoNuevo);
            }
            if (codigoTransaccion != _deposito.CodigoTransaccion)
            {
                datoAnterior = _deposito.CodigoTransaccion;
                datoNuevo = codigoTransaccion;
                cambio = true;
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "Codigo_Transaccion", tableName, datoAnterior, datoNuevo);
                _entreganiquel.UpdtProBVDpsito(idDeposito, "Codigo_Transaccion", datoNuevo);
            }
            if (decimal.Parse(montoContado) != _deposito.Monto)
            {
                datoAnterior = _deposito.Monto.ToString();
                datoNuevo = montoContado;
                cambio = true;
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "Monto_Contado", tableName, datoAnterior, datoNuevo);
                _entreganiquel.UpdtProBVDpsito(idDeposito, "Monto_Contado", datoNuevo);
            }
            if (decimal.Parse(diferencia) != _deposito.MontoDiferencia)
            {
                datoAnterior = _deposito.MontoDiferencia.ToString();
                datoNuevo = diferencia;
                cambio = true;
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, _coordinador.ID, "Diferencia", tableName, datoAnterior, datoNuevo);
                _entreganiquel.UpdtProBVDpsito(idDeposito, "Diferencia", datoNuevo);
            }
            return cambio;
        }

               public void UpdateBilletesFalsos(int idDeposito, BindingList<BilleteFalso> listabilletefalso, BindingList<BilleteFalso> listabilletefalsoAnterior, int idCoordinador)
        {
            foreach (BilleteFalso bf in listabilletefalso)
            {
                if (bf.ID == 0)
                {
                    _entreganiquel.insertBilleteFalsoDepostito(idDeposito, bf);
                }
                else
                {
                    foreach (BilleteFalso bf2 in listabilletefalsoAnterior)
                    {
                        if (bf2.ID == bf.ID)
                        {
                            if (bf2.SerieBillete != bf.SerieBillete || bf2.Moneda != bf.Moneda || bf2.denominacion != bf.denominacion)
                            {
                                _entreganiquel.updateBilleteFalsoDeposito(bf);
                                _entreganiquel.updateBitacoraBilleteFalsoDeposito(idDeposito, bf, idCoordinador);
                            }
                        }
                    }
                }
            }
            foreach (BilleteFalso billete1 in listabilletefalsoAnterior)
            {
                Boolean aux = false;
                foreach (BilleteFalso billete2 in listabilletefalso)
                {
                    if (billete1.ID == billete2.ID) aux = true;
                }
                if (!aux) _entreganiquel.eliminarBilleteFalsoDeposito(billete1.ID);
            }

        }

        public void UpdateCheques(int idDeposito, BindingList<ChequeDeposito> listachequedeposito, BindingList<ChequeDeposito> listachequedepositoAnt, int idCoordinador)
        {
            foreach (ChequeDeposito cd in listachequedeposito)
            {
                if (cd.ID == 0)
                {
                    _entreganiquel.insertChequeDeposito(idDeposito, cd);
                }
                else
                {
                    foreach (ChequeDeposito cd2 in listachequedepositoAnt)
                    {
                        if (cd2.ID == cd.ID)
                        {
                            if (cd2.TipoCheque != cd.TipoCheque || cd2.Moneda != cd.Moneda || cd2.Monto != cd.Monto)
                            {
                                _entreganiquel.updateChequesDeposito(cd);
                                _entreganiquel.updateBitacoraChequesDeposito(idDeposito, cd, idCoordinador);
                            }
                        }
                    }
                }
            }
            foreach (ChequeDeposito cheque1 in listachequedepositoAnt)
            {
                Boolean aux = false;
                foreach (ChequeDeposito cheque2 in listachequedeposito)
                {
                    if (cheque1.ID == cheque2.ID) aux = true;
                }
                if (!aux) _entreganiquel.eliminarChequeDeposito(cheque1.ID);
            }
        }

        public void updateConteoNiquel(ConteoNiquel conteo, ConteoNiquel conteoAnterior, int idDeposito, int idCordinador)
        {
            Boolean cambio = false;
            string tableName = "tblInfoConteoNiquel";
            if (conteo.conteo500 != conteoAnterior.conteo500)
            {
                cambio = true;
                _entreganiquel.updateConteoNiquel(conteoAnterior.ID, "denominacion500", conteo.conteo500);
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, idCordinador, "denominacion500", tableName, conteoAnterior.conteo500.ToString(), conteo.conteo500.ToString());
            }
            if (conteo.conteo100 != conteoAnterior.conteo100)
            {
                cambio = true;
                _entreganiquel.updateConteoNiquel(conteoAnterior.DB_ID, "denominacion100", conteo.conteo100);
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, idCordinador, "denominacion100", tableName, conteoAnterior.conteo100.ToString(), conteo.conteo100.ToString());
            }
            if (conteo.conteo50 != conteoAnterior.conteo50)
            {
                cambio = true;
                _entreganiquel.updateConteoNiquel(conteoAnterior.DB_ID, "denominacion50", conteo.conteo50);
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, idCordinador, "denominacion50", tableName, conteoAnterior.conteo50.ToString(), conteo.conteo50.ToString());
            }
            if (conteo.conteo25 != conteoAnterior.conteo25)
            {
                cambio = true;
                _entreganiquel.updateConteoNiquel(conteoAnterior.DB_ID, "denominacion25", conteo.conteo25);
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, idCordinador, "denominacion25", tableName, conteoAnterior.conteo25.ToString(), conteo.conteo25.ToString());

            }
            if (conteo.conteo10 != conteoAnterior.conteo10)
            {
                cambio = true;
                _entreganiquel.updateConteoNiquel(conteoAnterior.DB_ID, "denominacion10", conteo.conteo10);
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, idCordinador, "denominacion10", tableName, conteoAnterior.conteo10.ToString(), conteo.conteo10.ToString());
            }
            if (conteo.conteo5 != conteoAnterior.conteo5)
            {
                cambio = true;
                _entreganiquel.updateConteoNiquel(conteoAnterior.DB_ID, "denominacion5", conteo.conteo5);
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, idCordinador, "denominacion5", tableName, conteoAnterior.conteo5.ToString(), conteo.conteo5.ToString());
            }
            if (cambio)
            {
                _entreganiquel.updateConteoNiquel(conteoAnterior.DB_ID, "Total_Niquel", conteo.conteototal);
                _entreganiquel.UpdtBitacoraCambiosProBVDpsito(idDeposito, idCordinador, "Total_Niquel", tableName, conteoAnterior.conteototal.ToString(), conteo.conteototal.ToString());
            }
        }
        #endregion

        public DataTable SelectDepositos(int tulaId)
        {
            return _entreganiquel.selecteDepositos(tulaId);
        }
        public DataTable selectTulas(int codigo)
        {
            return _entreganiquel.selectTulas(codigo);
        }
        #endregion Métodos Públicos

        public DataTable listarClientesDT()
        {
            return _clientes.listarClientesDT();
        }
        
        public DataTable obtenerPuntosVentaClienteID(string idCliente)
        {
            return _puntos_venta.obtenerPuntosVentaClienteDT(idCliente);
        }

        public void actualizarManifiesto(int idUsuario, int iDManifiesto, int idCliente, int idPV, decimal colones, decimal dolares, decimal euros)
        {
            _entreganiquel.actualizarManifiesto(idUsuario, iDManifiesto, idCliente, idPV, colones, dolares, euros);
        }
    }


}
