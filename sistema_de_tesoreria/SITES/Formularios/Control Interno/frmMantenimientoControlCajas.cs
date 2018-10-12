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

namespace GUILayer.Formularios.Control_Interno
{
    public partial class frmMantenimientoControlCajas : Form
    {
       #region Atributos

        private MantenimientoBL _manejador = MantenimientoBL.Instancia;
        private frmAdministracionControlCajas _padre = null;
        private Colaborador _usuario = null;

        private Caja _caja = null;

        #endregion Atributos

       #region Constructor
        public frmMantenimientoControlCajas(frmAdministracionControlCajas padre, Colaborador usuario)
        {
            InitializeComponent();
            _padre = padre;
            _usuario = usuario;
        }

       public frmMantenimientoControlCajas(Caja caja, frmAdministracionControlCajas padre, Colaborador usuario)
        {
            InitializeComponent();
            _padre = padre;
           _caja = caja;
           _usuario = usuario;

           txtDescripcion.Text = _caja.Descripcion;
           txtNumero.Text = _caja.Numero.ToString();
        }
        #endregion Constructor

       #region Eventos
       private void btnSalir_Click(object sender, EventArgs e)
       {
           this.Close();
       }

       private void btnGuardar_Click(object sender, EventArgs e)
       {
           // Verificar que se hayan seleccionado los datos

           if (txtNumero.Text.Equals(string.Empty))
           {
               Excepcion.mostrarMensaje("ErrorCajaDatosRegistro");
               return;
           }

           try
           {
               decimal numero = Convert.ToDecimal(txtNumero.Text);
               string descripcion = txtDescripcion.Text;
               

               // Si la caja es nueva

               if (_caja == null)
               {
                   // Agregar la caja

                   if (Mensaje.mostrarMensajeConfirmacion("MensajeCajaRegistro") == DialogResult.Yes)
                   {
                       Caja nueva = new Caja();
                       nueva.Numero = numero;
                       nueva.Descripcion = descripcion;
                       nueva.Usuario = _usuario;
                       nueva.Fecha = System.DateTime.Now;

                       _manejador.agregarCaja(ref nueva, _usuario);
                       _padre.agregarCaja(nueva);

                       Mensaje.mostrarMensaje("MensajeCajaConfirmacionRegistro");
                       this.Close();
                   }

               }
               else
               {
                   // Actualizar la empresa de transporte

                   Caja copia = new Caja(numero:numero, id: _caja.ID, colaborador:_caja.Usuario, fecha_ingreso:_caja.Fecha, descripcion:descripcion);

                   _manejador.actualizarCaja(copia);

                   _caja.Numero = numero;
                   _caja.Descripcion = descripcion;

                   _padre.actualizarLista();
                   Mensaje.mostrarMensaje("MensajeCajaConfirmacionActualizacion");
                   this.Close();
               }

           }
           catch (Excepcion ex)
           {
               ex.mostrarMensaje();
           }
       }

       #endregion Eventos
    }
}
