//
//  @ Project : 
//  @ File Name : frmMantenimientoClientes.cs
//  @ Date : 01/06/2011
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

    public partial class frmMantenimientoEmpresasTransporte : Form
    {

        #region Atributos

        private MantenimientoBL _manejador = MantenimientoBL.Instancia;
        private frmAdministracionEmpresasTransporte _padre = null;

        private EmpresaTransporte _empresa = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoEmpresasTransporte(frmAdministracionEmpresasTransporte padre)
        {
            InitializeComponent();

            _padre = padre;
        }

        public frmMantenimientoEmpresasTransporte(EmpresaTransporte empresa, frmAdministracionEmpresasTransporte padre)
        {
            InitializeComponent();

            _padre = padre;
            _empresa = empresa;

            txtNombre.Text = _empresa.Nombre;
            nudPrecioMilColones.Value = _empresa.PrecioUnitarioMilColones;
            nudPrecioMilDolares.Value = _empresa.PrecioUnitarioMilDolares;
            nudPrecioPieza.Value = _empresa.PrecioUnitarioPieza;
            
        }
       
        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
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
                decimal precio_unitario_pieza = nudPrecioPieza.Value;
                decimal precio_mil_colones = nudPrecioMilColones.Value;
                decimal precio_mil_dolares = nudPrecioMilDolares.Value;
   


                // Si la empresa de transporte es nueva

                if (_empresa == null)
                {
                    // Agregar la empresa de transporte

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeEmpresaTransporteRegistro") == DialogResult.Yes)
                    {
                        EmpresaTransporte nueva = new EmpresaTransporte(nombre);
                        nueva.PrecioUnitarioPieza = precio_unitario_pieza;
                        nueva.PrecioUnitarioMilColones = precio_mil_colones;
                        nueva.PrecioUnitarioMilDolares = precio_mil_dolares;

                        _manejador.agregarEmpresaTransporte(ref nueva);
                        _padre.agregarEmpresa(nueva);

                        Mensaje.mostrarMensaje("MensajeEmpresaTransporteConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar la empresa de transporte

                    EmpresaTransporte copia = new EmpresaTransporte(nombre, id: _empresa.ID);

                    copia.PrecioUnitarioPieza = precio_unitario_pieza;
                    copia.PrecioUnitarioMilColones = precio_mil_colones;
                    copia.PrecioUnitarioMilDolares = precio_mil_dolares;

                    _manejador.actualizarEmpresaTransporte(copia);

                      _empresa.Nombre = nombre;

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