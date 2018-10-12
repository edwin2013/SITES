using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriaMensajes;
using BussinessLayer;
using CommonObjects.Clases;
using CommonObjects;

namespace GUILayer.Formularios.Blindados
{
    public partial class frmModificacionPedido : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmModificacionPedido(PedidoBancos carga, Colaborador colaborador, bool solo_lectura)
        {
            InitializeComponent();

            lblNombre.Text = carga.NombreCanal;
            lblNombre.Visible = true;
            dgvMontosCarga.AutoGenerateColumns = false;

            if (colaborador.Puestos.Contains(Puestos.Coordinador) ||
                colaborador.Puestos.Contains(Puestos.Supervisor))
            {
                MontoAsignadoCartuchoCarga.Visible = true;
                CantidadAsignadaCartuchoCarga.Visible = true;

                MontoCartuchoCarga.Visible = true;
                CantidadCartuchoCarga.Visible = true;
                CantidadBolsa.Visible = true;
             


                MarchamoCartuchoCarga.Visible = true;

                Anular.ReadOnly = false;

                CantidadCartuchoCarga.ReadOnly = solo_lectura;
                MontoCartuchoCarga.ReadOnly = solo_lectura;
              

            }
            else if (colaborador.Puestos.Contains(Puestos.Analista))
            {
                MontoAsignadoCartuchoCarga.Visible = true;
                CantidadAsignadaCartuchoCarga.Visible = true;
                CantidadBolsa.Visible = true;
                CantidadAsignadaCartuchoCarga.ReadOnly = solo_lectura;
                MontoCartuchoCarga.ReadOnly = solo_lectura;
            }
            else
            {
                MontoCartuchoCarga.Visible = true;
                CantidadCartuchoCarga.Visible = true;

                MarchamoCartuchoCarga.Visible = true;
            }

            dgvMontosCarga.DataSource = carga.Bolsas;
            dgvMontosCarga.ReadOnly = solo_lectura;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Actualizar la cantidad de formulas de un cartucho.
        /// </summary
        private void dgvMontosCarga_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvMontosCarga.RowCount > 0)
            {
                DataGridViewRow fila = dgvMontosCarga.Rows[e.RowIndex];

                this.actualizarCartucho(fila);

                dgvMontosCarga.Refresh();
            }

        }

        /// <summary>
        /// Se da formato a la celda con las cantidades de fórmulas de un cartucho.
        /// </summary
        private void dgvMontosCarga_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {

            if (e.ColumnIndex == CantidadAsignadaCartuchoCarga.Index ||
                e.ColumnIndex == CantidadCartuchoCarga.Index)
                this.validarFormatoNumericoCelda(e);

        }


        /// <summary>
        /// Clic en el boton de agregar una nueva denominacion
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Actualizar los datos de un cartucho.
        /// </summary
        private void actualizarCartucho(DataGridViewRow fila)
        {

            try
            {
                BolsaCargaBanco cartucho = (BolsaCargaBanco)fila.DataBoundItem;

                _coordinacion.actualizarBolsaPedidoBancoCantidad(cartucho);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

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

        #endregion Métodos Privados

        private void frmModificacionPedido_Load(object sender, EventArgs e)
        {

        }

        
    }
}
