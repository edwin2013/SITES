using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using CommonObjects.Clases;
using System.Data.SqlClient;
using LibreriaMensajes;
using System.ComponentModel;
using System.Data;
using CommonObjects;

namespace DataLayer.Clases
{
    public class GarantiaCartuchoDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static GarantiaCartuchoDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static GarantiaCartuchoDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new GarantiaCartuchoDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public GarantiaCartuchoDL() { }

        #endregion Constructor

        #region Métodos Públicos

       
        public void agregarGarantiaCartucho(ref GarantiaCartucho g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("[InsertGarantiaCartucho]");

            _manejador.agregarParametro(comando, "@dias", g.dias, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@colaborador", g.usuario, SqlDbType.SmallInt);
           try
            {
                g.ID = Convert.ToInt32(_manejador.ejecutarEscalar(comando));
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorFallaGarantiaRegistro");
            }

        }

        public void actualizarGarantiaCartucho(ref GarantiaCartucho g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateFallasCartuchos");

            //_manejador.agregarParametro(comando, "@id", g.ID, SqlDbType.TinyInt);
            //_manejador.agregarParametro(comando, "@nombre", g.Nombre, SqlDbType.NVarChar);

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

        public void eliminarGarantiaCartucho(GarantiaCartucho g)
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

        public BindingList<GarantiaCartucho> listarGarantiaCartuchos(string nombre)
        {
            BindingList<GarantiaCartucho> GarantiaCartucho = new BindingList<GarantiaCartucho>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectGarantiaCartucho");

            _manejador.agregarParametro(comando, "@Colaborador", nombre, SqlDbType.NVarChar);
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = Convert.ToInt32(datareader["pk_ID"]);

                    Colaborador us = new Colaborador();
                    us.ID = Convert.ToInt32(datareader["fk_ID_Usuario"]);
                    us.Nombre = (string)datareader["Nombre"];
                    int dias = (int)datareader["CantidadDias"];
                    DateTime fecha = (DateTime)datareader["Fecha"];

                    GarantiaCartucho garantia = new GarantiaCartucho(id: id, usuario:us, dias:dias, fecha:fecha);

                    GarantiaCartucho.Add(garantia);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return GarantiaCartucho;
        }

        #endregion Métodos Públicos
    }
}
