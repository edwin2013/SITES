//
//  @ Project : 
//  @ File Name : SobresDL.cs
//  @ Date : 08/08/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;

namespace DataLayer
{

    /// <summary>
    /// Clase de la capa de datos que maneja los valores.
    /// </summary>
    public class ValoresDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ValoresDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ValoresDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ValoresDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ValoresDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un valor y ligarlo con una inconsistencia.
        /// </summary>
        /// <param name="s">Objeto Valor con los datos del valor</param>
        /// <param name="i">Inconsistencia en un deposito a la cual se ligará el valor</param>
        public void agregarValor(ref Valor v, InconsistenciaDeposito i)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertValor");

            _manejador.agregarParametro(comando, "@identificador", v.Identificador, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@tipo", v.Tipo, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@comentario", v.Comentario, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@inconsistencia", i.Id, SqlDbType.Int);

            try
            {
                v.Id = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorValorRegistro");
            }

        }

        /// <summary>
        /// Eliminar los datos de un valor.
        /// </summary>
        /// <param name="s">Objeto Valor con los datos del valor a eliminar</param>
        public void eliminaValor(Valor v)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteValor");

            _manejador.agregarParametro(comando, "@valor", v.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorValorEliminacion");
            }

        }

        /// <summary>
        /// Obtener todos los valores que pertenecen a una inconsistencia en un deposito.
        /// </summary>
        /// <param name="i">Inconsistencia en un deposito para la cual se obtiene la lista de valores</param>
        public void obtenerValoresInconsistencia(ref InconsistenciaDeposito i)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectInconsistenciaDepositoValores");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@inconsistencia", i.Id, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string identificador = (string)datareader["Identificador"];
                    TipoValor tipo = (TipoValor)datareader["Tipo"];
                    string comentario = (string)datareader["Comentario"];

                    Valor valor = new Valor(id, tipo, identificador, comentario);

                    i.agregarValor(valor);
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
