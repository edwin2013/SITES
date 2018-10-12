//
//  @ Project : 
//  @ File Name : frmOrdenRuta.cs
//  @ Date : 25/10/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using LibreriaReportesOffice;

namespace GUILayer
{

    public partial class frmOrdenRuta : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private DateTime _fecha;

        #endregion Atributos

        #region Constructor

        public frmOrdenRuta(DateTime fecha)
        {
            InitializeComponent();

            _fecha = fecha;

            dgvCargas.AutoGenerateColumns = false;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                byte ruta = (byte)nudRuta.Value;

                dgvCargas.DataSource = _coordinacion.listarCargasATMsPorRuta(ruta, _fecha);
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

            try
            {
                BindingList<CargaATM> cargas = (BindingList<CargaATM>)dgvCargas.DataSource;

                for (byte orden = 0; orden < cargas.Count; orden++)
                {
                    CargaATM carga = cargas[orden];

                    carga.Orden_ruta = orden;
                }

                _coordinacion.actualizarCargasATMsOrdenRuta(cargas);

                Mensaje.mostrarMensaje("MensajeCargasATMsConfirmacionActualizacionOrden");
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de arriba para cambiar el orden de las cargas.
        /// </summary>
        private void btnArriba_Click(object sender, EventArgs e)
        {
            this.cambiarOrdenCarga(-1);
        }

        /// <summary>
        /// Clic en el botón de abajo para cambiar el orden de las cargas.
        /// </summary>
        private void btnAbajo_Click(object sender, EventArgs e)
        {
            this.cambiarOrdenCarga(1);
        }

        /// <summary>
        /// Clic en el botón de cancelar.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se agrega una carga a la lista de cargas.
        /// </summary>
        private void dgvCargas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCargas.Rows[e.RowIndex + contador];
                CargaATM carga = (CargaATM)fila.DataBoundItem;

                fila.Cells[ATMCarga.Index].Value = carga.ToString();
            }

        }

        /// <summary>
        /// Se selecciona otra carga de la lista de cargas.
        /// </summary>
        private void dgvCargas_SelectionChanged(object sender, EventArgs e)
        {
            this.validaBotonesDesplazamientos();
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Cambiar el orden de una carga en la lista de carga.
        /// </summary>
        private void cambiarOrdenCarga(int desplazamiento)
        {
            BindingList<CargaATM> cargas = (BindingList<CargaATM>)dgvCargas.DataSource;
            DataGridViewRow fila = dgvCargas.SelectedRows[0];
            CargaATM carga = (CargaATM)fila.DataBoundItem;
            int posicion = fila.Index + desplazamiento;

            cargas.Remove(carga);
            cargas.Insert(posicion, carga);

            dgvCargas.Rows[posicion].Selected = true;
        }

        /// <summary>
        /// Mostrar u ocultar los botones de desplazamiento dependiendo de la selección de una fila.
        /// </summary>
        private void validaBotonesDesplazamientos()
        {

            if (dgvCargas.SelectedRows.Count > 0)
            {
                BindingList<CargaATM> cargas = (BindingList<CargaATM>)dgvCargas.DataSource;
                DataGridViewRow fila = dgvCargas.SelectedRows[0];

                btnArriba.Enabled = fila.Index != 0;
                btnAbajo.Enabled = fila.Index != cargas.Count - 1;
                btnGuardar.Enabled = true;
            }
            else
            {
                btnArriba.Enabled = false;
                btnAbajo.Enabled = false;
                btnGuardar.Enabled = false;
            }

        }

        #endregion Métodos Privados

    }

}
