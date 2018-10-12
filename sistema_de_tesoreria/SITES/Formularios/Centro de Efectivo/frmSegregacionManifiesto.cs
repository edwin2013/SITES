//
//  @ Project : 
//  @ File Name : frmSegregacionManifiesto.cs
//  @ Date : 09/11/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmSegregacionManifiesto : Form
    {

        #region Atributos

        private AtencionBL _atencion = AtencionBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private Colaborador _coordinador = null;

        #endregion Atributos

        #region Eventos

        #endregion Eventos

        #region Constructor

        public frmSegregacionManifiesto(Colaborador coordinador)
        {
            InitializeComponent();

            dgvManifiestos.AutoGenerateColumns = false;
            dgvManifiestosSegregados.AutoGenerateColumns = false;

            _coordinador = coordinador;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de segregar.
        /// </summary>
        private void btnSegregar_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeManifiestoSegregacion") == DialogResult.Yes)
                {
                    ManifiestoCEF manifiesto = (ManifiestoCEF)dgvManifiestos.SelectedRows[0].DataBoundItem;

                    int cajeros = (int)nudCajeros.Value;

                    _atencion.segregarManifiesto(manifiesto, cajeros);

                    dgvManifiestosSegregados.DataSource = manifiesto.Segregados;
                    dgvManifiestosSegregados.Enabled = true;

                    gbSegregacion.Enabled = false;
                    btnEliminar.Enabled = true;

                    Mensaje.mostrarMensaje("MensajeManifiestoConfirmacionSegregacion");
                }

            }
            catch(Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de eliminar segregados.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeManifiestoEliminacionSegregacion") == DialogResult.Yes)
                {
                    ManifiestoCEF manifiesto = (ManifiestoCEF)dgvManifiestos.SelectedRows[0].DataBoundItem;

                    _atencion.eliminarSegregadosManifiesto(manifiesto);

                    manifiesto.Segregados.Clear();

                    dgvManifiestosSegregados.DataSource = manifiesto.Segregados;
                    dgvManifiestosSegregados.Enabled = false;

                    gbSegregacion.Enabled = true;
                    btnEliminar.Enabled = false;

                    Mensaje.mostrarMensaje("MensajeManifiestoConfirmacionEliminacionSegregacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de buscar.
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                string codigo = txtCodigoBuscado.Text;

                if (codigo == string.Empty && codigo.Length < 4) return;

                dgvManifiestos.DataSource = _atencion.listarManifiestosCEFRecientes(codigo);

                txtCodigoBuscado.Text = string.Empty;
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
        /// Se selecciona otro manifiesto.
        /// </summary>
        private void dgvManifiestos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvManifiestos.SelectedRows.Count > 0)
            {
                ManifiestoCEF manifiesto = (ManifiestoCEF)dgvManifiestos.SelectedRows[0].DataBoundItem;

                dgvManifiestosSegregados.DataSource = manifiesto.Segregados;

                gbManifiestosSegregados.Enabled = false;

                if (manifiesto.Segregados.Count == 0)
                {
                    gbSegregacion.Enabled = true;
                    btnEliminar.Enabled = false;
                }
                else
                {
                    gbSegregacion.Enabled = false;
                    btnEliminar.Enabled = _coordinador.Puestos.Contains(Puestos.Supervisor);
                }

            }
            else
            {
                this.deshabilitarOpciones();
            }

        }

        /// <summary>
        /// El cuadro de búsqueda obtiene el foco.
        /// </summary>
        private void txtCodigoBuscado_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnBuscar;
        }

        /// <summary>
        /// El NumericUpDown del número de cajas obtiene el foco.
        /// </summary>
        private void nudCajeros_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnSegregar;
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Deshabilitar las opciones de la ventana.
        /// </summary>
        private void deshabilitarOpciones()
        {
            dgvManifiestosSegregados.DataSource = null;

            gbManifiestosSegregados.Enabled = false;
            gbSegregacion.Enabled = false;
            btnEliminar.Enabled = false;
        }

        #endregion Métodos Privados

    }

}
