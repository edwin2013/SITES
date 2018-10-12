using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects;
using CommonObjects.Clases;
using OnBarcode;
using OnBarcode.Barcode;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using BussinessLayer;

namespace GUILayer.Formularios.Boveda
{
    public partial class frmManifiestoGeneral : Form
    {
        #region Atributos

        CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        AtencionBL _atencion = AtencionBL.Instancia;
        MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        
        DescargaATM _carga_atm = null;
        CargaSucursal _carga_sucursal = null;
        PedidoBancos _pedido_banco = null;
        Denominacion _denominacion = null;

        TipoCambio _tipocambio = null;
        Colaborador _usuario = null;


        private static readonly BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);         //DEFINE UN TIPO DE FUENTE PARA ESCRIBIR EN EL DOCUMENTO
        BaseFont font2 = BaseFont.CreateFont(@"\\10.120.131.100\Releases\ConnectCode39.ttf", BaseFont.WINANSI, BaseFont.EMBEDDED);     //DEEFINE LA FUENTE PARA IMPRIMIR CODIGO DE BARRAS
        PdfContentByte _pcb;     // OBJETO QUE CONTIENE EL TEXTO DE USUARIO POSICIONADO Y EL CONTENIDO GRÁFICO DE LA PAGINA SOBRE LA QUE SE VA A TRABAJAR

        string montoenletras = "";
       
        #endregion Atributos


        #region Constructor

        /// <summary>
        /// Constructor CargaATM
        /// </summary>
        /// <param name="atm"></param>
        public frmManifiestoGeneral(DescargaATM atm)
        {
            InitializeComponent();
            dgvCargas.AutoGenerateColumns = false;

            _mantenimiento.obtenerTipoCambio(atm.Carga.Fecha_asignada);
            _carga_atm = atm;
            mostrarDatosCargaATM();
            CrearPDFATM();
            frmVisualizarManifiesto formulario = new frmVisualizarManifiesto(_carga_atm);
            formulario.ShowDialog();
            
        }


        /// <summary>
        /// Constructor CargaSucursal
        /// </summary>
        /// <param name="sucursal"></param>
        public frmManifiestoGeneral(CargaSucursal sucursal)
        {
            InitializeComponent();
            dgvCargas.AutoGenerateColumns = false;
            _carga_sucursal = sucursal;
            //mostrarDatosCargaSucursal();
            CrearPDFSucursal();
                        
        }

        /// <summary>
        /// Constructor PedidoBanco
        /// </summary>
        /// <param name="bancos"></param>
        public frmManifiestoGeneral(PedidoBancos bancos)
        {
            InitializeComponent();
            dgvCargas.AutoGenerateColumns = false;
            _pedido_banco = bancos;
            mostrarDatosPedidoBanco();
            CrearPDFBanco();
            
        }

        #endregion Constructor

        #region Metodos Publicos

        public void llenarManifiesto()
        {
            if (_carga_atm != null)
            {
                CrearPDFATM();
            }
            if (_carga_sucursal != null)
            {
                CrearPDFSucursal();
            }
            if (_pedido_banco != null)
            {
               
            }
        }

