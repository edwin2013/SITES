using CommonObjects;
using CommonObjects.Clases;
using LibreriaAccesoDatos;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataLayer.Clases
{
    public class SaldoLibroBovedaDL : ObjetoIndexado
    {
       #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static SaldoLibroBovedaDL _instancia;


        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static SaldoLibroBovedaDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SaldoLibroBovedaDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

       #region Constructor

        public SaldoLibroBovedaDL() { }

        #endregion Constructor

       #region Métodos Públicos

        #region Inicial
        /// <summary>
        /// Registrar un nuevo SaldoLibroBoveda en el sistema.
        /// </summary>
        /// <param name="c">Objeto SaldoLibroBoveda con los datos del nuevo SaldoLibroBoveda</param>
        public void agregarSaldoLibroBoveda(ref SaldoLibroBoveda c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertSaldoLibroBoveda");

            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@colaborador", c.Colaborador, SqlDbType.Int);
            //_manejador.agregarParametro(comando, "@monto_colones", c.MontoColones, SqlDbType.Decimal);
            //_manejador.agregarParametro(comando, "@monto_dolares", c.MontoDolares, SqlDbType.Decimal);
            //_manejador.agregarParametro(comando, "@monto_euros", c.MontoEuros, SqlDbType.Decimal);
            //_manejador.agregarParametro(comando, "@denominacion", c.Denominacion, SqlDbType.TinyInt);
            //_manejador.agregarParametro(comando, "@cola_colones", c.ColaColones, SqlDbType.Money);
            //_manejador.agregarParametro(comando, "@cola_dolares", c.ColaDolares, SqlDbType.Money);
            //_manejador.agregarParametro(comando, "@cola_euros", c.ColaEuros, SqlDbType.Money);
            //_manejador.agregarParametro(comando, "@mutilado_colones", c.MutiladoColones, SqlDbType.Money);
            //_manejador.agregarParametro(comando, "@mutilado_euros", c.MutiladoEuros, SqlDbType.Money);
            //_manejador.agregarParametro(comando, "@mutilado_dolares", c.MutiladoDolares, SqlDbType.Money);
            //_manejador.agregarParametro(comando, "@custodia_auxiliar", c.CustodiaAuxiliar, SqlDbType.Money);


            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSaldoLibroBovedaRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un SaldoLibroBoveda en el sistema.
        /// </summary>
        /// <param name="c">Objeto SaldoLibroBoveda con los datos del SaldoLibroBoveda</param>
        public void actualizarSaldoLibroBoveda(SaldoLibroBoveda c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateSaldoLibroBoveda");

            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@colaborador", c.Colaborador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto_colones", c.MontoColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_dolares", c.MontoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_euros", c.MontoEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo", c.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cola_colones", c.ColaColones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cola_dolares", c.ColaDolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cola_euros", c.ColaEuros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@mutilado_colones", c.MutiladoColones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@mutilado_euros", c.MutiladoEuros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@mutilado_dolares", c.MutiladoDolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@custodia_auxiliar", c.CustodiaAuxiliar, SqlDbType.Money);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSaldoLibroBovedaActualizacion");
            }

        }

        /// <summary>
        /// Marcar como inactivo a un SaldoLibroBoveda del sistema.
        /// </summary>
        /// <param name="c">Objeto SaldoLibroBoveda con los datos del SaldoLibroBoveda a marcar</param>
        public void eliminarSaldoLibroBoveda(SaldoLibroBoveda c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteSaldoLibroBoveda");

            _manejador.agregarParametro(comando, "@SaldoLibroBoveda", c.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSaldoLibroBovedaEliminacion");
            }

        }

        /// <summary>
        /// Listar a los SaldoLibroBovedas del sistema.
        /// </summary>
        /// <param name="n">Parte del nombre de los SaldoLibroBovedas a listar</param>
        /// <returns>Lista de los SaldoLibroBoveda registrados en el sistema</returns>
        public BindingList<SaldoLibroBoveda> listarSaldoLibroBoveda(DateTime f)
        {
            BindingList<SaldoLibroBoveda> SaldoLibroBovedas = new BindingList<SaldoLibroBoveda>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectSaldoLibroBoveda");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    DateTime fecha = (DateTime)datareader["Fecha"];
                    decimal monto_colones = (decimal)datareader["Monto_Colones"];
                    decimal monto_dolares = (decimal)datareader["Monto_Dolares"];
                    decimal monto_euros = (decimal)datareader["Monto_Euros"];
                    decimal custodia_auxiliar = (decimal)datareader["Custodia_Auxiliar"];


                    decimal cola_colones = (decimal)datareader["Cola_Colones"];
                    decimal cola_dolares = (decimal)datareader["Cola_Dolares"];
                    decimal cola_euros = (decimal)datareader["Cola_Euros"];


                    decimal mutilado_colones = (decimal)datareader["Mutilado_Colones"];
                    decimal mutilado_dolares = (decimal)datareader["Mutilado_Dolares"];
                    decimal mutilado_euros = (decimal)datareader["Mutilado_Euros"];

                    byte id_denominacion = (byte)datareader["ID_Denominacion"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    
                    int id_colaborador = (int)datareader["ID_Colaborador"];
                    string nombre_colaborador = (string)datareader["Nombre"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];

                    Colaborador c = new Colaborador(id: id_colaborador, nombre: nombre_colaborador, primer_apellido: primer_apellido, segundo_apellido: segundo_apellido);

                    Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda);


                    SaldoLibroBoveda SaldoLibroBoveda = new SaldoLibroBoveda(id:id, fecha_asignada: fecha, monto_colones: monto_colones, monto_dolares: monto_dolares, monto_euros: monto_euros, d: denominacion, colaborador: c,
                        mutilado_colones: mutilado_colones, mutilado_dolares: mutilado_dolares, mutilado_euros: mutilado_euros, cola_colones: cola_colones, cola_dolares: cola_dolares, cola_euros: cola_euros, custodia_auxiliar: custodia_auxiliar);

                    SaldoLibroBovedas.Add(SaldoLibroBoveda);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return SaldoLibroBovedas;
        }

        public SaldoLibroBoveda listarSaldoBoveda(DateTime f)
        {
            SaldoLibroBoveda SaldoLibroBoveda = new SaldoLibroBoveda();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectSaldoBoveda");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    SaldoLibroBoveda.MontoColones = (decimal)datareader["Monto_Colones"];
                    SaldoLibroBoveda.MontoDolares = (decimal)datareader["Monto_Dolares"];
                    SaldoLibroBoveda.MontoEuros = (decimal)datareader["Monto_Euros"];
                    SaldoLibroBoveda.CustodiaAuxiliar = (decimal)datareader["CAN"];
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return SaldoLibroBoveda;
        }

        /// <summary>
        /// Verificar si existe un SaldoLibroBoveda.
        /// </summary>
        /// <param name="c">Objeto SaldoLibroBoveda con los datos del SaldoLibroBoveda a verificar</param>
        /// <returns>Valor que indica si el SaldoLibroBoveda existe</returns>
        public bool verificarSaldoLibroBoveda(ref SaldoLibroBoveda c)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteSaldoLibroBoveda");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    existe = id != c.ID;

                    c.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return existe;
        }

        #endregion Inicial

        #region Final
        /// <summary>
        /// Registrar un nuevo SaldoLibroBoveda en el sistema.
        /// </summary>
        /// <param name="c">Objeto SaldoLibroBoveda con los datos del nuevo SaldoLibroBoveda</param>
        public void agregarSaldoLibroBovedaFinal(ref SaldoLibroBoveda c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertSaldoLibroBovedaFinal");

            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@colaborador", c.Colaborador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto_colones", c.MontoColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_dolares", c.MontoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_euros", c.MontoEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@denominacion", c.Denominacion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cola_colones", c.ColaColones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cola_dolares", c.ColaDolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cola_euros", c.ColaEuros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@mutilado_colones", c.MutiladoColones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@mutilado_euros", c.MutiladoEuros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@mutilado_dolares", c.MutiladoDolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@custodia_auxiliar", c.CustodiaAuxiliar, SqlDbType.Money);
            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        /// <summary>
        /// Actualizar los datos de un SaldoLibroBoveda en el sistema.
        /// </summary>
        /// <param name="c">Objeto SaldoLibroBoveda con los datos del SaldoLibroBoveda</param>
        public void actualizarSaldoLibroBovedaFinal(SaldoLibroBoveda c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateSaldoLibroBovedaFinal");

            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@colaborador", c.Colaborador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto_colones", c.MontoColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_dolares", c.MontoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_euros", c.MontoEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo", c.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cola_colones", c.ColaColones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cola_dolares", c.ColaDolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@cola_euros", c.ColaEuros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@mutilado_colones", c.MutiladoColones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@mutilado_euros", c.MutiladoEuros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@mutilado_dolares", c.MutiladoDolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@custodia_auxiliar", c.CustodiaAuxiliar, SqlDbType.Money);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        /// <summary>
        /// Marcar como inactivo a un SaldoLibroBoveda del sistema.
        /// </summary>
        /// <param name="c">Objeto SaldoLibroBoveda con los datos del SaldoLibroBoveda a marcar</param>
        public void eliminarSaldoLibroBovedaFinal(SaldoLibroBoveda c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteSaldoLibroBovedaFinal");

            _manejador.agregarParametro(comando, "@SaldoLibroBoveda", c.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSaldoLibroBovedaEliminacion");
            }

        }

        /// <summary>
        /// Listar a los SaldoLibroBovedas del sistema.
        /// </summary>
        /// <param name="n">Parte del nombre de los SaldoLibroBovedas a listar</param>
        /// <returns>Lista de los SaldoLibroBoveda registrados en el sistema</returns>
        public BindingList<SaldoLibroBoveda> listarSaldoLibroBovedaFinal(DateTime f, Colaborador usuario)
        {
            BindingList<SaldoLibroBoveda> SaldoLibroBovedas = new BindingList<SaldoLibroBoveda>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectSaldoLibroBovedaFinal");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@colaborador", usuario, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    DateTime fecha = (DateTime)datareader["Fecha"];
                    decimal monto_colones = (decimal)datareader["Monto_Colones"];
                    decimal monto_dolares = (decimal)datareader["Monto_Dolares"];
                    decimal monto_euros = (decimal)datareader["Monto_Euros"];
                    decimal custodia_auxiliar = (decimal)datareader["Custodia_Auxiliar"];


                    decimal cola_colones = (decimal)datareader["Cola_Colones"];
                    decimal cola_dolares = (decimal)datareader["Cola_Dolares"];
                    decimal cola_euros = (decimal)datareader["Cola_Euros"];


                    decimal mutilado_colones = (decimal)datareader["Mutilado_Colones"];
                    decimal mutilado_dolares = (decimal)datareader["Mutilado_Dolares"];
                    decimal mutilado_euros = (decimal)datareader["Mutilado_Euros"];

                    byte id_denominacion = (byte)datareader["ID_Denominacion"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    
                    int id_colaborador = (int)datareader["ID_Colaborador"];
                    string nombre_colaborador = (string)datareader["Nombre"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];

                    Colaborador c = new Colaborador(id: id_colaborador, nombre: nombre_colaborador, primer_apellido: primer_apellido, segundo_apellido: segundo_apellido);

                    Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda);


                    SaldoLibroBoveda SaldoLibroBoveda = new SaldoLibroBoveda(id: id, fecha_asignada: fecha, monto_colones: monto_colones, monto_dolares: monto_dolares, monto_euros: monto_euros, d: denominacion, colaborador: c,
                        mutilado_colones: mutilado_colones, mutilado_dolares: mutilado_dolares, mutilado_euros: mutilado_euros, cola_colones: cola_colones, cola_dolares: cola_dolares, cola_euros: cola_euros, custodia_auxiliar: custodia_auxiliar);

                    SaldoLibroBovedas.Add(SaldoLibroBoveda);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return SaldoLibroBovedas;
        }

        /// <summary>
        /// Verificar si existe un SaldoLibroBoveda.
        /// </summary>
        /// <param name="c">Objeto SaldoLibroBoveda con los datos del SaldoLibroBoveda a verificar</param>
        /// <returns>Valor que indica si el SaldoLibroBoveda existe</returns>
        public bool verificarSaldoLibroBovedaFinal(ref SaldoLibroBoveda c)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteSaldoLibroBovedaFinal");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    existe = id != c.ID;

                    c.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarSaldoLibroBovedaDuplicado");
            }

            return existe;
        }

        #endregion Inicial

        #endregion Métodos Públicos
    }
}
