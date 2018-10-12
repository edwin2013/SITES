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

namespace GUILayer.Formularios.Boveda
{
    public partial class frmFormulas : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private Colaborador _colaborador = null;
        private Formula _formulas = null;

        #endregion Atributos

        #region Constructor

        public frmFormulas(Colaborador c)
        {
            InitializeComponent();
            _colaborador = c;
            this.mostrarFormula();
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
                int paqueton = (int)nudPaqueton.Value;
                int bolsa = (int)nudBolsa.Value;

                // Verificar si el tipo de gestión ya está registrado

                if (_formulas == null)
                {
                    // Agregar los datos del tipo de cambio

                    Formula nuevo = new Formula(paqueton:paqueton,bolsa:bolsa, c: _colaborador);

                    _mantenimiento.agregarFormula(ref nuevo);

                    _formulas = nuevo;

                    Mensaje.mostrarMensaje("MensajeFormulaConfirmacionRegistro");
                    this.Close();
                }
                else
                {
                    // Actualizar los datos del tipo de gestión

                    Formula copia = new Formula(id:_formulas.Id, paqueton:paqueton, bolsa: bolsa, c:_colaborador);

                    _mantenimiento.actualizarFormula(copia);

                    _formulas.Paquete = paqueton;
                    _formulas.Bolsa = bolsa;

                    Mensaje.mostrarMensaje("MensajeFormulaConfirmacionActualizacion");
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

        #region Métodos Privados

        /// <summary>
        /// Mostrar las formulas
        /// </summary>
        private void mostrarFormula()
        {

            try
            {

                _formulas = _mantenimiento.obtenerFormula();

                if (_formulas != null)
                {
                    nudPaqueton.Value = _formulas.Paquete;
                    nudBolsa.Value = _formulas.Bolsa;
                }
                else
                {
                    nudPaqueton.Value = 1;
                    nudBolsa.Value = 1;
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