        /// <summary>
        /// Crea PDF para las Cargas ATM
        /// </summary>
        /// <param name="carga">Objeto CargaATM con los datos de la Carga del ATM</param>
        public void CrearPDFATM()                  //Abre crear PDF ATM        
        {                 
            mostrarDatosCargaATM();

            DescargaATM carga = _carga_atm;
            DateTime hoy = DateTime.Today;
            string actual = hoy.ToString("dd/MM/yyyy");
            string destinopdf = @"\\10.120.131.100\Manifiestos\ATM-" + _carga_atm.Manifiesto + ".pdf";          //DEFINE NOMBRE Y UBICACION DEL PDF QUE SE DESEA CREAR
            Stream output = new FileStream(destinopdf, FileMode.Create, FileAccess.Write);
            string plantilla = @"\\10.120.131.100\Releases\manifiesto5.pdf";          //DEFINE LA UBICACION Y EL NOMBRE DE LA PLANTILLA A USAR

            PdfReader readerBicycle = null;
            Document documento = new Document();
            FileStream theFile = new FileStream(plantilla, FileMode.Open, FileAccess.Read);
            PdfWriter writer = PdfWriter.GetInstance(documento, output);
            documento.Open();
            readerBicycle = new PdfReader(theFile);
            PdfTemplate background = writer.GetImportedPage(readerBicycle, 1);
            documento.NewPage();
            


            iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(@"\\10.120.9.20\Blindados\Firmas\atencionsucursales-tripulacion1352-colaboradorrecibe228-colaboradorentrega135-fecha20140715.jpg");
                
                //iTextSharp.text.Image.GetInstance(@"\\10.120.9.20\Blindados\Firmas\atencionsucursales-tripulacion"+carga.Carga.Tripulacion.ID.ToString()+
                //"-colaboradorrecibe"+carga.Carga.Tripulacion.Portavalor.ID.ToString()+"-colaboradorentrega135-fecha"+carga.Fecha.Year.ToString()+carga.Fecha.Month.ToString()+carga.Fecha.Day.ToString()+".jpg");

            iTextSharp.text.Image pic2 = iTextSharp.text.Image.GetInstance(@"\\10.120.9.20\Blindados\Firmas\atencionsucursales-tripulacion1352-colaboradorrecibe228-colaboradorentrega135-fecha20140715.jpg");

            iTextSharp.text.Image pic3 = iTextSharp.text.Image.GetInstance(@"\\10.120.9.20\Blindados\Firmas\atencionsucursales-tripulacion1352-colaboradorrecibe228-colaboradorentrega135-fecha20140715.jpg");


            //pic.RotationDegrees = 90;
            //pic2.RotationDegrees = 90;
            //pic3.RotationDegrees = 90;

            _pcb = writer.DirectContentUnder;
            _pcb.AddTemplate(background, 0, 0);
            _pcb = writer.DirectContent;
            _pcb.BeginText();


            pic.ScaleAbsolute(75, 45);
            pic.SetAbsolutePosition(440, 462);
            documento.Add(pic);


            pic2.ScaleAbsolute(75, 45);
            pic2.SetAbsolutePosition(442, 357);
            documento.Add(pic2);


            pic3.ScaleAbsolute(75, 35);
            pic3.SetAbsolutePosition(442, 157);
            documento.Add(pic3);

            //pic.ScaleAbsolute(25, 20);
            //pic.SetAbsolutePosition(500, 384);
            //documento.Add(pic);

            

            SetFontBarCode(8);                   //ESTABLECE LA FUENTE E IMPRIME CON LA FUENTE BARCODE HASTA SER CAMBIADA
            PrintText("*" + carga.Manifiesto.Codigo + "*", 335, 561);      //Imprime codigo de barras
            SetFont(6);
            PrintText("No: ATM-"+carga.Manifiesto.Codigo, 335, 545);       //Imprime numero de manifiesto
            SetFont(8);                   //CAMBIAMOS LA FUENTE
            
            montoLetrasPdf(montoenletras);   //Imprime monto total en letras y valida el tamaño

            PrintText(_tipocambio.Venta.ToString("N2"), 311, 525); //Imprime tipo de cambio
            PrintText(carga.Cartuchos.Count.ToString(), 360, 525); //Cantidad depositos
            PrintText("1", 440, 517); //Imprime cantidad de manifiestos

            //LADO IZQUIERDO
            
            PrintText("ATM", 90,490); //Origen de los fondos
            PrintText("BAC San José", 184, 60); //Recibido de
            PrintText("Centro de Dist. Cipreses", 59, 465); //Direccion
            PrintText("CURRIDABAT", 44, 416); //Ciudad
            PrintText("SAN JOSE", 175, 417); //Provincia
            PrintText(carga.Carga.Cajero.ToString(), 19, 384); //Nombre de Persona que preparó cargamento
            PrintText(carga.Carga.Fecha_asignada.ToShortDateString(), 230, 384); //Fecha de Entrega
            if(carga.Carga.Tripulacion != null)
                PrintText(carga.Carga.Tripulacion.Portavalor.ToString(), 52, 354); //Entregado a
            else
                PrintText("", 52, 354);
            PrintText(carga.ATM.Oficinas, 223, 354); //Oficinas
            PrintText("Centro de Dist. Cipreses", 45, 330); //Direccion
            PrintText("CURRIDABAT", 46, 306); //CIUDAD
            PrintText("SAN JOSE", 178, 307); //Provincia
            
          
            //MARCHAMOS BT BULTOS Y MONTO

            PrintText(carga.Carga.Manifiesto.Codigo, 362, 77); //Provincia
            
                //int bultos = 0;
                //if (carga.Cartuchos.Count > 5)
                //{
                    int fila = 155;
                    if (carga.Carga.Monto_asignado_colones > 0)
                    {
                        PrintText(("CRC " + carga.Carga.Monto_asignado_colones.ToString("N2")), 148, fila); /*MONTO colones*/
                        PrintText("1", 86, fila); /*BULTOS*/
                        PrintText("B", 110, fila); /*BT*/
                        PrintText(carga.Manifiesto.Marchamo, 20, fila); /*BT*/ 
                        fila = fila - 20;
                    }
                    if (carga.Carga.Monto_asignado_dolares > 0)
                    {
                        PrintText(("USD " + carga.Carga.Monto_asignado_dolares.ToString("N2")), 246, fila); /*MONTO dolares*/
                        PrintText("1", 111, fila); /*BULTOS*/
                        PrintText("B", 85, fila); /*BT*/
                        PrintText(carga.Manifiesto.Marchamo, 20, fila); /*BT*/
                        fila = fila - 20;
                    }
                    if (carga.Carga.Monto_asignado_euros > 0)
                    {
                        PrintText(("EUR " + carga.Carga.Monto_asignado_euros.ToString("N2")), fila, 226); /*MONTO Euros*/
                        PrintText("1", 114, fila); /*BULTOS*/
                        PrintText("B", 85, fila); /*BT*/
                        PrintText(carga.Manifiesto.Marchamo, 20, fila); /*BT*/
                    }
               
            PrintText(lblGranTotal.Text, 149, 35);
                           
            //LADO DERECHO
            if (carga.Carga.Tripulacion != null)
                  PrintText(carga.Carga.ColaboradorRecibidoBoveda.ToString(), 303, 486); //Nombre portavalor recibe
            else
                PrintText("", 303, 486); //Nombre portavalor recibe

            PrintText(carga.Carga.Ruta.ToString(), 361, 460); //Ruta 
            PrintText(lblcantBultos.Text,311,460);
            PrintText(carga.Carga.Hora_Llegada.ToShortTimeString(), 305, 411);
            PrintText(carga.Carga.Hora_Salida.ToShortTimeString(), 358, 411);
            PrintText(carga.Carga.Fecha_asignada.ToShortDateString(), 333, 437); //Fecha
            PrintText(lblPortavalorRuta.Text, 306, 375); //Responsable Ruta
            
            PrintText(carga.ATM.Numero.ToString(), 304, 350); //Numero de ATM

            if(carga.ATM.Full)
                PrintText("X", 365, 325); // x de normal
            else
                PrintText("X", 306, 325); //x de full

            PrintText(("CRC " + carga.Monto_descarga_colones.ToString("N2")), 311, 312); //monto descarga colones
            PrintText(("USD " + carga.Monto_descarga_dolares.ToString("N2")), 318, 300); //monto descarga dolares
            PrintText(carga.Manifiesto.Bolsa_rechazo, 313, 252); //Numero de marchamo de rechazo
            PrintText(lblComentario.Text, 311, 230);

            
            if (carga.ATM.Full)
                PrintText(carga.Carga.Manifiesto_full.Marchamo, 379, 499); //monto descarga dolares
            else
                PrintText(carga.Manifiesto.Marchamo_adicional, 379, 499);// marchamo adicional
            
            
            _pcb.EndText();
            writer.Flush();
            
            if (readerBicycle == null)
                readerBicycle.Close();
            documento.Close();



        }              //Cierra crear PDF ATM


