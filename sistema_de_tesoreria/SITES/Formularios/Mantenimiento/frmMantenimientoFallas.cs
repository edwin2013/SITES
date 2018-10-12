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

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmMantenimientoFallas : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private Falla _tipo = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoFallas()
        {
            InitializeComponent();
            dgvDetalleFallas.DataSource = new BindingList<DetalleFalla>();
            dgvDetalleFallas.AutoGenerateColumns = false;

            cboTipo.ListaMostrada = _mantenimiento.listarTipoFallasBlindadoss();
        }

        public frmMantenimientoFallas(Falla tipo)
        {
            InitializeComponent();
            cboTipo.ListaMostrada = _mantenimiento.listarTipoFallasBlindadoss();
            _tipo = tipo;

            cboTipo.Text = _tipo.Tipo_Falla.ToString();
            cboTipo.Enabled = false;
            txtDescripcion.Text = _tipo.Descripcion;
            dgvDetalleFallas.DataSource = _tipo.Detalle_falla;
            dgvDetalleFallas.AutoGenerateColumns = false;
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
                Excepcion.mostrarMensaje("ErrorTipoErrorCierreDatosRegistro");
                return;
            }

            try
            {
                TipoFallasBlindados tipo = (TipoFallasBlindados)cboTipo.SelectedItem;
                string descripcion = txtDescripcion.Text;

                BindingList<DetalleFalla> fallas = (BindingList<DetalleFalla>)dgvDetalleFallas.DataSource;
                frmAdministracionFallas padre = (frmAdministracionFallas)this.Owner;

                // Verificar si el tipo de error ya está registrado

                if (_tipo == null)
                {
                    // Agregar los datos del tipo de error

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeTipoErrorCierreRegistro") == DialogResult.Yes)
                    {
                        Falla nuevo = new Falla(descripcion:descripcion,tipo:tipo);

                        foreach (DetalleFalla detalle in fallas)
                            nuevo.agregarDetalleFalla(detalle);

                        _mantenimiento.agregarFalla(ref nuevo);

                       // padre.agregarTipoError(nuevo);
                        Mensaje.mostrarMensaje("MensajeTipoErrorCierreConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos del tipo de error

                    Falla copia = new Falla(id:_tipo.ID,descripcion:descripcion,tipo:tipo);

                    foreach (DetalleFalla detalle in fallas)
                        copia.agregarDetalleFalla(detalle);

                    _mantenimiento.actualizarFalla(copia);

                    _tipo.Tipo_Falla = tipo;
                    _tipo.Descripcion = descripcion;



                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeTipoErrorCierreConfirmacionActualizacion");
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
        /// Clic en el botón de agregar un punto de venta.
        /// </summary>
        private void btnAgregarPuntoVenta_Click(object sender, EventArgs e)
        {
            if (txtDetalleFalla.Text.Equals(string.Empty)) return;

            string nombre = txtDetalleFalla.Text;

            DetalleFalla detalle_falla = new DetalleFalla(nombre: nombre);
            BindingList<DetalleFalla> detalles_fallas = (BindingList<DetalleFalla>)dgvDetalleFallas.DataSource;

            detalles_fallas.Add(detalle_falla);

            dgvDetalleFallas.Refresh();
        }

        /// <summary>
        /// Clic en el botón de quitar un punto de venta.
        /// </summary>
        private void btnQuitarPuntoVenta_Click(object sender, EventArgs e)
        {
            dgvDetalleFallas.Rows.Remove(dgvDetalleFallas.SelectedRows[0]);
        }


        /// <summary>
        /// Acciones correspondientes 
        /// </summary>

        private void dgvDetalleFallas_SelectionChanged(object sender, EventArgs e)
        {
            btnQuitarFalla.Enabled = dgvDetalleFallas.RowCount > 0;
        }


        /// <summary>
        /// Actualiza los datos de un detalle de fallas
        /// </summary>
        private void dgvDetalleFallas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgvDetalleFallas.Rows[e.RowIndex];
            DetalleFalla detalle = (DetalleFalla)fila.DataBoundItem;

            try
            {
                _mantenimiento.actualizarDetalleFalla(detalle);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }
        #endregion Eventos

       
    }
}
