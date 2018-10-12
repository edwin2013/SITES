//
//  @ Project : 
//  @ File Name : frmInclusionCiudades.cs
//  @ Date : 03/01/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmInclusionCiudades : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private BindingList<Ciudad> _ciudades = null;

        #endregion Atributos

        #region Constructor

        public frmInclusionCiudades()
        {
            InitializeComponent();

            try
            {
                _ciudades = _mantenimiento.listarCiudades();

                dgvCiudades.AutoGenerateColumns = false;

                cboProvincias.SelectedIndex = 0;
            }
            catch (Excepcion ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en e botón de agregar ciudad.
        /// </summary>
        private void btnAgregarCiudad_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Equals(string.Empty)) return;

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeCiudadRegistro") == DialogResult.Yes)
                {
                    Provincias provincia = (Provincias)cboProvincias.SelectedIndex;
                    string nombre = txtNombre.Text;

                    Ciudad ciudad = new Ciudad(nombre, provincia);

                    _mantenimiento.agregarCiudad(ref ciudad);

                    BindingList<Ciudad> ciudades = (BindingList<Ciudad>)dgvCiudades.DataSource;

                    ciudades.Add(ciudad);

                    dgvCiudades.Refresh();

                    Mensaje.mostrarMensaje("MensajeCiudadConfirmacionRegistro");
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
        /// Se selecciona otra ciudad.
        /// </summary>
        private void cboProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            Provincias provincia = (Provincias)cboProvincias.SelectedIndex;
            BindingList<Ciudad> ciudades = new BindingList<Ciudad>();

            foreach (Ciudad ciudad in _ciudades)
            {

                if (ciudad.Provincia.Equals(provincia)) ciudades.Add(ciudad);

            }

            dgvCiudades.DataSource = ciudades;
        }

        #endregion Eventos

  
        
    }

}
