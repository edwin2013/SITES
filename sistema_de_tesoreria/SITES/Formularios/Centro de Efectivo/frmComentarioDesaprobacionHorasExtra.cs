//
//  @ Project : 
//  @ File Name : frmComentarioDesaprobacionHorasExtra.cs
//  @ Date : 05/12/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

namespace GUILayer
{

    public partial class frmComentarioDesaprobacionHorasExtra : Form
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

        public frmComentarioDesaprobacionHorasExtra()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de cancelar.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _comentario = txtComentario.Text;
            this.Close();
        }

        /// <summary>
        /// Se escribe en el campo de texto del comentario.
        /// </summary>
        private void txtComentario_TextChanged(object sender, EventArgs e)
        {
            btnAceptar.Enabled = txtComentario.Text.Length > 0;
        }

        #endregion Eventos

    }

}
