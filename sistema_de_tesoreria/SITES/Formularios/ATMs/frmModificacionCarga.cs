//
//  @ Project : 
//  @ File Name : frmModificacionCarga.cs
//  @ Date : 21/06/2012
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

    public partial class frmModificacionCarga : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private CargaATM _carga = new CargaATM();

        #endregion Atributos

        #region Constructor

        public frmModificacionCarga(CargaATM carga, Colaborador colaborador, bool solo_lectura)
        {
            InitializeComponent();

            _carga = carga;
           // lblNombre.Text = carga.ATM.Numero + " " + carga.ATM.Codigo;
            lblNombre.Visible = true;
            dgvMontosCarga.AutoGenerateColumns = false;

            if (colaborador.Puestos.Contains(Puestos.Coordinador) ||
                colaborador.Puestos.Contains(Puestos.Supervisor))
            {
                MontoAsignadoCartuchoCarga.Visible = true;
                CantidadAsignadaCartuchoCarga.Visible = true;

                MontoCartuchoCarga.Visible = true;
                CantidadCartuchoCarga.Visible = true;

                MarchamoCartuchoCarga.Visible = true;

                Anular.ReadOnly = false;

                CantidadCartuchoCarga.ReadOnly = solo_lectura;
            }
            else if (colaborador.Puestos.Contains(Puestos.Analista))
            {
                MontoAsignadoCartuchoCarga.Visible = true;
                CantidadAsignadaCartuchoCarga.Visible = true;

                CantidadAsignadaCartuchoCarga.ReadOnly = solo_lectura;
            }
            else
            {
                MontoCartuchoCarga.Visible = true;
                CantidadCartuchoCarga.Visible = true;

                MarchamoCartuchoCarga.Visible = true;
            }

            dgvMontosCarga.DataSource = carga.Cartuchos;
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

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Actualizar los datos de un cartucho.
        /// </summary
        private void actualizarCartucho(DataGridViewRow fila)
        {

            try
            {
                CartuchoCargaATM cartucho = (CartuchoCargaATM)fila.DataBoundItem;

                _coordinacion.actualizarCartuchoCargaATMCantidad(cartucho);

                _carga.Cartuchos = (BindingList<CartuchoCargaATM>)dgvMontosCarga.DataSource;

                BindingList<CargaATM> _carguita = new BindingList<CargaATM>();
                _carguita.Add(_carga);

                _coordinacion.guardarDatosATMINFO(_carguita, "M");

                
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

        private void dgvMontosCarga_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      

        
    }

}