        /// <summary>
        /// Crea PDF para los Pedidos de los Bancos
        /// </summary>
        /// <param name="carga">Objeto PedidoBancos con los datos de la Carga del ATM</param>
        public void CrearPDFBanco()               //Abre crear PDF Banco       
        {
            mostrarDatosPedidoBanco();

            PedidoBancos banco = _pedido_banco;
            DateTime hoy = DateTime.Today;
            string actual = hoy.ToString("dd/MM/yyyy");
            string destinopdf = @"\\10.120.131.100\Manifiestos\BANCO-" + banco.Manifiesto + ".pdf";        //DEFINE NOMBRE Y UBICACION DEL PDF QUE SE DESEA CREAR
            Stream output = new FileStream(destinopdf, FileMode.Create, FileAccess.Write);
            string plantilla = @"\\10.120.131.100\Releases\manifiesto.pdf";         //DEFINE LA UBICACION Y EL NOMBRE DE LA PLANTILLA A USAR

            PdfReader readerBicycle = null;
            Document documento = new Document();
            FileStream theFile = new FileStream(plantilla, FileMode.Open, FileAccess.Read);
            PdfWriter writer = PdfWriter.GetInstance(documento, output);
            documento.Open();
            readerBicycle = new PdfReader(theFile);
            PdfTemplate background = writer.GetImportedPage(readerBicycle, 1);
            documento.NewPage();


            _pcb = writer.DirectContentUnder;
            _pcb.AddTemplate(background, 0, 0);
            _pcb = writer.DirectContent;
            _pcb.BeginText();

            SetFontBarCode(11);                   //ESTABLECE LA FUENTE E IMPRIME CON LA FUENTE BARCODE HASTA SER CAMBIADA
           // PrintText("*" + banco.Manifiesto.Codigo + "*", 250, 700);      //Imprime codigo de barras
            SetFont(13);
           // PrintText(banco.Manifiesto.Codigo, 450, 705);       //Imprime numero de manifiesto
            SetFont(8);                          //CAMBIAMOS LA FUENTE
            
            montoLetrasPdf(montoenletras);  //Imprime monto total en letras y valida el tamaño

            PrintText(lblTipoCambio.Text, 355, 670); //Imprime tipo de cambio
            PrintText(lblCantDepositos.Text , 415, 1670); //Cantidad depositos
            //PrintText("MANIS", 480, 670); //Imprime tipo de cambio

            //LADO IZQUIERDO


            PrintText("PEDIDOS BANCOS", 87, 632); //Origen de los fondos
            PrintText("BAC San José", 87, 610); //Origen de los fondos
            PrintText("Centro de Dist. Cipréses", 87, 589); //Origen de los fondos
            PrintText("CURRIDABAT", 87, 568); //Origen de los fondos
            PrintText("SAN JOSE", 202, 568); //Provincia
            PrintText(banco.Cajero.ToString(), 87, 547); //Nombre de Persona que preparó cargamento
            PrintText(banco.Fecha_asignada.ToShortDateString(), 265, 547); //Fecha de Entrega
            PrintText(banco.Colaborador_verificador.ToString(), 87, 525); //Entregado a
            PrintText(banco.ToString(), 252, 525); //Oficinas           
            PrintText("Centro de Dist. Cipreses", 87, 505); //Direccion
            PrintText("CURRIDABAT", 87, 483); //Origen de los fondos
            PrintText("SAN JOSE", 225, 483); //Provincia

            
            //MARCHAMOS BT BULTOS Y MONTO

            int bultos = 0;
            if (banco.Bolsas.Count > 5)
            {
                if (banco.Monto_asignado_colones > 0)
                {
                    PrintText(("CRC " + banco.Monto_asignado_colones.ToString("N2")), 225, 454); /*MONTO colones*/
                }
                if (banco.Monto_asignado_dolares > 0)
                {
                    PrintText(("USD " + banco.Monto_asignado_dolares.ToString("N2")), 225, 432); /*MONTO dolares*/
                }
                if (banco.Monto_asignado_dolares > 0)
                {
                    PrintText(("EUR " + banco.Monto_asignado_dolares.ToString("N2")), 225, 411); /*MONTO Euros*/
                }
            }
            else
            {
                int fila = 454;

                
                foreach (BolsaCargaBanco bolsabanco in banco.Bolsas)
                {


                    switch (bolsabanco.Denominacion.Moneda)
                    {
                        case Monedas.Colones:
                            PrintText(("CRC " + bolsabanco.Monto_carga.ToString("N2")), 225, fila); /*MONTO colones*/

                            PrintText(bolsabanco.Marchamo.ToString(), 87, fila); /*MONTO colones*/

                            PrintText("1", 200, fila); /*BULTOS*/

                            PrintText("B", 175, fila); /*BT*/

                            fila = fila - 22;

                            bultos++;

                            break;

                        case Monedas.Dolares:

                            PrintText(("USD " + bolsabanco.Monto_carga.ToString("N2")), 225, fila); /*MONTO dolares*/

                            PrintText(bolsabanco.Marchamo.ToString(), 87, fila); /*MONTO dolares*/

                            PrintText("1", 200, fila); /*BULTOS*/

                            PrintText("B", 175, fila); /*BT*/

                            fila = fila - 22;

                            bultos++;

                            break;

                        case Monedas.Euros:

                            PrintText(("EUR " + bolsabanco.Monto_carga.ToString("N2")), 225, fila); /*MONTO euros*/

                            PrintText(bolsabanco.Marchamo.ToString(), 87, fila); /*MONTO euros*/

                            PrintText("1", 200, fila); /*BULTOS*/

                            PrintText("B", 175, fila); /*BT*/

                            fila = fila - 22;

                            bultos++;

                            break;

                    }
                }

            }

            PrintText("CRC " + lblGranTotal.Text, 225, 315);


            //LADO DERECHO
            PrintText(lblPortavalorRecibe.Text, 320, 632); //Nombre portavalor recibe
            PrintText(lblPortavalorRuta.Text, 320, 578); //Responsable Ruta
            PrintText(banco.ToString(), 358, 562); //Numero de Banco

            PrintText(lblDescargasColones.Text, 438, 538); //monto descarga colones
            PrintText(lblDescargaDolares.Text, 438, 518); //monto descarga dolares

            PrintText(banco.Ruta.ToString(), 440, 610); //Ruta 
            PrintText(bultos.ToString(), 332, 610);
            PrintText(banco.Hora_Entrada.ToShortTimeString(), 346, 610);
            PrintText(banco.Hora_Salida.ToShortTimeString(), 385, 610);
            PrintText(banco.Fecha_asignada.ToShortDateString(), 475, 610); //Fecha
           
            PrintText(lblnumeroatm.Text, 358, 562); //Numero de ATM

            PrintText(("CRC " + banco.Monto_carga_colones.ToString("N2")), 438, 538); //monto descarga colones
            PrintText(("USD " + banco.Monto_carga_dolares.ToString("N2")), 438, 518); //monto descarga dolares
            PrintText(lblBolsaMarchamo.Text, 438, 498); //Numero de marchamo de rechazo
            PrintText(lblComentario.Text, 325, 450);

            PrintText(lblTulaBNA.Text, 438, 478);
           
            _pcb.EndText();
            writer.Flush();
            if (readerBicycle == null)
                readerBicycle.Close();
            documento.Close();


        }              //Cierra crear PDF Banco



