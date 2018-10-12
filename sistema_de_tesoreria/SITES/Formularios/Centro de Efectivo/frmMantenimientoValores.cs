//
//  @ Project : 
//  @ File Name : frmMantenimientoValores.cs
//  @ Date : 30/09/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

using CommonObjects;

namespace GUILayer
{

    public partial class frmMantenimientoValores : Form
    {

        #region Constructor

        public frmMantenimientoValores()
        {
            InitializeComponent();
        }
        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtIdentificador.Text.Equals(string.Empty) || cboTipo.SelectedItem == null)
                return;

            frmMantenimientoInconsistenciasDepositos padre = (frmMantenimientoInconsistenciasDepositos)this.Owner;

            TipoValor tipo = (TipoValor)cboTipo.SelectedIndex;
            string identificador = txtIdentificador.Text;
            string comentario = txtComentario.Text;

            Valor valor = new Valor(tipo, identificador, comentario);

            padre.agregarValor(valor);
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
