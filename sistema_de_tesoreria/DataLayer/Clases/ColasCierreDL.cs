//
//  @ Project : 
//  @ File Name : ColasCierreDL.cs
//  @ Date : 26/09/2011
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

    public class ColasCierreDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ColasCierreDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ColasCierreDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ColasCierreDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ColasCierreDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Obtener los saldos de los cierres en una fecha específica.
        /// </summary>
        /// <param name="f">Fecha para la cual se obtendrán los saldos</param>
        /// <returns>Lista de saldos(colas)</returns>
        public BindingList<ColaCierre> listarSaldosCierre(DateTime f)
        {
            BindingList<ColaCierre> colas = new BindingList<ColaCierre>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreSaldos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    decimal saldo_colones = (decimal)datareader["Saldo_Colones"];
                    decimal saldo_dolares = (decimal)datareader["Saldo_Dolares"];

                    int id = (int)datareader["ID_Cajero"];
                    string nombre = (string)datareader["Nombre"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];

                    Colaborador cajero = new Colaborador(id, nombre, primer_apellido, segundo_apellido);
                    ColaCierre cola = new ColaCierre(cajero, saldo_colones, saldo_dolares);

                    colas.Add(cola);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return colas;
        }
        
        #endregion Métodos Públicos

    }

}
