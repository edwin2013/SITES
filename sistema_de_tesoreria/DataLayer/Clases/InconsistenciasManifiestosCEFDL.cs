//
//  @ Project : 
//  @ File Name : InconsistenciasManifiestosCEFDL.cs
//  @ Date : 18/10/2011
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

    public class InconsistenciasManifiestosCEFDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static InconsistenciasManifiestosCEFDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static InconsistenciasManifiestosCEFDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new InconsistenciasManifiestosCEFDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public InconsistenciasManifiestosCEFDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar una inconsistencia en un manifiesto del CEF.
        /// </summary>
        /// <param name="i">Objeto InconsistenciaManifiestoCEF con los datos de la inconsistencia</param>
        public void agregarInconsistencia(ref InconsistenciaManifiestoCEF i)
        {

            SqlCommand comando = _manejador.obtenerProcedimiento("InsertInconsistenciaManifiestoCEF");

            _manejador.agregarParametro(comando, "@camara", i.Camara, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@manifiesto", i.Manifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto_colones_reportado", i.Monto_colones_reportado, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_dolares_reportado", i.Monto_dolares_reportado, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_euros_reportado", i.Monto_euros_reportado, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_total_reportado", i.Monto_total_reportado, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_total_real", i.Monto_total_real, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@fecha", i.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@comentario", i.Comentario, SqlDbType.VarChar);

            try
            {
                i.Id = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorInconsistenciaManifiestoCEFRegistro");
            }

        }

        /// <summary>
        /// Verificar si existe una inconsistencia para un manifiesto del CEF.
        /// </summary>
        /// <param name="i">Objeto InconsistenciaManifiestoCEF con los datos de la inconsistencia</param>
        /// <returns>Valor que indica si la inconsistencia existe</returns>
        public bool verificarInconsistencia(InconsistenciaManifiestoCEF i)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteInconsistenociaManifiestoCEF");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@manifiesto", i.Manifiesto, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id_encontrado = (int)datareader["pk_ID"];

                    existe = id_encontrado != i.Id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarInconsistenciaManifiestoCEFDuplicado");
            }

            return existe;
        }

        /// <summary>
        /// Actualizar los datos de una inconsistencia en un manifiesto del CEF.
        /// </summary>
        /// <param name="i">Objeto UpdateInconsistenciaManifiestoCEF con los datos de la inconsistencia</param>
        public void actualizarInconsistencia(InconsistenciaManifiestoCEF i)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateInconsistenciaManifiestoCEF");

            _manejador.agregarParametro(comando, "@camara", i.Camara, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@manifiesto", i.Manifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto_colones_reportado", i.Monto_colones_reportado, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto_dolares_reportado", i.Monto_dolares_reportado, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto_euros_reportado", i.Monto_euros_reportado, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto_total_reportado", i.Monto_total_reportado, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_total_real", i.Monto_total_real, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@fecha", i.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@comentario", i.Comentario, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@inconsistencia", i.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorInconsistenciaManifiestoCEFActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de una inconsistencia en un manifiesto del CEF.
        /// </summary>
        /// <param name="i">Objeto InconsistenciaManifiestoCEF con los datos de la inconsistencia</param>
        public void eliminarInconsistencia(InconsistenciaManifiestoCEF i)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteInconsistenciaManifiestoCEF");

            _manejador.agregarParametro(comando, "@inconsistencia", i.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorInconsistenciaManifiestoCEFEliminacion");
            }

        }

        /// <summary>
        /// Listar las inconsistencias de manifiestos del CEF.
        /// </summary>
        /// <param name="i">Fecha inicial del periodo de tiempo</param>
        /// <param name="f">Fecha final del periodo de tiempo</param>
        /// <returns>Lista de las inconsistencias registradas en el periodo de tiempo indicado</returns>
        public BindingList<InconsistenciaManifiestoCEF> listarInconsistencias(DateTime i, DateTime f)
        {
            BindingList<InconsistenciaManifiestoCEF> inconsistencias = new BindingList<InconsistenciaManifiestoCEF>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectInconsistenciasManifiestosCEF");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha_inicio", i, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha_fin", f, SqlDbType.DateTime);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_inconsistenca = (int)datareader["ID_Incosistencia"];
                    DateTime fecha = (DateTime)datareader["Fecha"];
                    decimal monto_colones_reportado = (decimal)datareader["Monto_Colones_Reportado"];
                    decimal monto_dolares_reportado = (decimal)datareader["Monto_Dolares_Reportado"];
                    decimal monto_euros_reportado = 0;
                    if(datareader["Monto_Euros_Reportado"]!= DBNull.Value)
                     monto_euros_reportado = (decimal)datareader["Monto_Euros_Reportado"];
                    decimal monto_total_reportado = (decimal)datareader["Monto_Total_Reportado"];
                    decimal monto_total_real = (decimal)datareader["Monto_Total_Real"];
                    string comentario = (string)datareader["Comentario"];

                    int id_manifiesto = (int)datareader["ID_Manifiesto"];
                    string codigo = (string)datareader["Codigo"];
                    decimal monto_colones = (decimal)datareader["Monto_Colones"];
                    decimal monto_dolares = (decimal)datareader["Monto_Dolares"];
                    short depositos = (short)datareader["Depositos"];
                    byte id_camara = (byte)datareader["ID_Camara"];
                    string identificador = (string)datareader["Identificador"];

                    ManifiestoCEF manifiesto = new ManifiestoCEF(id_manifiesto, codigo: codigo, monto_colones: monto_colones,
                                                                 monto_dolares: monto_dolares, depositos: depositos);
                    Camara camara = new Camara(identificador, id: id_camara);

                    InconsistenciaManifiestoCEF inconsistencia = 
                        new InconsistenciaManifiestoCEF(id_inconsistenca, manifiesto, camara, fecha, monto_colones_reportado,  
                                                        monto_dolares_reportado, monto_total_reportado, monto_total_real,
                                                        comentario, monto_euros_reportado);

                    inconsistencias.Add(inconsistencia);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return inconsistencias;
        }

        #endregion Métodos Públicos

    }

}
