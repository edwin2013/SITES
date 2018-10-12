//
//  @ Project : 
//  @ File Name : frmTerminacionGestiones.cs
//  @ Date : 19/08/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmTerminacionGestiones : Form
    {

        #region Atributos

        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;

        BindingList<CausaGestion> _causas = null;

        private Gestion _gestion = null;



        #endregion Atributos

        #region Constructor

        public frmTerminacionGestiones(Gestion gestion)
        {
            InitializeComponent();

            _gestion = gestion;

            try
            {
                // Cargar los datos

                this.cargarDatos();

                cboCausante.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public frmTerminacionGestiones(Gestion gestion, bool supervisor)
        {
            InitializeComponent();

            _gestion = gestion;

            try
            {
                // Cargar los datos

                this.cargarDatos();

                btnGuardar.Enabled = supervisor;
                cboCausa.Enabled = supervisor;
                cboCausante.Enabled = supervisor;
                txtComentarioCausa.Enabled = supervisor;

                cboCausante.SelectedIndex = (byte)_gestion.Causa.Causante;
                cboCausa.Text = _gestion.Causa.Descripcion;
                cboClasificacion.SelectedIndex = (byte)_gestion.Clasificacion;
                txtComentarioCausa.Text = _gestion.Comentario_causa;

                string colaborador = _gestion.Colaborador == null ?
                    string.Empty : _gestion.Colaborador.ToString();

                string transportadora = _gestion.Transportadora == null ?
                    string.Empty : _gestion.Transportadora.Nombre;

                switch (_gestion.Causa.Causante)
                {
                    case Causantes.Cajero:
                        lblCajero.Visible = true;
                        cboCajero.Text = colaborador;
                        cboCajero.Enabled = supervisor;
                        break;
                    case Causantes.Digitador:
                        lblDigitador.Visible = true;
                        cboDigitador.Text = colaborador;
                        cboDigitador.Enabled = supervisor;
                        break;
                    case Causantes.Coordinador:
                        lblCoordinador.Visible = true;
                        cboCoordinador.Text = colaborador;
                        cboCoordinador.Enabled = supervisor;
                        break;
                    case Causantes.Receptor:
                        lblReceptor.Visible = true;
                        cboReceptor.Text = colaborador;
                        cboReceptor.Enabled = supervisor;
                        break;
                    case Causantes.Transportadora:
                        lblEmpresa.Visible = true;
                        cboEmpresa.Text = transportadora;
                        cboEmpresa.Enabled = supervisor;
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Cargar los datos del formulario.
        /// </summary>
        private void cargarDatos()
        {
            txtCliente.Text = _gestion.Punto_venta.Cliente.Nombre;
            txtDetalleCliente.Text = _gestion.Punto_venta.Nombre;
            txtGestion.Text = _gestion.Tipo.Nombre;
            txtComentario.Text = _gestion.Comentario;
            txtMonto.Text = _gestion.Monto.ToString("N2");

            dgvDepositos.AutoGenerateColumns = false;
            dgvDepositos.DataSource = _gestion.Depositos;

            dgvTulas.AutoGenerateColumns = false;
            dgvTulas.DataSource = _gestion.Tulas;

            dgvManifiestos.AutoGenerateColumns = false;
            dgvManifiestos.DataSource = _gestion.Manifiestos;

            try
            {
                cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB);
                cboDigitador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Digitador);
                cboCoordinador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Coordinador);
                cboEmpresa.ListaMostrada = _mantenimiento.listarEmpresasTransporte();

                _causas = _mantenimiento.listarCausasGestion();
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
            // Verificar que se hayan seleccionado los datos

            Causantes causante = (Causantes)cboCausante.SelectedIndex;

            if ((causante == Causantes.Cajero && cboCajero.SelectedItem == null) ||
                (causante == Causantes.Digitador && cboDigitador.SelectedItem == null) ||
                (causante == Causantes.Coordinador && cboCoordinador.SelectedItem == null) ||
                (causante == Causantes.Receptor && cboReceptor.SelectedItem == null) ||
                (causante == Causantes.Transportadora && cboEmpresa.SelectedItem == null) ||
                cboCausa.SelectedItem == null ||
                cboClasificacion.SelectedItem == null)
            {
                Excepcion.mostrarMensaje("ErrorGestionDatosTerminacion");
                return;
            }

            try
            {
                CausaGestion causa = (CausaGestion)cboCausa.SelectedItem;
                Colaborador colaborador = null;
                EmpresaTransporte transportadora = null;
                ClasificacionesGestion clasificacion = (ClasificacionesGestion)cboClasificacion.SelectedIndex;
                string comentario_causa = txtComentarioCausa.Text;

                switch (causante)
                {
                    case Causantes.Cajero:
                        colaborador = (Colaborador)cboCajero.SelectedItem;
                        break;
                    case Causantes.Digitador:
                        colaborador = (Colaborador)cboDigitador.SelectedItem;
                        break;
                    case Causantes.Coordinador:
                        colaborador = (Colaborador)cboCoordinador.SelectedItem;
                        break;
                    case Causantes.Receptor:
                        colaborador = (Colaborador)cboReceptor.SelectedItem;
                        break;
                    case Causantes.Transportadora:
                        transportadora = (EmpresaTransporte)cboEmpresa.SelectedItem;
                        break;
                }

                if (Mensaje.mostrarMensajeConfirmacion("MensajeGestionTerminacion") == DialogResult.Yes)
                {
                    // Actualizar los datos de la gestión

                    _gestion.Causa = causa;
                    _gestion.Colaborador = colaborador;
                    _gestion.Transportadora = transportadora;
                    _gestion.Comentario_causa = comentario_causa;
                    _gestion.Clasificacion = clasificacion;

                    _coordinacion.actualizarGestionTerminar(_gestion);

                    if (this.Owner is frmAdministracionGestiones)
                        ((frmAdministracionGestiones)this.Owner).eliminarGestion(_gestion);
                    else if (this.Owner is frmRecordatorioGestiones)
                        ((frmRecordatorioGestiones)this.Owner).eliminarGestion(_gestion);
                    else if (this.Owner is frmGestionesTeminadas)
                        ((frmGestionesTeminadas)this.Owner).actualizarLista();

                    Mensaje.mostrarMensaje("MensajeGestionConfirmacionTerminacion");
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

        /// <summary>
        /// Seleccion de un causante.
        /// </summary>
        private void cboCausante_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCajero.Visible = false;
            cboCajero.Visible = false;

            lblDigitador.Visible = false;
            cboDigitador.Visible = false;

            lblCoordinador.Visible = false;
            cboCoordinador.Visible = false;

            lblReceptor.Visible = false;
            cboReceptor.Visible = false;

            lblEmpresa.Visible = false;
            cboEmpresa.Visible = false;

            lblDetalleCliente.Visible = false;
            txtDetalleCliente.Visible = false;

            Causantes causante = (Causantes)cboCausante.SelectedIndex;

            switch (causante)
            {
                case Causantes.Cajero:
                    lblCajero.Visible = true;
                    cboCajero.Visible = true;
                    break;
                case Causantes.Digitador:
                    lblDigitador.Visible = true;
                    cboDigitador.Visible = true;
                    break;
                case Causantes.Coordinador:
                    lblCoordinador.Visible = true;
                    cboCoordinador.Visible = true;
                    break;
                case Causantes.Receptor:
                    lblReceptor.Visible = true;
                    cboReceptor.Visible = true;
                    break;
                case Causantes.Transportadora:
                    lblEmpresa.Visible = true;
                    cboEmpresa.Visible = true;
                    break;
                case Causantes.Cliente: case Causantes.Otro:
                    lblDetalleCliente.Visible = true;
                    txtDetalleCliente.Visible = true;
                    break;

            }

            // Restringir las causas según el causante

            BindingList<CausaGestion> causas_causante = new BindingList<CausaGestion>();

            foreach (CausaGestion causa in _causas)
                if (causa.Causante == causante) causas_causante.Add(causa);

            cboCausa.ListaMostrada = causas_causante;

            if (cboCausa.Items.Count > 0) cboCausa.SelectedIndex = 0;
        }

        #endregion Eventos

    }

}
