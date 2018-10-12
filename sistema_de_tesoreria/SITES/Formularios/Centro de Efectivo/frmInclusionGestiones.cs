//
//  @ Project : 
//  @ File Name : frmInclusionGestiones.cs
//  @ Date : 18/08/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{
    public partial class frmInclusionGestiones : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;

        private Gestion _gestion = null;

        #endregion Atributos

        #region Constructor

        public frmInclusionGestiones()
        {
            InitializeComponent();

            try
            {
                this.cargarDatos();

                dgvManifiestos.AutoGenerateColumns = false;
                dgvManifiestos.DataSource = new BindingList<ManifiestoCEF>();

                dgvTulas.AutoGenerateColumns = false;
                dgvTulas.DataSource = new BindingList<Tula>();

                dgvDepositos.AutoGenerateColumns = false;
                dgvDepositos.DataSource = new BindingList<Deposito>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public frmInclusionGestiones(Gestion gestion)
        {
            InitializeComponent();

            _gestion = gestion;

            try
            {
                this.cargarDatos();

                cboCliente.Text = _gestion.Punto_venta.Cliente.Nombre;
                cboPuntoVenta.Text = _gestion.Punto_venta.Nombre;
                cboGestion.Text = _gestion.Tipo.Nombre;
                txtComentario.Text = _gestion.Comentario;
                nudMonto.Value = _gestion.Monto;

                dgvManifiestos.AutoGenerateColumns = false;
                dgvManifiestos.DataSource = _gestion.Manifiestos;

                dgvTulas.AutoGenerateColumns = false;
                dgvTulas.DataSource = _gestion.Tulas;

                dgvDepositos.AutoGenerateColumns = false;
                dgvDepositos.DataSource = _gestion.Depositos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Cargar los datos de las listas.
        /// </summary>
        private void cargarDatos()
        {

            try
            {
                // Cargar las listas

                cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);
                cboGestion.ListaMostrada = _mantenimiento.listarTiposGestion();

                // Establecer el separador de decimales

                CultureInfo anterior = System.Threading.Thread.CurrentThread.CurrentCulture;
                CultureInfo nueva = (CultureInfo)anterior.Clone();

                nueva.NumberFormat.NumberDecimalSeparator = ".";
                nueva.NumberFormat.NumberGroupSeparator = ",";
                System.Threading.Thread.CurrentThread.CurrentCulture = nueva;

                CultureInfo cultura = System.Threading.Thread.CurrentThread.CurrentCulture;
            }
            catch (Excepcion ex)
            {
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

            if (cboPuntoVenta.SelectedItem == null || cboGestion.SelectedItem == null)
            {
                Excepcion.mostrarMensaje("ErrorGestionDatosRegistro");
                return;
            }

            try
            {
                frmAdministracionGestiones padre = (frmAdministracionGestiones)this.Owner;

                TipoGestion tipo = (TipoGestion)cboGestion.SelectedItem;
                PuntoVenta punto_venta = (PuntoVenta)cboPuntoVenta.SelectedItem;
                DateTime fecha = DateTime.Now;
                string comentario = txtComentario.Text;
                decimal monto = nudMonto.Value;

                BindingList<Deposito> depositos = (BindingList<Deposito>)dgvDepositos.DataSource;
                BindingList<ManifiestoCEF> manifiestos = (BindingList<ManifiestoCEF>)dgvManifiestos.DataSource;
                BindingList<Tula> tulas = (BindingList<Tula>)dgvTulas.DataSource;

                // Verificar si la gestión ya está registrada

                if (_gestion == null)
                {
                    // Agregar los datos de la gestión

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeGestionRegistro") == DialogResult.Yes)
                    {
                        Gestion nueva = new Gestion(punto_venta: punto_venta, monto: monto, tipo: tipo, fecha: fecha,
                                                    comentario: comentario);

                        foreach (Deposito deposito in depositos)
                            nueva.agregarDeposito(deposito);

                        foreach (ManifiestoCEF manifiesto in manifiestos)
                            nueva.agregarManifiesto(manifiesto);

                        foreach (Tula tula in tulas)
                            nueva.agregarTula(tula);

                        _coordinacion.agregarGestion(ref nueva);

                        padre.agregarGestion(nueva);
                        Mensaje.mostrarMensaje("MensajeGestionConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la gestión

                    Gestion copia = new Gestion(id: _gestion.ID, punto_venta: punto_venta, monto: monto, tipo: tipo,
                                                comentario: comentario);

                    foreach (Deposito deposito in depositos)
                        copia.agregarDeposito(deposito);

                    foreach (ManifiestoCEF manifiesto in manifiestos)
                        copia.agregarManifiesto(manifiesto);

                    foreach (Tula tula in tulas)
                        copia.agregarTula(tula);

                    _coordinacion.actualizarGestion(copia);

                    _gestion.Punto_venta = punto_venta;
                    _gestion.Tipo = tipo;
                    _gestion.Comentario = comentario;
                    _gestion.Depositos = depositos;
                    _gestion.Manifiestos = manifiestos;
                    _gestion.Tulas = tulas;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeGestionConfirmacionActualizacion");
                    this.Close();
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de agregar tula.
        /// </summary>
        private void btnAgregarTula_Click(object sender, EventArgs e)
        {
            Tula tula = new Tula(txtTula.Text);

            BindingList<Tula> tulas = (BindingList<Tula>)dgvTulas.DataSource;

            tulas.Add(tula);
        }

        /// <summary>
        /// Clic en el botón de quitar tula.
        /// </summary>
        private void btnQuitarTula_Click(object sender, EventArgs e)
        {
            dgvTulas.Rows.Remove(dgvTulas.SelectedRows[0]);
        }

        /// <summary>
        /// Clic en el botón de agregar deposito.
        /// </summary>
        private void btnAgregarDeposito_Click(object sender, EventArgs e)
        {
            int referencia = int.Parse(mtbDeposito.Text);
            Deposito deposito = new Deposito(referencia);

            BindingList<Deposito> depositos = (BindingList<Deposito>)dgvDepositos.DataSource;

            depositos.Add(deposito);
        }

        /// <summary>
        /// Clic en el botón de quitar deposito.
        /// </summary>
        private void btnQuitarDeposito_Click(object sender, EventArgs e)
        {
            dgvDepositos.Rows.Remove(dgvDepositos.SelectedRows[0]);
        }

        /// <summary>
        /// Clic en el botón de agregar manifiesto.
        /// </summary>
        private void btnAgregarManifiesto_Click(object sender, EventArgs e)
        {
            ManifiestoCEF manifiesto = new ManifiestoCEF(txtManifiesto.Text);

            BindingList<ManifiestoCEF> manifiestos = (BindingList<ManifiestoCEF>)dgvManifiestos.DataSource;

            manifiestos.Add(manifiesto);
        }

        /// <summary>
        /// Clic en el botón de quitar manifiesto.
        /// </summary>
        private void btnQuitarManifiesto_Click(object sender, EventArgs e)
        {
            dgvManifiestos.Rows.Remove(dgvManifiestos.SelectedRows[0]);
        }

        /// <summary>
        /// Clic en el botón de agregar un punto de venta para un cliente.
        /// </summary>
        private void btnAgregarSucursal_Click(object sender, EventArgs e)
        {

            try
            {
                Cliente cliente = (Cliente)cboCliente.SelectedItem;
                frmInclusionPuntosVenta formulario = new frmInclusionPuntosVenta(ref cliente);

                formulario.ShowDialog(this);

                cboPuntoVenta.ListaMostrada = cliente.Puntos_venta;
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
        /// Se selecciona otro cliente.
        /// </summary>
        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboCliente.SelectedItem != null)
            {
                Cliente cliente = (Cliente)cboCliente.SelectedItem;

                cboPuntoVenta.ListaMostrada = cliente.Puntos_venta;
            }
            else
            {
                cboPuntoVenta.ListaMostrada = null;
            }

        }

        /// <summary>
        /// Se cambia el código del manifiesto.
        /// </summary>
        private void txtManifiesto_TextChanged(object sender, EventArgs e)
        {
            btnAgregarManifiesto.Enabled = txtManifiesto.Text.Length > 0;
        }

        /// <summary>
        /// Se cambia la referencia del deposito.
        /// </summary>
        private void mtbDeposito_TextChanged(object sender, EventArgs e)
        {
            btnAgregarDeposito.Enabled = mtbDeposito.Text.Length > 0;
        }

        /// <summary>
        /// Se cambia el código de la tula.
        /// </summary>
        private void txtTula_TextChanged(object sender, EventArgs e)
        {
            btnAgregarTula.Enabled = txtTula.Text.Length > 0;
        }

        /// <summary>
        /// Se selecciona una tula de la lista de tulas.
        /// </summary>
        private void dgvTulas_SelectionChanged(object sender, EventArgs e)
        {
            btnQuitarTula.Enabled = dgvTulas.SelectedRows.Count > 0;
        }

        /// <summary>
        /// Se selecciona un deposito de la lista de depositos.
        /// </summary>
        private void dgvDepositos_SelectionChanged(object sender, EventArgs e)
        {
            btnQuitarDeposito.Enabled = dgvDepositos.SelectedRows.Count > 0;
        }

        /// <summary>
        /// Se selecciona un manifiesto de la lista de manifiestos.
        /// </summary>
        private void dgvManifiestos_SelectionChanged(object sender, EventArgs e)
        {
            btnQuitarManifiesto.Enabled = dgvManifiestos.SelectedRows.Count > 0;
        }

        #endregion Eventos

    }

}
