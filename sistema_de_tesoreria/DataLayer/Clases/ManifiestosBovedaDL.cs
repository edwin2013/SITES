//
//  @ Project : 
//  @ File Name : ManifiestosBovedaDL.cs
//  @ Date : 03/04/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;

namespace DataLayer
{

    /// <summary>
    /// Clase de la capa de datos que maneja los manifiestos de bóveda.
    /// </summary>
    public class ManifiestosBovedaDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ManifiestosBovedaDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ManifiestosBovedaDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ManifiestosBovedaDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ManifiestosBovedaDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Actualizar los datos de un manifiesto de bóveda.
        /// </summary>
        /// <param name="m">Objeto ManifiestoBoveda con los datos del manifiesto a actualizar</param>
        public void actualizarManifiestoBoveda(ManifiestoBoveda m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManifiestoBoveda");

            _manejador.agregarParametro(comando, "@cajero", m.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto_colones", m.Monto_colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_dolares", m.Monto_dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@punto_venta", m.Punto_venta.Id, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@sucursal", m.Sucursal, SqlDbType.SmallInt);
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
        /// Actualizar los datos de los colaboradores y la sucursal o el origen de un manifiesto de boveda.
        /// </summary>
        /// <param name="m">Objeto ManifiestoBoveda con los datos del manifiesto a actualizar</param>
        public void actualizarManifiestoBovedaDatos(ManifiestoBoveda m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateManifiestoBovedaDatos");

            _manejador.agregarParametro(comando, "@cajero", m.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@punto_venta", m.Punto_venta.Id, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@sucursal", m.Sucursal, SqlDbType.SmallInt);
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
        /// Obtener una lista de los manifiestos de bóveda que tienen un determinado código o parte del mismo.
        /// </summary>
        /// <param name="c">Código o parte del mismo de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoBoveda> listarManifiestosBovedaPorCodigo(string c)
        {
            BindingList<ManifiestoBoveda> manifiestos = new BindingList<ManifiestoBoveda>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestosBovedaCodigo");
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
                    ManifiestoBoveda manifiesto = new ManifiestoBoveda(codigo, id: id_manifiesto, grupo: grupo, caja: caja, empresa: empresa,
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
        /// Obtener una lista de los manifiestos de bóveda que tienen un determinado código o parte del mismo recibidos en la última semana.
        /// </summary>
        /// <param name="c">Código o parte del mismo de los manifiestos que se listarán</param>
        /// <returns>Lista de manifiesto que cumplen con el criterio de búsqueda</returns>
        public BindingList<ManifiestoBoveda> listarManifiestosBovedaRecientes(string c)
        {
            BindingList<ManifiestoBoveda> manifiestos = new BindingList<ManifiestoBoveda>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestosBovedaCodigoRecientes");
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
                    bool retraso = (bool)datareader["Retraso_Transportadora"];

                    byte id_transportadora = (byte)datareader["ID_Transportadora"];
                    string nombre_transportadora = (string)datareader["Nombre"];

                    EmpresaTransporte transportadora = new EmpresaTransporte(nombre_transportadora, id: id_transportadora);

                    ManifiestoBoveda manifiesto = new ManifiestoBoveda(codigo, id: id, empresa: transportadora, retraso: retraso,
                                                                       fecha_recepcion: fecha_recepcion);

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
        /// Obtener el coordinador, cajero, el digitador, la sucursal o el origen y la fecha de procesamiento de un manifiesto de bóveda.
        /// </summary>
        /// <param name="m">Objeto ManifiestoBoveda con los datos del manifiesto para el cual se obtienen los datos</param>
        public void obtenerDatosManifiestoBoveda(ref ManifiestoBoveda m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestoBovedaDatos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    DateTime fecha_procesamiento = (DateTime)datareader["Fecha_Procesamiento"];

                    int id_cajero = (int)datareader["ID_Cajero"];
                    string nombre_cajero = (string)datareader["Nombre_Cajero"];
                    string primer_apellido_cajero = (string)datareader["Primer_Apellido_Cajero"];
                    string segundo_apellido_cajero = (string)datareader["Segundo_Apellido_Cajero"];

                    PuntoVenta punto_venta = null;

                    if (datareader["ID_Punto_Venta"] != DBNull.Value)
                    {

                        short id_punto_venta = (short)datareader["ID_Punto_Venta"];
                        string nombre_punto_venta = (string)datareader["Nombre_Punto_Venta"];

                        short id_cliente = (short)datareader["ID_Cliente"];
                        string nombre_cliente = (string)datareader["Nombre_Cliente"];

                        Cliente cliente = new Cliente(id_cliente, nombre_cliente);

                        punto_venta = new PuntoVenta(id_punto_venta, nombre_punto_venta, cliente);
                    }

                    Sucursal sucursal = null;

                    if (datareader["ID_Sucursal"] != DBNull.Value)
                    {

                        short id_sucursal = (short)datareader["ID_Sucursal"];
                        string nombre_sucursal = (string)datareader["Nombre_Sucursal"];

                        sucursal = new Sucursal(nombre_sucursal, id: id_sucursal);
                    }

                    Colaborador cajero = new Colaborador(id_cajero, nombre_cajero, primer_apellido_cajero, segundo_apellido_cajero);

                    m.Punto_venta = punto_venta;
                    m.Sucursal = sucursal;
                    m.Cajero = cajero;
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

        #endregion Métodos Públicos

    }

}
