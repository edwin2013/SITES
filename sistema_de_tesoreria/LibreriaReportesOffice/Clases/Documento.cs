//
//  @ Project : 
//  @ File Name : Documento.cs
//  @ Date : 19/01/2011
//  @ Author : Erick Chavarría 
//

using System.Drawing;

namespace LibreriaReportesOffice
{

    public enum AlineacionVertical : byte
    {
        Centro = 1,
        Arriba = 2,
        Abajo = 3,
        Justificado = 4,
        Distribuido = 5
    }

    public enum AlineacionHorizontal : byte
    {
        Centro = 1,
        Izquierda = 2,
        Derecha = 3,
        Lleno = 4,
        Justificado = 5,
        Distribuido = 6,
        General = 7
    }

    public enum Orientacion : byte
    {
        Vertical = 1,
        Horizontal = 2,
    }


    /// <summary>
    /// Clase que se representa una columna de un archivo excel.
    /// </summary>
    public class Celda
    {

        #region Atributos

        private int _fila = 0;

        public int Fila
        {
            get { return _fila; }
            set { _fila = value; }
        }

        private int _columna = 0;

        public int Columna
        {
            get { return _columna; }
            set { _columna = value; }
        }

        private string _valor = null;

        public string Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        private string _formula = null;

        public string Formula
        {
            get { return _formula; }
            set { _formula = value; }
        }

        private string _texto = null;

        public string Texto
        {
            get { return _texto; }
            set { _texto = value; }
        }

        public string _direccion;

        public string Direccion
        {
            get { return this.obtenerDireccion(); }
        }

        #endregion Atributos

        #region  Constructor

        public Celda(int fila, int columna, object valor, object formula, object texto)
        {
            _fila = fila;
            _columna = columna;
            _valor = valor == null ? string.Empty : valor.ToString();
            _formula = formula == null ? string.Empty : formula.ToString();
            _texto = texto == null ? string.Empty : texto.ToString();
        }

        #endregion Constructor

        #region Métodos Privados

        private string obtenerDireccion()
        {

            return string.Empty;
        }

        #endregion Métodos Privados

        #region Overrides

        public override string ToString()
        {
            return _valor;
        }

        #endregion Overrides

    }

    /// <summary>
    /// Clase abstracta para los documentos de Excel y Calc
    /// </summary>
    public abstract class Documento
    {

        #region Métodos Abstractos

        #region Manejo de Hojas

        /// <summary>
        /// Agregar una hoja a un libro.
        /// <param name="nombre">Nombre de la hoja a agregar</param>
        /// </summary>
        public abstract void agregarHoja(string nombre);

        /// <summary>
        /// Seleccionar una determinada hoja de un libro de un archivo de excel.
        /// <param name="hoja">Número de hoja a seleccionar</param>
        /// </summary>
        public abstract void seleccionarHoja(int hoja);

        /// <summary>
        /// Seleccionar una determinada hoja de un libro de un archivo de excel.
        /// <param name="hoja">Nombre de la hoja a seleccionar</param>
        /// </summary>
        public abstract void seleccionarHoja(string hoja);

        /// <summary>
        /// Cambiar el color de la pestaña de la hoja seleccionada.
        /// <param name="color">Color que se asignará a la pestaña de la hoja seleccionada</param>
        /// </summary>
        public abstract void cambiarColorHoja(Color color);

        /// <summary>
        /// Duplicar la hoja seleccionada.
        /// <param name="nombre">Nombre de la nueva hoja</param>
        /// </summary>
        public abstract void duplicarHoja(string nombre);

        #endregion Manejo de Hojas

        #region Manejo de Celdas

        /// <summary>
        /// Seleccionar una celda.
        /// <param name="fila">Fila del la celda</param>
        /// <param name="columna">Columna del la celda</param>
        /// <returns>Celda seleccionada</returns>
        /// </summary>
        public abstract Celda seleccionarCelda(int fila, int columna);

