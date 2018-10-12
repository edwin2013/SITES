using BussinessLayer;
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
    public partial class frmMantenimientoPenalidades : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private Penalidad _penalidad = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoPenalidades()
        {
            InitializeComponent();

            cboTipoPenalidad.ListaMostrada = _mantenimiento.listarTipoPenalidades(string.Empty);
        }

        public frmMantenimientoPenalidades(Penalidad penalidad)
        {
            InitializeComponent();

            _penalidad = penalidad;
            cboTipoPenalidad.ListaMostrada = _mantenimiento.listarTipoPenalidades(string.Empty);
            txtDescripcion.Text = _penalidad.Descripcion;
            cboTipoPenalidad.Text = _penalidad.TipoPenalidad.ToString();
        }
       
        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (txtDescripcion.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorPenalidadDatosRegistro");
                return;
            }

            try
            {
                frmAdministracionPenalidades padre = (frmAdministracionPenalidades)this.Owner;

                string identificador = txtDescripcion.Text;
                TipoPenalidad tipo = (TipoPenalidad)cboTipoPenalidad.SelectedItem;

                // Verificar si la camará ya está registrada

                if (_penalidad == null)
                {
                    // Agregar la cámara

                    if (Mensaje.mostrarMensajeConfirmacion("MensajePenalidadRegistro") == DialogResult.Yes)
                    {
                        Penalidad nueva = new Penalidad(descripcion: identificador, tipopenalidad: tipo);

                        _mantenimiento.agregarPenalidad(ref nueva);
                        padre.agregarPenalidad(nueva);

                        Mensaje.mostrarMensaje("MensajePenalidadConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la cámara

                    Penalidad copia = new Penalidad(id: _penalidad.ID, tipopenalidad: tipo, descripcion: identificador);

                    _mantenimiento.actualizarPenalidad(copia);

                    _penalidad.Descripcion = identificador;
                    _penalidad.TipoPenalidad = tipo;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajePenalidadConfirmacionActualizacion");
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
