//
//  @ Project : 
//  @ File Name : frmRegistroModificacionRecap.cs
//  @ Date : 19/03/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;
using System.Globalization;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{
    
    public partial class frmRegistroModificacionRecap : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        
        private Manifiesto _manifiesto = null;
        private RecapExterno _recap = null;

        private int[] _denominaciones_colones = { 50000, 20000, 10000, 5000, 2000, 1000 };
        private int[] _denominaciones_dolares = { 100, 50, 20, 10, 5, 1 };
        private int[] _denominaciones_euros = { 100, 50, 20, 10, 5, 1 };

        #endregion Atributos

        #region Constructor

        public frmRegistroModificacionRecap(Manifiesto manifiesto, RecapExterno recap)
        {
            InitializeComponent();

            _manifiesto = manifiesto;
            _recap = recap;

            mtbReferencia.Text = _recap.Referencia.ToString();

            if (_recap.Cuenta == null)
            {
                chkCuenta.Checked = true;
                mtbCuenta.Text = string.Empty;
            }
            else
            {
                chkCuenta.Checked = true;
                mtbCuenta.Text = _recap.Cuenta.ToString();
            }

            chkATM.Checked = _recap.ATM;
            chkMatriz.Checked = _recap.Matriz;
            cboMoneda.SelectedIndex = (byte)_recap.Moneda;

            switch (recap.Moneda)
            {
                case Monedas.Colones:
                    dgvMontos[Monto.Index, 0].Value = recap.Colones_cincuenta_mil;
                    dgvMontos[Monto.Index, 1].Value = recap.Colones_veinte_mil;
                    dgvMontos[Monto.Index, 2].Value = recap.Colones_diez_mil;
                    dgvMontos[Monto.Index, 3].Value = recap.Colones_cinco_mil;
                    dgvMontos[Monto.Index, 4].Value = recap.Colones_dos_mil;
                    dgvMontos[Monto.Index, 5].Value = recap.Colones_mil;
                    break;
                case Monedas.Dolares:
                    dgvMontos[Monto.Index, 0].Value = recap.Dolares_cien;
                    dgvMontos[Monto.Index, 1].Value = recap.Dolares_cincuenta;
                    dgvMontos[Monto.Index, 2].Value = recap.Dolares_veinte;
                    dgvMontos[Monto.Index, 3].Value = recap.Dolares_diez;
                    dgvMontos[Monto.Index, 4].Value = recap.Dolares_cinco;
                    dgvMontos[Monto.Index, 5].Value = recap.Dolares_uno;
                    break;
                case Monedas.Euros:
                    dgvMontos[Monto.Index, 0].Value = recap.Euros_cien;
                    dgvMontos[Monto.Index, 1].Value = recap.Euros_cincuenta;
                    dgvMontos[Monto.Index, 2].Value = recap.Euros_veinte;
                    dgvMontos[Monto.Index, 3].Value = recap.Euros_diez;
                    dgvMontos[Monto.Index, 4].Value = recap.Euros_cinco;
                    break;
            }

        }

        public frmRegistroModificacionRecap(Manifiesto manifiesto)
        {
            InitializeComponent();

            _manifiesto = manifiesto;

            cboMoneda.SelectedIndex = (byte)Monedas.Colones;

            this.crearTablaColones();
            this.establecerFormato();
        }

        /// <summary>
        /// Establecer el separador de decimales.
        /// </summary>
        private void establecerFormato()
        {
            CultureInfo anterior = System.Threading.Thread.CurrentThread.CurrentCulture;
            CultureInfo nueva = (CultureInfo)anterior.Clone();

            nueva.NumberFormat.NumberDecimalSeparator = ".";
            nueva.NumberFormat.NumberGroupSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture = nueva;

            CultureInfo cultura = System.Threading.Thread.CurrentThread.CurrentCulture;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                frmAsignacionMontosBoveda padre = (frmAsignacionMontosBoveda)this.Owner;

                decimal colones_cincuenta_mil = 0;
                decimal colones_veinte_mil = 0;
                decimal colones_diez_mil = 0;
                decimal colones_cinco_mil = 0;
                decimal colones_dos_mil = 0;
                decimal colones_mil = 0;

                decimal dolares_cien = 0;
                decimal dolares_cincuenta = 0;
                decimal dolares_veinte = 0;
                decimal dolares_diez = 0;
                decimal dolares_cinco = 0;
                decimal dolares_uno = 0;

                decimal euros_cien = 0;
                decimal euros_cincuenta = 0;
                decimal euros_veinte = 0;
                decimal euros_diez = 0;
                decimal euros_cinco = 0;

                switch ((Monedas)cboMoneda.SelectedIndex)
                {
                    case Monedas.Colones:
                        colones_cincuenta_mil = Convert.ToDecimal(dgvMontos[Monto.Index, 0].Value);
                        colones_veinte_mil = Convert.ToDecimal(dgvMontos[Monto.Index, 1].Value);
                        colones_diez_mil = Convert.ToDecimal(dgvMontos[Monto.Index, 2].Value);
                        colones_cinco_mil = Convert.ToDecimal(dgvMontos[Monto.Index, 3].Value);
                        colones_dos_mil = Convert.ToDecimal(dgvMontos[Monto.Index, 4].Value);
                        colones_mil = Convert.ToDecimal(dgvMontos[Monto.Index, 5].Value);
                        break;
                    case Monedas.Dolares:
                        dolares_cien = Convert.ToDecimal(dgvMontos[Monto.Index, 0].Value);
                        dolares_cincuenta = Convert.ToDecimal(dgvMontos[Monto.Index, 1].Value);
                        dolares_veinte = Convert.ToDecimal(dgvMontos[Monto.Index, 2].Value);
                        dolares_diez = Convert.ToDecimal(dgvMontos[Monto.Index, 3].Value);
                        dolares_cinco = Convert.ToDecimal(dgvMontos[Monto.Index, 4].Value);
                        dolares_uno = Convert.ToDecimal(dgvMontos[Monto.Index, 5].Value);
                        break;
                    case Monedas.Euros:
                        euros_cien = Convert.ToDecimal(dgvMontos[Monto.Index, 0].Value);
                        euros_cincuenta = Convert.ToDecimal(dgvMontos[Monto.Index, 1].Value);
                        euros_veinte = Convert.ToDecimal(dgvMontos[Monto.Index, 2].Value);
                        euros_diez = Convert.ToDecimal(dgvMontos[Monto.Index, 3].Value);
                        euros_cinco = Convert.ToDecimal(dgvMontos[Monto.Index, 4].Value);
                        break;
                }

                // Si el recap es nuevo

                if (_recap == null)
                {
                    // Agregar el recap
                    /*
                    if (Mensaje.mostrarMensajeConfirmacion("MensajeRecapRegistro") == DialogResult.Yes)
                    { 
                        RecapExterno nuevo = new RecapExterno(nombre, nombre_fantasia, cif, contrato_transporte, solicitud_remesas, contacto);
                       
                        _manejador.agregarCliente(ref nuevo);
                        padre.agregarCliente(nuevo);

                        Mensaje.mostrarMensaje("MensajeRecapConfirmacionRegistro");
                        this.Close();
                    }
                        */
                }
                else
                {/*
                    RecapExterno copia = new RecapExterno(_cliente.Id, cif, nombre, nombre_fantasia, contrato_transporte, solicitud_remesas, contacto);

                    _manejador.actualizarCliente(copia);

                    // Actualizar el cliente

                    _cliente.Cif = cif;
                    _cliente.Nombre = nombre;
                    _cliente.Nombre_fantasia = nombre_fantasia;
                    _cliente.Solicitud_remesas = solicitud_remesas;
                    _cliente.Contrato_transporte = contrato_transporte;
                    _cliente.Cuentas = copia.Cuentas;
                    _cliente.Telefonos = copia.Telefonos;
                    _cliente.Correos = copia.Correos;
                    _cliente.Puntos_venta = copia.Puntos_venta;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeRecapConfirmacionActualizacion");
                    this.Close();*/
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
        /// Se selecciona otra moneda.
        /// </summary>
        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((Monedas)cboMoneda.SelectedIndex)
            {
                case Monedas.Colones:
                    this.crearTablaColones();
                    break;
                case Monedas.Dolares:
                    this.crearTablaDolares();
                    break;
                case Monedas.Euros:
                    this.crearTablaEuros();
                    break;
            }

        }

        /// <summary>
        /// Se modifica una fila de los montos.
        /// </summary
        private void dgvMontos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Denominacion.Index || e.ColumnIndex == Cantidad.Index) return;

            int ultima_fila = dgvMontos.RowCount - 1;

            DataGridViewCell celda_monto = dgvMontos[Monto.Index, e.RowIndex];
            DataGridViewCell celda_cantidad = dgvMontos[Cantidad.Index, e.RowIndex];
            DataGridViewCell celda_monto_total = dgvMontos[Monto.Index, ultima_fila];
            DataGridViewCell celda_cantidad_total = dgvMontos[Cantidad.Index, ultima_fila];

            decimal monto = 0;
            decimal monto_total = 0;
            int cantidad = 0;
            int cantidad_total = 0;

            if (!decimal.TryParse(celda_monto.Value.ToString(), out monto))
                celda_monto.Value = monto;

            switch ((Monedas)cboMoneda.SelectedIndex)
            {
                case Monedas.Colones:
                    cantidad = (int)monto / _denominaciones_colones[e.RowIndex];
                    break;
                case Monedas.Dolares:
                    cantidad = (int)monto / _denominaciones_colones[e.RowIndex];
                    break;
                case Monedas.Euros:
                    cantidad = (int)monto / _denominaciones_colones[e.RowIndex];
                    break;
            }

            celda_cantidad.Value = cantidad;

            // Calcular los totales

            for (int contador = 0; contador < ultima_fila; contador++)
            {
                celda_monto = dgvMontos[Monto.Index, contador];
                celda_cantidad = dgvMontos[Cantidad.Index, contador];

                monto = 0;
                cantidad = 0;

                decimal.TryParse(celda_monto.Value.ToString(), out monto);
                int.TryParse(celda_cantidad.Value.ToString(), out cantidad);

                monto_total += monto;
                cantidad_total += cantidad;
            }

            celda_monto_total.Value = monto_total;
            celda_cantidad_total.Value = cantidad_total;
        }

        /// <summary>
        /// Se marca o desmarca la opción de asignar una cuenta al recap.
        /// </summary
        private void chkCuenta_CheckedChanged(object sender, EventArgs e)
        {
            mtbCuenta.Enabled = chkCuenta.Checked;
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Crear las filas de colones del DataGridView.
        /// </summary>
        private void crearTablaColones()
        {
            dgvMontos.Rows.Clear();

            dgvMontos.Rows.Add("50.000", 0, 0);
            dgvMontos.Rows.Add("20.000", 0, 0);
            dgvMontos.Rows.Add("10.000", 0, 0);
            dgvMontos.Rows.Add("5.000", 0, 0);
            dgvMontos.Rows.Add("2.000", 0, 0);
            dgvMontos.Rows.Add("1.000", 0, 0);
            dgvMontos.Rows.Add("Total", 0, 0);

            dgvMontos.Rows[6].ReadOnly = true;
        }

        /// <summary>
        /// Crear las filas de dólares del DataGridView.
        /// </summary>
        private void crearTablaDolares()
        {
            dgvMontos.Rows.Clear();

            dgvMontos.Rows.Add("100", 0);
            dgvMontos.Rows.Add("50", 0);
            dgvMontos.Rows.Add("20", 0);
            dgvMontos.Rows.Add("10", 0);
            dgvMontos.Rows.Add("5", 0);
            dgvMontos.Rows.Add("1", 0);
            dgvMontos.Rows.Add("Total", 0, 0);

            dgvMontos.Rows[6].ReadOnly = true;
        }

        /// <summary>
        /// Crear las filas de euros del DataGridView.
        /// </summary>
        private void crearTablaEuros()
        {
            dgvMontos.Rows.Clear();

            dgvMontos.Rows.Add("100", 0);
            dgvMontos.Rows.Add("50", 0);
            dgvMontos.Rows.Add("20", 0);
            dgvMontos.Rows.Add("10", 0);
            dgvMontos.Rows.Add("5", 0);
            dgvMontos.Rows.Add("Total", 0, 0);

            dgvMontos.Rows[5].ReadOnly = true;
        }

        #endregion Métodos Privados

    }

}
