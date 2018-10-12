//
//  @ Project : 
//  @ File Name : ATMsDL.cs
//  @ Date : 08/05/2012
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
    /// Clase de la capa de datos que maneja los ATM's.
    /// </summary>
    public class ATMsDL
    {
        
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ATMsDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ATMsDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ATMsDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ATMsDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un ATM.
        /// </summary>
        /// <param name="a">Objeto ATM con los datos del ATM</param>
        public void agregarATM(ref ATM a)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertATM");

            _manejador.agregarParametro(comando, "@numero", a.Numero, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@transportadora", a.Empresa_encargada, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@tipo", a.Tipo, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@cartuchos", a.Cartuchos, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@externo", a.Externo, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@full", a.Full, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@ena", a.ENA, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@vip", a.VIP, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@cartucho_rechazo", a.Cartucho_rechazo, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@codigo", a.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@oficinas", a.Oficinas, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@periodo_carga", a.Periodo_carga, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@sucursal", a.Sucursal, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@ubicacion", a.Ubicacion, SqlDbType.SmallInt);

            try
            {
                a.ID = (short)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorATMRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un ATM en el sistema.
        /// </summary>
        /// <param name="a">Objeto ATM con los datos del ATM</param>
        public void actualizarATM(ATM a)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateATM");

            _manejador.agregarParametro(comando, "@numero", a.Numero, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@transportadora", a.Empresa_encargada, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@tipo", a.Tipo, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@cartuchos", a.Cartuchos, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@externo", a.Externo, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@full", a.Full, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@ena", a.ENA, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@vip", a.VIP, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@cartucho_rechazo", a.Cartucho_rechazo, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@codigo", a.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@oficinas", a.Oficinas, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@periodo_carga", a.Periodo_carga, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@sucursal", a.Sucursal, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@ubicacion", a.Ubicacion, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@atm", a, SqlDbType.SmallInt);

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
        
        /// <summary>
        /// Eliminar los datos de un ATM.
        /// </summary>
        /// <param name="a">Objeto ATM con los datos del ATM a eliminar</param>
        public void eliminarATM(ATM a)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteATM");

            _manejador.agregarParametro(comando, "@atm", a, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorATMEliminacion");
            }

        }

        /// <summary>
        /// Listar los ATM's registrados en el sistema.
        /// </summary>
        /// <returns>Lista de los ATM's registrados en el sistema</returns>
        public BindingList<ATM> listarATMs()
        {
            BindingList<ATM> atms = new BindingList<ATM>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectATMs");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id_atm = (short)datareader["ID_ATM"];
                    short numero = (short)datareader["Numero"];
                    TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];
                    byte cartuchos = (byte)datareader["Cartuchos"];
                    bool externo = (bool)datareader["Externo"];
                    bool full = (bool)datareader["ATM_Full"];
                    bool ena = (bool)datareader["ENA"];
                    bool vip = (bool)datareader["VIP"];
                    bool cartucho_rechazo = (bool)datareader["Cartucho_Rechazo"];
                    string codigo = (string)datareader["Codigo"];
                    string oficinas = (string)datareader["Oficinas"];
                    byte? periodo_carga = datareader["Periodo_Carga"] as byte?;

                    EmpresaTransporte empresa_encargada = null;

                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_empresa_encargada = (byte)datareader["ID_Transportadora"];
                        string nombre = (string)datareader["Nombre_Transportadora"];

                        empresa_encargada = new EmpresaTransporte(nombre, id: id_empresa_encargada);
                    }

                    Sucursal sucursal = null;

                    if (datareader["ID_Sucursal"] != DBNull.Value)
                    {
                        short id_sucursal = (short)datareader["ID_Sucursal"];
                        string nombre = (string)datareader["Nombre_Sucursal"];

                        sucursal = new Sucursal(nombre, id: id_sucursal);
                    }

                    Ubicacion ubicacion = null;

                    if (datareader["ID_Ubicacion"] != DBNull.Value)
                    {
                        short id_ubicacion = (short)datareader["ID_Ubicacion"];
                        string oficina = (string)datareader["Oficina"];
                        string direccion = (string)datareader["Direccion"];

                        ubicacion = new Ubicacion(oficina, direccion, id: id_ubicacion);
                    }

                    ATM atm = new ATM(id: id_atm, numero: numero, empresa_encargada: empresa_encargada, tipo: tipo,
                                      cartuchos: cartuchos, externo: externo, full: full, ena: ena,
                                      vip: vip, cartucho_rechazo: cartucho_rechazo, codigo: codigo, 
                                      oficinas: oficinas, periodo_carga: periodo_carga, sucursal: sucursal, 
                                      ubicacion: ubicacion);

                    atms.Add(atm);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return atms;
        }

        /// <summary>
        /// Lista de ATM's que se encuentran registrados en el sistema
        /// </summary>
        /// <returns>Un DataTable con los ATM's obtenidos</returns>
        public DataTable listarATMsExportacion()
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectATMsExportar");
            SqlDataReader datareader = null;

                  try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return salida;
        }

        /// <summary>
        /// Verificar si existe un ATM.
        /// </summary>
        /// <param name="a">Objeto ATM con los datos del ATM a verificar</param>
        /// <returns>Valor que indica si el ATM existe</returns>
        public bool verificarATM(ref ATM a)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteATM");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@numero", a.Numero, SqlDbType.SmallInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];

                    existe = id != a.ID;

                    a.ID = id;
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
        /// Obtener los datos de un ATM.
        /// </summary>
        /// <param name="a">ATM para el cual se obtienen los datos</param>
        /// <returns>Valor que indica si el ATM existe</returns>
        public bool obtenerDatosATM(ref ATM a)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectATMDatos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@numero", a.Numero, SqlDbType.SmallInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id_atm = (short)datareader["ID_ATM"];
                    TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];
                    byte cartuchos = (byte)datareader["Cartuchos"];
                    bool externo = (bool)datareader["Externo"];
                    bool full = (bool)datareader["ATM_Full"];
                    bool ena = (bool)datareader["ENA"];
                    bool cartucho_rechazo = (bool)datareader["Cartucho_Rechazo"];

                    byte id_empresa_encargada = (byte)datareader["ID_Transportadora"];
                    string nombre = (string)datareader["Nombre_Transportadora"];

                    EmpresaTransporte empresa_encargada = new EmpresaTransporte(nombre, id: id_empresa_encargada);

                    a.ID = id_atm;
                    a.Empresa_encargada = empresa_encargada;
                    a.Tipo = tipo;
                    a.Cartuchos = cartuchos;
                    a.Externo = externo;
                    a.Full = full;
                    a.ENA = ena;
                    a.Cartucho_rechazo = cartucho_rechazo;

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
        /// Actualizar un proveedor para un ATM especifico
        /// </summary>
        /// <param name="a">ATM para el cual se obtienen los datos</param>
        /// <returns>Valor que indica si el ATM existe</returns>
        public void actualizarProveedorATM(ref ATM a)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("[UpdateProveedorATM]");

            _manejador.agregarParametro(comando, "@atm", a.Numero, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@transportadora", a.Empresa_encargada.DB_ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@externo", a.Externo, SqlDbType.Bit);
            

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

        #region Días de Carga

        /// <summary>
        /// Asignar un día de carga a un ATM.
        /// </summary>
        /// <param name="a">Objeto ATM con los datos del ATM</param>
        /// <param name="d">Día de carga que se asigna al ATM</param>
        public void agregarDiaCargaATM(ATM a, Dias d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertATMDiaCarga");

            _manejador.agregarParametro(comando, "@atm", a, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@dia", d, SqlDbType.TinyInt);

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

        /// <summary>
        /// Desligar un día de carga de un ATM.
        /// </summary>
        /// <param name="a">Objeto ATM con los datos del ATM</param>
        /// <param name="d">Día de carga que se desasigna del ATM</param>
        public void eliminarDiaCargaATM(ATM a, Dias d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteATMDiaCarga");

            _manejador.agregarParametro(comando, "@atm", a, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@dia", d, SqlDbType.TinyInt);

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

        /// <summary>
        /// Obtener los días de carga de un ATM.
        /// </summary>
        /// <param name="a">ATM para el cual se obtienen los días de carga</param>
        public void obtenerDiasCargaATM(ref ATM a)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectATMDiasCarga");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@atm", a, SqlDbType.SmallInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    Dias dia = (Dias)datareader["Dia"];

                    a.agregarDiaCarga(dia);
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

        #endregion Métodos Públicos

    }

}
