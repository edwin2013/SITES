//
//  @ Project : 
//  @ File Name : frmIngresoManualManifiesto.cs
//  @ Date : 28/11/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmIngresoManualManifiesto : Form
    {

        #region Atributos

        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;

        private Colaborador _coordinador = null;

        #endregion Atributos

        #region Constructor

        public frmIngresoManualManifiesto(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            try
            {
                cboEmpresa.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
                cboReceptor.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Receptor);
                cboGrupo.ListaMostrada = _mantenimiento.listarGrupos();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (cboEmpresa.SelectedItem == null || cboReceptor.SelectedItem == null ||
                cboGrupo.SelectedItem == null || txtCodigo.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorManifiestoDatosRegistro");
                return;
            }

            try
            {
                string codigo = txtCodigo.Text;
                EmpresaTransporte transportadora = (EmpresaTransporte)cboEmpresa.SelectedItem;
                Colaborador receptor = (Colaborador)cboReceptor.SelectedItem;
                Grupo grupo = (Grupo)cboGrupo.SelectedItem;
                DateTime fecha= dtpFecha.Value;
                byte caja = (byte)nudCaja.Value;

                if (Mensaje.mostrarMensajeConfirmacion("MensajeManifiestoRegistro") == DialogResult.Yes)
                {
                    Manifiesto manifiesto = new Manifiesto(codigo, grupo: grupo, caja: caja, empresa: transportadora,
                                                           receptor: receptor, fecha_recepcion: fecha, area: grupo.Area);

                    _atencion.agregarManifiesto(ref manifiesto, _coordinador);

                    Mensaje.mostrarMensaje("MensajeManifiestoConfirmacionRegistro");
                    this.Close();
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

        #endregion Eventos

    }

}

