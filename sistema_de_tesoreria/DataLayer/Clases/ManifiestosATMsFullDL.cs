//
//  @ Project : 
//  @ File Name : ManifiestosATMsFullDL.cs
//  @ Date : 26/02/2013
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
    /// Clase de la capa de datos que maneja los manifiestos de full de ATM's.
    /// </summary>
    public class ManifiestosATMsFullDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ManifiestosATMsFullDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ManifiestosATMsFullDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ManifiestosATMsFullDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ManifiestosATMsFullDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo manifiesto de un ATM Full.
        /// </summary>
        /// <param name="m">Objeto ManifiestoATMFull con los datos del nuevo manifiesto</param>
        public void agregarManifiestoATMFull(ref ManifiestoATMFull m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertManifiestoATMFull");

            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@marchamo", m.Marchamo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@marchamo_adicional_ena", m.Marchamo_adicional_ena, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@marchamo_ena_a", m.Marchamo_ena_a, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@marchamo_ena_b", m.Marchamo_ena_b, SqlDbType.VarChar);
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
                throw new Excepcion("ErrorManifiestoATMFullRegistro");
            }

        }
       
        /// <summary>
        /// Actualizar los datos de un manifiesto de un ATM Full.
        /// </summary>
        /// <param name="m">Objeto ManifiestoATMFull con los datos del manifiesto a actualizar</param>
        public void actualizarManifiestoATMFull(ManifiestoATMFull m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManifiestoATMFull");

            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@marchamo", m.Marchamo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@marchamo_adicional_ena", m.Marchamo_adicional_ena, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@marchamo_ena_a", m.Marchamo_ena_a, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@marchamo_ena_b", m.Marchamo_ena_b, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@bolsa_rechazo", m.Bolsa_rechazo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", m.Fecha, SqlDbType.Date);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoATMFullActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un manifiesto de un ATM Full.
        /// </summary>
        /// <param name="m">Objeto ManifiestoATMFull con los datos del manifiesto a eliminar</param>
        public void eliminarManifiestoATMFull(ManifiestoATMFull m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteManifiestoATMFull");

            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoATMFullEliminacion");
            }

        }

        /// <summary>
        /// Verificar si un manifiesto de un ATM Full ya fue registrado.
        /// </summary>
        /// <param name="m">Objeto ManifiestoATMFull con los datos del manifiesto</param>
        /// <returns>Valor que indica si el manifiesto existe</returns>
        public bool verificarManifiestoATMFull(ref ManifiestoATMFull m)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteManifiestoATMFull");
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
                throw new Excepcion("ErrorVerificarManifiestoATMFullDuplicado");
            }

            return existe;
        }

        /// <summary>
        /// Obtener una lista de los manifiestos de ATM's Full que tienen un determinado código o parte del mismo.
        /// </summary>
        /// <param name="c">Código o parte del mismo de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoATMFull> listarManifiestosATMsFullPorCodigo(string c)
        {
            BindingList<ManifiestoATMFull> manifiestos = new BindingList<ManifiestoATMFull>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestosATMsFullPorCodigo");
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
                    string marchamo_adicional_ena = datareader["Marchamo_Adicional_ENA"] as string;
                    string marchamo_ena_a = datareader["Marchamo_ENA_A"] as string;
                    string marchamo_ena_b = datareader["Marchamo_ENA_B"] as string;
                    string bolsa_rechazo = "";
                    if (datareader["Bolsa_Rechazo"] != DBNull.Value)
                        bolsa_rechazo = datareader["Marchamo_ENA_B"] as string;

                    DateTime fecha = (DateTime)datareader["Fecha"];

                    ManifiestoATMFull manifiesto = new ManifiestoATMFull(codigo, marchamo, fecha, marchamo_adicional_ena, marchamo_ena_a,
                                                                         marchamo_ena_b, bolsa_rechazo, id: id);

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
        public void obtenerManifiestoDatos(ref ManifiestoATMFull man)
        {
            BindingList<ManifiestoATMCarga> manifiestos = new BindingList<ManifiestoATMCarga>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDatosManifiestoATMFull");
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
