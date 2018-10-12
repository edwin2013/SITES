//
//  @ Project : 
//  @ File Name : GestionDL.cs
//  @ Date : 18/08/2011
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
    /// Clase de la capa de datos que maneja las gestiones.
    /// </summary>
    public class GestionesDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static GestionesDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static GestionesDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new GestionesDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public GestionesDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar una nueva gestión.
        /// </summary>
        /// <param name="g">Objeto Gestion con los datos de la nueva gestión</param>
        public void agregarGestion(ref Gestion g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertGestion");

            _manejador.agregarParametro(comando, "@tipo", g.Tipo.Id, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@punto_venta", g.Punto_venta.Id, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto", g.Monto, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@fecha", g.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@comentario", g.Comentario, SqlDbType.VarChar);

            try
            {
                g.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorGestionRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de una gestión.
        /// </summary>
        /// <param name="g">Objeto Gestion con los datos de la gestión a actualizar</param>
        public void actualizarGestion(Gestion g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateGestion");

            _manejador.agregarParametro(comando, "@tipo", g.Tipo.Id, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@punto_venta", g.Punto_venta.Id, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto", g.Monto, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@comentario", g.Comentario, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@gestion", g, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorGestionActualizacion");
            }

        }

        /// <summary>
        /// Actualizar los datos de una gestión y terminarla.
        /// </summary>
        /// <param name="g">Objeto Gestion con los datos del tipo de gestión a actualizar</param>
        public void actualizarGestionTerminar(Gestion g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateGestionTerminar");

            _manejador.agregarParametro(comando, "@causa", g.Causa.Id, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@comentario_causa", g.Causa.Id, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@clasificacion", g.Clasificacion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@gestion", g, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorGestionActualizacion");
            }

        }

         /// <summary>
        /// Eliminar los datos de una gestión.
        /// </summary>
        /// <param name="t">Objeto Gestion con los datos de la gestión a eliminar</param>
        public void eliminarGestion(Gestion g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteGestion");

            _manejador.agregarParametro(comando, "@gestion", g, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErroroGestionEliminacion");
            }

        }

        /// <summary>
        /// Listar todas las gestiones registradas en el sistema.
        /// </summary>
        /// <returns>Lista de las gestiones registradas en el sistema</returns>
        public BindingList<Gestion> listarGestiones()
        {
            BindingList<Gestion> gestiones = new BindingList<Gestion>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectGestiones");
            SqlDataReader datareader = null;
            
            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_gestion = (int)datareader["ID_Gestion"];
                    DateTime fecha = (DateTime)datareader["Fecha"];
                    string comentario = (string)datareader["Comentario"];
                    decimal monto = (decimal)datareader["Monto"];

                    short id_cliente = (short)datareader["ID_Cliente"];
                    string nombre_cliente = (string)datareader["Nombre_Cliente"];

                    short id_punto_venta = (short)datareader["ID_Punto_Venta"];
                    string nombre_punto_venta = (string)datareader["Nombre_Punto_Venta"];

                    byte id_tipo = (byte)datareader["ID_Tipo"];
                    string nombre_tipo = (string)datareader["Nombre_Tipo"];
                    short tiempo_esperado = (short)datareader["Tiempo"];

                    Cliente cliente = new Cliente(id_cliente, nombre_cliente);
                    PuntoVenta punto_venta = new PuntoVenta(id_punto_venta, nombre_punto_venta, cliente);
                    TipoGestion tipo = new TipoGestion(id_tipo, nombre_tipo, tiempo_esperado);

                    Gestion gestion = new Gestion(id: id_gestion, punto_venta: punto_venta, monto: monto, tipo: tipo,
                                                  fecha: fecha, comentario: comentario);

                    gestiones.Add(gestion);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return gestiones;
        }

        /// <summary>
        /// Listar todas las gestiones terminadas registradas en el sistema en un periodo de tiempo.
        /// </summary>
        /// <param name="i">Fecha inicial del periodo de tiempo</param>
        /// <param name="i">Fecha final del periodo de tiempo</param>
        /// <returns>Lista de las gestiones registradas en el sistema</returns>
        public BindingList<Gestion> listarGestionesTerminadas(DateTime i, DateTime f)
        {
            BindingList<Gestion> gestiones = new BindingList<Gestion>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectGestionesTerminadas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha_inicio", i, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha_fin", f, SqlDbType.DateTime);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_gestion = (int)datareader["ID_Gestion"];
                    DateTime fecha = (DateTime)datareader["Fecha"];
                    DateTime fecha_finalizacion = (DateTime)datareader["Fecha_Finalizacion"];
                    string comentario = (string)datareader["Comentario"];
                    decimal monto = (decimal)datareader["Monto"];
                    ClasificacionesGestion clasificacion = (ClasificacionesGestion)datareader["Clasificacion"];

                    short id_cliente = (short)datareader["ID_Cliente"];
                    string nombre_cliente = (string)datareader["Nombre_Cliente"];

                    short id_punto_venta = (short)datareader["ID_Punto_Venta"];
                    string nombre_punto_venta = (string)datareader["Nombre_Punto_Venta"];

                    byte id_tipo = (byte)datareader["ID_Tipo"];
                    string nombre_tipo = (string)datareader["Nombre_Tipo"];
                    short tiempo_esperado = (short)datareader["Tiempo"];

                    byte id_causa = (byte)datareader["ID_Causa"];
                    string descripcion = (string)datareader["Descripcion"];
                    Causantes causante = (Causantes)datareader["Causante"];
                    string comentario_causa = (string)datareader["Comentario_Causa"];

                    Cliente cliente = new Cliente(id_cliente, nombre_cliente);
                    PuntoVenta punto_venta = new PuntoVenta(id_punto_venta, nombre_punto_venta, cliente);
                    TipoGestion tipo = new TipoGestion(id_tipo, nombre_tipo, tiempo_esperado);
                    CausaGestion causa = new CausaGestion(id_causa, descripcion, causante);

                    Gestion gestion = new Gestion(id: id_gestion, punto_venta: punto_venta, monto: monto, tipo: tipo,
                                                  causa: causa, comentario_causa: comentario_causa, fecha: fecha,
                                                  fecha_finalizacion: fecha_finalizacion, clasificacion: clasificacion,
                                                  comentario: comentario);

                    gestiones.Add(gestion);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return gestiones;
        }

        /// <summary>
        /// Listar las gestiones que están a punto de vencer.
        /// </summary>
        /// <returns>Lista de los tipos de gestión registrados en el sistema</returns>
        public BindingList<Gestion> listarGestionesPendientes()
        {
            BindingList<Gestion> gestiones = new BindingList<Gestion>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectGestionesPendientes");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_gestion = (int)datareader["ID_Gestion"];
                    DateTime fecha = (DateTime)datareader["Fecha"];
                    string comentario = (string)datareader["Comentario"];
                    decimal monto = (decimal)datareader["Monto"];

                    short id_cliente = (short)datareader["ID_Cliente"];
                    string nombre_cliente = (string)datareader["Nombre_Cliente"];

                    short id_punto_venta = (short)datareader["ID_Punto_Venta"];
                    string nombre_punto_venta = (string)datareader["Nombre_Punto_Venta"];

                    byte id_tipo = (byte)datareader["ID_Tipo"];
                    string nombre_tipo = (string)datareader["Nombre_Tipo"];
                    short tiempo_esperado = (short)datareader["Tiempo"];

                    Cliente cliente = new Cliente(id_cliente, nombre_cliente);
                    PuntoVenta punto_venta = new PuntoVenta(id_punto_venta, nombre_punto_venta, cliente);
                    TipoGestion tipo = new TipoGestion(id_tipo, nombre_tipo, tiempo_esperado);

                    Gestion gestion = new Gestion(id: id_gestion, punto_venta: punto_venta, monto: monto, tipo: tipo,
                                                  fecha: fecha, comentario: comentario);

                    gestiones.Add(gestion);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return gestiones;
        }

        /// <summary>
        /// Asignar a una transportadora como la causante de una gestión.
        /// </summary>
        /// <param name="g">Objeto Gestion con los datos de la gestión y de la transportadora</param>
        public void agregarTransportadoraGestion(Gestion g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateGestionTransportadora");

            _manejador.agregarParametro(comando, "@transportadora", g.Transportadora, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@gestion", g, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorGestionActualizacion");
            }

        }

        /// <summary>
        /// Obtener los datos de la transportadora causante de una gestión.
        /// </summary>
        /// <param name="g">Objeto Gestion con los datos de la gestión</param>
        public void obtenerTransportadoraGestion(ref Gestion g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectGestionTransportadora");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@gestion", g, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];

                    EmpresaTransporte empresa = new EmpresaTransporte(nombre, id: id);

                    g.Transportadora = empresa;
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
        /// Asignar a un colaborador como el causante de una gestión.
        /// </summary>
        /// <param name="g">Objeto Gestion con los datos de la gestión y del colaborador</param>
        public void agregarColaboradorGestion(Gestion g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateGestionColaborador");

            _manejador.agregarParametro(comando, "@colaborador", g.Colaborador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@gestion", g, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorGestionActualizacion");
            }

        }

        /// <summary>
        /// Obtener los datos del colaborador causante de una gestión.
        /// </summary>
        /// <param name="g">Objeto Gestion con los datos de la gestiónr</param>
        public void obtenerColaboradorGestion(ref Gestion g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectGestionColaborador");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@gestion", g, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {

                    int id = (int)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];

                    Colaborador colaborador = new Colaborador(id, nombre, primer_apellido, segundo_apellido);

                    g.Colaborador = colaborador;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        #region Deposito

        /// <summary>
        /// Asignar un deposito a una gestión.
        /// </summary>
        /// <param name="d">Deposito que se ligará a la gestión</param>
        /// <param name="g">Objeto Gestion con los datos de la gestión</param>
        public void agregarDepositoGestion(ref Deposito d, Gestion g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertGestionDeposito");

            _manejador.agregarParametro(comando, "@referencia", d.Referencia, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@gestion", g, SqlDbType.Int);

            try
            {
                d.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDepositoGestionActualizacion");
            }

        }

        /// <summary>
        /// Eliminar un deposito ligado a una gestión.
        /// </summary>
        /// <param name="d">Deposito a eliminar</param>
        public void eliminarDepositoGestion(Deposito d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteGestionDeposito");

            _manejador.agregarParametro(comando, "@deposito", d, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDepositoGestionActualizacion");
            }

        }

        /// <summary>
        /// Obtener los depositos ligados a una gestión.
        /// </summary>
        /// <param name="g">Objeto Gestion con los datos de la gestión para la cual se obtienen los depositos</param>
        public void obtenerDepositosGestion(ref Gestion g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectGestionDepositos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@gestion", g, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    int referencia = (int)datareader["Referencia"];

                    Deposito deposito = new Deposito(id, referencia);

                    g.agregarDeposito(deposito);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        #endregion Deposito

        #region Tula

        /// <summary>
        /// Asignar una tula a una gestión.
        /// </summary>
        /// <param name="t">Tula que se ligará a la gestión</param>
        /// <param name="g">Objeto Gestion con los datos de la gestión</param>
        public void agregarTulaGestion(ref Tula t, Gestion g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertGestionTula");

            _manejador.agregarParametro(comando, "@codigo", t.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@gestion", g, SqlDbType.Int);

            try
            {
                t.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaGestionActualizacion");
            }

        }

        /// <summary>
        /// Eliminar una tula ligada a una gestión.
        /// </summary>
        /// <param name="t">Tula a eliminar</param>
        public void eliminarTulaGestion(Tula t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteGestionTula");

            _manejador.agregarParametro(comando, "@tula", t, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaGestionActualizacion");
            }

        }

        /// <summary>
        /// Obtener las tulas ligadas a una gestión.
        /// </summary>
        /// <param name="g">Objeto Gestion con los datos de la gestión para la cual se obtienen las tulas</param>
        public void obtenerTulasGestion(ref Gestion g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectGestionTulas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@gestion", g, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string codigo = (string)datareader["Codigo"];

                    Tula tula = new Tula(codigo, id: id);

                    g.agregarTula(tula);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        #endregion Tula

        #region Manifiesto

        /// <summary>
        /// Asignar un manifiesto a una gestión.
        /// </summary>
        /// <param name="m">Manifiesto que se ligará a la gestión</param>
        /// <param name="g">Objeto Gestion con los datos de la gestión</param>
        public void agregarManifiestoGestion(ref ManifiestoCEF m, Gestion g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertGestionManifiesto");

            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@gestion", g, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoGestionActualizacion");
            }

        }

        /// <summary>
        /// Eliminar un manifiesto ligado a una gestión.
        /// </summary>
        /// <param name="m">Manifiesto a eliminar</param>
        public void eliminarManifiestoGestion(Manifiesto m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteGestionManifiesto");

            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoGestionActualizacion");
            }

        }

        /// <summary>
        /// Obtener los manifiestos ligadas a una gestión.
        /// </summary>
        /// <param name="g">Objeto Gestion con los datos de la gestión para la cual se obtienen los manifiestos</param>
        public void obtenerManifiestosGestion(ref Gestion g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectGestionManifiestos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@gestion", g, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string codigo = (string)datareader["Codigo"];

                    ManifiestoCEF manifiesto = new ManifiestoCEF(id, codigo: codigo);

                    g.agregarManifiesto(manifiesto);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        #endregion Manifiesto

        #endregion Métodos Públicos

    }

}
