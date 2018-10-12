using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

using CommonObjects;
using LibreriaMensajes;
using System.Data.SqlClient;
using System.ComponentModel;
using CommonObjects.Clases;
using System.Data;

namespace DataLayer.Clases
{
    /// <summary>
    /// Clase de la capa de datos que maneja los cartuchos
    /// </summary>
    public class FallaCartuchoDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static FallaCartuchoDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static FallaCartuchoDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new FallaCartuchoDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public FallaCartuchoDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar una nueva falla.
        /// </summary>
        /// <param name="g">Objeto FallaCartucho con los datos de la nueva falla</param>
        public void agregarFallaCartucho(ref FallaCartucho g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertFallaCartuchos");

            _manejador.agregarParametro(comando, "@nombre", g.Nombre, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@cantidad", g.Cantidad, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@norecuperable", g.NoRecuperable, SqlDbType.Bit);
           try
            {
                g.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorFallaCartuchoRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de una falla.
        /// </summary>
        /// <param name="g">Objeto FallaCartucho con los datos de la falla a actualizar</param>
        public void actualizarFallaCartucho(ref FallaCartucho g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateFallasCartuchos");

            _manejador.agregarParametro(comando, "@id", g.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@nombre", g.Nombre, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@cantidad", g.Cantidad, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@norecuperable", g.NoRecuperable, SqlDbType.Bit);


            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorFallaCartuchoActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de una falla.
        /// </summary>
        /// <param name="t">Objeto FallaCartucho con los datos de la falla a eliminar</param>
        public void eliminarFallaCartucho(FallaCartucho g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteFallaCartucho");

            _manejador.agregarParametro(comando, "@falla", g, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErroroFallaCartuchoEliminacion");
            }

        }

        /// <summary>
        /// Listar todas las FallaCartuchoes registradas en el sistema.
        /// </summary>
        /// <returns>Lista de las FallaCartuchoes registradas en el sistema</returns>
        public BindingList<FallaCartucho> listarFallaCartuchos(string nombre)
        {
            BindingList<FallaCartucho> FallaCartuchos = new BindingList<FallaCartucho>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectFallasCartuchos");

            _manejador.agregarParametro(comando, "@nombre", nombre, SqlDbType.NVarChar);
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_FallaCartucho = (int)datareader["ID_Falla"];
                    string nom = (string)datareader["Nombre"];
                    int cantidad = (int)datareader["Cantidad"];
                    bool norecuperable = (bool)datareader["NoRecuperable"];
                    //DateTime fecha = (DateTime)datareader["Fecha"];

                    //Colaborador us = new Colaborador();
                    //if (datareader["fk_ID_Colaborador"] != DBNull.Value)
                    //{
                    //    us.ID = (byte)datareader["fk_ID_Colaborador"];
                    //    us.Nombre = (string)datareader["Nombre Usuario"];
                    //}
                   
                    FallaCartucho FallaCartucho = new FallaCartucho(id: id_FallaCartucho, nombre: nom,cantidad:cantidad, NRecuperable:norecuperable);

                    FallaCartuchos.Add(FallaCartucho);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return FallaCartuchos;
        }

        public void verificarFalla(ref FallaCartucho c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteFallaCartucho");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@falla", c.Nombre, SqlDbType.NVarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id_encontrado = (int)datareader["pk_ID"];
                    bool Nrecuperable = (bool)datareader["NoRecuperable"];

                    c.ID = id_encontrado;
                    c.NoRecuperable = Nrecuperable;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarFalla");
            }

           // return c.ID;
        }

        #endregion Métodos Públicos
    }
}
