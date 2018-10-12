//
//  @ Project : 
//  @ File Name : frmRegistroTipoDeCambio.cs
//  @ Date : 29/07/2011
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

    public partial class frmRegistroTipoDeCambio : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private TipoCambio _tipo = null;

        #endregion Atributos

        #region Constructor

        public frmRegistroTipoDeCambio()
        {
            InitializeComponent();

            this.mostrarTipoCambio();
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Se presiona el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime fecha = dtpFecha.Value;
                decimal compra = nudCompra.Value;
                decimal venta = nudVenta.Value;
                decimal compra_euros = nudCompraEuros.Value;
                decimal venta_euros = nudVentaEuros.Value;

                // Verificar si el tipo de gestión ya está registrado

                if (_tipo == null)
                {
                    // Agregar los datos del tipo de cambio

                    TipoCambio nuevo = new TipoCambio(fecha, venta, compra,compra_euros, venta_euros);

                    _mantenimiento.agregarTipoCambio(ref nuevo);

                    _tipo = nuevo;

                    Mensaje.mostrarMensaje("MensajeTipoCambioConfirmacionRegistro");
                    this.Close();
                }
                else
                {
                    // Actualizar los datos del tipo de gestión

                    TipoCambio copia = new TipoCambio(_tipo.Id, venta, compra, venta_euros, compra_euros);

                    _mantenimiento.actualizarTipoCambio(copia);

                    _tipo.Venta = venta;
                    _tipo.Compra = compra;

                    Mensaje.mostrarMensaje("MensajeTipoCambioConfirmacionActualizacion");
                    this.Close();
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se selecciona otra fecha.
        /// </summary>
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            this.mostrarTipoCambio();
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Mostrar el tipo de cambio.
        /// </summary>
        private void mostrarTipoCambio()
        {

            try
            {
                DateTime fecha = dtpFecha.Value;

                _tipo = _mantenimiento.obtenerTipoCambio(fecha);

                if (_tipo != null)
                {
                    nudCompra.Value = _tipo.Compra;
                    nudVenta.Value = _tipo.Venta;
                    nudCompraEuros.Value = _tipo.CompraEuros;
                    nudVentaEuros.Value = _tipo.VentaEuros;
                }
                else
                {
                    nudCompra.Value = 1;
                    nudVenta.Value = 1;
                    nudCompraEuros.Value = 1;
                    nudVentaEuros.Value = 1;
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Métodos Privados

    }

}
