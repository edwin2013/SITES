//
//  @ Project : 
//  @ File Name : frmDescargasFullPendientes.cs
//  @ Date : 13/02/2013
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

    public partial class frmDescargasFullPendientes : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private CierreATMs _cierre = null;

        #endregion Atributos

        #region Constructor

        public frmDescargasFullPendientes(CierreATMs cierre)
        {
            InitializeComponent();

            _cierre = cierre;

            dgvDescargasFullPendientes.AutoGenerateColumns = false;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de mostrar todas las descargas full pendientes.
        /// </summary>
        private void btnMostrarTodas_Click(object sender, EventArgs e)
        {
            frmValidacionCoordinador formulario = new frmValidacionCoordinador();

            if (formulario.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    BindingList<DescargaATMFull> descargas_normales = _coordinacion.listarDescargasATMsFullPendientes();
                    BindingList<DescargaATMFull> descargas_emergencia = _coordinacion.listarDescargasATMsFullEmergenciaPendientes();

                    BindingList<DescargaATMFull> descargas = new BindingList<DescargaATMFull>();

                    foreach (DescargaATMFull descarga in descargas_normales)
                        descargas.Add(descarga);

                    foreach (DescargaATMFull descarga in descargas_emergencia)
                        descargas.Add(descarga);

                    dgvDescargasFullPendientes.DataSource = descargas;
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

                dgvDescargasFullPendientes.DataSource = _coordinacion.listarDescargasATMsFullPendientesPorMarchamo(marchamo);
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
                DescargaATMFull descarga = (DescargaATMFull)dgvDescargasFullPendientes.SelectedRows[0].DataBoundItem;

                descarga.Cierre = _cierre;

                _coordinacion.agregarDescargaATMFull(ref descarga);

                padre.agregarDescargaFull(descarga);

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
        private void dgvDescargasFullPendientes_SelectionChanged(object sender, EventArgs e)
        {
            btnAceptar.Enabled = dgvDescargasFullPendientes.SelectedRows.Count > 0;
        }

        /// <summary>
        /// Se cambia el código del marchamo buscado.
        /// </summary>
        private void txtMarchamoBusqueda_TextChanged(object sender, EventArgs e)
        {
            btnBuscar.Enabled = txtMarchamoBusqueda.TextLength > 2;
        }

        #endregion Eventos

    }

}
