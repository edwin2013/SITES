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
    public class NivelTipoPenalidadDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static NivelTipoPenalidadDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static NivelTipoPenalidadDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new NivelTipoPenalidadDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public NivelTipoPenalidadDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un detalle de una falla
        /// </summary>
        /// <param name="s">Objeto NivelTipoPenalidad con los datos del punto de venta</param>
        public void agregarNivelTipoPenalidad(ref NivelTipoPenalidad p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertNivelTipoPenalidad");

            _manejador.agregarParametro(comando, "@cantidad_valor_visita", p.CantidadValorVisita, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@porcentaje_minimo", p.PorcentajeMinimo, SqlDbType.Float);
            _manejador.agregarParametro(comando, "@porcentaje_maximo", p.PorcentajeMaximo, SqlDbType.Float);
            _manejador.agregarParametro(comando, "@porcentaje_valor_tarifa", p.PorcentajeValorTarifa, SqlDbType.Float);
            _manejador.agregarParametro(comando, "@tipo_penalidad", p.TipoPenalidad.Id, SqlDbType.Int);

            try
            {
               int id_nuevo = (int)_manejador.ejecutarEscalar(comando);
               p.Id = (short)id_nuevo;
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorNivelTipoPenalidadActualizacion");
            }

        }

        /// <summary>
        /// Actualizar los datos de un detalle de una falla
        /// </summary>
        /// <param name="s">Objeto NivelTipoPenalidad con los datos del punto de venta</param>
        public void actualizarNivelTipoPenalidad(NivelTipoPenalidad p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateNivelTipoPenalidad");

            _manejador.agregarParametro(comando, "@cantidad_valor_visita", p.CantidadValorVisita, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@porcentaje_minimo", p.PorcentajeMinimo, SqlDbType.Float);
            _manejador.agregarParametro(comando, "@porcentaje_maximo", p.PorcentajeMaximo, SqlDbType.Float);
            _manejador.agregarParametro(comando, "@porcentaje_valor_tarifa", p.PorcentajeValorTarifa, SqlDbType.Float);
            _manejador.agregarParametro(comando, "@niveltipopenalidad", p.Id, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorNivelTipoPenalidadActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un detalle de una falla.
        /// </summary>
        /// <param name="s">Objeto NivelTipoPenalidad con los datos del punto de venta a eliminar</param>
        public void eliminarNivelTipoPenalidad(NivelTipoPenalidad p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteNivelTipoPenalidad");

            _manejador.agregarParametro(comando, "@nivel_tipopenalidad", p.Id, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorNivelTipoPenalidadActualizacion");
            }

        }

        /// <summary>
        /// Obtener los detalle de una falla .
        /// </summary>
        /// <param name="c">Falla para el cual se obtiene la lista de detalles de falla</param>
        public void obtenerNivelTipoPenalidadFalla(ref TipoPenalidad c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectNivelTipoPenalidad");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@tipo_penalidad", c.Id, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    short id_nuevo = (short)id;
                    int cantidad_valor_visita = (int)datareader["Cantidad_Valor_Visita"];
                    double porcentaje_minimo = (double)datareader["Porcentaje_Minimo"];
                    double porcentaje_maximo = (double)datareader["Porcentaje_Maximo"];
                    double porcentaje_valor_tarifa = (double)datareader["Porcentaje_Valor_Tarifa"];

                    NivelTipoPenalidad punto = new NivelTipoPenalidad(id: id_nuevo, cantidadvalorvisita: cantidad_valor_visita, porcentaje_tarifa: porcentaje_valor_tarifa, valor_minimo: porcentaje_minimo, valor_maximo: porcentaje_maximo);

                    c.agregarNivel(punto);
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
