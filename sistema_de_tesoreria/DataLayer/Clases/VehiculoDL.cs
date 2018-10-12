using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.Data.SqlClient;
using System.Data;
using LibreriaMensajes;
using System.ComponentModel;
using CommonObjects;
using CommonObjects.Clases;

namespace DataLayer
{
    public class VehiculoDL
    {

         #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static VehiculoDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static VehiculoDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new VehiculoDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public VehiculoDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un Vehiculo.
        /// </summary>
        /// <param name="v">Objeto Vehiculo con los datos del Vehiculo</param>
        public void agregarVehiculo(ref Vehiculo v)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertVehiculo");

            _manejador.agregarParametro(comando, "@placa", v.Placa, SqlDbType.NChar);
            _manejador.agregarParametro(comando, "@modelo", v.Modelo, SqlDbType.NChar);
            _manejador.agregarParametro(comando, "@numeroasociado", v.NumeroAsociado, SqlDbType.Int);

            try
            {
                v.ID = (short)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVehiculoRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un Vehiculo en el sistema.
        /// </summary>
        /// <param name="v">Objeto Vehiculo con los datos del Vehiculo</param>
        public void actualizarVehiculo(ref Vehiculo v)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateVehiculo");

            _manejador.agregarParametro(comando, "@placa", v.Placa, SqlDbType.NChar);
            _manejador.agregarParametro(comando, "@modelo", v.Modelo, SqlDbType.NChar);
            _manejador.agregarParametro(comando, "@numeroasociado", v.NumeroAsociado, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@vehiculo", v, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVehiculoActualizacion");
            }

        }
        
        /// <summary>
        /// Eliminar los datos de un Vehiculo.
        /// </summary>
        /// <param name="v">Objeto Vehiculo con los datos del Vehiculo a eliminar</param>
        public void eliminarVehiculo(Vehiculo v)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteVehiculo");

            _manejador.agregarParametro(comando, "@vehiculo", v, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVehiculoEliminacion");
            }

        }

        /// <summary>
        /// Listar los Vehiculos registrados en el sistema.
        /// </summary>
        /// <returns>Lista de los Vehiculos registrados en el sistema</returns>
        public BindingList<Vehiculo> listarVehiculos(string b)
        {
            BindingList<Vehiculo> vehiculos = new BindingList<Vehiculo>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectVehiculos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@nombre", b, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id_atm = (short)datareader["ID_Vehiculo"];
                    string modelo = (string)datareader["Modelo"];
                    string placa = (string)datareader["Placa"];
                    int numeroasoc = (Int32)datareader["NumeroAsociado"];
                  
                    Vehiculo vehiculo = new Vehiculo(placa:placa, modelo:modelo, numeroasociado:numeroasoc,id:id_atm);

                    vehiculos.Add(vehiculo);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return vehiculos;
        }

      

        /// <summary>
        /// Verificar si existe un Vehiculo.
        /// </summary>
        /// <param name="v">Objeto Vehiculo con los datos del Vehiculo a verificar</param>
        /// <returns>Valor que indica si el Vehiculo existe</returns>
        public bool verificarVehiculo(ref Vehiculo v)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteVehiculo");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@placa", v.Placa, SqlDbType.NChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];

                    existe = id != v.ID;

                    v.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarVehiculoDuplicado");
            }

            return existe;
        }

        /// <summary>
        /// Obtener los datos de un Vehiculo.
        /// </summary>
        /// <param name="v">Vehiculo para el cual se obtienen los datos</param>
        /// <returns>Valor que indica si el Vehiculo existe</returns>
        public bool obtenerDatosVehiculoM(ref Vehiculo v)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectVehiculoDatos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@numero", v.Placa, SqlDbType.SmallInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id_atm = (short)datareader["ID_Vehiculo"];
                    string modelo = (string)datareader["Modelo"];
                    string placa = (string)datareader["Placa"];
                    int numeroasoc = (Int32)datareader["NumeroAsociado"];
                    existe = true;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return existe;
        }


        #region Revision de Vehiculo

        /// <summary>
        /// Lista el reporte de revisiones de vehiculo
        /// </summary>
        /// <returns>Lista de los Revisiones de Vehiculos registrados en el sistema</returns>
        public BindingList<RevisionVehiculo> listarRevisionVehiculos(DateTime fi, DateTime ff, Vehiculo v, Colaborador ch, int r)
        {
            BindingList<RevisionVehiculo> revisionvehiculos = new BindingList<RevisionVehiculo>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectReporteRevisionVehiculos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha_inicio", fi, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha_fin", ff, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@chofer",ch , SqlDbType.Int);

            if(r == 0)
                _manejador.agregarParametro(comando, "@ruta", null, SqlDbType.TinyInt);
            else
                _manejador.agregarParametro(comando, "@ruta", r, SqlDbType.TinyInt);

            _manejador.agregarParametro(comando, "@vehiculo", v, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {

                    DateTime fecha = (DateTime)datareader["Fecha"];
                    int rutita = (int)datareader["Ruta"];
                    short id_tripulacion = (short)datareader["ID_Tripulacion"];

                    short id_atm = (short)datareader["ID_Vehiculo"];
                    string modelo = (string)datareader["Modelo_Vehiculo"];
                    string placa = (string)datareader["Placa"];
                    int numeroasoc = (Int32)datareader["Numero_Vehiculo"];

                    Vehiculo vehiculo = new Vehiculo(placa: placa, modelo: modelo, numeroasociado: numeroasoc, id: id_atm);



                    int id_colaborador = (int)datareader["ID_Chofer"];
                    string chofer_nombre = (string)datareader["Chofer_Nombre"];
                    string chofer_primerapellido = (string)datareader["Chofer_Primer_Apellido"];
                    string chofer_segundoapellido = (string)datareader["Chofer_Segundo_Apellido"];

                    Colaborador chof = new Colaborador(id: id_colaborador, nombre: chofer_nombre, primer_apellido: chofer_primerapellido, segundo_apellido: chofer_segundoapellido);

                    string imagen = (string)datareader["NombreImagen"];

                    RevisionVehiculo revision = new RevisionVehiculo(fecha:fecha,ruta:rutita,v:vehiculo,chofer:chof,idtrip:id_tripulacion,imagen:imagen);

                    revisionvehiculos.Add(revision);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return revisionvehiculos;
        }

        #endregion Revision de Vehiculo
       
        #endregion Métodos Públicos
    }
}
