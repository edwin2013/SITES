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
    public class FormulaDL : ObjetoIndexado
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static FormulaDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static FormulaDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new FormulaDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public FormulaDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un tipo de cambio.
        /// </summary>
        /// <param name="u">Objeto Formula con los datos del tipo de cambio</param>
        public void agregarFormula(ref Formula t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertFormula");

            _manejador.agregarParametro(comando, "@paqueton", t.Paquete, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@bolsa", t.Bolsa, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@colaborador", t.Colaborador, SqlDbType.Int);

            try
            {
                t.Id = (short)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorFormulaRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos del tipo de cambio de una fecha determinada.
        /// </summary>
        /// <param name="u">Objeto Formula con los datos del tipo de cambio</param>
        public void actualizarFormula(Formula t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateFormula");

            _manejador.agregarParametro(comando, "@paqueton", t.Paquete, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@bolsa", t.Bolsa, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@formula", t.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@colaborador", t.Colaborador, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorFormulaActualizacion");
            }

        }

        /// <summary>
        /// Obtener el tipo de cambio de una fecha específica.
        /// </summary>
        /// <param name="f">Fecha para la cual se obtendrá el tipo de cambio</param>
        /// <returns>Objeto Formula con los datos del tipo de cambio de la fecha especificada</returns>
        public Formula obtenerFormula()
        {
            Formula tipo_cambio = null;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectFormula");
            SqlDataReader datareader = null;


            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {

                    short id = (short)datareader["pk_ID"];
                    int bolsa = (int)datareader["Bolsa"];
                    int paqueton = (int)datareader["Paqueton"];

                    tipo_cambio = new Formula(id:id, bolsa:bolsa, paqueton:paqueton);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return tipo_cambio;
        }

        /// <summary>
        /// Verificar si ya se registró el tipo de cambio para una fecha determinada.
        /// </summary>
        /// <param name="t">Objeto Formula con los datos del tipo de cambio</param>
        /// <returns>Valor booleano que indica si el tipo de cmabio ya fue registrado</returns>
        public bool verificarFormula(Formula t)
        {
            bool existe = false;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteFormula");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", t.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id_encontrado = (short)datareader["pk_ID"];

                    existe = id_encontrado != t.Id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarFormula");
            }

            return existe;
        }

        #endregion Métodos Públicos
    }
}
