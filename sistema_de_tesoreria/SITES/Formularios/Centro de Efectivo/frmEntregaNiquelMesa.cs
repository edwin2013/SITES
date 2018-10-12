using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using GUILayer.Formularios.Centro_de_Efectivo;
using CommonObjects.Clases;
using LibreriaReportesOffice;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmEntregaNiquelMesa : Form
    {
        #region Atributos

        String codigoentrega = "";
        Decimal ntotalniquel = 0;
        Boolean verificadorcodigo = false;
        private AtencionBL _atencion = AtencionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private Colaborador _cajero = null;
        BindingList<BoletaMesaNiquel> listaboletas = new BindingList<BoletaMesaNiquel>();
        private int idboleta;
        private int idprocesamientobajovolumen;
        DateTime fechaboleta;
        ProcesamientoBajoVolumenManifiesto man = new ProcesamientoBajoVolumenManifiesto();        

        #endregion Atributos    
   
        #region Constructor

        public frmEntregaNiquelMesa(Colaborador colaborador)
        {
            InitializeComponent();
            _cajero = colaborador;
            listaboletas = _atencion.ObtenerInfoFormularioBoletaNiquelMesa(_cajero);
            ntotalniquel = calculartotalniquel();
            if (ntotalniquel > 0) {
                fechaboleta = listaboletas[0].Fecha;
                codigoentrega = creacodigounico();
                while (verificadorcodigo == false)
                {
                    verificadorcodigo = _atencion.verificarcodigoentrega(codigoentrega);
                }
                idboleta = listaboletas[0].ID;
                idprocesamientobajovolumen = listaboletas[0].Procesobajovolumendeposito;
                lbldNiquel.Text = calculartotalniquel().ToString("n2");
                lbldCode.Text = codigoentrega;
                lbldCajero.Text = colaborador.Nombre + ' ' + colaborador.Primer_apellido + ' ' + colaborador.Segundo_apellido;
                lbldFecha.Text = fechaboleta.ToShortDateString();
                lbldHora.Text = fechaboleta.ToShortTimeString();
            } else {
                MessageBox.Show("No existe monto de Niquel pendiente por entregar");                
            }

        }

        #endregion Constructor

        #region Eventos
        

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea realizar la entrega de niquel?", "Confirmación de entrega de niquel en mesa", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                man = _mantenimiento.VerificaManifiestoPendiente(_cajero.ID);
                if (man == null)
                {
                    BoletaMesaNiquel boleta = new BoletaMesaNiquel(cajero: _cajero.ID, codigoentrega: codigoentrega, montoniquel: Convert.ToDecimal(lbldNiquel.Text), fecha: fechaboleta,
                    procesobajovolumendeposito: idprocesamientobajovolumen, estado: 0);
                    _mantenimiento.agregarBoletaMesaNiquel(ref boleta);
                    imprimirBoletaEntregaNiquel();
                    MessageBox.Show("El monto del niquel ha sido transferido al cajero niquel para su validación.");
                    this.Close();
                }                
                else
                    MessageBox.Show("No puede realizar entrega de niquel hasta cerrar un manifiesto pendiente de procesar.");
            }                
        }

        #endregion Eventos

        #region Métodos Privados

        private string creacodigounico()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        private void llenarpantallaboleta()
        {
            Decimal Montototal = 0;
            foreach (BoletaMesaNiquel boleta in listaboletas) {
                Montototal += boleta.MontoNiquel;
            }
            lbldCajero.Text = _cajero.Nombre + ' ' + _cajero.Primer_apellido + ' ' + _cajero.Segundo_apellido;
            lblCode.Text = codigoentrega;
            lbldFecha.Text = new DateTime().ToShortDateString();
            lbldHora.Text = new DateTime().ToShortTimeString();
            lbldNiquel.Text = Montototal.ToString().Replace(".0000", ".00");
        }

        private Decimal calculartotalniquel() {
            Decimal total = 0;
            foreach (BoletaMesaNiquel nboleta in listaboletas) {
                total += nboleta.MontoNiquel;
            }
            return total;
        }

        #endregion Métodos Privados

        private void imprimirBoletaEntregaNiquel()
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla boleta niquel_entrega_cola.xlsx", false);

                documento.seleccionarHoja(1);

                //documento.seleccionarCelda("D2");
                //documento.actualizarValorCelda("BOLETA DE EFECTIVO No. " + Convert.ToString(idboleta));

                documento.seleccionarCelda("C4");
                documento.actualizarValorCelda(lbldFecha.Text);

                documento.seleccionarCelda("F4");
                documento.actualizarValorCelda(lbldHora.Text);

                documento.seleccionarCelda("C6");
                documento.actualizarValorCelda(_cajero.Nombre + ' ' + _cajero.Primer_apellido + ' ' + _cajero.Segundo_apellido);

                documento.seleccionarCelda("C8");
                documento.actualizarValorCelda(codigoentrega);

                documento.seleccionarCelda("C10");
                documento.actualizarValorCelda(lbldNiquel.Text);                

                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _atencion.cancelarcodigoentrega(codigoentrega);
            this.Close();
        }

        private void frmEntregaNiquelMesa_Load(object sender, EventArgs e)
        {
            if (ntotalniquel == 0) {
                this.Close();
            }
        }
    }
}
