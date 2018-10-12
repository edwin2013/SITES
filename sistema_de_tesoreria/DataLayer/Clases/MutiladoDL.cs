using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;
using CommonObjects.Clases;

namespace DataLayer
{
    public class MutiladoDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static MutiladoDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static MutiladoDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new MutiladoDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;


        #endregion Atributos


         #region Constructor

        public MutiladoDL() { }

        #endregion Constructor


        #region Metodos Públicos

        /// <summary>
        /// Agrega un registro de billete - moneda mutilado en el sistema.
        /// </summary>
        /// <param name="m">Objeto Mutilado con los datos del nuevo registro</param>
        public void agregarEfectivoMutilado(ref Mutilado copia_mutilado)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertEfectivoMutilado");

            _manejador.agregarParametro(comando, "@registrador", copia_mutilado.Colaborador_Registro, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@sucursal", copia_mutilado.Sucursal, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@transportadora", copia_mutilado.Transportadora, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@manifiesto", copia_mutilado, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@ruta", copia_mutilado.Ruta, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@estado", copia_mutilado.Sucursal, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha", copia_mutilado.Fecha_Asignada, SqlDbType.Date);

           

            try
            {
                copia_mutilado.DB_ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaRegistro");
            }

        }


        /// <summary>
        /// Actualizar los datos de la carga de un Sucursal.
        /// </summary>
        /// <param name="c">Objeto CargaSucursal con los datos de la carga</param>
        public void actualizarEfectivoMutilado(Mutilado m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateEfectivoMutilado");
            
            //_manejador.agregarParametro(comando, "@manifiesto", m.Manifiesto, SqlDbType.Int);
            //_manejador.agregarParametro(comando, "@sucursal", m.Sucursal, SqlDbType.Int);
            //_manejador.agregarParametro(comando, "@ruta", m.Ruta, SqlDbType.TinyInt);
            //_manejador.agregarParametro(comando, "@hora_inicio", m.Hora_inicio, SqlDbType.DateTime);
            //_manejador.agregarParametro(comando, "@hora_finalizacion", m.Hora_finalizacion, SqlDbType.DateTime);
            //_manejador.agregarParametro(comando, "@observaciones", m.Observaciones, SqlDbType.VarChar);
            //_manejador.agregarParametro(comando, "@mutilado", m, SqlDbType.Int);
            //_manejador.agregarParametro(comando, "@transportadora", m.Transportadora, SqlDbType.TinyInt);
            //_manejador.agregarParametro(comando, "@tipo_carga", m.TipoEntregas, SqlDbType.Int);
            //_manejador.agregarParametro(comando, "@estado", m.Estado, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaATMActualizacion");
            }

        }



        #endregion Metodos Públicos
    }
}
