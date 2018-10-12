//
//  @ Project : 
//  @ File Name : frmAdministracionGestiones.cs
//  @ Date : 18/08/2011
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

    public partial class frmAdministracionGestiones : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<Gestion> _gestiones = new BindingList<Gestion>();

        private bool _coordinador_operativo = false;

        #endregion Atributos

        #region Constructor

        public frmAdministracionGestiones(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador_operativo = coordinador.Puestos.Contains(Puestos.CoordinadorOperativo);

            btnTerminar.Visible = _coordinador_operativo;

            try
            {
                // Cargar la lista de clientes y las gestiones

                cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);

                if (cboCliente.Items.Count > 0) cboCliente.SelectedIndex = 0;

                // Generar la lista de gestiones

                bool terminadas = _coordinador_operativo;

                _gestiones = _coordinacion.listarGestiones();

                dgvGestiones.AutoGenerateColumns = false;
                dgvGestiones.DataSource = _gestiones;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.filtrarPorCliente();
        }

        /// <summary>
        /// Clic en el botón de nueva gestión.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmInclusionGestiones formulario = new frmInclusionGestiones();

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de modificar.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Clic en el botón de eliminar.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeGestionEliminacion") == DialogResult.Yes)
                {
                    Gestion gestion = (Gestion)dgvGestiones.SelectedRows[0].DataBoundItem;

                    _coordinacion.eliminarGestion(gestion);

                    this.eliminarGestion(gestion);

                    Mensaje.mostrarMensaje("MensajeGestionConfirmacionEliminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de terminar.
        /// </summary>
        private void btnTerminar_Click(object sender, EventArgs e)
        {

            try
            {
                Gestion gestion = (Gestion)dgvGestiones.SelectedRows[0].DataBoundItem;
                frmTerminacionGestiones formulario = new frmTerminacionGestiones(gestion);

                formulario.ShowDialog(this);
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
        /// Doble clic en la lista de gestiones.
        /// </summary>
        private void dgvGestiones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostarVentanaModificacion();
        }

        /// <summary>
        /// Se selecciona otra gestion.
        /// </summary>
        private void dgvGestiones_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvGestiones.RowCount > 0)
            {
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                btnTerminar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnTerminar.Enabled = false;
            }

        }

        /// <summary>
        /// Se da formato a las filas.
        /// </summary>
        private void dgvGestiones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex == ID.Index)
            {
                Gestion gestion = (Gestion)dgvGestiones.Rows[e.RowIndex].DataBoundItem;

                // Depositos

                string depositos = string.Empty;

                foreach (Deposito deposito in gestion.Depositos)
                    depositos += deposito.Referencia.ToString() + '\n';

                dgvGestiones[Depositos.Index, e.RowIndex].Value = depositos.TrimEnd('\n');

                // Manifiestos

                string manifiestos = string.Empty;

                foreach (Manifiesto manifiesto in gestion.Manifiestos)
                    manifiestos += manifiesto.Codigo + '\n';

                dgvGestiones[Manifiestos.Index, e.RowIndex].Value = manifiestos.TrimEnd('\n');

                // Tulas

                string tulas = string.Empty;

                foreach (Tula tula in gestion.Tulas)
                    tulas += tula.Codigo + '\n';

                dgvGestiones[Tulas.Index, e.RowIndex].Value = tulas.TrimEnd('\n');

                // Cliente

                string cliente = string.Empty;

                cliente = gestion.Punto_venta.Cliente.Nombre + ", " + gestion.Punto_venta.Nombre;

                dgvGestiones[Cliente.Index, e.RowIndex].Value = cliente;
            }

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Filtrar las gestiones por cliente.
        /// </summary>
        private void filtrarPorCliente()
        {

            if (cboCliente.SelectedIndex == 0 || cboCliente.SelectedItem == null)
            {
                dgvGestiones.DataSource = _gestiones;
            }
            else
            {
                BindingList<Gestion> gestiones = new BindingList<Gestion>();
                Cliente cliente = (Cliente)cboCliente.SelectedItem;

                foreach (Gestion gestion in _gestiones)
                    if (gestion.Punto_venta.Cliente.Equals(cliente)) gestiones.Add(gestion);

                dgvGestiones.DataSource = gestiones;
            }

            dgvGestiones.AutoResizeColumns();
        }

        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        private void mostarVentanaModificacion()
        {

            try
            {
                Gestion gestion = (Gestion)dgvGestiones.SelectedRows[0].DataBoundItem;

                frmInclusionGestiones formulario = new frmInclusionGestiones(gestion);
                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Métodos Privados

        #region Métodos Públicos

        /// <summary>
        /// Actualizar los valores de la lista.
        /// </summary>
        public void actualizarLista()
        {
            dgvGestiones.Refresh();
            dgvGestiones.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar una gestión a la lista.
        /// </summary>
        public void agregarGestion(Gestion gestion)
        {
            BindingList<Gestion> gestiones = (BindingList<Gestion>)dgvGestiones.DataSource;

            gestiones.Add(gestion);
            dgvGestiones.AutoResizeColumns();
        }

        /// <summary>
        /// Eliminar una gestión a la lista.
        /// </summary>
        public void eliminarGestion(Gestion gestion)
        {
            BindingList<Gestion> gestiones = (BindingList<Gestion>)dgvGestiones.DataSource;

            gestiones.Remove(gestion);
            dgvGestiones.AutoResizeColumns();
        }

        #endregion Métodos Públicos

    }

}
