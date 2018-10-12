using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using CommonObjects;
using System.Data.SqlClient;
using System.Data;
using LibreriaMensajes;
using System.ComponentModel;

namespace DataLayer.Clases
{
    public class DocumentosDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static DocumentosDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static DocumentosDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new DocumentosDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public DocumentosDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo documento.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del nuevo manifiesto</param>
        public void agregarDocumentos(ref Manifiesto m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertDocumento");

            _manejador.agregarParametro(comando, "@manifiesto", m.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@receptor", m.Receptor.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@empresa", m.Empresa.ID, SqlDbType.TinyInt);

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
        /// Actualizar el código de un manifiesto.
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto a actualizar</param>
        /// <param name="c">Colaborador que realiza el cambio</param>
        public void actualizarDocumento(Manifiesto m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateDocumento");

            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@codigo", m.Codigo, SqlDbType.VarChar);

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
        /// Eliminar los datos de un manifiesto .
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto a eliminar</param>
        public void eliminarDocumento(Manifiesto m)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteManifiestoDocumento");

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
        /// Verificar si existe un manifiesto ya registrado en el ara de niquel
        /// </summary>
        /// <param name="m">Objeto Manifiesto con los datos del manifiesto</param>
        /// <returns>Valor que indica si el manifiesto existe</returns>
        public bool verificarDocumento(ref Manifiesto m)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteDocumento");
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
        //public BindingList<Manifiesto> listarManifiestosPorCodigo(string c)
        //{
        //    BindingList<Manifiesto> manifiestos = new BindingList<Manifiesto>();

        //    SqlCommand comando = _manejador.obtenerProcedimiento("SelectManifiestosCodigo2");
        //    SqlDataReader datareader = null;

        //    _manejador.agregarParametro(comando, "@codigo", c, SqlDbType.VarChar);

        //    try
        //    {
        //        datareader = _manejador.ejecutarConsultaDatos(comando);

        //        while (datareader.Read())
        //        {
        //            int id_manifiesto = (int)datareader["ID_Manifiesto"];
        //            string codigo = (string)datareader["Codigo"];
        //            byte caja = (byte)datareader["Caja"];
        //            DateTime fecha_recepcion = (DateTime)datareader["Fecha_Recepcion"];
        //            DateTime fecha_recoleccion = (DateTime)datareader["Fecha_Recepcion"];
        //            bool retraso = (bool)datareader["Retraso_Transportadora"];
        //            AreasManifiestos area = (AreasManifiestos)datareader["Area"];

        //            int id_receptor = (int)datareader["ID_Receptor"];
        //            string nombre_receptor = (string)datareader["Nombre"];
        //            string primer_apellido = (string)datareader["Primer_Apellido"];
        //            string segundo_apellido = (string)datareader["Segundo_Apellido"];

        //            byte id_empresa = (byte)datareader["ID_Empresa"];
        //            string nombre_empresa = (string)datareader["Nombre_Empresa"];

        //            byte id_grupo = (byte)datareader["ID_Grupo"];
        //            string nombre_grupo = (string)datareader["Nombre_Grupo"];
        //            Colaborador cajero_receptor = null;

        //            if (datareader["ID_Cajero_Receptor"] != DBNull.Value)
        //            {
        //                int id_cajero_receptor = (int)datareader["ID_Cajero_Receptor"];
        //                string nombre_cajero_receptor = (string)datareader["Nombre_Cajero_Receptor"];
        //                string primer_apellido_cajero = (string)datareader["Primer_Apellido_Cajero_Receptor"];
        //                string segundo_apellido_cajero = (string)datareader["Segundo_Apellido_Cajero_Receptor"];

        //                cajero_receptor = new Colaborador(id_cajero_receptor, nombre_cajero_receptor, primer_apellido_cajero, segundo_apellido_cajero);

        //            }
        //            Colaborador cajero_reasingado = null;

        //            if (datareader["ID_Cajero_Reasignado"] != DBNull.Value)
        //            {
        //                int id_cajero_reasingado = (int)datareader["ID_Cajero_Reasignado"];
        //                string nombre_cajero_reasingado = (string)datareader["Nombre_Cajero_Reasignado"];
        //                string primer_apellido_cajero_reasingado = (string)datareader["Primer_Apellido_Cajero_Reasignado"];
        //                string segundo_apellido_cajero_reasingado = (string)datareader["Segundo_Apellido_Cajero_Reasignado"];

        //                cajero_reasingado = new Colaborador(id_cajero_reasingado, nombre_cajero_reasingado, primer_apellido_cajero_reasingado, segundo_apellido_cajero_reasingado);

        //            }

        //            Colaborador receptor = new Colaborador(id_receptor, nombre_receptor, primer_apellido, segundo_apellido);
        //            EmpresaTransporte empresa = new EmpresaTransporte(nombre_empresa, id: id_empresa);
        //            Grupo grupo = new Grupo(id_grupo, nombre_grupo);

        //            Manifiesto manifiesto = new Manifiesto(codigo, id: id_manifiesto, grupo: grupo, caja: caja, empresa: empresa,
        //                                                   area: area, receptor: receptor, fecha_recepcion: fecha_recepcion,
        //                                                   fecha_recoleccion: fecha_recoleccion, retraso: retraso, cajero_receptor: cajero_receptor);

        //            manifiesto.Cajero_Reasignado = cajero_reasingado;
        //            manifiesto.Area = area;
        //            manifiestos.Add(manifiesto);
        //        }

        //        comando.Connection.Close();
        //    }
        //    catch (Exception)
        //    {
        //        comando.Connection.Close();
        //        throw new Excepcion("ErrorDatosConexion");
        //    }

        //    return manifiestos;
        //}

        #endregion Métodos Públicos
    }
}
