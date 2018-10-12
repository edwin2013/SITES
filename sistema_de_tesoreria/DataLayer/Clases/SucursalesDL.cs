//
//  @ Project : 
//  @ File Name : SucursalesDL.cs
//  @ Date : 30/04/2011
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

    /// <summary>
    /// Clase de la capa de datos que maneja las sucursales.
    /// </summary>
    public class SucursalesDL
    {
        
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static SucursalesDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static SucursalesDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SucursalesDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public SucursalesDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar una sucursal.
        /// </summary>
        /// <param name="s">Objeto Sucursal con los datos de la sucursal</param>
        public void agregarSucursal(ref Sucursal s)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertSucursal");

            _manejador.agregarParametro(comando, "@nombre", s.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@direccion", s.Direccion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@provincia", s.Provincia, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando,"@tipo",s.TipoSucursal,SqlDbType.TinyInt);
            _manejador.agregarParametro(comando,"@externa",s.Externo,SqlDbType.Bit);
            _manejador.agregarParametro(comando,"@numero",s.Codigo,SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@transportadora", s.Empresa, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@caja", s.CajaEmpresarial, SqlDbType.Bit);

            try
            {
                s.ID = (short)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSucursalRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de una sucursal en el sistema.
        /// </summary>
        /// <param name="s">Objeto Sucursal con los datos de la sucursal</param>
        public void actualizarSucursal(Sucursal s)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateSucursal");

            _manejador.agregarParametro(comando, "@nombre", s.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@direccion", s.Direccion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@provincia", s.Provincia, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@sucursal", s.ID, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@tipo", s.TipoSucursal, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@externa", s.Externo, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@numero", s.Codigo, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@transportadora", s.Empresa, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@caja", s.CajaEmpresarial, SqlDbType.Bit);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSucursalActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de una sucursal.
        /// </summary>
        /// <param name="s">Objeto Sucursal con los datos de la sucursal a eliminar</param>
        public void eliminarSucursal(Sucursal s)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteSucursal");

            _manejador.agregarParametro(comando, "@sucursal", s, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSucursalEliminacion");
            }

        }


        /// <summary>
        /// Listar las sucursales del sistema.
        /// </summary>
        /// <returns>Lista de las sucursales registradas en el sistema</returns>
        public BindingList<Sucursal> listarSucursales()
        {
            BindingList<Sucursal> sucursales = new BindingList<Sucursal>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectSucursales");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string direccion = (string)datareader["Direccion"];
                    Provincias provincia = (Provincias)datareader["Provincia"];
                    bool externa = (bool)datareader["Externa"];
                    short codigo = (short)datareader["Numero"];
                    bool caja = (bool)datareader["Caja"];

                    TipoSucursal sucursal = (TipoSucursal)datareader["Tipo"];
                    EmpresaTransporte empresa = null;
                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_transportadora = (byte)datareader["ID_Transportadora"];
                        string nombretransportadora = (string)datareader["Transportadora"];



                        empresa = new EmpresaTransporte(nombretransportadora, id_transportadora);
                    }


                    Sucursal nuevasucursal = new Sucursal(nombre, id: id, direccion: direccion, provincia: provincia,sucursal:sucursal,externo:externa,codigo:codigo,transporte:empresa, caja:caja);

                    sucursales.Add(nuevasucursal);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return sucursales;
        }




        /// <summary>
        /// Listar las sucursales del sistema con numero de branche correcto
        /// </summary>
        /// <returns>Lista de las sucursales registradas en el sistema con el numero de branch correcto</returns>
        public BindingList<Sucursal> listarSucursalesBranche()
        {
            BindingList<Sucursal> sucursales = new BindingList<Sucursal>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectSucursalesBranche");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string direccion = (string)datareader["Direccion"];
                    Provincias provincia = (Provincias)datareader["Provincia"];
                    bool externa = (bool)datareader["Externa"];
                    short codigo = (short)datareader["Numero"];
                    bool caja = (bool)datareader["CajaEmpresarial"];

                    TipoSucursal sucursal = (TipoSucursal)datareader["Tipo"];
                    EmpresaTransporte empresa = null;
                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_transportadora = (byte)datareader["ID_Transportadora"];
                        string nombretransportadora = (string)datareader["Transportadora"];



                        empresa = new EmpresaTransporte(nombretransportadora, id_transportadora);
                    }


                    Sucursal nuevasucursal = new Sucursal(nombre, id: id, direccion: direccion, provincia: provincia, sucursal: sucursal, externo: externa, codigo: codigo, transporte: empresa, caja:caja);

                    sucursales.Add(nuevasucursal);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return sucursales;
        }



        /// <summary>
        /// Cargar sucursales por dia a cargar
        /// </summary>
        /// <param name="fecha">Fecha de carga</param>
        /// <returns>Una lista con las sucursales del dia a cargar</returns>
        public BindingList<Sucursal> listarSucursalesaCargar(DateTime fecha)
        {
            BindingList<Sucursal> sucursales = new BindingList<Sucursal>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectSucursalesporDia");
            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.DateTime);
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string direccion = (string)datareader["Direccion"];
                    Provincias provincia = (Provincias)datareader["Provincia"];
                    bool externa = (bool)datareader["Externa"];
                    short codigo = (short)datareader["Numero"];

                    TipoSucursal sucursal = (TipoSucursal)datareader["Tipo"];
                    EmpresaTransporte empresa = null;
                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_transportadora = (byte)datareader["ID_Transportadora"];
                        string nombretransportadora = (string)datareader["Transportadora"];



                        empresa = new EmpresaTransporte(nombretransportadora, id_transportadora);
                    }


                    Sucursal nuevasucursal = new Sucursal(nombre, id: id, direccion: direccion, provincia: provincia, sucursal: sucursal, externo: externa, codigo: codigo, transporte: empresa);

                    sucursales.Add(nuevasucursal);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return sucursales;
        }


        /// <summary>
        /// Verificar si existe una sucursal.
        /// </summary>
        /// <param name="s">Objeto Sucursal con los datos de la sucursal a verificar</param>
        /// <returns>Valor que indica si la sucursal existe</returns>
        public bool verificarSucursal(ref Sucursal s)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteSucursal");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@nombre", s.Codigo, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];

                    existe = id != s.ID;

                    s.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarSucursalDuplicada");
            }

            return existe;
        }



        /// <summary>
        /// Verificar si existe una sucursal.
        /// </summary>
        /// <param name="s">Objeto Sucursal con los datos de la sucursal a verificar</param>
        /// <returns>Valor que indica si la sucursal existe</returns>
        public bool verificarSucursalCodigo(ref Sucursal s)
        {
            bool existe = true;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteSucursalNumero");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@numero", s.Codigo, SqlDbType.SmallInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    short numero = (short)datareader["Numero"];

                    existe = numero != s.Codigo;

                    s.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarSucursalDuplicada");
            }

            return existe;
        }


        /// <summary>
        /// Obtiene los datos de una sucursal
        /// </summary>
        /// <param name="a">Objeto Sucursal con los datos de la sucursal a buscar</param>
        /// <returns>Retorna si existe o no la sucursal</returns>
        public bool obtenerDatosSucursal(ref Sucursal a)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectSucursalDatos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@numero", a.Codigo, SqlDbType.SmallInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string direccion = (string)datareader["Direccion"];
                    Provincias provincia = (Provincias)datareader["Provincia"];
                    bool externa = (bool)datareader["Externa"];
                    bool caja = (bool)datareader["CajaEmpresarial"];
                    short codigo = (short)datareader["Numero"];

                    TipoSucursal sucursal = (TipoSucursal)datareader["Tipo"];
                    EmpresaTransporte empresa = null;
                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_transportadora = (byte)datareader["ID_Transportadora"];
                        string nombretransportadora = (string)datareader["Transportadora"];



                        empresa = new EmpresaTransporte(nombretransportadora, id_transportadora);
                    }
                    a.ID = id;
                    a.Nombre = nombre;
                    a.Direccion = direccion;
                    a.Provincia = provincia;
                    a.Externo = externa;
                    a.Codigo = codigo;
                    a.TipoSucursal = sucursal;
                    a.Empresa = empresa;
                    a.CajaEmpresarial = caja;
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








        #endregion Métodos Públicos


        #region Días de Carga

        /// <summary>
        /// Asignar un día de carga a una Sucursal.
        /// </summary>
        /// <param name="s">Objeto Sucursal con los datos de la Sucursal</param>
        /// <param name="d">Día de carga que se asigna a la Sucursal</param>
        public void agregarDiaCargaSucursal(Sucursal s, Dias d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertSucursalDiaCarga");

            _manejador.agregarParametro(comando, "@sucursal", s, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@dia", d, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSucursalActualizacion");
            }

        }

        /// <summary>
        /// Desligar un día de carga de una Sucursal.
        /// </summary>
        /// <param name="s">Objeto Sucursal con los datos de la Sucursal</param>
        /// <param name="d">Día de carga que se desasigna de la Sucursal</param>
        public void eliminarDiaCargaSucursal(Sucursal s, Dias d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteSucursalDiaCarga");

            _manejador.agregarParametro(comando, "@sucursal", s, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@dia", d, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorSucursalActualizacion");
            }

        }

        /// <summary>
        /// Obtener los días de carga de una Sucursal
        /// </summary>
        /// <param name="s">Sucursal para el cual se obtienen los días de carga</param>
        public void obtenerDiasCargaSucursal(ref Sucursal s)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectSucursalDiasCarga");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@sucursal", s.ID, SqlDbType.SmallInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    Dias dia = (Dias)datareader["Dia"];

                    s.agregarDiaCarga(dia);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        #endregion Días de Carga

        #region Tarifas Transportadora

        /// <summary>
        /// Registrar un punto de venta para un cliente.
        /// </summary>
        /// <param name="s">Objeto PuntoVenta con los datos del punto de venta</param>
        public void agregarTarifaSucursal(ref TarifaPuntoVentaTransportadora p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertTarifaSucursal");

            _manejador.agregarParametro(comando, "@tarifa_regular", p.TarifaRegular, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tarifa_feriado", p.TarifaFeriados, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@recargo", p.Recargo, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tope", p.Tope, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@sucursal", p.Sucursal.ID, SqlDbType.SmallInt);
            //_manejador.agregarParametro(comando, "@cliente", p.Cliente.Id , SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@transportadora", p.EmpresaTransporte.ID, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@moneda_tarifa_regular", p.MonedaTarifaRegular, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda_tarifa_feriado", p.MonedaTarifaFeriado, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda_tope", p.MonedaTope, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda_recargo", p.MonedaRecargo, SqlDbType.TinyInt);


            try
            {
                p.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPuntosVentaActualizacion");
            }

        }


        /// <summary>
        /// Valida si una tarifa de un punto existe
        /// </summary>
        /// <param name="t">Objeto TarifaPuntoVentaTransportadora con los datos de la tarifa</param>
        /// <returns></returns>
        public bool verificarTarifaSucursal(ref TarifaPuntoVentaTransportadora t)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteTarifaSucursal");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@transportadora", t.EmpresaTransporte.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@punto", t.Sucursal.ID, SqlDbType.SmallInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    existe = id != t.ID;

                    t.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarATMDuplicado");
            }

            return existe;

        }







        /// <summary>
        /// Actualizar los datos de un punto de venta.
        /// </summary>
        /// <param name="s">Objeto PuntoVenta con los datos del punto de venta</param>
        public void actualizarTarifaSucursal(TarifaPuntoVentaTransportadora p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateTarifaSucursal");

            _manejador.agregarParametro(comando, "@tarifa_regular", p.TarifaRegular, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tarifa_feriado", p.TarifaFeriados, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@recargo", p.Recargo, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tope", p.Tope, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@sucursal", p.Sucursal.ID, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@transportadora", p.EmpresaTransporte.ID, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@moneda_tarifa_regular", p.MonedaTarifaRegular, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda_tarifa_feriado", p.MonedaTarifaFeriado, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda_tope", p.MonedaTope, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda_recargo", p.MonedaRecargo, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@id", p.ID, SqlDbType.Int);


            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPuntosVentaActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un punto de venta.
        /// </summary>
        /// <param name="s">Objeto PuntoVenta con los datos del punto de venta a eliminar</param>
        public void eliminarTarifaSucursal(TarifaPuntoVentaTransportadora p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteTarifaSucursal");

            _manejador.agregarParametro(comando, "@tarifa", p.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPuntosVentaActualizacion");
            }

        }

        /// <summary>
        /// Obtener los puntos de venta de un cliente.
        /// </summary>
        /// <param name="c">Cliente para el cual se obtiene la lista de puntos de venta</param>
        public void obtenerTarifaTransportadoraSucursal(ref Sucursal c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTarifaTransportadoraSucursal");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@sucursal", c.ID, SqlDbType.SmallInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_tarifa = (int)datareader["ID_Tarifa"];


                    byte id_transportadora = (byte)datareader["ID_Transportadora"];
                    string nombre_transportadora = (string)datareader["Nombre_Transportadora"];

                    EmpresaTransporte transportadora = new EmpresaTransporte(id: id_transportadora, nombre: nombre_transportadora);

                    decimal tarifaregular = 0;
                    if (datareader["Tarifa_Regular"] != DBNull.Value)
                        tarifaregular = (decimal)datareader["Tarifa_Regular"];

                    decimal tarifaferiado = 0;

                    if (datareader["Tarifa_Feriados"] != DBNull.Value)
                        tarifaferiado = (decimal)datareader["Tarifa_Feriados"];


                    decimal tope = 0;

                    if (datareader["Tope"] != DBNull.Value)
                        tope = (decimal)datareader["Tope"];


                    decimal recargo = 0;

                    if (datareader["Recargo"] != DBNull.Value)
                        recargo = (decimal)datareader["Recargo"];


                   



                    Monedas moneda_regular = Monedas.Colones;

                    if (datareader["Moneda_Tarifa_Regular"] != DBNull.Value)
                        moneda_regular = (Monedas)datareader["Moneda_Tarifa_Regular"];


                    Monedas moneda_feriados = Monedas.Colones;

                    if (datareader["Moneda_Tarifa_Feriado"] != DBNull.Value)
                        moneda_feriados = (Monedas)datareader["Moneda_Tarifa_Feriado"];



                    

                    Monedas moneda_tope = Monedas.Colones;

                    if (datareader["Moneda_Tope"] != DBNull.Value)
                        moneda_tope = (Monedas)datareader["Moneda_Tope"];


                    Monedas moneda_recargo = Monedas.Colones;

                    if (datareader["Moneda_Recargo"] != DBNull.Value)
                        moneda_recargo = (Monedas)datareader["Moneda_Recargo"];



                  //  Sucursal punto = new Sucursal(id, nombre, c);

                    TarifaPuntoVentaTransportadora tarifa = new TarifaPuntoVentaTransportadora(id: id_tarifa, sucursal: c, tarifaregular: tarifaregular, tarifaferiados: tarifaferiado, 
                        moneda_feriado: moneda_feriados, moneda_recargo :moneda_recargo, moneda_tope:moneda_tope, moneda_regular:moneda_regular, tope: tope, recargo: recargo, transportadora:transportadora);

                    c.agregarTarifa(tarifa);
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
        /// Obtener los puntos de venta de un cliente.
        /// </summary>
        /// <param name="c">Cliente para el cual se obtiene la lista de puntos de venta</param>
        public void obtenerTarifaTransportadoraPuntoVenta(ref PuntoVenta c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTarifaTransportadoraSucursal");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@sucursal", c.Id, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_tarifa = (int)datareader["ID_Tarifa"];

                    byte id_transportadora = (byte)datareader["ID_Transportadora"];
                    string nombre_transportadora = (string)datareader["Nombre_Transportadora"];

                    EmpresaTransporte transportadora = new EmpresaTransporte(id: id_transportadora, nombre: nombre_transportadora);

                    decimal tarifaregular = 0;
                    if (datareader["Tarifa_Regular"] != DBNull.Value)
                        tarifaregular = (decimal)datareader["Tarifa_Regular"];

                    decimal tarifaferiado = 0;

                    if (datareader["Tarifa_Feriados"] != DBNull.Value)
                        tarifaferiado = (decimal)datareader["Tarifa_Feriados"];


                    decimal tope = 0;

                    if (datareader["Tope"] != DBNull.Value)
                        tope = (decimal)datareader["Tope"];


                    decimal recargo = 0;

                    if (datareader["Recargo"] != DBNull.Value)
                        recargo = (decimal)datareader["Recargo"];


                    decimal entrega_niquel = 0;

                    if (datareader["Tarifa_Niquel"] != DBNull.Value)
                        entrega_niquel = (decimal)datareader["Tarifa_Niquel"];



                    Monedas moneda_regular = Monedas.Colones;

                    if (datareader["Moneda_Tarifa_Regular"] != DBNull.Value)
                        moneda_regular = (Monedas)datareader["Moneda_Tarifa_Regular"];


                    Monedas moneda_feriados = Monedas.Colones;

                    if (datareader["Moneda_Tarifa_Feriado"] != DBNull.Value)
                        moneda_feriados = (Monedas)datareader["Moneda_Tarifa_Feriado"];



                    Monedas moneda_tope = Monedas.Colones;

                    if (datareader["Moneda_Tope"] != DBNull.Value)
                        moneda_tope = (Monedas)datareader["Moneda_Tope"];


                    Monedas moneda_recargo = Monedas.Colones;

                    if (datareader["Moneda_Recargo"] != DBNull.Value)
                        moneda_recargo = (Monedas)datareader["Moneda_Recargo"];

                    TarifaPuntoVentaTransportadora tarifa = new TarifaPuntoVentaTransportadora(id: id_tarifa, tarifaregular: tarifaregular, tarifaferiados: tarifaferiado, tarifaniquel: entrega_niquel, tope: tope, recargo: recargo, transportadora: transportadora, punto: c,
                        moneda_feriado: moneda_feriados, moneda_recargo: moneda_recargo, moneda_regular:moneda_regular, moneda_tope: moneda_tope);

                    c.agregarTarifa(tarifa);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }


       
        #endregion Tarifas Transportadora


        
    }

}
