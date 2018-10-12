//
//  @ Project : 
//  @ File Name : ManifiestosATMsCargasDL.cs
//  @ Date : 05/06/2012
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
    /// Clase de la capa de datos que maneja los manifiestos de cargas de ATM's.
    /// </summary>
    public class ManifiestosATMsCargasDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ManifiestosATMsCargasDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ManifiestosATMsCargasDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ManifiestosATMsCargasDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ManifiestosATMsCargasDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo manifiesto de carga de un ATM.
        /// </summary>
        /// <param name="m">Objeto ManifiestoATMCarga con los datos del nuevo manifiesto</param>
        public void agregarManifiestoATMCarga(ref ManifiestoATMCarga m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertManifiestoATM");

            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@marchamo", m.Marchamo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@marchamo_adicional", m.Marchamo_adicional, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@bolsa_rechazo", m.Bolsa_rechazo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@fecha", m.Fecha, SqlDbType.Date);


            try
            {
                m.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoATMCargaRegistro");
            }

        }
       
        /// <summary>
        /// Actualizar los datos de un manifiesto de carga de un ATM.
        /// </summary>
        /// <param name="m">Objeto ManifiestoATMCarga con los datos del manifiesto a actualizar</param>
        public void actualizarManifiestoATMCarga(ManifiestoATMCarga m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManifiestoATM");

            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@marchamo", m.Marchamo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@marchamo_adicional", m.Marchamo_adicional, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@bolsa_rechazo", m.Bolsa_rechazo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@fecha", m.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoATMCargaActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un manifiesto de carga de un ATM.
        /// </summary>
        /// <param name="m">Objeto ManifiestoATMCarga con los datos del manifiesto a eliminar</param>
        public void eliminarManifiestoATMCarga(ManifiestoATMCarga m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteManifiestoATM");

            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoATMCargaEliminacion");
            }

        }

        /// <summary>
        /// Verificar si un manifiesto de carga de un ATM ya fue registrado.
        /// </summary>
        /// <param name="m">Objeto ManifiestoATMCarga con los datos del manifiesto</param>
        /// <returns>Valor que indica si el manifiesto existe</returns>
        public bool verificarManifiestoATMCarga(ref ManifiestoATMCarga m)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteManifiestoATM");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id_encontrado = (int)datareader["pk_ID"];

                    existe = id_encontrado != m.ID;

                    m.ID = id_encontrado;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarManifiestoATMCargaDuplicado");
            }

            return existe;
        }

        /// <summary>
        /// Obtener una lista de los manifiestos de cargas de ATM's que tienen un determinado código o parte del mismo.
        /// </summary>
        /// <param name="c">Código o parte del mismo de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoATMCarga> listarManifiestosATMsCargasPorCodigo(string c)
        {
            BindingList<ManifiestoATMCarga> manifiestos = new BindingList<ManifiestoATMCarga>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestosATMsPorCodigo");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", c, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string codigo = (string)datareader["Codigo"];
                    string marchamo = (string)datareader["Marchamo"];
                    string marchamo_adicional = (string)datareader["Marchamo_Adicional"];
                    string bolsa_rechazo = datareader["Bolsa_Rechazo"] as string;
                    DateTime fecha = (DateTime)datareader["Fecha"];

                    ManifiestoATMCarga manifiesto = new ManifiestoATMCarga(codigo, marchamo, fecha, bolsa_rechazo, marchamo_adicional, id: id);

                    manifiestos.Add(manifiesto);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return manifiestos;
        }


        /// <summary>
        /// Obtiene los datos del manifiesto
        /// </summary>
        /// <param name="man">Objeto manifiesto con los datos del manifiesto</param>
        public void obtenerManifiestoDatos(ref ManifiestoATMCarga man)
        {
            BindingList<ManifiestoATMCarga> manifiestos = new BindingList<ManifiestoATMCarga>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDatosManifiestoATM");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@id", man, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    man.Codigo = (string)datareader["Codigo"];
                    man.Marchamo = (string)datareader["Marchamo"];
                     
                   
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
