//
//  @ Project : 
//  @ File Name : frmMantenimientoDenominaciones.cs
//  @ Date : 16/12/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmMantenimientoDenominaciones : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private Denominacion _denominacion = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoDenominaciones()
        {
            InitializeComponent();

            try
            {
                cboMoneda.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        public frmMantenimientoDenominaciones(Denominacion denominacion)
        {
            InitializeComponent();

            _denominacion = denominacion;

            nudValor.Value = denominacion.Valor;
            cboMoneda.SelectedIndex = (byte)denominacion.Moneda;
            chkCargaATM.Checked = _denominacion.Carga_atm;
            chkMoneda.Checked = _denominacion.EsMoneda;

            if (_denominacion.Carga_atm)
            {
                txtCodigo.Text = _denominacion.Codigo;
                txtConfiguracionOpteva.Text = _denominacion.Configuracion_opteva;
                txtConfiguracionDiebold.Text = _denominacion.Configuracion_diebold;
                nudFormulasMaximas.Value = (short)_denominacion.Formulas_maximas;
                nudFormulasMinimas.Value = (short)_denominacion.Formulas_minimas;
                nudIDImagen.Value = (byte)_denominacion.Id_imagen;
                chkMoneda.Checked = _denominacion.EsMoneda;
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

            if (chkCargaATM.Checked && (txtConfiguracionOpteva.Text.Equals(string.Empty) ||
                txtConfiguracionDiebold.Text.Equals(string.Empty) || txtCodigo.Text.Equals(string.Empty)))
            {
                Excepcion.mostrarMensaje("ErrorDenominacionDatosRegistro");
                return;
            }

            try
            {
                frmAdministracionDenominaciones padre = (frmAdministracionDenominaciones)this.Owner;

                Monedas moneda = (Monedas)cboMoneda.SelectedIndex;
                decimal valor = nudValor.Value;
                bool carga_atm = chkCargaATM.Checked;
                bool es_moneda = chkMoneda.Checked;
                string codigo = null;
                byte? id_imagen = null;
                string configuracion_opteva = null;
                string configuracion_diebold = null;
                short? formulas_maximas = null;
                short? formulas_minimas = null;

                if (carga_atm)
                {
                    codigo = txtCodigo.Text.ToUpper();
                    id_imagen = (byte)nudIDImagen.Value;
                    configuracion_opteva = txtConfiguracionOpteva.Text;
                    configuracion_diebold = txtConfiguracionDiebold.Text;
                    formulas_maximas = (short)nudFormulasMaximas.Value;
                    formulas_minimas = (short)nudFormulasMinimas.Value;
                }

                // Verificar si la denominación ya está registrada

                if (_denominacion == null)
                {
                    // Agregar los datos de la denominación

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeDenominacionRegistro") == DialogResult.Yes)
                    {
                        Denominacion nueva = new Denominacion(valor: valor, moneda: moneda, carga_atm: carga_atm, codigo: codigo, id_imagen: id_imagen,
                                                              formulas_maximas: formulas_maximas, formulas_minimas: formulas_minimas,
                                                              configuracion_opteva: configuracion_opteva, configuracion_diebold: configuracion_diebold, esmoneda: es_moneda);

                        _mantenimiento.agregarDenominacion(ref nueva);
                       

                        padre.agregarDenominacion(nueva);
                        Mensaje.mostrarMensaje("MensajeDenominacionConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la Denominación

                    Denominacion copia = new Denominacion(id: _denominacion.Id, valor: valor, moneda: moneda, carga_atm: carga_atm, codigo: codigo,
                                                          id_imagen: id_imagen, formulas_maximas: formulas_maximas, formulas_minimas: formulas_minimas,
                                                          configuracion_opteva: configuracion_opteva, configuracion_diebold: configuracion_diebold, esmoneda:es_moneda);

                    _mantenimiento.actualizarDenominacion(copia);

                    _denominacion.Valor = valor;
                    _denominacion.Moneda = moneda;
                    _denominacion.Carga_atm = carga_atm;
                    _denominacion.Codigo = codigo;
                    _denominacion.Id_imagen = id_imagen;
                    _denominacion.Configuracion_opteva = configuracion_opteva;
                    _denominacion.Configuracion_diebold = configuracion_diebold;
                    _denominacion.Formulas_maximas = formulas_maximas;
                    _denominacion.Formulas_minimas = formulas_minimas;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeDenominacionConfirmacionActualizacion");
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

        /// <summary>
        /// Se marca o desmarca la opción  de asignar los datos de carga de ATM's a la denominación.
        /// </summary>
        private void chkCargaATM_CheckedChanged(object sender, EventArgs e)
        {
            pnlDatosCargaATM.Enabled = chkCargaATM.Checked;
        }

        #endregion Eventos

    }

}
