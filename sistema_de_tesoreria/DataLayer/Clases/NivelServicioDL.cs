using CommonObjects;
using CommonObjects.Clases;
using LibreriaAccesoDatos;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataLayer.Clases
{
    public class NivelServicioDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static NivelServicioDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static NivelServicioDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new NivelServicioDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public NivelServicioDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un detalle de una falla
        /// </summary>
        /// <param name="s">Objeto NivelServicio con los datos del punto de venta</param>
        public void agregarNivelServicio(ref NivelServicio p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertNivelServicio");

            _manejador.agregarParametro(comando, "@cliente", p.Cliente.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@porcentaje_cumplimiento", p.PorcentajeNivelCumplimiento, SqlDbType.Float);
            _manejador.agregarParametro(comando, "@porcentaje_efectividad", p.PorcentajeNivelEfectividad, SqlDbType.Float);
            _manejador.agregarParametro(comando, "@fecha_inicio", p.FechaInicio, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fecha_fin", p.FechaFin, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@transportadora", p.Transportadora, SqlDbType.TinyInt);

            try
            {
               int id_nuevo = (int)_manejador.ejecutarEscalar(comando);
               p.Id = (short)id_nuevo;
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorNivelServicioActualizacion");
            }

        }

        /// <summary>
        /// Actualizar los datos de un detalle de una falla
        /// </summary>
        /// <param name="s">Objeto NivelServicio con los datos del punto de venta</param>
        public void actualizarNivelServicio(NivelServicio p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateNivelServicio");

            _manejador.agregarParametro(comando, "@cliente", p.Cliente.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@porcentaje_cumplimiento", p.PorcentajeNivelCumplimiento, SqlDbType.Float);
            _manejador.agregarParametro(comando, "@porcentaje_efectividad", p.PorcentajeNivelEfectividad, SqlDbType.Float);
            _manejador.agregarParametro(comando, "@fecha_inicio", p.FechaInicio, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fecha_fin", p.FechaFin, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@nivelservicio", p.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@transportadora", p.Transportadora, SqlDbType.TinyInt);


            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorNivelServicioActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un detalle de una falla.
        /// </summary>
        /// <param name="s">Objeto NivelServicio con los datos del punto de venta a eliminar</param>
        public void eliminarNivelServicio(NivelServicio p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteNivelServicio");

            _manejador.agregarParametro(comando, "@nivel_servicio", p.Id, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorNivelServicioActualizacion");
            }

        }

        /// <summary>
        /// Obtener los detalle de una falla .
        /// </summary>
        /// <param name="c">Falla para el cual se obtiene la lista de detalles de falla</param>
        public BindingList<NivelServicio> obtenerNivelServicio(DateTime fechai, DateTime fechaf)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectNivelServicio");
            SqlDataReader datareader = null;

            BindingList<NivelServicio> niveles = new BindingList<NivelServicio>();

            _manejador.agregarParametro(comando, "@fecha_inicio", fechai, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fecha_fin", fechaf, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    
                    short id_cliente = (short)datareader["ID_Cliente"];
                    short id_nuevo = (short)id_cliente;
                    double porcentaje_cumplimiento = (double)datareader["Porcentaje_Cumplimiento"];
                    double porcentaje_efectividad = (double)datareader["Porcentaje_Efectividad"];
                    string nombre_cliente = (string)datareader["Nombre_Cliente"];
                    DateTime fecha_inicio = (DateTime)datareader["FechaInicio"];
                    DateTime fecha_fin = (DateTime)datareader["FechaFin"];
                    Cliente cliente = null;
                    EmpresaTransporte trans = null;
                    if (datareader["ID_Cliente"] != DBNull.Value)
                    {
                        cliente = new Cliente();
                        cliente.Id = id_nuevo;
                        cliente.Nombre = nombre_cliente;
                    }

                    byte id_transportadora = 0;
                    string nombre_transportadora = "";

                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        id_transportadora = (byte)datareader["ID_Transportadora"];
                        nombre_transportadora = (string)datareader["Nombre_Transportadora"];

                        trans = new EmpresaTransporte(id: id_transportadora, nombre: nombre_transportadora);
                    }


                    NivelServicio punto = new NivelServicio(id: id, porcentaje_cumplimiento: porcentaje_cumplimiento, porcentaje_efectividad: porcentaje_efectividad, cliente: cliente, fechainicio : fecha_inicio, fechafin : fecha_fin, transp: trans);

                    niveles.Add(punto);
                }

                
                comando.Connection.Close();
                return niveles;
                
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }


        /// <summary>
        /// Valida si un nivel de servicio se encuentra registrado
        /// </summary>
        /// <param name="t">Objeto NivelServicio con los datos del Nivel</param>
        /// <returns></returns>
        public bool verificarNivelServicio(ref NivelServicio t)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteNivelServicio");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@transportadora", t.Transportadora.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cliente", t.Cliente.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha_inicio", t.FechaInicio, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fecha_fin", t.FechaFin, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    existe = id != t.Id;

                    t.Id = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarATMDuplicado");
            }

            return existe;

        }
       
        #endregion Métodos Públicos
    }
}
