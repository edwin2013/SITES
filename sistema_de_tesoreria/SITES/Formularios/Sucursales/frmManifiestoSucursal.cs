using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using CommonObjects;
using LibreriaMensajes;
using CommonObjects.Clases;
using GUILayer.Formularios.Boveda;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using OnBarcode.Barcode;

namespace GUILayer.Formularios.Blindados
{
    public partial class frmManifiestoSucursal : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;

        private Colaborador _colaborador = null;

        private bool _coordinador = false;
        private bool _analista = false;
        private CargaSucursal _carga = new CargaSucursal();

        private static readonly BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);         //DEFINE UN TIPO DE FUENTE PARA ESCRIBIR EN EL DOCUMENTO
        BaseFont font2 = BaseFont.CreateFont(@"\\10.120.131.100\Releases\ConnectCode39.ttf", BaseFont.WINANSI, BaseFont.EMBEDDED);     //DEEFINE LA FUENTE PARA IMPRIMIR CODIGO DE BARRAS
        PdfContentByte _pcb;     // OBJETO QUE CONTIENE EL TEXTO DE USUARIO POSICIONADO Y EL CONTENIDO GRÁFICO DE LA PAGINA SOBRE LA QUE SE VA A TRABAJAR

        string montoenletras = "";

        #endregion Atributos

        #region Constructor

        public frmManifiestoSucursal(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;

           
                btnActualizar.Enabled = true;

            try
            {
                dgvCargas.AutoGenerateColumns = false;

               
                cboCanal.ListaMostrada = _mantenimiento.listarSucursales();
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime fecha = dtpFecha.Value;

                Sucursal sucursal = cboCanal.SelectedIndex == 0 ?
                    null : (Sucursal)cboCanal.SelectedItem;

                   byte? ruta = chkRuta.Checked ?
                    (byte?)nudRuta.Value : null;

                //ruta = Convert.ToByte(nudRuta.Value);
 
             
               // _coordinacion.ActualizarCargasSucursalesRoadnet(fecha);
                dgvCargas.DataSource = _coordinacion.listarCargasSucursalesManifiesto(_colaborador,sucursal, fecha, ruta, EstadoAprobacionCargas.Aprobada);
                btnRevisar.Enabled = true;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }


        /// <summary>
        /// Clic en el boton de visualizar el  maifiesto
        /// </summary>
        private void btnManifiesto_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow fila = dgvCargas.SelectedRows[0];
                _carga = (CargaSucursal)fila.DataBoundItem;
                
               //if (_coordinacion.verificarExisteCargaVerificada(_carga))
               //{
                foreach (ManifiestoSucursalCarga manifestito in _carga.Manifiesto)
                {
                    manifestito.Pedido = _carga;
                    ManifiestoSucursalCarga mani = manifestito;
                    CrearPDFSucursal(manifestito);

                }

                UnirPDF(_carga);
                frmVisualizarManifiesto visualizar = new frmVisualizarManifiesto(_carga);
                visualizar.ShowDialog();

               //}

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
     
        /// <summary>
        /// Clic en el botón de modificar.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostrarVentanaModificacion();
        }

        /// <summary>
        /// Clic en el botón de revisar.
        /// </summary>
        private void btnRevisar_Click(object sender, EventArgs e)
        {
            this.mostrarVentanaRevision();
        }

       
       

      
        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Doble clic en la lista de cargas.
        /// </summary>
        private void dgvCargas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                DataGridViewRow fila = dgvCargas.SelectedRows[0];
                CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;

                if (_coordinador)
                {
                        this.mostrarVentanaModificacion();
                }
                else
                {
                    this.mostrarVentanaRevision();
                }

            }

        }

        /// <summary>
        /// Se agrega una carga a la lista de cargas.
        /// </summary>
        private void dgvCargas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCargas.Rows[e.RowIndex + contador];
                CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;

                fila.Cells[Columna_Banco.Index].Value = carga.ToString();

                

                    if (carga.Modificada)
                        fila.DefaultCellStyle.BackColor = Color.Green;
                    else
                        fila.DefaultCellStyle.BackColor = Color.LightGreen;

              
            }

        }

        /// <summary>
        /// Se selecciona otra carga de la lista de cargas.
        /// </summary>
        private void dgvCargas_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCargas.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvCargas.SelectedRows[0];
                CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;

                btnRevisar.Enabled = true;
                btnManifiesto.Enabled = true;
                
              
            }
            else
            {
                btnRevisar.Enabled = false;

            }

        }

        /// <summary>
        /// Se marca o desmarca la opción de filtrar por ruta.
        /// </summary>
        private void chkRuta_CheckedChanged(object sender, EventArgs e)
        {
            nudRuta.Enabled = chkRuta.Checked;
        }

        #endregion Eventos
     
        #region Métodos Privados

        /// <summary>
        /// Mostrar la ventana de revisión de la carga.
        /// </summary>
        private void mostrarVentanaRevision()
        {
            CargaSucursal carga = (CargaSucursal)dgvCargas.SelectedRows[0].DataBoundItem;
            frmModificacionCargaSucursal formulario = new frmModificacionCargaSucursal(carga, _colaborador, true);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Mostrar la ventana de modificación de la carga.
        /// </summary>
        private void mostrarVentanaModificacion()
        {
            CargaSucursal carga = (CargaSucursal)dgvCargas.SelectedRows[0].DataBoundItem;
            frmModificacionCargaSucursal formulario = new frmModificacionCargaSucursal(carga, _colaborador, false);

            formulario.ShowDialog(this);

            carga.recalcularMontosCarga();

            dgvCargas.Refresh();
        }



        /// <summary>
        /// Crea PDF para las Cargas de las Sucursales
        /// </summary>
        /// <param name="carga">Objeto CargaSucursal con los datos de la Carga de la Sucursal</param>

        /// <summary>
        /// Crea PDF para las Cargas de Sucursales
        /// </summary>
        /// <param name="carga">Objeto ManifiestoSucursal con los datos de la Carga de la Sucursal</param>
        public void CrearPDFSucursal(ManifiestoSucursalCarga man)                  //Abre crear PDF Sucursal        
        {

            CargaSucursal carga = _carga;
            DateTime hoy = DateTime.Today;
            string actual = hoy.ToString("dd/MM/yyyy");
            string destinopdf = @"\\10.120.131.100\Manifiestos\SUC-" + man.ID.ToString() + ".pdf";          //DEFINE NOMBRE Y UBICACION DEL PDF QUE SE DESEA CREAR
            Stream output = new FileStream(destinopdf, FileMode.Create, FileAccess.Write);
            string plantilla = @"\\10.120.131.100\Releases\manifiesto5.pdf";          //DEFINE LA UBICACION Y EL NOMBRE DE LA PLANTILLA A USAR


            TipoCambio tip = null;
            tip = _mantenimiento.obtenerTipoCambio(dtpFecha.Value);
            int tipocambio = (int)tip.Venta;
            int tipocambioeuros = (int)tip.VentaEuros;
            PdfReader readerBicycle = null;
            iTextSharp.text.Rectangle pagesize = new iTextSharp.text.Rectangle(504, 580);
            Document documento = new Document(pagesize);
            FileStream theFile = new FileStream(plantilla, FileMode.Open, FileAccess.Read);
            PdfWriter writer = PdfWriter.GetInstance(documento, output);
            writer.SetEncryption(null, null, PdfWriter.ALLOW_PRINTING, PdfWriter.STRENGTH40BITS);
            documento.Open();
            readerBicycle = new PdfReader(theFile);
            PdfTemplate background = writer.GetImportedPage(readerBicycle, 1);
            documento.NewPage();

            string receptor = "";
            string emisor = "";

            iTextSharp.text.Image pic = null;

            iTextSharp.text.Image pic2 = null;

            if (carga.Tripulacion == null)
            {
                carga.Tripulacion = new Tripulacion();
            }

            string colaborador_recibo = "";

            if (carga.ColaboradorRecibidoBoveda != null)
            {
                colaborador_recibo = carga.ColaboradorRecibidoBoveda.ID.ToString();
            }

            if (File.Exists(@"\\10.120.9.20\Blindados\Firmas\atencionsucursales-tripulacion" + carga.Tripulacion.ID.ToString() +
            "-colaboradorentrega" + carga.Tripulacion.Portavalor.ID.ToString() + "-colaboradorrecibe" + colaborador_recibo + "-fecha" + carga.Fecha_asignada.Year.ToString() + carga.Fecha_asignada.Month.ToString() + carga.Fecha_asignada.Day.ToString("00") + ".jpg"))
            {



                if (carga.EntregaBovedaSucursal == EntregaRecibo.Entregas)
                {
                    receptor = @"\\10.120.9.20\Blindados\Firmas\atencionsucursales-tripulacion" + carga.Tripulacion.ID.ToString() + "-colaboradorrecibe" + carga.Tripulacion.Portavalor.ID.ToString() + "-colaboradorentrega" + colaborador_recibo + "-fecha" + carga.Fecha_asignada.Year.ToString() + carga.Fecha_asignada.Month.ToString("00") + carga.Fecha_asignada.Day.ToString("00") + ".jpg";
                    emisor = @"\\10.120.9.20\Blindados\Firmas\atencionsucursales-tripulacion" + carga.Tripulacion.ID.ToString() + "-colaboradorrecibe" + colaborador_recibo + "-colaboradorentrega" + carga.Tripulacion.Portavalor.ID.ToString() + "-fecha" + carga.Fecha_asignada.Year.ToString() + carga.Fecha_asignada.Month.ToString("00") + carga.Fecha_asignada.Day.ToString("00") + ".jpg";
                }
                else
                {
                    receptor = @"\\10.120.9.20\Blindados\Firmas\atencionsucursales-tripulacion" + carga.Tripulacion.ID.ToString() + "-colaboradorrecibe" + carga.Tripulacion.Portavalor.ID.ToString() + "-colaboradorentrega" + colaborador_recibo + "-fecha" + carga.Fecha_asignada.Year.ToString() + carga.Fecha_asignada.Month.ToString("00") + carga.Fecha_asignada.Day.ToString("00") + ".jpg";
                    emisor = @"\\10.120.9.20\Blindados\Firmas\atencionsucursales-tripulacion" + carga.Tripulacion.ID.ToString() + "-colaboradorrecibe" + colaborador_recibo + "-colaboradorentrega" + carga.Tripulacion.Portavalor.ID.ToString() + "-fecha" + carga.Fecha_asignada.Year.ToString() + carga.Fecha_asignada.Month.ToString("00") + carga.Fecha_asignada.Day.ToString("00") + ".jpg";
                }


                pic = iTextSharp.text.Image.GetInstance(receptor);

                pic2 = iTextSharp.text.Image.GetInstance(emisor);


                pic.ScaleAbsolute(75, 45);
                pic.SetAbsolutePosition(411, 440);
                documento.Add(pic);


                // receptor
                pic2.ScaleAbsolute(75, 35);
                pic2.SetAbsolutePosition(411, 120);
                documento.Add(pic2);

            }

            _pcb = writer.DirectContentUnder;
            _pcb.AddTemplate(background, 0, 0);
            _pcb = writer.DirectContent;
            _pcb.BeginText();





            //pic2.ScaleAbsolute(75, 45);
            //pic2.SetAbsolutePosition(411, 330);
            //documento.Add(pic2);





            //_pcb = writer.DirectContentUnder;
            //_pcb.AddTemplate(background, 0, 0);
            //_pcb = writer.DirectContent;
            //_pcb.BeginText();


            TipoCambio t = _mantenimiento.obtenerTipoCambio(dtpFecha.Value);

            //_pcno me diab = writer.DirectContentUnder;
            //_pcb.AddTemplate(background, 0, 0);
            //_pcb = writer.DirectContent;
            //_pcb.BeginText();

            SetFontBarCode(8);                   //ESTABLECE LA FUENTE E IMPRIME CON LA FUENTE BARCODE HASTA SER CAMBIADA
            PrintText("*" + man.ID.ToString() + "*", 335, 561);      //Imprime codigo de barras
            SetFont(13);
            PrintText("No: SUC-" + man.ID.ToString(), 335, 550);       //Imprime numero de manifiesto
            SetFont(8);                   //CAMBIAMOS LA FUENTE

            //montoLetrasPdf(montoenletras);   //Imprime monto total en letras y valida el tamaño

            PrintText(t.Venta.ToString("N0") + "/" + t.VentaEuros.ToString("N0"), 300, 525); //Imprime tipo de cambio
            PrintText(carga.Cartuchos.Count.ToString(), 360, 525); //Cantidad depositos
            PrintText("1", 440, 525); //Imprime cantidad de manifiestos


            //LADO IZQUIERDO

            if (carga.EntregaBovedaSucursal == EntregaRecibo.Entregas)
            {
                PrintText("SERVICIO  BANCARIO", 90, 490); //Origen de los fondos
                PrintText(carga.Sucursal.Nombre, 59, 465); //Origen de los fondos
                //PrintText("Centro de Dist. Cipreses", 59, 440);
                PrintText(carga.Sucursal.Provincia.ToString(), 44, 416); //Origen de los fondos
                PrintText(carga.Sucursal.Provincia.ToString(), 175, 417); //Provincia
                PrintText(dtpFecha.Value.ToShortDateString(), 230, 384); //Fecha de Entrega

                if (carga.Colaborador_verificador != null)
                    PrintText(carga.Colaborador_verificador.ToString(), 19, 384); //Nombre de Persona que preparó cargamento

                if (carga.Tripulacion.Portavalor != null)
                    PrintText("BAC SAN JOSE", 52, 354);//PrintText(carga.Tripulacion.Portavalor.ToString(), 52, 354); //Entregado a

                if (carga.Sucursal.Direccion != null)
                    PrintText(carga.Sucursal.Direccion, 59, 440); //Origen de los fondos


                PrintText("Centro de Dist. Cipreses", 45, 330);// Direccion

                PrintText("CURRIDABAT", 45, 307);// Ciudad

                PrintText("SAN JOSE", 178, 307); //Provincia

                if (carga.Sucursal != null)
                {
                    PrintText("CURRIDABAT", 201, 353); //Oficinas
                    //PrintText("Centro de Dist. Cipreses", 323, 60); //DIRECCION
                    //PrintText("SAN JOSE", 323, 228); //Provincia

                }

            }
            else
            {
                if (carga.EntregaBovedaSucursal == EntregaRecibo.Pedidos)
                {
                    PrintText("SERVICIO BANCARIO", 90, 490); //Origen de los fondos
                    PrintText("BAC San José", 59, 465); //Origen de los fondos
                    PrintText("Centro de Dist. Cipreses", 59, 440); //Origen de los fondos
                    PrintText("CURRIDABAT", 44, 416); //Origen de los fondos
                    //PrintText("SAN JOSE", 175, 417); //Provincia
                    PrintText(dtpFecha.Value.ToShortDateString(), 230, 384); //Fecha de Entrega
                    PrintText(carga.Sucursal.Provincia.ToString(), 175, 417); //Provincia

                    if (carga.Colaborador_verificador != null)
                        PrintText(carga.Colaborador_verificador.ToString(), 19, 384); //Nombre de Persona que preparó cargamento

                    if (carga.Tripulacion.Portavalor != null)
                        PrintText("BAC SAN JOSE", 52, 354);//PrintText(carga.Tripulacion.Portavalor.ToString(), 52, 354); //Entregado a

                    if (carga.Sucursal.Direccion != null)
                        PrintText(carga.Sucursal.Direccion.ToString(), 45, 330);// Direccion


                    PrintText(carga.Sucursal.Provincia.ToString(), 178, 307); //Provincia


                    PrintText(carga.Sucursal.Provincia.ToString(), 45, 307); //Ciudad

                    if (carga.Sucursal != null)
                    {
                        PrintText(carga.Sucursal.Nombre, 201, 353); //Oficinas

                    }
                }
            }

            //MARCHAMOS BT BULTOS Y MONTO

            int bultos = 0;
            //if (carga.Cartuchos.Count > 5 || carga.Cartuchos == null)
            //{
            int fila = 276;

            decimal montocol = 0;
            decimal montodol = 0;
            decimal montoeur = 0;
            string monto_final_letras = "";
            foreach (Bolsa b in man.ListaBolsas)
            {
                Bolsa copia = b;

                montocol = 0;
                montodol = 0;
                montoeur = 0;

                foreach (BolsaMontosSucursales mont in copia.Cartuchos)
                {
                    if (mont.Denominacion.Moneda == Monedas.Colones)
                    {
                        montocol = montocol + mont.Cantidad_asignada;
                    }
                    if (mont.Denominacion.Moneda == Monedas.Dolares)
                    {
                        montodol = montodol + mont.Cantidad_asignada;
                    }
                    if (mont.Denominacion.Moneda == Monedas.Euros)
                    {
                        montoeur = montoeur + mont.Cantidad_asignada;
                    }
                }
                if (montocol > 0)
                {
                    PrintText(("CRC " + montocol.ToString("N2")), 148, fila); /*MONTO colones*/
                    PrintText("B", 86, fila); /*BULTOS*/
                    PrintText("1", 110, fila); /*BT*/
                    PrintText(copia.SerieBolsa, 20, fila); /*Numero de Bolsa*/
                    fila = fila - 20;
                }

                if (montodol > 0)
                {
                    PrintText(("USD " + montodol.ToString("N2")), 148, fila); /*MONTO colones*/
                    PrintText("B", 86, fila); /*BULTOS*/
                    PrintText("1", 110, fila); /*BT*/
                    PrintText(copia.SerieBolsa, 20, fila); /*Numero de Bolsa*/
                    fila = fila - 20;
                }

                if (montoeur > 0)
                {
                    PrintText(("EUR " + montoeur.ToString("N2")), 148, fila); /*MONTO colones*/
                    PrintText("B", 86, fila); /*BULTOS*/
                    PrintText("1", 110, fila); /*BT*/
                    PrintText(copia.SerieBolsa, 20, fila); /*Numero de Bolsa*/
                    fila = fila - 20;
                }

                // Muestra el valor total del manifiesto.
                //PrintText(("CRC " + (montocol + (montodol * tipocambio) + (montoeur * tipocambioeuros)).ToString("N2")), 152, 33);

                //Realiza la suma de Carga en colones mas la Carga de dolares en colones        
                //string montototal = "";
                //montototal = Convert.ToInt64(montocol + (montodol * tipocambio) + (montoeur * tipocambioeuros)).ToString();

                //Conviete el gran total en letras.
                //if (montototal != "0")
                //{
                //    montoenletras = _coordinacion.convertirMontoaLetras(montototal) + " DE COLONES";
                //}


            }

            decimal montito_total = 0;

            foreach (Bolsa b in man.ListaBolsas)
            {
                foreach (BolsaMontosSucursales bol in b.Cartuchos)
                {

                    if (bol.Denominacion.Moneda == Monedas.Dolares)
                    {
                        montito_total = montito_total + (bol.Cantidad_asignada * tipocambio);
                    }
                    if (bol.Denominacion.Moneda == Monedas.Euros)
                    {
                        montito_total = montito_total + (bol.Cantidad_asignada * tipocambioeuros);
                    }
                    if (bol.Denominacion.Moneda == Monedas.Colones)
                    {
                        montito_total = montito_total + bol.Cantidad_asignada;
                    }
                }
            }

            string montito_total_letras = _coordinacion.convertirMontoaLetras(montito_total.ToString());
            string monto = montito_total_letras + " DE COLONES";


            //Imprime Gran Total Monto en Letras en el pdf
            if (monto.Length > 80)
            {
                PrintText(monto.Substring(0, 28), 18, 523);
                PrintText(monto.Substring(68, monto.Length - 28), 20, 521);
            }
            else
                PrintText(monto, 18, 523);


            // Muestra total manifiesto

            PrintText(("CRC " + montito_total.ToString("N2")), 152, 33);

            //LADO DERECHO

            if (carga.Tripulacion != null)
                PrintText(carga.Tripulacion.Portavalor.ToString(), 303, 486); //Nombre portavalor recibe
            else
                PrintText("", 303, 486); //Nombre portavalor recibe

            PrintText(carga.Ruta.ToString(), 361, 465); //Ruta 
            PrintText(man.ListaBolsas.Count.ToString(), 311, 465);
            PrintText(carga.Hora_inicio.ToShortTimeString(), 305, 420);
            PrintText(carga.Hora_finalizacion.ToShortTimeString(), 358, 420);
            PrintText(dtpFecha.Value.ToShortDateString(), 333, 440); //Fecha




            //Obtiene el nombre del portavalor.
            _coordinacion.listarPortavalorPorCargaSucursal(ref carga);

            if (carga.ColaboradorRecibidoBoveda != null)
            {
                PrintText((carga.ColaboradorRecibidoBoveda + " " + carga.ColaboradorRecibidoBoveda.Identificacion), 320, 632);
                PrintText((carga.ColaboradorRecibidoBoveda + " " + carga.ColaboradorRecibidoBoveda.Identificacion), 320, 578);
            }
            else
            {
                PrintText("", 320, 578);
                PrintText("", 320, 632);
            }



            //PrintText(carga.Ruta.ToString(), 369, 175); //Ruta 
            //PrintText(man.ListaBolsas.Count.ToString(), 317, 175);// Bultos
            //PrintText(carga.Fecha_asignada.ToShortDateString(), 416, 175);// Fecha

            //////////////////////////////////////Quitar el número de ATM  08/04/2014///////////////////////////////////////////////////////


            PrintText(carga.Observaciones, 325, 450);


            _pcb.EndText();
            writer.Flush();

            if (readerBicycle == null)
                readerBicycle.Close();

            documento.Close();   //Cierra crear PDF Sucursal


        }              //Cierra crear PDF Sucursales



        private void generarCodigoBarra(string manifiesto)
        {
            Graphics codigo = null;

            Linear barcode = new Linear();
            barcode.Type = BarcodeType.CODE11;
            barcode.Data = manifiesto;
            barcode.drawBarcode(codigo);
            // pbcodigobarras.
        }

        /// <summary>
        ///  DETERMINA LA FUENTE QUE SE VA A UTILIZAR 
        /// </summary>
        /// <param name="size">TAMAÑO DE LA FUENTE</param>
        private void SetFont(Single size)
        {
            _pcb.SetFontAndSize(font, size);
        }


        private void SetFontBarCode(Single size)  //DETERMINA LA FUENTE BARCODE Y ASIGNA UN TAMAÑO
        {
            _pcb.SetFontAndSize(font2, size);
        }

        /// <summary>
        /// Posiciona los datos dentro de la plantilla y los imprime
        /// </summary>
        /// <param name="text">El valor que se va a imprimir</param>
        /// <param name="x">Coordenada en el eje X para posicionarse</param>
        /// <param name="y">Coordenada en el eje Y para posicionarse</param>
        private void PrintText(string text, int x, int y)
        {
            _pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, text, x, y, 0);
        }


        /// <summary>
        /// Verifica si el monto excede el tamaño el espacio
        /// </summary>
        /// <param name="monto">Objeto String con el monto a pintar</param>
        private void montoLetrasPdf(string monto)
        {
            monto = montoenletras;

            //Imprime Gran Total Monto en Letras en el pdf
            if (monto.Length > 38)
            {
                PrintText(monto.Substring(0, 38), 185, 685);
                PrintText(monto.Substring(38, monto.Length - 38), 87, 675);
            }
            else
                PrintText(monto, 185, 685);


        }



        /// <summary>
        /// Une los manifiesto de una determinada 
        /// </summary>
        /// <param name="c"></param>
        public void UnirPDF(CargaSucursal c)
        {
            Document doc = new Document();
            try
            {
                ManipulacionPDF m = new ManipulacionPDF();
                string[] final = new string[c.Manifiesto.Count];
                int i = 0;

                foreach (ManifiestoSucursalCarga man in c.Manifiesto)
                {
                    final[i] = @"\\10.120.131.100\Manifiestos\SUC-" + man.ID.ToString() + ".pdf";
                    i++;
                }

                //m.MergePdfFiles(final, @"\\10.120.131.100\ECARD\Final_Validacion\FINALSUCURSAL-" + c.ID + ".pdf");

                string rutafinal = @"\\10.120.131.100\ECARD\Final_Validacion\FINALSUCURSAL-" + c.ID + ".pdf";


                FileStream fs = new FileStream(rutafinal, FileMode.Create, FileAccess.Write, FileShare.None);

                PdfCopy copy = new PdfCopy(doc, fs);
                doc.Open();

                iTextSharp.text.pdf.PdfReader reader = null;
                iTextSharp.text.pdf.PdfReader.unethicalreading = true;


                int n;

                foreach (string file in final)
                {
                    reader = new PdfReader(file);
                    iTextSharp.text.pdf.PdfReader.unethicalreading = true;
                    n = reader.NumberOfPages;

                    int page = 0;

                    while (page < n)
                    {
                        page++;
                        copy.AddPage(copy.GetImportedPage(reader, page));
                    }

                    copy.FreeReader(reader);

                    reader.Close();
                }


            }
            catch (Excepcion ex)
            {
                doc.Close();
            }
            finally
            {
                doc.Close();
            }

        }
       

        #endregion Métodos Privados

        private void frmManifiestoSucursal_Load(object sender, EventArgs e)
        {

        }

        
    }
}