        /// <summary>
        /// Crea PDF para las Cargas de las Sucursales
        /// </summary>
        /// <param name="carga">Objeto CargaSucursal con los datos de la Carga de la Sucursal</param>

        public void CrearPDFSucursal()            //Abre crear PDF Sucursal    
        {
           // mostrarDatosCargaSucursal();
            
            CargaSucursal suc = _carga_sucursal;
            DateTime hoy = DateTime.Today;
            string actual = hoy.ToString("dd/MM/yyyy");
            string destinopdf = @"\\10.120.131.100\Manifiestos\SUC-" + suc.Manifiesto + ".pdf";      //DEFINE NOMBRE Y UBICACION DEL PDF QUE SE DESEA CREAR
            Stream output = new FileStream(destinopdf, FileMode.Create, FileAccess.Write);
            string plantilla = @"\\10.120.131.100\Releases\manifiesto.pdf";          //DEFINE LA UBICACION Y EL NOMBRE DE LA PLANTILLA A USAR

            PdfReader readerBicycle = null;
            Document documento = new Document();
            FileStream theFile = new FileStream(plantilla, FileMode.Open, FileAccess.Read);
            PdfWriter writer = PdfWriter.GetInstance(documento, output);
            documento.Open();
            readerBicycle = new PdfReader(theFile);
            PdfTemplate background = writer.GetImportedPage(readerBicycle, 1);
            documento.NewPage();


            _pcb = writer.DirectContentUnder;
            _pcb.AddTemplate(background, 0, 0);
            _pcb = writer.DirectContent;
            _pcb.BeginText();

            SetFontBarCode(11);                   //ESTABLECE LA FUENTE E IMPRIME CON LA FUENTE BARCODE HASTA SER CAMBIADA
            PrintText("*" + suc.Manifiesto + "*", 250, 700);      //Imprime codigo de barras
            SetFont(13);
            PrintText(suc.Manifiesto.ToString(), 450, 705);       
            SetFont(8);                         //CAMBIAMOS LA FUENTE

            montoLetrasPdf(montoenletras);   //Imprime monto total en letras y valida el tamaño

            PrintText("TIPO", 355, 670); //Imprime tipo de cambio
            PrintText("CANT", 415, 1670); //Cantidad depositos
            //PrintText("MANIS", 480, 670); //Imprime tipo de cambio

            //LADO IZQUIERDO


            PrintText(suc.Sucursal.ToString(), 87, 632); //Origen de los fondos
            PrintText("BAC San José", 87, 610); //Origen de los fondos
            PrintText("Centro de Dist. Cipréses", 87, 589); //Origen de los fondos
            PrintText("CURRIDABAT", 87, 568); //Origen de los fondos
            PrintText("SAN JOSE", 202, 568); //Provincia
            PrintText(suc.Cajero.ToString(), 87, 547); //Nombre de Persona que preparó cargamento
            PrintText(suc.Fecha_asignada.ToShortDateString(), 265, 547); //Fecha de Entrega
            PrintText(suc.Cajero.ToString(), 87, 525); //Entregado a
            PrintText(suc.ToString(), 252, 525); //Oficinas       
            PrintText("Centro de Dist. Cipreses", 87, 505); //Direccion
            PrintText("CURRIDABAT", 87, 483); //Origen de los fondos
            PrintText("SAN JOSE", 225, 483); //Provincia

           int bultos = 0;
            if (suc.Cartuchos.Count > 5)
            {
                if (suc.Monto_asignado_colones > 0)
                {
                    PrintText(("CRC " + suc.Monto_asignado_colones.ToString("N2")), 225, 454); /*MONTO colones*/
                }
                if (suc.Monto_asignado_dolares > 0)
                {
                    PrintText(("USD " + suc.Monto_asignado_dolares.ToString("N2")), 225, 432); /*MONTO dolares*/
                }
                if (suc.Monto_asignado_dolares > 0)
                {
                    PrintText(("EUR " + suc.Monto_asignado_dolares.ToString("N2")), 225, 411); /*MONTO Euros*/
                }
            }
            else
            {
                int fila = 454;

                
                foreach (CartuchoCargaSucursal cartucho in suc.Cartuchos)
                {


                    switch (cartucho.Denominacion.Moneda)
                    {
                        case Monedas.Colones:
                            PrintText(("CRC " + cartucho.Monto_carga.ToString("N2")), 225, fila); /*MONTO colones*/

                           // PrintText(cartucho.Marchamo.ToString(), 87, fila); /*MONTO colones*/

                            PrintText("1", 200, fila); /*BULTOS*/

                            PrintText("B", 175, fila); /*BT*/

                            fila = fila - 22;

                            bultos++;

                            break;

                        case Monedas.Dolares:

                            PrintText(("USD " + cartucho.Monto_carga.ToString("N2")), 225, fila); /*MONTO dolares*/

                            PrintText(cartucho.Marchamo.ToString(), 87, fila); /*MONTO dolares*/

                            PrintText("1", 200, fila); /*BULTOS*/

                            PrintText("B", 175, fila); /*BT*/

                            fila = fila - 22;

                            bultos++;

                            break;

                        case Monedas.Euros:

                            PrintText(("EUR " + cartucho.Monto_carga.ToString("N2")), 225, fila); /*MONTO euros*/

                            PrintText(cartucho.Marchamo.ToString(), 87, fila); /*MONTO euros*/

                            PrintText("1", 200, fila); /*BULTOS*/

                            PrintText("B", 175, fila); /*BT*/

                            fila = fila - 22;

                            bultos++;

                            break;

                    }
                }

            }

            PrintText("CRC " + lblGranTotal.Text, 225, 315);

            //LADO DERECHO
            PrintText(lblPortavalorRecibe.Text, 320, 632); //Nombre portavalor recibe
            PrintText(lblPortavalorRuta.Text, 320, 578); //Responsable Ruta
            PrintText(lblnumeroatm.Text, 358, 562); //Numero de Banco

            PrintText(suc.Monto_carga_colones.ToString("N2"), 438, 538); //monto descarga colones
            PrintText(suc.Monto_carga_dolares.ToString("N2"), 438, 518); //monto descarga dolares

            PrintText(suc.Ruta.ToString(), 440, 610); //Ruta 
            PrintText(suc.ToString(), 332, 610);
            PrintText(suc.Hora_Entrada.ToShortTimeString(), 346, 610);
            PrintText(suc.Hora_Salida.ToShortTimeString(), 385, 610);
            PrintText(suc.Fecha_asignada.ToShortDateString(), 475, 610); //Fecha
           
            PrintText(lblnumeroatm.Text, 358, 562); //Numero de ATM

            PrintText(("CRC " + suc.Monto_carga_colones.ToString("N2")), 438, 538); //monto descarga colones
            PrintText(("USD " + suc.Monto_carga_dolares.ToString("N2")), 438, 518); //monto descarga dolares
            PrintText(lblBolsaMarchamo.Text, 438, 498); //Numero de marchamo de rechazo
            PrintText(lblComentario.Text, 325, 450);

            PrintText(lblTulaBNA.Text, 438, 478);




        }              //Cierra crear PDF Sucursal





