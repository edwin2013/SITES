using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects.Clases;
using BussinessLayer;
using CommonObjects;
using LibreriaMensajes;
using LibreriaReportesOffice;

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmCoordinacionProveedor : Form
    {
        #region Atributos
        private RequerimientoMantenimiento _requerimiento = null;
        private MantenimientoBL _manejador = MantenimientoBL.Instancia;

        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private EstadoRequerimiento _estado = EstadoRequerimiento.Solicitado;
        private frmAdministracionCoordinacionProveedor _padre = new frmAdministracionCoordinacionProveedor();
        private Colaborador _usuario = new Colaborador();
        #endregion Atributos
        
        #region Constructor
        public frmCoordinacionProveedor()
        {
            InitializeComponent();
        }


        public frmCoordinacionProveedor(RequerimientoMantenimiento requerimiento)
        {
            InitializeComponent();

            cboEquipo.ListaMostrada = _manejador.listarEquiposTesoreria();
            cboColaborador.ListaMostrada = _seguridad.listarColaboradores(string.Empty);
            _requerimiento = requerimiento;

            CargarDatos();
        }

        #endregion Constructor

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

        private void ExportarRequerimiento()
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla Requerimiento.xlt", true);

                documento.seleccionarHoja(1);

                // Escribir los datos

                            
                    documento.seleccionarCelda(3, 3);
                    documento.actualizarValorCelda(cboColaborador.Text);

                    documento.seleccionarCelda(5, 3);
                    documento.actualizarValorCelda(dtpFechaSolicitud.Value.ToString());

                    documento.seleccionarCelda(7, 3);
                    documento.actualizarValorCelda(cboArea.Text);

                    documento.seleccionarCelda(9, 3);
                    documento.actualizarValorCelda(txtProveedor.Text);

                    documento.seleccionarCelda(12, 6);
                    documento.actualizarValorCelda(cboEquipo.Text);
                    documento.seleccionarCelda(12, 8);
                    documento.actualizarValorCelda(txtSerie.Text);
                    documento.seleccionarCelda(12, 9);
                    documento.actualizarValorCelda(txtActivo.Text);


                    if (rbtnPreventivo.Checked == true)
                    {
                        documento.seleccionarCelda(12, 2);
                        documento.actualizarValorCelda("X   Preventivo");
                    }
                    if (rbtnCorrectivo.Checked == true)
                    {
                        documento.seleccionarCelda(12, 4);
                        documento.actualizarValorCelda("X   Correctivo");
                    }


                    documento.seleccionarCelda(15, 1);
                    documento.actualizarValorCelda(txtDescRequerimiento.Text);

                    documento.seleccionarCelda(25, 3);
                    documento.actualizarValorCelda(txtSAP.Text);

                    documento.seleccionarCelda(25, 7);
                    documento.actualizarValorCelda(dtpFechaProveedor.Value.ToString());

                    documento.seleccionarCelda(25, 10);
                    documento.actualizarValorCelda(dtpFechaEjecucion.Value.ToString());
                    
                    documento.seleccionarCelda(28, 1);
                    documento.actualizarValorCelda(txtDescServicio.Text);


                    if (_requerimiento.Evaluacion == Evaluacion.Bueno)
                    {
                        documento.seleccionarCelda(21, 8);
                        documento.formatoCelda(false, false, false, null, Color.White, Color.Green);
                    }

                    if (_requerimiento.Evaluacion == Evaluacion.Malo)
                    {
                        documento.seleccionarCelda(21, 4);
                        documento.formatoCelda(false, false, false, null, Color.White, Color.Red);
                    }

                    if (_requerimiento.Evaluacion == Evaluacion.Regular)
                    {
                        documento.seleccionarCelda(21, 6);
                        documento.formatoCelda(false, false, false, null, Color.Black, Color.Yellow);
                    }

                    if (_requerimiento.Evaluacion == Evaluacion.Excelente)
                    {
                        documento.seleccionarCelda(21, 10);
                        documento.formatoCelda(false, false, false, null, Color.White, Color.Blue);
                    }

                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        #endregion Metodos Privados

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
                //para cuando se contacta con el proveedor
                DateTime fechaproveedor = dtpFechaProveedor.Value;
                DateTime fechaservicio = dtpFechaEjecucion.Value;
                string descripcionservicio = txtDescServicio.Text;
                string sap = txtSAP.Text;

                _requerimiento.Estado = EstadoRequerimiento.Procesado;
                _requerimiento.DescripcionServicio = descripcionservicio;
                _requerimiento.SAP = sap;
                _requerimiento.FechaProveedor = fechaproveedor;
                _requerimiento.FechaServicio = fechaservicio;

                RequerimientoMantenimiento copia = _requerimiento;

                _manejador.actualizarRequerimientoMantenimiento(copia);
  
                _padre.actualizarLista();
                Mensaje.mostrarMensaje("MensajeRequerimientoMantenimientoConfirmacionActualizacion");
                this.Close();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarRequerimiento();
        }
        #endregion Eventos


             
    }
}
