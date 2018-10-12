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
    public class RecaptPreliminarDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static RecaptPreliminarDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static RecaptPreliminarDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new RecaptPreliminarDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public RecaptPreliminarDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo RecaptPreliminar en el sistema.
        /// </summary>
        /// <param name="c">Objeto RecaptPreliminar con los datos del nuevo RecaptPreliminar</param>
        public void agregarRecaptPreliminar(ref RecaptPreliminar c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertRecaptPreliminar");

            _manejador.agregarParametro(comando, "@colaborador", c.Colaborador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@estado", c.Estado, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tipo_recap", c.TipoRecap, SqlDbType.Int);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRecaptPreliminarRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un RecaptPreliminar en el sistema.
        /// </summary>
        /// <param name="c">Objeto RecaptPreliminar con los datos del RecaptPreliminar</param>
        public void actualizarRecaptPreliminar(RecaptPreliminar c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateRecaptPreliminar");

            _manejador.agregarParametro(comando, "@colaborador", c.Colaborador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@estado", c.Estado, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@estado", c.Estado, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@estado", c.Estado, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRecaptPreliminarActualizacion");
            }

        }




        /// <summary>
        /// Actualizar los datos de un RecaptPreliminar en el sistema.
        /// </summary>
        /// <param name="c">Objeto RecaptPreliminar con los datos del RecaptPreliminar</param>
        public void actualizarEnvioAprobacionRecapPreliminar(DateTime fecha, EstadoRecapt estado)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateEnvioAprobacionRecapPreliminar");

            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@estado", estado, SqlDbType.Int);
 

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRecaptPreliminarActualizacion");
            }

        }

        /// <summary>
        /// Marcar como inactivo a un RecaptPreliminar del sistema.
        /// </summary>
        /// <param name="c">Objeto RecaptPreliminar con los datos del RecaptPreliminar a marcar</param>
        public void eliminarRecaptPreliminar(RecaptPreliminar c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteRecaptPreliminar");

            _manejador.agregarParametro(comando, "@RecaptPreliminar", c.ID, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRecaptPreliminarEliminacion");
            }

        }

        /// <summary>
        /// Listar a los RecaptPreliminar del sistema.
        /// </summary>
        /// <param name="n">Parte del nombre de los RecaptPreliminar a listar</param>
        /// <returns>Lista de los RecaptPreliminar registrados en el sistema</returns>
        public BindingList<MontosRecaptPreliminar> listarRecaptPreliminar(DateTime n)
        {
            BindingList<MontosRecaptPreliminar> recapts = new BindingList<MontosRecaptPreliminar>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectRecaptPreliminar");
            SqlDataReader datareader = null;
            comando.CommandTimeout =100000;
            _manejador.agregarParametro(comando, "@fecha", n, SqlDbType.Date);
            

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {

                    Decimal monto = 0;

                    if (datareader["Monto"] != DBNull.Value)
                    {
                        monto = (decimal)datareader["Monto"];
                    }

                    short id_denominacion = (short)datareader["ID_Denominacion"];
                    byte id_denominacion2 = Convert.ToByte(id_denominacion);
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    decimal valor_denominacion = (decimal)datareader["Valor"];


                    Denominacion d = new Denominacion(valor:valor_denominacion,moneda:moneda);

                    MontosRecaptPreliminar montorecapt = new MontosRecaptPreliminar(denominacion: d, cantidad_asignada: monto); 
                        

                   
                    recapts.Add(montorecapt);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return recapts;
        }







        /// <summary>
        /// Listar a los RecaptPreliminar del sistema.
        /// </summary>
        /// <param name="n">Parte del nombre de los RecaptPreliminar a listar</param>
        /// <returns>Lista de los RecaptPreliminar registrados en el sistema</returns>
        public BindingList<Recap> listarRecap(DateTime n)
        {
            BindingList<Recap> recapts = new BindingList<Recap>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectRecaps");
            SqlDataReader datareader = null;
            comando.CommandTimeout = 100000;
            _manejador.agregarParametro(comando, "@fecha", n, SqlDbType.Date);

            Recap recap = new Recap();

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    RecaptPreliminar preliminar = new RecaptPreliminar();

                    int id_preliminar = (int)datareader["pk_ID"];
                    TipoRecapt tipo = (TipoRecapt)datareader["Tipo"];
                    Colaborador colaborador = null;

                    if (datareader["ID_Colaborador"] != DBNull.Value)
                    {
                        short id_cliente = (short)datareader["ID_Colaborador"];
                        string nombre = (string)datareader["Nombre"];
                        string primer_apellido = (string)datareader["Primer_Apellido"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido"];

                        colaborador = new Colaborador(id: id_cliente, nombre: nombre, primer_apellido: primer_apellido, segundo_apellido: segundo_apellido);

                    }

                    preliminar.TipoRecap = tipo;

                    DateTime fecha = (DateTime)datareader["Fecha_Ingreso"];

                    preliminar.Colaborador = colaborador;

                    recap.agregarRecapPreliminar(preliminar);


                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return recapts;
        }




        /// <summary>
        /// Listar a los RecaptPreliminar del sistema.
        /// </summary>
        /// <param name="n">Parte del nombre de los RecaptPreliminar a listar</param>
        /// <returns>Lista de los RecaptPreliminar registrados en el sistema</returns>
        public BindingList<RecaptPreliminar> listarRecapPreliminarPorEstado(EstadoRecapt estado)
        {
            BindingList<RecaptPreliminar> recapts = new BindingList<RecaptPreliminar>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectRecaptPreliminarPorAprobar");
            SqlDataReader datareader = null;
            _manejador.agregarParametro(comando, "@estado", estado, SqlDbType.Int);
            Recap recap = new Recap();

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    RecaptPreliminar preliminar = new RecaptPreliminar();

                    int id_preliminar = (int)datareader["pk_ID"];
                    int tipo = (int)datareader["Tipo"];

     
                    Colaborador colaborador = null;

                    if (datareader["ID_Colaborador"] != DBNull.Value)
                    {
                        int id_cliente = (int)datareader["ID_Colaborador"];
                        string nombre = (string)datareader["Nombre"];
                        string primer_apellido = (string)datareader["Primer_Apellido"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido"];

                        colaborador = new Colaborador(id: id_cliente, nombre: nombre, primer_apellido: primer_apellido, segundo_apellido: segundo_apellido);

                    }

                    


                    DateTime fecha = (DateTime)datareader["Fecha_Ingreso"];
                    preliminar.TipoRecap = (TipoRecapt)tipo;
                    preliminar.ID = id_preliminar;
                    preliminar.Colaborador = colaborador;
                    preliminar.Fecha_ingreso = fecha;

                    recapts.Add(preliminar);


                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return recapts;
        }




        /// <summary>
        /// Verificar si existe un RecaptPreliminar.
        /// </summary>
        /// <param name="c">Objeto RecaptPreliminar con los datos del RecaptPreliminar a verificar</param>
        /// <returns>Valor que indica si el RecaptPreliminar existe</returns>
        public bool verificarRecaptPreliminar(ref RecaptPreliminar c)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteRecaptPreliminar");
            SqlDataReader datareader = null;
            _manejador.agregarParametro(comando, "@tipo", c.TipoRecap, SqlDbType.Int);
            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    existe = id != c.ID;

                    c.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarRecaptPreliminarDuplicado");
            }

            return existe;
        }

      


        #endregion Métodos Públicos
    }
}
