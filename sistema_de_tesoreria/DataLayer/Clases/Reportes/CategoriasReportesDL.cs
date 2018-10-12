//
//  @ Project : 
//  @ File Name : CategoriasReportesDL.cs
//  @ Date : 18/02/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using CommonObjects.Graficos;
using LibreriaAccesoDatos;
using LibreriaMensajes;

namespace DataLayer
{

    public class CategoriasReportesDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CategoriasReportesDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CategoriasReportesDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CategoriasReportesDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public CategoriasReportesDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Listar todas la categoría de reportes del sistema a las que tiene acceso un colaborador.
        /// </summary>
        /// <returns>Una lista de todas las categorías de reportes</returns>
        public BindingList<CategoriaReporte> listarCategoriasReportes()
        {
            BindingList<CategoriaReporte> categorias = new BindingList<CategoriaReporte>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCategoriasReportes");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];

                    CategoriaReporte categoria = new CategoriaReporte(id, nombre);

                    categorias.Add(categoria);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return categorias;
        }

        /// <summary>
        /// Obtener los reportes pertenecientes a una categoría.
        /// </summary>
        /// <param name="c">Categoría para la cual se genera la lista</param>
        public void obtenerReportesCategoria(ref CategoriaReporte c, Colaborador co)
        {
            SqlDataReader datareader = null;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectReportePuestoPerfil");

            _manejador.agregarParametro(comando, "@colaborador", co.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@categoria", c.ID, SqlDbType.TinyInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    string nombre = (string)datareader["Nombre"];
                    string descripcion = (string)datareader["Descripcion"];
                    string procedimiento = (string)datareader["Procedimiento"];
                    bool filtro_fechas = (bool)datareader["Filtro_Fechas"];

                    Reporte reporte = new Reporte(id, nombre, descripcion, procedimiento, filtro_fechas);

                    c.agregarReporte(reporte);
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
