using BussinessLayer;
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

namespace GUILayer.Formularios.Facturacion
{
    public partial class frmMantenimientoTipoPenalidades : Form
    {
         #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private TipoPenalidad _tipo_penalidad = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoTipoPenalidades()
        {
            InitializeComponent();

            dgvNiveles.AutoGenerateColumns = false;
            dgvNiveles.DataSource = new BindingList<NivelTipoPenalidad>();

            
        }

        public frmMantenimientoTipoPenalidades(TipoPenalidad tipo_penalidad)
        {
            InitializeComponent();

            _tipo_penalidad = tipo_penalidad;
            txtDescripcion.Text = tipo_penalidad.Nombre;


            dgvNiveles.AutoGenerateColumns = false;
            dgvNiveles.DataSource = _tipo_penalidad.Niveles;

            

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (txtDescripcion.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorTipoPenalidadDatosRegistro");
                return;
            }

            try
            {
                frmAdministracionTipoPenalidad padre = (frmAdministracionTipoPenalidad)this.Owner;

                BindingList<NivelTipoPenalidad> niveles = (BindingList<NivelTipoPenalidad>)dgvNiveles.DataSource;
                string descripcion = txtDescripcion.Text;

                // Verificar si el esquema es nuevo

                if (_tipo_penalidad == null)
                {
                    // Agregar los datos del nuevo esquema

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeTipoPenalidadRegistro") == DialogResult.Yes)
                    {
                        TipoPenalidad nuevo = new TipoPenalidad(nombre:descripcion);

                        nuevo.Niveles = niveles;

                        _mantenimiento.agregarTipoPenalidad(ref nuevo);

                        padre.agregarTipoPenalidad(nuevo);
                        Mensaje.mostrarMensaje("MensajeTipoPenalidadConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    TipoPenalidad copia = new TipoPenalidad(id: _tipo_penalidad.Id, nombre: descripcion);

                    copia.Niveles = niveles;

                    // Actualizar los datos del esquema

                    _mantenimiento.actualizarTipoPenalidad(copia);

                    _tipo_penalidad.Nombre = copia.Nombre;
                    _tipo_penalidad.Niveles = copia.Niveles;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeTipoPenalidadConfirmacionActualizacion");
                    this.Close();
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de agregar posición.
        /// </summary>
        private void btnAgregarPosicion_Click(object sender, EventArgs e)
        {

            string descripcion = txtDescripcion.Text;

            NivelTipoPenalidad posicion = new NivelTipoPenalidad();

            BindingList<NivelTipoPenalidad> niveles = (BindingList<NivelTipoPenalidad>)dgvNiveles.DataSource;

            niveles.Add(posicion);

            //txtDescripcion.Text = string.Empty;
        }

        /// <summary>
        /// Clic en el botón de quitar posición.
        /// </summary>
        private void btnQuitarPosicion_Click(object sender, EventArgs e)
        {
            dgvNiveles.Rows.Remove(dgvNiveles.SelectedCells[0].OwningRow);
        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Actualizar los valores de una posición del esquema.
        /// </summary
        private void dgvPosiciones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvNiveles.RowCount > 0)
            {
                DataGridViewRow fila = dgvNiveles.Rows[e.RowIndex];
                NivelTipoPenalidad posicion = (NivelTipoPenalidad)fila.DataBoundItem;

                try
                {
                    _mantenimiento.actualizarNivelTipoPenalidad(posicion);
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

                dgvNiveles.Refresh();
            }

        }

        /// <summary>
        /// Se selecciona otra posición.
        /// </summary>
        private void dgvPosiciones_SelectionChanged(object sender, EventArgs e)
        {
            btnQuitarNivel.Enabled = dgvNiveles.RowCount > 0;
        }

        /// <summary>
        /// Se cambia el texto de la descripción.
        /// </summary>
        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            btnAgregarNivel.Enabled = txtDescripcion.Text.Length > 0;
        }

        #endregion Eventos
    }
}
