//
//  @ Project : 
//  @ File Name : frmMarcacionTulas.cs
//  @ Date : 15/06/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{
    public partial class frmMarcacionManifiestos : Form
    {

        #region Atributos

        private AtencionBL _atencion = AtencionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmMarcacionManifiestos()
        {
            InitializeComponent();

            dgvManifiestos.AutoGenerateColumns = false;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el  botón de buscar.
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                string manifiesto_buscado = txtCodigoManifiesto.Text;

                dgvManifiestos.DataSource = _atencion.listarManifiestosPorCodigo(manifiesto_buscado);
                dgvManifiestos.AutoResizeColumns();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el  botón de marcar.
        /// </summary>
        private void btnMarcar_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime fecha = dtpFecha.Value;
                Manifiesto manifiesto = (Manifiesto)dgvManifiestos.SelectedRows[0].DataBoundItem;

                manifiesto.Fecha_recoleccion = fecha;

                _atencion.actualizarManifiestoMarcarRetraso(ref manifiesto);

                btnMarcar.Visible = false;
                btnDesmarcar.Visible = true;

                dgvManifiestos.Refresh();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el  botón de desmarcar.
        /// </summary>
        private void btnDesmarcar_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime fecha = dtpFecha.Value;
                Manifiesto manifiesto = (Manifiesto)dgvManifiestos.SelectedRows[0].DataBoundItem;

                _atencion.actualizarManifiestoDesmarcarRetraso(ref manifiesto);

                btnMarcar.Visible = true;
                btnDesmarcar.Visible = false;

                dgvManifiestos.Refresh();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el  botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se escribe en el texto de búsqueda.
        /// </summary>
        private void txtCodigoManifiesto_TextChanged(object sender, EventArgs e)
        {
            btnBuscar.Enabled = txtCodigoManifiesto.Text.Length >= 5;
        }

        #endregion Eventos

        private void dgvManifiestos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvManifiestos.SelectedRows.Count > 0)
            {
                Manifiesto manifiesto = (Manifiesto)dgvManifiestos.SelectedRows[0].DataBoundItem;

                if (manifiesto.Retraso)
                {
                    btnDesmarcar.BringToFront();
                    btnDesmarcar.Enabled = true;
                    btnMarcar.Enabled = false;
                }
                else
                {
                    btnMarcar.BringToFront();
                    btnDesmarcar.Enabled = false;
                    btnMarcar.Enabled = true;
                }

            }
            else
            {
                btnMarcar.Enabled = false;
                btnDesmarcar.Enabled = false;
            }

        }

        #region Métodos Privados
        
        #endregion Métodos Privados

    }

}
