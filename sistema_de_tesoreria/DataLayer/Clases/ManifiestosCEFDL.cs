//
//  @ Project : 
//  @ File Name : ManifiestosCEFDL.cs
//  @ Date : 03/04/2011
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
    /// Clase de la capa de datos que maneja los manifiestos de CEF.
    /// </summary>
    public class ManifiestosCEFDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ManifiestosCEFDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ManifiestosCEFDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ManifiestosCEFDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ManifiestosCEFDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Actualizar los datos de un manifiesto del CEF.
        /// </summary>
        /// <param name="m">Objeto ManifiestoCEF con los datos del manifiesto a actualizar</param>
        /// <param name="c">Coordinador que realiza la actualización</param>
        public void actualizarManifiestoCEF(ManifiestoCEF m, Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManifiestoCEF");
             
            _manejador.agregarParametro(comando, "@cajero", m.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", m.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", m.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador_encargado",c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto_colones", m.Monto_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_dolares", m.Monto_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_euros", m.Monto_Euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@depositos", m.Depositos, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@punto_venta", m.Punto_venta.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", m.Fecha_procesamiento, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);
            
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoActualizacion");
            }

        }

        /// <summary>
        /// Actualizar los datos de los colaboradores y la sucursal de un manifiesto del CEF.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto a actualizar</param>
        public void actualizarManifiestoCEFDatos(ManifiestoCEF m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManifiestoCEFDatos");

            _manejador.agregarParametro(comando, "@cajero", m.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", m.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", m.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@punto_venta", m.Punto_venta.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@fecha", m.Fecha_procesamiento, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoActualizacion");
            }

        }

         /// <summary>
        /// Obtener una lista de los manifiestos del CEF que tienen un determinado código o parte del mismo.
        /// </summary>
        /// <param name="c">Código o parte del mismo de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoCEF> listarManifiestosCEFPorCodigo(string c)
        {
            BindingList<ManifiestoCEF> manifiestos = new BindingList<ManifiestoCEF>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestosCEFCodigo");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", c, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_manifiesto = (int)datareader["ID_Manifiesto"];
                    string codigo = (string)datareader["Codigo"];
                    byte caja = (byte)datareader["Caja"];
                    DateTime fecha_recepcion = (DateTime)datareader["Fecha_Recepcion"];
                    DateTime fecha_recoleccion = (DateTime)datareader["Fecha_Recepcion"];
                    bool retraso = (bool)datareader["Retraso_Transportadora"];

                    int id_receptor = (int)datareader["ID_Receptor"];
                    string nombre_receptor = (string)datareader["Nombre"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];

                    byte id_empresa = (byte)datareader["ID_Empresa"];
                    string nombre_empresa = (string)datareader["Nombre_Empresa"];

                    byte id_grupo = (byte)datareader["ID_Grupo"];
                    string nombre_grupo = (string)datareader["Nombre_Grupo"];

                    Colaborador receptor = new Colaborador(id_receptor, nombre_receptor, primer_apellido, segundo_apellido);
                    EmpresaTransporte empresa = new EmpresaTransporte(nombre_empresa, id: id_empresa);
                    Grupo grupo = new Grupo(id_grupo, nombre_grupo);

                    ManifiestoCEF manifiesto = new ManifiestoCEF(codigo, id: id_manifiesto, grupo: grupo, caja: caja, empresa: empresa,
                                                                 receptor: receptor, fecha_recepcion: fecha_recepcion,
                                                                 fecha_recoleccion: fecha_recoleccion, retraso: retraso);

                    manifiestos.Add(manifiesto);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return manifiestos;
        }

        /// <summary>
        /// Obtener una lista de los manifiestos del CEF que tienen un determinado código o parte del mismo recibidos en la última semana.
        /// </summary>
        /// <param name="c">Código o parte del mismo de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoCEF> listarManifiestosCEFRecientes(string c)
        {
            BindingList<ManifiestoCEF> manifiestos = new BindingList<ManifiestoCEF>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestosCEFCodigoRecientes2");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", c, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {

                    int id = (int)datareader["ID_Manifiestos"];
                    string codigo = (string)datareader["Codigo"];
                    DateTime fecha_recepcion = (DateTime)datareader["Fecha_Recepcion"];

                    byte id_transportadora = (byte)datareader["ID_Transportadora"];
                    string nombre_transportadora = (string)datareader["Nombre"];

                    Colaborador cajero_receptor = null;

                    if (datareader["ID_Cajero"] != DBNull.Value)
                    {
                        int id_cajero = (int)datareader["ID_Cajero"];
                        string nombre_cajero = (string)datareader["Nombre_Cajero"];
                        string primer_apellido = (string)datareader["Primer_Apellido"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido"];

                        cajero_receptor = new Colaborador(id: id_cajero, nombre: nombre_cajero, primer_apellido: primer_apellido,
                                                            segundo_apellido: segundo_apellido);
                    }
                    EmpresaTransporte transportadora = new EmpresaTransporte(nombre_transportadora, id: id_transportadora);


                    ManifiestoCEF manifiesto = new ManifiestoCEF(codigo, id: id, empresa: transportadora,
                                                                fecha_recepcion: fecha_recepcion, cajero_receptor: cajero_receptor);
                    manifiesto.Cajero_Receptor = cajero_receptor;

                    manifiestos.Add(manifiesto);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return manifiestos;

        }

        /// <summary>
        /// Obtener el coordinador, cajero, el digitador, la sucursal y la fecha de procesamiento de un manifiesto del CEF.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto para el cual se obtienen los datos</param>
        public void obtenerDatosManifiestoCEF(ref ManifiestoCEF m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestoCEFDatos2");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    DateTime fecha_procesamiento = (DateTime)datareader["Fecha_Procesamiento"];
                    decimal monto_colones = (decimal)datareader["Monto_Colones"];
                    decimal monto_dolares = (decimal)datareader["Monto_Dolares"];
                    decimal monto_euros = 0;

                    if (datareader["Monto_Euros"] != DBNull.Value)
                    {
                        monto_euros = (decimal)datareader["Monto_Euros"];
                    }

                    short depositos = (short)datareader["Depositos"];

                    int id_cajero = (int)datareader["ID_Cajero"];
                    string nombre_cajero = (string)datareader["Nombre_Cajero"];
                    string primer_apellido_cajero = (string)datareader["Primer_Apellido_Cajero"];
                    string segundo_apellido_cajero = (string)datareader["Segundo_Apellido_Cajero"];

                    int id_digitador = (int)datareader["ID_Digitador"];
                    string nombre_digitador = (string)datareader["Nombre_Digitador"];
                    string primer_apellido_digitador = (string)datareader["Primer_Apellido_Digitador"];
                    string segundo_apellido_digitador = (string)datareader["Segundo_Apellido_Digitador"];

                    int id_coordinador = (int)datareader["ID_Coordinador"];
                    string nombre_coordinador = (string)datareader["Nombre_Coordinador"];
                    string primer_apellido_coordinador = (string)datareader["Primer_Apellido_Coordinador"];
                    string segundo_apellido_coordinador = (string)datareader["Segundo_Apellido_Coordinador"];

                    Colaborador cajero_receptor = null;

                    if (datareader["ID_Cajero_Receptor"] != DBNull.Value)
                    {
                        int id_cajero_receptor = (int)datareader["ID_Cajero_Receptor"];
                        string nombre_cajero_receptor = (string)datareader["Nombre_Cajero_Receptor"];
                        string primer_apellido_receptor = (string)datareader["Primer_Apellido_Cajero_Receptor"];
                        string segundo_apellido_receptor = (string)datareader["Segundo_Apellido_Cajero_Receptor"];

                        cajero_receptor = new Colaborador(id: id_cajero_receptor, nombre: nombre_cajero_receptor, primer_apellido: primer_apellido_receptor,
                                                            segundo_apellido: segundo_apellido_receptor);
                    }


                    short id_punto_venta = (short)datareader["ID_Punto_Venta"];
                    string nombre_punto_venta = (string)datareader["Nombre_Punto_Venta"];

                    short id_cliente = (short)datareader["ID_Cliente"];
                    string nombre_cliente = (string)datareader["Nombre_Cliente"];



                    Cliente cliente = new Cliente(id_cliente, nombre_cliente);
                    PuntoVenta punto_venta = new PuntoVenta(id_punto_venta, nombre_punto_venta, cliente);

                    Colaborador cajero = new Colaborador(id_cajero, nombre_cajero, primer_apellido_cajero, segundo_apellido_cajero);
                    Colaborador digitador = new Colaborador(id_digitador, nombre_digitador, primer_apellido_digitador, segundo_apellido_digitador);
                    Colaborador coordinador = new Colaborador(id_coordinador, nombre_coordinador, primer_apellido_coordinador, segundo_apellido_coordinador);

                    m.Monto_colones = monto_colones;
                    m.Monto_dolares = monto_dolares;
                    m.Monto_Euros = monto_euros;
                    m.Depositos = depositos;
                    m.Punto_venta = punto_venta;
                    m.Cajero = cajero;
                    m.Cajero_Receptor = cajero_receptor;
                    m.Digitador = digitador;
                    m.Coordinador = coordinador;
                    m.Fecha_procesamiento = fecha_procesamiento;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }
        }


        #region ManifiestosColaboradores

        /// <summary>
        /// Listar todos los colaboradores registrados.
        /// </summary>
        /// <returns>Lista de colaboradores registrados en el sistema en el Area de CEF</returns>
        public BindingList<Colaborador> listarCajerosAsignados()
        {
            BindingList<Colaborador> colaboradores = new BindingList<Colaborador>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestoCajero");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];

                    Colaborador colaborador = new Colaborador(id: id, nombre: nombre, primer_apellido: primer_apellido,
                                                              segundo_apellido: segundo_apellido);
                    colaboradores.Add(colaborador);

                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return colaboradores;
        }

        /// <summary>
        /// Registrar un nuevo grupo de cajas.
        /// </summary>
        /// <param name="g">Objeto Grupo con los datos del nuevo grupo</param>
        public void agregarAsignacionManifiestoCajero(ref ManifiestoColaborador m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertRegistroManifiestoColaborador");

            _manejador.agregarParametro(comando, "@manifiesto", m.Manifiesto, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@colaborador", m.Cajero_Receptor, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@grupo", m.Grupo.Id, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@posicion", m.Posicion, SqlDbType.TinyInt);

            try
            {
                m.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorGrupoRegistro");
            }

        }

        /// <summary>
        /// Verificar si existe un cartucho.
        /// </summary>
        /// <param name="m">Objeto ManifiestoColaborador con los datos del cartucho a verificar</param>
        /// <returns>Valor que indica si el cartucho existe</returns>
        public bool verificarAsignacionManifiestoCajero(ref ManifiestoColaborador m)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteManifiestoColaborador2");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@colaborador", m.Cajero_Receptor.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@grupo", m.Grupo.Id, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    existe = id != m.ID;

                    m.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoActualizacion");
            }

            return existe;
        }



        /// <summary>
        /// Actualizar los datos de los colaboradores y la sucursal de un manifiesto del CEF.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto a actualizar</param>
        public void actualizarAsignacionManifiestoCajero(ref ManifiestoColaborador m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManifiestoColaboradorAsignacion2");

            _manejador.agregarParametro(comando, "@colaborador", m.Cajero_Receptor, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@grupo", m.Grupo.Id, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoActualizacion");
            }

        }


        /// <summary>
        /// Actualizar los datos de los colaboradores y la sucursal de un manifiesto del CEF.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto a actualizar</param>
        public void actualizarManifiestoCajero(ref ManifiestoColaborador m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManifiestoColaborador2");

            _manejador.agregarParametro(comando, "@colaborador", m.Cajero_Receptor, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@manifiesto", m.Manifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@grupo", m.Grupo.Id, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoActualizacion");
            }

        }


        /// <summary>
        /// Actualizar los datos de los colaboradores y la sucursal de un manifiesto del CEF.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto a actualizar</param>
        public void reiniciarAsignacionManifiestoCajero(Grupo g)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManifiestoColaboradorAsignacionReiniciar2");

            _manejador.agregarParametro(comando, "@grupo", g.Id, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoActualizacion");
            }

        }


        /// <summary>
        /// Listar todas las relaciones colaborador - manifiesto registradas del dia.
        /// </summary>
        /// <returns>Listar todas las relaciones colaborador - manifiesto registradas en el sistema</returns>
        public BindingList<ManifiestoColaborador> listarRegistrosCajerosAsignados(Grupo g)
        {
            BindingList<ManifiestoColaborador> registros = new BindingList<ManifiestoColaborador>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestoColaborador2");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@grupo", g.Id, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {

                    int id = (int)datareader["ID_Colaborador"];
                    string nombre = (string)datareader["Nombre_Colaborador"];
                    string primer_apellido = (string)datareader["Primer_Apellido_Colaborador"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido_Colaborador"];

                    Colaborador colaborador = new Colaborador(id: id, nombre: nombre, primer_apellido: primer_apellido,
                                                              segundo_apellido: segundo_apellido);

                    Grupo grupo = null;

                    if (datareader["ID_Grupo"] != DBNull.Value)
                    {
                        byte idgrup = (byte)datareader["ID_Grupo"];
                        string nombregrup = (string)datareader["Nombre_Grupo"];

                        grupo = new Grupo(id: idgrup, nombre: nombregrup);
                    }

                    Manifiesto manifiesto = null;
                    if (datareader["ID_Manifiesto"] != DBNull.Value)
                    {
                        int idmanif = (int)datareader["ID_Manifiesto"];
                        byte cajamanif = (byte)datareader["Caja_Manifiesto"];
                        string codigomanif = (string)datareader["Codigo_Manifiesto"];

                        manifiesto = new Manifiesto(id: idmanif, caja: cajamanif, codigo: codigomanif);
                    }

                    int posicion = (int)datareader["Posicion"];

                    ManifiestoColaborador registro = new ManifiestoColaborador(posicion: posicion, grupo: grupo, manifiesto: manifiesto, cajero_receptor: colaborador);

                    registros.Add(registro);

                }

                comando.Connection.Close();

            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return registros;
        }


        #endregion ManifiestosColaboradores 


        #endregion Métodos Públicos

    }

}
