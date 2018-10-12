using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects.Clases;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmRegistroDenominacionesNiquel : Form
    {
        #region Atributos

        Decimal montoNiquel;
        private bool Error = false;
        private Boolean VerificaMonto = true;
        private byte cancelact = 0;

        #endregion Atributos

        #region Constructor

        public frmRegistroDenominacionesNiquel()
        {
            InitializeComponent();
            nud500.Tag = nud500.Value;
            nud100.Tag = nud100.Value;
            nud50.Tag = nud500.Value;
            nud25.Tag = nud25.Value;
            nud10.Tag = nud10.Value;
            nud5.Tag = nud5.Value;
        }

        #endregion Constructor

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            frmBajoVolumenIngresoDepositos padre = (frmBajoVolumenIngresoDepositos)this.Owner;
            ConteoNiquel conteoNiquel = new ConteoNiquel(c500: nud500.Value, c50: nud50.Value, c25: nud25.Value, c10: nud10.Value, c100: nud100.Value, c5: nud5.Value);            
            padre.actualizarmontoNiquel(montoNiquel);
            padre.actualizarconteoNiquel(conteoNiquel);
            this.Close();
        }

        private void nud500_ValueChanged(object sender, EventArgs e)
        {
            if ((VerificaMonto == true) && (cancelact == 0))
            {

                decimal mValuePre = (decimal)nud500.Tag;
                if (mValuePre > nud500.Value)
                {
                    epError.SetError(nud500, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud500.Tag);
                    Error = true;
                    sumarTotales();
                }
                else
                {
                    if (ValidarMontos(nud500.Value, 500, nud500))
                    {
                        Error = false;
                        nud500.Tag = nud500.Value;
                        sumarTotales();
                    }
                }
                epError.SetError(nud500, "");
            }
        }

        #endregion Eventos


        #region Métodos Privados

        private bool ValidarMontos(Decimal monto, Decimal denominacion, NumericUpDown t)
        {
            bool bStatus = true;
            if ((monto % denominacion) != 0)
            {                
                bStatus = false;
                sumarTotales();
            }
            else
            {
                if (Error != true)
                {
                    epError.SetError(t, "");
                }
            }

            return bStatus;

        }

        private void sumarTotales()
        {            
            montoNiquel = nud5.Value + nud50.Value + nud100.Value + nud25.Value +
                    nud10.Value + nud500.Value;
            txtMontoContado.Text = montoNiquel.ToString("n2");     
            //montodep = new MontoDeposito(denominacion: new Denominacion(moneda: ((Monedas)cboMonedaDeclarada.SelectedIndex)), cantidad_asignada: totalcontado);                        
        }

        #endregion Métodos Privados        

        private void nud500_Leave(object sender, EventArgs e)
        {
            if (cancelact == 0)
            {
                VerificaMonto = ValidarMontos(nud500.Value, 500, nud500);
            }
        }

        private void nud25_Leave(object sender, EventArgs e)
        {
            if (cancelact == 0)
            {
                VerificaMonto = ValidarMontos(nud25.Value, 25, nud25);
            }
        }

        private void nud100_Leave(object sender, EventArgs e)
        {
            if (cancelact == 0)
            {
                VerificaMonto = ValidarMontos(nud100.Value, 100, nud100);
            }
        }

        private void nud5_Leave(object sender, EventArgs e)
        {
            if (cancelact == 0)
            {
                VerificaMonto = ValidarMontos(nud5.Value, 5, nud5);
            }
        }

        private void nud10_Leave(object sender, EventArgs e)
        {
            if (cancelact == 0)
            {
                VerificaMonto = ValidarMontos(nud10.Value, 10, nud10);
            }
        }

        private void nud50_Leave(object sender, EventArgs e)
        {
            if (cancelact == 0)
            {
                VerificaMonto = ValidarMontos(nud50.Value, 50, nud50);
            }
        }

        private void nud100_ValueChanged(object sender, EventArgs e)
        {
            if ((VerificaMonto == true) && (cancelact == 0))
            {

                decimal mValuePre = Convert.ToDecimal(nud100.Tag);
                if (mValuePre > nud100.Value)
                {
                    epError.SetError(nud100, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud100.Tag);
                    Error = true;
                    sumarTotales();
                }
                else
                {
                    if (ValidarMontos(nud100.Value, 100, nud100))
                    {
                        Error = false;
                        nud100.Tag = nud100.Value;
                        sumarTotales();
                    }
                }
                epError.SetError(nud100, "");
            }
        }

        private void nud50_ValueChanged(object sender, EventArgs e)
        {
            if ((VerificaMonto == true) && (cancelact == 0))
            {

                decimal mValuePre = Convert.ToDecimal(nud50.Tag);
                if (mValuePre > nud50.Value)
                {
                    epError.SetError(nud500, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud50.Tag);
                    Error = true;
                    sumarTotales();
                }
                else
                {
                    if (ValidarMontos(nud50.Value, 50, nud50))
                    {
                        Error = false;
                        nud50.Tag = nud50.Value;
                        sumarTotales();
                    }
                }
                epError.SetError(nud50, "");
            }
        }

        private void nud25_ValueChanged(object sender, EventArgs e)
        {
            if ((VerificaMonto == true) && (cancelact == 0))
            {

                decimal mValuePre = Convert.ToDecimal(nud25.Tag);
                if (mValuePre > nud25.Value)
                {
                    epError.SetError(nud25, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud25.Tag);
                    Error = true;
                    sumarTotales();
                }
                else
                {
                    if (ValidarMontos(nud25.Value, 25, nud25))
                    {
                        Error = false;
                        nud25.Tag = nud25.Value;
                        sumarTotales();
                    }
                }
                epError.SetError(nud25, "");
            }
        }

        private void nud10_ValueChanged(object sender, EventArgs e)
        {
            if ((VerificaMonto == true) && (cancelact == 0))
            {

                decimal mValuePre = Convert.ToDecimal(nud10.Tag);
                if (mValuePre > nud10.Value)
                {
                    epError.SetError(nud10, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud10.Tag);
                    Error = true;
                    sumarTotales();
                }
                else
                {
                    if (ValidarMontos(nud100.Value, 10, nud10))
                    {
                        Error = false;
                        nud10.Tag = nud10.Value;
                        sumarTotales();
                    }
                }
                epError.SetError(nud10, "");
            }
        }

        private void nud5_ValueChanged(object sender, EventArgs e)
        {
            if ((VerificaMonto == true) && (cancelact == 0))
            {

                decimal mValuePre = (decimal)nud5.Tag;
                if (mValuePre > nud5.Value)
                {
                    epError.SetError(nud100, "No se puede ingresar ese monto, el valor permitido es igual o mayor a " + nud5.Tag);
                    Error = true;
                    sumarTotales();
                }
                else
                {
                    if (ValidarMontos(nud100.Value, 5, nud5))
                    {
                        Error = false;
                        nud5.Tag = nud5.Value;
                        sumarTotales();
                    }
                }
                epError.SetError(nud5, "");
            }
        }
    }
}
