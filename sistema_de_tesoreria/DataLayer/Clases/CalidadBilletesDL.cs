using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.Data.SqlClient;
using System.Data;
using LibreriaMensajes;
using System.ComponentModel;
using CommonObjects.Clases;

namespace DataLayer.Clases
{
    public class CalidadBilletesDL
    {
          #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CalidadBilletesDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CalidadBilletesDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CalidadBilletesDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public CalidadBilletesDL() { }

        #endregion Constructor

        #region Métodos Públicos

        public void agregarCalidadBilletes(ref CalidadBilletes g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCalidadBilletes");

            //_manejador.agregarParametro(comando, "@tipo", g.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@nombre", g.Nombre, SqlDbType.NVarChar);
            try
            {
                g.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorproveedorCartuchoRegistro");
            }

        }

       public void actualizarCalidadBilletes(ref CalidadBilletes g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCalidadBilletes");

            _manejador.agregarParametro(comando, "@calidad", g.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@nombre", g.Nombre, SqlDbType.NVarChar);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorProveedorCartuchoActualizacion");
            }

        }

       public void eliminarCalidadBilletes(CalidadBilletes g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCalidadBilletes");

            _manejador.agregarParametro(comando, "@calidad", g, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErroroProveedorCartuchoEliminacion");
            }

        }

       public BindingList<CalidadBilletes> listarCalidadBilletes(string nombre)
        {
            BindingList<CalidadBilletes> calidad = new BindingList<CalidadBilletes>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCalidadBilletes");

            _manejador.agregarParametro(comando,"@nombre", nombre, SqlDbType.NVarChar);
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_calidad = (int)datareader["pk_ID"];
                    string nom = (string)datareader["Nombre"];

                    CalidadBilletes calidadbillete = new CalidadBilletes(id: id_calidad, nombre: nom);

                    calidad.Add(calidadbillete);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return calidad;
        }

        #endregion Métodos Públicos
    }
}
