//
//  @ Project : 
//  @ File Name : MontosRetirosATMsDL.cs
//  @ Date : 30/01/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;

namespace DataLayer
{

    /// <summary>
    /// Clase de la capa de datos que maneja los montos esperados de los retiros de los ATM's.
    /// </summary>
    public class MontosRetirosATMsDL
    {
        
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static MontosRetirosATMsDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static MontosRetirosATMsDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new MontosRetirosATMsDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public MontosRetirosATMsDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar los montos esperados en retiros de un ATM en el sistema.
        /// </summary>
        /// <param name="m">Objeto MontosRetirosATM con los montos esperados</param>
        public void agregarMontosRetirosATM(ref MontosRetirosATM m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertMontosRetirosATM");

            _manejador.agregarParametro(comando, "@atm", m.ATM, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@moneda", m.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@retiro_lunes", m.Retiro_lunes, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_martes", m.Retiro_martes, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_miercoles", m.Retiro_miercoles, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_jueves", m.Retiro_jueves, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_viernes", m.Retiro_viernes, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_sabado", m.Retiro_sabado, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_domingo", m.Retiro_domingo, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_lunes_quincena", m.Retiro_lunes_quincena, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_martes_quincena", m.Retiro_martes_quincena, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_miercoles_quincena", m.Retiro_miercoles_quincena, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_jueves_quincena", m.Retiro_jueves_quincena, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_viernes_quincena", m.Retiro_viernes_quincena, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_sabado_quincena", m.Retiro_sabado_quincena, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_domingo_quincena", m.Retiro_domingo, SqlDbType.Money);

            try
            {
                m.ID = (short)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorMontosRetirosATMRegistro");
            }

        }

        /// <summary>
        /// Actualizar los montos esperados en retiros de un ATM en el sistema.
        /// </summary>
        /// <param name="m">Objeto MontosRetirosATM con los montos esperados</param>
        public void actualizarMontosRetirosATM(MontosRetirosATM m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateMontosRetirosATM");

            _manejador.agregarParametro(comando, "@retiro_lunes", m.Retiro_lunes, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_martes", m.Retiro_martes, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_miercoles", m.Retiro_miercoles, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_jueves", m.Retiro_jueves, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_viernes", m.Retiro_viernes, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_sabado", m.Retiro_sabado, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_domingo", m.Retiro_domingo, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_lunes_quincena", m.Retiro_lunes_quincena, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_martes_quincena", m.Retiro_martes_quincena, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_miercoles_quincena", m.Retiro_miercoles_quincena, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_jueves_quincena", m.Retiro_jueves_quincena, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_viernes_quincena", m.Retiro_viernes_quincena, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_sabado_quincena", m.Retiro_sabado_quincena, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@retiro_domingo_quincena", m.Retiro_domingo, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@montos", m, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorMontosRetirosATMActualizacion");
            }

        }


        /// <summary>
        /// Obtener una lista de todos los ATM's con sus respectivos montos esperados de retiros para una moneda específica.
        /// </summary>
        /// <param name="m">Moneda para la cual se genera la lista</param>
        /// <returns>Lista de los ATM's y sus respectivos montos</returns>
        public BindingList<MontosRetirosATM> listarMontosRetirosATMs(Monedas m)
        {
            BindingList<MontosRetirosATM> montos_atms = new BindingList<MontosRetirosATM>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectMontosRetirosATMs");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@moneda", m, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id_montos = (short)datareader["ID_Montos"];

                    short id_atm = (short)datareader["ID_ATM"];
                    short numero = (short)datareader["Numero"];
                    string codigo = (string)datareader["Codigo"];

                    decimal retiro_lunes = (decimal)datareader["Retiro_Lunes"];
                    decimal retiro_martes = (decimal)datareader["Retiro_Martes"];
                    decimal retiro_miercoles = (decimal)datareader["Retiro_Miercoles"];
                    decimal retiro_jueves = (decimal)datareader["Retiro_Jueves"];
                    decimal retiro_viernes = (decimal)datareader["Retiro_Viernes"];
                    decimal retiro_sabado = (decimal)datareader["Retiro_Sabado"];
                    decimal retiro_domingo = (decimal)datareader["Retiro_Domingo"];
                    decimal retiro_lunes_quincena = (decimal)datareader["Retiro_Lunes_Quincena"];
                    decimal retiro_martes_quincena = (decimal)datareader["Retiro_Martes_Quincena"];
                    decimal retiro_miercoles_quincena = (decimal)datareader["Retiro_Miercoles_Quincena"];
                    decimal retiro_jueves_quincena = (decimal)datareader["Retiro_Jueves_Quincena"];
                    decimal retiro_viernes_quincena = (decimal)datareader["Retiro_Viernes_Quincena"];
                    decimal retiro_sabado_quincena = (decimal)datareader["Retiro_Sabado_Quincena"];
                    decimal retiro_domingo_quincena = (decimal)datareader["Retiro_Domingo_Quincena"];

                    ATM atm = new ATM(id: id_atm, numero: numero, codigo: codigo);

                    MontosRetirosATM montos = new MontosRetirosATM(atm, m, id: id_montos, retiro_lunes: retiro_lunes, retiro_martes: retiro_martes,
                                                                   retiro_miercoles: retiro_miercoles, retiro_jueves: retiro_jueves,
                                                                   retiro_viernes: retiro_viernes, retiro_sabado: retiro_sabado,
                                                                   retiro_domingo: retiro_domingo, retiro_lunes_quincena: retiro_lunes_quincena,
                                                                   retiro_martes_quincena: retiro_martes_quincena,
                                                                   retiro_miercoles_quincena: retiro_miercoles_quincena,
                                                                   retiro_jueves_quincena: retiro_jueves_quincena,
                                                                   retiro_viernes_quincena: retiro_viernes_quincena,
                                                                   retiro_sabado_quincena: retiro_sabado_quincena,
                                                                   retiro_domingo_quincena: retiro_domingo_quincena);

                    montos_atms.Add(montos);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return montos_atms;
        }

        /// <summary>
        /// Verificar si un ATM ya tiene asignado los montos esperados de retiros.
        /// </summary>
        /// <param name="a">Objeto MontosRetirosATM con los datos del ATM a verificar</param>
        /// <returns>Valor que indica si los montos esperados ya fueron asignados</returns>
        public bool verificarMontosRetirosATM(ref MontosRetirosATM m)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExistenMontosRetirosATM");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@atm", m.ATM, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@moneda", m.Moneda, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];

                    existe = id != m.ID;

                    m.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarMontosRetirosATM");
            }

            return existe;
        }
        
        #endregion Métodos Públicos
        
    }

}
