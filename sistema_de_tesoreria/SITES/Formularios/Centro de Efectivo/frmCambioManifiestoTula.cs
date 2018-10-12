//
//  @ Project : 
//  @ File Name : frmCambioManifiestoTula.cs
//  @ Date : 28/11/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmCambioManifiestoTula : Form
    {

        #region Atributos

        private AtencionBL _atencion = AtencionBL.Instancia;

        private Colaborador _coordinador = null;

        #endregion Atributos

        #region Constructor

        public frmCambioManifiestoTula(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            dgvManifiestos.AutoGenerateColumns = false;
            dgvTulas.AutoGenerateColumns = false;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (dgvManifiestos.SelectedRows.Count == 0)
            {
                Excepcion.mostrarMensaje("ErrorTulaDatosActualizacion");
                return;
            }

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeTulaActualizacionManifiesto") == DialogResult.Yes)
                {
                    Manifiesto manifiesto = (Manifiesto)dgvManifiestos.SelectedRows[0].DataBoundItem;
                    Tula tula = (Tula)dgvTulas.SelectedRows[0].DataBoundItem;

                    tula.Manifiesto = manifiesto;

                    _atencion.actualizarTulaManifiesto(tula, _coordinador);

                    Mensaje.mostrarMensaje("MensajeTulaConfirmacionActualizacionManifiesto");
                    this.Close();
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de buscar tula.
        /// </summary>
        private void btnBuscarTula_Click(object sender, EventArgs e)
        {
            try
            {
                string tula_buscada = txtCodigoTulaBuscada.Text;

                dgvTulas.DataSource = _atencion.listarTulasPorCodigo(tula_buscada);

                txtCodigoTulaBuscada.Text = string.Empty;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de buscar manifiesto.
        /// </summary>
        private void btnBuscarManifiesto_Click(object sender, EventArgs e)
        {

            try
            {
                string codigo = txtCodigoManifiestoBuscado.Text;

                dgvManifiestos.DataSource = _atencion.listarManifiestosCEFPorCodigo(codigo);

                txtCodigoManifiestoBuscado.Text = string.Empty;
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
        /// Se selecciona otra tula.
        /// </summary>
        private void dgvTulas_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvTulas.SelectedRows.Count > 0)
            {
                Tula tula = (Tula)dgvTulas.SelectedRows[0].DataBoundItem;

                _atencion.obtenerManifiestoTula(ref tula);

                Manifiesto manifiesto = tula.Manifiesto;

                txtCodigoManifiesto.Text = manifiesto.Codigo;
                txtReceptor.Text = manifiesto.Receptor.Nombre;
                txtEmpresa.Text = manifiesto.Empresa.Nombre;
                txtCaja.Text = manifiesto.Caja.ToString();
                txtGrupo.Text = manifiesto.Grupo.Nombre;
                txtFecha.Text = manifiesto.Fecha_recepcion.ToShortDateString();
            }
            else
            {
                txtCodigoManifiesto.Text = string.Empty;
                txtReceptor.Text = string.Empty;
                txtEmpresa.Text = string.Empty;
                txtCaja.Text = string.Empty;
                txtGrupo.Text = string.Empty;
                txtFecha.Text = string.Empty;
            }

        }

        /// <summary>
        /// Se selecciona otro manifiesto.
        /// </summary>
        private void dgvManifiestos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvManifiestos.SelectedRows.Count > 0)
            {
                Manifiesto manifiesto = (Manifiesto)dgvManifiestos.SelectedRows[0].DataBoundItem;

                txtCodigoManifiestoNuevo.Text = manifiesto.Codigo;
                txtReceptorNuevo.Text = manifiesto.Receptor.Nombre;
                txtEmpresaNueva.Text = manifiesto.Empresa.Nombre;
                txtCajaNueva.Text = manifiesto.Caja.ToString();
                txtGrupoNuevo.Text = manifiesto.Grupo.Nombre;
                txtFechaNueva.Text = manifiesto.Fecha_recepcion.ToShortDateString();
            }
            else
            {
                txtCodigoManifiestoNuevo.Text = string.Empty;
                txtReceptorNuevo.Text = string.Empty;
                txtEmpresaNueva.Text = string.Empty;
                txtCajaNueva.Text = string.Empty;
                txtGrupoNuevo.Text = string.Empty;
                txtFechaNueva.Text = string.Empty;
            }

        }

        /// <summary>
        /// Se escribe en el texto de búsqueda de la tula.
        /// </summary>
        private void txtCodigoTulaBuscada_TextChanged(object sender, EventArgs e)
        {
            btnBuscarTula.Enabled = txtCodigoTulaBuscada.Text.Length >= 4;
        }

        /// <summary>
        /// Se escribe en el texto de búsqueda del manifiesto.
        /// </summary>
        private void txtCodigoManifiestoBuscado_TextChanged(object sender, EventArgs e)
        {
            btnBuscarManifiesto.Enabled = txtCodigoManifiestoBuscado.Text.Length >= 4;
        }

        #endregion Eventos

    }

}
