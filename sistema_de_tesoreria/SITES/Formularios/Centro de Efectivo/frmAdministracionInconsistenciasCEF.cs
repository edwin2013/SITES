//
//  @ Project : 
//  @ File Name : frmAdministracionInconsistencias.cs
//  @ Date : 28/07/2011
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

    public partial class frmAdministracionInconsistenciasCEF : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private Colaborador _coordinador = null;

        #endregion Atributos

        #region Constructor

        public frmAdministracionInconsistenciasCEF(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            try
            {
                // Asignar los valores a las fechas

                DateTime ahora = DateTime.Now;
                DateTime inicio = new DateTime(ahora.Year, ahora.Month, ahora.Day, 0, 0, 0);
                DateTime fin = new DateTime(ahora.Year, ahora.Month, ahora.Day, 23, 59, 59);

                dtpInicio.Value = inicio;
                dtpFinalizacion.Value = fin;

                dgvInconsistenciasDepositos.AutoGenerateColumns = false;
                dgvInconsistenciasManifiestosCEF.AutoGenerateColumns = false;

                this.mostrarListas();
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
                this.mostrarListas();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de agregar inconsistencia en un deposito.
        /// </summary>
        private void btnNuevaInconsistenciaDeposito_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoInconsistenciasDepositos formulario = new frmMantenimientoInconsistenciasDepositos(_coordinador);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar una inconsistencia en un deposito.
        /// </summary>
        private void btnModificarInconsistenciaDeposito_Click(object sender, EventArgs e)
        {
            this.mostarVentanaModificacionClientesDepositos();
        }

        /// <summary>
        /// Clic en el botón de eliminar una inconsistencia en un deposito.
        /// </summary>
        private void btnEliminarInconsistenciaDeposito_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeInconsistenciaEliminacion") == DialogResult.Yes)
                {
                    InconsistenciaDeposito inconsistencia =
                        (InconsistenciaDeposito)dgvInconsistenciasDepositos.SelectedRows[0].DataBoundItem;

                    _coordinacion.eliminarInconsistenciaDeposito(inconsistencia);

                    dgvInconsistenciasDepositos.Rows.Remove(dgvInconsistenciasDepositos.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeInconsistenciaConfirmacionEliminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de agregar inconsistencia en un manifiesto.
        /// </summary>
        private void btnNuevaInconsistenciaManifiesto_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoInconsistenciasManifiestosCEF formulario = new frmMantenimientoInconsistenciasManifiestosCEF(_coordinador);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar una inconsistencia en un manifiesto.
        /// </summary>
        private void btnModificarInconsistenciaManifiesto_Click(object sender, EventArgs e)
        {
            this.mostarVentanaModificacionClientesManifiestos();
        }

        /// <summary>
        /// Clic en el botón de eliminar una inconsistencia en un manifiesto.
        /// </summary>
        private void btnEliminarInconsistenciaManifiesto_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeInconsistenciaEliminacion") == DialogResult.Yes)
                {
                    InconsistenciaManifiestoCEF inconsistencia =
                        (InconsistenciaManifiestoCEF)dgvInconsistenciasManifiestosCEF.SelectedRows[0].DataBoundItem;

                    _coordinacion.eliminarInconsistenciaManifiestoCEF(inconsistencia);

                    dgvInconsistenciasManifiestosCEF.Rows.Remove(dgvInconsistenciasManifiestosCEF.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeInconsistenciaConfirmacionEliminacion");
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
        /// Formato de la lista de inconsistencias en los depositos por causa del cliente.
        /// </summary>
        private void dgvInconsistenciasDepositos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex == DepositoDeposito.Index)
            {
                InconsistenciaDeposito inconsistencia =
                    (InconsistenciaDeposito)dgvInconsistenciasDepositos.Rows[e.RowIndex].DataBoundItem;
                Deposito deposito = inconsistencia.Deposito;

                dgvInconsistenciasDepositos[MontoDeposito.Index, e.RowIndex].Value = deposito.Monto;
            }
            else if (e.ColumnIndex == ManifiestoDeposito.Index)
            {
                InconsistenciaDeposito inconsistencia =
                    (InconsistenciaDeposito)dgvInconsistenciasDepositos.Rows[e.RowIndex].DataBoundItem;

                PlanillaCEF planilla = null;

                if (inconsistencia.Segregado != null)
                    planilla = inconsistencia.Segregado;
                else
                    planilla = inconsistencia.Manifiesto;

                dgvInconsistenciasDepositos[CajeroDeposito.Index, e.RowIndex].Value = planilla.Cajero;
                dgvInconsistenciasDepositos[DigitadorDeposito.Index, e.RowIndex].Value = planilla.Digitador;
                dgvInconsistenciasDepositos[CoordinadorDeposito.Index, e.RowIndex].Value = planilla.Coordinador;
            }
            else if (e.ColumnIndex == MontoDeposito.Index)
            {
                InconsistenciaDeposito inconsistencia =
                    (InconsistenciaDeposito)dgvInconsistenciasDepositos.Rows[e.RowIndex].DataBoundItem;

                decimal diferencia_colones = inconsistencia.Diferencia_colones;
                decimal diferencia_dolares = inconsistencia.Diferencia_dolares;

                foreach (Sobre sobre in inconsistencia.Sobres)
                {

                    switch (sobre.Moneda)
                    {
                        case Monedas.Colones:
                            diferencia_colones += sobre.Monto_real - sobre.Monto_reportado;
                            break;
                        case Monedas.Dolares:
                            diferencia_dolares += sobre.Monto_real - sobre.Monto_reportado;
                            break;
                    }

                }

                dgvInconsistenciasDepositos[DiferenciaColones.Index, e.RowIndex].Value = diferencia_colones;
                dgvInconsistenciasDepositos[DiferenciaDolares.Index, e.RowIndex].Value = diferencia_dolares;
            }

        }

        /// <summary>
        /// Doble clic en la lista de inconsistencias en depositos por causa de los clientes.
        /// </summary>
        private void dgvInconsistenciasDepositos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacionClientesDepositos();
        }

        /// <summary>
        /// Se selecciona otra inconsistencia en un deposito por causa de un cliente.
        /// </summary>
        private void dgvInconsistenciasDepositos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvInconsistenciasDepositos.SelectedRows.Count == 0)
            {
                btnEliminarInconsistenciaDeposito.Enabled = false;
                btnModificarInconsistenciaDeposito.Enabled = false;
            }
            else
            {
                InconsistenciaDeposito inconsistencia =
                    (InconsistenciaDeposito)dgvInconsistenciasDepositos.SelectedRows[0].DataBoundItem;

                PlanillaCEF planilla = null;

                if (inconsistencia.Segregado != null)
                    planilla = inconsistencia.Segregado;
                else
                    planilla = inconsistencia.Manifiesto;

                bool estado= true;

                if (planilla.Coordinador != null) estado = planilla.Coordinador.Equals(_coordinador);

                btnEliminarInconsistenciaDeposito.Enabled = true;
                btnModificarInconsistenciaDeposito.Enabled = true;
            
            }

        }

        /// <summary>
        /// Formato de la lista de inconsistencias en los manifiestos del CEF.
        /// </summary>
        private void dgvInconsistenciasManifiestosCEF_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex == ManifiestoManifiesto.Index)
            {
                InconsistenciaManifiestoCEF inconsistencia =
                    (InconsistenciaManifiestoCEF)dgvInconsistenciasManifiestosCEF.Rows[e.RowIndex].DataBoundItem;
                ManifiestoCEF manifiesto = inconsistencia.Manifiesto;

                if (manifiesto.Fecha_procesamiento != null)
                {
                    dgvInconsistenciasManifiestosCEF[CajeroManifiesto.Index, e.RowIndex].Value = manifiesto.Cajero;
                    dgvInconsistenciasManifiestosCEF[CoordinadorManifiesto.Index, e.RowIndex].Value = manifiesto.Coordinador;
                }

                dgvInconsistenciasManifiestosCEF[MontoColonesManifiesto.Index, e.RowIndex].Value = manifiesto.Monto_colones;
                dgvInconsistenciasManifiestosCEF[MontoDolaresManifiesto.Index, e.RowIndex].Value = manifiesto.Monto_dolares;
                dgvInconsistenciasManifiestosCEF[Depositos.Index, e.RowIndex].Value = manifiesto.Depositos;
            }
            else if (e.ColumnIndex == MontoTotal.Index)
            {
                InconsistenciaManifiestoCEF inconsistencia =
                    (InconsistenciaManifiestoCEF)dgvInconsistenciasManifiestosCEF.Rows[e.RowIndex].DataBoundItem;

                dgvInconsistenciasManifiestosCEF[DiferenciaInconsistenciaManifiesto.Index, e.RowIndex].Value =
                    Math.Abs(inconsistencia.Monto_total_real - inconsistencia.Monto_total_reportado);
                dgvInconsistenciasManifiestosCEF[TipoInconsistenciaManifiesto.Index, e.RowIndex].Value =
                    inconsistencia.Monto_total_real > inconsistencia.Monto_total_reportado ?
                    "Sobrante" : "Faltante";
            }

        }

        /// <summary>
        /// Doble clic en la lista de inconsistencias en manifiestos del CEF.
        /// </summary>
        private void dgvInconsistenciasManifiestosCEF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacionClientesManifiestos();
        }

        /// <summary>
        /// Se selecciona otra inconsistencia en un manifiesto del CEF.
        /// </summary>
        private void dgvInconsistenciasManifiestosCEF_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvInconsistenciasManifiestosCEF.SelectedRows.Count == 0)
            {
                btnEliminarInconsistenciaManifiesto.Enabled = false;
                btnModificarInconsistenciaManifiesto.Enabled = false;
            }
            else
            {
                InconsistenciaManifiestoCEF inconsistencia =
                    (InconsistenciaManifiestoCEF)dgvInconsistenciasManifiestosCEF.SelectedRows[0].DataBoundItem;
                ManifiestoCEF manifiesto = inconsistencia.Manifiesto;

                bool estado = true;

                if (manifiesto.Coordinador != null) estado = manifiesto.Coordinador.Equals(_coordinador);
                   
                btnEliminarInconsistenciaManifiesto.Enabled = true;
                btnModificarInconsistenciaManifiesto.Enabled = true;
            }

        }

        /// <summary>
        /// Se selecciona otro pestaña.
        /// </summary>
        private void tcListas_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (tcListas.SelectedIndex)
            {

                case 0:
                    pnlInconsistenciasClientesManifiestos.BringToFront();
                    break;
                case 1:
                    pnlInconsistenciasClientesDepositos.BringToFront();
                    break;
            }

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Mostrar las listas de inconsistencias.
        /// </summary>
        private void mostrarListas()
        {
            try
            {
                DateTime fecha_inicio = dtpInicio.Value;
                DateTime fecha_final = dtpFinalizacion.Value;

                BindingList<InconsistenciaDeposito> inconsistencias_depositos =
                    _coordinacion.listarInconsistenciasDepositos(fecha_inicio, fecha_final);
                BindingList<InconsistenciaManifiestoCEF> inconsistencias_manifiestos =
                    _coordinacion.listarInconsistenciasManifiestosCEF(fecha_inicio, fecha_final); ;

                dgvInconsistenciasDepositos.DataSource = inconsistencias_depositos;
                dgvInconsistenciasManifiestosCEF.DataSource = inconsistencias_manifiestos;

                dgvInconsistenciasDepositos.AutoResizeColumns();
                dgvInconsistenciasManifiestosCEF.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Mostrar la ventana de modificación de inconsistencias en depositos por causa de los clientes.
        /// </summary>
        public void mostarVentanaModificacionClientesDepositos()
        {

            try
            {
                InconsistenciaDeposito inconsistencia =
                    (InconsistenciaDeposito)dgvInconsistenciasDepositos.SelectedRows[0].DataBoundItem;
                frmMantenimientoInconsistenciasDepositos formulario = new frmMantenimientoInconsistenciasDepositos(inconsistencia, _coordinador);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Mostrar la ventana de modificación de inconsistencias en manifiestos por causa de los clientes.
        /// </summary>
        public void mostarVentanaModificacionClientesManifiestos()
        {

            try
            {
                InconsistenciaManifiestoCEF inconsistencia =
                    (InconsistenciaManifiestoCEF)dgvInconsistenciasManifiestosCEF.SelectedRows[0].DataBoundItem;
                frmMantenimientoInconsistenciasManifiestosCEF formulario = new frmMantenimientoInconsistenciasManifiestosCEF(inconsistencia, _coordinador);

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
        /// Actualizar los valores de la lista de inconsistencias en depositos.
        /// </summary>
        public void actualizarListaClientesDepositos()
        {
            dgvInconsistenciasDepositos.Refresh();
            dgvInconsistenciasDepositos.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar una inconsistencia a la lista de inconsistencias en depositos.
        /// </summary>
        public void agregarInconsistenciaClienteDeposito(InconsistenciaDeposito inconsistencia)
        {
            BindingList<InconsistenciaDeposito> inconsistencias =
                (BindingList<InconsistenciaDeposito>)dgvInconsistenciasDepositos.DataSource;

            inconsistencias.Add(inconsistencia);
            dgvInconsistenciasDepositos.AutoResizeColumns();
        }

        /// <summary>
        /// Actualizar los valores de la lista de inconsistencias en manifiestos del CEF.
        /// </summary>
        public void actualizarListaClientesManifiestos()
        {
            dgvInconsistenciasManifiestosCEF.Refresh();
            dgvInconsistenciasManifiestosCEF.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar una inconsistencia a la lista de inconsistencias en manifiestos del CEF.
        /// </summary>
        public void agregarInconsistenciaManifiestoCEF(InconsistenciaManifiestoCEF inconsistencia)
        {
            BindingList<InconsistenciaManifiestoCEF> inconsistencias =
                (BindingList<InconsistenciaManifiestoCEF>)dgvInconsistenciasManifiestosCEF.DataSource;

            inconsistencias.Add(inconsistencia);
            dgvInconsistenciasManifiestosCEF.AutoResizeColumns();
        }

        #endregion Métodos Públicos

        private void frmAdministracionInconsistenciasCEF_Load(object sender, EventArgs e)
        {

        }

     }

}