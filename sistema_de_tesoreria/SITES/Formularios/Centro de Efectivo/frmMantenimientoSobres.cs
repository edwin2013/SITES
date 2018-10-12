//
//  @ Project : 
//  @ File Name : frmMantenimientoSobres.cs
//  @ Date : 26/11/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

using CommonObjects;

namespace GUILayer
{

    public partial class frmMantenimientoSobres : Form
    {

        #region Atributos

        #endregion Atributos

        #region Constructor

        public frmMantenimientoSobres()
        {
            InitializeComponent();

            cboMoneda.SelectedIndex = (byte)Monedas.Colones;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            frmMantenimientoInconsistenciasDepositos padre = (frmMantenimientoInconsistenciasDepositos)this.Owner;

            Monedas moneda = (Monedas)cboMoneda.SelectedIndex;
            decimal monto_reportado = nudMontoReportadoSobre.Value;
            decimal monto_real = nudMontoRealSobre.Value;
            int numero = (int)nudNumeroSobre.Value;

            Sobre sobre = new Sobre(numero, monto_reportado, monto_real, moneda);

            padre.agregarSobre(sobre);
            this.Close();
        }

        /// <summary>
        /// Clic en el botón de cancelar.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Eventos

    }

}
