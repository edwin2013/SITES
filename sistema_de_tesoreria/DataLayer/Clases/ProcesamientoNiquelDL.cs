using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using CommonObjects;
using CommonObjects.Clases;
using System.Data.SqlClient;
using LibreriaMensajes;
using System.ComponentModel;
using System.Data;

namespace DataLayer.Clases
{
    public class ProcesamientoNiquelDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ProcesamientoNiquelDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ProcesamientoNiquelDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ProcesamientoNiquelDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ProcesamientoNiquelDL() { }

        #endregion Constructor

        #region Métodos Públicos
        
        public int agregarInfoConteoNiquel(ref ConteoNiquel conteo)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertInfoConteoNiquel");

            _manejador.agregarParametro(comando, "@denominacion5", conteo.conteo5, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@denominacion10", conteo.conteo10, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@denominacion25", conteo.conteo25, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@denominacion50", conteo.conteo50, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@denominacion100", conteo.conteo100, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@denominacion500", conteo.conteo500, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_Niquel", conteo.conteototal, SqlDbType.Money);            
            
            try
            {
                
                conteo.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("InsertInfoConteoNiquel");
            }

            return conteo.ID;

        }

        public int agregarRegistroProcesamientoNiquel(ref ProcesamientoNiquel proceso)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertProcesamientoNiquel");

            _manejador.agregarParametro(comando, "@fk_ID_Cajero", proceso.Cajero, SqlDbType.Int);
            if (proceso.Deposito == null)
            {
                _manejador.agregarParametro(comando, "@fk_ID_ProcesamientoBajoVolumenDeposito", null, SqlDbType.Int);
            }
            else
            {
                _manejador.agregarParametro(comando, "@fk_ID_ProcesamientoBajoVolumenDeposito", proceso.Deposito.ID, SqlDbType.Int);
            }
            if (proceso.Transportadora == null)
            {
                _manejador.agregarParametro(comando, "@fk_ID_EmpresaTransporte", null, SqlDbType.Int);
            }
            else
            {
                _manejador.agregarParametro(comando, "@fk_ID_EmpresaTransporte", proceso.Transportadora.ID, SqlDbType.Int);
            }
            _manejador.agregarParametro(comando, "@ID_TipoProcesamiento", proceso.TipoProcesamiento, SqlDbType.TinyInt);
            if (proceso.Manifiesto == null)
            {
                _manejador.agregarParametro(comando, "@fk_ID_Manifiesto", null, SqlDbType.Int);
            }
            else
            {
                _manejador.agregarParametro(comando, "@fk_ID_Manifiesto", proceso.Manifiesto.IDManifiesto, SqlDbType.Int);
            }
            _manejador.agregarParametro(comando, "@fk_ID_InfoConteoNiquel", proceso.conteoNiquel.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Identificador", proceso.Identificador, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@Total_Niquel", proceso.TotalNiquel, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Monto_Contado", proceso.MontoContado, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Diferencia", proceso.Diferencia, SqlDbType.Money);

            try
            {

                proceso.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("InsertInfoConteoNiquel");
            }

            return proceso.ID;

        }

        public DataTable listarDatosVerificacionNiquel(byte tipoprocesamiento, string identificador)
        {
            DataTable salida = new DataTable();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDatosVerificacionNiquel");
            SqlDataReader datareader = null;
            _manejador.agregarParametro(comando, "@tipoprocesamiento", tipoprocesamiento, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@identificador", identificador, SqlDbType.VarChar);

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
