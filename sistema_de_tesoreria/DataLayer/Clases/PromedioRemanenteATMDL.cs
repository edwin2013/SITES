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
    public class PromedioRemanenteATMDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static PromedioRemanenteATMDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static PromedioRemanenteATMDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new PromedioRemanenteATMDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public PromedioRemanenteATMDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un detalle de una falla
        /// </summary>
        /// <param name="s">Objeto PromedioRemanenteATM con los datos del punto de venta</param>
        public void agregarPromedioRemanenteATM(ref PromedioRemanenteATM p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertPromedioRemanenteATM");

            _manejador.agregarParametro(comando, "@promedio_quincena", p.MontoQuincena, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@promedio", p.Monto, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@promedio_dolares_quincena", p.MontoQuincenaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@promedio_dolares", p.MontoDolares, SqlDbType.Decimal);
           
            try
            {
               int id_nuevo = (int)_manejador.ejecutarEscalar(comando);
               p.ID = (int)id_nuevo;
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPromedioRemanenteATMActualizacion");
            }

        }

        /// <summary>
        /// Actualizar los datos de un detalle de una falla
        /// </summary>
        /// <param name="s">Objeto PromedioRemanenteATM con los datos del punto de venta</param>
        public void actualizarPromedioRemanenteATM(PromedioRemanenteATM p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePromedioRemanenteATM");

            _manejador.agregarParametro(comando, "@promedio_quincena", p.MontoQuincena, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@promedio", p.Monto, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@promedio_dolares_quincena", p.MontoQuincenaDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@promedio_dolares", p.MontoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@promediodescarga", p.ID, SqlDbType.Int);


            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPromedioRemanenteATMActualizacion");
            }

        }

      

        /// <summary>
        /// Obtener los detalle de una falla .
        /// </summary>
        /// <param name="c">Falla para el cual se obtiene la lista de detalles de falla</param>
        public PromedioRemanenteATM obtenerPromedioRemanenteATM()
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPromedioRemanenteATM");
            SqlDataReader datareader = null;

           PromedioRemanenteATM niveles = new PromedioRemanenteATM();

            

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["ID_Promedio"];
                    decimal monto = (decimal)datareader["Monto"];
                    decimal monto_quincena = (decimal)datareader["MontoQuincena"];
                    decimal montodolares = (decimal)datareader["MontoDolares"];
                    decimal montodolares_quincena = (decimal)datareader["MontoDolaresQuincena"];

                    PromedioRemanenteATM punto = new PromedioRemanenteATM(id: id,monto: monto, montoquincena:monto_quincena, montodolares: montodolares, montodolaresq: montodolares_quincena );

                    niveles = punto;
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
        /// <param name="t">Objeto PromedioRemanenteATM con los datos del Nivel</param>
        /// <returns></returns>
        public bool verificarPromedioRemanenteATM(ref PromedioRemanenteATM t)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExistePromedioRemanenteATM");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@numero", t.ID, SqlDbType.SmallInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    existe = id != t.ID;

                    t.ID = id;
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
