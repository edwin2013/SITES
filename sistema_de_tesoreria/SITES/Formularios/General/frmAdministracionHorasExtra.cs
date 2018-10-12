//
//  @ Project : 
//  @ File Name : frmAdministracionHorasExtra.cs
//  @ Date : 05/08/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmAdministracionHorasExtra : Form
    {

        #region Atributos

        private SupervisionBL _supervision = SupervisionBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _coordinador = null;

        private bool _supervisor = false;

        #endregion Atributos

        #region Constructor

        public frmAdministracionHorasExtra(Colaborador coordinador)
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

                // Validar si el usuario es supervisor

                _supervisor = _coordinador.Puestos.Contains(Puestos.Supervisor);
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
        /// Clic en el botón de desaprobar.
        /// </summary>
        private void btnRechazar_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeRegistrosHorasExtraRechazo") == DialogResult.Yes)
                {
                    frmComentarioBitacora formulario = new frmComentarioBitacora();

                    formulario.ShowDialog();

                    string comentario = formulario.Comentario;

                    foreach (DataGridViewRow fila in dgvRegistros.SelectedRows)
                    {
                        RegistroHorasExtra registro = (RegistroHorasExtra)fila.DataBoundItem;

                        if (registro.Estado == Estados.Aprobado || registro.Estado == Estados.NoRevisado)
                            _supervision.actualizarRegistroHorasExtraRechazar(ref registro, _coordinador, comentario);

                    }

                    btnAprobar.Enabled = true;
                    btnRechazar.Enabled = false;

                    this.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeRegistrosHorasExtraConfirmacionRechazo");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de aprobar.
        /// </summary>
        private void btnAprobar_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeRegistrosHorasExtraAprobacion") == DialogResult.Yes)
                {

                    foreach (DataGridViewRow fila in dgvRegistros.SelectedRows)
                    {
                        RegistroHorasExtra registro = (RegistroHorasExtra)fila.DataBoundItem;

                        if (registro.Estado == Estados.Rechazado || registro.Estado == Estados.NoRevisado)
                            _supervision.actualizarRegistroHorasExtraAprobar(ref registro);

                    }

                    btnAprobar.Enabled = false;
                    btnRechazar.Enabled = true;

                    this.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeRegistrosHorasExtraConfirmacionAprobacion");
                }

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
                frmMantenimientoHorasExtra formulario = new frmMantenimientoHorasExtra(_coordinador);

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

                if (Mensaje.mostrarMensajeConfirmacion("MensajeRegistroHorasExtraEliminacion") == DialogResult.Yes)
                {
                    RegistroHorasExtra registro = (RegistroHorasExtra)dgvRegistros.SelectedRows[0].DataBoundItem;

                    _supervision.eliminarRegistroHorasExtra(registro);

                    dgvRegistros.Rows.Remove(dgvRegistros.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeRegistroHorasExtraConfirmacionEliminacion");
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

                if (dgvRegistros.SelectedRows.Count > 1)
                {
                    btnEliminar.Enabled = false;
                    btnModificar.Enabled = false;

                    btnRechazar.Enabled = _supervisor;
                    btnAprobar.Enabled = _supervisor;
                }
                else
                {
                    RegistroHorasExtra registro = (RegistroHorasExtra)dgvRegistros.SelectedRows[0].DataBoundItem;

                    btnEliminar.Enabled = true;
                    btnModificar.Enabled = true;

                    switch (registro.Estado)
                    {
                        case Estados.Aprobado:
                            btnRechazar.Enabled = _supervisor;
                            btnAprobar.Enabled = false;
                            break;
                        case Estados.Rechazado:
                            btnRechazar.Enabled = false;
                            btnAprobar.Enabled = _supervisor;
                            break;
                        default:
                            btnRechazar.Enabled = _supervisor;
                            btnAprobar.Enabled = _supervisor;
                            break;
                    }

                }

            }
            else
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = true;
                btnAprobar.Enabled = false;
                btnRechazar.Enabled = false;
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
        /// Se agregan filas a la lista de registros de horas extra.
        /// </summary>
        private void dgvRegistros_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvRegistros.Rows[e.RowIndex + contador];

                this.actualizarEstados(fila);
            }

        }

        /// <summary>
        /// Se marca o desmarca la opción de mostrar los montos.
        /// </summary>
        private void chkMontos_CheckedChanged(object sender, EventArgs e)
        {
            Alimentacion.Visible = chkMontos.Checked;
            Transporte.Visible = chkMontos.Checked;
        }

        /// <summary>
        /// Se marca o desmarca la opción de mostrar los comentarios.
        /// </summary>
        private void chkComentarios_CheckedChanged(object sender, EventArgs e)
        {
            ComentarioGastos.Visible = chkComentarios.Checked;
            ComentarioMotivos.Visible = chkComentarios.Checked;
        }

        /// <summary>
        /// Se marca o desmarca la opción de mostrar las horas.
        /// </summary>
        private void chkHoras_CheckedChanged(object sender, EventArgs e)
        {
            HorasExtra.Visible = chkHoras.Checked;
            HorasExtraDobles.Visible = chkHoras.Checked;
            HorasDobles.Visible = chkHoras.Checked;
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Actualizar los estados de los registros.
        /// </summary>
        public void actualizarEstados(DataGridViewRow fila)
        {
            RegistroHorasExtra registro = (RegistroHorasExtra)fila.DataBoundItem;

            fila.Cells[Diferencia.Index].Value = (registro.Hora_salida - registro.Hora_ingreso).Hours;
            fila.Cells[Aprobado.Index].Value = registro.Estado == Estados.Aprobado;
            fila.Cells[Rechazado.Index].Value = registro.Estado == Estados.Rechazado;

            this.mostrarErrorHoras(fila.Cells[HorasExtra.Index], fila.Cells[Colaborador.Index]);
            this.mostrarErrorHoras(fila.Cells[HorasDobles.Index], fila.Cells[Colaborador.Index]);
            this.mostrarErrorHoras(fila.Cells[HorasExtraDobles.Index], fila.Cells[Colaborador.Index]);
            this.mostrarErrorDiferencia(fila.Cells[Diferencia.Index], fila.Cells[Colaborador.Index]);
        }

        /// <summary>
        /// Marcar las celdas con valores anormales.
        /// </summary>
        private void mostrarErrorHoras(DataGridViewCell celda, DataGridViewCell celda_normal)
        {
            decimal valor = (decimal)celda.Value;

            if (valor >= 12)
            {
                celda.Style.BackColor = Color.Red;
                celda.Style.SelectionBackColor = Color.Red;
            }
            else if (valor >= 8)
            {
                celda.Style.BackColor = Color.Yellow;
                celda.Style.SelectionBackColor = Color.Yellow;
            }
            else
            {
                celda.Style.BackColor = celda_normal.Style.BackColor;
                celda.Style.SelectionBackColor = celda_normal.Style.SelectionBackColor;
            }

        }

        /// <summary>
        /// Marcar las celdas de diferencias con valores anormales.
        /// </summary>
        private void mostrarErrorDiferencia(DataGridViewCell celda, DataGridViewCell celda_normal)
        {
            int valor = (int)celda.Value;

            if (valor < 0 || valor > 16)
            {
                celda.Style.BackColor = Color.Red;
                celda.Style.SelectionBackColor = Color.Red;
            }
            else
            {
                celda.Style.BackColor = celda_normal.Style.BackColor;
                celda.Style.SelectionBackColor = celda_normal.Style.SelectionBackColor;
            }

        }

        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        private void mostarVentanaModificacion()
        {

            try
            {
                RegistroHorasExtra registro = (RegistroHorasExtra)dgvRegistros.SelectedRows[0].DataBoundItem;
                frmMantenimientoHorasExtra formulario = new frmMantenimientoHorasExtra(registro, _coordinador);

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

                if (cboColaborador.SelectedItem is Colaborador)
                {
                    Colaborador colaborador = (Colaborador)cboColaborador.SelectedItem;

                    dgvRegistros.DataSource = _supervision.listarRegistrosHorasExtraColaborador(colaborador, inicio, finalizacion);
                }
                else
                {
                    dgvRegistros.DataSource = _supervision.listarRegistrosHorasExtra(_coordinador.Area, inicio, finalizacion);
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
            DataGridViewRow fila = dgvRegistros.SelectedRows[0];

            this.actualizarEstados(fila);

            dgvRegistros.Refresh();
            dgvRegistros.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un registro a la lista.
        /// </summary>
        public void agregarRegistro(RegistroHorasExtra registro)
        {
            BindingList<RegistroHorasExtra> registros = (BindingList<RegistroHorasExtra>)dgvRegistros.DataSource;

            registros.Add(registro);
            dgvRegistros.AutoResizeColumns();
        }

        #endregion Métodos Públicos

        private void frmAdministracionHorasExtra_Load(object sender, EventArgs e)
        {

        }

      }

}
