//
//  @ Project : 
//  @ File Name : GrupoDL.cs
//  @ Date : 30/05/2011
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
    /// Clase de la capa de datos que maneja los grupos de cajas.
    /// </summary>
    public class GruposDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static GruposDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static GruposDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new GruposDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public GruposDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo grupo de cajas.
        /// </summary>
        /// <param name="g">Objeto Grupo con los datos del nuevo grupo</param>
        public void agregarGrupo(ref Grupo g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertGrupo");

            _manejador.agregarParametro(comando, "@nombre", g.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@descripcion", g.Descripcion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@caja_unica", g.Caja_unica, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@area", g.Area, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@semaforo", g.Semaforo, SqlDbType.Bit);

            try
            {
                g.Id = (byte)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorGrupoRegistro");
            }

        }

         /// <summary>
        /// Actualizar los datos de un grupo de cajas.
        /// </summary>
        /// <param name="g">Objeto Grupo con los datos del grupo a actualizar</param>
        public void actualizarGrupo(Grupo g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateGrupo");

            _manejador.agregarParametro(comando, "@nombre", g.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@descripcion", g.Descripcion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@caja_unica", g.Caja_unica, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@area", g.Area, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@grupo", g.Id, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@semaforo", g.Semaforo, SqlDbType.Bit);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorGrupoActualizacion");
            }

        }

        /// <summary>
        /// Actualizar el contador de cajas de un grupo.
        /// </summary>
        /// <param name="g">Objeto Grupo con los datos del grupo a actualizar</param>
        public void actualizarGrupoTotales(Grupo g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateGrupoTotales");

            _manejador.agregarParametro(comando, "@numero_cajas", g.Numero_cajas, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@caja_actual", g.Caja_actual, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@total_manifiestos", g.Total_manifiestos, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@grupo", g.Id, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorGrupoActualizacionCajas");
            }

        }

        /// <summary>
        /// Eliminar los datos de un grupo.
        /// </summary>
        /// <param name="e">Objeto Grupo con los datos del grupo a eliminar</param>
        public void eliminarGrupo(Grupo g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteGrupo");

            _manejador.agregarParametro(comando, "@grupo", g.Id, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorGrupoEliminacion");
            }

        }

        /// <summary>
        /// Listar todos los grupos de cajas registrados.
        /// </summary>
        /// <returns>Lista de grupos de cajas registrados en el sistema</returns>
        public BindingList<Grupo> listarGrupos()
        {
            BindingList<Grupo> grupos = new BindingList<Grupo>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectGrupos");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string descripcion = (string)datareader["Descripcion"];
                    byte numero_cajas = (byte)datareader["Numero_Cajas"];
                    byte caja_actual = (byte)datareader["Caja_Actual"];
                    short total_manifiestos = (short)datareader["Total_manifiestos"];
                    bool caja_unica = (bool)datareader["Caja_Unica"];
                    AreasManifiestos area = (AreasManifiestos)datareader["Area"];
                    bool semaforo = (bool)datareader["Semaforo"];

                    Grupo grupo = new Grupo(id, nombre, descripcion, numero_cajas, caja_actual, total_manifiestos, caja_unica, area, semaforo);

                    grupos.Add(grupo);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return grupos;
        }
       
        #endregion Métodos Públicos

    }

}
