//
//  @ Project : 
//  @ File Name : frmDespachoRecepcionCartuchos.cs
//  @ Date : 15/11/2012
//  @ Author : César Mendoza
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using CommonObjects.Clases;

namespace GUILayer
{

    public partial class frmDespachoRecepcionCartuchos : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private Colaborador _usuario = new Colaborador();
        private Cartucho _cartucho;
        private BindingList<FallaCartucho> _anteriores = new BindingList<FallaCartucho>();

        #endregion Atributos

        #region Constructor

        public frmDespachoRecepcionCartuchos(Colaborador c)
        {
            InitializeComponent();

            _usuario = c;
            dgvCartuchos.AutoGenerateColumns = false;
            
            BindingList<FallaCartucho> Fallas = _mantenimiento.listarFallasCartucho();
            foreach (FallaCartucho r in Fallas)
            {
                clbFallas.Items.Add(r);
            }
           
            
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de buscar.
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (mtbCodigo.Text.Equals(string.Empty)) return;

            try
            {
                string numero = mtbCodigo.Text;

                Cartucho cartucho = new Cartucho(numero);
                if (_mantenimiento.verificarCartucho(ref cartucho))
                {
                    _cartucho = cartucho;
                    _anteriores = cartucho.Fallas;
                    txtNumero.Text = cartucho.Numero;
                    txtTipo.Text = cartucho.Tipo.ToString();
                    txtTransportadora.Text = cartucho.Transportadora.ToString();

                    dgvCartuchos.AutoGenerateColumns = false;
                    dgvCartuchos.DataSource = cartucho.Fallas;
                    cboEstado.SelectedIndex = (int)cartucho.Estado;
                }

                mtbCodigo.Text = string.Empty;
                mtbCodigo.Focus();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                EstadosCartuchos estado = (EstadosCartuchos)cboEstado.SelectedIndex;

                _cartucho.Estado = estado;
                string mensaje = _mantenimiento.actualizarCartuchoEstado(_cartucho,_usuario);
                if ( mensaje !=  "Realizar pedido de ")
                    MessageBox.Show(mensaje, "BAC CREDOMATIC",MessageBoxButtons.OK,MessageBoxIcon.Error);

                _mantenimiento.verificarAlertaLimiteFallas();

                Mensaje.mostrarMensaje("MensajeCartuchoConfirmacionActualizacion");
               
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
        /// Se selecciona un cartucho de la lista de cartuchos.
        /// </summary>
        private void dgvCartuchos_SelectionChanged(object sender, EventArgs e)
        {
            //btnGuardar.Enabled = dgvCartuchos.RowCount > 0;
            btnQuitarFalla.Enabled = dgvCartuchos.RowCount > 0;
        }

        /// <summary>
        /// Se agregan cartuchos a la lista de cartuchos.
        /// </summary>
        private void dgvCartuchos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCartuchos.Rows[e.RowIndex + contador];

                this.actualizarDatosCartucho(fila);
            }

        }

        /// <summary>
        /// El cuadro de texto del código del cartucho obtiene el foco.
        /// </summary>
        private void mtbCodigo_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnBuscar;
        }

        /// <summary>
        /// El cuadro de texto del código del cartucho pierde el foco.
        /// </summary>
        private void mtbCodigo_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = btnGuardar;
        }

        private void btnAgregarFalla_Click(object sender, EventArgs e)
        {
            if (clbFallas.CheckedItems.Count > 0)
            {
                foreach (FallaCartucho falla in clbFallas.CheckedItems)
                {
                    falla.Usuario = _usuario;
                    falla.Fecha = System.DateTime.Today;

                    if (!_cartucho.Fallas.Contains(falla))
                    {
                        _cartucho.Fallas.Add(falla);
                    }
                    dgvCartuchos.Refresh();
                    validaEstado();
                }
            }
        }

        private void validaEstado()
        {
            if (_cartucho.Fallas.Count == 0)
            {
                cboEstado.Text = "Bueno";
            }
            else
            {
                for (int fc = 0; fc < _cartucho.Fallas.Count; fc++)
                {
                    if (_cartucho.Fallas[fc].NoRecuperable == true)
                    {
                        cboEstado.Text = "No Recuperable";
                        fc = _cartucho.Fallas.Count + 1;
                    }
                    else 
                        cboEstado.Text = "Malo en Tesorería";
                }
            }
           

        }

        private void btnQuitarFalla_Click(object sender, EventArgs e)
        {
            FallaCartucho falla = (FallaCartucho)dgvCartuchos.SelectedRows[0].DataBoundItem;
            _cartucho.Fallas.Remove(falla);
            validaEstado();

          //  dgvCartuchos.Rows.Remove(dgvCartuchos.SelectedRows[0]);
           
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            if (!txtNumero.Text.Equals(string.Empty))
            {
                btnGuardar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
            }
        }    

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Actualizar los datos de los cartuchos en lista.
        /// </summary>
        private void actualizarDatosCartucho(DataGridViewRow fila)
        {
            //Cartucho cartucho = (Cartucho)fila.DataBoundItem;

            //string estado = string.Empty;

            //switch (cartucho.Estado)
            //{
            //    case EstadosCartuchos.EntregadoTaller:
            //        estado = "Estregado al Taller";
            //        break;
            //    case EstadosCartuchos.RecibidoTaller:
            //        estado = "Recibido del Taller";
            //        break;
            //    default:
            //        estado = Enum.GetName(typeof(EstadosCartuchos), cartucho.Estado);
            //        break;
            //}

           // fila.Cells[Estado.Index].Value = estado;
        }

        #endregion Métodos Privados

        private void frmDespachoRecepcionCartuchos_Load(object sender, EventArgs e)
        {

        }

       
    }

}
