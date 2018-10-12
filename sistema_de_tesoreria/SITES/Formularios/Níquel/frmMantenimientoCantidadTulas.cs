using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Níquel
{
    public partial class frmMantenimientoCantidadTulas : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private MaximasCantidades _MaximasCantidades = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoCantidadTulas()
        {
            InitializeComponent();

            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();

        }

        public frmMantenimientoCantidadTulas(MaximasCantidades MaximasCantidades)
        {
            InitializeComponent();

            _MaximasCantidades = MaximasCantidades;
            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
            nudTulas.Value = _MaximasCantidades.Tulas;
            cboTransportadora.Text = _MaximasCantidades.EmpresaTransportadora.ToString();

        }
       
        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (nudTulas.Value <= 0)
            {
                Excepcion.mostrarMensaje("ErrorMaximasCantidadesDatosRegistro");
                return;
            }

            try
            {


                int cantidad_tulas = (int)nudTulas.Value;
      
                EmpresaTransporte empresa = (EmpresaTransporte)cboTransportadora.SelectedItem;

                // Verificar si la camará ya está registrada
                frmAdministracionCantidadTulas padre = (frmAdministracionCantidadTulas)this.Owner;
                if (_MaximasCantidades == null)
                {
                    // Agregar la cámara

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeMaximasCantidadesRegistro") == DialogResult.Yes)
                    {
                        MaximasCantidades nueva = new MaximasCantidades(tulas: cantidad_tulas,  emp: empresa);

                        _mantenimiento.agregarCantidadTulas(ref nueva);

                        padre.agregarMaximasCantidades(nueva);
                        Mensaje.mostrarMensaje("MensajeMaximasCantidadesConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la cámara

                    MaximasCantidades copia = new MaximasCantidades(id: _MaximasCantidades.ID, tulas: cantidad_tulas, emp: empresa);

                    _mantenimiento.actualizarCantidadTulas(copia);

                    _MaximasCantidades.Tulas = cantidad_tulas;
         
                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeMaximasCantidadesConfirmacionActualizacion");
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
