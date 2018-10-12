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
    public partial class frmMantenimientoEquipos : Form
    {
        #region Atributos
        private MantenimientoBL _manejador = MantenimientoBL.Instancia;
        private frmAdministracionEquipos _padre = null;

        private EquipoTesoreria _equipo = null;

        #endregion Atributos

        #region Constructor
        public frmMantenimientoEquipos(frmAdministracionEquipos padre)
        {
            InitializeComponent();

            _padre = padre;

            cboProveedor.ListaMostrada = _manejador.listarProveedorEquipo(string.Empty);
        }


        public frmMantenimientoEquipos(EquipoTesoreria equipo, frmAdministracionEquipos padre)
        {
            InitializeComponent();

            _padre = padre;
            _equipo = equipo;

            txtNombre.Text = _equipo.Nombre;
            txtSerie.Text = _equipo.Serie;
            txtActivo.Text = _equipo.NumActivo;
            cboProveedor.SelectedItem = (ProveedorEquipo)_equipo.Proveedor;

            cboAreas.SelectedIndex = (byte)_equipo.Area;

            try
            {
                cboProveedor.ListaMostrada = _manejador.listarProveedorEquipo(string.Empty);
                cboProveedor.Text = _equipo.Proveedor.ToString();
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }
            
        }

        #endregion Constructor

        #region Eventos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (txtNombre.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorEquipoDatosRegistro");
                return;
            }

            try
            {
                string nombre = txtNombre.Text;
                string NumActivo = txtActivo.Text;
                string Serie = txtSerie.Text;
                ProveedorEquipo Proveedor = (ProveedorEquipo)cboProveedor.SelectedItem;
                Areas area = (Areas)cboAreas.SelectedIndex;

                if (_equipo == null)
                {
                    if (Mensaje.mostrarMensajeConfirmacion("MensajeEquipoRegistro") == DialogResult.Yes)
                    {
                        EquipoTesoreria nueva = new EquipoTesoreria(nom:nombre, serie:Serie, activonum:NumActivo, provedor:Proveedor, area: area);

                        _manejador.agregarEquipoTesoreria(ref nueva);
                        _padre.agregarEquipo(nueva);

                        Mensaje.mostrarMensaje("MensajeEquipoConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    EquipoTesoreria copia = new EquipoTesoreria(id: _equipo.ID, nom: nombre, serie: Serie, activonum: NumActivo, provedor: Proveedor, area:area);
                        
                    _manejador.actualizarEquipoTesoreria(copia);

                    _equipo.Nombre = nombre;
                    _equipo.Serie = Serie;
                    _equipo.NumActivo = NumActivo;
                    _equipo.Proveedor = Proveedor;
                    _equipo.Area = area;

                    _padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeEquipoConfirmacionActualizacion");
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
