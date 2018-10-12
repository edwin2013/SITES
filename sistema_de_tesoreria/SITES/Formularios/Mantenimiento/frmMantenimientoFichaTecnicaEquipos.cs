using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects.Clases;
using LibreriaMensajes;
using BussinessLayer;

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmMantenimientoFichaTecnicaEquipos : Form
    {
        #region Atributos

        private frmAdministracionFichaTecnicaEquipos _padre = null;
        private FichaTecnica _ficha = null;
        private MantenimientoBL _manejador = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoFichaTecnicaEquipos(frmAdministracionFichaTecnicaEquipos padre)
        {
            InitializeComponent();

            _padre = padre;

            cboEquipo.ListaMostrada = _manejador.listarEquiposTesoreria();
        }
        
        public frmMantenimientoFichaTecnicaEquipos(FichaTecnica ficha, frmAdministracionFichaTecnicaEquipos padre)
        {
            InitializeComponent();

            _ficha = ficha;
            _padre = padre;

            cboEquipo.ListaMostrada = _manejador.listarEquiposTesoreria();
            
            cboEstatus.SelectedIndex = (int)_ficha.Estatus;
            cboEquipo.SelectedItem = (EquipoTesoreria)_ficha.Equipo;
            txtBoleta.Text = _ficha.Boleta;
            txtObservacion.Text = _ficha.Observaciones;
            dtpFecha.Value = _ficha.Fecha;
            dtpPeriodicidad.Value = _ficha.Periodicidad;
            nudCosto.Value = _ficha.Costo;
            if (_ficha.Mantenimiento == TipoMantenimiento.Correctivo)
                rbtnCorrectivo.Checked =  true;
            else
                rbtnPreventivo.Checked = true;
        }

        #endregion Constructor

        #region Eventos

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (cboEquipo.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorFichaTecnicaDatosRegistro");
                return;
            }

            try
            {
                EquipoTesoreria equipo = (EquipoTesoreria)cboEquipo.SelectedItem;
                string Boleta = txtBoleta.Text;
                EstadoEquipo Estado = (EstadoEquipo)cboEstatus.SelectedIndex;
                DateTime fecha = dtpFecha.Value;
                DateTime periodicidad = dtpPeriodicidad.Value;
                decimal Costo = nudCosto.Value;
                string observaciones = txtObservacion.Text;

                TipoMantenimiento mantenimiento = TipoMantenimiento.Preventivo;
                if (rbtnCorrectivo.Checked == true)
                    mantenimiento = TipoMantenimiento.Correctivo;
                
                if (_ficha == null)
                {
                    if (Mensaje.mostrarMensajeConfirmacion("MensajeFichaTecnicaRegistro") == DialogResult.Yes)
                    {
                        FichaTecnica nueva = new FichaTecnica(equipo:equipo, boleta:Boleta, periodicidad:periodicidad, fecha:fecha,observaciones:observaciones,costo:Costo, estado:Estado, mantenimiento:mantenimiento);

                        _manejador.agregarFichaTecnica(ref nueva);
                        _padre.agregarFichaTecnica(nueva);

                        Mensaje.mostrarMensaje("MensajeFichaTecnicaConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    FichaTecnica copia = new FichaTecnica(id:_ficha.ID,equipo: equipo, boleta: Boleta,
                        periodicidad: periodicidad, fecha: fecha, observaciones: observaciones, costo: Costo, 
                        estado: Estado, mantenimiento: mantenimiento);

                    _manejador.actualizarFichaTecnica(copia);

                    _ficha.Boleta = Boleta;
                    _ficha.Costo = Costo;
                    _ficha.Equipo = equipo;
                    _ficha.Estatus = Estado;
                    _ficha.Mantenimiento = mantenimiento;
                    _ficha.Periodicidad = periodicidad;
                    _ficha.Fecha = fecha;
                    _ficha.Observaciones = observaciones;

                    _padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeFichaTecnicaConfirmacionActualizacion");
                    this.Close();
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Eventos

    }
}
