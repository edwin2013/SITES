//
//  @ Project : 
//  @ File Name : frmDescargasPendientes.cs
//  @ Date : 26/11/2012
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

    public partial class frmDescargasPendientes : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private CierreATMs _cierre = null;

        #endregion Atributos

        #region Constructor

        public frmDescargasPendientes(CierreATMs cierre)
        {
            InitializeComponent();

            _cierre = cierre;

            dgvDescargasPendientes.AutoGenerateColumns = false;
            dgvMontosCarga.AutoGenerateColumns = false;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de mostrar todas las descargas pendientes.
        /// </summary>
        private void btnMostrarTodas_Click(object sender, EventArgs e)
        {
            frmValidacionCoordinador formulario = new frmValidacionCoordinador();

            if (formulario.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    BindingList<DescargaATM> descargas_normales = _coordinacion.listarDescargasATMsPendientes();
                    BindingList<DescargaATM> descargas_emergencia = _coordinacion.listarDescargasATMsEmergenciaPendientes();
                    BindingList<DescargaATM> descargas = new BindingList<DescargaATM>();

                    foreach (DescargaATM descarga in descargas_normales)
                        descargas.Add(descarga);

                    foreach (DescargaATM descarga in descargas_emergencia)
                        descargas.Add(descarga);

                    dgvDescargasPendientes.DataSource = descargas;
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }

        /// <summary>
        /// Clic en el botón de buscar.
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                string marchamo = txtMarchamoBusqueda.Text;

                BindingList<DescargaATM> descargas_normales = _coordinacion.listarDescargasATMsPendientesPorMarchamo(marchamo);
                BindingList<DescargaATM> descargas_emergencia = _coordinacion.listarDescargasATMsEmergenciaPendientesPorMarchamo(marchamo);

                BindingList<DescargaATM> descargas = new BindingList<DescargaATM>();

                foreach (DescargaATM descarga in descargas_normales)
                    descargas.Add(descarga);

                foreach (DescargaATM descarga in descargas_emergencia)
                    descargas.Add(descarga);

                dgvDescargasPendientes.DataSource = descargas;
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

            try
            {
                frmRegistroCierreATMs padre = (frmRegistroCierreATMs)this.Owner;
                DescargaATM descarga = (DescargaATM)dgvDescargasPendientes.SelectedRows[0].DataBoundItem;
                    
                descarga.Cierre = _cierre;
                descarga.recalcularDetalles();

                _coordinacion.agregarDescargaATM(ref descarga);

                padre.agregarDescarga(descarga);

                this.Close();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de cancelar.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se selecciona una descarga de la lista de descargas pendientes.
        /// </summary>
        private void dgvDescargasPendientes_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvDescargasPendientes.SelectedRows.Count > 0)
            {
                DescargaATM descarga = (DescargaATM)dgvDescargasPendientes.SelectedRows[0].DataBoundItem;

                dgvMontosCarga.DataSource = descarga.Cartuchos;

                btnAceptar.Enabled = true;
            }
            else
            {
                btnAceptar.Enabled = false;
            }

        }

        /// <summary>
        /// Se cambia el código del marchamo buscado.
        /// </summary>
        private void txtMarchamoBusqueda_TextChanged(object sender, EventArgs e)
        {
            btnBuscar.Enabled = txtMarchamoBusqueda.TextLength > 2;
        }

        #endregion Eventos

        private void gbBusqueda_Enter(object sender, EventArgs e)
        {

        }

       

    }

}
