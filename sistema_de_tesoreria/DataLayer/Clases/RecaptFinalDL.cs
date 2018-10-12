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
    public class RecaptFinalDL : ObjetoIndexado
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static RecaptFinalDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static RecaptFinalDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new RecaptFinalDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public RecaptFinalDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo RecaptFinal en el sistema.
        /// </summary>
        /// <param name="c">Objeto RecaptFinal con los datos del nuevo RecaptFinal</param>
        public void agregarRecaptFinal(ref RecaptFinal c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertRecapAdicional");

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
                throw new Excepcion("ErrorRecaptFinalRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un RecaptFinal en el sistema.
        /// </summary>
        /// <param name="c">Objeto RecaptFinal con los datos del RecaptFinal</param>
        public void actualizarRecaptFinal(RecaptFinal c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateRecaptFinal");

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
                throw new Excepcion("ErrorRecaptFinalActualizacion");
            }

        }





        /// <summary>
        /// Marcar como inactivo a un RecaptFinal del sistema.
        /// </summary>
        /// <param name="c">Objeto RecaptFinal con los datos del RecaptFinal a marcar</param>
        public void eliminarRecaptFinal(RecaptFinal c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteRecaptFinal");

            _manejador.agregarParametro(comando, "@RecaptFinal", c.ID, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRecaptFinalEliminacion");
            }

        }

        /// <summary>
        /// Listar a los RecaptFinal del sistema.
        /// </summary>
        /// <param name="n">Parte del nombre de los RecaptFinal a listar</param>
        /// <returns>Lista de los RecaptFinal registrados en el sistema</returns>
        public BindingList<MontosRecaptFinal> listarRecaptFinal(DateTime n)
        {
            BindingList<MontosRecaptFinal> recapts = new BindingList<MontosRecaptFinal>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectRecaptAdicional");
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


                    Denominacion d = new Denominacion(id:id_denominacion2,valor:valor_denominacion,moneda:moneda);

                    MontosRecaptFinal montorecapt = new MontosRecaptFinal(denominacion: d, cantidad_asignada: monto); 
                        

                   
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
        /// Listar a los RecaptFinal del sistema.
        /// </summary>
        /// <param name="n">Parte del nombre de los RecaptFinal a listar</param>
        /// <returns>Lista de los RecaptFinal registrados en el sistema</returns>
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
                    RecaptFinal preliminar = new RecaptFinal();

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

                    recap.agregarRecapFinal(preliminar);


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
        /// Listar a los RecaptFinal del sistema.
        /// </summary>
        /// <param name="n">Parte del nombre de los RecaptFinal a listar</param>
        /// <returns>Lista de los RecaptFinal registrados en el sistema</returns>
        public BindingList<RecaptFinal> listarRecapPreliminarPorEstado(EstadoRecapt estado)
        {
            BindingList<RecaptFinal> recapts = new BindingList<RecaptFinal>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectRecaptFinalPorAprobar");
            SqlDataReader datareader = null;
            _manejador.agregarParametro(comando, "@estado", estado, SqlDbType.Int);
            Recap recap = new Recap();

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    RecaptFinal preliminar = new RecaptFinal();

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
        /// Verificar si existe un RecaptFinal.
        /// </summary>
        /// <param name="c">Objeto RecaptFinal con los datos del RecaptFinal a verificar</param>
        /// <returns>Valor que indica si el RecaptFinal existe</returns>
        public bool verificarRecaptFinal(ref RecaptFinal c)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteRecaptFinal");
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
                throw new Excepcion("ErrorVerificarRecaptFinalDuplicado");
            }

            return existe;
        }

      


        #endregion Métodos Públicos
    }

    
}
