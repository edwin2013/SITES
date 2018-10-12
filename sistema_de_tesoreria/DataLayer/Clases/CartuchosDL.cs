//
//  @ Project : 
//  @ File Name : CartuchosDL.cs
//  @ Date : 01/08/2012
//  @ Author : César Mendoza
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
    /// Clase de la capa de datos que maneja los cartuchos.
    /// </summary>
    public class CartuchosDL
    {
        
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CartuchosDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CartuchosDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CartuchosDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public CartuchosDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un cartucho.
        /// </summary>
        /// <param name="c">Objeto Cartucho con los datos del cartucho</param>
        public void agregarCartucho(ref Cartucho c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCartucho");

            _manejador.agregarParametro(comando, "@numero", c.Numero, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@tipo", c.Tipo, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@denominacion", 1, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@empresa", c.Transportadora.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@estado", c.Estado, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fk_ID_proveedor", c.Proveedor, SqlDbType.Int);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCartuchoRegistro");
            }

        }

        public void agregarCartuchoRecibido(Cartucho c, Colaborador usuario)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCartuchoRecibido");

            _manejador.agregarParametro(comando, "@cartucho", c.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@colaborador", usuario, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCartuchoRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un cartucho en el sistema.
        /// </summary>
        /// <param name="c">Objeto Cartucho con los datos del cartucho</param>
        public void actualizarCartucho(Cartucho c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCartucho");

            _manejador.agregarParametro(comando, "@numero", c.Numero, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@tipo", c.Tipo, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@estado", c.Estado, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@empresa", c.Transportadora.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cartucho", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fk_ID_proveedor", c.Proveedor,SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCartuchoActualizacion");
            }

        }

        /// <summary>
        /// Actualizar el estado de un cartucho en el sistema.
        /// </summary>
        /// <param name="c">Objeto Cartucho con los datos del cartucho</param>
        public void actualizarCartuchoEstado(Cartucho c, Colaborador colaborador)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCartuchoEstado");

            _manejador.agregarParametro(comando, "@estado", c.Estado, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cartucho", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@usuario", colaborador, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCartuchoActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un cartucho.
        /// </summary>
        /// <param name="c">Objeto Cartucho con los datos del cartucho a eliminar</param>
        public void eliminarCartucho(Cartucho c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCartucho");

            _manejador.agregarParametro(comando, "@cartucho", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCartuchoEliminacion");
            }

        }

        /// <summary>
        /// Listar los cartuchos registrados en el sistema.
        /// </summary>
        /// <returns>Lista de los cartuchos registrados en el sistema</returns>
        public BindingList<Cartucho> listarCartuchos()
        {
            BindingList<Cartucho> cartuchos = new BindingList<Cartucho>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCartuchos");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_cartucho = (int)datareader["ID_Cartucho"];
                    string numero = (string)datareader["Numero"];
                    TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];

                    EstadosCartuchos estado = (EstadosCartuchos)datareader["Estado"];
                    
                   //if (datareader["Estado"]!= DBNull.Value)
                   //{
                   //    estado.ID = Convert.ToInt32(datareader["Estado"]);
                   //    estado.Estado = (string)datareader["NomEstado"];
                   //}

                    EmpresaTransporte emp = new EmpresaTransporte();
                 
                    if (datareader["fk_ID_Transportadora"] != DBNull.Value)
                    {
                    emp.ID =(byte)datareader["fk_ID_Transportadora"];
                    emp.Nombre = (string)datareader["Nombre"];
                    }

                    ProveedorCartucho prov = new ProveedorCartucho();

                    if (datareader["fk_ID_Proveedor"] != DBNull.Value)
                    {
                        prov.ID = (int)datareader["fk_ID_Proveedor"];
                        prov.Nombre = (string)datareader["Nombre Proveedor"];
                    }

                    byte id_denominacion = (byte)datareader["ID_Denominacion"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];

                    Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda);
                    Cartucho cartucho = new Cartucho(numero, id: id_cartucho, tipo: tipo, denominacion: denominacion,transportadora:emp, estado: estado, provedor:prov);

                    cartuchos.Add(cartucho);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return cartuchos;
        }

        public BindingList<Cartucho> listarCartuchosEstado(EstadosCartuchos est, String c)
        {
            BindingList<Cartucho> cartuchos = new BindingList<Cartucho>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCartuchosEstado");

            _manejador.agregarParametro(comando, "@estado", est, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cartucho", c, SqlDbType.NVarChar);
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_cartucho = (int)datareader["ID_Cartucho"];
                    string numero = (string)datareader["Numero"];
                    TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];

                    EstadosCartuchos estado = (EstadosCartuchos)datareader["Estado"];
                    EmpresaTransporte emp = new EmpresaTransporte();

                    if (datareader["fk_ID_Transportadora"] != DBNull.Value)
                    {
                        emp.ID = (byte)datareader["fk_ID_Transportadora"];
                        emp.Nombre = (string)datareader["Nombre"];
                    }

                    ProveedorCartucho prov = new ProveedorCartucho();

                    if (datareader["fk_ID_Proveedor"] != DBNull.Value)
                    {
                        prov.ID = (int)datareader["fk_ID_Proveedor"];
                        prov.Nombre = (string)datareader["Nombre Proveedor"];
                    }

                    Cartucho cartucho = new Cartucho(numero, id: id_cartucho, tipo: tipo, transportadora: emp, estado: estado,provedor:prov);

                    cartuchos.Add(cartucho);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return cartuchos;
        }

        /// <summary>
        /// Verificar si existe un cartucho.
        /// </summary>
        /// <param name="c">Objeto Cartucho con los datos del cartucho a verificar</param>
        /// <returns>Valor que indica si el cartucho existe</returns>
        public bool verificarCartucho(ref Cartucho c)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteCartucho");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@numero", c.Numero,  SqlDbType.NVarChar);

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
                throw new Excepcion("ErrorVerificarCartuchoDuplicado");
            }

            return existe;
        }

        public bool verificarCartuchoFallas(ref Cartucho c)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteCartuchoFallas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@numero", c.Numero,  SqlDbType.NVarChar);

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
                throw new Excepcion("ErrorVerificarCartuchoDuplicado");
            }

            return existe;
        }
       
        /// <summary>
        /// Obtener los datos de un cartucho.
        /// </summary>
        /// <param name="c">Objeto Cartucho con los datos del cartucho para el cual se obtienen los datos</param>
        /// <returns>Valor que indica si el cartucho existe</returns>
        public bool obtenerDatosCartucho(ref Cartucho c)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCartuchoDatos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cartucho", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];

                    EstadosCartuchos estado = (EstadosCartuchos)datareader["Estado"];

                    //if (datareader["Estado"] != DBNull.Value)
                    //{
                    //    estado.ID = Convert.ToInt32(datareader["Estado"]);
                    //    estado.Estado = (string)datareader["NomEstado"];
                    //}

                    byte id_denominacion = (byte)datareader["ID_Denominacion"];
                    decimal valor = (decimal)datareader["Valor"];
                    Monedas moneda = (Monedas)datareader["Moneda"];

                    EmpresaTransporte emp = new EmpresaTransporte();
                    if (datareader["fk_ID_Transportadora"] != DBNull.Value)
                    {
                        emp.ID = (byte)datareader["fk_ID_Transportadora"];
                        emp.Nombre = (string)datareader["Nombre"];
                    }
                    
                    ProveedorCartucho prov = new ProveedorCartucho();
                    if (datareader["fk_ID_Proveedor"] != DBNull.Value)
                    {
                        prov.ID = (int)datareader["fk_ID_Proveedor"];
                        prov.Nombre = (string)datareader["Nombre Proveedor"];
                    }

                    Denominacion denominacion = new Denominacion(id: id_denominacion, valor: valor, moneda: moneda);

                    c.Tipo = tipo;
                    c.Estado = estado;
                    c.Denominacion = denominacion;
                    c.Transportadora = emp;
                    c.Proveedor = prov;
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

        #region Fallas

        public bool verificarLimiteFallas()
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("ReporteCartuchoMaximoNumeroFallas");

            bool limite = false;
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    limite = true;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return limite;
        }

        public BindingList<FallaCartucho> obtenerFallasCartucho(ref Cartucho c)
        {
            BindingList<FallaCartucho> fallas = new BindingList<FallaCartucho>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectFallasPorCartucho");

            _manejador.agregarParametro(comando, "@cartucho", c.ID, SqlDbType.Int);

            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id_falla = (short)datareader["fk_ID_Falla"];
                    string nombre = (string)datareader["Nombre"];
                    DateTime fecha = (DateTime)datareader["Fecha"];

                    Colaborador us = new Colaborador();

                    if (datareader["fk_ID_Colaborador"] != DBNull.Value)
                    {
                        us.ID = Convert.ToInt32(datareader["fk_ID_Colaborador"]);
                        us.Nombre = (string)datareader["Nombre Usuario"];
                    }


                    FallaCartucho falla = new FallaCartucho(id: id_falla, nombre:nombre, fecha:fecha, us:us);

                    c.agregarFalla(falla);

                    fallas.Add(falla);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }
            return fallas;

        }

        public BindingList<Cartucho> listarFallasCartuchoMalo(ref Cartucho c)
        {
            BindingList<Cartucho> cartuchos = new BindingList<Cartucho>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCartuchosMaloTesoreria");

            _manejador.agregarParametro(comando, "@cartucho", c, SqlDbType.Int);
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id_falla = (short)datareader["fk_ID_Falla"];
                    string nombre = (string)datareader["Nombre"];
                    DateTime fecha = (DateTime)datareader["Fecha"];

                    Colaborador us = new Colaborador();

                    if (datareader["fk_ID_Colaborador"] != DBNull.Value)
                    {
                        us.ID = Convert.ToInt32(datareader["fk_ID_Colaborador"]);
                        us.Nombre = (string)datareader["Nombre Usuario"];
                    }


                    FallaCartucho falla = new FallaCartucho(id: id_falla, nombre: nombre, fecha: fecha, us: us);

                    c.agregarFalla(falla);

                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return cartuchos;
        }

        public BindingList<Cartucho> listarFallasCartuchoNoRecuperable(ref Cartucho c)
        {
            BindingList<Cartucho> cartuchos = new BindingList<Cartucho>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCartuchosNoRecuperable");

            _manejador.agregarParametro(comando, "@cartucho", c, SqlDbType.Int);
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id_falla = (short)datareader["fk_ID_Falla"];
                    string nombre = (string)datareader["Nombre"];
                    DateTime fecha = (DateTime)datareader["Fecha"];

                    Colaborador us = new Colaborador();

                    if (datareader["fk_ID_Colaborador"] != DBNull.Value)
                    {
                        us.ID = Convert.ToInt32(datareader["fk_ID_Colaborador"]);
                        us.Nombre = (string)datareader["Nombre Usuario"];
                    }


                    FallaCartucho falla = new FallaCartucho(id: id_falla, nombre: nombre, fecha: fecha, us: us);

                    c.agregarFalla(falla);

                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return cartuchos;
        }

        public void agregarFallaCartucho(ref Cartucho c, Colaborador clb, FallaCartucho falla)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertFallasPorCartucho");
             
            _manejador.agregarParametro(comando, "@fk_ID_Cartucho", c.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fk_ID_Falla", falla.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fk_ID_Colaborador", clb, SqlDbType.TinyInt);

            try
            {
                //c.ID = (int)
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCartuchoRegistro");
            }
        }

        public void eliminarFallaCartucho(ref Cartucho c, Colaborador clb, FallaCartucho falla)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteFallasPorCartucho");

            _manejador.agregarParametro(comando, "@fk_ID_Cartucho", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fk_ID_Falla", falla, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fk_ID_Elimina", clb.ID, SqlDbType.SmallInt);
       
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCartuchoEliminacion");
            }


        }
       
        #endregion Fallas
        
        #region Recepcion

        public DataTable ObtenerDatosResumenRecepcion()
        {
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("ReporteRecepcionCartuchosResumen");

            try
            {
                comando.CommandTimeout = 100000;
                datareader = _manejador.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();
              
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw ex;
            }

            return salida;
        }


        public DataTable obtenerDatosRecepcion(Colaborador entrega, Colaborador recibe, ProveedorCartucho prov, EstadosCartuchos est)
        {
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("ReporteRecepcionCartuchos");

            if (entrega != null)
                _manejador.agregarParametro(comando, "@usuario", entrega, SqlDbType.TinyInt);
            if (recibe != null)
                _manejador.agregarParametro(comando, "@registro", recibe, SqlDbType.TinyInt);
            if (prov != null)
                _manejador.agregarParametro(comando, "@proveedor", prov, SqlDbType.TinyInt);

            if (est != EstadosCartuchos.Indefinido)
                _manejador.agregarParametro(comando, "@estado", est, SqlDbType.TinyInt);

            try
            {
                comando.CommandTimeout = 100000;
                datareader = _manejador.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();

            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw ex;
            }

            return salida;
        }


        
        public DataTable ObtenerDatosReporteFallas(DateTime inicio, DateTime fin, FallaCartucho falla, int est, Cartucho c)
        {
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("ReporteFallasCartuchos");

            _manejador.agregarParametro(comando, "@fecha_inicio", inicio, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha_fin", fin, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@falla", falla, SqlDbType.Int);

            if (est != -1)
            {
                _manejador.agregarParametro(comando, "@estado", est, SqlDbType.TinyInt);
            }
            
	        if (c.ID != 0 & c.Numero != "")
                _manejador.agregarParametro(comando, "@cartucho", c, SqlDbType.Int);

            try
            {
                comando.CommandTimeout = 100000;
                datareader = _manejador.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();

            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw ex;
            }

            return salida;
        }

        #endregion Recepcion

        #endregion Métodos Públicos

    }

}
