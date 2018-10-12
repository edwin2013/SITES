//
//  @ Project : 
//  @ File Name : frmAdministracionColaboradores.cs
//  @ Date : 19/04/2011
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

    public partial class frmAdministracionColaboradores : Form
    {
       
        #region Atributos
       
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _administrador = null;

        #endregion Atributos

        #region Constructor

        public frmAdministracionColaboradores(Colaborador administrador)
        {
            InitializeComponent();

            _administrador = administrador;

            try
            {
                // Cargar la lista de colaboradores

                dgvColaboradores.AutoGenerateColumns = false;
                dgvColaboradores.DataSource = _seguridad.listarColaboradores(string.Empty);
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
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                string buscado = txtBuscar.Text;

                dgvColaboradores.DataSource = _seguridad.listarColaboradores(buscado);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

         /// <summary>
        /// Clic en el botón de agregar colaborador.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoColaboradores formulario = new frmMantenimientoColaboradores(_administrador);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar colaborador.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Clic en el botón de eliminar colaborador.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeColaboradorEliminacion") == DialogResult.Yes)
                {
                    Colaborador colaborador = (Colaborador)dgvColaboradores.SelectedRows[0].DataBoundItem;

                    _seguridad.eliminarColaborador(colaborador);

                    dgvColaboradores.Rows.Remove(dgvColaboradores.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeColaboradorConfirmacionEliminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de reiniciar contraseña.
        /// </summary>
        private void btnReiniciarContraseña_Click(object sender, EventArgs e)
        {

            try
            {
                Colaborador colaborador = (Colaborador)dgvColaboradores.SelectedRows[0].DataBoundItem;

                _seguridad.reiniciarColaboradorContrasena(colaborador);

                Mensaje.mostrarMensaje("MensajeColaboradorConfirmacionActualizacionContrasena");
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
        /// Doble clic en la lista de colaboradores.
        /// </summary>
        private void dgvColaboradores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se agregan filas a la lista de colaboradores.
        /// </summary>
        private void dgvColaboradores_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvColaboradores.Rows[e.RowIndex + contador];

                this.actualizarAreas(fila);
            }

        }

        /// <summary>
        /// Se selecciona otro colaborador.
        /// </summary>
        private void dgvColaboradores_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvColaboradores.SelectedRows.Count > 0)
            {
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                btnReiniciarContraseña.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnReiniciarContraseña.Enabled = false;
            }

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Actualizar el área del colaborador.
        /// </summary>
        public void actualizarAreas(DataGridViewRow fila)
        {
            Colaborador colaborador = (Colaborador)fila.DataBoundItem;

            string area = string.Empty;

            switch (colaborador.Area)
            {
                case Areas.CentroEfectivo: area = "Centro de Efectivo"; break;
                case Areas.Boveda: area = "Bóveda"; break;
                case Areas.ATMs: area = "ATM's"; break;
                case Areas.Tesoreria: area = "Tesorería"; break;
                case Areas.Blindados: area = "Blindados"; break;
            }

            fila.Cells[Area.Index].Value = area;
        }

        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        public void mostarVentanaModificacion()
        {

            try
            {
                Colaborador colaborador = (Colaborador)dgvColaboradores.SelectedRows[0].DataBoundItem;
                frmMantenimientoColaboradores formulario = new frmMantenimientoColaboradores(_administrador, colaborador);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Métodos Privados

        #region Métodos Públicos

        /// <summary>
        /// Actualizar los colaboradores de la lista.
        /// </summary>
        public void actualizarLista()
        {
            DataGridViewRow fila = dgvColaboradores.SelectedRows[0];

            this.actualizarAreas(fila);

            dgvColaboradores.Refresh();
            dgvColaboradores.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un colaborador a la lista.
        /// </summary>
        public void agregarColaborador(Colaborador colaborador)
        {
            BindingList<Colaborador> colaboradores = (BindingList<Colaborador>)dgvColaboradores.DataSource;

            colaboradores.Add(colaborador);
            dgvColaboradores.AutoResizeColumns();
        }

        #endregion Métodos Públicos

    }

}