        public void mostrarDatosPedidoBanco()
        {             
            dgvCargas.DataSource = _pedido_banco.Bolsas;

            lblcantBultos.Text = _pedido_banco.Bolsas.Count.ToString();
            lblCantDepositos.Text = _pedido_banco.Bolsas.Count.ToString();
            lblCantManif.Text = "1";
            lblCiudadEnt.Text = "Curridabat";//_pedido_banco.NombreCanal.ToString();
            lblComentario.Text = _pedido_banco.Observaciones.ToString();
            lblDireccion.Text = _pedido_banco.Canal.Nombre.ToString();
            lblEncargado.Text = _pedido_banco.Cajero.ToString();
            lblEntregadoA.Text = _pedido_banco.Colaborador_verificador.ToString();
            lblFecha.Text = _pedido_banco.Fecha_asignada.ToLongDateString();
            lblFechaCargamento.Text = _pedido_banco.Fecha_verificacion.ToShortDateString();

            //Realiza la suma de Carga en colones mas la Carga de dolares en colones.
            lblGranTotal.Text = "CRC " + (_pedido_banco.Monto_pedido_colones + (_pedido_banco.Monto_pedido_dolares * (Convert.ToDecimal(lblTipoCambio.Text)))).ToString("N2");
            
            //Conviete el gran total en letras.
            string montototal = "";
            montototal = Convert.ToInt32(( _pedido_banco.Monto_asignado_colones + (_pedido_banco.Monto_asignado_dolares * (Convert.ToInt32(lblTipoCambio.Text))))).ToString();
            
            lblGranTotalLetras.Text = _coordinacion.convertirMontoaLetras(montototal) + "COLONES";
            montoenletras = lblGranTotalLetras.Text;
           
            lblHLlegada.Text = _pedido_banco.Hora_Entrada.ToShortDateString();
            lblHSalida.Text = _pedido_banco.Hora_Salida.ToShortDateString();
            lblNumero.Text = _pedido_banco.Manifiesto.ToString();
            lblnumeroatm.Text = "0";
            lblOrigenFondosR.Text = "Pedido Banco";
            lblProvinciaEnt.Text = _pedido_banco.Canal.Nombre.ToString();
            lblRuta.Text = _pedido_banco.Ruta.ToString();
            lblDescargaDolares.Text = "USD " + ( _pedido_banco.Monto_asignado_dolares).ToString("N2");
            lblDescargasColones.Text = "CRC " + (_pedido_banco.Monto_asignado_colones).ToString("N2");
            
              //Obtiene el nombre del portavalor.
            _coordinacion.listarPortavalorPorPedidoBanco(ref _pedido_banco);
            
            if (_pedido_banco.ColaboradorRecibidoBoveda != null)
            {
                lblPortavalorRecibe.Text = (_pedido_banco.ColaboradorRecibidoBoveda + " " + _pedido_banco.ColaboradorRecibidoBoveda.Identificacion).ToString();
                lblPortavalorRuta.Text = lblPortavalorRecibe.Text;
            }
            else
            {
                lblPortavalorRecibe.Text = string.Empty;
                lblPortavalorRuta.Text = string.Empty;
            }
            
            ///if (_atencion.listarBolsasSucursalPorManifiesto(_carga_sucursal.Manifiesto) != null)
            ////{
            ////    BindingList<Bolsa> bolsas =new BindingList<Bolsa>();
            ////    bolsas = _atencion.listarBolsasSucursalPorManifiesto(_carga_sucursal.Manifiesto);
                
            ////    lblcantBultos.Text = bolsas.Count.ToString();
            ////}
            ////else
            ////{    lblcantBultos.Text = "1"; 
                //    lblCantDepositos.Text = "1";
                //}

         
            if (_pedido_banco.Canal != null)
            {
                lblOficinasEntrega.Text = _pedido_banco.Canal.Nombre.ToString();
                lblOficinasEntrega.Text = lblOficinasEntrega.Text;
            }
            
            lblnumeroatm.Text = "0";
            lblBolsaMarchamo.Text = "-";
            rbFull.Enabled = false;
            lblTulaBNA.Text = "-";
            rbNormal.Enabled = false;
            
        }


