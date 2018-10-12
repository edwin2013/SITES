//
//  @ Project : 
//  @ File Name : frmComentarioBitacora.cs
//  @ Date : 14/10/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUILayer
{

    public partial class frmComentarioBitacora : Form
    {

        #region Atributos

        private string _comentario;

        public string Comentario
        {
            get { return _comentario; }
            set { _comentario = value; }
        }

        #endregion Atributos

        #region Constructor

        public frmComentarioBitacora()
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
            _comentario = txtComentario.Text;
            this.Close();
        }

        /// <summary>
        /// Se cambia el comentario.
        /// </summary>
        private void txtComentario_TextChanged(object sender, EventArgs e)
        {
            btnAceptar.Enabled = txtComentario.Text.Length > 0;
        }

        #endregion Eventos

    }

}
