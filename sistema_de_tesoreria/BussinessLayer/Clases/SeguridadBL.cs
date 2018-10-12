//
//  @ Project : 
//  @ File Name : SeguridadBL.cs
//  @ Date : 14/02/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

using CommonObjects;
using DataLayer;
using LibreriaMensajes;

using LibreriaAccesoDatos;
using BussinessLayer.Clases;
using CommonObjects.Clases;
using DataLayer.Clases;

using LibreriaAccesoDatos;
using System.Windows.Forms;
using BussinessLayer.Clases;
using System.DirectoryServices;
using CommonObjects.Clases;
using DataLayer.Clases;


namespace BussinessLayer
{

    public class SeguridadBL
    {

        #region Constantes

        // Puestos

        public static int Cajero = 1;
        public static int Digitador = 2;
        public static int Coordinador = 3;


        // Areas

        #endregion Constantes

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static SeguridadBL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static SeguridadBL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SeguridadBL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ColaboradoresDL _colaboradores = ColaboradoresDL.Instancia;
        private PerfilesDL _perfiles = PerfilesDL.Instancia;

        private PuestosColaboradorDL _puestosColaborador = PuestosColaboradorDL.Instancia;

        #endregion Atributos

        #region Constructor

        public SeguridadBL() { }

        #endregion Constructor

        #region Métodos Públicos

        #region Colaboradores