                /// <summary>
        /// Mostrar los datos de carga de sucursal.
        /// </summary
        public void mostrarDatosCargaSucursal()
        {
            
            dgvCargas.DataSource = _carga_sucursal.Cartuchos;///******Bolsas o Cartuchos...
           
            lblCantManif.Text = "1"; 
            lblComentario.Text = _carga_sucursal.Observaciones.ToString();
            lblDireccionEnt.Text = _carga_sucursal.Sucursal.Direccion.ToString();
            lblEncargado.Text = "";// _carga_sucursal.Cajero.ToString();
            lblEntregadoA.Text = // _carga_sucursal.Colaborador_verificador.ToString();
            lblFecha.Text = _carga_sucursal.Fecha_asignada.ToShortDateString();
            lblFechaCargamento.Text = _carga_sucursal.Fecha_verificacion.ToShortDateString();
            
            //Realiza la suma de Carga en colones mas la Carga de dolares en colones.
            lblGranTotal.Text = "CRC " + (_carga_sucursal.Monto_asignado_colones + (_carga_sucursal.Monto_asignado_dolares * (Convert.ToInt32(lblTipoCambio.Text)))).ToString("N2");
           
             //Conviete el gran total en letras.
            string montototal = "";
            montototal = Convert.ToInt32((_carga_sucursal.Monto_asignado_colones + (_carga_sucursal.Monto_asignado_dolares * (Convert.ToInt32(lblTipoCambio.Text))))).ToString();
                       
            lblGranTotalLetras.Text = _coordinacion.convertirMontoaLetras(montototal) + "COLONES";
            montoenletras = lblGranTotalLetras.Text;

            lblHLlegada.Text = _carga_sucursal.Hora_Entrada.ToShortDateString();
            lblHSalida.Text = _carga_sucursal.Hora_Salida.ToShortDateString();
            lblNumero.Text = _carga_sucursal.Manifiesto.ToString();
            lblnumeroatm.Text = "0";
            lblOrigenFondosR.Text = "Sucursal";
            lblRuta.Text = _carga_sucursal.Ruta.ToString();
            lblDescargaDolares.Text = "USD " + (_carga_sucursal.Monto_asignado_dolares).ToString("N2");
            lblDescargasColones.Text = "CRC " + (_carga_sucursal.Monto_asignado_colones).ToString("N2");

            //Obtiene el nombre del portavalor.
            _coordinacion.listarPortavalorPorCargaSucursal(ref _carga_sucursal);

            if (_carga_sucursal.ColaboradorRecibidoBoveda != null)
            {
                lblPortavalorRecibe.Text = (_carga_sucursal.ColaboradorRecibidoBoveda + " " + _carga_sucursal.ColaboradorRecibidoBoveda.Identificacion).ToString();
                lblPortavalorRuta.Text = lblPortavalorRecibe.Text;
            }
            else
            {
                lblPortavalorRecibe.Text = string.Empty;
                lblPortavalorRuta.Text = string.Empty;
            }

            foreach (ManifiestoSucursalCarga m in _carga_sucursal.Manifiesto)
            {
                if (_atencion.listarBolsasSucursalPorManifiesto(m) != null)
                {
                    BindingList<Bolsa> bolsas = new BindingList<Bolsa>();
                    bolsas = _atencion.listarBolsasSucursalPorManifiesto(m);

                    lblcantBultos.Text = bolsas.Count.ToString();
                }
                else
                    lblcantBultos.Text = "1";
            }
           
            if (_carga_sucursal.Sucursal != null)
            {
                lblOficinasEntrega.Text = _carga_sucursal.Sucursal.Nombre.ToString();
            }

            if (_carga_sucursal.Sucursal.Direccion != null)
            {
                lblOficinasEntrega.Text = _carga_sucursal.Sucursal.Direccion.ToString();
            }

            //if (_carga_sucursal.Manifiesto.ListaBolsas.Count > 0)
            //    lblCantDepositos.Text = _carga_sucursal.Cartuchos.Count.ToString();
            //else
            //    lblCantDepositos.Text = "1";

            lblnumeroatm.Text = "0";
            lblBolsaMarchamo.Text = "-";
            rbFull.Enabled = false;
            lblTulaBNA.Text = "-";
            rbNormal.Enabled = false;
            
           
        }


