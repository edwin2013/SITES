//
//  @ Project : 
//  @ File Name : ManifiestosDL.cs
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
using CommonObjects.Clases;

namespace DataLayer
{

    /// <summary>
    /// Clase de la capa de datos que maneja los manifiestos.
    /// </summary>
    public class ManifiestosDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ManifiestosDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ManifiestosDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ManifiestosDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ManifiestosDL() { }

        #endregion Constructor

        #region Métodos Públicos

        #region SITES
        /// <summary>
        /// Registrar un nuevo manifiesto.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del nuevo manifiesto</param>
        public void agregarManifiestos(ref Manifiesto m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertManifiesto2");

            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@receptor", m.Receptor.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@empresa", m.Empresa.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@caja", m.Caja, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@grupo", m.Grupo.Id, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@area", m.Area, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cajeroreceptor", m.Cajero_Receptor.ID, SqlDbType.Int);


            try
            {
                m.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoRegistro");
            }

        }


        /// <summary>
        /// Registrar un nuevo manifiesto.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del nuevo manifiesto</param>
        public void agregarManifiestoNiquel(ref Manifiesto m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("[InsertManifiestoNiquel]");

            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@receptor", m.Receptor, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@empresa", m.Empresa, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@caja", m.Caja, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cliente", m.Cliente.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@area", m.Area, SqlDbType.TinyInt);

            try
            {
                m.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoRegistro");
            }

        }

        /// <summary>
        /// Agregar un nuevo manifiesto no registrado por un receptor.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del nuevo manifiesto</param>
        /// <param name="c">Coordinador que registra el manifiesto</param>
        public void agregarManifiesto(ref Manifiesto m, Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertManifiestoTardio");

            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@receptor", m.Receptor, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@empresa", m.Empresa, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@caja", m.Caja, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@grupo", m.Grupo.Id, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@area", m.Area, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha", m.Fecha_recepcion, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@coordinador", c, SqlDbType.Int);

            try
            {
                m.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoRegistro");
            }

        }

        /// <summary>
        /// Reiniciar los datos de un manifiesto.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto a reiniciar</param>
        public void reiniciarManifiesto(Manifiesto m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManifiestoReiniciar");

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
        /// Actualizar el código de un manifiesto.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto a actualizar</param>
        /// <param name="c">Colaborador que realiza el cambio</param>
        public void actualizarCodigoManifiesto(Manifiesto m, Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManifiestoCodigo");

            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoActualizacionCodigo");
            }

        }

        /// <summary>
        /// Actualizar el grupo de un manifiesto.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto a actualizar</param>
        public void actualizarGrupoManifiesto(Manifiesto m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManifiestoGrupo");

            _manejador.agregarParametro(comando, "@caja", m.Caja, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@grupo", m.Grupo.Id, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoActualizacionGrupo");
            }

        }

        /// <summary>
        /// Actualizar el área de un manifiesto.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto a actualizar</param>
        public void actualizarAreaManifiesto(Manifiesto m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManifiestoArea");

            _manejador.agregarParametro(comando, "@area", m.Area, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cajeroreceptor", m.Cajero_Receptor, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cajeroreasignado", m.Cajero_Reasignado, SqlDbType.Int);


            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoActualizacionArea");
            }

        }


        /// <summary>
        /// Actualizar un manifiesto desmarcándolo como entregado tardiamente por la transportadora.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto a actualizar</param>
        public void actualizarManifiestoDesmarcarRetraso(Manifiesto m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManifiestoRetrasoDesmarcar");

            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoDesmarcacion");
            }

        }

        /// <summary>
        /// Actualizar un manifiesto marcándolo como entregado tardiamente por la transportadora.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto a actualizar</param>
        public void actualizarManifiestoMarcarRetraso(Manifiesto m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManifiestoRetrasoMarcar");

            _manejador.agregarParametro(comando, "@fecha_recoleccion", m.Fecha_recoleccion, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoMarcacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un manifiesto .
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto a eliminar</param>
        public void eliminarManifiesto(Manifiesto m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteManifiesto");

            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoEliminacion");
            }

        }



        /// <summary>
        /// Eliminar los datos de un manifiesto .
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto a elimina, del area de entrega de niquel</param>
        public void eliminarManifiestoNiquel(Manifiesto m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteManifiestoNiquel");

            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoEliminacion");
            }

        }

        /// <summary>
        /// Verificar si existe un manifiesto ya registrado.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto</param>
        /// <returns>Valor que indica si el manifiesto existe</returns>
        public bool verificarManifiesto(ref Manifiesto m)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteManifiesto");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id_encontrado = (int)datareader["pk_ID"];

                    existe = id_encontrado != m.ID;

                    m.ID = id_encontrado;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarManifiestoDuplicado");
            }

            return existe;
        }


        /// <summary>
        /// Verificar si existe un manifiesto ya registrado en el ara de niquel
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto</param>
        /// <returns>Valor que indica si el manifiesto existe</returns>
        public bool verificarManifiestoNiquel(ref Manifiesto m)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteManifiestoNiquel");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id_encontrado = (int)datareader["pk_ID"];

                    existe = id_encontrado != m.ID;

                    m.ID = id_encontrado;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarManifiestoDuplicado");
            }

            return existe;
        }

        /// <summary>
        /// Obtener una lista de los manifiestos que tienen un determinado código o parte del mismo.
        /// </summary>
        /// <param name="c">Código o parte del mismo de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<Manifiesto> listarManifiestosPorCodigo(string c)
        {
            BindingList<Manifiesto> manifiestos = new BindingList<Manifiesto>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestosCodigo2");
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
                    AreasManifiestos area = (AreasManifiestos)datareader["Area"];

                    int id_receptor = (int)datareader["ID_Receptor"];
                    string nombre_receptor = (string)datareader["Nombre"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];

                    byte id_empresa = (byte)datareader["ID_Empresa"];
                    string nombre_empresa = (string)datareader["Nombre_Empresa"];

                    byte id_grupo = (byte)datareader["ID_Grupo"];
                    string nombre_grupo = (string)datareader["Nombre_Grupo"];
                    Colaborador cajero_receptor = null;

                    if (datareader["ID_Cajero_Receptor"] != DBNull.Value)
                    {
                        int id_cajero_receptor = (int)datareader["ID_Cajero_Receptor"];
                        string nombre_cajero_receptor = (string)datareader["Nombre_Cajero_Receptor"];
                        string primer_apellido_cajero = (string)datareader["Primer_Apellido_Cajero_Receptor"];
                        string segundo_apellido_cajero = (string)datareader["Segundo_Apellido_Cajero_Receptor"];

                        cajero_receptor = new Colaborador(id_cajero_receptor, nombre_cajero_receptor, primer_apellido_cajero, segundo_apellido_cajero);

                    }
                    Colaborador cajero_reasingado = null;

                    if (datareader["ID_Cajero_Reasignado"] != DBNull.Value)
                    {
                        int id_cajero_reasingado = (int)datareader["ID_Cajero_Reasignado"];
                        string nombre_cajero_reasingado = (string)datareader["Nombre_Cajero_Reasignado"];
                        string primer_apellido_cajero_reasingado = (string)datareader["Primer_Apellido_Cajero_Reasignado"];
                        string segundo_apellido_cajero_reasingado = (string)datareader["Segundo_Apellido_Cajero_Reasignado"];

                        cajero_reasingado = new Colaborador(id_cajero_reasingado, nombre_cajero_reasingado, primer_apellido_cajero_reasingado, segundo_apellido_cajero_reasingado);

                    }

                    Colaborador receptor = new Colaborador(id_receptor, nombre_receptor, primer_apellido, segundo_apellido);
                    EmpresaTransporte empresa = new EmpresaTransporte(nombre_empresa, id: id_empresa);
                    Grupo grupo = new Grupo(id_grupo, nombre_grupo);

                    Manifiesto manifiesto = new Manifiesto(codigo, id: id_manifiesto, grupo: grupo, caja: caja, empresa: empresa,
                                                           area: area, receptor: receptor, fecha_recepcion: fecha_recepcion,
                                                           fecha_recoleccion: fecha_recoleccion, retraso: retraso, cajero_receptor: cajero_receptor);

                    manifiesto.Cajero_Reasignado = cajero_reasingado;
                    manifiesto.Area = area;
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
        /// Obtener una lista de los manifiestos que tienen un determinado código o parte del mismo recibidos en la última semana.
        /// </summary>
        /// <param name="c">Código o parte del mismo de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<Manifiesto> listarManifiestosRecientes(string c)
        {
            BindingList<Manifiesto> manifiestos = new BindingList<Manifiesto>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestosCodigoRecientes");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", c, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["ID_Manifiestos"];
                    string codigo = (string)datareader["Codigo"];
                    bool retraso = (bool)datareader["Retraso_Transportadora"];
                    AreasManifiestos area = (AreasManifiestos)datareader["Area"];

                    byte id_transportadora = (byte)datareader["ID_Transportadora"];
                    string nombre_transportadora = (string)datareader["Nombre"];

                    EmpresaTransporte transportadora = new EmpresaTransporte(nombre_transportadora, id: id_transportadora);

                    Manifiesto manifiesto = new Manifiesto(codigo, id: id, empresa: transportadora, retraso: retraso, area: area);

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
        /// Obtener el manifiesto al que está ligado una tula.
        /// </summary>
        /// <param name="t">Tula para la cual se obtendrá el manifiesto al que está ligada</param>
        public void obtenerManifiestoTula(ref Tula t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestoTula2");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@tula", t, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["ID_Manifiesto"];
                    string codigo = (string)datareader["Codigo"];
                    byte caja = (byte)datareader["Caja"];
                    DateTime fecha_recepcion = (DateTime)datareader["Fecha_Recepcion"];

                    byte id_grupo = (byte)datareader["ID_Grupo"];
                    string nombre_grupo = (string)datareader["Nombre_Grupo"];

                    int id_receptor = (int)datareader["ID_Receptor"];
                    string nombre_receptor = (string)datareader["Nombre_Receptor"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];

                    byte id_empresa = (byte)datareader["ID_Empresa"];
                    string nombre_empresa = (string)datareader["Nombre_Empresa"];

                    Colaborador cajero_receptor = null;
                   
                    if ( datareader["ID_Cajero_Receptor"] != DBNull.Value)
                    {
                        int id_cajero_receptor = (int)datareader["ID_Cajero_Receptor"];
                        string nombre_cajero_receptor = (string)datareader["Nombre_Cajero_Receptor"];
                        string primer_apellido_cajero = (string)datareader["Primer_Apellido_Cajero"];
                        string segundo_apellido_cajero = (string)datareader["Segundo_Apellido_Cajero"];

                        cajero_receptor = new Colaborador(id_cajero_receptor, nombre_cajero_receptor, primer_apellido_cajero, segundo_apellido_cajero);
                    
                    }
                   
                    Grupo grupo = new Grupo(id_grupo, nombre_grupo);
                    Colaborador receptor = new Colaborador(id_receptor, nombre_receptor, primer_apellido, segundo_apellido);
                    EmpresaTransporte empresa = new EmpresaTransporte(nombre_empresa, id: id_empresa);

                    t.Manifiesto = new Manifiesto(codigo, id: id, grupo: grupo, caja: caja, empresa: empresa,
                                                receptor: receptor, fecha_recepcion: fecha_recepcion, cajero_receptor:cajero_receptor);
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
        /// Obtener el manifiesto al que está ligado una tula.
        /// </summary>
        /// <param name="t">Tula para la cual se obtendrá el manifiesto al que está ligada</param>
        public void obtenerManifiestoTulaNiquel(ref Tula t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestoTulaNiquel");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@tula", t, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["ID_Manifiesto"];
                    string codigo = (string)datareader["Codigo"];
                    //byte caja = ()datareader["Caja"];
                    DateTime fecha_recepcion = (DateTime)datareader["Fecha_Recepcion"];

                    short id_cliente = (short)datareader["ID_Cliente"];
                    string nombre_cliente = (string)datareader["Nombre_Cliente"];

                    int id_receptor = (int)datareader["ID_Receptor"];
                    string nombre_receptor = (string)datareader["Nombre_Receptor"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];

                    byte id_empresa = (byte)datareader["ID_Empresa"];
                    string nombre_empresa = (string)datareader["Nombre_Empresa"];

                    Cliente cliente = new Cliente(id_cliente, nombre_cliente);
                    Colaborador receptor = new Colaborador(id_receptor, nombre_receptor, primer_apellido, segundo_apellido);
                    EmpresaTransporte empresa = new EmpresaTransporte(nombre_empresa, id: id_empresa);

                    t.Manifiesto = new Manifiesto(codigo, id: id, cliente:cliente, empresa: empresa,
                                                     receptor: receptor, fecha_recepcion: fecha_recepcion);
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
        /// Eliminar la relacion manifiesto colaborador .
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos de la la relacion manifiesto colaborador a eliminar</param>
        public void eliminarManifiestoColaborador(Manifiesto m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteManifiestoColaborador");

            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoEliminacion");
            }

        }
        #endregion SITES

        #region PROA

        public bool verificarManifiestoReabierto(String codigo)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerConsulta(@"SELECT COUNT([pk_ID]) AS 'CONTEO' FROM [dbo].[tblPendienteProcesamientoBajoVolumenManifiesto] 
                WHERE fk_ID_ProcesamientoBajoVolumenManifiesto = (
                    SELECT pk_ID FROM [dbo].[tblProcesamientoBajoVolumenManifiesto] WHERE fk_ID_Manifiesto IN (
                        SELECT TOP 1 pk_ID FROM dbo.tblManifiesto WHERE Codigo = '" + codigo + @"' ORDER BY pk_ID DESC
                    )
                )");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", codigo, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id_encontrado = (int)datareader["CONTEO"];

                    if (id_encontrado == 0)
                    {
                        existe = false;
                    }
                    else
                    {
                        existe = true;
                    }
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarManifiestoDuplicado");
            }

            return existe;
        }

        public bool verificarManifiestoProcesado(String codigo)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerConsulta(@"SELECT COUNT([pk_ID]) AS 'CONTEO' FROM [dbo].[tblProcesamientoBajoVolumenManifiesto] WHERE fk_ID_Manifiesto IN 
                (SELECT TOP 1 pk_ID FROM dbo.tblManifiesto WHERE Codigo = '" + codigo + "' ORDER BY pk_ID DESC)");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", codigo, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id_encontrado = (int)datareader["CONTEO"];

                    if (id_encontrado == 0)
                    {
                        existe = false;
                    }
                    else
                    {
                        existe = true;
                    }
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarManifiestoDuplicado");
            }

            return existe;
        }

        public string PROABorrarManifiesto(String codigo, int idcolaborador) //Cambio GZH 13092017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("PROA_Borrar_ProcesamientoBajoVolumenmanifiesto");
            comando.CommandTimeout = 60000;

            _manejador.agregarParametro(comando, "@manifiesto", codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@idcolaborador", idcolaborador, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
                return "";
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                //throw new Excepcion(ex.Message);
                return ex.Message;
            }

        }
        public void PROAReaperturarManifiesto(String codigo)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("PROA_Reabrir_manifiesto");
            comando.CommandTimeout = 60000;

            _manejador.agregarParametro(comando, "@manifiesto", codigo, SqlDbType.VarChar);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion(ex.Message);
            }

        }
        public bool verificarManifiesto3(ref Manifiesto m) //Cambios GZH 31/10/2017
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteManifiesto5");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);
            int id_encontrado;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    id_encontrado = (int)datareader["RESULTADO"];
                    if (id_encontrado > 0)
                    {
                        m.ID = id_encontrado;
                        existe = true;
                    }
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarManifiestoDuplicado");
            }

            return existe;
        }

        public bool verificarManifiesto2(ref ProcesamientoBajoVolumenManifiesto m, Boolean pendiente)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteManifiesto4");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id_encontrado = (int)datareader["pk_ID"];

                    if (pendiente == true)
                    {
                        existe = id_encontrado == m.IDManifiesto;
                    }
                    else
                    {
                        existe = true;
                        m.IDManifiesto = id_encontrado;
                    }
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarManifiestoDuplicado");
            }

            return existe;
        }

        public void actualizarManifiestoCodigo(Manifiesto m, Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManifiestoCodigo2");

            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoActualizacionCodigo");
            }

        }

        public BindingList<Manifiesto> listarManifiestosPorFecha(DateTime i, DateTime f)
        {
            BindingList<Manifiesto> manifiestos = new BindingList<Manifiesto>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestosFecha");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha_inicio", i, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha_final", f, SqlDbType.DateTime);

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
                    AreasManifiestos area = (AreasManifiestos)datareader["Area"];

                    int id_receptor = (int)datareader["ID_Receptor"];
                    string nombre_receptor = (string)datareader["Nombre"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];

                    byte id_empresa = (byte)datareader["ID_Empresa"];
                    string nombre_empresa = (string)datareader["Nombre_Empresa"];

                    byte id_grupo = (byte)datareader["ID_Grupo"];
                    string nombre_grupo = (string)datareader["Nombre_Grupo"];
                    Colaborador cajero_receptor = null;

                    if (datareader["ID_Cajero_Receptor"] != DBNull.Value)
                    {
                        int id_cajero_receptor = (int)datareader["ID_Cajero_Receptor"];
                        string nombre_cajero_receptor = (string)datareader["Nombre_Cajero_Receptor"];
                        string primer_apellido_cajero = (string)datareader["Primer_Apellido_Cajero_Receptor"];
                        string segundo_apellido_cajero = (string)datareader["Segundo_Apellido_Cajero_Receptor"];

                        cajero_receptor = new Colaborador(id_cajero_receptor, nombre_cajero_receptor, primer_apellido_cajero, segundo_apellido_cajero);

                    }
                    Colaborador cajero_reasingado = null;

                    if (datareader["ID_Cajero_Reasignado"] != DBNull.Value)
                    {
                        int id_cajero_reasingado = (int)datareader["ID_Cajero_Reasignado"];
                        string nombre_cajero_reasingado = (string)datareader["Nombre_Cajero_Reasignado"];
                        string primer_apellido_cajero_reasingado = (string)datareader["Primer_Apellido_Cajero_Reasignado"];
                        string segundo_apellido_cajero_reasingado = (string)datareader["Segundo_Apellido_Cajero_Reasignado"];

                        cajero_reasingado = new Colaborador(id_cajero_reasingado, nombre_cajero_reasingado, primer_apellido_cajero_reasingado, segundo_apellido_cajero_reasingado);

                    }

                    Colaborador receptor = new Colaborador(id_receptor, nombre_receptor, primer_apellido, segundo_apellido);
                    EmpresaTransporte empresa = new EmpresaTransporte(nombre_empresa, id: id_empresa);
                    Grupo grupo = new Grupo(id_grupo, nombre_grupo);

                    Manifiesto manifiesto = new Manifiesto(codigo, id: id_manifiesto, grupo: grupo, caja: caja, empresa: empresa,
                                                           area: area, receptor: receptor, fecha_recepcion: fecha_recepcion,
                                                           fecha_recoleccion: fecha_recoleccion, retraso: retraso, cajero_receptor: cajero_receptor);

                    manifiesto.Cajero_Reasignado = cajero_reasingado;
                    manifiesto.Area = area;
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

        #endregion PROA

        #endregion Métodos Públicos

    }

}
