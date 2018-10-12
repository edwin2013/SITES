using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using CommonObjects.Clases;
using System.Data.SqlClient;
using System.Data;
using LibreriaMensajes;
using System.ComponentModel;
using CommonObjects;

namespace DataLayer.Clases
{
    public class AsignacionAsignacionEquipoDL:ObjetoIndexado
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static AsignacionAsignacionEquipoDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static AsignacionAsignacionEquipoDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new AsignacionAsignacionEquipoDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public AsignacionAsignacionEquipoDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo cliente en el sistema.
        /// </summary>
        /// <param name="c">Objeto AsignacionEquipo con los datos del nuevo cliente</param>
        public void agregarAsignacionEquipo(ref Tripulacion c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertAsignacionEquipo");

            _manejador.agregarParametro(comando, "@tripulacion", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@colaborador_registro", c.Asignaciones.ColaboradorRegistro, SqlDbType.Int);

            try
            {
                c.Asignaciones.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorAsignacionEquipoRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un cliente en el sistema.
        /// </summary>
        /// <param name="c">Objeto AsignacionEquipo con los datos del cliente</param>
        public void actualizarAsignacionEquipo(Tripulacion c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateAsignacionEquipo");

            _manejador.agregarParametro(comando, "@registro_colaborador", c.Asignaciones.ColaboradorRegistro, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@asignacion", c.Asignaciones, SqlDbType.Int);


            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorAsignacionEquipoActualizacion");
            }

        }

        /// <summary>
        /// Marcar como inactivo a un cliente del sistema.
        /// </summary>
        /// <param name="c">Objeto AsignacionEquipo con los datos del cliente a marcar</param>
        public void eliminarAsignacionEquipo(AsignacionEquipo c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteAsignacionEquipo");

            _manejador.agregarParametro(comando, "@cliente", c.ID, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorAsignacionEquipoEliminacion");
            }

        }

        /// <summary>
        /// Listar a los clientes del sistema.
        /// </summary>
        /// <param name="n">Parte del nombre de los clientes a listar</param>
        /// <returns>Lista de los cliente registrados en el sistema</returns>
        public BindingList<AsignacionEquipo> listarAsignacionEquipos(string n)
        {
            BindingList<AsignacionEquipo> clientes = new BindingList<AsignacionEquipo>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectAsignacionEquipos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@nombre", n, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    int contactoasignado = (int)datareader["Nombre"];
                    string contacto = (string)datareader["Contacto"];
                   
                    bool solicitud_remesas = (bool)datareader["Solicitud_Remesas"];

                 //   AsignacionEquipo cliente = new AsignacionEquipo(id, nombre, contrato_transporte, solicitud_remesas, contacto);

                  //  clientes.Add(cliente);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return clientes;
        }

        /// <summary>
        /// Verificar si existe un cliente.
        /// </summary>
        /// <param name="c">Objeto cliente con los datos del cliente a verificar</param>
        /// <returns>Valor que indica si el cliente existe</returns>
        public bool verificarAsignacionEquipo(ref AsignacionEquipo c)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteAsignacionEquipo");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];

                    existe = id != c.ID;

                    c.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarAsignacionEquipoDuplicado");
            }

            return existe;
        }

        
        

        #region Asignacion de Equipos

        /// <summary>
        /// Registrar un equipo para un cliente.
        /// </summary>
        /// <param name="t">Objeto Equipo con los datos del equipo</param>
        /// <param name="c">AsignacionEquipo al cual pertenece el equipo</param>
        public void agregarEquipoAsignacionEquipo(ref Equipo t, Tripulacion c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertAsignacionEquipoEquipo");

            _manejador.agregarParametro(comando, "@equipo", t.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@asignacion", c.Asignaciones, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@colaborador", c.Asignaciones.ColaboradorAsignado, SqlDbType.Int);

            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEquipoAsignacionEquipoActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos del equipo de un cliente.
        /// </summary>
        /// <param name="t">Objeto Equipo con los datos del telefono a eliminar</param>
        public void eliminarEquipoAsignacionEquipo(Equipo t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteAsignacionEquipoEquipo");

            _manejador.agregarParametro(comando, "@equipo", t.IDAsignacionEquipo, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEquipoAsignacionEquipoActualizacion");
            }

        }

        /// <summary>
        /// Obtener los equipos de un cliente.
        /// </summary>
        /// <param name="c">AsignacionEquipo para el cual se obtiene la lista de equipo</param>
        public void obtenerEquiposAsignacionEquipo(ref AsignacionEquipo c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectAsignacionEquipoEquipos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@asignacion", c.ID, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string numero = (string)datareader["Equipo"];

                    Equipo telefono = new Equipo(id, numero);

                    c.agregarEquipo(telefono);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        #endregion Asignacion de Equipos



        #endregion Métodos Públicos
    }
}
