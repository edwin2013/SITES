using BussinessLayer;
using CommonObjects;
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

namespace GUILayer.Formularios.Níquel
{
    public partial class frmMantenimientoBolsasNiquel : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private CantidadMonedasBolsaNiquel _CantidadMonedasBolsaNiquel = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoBolsasNiquel()
        {
            InitializeComponent();

            dgvBolsas.AutoGenerateColumns = false;
            dgvBolsas.DataSource = new BindingList<CantidadMonedasBolsaNiquel>();
            cboDenominacion.ListaMostrada = _mantenimiento.listarDenominacionesMonedas();
            dgvBolsas.DataSource = _mantenimiento.listarCantidadMonedasBolsa();


        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            //if (cboDenominacion.Text.Equals(string.Empty) || nudCantidad.Value == 0)
            //{
            //    Excepcion.mostrarMensaje("ErrorCantidadMonedasBolsaNiquelRegistro");
            //    return;
            //}

            try
            {

                BindingList<CantidadMonedasBolsaNiquel> bolsas = (BindingList<CantidadMonedasBolsaNiquel>)dgvBolsas.DataSource;

                foreach (CantidadMonedasBolsaNiquel c in bolsas)
                {
                    CantidadMonedasBolsaNiquel copia = c; 
                    if (c.ID != 0)
                        _mantenimiento.actualizarCantidadMonedasBolsa(copia);
                    else
                        _mantenimiento.agregarCantidadMonedasBolsa(ref copia);
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
        /// Agrega una nueva denominacion y una cantidad de piezas a una bolsa. 
        /// </summary>
        private void btnAgregarBolsa_Click(object sender, EventArgs e)
        {
            try
            {
                Denominacion d = (Denominacion)cboDenominacion.SelectedItem;
                int cantidad = (int)nudCantidad.Value;

                CantidadMonedasBolsaNiquel bolsa = new CantidadMonedasBolsaNiquel(d: d, cantidad: cantidad);

                BindingList<CantidadMonedasBolsaNiquel> bolsas = (BindingList<CantidadMonedasBolsaNiquel>)dgvBolsas.DataSource;

                bolsas.Add(bolsa);

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Eliminar una parametrización de piezas por bolsas. 
        /// </summary>
        private void btnQuitarBolsa_Click(object sender, EventArgs e)
        {
            CantidadMonedasBolsaNiquel bolsa = (CantidadMonedasBolsaNiquel)dgvBolsas.SelectedRows[0].DataBoundItem;

            BindingList<CantidadMonedasBolsaNiquel> bolsas = (BindingList<CantidadMonedasBolsaNiquel>)dgvBolsas.DataSource;

            if(bolsa.ID != 0)
                _mantenimiento.eliminarCantidadMonedasBolsa(bolsa);

            bolsas.Remove(bolsa);
        }


        /// <summary>
        ///  Cambio en la tabla de Cantidad de piezas por bolsa
        /// </summary>
        private void dgvBolsas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBolsas.Rows.Count > 0)
            {
                btnQuitarBolsa.Enabled = true;
                btnGuardar.Enabled = true;
            }
            else
            {
                btnQuitarBolsa.Enabled = false;
                btnGuardar.Enabled = false;
            }
        }


        /// <summary>
        /// Valida si los valores en la celda son númericos
        /// </summary>
        private void dgvBolsas_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == clmCantidad.Index)
                this.validarFormatoNumericoCelda(e);
        }


        /// <summary>
        /// Actualiza los datos de la cantidad de piezas por bolsa
        /// </summary>
        private void dgvBolsas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBolsas.RowCount > 0)
            {
                DataGridViewRow fila = dgvBolsas.Rows[e.RowIndex];

                this.actualizarBolsa(fila);

                dgvBolsas.Refresh();
            }
        }


        #endregion Eventos
        #region Métodos Privados

        /// <summary>
        /// Validar el formato númerico de la celda de la cantidad de fórmulas de un cartucho.
        /// </summary
        private void validarFormatoNumericoCelda(DataGridViewCellParsingEventArgs e)
        {

            if (e.Value != null)
            {
                short valor;

                short.TryParse(e.Value.ToString().Replace(",", ""), out valor);

                e.Value = valor;
                e.ParsingApplied = true;
            }

        }



        /// <summary>
        /// Actualiza la cantidad de piezas de una bolsa específica
        /// </summary>
        /// <param name="fila">Fila seleccionada donde reside la bolsa</param>
        private void actualizarBolsa(DataGridViewRow fila)
        {
            try
            {
                CantidadMonedasBolsaNiquel cartucho = (CantidadMonedasBolsaNiquel)fila.DataBoundItem;

                _mantenimiento.actualizarCantidadMonedasBolsa(cartucho);

                
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        #endregion Métodos Privados

        private void frmMantenimientoBolsasNiquel_Load(object sender, EventArgs e)
        {

        }


       
      

       

        
    }
}
