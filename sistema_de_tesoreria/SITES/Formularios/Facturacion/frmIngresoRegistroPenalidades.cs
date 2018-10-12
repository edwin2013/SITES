using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Facturacion
{
    public partial class frmIngresoRegistroPenalidades : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private Colaborador _usuario = null;
        private RegistroPenalidad _registro_penalidad = null;

        #endregion Atributos

        #region Constructor

        public frmIngresoRegistroPenalidades(Colaborador colaborador)
        {
            InitializeComponent();
            _usuario = colaborador;
            cboEmpresaTransporte.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
            cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);
            cboTipoPenalidad.ListaMostrada = _mantenimiento.listarPenalidades();
        }

        public frmIngresoRegistroPenalidades(RegistroPenalidad reg, Colaborador c)
        {
            InitializeComponent();

            cboEmpresaTransporte.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
            cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);
            cboTipoPenalidad.ListaMostrada = _mantenimiento.listarPenalidades();
            dtpFecha.Value = reg.Fecha_Registro;
            cboCliente.Text = reg.Cliente.ToString();
            cboPuntoVenta.Text = reg.Punto_Venta.ToString();
            cboEmpresaTransporte.Text = reg.Transportadora.ToString();
            cboTipoPenalidad.Text = reg.Penalidad.ToString();

            chkProntoAviso.Checked = reg.Pronto_Aviso;

            _registro_penalidad = reg;
 
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (cboPuntoVenta.SelectedIndex == 0 || cboEmpresaTransporte.SelectedIndex == 0 || cboTipoPenalidad.SelectedIndex == 0)
            {
                Excepcion.mostrarMensaje("ErrorubicacionDatosRegistro");
                return;
            }

            try
            {

                frmAdministracionRegistroPenalidades padre = (frmAdministracionRegistroPenalidades)this.Owner;

                Penalidad penalidad = (Penalidad)cboTipoPenalidad.SelectedItem;
                EmpresaTransporte transportadora = (EmpresaTransporte)cboEmpresaTransporte.SelectedItem;
                PuntoVenta punto_venta = (PuntoVenta)cboPuntoVenta.SelectedItem;
                bool pronto_aviso = chkProntoAviso.Checked;
                DateTime fecha = dtpFecha.Value;

                

                // Verificar si la ubicación ya está registrada

                if (_registro_penalidad == null)
                {
                    // Agregar los datos de la ubicación

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeRegistroPenalidadRegistro") == DialogResult.Yes)
                    {
                        RegistroPenalidad nueva = new RegistroPenalidad(penalidad: penalidad, transportadora: transportadora, punto: punto_venta, colaborador : _usuario, pronto_aviso: pronto_aviso, fecha_registro : fecha);

                        _coordinacion.agregarRegistroPenalidad(ref nueva);

                        padre.agregarRegistroPenalidad(nueva);
                        Mensaje.mostrarMensaje("MensajeRegistroPenalidadConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la ubicación

                    RegistroPenalidad copia = new RegistroPenalidad(penalidad : penalidad, id: _registro_penalidad.Id, transportadora: transportadora,
                                                    punto: punto_venta, pronto_aviso : pronto_aviso);

                    _coordinacion.actualizarRegistroPenalidad(copia);

                    _registro_penalidad.Transportadora = transportadora;
                    _registro_penalidad.Penalidad = penalidad;
                    _registro_penalidad.Punto_Venta = punto_venta;
                    _registro_penalidad.Pronto_Aviso = pronto_aviso;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeRegistroPenalidadConfirmacionActualizacion");
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
        /// Muestra los puntos de venta de un cliene especifico
        /// </summary>
        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedIndex != 0)
            {
                Cliente nuevo = (Cliente)cboCliente.SelectedItem;

                cboPuntoVenta.ListaMostrada = nuevo.Puntos_venta;

            }
        }
        #endregion Eventos

        

        
    }
}
