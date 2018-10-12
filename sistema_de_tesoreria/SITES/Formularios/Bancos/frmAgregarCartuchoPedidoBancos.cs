using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
using GUILayer.Formularios.Mantenimiento;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Bancos
{
    public partial class frmAgregarCartuchoPedidoBancos : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;
        private BindingList<bool> _validados = new BindingList<bool>();
        private BindingList<PedidoBancos> _cargas = new BindingList<PedidoBancos>();
        private BindingList<Denominacion> _denominaciones = new BindingList<Denominacion>();
        private PedidoBancos _carga = null;
        private Colaborador _colaborador = null;

        private string _archivo = string.Empty;

        private String _comentario = String.Empty;

        private List<int> _filas_incorrectas = new List<int>();

        #endregion Atributos

        #region Constructor

        public frmAgregarCartuchoPedidoBancos(Colaborador colaborador, PedidoBancos carga)
        {
            InitializeComponent();
            cboDenominacion.ListaMostrada = _mantenimiento.listarDenominaciones();
            _colaborador = colaborador;
            _carga = carga;
            _cargas.Clear();
            _validados.Clear();

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                if (ValidarCampos())
                {
                    _cargas.Clear();

                    Denominacion nueva = (Denominacion)cboDenominacion.SelectedItem;
                    double monto = Convert.ToDouble(txtNombre.Text);

                    this.asignarCartuchos(monto, ref _carga, nueva);
                    
                    //_coordinacion.importarCargasSucursales(_cargas);

                    Mensaje.mostrarMensaje("MensajeCargasSucursalesConfirmacionGeneracion");


                    //btnAceptar.Enabled = false;
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
        /// Valida que solo se digiten numeros
        /// </summary>
        private void txtMontoDisminucion_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                }
        }

        /// <summary>
        /// Verifica si el combo se ha seleccionado o no
        /// </summary>
        private void cboDenominacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDenominacion.Text == string.Empty)
                txtNombre.ReadOnly = true;
            else
            {
                txtNombre.ReadOnly = false;
                txtNombre.Text = string.Empty;
            }
        }
        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Valida que los campos requeridos no esten vacion
        /// </summary>
        /// <returns>Un bool, indicando si la validacin</returns>
        private bool ValidarCampos()
        {
            bool bStatus = true;
            if (cboDenominacion.Text == "")
            {
                epError.SetError(cboDenominacion, "Debe ingresar una Sucursal ");
                bStatus = false;
            }
            else
                epError.SetError(cboDenominacion, "");
           
            return bStatus;
        }

        /// <summary>
        /// Verifica si un monto se puede aceptar debido a la denominacion correspondiente
        /// </summary>
        /// <param name="monto">Monto digitado</param>
        /// <param name="denominacion">Denominacion correspondiente del pedido</param>
        /// <param name="t">Objeto Textbox donde se encuentra el monto</param>
        /// <returns></returns>
        private bool ValidarMontos(Decimal monto,Decimal denominacion, TextBox t, ref bool aux)
        {
            
            bool bStatus = true;

            if (monto % denominacion != 0)
            {
                epError.SetError(t, "No se puede ingresar ese monto");
                bStatus = false;
            }
            else
                epError.SetError(t, "");

            aux = bStatus;
           
  
            return bStatus;
        }
        /// <summary>
        /// Asignar los cartuchos de una carga y determinar si el monto erra correcto.
        /// </summary>
        private void asignarCartuchos(double p_monto, ref PedidoBancos carga,Denominacion denominacion)
        {
            decimal monto = Convert.ToDecimal(p_monto);

            //Denominacion denominacion = new Denominacion(valor: Convert.ToDecimal(p_monto), moneda: moneda);

            _mantenimiento.verificarDenominacion(ref denominacion);

                double cantidad_total = (double)Math.Ceiling(monto / denominacion.Valor);

                double cantidad_cartucho = (double)(monto / denominacion.Valor);

               // cantidad_cartucho = (short)(100 * (int)Math.Ceiling((decimal)(cantidad_cartucho / 100)));


                BolsaCargaBanco cartucho = new BolsaCargaBanco(movimiento: carga, cantidad_asignada: cantidad_cartucho,
                                                                     denominacion: denominacion);

                    frmObservaciones formulario = new frmObservaciones();
                    formulario.Padre7 = this;
                    formulario.ShowDialog();

                    cartucho.Comentario = _comentario;
                    carga.agregarCartucho(cartucho);

                switch (denominacion.Moneda)
                {
                    case Monedas.Colones: carga.Monto_pedido_colones += monto; break;
                    case Monedas.Dolares: carga.Monto_pedido_dolares += monto; break;
                    case Monedas.Euros: carga.Monto_pedido_euros += monto; break;
                }


                _coordinacion.actualizarPedidoBanco(carga);

        }

        /// <summary>
        /// 
        /// </summary>
        private void agregarCarga()
        {
 
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
