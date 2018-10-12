//
//  @ Project : 
//  @ File Name : frmMantenimientoUbicaciones.cs
//  @ Date : 08/05/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmMantenimientoUbicaciones : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private Ubicacion _ubicacion = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoUbicaciones()
        {
            InitializeComponent();

            cboProvincias.SelectedIndex = 0;
        }

        public frmMantenimientoUbicaciones(Ubicacion ubicacion)
        {
            InitializeComponent();

            _ubicacion = ubicacion;

            txtOficina.Text = _ubicacion.Oficina;
            txtDireccion.Text = _ubicacion.Direccion;
            txtDireccionExacta.Text = _ubicacion.Direccion_exacta;

            cboProvincias.SelectedIndex = (byte)_ubicacion.Provincia;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (txtOficina.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorubicacionDatosRegistro");
                return;
            }

            try
            {
                string oficina = txtOficina.Text;
                string direccion = txtDireccion.Text;
                string direccion_exacta = txtDireccionExacta.Text;
                Provincias provincia = (Provincias)cboProvincias.SelectedIndex;

                frmAdministracionUbicaciones padre = (frmAdministracionUbicaciones)this.Owner;

                // Verificar si la ubicación ya está registrada

                if (_ubicacion == null)
                {
                    // Agregar los datos de la ubicación

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeUbicacionRegistro") == DialogResult.Yes)
                    {
                        Ubicacion nueva = new Ubicacion(oficina, direccion, direccion_exacta: direccion_exacta, provincia: provincia);

                        _mantenimiento.agregarUbicacion(ref nueva);

                        padre.agregarUbicacion(nueva);
                        Mensaje.mostrarMensaje("MensajeUbicacionConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la ubicación

                    Ubicacion copia = new Ubicacion(oficina, direccion, id: _ubicacion.ID, direccion_exacta: direccion_exacta,
                                                    provincia: provincia);

                    _mantenimiento.actualizarUbicacion(copia);

                    _ubicacion.Oficina = oficina;
                    _ubicacion.Direccion = direccion;
                    _ubicacion.Direccion_exacta = direccion_exacta;
                    _ubicacion.Provincia = provincia;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeUbicacionConfirmacionActualizacion");
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
