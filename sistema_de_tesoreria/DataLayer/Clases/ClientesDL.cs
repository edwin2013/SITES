//
//  @ Project : 
//  @ File Name : ClienteDL.cs
//  @ Date : 01/06/2011
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

    public class ClientesDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ClientesDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ClientesDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ClientesDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ClientesDL() { }

        #endregion Constructor

        #region Métodos Públicos

        public DataTable listarClientesDT()
        {
            DataTable dt = new DataTable();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectClientes");
            SqlDataReader datareader = null;
            _manejador.agregarParametro(comando, "@nombre", "", SqlDbType.VarChar);
            try
            {
                comando.Connection.Open();
                datareader = comando.ExecuteReader();
                dt.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion(ex.Message);
            }

            return dt;
        }
        /// <summary>
        /// Registrar un nuevo cliente en el sistema.
        /// </summary>
        /// <param name="c">Objeto Cliente con los datos del nuevo cliente</param>
        public void agregarCliente(ref Cliente c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCliente");

            _manejador.agregarParametro(comando, "@nombre", c.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@contrato_transporte", c.Contrato_transporte, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@solicitud_remesas", c.Solicitud_remesas, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@contacto", c.Contacto, SqlDbType.VarChar);

            try
            {
                c.Id = (short)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorClienteRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un cliente en el sistema.
        /// </summary>
        /// <param name="c">Objeto Cliente con los datos del cliente</param>
        public void actualizarCliente(Cliente c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCliente");

            _manejador.agregarParametro(comando, "@nombre", c.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@contrato_transporte", c.Contrato_transporte, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@solicitud_remesas", c.Solicitud_remesas, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@contacto", c.Contacto, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@cliente", c.Id, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorClienteActualizacion");
            }

        }




        /// <summary>
        /// Actualizar los datos de un punto de venta en el sistema.
        /// </summary>
        /// <param name="c">Objeto Comision con los datos del comision</param>
        public void actualizarPuntoVentacomision(Comision c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdatePuntoVentaComision");

            _manejador.agregarParametro(comando, "@punto", c.Nombre.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@comision", c.MComision, SqlDbType.Decimal);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorClienteActualizacion");
            }

        }

        /// <summary>
        /// Marcar como inactivo a un cliente del sistema.
        /// </summary>
        /// <param name="c">Objeto Cliente con los datos del cliente a marcar</param>
        public void eliminarCliente(Cliente c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCliente");

            _manejador.agregarParametro(comando, "@cliente", c.Id, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorClienteEliminacion");
            }

        }

        /// <summary>
        /// Listar a los clientes del sistema.
        /// </summary>
        /// <param name="n">Parte del nombre de los clientes a listar</param>
        /// <returns>Lista de los cliente registrados en el sistema</returns>
        public BindingList<Cliente> listarClientes(string n)
        {
            BindingList<Cliente> clientes = new BindingList<Cliente>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectClientes");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@nombre", n, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string contacto = (string)datareader["Contacto"];
                    Contratos_Transporte contrato_transporte = (Contratos_Transporte)datareader["Contrato_Transporte"];
                    bool solicitud_remesas = (bool)datareader["Solicitud_Remesas"];

                    Cliente cliente = new Cliente(id, nombre, contrato_transporte, solicitud_remesas, contacto);

                    clientes.Add(cliente);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return clientes;
        }

        /// <summary>
        /// Verificar si existe un cliente.
        /// </summary>
        /// <param name="c">Objeto cliente con los datos del cliente a verificar</param>
        /// <returns>Valor que indica si el cliente existe</returns>
        public bool verificarCliente(ref Cliente c)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteCliente");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];

                    existe = id != c.Id;

                    c.Id = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarClienteDuplicado");
            }

            return existe;
        }

        #region Nombres Jurídicos

        /// <summary>
        /// Registrar un nombre jurídico para un cliente.
        /// </summary>
        /// <param name="n">Objeto NombreJuridico con los datos del nombre</param>
        /// <param name="c">Cliente al cual pertenece el nombre jurídico</param>
        public void agregarNombreJuridicoCliente(ref NombreJuridico n, Cliente c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertClienteNombreJuridico");

            _manejador.agregarParametro(comando, "@nombre", n.Nombre, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@cif", n.CIF, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cliente", c.Id, SqlDbType.Int);

            try
            {
                n.Id = (short)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorNombreJuridicoClienteActualizacion");
            }

        }

        /// <summary>
        /// Eliminar el nombre jurídico de un cliente.
        /// </summary>
        /// <param name="n">Objeto NombreJuridico con los datos del nombre a eliminar</param>
        public void eliminarNombreJuridicoCliente(NombreJuridico n)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteClienteNombreJuridico");

            _manejador.agregarParametro(comando, "@nombre_juridico", n.Id, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorNombreJuridicoClienteActualizacion");
            }

        }

        /// <summary>
        /// Obtener los nombres jurídicos de un cliente.
        /// </summary>
        /// <param name="c">Cliente para el cual se obtiene la lista de nombres</param>
        public void obtenerNombresJuridicosCliente(ref Cliente c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectClienteNombresJuridicos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cliente", c.Id, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    int cif = (int)datareader["CIF"];
                    string nombre = (string)datareader["Nombre"];

                    NombreJuridico nombre_juridico = new NombreJuridico(id: id, cif: cif, nombre: nombre);

                    c.agregarNombreJuridico(nombre_juridico);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        #endregion Nombres Jurídicos

        #region Cuentas

        /// <summary>
        /// Registrar una cuenta para un nombre jurídico de un cliente.
        /// </summary>
        /// <param name="c">Objeto Cuenta con los datos de la cuenta</param>
        /// <param name="n">Nombre jurídico al cual pertenece la cuenta</param>
        public void agregarCuentaNombreJuridicoCliente(ref Cuenta c, NombreJuridico n)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertClienteNombreJuridicoCuenta");

            _manejador.agregarParametro(comando, "@cuenta", c.Numero_cuenta, SqlDbType.BigInt);
            _manejador.agregarParametro(comando, "@moneda", c.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@nombre_juridico",  n.Id, SqlDbType.Int);

            try
            {
                c.Id = (short)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCuentaNombreJuridicoClienteActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de la cuenta de un nombre jurídico de un cliente.
        /// </summary>
        /// <param name="c">Objeto Cuenta con los datos de la cuenta a eliminar</param>
        public void eliminarCuentaNombreJuridicoCliente(Cuenta c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteClienteNombreJuridicoCuenta");

            _manejador.agregarParametro(comando, "@cuenta", c.Id, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCuentaNombreJuridicoClienteActualizacion");
            }

        }

        /// <summary>
        /// Obtener las cuentas de un cliente para un nombre jurídico específico.
        /// </summary>
        /// <param name="n">Nombre jurídico para el cual se obtiene la lista de cuentas</param>
        public void obtenerCuentasNombreJuridicoCliente(ref NombreJuridico n)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectClienteNombresJuridicosCuentas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@nombre_juridico", n.Id, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    long numero = (long)datareader["Cuenta"];
                    Monedas moneda = (Monedas)datareader["Moneda"];

                    Cuenta cuenta = new Cuenta(id, numero, moneda);

                    n.agregarCuenta(cuenta);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        #endregion Cuentas

        #region Telefonos

        /// <summary>
        /// Registrar un teléfono para un cliente.
        /// </summary>
        /// <param name="t">Objeto Telefono con los datos del teléfono</param>
        /// <param name="c">Cliente al cual pertenece el teléfono</param>
        public void agregarTelefonoCliente(ref Telefono t, Cliente c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertClienteTelefono");

            _manejador.agregarParametro(comando, "@numero", t.Numero, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@cliente", c.Id, SqlDbType.Int);

            try
            {
                t.Id = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTelefonoClienteActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos del teléfono de un cliente.
        /// </summary>
        /// <param name="t">Objeto Telefono con los datos del telefono a eliminar</param>
        public void eliminarTelefonoCliente(Telefono t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteClienteTelefono");

            _manejador.agregarParametro(comando, "@telefono", t.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTelefonoClienteActualizacion");
            }

        }

        /// <summary>
        /// Obtener los teléfonos de un cliente.
        /// </summary>
        /// <param name="c">Cliente para el cual se obtiene la lista de teléfono</param>
        public void obtenerTelefonosCliente(ref Cliente c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectClienteTelefonos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cliente", c.Id, SqlDbType.Int);

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

        #region Correos

        /// <summary>
        /// Registrar un correo para un cliente.
        /// </summary>
        /// <param name="t">Objeto Correo con los datos del correo</param>
        /// <param name="c">Cliente al cual pertenece el correo</param>
        public void agregarCorreoCliente(ref Correo c, Cliente cl)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertClienteCorreo");

            _manejador.agregarParametro(comando, "@correo", c.Direccion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@cliente", cl.Id, SqlDbType.Int);

            try
            {
                c.Id = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCorreoClienteActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un correo.
        /// </summary>
        /// <param name="c">Objeto Correo con los datos del correo a eliminar</param>
        public void eliminarCorreoCliente(Correo c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteClienteCorreo");

            _manejador.agregarParametro(comando, "@correo", c.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCorreoClienteActualizacion");
            }

        }

        /// <summary>
        /// Obtener los correos de un cliente.
        /// </summary>
        /// <param name="c">Cliente para el cual se obtiene la lista de correos</param>
        public void obtenerCorreosCliente(ref Cliente c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectClienteCorreos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cliente", c.Id, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string direccion = (string)datareader["Correo"];

                    Correo correo = new Correo(id, direccion);
                    c.agregarCorreo(correo);
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
