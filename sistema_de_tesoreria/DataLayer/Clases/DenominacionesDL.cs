//
//  @ Project : 
//  @ File Name : DenominacionesDL.cs
//  @ Date : 25/05/2012
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

    /// <summary>
    /// Clase de la capa de datos que maneja las denominaciones.
    /// </summary>
    public class DenominacionesDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static DenominacionesDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static DenominacionesDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new DenominacionesDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public DenominacionesDL() { }

        #endregion Constructor

        #region Métodos Públicos
        
        /// <summary>
        /// Obtener una lista de las denominaciones de monedas definidas en el sistema.
        /// </summary>
        /// <returns>Lista de las denominaciones definidas en el sistema</returns>
        public BindingList<Denominacion> listarDenominaciones()
        {
            BindingList<Denominacion> denominaciones = new BindingList<Denominacion>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDenominaciones");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    bool carga_atm = (bool)datareader["Carga_ATM"];
                    bool esmoneda = (bool)datareader["EsMoneda"];
                    byte? id_imagen = datareader["ID_Imagen"] as byte?;
                    string codigo = datareader["Codigo"] as string;
                    string configuracion_diebold = datareader["Configuracion_Diebold"] as string;
                    string configuracion_opteva = datareader["Configuracion_Opteva"] as string;
                    short? formulas_maximas = datareader["Formulas_Maximas"] as short?;
                    short? formulas_minimas = datareader["Formulas_Minimas"] as short?;

                    Denominacion denominacion = new Denominacion(id: id, valor: valor, moneda: moneda, carga_atm: carga_atm, codigo: codigo,
                                                                 id_imagen: id_imagen, configuracion_opteva: configuracion_opteva, 
                                                                 configuracion_diebold: configuracion_diebold, formulas_maximas: formulas_maximas, 
                                                                 formulas_minimas: formulas_minimas, esmoneda:esmoneda);

                    denominaciones.Add(denominacion);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return denominaciones;

        }

        /// <summary>
        /// Obtener una lista de las denominaciones de monedas definidas en el sistema que se utilizan en las cargas de ATM's.
        /// </summary>
        /// <returns>Lista de las denominaciones definidas en el sistema</returns>
        public BindingList<Denominacion> listarDenominacionesCargasATMs()
        {
            BindingList<Denominacion> denominaciones = new BindingList<Denominacion>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDenominacionesCargasATMs");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    string codigo = (string)datareader["Codigo"];
                    string configuracion_diebold = (string)datareader["Configuracion_Diebold"];
                    string configuracion_opteva = (string)datareader["Configuracion_Opteva"];
                    byte id_imagen = (byte)datareader["ID_Imagen"];

                    Denominacion denominacion = new Denominacion(id: id, valor: valor, moneda: moneda, codigo: codigo,
                                                                 configuracion_diebold: configuracion_diebold,
                                                                 configuracion_opteva: configuracion_opteva,
                                                                 id_imagen: id_imagen);

                    denominaciones.Add(denominacion);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return denominaciones;

        }

        /// <summary>
        /// Obtener una lista de las denominaciones de monedas definidas en el sistema que se utilizan en las cargas de ATM's.
        /// </summary>
        /// <returns>Lista de las denominaciones definidas en el sistema</returns>
        public BindingList<Denominacion> listarDenominacionesMonedas()
        {
            BindingList<Denominacion> denominaciones = new BindingList<Denominacion>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDenominacionesMoneda");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    string codigo = "";

                    if (datareader["Codigo"] != DBNull.Value)
                    {
                        codigo = (string)datareader["Codigo"];
                    }
                    string configuracion_diebold = "";
                    if (datareader["Configuracion_Diebold"] != DBNull.Value)
                    {
                        configuracion_diebold = (string)datareader["Configuracion_Diebold"];
                    }
                    string configuracion_opteva = "";
                    if (datareader["Configuracion_Opteva"] != DBNull.Value)
                    {
                        configuracion_opteva = (string)datareader["Configuracion_Opteva"];
                    }
                     byte id_imagen = 0;
                    if (datareader["ID_Imagen"] != DBNull.Value)
                    {
                        id_imagen = (byte)datareader["ID_Imagen"];
                    }


                    Denominacion denominacion = new Denominacion(id: id, valor: valor, moneda: moneda, codigo: codigo,
                                                                 configuracion_diebold: configuracion_diebold,
                                                                 configuracion_opteva: configuracion_opteva,
                                                                 id_imagen: id_imagen);

                    denominaciones.Add(denominacion);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return denominaciones;

        }

        /// <summary>
        /// Obtener una lista de las denominaciones de monedas definidas en el sistema que se utilizan en las cargas de ATM's.
        /// </summary>
        /// <returns>Lista de las denominaciones definidas en el sistema</returns>
        public BindingList<Denominacion> listarDenominacionesCargasSucursales()
        {
            BindingList<Denominacion> denominaciones = new BindingList<Denominacion>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDenominacionesCargasSucursales");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    string codigo = (string)datareader["Codigo"];
                    string configuracion_diebold = (string)datareader["Configuracion_Diebold"];
                    string configuracion_opteva = (string)datareader["Configuracion_Opteva"];
                    byte id_imagen = (byte)datareader["ID_Imagen"];

                    Denominacion denominacion = new Denominacion(id: id, valor: valor, moneda: moneda, codigo: codigo,
                                                                 configuracion_diebold: configuracion_diebold,
                                                                 configuracion_opteva: configuracion_opteva,
                                                                 id_imagen: id_imagen);

                    denominaciones.Add(denominacion);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return denominaciones;

        }
        
        public BindingList<Denominacion> listarDenominacionesxmoneda(byte datomoneda)
        {
            BindingList<Denominacion> denominaciones = new BindingList<Denominacion>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDenominacionesxmoneda");
            SqlDataReader datareader = null;
            _manejador.agregarParametro(comando, "@moneda", datomoneda, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    bool carga_atm = (bool)datareader["Carga_ATM"];
                    bool esmoneda = (bool)datareader["EsMoneda"];
                    byte? id_imagen = datareader["ID_Imagen"] as byte?;
                    string codigo = datareader["Codigo"] as string;
                    string configuracion_diebold = datareader["Configuracion_Diebold"] as string;
                    string configuracion_opteva = datareader["Configuracion_Opteva"] as string;
                    short? formulas_maximas = datareader["Formulas_Maximas"] as short?;
                    short? formulas_minimas = datareader["Formulas_Minimas"] as short?;

                    Denominacion denominacion = new Denominacion(id: id, valor: valor, moneda: moneda, carga_atm: carga_atm, codigo: codigo,
                                                                 id_imagen: id_imagen, configuracion_opteva: configuracion_opteva,
                                                                 configuracion_diebold: configuracion_diebold, formulas_maximas: formulas_maximas,
                                                                 formulas_minimas: formulas_minimas, esmoneda: esmoneda);

                    denominaciones.Add(denominacion);
                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                
                throw new Excepcion("ErrorDatosConexion");
            }

            return denominaciones;

        }

         /// <summary>
        /// Verificar si una denominación esta registrada en el sistema.
        /// </summary>
        /// <returns>valor que indica si la denominación existe</returns>
        public bool verificarDenominacion(ref Denominacion d)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteDenominacion");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@valor", d.Valor, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@moneda", d.Moneda, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    byte id_encontrado = (byte)datareader["pk_ID"];

                    existe = id_encontrado != d.Id;

                    d.Id = id_encontrado;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarDenominacion");
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

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteDenominacionCodigo");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", d.Codigo, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    byte id_encontrado = (byte)datareader["pk_ID"];

                    existe = id_encontrado != d.Id;

                    d.Id = id_encontrado;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarDenominacion");
            }

            return existe;
        }

        /// <summary>
        /// Obtener los datos de una denominación.
        /// </summary>
        /// <param name="d">Denominación para la cual se obtienen los datos</param>
        /// <returns>Valor que indica si la denominación existe</returns>
        public bool obtenerDatosDenominacion(ref Denominacion d)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDenominacionDatos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@denominacion", d, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["moneda"];
                    bool carga_atm = (bool)datareader["Carga_ATM"];
                    short? formulas_maximas = datareader["Formulas_Maximas"] as short?;
                    short? formulas_minimas = datareader["Formulas_Minimas"] as short?;

                    d.Valor = valor;
                    d.Moneda = moneda;
                    d.Carga_atm = carga_atm;
                    d.Formulas_maximas = formulas_maximas;
                    d.Formulas_minimas = formulas_minimas;

                    existe = true;
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



        /// <summary>
        /// Obtener los datos de una denominación.
        /// </summary>
        /// <param name="d">Denominación para la cual se obtienen los datos</param>
        /// <returns>Valor que indica si la denominación existe</returns>
        public Denominacion obtenerDatosDenominacion2(ref Denominacion d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDenominacionDatos");
            SqlDataReader datareader = null;
            Denominacion nueva = new Denominacion();

            _manejador.agregarParametro(comando, "@denominacion", d, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["moneda"];
                    bool carga_atm = (bool)datareader["Carga_ATM"];
                    short? formulas_maximas = datareader["Formulas_Maximas"] as short?;
                    short? formulas_minimas = datareader["Formulas_Minimas"] as short?;

                    d.Valor = valor;
                    d.Moneda = moneda;
                    d.Carga_atm = carga_atm;
                    d.Formulas_maximas = formulas_maximas;
                    d.Formulas_minimas = formulas_minimas;

                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return d;
        }



        /// <summary>
        /// Registrar una Denominacion.
        /// </summary>
        /// <param name="a">Objeto Denominacion con los datos de la Denominacion</param>
        public void agregarDenominacion(ref Denominacion a)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertDenominacion");

            _manejador.agregarParametro(comando, "@valor", a.Valor, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@moneda", a.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@carga_atm", a.Carga_atm, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@codigo", a.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@id_imagen", a.Id_imagen, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@configuracion_diebold", a.Configuracion_diebold, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@configuracion_opteva", a.Configuracion_opteva, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@formulas_maximas", a.Formulas_maximas, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@formulas_maximas", a.Formulas_minimas, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@esmoneda", a.EsMoneda, SqlDbType.Bit);
            

            try
            {
                a.Id = (byte)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorATMRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de una Denominacion en el sistema.
        /// </summary>
        /// <param name="a">Objeto Denominacion con los datos de la Denominacion</param>
        public void actualizarDenominacion(Denominacion a)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateDenominacion");

            _manejador.agregarParametro(comando, "@valor", a.Valor, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@moneda", a.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@carga_atm", a.Carga_atm, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@codigo", a.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@id_imagen", a.Id_imagen, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@configuracion_diebold", a.Configuracion_diebold, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@configuracion_opteva", a.Configuracion_opteva, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@formulas_maximas", a.Formulas_maximas, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@formulas_minimas", a.Formulas_minimas, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@esmoneda", a.EsMoneda, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@denominacion", a, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorATMActualizacion");
            }

        }




        #endregion Métodos Públicos

    }

}
