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

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmMantenimientoCalidadBilletes : Form
    {

        #region Atributos

        private MantenimientoBL _manejador = MantenimientoBL.Instancia;
        private frmAdministracionCalidadBilletes _padre = null;

        private CalidadBilletes _calidad = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoCalidadBilletes(frmAdministracionCalidadBilletes padre)
        {
            InitializeComponent();

            _padre = padre;
        }

        public frmMantenimientoCalidadBilletes(CalidadBilletes calidad, frmAdministracionCalidadBilletes padre)
        {
            InitializeComponent();

            _padre = padre;
            _calidad = calidad;

            txtNombre.Text = _calidad.Nombre;
            
        }
       
        #endregion Constructor

        #region Eventos

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (txtNombre.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorEmpresaTransporteDatosRegistro");
                return;
            }

            try
            {
                string nombre = txtNombre.Text.ToUpper();



                // Si la calidad del billete es nueva

                if (_calidad == null)
                {
                    // Agregar la calidad del billete

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeEmpresaTransporteRegistro") == DialogResult.Yes)
                    {
                        CalidadBilletes nueva = new CalidadBilletes(nombre:nombre);

                        _manejador.agregarCalidadBilletes(ref nueva);
                        _padre.agregarCalidadBilletes(nueva);

                        Mensaje.mostrarMensaje("MensajeEmpresaTransporteConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar la empresa de transporte

                    CalidadBilletes copia = new CalidadBilletes(id: _calidad.ID, nombre:nombre);

                    _manejador.actualizarCalidadBilletes(copia);

                    _calidad.Nombre = nombre;

                    _padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeEmpresaTransporteConfirmacionActualizacion");
                    this.Close();
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        #endregion Eventos
    }
}
