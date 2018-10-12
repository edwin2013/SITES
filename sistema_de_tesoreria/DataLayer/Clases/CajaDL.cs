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
    public class CajaDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CajaDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CajaDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CajaDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public CajaDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar una nueva caja.
        /// </summary>
        /// <param name="c">Objeto Caja con los datos de la nueva caja</param>
        public void agregarCaja(ref Caja c, Colaborador usuario)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCaja");

            _manejador.agregarParametro(comando, "@numero", c.Numero, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@descripcion", c.Descripcion, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@fk_ID_Usuario", usuario.ID, SqlDbType.Int);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCajaRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de una caja.
        /// </summary>
        /// <param name="c">Objeto Caja con los datos de la caja a actualizar</param>
        public void actualizarCaja(Caja c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCaja");

            _manejador.agregarParametro(comando, "@numero", c.Numero, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@descripcion", c.Descripcion, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@caja", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCajaActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de una caja.
        /// </summary>
        /// <param name="c">Objeto Caja con los datos de la caja a eliminar</param>
        public void eliminarCaja(Caja c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCaja");

            _manejador.agregarParametro(comando, "@caja", c, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCajaEliminacion");
            }

        }

        /// <summary>
        /// Listar todas las cajas registradas.
        /// </summary>
        /// <returns>Lista de cajas registradas en el sistema</returns>
        public BindingList<Caja> listarCajas(decimal numero)
        {
            BindingList<Caja> Cajas = new BindingList<Caja>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCajas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@numero", numero, SqlDbType.Decimal);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string descripcion = (string)datareader["Descripcion"];
                    decimal Numero =(decimal)datareader["Numero"];
                    DateTime Fecha = (DateTime)datareader["Fecha"];
                    Colaborador usuario = null;
                    if (datareader["fk_ID_Colaborador"] != DBNull.Value)
                    {
                        int fk_ID_Colaborabor = (int)datareader["fk_ID_Colaborador"];
                        string nombre = (string)datareader["NombreColaborador"];

                        usuario = new Colaborador(id:fk_ID_Colaborabor, nombre:nombre);
                    }
                    

                    Caja Caja = new Caja(id:id,fecha_ingreso:Fecha, descripcion:descripcion, numero:Numero, colaborador:usuario);

                    Cajas.Add(Caja);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return Cajas;
        }

      #endregion Métodos Públicos
    }
}