        /// <summary>
        /// Seleccionar una celda de la hoja de cálculo.
        /// <param name="celda">Nombre de la celda a seleccionar</param>
        /// <returns>Celda seleccionada</returns>
        /// </summary>
        public abstract Celda seleccionarCelda(string celda);

        /// <summary>
        /// Seleccionar una segunda celda.
        /// <param name="fila">Fila del la celda</param>
        /// <param name="columna">Columna del la celda</param>
        /// </summary>
        public abstract void seleccionarSegundaCelda(int fila, int columna);

        /// <summary>
        /// Seleccionar una segunda celda.
        /// <param name="celda">Nombre de la celda a seleccionar</param>
        /// </summary>
        public abstract void seleccionarSegundaCelda(string celda);

        /// <summary>
        /// Cambiar el valor de la celda seleccionada.
        /// <param name="valor">Valor que se asignará a la celda</param>
        /// </summary>
        public abstract void actualizarValorCelda(object valor);

        /// <summary>
        /// Cambiar la fórmula de la celda seleccionada.
        /// <param name="formula">Fórmula que se asignará a la celda</param>
        /// </summary>
        public abstract void actualizarFormulaCelda(string formula);

        /// <summary>
        /// Copiar los valores de la celda seleccionada.
        /// </summary>
        public abstract void copiarValoresCelda();

        /// <summary>
        /// Pegar una formula de la celda seleccionada.
        /// </summary>
        public abstract void pegarFormula();

        /// <summary>
        /// Pegar los datos de una celda o celdas seleccionadas.
        /// </summary>
        public abstract void pegarValoresCelda();

        #endregion Manejo de Celdas

        #region Manejo de Tablas

        /// <summary>
        /// Agregar una tabla al Documento.
        /// <param name="tabla">DataTable que contiene los datos con los cuales se poblará la tabla</param>
        /// </summary>
        public abstract void actualizarValoresTabla(System.Data.DataTable tabla);

        /// <summary>
        /// Seleccionar una tabla completa a partir de la celda seleccionada.
        /// </summary>
        public abstract void seleccionarTabla();

        /// <summary>
        /// Seleccionar la columna completa de una tabla a partir de la celda seleccionada.
        /// <returns>Número de la última fila de la columna</returns>
        /// </summary>
        public abstract int seleccionarColumnaTabla();

        /// <summary>
        /// Seleccionar la fila completa de una tabla a partir de la celda seleccionada.
        /// <returns>Número de la última columna de la fila</returns>
        /// </summary>
        public abstract int seleccionarFilaTabla();

        /// <summary>
        /// Crear una tabla pivot.
        /// <param name="hoja_tabla">Número de la hoja a la que se agregará la tabla pivot</param>
        /// <param name="nombre_campo_fila">Nombre del campo de fila</param>
        /// <param name="nombre_campo_datos">Nombre del campo de datos</param>
        /// </summary>
        public abstract void crearTablaPivot(string hoja_tabla, string nombre_campo_fila, string nombre_campo_datos);

        #endregion Manejo de Tablas

        #region Manejo de Filas y Columnas

        /// <summary>
        /// Seleccionar una fila completa.
        /// </summary>
        public abstract void seleccionarFila();

        /// <summary>
        /// Cambiar el tamaño de la fila de la celda seleccionada.
        /// <param name="tamano">Tamaño de la fila</param>
        /// </summary>
        public abstract void cambiarTamanoFila(int tamano);

        /// <summary>
        /// Autoajustar el tamaño de la filas de la celdas seleccionadas.
        /// </summary>
        public abstract void autoajustarTamanoFilas();

        /// <summary>
        /// Seleccionar la columna completa de la celda seleccionada.
        /// </summary>
        public abstract void seleccionarColumna();

