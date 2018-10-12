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


namespace ImpresionManifiestos
{

    public partial class frmImpresionManifiestos : Form
    {

        #region Constructor

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private BindingList<Ciudad> _ciudades = null;

        private Font _fuente = new Font("Arial", 10);

        #endregion Constructor

        #region Constructor

        public frmImpresionManifiestos()
        {
            InitializeComponent();

            try
            {
                ManejadorBD.Instancia.conectarse("BCOCURSERV3P\\ASGARD", "Sistema Tesoreria", "UsuarioST", "Credomatic");

                cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);

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
                frmInclusionSucursales formulario = new frmInclusionSucursales(ref cliente);

                formulario.ShowDialog(this);

             //   cboSucursal.ListaMostrada = cliente.Sucursales;
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

             //   cboSucursal.ListaMostrada = cliente.Sucursales;
                btnAgregarSucursal.Enabled = true;
            }
            else
            {
                cboSucursal.ListaMostrada = null;
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
            
            e.Graphics.DrawString("Remesas", _fuente, Brushes.Black, punto(14f, 2.7f)); // Origen de los fondos
            e.Graphics.DrawString("BAC San José", _fuente, Brushes.Black, punto(12.6f, 3.6f)); // Recibo de
            e.Graphics.DrawString("Centro de Distribución Cipreses", _fuente, Brushes.Black, punto(12.6f, 4.5f)); // Dirección
            e.Graphics.DrawString("Curridabat", _fuente, Brushes.Black, punto(11.0f, 5.5f)); // Ciudad
            e.Graphics.DrawString("San josé", _fuente, Brushes.Black, punto(16.7f, 5.5f)); // Provincia
            e.Graphics.DrawString(DateTime.Today.ToShortDateString(), _fuente, Brushes.Black, punto(18.3f, 6.5f));

            // Imprimir los datos variables

            string nombre_sucursal = cboSucursal.Text;

            e.Graphics.DrawString(cboCliente.Text, _fuente, Brushes.Black, punto(12.2f, 7.4f)); // Cliente
            e.Graphics.DrawString(nombre_sucursal, _fuente, Brushes.Black, punto(17f, 7.4f)); // Sucursal
            e.Graphics.DrawString(cboCiudad.Text, _fuente, Brushes.Black, punto(12.2f, 8.3f)); // Dirección
            e.Graphics.DrawString(cboCiudad.Text, _fuente, Brushes.Black, punto(10.7f, 9.1f)); // Ciudad
            e.Graphics.DrawString(cboProvincias.Text, _fuente, Brushes.Black, punto(16f, 9.1f)); // Provincia

            e.Graphics.DrawString(nudTipoCambio.Value.ToString("N2"), _fuente, Brushes.Black, punto(10.5f, 2.0f));
            e.Graphics.DrawString(nudDepositos.Value.ToString("N0"), _fuente, Brushes.Black, punto(13.5f, 2.0f));

            // Imprimir los montos

            float y = 3.5f;

            for (int contador = 0; contador < dgvMontos.Rows.Count - 1; contador++)
            {
                DataGridViewRow fila = dgvMontos.Rows[contador];

                string numero_marchamo = fila.Cells[NumeroMarchamo.Index].Value == null ? string.Empty : (string)fila.Cells[NumeroMarchamo.Index].Value;
                string bt = fila.Cells[BT.Index].Value == null ? string.Empty : (string)fila.Cells[BT.Index].Value;
                int bultos = fila.Cells[Bultos.Index].Value == null ? 0 : (int)fila.Cells[Bultos.Index].Value;
                decimal monto = fila.Cells[Monto.Index].Value == null ? 0 : (decimal)fila.Cells[Monto.Index].Value;
                int cent = fila.Cells[Cent.Index].Value == null ? 0 : (int)fila.Cells[Cent.Index].Value;

                e.Graphics.DrawString(numero_marchamo, _fuente, Brushes.Black, punto(3.0f, y));
                e.Graphics.DrawString(bt, _fuente, Brushes.Black, punto(5.3f, y));
                e.Graphics.DrawString(bultos.ToString("N0"), _fuente, Brushes.Black, punto(5.9f, y));
                e.Graphics.DrawString(monto.ToString("N2"), _fuente, Brushes.Black, punto(6.9f, y));
                e.Graphics.DrawString(cent.ToString("N0"), _fuente, Brushes.Black, punto(9.6f, y));

                y += 0.8f;
            }

            e.Graphics.DrawString(txtTotalBultos.Text, _fuente, Brushes.Black, punto(5.9f, 9));
            e.Graphics.DrawString(txtTotalMonto.Text, _fuente, Brushes.Black, punto(6.9f, 9));
        }

        private PointF punto(float centimetros_x, float centimetros_y)
        {
            float x = (centimetros_x + 0.5f) * 10;
            float y = (centimetros_y) * 10;

            return new PointF(x, y);
        }

        #endregion Métodos Privados

        private void frmImpresionManifiestos_Load(object sender, EventArgs e)
        {

        }

    }

}
