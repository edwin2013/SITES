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
    public partial class frmMantenimientoGrupos : Form
    {

        #region Atributos

        private frmAdministracionGrupos _padre = null;

        private MantenimientoBL _manejador = MantenimientoBL.Instancia;

        private Grupo _grupo = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoGrupos(frmAdministracionGrupos padre)
        {
            InitializeComponent();

            _padre = padre;
        }

        public frmMantenimientoGrupos(Grupo grupo, frmAdministracionGrupos padre)
        {
            InitializeComponent();

            _padre = padre;
            _grupo = grupo;

            txtNombre.Text = _grupo.Nombre;
            txtDescripcion.Text = _grupo.Descripcion;
            chkCajaUnica.Checked = _grupo.Caja_unica;
            cboArea.SelectedIndex = (short)_grupo.Area;
            chkSemaforo.Checked = _grupo.Semaforo;
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
                Excepcion.mostrarMensaje("ErrorGrupoDatosRegistro");
                return;
            }

            try
            {
                string nombre = txtNombre.Text;
                string descripcion = txtDescripcion.Text;
                bool caja_unica = chkCajaUnica.Checked;
                bool semaforo = chkSemaforo.Checked;
                AreasManifiestos area = (AreasManifiestos)cboArea.SelectedIndex;

                // Si el grupo es un nuevo

                if (_grupo == null)
                {
                    // Agregar el grupo

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeGrupoRegistro") == DialogResult.Yes)
                    {
                        Grupo nuevo = new Grupo(nombre, descripcion, caja_unica, area, semaforo);

                        _manejador.agregarGrupo(ref nuevo);
                        _padre.agregarGrupo(nuevo);
                        
                        Mensaje.mostrarMensaje("MensajeGrupoConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar el grupo

                    Grupo copia = new Grupo(_grupo.Id, nombre, descripcion, caja_unica, area, semaforo);

                    _manejador.actualizarGrupo(copia);

                    _grupo.Nombre = nombre;
                    _grupo.Descripcion = descripcion;
                    _grupo.Caja_unica = caja_unica;
                    _grupo.Semaforo = semaforo;

                    _padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeGrupoConfirmacionActualizacion");
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
