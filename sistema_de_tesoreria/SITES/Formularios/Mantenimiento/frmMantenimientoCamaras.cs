//
//  @ Project : 
//  @ File Name : frmMantenimientoCamaras.cs
//  @ Date : 28/07/2011
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

    public partial class frmMantenimientoCamaras : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private Camara _camara = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoCamaras()
        {
            InitializeComponent();

            cboAreas.SelectedIndex = (byte)Areas.CentroEfectivo;
        }

        public frmMantenimientoCamaras(Camara camara)
        {
            InitializeComponent();

            _camara = camara;

            txtIdentificador.Text = _camara.Identificador;
            cboAreas.SelectedIndex = (byte)_camara.Area;
        }
       
        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (txtIdentificador.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorCamaraDatosRegistro");
                return;
            }

            try
            {
                frmAdministracionCamaras padre = (frmAdministracionCamaras)this.Owner;

                string identificador = txtIdentificador.Text;
                Areas area = (Areas)cboAreas.SelectedIndex;

                // Verificar si la camará ya está registrada

                if (_camara == null)
                {
                    // Agregar la cámara

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeCamaraRegistro") == DialogResult.Yes)
                    {
                        Camara nueva = new Camara(identificador, area: area);

                        _mantenimiento.agregarCamara(ref nueva);
                        padre.agregarCamara(nueva);

                        Mensaje.mostrarMensaje("MensajeCamaraConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la cámara

                    Camara copia = new Camara(identificador, id: _camara.ID, area: area);

                    _mantenimiento.actualizarCamara(copia);

                    _camara.Identificador = identificador;
                    _camara.Area = area;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeCamaraConfirmacionActualizacion");
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
