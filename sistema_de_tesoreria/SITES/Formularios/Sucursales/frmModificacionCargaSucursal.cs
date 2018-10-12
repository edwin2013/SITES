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
using CommonObjects;
using LibreriaMensajes;
using GUILayer.Formularios.Boveda;
using GUILayer.Formularios.Mantenimiento;

namespace GUILayer.Formularios.Blindados
{
    public partial class frmModificacionCargaSucursal : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private CargaSucursal _carga = null;
        private Colaborador _colaborador = null;

        private String _comentario = String.Empty;

        #endregion Atributos

        #region Constructor

        /// <summary>
        /// Ventana de una modificación de las sucursales
        /// </summary>
        /// <param name="carga">Objeto CargaSucursal con los datos de la sucursal</param>
        /// <param name="colaborador">Colaborador con los datos del colaborador</param>
        /// <param name="solo_lectura">si el perfil permite modificar o solo revisar los datos</param>
        public frmModificacionCargaSucursal(CargaSucursal carga, Colaborador colaborador, bool solo_lectura)
        {
            InitializeComponent();
            _carga = carga;
            _colaborador = colaborador;
            lblNombre.Text = carga.Sucursal.Nombre;
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
                MontoCartuchoCarga.ReadOnly = solo_lectura;
              

            }
            else if (colaborador.Puestos.Contains(Puestos.Analista))
            {
                MontoAsignadoCartuchoCarga.Visible = true;
                CantidadAsignadaCartuchoCarga.Visible = true;

                CantidadAsignadaCartuchoCarga.ReadOnly = solo_lectura;
                MontoCartuchoCarga.ReadOnly = solo_lectura;
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

        public frmModificacionCargaSucursal(CargaSucursal carga, Colaborador colaborador, bool solo_lectura, int aprobacion)
        {
            InitializeComponent();
            _carga = carga;
            _colaborador = colaborador;
            lblNombre.Text = carga.Sucursal.Nombre;
            lblNombre.Visible = true;
            dgvMontosCarga.AutoGenerateColumns = false;
            btnAgregar.Visible = false;

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
                MontoCartuchoCarga.ReadOnly = solo_lectura;


            }
            else if (colaborador.Puestos.Contains(Puestos.Analista))
            {
                MontoAsignadoCartuchoCarga.Visible = true;
                CantidadAsignadaCartuchoCarga.Visible = true;

                CantidadAsignadaCartuchoCarga.ReadOnly = solo_lectura;
                MontoCartuchoCarga.ReadOnly = solo_lectura;
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

        /// <summary>
        /// Clic en el boton de ingresar una nueva denominacion
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarCartuchoCargaSucursal formulario = new frmAgregarCartuchoCargaSucursal(_colaborador,_carga);
            formulario.ShowDialog();
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
                CartuchoCargaSucursal cartucho = (CartuchoCargaSucursal)fila.DataBoundItem;
                               

                if (cartucho.Cantidad_carga % 100 == 0)
                {

                    frmObservaciones formulario = new frmObservaciones();
                    formulario.Padre3 = this;
                    formulario.ShowDialog();

                    cartucho.Comentario = _comentario;

                    dgvMontosCarga.Rows[fila.Index].Cells[4].ErrorText = "";
                    _coordinacion.actualizarCartuchoCargaSucursalCantidad(cartucho);
                }
                else
                {
                    dgvMontosCarga.Rows[fila.Index].Cells[4].ErrorText = "Dato Incorrecto";
                }
                
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

        #region Metodos Publicos
        /// <summary>
        /// Define el comentario de la modificación del pedido a sucursal
        /// </summary>
        /// <param name="comentario"></param>
        public void asignarComentario(String comentario)
        {
            _comentario = comentario;
        }
        #endregion Metodos Publicos



        
    }
}
