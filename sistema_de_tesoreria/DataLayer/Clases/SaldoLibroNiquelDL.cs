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
    public class SaldoLibroNiquelDL : ObjetoIndexado
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static SaldoLibroNiquelDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static SaldoLibroNiquelDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SaldoLibroNiquelDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public SaldoLibroNiquelDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo SaldoLibroBoveda en el sistema.
        /// </summary>
        /// <param name="c">Objeto SaldoLibroBoveda con los datos del nuevo SaldoLibroBoveda</param>
        public void agregarSaldoLibroNiquel(ref SaldoLibroBoveda c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertSaldoLibroNiquel");

            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@colaborador", c.Colaborador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto_colones", c.MontoColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_dolares", c.MontoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_euros", c.MontoEuros, SqlDbType.Decimal);

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
        public void actualizarSaldoLibroNiquel(SaldoLibroBoveda c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateSaldoLibroNiquel");

            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@colaborador", c.Colaborador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto_colones", c.MontoColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_dolares", c.MontoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_euros", c.MontoEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldo", c.ID, SqlDbType.Int);

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
        public void eliminarSaldoLibroNiquel(SaldoLibroBoveda c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteSaldoLibroNiquel");

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

        public BindingList<SaldoLibroBoveda> listarSaldoLibroNiquel(DateTime f)
        {
            BindingList<SaldoLibroBoveda> SaldoLibroBovedas = new BindingList<SaldoLibroBoveda>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectSaldoLibroNiquel");
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


        public SaldoLibroNiquel listarSaldoNiquel(DateTime f)
        {
            SaldoLibroNiquel SaldoLibroN = new SaldoLibroNiquel();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectSaldoNiquel");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    SaldoLibroN.MontoColones = (decimal)datareader["Monto_Colones"];
                    SaldoLibroN.MontoDolares = (decimal)datareader["Monto_Dolares"];
                    SaldoLibroN.MontoEuros = (decimal)datareader["Monto_Euros"];
                    SaldoLibroN.CustodiaAuxiliar = (decimal)datareader["CAN"];
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return SaldoLibroN;
        }

        /// <summary>
        /// Listar a los SaldoLibroBovedas del sistema.
        /// </summary>
        /// <param name="n">Parte del nombre de los SaldoLibroBovedas a listar</param>
        /// <returns>Lista de los SaldoLibroBoveda registrados en el sistema</returns>
        //public BindingList<SaldoLibroBoveda> listarSaldoLibroNiquel(string n)
        //{
        //    BindingList<SaldoLibroBoveda> SaldoLibroBovedas = new BindingList<SaldoLibroBoveda>();

        //    SqlCommand comando = _manejador.obtenerProcedimiento("SelectSaldoLibroNiquel");
        //    SqlDataReader datareader = null;

        //    _manejador.agregarParametro(comando, "@nombre", n, SqlDbType.VarChar);

        //    try
        //    {
        //        datareader = _manejador.ejecutarConsultaDatos(comando);

        //        while (datareader.Read())
        //        {
        //            int id = (int)datareader["ID_Saldo"];
        //            DateTime fecha = (DateTime)datareader["Fecha"];
        //            decimal monto_colones = (decimal)datareader["Monto_Colones"];
        //            decimal monto_dolares = (decimal)datareader["Monto_Dolares"];
        //            decimal monto_euros = (decimal)datareader["Monto_Euros"];

        //            byte id_denominacion = (byte)datareader["ID_Denominacion"];
        //            decimal valor = (decimal)datareader["Valor"];
        //            Monedas moneda = (Monedas)datareader["Moneda"];
        //            string codigo = (string)datareader["Codigo"];
        //            string configuracion_diebold = (string)datareader["Configuracion_Diebold"];
        //            string configuracion_opteva = (string)datareader["Configuracion_Opteva"];
        //            byte? id_imagen = datareader["ID_Imagen"] as byte?;

        //            int id_colaborador = (int)datareader["ID_Colaborador"];
        //            string nombre_colaborador = (string)datareader["Nombre"];
        //            string primer_apellido = (string)datareader["Primer_Apellido"];
        //            string segundo_apellido = (string)datareader["Segundo_Apellido"];

        //            Colaborador c = new Colaborador(id: id_colaborador, nombre: nombre_colaborador, primer_apellido: primer_apellido, segundo_apellido: segundo_apellido);

        //            Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda, codigo: codigo,
        //                                                         id_imagen: id_imagen, configuracion_diebold: configuracion_diebold,
        //                                                         configuracion_opteva: configuracion_opteva);


        //            SaldoLibroBoveda SaldoLibroBoveda = new SaldoLibroBoveda(id: id, fecha_asignada: fecha, monto_colones: monto_colones, monto_dolares: monto_dolares, monto_euros: monto_euros, d: denominacion, colaborador: c);

        //            SaldoLibroBovedas.Add(SaldoLibroBoveda);
        //        }

        //        comando.Connection.Close();
        //    }
        //    catch (Exception)
        //    {
        //        comando.Connection.Close();
        //        throw new Excepcion("ErrorDatosConexion");
        //    }

        //    return SaldoLibroBovedas;
        //}

        /// <summary>
        /// Verificar si existe un SaldoLibroBoveda.
        /// </summary>
        /// <param name="c">Objeto SaldoLibroBoveda con los datos del SaldoLibroBoveda a verificar</param>
        /// <returns>Valor que indica si el SaldoLibroBoveda existe</returns>
        public bool verificarSaldoLibroNiquel(ref SaldoLibroBoveda c)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteSaldoLibroBoveda");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];

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

        #region Final

       public BindingList<SaldoLibroBoveda> listarSaldoLibroNiquelFinal(DateTime f, Colaborador usuario)
        {
            BindingList<SaldoLibroBoveda> SaldoLibroBovedas = new BindingList<SaldoLibroBoveda>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectSaldoLibroNiquelFinal");
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

        #endregion Final
        #endregion Métodos Públicos

    }
}
