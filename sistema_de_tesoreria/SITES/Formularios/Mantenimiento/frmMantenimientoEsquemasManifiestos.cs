//
//  @ Project : 
//  @ File Name : frmMantenimientoEsquemasManifiestos.cs
//  @ Date : 03/07/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmMantenimientoEsquemasManifiestos : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private EsquemaManifiesto _esquema = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoEsquemasManifiestos()
        {
            InitializeComponent();

            dgvPosiciones.AutoGenerateColumns = false;
            dgvPosiciones.DataSource = new BindingList<PosicionEsquema>();

            try
            {
                cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        public frmMantenimientoEsquemasManifiestos(EsquemaManifiesto esquema)
        {
            InitializeComponent();

            _esquema = esquema;

            nudAncho.Value = (decimal)_esquema.Ancho;
            nudAlto.Value = (decimal)_esquema.Alto;

            dgvPosiciones.AutoGenerateColumns = false;
            dgvPosiciones.DataSource = _esquema.Posiciones;

            try
            {
                cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();

                cboTransportadora.Text = _esquema.Transportadora.Nombre;
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
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

            if (cboTransportadora.SelectedItem == null)
            {
                Excepcion.mostrarMensaje("ErrorEsquemaManifiestoDatosRegistro");
                return;
            }

            try
            {
                frmAdministracionEsquemasManifiestos padre = (frmAdministracionEsquemasManifiestos)this.Owner;

                EmpresaTransporte transportadora = (EmpresaTransporte)cboTransportadora.SelectedItem;

                decimal ancho = nudAncho.Value;
                decimal alto = nudAlto.Value;

                BindingList<PosicionEsquema> posiciones = (BindingList<PosicionEsquema>)dgvPosiciones.DataSource;

                // Verificar si el esquema es nuevo

                if (_esquema == null)
                {
                    // Agregar los datos del nuevo esquema

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeEsquemaManifiestoRegistro") == DialogResult.Yes)
                    {
                        EsquemaManifiesto nuevo = new EsquemaManifiesto(transportadora: transportadora, ancho: ancho, alto: alto);

                        nuevo.Posiciones = posiciones;

                        _mantenimiento.agregarEsquemaManifiesto(ref nuevo);

                        padre.agregarEsquema(nuevo);
                        Mensaje.mostrarMensaje("MensajeEsquemaManifiestoConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    EsquemaManifiesto copia = new EsquemaManifiesto(id: _esquema.ID, transportadora: transportadora, ancho: ancho, alto: alto);

                    copia.Posiciones = posiciones;

                    // Actualizar los datos del esquema

                    _mantenimiento.actualizarEsquemaManifiesto(copia);

                    _esquema.Transportadora = transportadora;
                    _esquema.Ancho = ancho;
                    _esquema.Alto = alto;
                    _esquema.Posiciones = copia.Posiciones;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeEsquemaManifiestoConfirmacionActualizacion");
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

            PosicionEsquema posicion = new PosicionEsquema(descripcion);

            BindingList<PosicionEsquema> posiciones = (BindingList<PosicionEsquema>)dgvPosiciones.DataSource;

            posiciones.Add(posicion);

            txtDescripcion.Text = string.Empty;
        }

        /// <summary>
        /// Clic en el botón de quitar posición.
        /// </summary>
        private void btnQuitarPosicion_Click(object sender, EventArgs e)
        {
            dgvPosiciones.Rows.Remove(dgvPosiciones.SelectedCells[0].OwningRow);
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

            if (dgvPosiciones.RowCount > 0)
            {
                DataGridViewRow fila = dgvPosiciones.Rows[e.RowIndex];
                PosicionEsquema posicion = (PosicionEsquema)fila.DataBoundItem;

                try
                {
                    _mantenimiento.actualizarPosicionEsquema(posicion);
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

                dgvPosiciones.Refresh();
            }

        }

        /// <summary>
        /// Se selecciona otra posición.
        /// </summary>
        private void dgvPosiciones_SelectionChanged(object sender, EventArgs e)
        {
            btnQuitarPosicion.Enabled = dgvPosiciones.RowCount > 0;
        }

        /// <summary>
        /// Se cambia el texto de la descripción.
        /// </summary>
        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            btnAgregarPosicion.Enabled = txtDescripcion.Text.Length > 0;
        }

        #endregion Eventos

    }

}
