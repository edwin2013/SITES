//
//  @ Project : 
//  @ File Name : frmCorreccionRegistro.cs
//  @ Date : 15/06/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmCorreccionRegistro : Form
    {

        #region Atributos

        private AtencionBL _atencion = AtencionBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmCorreccionRegistro()
        {
            InitializeComponent();

            dgvTulas.AutoGenerateColumns = false;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de buscar.
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                string tula_buscada = txtCodigoBuscado.Text;

                dgvTulas.DataSource = _atencion.listarTulasPorCodigo(tula_buscada);

                txtCodigoBuscado.Text = string.Empty;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Se presiona el botón de eliminar.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarTula();
        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se selecciona otra tula en la lista de tulas.
        /// </summary>
        private void dgvTulas_SelectionChanged(object sender, EventArgs e)
        {
            btnEliminar.Enabled = dgvTulas.SelectedRows.Count > 0;
        }

        /// <summary>
        /// Se escribe en el texto de búsqueda.
        /// </summary>
        private void txtCodigoBuscado_TextChanged(object sender, EventArgs e)
        {
            btnBuscar.Enabled = txtCodigoBuscado.Text.Length >= 3;
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Eliminar una tula la base de datos.
        /// </summary>
        private void eliminarTula()
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeTulaEliminacion") == DialogResult.Yes)
                {
                    Tula tula = (Tula)dgvTulas.SelectedRows[0].DataBoundItem;

                    _atencion.eliminarTulaCorrecion(tula);

                    dgvTulas.Rows.Remove(dgvTulas.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeTulaConfirmacionEliminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Métodos Privados

    }

}
