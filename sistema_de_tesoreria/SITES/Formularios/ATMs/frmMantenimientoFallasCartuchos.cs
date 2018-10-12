using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriaMensajes;
using GUILayer.Formularios.Níquel;
using CommonObjects.Clases;
using BussinessLayer;

namespace GUILayer.Formularios.ATMs
{
    public partial class frmMantenimientoFallasCartuchos : Form
    {

        #region Atributos

        private FallaCartucho _falla = null;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        #endregion Atributos

        #region Constructor
        public frmMantenimientoFallasCartuchos()
        {
            InitializeComponent();
        }

        public frmMantenimientoFallasCartuchos(FallaCartucho falla)
        {
            InitializeComponent();

            _falla = falla;
            txtDescripcion.Text = _falla.Nombre;
            nudCantidad.Value = _falla.Cantidad;
            cbNoRecuperable.Checked = _falla.NoRecuperable;
        }

        #endregion Constructor

        #region Eventos

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (txtDescripcion.Text.Equals(string.Empty) || nudCantidad.Value == 0)
            {
                Excepcion.mostrarMensaje("ErrorFallaCartuchoDatosRegistro");
                return;
            }

            try
            {
                frmAdministracionFallasCartuchos padre = (frmAdministracionFallasCartuchos)this.Owner;

                string falla = txtDescripcion.Text;
                int cant = Convert.ToInt32(nudCantidad.Value);
                bool norecup = cbNoRecuperable.Checked;
                
                // Verificar si la falla ya está registrada

                if (_falla == null)
                {
                    // Agregar la falla

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeFallaCartuchoRegistro") == DialogResult.Yes)
                    {
                        FallaCartucho nueva = new FallaCartucho(id:0,nombre: falla, cantidad:cant, NRecuperable:norecup);

                        _mantenimiento.agregarFallaCartucho(ref nueva);
                        
                        padre.agregarFallaCartucho(nueva);

                        Mensaje.mostrarMensaje("MensajeFallaCartuchoConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la falla

                    FallaCartucho copia = new FallaCartucho(id: _falla.ID, nombre: falla, cantidad:cant, NRecuperable:norecup);
                    
                    _mantenimiento.actualizarFallaCartucho(ref copia);
                    
                    _falla.Nombre = falla;
                    _falla.Cantidad = cant;
                    _falla.NoRecuperable = norecup;
                   
                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeFallaCartuchoConfirmacionActualizacion");
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
