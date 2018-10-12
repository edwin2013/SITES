using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using CommonObjects;
using LibreriaMensajes;

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmMantenimientoColaboradorSucursal : Form
    {
        #region Atributos

        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private Colaborador _colaborador = null;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoColaboradorSucursal(Colaborador administrador)
        {
            InitializeComponent();
            try
            {
                cboColaborador.ListaMostrada = _seguridad.listarColaboradoresPorArea(Areas.Sucursal);
                cboSucursal.ListaMostrada = _mantenimiento.listarSucursalesRecientes();
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        public frmMantenimientoColaboradorSucursal(Colaborador administrador, Colaborador colaborador)
        {
            try
            {
                InitializeComponent();
                cboColaborador.ListaMostrada = _seguridad.listarColaboradoresPorArea(Areas.Sucursal);
                cboSucursal.ListaMostrada = _mantenimiento.listarSucursalesRecientes();
                _colaborador = colaborador;

                cboColaborador.Text = _colaborador.ToString();
                cboSucursal.Text = _colaborador.Sucursal.ToString();

            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

       
        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (cboColaborador.Text.Equals(string.Empty) || cboSucursal.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorColaboradorDatosRegistro");
                return;
            }

            try
            {
               
                Colaborador colaborador = (Colaborador)cboColaborador.SelectedItem;
                Sucursal sucursal = (Sucursal)cboSucursal.SelectedItem;

                _colaborador = colaborador;
                // Verificar si el colaborador es nuevo

                if (_colaborador == null)
                {
                    // Agregar los datos del nuevo colaborador

                    //if (Mensaje.mostrarMensajeConfirmacion("MensajeColaboradorRegistro") == DialogResult.Yes)
                    //{
                    //    Colaborador nuevo = new Colaborador(sucursal: sucursal);

                        
                    //    _seguridad.agregarColaborador(ref nuevo);

                        
                    //    Mensaje.mostrarMensaje("MensajeColaboradorConfirmacionRegistro");
                    //    this.Close();
                    //}

                }
                else
                {
                   


                    // Actualizar los datos del colaborador
                    _colaborador.Sucursal = sucursal;
                    _seguridad.actualizarColaboradorSucursal(_colaborador);

                    
                   

                    Mensaje.mostrarMensaje("MensajeColaboradorConfirmacionActualizacion");
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

        private void cboColaborador_SelectedIndexChanged(object sender, EventArgs e)
        {
            Colaborador colaborador = (Colaborador)cboColaborador.SelectedItem;

            if (colaborador.Sucursal != null)
            {
                cboSucursal.Text = colaborador.Sucursal.Nombre;
            }
        }

    }
}
