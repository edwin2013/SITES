using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects.Clases;
using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmMantenimientoEquipo : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private Equipo _equipo = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoEquipo()
        {
            InitializeComponent();

            cargarDatos();
        }

        public frmMantenimientoEquipo(Equipo equipo)
        {
            InitializeComponent();

            cargarDatos();

            _equipo = equipo;

            txtSerie.Text = _equipo.Serie;
            txtCodigoBarras.Text = _equipo.CodigoBarras;
            cboTipoEquipo.SelectedItem = _equipo.TipoEquipo;
            txtIDAsignacion.Text = _equipo.IdAsignacion;

            if (_equipo.ATM != null)
            {
                rbtnATM.Checked = true;
                cboATM.SelectedItem = _equipo.ATM;

            }

            if (_equipo.Asginado != null)
            {
                rbtnColaborador.Checked = true;
                cboColaborador.Text = _equipo.Asginado.ToString();

            }

            if (_equipo.Manojo != null)
            {
                rbtnManojo.Checked = true;
                cboManojo.SelectedItem = _equipo.Manojo;

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

            if ((txtSerie.Text.Equals(string.Empty) || txtCodigoBarras.Text.Equals(string.Empty) || txtIDAsignacion.Text.Equals(string.Empty) || cboTipoEquipo.Text.Equals(string.Empty)))
            {
                Excepcion.mostrarMensaje("ErrorEquipoDatosRegistro");
                return;
            }

            try
            {
                string serie = txtSerie.Text;
                string codigo_barras = txtCodigoBarras.Text;
                string id_asignacion = txtIDAsignacion.Text;
                CommonObjects.ATM atm = (CommonObjects.ATM)cboATM.SelectedItem;
                TipoEquipo tipo_equipo = (TipoEquipo)cboTipoEquipo.SelectedItem;
                Colaborador colaborador_asignado = (Colaborador)cboColaborador.SelectedItem;
                Manojo manojo = (Manojo)cboManojo.SelectedItem;

                Puestos p = 0;

                // Llena los puestos en base al combo

                if (cboPuesto.SelectedIndex == 0)
                {
                    p = Puestos.Chofer;
                }
                if (cboPuesto.SelectedIndex == 1)
                {
                    p = Puestos.Custodio;
                }
                if (cboPuesto.SelectedIndex == 2)
                {
                    p = Puestos.Portavalor;
                }

                frmAdministracionEquipo padre = (frmAdministracionEquipo)this.Owner;

                // Verificar si la sucursal ya está registrada

                if (_equipo == null)
                {
                    // Agregar los datos de la sucursal

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeEquipoRegistro") == DialogResult.Yes)
                    {
                        Equipo nueva = new Equipo(serie: serie, tipoequipo: tipo_equipo, idasignacion: id_asignacion, codigobarras: codigo_barras, atm: atm, col: colaborador_asignado, man: manojo, p: p);

                        
                        _mantenimiento.agregarEquipo(ref nueva);

                        padre.agregarEquipo(nueva);
                        Mensaje.mostrarMensaje("MensajeEquipoConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la sucursal

                    Equipo copia = new Equipo(id:_equipo.ID,serie:serie,tipoequipo:tipo_equipo,idasignacion:id_asignacion,codigobarras:codigo_barras,atm:atm,col:colaborador_asignado,man:manojo, p:p);





                    _mantenimiento.actualizarEquipo(copia);

                    _equipo.Serie = serie;
                    _equipo.CodigoBarras = codigo_barras;
                    _equipo.ATM = atm;
                    _equipo.IdAsignacion = id_asignacion;
                    _equipo.Asginado = colaborador_asignado;
                    _equipo.Manojo = manojo;
                    _equipo.TipoEquipo = tipo_equipo;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeEquipoConfirmacionActualizacion");
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
        /// Clic en el radio buttton de ATMs
        /// </summary>
        private void rbtnATM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnATM.Checked == true)
            {
                cboATM.Enabled = true;
                cboColaborador.Enabled = false;
                cboColaborador.Text = "";
                cboManojo.Enabled = false;
                cboManojo.Text = "";
            }

        }

        private void rbtnColaborador_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnColaborador.Checked == true)
            {
                cboColaborador.Enabled = true;
                cboATM.Enabled = false;
                cboATM.Text = "";
                cboManojo.Enabled = false;
                cboManojo.Text = "";
            }
        }

        /// <summary>
        /// Clic en el radio button de Manojos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnManojo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnManojo.Checked == true)
            {
                cboManojo.Enabled = true;
                cboATM.Enabled = false;
                cboATM.Text = "";
                cboColaborador.Enabled = false;
                cboColaborador.Text = "";
            }
        }


        #endregion Eventos
        
        #region Metodos Privados

        /// <summary>
        /// Carga los datos del sistema
        /// </summary>
        private void cargarDatos()
        {
            cboTipoEquipo.ListaMostrada = _mantenimiento.listarTipoEquipo();
            cboManojo.ListaMostrada = _mantenimiento.listarManojo(string.Empty);
            cboATM.ListaMostrada = _mantenimiento.listarATMs();
            cboColaborador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.Blindados, Puestos.Chofer, Puestos.Portavalor, Puestos.Custodio);
        }

        #endregion Metodos Privados


        
    }
}
