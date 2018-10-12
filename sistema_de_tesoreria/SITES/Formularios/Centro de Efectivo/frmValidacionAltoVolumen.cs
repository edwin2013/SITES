using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriaMensajes;
using CommonObjects;
using BussinessLayer;
using CommonObjects.Clases;
using LibreriaReportesOffice;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmValidacionAltoVolumen : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;        
        private Manifiesto _manifiesto = null;        
        private ProcesamientoAltoVolumen procesoAV = new ProcesamientoAltoVolumen();
        private ValidacionAltoVolumen validacionAV = new ValidacionAltoVolumen();
        private Colaborador _colaborador = null;
        private BilletesRechazadosAltoVolumen billeterechazado = null;
        private BilletesContadosVolumenAlto billetecontado = null;
        private byte _tipovalidacion = 0;
        private Boolean permisosup = false;
        int conteoerrores = 0;
        private int _coordinador = 0; 

        #endregion Atributos

        #region Constructor

        public frmValidacionAltoVolumen(byte TipoValidacion, ref Colaborador col)
        {
            InitializeComponent();
            _tipovalidacion = TipoValidacion;
            _colaborador = col;            
            cboMoneda.SelectedIndex = 0;
            cboCamaraValidador.ListaMostrada = _mantenimiento.listarCamarasPorArea(Areas.CentroEfectivo);
            //cboCliente.ListaMostrada = _mantenimiento.listarSucursales();
            _manifiesto = new Manifiesto();
            formatoVentana();
            mostrarcamposmoneda(cboMonedaDeclarada.SelectedIndex);
            gbDatosContado.Enabled = false;
            btnConteoAut.Visible = false;
            btnValidar.Enabled = false;
            cboCamara.ListaMostrada = _mantenimiento.listarCamarasPorArea(Areas.CentroEfectivo);
            cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);
            sumarTotales();
        }

        private void formatoVentana()
        {
            cboMonedaDeclarada.SelectedIndex = (byte)Monedas.Colones;
            //cboTipoMesaNiquel.SelectedIndex = (byte)Monedas.Colones;
        }

        private void mostrarcamposmoneda(int seleccionmoneda)
        {
            switch (seleccionmoneda)
            {
                case 0:
                    gbcolones.Visible = true;
                    gbdolares.Visible = false;
                    gbeuros.Visible = false;
                    break;
                case 1:
                    gbcolones.Visible = false;
                    gbdolares.Visible = true;
                    gbeuros.Visible = false;
                    break;
                case 2:
                    gbcolones.Visible = false;
                    gbdolares.Visible = false;
                    gbeuros.Visible = true;
                    break;
            }
        }

        #endregion Constructor       

        #region Eventos

        private void nudcincoeur_ValueChanged(object sender, EventArgs e)
        {
            ValidarMontos(nud5EUR.Value, 5, nud5EUR);
            sumarTotales();
        }

        private void nudcieneur_ValueChanged(object sender, EventArgs e)
        {
            ValidarMontos(nud100EUR.Value, 100, nud100EUR);
            sumarTotales();
        }

        private void nuddiezeur_ValueChanged(object sender, EventArgs e)
        {
            ValidarMontos(nud10EUR.Value, 10, nud10EUR);
            sumarTotales();
        }

        private void nuddoscientoseur_ValueChanged(object sender, EventArgs e)
        {
            ValidarMontos(nud200EUR.Value, 200, nud200EUR);
            sumarTotales();
        }

        private void nudveinteeur_ValueChanged(object sender, EventArgs e)
        {
            ValidarMontos(nud20EUR.Value, 20, nud20EUR);
            sumarTotales();
        }

        private void nudquinientoseur_ValueChanged(object sender, EventArgs e)
        {
            ValidarMontos(nud500EUR.Value, 500, nud500EUR);
            sumarTotales();
        }

        private void nudcincuentaeur_ValueChanged(object sender, EventArgs e)
        {
            ValidarMontos(nud50EUR.Value, 50, nud50EUR);
            sumarTotales();
        }

        private void nudunusd_ValueChanged(object sender, EventArgs e)
        {
            ValidarMontos(nud1USD.Value, 1, nud1USD);
            sumarTotales();
        }

        private void nudveinteusd_ValueChanged(object sender, EventArgs e)
        {
            ValidarMontos(nud20USD.Value, 20, nud20USD);
            sumarTotales();
        }

        private void nudcincousd_ValueChanged(object sender, EventArgs e)
        {
            ValidarMontos(nud5USD.Value, 5, nud5USD);
            sumarTotales();
        }

        private void nudcincuentausd_ValueChanged(object sender, EventArgs e)
        {
            ValidarMontos(nud50USD.Value, 50, nud50USD);
            sumarTotales();
        }

        private void nuddiezusd_ValueChanged(object sender, EventArgs e)
        {
            ValidarMontos(nud10USD.Value, 10, nud10USD);
            sumarTotales();
        }

        private void nudcienusd_ValueChanged(object sender, EventArgs e)
        {
            ValidarMontos(nud100USD.Value, 100, nud100USD);
            sumarTotales();
        }

        private void nudCincuentamil_ValueChanged(object sender, EventArgs e)
        {
            ValidarMontos(nud50000CRC.Value, 50000, nud50000CRC);
            sumarTotales();
        }

        private void nudCincomil_ValueChanged(object sender, EventArgs e)
        {
            ValidarMontos(nud5000CRC.Value, 5000, nud5000CRC);
            sumarTotales();
        }

        private void nudVeintemil_ValueChanged(object sender, EventArgs e)
        {
            ValidarMontos(nud20000CRC.Value, 20000, nud20000CRC);
            sumarTotales();
        }

        private void nudDosmil_ValueChanged(object sender, EventArgs e)
        {
            ValidarMontos(nud2000CRC.Value, 2000, nud2000CRC);
            sumarTotales();
        }

        private void nudDiezmil_ValueChanged(object sender, EventArgs e)
        {
            ValidarMontos(nud10000CRC.Value, 10000, nud10000CRC);
            sumarTotales();
        }

        private void nudMil_ValueChanged(object sender, EventArgs e)
        {
            ValidarMontos(nud1000CRC.Value, 1000, nud1000CRC);
            sumarTotales();
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboMoneda.SelectedIndex) {
                case 0:
                    gbcolones.Visible = true;
                    gbdolares.Visible = false;
                    gbeuros.Visible = false;
                    break;
                case 1:
                    gbcolones.Visible = false;
                    gbdolares.Visible = true;
                    gbeuros.Visible = false;
                    break;
                case 2:
                    gbcolones.Visible = false;
                    gbdolares.Visible = false;
                    gbeuros.Visible = true;
                    break;
            }
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if ((cboCamaraValidador.SelectedIndex != -1) && (!cboCamaraValidador.SelectedItem.Equals("Todos")))
            {
                if ((revisardenominacionesbillete()) || (conteoerrores == 1))
                {
                    if (Convert.ToDecimal(txtDiferencia.Text) != 0)
                    {
                        if (conteoerrores == 0)
                        {
                            epError.SetError(txtDiferencia, "Existe una diferencia entre el monto contado y el declarado.");
                            conteoerrores += 1;
                        }
                        else
                        {
                            if (MessageBox.Show("¿Desea CERRAR la Validacion?", "Confirmación de validación de depósitos de alto volumen", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {
                                frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(8, _colaborador);
                                formulario.ShowDialog(this);
                                if (permisosup)
                                {
                                    cerrarvalidacion();
                                    limpiarvalores();
                                }
                            }
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("¿Desea CERRAR la Validacion?", "Confirmación de validación de depósitos de alto volumen", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            cerrarvalidacion();
                            limpiarvalores();
                        }
                    }
                }
                else
                {
                    if (conteoerrores == 0)
                    {
                        conteoerrores = 1;
                        if (Convert.ToDecimal(txtDiferencia.Text) != 0)
                        {
                            epError.SetError(txtDiferencia, "Existe una diferencia entre el monto contado y el declarado.");
                        }
                    }
                    else
                    {
                        if (Convert.ToDecimal(txtDiferencia.Text) != 0)
                        {
                            epError.SetError(txtDiferencia, "Existe una diferencia entre el monto contado y el declarado.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado una cámara para continuar.", "Cámara del validador sin seleccionar", MessageBoxButtons.OK);
            }            
            txtHeaderCard.Focus();
        }

        private void btnConteoAut_Click(object sender, EventArgs e)
        {
            try
            {
                object[,] conteo = _mantenimiento.ObtenerArchivosBPS_Headercard(txtHeaderCard.Text);
                int denominacion = 0;
                if (conteo != null)
                {
                    if (!conteo[0, 0].Equals(string.Empty))
                    {
                        if (conteo[0, 0].Equals("CRC"))
                        {
                            cboMoneda.SelectedIndex = 0;
                        }
                        else
                            if (conteo[0, 0].Equals("USD"))
                        {
                            cboMoneda.SelectedIndex = 1;
                        }
                        else
                                if (conteo[0, 0].Equals("EUR"))
                        {
                            cboMoneda.SelectedIndex = 2;
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            denominacion = Convert.ToInt32(conteo[i, 1]);
                            switch (cboMoneda.SelectedIndex)
                            {
                                case 0:
                                    switch (denominacion)
                                    {
                                        case 10000:
                                            nud10000CRC.Value = Convert.ToDecimal(conteo[i, 3]);
                                            break;
                                        case 1000:
                                            nud1000CRC.Value = Convert.ToDecimal(conteo[i, 3]);
                                            break;
                                        case 20000:
                                            nud20000CRC.Value = Convert.ToDecimal(conteo[i, 3]);
                                            break;
                                        case 2000:
                                            nud2000CRC.Value = Convert.ToDecimal(conteo[i, 3]);
                                            break;
                                        case 5000:
                                            nud5000CRC.Value = Convert.ToDecimal(conteo[i, 3]);
                                            break;
                                        case 50000:
                                            nud50000CRC.Value = Convert.ToDecimal(conteo[i, 3]);
                                            break;
                                    }
                                    /*if (conteo[i, 1] == 10000))
                                    {
                                        nud10000CRC.Value = Convert.ToDecimal(conteo[i, 3]);
                                    }
                                    if (conteo[i, 1].Equals("1000"))
                                    {
                                        nud1000CRC.Value = Convert.ToDecimal(conteo[i, 3]);
                                    }
                                    if (conteo[i, 1].Equals("20000"))
                                    {
                                        nud20000CRC.Value = Convert.ToDecimal(conteo[i, 3]);
                                    }
                                    if (conteo[i, 1].Equals("2000"))
                                    {
                                        nud2000CRC.Value = Convert.ToDecimal(conteo[i, 3]);
                                    }
                                    if (conteo[i, 1].Equals("5000"))
                                    {
                                        nud5000CRC.Value = Convert.ToDecimal(conteo[i, 3]);
                                    }
                                    if (conteo[i, 1].Equals("50000"))
                                    {
                                        nud50000CRC.Value = Convert.ToDecimal(conteo[i, 3]);
                                    }*/
                                    break;
                                case 1:
                                    switch (denominacion)
                                    {
                                        case 1:
                                            nud1USD.Value = Convert.ToDecimal(conteo[i, 3]);
                                            break;
                                        case 5:
                                            nud5USD.Value = Convert.ToDecimal(conteo[i, 3]);
                                            break;
                                        case 10:
                                            nud10USD.Value = Convert.ToDecimal(conteo[i, 3]);
                                            break;
                                        case 20:
                                            nud20USD.Value = Convert.ToDecimal(conteo[i, 3]);
                                            break;
                                        case 50:
                                            nud50USD.Value = Convert.ToDecimal(conteo[i, 3]);
                                            break;
                                        case 100:
                                            nud100USD.Value = Convert.ToDecimal(conteo[i, 3]);
                                            break;
                                    }
                                    /*if (conteo[i, 1].Equals("1"))
                                    {
                                        nud1USD.Value = Convert.ToDecimal(conteo[i, 3]);
                                    }
                                    if (conteo[i, 1].Equals("5"))
                                    {
                                        nud5USD.Value = Convert.ToDecimal(conteo[i, 3]);
                                    }
                                    if (conteo[i, 1].Equals("10"))
                                    {
                                        nud10USD.Value = Convert.ToDecimal(conteo[i, 3]);
                                    }
                                    if (conteo[i, 1].Equals("20"))
                                    {
                                        nud20USD.Value = Convert.ToDecimal(conteo[i, 3]);
                                    }
                                    if (conteo[i, 1].Equals("50"))
                                    {
                                        nud50USD.Value = Convert.ToDecimal(conteo[i, 3]);
                                    }
                                    if (conteo[i, 1].Equals("100"))
                                    {
                                        nud100USD.Value = Convert.ToDecimal(conteo[i, 3]);
                                    }*/
                                    break;
                                case 2:
                                    switch (denominacion)
                                    {
                                        case 5:
                                            nud5EUR.Value = Convert.ToDecimal(conteo[i, 3]);
                                            break;
                                        case 10:
                                            nud10EUR.Value = Convert.ToDecimal(conteo[i, 3]);
                                            break;
                                        case 20:
                                            nud20EUR.Value = Convert.ToDecimal(conteo[i, 3]);
                                            break;
                                        case 50:
                                            nud50EUR.Value = Convert.ToDecimal(conteo[i, 3]);
                                            break;
                                        case 100:
                                            nud100EUR.Value = Convert.ToDecimal(conteo[i, 3]);
                                            break;
                                        case 200:
                                            nud200EUR.Value = Convert.ToDecimal(conteo[i, 3]);
                                            break;
                                        case 500:
                                            nud500EUR.Value = Convert.ToDecimal(conteo[i, 3]);
                                            break;
                                    }
                                    /*if (conteo[i, 1].Equals("5"))
                                    {
                                        nud5EUR.Value = Convert.ToDecimal(conteo[i, 3]);
                                    }
                                    if (conteo[i, 1].Equals("10"))
                                    {
                                        nud10EUR.Value = Convert.ToDecimal(conteo[i, 3]);
                                    }
                                    if (conteo[i, 1].Equals("20"))
                                    {
                                        nud20EUR.Value = Convert.ToDecimal(conteo[i, 3]);
                                    }
                                    if (conteo[i, 1].Equals("50"))
                                    {
                                        nud50EUR.Value = Convert.ToDecimal(conteo[i, 3]);
                                    }
                                    if (conteo[i, 1].Equals("100"))
                                    {
                                        nud100EUR.Value = Convert.ToDecimal(conteo[i, 3]);
                                    }
                                    if (conteo[i, 1].Equals("200"))
                                    {
                                        nud200EUR.Value = Convert.ToDecimal(conteo[i, 3]);
                                    }
                                    if (conteo[i, 1].Equals("500"))
                                    {
                                        nud500EUR.Value = Convert.ToDecimal(conteo[i, 3]);
                                    }*/
                                    break;
                            }
                        }
                    }
                }
            }                
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void cerrarvalidacion()
        {
            validacionAV = new ValidacionAltoVolumen();
            validacionAV.Moneda = (Monedas)cboMoneda.SelectedIndex;
            validacionAV.MontoContado = Convert.ToDecimal(txtMontoContado.Text);
            if (procesoAV.Tipo != 3)
            {
                validacionAV.MontoDeclarado = nudMontoCajero.Value;
                validacionAV.TipoConteo = 0;
            }
            else 
            {
                validacionAV.MontoDeclarado = nudMontoCliente.Value;                
                validacionAV.TipoConteo = 1;
            }
            validacionAV.MontoDiferencia = Convert.ToDecimal(txtDiferencia.Text);
            validacionAV.Proceso = procesoAV;
            validacionAV.TipoValidacion = _tipovalidacion;
            validacionAV.Validador = _colaborador;
            validacionAV.Camara = (Camara)cboCamaraValidador.SelectedItem; //Cambio GZH 13092017
            billeterechazado = new BilletesRechazadosAltoVolumen();
            billeterechazado.C10000CRC = (int)nudDiezmilrec.Value;
            billeterechazado.C20000CRC = (int)nudCincomilrec.Value;
            billeterechazado.C50000CRC = (int)nudCincuentamilrec.Value;
            billeterechazado.C2000CRC = (int)nudDosmilrec.Value;
            billeterechazado.C1000CRC = (int)nudMilrec.Value;
            billeterechazado.C5000CRC = (int)nudCincomilrec.Value;
            billeterechazado.C100EUR = (int)nudcieneurrec.Value;
            billeterechazado.C200EUR = (int)nuddoscientoseurrec.Value;
            billeterechazado.C500EUR = (int)nudquinientoseurrec.Value;
            billeterechazado.C50EUR = (int)nudcincuentaeurrec.Value;
            billeterechazado.C20EUR = (int)nudveinteeurrec.Value;
            billeterechazado.C10EUR = (int)nuddiezeurrec.Value;
            billeterechazado.C5EUR = (int)nudcincoeurrec.Value;
            billeterechazado.C100USD = (int)nudcienusdrec.Value;
            billeterechazado.C50USD = (int)nudcincuentausdrec.Value;
            billeterechazado.C20USD = (int)nudveinteusdrec.Value;
            billeterechazado.C10USD = (int)nuddiezusdrec.Value;
            billeterechazado.C5USD = (int)nudcincousdrec.Value;
            billeterechazado.C1USD = (int)nudunusdrec.Value;
            billeterechazado.M50000CRC = nudCincuentamilrec.Value * 50000;
            billeterechazado.M20000CRC = nudVeintemilrec.Value * 20000;
            billeterechazado.M10000CRC = nudDiezmilrec.Value * 10000;
            billeterechazado.M5000CRC = nudCincomilrec.Value * 5000;
            billeterechazado.M2000CRC = nudDosmilrec.Value * 2000;
            billeterechazado.M1000CRC = nudMilrec.Value * 1000;
            billeterechazado.M500EUR = nudquinientoseurrec.Value * 500;
            billeterechazado.M200EUR = nuddoscientoseurrec.Value * 200;
            billeterechazado.M100EUR = nudcieneurrec.Value * 100;
            billeterechazado.M50EUR = nudcincuentaeurrec.Value * 50;
            billeterechazado.M20EUR = nudveinteeurrec.Value * 20;
            billeterechazado.M10EUR = nuddiezeurrec.Value * 10;
            billeterechazado.M5EUR = nudcincoeurrec.Value * 5;
            billeterechazado.M1USD = nudunusdrec.Value;
            billeterechazado.M5USD = nudcincousdrec.Value * 5;
            billeterechazado.M10USD = nuddiezusdrec.Value * 10;
            billeterechazado.M20USD = nudveinteusdrec.Value * 20;
            billeterechazado.M50USD = nudcincuentausdrec.Value * 50;
            billeterechazado.M100USD = nudcienusdrec.Value * 100;            
            billeterechazado.Moneda =(Monedas)cboMoneda.SelectedIndex;
            switch(billeterechazado.Moneda)
            {
                case Monedas.Colones:
                    billeterechazado.MontoTotal = billeterechazado.M50000CRC + billeterechazado.M20000CRC + billeterechazado.M10000CRC + billeterechazado.M5000CRC + billeterechazado.M2000CRC +
                billeterechazado.M1000CRC;
                    break;
                case Monedas.Dolares:
                    billeterechazado.MontoTotal = billeterechazado.M1USD + billeterechazado.M5USD + billeterechazado.M10USD + billeterechazado.M20USD + billeterechazado.M50USD + 
                        billeterechazado.M100USD;
                    break;
                case Monedas.Euros:
                    billeterechazado.MontoTotal = billeterechazado.M500EUR + billeterechazado.M200EUR + billeterechazado.M100EUR + billeterechazado.M50EUR + billeterechazado.M20EUR + 
                        billeterechazado.M10EUR + billeterechazado.M5EUR;
                    break;
            }
            billetecontado = new BilletesContadosVolumenAlto();
            billetecontado.M50000CRC = nud50000CRC.Value;
            billetecontado.M20000CRC = nud20000CRC.Value;
            billetecontado.M10000CRC = nud10000CRC.Value;
            billetecontado.M5000CRC = nud5000CRC.Value;
            billetecontado.M2000CRC = nud2000CRC.Value;
            billetecontado.M1000CRC = nud1000CRC.Value;
            billetecontado.M500EUR = nud500EUR.Value;
            billetecontado.M200EUR = nud200EUR.Value;
            billetecontado.M100EUR = nud100EUR.Value;
            billetecontado.M50EUR = nud50EUR.Value;
            billetecontado.M20EUR = nud20EUR.Value;
            billetecontado.M10EUR = nud10EUR.Value;
            billetecontado.M5EUR = nud5EUR.Value;
            billetecontado.M1USD = nud1USD.Value;
            billetecontado.M5USD = nud5USD.Value;
            billetecontado.M10USD = nud10USD.Value;
            billetecontado.M20USD = nud20USD.Value;
            billetecontado.M50USD = nud50USD.Value;
            billetecontado.M100USD = nud100USD.Value;
            billetecontado.Moneda = (Monedas)cboMoneda.SelectedIndex;
            switch (billetecontado.Moneda)
            {
                case Monedas.Colones:
                    billetecontado.MontoTotal = billetecontado.M50000CRC + billetecontado.M20000CRC + billetecontado.M10000CRC + billetecontado.M5000CRC + billetecontado.M2000CRC +
                billetecontado.M1000CRC;
                    break;
                case Monedas.Dolares:
                    billetecontado.MontoTotal = billetecontado.M1USD + billetecontado.M5USD + billetecontado.M10USD + billetecontado.M20USD + billetecontado.M50USD +
                        billetecontado.M100USD;
                    break;
                case Monedas.Euros:
                    billetecontado.MontoTotal = billetecontado.M500EUR + billetecontado.M200EUR + billetecontado.M100EUR + billetecontado.M50EUR + billetecontado.M20EUR +
                        billetecontado.M10EUR + billetecontado.M5EUR;
                    break;
            }

            validacionAV.BilleteContado = billetecontado;
            validacionAV.BilleteRechazado = billeterechazado;
            _mantenimiento.agregarValidacionAltoVolumen(ref validacionAV);
            _mantenimiento.agregarBilleteConteoAltoVolumen(ref validacionAV);
            _mantenimiento.agregarBilleteRechazadoAltoVolumen(ref validacionAV);
            if (validacionAV.MontoDiferencia != 0)
            {
                _mantenimiento.agregarInconsistenciaAltoVolumen(validacionAV, _colaborador);
                validacionAV.Fecha = DateTime.Now;
                imprimirInconsistenciaAltoVolumen(validacionAV, _colaborador);

            } 
            MessageBox.Show("Proceso de validación realizado correctamente");
        }

        private void imprimirInconsistenciaAltoVolumen(ValidacionAltoVolumen v, Colaborador co)
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla Detalle_Inconsistencias_Tesoreria.xlsx", false);

                documento.seleccionarHoja(1);
                if (v.MontoDiferencia < 0)
                {
                    documento.seleccionarCelda("D9");
                }
                else
                {
                    documento.seleccionarCelda("I9");
                }
                documento.actualizarValorCelda("X");
                switch (v.Moneda)
                {
                    case Monedas.Colones:
                        documento.seleccionarCelda("D11");
                        break;
                    case Monedas.Dolares:
                        documento.seleccionarCelda("I11");
                        break;
                    default:
                        break;

                }
                documento.actualizarValorCelda("X");

                //documento.seleccionarCelda("E15");
                if (v.TipoConteo == 0)
                {
                    //documento.actualizarValorCelda(co.Nombre + ' ' + co.Primer_apellido + ' ' + co.Segundo_apellido);
                    documento.llenarcuadrodetexto("Rectangle 13", v.Proceso.Cajero.Nombre + " " + v.Proceso.Cajero.Primer_apellido + " " + v.Proceso.Cajero.Segundo_apellido); //Cambios GZH 11092017
                    //documento.llenarcuadrodetexto("Rectangle 13", co.Nombre + ' ' + co.Primer_apellido + ' ' + co.Segundo_apellido);
                }
                else
                {
                    documento.llenarcuadrodetexto("Rectangle 13", v.Proceso.Cliente.Nombre);
                    //documento.actualizarValorCelda(v.Proceso.Cliente.Nombre);
                }

                if (v.TipoConteo == 0)
                {
                    //documento.seleccionarCelda("E17");
                    documento.llenarcuadrodetexto("Rectangle 17", v.Proceso.Detalle[0].Headercard);
                    //documento.actualizarValorCelda(v.Proceso.Detalle[0].Headercard);
                }
                else
                {
                    //documento.seleccionarCelda("L15");
                    documento.llenarcuadrodetexto("Rectangle 14", v.Proceso.Detalle[0].Headercard);
                    //documento.actualizarValorCelda(v.Proceso.Detalle[0].Headercard);
                    //documento.seleccionarCelda("E17");
                    documento.llenarcuadrodetexto("Rectangle 17", v.Proceso.Manifiesto.Codigo);
                    //documento.actualizarValorCelda(v.Proceso.Manifiesto.Codigo);
                    //documento.seleccionarCelda("L17");
                    documento.llenarcuadrodetexto("Rectangle 15", v.Proceso.Detalle[0].Tula.Codigo);
                    //documento.actualizarValorCelda(v.Proceso.Detalle[0].Tula.Codigo);
                    //documento.seleccionarCelda("D19");
                    for (int i=0; i< v.Proceso.PuntoVenta.Cuentas.Count; i++) {
                        if (v.Proceso.PuntoVenta.Cuentas[i].Moneda == v.Proceso.Moneda) {
                            documento.llenarcuadrodetexto("Rectangle 18", v.Proceso.PuntoVenta.Cuentas[i].Numero_cuenta.ToString());
                            //documento.actualizarValorCelda(v.Proceso.PuntoVenta.Cuentas[i].Numero_cuenta);
                    }
                    }
                    
                    
                  
                    //documento.actualizarValorCelda(v.Proceso.Camara.Identificador);

                }
                //danilo--
                documento.llenarcuadrodetexto("Rectangle 16", v.Camara.Identificador);
                // --
                //documento.seleccionarCelda("N19");
                documento.llenarcuadrodetexto("Rectangle 19", v.Fecha.ToShortTimeString());
                //documento.actualizarValorCelda(v.Fecha.ToShortTimeString());

                documento.seleccionarCelda("G33");
                documento.actualizarValorCelda(v.MontoDiferencia);

                documento.seleccionarCelda("C36");
                documento.actualizarValorCelda("Monto declarado por cliente: " + v.MontoDeclarado);

                documento.seleccionarCelda("C37");
                documento.actualizarValorCelda("Monto recibido: " + v.MontoContado);

                documento.seleccionarCelda("D26");
                documento.actualizarValorCelda("X");               

                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        private bool revisardenominacionesbillete()
        {
            bool retorno = true;
            switch (cboMoneda.SelectedIndex)
            {
                case 0:
                    foreach (Control control in gbcolones.Controls)
                    {
                        NumericUpDown numControls = control as NumericUpDown;
                        if (numControls != null)
                        {
                            if (epError.GetError(numControls).Equals("") == false)
                            {
                                retorno = false;
                                break;
                            }
                        }
                    }
                    break;
                case 1:
                    foreach (Control control in gbdolares.Controls)
                    {
                        NumericUpDown numControls = control as NumericUpDown;
                        if (numControls != null)
                        {
                            if (epError.GetError(numControls).Equals("") == false)
                            {
                                retorno = false;
                                break;
                            }
                        }
                    }
                    break;
                case 2:
                    foreach (Control control in gbeuros.Controls)
                    {
                        NumericUpDown numControls = control as NumericUpDown;
                        if (numControls != null)
                        {
                            if (epError.GetError(numControls).Equals("") == false)
                            {
                                retorno = false;
                                break;
                            }
                        }
                    }
                    break;
            }
            return retorno;
        }

        private void btnIngresarHC_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHeaderCard.Text.Equals(string.Empty) == false)
                {
                    procesoAV = _mantenimiento.obtenerProcesamientoAltoVolumen(txtHeaderCard.Text);
                    if (procesoAV != null)
                    {
                        switch (procesoAV.Tipo)
                        {
                            case 0:
                                gbclientexterno.Visible = false;
                                gbCajero.Visible = true;
                                txtCajero.Text = procesoAV.Cajero.Nombre + ' ' + procesoAV.Cajero.Primer_apellido + ' ' + procesoAV.Cajero.Segundo_apellido;
                                cboCamara.SelectedItem = procesoAV.Camara;
                                cboMonedaDeclaradaCajero.SelectedIndex = (byte)procesoAV.Moneda;
                                nudMontoCajero.Value = procesoAV.Detalle[0].Monto;
                                break;
                            case 1:
                                gbclientexterno.Visible = false;
                                gbCajero.Visible = true;
                                txtCajero.Text = procesoAV.Cajero.Nombre + ' ' + procesoAV.Cajero.Primer_apellido + ' ' + procesoAV.Cajero.Segundo_apellido;
                                cboCamara.SelectedItem = procesoAV.Camara;
                                cboMonedaDeclaradaCajero.SelectedIndex = (byte)procesoAV.Moneda;
                                nudMontoCajero.Value = procesoAV.Detalle[0].Monto;
                                break;
                            case 2:
                                gbclientexterno.Visible = false;
                                gbCajero.Visible = true;
                                txtCajero.Text = procesoAV.Cajero.Nombre + ' ' + procesoAV.Cajero.Primer_apellido + ' ' + procesoAV.Cajero.Segundo_apellido;
                                cboCamara.SelectedItem = procesoAV.Camara;
                                cboMonedaDeclaradaCajero.SelectedIndex = (byte)procesoAV.Moneda;
                                nudMontoCajero.Value = procesoAV.Detalle[0].Monto;
                                break;
                            case 3:
                                gbclientexterno.Visible = true;
                                gbCajero.Visible = false;
                                if (procesoAV.Manifiesto != null)
                                    txtCodigoManifiesto.Text = procesoAV.Manifiesto.Codigo;
                                if (procesoAV.Detalle[0].Tula != null)
                                    txtCodigoTula.Text = procesoAV.Detalle[0].Tula.Codigo;
                                cboMonedaDeclarada.SelectedIndex = (byte)procesoAV.Moneda;
                                cboCliente.SelectedItem = procesoAV.Cliente;
                                Cliente cliente = (Cliente)cboCliente.SelectedItem;
                                cboPuntoVenta.ListaMostrada = cliente.Puntos_venta;
                                cboPuntoVenta.SelectedItem = procesoAV.PuntoVenta;
                                procesoAV.PuntoVenta = (PuntoVenta)cboPuntoVenta.SelectedItem;
                                nudMontoCliente.Value = procesoAV.Detalle[0].Monto;
                                break;
                            case 4:
                                gbclientexterno.Visible = false;
                                gbCajero.Visible = true;
                                txtCajero.Text = procesoAV.Cajero.Nombre + ' ' + procesoAV.Cajero.Primer_apellido + ' ' + procesoAV.Cajero.Segundo_apellido;
                                cboCamara.SelectedItem = procesoAV.Camara;
                                cboMonedaDeclaradaCajero.SelectedIndex = (byte)procesoAV.Moneda;
                                nudMontoCajero.Value = procesoAV.Detalle[0].Monto;
                                break;
                            case 5:
                                gbclientexterno.Visible = false;
                                gbCajero.Visible = true;
                                txtCajero.Text = procesoAV.Cajero.Nombre + ' ' + procesoAV.Cajero.Primer_apellido + ' ' + procesoAV.Cajero.Segundo_apellido;
                                cboCamara.SelectedItem = procesoAV.Camara;
                                cboMonedaDeclaradaCajero.SelectedIndex = (byte)procesoAV.Moneda;
                                nudMontoCajero.Value = procesoAV.Detalle[0].Monto;
                                break;
                        }
                        gbDatosContado.Enabled = true;
                        btnValidar.Enabled = true;
                        if (_tipovalidacion == 1)
                        {
                            deshabilitarmontos();
                            Habilitarformulas();
                            btnConteoAut.Visible = true;
                        }
                        else
                        {
                            habilitarmontos();
                            deshabilitarformulas();
                            btnConteoAut.Visible = false;
                        }
                        sumarTotales();
                    }
                    else
                    {
                        epError.SetError(txtHeaderCard, "El Headercard indicado no existe o no corresponde.");
                    }
                }
                else
                {
                    epError.SetError(txtHeaderCard, "El campo del Headercard se encuentra vacío.");
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        private void btnSaldoInicial_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void nudCincuentamil_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud50000CRC.Value, 50000, nud50000CRC);
        }

        private void nudCincomil_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud5000CRC.Value, 5000, nud5000CRC);
        }

        private void nudVeintemil_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud20000CRC.Value, 20000, nud20000CRC);
        }

        private void nudDosmil_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud2000CRC.Value, 2000, nud2000CRC);
        }

        private void nudDiezmil_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud10000CRC.Value, 10000, nud10000CRC);
        }

        private void nudMil_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud1000CRC.Value, 1000, nud1000CRC);
        }

        private void nudcincoeur_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud5EUR.Value, 5, nud5EUR);
        }

        private void nudcieneur_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud100EUR.Value, 100, nud100EUR);
        }

        private void nuddiezeur_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud10EUR.Value, 10, nud10EUR);
        }

        private void nuddoscientoseur_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud200EUR.Value, 200, nud200EUR);
        }

        private void nudveinteeur_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud20EUR.Value, 20, nud20EUR);
        }

        private void nudquinientoseur_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud500EUR.Value, 500, nud500EUR);
        }

        private void nudcincuentaeur_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud50EUR.Value, 50, nud50EUR);
        }

        private void nudunusd_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud1USD.Value, 1, nud1USD);
        }

        private void nudveinteusd_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud20USD.Value, 20, nud20USD);
        }

        private void nudcincousd_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud5USD.Value, 5, nud5USD);
        }

        private void nudcincuentausd_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud50USD.Value, 50, nud50USD);
        }

        private void nuddiezusd_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud10USD.Value, 10, nud10USD);
        }

        private void nudcienusd_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud100USD.Value, 100, nud10USD);
        }

        private void nudveinteusdrec_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudcincuentausdrec_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }
        private void nudcienusdrec_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudunusdrec_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudcincousdrec_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nuddiezusdrec_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudCincuentamilrec_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudVeintemilrec_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudDiezmilrec_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudCincomilrec_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudDosmilrec_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudMilrec_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        #endregion Eventos                                        
        
        #region Métodos Privados

        private void habilitarmontos()
        {
            nud10000CRC.Enabled = true;
            nud1000CRC.Enabled = true;
            nud50000CRC.Enabled = true;
            nud20000CRC.Enabled = true;
            nud2000CRC.Enabled = true;
            nud5000CRC.Enabled = true;
            nud1USD.Enabled = true;
            nud5USD.Enabled = true;
            nud10USD.Enabled = true;
            nud20USD.Enabled = true;
            nud50USD.Enabled = true;
            nud100USD.Enabled = true;
            nud5EUR.Enabled = true;
            nud10EUR.Enabled = true;
            nud20EUR.Enabled = true;
            nud50EUR.Enabled = true;
            nud100EUR.Enabled = true;
            nud200EUR.Enabled = true;
            nud500EUR.Enabled = true;
        }

        private void deshabilitarmontos()
        {
            nud10000CRC.Enabled = false;
            nud1000CRC.Enabled = false;
            nud50000CRC.Enabled = false;
            nud20000CRC.Enabled = false;
            nud2000CRC.Enabled = false;
            nud5000CRC.Enabled = false;
            nud1USD.Enabled = false;
            nud5USD.Enabled = false;
            nud10USD.Enabled = false;
            nud20USD.Enabled = false;
            nud50USD.Enabled = false;
            nud100USD.Enabled = false;
            nud5EUR.Enabled = false;
            nud10EUR.Enabled = false;
            nud20EUR.Enabled = false;
            nud50EUR.Enabled = false;
            nud100EUR.Enabled = false;
            nud200EUR.Enabled = false;
            nud500EUR.Enabled = false;
        }

        private void deshabilitarformulas() //Cambios GZH 11092017
        {
            nudMilrec.Enabled = false;
            nudDosmilrec.Enabled = false;
            nudCincomilrec.Enabled = false;
            nudDiezmilrec.Enabled = false;
            nudVeintemilrec.Enabled = false;
            nudCincuentamilrec.Enabled = false;
            nudunusdrec.Enabled = false;
            nudcincousdrec.Enabled = false;
            nuddiezusdrec.Enabled = false;
            nudveinteusdrec.Enabled = false;
            nudcincuentausdrec.Enabled = false;
            nudcienusdrec.Enabled = false;
            nudcincoeurrec.Enabled = false;
            nuddiezeurrec.Enabled = false;
            nudveinteeurrec.Enabled = false;
            nudcincuentaeurrec.Enabled = false;
            nudcieneurrec.Enabled = false;                                    
            nuddoscientoseurrec.Enabled = false;                        
            nudquinientoseurrec.Enabled = false;                        
        }

        private void Habilitarformulas() //Cambios GZH 11092017
        {
            nudMilrec.Enabled = true;
            nudDosmilrec.Enabled = true;
            nudCincomilrec.Enabled = true;
            nudDiezmilrec.Enabled = true;
            nudVeintemilrec.Enabled = true;
            nudCincuentamilrec.Enabled = true;
            nudunusdrec.Enabled = true;
            nudcincousdrec.Enabled = true;
            nuddiezusdrec.Enabled = true;
            nudveinteusdrec.Enabled = true;
            nudcincuentausdrec.Enabled = true;
            nudcienusdrec.Enabled = true;
            nudcincoeurrec.Enabled = true;
            nuddiezeurrec.Enabled = true;
            nudveinteeurrec.Enabled = true;
            nudcincuentaeurrec.Enabled = true;
            nudcieneurrec.Enabled = true;
            nuddoscientoseurrec.Enabled = true;
            nudquinientoseurrec.Enabled = true;
        }

        private bool ValidarMontos(Decimal monto, Decimal denominacion, NumericUpDown t)
        {
            bool bStatus = true;
            if ((monto % denominacion) != 0)
            {
                epError.SetError(t, "No se puede ingresar ese monto");
                bStatus = false;
            }
            else
                epError.SetError(t, "");


            return bStatus;

        }

        private void sumarTotales()
        {
            switch (cboMoneda.Text)
            {
                case "Colones":

                    decimal totalbilletes = nud5000CRC.Value + nud50000CRC.Value + nud10000CRC.Value + nud2000CRC.Value +
                    nud1000CRC.Value + nud20000CRC.Value;
                    decimal totalformulaCRC = (nudCincomilrec.Value * 5000) + (nudCincuentamilrec.Value * 50000) + (nudDiezmilrec.Value * 10000) + (nudDosmilrec.Value * 2000) +
                        (nudMilrec.Value * 1000) + (nudVeintemilrec.Value * 20000);
                    decimal totalcontadoCRC = totalbilletes + totalformulaCRC;

                    if (gbclientexterno.Visible)
                    {
                        decimal totalDiferencia = totalcontadoCRC - nudMontoCliente.Value;
                        //txtDiferencia.Text = System.Convert.ToString(totalDiferencia);
                        txtDiferencia.Text = totalDiferencia.ToString("n2");
                    }
                    else
                    {
                        decimal totalDiferencia = totalcontadoCRC - nudMontoCajero.Value;
                        //txtDiferencia.Text = System.Convert.ToString(totalDiferencia);
                        txtDiferencia.Text = totalDiferencia.ToString("n2");
                    }
                    //txtMontoContado.Text = System.Convert.ToString(totalcontadoCRC);                    
                    txtMontoContado.Text = totalcontadoCRC.ToString("n2");
                    break;
                case "Dólares":

                    decimal totalDolares = nud100USD.Value + nud5USD.Value + nud50USD.Value +
                        nud10USD.Value + nud1USD.Value + nud20USD.Value;
                    decimal totalformulaUSD = (nudunusdrec.Value) + (nudcincousdrec.Value * 5) + (nuddiezusdrec.Value * 10) + (nudveinteusdrec.Value * 20) +
                        (nudcincuentausdrec.Value * 50) + (nudcienusdrec.Value * 100);
                    decimal totalcontadoUSD = totalDolares + totalformulaUSD;
                    if (gbclientexterno.Visible)
                    {
                        decimal totalDiferencia = totalcontadoUSD - nudMontoCliente.Value;
                        //txtDiferencia.Text = System.Convert.ToString(totalDiferencia);
                        txtDiferencia.Text = totalDiferencia.ToString("n2");
                    }
                    else
                    {
                        decimal totalDiferencia = totalcontadoUSD - nudMontoCajero.Value;
                        //txtDiferencia.Text = System.Convert.ToString(totalDiferencia);
                        txtDiferencia.Text = totalDiferencia.ToString("n2");
                    }
                    //txtMontoContado.Text = System.Convert.ToString(totalcontadoUSD);
                    txtMontoContado.Text = totalcontadoUSD.ToString("n2");

                    break;
                case "Euros":

                    decimal totalEuros = nud100EUR.Value + nud5EUR.Value + nud50EUR.Value + nud10EUR.Value +
                    nud200EUR.Value + nud500EUR.Value + nud20EUR.Value;
                    decimal totalformulaEUR = (nudcincoeurrec.Value * 5) + (nuddiezeurrec.Value * 10) + (nudveinteeurrec.Value * 20) +
                        (nudcincuentaeurrec.Value * 50) + (nudcieneurrec.Value * 100) + (nuddoscientoseurrec.Value * 200) + (nudquinientoseurrec.Value * 500);
                    decimal totalcontadoEUR = totalEuros + totalformulaEUR;
                    if (gbclientexterno.Visible)
                    {
                        decimal totalDiferencia = totalcontadoEUR - nudMontoCliente.Value;
                        //txtDiferencia.Text = System.Convert.ToString(totalDiferencia);
                        txtDiferencia.Text = totalDiferencia.ToString("n2");
                    }
                    else
                    {
                        decimal totalDiferencia = totalcontadoEUR - nudMontoCajero.Value;
                        //txtDiferencia.Text = System.Convert.ToString(totalDiferencia);
                        txtDiferencia.Text = totalDiferencia.ToString("n2");
                    }
                    //txtMontoContado.Text = System.Convert.ToString(totalcontadoEUR);
                    txtMontoContado.Text = totalcontadoEUR.ToString("n2");

                    break;
                default:
                    break;
            }
        }

        #endregion Métodos Privados                                

        private void cboPuntoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nudcincoeurrec_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nuddiezeurrec_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudveinteeurrec_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudcincuentaeurrec_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudcieneurrec_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nuddoscientoseurrec_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudquinientoseurrec_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void txtMontoContado_TextChanged(object sender, EventArgs e)
        {
            epError.SetError(txtDiferencia, "");
            conteoerrores = 0;
        }

        private void limpiarvalores()
        {

            foreach (Control control in gbcolones.Controls)
            {
                NumericUpDown numControls = control as NumericUpDown;
                if (numControls != null)
                {
                    numControls.Value = 0;
                }
            }            
            foreach (Control control in gbdolares.Controls)
            {
                NumericUpDown numControls = control as NumericUpDown;
                if (numControls != null)
                {
                    numControls.Value = 0;
                }
            }               
            foreach (Control control in gbeuros.Controls)
            {
                NumericUpDown numControls = control as NumericUpDown;
                if (numControls != null)
                {
                    numControls.Value = 0;
                }
            }
            cboCamara.SelectedIndex = -1;
            nudMontoCajero.Value = 0;
            nudMontoCliente.Value = 0;
            cboMonedaDeclarada.SelectedIndex = -1;
            cboMonedaDeclaradaCajero.SelectedIndex = -1; 
            cboMoneda.SelectedIndex = -1;
            cboPuntoVenta.SelectedIndex = -1;
            cboCliente.SelectedIndex = -1;
            txtCajero.Text = "";
            txtCodigoManifiesto.Text = "";
            txtCodigoTula.Text = "";
            txtHeaderCard.Text = "";
            txtDiferencia.Text = "";
            sumarTotales();
        }

        private void txtHeaderCard_TextChanged(object sender, EventArgs e)
        {
            epError.SetError(txtHeaderCard, "");
        }

        public void permisocoordinador(int ID_Coordinador)
        {
            permisosup = true;
            _coordinador = ID_Coordinador;
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*Cliente cliente = (Cliente)cboCliente.SelectedItem;
            cboPuntoVenta.ListaMostrada = cliente.Puntos_venta;*/
        }

        private void cboMonedaDeclarada_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboMoneda.SelectedIndex = cboMonedaDeclarada.SelectedIndex;
            }
            catch(Excepcion ex)
            {
                MessageBox.Show("Error cbomonedaDeclarada_SelectedIndexChanged: " + ex.Message);
            }
        }

        private void cboMonedaDeclaradaCajero_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboMoneda.SelectedIndex = cboMonedaDeclaradaCajero.SelectedIndex;
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("Error cbomonedaDeclarada_SelectedIndexChanged: " + ex.Message);
            }
        }

        private void nud50000CRC_Click(object sender, EventArgs e)
        {
            try
            {
                nud50000CRC.Select(0, nud50000CRC.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud20000CRC_Click(object sender, EventArgs e)
        {
            try
            {
                nud20000CRC.Select(0, nud20000CRC.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud10000CRC_Click(object sender, EventArgs e)
        {
            try
            {
                nud10000CRC.Select(0, nud10000CRC.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud5000CRC_Click(object sender, EventArgs e)
        {
            try
            {
                nud5000CRC.Select(0, nud5000CRC.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud2000CRC_Click(object sender, EventArgs e)
        {
            try
            {
                nud2000CRC.Select(0, nud2000CRC.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud1000CRC_Click(object sender, EventArgs e)
        {
            try
            {
                nud1000CRC.Select(0, nud1000CRC.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud50000CRC_Enter(object sender, EventArgs e)
        {
            try
            {
                nud50000CRC.Select(0, nud50000CRC.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud20000CRC_Enter(object sender, EventArgs e)
        {
            try
            {
                nud20000CRC.Select(0, nud20000CRC.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud10000CRC_Enter(object sender, EventArgs e)
        {
            try
            {
                nud10000CRC.Select(0, nud10000CRC.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud5000CRC_Enter(object sender, EventArgs e)
        {
            try
            {
                nud5000CRC.Select(0, nud5000CRC.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud2000CRC_Enter(object sender, EventArgs e)
        {
            try
            {
                nud2000CRC.Select(0, nud2000CRC.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud1000CRC_Enter(object sender, EventArgs e)
        {
            try
            {
                nud1000CRC.Select(0, nud1000CRC.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudCincuentamilrec_Click(object sender, EventArgs e)
        {
            try
            {
                nudCincuentamilrec.Select(0, nudCincuentamilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudCincuentamilrec_Enter(object sender, EventArgs e)
        {
            try
            {
                nudCincuentamilrec.Select(0, nudCincuentamilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudVeintemilrec_Click(object sender, EventArgs e)
        {
            try
            {
                nudVeintemilrec.Select(0, nudVeintemilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudVeintemilrec_Enter(object sender, EventArgs e)
        {
            try
            {
                nudVeintemilrec.Select(0, nudVeintemilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudDiezmilrec_Click(object sender, EventArgs e)
        {
            try
            {
                nudDiezmilrec.Select(0, nudDiezmilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudDiezmilrec_Enter(object sender, EventArgs e)
        {
            try
            {
                nudDiezmilrec.Select(0, nudDiezmilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudCincomilrec_Click(object sender, EventArgs e)
        {
            try
            {
                nudCincomilrec.Select(0, nudCincomilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudCincomilrec_Enter(object sender, EventArgs e)
        {
            try
            {
                nudCincomilrec.Select(0, nudCincomilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudDosmilrec_Click(object sender, EventArgs e)
        {
            try
            {
                nudDosmilrec.Select(0, nudDosmilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudDosmilrec_Enter(object sender, EventArgs e)
        {
            try
            {
                nudDosmilrec.Select(0, nudDosmilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudMilrec_Click(object sender, EventArgs e)
        {
            try
            {
                nudMilrec.Select(0, nudMilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudMilrec_Enter(object sender, EventArgs e)
        {
            try
            {
                nudMilrec.Select(0, nudMilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud5EUR_Click(object sender, EventArgs e)
        {
            try
            {
                nud5EUR.Select(0, nud5EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud5EUR_Enter(object sender, EventArgs e)
        {
            try
            {
                nud5EUR.Select(0, nud5EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud10EUR_Click(object sender, EventArgs e)
        {
            try
            {
                nud10EUR.Select(0, nud10EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud10EUR_Enter(object sender, EventArgs e)
        {
            try
            {
                nud10EUR.Select(0, nud10EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud20EUR_Click(object sender, EventArgs e)
        {
            try
            {
                nud20EUR.Select(0, nud20EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud20EUR_Enter(object sender, EventArgs e)
        {
            try
            {
                nud20EUR.Select(0, nud20EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud50EUR_Click(object sender, EventArgs e)
        {
            try
            {
                nud50EUR.Select(0, nud50EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud50EUR_Enter(object sender, EventArgs e)
        {
            try
            {
                nud50EUR.Select(0, nud50EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud100EUR_Click(object sender, EventArgs e)
        {
            try
            {
                nud100EUR.Select(0, nud100EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud100EUR_Enter(object sender, EventArgs e)
        {
            try
            {
                nud100EUR.Select(0, nud100EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud200EUR_Click(object sender, EventArgs e)
        {
            try
            {
                nud200EUR.Select(0, nud200EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud200EUR_Enter(object sender, EventArgs e)
        {
            try
            {
                nud200EUR.Select(0, nud200EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud500EUR_Click(object sender, EventArgs e)
        {
            try
            {
                nud500EUR.Select(0, nud500EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud500EUR_Enter(object sender, EventArgs e)
        {
            try
            {
                nud500EUR.Select(0, nud500EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcincoeurrec_Click(object sender, EventArgs e)
        {
            try
            {
                nudcincoeurrec.Select(0, nudcincoeurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcincoeurrec_Enter(object sender, EventArgs e)
        {
            try
            {
                nudcincoeurrec.Select(0, nudcincoeurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nuddiezeurrec_Click(object sender, EventArgs e)
        {
            try
            {
                nuddiezeurrec.Select(0, nuddiezeurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nuddiezeurrec_Enter(object sender, EventArgs e)
        {
            try
            {
                nuddiezeurrec.Select(0, nuddiezeurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudveinteeurrec_Click(object sender, EventArgs e)
        {
            try
            {
                nudveinteeurrec.Select(0, nudveinteeurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudveinteeurrec_Enter(object sender, EventArgs e)
        {
            try
            {
                nudveinteeurrec.Select(0, nudveinteeurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcincuentaeurrec_Click(object sender, EventArgs e)
        {
            try
            {
                nudcincuentaeurrec.Select(0, nudcincuentaeurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcincuentaeurrec_Enter(object sender, EventArgs e)
        {
            try
            {
                nudcincuentaeurrec.Select(0, nudcincuentaeurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcieneurrec_Click(object sender, EventArgs e)
        {
            try
            {
                nudcieneurrec.Select(0, nudcieneurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcieneurrec_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void nudcieneurrec_Enter(object sender, EventArgs e)
        {
            try
            {
                nudcieneurrec.Select(0, nudcieneurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nuddoscientoseurrec_Click(object sender, EventArgs e)
        {
            try
            {
                nuddoscientoseurrec.Select(0, nuddoscientoseurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nuddoscientoseurrec_Enter(object sender, EventArgs e)
        {
            try
            {
                nuddoscientoseurrec.Select(0, nuddoscientoseurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudquinientoseurrec_Click(object sender, EventArgs e)
        {
            try
            {
                nudquinientoseurrec.Select(0, nudquinientoseurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudquinientoseurrec_Enter(object sender, EventArgs e)
        {
            try
            {
                nudquinientoseurrec.Select(0, nudquinientoseurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud1USD_Click(object sender, EventArgs e)
        {
            try
            {
                nud1USD.Select(0, nud1USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud1USD_Enter(object sender, EventArgs e)
        {
            try
            {
                nud1USD.Select(0, nud1USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud5USD_Click(object sender, EventArgs e)
        {
            try
            {
                nud5USD.Select(0, nud5USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud5USD_Enter(object sender, EventArgs e)
        {
            try
            {
                nud5USD.Select(0, nud5USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud10USD_Click(object sender, EventArgs e)
        {
            try
            {
                nud10USD.Select(0, nud10USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud10USD_Enter(object sender, EventArgs e)
        {
            try
            {
                nud10USD.Select(0, nud10USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudunusdrec_Click(object sender, EventArgs e)
        {
            try
            {
                nudunusdrec.Select(0, nudunusdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudunusdrec_Enter(object sender, EventArgs e)
        {
            try
            {
                nudunusdrec.Select(0, nudunusdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcincousdrec_Click(object sender, EventArgs e)
        {
            try
            {
                nudcincousdrec.Select(0, nudcincousdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcincousdrec_Enter(object sender, EventArgs e)
        {
            try
            {
                nudcincousdrec.Select(0, nudcincousdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nuddiezusdrec_Click(object sender, EventArgs e)
        {
            try
            {
                nuddiezusdrec.Select(0, nuddiezusdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nuddiezusdrec_Enter(object sender, EventArgs e)
        {
            try
            {
                nuddiezusdrec.Select(0, nuddiezusdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud20USD_Click(object sender, EventArgs e)
        {
            try
            {
                nud20USD.Select(0, nud20USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud20USD_Enter(object sender, EventArgs e)
        {
            try
            {
                nud20USD.Select(0, nud20USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud50USD_Click(object sender, EventArgs e)
        {
            try
            {
                nud50USD.Select(0, nud50USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud50USD_Enter(object sender, EventArgs e)
        {
            try
            {
                nud50USD.Select(0, nud50USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud100USD_Click(object sender, EventArgs e)
        {
            try
            {
                nud100USD.Select(0, nud100USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud100USD_Enter(object sender, EventArgs e)
        {
            try
            {
                nud100USD.Select(0, nud100USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudveinteusdrec_Click(object sender, EventArgs e)
        {
            try
            {
                nudveinteusdrec.Select(0, nudveinteusdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudveinteusdrec_Enter(object sender, EventArgs e)
        {
            try
            {
                nudveinteusdrec.Select(0, nudveinteusdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcincuentausdrec_Click(object sender, EventArgs e)
        {
            try
            {
                nudcincuentausdrec.Select(0, nudcincuentausdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcincuentausdrec_Enter(object sender, EventArgs e)
        {
            try
            {
                nudcincuentausdrec.Select(0, nudcincuentausdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcienusdrec_Click(object sender, EventArgs e)
        {
            try
            {
                nudcienusdrec.Select(0, nudcienusdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcienusdrec_Enter(object sender, EventArgs e)
        {
            try
            {
                nudcienusdrec.Select(0, nudcienusdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtHeaderCard_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue == 13) && (!txtHeaderCard.Text.Trim().Equals(String.Empty)))
                btnIngresarHC_Click(sender, e);
        }

        private void nud50000CRC_Click_1(object sender, EventArgs e)
        {
            try
            {
                nud50000CRC.Select(0, nud50000CRC.Text.Length);
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud50000CRC_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nud50000CRC.Select(0, nud50000CRC.Text.Length);
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud20000CRC_Click_1(object sender, EventArgs e)
        {
            nud20000CRC.Select(0, nud20000CRC.Text.Length);
        }

        private void nud20000CRC_Enter_1(object sender, EventArgs e)
        {
            nud20000CRC.Select(0, nud20000CRC.Text.Length);
        }

        private void nud10000CRC_Click_1(object sender, EventArgs e)
        {
            nud10000CRC.Select(0, nud10000CRC.Text.Length);
        }

        private void nud10000CRC_Enter_1(object sender, EventArgs e)
        {
            nud10000CRC.Select(0, nud10000CRC.Text.Length);
        }

        private void nud5000CRC_Click_1(object sender, EventArgs e)
        {
            nud5000CRC.Select(0, nud5000CRC.Text.Length);
        }

        private void nud5000CRC_Enter_1(object sender, EventArgs e)
        {
            nud5000CRC.Select(0, nud5000CRC.Text.Length);
        }

        private void nud2000CRC_Click_1(object sender, EventArgs e)
        {
            try
            {
                nud2000CRC.Select(0, nud2000CRC.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud2000CRC_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nud2000CRC.Select(0, nud2000CRC.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud1000CRC_Click_1(object sender, EventArgs e)
        {
            try
            {
                nud1000CRC.Select(0, nud1000CRC.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud1000CRC_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nud1000CRC.Select(0, nud1000CRC.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudCincuentamilrec_Click_1(object sender, EventArgs e)
        {
            try
            {
                nudCincuentamilrec.Select(0, nudCincuentamilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudCincuentamilrec_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nudCincuentamilrec.Select(0, nudCincuentamilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudVeintemilrec_Click_1(object sender, EventArgs e)
        {
            try
            {
                nudVeintemilrec.Select(0, nudVeintemilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudVeintemilrec_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nudVeintemilrec.Select(0, nudVeintemilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudDiezmilrec_Click_1(object sender, EventArgs e)
        {
            try
            {
                nudDiezmilrec.Select(0, nudDiezmilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudDiezmilrec_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nudDiezmilrec.Select(0, nudDiezmilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudCincomilrec_Click_1(object sender, EventArgs e)
        {
            try
            {
                nudCincomilrec.Select(0, nudCincomilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudCincomilrec_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nudCincomilrec.Select(0, nudCincomilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudDosmilrec_Click_1(object sender, EventArgs e)
        {
            try
            {
                nudDosmilrec.Select(0, nudDosmilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudDosmilrec_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nudDosmilrec.Select(0, nudDosmilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudMilrec_Click_1(object sender, EventArgs e)
        {
            try
            {
                nudMilrec.Select(0, nudMilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudMilrec_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nudMilrec.Select(0, nudMilrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcincoeurrec_Click_1(object sender, EventArgs e)
        {
            try
            {
                nudcincoeurrec.Select(0, nudcincoeurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcincoeurrec_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nudcincoeurrec.Select(0, nudcincoeurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nuddiezeurrec_Click_1(object sender, EventArgs e)
        {
            try
            {
                nuddiezeurrec.Select(0, nuddiezeurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nuddiezeurrec_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nuddiezeurrec.Select(0, nuddiezeurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudveinteeurrec_Click_1(object sender, EventArgs e)
        {
            try
            {
                nudveinteeurrec.Select(0, nudveinteeurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudveinteeurrec_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nudveinteeurrec.Select(0, nudveinteeurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcincuentaeurrec_Click_1(object sender, EventArgs e)
        {
            try
            {
                nudcincuentaeurrec.Select(0, nudcincuentaeurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcincuentaeurrec_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nudcincuentaeurrec.Select(0, nudcincuentaeurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcieneurrec_Click_1(object sender, EventArgs e)
        {
            try
            {
                nudcieneurrec.Select(0, nudcieneurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcieneurrec_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nudcieneurrec.Select(0, nudcieneurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nuddoscientoseurrec_Click_1(object sender, EventArgs e)
        {
            try
            {
                nuddoscientoseurrec.Select(0, nuddoscientoseurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nuddoscientoseurrec_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nuddoscientoseurrec.Select(0, nuddoscientoseurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud500EUR_Click_1(object sender, EventArgs e)
        {
            try
            {
                nud500EUR.Select(0, nud500EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudquinientoseurrec_Click_1(object sender, EventArgs e)
        {
            try
            {
                nudquinientoseurrec.Select(0, nudquinientoseurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud500EUR_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nud500EUR.Select(0, nud500EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud5EUR_Click_1(object sender, EventArgs e)
        {
            try
            {
                nud5EUR.Select(0, nud5EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud10EUR_Click_1(object sender, EventArgs e)
        {
            try
            {
                nud10EUR.Select(0, nud10EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud10EUR_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nud10EUR.Select(0, nud10EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void nud5EUR_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nud5EUR.Select(0, nud5EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud20EUR_Click_1(object sender, EventArgs e)
        {
            try
            {
                nud20EUR.Select(0, nud20EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud20EUR_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nud20EUR.Select(0, nud20EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud50EUR_Click_1(object sender, EventArgs e)
        {
            try
            {
                nud50EUR.Select(0, nud50EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud50EUR_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nud50EUR.Select(0, nud50EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudquinientoseurrec_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nudquinientoseurrec.Select(0, nudquinientoseurrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud100EUR_Click_1(object sender, EventArgs e)
        {
            try
            {
                nud100EUR.Select(0, nud100EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud100EUR_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nud100EUR.Select(0, nud100EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud200EUR_Click_1(object sender, EventArgs e)
        {
            try
            {
                nud200EUR.Select(0, nud200EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud200EUR_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nud200EUR.Select(0, nud200EUR.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud1USD_Click_1(object sender, EventArgs e)
        {
            try
            {
                nud1USD.Select(0, nud1USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud1USD_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nud1USD.Select(0, nud1USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud5USD_Click_1(object sender, EventArgs e)
        {
            try
            {
                nud5USD.Select(0, nud5USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud5USD_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nud5USD.Select(0, nud5USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud10USD_Click_1(object sender, EventArgs e)
        {
            try
            {
                nud10USD.Select(0, nud10USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud10USD_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nud10USD.Select(0, nud10USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud20USD_Click_1(object sender, EventArgs e)
        {
            try
            {
                nud20USD.Select(0, nud20USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud20USD_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nud20USD.Select(0, nud20USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud50USD_Click_1(object sender, EventArgs e)
        {
            try
            {
                nud50USD.Select(0, nud50USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud50USD_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nud50USD.Select(0, nud50USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud100USD_Click_1(object sender, EventArgs e)
        {
            try
            {
                nud100USD.Select(0, nud100USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nud100USD_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nud100USD.Select(0, nud100USD.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudunusdrec_Click_1(object sender, EventArgs e)
        {
            try
            {
                nudunusdrec.Select(0, nudunusdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudunusdrec_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nudunusdrec.Select(0, nudunusdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcincousdrec_Click_1(object sender, EventArgs e)
        {
            try
            {
                nudcincousdrec.Select(0, nudcincousdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcincousdrec_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nudcincousdrec.Select(0, nudcincousdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nuddiezusdrec_Click_1(object sender, EventArgs e)
        {
            try
            {
                nuddiezusdrec.Select(0, nuddiezusdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nuddiezusdrec_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nuddiezusdrec.Select(0, nuddiezusdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudveinteusdrec_Click_1(object sender, EventArgs e)
        {
            try
            {
                nudveinteusdrec.Select(0, nudveinteusdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudveinteusdrec_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nudveinteusdrec.Select(0, nudveinteusdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcincuentausdrec_Click_1(object sender, EventArgs e)
        {
            try
            {
                nudcincuentausdrec.Select(0, nudcincuentausdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcincuentausdrec_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nudcincuentausdrec.Select(0, nudcincuentausdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcienusdrec_Click_1(object sender, EventArgs e)
        {
            try
            {
                nudcienusdrec.Select(0, nudcienusdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudcienusdrec_Enter_1(object sender, EventArgs e)
        {
            try
            {
                nudcienusdrec.Select(0, nudcienusdrec.Text.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboMonedaDeclaradaCajero_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                cboMoneda.SelectedIndex = cboMonedaDeclaradaCajero.SelectedIndex;
            }
            catch(Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboMonedaDeclarada_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                cboMoneda.SelectedIndex = cboMonedaDeclarada.SelectedIndex;
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
