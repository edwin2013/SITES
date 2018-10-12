//
//  @ Project : 
//  @ File Name : DocumentoExcel.cs
//  @ Date : 19/01/2011
//  @ Author : Erick Chavarría 
//

using System;

using Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Reflection;

namespace LibreriaReportesOffice
{

    /// <summary>
    /// Clase que se encarga de la creación de reportes utilizando Microsoft Excel.
    /// </summary>
    public class DocumentoExcel : Documento
    {

        #region Atributos

        private Object _missing = Missing.Value;

        private Application _instancia_excel = new Application();

        private Range _seleccionado = null;

        protected Worksheet _hoja;

        public Worksheet Hoja
        {
            get { return _hoja; }
        }

        protected Workbook _libro;

        public Workbook Libro
        {
            get { return _libro; }
        }

        protected Celda _primera_celda = null;

        public Celda Primera_Celda
        {
            get { return _primera_celda; }
        }

        protected Celda _segunda_celda = null;

        public Celda Segunda_Celda
        {
            get { return _segunda_celda; }
        }

        #endregion Atributos

        #region Constructor

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public DocumentoExcel()
        {

            try
            {
                this.ajustarLenguaje();

                //Crear los objetos

                _libro = _instancia_excel.Workbooks.Add(_missing);

                _instancia_excel.DisplayAlerts = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Constructor de la clase.
        /// <param name="archivo">Ubicacion del archivo excel</param>
        /// <param name="solo_lectura">Valor que indica si el archivo se va a abrir en modo de solo lectura</param>
        /// </summary>
        public DocumentoExcel(string archivo, bool solo_lectura)
        {

            try
            {
                this.ajustarLenguaje();

                //Crear los objetos

                _libro = _instancia_excel.Workbooks.Open(archivo, 0, solo_lectura, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                _instancia_excel.DisplayAlerts = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Ajustar el lenjuague de la aplicación para evitar conflictos con la versión de Office
        /// </summary>
        private void ajustarLenguaje()
        {

            try
            {
                System.Globalization.CultureInfo cultura;
                System.Globalization.CultureInfo anterior;

                //Cambiar la configuracion de cultura a la configuración del la librería de office

                Microsoft.Office.Core.MsoAppLanguageID id_lenguaje = Microsoft.Office.Core.MsoAppLanguageID.msoLanguageIDUI;

                anterior = System.Threading.Thread.CurrentThread.CurrentCulture;
                cultura = new System.Globalization.CultureInfo(_instancia_excel.LanguageSettings.get_LanguageID(id_lenguaje));
                System.Threading.Thread.CurrentThread.CurrentCulture = cultura;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Métodos

        #region Manejo de Hojas

        /// <summary>
        /// Copiar una hoja en otro libro.
        /// <param name="documento">Libro en el que se copiará la hoja</param>
        /// <param name="celda">Nombre de la celda en la que se copiarán los datos</param>
        /// </summary>
        public void copiarHojaALibro(DocumentoExcel documento)
        {

            try
            {
                _hoja.Cells.Copy();

                documento.Hoja.Paste();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Agregar una hoja a un libro.
        /// <param name="nombre">Nombre de la hoja a agregar</param>
        /// </summary>
        public override void agregarHoja(string nombre)
        {
            Worksheet hoja = (Worksheet)_libro.Worksheets.Add();

            hoja.Name = nombre;
        }

        /// <summary>
        /// Seleccionar una determinada hoja de un libro de un archivo de excel.
        /// <param name="hoja">Número de hoja a seleccionar</param>
        /// </summary>
        public override void seleccionarHoja(int hoja)
        {
            _hoja = (Worksheet)_libro.Worksheets[hoja];
        }

        /// <summary>
        /// Seleccionar una determinada hoja de un libro de un archivo de excel.
        /// <param name="hoja">Nombre de la hoja a seleccionar</param>
        /// </summary>
        public override void seleccionarHoja(string hoja)
        {
            _hoja = (Worksheet)_libro.Worksheets[hoja];
        }

        /// <summary>
        /// Cambiar el color de la pestaña de la hoja seleccionada.
        /// <param name="color">Color que se asignará a la pestaña de la hoja seleccionada</param>
        /// </summary>
        public override void cambiarColorHoja(Color color)
        {
            _hoja.Tab.Color = color.ToArgb();
        }

        /// <summary>
        /// Duplicar la hoja seleccionada.
        /// <param name="nombre">Nombre de la nueva hoja</param>
        /// </summary>
        public override void duplicarHoja(string nombre)
        {
            _hoja.Copy(_hoja);

            _hoja.Name = nombre;
        }

        #endregion Manejo de Hojas

        #region Manejo de Celdas

        /// <summary>
        /// Seleccionar una celda.
        /// <param name="fila">Fila del la celda a modificar</param>
        /// <param name="columna">Columna del la celda</param>
        /// <returns>Celda seleccionada</returns>
        /// </summary>
        public override Celda seleccionarCelda(int fila, int columna)
        {
            _seleccionado = (Range)_hoja.Cells[fila, columna];
            _primera_celda = new Celda(_seleccionado.Row, _seleccionado.Column, _seleccionado.Value2, _seleccionado.Formula, _seleccionado.Text);

            return _primera_celda;
        }

        /// <summary>
        /// Seleccionar una celda de la hoja de cálculo.
        /// <param name="celda">Nombre de la celda a seleccionar</param>
        /// <returns>Celda seleccionada</returns>
        /// </summary>
        public override Celda seleccionarCelda(string celda)
        {
            _seleccionado = (Range)_hoja.get_Range(celda, celda);
            _primera_celda = new Celda(_seleccionado.Row, _seleccionado.Column, _seleccionado.Value2, _seleccionado.Formula, _seleccionado.Text);

            return _primera_celda;
        }

        /// <summary>
        /// Seleccionar una segunda celda.
        /// <param name="fila">Fila del la celda</param>
        /// <param name="columna">Columna del la celda</param>
        /// </summary>
        public override void seleccionarSegundaCelda(int fila, int columna)
        {
            Range segunda_seleccion = (Range)_hoja.Cells[fila, columna];

            _segunda_celda = new Celda(segunda_seleccion.Row, segunda_seleccion.Column, segunda_seleccion.Value2,
                                       segunda_seleccion.Formula, segunda_seleccion.Text);

            _seleccionado = (Range)_hoja.get_Range(_seleccionado, segunda_seleccion);
        }

        /// <summary>
        /// Seleccionar una segunda celda.
        /// <param name="celda">Nombre de la celda a seleccionar</param>
        /// </summary>
        public override void seleccionarSegundaCelda(string celda)
        {
            Range segunda_seleccion = (Range)_hoja.get_Range(celda, celda);

            _segunda_celda = new Celda(segunda_seleccion.Row, segunda_seleccion.Column, segunda_seleccion.Value2,
                                       segunda_seleccion.Formula, segunda_seleccion.Text);

            _seleccionado = (Range)_hoja.get_Range(_seleccionado, segunda_seleccion);
        }

        /// <summary>
        /// Cambiar el valor de la celda seleccionada.
        /// <param name="valor">Valor que se asignará a la celda</param>
        /// </summary>
        public override void actualizarValorCelda(object valor)
        {
            _seleccionado.Value2 = valor;
        }

        /// <summary>
        /// Cambiar la fórmula de la celda seleccionada.
        /// <param name="formula">Fórmula que se asignará a la celda</param>
        /// </summary>
        public override void actualizarFormulaCelda(string formula)
        {
            _seleccionado.FormulaLocal = formula;
        }

        /// <summary>
        /// Copiar los valores de la celda seleccionada.
        /// </summary>
        public override void copiarValoresCelda()
        {
            _seleccionado.Copy(_missing);
        }

        /// <summary>
        /// Pegar una formula de la celda seleccionada.
        /// </summary>
        public override void pegarFormula()
        {
            XlPasteType tipo = XlPasteType.xlPasteFormulasAndNumberFormats;
            XlPasteSpecialOperation operacion = XlPasteSpecialOperation.xlPasteSpecialOperationNone;

            _seleccionado.PasteSpecial(tipo, operacion, false, false);
        }

        /// <summary>
        /// Pegar los datos de una celda o celdas seleccionadas.
        /// </summary>
        public override void pegarValoresCelda()
        {
            XlPasteType tipo = XlPasteType.xlPasteAll;
            XlPasteSpecialOperation operacion = XlPasteSpecialOperation.xlPasteSpecialOperationNone;

            _seleccionado.PasteSpecial(tipo, operacion, false, false);
        }

        #endregion Manejo de Celdas

        #region Manejo de Tablas

        /// <summary>
        /// Agregar una tabla al Documento.
        /// <param name="tabla">DataTable que contiene los datos con los cuales se poblará la tabla</param>
        /// </summary>
        public override void actualizarValoresTabla(System.Data.DataTable tabla)
        {
            int total_filas = tabla.Rows.Count;
            int total_columnas = tabla.Columns.Count;
            object[,] valores = new object[total_filas, total_columnas];

            for (int pos_y = 0; pos_y < total_filas; pos_y++)
            {

                for (int pos_x = 0; pos_x < total_columnas; pos_x++)
                    valores[pos_y, pos_x] = tabla.Rows[pos_y].ItemArray[pos_x];

            }

            Range final = (Range)_hoja.Cells[_seleccionado.Row + tabla.Rows.Count - 1,
                                             _seleccionado.Column + tabla.Columns.Count - 1];


            _seleccionado = (Range)_hoja.get_Range(_seleccionado, final);

            _seleccionado.Value2 = valores;
        }

        /// <summary>
        /// Seleccionar una tabla completa a partir de la celda seleccionada.
        /// </summary>
        public override void seleccionarTabla()
        {
            int ultima_fila = _seleccionado.get_End(XlDirection.xlDown).Row;
            int ultima_columna = _seleccionado.get_End(XlDirection.xlToRight).Column;

            Range ultima_celda = (Range)_hoja.Cells[ultima_fila, ultima_columna];

            _seleccionado = _hoja.get_Range(_seleccionado, ultima_celda);
        }

        /// <summary>
        /// Seleccionar la columna completa de una tabla a partir de la celda seleccionada.
        /// <returns>Número de la última fila de la columna</returns>
        /// </summary>
        public override int seleccionarColumnaTabla()
        {
            int ultima_fila = _seleccionado.get_End(XlDirection.xlDown).Row;
            Range ultima_celda = (Range)_hoja.Cells[ultima_fila, _seleccionado.Column];

            _seleccionado = _hoja.get_Range(_seleccionado, ultima_celda);

            return ultima_fila;
        }

        /// <summary>
        /// Seleccionar la fila completa de una tabla a partir de la celda seleccionada.
        /// <returns>Número de la última columna de la fila</returns>
        /// </summary>
        public override int seleccionarFilaTabla()
        {

            int ultima_columna = _seleccionado.get_End(XlDirection.xlToRight).Column;
            Range ultima_celda = (Range)_hoja.Cells[_seleccionado.Row, ultima_columna];

            _seleccionado = _hoja.get_Range(_seleccionado, ultima_celda);

            return ultima_columna;
        }

        /// <summary>
        /// Crear una tabla pivot.
        /// <param name="hoja_tabla">Número de la hoja a la que se agregará la tabla pivot</param>
        /// <param name="nombre_campo_fila">Nombre del campo de fila</param>
        /// <param name="nombre_campo_datos">Nombre del campo de datos</param>
        /// </summary>
        public override void crearTablaPivot(string hoja_tabla, string nombre_campo_fila, string nombre_campo_datos)
        {
            XlPivotTableSourceType fuente = XlPivotTableSourceType.xlDatabase;
            XlPivotFieldOrientation orientacion_fila = XlPivotFieldOrientation.xlRowField;
            XlPivotFieldOrientation orientacion_datos = XlPivotFieldOrientation.xlDataField;

            // Crear la tabla pivot

            _hoja = (Worksheet)_libro.Worksheets[hoja_tabla];

            _hoja.PivotTableWizard(fuente, _seleccionado, _missing, "PivTab1");

            PivotTable tabla = (PivotTable)_hoja.PivotTables("PivTab1");
            PivotField campo_fila = ((PivotField)tabla.PivotFields(nombre_campo_fila));
            PivotField campo_datos = ((PivotField)tabla.PivotFields(nombre_campo_datos));

            campo_fila.Orientation = orientacion_fila;
            campo_datos.Orientation = orientacion_datos;
        }

        #endregion Manejo de Tablas

        #region Manejo de Filas y Columnas

        /// <summary>
        /// Seleccionar una fila completa.
        /// </summary>
        public override void seleccionarFila()
        {
            _seleccionado = _seleccionado.EntireRow;
        }

        /// <summary>
        /// Cambiar el tamaño de la fila de la celda seleccionada.
        /// <param name="tamano">Tamaño de la fila</param>
        /// </summary>
        public override void cambiarTamanoFila(int tamano)
        {
            _seleccionado.EntireRow.RowHeight = tamano;
        }

        /// <summary>
        /// Autoajustar el tamaño de las filas de las celdas seleccionadas.
        /// </summary>
        public override void autoajustarTamanoFilas()
        {
            _seleccionado.Rows.AutoFit();
        }     

        /// <summary>
        /// Seleccionar la columna completa de la celda seleccionada.
        /// </summary>
        public override void seleccionarColumna()
        {
            _seleccionado = _seleccionado.EntireColumn;
        }

        /// <summary>
        /// Cambiar el tamaño de la columna de la celda seleccionada.
        /// <param name="tamano">Tamaño de la columna</param>
        /// </summary>
        public override void cambiarTamanoColumna(int tamano)
        {
            _seleccionado.EntireColumn.ColumnWidth = tamano;
        }

        /// <summary>
        /// Autoajustar el tamaño de las columnas de las celdas seleccionadas.
        /// </summary>
        public override void autoajustarTamanoColumnas()
        {
            _seleccionado.Columns.AutoFit();
        }            

        /// <summary>
        /// Seleccionar una columna completa.
        /// </summary>
        public override void agregarColuma(int posicion)
        {
            ((Range)_hoja.Columns[posicion]).Insert(posicion);
        }

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
        public override void formatoCelda(bool cursiva = false,
                                          bool subrayado = false,
                                          bool negrita = false,
                                          int? tamano = null,
                                          Color? color_fuente = null,
                                          Color? color_fondo = null)
        {
            _seleccionado.Font.Italic = cursiva;
            _seleccionado.Font.Underline = subrayado;
            _seleccionado.Font.Bold = negrita;

            if (tamano != null) _seleccionado.Font.Size = (int)tamano;

            if (color_fuente != null)
            {
                int fuente = ColorTranslator.ToOle((Color)color_fuente);

                _seleccionado.Font.Color = fuente;
            }

            if (color_fondo != null)
            {
                int fondo = ColorTranslator.ToOle((Color)color_fondo);

                _seleccionado.Interior.Color = fondo;
            }

        }

        /// <summary>
        /// Dar formato de tabla a los valores de la hoja.
        /// </summary>
        /// <param name="bordes_internos">Valor que indica si se deben mostrar los bordes internos</param>
        public override void formatoTabla(bool bordes_internos)
        {
            XlLineStyle estilo = XlLineStyle.xlContinuous;
            XlBorderWeight ancho = XlBorderWeight.xlThin;
            XlColorIndex color = XlColorIndex.xlColorIndexAutomatic;

            if (bordes_internos)
            {
                _seleccionado.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = estilo;
                _seleccionado.Borders[XlBordersIndex.xlInsideHorizontal].Weight = ancho;

                _seleccionado.Borders[XlBordersIndex.xlInsideVertical].LineStyle = estilo;
                _seleccionado.Borders[XlBordersIndex.xlInsideVertical].Weight = ancho;
            }

            _seleccionado.BorderAround(estilo, ancho, color, Color.Black.ToArgb());
        }

        /// <summary>
        /// Especificar el formato de datos de la celda seleccionada.
        /// <param name="formato">Cadena de texto que especifica el formato de los datos</param>
        /// </summary>
        public override void formatoCeldaTipoDatos(string formato)
        {
            _seleccionado.NumberFormat = formato;
        }

        /// <summary>
        /// Consolidar las celdas seleccionadas.
        /// </summary>
        /// <param name="alineacion">Alineación de las celdas consolidadas</param>
        public override void ajustarCeldas(AlineacionHorizontal alineacion)
        {
            XlHAlign alineacion_horizontal = XlHAlign.xlHAlignJustify;

            switch (alineacion)
            {
                case AlineacionHorizontal.Izquierda:
                    alineacion_horizontal = XlHAlign.xlHAlignLeft;
                    break;
                case AlineacionHorizontal.Centro:
                    alineacion_horizontal = XlHAlign.xlHAlignCenter;
                    break;
            }

            _seleccionado.Merge(_missing);
            _seleccionado.HorizontalAlignment = alineacion_horizontal;
        }

        /// <summary>
        /// Definir si se da un ajuste de linea en las celdas seleccionadas.
        /// <param name="ajuste">Valor que determina si de da un ajuste de linea en las celdas</param>
        /// </summary>
        public override void cambiarAjusteLinea(bool ajuste)
        {
            _seleccionado.WrapText = ajuste;
        }

        /// <summary>
        /// Cambiar la alineación del texto de las celdas seleccionadas.
        /// <param name="vertical">Alineación vertical</param>
        /// <param name="horizontal">Alineación horizontal</param>
        /// </summary>
        public override void cambiarAlineacionTexto(AlineacionVertical vertical, AlineacionHorizontal horizontal)
        {

            XlVAlign alineacion_vertical = XlVAlign.xlVAlignBottom;
            XlHAlign alineacion_horizontal = XlHAlign.xlHAlignLeft;

            switch (vertical)
            {
                case AlineacionVertical.Centro: alineacion_vertical = XlVAlign.xlVAlignCenter; break;
                case AlineacionVertical.Arriba: alineacion_vertical = XlVAlign.xlVAlignTop; break;
                case AlineacionVertical.Abajo: alineacion_vertical = XlVAlign.xlVAlignBottom; break;
                case AlineacionVertical.Justificado: alineacion_vertical = XlVAlign.xlVAlignJustify; break;
                case AlineacionVertical.Distribuido: alineacion_vertical = XlVAlign.xlVAlignDistributed; break;
            }

            switch (horizontal)
            {
                case AlineacionHorizontal.Centro: alineacion_horizontal = XlHAlign.xlHAlignCenter; break;
                case AlineacionHorizontal.Izquierda: alineacion_horizontal = XlHAlign.xlHAlignLeft; break;
                case AlineacionHorizontal.Derecha: alineacion_horizontal = XlHAlign.xlHAlignRight; break;
                case AlineacionHorizontal.Lleno: alineacion_horizontal = XlHAlign.xlHAlignFill; break;
                case AlineacionHorizontal.Justificado: alineacion_horizontal = XlHAlign.xlHAlignJustify; break;
                case AlineacionHorizontal.Distribuido: alineacion_horizontal = XlHAlign.xlHAlignDistributed; break;
                case AlineacionHorizontal.General: alineacion_horizontal = XlHAlign.xlHAlignGeneral; break;
            }

            _seleccionado.VerticalAlignment = alineacion_vertical;
            _seleccionado.HorizontalAlignment = alineacion_horizontal;
        }

        #endregion Formato

        #region Impresión

        /// <summary>
        /// Definir las celdas seleccionadas como el área de impresión del archivo.
        /// </summary>
        public override void definirAreaImpresion() { }

        /// <summary>
        /// Definir las opciones de impresión del documento.
        /// <param name="orientacion">Orientacion del documento</param>
        /// <param name="ajuste_pagina">Valor que indica si se deben ajustar los datos a una sola página</param>
        /// </summary>
        public override void definirOpcionesimpresionImpresion(Orientacion orientacion, bool ajuste_pagina)
        {

            switch (orientacion)
            {
                case Orientacion.Vertical:
                    _hoja.PageSetup.Orientation = XlPageOrientation.xlPortrait;
                    break;
                case Orientacion.Horizontal:
                    _hoja.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                    break;
            }

            if (ajuste_pagina)
            {
                _hoja.PageSetup.Zoom = false;
                _hoja.PageSetup.FitToPagesWide = 1;
                _hoja.PageSetup.FitToPagesTall = 1;
                _hoja.PageSetup.CenterHorizontally = true;
                _hoja.PageSetup.CenterVertically = true;
            }

        }

        #endregion Impresión

        #region Manejo del Archivo

        /// <summary>
        /// Muestra el documento.
        /// </summary>
        public override void mostrar()
        {
            _instancia_excel.Visible = true;
        }

        /// <summary>
        /// Cerrar el libro.
        /// <returns>Valor que indica si el libro se cerro correctamente.</returns>
        /// </summary>
        public override bool cerrar()
        {

            try
            {
                _instancia_excel = null;
                _libro = null;
                _hoja = null;

                GC.Collect();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Imprimir la hora seleccionada.
        /// </summary>
        public override void imprimir()
        {
            _hoja.PrintOut();
        }

        /// <summary>
        /// Mostrar el cuadro de diálogo de impresión.
        /// </summary>
        public void mostrarDialogoImpresion()
        {
            _instancia_excel.Dialogs[XlBuiltInDialog.xlDialogPrint].Show();
        }

        #endregion Manejo del Archivo

        #region Manejo de objetos en Excel         

        public void llenarcuadrodetexto(string nombrecuadrotexto, string texto)
        {

            _hoja.Shapes.Item(nombrecuadrotexto).TextFrame.Characters(Type.Missing, Type.Missing).Text = texto;
        }
        //public void llenarcuadrodetexto(string nombrecuadrotexto, string texto)
        //{

        //    _hoja.Shapes.Item(nombrecuadrotexto).TextFrame.Characters(Type.Missing, Type.Missing).Text = texto;
        //}

        #endregion Manejo de Tablas en Excel
        
        #endregion Métodos
    }

}
