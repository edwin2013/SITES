//
//  @ Project : 
//  @ File Name : ColaboradoresDL.cs
//  @ Date : 14/02/2011
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
    /// Clase de la capa de datos que maneja los colaboradores.
    /// </summary>
    public class ColaboradoresDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ColaboradoresDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ColaboradoresDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ColaboradoresDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ColaboradoresDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo colaborador en el sistema.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del nuevo colaborador</param>
        /// <param name="con">Hash de la contraseña del colaborador</param>
        public void agregarColaborador(ref Colaborador c, byte[] con)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertColaborador");

            _manejador.agregarParametro(comando, "@nombre", c.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@primer_apellido", c.Primer_apellido, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@segundo_apellido", c.Segundo_apellido, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@identificacion", c.Identificacion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@fecha_ingreso", c.Fecha_ingreso, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@cuenta", c.Cuenta, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@contrasena", con, SqlDbType.Binary);
            _manejador.agregarParametro(comando, "@area", c.Area, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@administrador_general", c.Administrador_general, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@email", c.Correo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@base_correo", c.BaseDatosCorreo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@servidor_correo", c.ServidorCorreo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@clave_cef", c.ClaveCEF, SqlDbType.VarChar);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorColaboradorRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un colaborador en el sistema.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del colaborador</param>
        public void actualizarColaborador(Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateColaborador");

            _manejador.agregarParametro(comando, "@nombre", c.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@primer_apellido", c.Primer_apellido, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@segundo_apellido", c.Segundo_apellido, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@identificacion", c.Identificacion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@fecha_ingreso", c.Fecha_ingreso, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@cuenta", c.Cuenta, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@area", c.Area, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@administrador_general", c.Administrador_general, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@email", c.Correo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@base_correo", c.BaseDatosCorreo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@servidor_correo", c.ServidorCorreo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@clave_cef", c.ClaveCEF, SqlDbType.VarChar);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorColaboradorActualizacion");
            }

        }

        /// <summary>
        /// Actualizar la contraseña de acceso de un colaborador en el sistema.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del colaborador</param>
        /// <param name="con">Hash de la contraseña del usuario</param>
        public void actualizarColaboradorContrasena(Colaborador c, byte[] con)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateColaboradorContrasena");

            _manejador.agregarParametro(comando, "@contrasena", con, SqlDbType.Binary);
            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorColaboradorActualizacionContrasena");
            }

        }

        /// <summary>
        /// Actualizar el código de identificación de un colaborador.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del colaborador</param>
        /// <param name="cod">Código de identificación encriptado del colaborador</param>
        /// <param name="con">Contraseña de identificación encriptada del colaborador</param>
        /// <param name="hcod">Hash deñ código de identificación del colaborador</param>
        /// <param name="hcon">Hash de la contraseña de identificación del colaborador</param>
        public void actualizarColaboradorCodigo(Colaborador c, byte[] cod, byte[] con, byte[] hcod, byte[] hcon, string atributo)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateColaboradorCodigoIdentificacion");

            _manejador.agregarParametro(comando, "@codigo", cod, SqlDbType.Binary);
            _manejador.agregarParametro(comando, "@contrasena_codigo", con, SqlDbType.Binary);
            _manejador.agregarParametro(comando, "@hash_codigo", hcod, SqlDbType.Binary);
            _manejador.agregarParametro(comando, "@hash_contrasena_codigo", hcon, SqlDbType.Binary);
            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@atributo", atributo, SqlDbType.NVarChar);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorColaboradorActualizacionCodigo");
            }

        }


        public void actualizarColaboradorSucursal(Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateColaboradorSucursal");

            _manejador.agregarParametro(comando, "@sucursal", c.Sucursal, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorColaboradorActualizacionCodigo");
            }
        }

        /// <summary>
        /// Eliminar los datos de un colaborador.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del colaborador a eliminar</param>
        public void eliminarColaborador(Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteColaborador");

            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorColaboradorEliminacion");
            }

        }

        /// <summary>
        /// Listar todos los colaboradores registrados.
        /// </summary>
        /// <param name="n">Parte del nombre de los colaboradores que se listarán</param>
        /// <returns>Lista de colaboradores registrados en el sistema</returns>
        public BindingList<Colaborador> listarColaboradores(string n)
        {
            BindingList<Colaborador> colaboradores = new BindingList<Colaborador>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectColaboradores");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@nombre", n, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];
                    string identificacion = (string)datareader["Identificacion"];
                    string cuenta = datareader["Cuenta"] as string;
                    DateTime fecha_ingreso = (DateTime)datareader["Fecha_Ingreso"];
                    Areas area = (Areas)datareader["Area"];
                    bool administrador_general = (bool)datareader["Administrador_General"];

                    string email = "";
                    if (datareader["Email"]!=DBNull.Value) 
                        email = (string)datareader["Email"];


                    string base_correo = "";
                    if (datareader["Base_Correo"] != DBNull.Value)
                        base_correo = (string)datareader["Base_Correo"];


                    string servidor_correo = "";
                    if (datareader["Servidor_Correo"] != DBNull.Value)
                        servidor_correo = (string)datareader["Servidor_Correo"];

                    string clave_cef = "";
                    if (datareader["Clave_IBS"] != DBNull.Value)
                        clave_cef = (string)datareader["Clave_IBS"];


                    Colaborador colaborador = new Colaborador(id: id, nombre: nombre, primer_apellido: primer_apellido,
                                                              segundo_apellido: segundo_apellido, identificacion: identificacion,
                                                              fecha_ingreso: fecha_ingreso, cuenta: cuenta, area: area,
                                                              administrador_general: administrador_general, correo: email, basedatoscorreo:base_correo, servidorcorreo: servidor_correo, clave_cef: clave_cef);
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
        /// Listar los colaboradores que pertenecen a un área específica.
        /// </summary>
        /// <param name="a">Área para la cual se genera la lista</param>
        /// <returns>Lista de colaboradores registrados en el sistema que pertenecen al área especificada</returns>
        public BindingList<Colaborador> listarColaboradoresdeSucursal()
        {
            BindingList<Colaborador> colaboradores = new BindingList<Colaborador>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectColaboradoresSucursal");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["ID"];
                    string nombre = (string)datareader["Nombre"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];
                    string identificacion = (string)datareader["Identificacion"];

                    Sucursal sucursal = new Sucursal();

                    if (datareader["ID_Sucursal"] != DBNull.Value)
                    {
                        short id_sucursal = (short)datareader["ID_Sucursal"];
                        string nombre_sucursal = (string)datareader["Nombre_Sucursal"];
                        TipoSucursal tipo = (TipoSucursal)datareader["Tipo"];

                        sucursal = new Sucursal(id: id_sucursal, nombre: nombre_sucursal, tipo: tipo);
                    }

                    Colaborador colaborador = new Colaborador(id, nombre, primer_apellido, segundo_apellido, identificacion);
                    colaborador.Sucursal = sucursal;
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
        /// Listar los colaboradores que pertenecen a un área específica y están asignados a un determinado puesto.
        /// </summary>
        /// <param name="a">Área para la cual se genera la lista</param>
        /// <param name="p">Puesto para el cual se genera la lista</param>
        /// <param name="c">Lista en la cual se asignarán los colaboradores</param>
        public void listarColaboradoresPorPuestoArea(Puestos p, Areas a, ref BindingList<Colaborador> c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectColaboradoresPuestoArea");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@puesto", p, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@area", a, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];
                     string clave_cef = "";
                    if(datareader["Clave_IBS"]!=DBNull.Value)
                     clave_cef  = (string)datareader["Clave_IBS"];
                    Colaborador colaborador = new Colaborador(id, nombre, primer_apellido, segundo_apellido,clave_cef:clave_cef);

                    if (!c.Contains(colaborador))
                        c.Add(colaborador);

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
        /// Listar los colaboradores que pertenecen a un área específica y están asignados a un determinado puesto.
        /// </summary>
        /// <param name="a">Área para la cual se genera la lista</param>
        /// <param name="p">Puesto para el cual se genera la lista</param>
        /// <param name="c">Lista en la cual se asignarán los colaboradores</param>
        public void listarColaboradoresPorPuestoSucursal(Puestos p, Sucursal a, ref BindingList<Colaborador> c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectColaboradoresPuestoSucursal");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@puesto", p, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@sucursal", a, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];

                    Colaborador colaborador = new Colaborador(id, nombre, primer_apellido, segundo_apellido);

                    if (!c.Contains(colaborador))
                        c.Add(colaborador);

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
        /// Listar los colaboradores que pertenecen a un área específica.
        /// </summary>
        /// <param name="a">Área para la cual se genera la lista</param>
        /// <returns>Lista de colaboradores registrados en el sistema que pertenecen al área especificada</returns>
        public BindingList<Colaborador> listarColaboradoresPorArea(Areas a)
        {
            BindingList<Colaborador> colaboradores = new BindingList<Colaborador>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectColaboradoresArea");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@area", a, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];
                    string identificacion = (string)datareader["Identificacion"];

                    Colaborador colaborador = new Colaborador(id, nombre, primer_apellido, segundo_apellido, identificacion);
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
        /// Verificar si existe un colaborador registrado.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del colaborador</param>
        /// <returns>Valor que indica si el colaborador existe</returns>
        public bool verificarColaborador(Colaborador c)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteColaborador");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@identificacion", c.Identificacion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@cuenta", c.Cuenta, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id_encontrado = (int)datareader["pk_ID"];

                    existe = id_encontrado != c.ID;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarColaboradorDuplicado");
            }

            return existe;
        }

        /// <summary>
        /// Verificar si existe un colaborador registrado según su cuenta y contraseña.
        /// </summary>
        /// <param name="c">Cuenta del usuario</param>
        /// <param name="con">Hash de la contraseña del usuario</param>
        /// <returns>Objeto Colaborador con los datos del colaborador</returns>
        public Colaborador verificarColaboradorContrasena(string c, byte[] con)
        {
            Colaborador colaborador = null;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteColaboradorCuentaContrasena");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cuenta", c, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@contrasena", con, SqlDbType.Binary);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    colaborador = new Colaborador(id: id, cuenta: c);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarColaborador");
            }

            return colaborador;
        }

        /// <summary>
        /// Verificar si existe un colaborador registrado según su código de identificación y contraseña de identificación.
        /// </summary>
        /// <param name="cod">Hash del código de identificación del usuario</param>
        /// <param name="con">Hash de la contraseña de identificación del usuario</param>
        /// <returns>Objeto Colaborador con los datos del colaborador</returns>
        public Colaborador verificarColaboradorCodigoIdentificacion(byte[] cod, byte[] con, string atributo)
        {
            Colaborador colaborador = null;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteColaboradorCodigoIdentificacion");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", cod, SqlDbType.Binary);
            _manejador.agregarParametro(comando, "@contrasena", con, SqlDbType.Binary);
            

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];
                    string identificacion = (string)datareader["Identificacion"];

                    colaborador = new Colaborador(id: id, nombre: nombre, primer_apellido: primer_apellido,
                                                  segundo_apellido: segundo_apellido, identificacion: identificacion);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarColaborador");
            }

            return colaborador;
        }

        /// <summary>
        /// Obtener los datos de un colaborador.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del colaborador</param>
        public void obtenerDatosColaborador(ref Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectColaborador");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];
                    string identificacion = (string)datareader["Identificacion"];
                    Areas area = (Areas)datareader["Area"];
                    bool administrador_general = (bool)datareader["Administrador_General"];

                    string email = "";
                        if (datareader["Email"] != DBNull.Value)
                            email = (string)datareader["Email"];


                        string base_correo = "";
                        if (datareader["Base_Correo"] != DBNull.Value)
                            base_correo = (string)datareader["Base_Correo"];


                        string servidor_correo = "";
                        if (datareader["Servidor_Correo"] != DBNull.Value)
                            servidor_correo = (string)datareader["Servidor_Correo"];

                        string clave_cef = "";
                        if (datareader["Clave_IBS"] != DBNull.Value)
                            clave_cef = (string)datareader["Clave_IBS"];



                    if (datareader["id_Sucursal"] != DBNull.Value)
                    {
                        short id_sucursal = (short)datareader["id_Sucursal"];
                        string nombre_sucursal = (string)datareader["Sucursal_Nombre"];
                        string direccion = (string)datareader["Sucursal_Direccion"];
                        Provincias provincia = (Provincias)datareader["Provincia"];
                        bool externa = (bool)datareader["Externa"];
                        bool caja = (bool)datareader["CajaEmpresarial"];
                        short codigo = (short)datareader["Numero_Sucursal"];


                        

                        TipoSucursal sucursal = (TipoSucursal)datareader["Tipo"];
                        EmpresaTransporte empresa = null;
                        if (datareader["ID_Transportadora"] != DBNull.Value)
                        {
                            byte id_transportadora = (byte)datareader["ID_Transportadora"];
                            string nombretransportadora = (string)datareader["Transportadora"];



                            empresa = new EmpresaTransporte(nombretransportadora, id_transportadora);
                        }


                        Sucursal nuevasucursal = new Sucursal(nombre_sucursal, id: id_sucursal, direccion: direccion, provincia: provincia, sucursal: sucursal, externo: externa, codigo: codigo, transporte: empresa, caja:caja);

                        c.Sucursal = nuevasucursal;
                    }
                    

                   

                    c.Nombre =  nombre;
                    c.Primer_apellido = primer_apellido;
                    c.Segundo_apellido = segundo_apellido;
                    c.Identificacion = identificacion;
                    c.Area = area;
                    c.Administrador_general = administrador_general;
                    c.Correo = email;
                    c.BaseDatosCorreo = base_correo;
                    c.ServidorCorreo = servidor_correo;
                    c.ClaveCEF = clave_cef;
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
        /// Obtener los datos de un colaborador.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del colaborador</param>
        public Colaborador obtenerDatosColaboradorCompleto(ref Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectColaborador");
           
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string primer_apellido = (string)datareader["Primer_Apellido"];
                    string segundo_apellido = (string)datareader["Segundo_Apellido"];
                    string identificacion = (string)datareader["Identificacion"];
                    Areas area = (Areas)datareader["Area"];
                    bool administrador_general = (bool)datareader["Administrador_General"];

                    c.Nombre = nombre;
                    c.Primer_apellido = primer_apellido;
                    c.Segundo_apellido = segundo_apellido;
                    c.Identificacion = identificacion;
                    c.Area = area;
                    c.Administrador_general = administrador_general;
                }

                comando.Connection.Close();
                return c;
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        /// <summary>
        /// Obtener el código de identificación de un colaborador.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del colaborador</param>
        /// <param name="hcon">Hash de la contraseña de identificación del colaborador</param>
        public void obtenerCodigoColaborador(Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectColaboradorCodigoIdentificacion");

            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaDatos(comando);



                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        /// <summary>
        /// Verificar si existe un colaborador registrado según su cuenta y contraseña.
        /// </summary>
        /// <param name="c">Cuenta del usuario</param>
        /// <param name="con">Hash de la contraseña del usuario</param>
        /// <returns>Objeto Colaborador con los datos del colaborador</returns>
        public Colaborador verificarColaboradorCuenta(string c)
        {
            Colaborador colaborador = null;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteColaboradorCuenta");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cuenta", c, SqlDbType.VarChar);


            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    colaborador = new Colaborador(id: id, cuenta: c);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarColaborador");
            }

            return colaborador;
        }
        #region Puestos

        /// <summary>
        /// Asignar a un colaborador un puesto especifico.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del colaborador</param>
        /// <param name="p">Valor que indica el puesto que se asignará al usuario</param>
        public void agregarPuestoColaborador(Colaborador c, PuestoColaborador p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertColaboradorPuestoPerfil");

            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@puesto", p, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPuestoColaboradorActualizacion");
            }

        }

        //public void agregarPuestoPerfil(Perfil c, Puestos p)
        //{
        //    SqlCommand comando = _manejador.obtenerProcedimiento("InsertColaboradorPuestoPerfil");

        //    _manejador.agregarParametro(comando, "@perfil", c, SqlDbType.Int);
        //    _manejador.agregarParametro(comando, "@puesto", p, SqlDbType.TinyInt);

        //    try
        //    {
        //        _manejador.ejecutarConsultaActualizacion(comando);
        //        comando.Connection.Close();
        //    }
        //    catch (Exception)
        //    {
        //        comando.Connection.Close();
        //        throw new Excepcion("ErrorPuestoColaboradorActualizacion");
        //    }

        //}

        /// <summary>
        /// Desligar a un colaborador de un puesto especifico.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del colaborador</param>
        /// <param name="r">Valor que indica el puesto asignado al usuario que se eliminara</param>
        public void eliminarPuestoColaborador(Colaborador c, PuestoColaborador p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteColaboradorPuestoPerfil");

            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@puesto", p, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorColaboradorActualizacion");
            }

        }

        /// <summary>
        /// Obtener los puestos de un colaborador.
        /// </summary>
        /// <param name="c">Colaborador para el cual se obtienen los puestos</param>
        public void obtenerPuestosColaborador(ref Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectColaboradorPuestos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    Puestos puesto = (Puestos)datareader["Puesto"];

                    c.agregarPuesto(puesto);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        public void obtenerPuestosRolColaborador(ref Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectColaboradorPuesto");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    PuestoColaborador puesto = new PuestoColaborador();
                    puesto.ID = (byte)datareader["Puesto"];

                    c.agregarPuestoColaborador(puesto);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }
        
        #endregion Puestos

        #region Perfiles

        /// <summary>
        /// Asignar a un colaborador un perfil específico.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del colaborador</param>
        /// <param name="p">Objeto Perfil con los datos del perfil</param>
        public void agregarPerfilColaborador(Colaborador c, Perfil p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertColaboradorPerfil");

            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@perfil", p, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPerfilColaboradorActualizacion");
            }

        }

        /// <summary>
        /// Desligar a un colaborador de un perfil específico.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del colaborador</param>
        /// <param name="p">Objeto Perfil con los datos del perfil</param>
        public void eliminarPerfilColaborador(Colaborador c, Perfil p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteColaboradorPerfil");

            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@perfil", p, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPerfilColaboradorActualizacion");
            }

        }


        /// <summary>
        /// Obtener los perfiles de un colaborador.
        /// </summary>
        /// <param name="c">Colaborador para el que se obtienen los perfiles</param>
        public void obtenerPerfilesColaborador(ref Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPerfilesPorColaboradorPuesto");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];

                    Perfil perfil = new Perfil(id, nombre);

                    c.agregarPerfil(perfil);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }


        public BindingList<Perfil> obtenerPerfilesPuestos(Puestos c)
        {
            BindingList<Perfil> perfiles = new BindingList<Perfil>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectPerfilesPorPuesto");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@puesto", c, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];

                    Perfil perfil = new Perfil(id, nombre);

                    perfiles.Add(perfil);
                   // c.agregarPerfil(perfil);
                }

                comando.Connection.Close();
                return perfiles;
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }
        #endregion Perfiles

        #region Telefonos

        /// <summary>
        /// Registrar un teléfono para un colaborador.
        /// </summary>
        /// <param name="t">Objeto Telefono con los datos del teléfono</param>
        /// <param name="c">Colaborador al cual pertenece el teléfono</param>
        public void agregarTelefonoColaborador(ref Telefono t, Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertColaboradorTelefono");

            _manejador.agregarParametro(comando, "@telefono", t.Numero, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);

            try
            {
                t.Id = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTelefonosColaboradorActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un teléfono.
        /// </summary>
        /// <param name="t">Objeto Telefono con los datos del telefono a eliminar</param>
        public void eliminarTelefonoColaborador(Telefono t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteColaboradorTelefono");

            _manejador.agregarParametro(comando, "@telefono", t.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTelefonosColaboradorActualizacion");
            }

        }

        /// <summary>
        /// Obtener los teléfonos de un colaborador.
        /// </summary>
        /// <param name="c">Colaborador para el cual se obtiene la lista de teléfono</param>
        public void obtenerTelefonosColaborador(ref Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectColaboradorTelefonos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@colaborador", c, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string numero = (string)datareader["Telefono"];

                    Telefono telefono = new Telefono(id, numero);

                    c.agregarTelefono(telefono);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        #endregion Telefonos

        #endregion Métodos Públicos


        
    }

}
