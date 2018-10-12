using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using CommonObjects;
using LibreriaMensajes;

namespace GUILayer.Formularios.Cajeros_Automaticos
{
    public partial class frmListaCargasATMCajerosAutomaticos : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _colaborador = null;
        private int _indice = 0;
        private bool _coordinador = false;
        private bool _analista = false;

        #endregion Atributos

        #region Constructor

        public frmListaCargasATMCajerosAutomaticos(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;
            _coordinador = _colaborador.Puestos.Contains(Puestos.Coordinador) || _colaborador.Puestos.Contains(Puestos.Supervisor);
            _analista = _colaborador.Puestos.Contains(Puestos.Analista);


            try
            {
                dgvCargas.AutoGenerateColumns = false;

                cboATM.ListaMostrada = _mantenimiento.listarATMs();

                actualizarDatos();
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
                actualizarDatos();

                
              
                
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
            this.mostrarVentanaModificacion();
        }

       

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            tmrActualizarCargas.Stop();
            this.Close();
        }

        /// <summary>
        /// Doble clic en la lista de cargas.
        /// </summary>
        private void dgvCargas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                DataGridViewRow fila = dgvCargas.SelectedRows[0];
                CargaATM carga = (CargaATM)fila.DataBoundItem;


                _indice = fila.Index;
               


                    if (carga.Cierre == null)
                        this.mostrarVentanaModificacion();
                   

            }

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

                _coordinacion.actualizarCodigosCajerosCargaATM(carga);

                fila.Cells[ATMCarga.Index].Value = carga.ToString();


                if (carga.CodigoApertura.Equals("") && carga.CodigoCierre.Equals("") && carga.ConfirmacionCodigos == false && carga.SolicitudCodigos == false)
                {
                    fila.DefaultCellStyle.BackColor = Color.Silver;
                }

                if (carga.CodigoApertura.Equals("") && carga.CodigoCierre.Equals("") && carga.ConfirmacionCodigos == false && carga.SolicitudCodigos == true)
                {
                    fila.DefaultCellStyle.BackColor = Color.Red;
                }

                if (!carga.CodigoApertura.Equals("") && carga.CodigoCierre.Equals("") && carga.ConfirmacionCodigos == false && carga.SolicitudCodigos == true)
                {
                    fila.DefaultCellStyle.BackColor = Color.Gold;
                }

                if (!carga.CodigoApertura.Equals("") && !carga.CodigoCierre.Equals("") && carga.ConfirmacionCodigos == false && carga.SolicitudCodigos == true)
                {
                    fila.DefaultCellStyle.BackColor = Color.Lime;
                }

            }

        }

        /// <summary>
        /// Se selecciona otra carga de la lista de cargas.
        /// </summary>
        private void dgvCargas_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCargas.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvCargas.SelectedRows[0];
                CargaATM carga = (CargaATM)fila.DataBoundItem;

                _indice = fila.Index;

                btnModificar.Enabled = true;
                btnFinalizar.Enabled = true;

                if (carga.Cierre == null)
                {

                    btnModificar.Enabled = true;

                }
                else
                {

                    btnModificar.Enabled = true;

                }

            }
            else
            {

                btnModificar.Enabled = false;

            }

        }

        /// <summary>
        /// Se marca o desmarca la opción de filtrar por ruta.
        /// </summary>
        private void chkRuta_CheckedChanged(object sender, EventArgs e)
        {
            nudRuta.Enabled = chkRuta.Checked;
        }





        /// <summary>
        /// Finaliza la carga
        /// </summary>
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow fila = dgvCargas.SelectedRows[0];
                CargaATM carga = (CargaATM)fila.DataBoundItem;

           

                _coordinacion.actualizarFinalizarCodigoCargaATM(carga);

                Mensaje.mostrarMensaje("MensajeCodigoATMActualizacion");
               // dgvCargas.Rows.Remove(fila);
            }
            catch (Excepcion ex)
            {
                Excepcion.mostrarMensaje("ErrorDatosConexion");
            }
        }
        #endregion Eventos
     
        #region Métodos Privados

       
       

        /// <summary>
        /// Mostrar la ventana de modificación de la carga.
        /// </summary>
        private void mostrarVentanaModificacion()
        {
            CargaATM carga = (CargaATM)dgvCargas.SelectedRows[0].DataBoundItem;
            frmSolicitudCodigoCargasATM formulario = new frmSolicitudCodigoCargasATM(carga, _colaborador);


            DataGridViewRow fila = dgvCargas.SelectedRows[0];
            _indice = fila.Index;

            formulario.ShowDialog(this);

            carga.recalcularMontosCarga();

            dgvCargas.Refresh();
        }

        /// <summary>
        /// Actualiza los datos de las cargas
        /// </summary>
        private void actualizarDatos()
        {
            DateTime fecha = dtpFecha.Value;
            Colaborador cajero = null;
            CommonObjects.ATM atm = null;
            byte? ruta = chkRuta.Checked ?
                (byte?)nudRuta.Value : null;
            dgvCargas.Refresh();

            dgvCargas.Rows.Clear();

            //dgvCargas.Columns.Clear();

            tmrActualizarCargas.Start();

            dgvCargas.DataSource = _coordinacion.listarCargasATMsCodigosCajeroAutomaticos(cajero, atm, fecha, ruta);

            dgvCargas.Refresh();

        }
        #endregion Métodos Privados

        
    }
}
