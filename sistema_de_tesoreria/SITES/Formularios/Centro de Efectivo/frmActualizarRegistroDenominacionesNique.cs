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
    public partial class frmActualizarRegistroDenominacionesNiquel : Form
    {
        #region Atributos

        Decimal montoNiquel;
        ConteoNiquel conteoNiquel;
        #endregion Atributos

        #region Constructor

        public frmActualizarRegistroDenominacionesNiquel(ConteoNiquel conteoNiquel, Boolean readOnly)
        {
            InitializeComponent();
            this.conteoNiquel = conteoNiquel;
            cargarDatos();
            btnProcesar.Enabled = false;
        }

        private void cargarDatos()
        {
            nud500.Value = conteoNiquel.conteo500;
            nud100.Value = conteoNiquel.conteo100;
            nud50.Value = conteoNiquel.conteo50;
            nud25.Value = conteoNiquel.conteo25;
            nud10.Value = conteoNiquel.conteo10;
            nud5.Value = conteoNiquel.conteo5;
            sumarTotales();
        }

        #endregion Constructor

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (montosCorrectos())
            {
                frmActualizarBajoVolumen padre = (frmActualizarBajoVolumen)this.Owner;
                sumarTotales();
                ConteoNiquel conteoNiquel = new ConteoNiquel(c500: nud500.Value, c50: nud50.Value, c25: nud25.Value, c10: nud10.Value, c100: nud100.Value, c5: nud5.Value);
                padre.actualizarmontoNiquel(montoNiquel);
                padre.actualizarconteoNiquel(conteoNiquel);
                this.Close();
            }
            else
            {
                MessageBox.Show("Hay datos incorrectos, verifique por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion Eventos


        #region Métodos Privados

        private bool montosCorrectos()
        {
            return (nud500.Value % 500) == 0 && (nud100.Value % 100) == 0 && (nud50.Value % 50) == 0 && (nud25.Value % 25) == 0 && (nud10.Value % 10) == 0 && (nud5.Value % 5) == 0;
        }

        private void ValidarMontos(Decimal monto, Decimal denominacion, NumericUpDown t)
        {
            if ((monto % denominacion) != 0)
            {
                epError.SetError(t, "Monto inválido. " + monto + " no es múltiplo de " + denominacion + ", verifique si es tan amable");
            }
            else
            {
                epError.SetError(t, "");
            }
            sumarTotales();
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
            ValidarMontos(nud500.Value, 500, nud500);
        }

        private void nud25_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud25.Value, 25, nud25);
        }

        private void nud100_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud100.Value, 100, nud100);
        }

        private void nud5_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud5.Value, 5, nud5);
        }

        private void nud10_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud10.Value, 10, nud10);
        }

        private void nud50_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud50.Value, 50, nud50);
        }

        private void frmActualizarRegistroDenominacionesNiquel_Load(object sender, EventArgs e)
        {

        }
    }
}
