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
    public class PromedioDescargaATMDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static PromedioDescargaATMDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static PromedioDescargaATMDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new PromedioDescargaATMDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public PromedioDescargaATMDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un detalle de una falla
        /// </summary>
        /// <param name="s">Objeto PromedioDescargaATM con los datos del punto de venta</param>
        public void agregarPromedioDescargaATM(ref PromedioDescargaATM p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertPromedioDescargaATM");

            _manejador.agregarParametro(comando, "@atm", p.ATM.ID, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@promedio", p.Monto, SqlDbType.Decimal);
           
            try
            {
               int id_nuevo = (int)_manejador.ejecutarEscalar(comando);
               p.ID = (int)id_nuevo;
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPromedioDescargaATMActualizacion");
            }

        }

        /// <summary>
        /// Actualizar los datos de un detalle de una falla
        /// </summary>
        /// <param name="s">Objeto PromedioDescargaATM con los datos del punto de venta</param>
        public void actualizarPromedioDescargaATM(PromedioDescargaATM p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePromedioDescargaATM");

            _manejador.agregarParametro(comando, "@atm", p.ATM.ID, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@promedio", p.Monto, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@promediodescarga", p.ID, SqlDbType.Int);


            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPromedioDescargaATMActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un detalle de una falla.
        /// </summary>
        /// <param name="s">Objeto PromedioDescargaATM con los datos del punto de venta a eliminar</param>
        public void eliminarPromedioDescargaATM(PromedioDescargaATM p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeletePromedioDescargaATM");

            _manejador.agregarParametro(comando, "@promedio_descarga", p.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPromedioDescargaATMActualizacion");
            }

        }

        /// <summary>
        /// Obtener los detalle de una falla .
        /// </summary>
        /// <param name="c">Falla para el cual se obtiene la lista de detalles de falla</param>
        public BindingList<PromedioDescargaATM> obtenerPromedioDescargaATM()
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPromedioDescargaATM");
            SqlDataReader datareader = null;

            BindingList<PromedioDescargaATM> niveles = new BindingList<PromedioDescargaATM>();

            

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["ID_Promedio"];
                    decimal monto = (decimal)datareader["Monto"];

                    ATM atm = null;

                    short id_atm = 0;
                    short numero = 0;
                    string codigo = "";
                    
                    if (datareader["ID_ATM"] != DBNull.Value)
                    {
                        id_atm = (short) datareader["ID_ATM"];
                        numero = (short) datareader["Numero"];
                        codigo = (string) datareader["Codigo"];

                        atm = new ATM(id: id_atm, numero: numero, codigo: codigo);
                    }




                    PromedioDescargaATM punto = new PromedioDescargaATM(id: id, atm: atm, monto: monto);

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
        /// Obtener los detalle de una falla .
        /// </summary>
        /// <param name="c">Falla para el cual se obtiene la lista de detalles de falla</param>
        public void obtenerDatosPromedioDescargaATM(ref PromedioDescargaATM promedio)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPromedioDescargaATMDatos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@atm", promedio.ATM.ID, SqlDbType.SmallInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["ID_Promedio"];
                    decimal monto = (decimal)datareader["Monto"];

                    ATM atm = null;

                    short id_atm = 0;
                    short numero = 0;
                    string codigo = "";

                    if (datareader["ID_ATM"] != DBNull.Value)
                    {
                        id_atm = (short)datareader["ID_ATM"];
                        numero = (short)datareader["Numero"];
                        codigo = (string)datareader["Codigo"];

                        atm = new ATM(id: id_atm, numero: numero, codigo: codigo);
                    }


                    promedio.ATM = atm;
                    promedio.ID = id;
                    promedio.Monto = monto;



                }


                comando.Connection.Close();

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
        /// <param name="t">Objeto PromedioDescargaATM con los datos del Nivel</param>
        /// <returns></returns>
        public bool verificarPromedioDescargaATM(ref PromedioDescargaATM t)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExistePromedioDescargaATM");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@numero", t.ATM.ID, SqlDbType.SmallInt);

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
