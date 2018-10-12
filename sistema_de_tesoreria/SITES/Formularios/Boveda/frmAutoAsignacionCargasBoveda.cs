using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects;
using LibreriaMensajes;
using CommonObjects.Clases;
using BussinessLayer;

namespace GUILayer.Formularios.Boveda
{
    public partial class frmAutoAsignacionCargasBoveda : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        Dictionary<Colaborador, List<CargaSucursal>> _cargas_asignadas = null;

        #endregion Atributos

        #region Constructor

        public frmAutoAsignacionCargasBoveda()
        {
            InitializeComponent();

            try
            {
                dgvCargas.AutoGenerateColumns = false;
                dgvCargasAsignadas.AutoGenerateColumns = false;

                BindingList<Colaborador> cajeros = _seguridad.listarColaboradoresPorPuestoArea(Areas.Boveda, Puestos.CajeroA);

                foreach (Colaborador cajero in cajeros)
                    clbCajeros.Items.Add(cajero);

                this.actualizarlista();
            }
            catch(Excepcion ex)
            {
                this.Close();
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de asignar.
        /// </summary>
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            List<Colaborador> cajeros = new List<Colaborador>();

            foreach (object cajero in clbCajeros.CheckedItems)
                cajeros.Add((Colaborador)cajero);

            BindingList<CargaSucursal> cargas = (BindingList<CargaSucursal>)dgvCargas.DataSource;

            _cargas_asignadas = _coordinacion.autoAsignarCargasSucursal(cajeros, cargas);

            cboCajero.ListaMostrada = cajeros;

            dgvCargasAsignadas.DataSource = null;

            gbCargasAsignadas.Enabled = true;
            btnAceptar.Enabled = true;
        }

        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.actualizarlista();
        }

        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                frmAsignacionCargasSucursales padre = (frmAsignacionCargasSucursales)this.Owner;

                padre.autoasignarCargas(_cargas_asignadas);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

            this.Close();
        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se selecciona otro cajero en la lista de cajeros.
        /// </summary>
        private void cboCajero_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboCajero.SelectedItem == null)
            {
                dgvCargasAsignadas.DataSource = null;
            }
            else
            {
                Colaborador cajero = (Colaborador)cboCajero.SelectedItem;

                dgvCargasAsignadas.DataSource = _cargas_asignadas[cajero];
            }

        }

        /// <summary>
        /// Se agrega una carga a la lista de cargas asignadas.
        /// </summary>
        private void dgvCargasAsignadas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCargasAsignadas.Rows[e.RowIndex + contador];
                CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;

                fila.Cells[ATMCargaAsignada.Index].Value = carga.ToString();
            }

        }

        /// <summary>
        /// Se agrega una carga a la lista de cargas pendientes.
        /// </summary>
        private void dgvCargas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCargas.Rows[e.RowIndex + contador];
                CargaSucursal carga = (CargaSucursal)fila.DataBoundItem;

                fila.Cells[ATMCarga.Index].Value = carga.ToString();
            }

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Actualizar la lista de cargas.
        /// </summary>
        private void actualizarlista()
        {

            try
            {
                DateTime fecha = dtpFecha.Value;

                dgvCargas.DataSource = _coordinacion.listarCargasSucursalesSinAsignarCajero(null, null, fecha, null);

                dgvCargasAsignadas.DataSource = null;
                gbCargasAsignadas.Enabled = false;

                cboCajero.Text = string.Empty;
                cboCajero.ListaMostrada = null;

                btnAceptar.Enabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Métodos Privados

    }
}
