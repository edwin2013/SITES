using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmMantenimientoVehiculo : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private Vehiculo _vehiculo = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoVehiculo()
        {
            InitializeComponent();

        }

        public frmMantenimientoVehiculo(Vehiculo vehiculo)
        {
            InitializeComponent();

            _vehiculo = vehiculo;

            txtModelo.Text = _vehiculo.Modelo;
            txtPlaca.Text = _vehiculo.Placa;
            txtNumeroA.Text = _vehiculo.NumeroAsociado.ToString();

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (ValidateMonto())
            {


                try
                {
                    string placa = txtPlaca.Text;
                    string modelo = txtModelo.Text;
                    int numeroasociado = Convert.ToInt32(txtNumeroA.Text);

                    frmAdministracionVehiculos padre = (frmAdministracionVehiculos)this.Owner;

                    // Verificar si el vehiculo ya está registrado

                    if (_vehiculo == null)
                    {
                        // Agregar los datos del vehiculo

                        if (Mensaje.mostrarMensajeConfirmacion("MensajeVehiculoRegistro") == DialogResult.Yes)
                        {
                            Vehiculo nueva = new Vehiculo(placa,modelo,numeroasociado);

                            _mantenimiento.agregarVehiculo(ref nueva);


                            Mensaje.mostrarMensaje("MensajeVehiculoConfirmacionRegistro");
                            this.Close();
                        }

                    }
                    else
                    {
                        // Actualizar los datos de la ubicación

                        Vehiculo copia = new Vehiculo(placa, modelo,numeroasociado,_vehiculo.ID);

                        _mantenimiento.actualizarVehiculo(copia);


                        Mensaje.mostrarMensaje("MensajeVehiculoConfirmacionActualizacion");
                        this.Close();
                    }

                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }
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

        #region Metodos Privados

        // Genera una alarma si no se han ingresado todos los campos
        private bool ValidateMonto()
        {
            bool bStatus = true;
            if (String.IsNullOrEmpty(txtPlaca.Text))
            {
                errorProvider1.SetError(txtPlaca, "Debe ingresar el número de placa");
                bStatus = false;
            }
            else
                errorProvider1.SetError(txtPlaca, "");

            //if (String.IsNullOrEmpty(txtModelo.Text))
            //{
            //    errorProvider1.SetError(txtModelo, "Debe ingresar el modelo del blindado");
            //    bStatus = false;
            //}
            //else
            //    errorProvider1.SetError(txtModelo, "");

            if (String.IsNullOrEmpty(txtNumeroA.Text))
            {
                errorProvider1.SetError(txtNumeroA, "Debe ingresar el número asociado");
                bStatus = false;
            }
            else
                errorProvider1.SetError(txtNumeroA, "");
            return bStatus;
        }


        /// <summary>
        /// Metodo que valida que no se digiten numeros
        /// </summary>
        private void txtNumeroA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48 && e.KeyChar != 8 && e.KeyChar != 44) || e.KeyChar > 57)
            {
                MessageBox.Show("Sólo se permiten Números");
                e.Handled = true;
            }
        }

        #endregion Metodos Privados

       
    }
}
