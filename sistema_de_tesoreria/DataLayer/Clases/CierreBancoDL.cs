using CommonObjects;
using CommonObjects.Clases;
using LibreriaAccesoDatos;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataLayer.Clases
{
    public class CierreBancoDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CierreBancoDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CierreBancoDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CierreBancoDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public CierreBancoDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un cierre de Sucursales en el sistema.
        /// </summary>
        /// <param name="c">Objeto CierreCargaBanco con los datos del cierre</param>
        public void agregarCierreBanco(ref CierreCargaBanco c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCierreBancos");

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCierreRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un cierre de Sucursal.
        /// </summary>
        /// <param name="c">Objeto CierreCargaBanco con los datos del cierre</param>
        public void actualizarCierreBanco(CierreCargaBanco c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCierreBancos");

            _manejador.agregarParametro(comando, "@coordinador", c.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@camara", c.Camara, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cierre", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCierreActualizacion");
            }

        }

        /// <summary>
        /// Marcar como terminado un cierre de Sucursal.
        /// </summary>
        /// <param name="c">Objeto CierreCargaBanco con los datos del cierre</param>
        public void actualizarCierreBancoTerminar(CierreCargaBanco c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCierreBancosTerminar");

            _manejador.agregarParametro(comando, "@cierre", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCierreActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un cierre de Sucursales.
        /// </summary>
        /// <param name="c">Objeto CierreCargaBanco con los datos del cierre a eliminar</param>
        public void eliminarCierreBanco(CierreCargaBanco c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCierreBancos");

            _manejador.agregarParametro(comando, "@cierre", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCierreEliminacion");
            }

        }

        /// <summary>
        /// Verificar si existe un cierre registrado para un cajero en una fecha determinada.
        /// </summary>
        /// <param name="c">Objeto CierreCargaBanco con los datos del cierre</param>
        /// <returns>Valor que indica si el cierre existe</returns>
        public bool verificarCierreBanco(ref CierreCargaBanco c)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreBovedaBancos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    existe = true;

                    int id_cierre = (int)datareader["ID_Cierre"];
                    bool terminado = (bool)datareader["Terminado"];

                    Camara camara = null;

                    if (datareader["ID_Camara"] != DBNull.Value)
                    {
                        byte id_camara = (byte)datareader["ID_Camara"];
                        string identificador = (string)datareader["Identificador"];

                        camara = new Camara(identificador, id: id_camara);
                    }

                    Colaborador coordinador = null;

                    if (datareader["ID_Coordinador"] != DBNull.Value)
                    {
                        int id_coordinador = (int)datareader["ID_Coordinador"];
                        string nombre = (string)datareader["Nombre"];
                        string primer_apellido = (string)datareader["Primer_Apellido"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido"];

                        coordinador = new Colaborador(id_coordinador, nombre, primer_apellido, segundo_apellido);
                    }

                    c.ID = id_cierre;
                    c.Coordinador = coordinador;
                    c.Camara = camara;
                    c.Terminado = terminado;
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
        /// Verificar si un cajero tiene un cierre pendiente de finalizar.
        /// </summary>
        /// <param name="c">Objeto CierreCargaBanco con los datos del cajero</param>
        /// <returns>Valor que indica si el cajero tiene un cierre pendiente</returns>
        public bool verificarCierreBancoPendiente(ref CierreCargaBanco c)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreBancoPendiente");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
     

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    existe = true;

                    int id_cierre = (int)datareader["ID_Cierre"];
                    DateTime fecha = (DateTime)datareader["Fecha"];

                    Camara camara = null;

                    if (datareader["ID_Camara"] != DBNull.Value)
                    {
                        byte id_camara = (byte)datareader["ID_Camara"];
                        string identificador = (string)datareader["Identificador"];

                        camara = new Camara(identificador, id: id_camara);
                    }

                    Colaborador coordinador = null;

                    if (datareader["ID_Coordinador"] != DBNull.Value)
                    {
                        int id_coordinador = (int)datareader["ID_Coordinador"];
                        string nombre = (string)datareader["Nombre"];
                        string primer_apellido = (string)datareader["Primer_Apellido"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido"];

                        coordinador = new Colaborador(id_coordinador, nombre, primer_apellido, segundo_apellido);
                    }

                    c.ID = id_cierre;
                    c.Coordinador = coordinador;
                    c.Camara = camara;
                    c.Fecha = fecha;
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
    }
}
