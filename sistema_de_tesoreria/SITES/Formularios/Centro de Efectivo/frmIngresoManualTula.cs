//
//  @ Project : 
//  @ File Name : frmIngresoManualTula.cs
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

    public partial class frmIngresoManualTula : Form
    {

        #region Atributos

        private AtencionBL _atencion = AtencionBL.Instancia;

        private Colaborador _coordinador = null;

        #endregion Atributos

        #region Constructor

        public frmIngresoManualTula(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            dgvManifiestos.AutoGenerateColumns = false;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de buscar manifiesto.
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                string codigo = txtCodigoBuscado.Text;

                if (codigo == string.Empty && codigo.Length < 4) return;

                dgvManifiestos.DataSource = _atencion.listarManifiestosPorCodigo(codigo);

                txtCodigoBuscado.Text = string.Empty;

                if (dgvManifiestos.RowCount > 0)
                {
                    gbDatosTula.Enabled = true;
                    txtCodigo.Focus();
                }
                else
                {
                    gbDatosTula.Enabled = false;
                }

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

            if (dgvManifiestos.SelectedRows.Count == 0 || txtCodigo.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorTulaDatosRegistro");
                return;
            }

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeTulaRegistro") == DialogResult.Yes)
                {
                    string codigo = txtCodigo.Text;
                    Manifiesto manifiesto = (Manifiesto)dgvManifiestos.SelectedRows[0].DataBoundItem;
                    DateTime fecha= dtpFecha.Value;

                    Tula tula = new Tula(codigo, manifiesto: manifiesto, fecha_ingreso: fecha);

                    _atencion.agregarTula(ref tula, _coordinador);

                    Mensaje.mostrarMensaje("MensajeTulaConfirmacionRegistro");

                    this.Close();
                }

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
        /// El cuadro de texto del código del manifiesto obtiene el foco.
        /// </summary>
        private void txtCodigoBuscado_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnBuscar;
        }

        /// <summary>
        /// El cuadro de texto del código de la tula obtiene el foco.
        /// </summary>
        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnGuardar;
        }

        #endregion Eventos

    }

}
