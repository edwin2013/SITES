//
//  @ Project : 
//  @ File Name : frmMantenimientoCausasGestion.cs
//  @ Date : 18/08/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmMantenimientoCausasGestion : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private CausaGestion _causa = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoCausasGestion()
        {
            InitializeComponent();

            cboCausante.SelectedIndex = 0;
        }

        public frmMantenimientoCausasGestion(CausaGestion causa)
        {
            InitializeComponent();

            _causa = causa;

            txtDescripcion.Text = _causa.Descripcion;
            cboCausante.SelectedIndex = (byte)_causa.Causante;
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
                Excepcion.mostrarMensaje("ErrorCausaGestionDatosRegistro");
                return;
            }

            try
            {
                string descripcion = txtDescripcion.Text;
                Causantes causante = (Causantes)cboCausante.SelectedIndex;

                frmAdministracionCausasGestion padre = (frmAdministracionCausasGestion)this.Owner;

                // Verificar si la causa de gestión ya está registrada

                if (_causa == null)
                {
                    // Agregar los datos de la causa de gestión

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeCausaGestionRegistro") == DialogResult.Yes)
                    {
                        CausaGestion nueva = new CausaGestion(descripcion, causante);

                        _mantenimiento.agregarCausaGestion(ref nueva);
                        padre.agregarCausaGestion(nueva);

                        Mensaje.mostrarMensaje("MensajeCausaGestionConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la causa de gestión

                    CausaGestion copia = new CausaGestion(_causa.Id, descripcion, causante);

                    _mantenimiento.actualizarCausaGestion(copia);

                    _causa.Descripcion = descripcion;
                    _causa.Causante = causante;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeCausaGestionConfirmacionActualizacion");
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
