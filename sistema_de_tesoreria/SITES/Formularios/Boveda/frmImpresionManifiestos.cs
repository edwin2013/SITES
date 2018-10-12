//
//  @ Project : 
//  @ File Name : frmImpresionManifiestos.cs
//  @ Date : 06/10/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using LibreriaAccesoDatos;


namespace GUILayer
{

    public partial class frmImpresionManifiestos : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private BindingList<Ciudad> _ciudades = null;

        private EsquemaManifiesto _esquema = null;

        private Font _fuente = new Font("Arial", 10);

        #endregion Atributos

        #region Constructor

        public frmImpresionManifiestos()
        {
            InitializeComponent();

            try
            {
                cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);
                cboEsquema.ListaMostrada = _mantenimiento.listarEsquemasManifiestos();

                _ciudades = _mantenimiento.listarCiudades();

                cboProvincias.SelectedIndex = 0;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de imprimir.
        /// </summary
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (cboEsquema.SelectedItem == null)
                return;
            else
                _esquema = (EsquemaManifiesto)cboEsquema.SelectedItem;

            pdManifiesto.DefaultPageSettings.Margins.Left = 0;
            pdManifiesto.DefaultPageSettings.Margins.Top = 0;
            pdManifiesto.DefaultPageSettings.Margins.Right = 0;
            pdManifiesto.DefaultPageSettings.Margins.Bottom = 0;

            pdManifiesto.Print();
        }

        /// <summary>
        /// Clic en el botón de agregar ciudad.
        /// </summary
        private void btnAgregarCiudad_Click(object sender, EventArgs e)
        {

            try
            {
                frmInclusionCiudades formulario = new frmInclusionCiudades();

                formulario.ShowDialog(this);

                _ciudades = _mantenimiento.listarCiudades();

                this.validarCiudades();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de agregar sucursal.
        /// </summary
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
        /// </summary
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se selecciona otro cliente.
        /// </summary
        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboCliente.SelectedItem != null)
            {
                Cliente cliente = (Cliente)cboCliente.SelectedItem;

                cboPuntoVenta.ListaMostrada = cliente.Puntos_venta;
                btnAgregarSucursal.Enabled = true;
            }
            else
            {
                cboPuntoVenta.ListaMostrada = null;
                btnAgregarSucursal.Enabled = false;
            }

        }

        /// <summary>
        /// Validar los valores de las celdas.
        /// </summary
        private void dgvMontos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell celda = dgvMontos[e.ColumnIndex, e.RowIndex];

            if (e.ColumnIndex == Monto.Index)
            {
                decimal valor = 0;

                decimal.TryParse(celda.Value.ToString(), out valor);
                celda.Value = valor;
            }
            else if (e.ColumnIndex == Bultos.Index || e.ColumnIndex == Cent.Index)
            {
                int valor = 0;
                string cadena = celda.Value != null ? celda.Value.ToString() : string.Empty;

                int.TryParse(cadena, out valor);
                celda.Value = valor;
            }