        /// <summary>
        /// Mostrar los datos de carga de ATMs.
        /// </summary

        public void mostrarDatosCargaATM()
        {
                      
            dgvCargas.DataSource = _carga_atm.Cartuchos;
            lblBolsaMarchamo.Text = "";
            lblcantBultos.Text = "1";
            lblCantDepositos.Text = _carga_atm.Cartuchos.Count.ToString();
            lblCantManif.Text = "1";
            lblComentario.Text = _carga_atm.Observaciones.ToString();
            lblEncargado.Text = _carga_atm.Carga.Cajero.ToString();
            lblEntregadoA.Text = _carga_atm.Carga.Cajero.ToString(); // portavalor
            lblFecha.Text = _carga_atm.Carga.Fecha_asignada.ToShortDateString();
            lblFechaCargamento.Text = _carga_atm.Carga.Fecha_verificacion.ToShortDateString();

            //Realiza la suma de Carga en colones mas la Carga de dolares en colones.
            lblGranTotal.Text = "CRC " + (_carga_atm.Monto_carga_colones + (_carga_atm.Monto_carga_dolares * (Convert.ToInt32(lblTipoCambio.Text)))).ToString("N2");

            string montototal = "";
            
            montototal= Convert.ToInt32((_carga_atm.Monto_carga_colones + (_carga_atm.Monto_carga_dolares * (_tipocambio.Venta)))).ToString();
           
            //Conviete el gran total en letras.
            lblGranTotalLetras.Text = _coordinacion.convertirMontoaLetras(montototal)+ "COLONES";
            montoenletras = lblGranTotalLetras.Text; 
           
            lblHLlegada.Text = _carga_atm.Carga.Hora_Llegada.ToShortTimeString();
            lblHSalida.Text = _carga_atm.Carga.Hora_Salida.ToLongTimeString();
            lblNumero.Text = _carga_atm.Manifiesto.ToString();
            lblnumeroatm.Text = _carga_atm.ATM.Numero.ToString();
            lblOrigenFondosR.Text = "ATM";
            lblRuta.Text = _carga_atm.Carga.Ruta.ToString();
            lblDescargaDolares.Text = "USD " + _carga_atm.Monto_carga_dolares.ToString("N2");
            lblDescargasColones.Text = "CRC " + _carga_atm.Monto_carga_colones.ToString("N2");


            CargaATM _carguita = _carga_atm.Carga;
            //Obtiene el nombre del portavalor.
            _coordinacion.listarPortavalorPorCargaATM(ref _carguita);
            
            if (_carga_atm.Carga.ColaboradorRecibidoBoveda != null)
            {
                lblPortavalorRecibe.Text = (_carga_atm.Carga.ColaboradorRecibidoBoveda + " " + _carga_atm.Carga.ColaboradorRecibidoBoveda.Identificacion).ToString();
                lblPortavalorRuta.Text = lblPortavalorRecibe.Text;
            }
            else
            {
                lblPortavalorRecibe.Text = string.Empty;
                lblPortavalorRuta.Text = string.Empty;
            }

            if (_carga_atm.ATM.Ubicacion != null)
            {
                lblOficinasEntrega.Text = _carga_atm.ATM.Ubicacion.Oficina.ToString();
            }
            if (_carga_atm.Manifiesto.Bolsa_rechazo != null)
            { 
                lblBolsaMarchamo.Text = _carga_atm.Manifiesto.Bolsa_rechazo;
            } 
            
            //Selecciona si el ATM es full o no lo es y asigna el marchamo.
            if (_carga_atm.Carga.ATM_full)
            {
                rbFull.Checked = true;
                lblTulaBNA.Text = _carga_atm.Carga.Manifiesto_full.Marchamo;
            }
            else   
            {
                rbNormal.Checked = true;
                lblTulaBNA.Text = _carga_atm.Manifiesto.Marchamo_adicional;
            }
        
        }

        

