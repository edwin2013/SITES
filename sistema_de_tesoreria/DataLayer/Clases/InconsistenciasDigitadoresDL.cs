//
//  @ Project : 
//  @ File Name : InconsistenciasDigitadoresDL.cs
//  @ Date : 27/08/2011
//  @ Author : Erick Chavarría 
//  

using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;

namespace DataLayer
{

    public class InconsistenciasDigitadoresDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static InconsistenciasDigitadoresDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static InconsistenciasDigitadoresDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new InconsistenciasDigitadoresDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public InconsistenciasDigitadoresDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar una inconsistencia causadas por un digitador en el sistema.
        /// </summary>
        /// <param name="i">Objeto InconsistenciaDigitador con los datos de la inconsistencia</param>
        public void agregarInconsistencia(ref InconsistenciaDigitador i)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertInconsistenciaDigitador");

            _manejador.agregarParametro(comando, "@deposito", i.Deposito, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", i.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", i.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", i.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@punto_venta", i.Punto_venta.Id, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@t", i.T, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@referencia_erronea", i.Referencia_erronea, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto_erroneo", i.Monto_erroneo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cuenta_erronea", i.Cuenta_erronea, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@moneda_erronea", i.Moneda_erronea, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@roe_cedula_incorrecta", i.ROE_cedula_incorrecta, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@roe_origen_incorrecto", i.ROE_origen_incorrecto, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@roe_cuenta_incorrecta", i.ROE_cuenta_incorrecta, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@roe_reimpresion", i.ROE_reimpresion, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@roe_firma", i.ROE_firma, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@roe_sello", i.ROE_sello, SqlDbType.Bit);

            try
            {
                i.Id = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorInconsistenciaDigitadorRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de una inconsistencia causadas por un digitador.
        /// </summary>
        /// <param name="i">Objeto InconsistenciaDigitador con los datos de la inconsistencia</param>
        public void actualizarInconsistencia(InconsistenciaDigitador i)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateInconsistenciaDigitador");

            _manejador.agregarParametro(comando, "@deposito", i.Deposito, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", i.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", i.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", i.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@punto_venta", i.Punto_venta.Id, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@t", i.T, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@referencia_erronea", i.Referencia_erronea, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto_erroneo", i.Monto_erroneo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cuenta_erronea", i.Cuenta_erronea, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@moneda_erronea", i.Moneda_erronea, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@roe_cedula_incorrecta", i.ROE_cedula_incorrecta, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@roe_origen_incorrecto", i.ROE_origen_incorrecto, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@roe_cuenta_incorrecta", i.ROE_cuenta_incorrecta, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@roe_reimpresion", i.ROE_reimpresion, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@roe_firma", i.ROE_firma, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@roe_sello", i.ROE_sello, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@inconsistencia", i.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorInconsistenciaDigitadorActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de una inconsistencia causadas por un digitador.
        /// </summary>
        /// <param name="i">Objeto InconsistenciaDigitador con los datos de la inconsistencia</param>
        public void eliminarInconsistencia(InconsistenciaDigitador i)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteInconsistenciaDigitador");

            _manejador.agregarParametro(comando, "@inconsistencia", i.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorInconsistenciaDigitadorEliminacion");
            }

        }

        /// <summary>
        /// Listar las inconsistencias causadas por digitadores registradas durante un periodo de tiempo.
        /// </summary>
        /// <param name="i">Fecha inicial del periodo de tiempo</param>
        /// <param name="f">Fecha final del periodo de tiempo</param>
        /// <returns>Lista de las inconsistencias registrados en el periodo de tiempo indicado</returns>
        public BindingList<InconsistenciaDigitador> listarInconsistencias(DateTime i, DateTime f)
        {
            BindingList<InconsistenciaDigitador> inconsistencias = new BindingList<InconsistenciaDigitador>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectInconsistenciasDigitadores");
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
                    byte t = (byte)datareader["T"];

                    int? referencia_erronea = datareader["Referencia_Erronea"] as int?;
                    decimal? monto_erroneo = datareader["Monto_Erroneo"] as decimal?;
                    int? cuenta_erronea = datareader["Cuenta_Erronea"] as int?;
                    Monedas? moneda_erronea = datareader["Moneda_Erronea"] as Monedas?;

	                bool roe_cedula_incorrecta = (bool)datareader["ROE_Cedula_Incorrecta"];
	                bool roe_origen_incorrecto = (bool)datareader["ROE_Origen_Incorrecto"];
	                bool roe_cuenta_incorrecta = (bool)datareader["ROE_Cuenta_Incorrecta"];
                    bool roe_reimpresion = (bool)datareader["ROE_Reimpresion"];
                    bool roe_firma = (bool)datareader["ROE_Firma"];
                    bool roe_sello = (bool)datareader["ROE_Sello"];

                    short id_punto_venta = (short)datareader["ID_Punto_Venta"];
                    string nombre_punto_venta = (string)datareader["Nombre_Punto_Venta"];

                    short id_cliente = (short)datareader["ID_Cliente"];
                    string nombre_cliente = (string)datareader["Nombre_Cliente"];

                    int id_coordinador = (int)datareader["ID_Coordinador"];
                    string nombre_coordinador = (string)datareader["Nombre_Coordinador"];
                    string primer_apellido_coordinador = (string)datareader["Primer_Apellido_Coordinador"];
                    string segundo_apellido_coordinador = (string)datareader["Segundo_Apellido_Coordinador"];

                    int id_digitador = (int)datareader["ID_Digitador"];
                    string nombre_digitador = (string)datareader["Nombre_Digitador"];
                    string primer_apellido_digitador = (string)datareader["Primer_Apellido_Digitador"];
                    string segundo_apellido_digitador = (string)datareader["Segundo_Apellido_Digitador"];

                    int id_deposito = (int)datareader["ID_Deposito"];
                    long referencia_deposito = (long)datareader["Referencia"];
                    decimal monto_deposito = (decimal)datareader["Monto"];
                    Monedas moneda_deposito = (Monedas)datareader["Moneda"];
                    long cuenta_deposito = (long)datareader["Cuenta"];

                    Deposito deposito = new Deposito(referencia_deposito, id: id_deposito, monto: monto_deposito, moneda: moneda_deposito,
                                                     cuenta: cuenta_deposito);
                    Colaborador coordinador = new Colaborador(id_coordinador, nombre_coordinador, primer_apellido_coordinador,
                                                              segundo_apellido_coordinador);
                    Colaborador digitador = new Colaborador(id_digitador, nombre_digitador, primer_apellido_digitador,
                                                            segundo_apellido_digitador);
                    Cliente cliente = new Cliente(id_cliente, nombre_cliente);
                    PuntoVenta punto_venta = new PuntoVenta(id_punto_venta, nombre_punto_venta, cliente);

                    InconsistenciaDigitador inconsistencia =
                        new InconsistenciaDigitador(id: id_inconsistenca, deposito: deposito, coordinador: coordinador, digitador: digitador,
                                                    fecha: fecha, punto_venta: punto_venta, referencia_erronea: referencia_erronea,
                                                    cuenta_erronea: cuenta_erronea, monto_erroneo: monto_erroneo,
                                                    moneda_erronea: moneda_erronea, roe_cedula_incorrecta: roe_cedula_incorrecta,
                                                    roe_cuenta_incorrecta: roe_cuenta_incorrecta, roe_origen_incorrecto: roe_origen_incorrecto,
                                                    roe_reimpresion: roe_reimpresion, roe_firma: roe_firma, roe_sello: roe_sello, t: t);

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
        
        #endregion Métodos Públicos

    }

}