            if (e.ColumnIndex == Monto.Index || e.ColumnIndex == Bultos.Index)
            {
                decimal total_montos = 0;
                int total_bultos = 0;

                foreach (DataGridViewRow fila in dgvMontos.Rows)
                {
                    decimal monto = fila.Cells[Monto.Index].Value == null ? 0 : (decimal)fila.Cells[Monto.Index].Value;
                    int bultos = fila.Cells[Bultos.Index].Value == null ? 0 : (int)fila.Cells[Bultos.Index].Value;

                    total_montos += monto;
                    total_bultos += bultos;
                }

                txtTotalBultos.Text = total_bultos.ToString("N0");
                txtTotalMonto.Text = total_montos.ToString("N2");
            }

        }

        /// <summary>
        /// Se selecciona otra provincia.
        /// </summary
        private void cboProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.validarCiudades();
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Validar las ciudades que se mostrarán según la provincia seleccionada.
        /// </summary
        private void validarCiudades()
        {
            Provincias provincia = (Provincias)cboProvincias.SelectedIndex;
            BindingList<Ciudad> ciudades = new BindingList<Ciudad>();

            foreach (Ciudad ciudad in _ciudades)
            {

                if (ciudad.Provincia.Equals(provincia))
                    ciudades.Add(ciudad);

            }

            cboCiudad.ListaMostrada = ciudades;
        }

        /// <summary>
        /// Imprimir el manifiesto.
        /// </summary
        private void pdManifiesto_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;

            // Imprimir los datos fijos

            e.Graphics.DrawString("Remesas", _fuente, Brushes.Black, _esquema.obtenerPunto(3, 0)); // Origen de los fondos
            e.Graphics.DrawString("BAC San José", _fuente, Brushes.Black, _esquema.obtenerPunto(4, 0)); // Recibo de
            e.Graphics.DrawString("Centro de Distribución Cipreses", _fuente, Brushes.Black, _esquema.obtenerPunto(5, 0)); // Dirección
            e.Graphics.DrawString("Curridabat", _fuente, Brushes.Black, _esquema.obtenerPunto(6, 0)); // Ciudad
            e.Graphics.DrawString("San josé", _fuente, Brushes.Black, _esquema.obtenerPunto(7, 0)); // Provincia
            e.Graphics.DrawString(DateTime.Today.ToShortDateString(), _fuente, Brushes.Black, _esquema.obtenerPunto(8, 0)); // Fecha

            // Imprimir los datos variables

            string punto_venta = cboPuntoVenta.Text;

            e.Graphics.DrawString(cboCliente.Text, _fuente, Brushes.Black, _esquema.obtenerPunto(9, 0)); // Cliente
            e.Graphics.DrawString(punto_venta, _fuente, Brushes.Black, _esquema.obtenerPunto(10, 0)); // Oficina
            e.Graphics.DrawString(cboCiudad.Text, _fuente, Brushes.Black, _esquema.obtenerPunto(11, 0)); // Dirección
            e.Graphics.DrawString(cboCiudad.Text, _fuente, Brushes.Black, _esquema.obtenerPunto(12, 0)); // Ciudad
            e.Graphics.DrawString(cboProvincias.Text, _fuente, Brushes.Black, _esquema.obtenerPunto(13, 0)); // Provincia

            e.Graphics.DrawString(nudTipoCambio.Value.ToString("N2"), _fuente, Brushes.Black, _esquema.obtenerPunto(1, 0)); // Tipo de Cambio
            e.Graphics.DrawString(nudDepositos.Value.ToString("N0"), _fuente, Brushes.Black, _esquema.obtenerPunto(2, 0)); // Depositos

            // Imprimir los montos

            for (int contador = 0; contador < dgvMontos.Rows.Count - 1; contador++)
            {
                DataGridViewRow fila = dgvMontos.Rows[contador];

                string numero_marchamo = fila.Cells[NumeroMarchamo.Index].Value == null ? string.Empty : (string)fila.Cells[NumeroMarchamo.Index].Value;
                string bt = fila.Cells[BT.Index].Value == null ? string.Empty : (string)fila.Cells[BT.Index].Value;
                int bultos = fila.Cells[Bultos.Index].Value == null ? 0 : (int)fila.Cells[Bultos.Index].Value;
                decimal monto = fila.Cells[Monto.Index].Value == null ? 0 : (decimal)fila.Cells[Monto.Index].Value;
                int cent = fila.Cells[Cent.Index].Value == null ? 0 : (int)fila.Cells[Cent.Index].Value;

                e.Graphics.DrawString(numero_marchamo, _fuente, Brushes.Black, _esquema.obtenerPunto(14, contador));
                e.Graphics.DrawString(bt, _fuente, Brushes.Black, _esquema.obtenerPunto(15, contador));
                e.Graphics.DrawString(bultos.ToString("N0"), _fuente, Brushes.Black, _esquema.obtenerPunto(16, contador));
                e.Graphics.DrawString(monto.ToString("N2"), _fuente, Brushes.Black, _esquema.obtenerPunto(17, contador));
                e.Graphics.DrawString(cent.ToString("N0"), _fuente, Brushes.Black, _esquema.obtenerPunto(18, contador));
            }

            e.Graphics.DrawString(txtTotalBultos.Text, _fuente, Brushes.Black, _esquema.obtenerPunto(19, 0)); // Total de bultos
            e.Graphics.DrawString(txtTotalMonto.Text, _fuente, Brushes.Black, _esquema.obtenerPunto(20, 0)); // Total de montos
        }

        #endregion Métodos Privados

    }

}
