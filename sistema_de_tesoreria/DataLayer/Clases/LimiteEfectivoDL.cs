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
    public class LimiteEfectivoDL:ObjetoIndexado
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static LimiteEfectivoDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static LimiteEfectivoDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new LimiteEfectivoDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public LimiteEfectivoDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar una nueva cámara.
        /// </summary>
        /// <param name="c">Objeto LimiteEfectivo con los datos de la nueva cámara</param>
        public void agregarLimiteEfectivo(ref LimiteEfectivo c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertLimiteEfectivo");

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@limiteAD", c.LimiteAD, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@limiteBD", c.LimiteBD, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@limiteCOL", c.LimiteCOL, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@limiteDOL", c.LimiteDOL, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@limiteEUR", c.LimiteEUR, SqlDbType.Decimal); //Cambios GZH 23/08/2017
            _manejador.agregarParametro(comando, "@usuario", c.Usuario_creacion, SqlDbType.Int);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorLimiteEfectivoRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de una cámara.
        /// </summary>
        /// <param name="c">Objeto LimiteEfectivo con los datos de la cámara a actualizar</param>
        public void actualizarLimiteEfectivo(LimiteEfectivo c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateLimiteEfectivo");

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@limiteAD", c.LimiteAD, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@limiteBD", c.LimiteBD, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@limiteCOL", c.LimiteCOL, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@limiteDOL", c.LimiteDOL, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@limiteEUR", c.LimiteEUR, SqlDbType.Decimal); //Cambios GZH 23/08/2017
            _manejador.agregarParametro(comando, "@usuario", c.Usuario_creacion, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@limiteID", c.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorLimiteEfectivoActualizacion");
            }

        }

        /// <summary>
        /// Actualizar los datos de una cámara.
        /// </summary>
        /// <param name="c">Objeto LimiteEfectivo con los datos de la cámara a actualizar</param>
        public void actualizarLimiteEfectivoTodos(LimiteEfectivo c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateLimiteEfectivo2");
            
            _manejador.agregarParametro(comando, "@limiteAD", c.LimiteAD, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@limiteBD", c.LimiteBD, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@limiteCOL", c.LimiteCOL, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@limiteDOL", c.LimiteDOL, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@limiteEUR", c.LimiteEUR, SqlDbType.Decimal); //Cambios GZH 23/08/2017
            _manejador.agregarParametro(comando, "@usuario", c.Usuario_creacion, SqlDbType.Int);           

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorLimiteEfectivoActualizacion");
            }

        }

        /// <summary>
        /// Listar todas las cámaras registradas.
        /// </summary>
        /// <returns>Lista de cámaras registradas en el sistema</returns>
        public BindingList<LimiteEfectivo> listarLimiteEfectivo(int c) //Cambios GZH 11092017
        {
            BindingList<LimiteEfectivo> listaLimiteEfectivo = new BindingList<LimiteEfectivo>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectLimiteEfectivo");
            SqlDataReader datareader = null;
            _manejador.agregarParametro(comando, "@cajero", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    Decimal limiteAD = (Decimal)datareader["Limite_AD"];
                    Decimal limiteBD = (Decimal)datareader["Limite_BD"];
                    Decimal limiteCOL = (Decimal)datareader["Limite_COL"];
                    Decimal limiteDOL = (Decimal)datareader["Limite_DOL"];
                    Decimal limiteEUR = (Decimal)datareader["Limite_EUR"]; //cambios GZH 23/08/2017
                    Colaborador colaborador = null;
                    int idColaborador = (int)datareader["idColaborador"];
                    string nombreColaborador = (string)datareader["nombreColaborador"];
                    string primerapellidoColaborador = (string)datareader["primerAPColaborador"];
                    string segundoapellidoColaborador = (string)datareader["segundoAPColaborador"];
                    colaborador = new Colaborador(id:idColaborador, nombre:nombreColaborador, primer_apellido: primerapellidoColaborador,segundo_apellido: segundoapellidoColaborador);

                    LimiteEfectivo LimiteEfectivo = new LimiteEfectivo(id, cajero: colaborador, limiteAD: limiteAD, limiteBD: limiteBD, limiteDOL: limiteDOL, limiteEUR: limiteEUR, limiteCOL: limiteCOL); //Cambios GZH añade limiteEUR 23/08/2017

                    listaLimiteEfectivo.Add(LimiteEfectivo);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return listaLimiteEfectivo;
        }

        public DataTable listarMonitoreoLimiteEfectivo(int c)
        {            

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectMonitoreoLimiteEfectivo");
            DataTable salida = new DataTable();
            SqlDataReader datareader = null;
            _manejador.agregarParametro(comando, "@cajero", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                salida.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return salida;
        }
       
        #endregion Métodos Públicos
    }
}
