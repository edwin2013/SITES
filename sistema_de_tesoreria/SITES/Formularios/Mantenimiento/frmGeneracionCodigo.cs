//
//  @ Project : 
//  @ File Name : frmGeneracionCodigo.cs
//  @ Date : 19/09/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

namespace GUILayer
{

    public partial class frmGeneracionCodigo : Form
    {

        #region Constructor

        public frmGeneracionCodigo(string[] datos)
        {
            InitializeComponent();

            txtCodigo.Text = datos[0];
            txtContrasena.Text = datos[1];
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Eventos

    }

}
