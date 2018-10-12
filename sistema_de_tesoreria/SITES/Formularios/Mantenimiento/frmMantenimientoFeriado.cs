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
    public partial class frmMantenimientoFeriado : Form
    {
        #region Atributos

        private frmAdministracionFeriados _padre;

        public frmAdministracionFeriados Padre
        {
            get { return _padre; }
            set { _padre = value; }
        }

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
       
        private Feriado _feriado = null;
        private Colaborador _usuario = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoFeriado(Colaborador usuario)
        {
            InitializeComponent();

            _usuario = usuario;

           

        }

        public frmMantenimientoFeriado(Colaborador usuario, Feriado feriado)
        {
            InitializeComponent();

            _usuario = usuario;
            _feriado = feriado;

            txtDescripcion.Text = _feriado.Descripcion;
            dtpFechaInicio.Value = _feriado.Fecha_inicio;
            dtpFechaFinalizacion.Value = _feriado.Fecha_finalizacion;

           

        }

      
        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (txtDescripcion.Text.Equals(string.Empty) || 
                dtpFechaInicio.Value > dtpFechaFinalizacion.Value)
            {
                Excepcion.mostrarMensaje("ErrorFeriadoDatosRegistro");
                return;
            }

            try
            {
                string descripcion = txtDescripcion.Text;
                DateTime fecha_inicio = dtpFechaInicio.Value;
                DateTime fecha_finalizacion = dtpFechaFinalizacion.Value;

                // Verificar si el feriado es nuevo

                if (_feriado == null)
                {
                    // Agregar el feriado

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeFeriadoRegistro") == DialogResult.Yes)
                    {
                        Feriado nuevo = new Feriado(descripcion, fecha_inicio, fecha_finalizacion);

                        _mantenimiento.agregarFeriado(ref nuevo);

                        _padre.agregarFeriado(nuevo);
                        
                        Mensaje.mostrarMensaje("MensajeFeriadoConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    Feriado copia = new Feriado(_feriado.Id, descripcion, fecha_inicio, fecha_finalizacion);


                    _mantenimiento.actualizarFeriado(copia);

                    // Actualizar la operación

                    _feriado.Descripcion = descripcion;
                    _feriado.Fecha_inicio = fecha_inicio;
                    _feriado.Fecha_finalizacion = fecha_finalizacion;
                   

                    _padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeFeriadoConfirmacionActualizacion");
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
