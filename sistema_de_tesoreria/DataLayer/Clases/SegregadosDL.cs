//
//  @ Project : 
//  @ File Name : SegregadosDL.cs
//  @ Date : 10/11/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;

namespace DataLayer
{

    /// <summary>
    /// Clase de la capa de datos que maneja los manifiestos segregados.
    /// </summary>
    public class SegregadosDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static SegregadosDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static SegregadosDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SegregadosDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public SegregadosDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo manifiesto segregado del CEF.
        /// </summary>
        /// <param name="s">Objeto SegregadoCEF con los datos del nuevo manifiesto segregado</param>
        public void agregarSegregado(ref SegregadoCEF s)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertSegregado");

            _manejador.agregarParametro(comando, "@manifiesto", s.Manifiesto, SqlDbType.VarChar);

            try
            {
                s.Id = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSegregadosRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un manifiesto segregado del CEF.
        /// </summary>
        /// <param name="s">Objeto SegregadoCEF con los datos del manifiesto segregado a actualizar</param>
        /// <param name="c">Coordinador que realiza la actualización</param>
        public void actualizarSegregado(SegregadoCEF s, Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateSegregado");

            _manejador.agregarParametro(comando, "@cajero", s.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", s.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", s.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador_encargado", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto_colones", s.Monto_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_dolares", s.Monto_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_euros", s.Monto_Euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@depositos", s.Depositos, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@punto_venta", s.Punto_venta.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", s.Fecha_procesamiento, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@segregado", s.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSegregadoActualizacion");
            }

        }

        /// <summary>
        /// Actualizar los datos de un manifiesto segregado del CEF.
        /// </summary>
        /// <param name="s">Objeto SegregadoCEF con los datos del manifiesto segregado a actualizar</param>
        public void actualizarSegregadoDatos(SegregadoCEF s)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateSegregadoDatos");

            _manejador.agregarParametro(comando, "@cajero", s.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", s.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", s.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@punto_venta", s.Punto_venta.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", s.Fecha_procesamiento, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@segregado", s.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSegregadoActualizacion");
            }

        }

        /// <summary>
        /// Reiniciar los datos de un manifiesto segregado del CEF.
        /// </summary>
        /// <param name="s">Objeto SegregadoCEF con los datos del manifiesto segregado a reiniciar</param>
        public void reiniciarSegregado(SegregadoCEF s)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateSegregadoReiniciar");

            _manejador.agregarParametro(comando, "@segregado", s.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSegregadoActualizacion");
            }

        }

        /// <summary>
        /// Método que permite eliminar los segregados de un manifiesto del CEF.
        /// </summary>
        /// <param name="m">Manifiesto para el cual se eliminan los segregados</param>
        public void eliminarSegregados(ManifiestoCEF m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteSegregadosManifiesto");

            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSegregadosEliminacion");
            }

        }

        /// <summary>
        /// Obtener una lista de los manifiestos segregados que son parte de un manifiesto del CEF.
        /// </summary>
        /// <param name="m">Manifiesto del CEF para el cual se obtienen los manifiestos segregados</param>
        public void obtenerSegregados(ref ManifiestoCEF m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectSegregadosManifiesto");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    decimal monto_colones = (decimal)datareader["Monto_Colones"];
                    decimal monto_dolones = (decimal)datareader["Monto_Dolares"];
                    decimal monto_euros = 0;
                    if (datareader["Monto_Euros"] != DBNull.Value)
                        monto_euros = (decimal)datareader["Monto_Euros"];

                    short depositos = (short)datareader["Depositos"];

                    SegregadoCEF segregado = new SegregadoCEF(id, m, monto_colones, monto_dolones, monto_euros, depositos);

                    m.agregarSegregado(segregado);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        /// <summary>
        /// Obtener el coordinador, cajero, el digitador, la sucursal y la fecha de procesamiento de un manifiesto segregado del CEF.
        /// </summary>
        /// <param name="s">Objeto SegregadoCEF con los datos del manifiesto segregado para el cual se obtienen los datos</param>
        public void obtenerDatosSegregado(ref SegregadoCEF s)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectSegregadoDatos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@segregado", s.Id, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    DateTime fecha_procesamiento = (DateTime)datareader["Fecha_Procesamiento"];

                    int id_cajero = (int)datareader["ID_Cajero"];
                    string nombre_cajero = (string)datareader["Nombre_Cajero"];
                    string primer_apellido_cajero = (string)datareader["Primer_Apellido_Cajero"];
                    string segundo_apellido_cajero = (string)datareader["Segundo_Apellido_Cajero"];

                    int id_digitador = (int)datareader["ID_Digitador"];
                    string nombre_digitador = (string)datareader["Nombre_Digitador"];
                    string primer_apellido_digitador = (string)datareader["Primer_Apellido_Digitador"];
                    string segundo_apellido_digitador = (string)datareader["Segundo_Apellido_Digitador"];

                    int id_coordinador = (int)datareader["ID_Coordinador"];
                    string nombre_coordinador = (string)datareader["Nombre_Coordinador"];
                    string primer_apellido_coordinador = (string)datareader["Primer_Apellido_Coordinador"];
                    string segundo_apellido_coordinador = (string)datareader["Segundo_Apellido_Coordinador"];

                    short id_punto_venta = (short)datareader["ID_Punto_Venta"];
                    string nombre_punto_venta = (string)datareader["Nombre_Punto_Venta"];

                    short id_cliente = (short)datareader["ID_Cliente"];
                    string nombre_cliente = (string)datareader["Nombre_Cliente"];

                    Cliente cliente = new Cliente(id_cliente, nombre_cliente);
                    PuntoVenta punto_venta = new PuntoVenta(id_punto_venta, nombre_punto_venta, cliente);
                    Colaborador cajero = new Colaborador(id_cajero, nombre_cajero, primer_apellido_cajero, segundo_apellido_cajero);
                    Colaborador digitador = new Colaborador(id_digitador, nombre_digitador, primer_apellido_digitador, segundo_apellido_digitador);
                    Colaborador coordinador = new Colaborador(id_coordinador, nombre_coordinador, primer_apellido_coordinador, segundo_apellido_coordinador);

                    s.Punto_venta = punto_venta;
                    s.Cajero = cajero;
                    s.Digitador = digitador;
                    s.Coordinador = coordinador;
                    s.Fecha_procesamiento = fecha_procesamiento;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }
               
        #endregion Métodos Públicos

    }

}
