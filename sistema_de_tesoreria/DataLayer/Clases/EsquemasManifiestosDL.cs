//
//  @ Project : 
//  @ File Name : EsquemasManifiestosDL.cs
//  @ Date : 09/07/2012
//  @ Author : Erick Chavarría 

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
    /// Clase de la capa de datos que maneja los esquemas de impresión de los manifiestos.
    /// </summary>
    public class EsquemasManifiestosDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static EsquemasManifiestosDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static EsquemasManifiestosDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new EsquemasManifiestosDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public EsquemasManifiestosDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo esquema de un manifiesto.
        /// </summary>
        /// <param name="e">Objeto EsquemaManifiesto con los datos del nuevo esquema</param>
        public void agregarEsquemaManifiesto(ref EsquemaManifiesto e)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertEsquemaManifiesto");

            _manejador.agregarParametro(comando, "@transportadora", e.Transportadora, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@ancho", e.Ancho, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@alto", e.Alto, SqlDbType.Decimal);

            try
            {
                e.ID = (byte)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEsquemaManifiestoRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos del esquema de un manifiesto.
        /// </summary>
        /// <param name="e">Objeto EsquemaManifiesto con los datos del esquema</param>
        public void actualizarEsquemaManifiesto(EsquemaManifiesto e)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateEsquemaManifiesto");

            _manejador.agregarParametro(comando, "@transportadora", e.Transportadora, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@ancho", e.Ancho, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@alto", e.Alto, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@esquema", e, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEsquemaManifiestoActualizacion");
            }

        }

        /// <summary>
        /// Marcar como inactivo el esquema de un manifiesto.
        /// </summary>
        /// <param name="e">Objeto EsquemaManifiesto con los datos del esquema</param>
        public void eliminarEsquemaManifiesto(EsquemaManifiesto e)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteEsquemaManifiesto");

            _manejador.agregarParametro(comando, "@esquema", e, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEsquemaManifiestoEliminacion");
            }

        }

        /// <summary>
        /// Listar los esquemas de manifiestos registrados en el sistema.
        /// </summary>
        /// <returns>Lista de esquemas de manifiestos registrados en el sistema</returns>
        public BindingList<EsquemaManifiesto> listarEsquemasManifiestos()
        {
            BindingList<EsquemaManifiesto> esquemas = new BindingList<EsquemaManifiesto>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectEsquemasManifiestos");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id_esquema = (byte)datareader["ID_Esquema"];
                    decimal ancho = (decimal)datareader["Ancho"];
                    decimal alto = (decimal)datareader["Alto"];

                    byte id_transportadora = (byte)datareader["ID_Transportadora"];
                    string nombre = (string)datareader["Nombre"];

                    EmpresaTransporte transportadora = new EmpresaTransporte(nombre, id: id_transportadora);
                    EsquemaManifiesto esquema = new EsquemaManifiesto(id_esquema, transportadora, ancho, alto);

                    esquemas.Add(esquema);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return esquemas;
        }



        /// <summary>
        /// Listar los esquemas de manifiestos registrados en el sistema.
        /// </summary>
        /// <returns>Lista de esquemas de manifiestos registrados en el sistema</returns>
        public EsquemaManifiesto listarEsquemasManifiestoEspecifico(int id)
        {
            EsquemaManifiesto esquema = new EsquemaManifiesto();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectEsquemasManifiestoEspecifico");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@esquema", id, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    byte id_esquema = (byte)datareader["ID_Esquema"];
                    decimal ancho = (decimal)datareader["Ancho"];
                    decimal alto = (decimal)datareader["Alto"];

                    byte id_transportadora = (byte)datareader["ID_Transportadora"];
                    string nombre = (string)datareader["Nombre"];

                    EmpresaTransporte transportadora = new EmpresaTransporte(nombre, id: id_transportadora);
                    esquema = new EsquemaManifiesto(id_esquema, transportadora, ancho, alto);

                    
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return esquema;
        }




        /// <summary>
        /// Listar los esquemas de manifiestos registrados en el sistema.
        /// </summary>
        /// <returns>Lista de esquemas de manifiestos registrados en el sistema</returns>
        public EsquemaManifiesto listarEsquemasManifiestoTransportadora(EmpresaTransporte empresa)
        {
            EsquemaManifiesto esquema = new EsquemaManifiesto();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectEsquemasManifiestoTransportadora");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@transportadora", empresa, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    byte id_esquema = (byte)datareader["ID_Esquema"];
                    decimal ancho = (decimal)datareader["Ancho"];
                    decimal alto = (decimal)datareader["Alto"];

                    byte id_transportadora = (byte)datareader["ID_Transportadora"];
                    string nombre = (string)datareader["Nombre"];

                    EmpresaTransporte transportadora = new EmpresaTransporte(nombre, id: id_transportadora);
                    esquema = new EsquemaManifiesto(id_esquema, transportadora, ancho, alto);


                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return esquema;
        }

        #region Posiciones

        /// <summary>
        /// Registrar una posición del esquema de un manifiesto.
        /// </summary>
        /// <param name="p">Objeto PosicionEsquema con los datos de la posición</param>
        /// <param name="c">Colaborador al cual pertenece el teléfono</param>
        public void agregarPosicionEsquema(ref PosicionEsquema p, EsquemaManifiesto e)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertEsquemaManifiestoPosicion");

            _manejador.agregarParametro(comando, "@descripcion", p.Descripcion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@posicion_x", p.Posicion_x, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@posicion_y", p.Posicion_y, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@desplazamiento_vertical", p.Desplazamiento_vertical, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@desplazamiento_horizontal", p.Desplazamiento_horizontal, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@alto", p.Alto, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@ancho", p.Ancho, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@id_impresion", p.Id_impresion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@esquema", e, SqlDbType.TinyInt);

            try
            {
                p.ID = (short)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPosicionesEsquemaActualizacion");
            }

        }

        /// <summary>
        /// Actualizar los datos de una posición del esquema de un manifiesto.
        /// </summary>
        /// <param name="p">Objeto PosicionEsquema con los datos de la posición a actualizar</param>
        public void actualizarPosicionEsquema(PosicionEsquema p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateEsquemaManifiestoPosicion");

            _manejador.agregarParametro(comando, "@descripcion", p.Descripcion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@posicion_x", p.Posicion_x, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@posicion_y", p.Posicion_y, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@desplazamiento_vertical", p.Desplazamiento_vertical, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@desplazamiento_horizontal", p.Desplazamiento_horizontal, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@alto", p.Alto, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@ancho", p.Ancho, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@id_impresion", p.Id_impresion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@posicion", p, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPosicionesEsquemaActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de una posición del esquema de un manifiesto.
        /// </summary>
        /// <param name="p">Objeto PosicionEsquema con los datos de la posición a eliminar</param>
        public void eliminarPosicionEsquema(PosicionEsquema p)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteEsquemaManifiestoPosicion");

            _manejador.agregarParametro(comando, "@posicion", p, SqlDbType.SmallInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPosicionesEsquemaActualizacion");
            }

        }

        /// <summary>
        /// Obtener las posiciones del esquema de un manifiesto.
        /// </summary>
        /// <param name="e">Esquema para el cual se obtiene la lista de posiciones</param>
        public void obtenerPosicionesEsquema(ref EsquemaManifiesto e)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectEsquemaManifiestoPosiciones");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@esquema", e, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    short id = (short)datareader["pk_ID"];
                    string descripcion = (string)datareader["Descripcion"];
                    decimal posicion_x = (decimal)datareader["Posicion_X"];
                    decimal posicion_y = (decimal)datareader["Posicion_Y"];
                    decimal desplazamiento_vertical = (decimal)datareader["Desplazamiento_Vertical"];
                    decimal desplazamiento_horizontal = (decimal)datareader["Desplazamiento_Horizontal"];
                    decimal alto = (decimal)datareader["Alto"];
                    decimal ancho = (decimal)datareader["Ancho"];
                    byte id_impresion = (byte)datareader["ID_Impresion"];

                    PosicionEsquema posicion = new PosicionEsquema(descripcion, id: id, posicion_x: posicion_x, posicion_y: posicion_y,
                                                                   desplazamiento_vertical: desplazamiento_vertical,
                                                                   desplazamiento_horizontal: desplazamiento_horizontal,
                                                                   alto: alto, ancho: ancho, id_impresion: id_impresion);

                    e.agregarPosicion(posicion);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        #endregion Posiciones

        #endregion Métodos Públicos

    }

}
