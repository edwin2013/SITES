//
//  @ Project : 
//  @ File Name : frmAdministracionRegistroErrores.cs
//  @ Date : 05/08/2011
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

    public partial class frmAdministracionRegistroErrores : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _coordinador = null;

        #endregion Atributos

        #region Constructor

        public frmAdministracionRegistroErrores(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            try
            {
                // Cargar la lista de registros y de colaboradores

                cboColaborador.ListaMostrada = _seguridad.listarColaboradoresPorArea(_coordinador.Area);

                if (cboColaborador.Items.Count > 0) cboColaborador.SelectedIndex = 0;

                dgvRegistros.AutoGenerateColumns = false;

                this.listarDatos();
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
                this.listarDatos();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }
        
        /// <summary>
        /// Clic en el botón de nuevo registro de horas extra.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoRegistroErrores formulario = new frmMantenimientoRegistroErrores(_coordinador);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Clic en el botón de eliminar.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeRegistroErrorCierreEliminacion") == DialogResult.Yes)
                {
                    RegistroErroresCierre registro = (RegistroErroresCierre)dgvRegistros.SelectedRows[0].DataBoundItem;

                    _coordinacion.eliminarRegistroErroresCierre(registro);

                    dgvRegistros.Rows.Remove(dgvRegistros.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeRegistroErrorCierreConfirmacionEliminacion");
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
        /// Se selecciona otra fila.
        /// </summary>
        private void dgvRegistros_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvRegistros.SelectedRows.Count > 0)
            {
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }

        }

        /// <summary>
        /// Doble clic en la lista de registros.
        /// </summary>
        private void dgvRegistros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se agregan filas a la lista de registro de errores.
        /// </summary>
        private void dgvRegistros_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvRegistros.Rows[e.RowIndex + contador];

                this.actualizarErrores(fila);
            }

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Actualizar los errores del registro.
        /// </summary>
        public void actualizarErrores(DataGridViewRow fila)
        {
            RegistroErroresCierre registro = (RegistroErroresCierre)fila.DataBoundItem;

            String errores = string.Empty;

            foreach (TipoErrorCierre error in registro.Errores)
                errores += error.Nombre + '\n';

            fila.Cells[Errores.Index].Value = errores;
        }

        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        public void mostarVentanaModificacion()
        {

            try
            {
                RegistroErroresCierre registro = (RegistroErroresCierre)dgvRegistros.SelectedRows[0].DataBoundItem;
                frmMantenimientoRegistroErrores formulario = new frmMantenimientoRegistroErrores(registro, _coordinador);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Mostrar la lista de registros de horas extra.
        /// </summary>
        private void listarDatos()
        {

            try
            {
                DateTime inicio = dtpInicio.Value;
                DateTime finalizacion = dtpFinalizacion.Value;

                if (cboColaborador.SelectedIndex == 0)
                {
                    dgvRegistros.DataSource = _coordinacion.listarRegistrosErroresCierres(inicio, finalizacion);
                }
                else
                {
                    Colaborador colaborador = (Colaborador)cboColaborador.SelectedItem;

                    dgvRegistros.DataSource = _coordinacion.listarRegistrosErroresCierresCajero(colaborador, inicio, finalizacion);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Métodos Privados

        #region Métodos Públicos

        /// <summary>
        /// Actualizar los valores de la lista.
        /// </summary>
        public void actualizarLista()
        {
            dgvRegistros.Refresh();
            dgvRegistros.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un registro de errores a la lista.
        /// </summary>
        public void agregarRegistro(RegistroErroresCierre registro)
        {
            BindingList<RegistroErroresCierre> registros = (BindingList<RegistroErroresCierre>)dgvRegistros.DataSource;

            registros.Add(registro);
            dgvRegistros.AutoResizeColumns();
        }

        #endregion Métodos Públicos

    }

}
