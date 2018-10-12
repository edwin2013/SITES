//
//  @ Project : 
//  @ File Name : SupervisionBL.cs
//  @ Date : 24/08/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Data;

using CommonObjects;
using CommonObjects.Graficos;
using DataLayer;
using LibreriaMensajes;

namespace BussinessLayer
{

    public class SupervisionBL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static SupervisionBL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static SupervisionBL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SupervisionBL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ReportesDL _reportes = ReportesDL.Instancia;
        private CategoriasReportesDL _categorias_reportes = CategoriasReportesDL.Instancia;
        private ParametrosDL _parametros = ParametrosDL.Instancia;
        private RegistrosHorasExtraDL _horas_extra = RegistrosHorasExtraDL.Instancia;

        #endregion Atributos

        #region Constructor

        public SupervisionBL() { }

        #endregion Constructor

        #region Métodos Públicos

        #region Registros de Horas Extra

        /// <summary>
        /// Agregar un registro de horas extra en la base de datos.
        /// </summary>
        /// <param name="r">Objeto RegistroHorasExtra con los datos del registro</param>
        public void agregarRegistroHorasExtra(ref RegistroHorasExtra r)
        {

            try
            {
                if (_horas_extra.verificarRegistroHorasExtra(r))
                    throw new Excepcion("ErrorRegistroHorasExtraDuplicado");

                _horas_extra.agregarRegistroHorasExtra(ref r);

                foreach (Motivos motivo in r.Motivos)
                    _horas_extra.agregarMotivoRegistroHorasExtra(r, motivo);

                foreach (Puestos puesto in r.Puestos)
                    _horas_extra.agregarPuestoRegistroHorasExtra(r, puesto);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar los datos de un registro de horas extra.
        /// </summary>
        /// <param name="r">Objeto RegistroHorasExtra con los datos del registro a actualizar</param>
        public void actualizarRegistroHorasExtra(RegistroHorasExtra r)
        {

            try
            {
                if (_horas_extra.verificarRegistroHorasExtra(r))
                    throw new Excepcion("ErrorRegistroHorasExtraDuplicado");

                _horas_extra.actualizarRegistroHorasExtra(r);

                // Desligar los motivos y puestos anteriores del registro y agregar los nuevos

                RegistroHorasExtra anterior = new RegistroHorasExtra(r.Id);

                _horas_extra.obtenerMotivosRegistroHorasExtra(ref anterior);
                _horas_extra.obtenerPuestosRegistroHorasExtra(ref anterior);

                foreach (Motivos motivo in r.Motivos)
                {

                    if (anterior.Motivos.Contains(motivo))
                        anterior.quitarMotivo(motivo);
                    else
                        _horas_extra.agregarMotivoRegistroHorasExtra(r, motivo);

                }

                foreach (Motivos motivo in anterior.Motivos)
                    _horas_extra.eliminarMotivoRegistroHorasExtra(r, motivo);

                foreach (Puestos puesto in r.Puestos)
                {

                    if (anterior.Puestos.Contains(puesto))
                        anterior.quitarPuesto(puesto);
                    else
                        _horas_extra.agregarPuestoRegistroHorasExtra(r, puesto);

                }

                foreach (Puestos puesto in anterior.Puestos)
                    _horas_extra.eliminarPuestoRegistroHorasExtra(r, puesto);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar un registro de horas extra marcándolo como aprobado.
        /// </summary>
        /// <param name="r">Objeto RegistroHorasExtra con los datos del egistro a actualizar</param>
        public void actualizarRegistroHorasExtraAprobar(ref RegistroHorasExtra r)
        {

            try
            {
                r.Estado = Estados.Aprobado;

                _horas_extra.actualizarRegistroHorasExtraAprobar(r);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualizar un registro de horas extra marcándolo como rechazado.
        /// </summary>
        /// <param name="r">Objeto RegistroHorasExtra con los datos del registro a actualizar</param>
        /// <param name="s">Objeto Supervisor con los datos del supervisor que desaprueba el registro</param>
        /// <param name="c">Comentario relacionado con el rechazo</param>
        public void actualizarRegistroHorasExtraRechazar(ref RegistroHorasExtra r, Colaborador s, string c)
        {

            try
            {
                r.Estado = Estados.Rechazado;

                _horas_extra.actualizarRegistroHorasExtraRechazar(r, s, c);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Eliminar los datos de un registro de horas extra.
        /// </summary>
        /// <param name="r">Objeto RegistroHorasExtra con los datos del egistro a eliminar</param>
        public void eliminarRegistroHorasExtra(RegistroHorasExtra r)
        {

            try
            {
                _horas_extra.eliminarRegistroHorasExtra(r);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todos los registros de horas extra para todos los colaboradores de un area determinada en un periodo de tiempo determinado.
        /// </summary>
        /// <param name="a">Área para la cual se genera la lista</param>
        /// <param name="i">Fecha inicial del periodo de tiempo</param>
        /// <param name="f">Fecha final del periodo de tiempo</param>
        /// <returns>Lista de registros de horas extra incluidos en el sistema</returns>
        public BindingList<RegistroHorasExtra> listarRegistrosHorasExtra(Areas a, DateTime i, DateTime f)
        {

            try
            {
                BindingList<RegistroHorasExtra> registros = _horas_extra.listarRegistrosHorasExtra(a, i, f);

                foreach (RegistroHorasExtra registro in registros)
                {
                    RegistroHorasExtra copia = registro;

                    _horas_extra.obtenerMotivosRegistroHorasExtra(ref copia);
                    _horas_extra.obtenerPuestosRegistroHorasExtra(ref copia);
                }

                return registros;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Listar todos los registros de horas extra para un colaborador específico en un periodo de tiempo determinado.
        /// </summary>
        /// <param name="c">Colaborador para el cual se genera la lista</param>
        /// <param name="i">Fecha inicial del periodo de tiempo</param>
        /// <param name="f">Fecha final del periodo de tiempo</param>
        /// <returns>Lista de registros de horas extra incluidos en el sistema</returns>
        public BindingList<RegistroHorasExtra> listarRegistrosHorasExtraColaborador(Colaborador c, DateTime i, DateTime f)
        {

            try
            {
                BindingList<RegistroHorasExtra> registros = _horas_extra.listarRegistrosHorasExtraColaborador(c, i, f);

                foreach (RegistroHorasExtra registro in registros)
                {
                    RegistroHorasExtra copia = registro;

                    _horas_extra.obtenerMotivosRegistroHorasExtra(ref copia);
                    _horas_extra.obtenerPuestosRegistroHorasExtra(ref copia);
                }

                return registros;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Registros de Horas Extra

        #region Reportes

        /// <summary>
        /// Listar todas la categoría de reportes del sistema a las que tiene acceso un colaborador.
        /// </summary>
        /// <param name="c">Colaborador para el cuals e genera la lista</param>
        /// <returns>Una lista de todas las categorías de reportes</returns>
        public BindingList<CategoriaReporte> listarCategoriasReportes(Colaborador c)
        {

            try
            {
                BindingList<CategoriaReporte> categorias = _categorias_reportes.listarCategoriasReportes();

                foreach (CategoriaReporte categoria in categorias)
                {
                    CategoriaReporte copia = categoria;

                    _categorias_reportes.obtenerReportesCategoria(ref copia, c);

                    foreach (Reporte reporte in categoria.Reportes)
                    {
                        Reporte copia_reporte = reporte;

                        _reportes.obtenerParametrosReporte(ref copia_reporte);
                        _reportes.obtenerGraficosBoxplot(ref copia_reporte);
                        _reportes.obtenerGraficosHistograma(ref copia_reporte);
                        _reportes.obtenerGraficosBarra(ref copia_reporte);
                        _reportes.obtenerGraficosBarraLinea(ref copia_reporte);
                        _reportes.obtenerGraficosPie(ref copia_reporte);
                    }

                }

                return categorias;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener la lista de elementos de una tabla.
        /// </summary>
        /// <param name="parametro">Parametro para el cual se busca obtener la lista de valores</param>
        public DataTable obtenerListaParametro(Parametro p)
        {

            try
            {
                return _parametros.obtenerListaParametro(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los datos de la consulta.
        /// </summary>
        /// <param name="i">Fecha incial para la cual se desea delimitar la consulta</param>
        /// <param name="f">Fecha final para la cual se desea delimitar la consulta</param>
        /// <param name="a">Área para la cual se genera el reporte</param>
        public DataTable obtenerDatosReporte(DateTime i, DateTime f, Areas a, Reporte r)
        {

            try
            {
                return _reportes.obtenerDatosReporte(i, f, a, r);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Obtener los datos de una consulta para la generación de un gráfico asociado a un reporte.
        /// </summary>
        /// <param name="i">Fecha incial para la cual se desea delimitar la consulta asociada al gráfico</param>
        /// <param name="f">Fecha final para la cual se desea delimitar la consulta asociada al gráfico</param>
        /// <param name="a">Área para la cual se genera el gráfico</param>
        /// <param name="g">Gráfico para el cual se ejecuta la consulta</param>
        /// <param name="r">Reporte al cual está asociado el gráfico</param>
        /// <returns>Tabla con los datos devueltos por la consulta</returns>
        public DataTable obtenerDatosGrafico(DateTime i, DateTime f, Areas a, Grafico g, Reporte r)
        {

            try
            {
                return _reportes.obtenerDatosGrafico(i, f, a, g, r);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Reportes

        #endregion Métodos Públicos

    }

}
