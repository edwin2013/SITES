//
//  @ Project : 
//  @ File Name : InconsistenciasDepositosDL.cs
//  @ Date : 18/10/2011
//  @ Author : Erick Chavarría 
//  

using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;
using CommonObjects.Clases;

namespace DataLayer
{

    public class InconsistenciasDepositosDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static InconsistenciasDepositosDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static InconsistenciasDepositosDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new InconsistenciasDepositosDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public InconsistenciasDepositosDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar una inconsistencia en un deposito.
        /// </summary>
        /// <param name="i">Objeto InconsistenciaDeposito con los datos de la inconsistencia</param>
        public void agregarInconsistencia(ref InconsistenciaDeposito i)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertInconsistenciaDeposito");

            _manejador.agregarParametro(comando, "@manifiesto", i.Manifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tula", i.Tula, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@deposito", i.Deposito, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@camara", i.Camara, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha", i.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@diferencia_colones", i.Diferencia_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@diferencia_dolares", i.Diferencia_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@diferencia_euros", i.Diferencia_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@comentario", i.Comentario, SqlDbType.VarChar);

            try
            {
                i.Id = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorInconsistenciaDepositoRegistro");
            }

        }

        /// <summary>
        /// Verificar si existe una inconsistencia para un deposito dado.
        /// </summary>
        /// <param name="i">Objeto InconsistenciaDeposito con los datos de la inconsistencia</param>
        /// <returns>Valor que indica si la inconsistencia existe</returns>
        public bool verificarInconsistenciaClienteDeposito(InconsistenciaDeposito i)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteInconsistenciaDeposito");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@deposito", i.Deposito, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id_encontrado = (int)datareader["pk_ID"];

                    existe = id_encontrado != i.Id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarInconsistenciaDepositoDuplicado");
            }

            return existe;
        }

        /// <summary>
        /// Actualizar los datos de una inconsistencia en un deposito.
        /// </summary>
        /// <param name="i">Objeto InconsistenciaDeposito con los datos de la inconsistencia</param>
        public void actualizarInconsistencia(InconsistenciaDeposito i)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateInconsistenciaDeposito");

            _manejador.agregarParametro(comando, "@manifiesto", i.Manifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tula", i.Tula, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@deposito", i.Deposito, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@camara", i.Camara, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha", i.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@diferencia_colones", i.Diferencia_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@diferencia_dolares", i.Diferencia_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@diferencia_euros", i.Diferencia_euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@comentario", i.Comentario, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@inconsistencia", i.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorInconsistenciaDepositoActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de una inconsistencia en un deposito.
        /// </summary>
        /// <param name="i">Objeto InconsistenciaDeposito con los datos de la inconsistencia</param>
        public void eliminarInconsistencia(InconsistenciaDeposito i)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteInconsistenciaDeposito");

            _manejador.agregarParametro(comando, "@inconsistencia", i.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorInconsistenciaDepositoEliminacion");
            }

        }

        /// <summary>
        /// Listar las inconsistencias en depositos registradas durante un periodo de tiempo.
        /// </summary>
        /// <param name="i">Fecha inicial del periodo de tiempo</param>
        /// <param name="f">Fecha final del periodo de tiempo</param>
        /// <returns>Lista de las inconsistencias registradas en el periodo de tiempo indicado</returns>
        public BindingList<InconsistenciaDeposito> listarInconsistencias(DateTime i, DateTime f)
        {
            BindingList<InconsistenciaDeposito> inconsistencias = new BindingList<InconsistenciaDeposito>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectInconsistenciasDepositos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha_inicio", i, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha_fin", f, SqlDbType.DateTime);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_inconsistenca = (int)datareader["ID_Incosistencia"];
                    DateTime fecha = (DateTime)datareader["Fecha"];
                    decimal diferencia_colones = (decimal)datareader["Diferencia_Colones"];
                    decimal diferencia_dolares = (decimal)datareader["Diferencia_Dolares"];
                    string comentario = (string)datareader["Comentario"];

                    int id_manifiesto = (int)datareader["ID_Manifiesto"];
                    string codigo_manifiesto = (string)datareader["Codigo_Manifiesto"];
 
                    int id_tula = (int)datareader["ID_Tula"];
                    string codigo_tula = (string)datareader["Codigo_Tula"];

                    byte id_camara = (byte)datareader["ID_Camara"];
                    string identificador = (string)datareader["Identificador"];

                    int id_deposito = (int)datareader["ID_Deposito"];
                    long referencia_deposito = (long)datareader["Referencia"];
                    decimal monto_deposito = (decimal)datareader["Monto"];
                    Monedas moneda_deposito = (Monedas)datareader["Moneda"];
                    long cuenta_deposito = (long)datareader["Cuenta"];

                    ManifiestoCEF manifiesto = new ManifiestoCEF(codigo_manifiesto, id: id_manifiesto);
                    Tula tula = new Tula(codigo_tula, id: id_tula);
                    Deposito deposito = new Deposito(referencia_deposito, id: id_deposito, monto: monto_deposito, moneda: moneda_deposito,
                                                     cuenta: cuenta_deposito);
                    Camara camara = new Camara(identificador, id: id_camara);

                    InconsistenciaDeposito inconsistencia =
                        new InconsistenciaDeposito(id_inconsistenca, manifiesto, tula, deposito, camara, fecha,
                                                   diferencia_colones, diferencia_dolares, comentario);
                    inconsistencias.Add(inconsistencia);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return inconsistencias;
        }        


        /// <summary>
        /// Ligar un manifiesto segregado con una inconsistencia en deposito.
        /// </summary>
        /// <param name="i">Objeto InconsistenciaDeposito con los datos de la inconsistencia</param>
        public void agregarSegregadoInconsistencia(InconsistenciaDeposito i)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertInconsistenciaDepositoSegregado");

            _manejador.agregarParametro(comando, "@segregado", i.Segregado.Id, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@bolso", i.Bolso, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@inconsistencia", i.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorInconsistenciaDepositoActualizacion");
            }

        }

        /// <summary>
        /// Desligar un manifiesto segregado de una inconsistencia en deposito.
        /// </summary>
        /// <param name="i">InconsistenciaDeposito con los datos de la inconsistencia</param>
        public void eliminarManifiestoSegregadoInconsistencia(InconsistenciaDeposito i)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteInconsistenciaDepositoSegregado");

            _manejador.agregarParametro(comando, "@inconsistencia", i.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorInconsistenciaDepositoActualizacion");
            }

        }

        /// <summary>
        /// Obtener el manifiesto segregado ligado a una inconsistencia.
        /// </summary>
        /// <param name="i">Inconsistencia para la cual se obtienen los manifiesto segregados</param>
        public void obtenerSegregadoInconsistencia(ref InconsistenciaDeposito i)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectInconsistenciaDepositoSegregado");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@inconsistencia", i.Id, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short bolso = (short)datareader["Bolso"];

                    int id_manifiesto = (int)datareader["ID_Manifiesto"];

                    short id_cliente = (short)datareader["ID_Cliente"];
                    string nombre_cliente = (string)datareader["Nombre_Cliente"];

                    short id_punto_venta = (short)datareader["ID_Punto_Venta"];
                    string nombre_punto_venta = (string)datareader["Nombre_Punto_Venta"];

                    int id_digitador = (int)datareader["ID_Digitador"];
                    string nombre_digitador = (string)datareader["Nombre_Digitador"];
                    string primer_apellido_digitador = (string)datareader["Primer_Apellido_Digitador"];
                    string segundo_apellido_digitador = (string)datareader["Segundo_Apellido_Digitador"];

                    int id_cajero = (int)datareader["ID_Cajero"];
                    string nombre_cajero = (string)datareader["Nombre_Cajero"];
                    string primer_apellido_cajero = (string)datareader["Primer_Apellido_Cajero"];
                    string segundo_apellido_cajero = (string)datareader["Segundo_Apellido_Cajero"];

                    int id_coordinador = (int)datareader["ID_Coordinador"];
                    string nombre_coordinador = (string)datareader["Nombre_Coordinador"];
                    string primer_apellido_coordinador = (string)datareader["Primer_Apellido_Coordinador"];
                    string segundo_apellido_coordinador = (string)datareader["Segundo_Apellido_Coordinador"];

                    Colaborador coordinador = new Colaborador(id_coordinador, nombre_coordinador, primer_apellido_coordinador, segundo_apellido_coordinador);
                    Colaborador digitador = new Colaborador(id_digitador, nombre_digitador, primer_apellido_digitador, segundo_apellido_digitador);
                    Colaborador cajero = new Colaborador(id_cajero, nombre_cajero, primer_apellido_cajero, segundo_apellido_cajero);
                    Cliente cliente = new Cliente(id_cliente, nombre_cliente);
                    PuntoVenta punto_venta = new PuntoVenta(id_punto_venta, nombre_punto_venta, cliente);
                    SegregadoCEF segregado = new SegregadoCEF(id_manifiesto, cajero, digitador, coordinador, punto_venta);

                    i.Segregado = segregado;
                    i.Bolso = bolso;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        //CAMBIOS GZH 06022017

        public DataTable listarInconsistenciasPROA(int idcliente, byte estado)
        {
            DataTable inconsistencias = new DataTable();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPROAInconsistenciasPorResolver");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cliente", idcliente, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@estado", estado, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                inconsistencias.Load(datareader);

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return inconsistencias;
        }

        public InconsistenciaDepositoBajoVolumen listarDetalleInconsistenciasPROA(int idincons)
        {
            InconsistenciaDepositoBajoVolumen inconsistencias = new InconsistenciaDepositoBajoVolumen();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPROADetalleInconsistenciasPorResolver");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@ID", idincons, SqlDbType.Int);            

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                if (datareader.Read())
                {                    
                    int id_manifiesto = (int)datareader["ID_Manifiesto"];
                    string codigo_manifiesto = (string)datareader["Codigo_manifiesto"];
                    Manifiesto man = new Manifiesto();
                    man.ID = id_manifiesto;
                    man.Codigo = codigo_manifiesto;

                    short id_cliente = (short)datareader["ID_Cliente"];
                    string nombre_cliente = (string)datareader["Nombre_Cliente"];

                    short id_punto_venta = (short)datareader["ID_Punto_Venta"];
                    string nombre_punto_venta = (string)datareader["Nombre_Punto_Venta"];                    

                    int id_cajero = (int)datareader["ID_Cajero"];
                    string nombre_cajero = (string)datareader["Nombre_Cajero"];
                    string primer_apellido_cajero = (string)datareader["Primer_Apellido_Cajero"];
                    string segundo_apellido_cajero = (string)datareader["Segundo_Apellido_Cajero"];

                    byte esdeposito = (byte)datareader["Es_deposito"];
                    byte escuenta = (byte)datareader["Es_cuenta"];
                    byte escedula = (byte)datareader["Es_cedula"];
                    byte escodigoVD = (byte)datareader["Es_codigoVD"];
                    byte escodigotransaccion = (byte)datareader["Es_codigotransaccion"];
                    byte esmoneda = (byte)datareader["Es_moneda"];

                    Tula tula = new Tula((string)datareader["codigo_tula"], id: (int)datareader["ID_Tula"]);
                    Camara cam = new Camara((string)datareader["Camara"], (byte)datareader["ID_Camara"]);                                       

                    Colaborador cajero = new Colaborador(id_cajero, nombre_cajero, primer_apellido_cajero, segundo_apellido_cajero);
                    Cliente cliente = new Cliente(id_cliente, nombre_cliente);
                    PuntoVenta punto_venta = new PuntoVenta(id_punto_venta, nombre_punto_venta, cliente);
                    ProcesamientoBajoVolumenDeposito procesobajo = new ProcesamientoBajoVolumenDeposito(ID: (int)datareader["ID_ProcesamientoBajoVolumenDeposito"], 
                        numero_deposito: (string)datareader["Numero_Deposito"], codigo_VD: (string)datareader["Codigo_VD"], cuenta: (string)datareader["Cuenta"], 
                        codigo_transaccion: (string)datareader["Codigo_transaccion"], cedula: (string)datareader["cedula"], moneda: (Monedas)datareader["Moneda"], 
                        MontoContado: Convert.ToDecimal(datareader["MontoDeposito"]), Diferencia: Convert.ToDecimal(datareader["DiferenciaDeposito"]), Depositante: (string)datareader["Depositante"]);
                    inconsistencias.ID = idincons;
                    inconsistencias.Cliente = cliente;
                    inconsistencias.Es_cedula = escedula;
                    inconsistencias.Es_codigotransaccion = escodigotransaccion;
                    inconsistencias.Es_codigoVD = escodigoVD;
                    inconsistencias.Es_cuenta = escuenta;
                    inconsistencias.Es_moneda = esmoneda;
                    inconsistencias.Es_numdeposito = esdeposito;
                    inconsistencias.Estado = 0;
                    inconsistencias.Fecha = DateTime.Today;
                    inconsistencias.Manifiesto = man;
                    inconsistencias.procesamiento = procesobajo;
                    inconsistencias.PuntoVenta = punto_venta;
                    inconsistencias.Tula = tula;
                    inconsistencias.Cajero = cajero;
                    inconsistencias.Camara = cam;
                    
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return inconsistencias;
        }

        public void actualizarInfoInconsistenciaDeposito(ref InconsistenciaDepositoBajoVolumen c, ref Colaborador d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePROAInconsistenciasInfoDeposito");

            _manejador.agregarParametro(comando, "@ID_Procesamiento", c.procesamiento.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@ID_PROAInconsistenciasInfoDeposito", c.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Cajero", d.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Numero_deposito", c.procesamiento.NumeroDeposito, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@Codigo_VD", c.procesamiento.CodigoVD, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@Codigo_Transaccion", c.procesamiento.CodigoTransaccion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@Cuenta_Referencia", c.procesamiento.Cuenta, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@cedula", c.procesamiento.Cedula, SqlDbType.VarChar);


            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("UpdatePROAInconsistenciasInfoDeposito");
            }

        }

        #endregion Métodos Públicos

    }

}