        /// <summary>
        /// Cambiar el tamaño de la columna de la celda seleccionada.
        /// <param name="tamano">Tamaño de la columna</param>
        /// </summary>
        public abstract void cambiarTamanoColumna(int tamano);

        /// <summary>
        /// Autoajustar el tamaño de la columnas de las celdas seleccionadas.
        /// </summary>
        public abstract void autoajustarTamanoColumnas();

        /// <summary>
        /// Seleccionar una columna completa.
        /// </summary>
        public abstract void agregarColuma(int posicion);

        #endregion Manejo de Filas

        #region Formato

        /// <summary>
        /// Cambiar la fuente de la celda seleccionada.
        /// <param name="cursiva">Valor que indica si para el texto de las celdas seleccionadas se utilizará letra cursiva</param>
        /// <param name="subrayado">Valor que indica si el texto de las celdas seleccionadas se subrayará</param>
        /// <param name="negrita">Valor que indica si para el texto de las celdas seleccionadas se utilizará fuente en negrita</param>
        /// <param name="tamano">tamaño de la fuente</param> 
        /// <param name="color_fondo">Color de fondo que se aplicará a las celdas seleccionadas</param>
        /// <param name="color_fuente">Color de la fuente de las celdas seleccionadas</param>
        /// </summary>
        public abstract void formatoCelda(bool cursiva = false,
                                          bool subrayado = false,
                                          bool negrita = false,
                                          int? tamano = null,
                                          Color? color_fuente = null,
                                          Color? color_fondo = null);

        /// <summary>
        /// Dar formato de tabla a los valores de la hoja.
        /// </summary>
        /// <param name="bordes_internos">Valor que indica si se deben mostrar los bordes internos</param>
        public abstract void formatoTabla(bool bordes_internos);

        /// <summary>
        /// Especificar el formato de datos de la celda seleccionada.
        /// <param name="formato">Cadena de texto que especifica el formato de los datos</param>
        /// </summary>
        public abstract void formatoCeldaTipoDatos(string formato);

        /// <summary>
        /// Consolidar las celdas seleccionadas.
        /// </summary>
        /// <param name="alineacion">Alineación de las celdas consolidadas</param>
        public abstract void ajustarCeldas(AlineacionHorizontal alineacion);

        /// <summary>
        /// Definir si se da un ajuste de linea en las celdas seleccionadas.
        /// <param name="ajuste">Valor que determina si de da un ajuste de linea en las celdas</param>
        /// </summary>
        public abstract void cambiarAjusteLinea(bool ajuste);

        /// <summary>
        /// Cambiar la alineación del texto de las celdas seleccionadas.
        /// <param name="vertical">Alineación vertical</param>
        /// <param name="horizontal">Alineación horizontal</param>
        /// </summary>
        public abstract void cambiarAlineacionTexto(AlineacionVertical vertical, AlineacionHorizontal horizontal);

        #endregion Formato

        #region Impresión

        /// <summary>
        /// Definir las celdas seleccionadas como el área de impresión del archivo.
        /// </summary>
        public abstract void definirAreaImpresion();

        /// <summary>
        /// Definir las opciones de impresión del documento.
        /// <param name="orientacion">Orientacion del documento</param>
        /// <param name="ajuste_pagina">Valor que indica si se deben ajustar los datos a una sola página</param>
        /// </summary>
        public abstract void definirOpcionesimpresionImpresion(Orientacion orientacion, bool ajuste_pagina);

        #endregion Impresión

        #region Manejo del Archivo

        /// <summary>
        /// Muestra el documento.
        /// </summary>
        public abstract void mostrar();

        /// <summary>
        /// Cerrar el libro.
        /// <returns>Valor que indica si el libro se cerro correctamente.</returns>
        /// </summary>
        public abstract bool cerrar();

        /// <summary>
        /// Imprimir la hora seleccionada.
        /// </summary>
        public abstract void imprimir();

        #endregion Manejo del Archivo

        #endregion Métodos Abstractos

    }

}
