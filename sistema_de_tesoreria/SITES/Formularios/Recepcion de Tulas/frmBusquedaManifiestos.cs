//
//  @ Project : 
//  @ File Name : frmBusquedaTulas.cs
//  @ Date : 15/06/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmBusquedaManifiestos : Form
    {

        #region Atributos

        private AtencionBL _atencion = AtencionBL.Instancia;

        private Manifiesto _manifiesto = null;
        private Colaborador _colaborador = null;

        #endregion Atributos

        #region Constructor

        public frmBusquedaManifiestos(Colaborador colaborador, bool modificacion)
        {
            InitializeComponent();

            _colaborador = colaborador;

            dgvTulasManifiesto.AutoGenerateColumns = false;
            dgvManifiestos.AutoGenerateColumns = false;

            txtCodigoManifiesto.ReadOnly = !modificacion;
            btnGuardar.Visible = modificacion;
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
                string manifiesto_buscado = txtCodigoBuscado.Text;

                dgvManifiestos.DataSource = _atencion.listarManifiestosPorCodigo(manifiesto_buscado);
              
                txtCodigoBuscado.Text = string.Empty;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtCodigoManifiesto.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorManifiestoDatos");
                return;
            }

            try
            {
                _manifiesto.Codigo = txtCodigoManifiesto.Text;

                _atencion.actualizarCodigoManifiesto(_manifiesto, _colaborador);

                txtCodigoBuscado.Focus();

                Mensaje.mostrarMensaje("MensajeManifiestoConfirmacionActualizacion");
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se escribe en el texto de búsqueda.
        /// </summary>
        private void txtCodigoBuscado_TextChanged(object sender, EventArgs e)
        {
            btnBuscar.Enabled = txtCodigoBuscado.Text.Length >= 4;
        }

        /// <summary>
        /// Se selecciona otro manifiesto en la lista de manifiestos.
        /// </summary>
        private void dgvManifiestos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvManifiestos.SelectedRows.Count > 0)
            {
                _manifiesto = (Manifiesto)dgvManifiestos.SelectedRows[0].DataBoundItem;

                dgvTulasManifiesto.DataSource = _atencion.listarTulasPorManifiesto(_manifiesto);

                txtCodigoManifiesto.Text = _manifiesto.Codigo;
                txtReceptor.Text = _manifiesto.Receptor.ToString();
                txtEmpresa.Text = _manifiesto.Empresa.Nombre;
                txtCaja.Text = _manifiesto.Caja.ToString();
                txtGrupo.Text = _manifiesto.Grupo.Nombre;
                if (_manifiesto.Cajero_Receptor != null)
                    txtCajeroAsignado.Text = _manifiesto.Cajero_Receptor.ToString();
                else
                    txtCajeroAsignado.Text = string.Empty;

                if (_manifiesto.Cajero_Receptor != null) 
                    txtCajeroAsignado.Text = _manifiesto.Cajero_Receptor.ToString();

                switch (_manifiesto.Area)
                {
                    case AreasManifiestos.Boveda: txtArea.Text = "Bóveda"; break;
                    case AreasManifiestos.CentroEfectivo: txtArea.Text = "CEF"; break;
                }

                gbDatosManifiesto.Enabled = true;
                gbTulas.Enabled = true;
            }
            else
            {
                dgvTulasManifiesto.DataSource = null;

                txtCajeroAsignado.Text = string.Empty;
                txtCodigoManifiesto.Text = string.Empty;
                txtArea.Text = string.Empty;
                txtReceptor.Text = string.Empty;
                txtEmpresa.Text = string.Empty;
                txtCaja.Text = string.Empty;
                txtGrupo.Text = string.Empty;

                gbDatosManifiesto.Enabled = false;
                gbTulas.Enabled = false;
            }

        }

        /// <summary>
        /// Se selecciona el cuadro de texto de búsqueda.
        /// </summary>
        private void txtCodigoBuscado_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnBuscar;
        }

        /// <summary>
        /// Se selecciona el cuadro del código del manifiesto.
        /// </summary>
        private void txtCodigoManifiesto_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = this.btnGuardar;
        }

        #endregion Eventos

    }

}
