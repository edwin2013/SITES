using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;


namespace GUILayer.Formularios.Niquel
{
    public partial class frmAdministracionRecepcionBolsas : Form
    {


        #region Atributos

        private MantenimientoBL _supervision = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        
        private Bolsa _bolsa = null;

        private Colaborador _coordinador = null;

        private bool _supervisor = false;

        #endregion Atributos


        public frmAdministracionRecepcionBolsas()
        {
            InitializeComponent();
        }

       


        #region Constructor

        public frmAdministracionRecepcionBolsas(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            try
            {
                // Cargar la lista de registros y de colaboradores

                cboColaborador.ListaMostrada = _seguridad.listarColaboradoresPorArea(_coordinador.Area);

                if (cboColaborador.Items.Count > 0) cboColaborador.SelectedIndex = 0;

                dgvBolsas.AutoGenerateColumns = false;

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

        /// <summary>
        /// Clic en el botón de nuevo registro de bolsa.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoRecepcionBolsas formulario = new frmMantenimientoRecepcionBolsas(_bolsa);

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
        /// Mostrar la ventana de modificación.
        /// </summary>
        private void mostarVentanaModificacion()
        {

            try
            {
                Bolsa bolsa = (Bolsa)dgvBolsas.SelectedRows[0].DataBoundItem;
                frmMantenimientoRecepcionBolsas formulario = new frmMantenimientoRecepcionBolsas(bolsa, _coordinador);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

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
                    Bolsa registro = (Bolsa)dgvBolsas.SelectedRows[0].DataBoundItem;

                 //   _supervision.eliminarBolsa(registro);

                    dgvBolsas.Rows.Remove(dgvBolsas.SelectedRows[0]);
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
        /// Listar Datos.
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

                   // dgvBolsas.DataSource = _supervision.listarRegistrosHorasExtraColaborador(colaborador, inicio, finalizacion);
                }
                else
                {
                   // dgvBolsas.DataSource = _supervision.listarRegistrosHorasExtra(_coordinador.Area, inicio, finalizacion);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void frmAdministracionRecepcionBolsas_Load(object sender, EventArgs e)
        {

        }

    }
}