        /// <summary>
        /// Listar todos los colaboradores de sucursal registrados.
        /// </summary>
        /// <returns>Lista de colaboradores de sucursal registrados en el sistema</returns>
        public BindingList<Colaborador> listarColaboradoresdeSucursal()
        {

            try
            {
                BindingList<Colaborador> colaboradores = _colaboradores.listarColaboradoresdeSucursal();

                foreach (Colaborador colaborador in colaboradores)
                {
                    Colaborador actual = colaborador;
                    _colaboradores.obtenerPuestosColaborador(ref actual);
                }

                return colaboradores;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }     

        /// <summary>
        /// Registrar un nuevo colaborador en el sistema.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del nuevo colaborador</param>
        public void agregarColaborador(ref Colaborador c)
        {

            try
            {
                if (_colaboradores.verificarColaborador(c))
                    throw new Excepcion("ErrorColaboradorDuplicado");

                // Obtener el hash de la contraseña

                byte[] contrasena = this.obtenerHashCadena(c.Cuenta);

                // Registrar el colaborador

                _colaboradores.agregarColaborador(ref c, contrasena);

                // Agregar los teléfonos, puestos y perfiles del colaborador

                foreach (Telefono telefono in c.Telefonos)
                {
                    Telefono copia = telefono;

                    _colaboradores.agregarTelefonoColaborador(ref copia, c);
                }

                foreach (PuestoColaborador puesto in c.PuestosColaborador)
                    _colaboradores.agregarPuestoColaborador(c, puesto);
                
                //LOS PERFILES SE VAN A MANEJAR POR PUESTOS NO POR COLABORADOR
                //foreach (Perfil perfil in c.Perfiles)
                //    _colaboradores.agregarPerfilColaborador(c, perfil);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un colaborador en el sistema.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del colaborador</param>
        public void actualizarColaborador(Colaborador c)
        {

            try
            {
                if (_colaboradores.verificarColaborador(c))
                    throw new Excepcion("ErrorColaboradorDuplicado");

                _colaboradores.actualizarColaborador(c);

                // Desligar los roles anteriores del colaborador y registrar los nuevos

                Colaborador anterior = new Colaborador(c.ID);

                _colaboradores.obtenerPuestosRolColaborador(ref anterior);

                foreach (PuestoColaborador puesto in c.PuestosColaborador)
                {

                    if (anterior.PuestosColaborador.Contains(puesto))
                        anterior.quitarPuestoColaborador(puesto);
                    else
                        _colaboradores.agregarPuestoColaborador(c, puesto);

                }

                foreach (PuestoColaborador puesto in anterior.PuestosColaborador)
                    _colaboradores.eliminarPuestoColaborador(c, puesto);

                // Desligar los telefonos anteriores del colaborador y registrar los nuevos

                _colaboradores.obtenerTelefonosColaborador(ref anterior);

                foreach (Telefono telefono in c.Telefonos)
                {

                    if (anterior.Telefonos.Contains(telefono))
                    {
                        anterior.quitarTelefono(telefono);
                    }
                    else
                    {
                        Telefono copia = telefono;

                        _colaboradores.agregarTelefonoColaborador(ref copia, c);
                    }

                }

                foreach (Telefono telefono in anterior.Telefonos)
                    _colaboradores.eliminarTelefonoColaborador(telefono);

                // Desligar los perfiles anteriores del colaborador y registrar los nuevos

                //_colaboradores.obtenerPerfilesColaborador(ref anterior);

                //foreach (Perfil perfil in c.Perfiles)
                //{

                //    if (anterior.Perfiles.Contains(perfil))
                //        anterior.quitarPerfil(perfil);
                //    else
                //        _colaboradores.agregarPerfilColaborador(c, perfil);

                //}

                //foreach (Perfil perfil in anterior.Perfiles)
                //    _colaboradores.eliminarPerfilColaborador(c, perfil);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        /// <summary>
        /// Actualizar los datos de un colaborador en el sistema.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del colaborador</param>
        public void actualizarColaboradorSucursal(Colaborador c)
        {

            try
            {
               

                _colaboradores.actualizarColaboradorSucursal(c);

                
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar la contraseña de acceso de un colaborador en el sistema.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del colaborador</param>
        /// <param name="n">Contraseña nueva del usuario</param>
        /// <param name="a">Contraseña anterior del usuario</param>
        public void actualizarColaboradorContrasena(Colaborador c, string n, string a)
        {

            try
            {
                // Obtener el hash de la contraseña

                byte[] contrasena_anterior = this.obtenerHashCadena(a);
                byte[] contrasena_nueva = this.obtenerHashCadena(n);

                // Verificar la contraseña anterior del usuario

                Colaborador colaborador = null;

                try
                {
                    colaborador = _colaboradores.verificarColaboradorContrasena(c.Cuenta, contrasena_anterior);
                }
                catch (Excepcion)
                {
                    throw new Excepcion("ErrorCuentaNoRegistrada");
                }

                if (colaborador == null)
                    throw new Excepcion("ErrorColaboradorActualizacionContrasenaAnterior");

                _colaboradores.actualizarColaboradorContrasena(c, contrasena_nueva);
            }
            catch (Exception ex)
            {
                throw ex;
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
        /// <returns>Código de identificación y contraseña de identificación asignada al usuario</returns>
        public string[] actualizarColaboradorCodigo(Colaborador c)
        {
            string[] datos = new string[2];

            try
            {
                // Generar el código y la contraseña

                string codigo = datos[0] = this.generarCadenaAleatoria(160, false);
                string contrasena = datos[1] = this.generarCadenaAleatoria(5, true);

                byte[] codigo_encriptado = this.encriptar(codigo, contrasena);
                byte[] contrasena_encriptada = this.encriptar(contrasena, c.Identificacion);

                // Obtener el hash de la contraseña y del código

                byte[] hash_codigo = this.obtenerHashCadena(codigo);
                byte[] hash_contrasena = this.obtenerHashCadena(contrasena);

                // Actualizar el código y la contraseña

                try
                {
                    _colaboradores.actualizarColaboradorCodigo(c, codigo_encriptado, contrasena_encriptada,
                                                               hash_codigo, hash_contrasena, contrasena);
                }
                catch (Excepcion ex)
                {
                    throw ex;
                }

                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar la contraseña de acceso de un colaborador en el sistema.
        /// </summary>
        /// <param name="c">Objeto Colaborador con los datos del colaborador</param>
        public void reiniciarColaboradorContrasena(Colaborador c)
        {

            try
            {
                // Obtener el hash de la contraseña

                byte[] contrasena = this.obtenerHashCadena(c.Cuenta);

                // Actualizar la contaseña

                _colaboradores.actualizarColaboradorContrasena(c, contrasena);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Marcar como inactivo a un colaborador en el sistema.
        /// </summary>
        /// <param name="u">Objeto Colaborador con los datos del colaborador a marcar</param>
        public void eliminarColaborador(Colaborador c)
        {

            try
            {
                _colaboradores.eliminarColaborador(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todos los colaboradores registrados.
        /// </summary>
        /// <param name="n">Parte del nombre de los colaboradores que se listarán</param>
        /// <returns>Lista de colaboradores registrados en el sistema</returns>
        public BindingList<Colaborador> listarColaboradores(string n)
        {

            try
            {
                BindingList<Colaborador> colaboradores = _colaboradores.listarColaboradores(n);
                BindingList<Perfil> perfiles = new BindingList<Perfil>();
                foreach (Colaborador colaborador in colaboradores)
                {
                    Colaborador actual = colaborador;

                    _colaboradores.obtenerPuestosRolColaborador(ref actual);
                    _colaboradores.obtenerTelefonosColaborador(ref actual);

                    //LOS PERFILES SE MANEJAN POR PUESTO NO POR COLABORADOR
                    //_colaboradores.obtenerPerfilesColaborador(ref actual);

                    if (actual.Puestos.Count > 0)
                    { 
                        perfiles = _colaboradores.obtenerPerfilesPuestos(actual.Puestos[0]);

                        foreach (Perfil perfil in perfiles)
                        {
                            Perfil copia = perfil;

                            _perfiles.obtenerOpcionesPerfil(ref copia);
                        }
                   }

                }

                return colaboradores;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar los colaboradores que pertenecen a un área específica y están asignados a determinados puestos.
        /// </summary>
        /// <param name="a">Área para la cual se genera la lista</param>
        /// <param name="p">Puestos para los cuales se genera la lista</param>
        /// <returns>Lista de colaboradores registrados en el sistema que pertenecen al área especificada y tienen el puesto especificado</returns>
        public BindingList<Colaborador> listarColaboradoresPorPuestoArea(Areas a, params Puestos[] p)
        {

            try
            {
                BindingList<Colaborador> colaboradores = new BindingList<Colaborador>();

                foreach (Puestos puesto in p)
                    _colaboradores.listarColaboradoresPorPuestoArea(puesto, a, ref colaboradores);

                return colaboradores;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar los colaboradores que pertenecen a un área específica y están asignados a determinados puestos.
        /// </summary>
        /// <param name="a">Área para la cual se genera la lista</param>
        /// <param name="p">Puestos para los cuales se genera la lista</param>
        /// <returns>Lista de colaboradores registrados en el sistema que pertenecen al área especificada y tienen el puesto especificado</returns>
        public BindingList<Colaborador> listarColaboradoresPorPuestoSucural(Sucursal a, params Puestos[] p)
        {

            try
            {
                BindingList<Colaborador> colaboradores = new BindingList<Colaborador>();

                foreach (Puestos puesto in p)
                    _colaboradores.listarColaboradoresPorPuestoSucursal(puesto, a, ref colaboradores);

                return colaboradores;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar los colaboradores que pertenecen a un área específica.
        /// </summary>
        /// <param name="a">Área para la cual se genera la lista</param>
        /// <returns>Lista de colaboradores registrados en el sistema que pertenecen al área especificada</returns>
        public BindingList<Colaborador> listarColaboradoresPorArea(Areas a)
        {

            try
            {
                BindingList<Colaborador> colaboradores = _colaboradores.listarColaboradoresPorArea(a);

                foreach (Colaborador colaborador in colaboradores)
                {
                    Colaborador actual = colaborador;
                    _colaboradores.obtenerDatosColaborador(ref actual);
                    _colaboradores.obtenerPuestosColaborador(ref actual);
                }

                return colaboradores;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Validar a un colaborador mediante su cuenta de Active Directory.
        /// </summary>
        /// <param name="p">Contraseña del colaborador</param>
        /// <param name="c">Cuenta del colaborador</param>
        /// <returns>Objeto Colaborador con los datos del colaborador</returns>
        public Colaborador validarCuentaColaborador(string c, string p)
        {

            try
            {
                // Obtener el hash de la contraseña

                byte[] contrasena = this.obtenerHashCadena(p);

                // Verificar la contaseña

                Colaborador colaborador = _colaboradores.verificarColaboradorContrasena(c, contrasena);

                if (colaborador != null)
                {
                    _colaboradores.obtenerDatosColaborador(ref colaborador);
                    _colaboradores.obtenerPuestosColaborador(ref colaborador);
                    _colaboradores.obtenerPerfilesColaborador(ref colaborador);

                    foreach (Perfil perfil in colaborador.Perfiles)
                    {
                        Perfil copia = perfil;

                        _perfiles.obtenerOpcionesPerfil(ref copia);
                    }

                }
                else
                {
                    throw new Excepcion("ErrorCuentaNoRegistrada");
                }

                return colaborador;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Validar a un colaborador mediante su código de identificación y contraseña de identificación.
        /// </summary>
        /// <param name="cod">Código de identificación del colaborador</param>
        /// <param name="con">Contraseña de identificación del colaborador</param>
        /// <returns>Objeto Colaborador con los datos del colaborador</returns>
        public Colaborador validarCodigoColaborador(string cod, string con)
        {

                try
                {
                    // Obtener el hash de la contraseña y del código

                    byte[] codigo = this.obtenerHashCadena(cod);
                    byte[] contrasena = this.obtenerHashCadena(con);

                    // Verificar el código y la contraseña

                    Colaborador colaborador = _colaboradores.verificarColaboradorCodigoIdentificacion(codigo, contrasena,con);

                    if (colaborador == null)
                        throw new Excepcion("ErrorCodigoInvalido");
                    else
                        _colaboradores.obtenerPuestosColaborador(ref colaborador);

                    return colaborador;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

        }

        /// <summary>
        /// Desencripta una cadena de caracteres
        /// </summary>
        /// <param name="Password">Texto a desencriptar</param>
        /// <returns>String con la cadena desencriptada</returns>
        public string desEncriptar(string Password)
        {
            String ClaTem = "";
            String ClaAux="";
            int LarTamAsc=0;
            int TamAsc=0;
            int CodAsc=0;

            ClaAux = Password;

            try
            {

                do
                {
                    LarTamAsc = ClaAux.Substring(1, 1).Length;
                    TamAsc = ClaAux.Substring(2, LarTamAsc).Length;
                    CodAsc = ClaAux.Substring(2 + LarTamAsc, TamAsc).Length;
                    ClaTem += Convert.ToChar(CodAsc);
                    ClaAux = ClaAux.Substring(2 + LarTamAsc + TamAsc, ClaAux.Length);
                } while (ClaAux != "");

            }
            catch(Excepcion ex) 
            {
                throw ex;
            }
            return ClaTem;
        }

        /// <summary>
        /// Obtine los datos del colaborador y valida que exista en el Active Directory
        /// </summary>
        /// <param name="usuario">nombre de usuario</param>
        /// <param name="password">password del usuario</param>
        /// <param name="dominio">dominio de Active Directory</param>
        /// <returns>Retorna un objeto colaborador con los datos del colaborador</returns>
        public Colaborador obtenerCuentaActiveDirectory(string usuario, string password, string dominio)
        {
            try
            {
                Colaborador colaborador = new Colaborador();

                DirectoryEntry adsEntry = new DirectoryEntry(dominio, usuario, password);
                DirectorySearcher adsSearcher = new DirectorySearcher(adsEntry);
                adsSearcher.Filter = "(sAMAccountName=" + usuario + ")";
                SearchResult adsSearchResult = adsSearcher.FindOne();
                if ((adsSearchResult != null))
                {
                    colaborador = _colaboradores.verificarColaboradorCuenta(usuario);

                    if (colaborador != null)
                    {
                        _colaboradores.obtenerDatosColaborador(ref colaborador);
                        _colaboradores.obtenerPerfilesColaborador(ref colaborador);
                        _colaboradores.obtenerPuestosColaborador(ref colaborador);

                        foreach (Perfil perfil in colaborador.Perfiles)
                        {
                            Perfil copia = perfil;

                            _perfiles.obtenerOpcionesPerfil(ref copia);
                        }

                        return colaborador;
                    }
                    else
                    {
                        throw new Excepcion("ErrorCuentaNoRegistrada");
                    }

                }
                else return colaborador;

            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }


        //PROA
        public void obtenerPerfilesxColaborador(ref Colaborador c)
        {

            try
            {
                _colaboradores.obtenerPerfilesColaborador(ref c);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion Colaboradores

        #region Perfiles

        /// <summary>
        /// Registrar un nuevo perfil en el sistema.
        /// </summary>
        /// <param name="p">Objeto Perfil con los datos del nuevo perfil</param>
        public void agregarPerfil(ref Perfil p)
        {

            try
            {
                _perfiles.agregarPerfil(ref p);

                foreach (Opcion opcion in p.Opciones)
                    _perfiles.agregarOpcionPerfil(p, opcion);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un perfil en el sistema.
        /// </summary>
        /// <param name="p">Objeto Perfil con los datos del perfil</param>
        public void actualizarPerfil(Perfil p)
        {

            try
            {
                _perfiles.actualizarPerfil(p);

                // Desligar las opciones anteriores del perfil y registrar las nuevas

                Perfil anterior = new Perfil(p.ID);

                _perfiles.obtenerOpcionesPerfil(ref anterior);

                foreach (Opcion opcion in p.Opciones)
                {

                    if (anterior.Opciones.Contains(opcion))
                        anterior.quitarOpcion(opcion);
                    else
                        _perfiles.agregarOpcionPerfil(p, opcion);

                }

                foreach (Opcion opcion in anterior.Opciones)
                    _perfiles.eliminarOpcionPerfil(p, opcion);

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        /// <summary>
        /// Eliminar los datos de un perfil.
        /// </summary>
        /// <param name="p">Objeto Perfil con los datos del perfil a eliminar</param>
        public void eliminarPerfil(Perfil p)
        {

            try
            {
                _perfiles.eliminarPerfil(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todos los perfiles registrados.
        /// </summary>
        /// <returns>Lista de perfiles registrados en el sistema</returns>
        public BindingList<Perfil> listarPerfiles()
        {

            try
            {
                BindingList<Perfil> perfiles = _perfiles.listarPerfiles();

                foreach (Perfil perfil in perfiles)
                {
                    Perfil actual = perfil;

                    _perfiles.obtenerOpcionesPerfil(ref actual);
                }

                return perfiles;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public BindingList<Perfil> listarPerfilesPuesto(PuestoColaborador p)
        {

            try
            {
                return _perfiles.listarPerfilesPuesto(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

      
        /// <summary>
        /// Listar las opciones del sistema.
        /// </summary>
        /// <returns>Lista de las opciones del sistema</returns>
        public BindingList<Opcion> listarOpciones()
        {

            try
            {
                return _perfiles.listarOpciones();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Perfiles

        #region Puestos

        public void agregarPuestos(ref PuestoColaborador p)
        {

            try
            {
                _puestosColaborador.agregarPuesto(ref p);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public BindingList<PuestoColaborador> listarPuestos()
        {

            try
            {
                BindingList<PuestoColaborador> puestos = _puestosColaborador.listarPuestos();

                return puestos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void actualizarPuesto(PuestoColaborador p, BindingList<Perfil> perfiles)
        {
            try
            {
                BindingList<Perfil> anterior = _perfiles.listarPerfilesPuesto(p);
                foreach (Perfil perfil in perfiles)
                {
                    if (anterior.Contains(perfil))
                        anterior.Remove(perfil);
                    else
                        _puestosColaborador.agregarPerfilPuesto(p, perfil);
                }
                foreach (Perfil perfil in anterior)
                        _puestosColaborador.eliminarPerfilPuesto(p, perfil);

                Mensaje.mostrarMensaje("MensajePuestoConfirmacionActualizacion");
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }

        public void actualizarNombrePuesto(PuestoColaborador p)
        {

            try
            {
                _puestosColaborador.actualizarpuesto(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void eliminarPuesto(PuestoColaborador p)
        {

            try
            {
                _puestosColaborador.eliminarPuesto(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Puestos

        #endregion Métodos Públicos

        #region Métodos Privados

        /// <summary>
        /// Obtener el hash de una cadena de texto.
        /// </summary>
        /// <param name="cadena">Cadena para la cual se obtiene el hash</param>
        /// <returns>Hash de la cadena de texto</returns>
        private byte[] obtenerHashCadena(string cadena)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();
            byte[] hash = encoder.GetBytes(cadena);

            hash = md5.ComputeHash(hash);

            return hash;
        }

        /// <summary>
        /// Generar una cadena de texto aleatoria.
        /// </summary>
        /// <param name="tamano">Tamaño de la cadena de texto</param>
        /// <param name="numerica">Valor que indica si la cadena solo debe contener números</param>
        /// <returns>Cadena de texto aleatoria del tamaño especificado</returns>
        private string generarCadenaAleatoria(int tamano, bool numerica)
        {
            string codigo = string.Empty;
            string caracteres = numerica ? "1234567890" : "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789%$.,";
            int longitud = caracteres.Length;
            int numero = 0;

            Random generador = new Random();

            for (int contador = 0; contador < tamano; contador++)
            {
                numero = generador.Next(0, longitud);

                codigo += caracteres[numero];
            }

            return codigo;
        }

        /// <summary>
        /// Encriptar una cadena de texto.
        /// </summary>
        /// <param name="cadena">Cadena de texto a encriptar</param>
        /// <param name="password">Contraseña de encriptación</param>
        /// <returns>Arreglo de bytes que contiene la cadena encriptada</returns>
        public byte[] encriptar(string cadena, string password)
        {
            byte[] texto = UTF8Encoding.UTF8.GetBytes(cadena);
            byte[] llave;

            MD5CryptoServiceProvider hash = new MD5CryptoServiceProvider();

            llave = hash.ComputeHash(UTF8Encoding.UTF8.GetBytes(password));

            hash.Clear();

            AesCryptoServiceProvider proveedor = new AesCryptoServiceProvider();

            proveedor.Key = llave;
            proveedor.Mode = CipherMode.CBC;
            proveedor.Padding = PaddingMode.PKCS7;

            ICryptoTransform encriptador = proveedor.CreateEncryptor();

            byte[] cifrado = encriptador.TransformFinalBlock(texto, 0, texto.Length);

            proveedor.Clear();

            return cifrado;
        }

        /// <summary>
        /// Desencriptar una cadena de texto.
        /// </summary>
        /// <param name="datos">Arreglo de bytes que contiene la cadena encriptada</param>
        /// <param name="password">Contraseña de desencriptación</param>
        /// <returns>Cadena de texto desencriptada</returns>
        private string Desencriptar(byte[] datos, string password)
        {
            byte[] llave;

            MD5CryptoServiceProvider hash = new MD5CryptoServiceProvider();

            llave = hash.ComputeHash(UTF8Encoding.UTF8.GetBytes(password));

            hash.Clear();

            TripleDESCryptoServiceProvider proveedor = new TripleDESCryptoServiceProvider();

            proveedor.Key = llave;
            proveedor.Mode = CipherMode.CBC;
            proveedor.Padding = PaddingMode.PKCS7;

            ICryptoTransform encriptador = proveedor.CreateDecryptor();

            byte[] salida = encriptador.TransformFinalBlock(datos, 0, datos.Length);

            proveedor.Clear();

            return UTF8Encoding.UTF8.GetString(salida);
        }

        

        #endregion Métodos Privados

    }

}
