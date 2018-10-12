using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using CommonObjects.Clases;
using LibreriaMensajes;
using CommonObjects;

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmSolicitudRequerimientos : Form
    {
        #region Atributos

            private RequerimientoMantenimiento _requerimiento = null;
            private MantenimientoBL _manejador = MantenimientoBL.Instancia;
            private Colaborador _usuario = new Colaborador();

            private SeguridadBL _seguridad = SeguridadBL.Instancia;
            private EstadoRequerimiento _estado = EstadoRequerimiento.Solicitado;
            private frmAdministracionSolicitudRequerimientos _padre = new frmAdministracionSolicitudRequerimientos(null);

            private BindingList<EquipoTesoreria> _equipos = new BindingList<EquipoTesoreria>();
            
       #endregion Atributos

        #region Constructor

        public frmSolicitudRequerimientos(RequerimientoMantenimiento requerimiento)
        {
            InitializeComponent();

            _requerimiento = requerimiento;
            cboColaborador.ListaMostrada = _seguridad.listarColaboradores(string.Empty);
            _equipos = _manejador.listarEquiposTesoreria();
            cboEquipo.ListaMostrada = _equipos;

            CargarDatos();
        }

        public frmSolicitudRequerimientos(Colaborador usuario)
        {
            InitializeComponent();

            _usuario = usuario;

            cboColaborador.ListaMostrada = _seguridad.listarColaboradores(string.Empty);
            cboColaborador.SelectedItem = _usuario;
            //cboEquipo.ListaMostrada = _manejador.listarEquiposTesoreria();
            _equipos = _manejador.listarEquiposTesoreria();
            cboEquipo.ListaMostrada = _equipos;
        }

        #endregion Constructor

        #region Eventos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (cboColaborador.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorRequerimientoMantenimientoDatosRegistro");
                return;
            }

            try
            {
                EquipoTesoreria equipo = (EquipoTesoreria)cboEquipo.SelectedItem;
                Colaborador solicitante = (Colaborador)cboColaborador.SelectedItem;
                DateTime fechasolicitud = dtpFechaSolicitud.Value;
                Areas area = (Areas)cboArea.SelectedIndex;
                TipoMantenimiento mantenimiento = TipoMantenimiento.Preventivo;
                if (rbtnCorrectivo.Checked == true)
                    mantenimiento = TipoMantenimiento.Correctivo;
                string descripcionsolicitud = txtDescRequerimiento.Text;
                
                
                //para cuando ya se realizó el mantenimiento
                Evaluacion evaluacion = Evaluacion.Pendiente;
                if (rbtnBueno.Checked == true)
                    evaluacion = Evaluacion.Bueno;
                else if (rbtnMalo.Checked == true)
                    evaluacion = Evaluacion.Malo;
                else if (rbtnRegular.Checked == true)
                    evaluacion = Evaluacion.Regular;
                else if (rbtnExcelente.Checked == true)
                    evaluacion = Evaluacion.Excelente;

                //para cuando se contacta con el proveedor
                DateTime fechaproveedor = dtpFechaProveedor.Value;
                DateTime fechaservicio = dtpFechaEjecucion.Value;
                string descripcionservicio = txtDescServicio.Text;
                string sap = txtSAP.Text;

                if (evaluacion != Evaluacion.Pendiente)
                    _estado = EstadoRequerimiento.Evaluado;

                if (_requerimiento == null)
                {
                    if (Mensaje.mostrarMensajeConfirmacion("MensajeRequerimientoMantenimientoRegistro") == DialogResult.Yes)
                    {
                        RequerimientoMantenimiento nueva = new RequerimientoMantenimiento(equipo:equipo, solicitante:solicitante, fechasolicitud:fechasolicitud,
                            area:area, mantenimiento:mantenimiento, descripcionsolicitud:descripcionsolicitud, evaluacion:evaluacion,
                            fechaproveedor:fechaproveedor,fechaservicio:fechaservicio, descripcionservicio:descripcionservicio,sap:sap,estado:(EstadoRequerimiento)_estado);

                        _manejador.agregarRequerimientoMantenimiento(ref nueva);
                        _padre.agregarRequerimientoMantenimiento(nueva);

                        Mensaje.mostrarMensaje("MensajeRequerimientoMantenimientoConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    RequerimientoMantenimiento copia = new RequerimientoMantenimiento(id:_requerimiento.ID,equipo: equipo, solicitante: solicitante, fechasolicitud: fechasolicitud,
                            area: area, mantenimiento: mantenimiento, descripcionsolicitud: descripcionsolicitud, evaluacion: evaluacion,
                            fechaproveedor: fechaproveedor, fechaservicio: fechaservicio, descripcionservicio: descripcionservicio, sap: sap, estado: (EstadoRequerimiento)_estado);

                    _manejador.actualizarRequerimientoMantenimiento(copia);

                    _requerimiento.Equipo = equipo;
                    _requerimiento.Solicitante = solicitante;
                    _requerimiento.Area = area;
                    _requerimiento.Estado = _estado;
                    _requerimiento.FechaSolicitud = fechasolicitud;
                    _requerimiento.Mantenimiento = mantenimiento;
                    _requerimiento.DescripcionSolicitud = descripcionsolicitud;
                    _requerimiento.DescripcionServicio = descripcionservicio;
                    _requerimiento.SAP = sap;
                    _requerimiento.Evaluacion = evaluacion;
                    _requerimiento.FechaProveedor = fechaproveedor;
                    _requerimiento.FechaServicio = fechaservicio;

                    _padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeRequerimientoMantenimientoConfirmacionActualizacion");
                    this.Close();
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        private void cboEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            EquipoTesoreria equipo = (EquipoTesoreria)cboEquipo.SelectedItem;
            txtActivo.Text = equipo.NumActivo;
            txtProveedor.Text = equipo.Proveedor.ToString();
            txtSerie.Text = equipo.Serie;
        }

        private void cboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingList<EquipoTesoreria> lista = new BindingList<EquipoTesoreria>();
            if (cboArea.Text == "")
                cboEquipo.Items.Clear();
            else
            {
                foreach (EquipoTesoreria a in _equipos)
                {
                    if ((Areas)a.Area == (Areas)cboArea.SelectedIndex)
                        lista.Add(a);
                }
                cboEquipo.ListaMostrada = lista;
            }
        }

        #endregion Eventos

        #region Metodos Privados

        private void CargarDatos()
        {

            txtDescRequerimiento.Text = _requerimiento.DescripcionSolicitud;
            txtDescServicio.Text = _requerimiento.DescripcionServicio;
            cboEquipo.SelectedItem = _requerimiento.Equipo;
            cboColaborador.SelectedItem = _requerimiento.Solicitante;
            cboArea.SelectedIndex = (int)_requerimiento.Area;
            txtProveedor.Text = _requerimiento.Equipo.Proveedor.ToString();
            txtSerie.Text = _requerimiento.Equipo.Serie.ToString();
            txtActivo.Text = _requerimiento.Equipo.NumActivo.ToString();
            txtSAP.Text = _requerimiento.SAP;
            dtpFechaSolicitud.Value = _requerimiento.FechaSolicitud;
            dtpFechaProveedor.Value = _requerimiento.FechaProveedor;
            dtpFechaEjecucion.Value = _requerimiento.FechaServicio;
            if (_requerimiento.Mantenimiento == TipoMantenimiento.Correctivo)
                rbtnCorrectivo.Checked = true;
            else
                rbtnPreventivo.Checked = true;


            if (_requerimiento.SAP != "" & _requerimiento.FechaServicio != null)
                gboEvaluacion.Enabled = true;
            else
                gboEvaluacion.Enabled = false;


            switch (_requerimiento.Evaluacion)
            {
                case Evaluacion.Bueno:
                    rbtnBueno.Checked = true;
                    break;
                case Evaluacion.Malo:
                    rbtnMalo.Checked = true;
                    break;
                case Evaluacion.Regular:
                    rbtnRegular.Checked = true;
                    break;
                case Evaluacion.Excelente:
                    rbtnExcelente.Checked = true;
                    break;
                default:
                    break;
            }

        }

        #endregion Metodos Privados

        
    }
}
