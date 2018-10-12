using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using CommonObjects.Clases;
using System.Data;
using System.Data.SqlClient;
using LibreriaMensajes;
using CommonObjects;
using System.ComponentModel;

namespace DataLayer.Clases.Reportes
{
    public class CartuchoMutiladoDL
    {
         #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CartuchoMutiladoDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CartuchoMutiladoDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CartuchoMutiladoDL ();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

         
        #region Constructor

        public CartuchoMutiladoDL() { }

        #endregion Constructor

         #region Métodos Públicos

        /// <summary>
        /// Registrar en el sistema el cartucho de una carga.
        /// </summary>
        /// <param name="c">Objeto CartuchoMutilado con los datos del cartucho</param>
        public void agregarCartuchoEfectivoMutilado(ref CartuchoMutilado  c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCartuchoEfectivoMutilado");
            
            _manejador.agregarParametro(comando,"@mutilado",c.Mutilado, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@denominacion", c.Denominacion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cantidad_asignada",c.Cantidad_carga, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cantidad_mutilado", c.Monto_asignado, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@marchamo", c.Marchamo, SqlDbType.NChar);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCartuchoCargaSucursalRegistro");
            }

        }


  
        /// <summary>
        /// Actualizar los datos del cartucho de una carga de una Sucursal.
        /// </summary>
        /// <param name="c">Objeto CartuchoEfectivoMutilado con los datos del cartucho</param>
       public void actualizarCartuchoEfectivoMutilado(CartuchoMutilado c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCartuchoEfectivoMutilado");

            _manejador.agregarParametro(comando, "@marchamo", c.Marchamo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@cartucho", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCartuchoCargaATMActualizacion");
            }

      }
        #endregion Métodos Públicos
        
    

    }
}