        #endregion Metodos Publicos

        #region Metodos Privados

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
                PrintText(monto.Substring(0, 28), 18, 517);
                PrintText(monto.Substring(68, monto.Length - 28), 129, 60);
            }
            else
                PrintText(monto, 114, 60);  
        }
        
        #endregion Metodos Privados

        #region Eventos
        private void btnMostrarPDF_Click(object sender, EventArgs e)
        {
            if (_carga_atm != null)
            {
                frmVisualizarManifiesto formulario = new frmVisualizarManifiesto(_carga_atm);
                formulario.ShowDialog();
            }
            if (_carga_sucursal != null)
            {
                frmVisualizarManifiesto formulario = new frmVisualizarManifiesto(_carga_sucursal);
                formulario.ShowDialog();
            }
            if (_pedido_banco != null)
            {
                frmVisualizarManifiesto formulario = new frmVisualizarManifiesto(_pedido_banco);
                formulario.ShowDialog();
            }


        }
#endregion Eventos 

        private void lblComentario_Click(object sender, EventArgs e)
        {

        }

        private void lblDescargaDolares_Click(object sender, EventArgs e)
        {

        }

        private void rbNormal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblGranTotalLetras_Click(object sender, EventArgs e)
        {

        }

        private void gbBolsaMarchamo_Enter(object sender, EventArgs e)
        {

        }


  





    }
}
