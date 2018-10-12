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
using CommonObjects;

namespace GUILayer.Formularios.ATMs
{
    public partial class frmMantenimientoGarantiaCartucho : Form
    {
        #region Atributos
        private GarantiaCartucho _garantia = null;
        private Colaborador _usuario = new Colaborador();
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        #endregion Atributos

        #region Constructor
        public frmMantenimientoGarantiaCartucho()
        {
            InitializeComponent();
        }

        public frmMantenimientoGarantiaCartucho(Colaborador usuario)
        {
            _usuario = usuario;
            InitializeComponent();
        }

        #endregion Constructor

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (nudDiasGarantia.Value==0)
            {
                Excepcion.mostrarMensaje("ErrorEstadoCartuchoDatosRegistro");
                return;
            }

            try
            {
                frmAdministraciónGarantiaCartuchos padre = (frmAdministraciónGarantiaCartuchos)this.Owner;

                int dias = Convert.ToInt32(nudDiasGarantia.Value);
                DateTime fecha = System.DateTime.Now;
               
                if (_garantia == null)
                {
                  
                    if (Mensaje.mostrarMensajeConfirmacion("MensajeGarantiaRegistro") == DialogResult.Yes)
                    {
                        GarantiaCartucho nueva = new GarantiaCartucho(id:0, dias:dias, fecha:fecha, usuario:_usuario);

                        _mantenimiento.agregarGarantiaCartucho(ref nueva);

                        padre.agregarGarantiaCartucho(nueva);

                        Mensaje.mostrarMensaje("MensajeGarantiaConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    
                    GarantiaCartucho copia = new GarantiaCartucho(id: _garantia.ID, dias: dias, fecha:fecha, usuario:_usuario);

                    _mantenimiento.actualizarGarantiaCartucho(ref copia);

                    _garantia.dias = dias;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeGarantiaConfirmacionActualizacion");
                    this.Close();
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }
    }
}
