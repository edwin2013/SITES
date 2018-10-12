//
//  @ Project : 
//  @ File Name : frmSeleccionManifiestoDescargaATM.cs
//  @ Date : 07/12/2012
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

    public partial class frmSeleccionManifiestoDescargaATMFull : Form
    {

        #region Atributos

        private AtencionBL _atencion = AtencionBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private DescargaATMFull _descarga = null;
        private ManifiestoATMFull _manifiesto = null;

        #endregion Atributos

        #region Constructor

        public frmSeleccionManifiestoDescargaATMFull(DescargaATMFull descarga)
        {
            InitializeComponent();

            _descarga = descarga;
            _manifiesto = _descarga.Manifiesto;

            try
            {
                BindingList<ManifiestoATMFull> manifiestos = new BindingList<ManifiestoATMFull>();

                dgvManifiestos.AutoGenerateColumns = false;
                dgvManifiestos.DataSource = manifiestos;

                if (_manifiesto != null) manifiestos.Add(_manifiesto);
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de Buscar.
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                string codigo = txtCodigoBuscado.Text;

                if (codigo == string.Empty && codigo.Length < 4)
                    return;

                dgvManifiestos.DataSource = _atencion.listarManifiestosATMsFullPorCodigo(codigo);

                txtCodigoBuscado.Text = string.Empty;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            frmRegistroCierreATMs padre = (frmRegistroCierreATMs)this.Owner;
            ManifiestoATMFull manifiesto = (ManifiestoATMFull)dgvManifiestos.SelectedRows[0].DataBoundItem;

            padre.seleccionarManifiestoDescargaFull(manifiesto);

            this.Close();
        }

        /// <summary>
        /// Clic en el botón de cancelar.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
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
        /// Se selecciona el control del texto de búsqueda.
        /// </summary>
        private void txtCodigoBuscado_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnBuscar;
        }

        /// <summary>
        /// El control del texto de búsqueda pierde el foco.
        /// </summary>
        private void txtCodigoBuscado_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = btnAceptar;
        }

        /// <summary>
        /// Se selecciona otro manifiesto de la lista de manifiestos.
        /// </summary>
        private void dgvManifiestos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvManifiestos.SelectedRows.Count > 0)
            {
                _manifiesto = (ManifiestoATMFull)dgvManifiestos.SelectedRows[0].DataBoundItem;

                gbDatosManifiesto.Enabled = true;

                this.mostrarDatos();
            }
            else
            {
                gbDatosManifiesto.Enabled = false;

                this.limpiarDatos();
            }

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Limpiar los datos mostrados del manifiesto.
        /// </summary>
        private void limpiarDatos()
        {
            btnAceptar.Enabled = false;

            txtCodigoManifiesto.Text = string.Empty;
            txtMarchamo.Text = string.Empty;
            txtMarchamoAdicionalENA.Text = string.Empty;
            txtMarchamoENAA.Text = string.Empty;
            txtMarchamoENAB.Text = string.Empty;
        }

        /// <summary>
        /// Limpiar los datos mostrados de un manifiesto seleccionado.
        /// </summary>
        private void mostrarDatos()
        {
            btnAceptar.Enabled = true;

            //txtFecha.Text = _manifiesto.Fecha.ToShortDateString();
            txtCodigoManifiesto.Text = _manifiesto.Codigo;
            txtMarchamo.Text = _manifiesto.Marchamo;

            if (_manifiesto.Marchamo_adicional_ena == null)
            {
                txtMarchamoAdicionalENA.Text = string.Empty;
                txtMarchamoENAA.Text = string.Empty;
                txtMarchamoENAB.Text = string.Empty;
            }
            else
            {
                txtMarchamoAdicionalENA.Text = _manifiesto.Marchamo_adicional_ena;
                txtMarchamoENAA.Text = _manifiesto.Marchamo_ena_a;
                txtMarchamoENAB.Text = _manifiesto.Marchamo_ena_b;
            }

        }

        #endregion Métodos Privados

    }

}
