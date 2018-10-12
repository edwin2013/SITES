using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
using LibreriaMensajes;
using LibreriaReportesOffice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmConversionArchivoAcreditacion : Form
    {
       #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<DepositoAcreditacion> _cargas = new BindingList<DepositoAcreditacion>();
        private BindingList<DepositoAcreditacion> _cargas_transportadora = new BindingList<DepositoAcreditacion>();
       
        private Colaborador _colaborador = null;

        private string _archivo = string.Empty;
        private string _archivo_transportadora = string.Empty;

       
        #endregion Atributos

        #region Contructor

        public frmConversionArchivoAcreditacion(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;

          
        }

        #endregion Contructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de abrir.
        /// </summary>
        private void btnAbrir_Click(object sender, EventArgs e)
        {

            try
            {

                if (ofdMontosCargas.ShowDialog() == DialogResult.OK)
                {
                    _archivo = ofdMontosCargas.FileName;

                    this.generarCargas(1);

                    btnExportarCompass.Enabled = _cargas.Count > 0;
                }
                else
                {
                    _archivo = string.Empty;

                    _cargas.Clear();

                    btnExportarCompass.Enabled = false;
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorCargasGeneracionFormatoArchivo");
            }

            txtArchivo.Text = _archivo;
        }

        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                sfdGuardar.Filter = "Fichero CSV (*.csv)|*.csv";
                sfdGuardar.FileName = "archivo";
                sfdGuardar.Title = "Exportar a CSV";
                if (sfdGuardar.ShowDialog() == DialogResult.OK)
                {
                    string destino = sfdGuardar.FileName;

                    StringBuilder stringBuilder = new StringBuilder();
                    AddComma("trncode", stringBuilder);
                    AddComma("moneda", stringBuilder);
                    AddComma("cuenta", stringBuilder);
                    AddComma("montototal", stringBuilder);
                    AddComma("referencia", stringBuilder);
                    AddComma("cedula", stringBuilder);
                    AddComma("depositante", stringBuilder);
                    AddComma("manifiesto", stringBuilder);
                    AddComma("depositid", stringBuilder);

                    stringBuilder.AppendLine();
                    File.AppendAllText(destino, stringBuilder.ToString());


                    foreach(DepositoAcreditacion dep in _cargas)
                    {
                        crearArchivo(dep, destino);
                    }

                    Mensaje.mostrarMensaje("MensajeImportacionArchivo");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

       

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        /// <summary>
        /// Abre el archivo para la transportadora
        /// </summary>
        private void btnAbrirTransportadora_Click(object sender, EventArgs e)
        {
            try
            {

                if (ofdMontosCargas.ShowDialog() == DialogResult.OK)
                {
                    _archivo_transportadora = ofdMontosCargas.FileName;

                    this.generarCargas(2);

                    btnExportarTransportadora.Enabled = _cargas_transportadora.Count > 0;
                }
                else
                {
                    _archivo_transportadora = string.Empty;

                    _cargas_transportadora.Clear();

                    btnExportarTransportadora.Enabled = false;
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorCargasGeneracionFormatoArchivo");
            }

            txtArchivoTransportadora.Text = _archivo_transportadora;
        }



        /// <summary>
        /// Exportar los datos del archivo de transportadora
        /// </summary>
        private void btnExportarTransportadora_Click(object sender, EventArgs e)
        {
            try
            {
                sfdGuardar.Filter = "Fichero CSV (*.csv)|*.csv";
                sfdGuardar.FileName = "archivo";
                sfdGuardar.Title = "Exportar a CSV";
                if (sfdGuardar.ShowDialog() == DialogResult.OK)
                {
                    string destino = sfdGuardar.FileName;

                    StringBuilder stringBuilder = new StringBuilder();
                    AddComma("trncode", stringBuilder);
                    AddComma("moneda", stringBuilder);
                    AddComma("cuenta", stringBuilder);
                    AddComma("montototal", stringBuilder);
                    AddComma("referencia", stringBuilder);
                    AddComma("cedula", stringBuilder);
                    AddComma("depositante", stringBuilder);
                    AddComma("manifiesto", stringBuilder);
                    AddComma("depositid", stringBuilder);

                    stringBuilder.AppendLine();
                    File.AppendAllText(destino, stringBuilder.ToString());

                    foreach (DepositoAcreditacion dep in _cargas_transportadora)
                    {
                        crearArchivo(dep,destino);
                    }


                    Mensaje.mostrarMensaje("MensajeImportacionArchivo");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        #endregion Eventos

        #region Métodos Privados

      

        /// <summary>
        /// Leer los montos del archivo y generar las cargas.
        /// </summary>
        private void generarCargas(int variable)
        {
            DocumentoExcel archivo = null;

            try
            {
               

                _cargas.Clear();
                _cargas_transportadora.Clear();

                if (variable == 1)
                {
                    archivo = new DocumentoExcel(_archivo, false);

                    archivo.seleccionarHoja(1);

                    Celda celda_codigo = archivo.seleccionarCelda(mtbCeldaCodigoCompass.Text);

                    Celda celda_cuenta = archivo.seleccionarCelda(mtbCeldaCuentaCompass.Text);
                    Celda celda_monto = archivo.seleccionarCelda(mtbCeldaMontoCompass.Text);
                    Celda celda_referencia = archivo.seleccionarCelda(mtbCeldaReferenciaCompass.Text);
                    Celda celda_puntoventa = archivo.seleccionarCelda(mtbCeldaPuntoVentaCompass.Text);
                    Celda celda_identificacion = archivo.seleccionarCelda(mtbCeldaIdentificacionCompass.Text);
                    Celda celda_deposito = archivo.seleccionarCelda(mtbCeldaDepositoCompass.Text);
                    Celda celda_manifiesto = archivo.seleccionarCelda(mtbCeldaManifiestoCompass.Text);
                    Celda celda_cliente = archivo.seleccionarCelda(mtbCeldaClienteCompass.Text);
                    

                    this.generarCargasCompass(archivo, celda_codigo, celda_cuenta, celda_monto, celda_referencia, celda_puntoventa,
                    celda_identificacion, celda_deposito, celda_manifiesto, celda_cliente, 1);

                }
                else
                {
                    archivo = new DocumentoExcel(_archivo_transportadora, false);

                    archivo.seleccionarHoja(1);

                    Celda celda_codigo = archivo.seleccionarCelda(mtbCodigoTransportadora.Text);

                    Celda celda_cuenta = archivo.seleccionarCelda(mtbCuentaTransportadora.Text);
                    Celda celda_monto = archivo.seleccionarCelda(mtbMontoTransportadora.Text);
                    Celda celda_referencia = archivo.seleccionarCelda(mtbReferenciaTransportadora.Text);
                    Celda celda_puntoventa = archivo.seleccionarCelda(mtbPuntoVentaTransportadora.Text);
                    Celda celda_identificacion = archivo.seleccionarCelda(mtbIdentificacionTransportadora.Text);
                    Celda celda_deposito = archivo.seleccionarCelda(mtbDespositoTransportadora.Text);
                    Celda celda_manifiesto = archivo.seleccionarCelda(mtbManifiestoTransportadora.Text);
                    //Celda celda_cliente = archivo.seleccionarCelda("A100");
                    Celda celda_id = archivo.seleccionarCelda("J9");

                    this.generarCargasCompassCliente(archivo, celda_codigo, celda_cuenta, celda_monto, celda_referencia, celda_puntoventa,
                    celda_identificacion, celda_deposito, celda_manifiesto, 2, celda_id);
                }


                archivo.mostrar();
                archivo.cerrar();

               
            }
            catch (Exception ex)
            {
                archivo.mostrar();
                archivo.cerrar();

                throw ex;
            }

        }

      

        /// <summary>
        /// Generar las cargas para una moneda específica.
        /// </summary>
        private void generarCargasCompass(DocumentoExcel archivo, Celda celda_codigo, Celda celda_cuenta,Celda celda_monto,Celda celda_referencia,Celda celda_puntoventa,
                    Celda celda_identificacion, Celda celda_deposito, Celda celda_manifiesto, Celda celda_cliente, int variable)
        {
            // Leer las denominaciones


            while (!celda_codigo.Valor.Equals(string.Empty))
            {
                string codigo = celda_codigo.Valor;
                string cuenta = celda_cuenta.Valor;
                Decimal monto = Convert.ToDecimal(celda_monto.Valor);
                string referencia = celda_referencia.Valor;
                string puntoventa = celda_puntoventa.Valor;
                string identificacion = celda_identificacion.Valor;
                string deposito = celda_deposito.Valor;
                string manifiesto = celda_manifiesto.Valor;
                string cliente = celda_cliente.Valor;



                DepositoAcreditacion carga = new DepositoAcreditacion(codigo: codigo, cuenta: cuenta, referencia: referencia, puntoventa: puntoventa,
                    identificacion: identificacion, deposito: deposito, manifiesto: manifiesto, cliente: cliente, monto: monto);



                celda_codigo = archivo.seleccionarCelda(celda_codigo.Fila + 1, celda_codigo.Columna);
                celda_cuenta = archivo.seleccionarCelda(celda_cuenta.Fila + 1, celda_cuenta.Columna);
                celda_monto = archivo.seleccionarCelda(celda_monto.Fila + 1, celda_monto.Columna);
                celda_referencia = archivo.seleccionarCelda(celda_referencia.Fila + 1, celda_referencia.Columna);
                celda_puntoventa = archivo.seleccionarCelda(celda_puntoventa.Fila + 1, celda_puntoventa.Columna);
                celda_identificacion = archivo.seleccionarCelda(celda_identificacion.Fila + 1, celda_identificacion.Columna);
                celda_deposito = archivo.seleccionarCelda(celda_deposito.Fila + 1, celda_deposito.Columna);
                celda_manifiesto = archivo.seleccionarCelda(celda_manifiesto.Fila + 1, celda_manifiesto.Columna);
                celda_cliente = archivo.seleccionarCelda(celda_cliente.Fila + 1, celda_cliente.Columna);

                if (variable == 1)
                    _cargas.Add(carga);
                else
                    _cargas_transportadora.Add(carga);
            }

        }




        private void generarCargasCompassCliente(DocumentoExcel archivo, Celda celda_codigo, Celda celda_cuenta, Celda celda_monto, Celda celda_referencia, Celda celda_puntoventa,
                    Celda celda_identificacion, Celda celda_deposito, Celda celda_manifiesto, int variable, Celda celda_id)
        {
            // Leer las denominaciones

            try
            {
                while (!celda_id.Valor.Equals(string.Empty) && !celda_id.Valor.Equals("SUBTOTAL"))
                {
                
                    if (!celda_id.Valor.Trim().Equals("TOTAL"))
                    {
                        try
                        {
                            string codigo = celda_codigo.Valor;
                            string cuenta = celda_cuenta.Valor;
                            Decimal monto = Convert.ToDecimal(celda_monto.Valor);
                            string referencia = celda_referencia.Valor;
                            string puntoventa = celda_puntoventa.Valor;
                            string identificacion = celda_identificacion.Valor;
                            string deposito = celda_deposito.Valor;
                            string manifiesto = celda_manifiesto.Valor;
                            string cliente = "";

                            //if (manifiesto == "900194366")
                            //{
                            //    int i = 1;
                            //}

                            DepositoAcreditacion carga = new DepositoAcreditacion(codigo: codigo, cuenta: cuenta, referencia: referencia, puntoventa: puntoventa,
                                identificacion: identificacion, deposito: deposito, manifiesto: manifiesto, cliente: cliente, monto: monto);





                            if (variable == 1)
                                _cargas.Add(carga);
                            else
                                _cargas_transportadora.Add(carga);
                        }
                        catch (Excepcion ex)
                        {
                            throw ex;
                        }
                    }
                    celda_codigo = archivo.seleccionarCelda(celda_codigo.Fila + 1, celda_codigo.Columna);
                    celda_cuenta = archivo.seleccionarCelda(celda_cuenta.Fila + 1, celda_cuenta.Columna);
                    celda_monto = archivo.seleccionarCelda(celda_monto.Fila + 1, celda_monto.Columna);
                    celda_referencia = archivo.seleccionarCelda(celda_referencia.Fila + 1, celda_referencia.Columna);
                    celda_puntoventa = archivo.seleccionarCelda(celda_puntoventa.Fila + 1, celda_puntoventa.Columna);
                    celda_identificacion = archivo.seleccionarCelda(celda_identificacion.Fila + 1, celda_identificacion.Columna);
                    celda_deposito = archivo.seleccionarCelda(celda_deposito.Fila + 1, celda_deposito.Columna);
                    celda_manifiesto = archivo.seleccionarCelda(celda_manifiesto.Fila + 1, celda_manifiesto.Columna);
                    //celda_cliente = archivo.seleccionarCelda(celda_cliente.Fila + 1, celda_cliente.Columna);
                    celda_id = archivo.seleccionarCelda(celda_id.Fila + 1, celda_id.Columna);
                }
            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }





        /// <summary>
        /// Crea el archivo
        /// </summary>
        /// <param name="a">DepositoAcreditacion con los datos del deposito</param>
        /// <param name="destino">Destino donde se almacenan los datos</param>
        private void crearArchivo(DepositoAcreditacion a, string destino)
        {
            StringBuilder stringBuilder = new StringBuilder();
            AddComma(a.Codigo, stringBuilder);
            if(a.Codigo == "5311")
                AddComma("CRC", stringBuilder);
            if (a.Codigo == "5312")
                AddComma("USD", stringBuilder);
            AddComma(a.Cuenta, stringBuilder);
            AddComma(a.Monto.ToString(), stringBuilder);
            AddComma(a.Referencia, stringBuilder);
            AddComma(a.Identificacion, stringBuilder);
            AddComma(a.PuntoVenta, stringBuilder);
            AddComma(a.Manifiesto, stringBuilder);
            AddComma(a.Referencia, stringBuilder);
            //HttpContext.Current.Response.Write(stringBuilder.ToString());
            //HttpContext.Current.Response.Write(Environment.NewLine);
            stringBuilder.AppendLine();
            File.AppendAllText(destino, stringBuilder.ToString());
        }


        private static void AddComma(string value, StringBuilder stringBuilder)
        {
            stringBuilder.Append(value.Replace(',', ' '));
            stringBuilder.Append(", ");
        }

     

        #endregion Métodos Privados

        private void gbArchivo_Enter(object sender, EventArgs e)
        {

        }

        private void gbArchivoTransportadora_Enter(object sender, EventArgs e)
        {

        }

        


        
    }
}
