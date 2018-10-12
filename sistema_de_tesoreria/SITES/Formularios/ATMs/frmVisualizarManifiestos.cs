using BussinessLayer;
using BussinessLayer.Clases;
using CommonObjects;
using CommonObjects.Clases;
using GUILayer.Formularios.Boveda;
using iTextSharp.text;
using iTextSharp.text.pdf;
using LibreriaMensajes;
using LibreriaReportesOffice;
using OnBarcode.Barcode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.ATMs
{
    public partial class frmVisualizarManifiestos : Form
    {

        #region Atributos

            private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
            private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
            private SeguridadBL _seguridad = SeguridadBL.Instancia;
            private AtencionBL _atencion = AtencionBL.Instancia;

            DescargaATM _carga_atm = null;
            CargaSucursal _carga_sucursal = null;
            PedidoBancos _pedido_banco = null;
            Denominacion _denominacion = null;
            EsquemaManifiesto _esquema = null;
            TipoCambio _tipocambio = null;
            Colaborador _colaborador = null;

            ManifiestoSucursalCarga _manifiesto_sucursal = null;
            private static readonly BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);         //DEFINE UN TIPO DE FUENTE PARA ESCRIBIR EN EL DOCUMENTO
            BaseFont font2 = BaseFont.CreateFont(@"\\10.120.131.100\Releases\ConnectCode39.ttf", BaseFont.WINANSI, BaseFont.EMBEDDED);     //DEEFINE LA FUENTE PARA IMPRIMIR CODIGO DE BARRAS
            PdfContentByte _pcb;     // OBJETO QUE CONTIENE EL TEXTO DE USUARIO POSICIONADO Y EL CONTENIDO GRÁFICO DE LA PAGINA SOBRE LA QUE SE VA A TRABAJAR

            string montoenletras = "";

        #endregion Atributos

        #region Constructor
        public frmVisualizarManifiestos(Colaborador colaborador)
        {
            InitializeComponent();


            _colaborador = colaborador;


            
            try
            {
                dgvCargas.AutoGenerateColumns = false;
                dgvCargasSucursales.AutoGenerateColumns = false;
                dgvCargasBancos.AutoGenerateColumns = false;
                cboATM.ListaMostrada = _mantenimiento.listarATMs();
                cboSucursal.ListaMostrada = _mantenimiento.listarSucursalesRecientes();
                cboCanal.ListaMostrada = _mantenimiento.listarCanales();
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        #endregion Constructor

        #region ATMs



        #region Eventos

        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime fecha = dtpFecha.Value;
                
                CommonObjects.ATM atm = cboATM.SelectedIndex == 0 ?
                    null : (CommonObjects.ATM)cboATM.SelectedItem;
                byte? ruta = chkRuta.Checked ?
                    (byte?)nudRuta.Value : null;

                dgvCargas.DataSource = _coordinacion.listarCargasATMs(null, atm, fecha, ruta);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

       

        /// <summary>
        /// Clic en el botón de imprimir.
        /// </summary>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            CargaATM carga = (CargaATM)dgvCargas.SelectedRows[0].DataBoundItem;

            this.imprimirHojaCarga(carga);
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
                CargaATM carga = (CargaATM)fila.DataBoundItem;

                _carga_atm = new DescargaATM();
                _carga_atm.Carga = carga;
                  
               this.mostrarVentanaRevision();

            }

        }

        /// <summary>
        /// Se agrega una carga a la lista de cargas.
        /// </summary>
        private void dgvCargas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvCargas.Rows.Count > 0)
            {

                for (int contador = 0; contador < e.RowCount; contador++)
                {
                    DataGridViewRow fila = dgvCargas.Rows[e.RowIndex + contador];
                    CargaATM carga = (CargaATM)fila.DataBoundItem;

                    fila.Cells[ATMCarga.Index].Value = carga.ToString();

                    if (carga.Colaborador_verificador != null)
                    {

                        if (carga.Modificada)
                            fila.DefaultCellStyle.BackColor = Color.Green;
                        else
                            fila.DefaultCellStyle.BackColor = Color.LightGreen;

                    }
                    else if (carga.Cierre != null)
                    {
                        fila.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else if (carga.Cajero != null)
                    {
                        fila.DefaultCellStyle.BackColor = Color.LightCoral;
                    }

                }
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
                CargaATM carga = (CargaATM)fila.DataBoundItem;

                
                btnRevisar.Enabled = true;
                btnImprimir.Enabled = true;

               

            }
            else
            {

                btnRevisar.Enabled = false;
                btnImprimir.Enabled = false;
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
        /// Imprimir los datos de una hoja de carga.
        /// </summary>
        private void imprimirHojaCarga(CargaATM carga)
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla carga.xlt", true);

                documento.seleccionarHoja(1);

                // Escribir los datos

                documento.seleccionarCelda("C7");
                documento.actualizarValorCelda(carga.Hora_inicio.ToShortDateString());

                documento.seleccionarCelda("C9");
                documento.actualizarValorCelda(carga.Hora_inicio.ToShortTimeString());

                documento.seleccionarCelda("C11");
                documento.actualizarValorCelda(Enum.GetName(typeof(TiposCartucho), carga.Tipo));

                documento.seleccionarCelda("C13");
                documento.actualizarValorCelda(carga.ATM_full ? "Sí" : "No");

                if (carga.Cierre.Camara != null)
                {
                    documento.seleccionarCelda("C15");
                    documento.actualizarValorCelda(carga.Cierre.Camara.ToString());
                }

                documento.seleccionarCelda("H7");
                documento.actualizarValorCelda(carga.ToString());

                documento.seleccionarCelda("H9");
                documento.actualizarValorCelda(carga.Codigo);

                documento.seleccionarCelda("H13");
                documento.actualizarValorCelda(carga.Ruta.ToString());

                documento.seleccionarCelda("H15");
                documento.actualizarValorCelda(carga.Cartucho_rechazo ? "Sí" : "No");

                documento.seleccionarCelda("A47");
                documento.actualizarValorCelda(carga.Cierre.Cajero.ToString() + " " + carga.Fecha_asignada.ToShortDateString());

                documento.seleccionarCelda("F47");
                documento.actualizarValorCelda(carga.Cierre.Coordinador.ToString() + " " + carga.Fecha_asignada.ToShortDateString());

                // Mostrar los datos de los manifiestos

                documento.seleccionarCelda("C37");
                documento.actualizarValorCelda(carga.Manifiesto.Codigo);

                documento.seleccionarCelda("C39");
                documento.actualizarValorCelda(carga.Manifiesto.Marchamo);

                documento.seleccionarCelda("H39");
                documento.actualizarValorCelda(carga.Manifiesto.Marchamo_adicional);

                if (carga.Bolsa_Rechazo)
                {
                    documento.seleccionarCelda("H41");
                    documento.actualizarValorCelda(carga.Manifiesto.Bolsa_rechazo);
                }

                if (carga.ATM_full)
                {
                    documento.seleccionarCelda("C41");
                    documento.actualizarValorCelda(carga.Manifiesto_full.Marchamo);

                    documento.seleccionarCelda("H37");
                    documento.actualizarValorCelda(carga.Manifiesto_full.Codigo);

                    if (carga.ENA)
                    {
                        documento.seleccionarCelda("C43");
                        documento.actualizarValorCelda(carga.Manifiesto_full.Marchamo_ena_a);

                        documento.seleccionarCelda("C45");
                        documento.actualizarValorCelda(carga.Manifiesto_full.Marchamo_ena_b);

                        documento.seleccionarCelda("H43");
                        documento.actualizarValorCelda(carga.Manifiesto_full.Marchamo_adicional_ena);
                    }

                }

                // Imprimir los montos

                int fila_colones = 0;
                int fila_dolares = 0;

                foreach (CartuchoCargaATM cartucho in carga.Cartuchos)
                {

                    switch (cartucho.Denominacion.Moneda)
                    {
                        case Monedas.Colones:
                            documento.seleccionarCelda(19 + fila_colones, 1);
                            documento.actualizarValorCelda(cartucho.Denominacion.Valor.ToString());

                            documento.seleccionarCelda(19 + fila_colones, 4);
                            documento.actualizarValorCelda(cartucho.Denominacion.Codigo);

                            documento.seleccionarCelda(19 + fila_colones, 5);
                            documento.actualizarValorCelda(cartucho.Cantidad_carga.ToString());

                            documento.seleccionarCelda(19 + fila_colones,6);
                            documento.actualizarValorCelda(cartucho.Cartucho.Numero.ToString());

                            documento.seleccionarCelda(19 + fila_colones,7);
                            documento.actualizarValorCelda(cartucho.Marchamo);

                            fila_colones++;
                            break;
                        case Monedas.Dolares:
                            documento.seleccionarCelda(33 + fila_dolares, 1);
                            documento.actualizarValorCelda(cartucho.Denominacion.Valor.ToString());

                            documento.seleccionarCelda(19 + fila_colones, 4);
                            documento.actualizarValorCelda(cartucho.Denominacion.Codigo);

                            documento.seleccionarCelda(33 + fila_dolares, 5);
                            documento.actualizarValorCelda(cartucho.Cantidad_carga.ToString());

                            documento.seleccionarCelda(33 + fila_dolares, 6);
                            documento.actualizarValorCelda(cartucho.Cartucho.Numero.ToString());

                            documento.seleccionarCelda(33 + fila_dolares, 7);
                            documento.actualizarValorCelda(cartucho.Marchamo);

                            fila_dolares++;
                            break;
                    }

                }

                // Imprimir el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        /// <summary>
        /// Mostrar la ventana de revisión de la carga.
        /// </summary>
        private void mostrarVentanaRevision()
        {
            CargaATM carga = (CargaATM)dgvCargas.SelectedRows[0].DataBoundItem;
            _carga_atm = new DescargaATM();
            _carga_atm.Carga = carga;
            CrearPDFATM();
            frmVisualizarManifiesto formulario = new frmVisualizarManifiesto(_carga_atm);
            formulario.ShowDialog();
        }

      

        /// <summary>
        /// Crea PDF para las Cargas ATM
        /// </summary>
        /// <param name="carga">Objeto CargaATM con los datos de la Carga del ATM</param>
        public void CrearPDFATM()                  //Abre crear PDF ATM        
        {
            
            DescargaATM carga = _carga_atm;
            DateTime hoy = DateTime.Today;
            string actual = hoy.ToString("dd/MM/yyyy");
            string destinopdf = @"\\10.120.131.100\Manifiestos\ATM-" + _carga_atm.Manifiesto + ".pdf";          //DEFINE NOMBRE Y UBICACION DEL PDF QUE SE DESEA CREAR
            Stream output = new FileStream(destinopdf, FileMode.Create, FileAccess.Write);

            string plantilla = Application.StartupPath + "\\manifiesto\\manifiesto5.pdf";
           // string plantilla = @"\\10.120.131.100\Releases\manifiesto5.pdf";          //DEFINE LA UBICACION Y EL NOMBRE DE LA PLANTILLA A USAR
            _tipocambio = _mantenimiento.obtenerTipoCambio(carga.Carga.Fecha_asignada);
            PdfReader readerBicycle = null;
            iTextSharp.text.Rectangle pagesize = new iTextSharp.text.Rectangle(504, 580);
            Document documento = new Document(pagesize);
            FileStream theFile = new FileStream(plantilla, FileMode.Open, FileAccess.Read);
            PdfWriter writer = PdfWriter.GetInstance(documento, output);
            documento.Open();
            readerBicycle = new PdfReader(theFile);
            PdfTemplate background = writer.GetImportedPage(readerBicycle, 1);
            documento.NewPage();

            iTextSharp.text.Image pic = null;
            iTextSharp.text.Image pic2 = null;
            iTextSharp.text.Image pic3 = null;

            



            if (File.Exists(@"\\10.120.9.20\Blindados\Firmas\recepcionvalores-tripulacion" + carga.Carga.Tripulacion.ID.ToString() +
            "-colaboradorrecibe" + carga.Carga.Tripulacion.Portavalor.ID.ToString() + "-colaboradorentrega" + carga.Carga.ColaboradorRecibidoBoveda.ID.ToString() + "-fecha" + carga.Carga.Fecha_asignada.Year.ToString() + carga.Carga.Fecha_asignada.Month.ToString("00") + carga.Carga.Fecha_asignada.Day.ToString("00") + ".jpg"))
            {


            //    @"\\10.120.9.20\Blindados\Firmas\recepcionvalores-tripulacion" + carga.Carga.Tripulacion.ID.ToString() +
            //"-colaboradorrecibe" + carga.Carga.Tripulacion.Portavalor.ID.ToString() + "-colaboradorentrega" + carga.Carga.ColaboradorRecibidoBoveda.ID.ToString() + "-fecha" + carga.Carga.Fecha_asignada.Year.ToString() + carga.Carga.Fecha_asignada.Month.ToString() + carga.Carga.Fecha_asignada.Day.ToString("00") + ".jpg"))
               //imagen 1
            //    pic = // iTextSharp.text.Image.GetInstance(@"\\10.120.9.20\Blindados\Firmas\atencionsucursales-tripulacion1352-colaboradorrecibe228-colaboradorentrega135-fecha20140715.jpg");

            //iTextSharp.text.Image.GetInstance( @"\\10.120.9.20\Blindados\Firmas\recepcionvalores-tripulacion" + carga.Carga.Tripulacion.ID.ToString() +
            //"-colaboradorrecibe" + carga.Carga.Tripulacion.Portavalor.ID.ToString() + "-colaboradorentrega" + carga.Carga.ColaboradorRecibidoBoveda.ID.ToString() + "-fecha" + carga.Carga.Fecha_asignada.Year.ToString() + carga.Carga.Fecha_asignada.Month.ToString("00") + carga.Carga.Fecha_asignada.Day.ToString("00") + ".jpg");


                //imagen 2

                pic2 = iTextSharp.text.Image.GetInstance(@"\\10.120.9.20\Blindados\Firmas\recepcionvalores-tripulacion" + carga.Carga.Tripulacion.ID.ToString() +
            "-colaboradorrecibe" + carga.Carga.Tripulacion.Portavalor.ID.ToString() + "-colaboradorentrega" + carga.Carga.ColaboradorRecibidoBoveda.ID.ToString() + "-fecha" + carga.Carga.Fecha_asignada.Year.ToString() + carga.Carga.Fecha_asignada.Month.ToString("00") + carga.Carga.Fecha_asignada.Day.ToString("00") + ".jpg");




            }



            if (File.Exists(@"\\10.120.9.20\Blindados\Firmas\recepcionvalores-tripulacion" + carga.Carga.Tripulacion.ID.ToString() +
            "-colaboradorentrega" + carga.Carga.ColaboradorRecibidoBoveda.ID.ToString() + "" + "-colaboradorrecibe" + carga.Carga.Tripulacion.Portavalor.ID.ToString() + "-fecha" + carga.Carga.Fecha_asignada.Year.ToString() + carga.Carga.Fecha_asignada.Month.ToString("00") + carga.Carga.Fecha_asignada.Day.ToString("00") + ".jpg"))
            {

                pic3 = iTextSharp.text.Image.GetInstance(@"\\10.120.9.20\Blindados\Firmas\recepcionvalores-tripulacion" + carga.Carga.Tripulacion.ID.ToString() +
                "-colaboradorentrega" + carga.Carga.ColaboradorRecibidoBoveda.ID.ToString() + "" + "-colaboradorrecibe" + carga.Carga.Tripulacion.Portavalor.ID.ToString() + "-fecha" + carga.Carga.Fecha_asignada.Year.ToString() + carga.Carga.Fecha_asignada.Month.ToString("00") + carga.Carga.Fecha_asignada.Day.ToString("00") + ".jpg");

            }


            string GranTotal = "CRC " + (_carga_atm.Monto_carga_colones + (_carga_atm.Monto_carga_dolares * (_tipocambio.Venta))).ToString("N2");

            string montototal = "";

            montototal = Convert.ToInt32((_carga_atm.Monto_carga_colones + (_carga_atm.Monto_carga_dolares * (_tipocambio.Venta)))).ToString();

            //Conviete el gran total en letras.
            string GranTotalLetras = _coordinacion.convertirMontoaLetras(montototal) + "COLONES";
            montoenletras = GranTotalLetras;

            //pic.RotationDegrees = 90;
            //pic2.RotationDegrees = 90;
            //pic3.RotationDegrees = 90;

            _pcb = writer.DirectContentUnder;
            _pcb.AddTemplate(background, 0, 0);
            _pcb = writer.DirectContent;
            _pcb.BeginText();

            if (pic2 != null)
            {
                //pic.ScaleAbsolute(75, 45);
                //pic.SetAbsolutePosition(411, 440);
                //documento.Add(pic);


                pic2.ScaleAbsolute(75, 45);
                pic2.SetAbsolutePosition(411, 330);
                documento.Add(pic2);
            }

            if (pic3 != null)
            {
                pic3.ScaleAbsolute(75, 35);// Receptor
                pic3.SetAbsolutePosition(411, 120);
                documento.Add(pic3);
            }

            //pic.ScaleAbsolute(25, 20);
            //pic.SetAbsolutePosition(500, 384);
            //documento.Add(pic);



            SetFontBarCode(10);                   //ESTABLECE LA FUENTE E IMPRIME CON LA FUENTE BARCODE HASTA SER CAMBIADA
            PrintText("*" + carga.Carga.Manifiesto.Codigo + "*", 335, 561);      //Imprime codigo de barras
            SetFont(7);
            PrintText("No: ATM-" + carga.Carga.Manifiesto.Codigo, 335, 550);       //Imprime numero de manifiesto
            SetFont(8);                   //CAMBIAMOS LA FUENTE

            montoLetrasPdf(montoenletras);   //Imprime monto total en letras y valida el tamaño

            PrintText(_tipocambio.Venta.ToString("N2"), 311, 525); //Imprime tipo de cambio
            PrintText(carga.Cartuchos.Count.ToString(), 360, 525); //Cantidad depositos
            PrintText("1", 440, 525); //Imprime cantidad de manifiestos

            //LADO IZQUIERDO

            PrintText("ATM", 90, 490); //Origen de los fondos
            PrintText("BAC San José", 59, 465); //Recibido de
            PrintText("Centro de Dist. Cipreses", 59, 440); //Direccion
            PrintText("CURRIDABAT", 44, 416); //Ciudad
            PrintText("SAN JOSE", 175, 417); //Provincia
            PrintText(carga.Carga.Cajero.ToString(), 19, 384); //Nombre de Persona que preparó cargamento
            PrintText(carga.Carga.Fecha_asignada.ToShortDateString(), 230, 384); //Fecha de Entrega
            if (carga.Carga.Tripulacion != null)
                PrintText(carga.Carga.Tripulacion.Portavalor.ToString(), 52, 354); //Entregado a
            else
                PrintText("", 52, 354);
            if (carga.ATM.Oficinas != string.Empty)
            {
                PrintText(carga.ATM.Oficinas, 201, 353); //Oficinas
            }
            PrintText("Centro de Dist. Cipreses", 45, 330); //Direccion
            PrintText("CURRIDABAT", 46, 306); //CIUDAD
            PrintText("SAN JOSE", 178, 307); //Provincia


            //MARCHAMOS BT BULTOS Y MONTO

            //PrintText(carga.Carga.Manifiesto.Codigo, 362, 77); //Provincia

            //int bultos = 0;
            //if (carga.Cartuchos.Count > 5)
            //{
            int fila = 276;
            if (carga.Carga.Monto_asignado_colones > 0)
            {
                PrintText(("CRC " + carga.Carga.Monto_asignado_colones.ToString("N2")), 148, fila); /*MONTO colones*/
                PrintText("1", 86, fila); /*BULTOS*/
                PrintText("B", 110, fila); /*BT*/
                PrintText(carga.Carga.Manifiesto.Marchamo, 20, fila); /*BT*/
                fila = fila - 20;
            }
            if (carga.Carga.Monto_asignado_dolares > 0)
            {
                PrintText(("USD " + carga.Carga.Monto_asignado_dolares.ToString("N2")), 147, fila); /*MONTO dolares*/
                PrintText("1", 85, fila); /*BULTOS*/
                PrintText("B", 110, fila); /*BT*/
                PrintText(carga.Carga.Manifiesto.Marchamo, 20, fila); /*BT*/
                fila = fila - 20;
            }
            if (carga.Carga.Monto_asignado_euros > 0)
            {
                PrintText(("EUR " + carga.Carga.Monto_asignado_euros.ToString("N2")), fila, 226); /*MONTO Euros*/
                PrintText("1", 114, fila); /*BULTOS*/
                PrintText("B", 85, fila); /*BT*/
                PrintText(carga.Carga.Manifiesto.Marchamo, 20, fila); /*BT*/
            }



            //Realiza la suma de Carga en colones mas la Carga de dolares en colones.
           

            PrintText(GranTotal, 152, 33);

            //LADO DERECHO
            //if (carga.Carga.Tripulacion != null)
            //    PrintText(carga.Carga.Tripulacion.Portavalor.ToString(), 303, 486); //Nombre portavalor recibe
            //else
            //    PrintText("", 303, 486); //Nombre portavalor recibe

            //PrintText(carga.Carga.Ruta.ToString(), 361, 465); //Ruta 
            //PrintText(carga.Carga.Cartuchos.Count.ToString(), 311, 465);
            //PrintText(carga.Carga.HoraEntregaoBoveda.ToShortTimeString(), 305, 420);
            //PrintText(carga.Carga.HoraRecibidoBoveda.ToShortTimeString(), 358, 420);
            //PrintText(carga.Carga.Fecha_asignada.ToShortDateString(), 333, 440); //Fecha
            


            CargaATM _carguita = _carga_atm.Carga;
            //Obtiene el nombre del portavalor.
            _coordinacion.listarPortavalorPorCargaATM(ref _carguita);

            string PortavalorRecibe = string.Empty;
            string PortavalorRuta = string.Empty;

            if (_carga_atm.Carga.ColaboradorRecibidoBoveda != null)
            {
                 PortavalorRecibe = (_carga_atm.Carga.ColaboradorRecibidoBoveda + " " + _carga_atm.Carga.ColaboradorRecibidoBoveda.Identificacion).ToString();
                 PortavalorRuta = PortavalorRecibe;
            }
          

           


            PrintText(PortavalorRuta, 306, 390); //Responsable Ruta
            PrintText(carga.ATM.Numero.ToString(), 335, 360); //Numero de ATM

            if (carga.ATM.Full)
                PrintText("X", 385, 335); // x de normal
            else
                PrintText("X", 306, 335); //x de full

            PrintText(("CRC " + carga.Monto_descarga_colones.ToString("N2")), 311, 312); //monto descarga colones
            PrintText(("USD " + carga.Monto_descarga_dolares.ToString("N2")), 318, 290); //monto descarga dolares
            PrintText(carga.Carga.Manifiesto.Bolsa_rechazo, 312, 325); //Numero de marchamo de rechazo
            PrintText(carga.Carga.Observaciones, 300, 250);


            //if (carga.ATM.Full)
            //    PrintText(carga.Carga.Manifiesto_full.Marchamo, 379, 515); //monto descarga dolares
            //else
            //    PrintText(carga.Carga.Manifiesto.Marchamo_adicional, 379, 515);// marchamo adicional


            // Parte de Recepción
            PrintText(carga.Carga.ReceptorTulas.ToString(), 340, 200); //Ruta 
            PrintText(carga.Carga.Ruta.ToString(), 369, 172); //Ruta 
            PrintText("1", 317, 172);// Bultos
            PrintText(carga.Fecha.ToShortDateString(), 416, 171);// Fecha
   

            _pcb.EndText();
            writer.Flush();

            if (readerBicycle == null)
                readerBicycle.Close();
            documento.Close();



        }              //Cierra crear PDF ATM





        /// <summary>
        /// Genera
        /// </summary>
        /// <param name="manifiesto"></param>
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
            if (monto.Length > 80)
            {
                PrintText(monto.Substring(0, 28), 18, 523);
                PrintText(monto.Substring(68, monto.Length - 28), 20, 521);
            }
            else
                PrintText(monto, 18, 523);
        }

        #endregion Métodos Privados



        #endregion ATMs


        #region Sucursales


        #region Eventos

        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizarSucursal_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime fecha = dtpFechaSucursal.Value;

                Sucursal suc= cboSucursal.SelectedIndex == 0 ?
                    null : (Sucursal)cboSucursal.SelectedItem;
                byte? ruta = chkRutaSucursal.Checked ?
                    (byte?)nudRuta.Value : null;

                dgvCargasSucursales.DataSource =  _coordinacion.listarCargasSucursales(null, suc, fecha, ruta, EstadoAprobacionCargas.Aprobada);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }



        /// <summary>
        /// Clic en el botón de imprimir.
        /// </summary>
        ///
        private void btnImprimirSucursal_Click(object sender, EventArgs e)
        {
            CargaSucursal carga = (CargaSucursal)dgvCargasSucursales.SelectedRows[0].DataBoundItem;
            _carga_sucursal = carga;
            //if (_coordinacion.verificarExisteCargaVerificada(carga))
            //{
            foreach (ManifiestoSucursalCarga manifestito in carga.Manifiesto)
            {
                manifestito.Pedido = carga;
                ManifiestoSucursalCarga mani = manifestito;

                imprimirHojaCargaSucursal(mani);

            }
        }



        /// <summary>
        /// Clic en el botón de revisar.
        /// </summary>
        private void btnRevisarSucursal_Click(object sender, EventArgs e)
        {
            this.mostrarVentanaRevisionSucursal();
        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalirSucursal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Doble clic en la lista de cargas.
        /// </summary>
        private void dgvCargasSucursal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                DataGridViewRow fila = dgvCargasSucursales.SelectedRows[0];
                CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;

                _carga_sucursal = carga;

                this.mostrarVentanaRevisionSucursal();

            }

        }

        /// <summary>
        /// Se agrega una carga a la lista de cargas.
        /// </summary>
        private void dgvCargasSucursales_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCargasSucursales.Rows[e.RowIndex + contador];
                CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;

                fila.Cells[ATMCarga.Index].Value = carga.ToString();

                if (carga.Colaborador_verificador != null)
                {

                    if (carga.Modificada)
                        fila.DefaultCellStyle.BackColor = Color.Green;
                    else
                        fila.DefaultCellStyle.BackColor = Color.LightGreen;

                }
                else if (carga.Cierre != null)
                {
                    fila.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (carga.Cajero != null)
                {
                    fila.DefaultCellStyle.BackColor = Color.LightCoral;
                }

            }

        }

        /// <summary>
        /// Se selecciona otra carga de la lista de cargas.
        /// </summary>
        private void dgvCargasSucursales_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCargasSucursales.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvCargasSucursales.SelectedRows[0];
                CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;


                btnRevisarSucursal.Enabled = true;
                btnImprimirSucursal.Enabled = true;



            }
            else
            {

                btnRevisarSucursal.Enabled = false;
                btnImprimirSucursal.Enabled = false;
            }

        }

        /// <summary>
        /// Se marca o desmarca la opción de filtrar por ruta.
        /// </summary>
        private void chkRutaSucursal_CheckedChanged(object sender, EventArgs e)
        {
            nudRutaSucursal.Enabled = chkRutaSucursal.Checked;
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Imprimir los datos de una hoja de carga.
        /// </summary>
        private void imprimirHojaCargaSucursal(ManifiestoSucursalCarga carga)
        {

            try
            {

                _manifiesto_sucursal = carga;

                pdOpcionesImpresion.PrinterSettings.PrinterName = Properties.Settings.Default.ImpresoraManifiestos;

                if (pdOpcionesImpresion.ShowDialog() == DialogResult.OK)
                {
                    string nombre_impresora = pdOpcionesImpresion.PrinterSettings.PrinterName;

                    Properties.Settings.Default.ImpresoraManifiestos = nombre_impresora;
                    Properties.Settings.Default.Save();

                    
                        _esquema = _mantenimiento.listarEsquemasManifiestoEspecifico(5);

                    PrinterSettings configuracion = new PrinterSettings();

                    configuracion.PrinterName = nombre_impresora;

                    pdDocumentoSucursales.PrinterSettings = configuracion;

                    PaperSize tamano = new System.Drawing.Printing.PaperSize();

                    tamano.RawKind = (int)(int)System.Drawing.Printing.PaperKind.Custom;
                    tamano.Height = (int)(_esquema.Alto * 100 / (decimal)2.54);
                    tamano.Width = (int)(_esquema.Ancho * 100 / (decimal)2.54);

                    PageSettings configuracion_pagina = new PageSettings(configuracion);

                    configuracion_pagina.Margins.Left = 0;
                    configuracion_pagina.Margins.Top = 0;
                    configuracion_pagina.Margins.Right = 0;
                    configuracion_pagina.Margins.Bottom = 0;
                    configuracion_pagina.PaperSize = tamano;

                    pdDocumentoSucursales.DefaultPageSettings = configuracion_pagina;


                    pdDocumentoSucursales.Print();

                }
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        /// <summary>
        /// Mostrar la ventana de revisión de la carga.
        /// </summary>
        private void mostrarVentanaRevisionSucursal()
        {
            CargaSucursal carga = (CargaSucursal)dgvCargasSucursales.SelectedRows[0].DataBoundItem;
            _carga_sucursal = carga;
            //if (_coordinacion.verificarExisteCargaVerificada(carga))
            //{
                foreach (ManifiestoSucursalCarga manifestito in carga.Manifiesto)
                {
                    manifestito.Pedido = carga;
                    ManifiestoSucursalCarga mani = manifestito;
                    CrearPDFSucursal(manifestito);
                    
                }

                UnirPDF(carga);
                frmVisualizarManifiesto visualizar = new frmVisualizarManifiesto(_carga_sucursal);
                visualizar.ShowDialog();
            //}
            //frmVisualizarManifiesto formulario = new frmVisualizarManifiesto(_carga_sucursal);
            //formulario.ShowDialog();
        }



        /// <summary>
        /// Crea PDF para las Cargas de Sucursales
        /// </summary>
        /// <param name="carga">Objeto ManifiestoSucursal con los datos de la Carga de la Sucursal</param>
        public void CrearPDFSucursal(ManifiestoSucursalCarga man)                  //Abre crear PDF Sucursal        
        {

            CargaSucursal carga = _carga_sucursal;
            DateTime hoy = DateTime.Today;
            string actual = hoy.ToString("dd/MM/yyyy");
            string destinopdf = @"\\10.120.131.100\Manifiestos\SUC-" + man.ID.ToString() + ".pdf";          //DEFINE NOMBRE Y UBICACION DEL PDF QUE SE DESEA CREAR
            Stream output = new FileStream(destinopdf, FileMode.Create, FileAccess.Write);
            string plantilla = @"\\10.120.131.100\Releases\manifiesto5.pdf";          //DEFINE LA UBICACION Y EL NOMBRE DE LA PLANTILLA A USAR


            TipoCambio tip = null;
            tip = _mantenimiento.obtenerTipoCambio(dtpFechaSucursal.Value);
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
            "-colaboradorentrega" + carga.Tripulacion.Portavalor.ID.ToString() + "-colaboradorrecibe"+colaborador_recibo+"-fecha" + carga.Fecha_asignada.Year.ToString() + carga.Fecha_asignada.Month.ToString("00") + carga.Fecha_asignada.Day.ToString("00") + ".jpg"))
            {

            

                if (carga.EntregaBovedaSucursal == EntregaRecibo.Entregas)
                {
                    receptor = @"\\10.120.9.20\Blindados\Firmas\atencionsucursales-tripulacion" + carga.Tripulacion.ID.ToString() + "-colaboradorrecibe" + carga.Tripulacion.Portavalor.ID.ToString() + "-colaboradorentrega" + colaborador_recibo + "-fecha" + carga.Fecha_asignada.Year.ToString() + carga.Fecha_asignada.Month.ToString("00") + carga.Fecha_asignada.Day.ToString("00") + ".jpg";
                    emisor = @"\\10.120.9.20\Blindados\Firmas\atencionsucursales-tripulacion"+carga.Tripulacion.ID.ToString()+"-colaboradorrecibe"+colaborador_recibo+"-colaboradorentrega"+carga.Tripulacion.Portavalor.ID.ToString()+"-fecha"+carga.Fecha_asignada.Year.ToString()+ carga.Fecha_asignada.Month.ToString("00")+carga.Fecha_asignada.Day.ToString("00")+".jpg";
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


            TipoCambio t = _mantenimiento.obtenerTipoCambio(dtpFechaSucursal.Value);

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

            PrintText(t.Venta.ToString("N0")+"/"+ t.VentaEuros.ToString("N0"), 300, 525); //Imprime tipo de cambio
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
                PrintText(carga.Hora_inicio.ToShortDateString(), 230, 384); //Fecha de Entrega

                if (carga.Cajero != null)
                    PrintText(carga.Cajero.ToString(), 19, 384); //Nombre de Persona que preparó cargamento

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
                    PrintText(carga.Hora_inicio.ToShortDateString(), 230, 384); //Fecha de Entrega
                    PrintText(carga.Sucursal.Provincia.ToString(), 175, 417); //Provincia

                    if (carga.Cajero != null)
                        PrintText(carga.Cajero.ToString(), 19, 384); //Nombre de Persona que preparó cargamento

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
                        montodol = montocol + mont.Cantidad_asignada;
                    }
                    if (mont.Denominacion.Moneda == Monedas.Euros)
                    {
                        montoeur = montocol + mont.Cantidad_asignada;
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
                    else
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
            PrintText(dtpFechaSucursal.Value.ToShortDateString(), 333, 440); //Fecha


            

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

      



        #endregion #Sucursales


        #region Bancos

        #region Eventos

        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizarPedidoBanco_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime fecha = dtpFechaBanco.Value;

                Canal suc = cboCanal.SelectedIndex == 0 ?
                    null : (Canal)cboCanal.SelectedItem;
                byte? ruta = chkRutaBanco.Checked ?
                    (byte?)nudRutaBanco.Value : null;

                dgvCargasBancos.DataSource = _coordinacion.listarPedidosBancos(null, suc, fecha, ruta);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }



        /// <summary>
        /// Clic en el botón de imprimir.
        /// </summary>
        ///
        private void btnImprimirPedidoBanco_Click(object sender, EventArgs e)
        {
            PedidoBancos carga = (PedidoBancos)dgvCargasBancos.SelectedRows[0].DataBoundItem;

            this.imprimirHojaPedidoBanco(carga);
        }



        /// <summary>
        /// Clic en el botón de revisar.
        /// </summary>
        private void btnRevisarPedidoBanco_Click(object sender, EventArgs e)
        {
            this.mostrarVentanaRevisionPedidoBanco();
        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalirPedidoBanco_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Doble clic en la lista de cargas.
        /// </summary>
        private void dgvPedidoBanco_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                DataGridViewRow fila = dgvCargasBancos.SelectedRows[0];
                PedidoBancos carga = (PedidoBancos)fila.DataBoundItem;

                _pedido_banco = carga;

                this.mostrarVentanaRevisionPedidoBanco();

            }

        }

        /// <summary>
        /// Se agrega una carga a la lista de cargas.
        /// </summary>
        private void dgvPedidoBanco_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCargasBancos.Rows[e.RowIndex + contador];
                PedidoBancos carga = (PedidoBancos)fila.DataBoundItem;

                fila.Cells[ATMCarga.Index].Value = carga.ToString();

                if (carga.Colaborador_verificador != null)
                {

                    if (carga.Modificada)
                        fila.DefaultCellStyle.BackColor = Color.Green;
                    else
                        fila.DefaultCellStyle.BackColor = Color.LightGreen;

                }
                else if (carga.Cierre != null)
                {
                    fila.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (carga.Cajero != null)
                {
                    fila.DefaultCellStyle.BackColor = Color.LightCoral;
                }

            }

        }

        /// <summary>
        /// Se selecciona otra carga de la lista de cargas.
        /// </summary>
        private void dgvPedidoBanco_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCargasBancos.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvCargasBancos.SelectedRows[0];
                PedidoBancos carga = (PedidoBancos)fila.DataBoundItem;


                btnRevisarBanco.Enabled = true;
                btnImprimirBanco.Enabled = true;



            }
            else
            {

                btnRevisarBanco.Enabled = false;
                btnImprimirBanco.Enabled = false;
            }

        }

        /// <summary>
        /// Se marca o desmarca la opción de filtrar por ruta.
        /// </summary>
        private void chkRutaBanco_CheckedChanged(object sender, EventArgs e)
        {
            nudRutaBanco.Enabled = chkRutaBanco.Checked;
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Imprimir los datos de una hoja de carga.
        /// </summary>
        private void imprimirHojaPedidoBanco(PedidoBancos carga)
        {

            try
            {
                foreach(ManifiestoPedidoBanco m in carga.Manifiesto)
                {

                }
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        /// <summary>
        /// Mostrar la ventana de revisión de la carga.
        /// </summary>
        private void mostrarVentanaRevisionPedidoBanco()
        {
            PedidoBancos carga = (PedidoBancos)dgvCargasBancos.SelectedRows[0].DataBoundItem;
            _pedido_banco = carga;
            //if (_coordinacion.verificarExisteCargaVerificada(carga))
            //{
            foreach (ManifiestoPedidoBanco manifestito in carga.Manifiesto)
            {
                manifestito.Pedido = carga;
                ManifiestoPedidoBanco mani = manifestito;
                CrearPDFBanco(manifestito);

            }

            UnirPDFBanco(carga);
            frmVisualizarManifiesto visualizar = new frmVisualizarManifiesto(_pedido_banco);
            visualizar.ShowDialog();
            //}
            //frmVisualizarManifiesto formulario = new frmVisualizarManifiesto(_carga_sucursal);
            //formulario.ShowDialog();
        }



        /// <summary>
        /// Crea PDF para las Cargas de Bancos
        /// </summary>
        /// <param name="carga">Objeto ManifiestoSucursal con los datos de la Carga de Banco</param>
        public void CrearPDFBanco(ManifiestoPedidoBanco man)                  //Abre crear PDF Banco        
        {

            PedidoBancos carga = _pedido_banco;
            DateTime hoy = DateTime.Today;
            string actual = hoy.ToString("dd/MM/yyyy");
            string destinopdf = @"\\10.120.131.100\Manifiestos\BAN-" + man.ID.ToString() + ".pdf";          //DEFINE NOMBRE Y UBICACION DEL PDF QUE SE DESEA CREAR
            Stream output = new FileStream(destinopdf, FileMode.Create, FileAccess.Write);
            string plantilla = @"\\10.120.131.100\Releases\manifiesto5.pdf";          //DEFINE LA UBICACION Y EL NOMBRE DE LA PLANTILLA A USAR


            TipoCambio tip = null;
            tip = _mantenimiento.obtenerTipoCambio(dtpFechaSucursal.Value);
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



                //if (carga.EntregaBovedaSucursal == EntregaRecibo.Entregas)
                //{
                //    receptor = @"\\10.120.9.20\Blindados\Firmas\atencionsucursales-tripulacion" + carga.Tripulacion.ID.ToString() + "-colaboradorrecibe" + carga.Tripulacion.Portavalor.ID.ToString() + "-colaboradorentrega" + colaborador_recibo + "-fecha" + carga.Fecha_asignada.Year.ToString() + carga.Fecha_asignada.Month.ToString("00") + carga.Fecha_asignada.Day.ToString("00") + ".jpg";
                //    emisor = @"\\10.120.9.20\Blindados\Firmas\atencionsucursales-tripulacion" + carga.Tripulacion.ID.ToString() + "-colaboradorrecibe" + colaborador_recibo + "-colaboradorentrega" + carga.Tripulacion.Portavalor.ID.ToString() + "-fecha" + carga.Fecha_asignada.Year.ToString() + carga.Fecha_asignada.Month.ToString("00") + carga.Fecha_asignada.Day.ToString("00") + ".jpg";
                //}
                //else
                //{
                    receptor = @"\\10.120.9.20\Blindados\Firmas\atencionsucursales-tripulacion" + carga.Tripulacion.ID.ToString() + "-colaboradorrecibe" + carga.Tripulacion.Portavalor.ID.ToString() + "-colaboradorentrega" + colaborador_recibo + "-fecha" + carga.Fecha_asignada.Year.ToString() + carga.Fecha_asignada.Month.ToString("00") + carga.Fecha_asignada.Day.ToString("00") + ".jpg";
                    emisor = @"\\10.120.9.20\Blindados\Firmas\atencionsucursales-tripulacion" + carga.Tripulacion.ID.ToString() + "-colaboradorrecibe" + colaborador_recibo + "-colaboradorentrega" + carga.Tripulacion.Portavalor.ID.ToString() + "-fecha" + carga.Fecha_asignada.Year.ToString() + carga.Fecha_asignada.Month.ToString("00") + carga.Fecha_asignada.Day.ToString("00") + ".jpg";
                //}


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



            TipoCambio t = _mantenimiento.obtenerTipoCambio(dtpFechaSucursal.Value);

           

            SetFontBarCode(8);                   //ESTABLECE LA FUENTE E IMPRIME CON LA FUENTE BARCODE HASTA SER CAMBIADA
            PrintText("*" + man.ID.ToString() + "*", 335, 561);      //Imprime codigo de barras
            SetFont(13);
            PrintText("No: BAN-" + man.ID.ToString(), 335, 550);       //Imprime numero de manifiesto
            SetFont(8);                   //CAMBIAMOS LA FUENTE

            //montoLetrasPdf(montoenletras);   //Imprime monto total en letras y valida el tamaño

            PrintText(t.Venta.ToString("N0") + "/" + t.VentaEuros.ToString("N0"), 300, 525); //Imprime tipo de cambio
            PrintText(carga.Bolsas.Count.ToString(), 360, 525); //Cantidad depositos
            PrintText("1", 440, 525); //Imprime cantidad de manifiestos


            //LADO IZQUIERDO


                    PrintText("SERVICIO BANCARIO", 90, 490); //Origen de los fondos
                    PrintText("BAC San José", 59, 465); //Origen de los fondos
                    PrintText("Centro de Dist. Cipreses", 59, 440); //Origen de los fondos
                    PrintText("CURRIDABAT", 44, 416); //Origen de los fondos
                    //PrintText("SAN JOSE", 175, 417); //Provincia
                    PrintText(carga.Hora_inicio.ToShortDateString(), 230, 384); //Fecha de Entrega
                    //PrintText(carga.Canal.Provincia.ToString(), 175, 417); //Provincia

                    if (carga.Cajero != null)
                        PrintText(carga.Cajero.ToString(), 19, 384); //Nombre de Persona que preparó cargamento

                    if (carga.Tripulacion.Portavalor != null)
                        PrintText("BAC SAN JOSE", 52, 354);//PrintText(carga.Tripulacion.Portavalor.ToString(), 52, 354); //Entregado a

                    //if (carga.Canal.Direccion != null)
                    //    PrintText(carga.Canal.Direccion.ToString(), 45, 330);// Direccion


                    //PrintText(carga.Canal.Provincia.ToString(), 178, 307); //Provincia


                    //PrintText(carga.Canal.Provincia.ToString(), 45, 307); //Ciudad

                    if (carga.Canal != null)
                    {
                        PrintText(carga.Canal.Nombre, 201, 353); //Oficinas

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
            foreach (BolsaBanco b in man.Serie_Tula)
            {
                BolsaBanco copia = b;

                montocol = 0;
                montodol = 0;
                montoeur = 0;

                foreach (BolsaMontoPedidoBanco mont in copia.Cartuchos)
                {
                    if (mont.Denominacion.Moneda == Monedas.Colones)
                    {
                        montocol = montocol + mont.Cantidad_asignada;
                    }
                    if (mont.Denominacion.Moneda == Monedas.Dolares)
                    {
                        montodol = montocol + mont.Cantidad_asignada;
                    }
                    if (mont.Denominacion.Moneda == Monedas.Euros)
                    {
                        montoeur = montocol + mont.Cantidad_asignada;
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

            foreach (BolsaBanco b in man.Serie_Tula)
            {
                foreach (BolsaMontoPedidoBanco bol in b.Cartuchos)
                {

                    if (bol.Denominacion.Moneda == Monedas.Dolares)
                    {
                        montito_total = montito_total + (bol.Cantidad_asignada * tipocambio);
                    }
                    if (bol.Denominacion.Moneda == Monedas.Euros)
                    {
                        montito_total = montito_total + (bol.Cantidad_asignada * tipocambioeuros);
                    }
                    else
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
            PrintText(man.Serie_Tula.Count.ToString(), 311, 465);
            PrintText(carga.Hora_inicio.ToShortTimeString(), 305, 420);
            PrintText(carga.Hora_finalizacion.ToShortTimeString(), 358, 420);
            PrintText(dtpFechaBanco.Value.ToShortDateString(), 333, 440); //Fecha




            //Obtiene el nombre del portavalor.
            _coordinacion.listarPortavalorPorPedidoBanco(ref carga);

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



            PrintText(carga.Ruta.ToString(), 369, 175); //Ruta 
            PrintText(man.Serie_Tula.Count.ToString(), 317, 175);// Bultos
            PrintText(carga.Fecha_asignada.ToShortDateString(), 416, 175);// Fecha

            //////////////////////////////////////Quitar el número de ATM  08/04/2014///////////////////////////////////////////////////////


            PrintText(carga.Observaciones, 325, 450);


            _pcb.EndText();
            writer.Flush();

            if (readerBicycle == null)
                readerBicycle.Close();

            documento.Close();   //Cierra crear PDF Sucursal


        }              //Cierra crear PDF Sucursales



        /// <summary>
        /// Une los manifiesto de una determinada 
        /// </summary>
        /// <param name="c"></param>
        public void UnirPDFBanco(PedidoBancos c)
        {
            Document doc = new Document();
            try
            {
                ManipulacionPDF m = new ManipulacionPDF();
                string[] final = new string[c.Manifiesto.Count];
                int i = 0;

                foreach (ManifiestoPedidoBanco man in c.Manifiesto)
                {
                    final[i] = @"\\10.120.131.100\Manifiestos\BAN-" + man.ID.ToString() + ".pdf";
                    i++;
                }

                //m.MergePdfFiles(final, @"\\10.120.131.100\ECARD\Final_Validacion\FINALSUCURSAL-" + c.ID + ".pdf");

                string rutafinal = @"\\10.120.131.100\ECARD\Final_Validacion\FINALBANCO-" + c.ID + ".pdf";





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


        

       
        #endregion Bancos



        /// <summary>
        /// Imprime el documento para sucursales
        /// </summary>
        private void pdDocumentoSucursales_PrintPage(object sender, PrintPageEventArgs e)
        {
            this.imprimirSucursales(e);
        }



        /// <summary>
        /// Imprimir los datos de un manifiesto.
        /// </summary>
        private void imprimirSucursales(PrintPageEventArgs e)
        {

            System.Drawing.Font _fuente = new System.Drawing.Font("Arial", 10);
            System.Drawing.Font _fuente_pequena = new System.Drawing.Font("Arial", 7);
            System.Drawing.Font _fuente_grande = new System.Drawing.Font("Arial", 14);

            e.Graphics.PageUnit = GraphicsUnit.Millimeter;



            TipoCambio _tipocambio = _mantenimiento.obtenerTipoCambio(_carga_sucursal.Fecha_asignada);

            // Imprimir los datos fijos






            CargaSucursal carga = _carga_sucursal;
           
            TipoCambio tip = null;
            tip = _mantenimiento.obtenerTipoCambio(dtpFechaSucursal.Value);
            int tipocambio = (int)tip.Venta;
            int tipocambioeuros = (int)tip.VentaEuros;
           
            string receptor = "";
            string emisor = "";

            if (carga.Tripulacion == null)
            {
                carga.Tripulacion = new Tripulacion();
            }

            string colaborador_recibo = "";

            if (carga.ColaboradorRecibidoBoveda != null)
            {
                colaborador_recibo = carga.ColaboradorRecibidoBoveda.ID.ToString();
            }


          
            TipoCambio t = _mantenimiento.obtenerTipoCambio(dtpFechaSucursal.Value);

            // Imprimir número de manifiesto

            //e.Graphics.DrawString("No: SUC-" + _manifiesto_sucursal.ID.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(3, 0)); // Origen de los fondos


            //Imprime Tipo de Cambio
            e.Graphics.DrawString(t.Venta.ToString("N0") + "/" + t.VentaEuros.ToString("N0"), _fuente, Brushes.Black, _esquema.obtenerPunto(1, 0)); // Origen de los fondos

            //Imprime cantidad de depósitos
            e.Graphics.DrawString(carga.Cartuchos.Count.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(2, 0)); // Origen de los fondos
            //Imprime Cantidad de Manifiestos 
            e.Graphics.DrawString("1", _fuente, Brushes.Black, _esquema.obtenerPunto(21, 0));

            e.Graphics.DrawString("1", _fuente, Brushes.Black, _esquema.obtenerPunto(21, 0)); 

      

            //LADO IZQUIERDO

            if (carga.EntregaBovedaSucursal == EntregaRecibo.Entregas)
            {
              //  //Origen de los Fondos
              //  e.Graphics.DrawString("SERVICIO  BANCARIO", _fuente, Brushes.Black, _esquema.obtenerPunto(3, 0));
              //  //Recibo De
              //  e.Graphics.DrawString(carga.Sucursal.Nombre, _fuente, Brushes.Black, _esquema.obtenerPunto(4, 0)); 
              //  //Canton
              //  e.Graphics.DrawString(carga.Sucursal.Provincia.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(5, 0));
                
              ////  PrintText(carga.Sucursal.Provincia.ToString(), 175, 417); //Provincia
              //  //Fecha Entrega
              //  e.Graphics.DrawString(carga.Hora_inicio.ToShortDateString(), _fuente, Brushes.Black, _esquema.obtenerPunto(8, 0)); 


              //  if (carga.Cajero != null)
              //      e.Graphics.DrawString(carga.Cajero.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(22, 0)); 
                    
              //  if (carga.Tripulacion.Portavalor != null)
              //      e.Graphics.DrawString("BAC SAN JOSE", _fuente, Brushes.Black, _esquema.obtenerPunto(22, 0)); 
  

              //  if (carga.Sucursal.Direccion != null)
              //      e.Graphics.DrawString(carga.Sucursal.Direccion, _fuente, Brushes.Black, _esquema.obtenerPunto(11, 0));

              //  //Dirección
              //  e.Graphics.DrawString("Centro de Dist. Cipreses", _fuente, Brushes.Black, _esquema.obtenerPunto(11, 0));
              //  //Ciudad
              //  e.Graphics.DrawString("CURRIDABAT", _fuente, Brushes.Black, _esquema.obtenerPunto(12, 0));
              //  //Provincia
              //  e.Graphics.DrawString("SAN JOSE", _fuente, Brushes.Black, _esquema.obtenerPunto(13, 0)); 

              //  if (carga.Sucursal != null)
              //  {
              //     // PrintText("CURRIDABAT", 201, 353); //Oficinas
              //      //PrintText("Centro de Dist. Cipreses", 323, 60); //DIRECCION
              //      //PrintText("SAN JOSE", 323, 228); //Provincia

              //  }

            }
            else
            {
                if (carga.EntregaBovedaSucursal == EntregaRecibo.Pedidos)
                {
                    //Origen de los Fondos
                    e.Graphics.DrawString("SERVICIO  BANCARIO", _fuente, Brushes.Black, _esquema.obtenerPunto(3, 0));
                    //Recibo De:
                    e.Graphics.DrawString("BAC San José", _fuente, Brushes.Black, _esquema.obtenerPunto(4, 0));
                    //Dirección
                    e.Graphics.DrawString("Centro de Dist. Cipreses", _fuente, Brushes.Black, _esquema.obtenerPunto(5, 0));
                    //Canton
                    e.Graphics.DrawString("CURRIDABAT", _fuente, Brushes.Black, _esquema.obtenerPunto(6, 0));
                    //Provincia
                    e.Graphics.DrawString("SAN JOSE", _fuente, Brushes.Black, _esquema.obtenerPunto(7, 0));

                    e.Graphics.DrawString(carga.Hora_inicio.ToShortDateString(), _fuente, Brushes.Black, _esquema.obtenerPunto(8, 0)); 
                    //PrintText(carga.Sucursal.Provincia.ToString(), 175, 417); //Provincia
                    //Cajero
                    if (carga.Cajero != null)
                        e.Graphics.DrawString(carga.Cajero.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(22, 0)); 
                       
                    if (carga.Tripulacion.Portavalor != null)
                        e.Graphics.DrawString("BAC SAN JOSE", _fuente, Brushes.Black, _esquema.obtenerPunto(9, 0)); 
                       
                    //Direccion

                    if (carga.Sucursal.Direccion != null)
                        e.Graphics.DrawString(carga.Sucursal.Direccion.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(11, 0));

                    //Ciudad
                    e.Graphics.DrawString(carga.Sucursal.Provincia.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(12, 0));
                    //Provincia
                    e.Graphics.DrawString(carga.Sucursal.Provincia.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(13, 0)); 
          


                    if (carga.Sucursal != null)
                    {
                        //Oficinas
                        e.Graphics.DrawString(carga.Sucursal.Nombre, _fuente, Brushes.Black, _esquema.obtenerPunto(10, 0)); 

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
            int linea = 0;
            foreach (Bolsa b in _manifiesto_sucursal.ListaBolsas)
            {
                Bolsa copia = b;

                montocol = 0;
                montodol = 0;
                montoeur = 0;


                PointF posicion_monto = _esquema.obtenerPunto(17, linea);
                PointF posicion_marchamo = _esquema.obtenerPunto(14, linea);
                PointF posicion_bolsa = _esquema.obtenerPunto(15, linea);
                PointF posicion_cantidad = _esquema.obtenerPunto(16, linea);



                foreach (BolsaMontosSucursales mont in copia.Cartuchos)
                {
                    if (mont.Denominacion.Moneda == Monedas.Colones)
                    {
                        montocol = montocol + mont.Cantidad_asignada;
                    }
                    if (mont.Denominacion.Moneda == Monedas.Dolares)
                    {
                        montodol = montocol + mont.Cantidad_asignada;
                    }
                    if (mont.Denominacion.Moneda == Monedas.Euros)
                    {
                        montoeur = montocol + mont.Cantidad_asignada;
                    }
                }
                if (montocol > 0)
                {

                    e.Graphics.DrawString(copia.SerieBolsa, _fuente, Brushes.Black, posicion_marchamo); // Marchamo
                    e.Graphics.DrawString("B", _fuente, Brushes.Black, posicion_bolsa); // Marchamo
                    e.Graphics.DrawString("1", _fuente, Brushes.Black, posicion_cantidad); // Marchamo
                    e.Graphics.DrawString(("CRC " + montocol.ToString("N2")), _fuente, Brushes.Black, posicion_monto); // Marchamo
                    linea++;
                }

                if (montodol > 0)
                {
                     posicion_monto = _esquema.obtenerPunto(17, linea);
                     posicion_marchamo = _esquema.obtenerPunto(14, linea);
                     posicion_bolsa = _esquema.obtenerPunto(15, linea);
                     posicion_cantidad = _esquema.obtenerPunto(16, linea);

                    e.Graphics.DrawString(copia.SerieBolsa, _fuente, Brushes.Black, posicion_marchamo); // Marchamo
                    e.Graphics.DrawString("B", _fuente, Brushes.Black, posicion_bolsa); // Marchamo
                    e.Graphics.DrawString("1", _fuente, Brushes.Black, posicion_cantidad); // Marchamo
                    e.Graphics.DrawString(("USD " + montodol.ToString("N2")), _fuente, Brushes.Black, posicion_monto); // Marchamo

                    linea = linea++;
                }

                if (montoeur > 0)
                {
                    //e.Graphics.DrawString(copia.SerieBolsa, _fuente, Brushes.Black, posicion_marchamo); // Marchamo
                    //e.Graphics.DrawString("B", _fuente, Brushes.Black, posicion_bolsa); // Marchamo
                    //e.Graphics.DrawString("1", _fuente, Brushes.Black, posicion_bolsa); // Marchamo
                    //e.Graphics.DrawString(("EUR " + montodol.ToString("N2")), _fuente, Brushes.Black, posicion_bolsa); // Marchamo

                    //linea = linea++;
                }


                linea++;

            }

            decimal montito_total = 0;

            foreach (Bolsa b in _manifiesto_sucursal.ListaBolsas)
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
                    else
                    {
                        montito_total = montito_total + bol.Cantidad_asignada;
                    }
                }
            }

            string montito_total_letras = _coordinacion.convertirMontoaLetras(montito_total.ToString());
            string monto = montito_total_letras + " DE COLONES";



            e.Graphics.DrawString(monto, _fuente, Brushes.Black, _esquema.obtenerPunto(23, 0));

            // Muestra total manifiesto


            e.Graphics.DrawString(("CRC " + montito_total.ToString("N2")), _fuente, Brushes.Black, _esquema.obtenerPunto(20, 0));
            //LADO DERECHO

            //if (carga.Tripulacion != null)
            //      e.Graphics.DrawString((carga.Tripulacion.Portavalor.ToString()), _fuente, Brushes.Black, _esquema.obtenerPunto(24, 0));

            ////Ruta
            //e.Graphics.DrawString(carga.Ruta.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(26, 0));
            ////Bultos
            //e.Graphics.DrawString(_manifiesto_sucursal.ListaBolsas.Count.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(25, 0));
            ////Hora de Llegada
            //e.Graphics.DrawString(carga.Hora_inicio.ToShortTimeString(), _fuente, Brushes.Black, _esquema.obtenerPunto(26, 0));
            ////Hora de Finalización
            //e.Graphics.DrawString(carga.Hora_finalizacion.ToShortTimeString(), _fuente, Brushes.Black, _esquema.obtenerPunto(26, 0));
            ////Fecha
            //e.Graphics.DrawString(dtpFechaSucursal.Value.ToShortDateString(), _fuente, Brushes.Black, _esquema.obtenerPunto(26, 0));

          




            ////Obtiene el nombre del portavalor.
            //_coordinacion.listarPortavalorPorCargaSucursal(ref carga);

            //if (carga.ColaboradorRecibidoBoveda != null)
            //{
            //    e.Graphics.DrawString((carga.ColaboradorRecibidoBoveda + " " + carga.ColaboradorRecibidoBoveda.Identificacion), _fuente, Brushes.Black, _esquema.obtenerPunto(30, 0));
           
            //    //PrintText((carga.ColaboradorRecibidoBoveda + " " + carga.ColaboradorRecibidoBoveda.Identificacion), 320, 578);
            //}
           

            ////Ruta
            //e.Graphics.DrawString(carga.Ruta.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(32, 0));

            ////
            //e.Graphics.DrawString(_manifiesto_sucursal.ListaBolsas.Count.ToString(), _fuente, Brushes.Black, _esquema.obtenerPunto(31, 0));

            //e.Graphics.DrawString(carga.Fecha_asignada.ToShortDateString(), _fuente, Brushes.Black, _esquema.obtenerPunto(33, 0));


            //////////////////////////////////////Quitar el número de ATM  08/04/2014///////////////////////////////////////////////////////


           // PrintText(carga.Observaciones, 325, 450);



        }


        /// <summary>
        /// Imprime los documentos de banco
        /// </summary>
        private void pdDocumentoBancos_PrintPage(object sender, PrintPageEventArgs e)
        {
            imprimirBancos(e);
        }



        private void imprimirBancos(PrintPageEventArgs e)
        {
 
        }



    }
}
