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
    public class LibroMayorBovedaDL : ObjetoIndexado
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static LibroMayorBovedaDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static LibroMayorBovedaDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new LibroMayorBovedaDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public LibroMayorBovedaDL() { }

        #endregion Constructor

        #region Métodos Públicos


        #region LibroMayorEntregas

        /// <summary>
        /// Registrar un LibroMayor.
        /// </summary>
        /// <param name="c">Objeto LibroMayor con los datos del LibroMayor</param>
        public void agregarLibroMayor(ref LibroMayor c, Colaborador usuario, DateTime fecha)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertLibroMayorBovedaEntrega");

            _manejador.agregarParametro(comando, "@codigo", c.Codigo, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@colaborador", usuario, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cola_dolares", c.ColaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cola_euros", c.ColaEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cola_colones", c.Cola, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@monto_10000_colones", c.Monto10000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_1000_colones", c.Monto1000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_colones", c.Monto100Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_dolares", c.Monto100Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_euros", c.Monto100Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_colones", c.Monto10Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_dolares", c.Monto10Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_euros", c.Monto10Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20000_colones", c.Monto20000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_2000_colones", c.Monto2000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_200_euros", c.Monto200Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20_dolares", c.Monto20Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20_euros", c.Monto20Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_25_colones", c.Monto25Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_2_dolares", c.Monto2Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50000_colones", c.Monto50000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5000_colones", c.Monto5000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_500_colones", c.Monto500Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_500_euros", c.Monto500Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_colones", c.Monto50Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_dolares", c.Monto50Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_euros", c.Monto50Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_colones", c.Monto5Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_dolares", c.Monto5Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_euros", c.Monto5Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_colones", c.Mutilado, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_dolares", c.MutiladoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_euros", c.MutiladoEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@observaciones", c.Observaciones, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@tipo", c.TipoLibroEntregas, SqlDbType.Int);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSaldoLibroBovedaDatosRegistro");
            }

        }


        /// <summary>
        /// Obtiene la cantidad de cajeros por montos de denominacion 
        /// </summary>
        /// <param name="fecha">Fecha en la que se realiza el procesamiento</param>
        /// <returns>Cantidad de cajeros</returns>
        public int cantidadCAjeros(DateTime fecha)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCantidadCajerosCEF");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                int cantidad = 0;
                if (datareader.Read())
                {
                    cantidad = (int)datareader["Cantidad"];

                }


                comando.Connection.Close();

                return cantidad;
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }


        /// <summary>
        /// Actualizar los datos de un LibroMayor en el sistema.
        /// </summary>
        /// <param name="c">Objeto LibroMayor con los datos del LibroMayor</param>
        public void actualizarLibroMayor(LibroMayor c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateLibroMayorBovedaEntrega");

            _manejador.agregarParametro(comando, "@cola_dolares", c.ColaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cola_euros", c.ColaEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cola_colones", c.Cola, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10000_colones", c.Monto10000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_1000_colones", c.Monto1000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_colones", c.Monto100Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_dolares", c.Monto100Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_euros", c.Monto100Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_colones", c.Monto10Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_dolares", c.Monto10Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_euros", c.Monto10Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20000_colones", c.Monto20000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_2000_colones", c.Monto2000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_200_euros", c.Monto200Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20_dolares", c.Monto20Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20_euros", c.Monto20Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_25_colones", c.Monto25Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_2_dolares", c.Monto2Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50000_colones", c.Monto50000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5000_colones", c.Monto5000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_500_colones", c.Monto500Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_500_euros", c.Monto500Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_colones", c.Monto50Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_dolares", c.Monto50Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_euros", c.Monto50Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_colones", c.Monto5Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_dolares", c.Monto5Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_euros", c.Monto5Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_colones", c.Mutilado, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_dolares", c.MutiladoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_euros", c.MutiladoEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@observaciones", c.Observaciones, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@tipo", c.TipoLibroEntregas, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@libro", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorLibroMayorActualizacion");
            }

        }

        public void actualizarLibroMayorSites(DateTime fecha)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateLibroMayorBovedaEntregaSITES");

            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.DateTime);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorLibroMayorActualizacion");
            }

        }

        //public void actualizarLibroMayorBovedaEntrega(DateTime fecha)
        //{
        //    SqlCommand comando = _manejador.obtenerProcedimiento("UpdateLibroMayorBovedaEntregaSITES");

        //    _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);

        //    try
        //    {
        //        _manejador.ejecutarConsultaActualizacion(comando);
        //        comando.Connection.Close();
        //    }
        //    catch (Exception)
        //    {
        //        comando.Connection.Close();
        //        throw new Excepcion("ErrorLibroMayorActualizacion");
        //    }

        //}
     
        /// <summary>
        /// Listar los LibroMayors registrados en el sistema.
        /// </summary>
        /// <returns>Lista de los LibroMayors registrados en el sistema</returns>
        public BindingList<LibroMayor> listarLibroMayors(DateTime fecha)
        {
            BindingList<LibroMayor> LibroMayors = new BindingList<LibroMayor>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectEntregasBoveda");

            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);

            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_LibroMayor = (int)datareader["pk_ID"];
                    //string observaciones = (string)datareader["Observaciones"];
                    string codigo = (string)datareader["Codigo"];
                    Colaborador colaborador = null; 
                    if(datareader["fk_ID_Usuario"]!=DBNull.Value)
                    {
                        int id_colaborador = (int)datareader["fk_ID_Usuario"];
                        string nombre_colaborador = (string)datareader["Nombre"];
                        string primer_apellido = (string)datareader["Primer_Apellido"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido"];
                    }

                    DateTime fecha_registro = (DateTime)datareader["Fecha_Registro"];
                    decimal cola_dolares = (decimal)datareader["Cola_Dolares"];
                    decimal cola_euros = (decimal)datareader["Cola_Euros"];
                    decimal cola_colones = (decimal)datareader["Cola"];
                    decimal monto_10000_colones = (decimal)datareader["10000_Colones"];
                    decimal monto_1000_colones = (decimal)datareader["1000_Colones"];
                    decimal monto_100_colones = (decimal)datareader["100_Colones"];
                    decimal monto_100_dolares = (decimal)datareader["100_Dolares"];
                    decimal monto_100_euros = (decimal)datareader["100_Euros"];
                    decimal monto_10_colones = (decimal)datareader["10_Colones"];
                    decimal monto_10_dolares = (decimal)datareader["10_Dolares"];
                    decimal monto_10_euros = (decimal)datareader["10_Euros"];
                    decimal monto_1_dolares = (decimal)datareader["1_Dolares"];
                    decimal monto_20000_colones = (decimal)datareader["20000_Colones"];
                    decimal monto_2000_colones = (decimal)datareader["2000_Colones"];
                    decimal monto_200_euros = (decimal)datareader["200_Euros"];
                    decimal monto_20_dolares = (decimal)datareader["20_Dolares"];
                    decimal monto_20_euros = (decimal)datareader["20_Euros"];
                    decimal monto_25_colones = (decimal)datareader["25_Colones"];
                    decimal monto_2_dolares = (decimal)datareader["2_Dolares"];
                    decimal monto_50000_colones = (decimal)datareader["50000_Colones"];
                    decimal monto_5000_colones = (decimal)datareader["5000_Colones"];
                    decimal monto_500_colones = (decimal)datareader["500_Colones"];
                    decimal monto_500_euros = (decimal)datareader["500_Euros"];
                    decimal monto_50_colones = (decimal)datareader["50_Colones"];
                    decimal monto_50_dolares = (decimal)datareader["50_Dolares"];
                    decimal monto_50_euros = (decimal)datareader["50_Euros"];
                    decimal monto_5_colones = (decimal)datareader["5_Colones"];
                    decimal monto_5_dolares = (decimal)datareader["5_Dolares"];
                    decimal monto_5_euros = (decimal)datareader["5_Euros"];
                    decimal mutilado_colones = (decimal)datareader["Mutilado"];
                    decimal mutilado_dolares = (decimal)datareader["Mutilado_Dolares"];
                    decimal mutilado_euros = (decimal)datareader["Mutilado_Euros"];
                    TipoClaseLibroMayorEntregas tipo = (TipoClaseLibroMayorEntregas)datareader["TipoTramiteLibro"];
                   

                    LibroMayor libro = new LibroMayor(id:id_LibroMayor,monto50000colones: monto_50000_colones,monto20000colones:monto_20000_colones, monto10000colones: monto_10000_colones,
                        monto5000colones:monto_5000_colones, monto2000colones: monto_2000_colones, monto1000colones: monto_1000_colones, monto500colones: monto_500_colones, monto100colones: monto_100_colones,
                        monto50colones:monto_50_colones,monto25colones: monto_25_colones,monto10colones:monto_10_colones,monto5colones: monto_5_colones, monto100dolares:monto_100_dolares, monto50dolares : monto_50_dolares,
                        monto20dolares: monto_20_dolares, monto10dolares: monto_10_dolares,monto5dolares: monto_5_dolares, monto2dolares: monto_2_dolares, monto1dolares: monto_1_dolares,monto500euros: monto_500_euros,
                        monto200euros: monto_200_euros, monto100euros: monto_100_euros,monto50euros:monto_50_euros, monto20euros: monto_20_euros, monto10euros: monto_10_euros, monto5euros: monto_5_euros,fecha_asignada: fecha_registro,
                        colaborador: colaborador, observaciones: "", tipoentrega: tipo, codigo: codigo, mutilado: mutilado_colones, cola: cola_colones, mutiladodolares: mutilado_dolares, coladolares: cola_dolares,
                        mutiladoeuros: mutilado_euros, colaeuros:cola_euros);



                    LibroMayors.Add(libro);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return LibroMayors;
        }

       
        /// <summary>
        /// Verificar si existe un LibroMayor.
        /// </summary>
        /// <param name="c">Objeto LibroMayor con los datos del LibroMayor a verificar</param>
        /// <returns>Valor que indica si el LibroMayor existe</returns>
        public bool verificarLibroMayor(DateTime fecha)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteLibroMayor");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@numero", fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["Cantidad"];

                    if (id > 0)
                        existe = true;
                    else
                        existe = false;

                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarLibroMayorDuplicado");
            }

            return existe;
        }

        #endregion LibroMayorEntrega

        #region LibroMayorPedidos

        /// <summary>
        /// Registrar un LibroMayor.
        /// </summary>
        /// <param name="c">Objeto LibroMayor con los datos del LibroMayor</param>
        public void agregarLibroMayorPedido(ref LibroMayor c, Colaborador usuario, DateTime fecha)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertLibroMayorBovedaPedido");

            _manejador.agregarParametro(comando, "@codigo", c.Codigo, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@colaborador", usuario, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cola_dolares", c.ColaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cola_euros", c.ColaEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cola_colones", c.Cola, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@monto_10000_colones", c.Monto10000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_1000_colones", c.Monto1000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_colones", c.Monto100Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_dolares", c.Monto100Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_euros", c.Monto100Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_colones", c.Monto10Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_dolares", c.Monto10Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_euros", c.Monto10Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20000_colones", c.Monto20000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_2000_colones", c.Monto2000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_200_euros", c.Monto200Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20_dolares", c.Monto20Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20_euros", c.Monto20Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_25_colones", c.Monto25Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_2_dolares", c.Monto2Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50000_colones", c.Monto50000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5000_colones", c.Monto5000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_500_colones", c.Monto500Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_500_euros", c.Monto500Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_colones", c.Monto50Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_dolares", c.Monto50Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_euros", c.Monto50Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_colones", c.Monto5Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_dolares", c.Monto5Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_euros", c.Monto5Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_colones", c.Mutilado, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_dolares", c.MutiladoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_euros", c.MutiladoEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@observaciones", c.Observaciones, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@tipo", c.TipoLibroPedido, SqlDbType.Int);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorLibroMayorRegistro");
            }

        }


        /// <summary>
        /// Obtiene la cantidad de cajeros por montos de denominacion 
        /// </summary>
        /// <param name="fecha">Fecha en la que se realiza el procesamiento</param>
        /// <returns>Cantidad de cajeros</returns>
        public int cantidadCAjerosPedido(DateTime fecha)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCantidadCajerosCEF");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                int cantidad = 0;
                if (datareader.Read())
                {
                    cantidad = (int)datareader["Cantidad"];

                }


                comando.Connection.Close();

                return cantidad;
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }


        /// <summary>
        /// Actualizar los datos de un LibroMayor en el sistema.
        /// </summary>
        /// <param name="c">Objeto LibroMayor con los datos del LibroMayor</param>
        public void actualizarLibroMayorPedido(LibroMayor c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateLibroMayorBovedaPedido");

            _manejador.agregarParametro(comando, "@cola_dolares", c.ColaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cola_euros", c.ColaEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cola_colones", c.Cola, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10000_colones", c.Monto10000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_1000_colones", c.Monto1000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_colones", c.Monto100Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_dolares", c.Monto100Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_euros", c.Monto100Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_colones", c.Monto10Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_dolares", c.Monto10Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_euros", c.Monto10Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20000_colones", c.Monto20000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_2000_colones", c.Monto2000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_200_euros", c.Monto200Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20_dolares", c.Monto20Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20_euros", c.Monto20Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_25_colones", c.Monto25Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_2_dolares", c.Monto2Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50000_colones", c.Monto50000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5000_colones", c.Monto5000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_500_colones", c.Monto500Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_500_euros", c.Monto500Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_colones", c.Monto50Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_dolares", c.Monto50Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_euros", c.Monto50Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_colones", c.Monto5Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_dolares", c.Monto5Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_euros", c.Monto5Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_colones", c.Mutilado, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_dolares", c.MutiladoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_euros", c.MutiladoEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@observaciones", c.Observaciones, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@tipo", c.TipoLibroEntregas, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@libro", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorLibroMayorActualizacion");
            }

        }

        public void actualizarLibroMayorPedidoSITES(DateTime fecha)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateLibroMayorBovedaPedidoSITES");

            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.DateTime);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorLibroMayorActualizacion");
            }

        }


        /// <summary>
        /// Listar los LibroMayors registrados en el sistema.
        /// </summary>
        /// <returns>Lista de los LibroMayors registrados en el sistema</returns>
        public BindingList<LibroMayor> listarLibroMayorPedido(DateTime fecha)
        {
            BindingList<LibroMayor> LibroMayors = new BindingList<LibroMayor>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPedidosBoveda");
            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);

            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_LibroMayor = (int)datareader["pk_ID"];
                    //string observaciones = (string)datareader["Observaciones"];
                    string codigo = (string)datareader["Codigo"];
                    Colaborador colaborador = null;
                    if (datareader["fk_ID_Usuario"] != DBNull.Value)
                    {
                        int id_colaborador = (int)datareader["fk_ID_Usuario"];
                        string nombre_colaborador = (string)datareader["Nombre"];
                        string primer_apellido = (string)datareader["Primer_Apellido"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido"];
                    }

                    DateTime fecha_registro = (DateTime)datareader["Fecha_Registro"];
                    decimal cola_dolares = (decimal)datareader["Cola_Dolares"];
                    decimal cola_euros = (decimal)datareader["Cola_Euros"];
                    decimal cola_colones = (decimal)datareader["Cola"];
                    decimal monto_10000_colones = (decimal)datareader["10000_Colones"];
                    decimal monto_1000_colones = (decimal)datareader["1000_Colones"];
                    decimal monto_100_colones = (decimal)datareader["100_Colones"];
                    decimal monto_100_dolares = (decimal)datareader["100_Dolares"];
                    decimal monto_100_euros = (decimal)datareader["100_Euros"];
                    decimal monto_10_colones = (decimal)datareader["10_Colones"];
                    decimal monto_10_dolares = (decimal)datareader["10_Dolares"];
                    decimal monto_10_euros = (decimal)datareader["10_Euros"];
                    decimal monto_1_dolares = (decimal)datareader["1_Dolares"];
                    decimal monto_20000_colones = (decimal)datareader["20000_Colones"];
                    decimal monto_2000_colones = (decimal)datareader["2000_Colones"];
                    decimal monto_200_euros = (decimal)datareader["200_Euros"];
                    decimal monto_20_dolares = (decimal)datareader["20_Dolares"];
                    decimal monto_20_euros = (decimal)datareader["20_Euros"];
                    decimal monto_25_colones = (decimal)datareader["25_Colones"];
                    decimal monto_2_dolares = (decimal)datareader["2_Dolares"];
                    decimal monto_50000_colones = (decimal)datareader["50000_Colones"];
                    decimal monto_5000_colones = (decimal)datareader["5000_Colones"];
                    decimal monto_500_colones = (decimal)datareader["500_Colones"];
                    decimal monto_500_euros = (decimal)datareader["500_Euros"];
                    decimal monto_50_colones = (decimal)datareader["50_Colones"];
                    decimal monto_50_dolares = (decimal)datareader["50_Dolares"];
                    decimal monto_50_euros = (decimal)datareader["50_Euros"];
                    decimal monto_5_colones = (decimal)datareader["5_Colones"];
                    decimal monto_5_dolares = (decimal)datareader["5_Dolares"];
                    decimal monto_5_euros = (decimal)datareader["5_Euros"];
                    decimal mutilado_colones = (decimal)datareader["Mutilado"];
                    decimal mutilado_dolares = (decimal)datareader["Mutilado_Dolares"];
                    decimal mutilado_euros = (decimal)datareader["Mutilado_Euros"];
                    TipoClaseLibroMayorPedidos tipo = (TipoClaseLibroMayorPedidos)datareader["TipoTramiteLibro"];


                    LibroMayor libro = new LibroMayor(id: id_LibroMayor, monto50000colones: monto_50000_colones, monto20000colones: monto_20000_colones, monto10000colones: monto_10000_colones,
                        monto5000colones: monto_5000_colones, monto2000colones: monto_2000_colones, monto1000colones: monto_1000_colones, monto500colones: monto_500_colones, monto100colones: monto_100_colones,
                        monto50colones: monto_50_colones, monto25colones: monto_25_colones, monto10colones: monto_10_colones, monto5colones: monto_5_colones, monto100dolares: monto_100_dolares, monto50dolares: monto_50_dolares,
                        monto20dolares: monto_20_dolares, monto10dolares: monto_10_dolares, monto5dolares: monto_5_dolares, monto2dolares: monto_2_dolares, monto1dolares: monto_1_dolares, monto500euros: monto_500_euros,
                        monto200euros: monto_200_euros, monto100euros: monto_100_euros, monto50euros: monto_50_euros, monto20euros: monto_20_euros, monto10euros: monto_10_euros, monto5euros: monto_5_euros, fecha_asignada: fecha_registro,
                        colaborador: colaborador, observaciones: "", tipopedido: tipo, codigo: codigo, mutilado: mutilado_colones, cola: cola_colones, mutiladodolares: mutilado_dolares, coladolares: cola_dolares,
                        mutiladoeuros: mutilado_euros, colaeuros: cola_euros);



                    LibroMayors.Add(libro);
                }

                comando.Connection.Close();
             }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return LibroMayors;
        }


        /// <summary>
        /// Verificar si existe un LibroMayor.
        /// </summary>
        /// <param name="c">Objeto LibroMayor con los datos del LibroMayor a verificar</param>
        /// <returns>Valor que indica si el LibroMayor existe</returns>
        public bool verificarLibroMayorPedido(DateTime fecha)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteLibroMayor");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@numero", fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["Cantidad"];

                    if (id > 0)
                        existe = true;
                    else
                        existe = false;

                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarLibroMayorDuplicado");
            }

            return existe;
        }

        #endregion LibroMayorEntrega

        #region LibroMayorNiquelEntregas

        /// <summary>
        /// Registrar un LibroMayor.
        /// </summary>
        /// <param name="c">Objeto LibroMayor con los datos del LibroMayor</param>
        public void agregarLibroMayorNiquelEntrega(ref LibroMayor c, Colaborador usuario, DateTime fecha)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertLibroMayorNiquelEntrega");

            _manejador.agregarParametro(comando, "@codigo", c.Codigo, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@colaborador", usuario, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cola_dolares", c.ColaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cola_euros", c.ColaEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cola_colones", c.Cola, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@monto_10000_colones", c.Monto10000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_1000_colones", c.Monto1000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_colones", c.Monto100Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_dolares", c.Monto100Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_euros", c.Monto100Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_colones", c.Monto10Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_dolares", c.Monto10Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_euros", c.Monto10Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20000_colones", c.Monto20000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_2000_colones", c.Monto2000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_200_euros", c.Monto200Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20_dolares", c.Monto20Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20_euros", c.Monto20Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_25_colones", c.Monto25Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_2_dolares", c.Monto2Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50000_colones", c.Monto50000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5000_colones", c.Monto5000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_500_colones", c.Monto500Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_500_euros", c.Monto500Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_colones", c.Monto50Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_dolares", c.Monto50Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_euros", c.Monto50Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_colones", c.Monto5Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_dolares", c.Monto5Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_euros", c.Monto5Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_colones", c.Mutilado, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_dolares", c.MutiladoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_euros", c.MutiladoEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@observaciones", c.Observaciones, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@tipo", c.TipoLibroEntregas, SqlDbType.Int);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorLibroMayorRegistro");
            }

        }


        /// <summary>
        /// Obtiene la cantidad de cajeros por montos de denominacion 
        /// </summary>
        /// <param name="fecha">Fecha en la que se realiza el procesamiento</param>
        /// <returns>Cantidad de cajeros</returns>
        public int cantidadCAjerosNiquelEntrega(DateTime fecha)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCantidadCajerosCEF");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                int cantidad = 0;
                if (datareader.Read())
                {
                    cantidad = (int)datareader["Cantidad"];

                }


                comando.Connection.Close();

                return cantidad;
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }


        /// <summary>
        /// Actualizar los datos de un LibroMayor en el sistema.
        /// </summary>
        /// <param name="c">Objeto LibroMayor con los datos del LibroMayor</param>
        public void actualizarLibroMayorNiquelEntrega(LibroMayor c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateLibroMayorNiquelEntrega");

            _manejador.agregarParametro(comando, "@cola_dolares", c.ColaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cola_euros", c.ColaEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cola_colones", c.Cola, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10000_colones", c.Monto10000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_1000_colones", c.Monto1000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_colones", c.Monto100Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_dolares", c.Monto100Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_euros", c.Monto100Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_colones", c.Monto10Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_dolares", c.Monto10Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_euros", c.Monto10Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20000_colones", c.Monto20000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_2000_colones", c.Monto2000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_200_euros", c.Monto200Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20_dolares", c.Monto20Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20_euros", c.Monto20Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_25_colones", c.Monto25Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_2_dolares", c.Monto2Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50000_colones", c.Monto50000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5000_colones", c.Monto5000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_500_colones", c.Monto500Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_500_euros", c.Monto500Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_colones", c.Monto50Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_dolares", c.Monto50Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_euros", c.Monto50Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_colones", c.Monto5Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_dolares", c.Monto5Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_euros", c.Monto5Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_colones", c.Mutilado, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_dolares", c.MutiladoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_euros", c.MutiladoEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@observaciones", c.Observaciones, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@tipo", c.TipoLibroEntregas, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@libro", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorLibroMayorActualizacion");
            }

        }

        public void actualizarLibroMayorNiquelEntregaSITES(DateTime fecha)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateLibroMayorNiquelEntregaSITES");

            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.DateTime);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorLibroMayorActualizacion");
            }

        }


        /// <summary>
        /// Listar los LibroMayors registrados en el sistema.
        /// </summary>
        /// <returns>Lista de los LibroMayors registrados en el sistema</returns>
        public BindingList<LibroMayor> listarLibroMayorNiquelEntrega(DateTime fecha)
        {
            BindingList<LibroMayor> LibroMayors = new BindingList<LibroMayor>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectEntregasNiquel");

            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);

            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_LibroMayor = (int)datareader["pk_ID"];
                    //string observaciones = (string)datareader["Observaciones"];
                    string codigo = (string)datareader["Codigo"];
                    Colaborador colaborador = null;
                    if (datareader["fk_ID_Usuario"] != DBNull.Value)
                    {
                        int id_colaborador = (int)datareader["fk_ID_Usuario"];
                        string nombre_colaborador = (string)datareader["Nombre"];
                        string primer_apellido = (string)datareader["Primer_Apellido"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido"];
                    }

                    DateTime fecha_registro = (DateTime)datareader["Fecha_Registro"];
                    decimal cola_dolares = (decimal)datareader["Cola_Dolares"];
                    decimal cola_euros = (decimal)datareader["Cola_Euros"];
                    decimal cola_colones = (decimal)datareader["Cola"];
                    decimal monto_10000_colones = (decimal)datareader["10000_Colones"];
                    decimal monto_1000_colones = (decimal)datareader["1000_Colones"];
                    decimal monto_100_colones = (decimal)datareader["100_Colones"];
                    decimal monto_100_dolares = (decimal)datareader["100_Dolares"];
                    decimal monto_100_euros = (decimal)datareader["100_Euros"];
                    decimal monto_10_colones = (decimal)datareader["10_Colones"];
                    decimal monto_10_dolares = (decimal)datareader["10_Dolares"];
                    decimal monto_10_euros = (decimal)datareader["10_Euros"];
                    decimal monto_1_dolares = (decimal)datareader["1_Dolares"];
                    decimal monto_20000_colones = (decimal)datareader["20000_Colones"];
                    decimal monto_2000_colones = (decimal)datareader["2000_Colones"];
                    decimal monto_200_euros = (decimal)datareader["200_Euros"];
                    decimal monto_20_dolares = (decimal)datareader["20_Dolares"];
                    decimal monto_20_euros = (decimal)datareader["20_Euros"];
                    decimal monto_25_colones = (decimal)datareader["25_Colones"];
                    decimal monto_2_dolares = (decimal)datareader["2_Dolares"];
                    decimal monto_50000_colones = (decimal)datareader["50000_Colones"];
                    decimal monto_5000_colones = (decimal)datareader["5000_Colones"];
                    decimal monto_500_colones = (decimal)datareader["500_Colones"];
                    decimal monto_500_euros = (decimal)datareader["500_Euros"];
                    decimal monto_50_colones = (decimal)datareader["50_Colones"];
                    decimal monto_50_dolares = (decimal)datareader["50_Dolares"];
                    decimal monto_50_euros = (decimal)datareader["50_Euros"];
                    decimal monto_5_colones = (decimal)datareader["5_Colones"];
                    decimal monto_5_dolares = (decimal)datareader["5_Dolares"];
                    decimal monto_5_euros = (decimal)datareader["5_Euros"];
                    decimal mutilado_colones = (decimal)datareader["Mutilado"];
                    decimal mutilado_dolares = (decimal)datareader["Mutilado_Dolares"];
                    decimal mutilado_euros = (decimal)datareader["Mutilado_Euros"];
                    TipoClaseLibroMayorEntregas tipo = (TipoClaseLibroMayorEntregas)datareader["TipoTramiteLibro"];


                    LibroMayor libro = new LibroMayor(id: id_LibroMayor, monto50000colones: monto_50000_colones, monto20000colones: monto_20000_colones, monto10000colones: monto_10000_colones,
                        monto5000colones: monto_5000_colones, monto2000colones: monto_2000_colones, monto1000colones: monto_1000_colones, monto500colones: monto_500_colones, monto100colones: monto_100_colones,
                        monto50colones: monto_50_colones, monto25colones: monto_25_colones, monto10colones: monto_10_colones, monto5colones: monto_5_colones, monto100dolares: monto_100_dolares, monto50dolares: monto_50_dolares,
                        monto20dolares: monto_20_dolares, monto10dolares: monto_10_dolares, monto5dolares: monto_5_dolares, monto2dolares: monto_2_dolares, monto1dolares: monto_1_dolares, monto500euros: monto_500_euros,
                        monto200euros: monto_200_euros, monto100euros: monto_100_euros, monto50euros: monto_50_euros, monto20euros: monto_20_euros, monto10euros: monto_10_euros, monto5euros: monto_5_euros, fecha_asignada: fecha_registro,
                        colaborador: colaborador, observaciones: "", tipoentrega: tipo, codigo: codigo, mutilado: mutilado_colones, cola: cola_colones, mutiladodolares: mutilado_dolares, coladolares: cola_dolares,
                        mutiladoeuros: mutilado_euros, colaeuros: cola_euros);



                    LibroMayors.Add(libro);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return LibroMayors;
        }


        /// <summary>
        /// Verificar si existe un LibroMayor.
        /// </summary>
        /// <param name="c">Objeto LibroMayor con los datos del LibroMayor a verificar</param>
        /// <returns>Valor que indica si el LibroMayor existe</returns>
        public bool verificarLibroMayorNiquelEntrega(DateTime fecha)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteLibroMayor");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@numero", fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["Cantidad"];

                    if (id > 0)
                        existe = true;
                    else
                        existe = false;

                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarLibroMayorDuplicado");
            }

            return existe;
        }

        #endregion LibroMayorNiquelEntrega

        #region LibroMayorNiquelPedidos

        /// <summary>
        /// Registrar un LibroMayor.
        /// </summary>
        /// <param name="c">Objeto LibroMayor con los datos del LibroMayor</param>
        public void agregarLibroMayorNiquelPedido(ref LibroMayor c, Colaborador usuario, DateTime fecha)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertLibroMayorNiquelPedido");

            _manejador.agregarParametro(comando, "@codigo", c.Codigo, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@colaborador", usuario, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cola_dolares", c.ColaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cola_euros", c.ColaEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cola_colones", c.Cola, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@monto_10000_colones", c.Monto10000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_1000_colones", c.Monto1000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_colones", c.Monto100Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_dolares", c.Monto100Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_euros", c.Monto100Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_colones", c.Monto10Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_dolares", c.Monto10Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_euros", c.Monto10Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20000_colones", c.Monto20000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_2000_colones", c.Monto2000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_200_euros", c.Monto200Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20_dolares", c.Monto20Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20_euros", c.Monto20Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_25_colones", c.Monto25Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_2_dolares", c.Monto2Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50000_colones", c.Monto50000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5000_colones", c.Monto5000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_500_colones", c.Monto500Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_500_euros", c.Monto500Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_colones", c.Monto50Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_dolares", c.Monto50Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_euros", c.Monto50Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_colones", c.Monto5Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_dolares", c.Monto5Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_euros", c.Monto5Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_colones", c.Mutilado, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_dolares", c.MutiladoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_euros", c.MutiladoEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@observaciones", c.Observaciones, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@tipo", c.TipoLibroPedido, SqlDbType.Int);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorLibroMayorRegistro");
            }

        }


        /// <summary>
        /// Obtiene la cantidad de cajeros por montos de denominacion 
        /// </summary>
        /// <param name="fecha">Fecha en la que se realiza el procesamiento</param>
        /// <returns>Cantidad de cajeros</returns>
        public int cantidadCAjerosNiquelPedido(DateTime fecha)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCantidadCajerosCEF");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                int cantidad = 0;
                if (datareader.Read())
                {
                    cantidad = (int)datareader["Cantidad"];

                }


                comando.Connection.Close();

                return cantidad;
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }


        /// <summary>
        /// Actualizar los datos de un LibroMayor en el sistema.
        /// </summary>
        /// <param name="c">Objeto LibroMayor con los datos del LibroMayor</param>
        public void actualizarLibroMayorNiquelPedido(LibroMayor c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateLibroMayorNiquelPedido");

            _manejador.agregarParametro(comando, "@cola_dolares", c.ColaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cola_euros", c.ColaEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cola_colones", c.Cola, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10000_colones", c.Monto10000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_1000_colones", c.Monto1000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_colones", c.Monto100Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_dolares", c.Monto100Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_100_euros", c.Monto100Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_colones", c.Monto10Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_dolares", c.Monto10Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_10_euros", c.Monto10Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20000_colones", c.Monto20000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_2000_colones", c.Monto2000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_200_euros", c.Monto200Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20_dolares", c.Monto20Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_20_euros", c.Monto20Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_25_colones", c.Monto25Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_2_dolares", c.Monto2Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50000_colones", c.Monto50000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5000_colones", c.Monto5000Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_500_colones", c.Monto500Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_500_euros", c.Monto500Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_colones", c.Monto50Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_dolares", c.Monto50Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_50_euros", c.Monto50Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_colones", c.Monto5Colones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_dolares", c.Monto5Dolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@monto_5_euros", c.Monto5Euros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_colones", c.Mutilado, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_dolares", c.MutiladoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado_euros", c.MutiladoEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@observaciones", c.Observaciones, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@tipo", c.TipoLibroEntregas, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@libro", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorLibroMayorActualizacion");
            }

        }

        public void actualizarLibroMayorNiquelPedidoSites(DateTime fecha)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateLibroMayorNiquelPedidoSITES");

            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.DateTime);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorLibroMayorActualizacion");
            }

        }


        /// <summary>
        /// Listar los LibroMayors registrados en el sistema.
        /// </summary>
        /// <returns>Lista de los LibroMayors registrados en el sistema</returns>
        public BindingList<LibroMayor> listarLibroMayorNiquelPedido(DateTime fecha)
        {
            BindingList<LibroMayor> LibroMayors = new BindingList<LibroMayor>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPedidosNiquel");
            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);

            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_LibroMayor = (int)datareader["pk_ID"];
                    //string observaciones = (string)datareader["Observaciones"];
                    string codigo = (string)datareader["Codigo"];
                    Colaborador colaborador = null;
                    if (datareader["fk_ID_Usuario"] != DBNull.Value)
                    {
                        int id_colaborador = (int)datareader["fk_ID_Usuario"];
                        string nombre_colaborador = (string)datareader["Nombre"];
                        string primer_apellido = (string)datareader["Primer_Apellido"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido"];
                    }

                    DateTime fecha_registro = (DateTime)datareader["Fecha_Registro"];
                    decimal cola_dolares = (decimal)datareader["Cola_Dolares"];
                    decimal cola_euros = (decimal)datareader["Cola_Euros"];
                    decimal cola_colones = (decimal)datareader["Cola"];
                    decimal monto_10000_colones = (decimal)datareader["10000_Colones"];
                    decimal monto_1000_colones = (decimal)datareader["1000_Colones"];
                    decimal monto_100_colones = (decimal)datareader["100_Colones"];
                    decimal monto_100_dolares = (decimal)datareader["100_Dolares"];
                    decimal monto_100_euros = (decimal)datareader["100_Euros"];
                    decimal monto_10_colones = (decimal)datareader["10_Colones"];
                    decimal monto_10_dolares = (decimal)datareader["10_Dolares"];
                    decimal monto_10_euros = (decimal)datareader["10_Euros"];
                    decimal monto_1_dolares = (decimal)datareader["1_Dolares"];
                    decimal monto_20000_colones = (decimal)datareader["20000_Colones"];
                    decimal monto_2000_colones = (decimal)datareader["2000_Colones"];
                    decimal monto_200_euros = (decimal)datareader["200_Euros"];
                    decimal monto_20_dolares = (decimal)datareader["20_Dolares"];
                    decimal monto_20_euros = (decimal)datareader["20_Euros"];
                    decimal monto_25_colones = (decimal)datareader["25_Colones"];
                    decimal monto_2_dolares = (decimal)datareader["2_Dolares"];
                    decimal monto_50000_colones = (decimal)datareader["50000_Colones"];
                    decimal monto_5000_colones = (decimal)datareader["5000_Colones"];
                    decimal monto_500_colones = (decimal)datareader["500_Colones"];
                    decimal monto_500_euros = (decimal)datareader["500_Euros"];
                    decimal monto_50_colones = (decimal)datareader["50_Colones"];
                    decimal monto_50_dolares = (decimal)datareader["50_Dolares"];
                    decimal monto_50_euros = (decimal)datareader["50_Euros"];
                    decimal monto_5_colones = (decimal)datareader["5_Colones"];
                    decimal monto_5_dolares = (decimal)datareader["5_Dolares"];
                    decimal monto_5_euros = (decimal)datareader["5_Euros"];
                    decimal mutilado_colones = (decimal)datareader["Mutilado"];
                    decimal mutilado_dolares = (decimal)datareader["Mutilado_Dolares"];
                    decimal mutilado_euros = (decimal)datareader["Mutilado_Euros"];
                    TipoClaseLibroMayorPedidos tipo = (TipoClaseLibroMayorPedidos)datareader["TipoTramiteLibro"];


                    LibroMayor libro = new LibroMayor(id: id_LibroMayor, monto50000colones: monto_50000_colones, monto20000colones: monto_20000_colones, monto10000colones: monto_10000_colones,
                        monto5000colones: monto_5000_colones, monto2000colones: monto_2000_colones, monto1000colones: monto_1000_colones, monto500colones: monto_500_colones, monto100colones: monto_100_colones,
                        monto50colones: monto_50_colones, monto25colones: monto_25_colones, monto10colones: monto_10_colones, monto5colones: monto_5_colones, monto100dolares: monto_100_dolares, monto50dolares: monto_50_dolares,
                        monto20dolares: monto_20_dolares, monto10dolares: monto_10_dolares, monto5dolares: monto_5_dolares, monto2dolares: monto_2_dolares, monto1dolares: monto_1_dolares, monto500euros: monto_500_euros,
                        monto200euros: monto_200_euros, monto100euros: monto_100_euros, monto50euros: monto_50_euros, monto20euros: monto_20_euros, monto10euros: monto_10_euros, monto5euros: monto_5_euros, fecha_asignada: fecha_registro,
                        colaborador: colaborador, observaciones: "", tipopedido: tipo, codigo: codigo, mutilado: mutilado_colones, cola: cola_colones, mutiladodolares: mutilado_dolares, coladolares: cola_dolares,
                        mutiladoeuros: mutilado_euros, colaeuros: cola_euros);



                    LibroMayors.Add(libro);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return LibroMayors;
        }


        /// <summary>
        /// Verificar si existe un LibroMayor.
        /// </summary>
        /// <param name="c">Objeto LibroMayor con los datos del LibroMayor a verificar</param>
        /// <returns>Valor que indica si el LibroMayor existe</returns>
        public bool verificarLibroMayorNiquelPedido(DateTime fecha)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteLibroMayor");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@numero", fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["Cantidad"];

                    if (id > 0)
                        existe = true;
                    else
                        existe = false;

                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarLibroMayorDuplicado");
            }

            return existe;
        }

        #endregion LibroMayorEntrega

        #endregion Métodos Públicos
    }
}
