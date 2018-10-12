//
//  @ Project : 
//  @ File Name : frmMarcacionCartuchosDanados.cs
//  @ Date : 15/11/2012
//  @ Author : César Mendoza
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using CommonObjects.Clases;

namespace GUILayer
{

    public partial class frmMarcacionCartuchosDanados : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private Colaborador _usuario = new Colaborador();
        private Cartucho _cartucho = null;

        #endregion Atributos

        #region Constructor

        public frmMarcacionCartuchosDanados(Colaborador usuario)
        {
            InitializeComponent();

            _usuario = usuario;

            BindingList<FallaCartucho> Fallas = _mantenimiento.listarFallasCartucho();
            foreach (FallaCartucho r in Fallas)
            {
                clbFallas.Items.Add(r);
            }
            
        }

        #endregion Constructor

        #region Eventos

        private void clbFallas_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool flag = false;
            if (clbFallas.CheckedItems.Count > 0)
            {
                foreach (FallaCartucho f in clbFallas.CheckedItems)
                {
                    if (f.NoRecuperable == true)
                        flag = true;
                }

                if (flag == true)
                {
                    cboEstado.Text = "No Recuperable";
                }
                else
                {
                    cboEstado.Text = "Malo en Tesorería";
                }
            }
            //else
            //    cboEstado.Text = "Bueno";


        }

        /// <summary>
        /// Clic en el botón de buscar el cartucho.
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string numero = "0";
            numero = txtNumeroCartucho.Text;
          //  if (!short.TryParse(mtbCodigo.Text, out numero)) return;

            try
            {
                Cartucho cartucho = new Cartucho(numero);

                if (_mantenimiento.verificarCartucho(ref cartucho))
                {
                    string estado = "";// cartucho.Estado;

                    switch (cartucho.Estado)
                    {
                        case EstadosCartuchos.EntregadoTaller:
                            estado = "Malo en Taller";
                            break;
                        case EstadosCartuchos.NoRecuperable:
                            estado = "No Recuperable";
                            break;
                        case EstadosCartuchos.Bueno:
                            estado = "Bueno";
                            break;
                        case EstadosCartuchos.Malo:
                            estado = "Malo en Tesorería";
                            break;
                        default:
                            estado = Enum.GetName(typeof(EstadosCartuchos), cartucho.Estado);
                            break;
                    }

                    txtEstadoActual.Text = estado;
                    txtTipo.Text = cartucho.Tipo.ToString();
                    btnAceptar.Enabled = true;

                    _cartucho = cartucho;
                }
                else
                {
                    txtEstadoActual.Text = string.Empty;
                    txtTipo.Text = string.Empty;

                    btnAceptar.Enabled = false;
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {


                if (clbFallas.CheckedItems.Count > 0)
                {
                    foreach (FallaCartucho falla in clbFallas.CheckedItems)
                    {
                        falla.Usuario = _usuario;
                        falla.Fecha = System.DateTime.Now;
                        _cartucho.Fallas.Add(falla);
                    }

                    if (cboEstado.Text == "No Recuperable")
                        _cartucho.Estado = EstadosCartuchos.NoRecuperable;

                    if (cboEstado.Text == "Malo en Tesorería")
                        _cartucho.Estado = EstadosCartuchos.Malo;

                }

                string mensaje = _mantenimiento.actualizarCartuchoEstado(_cartucho, _usuario);
                if (mensaje != "Realizar pedido de ")
                    MessageBox.Show(mensaje, "BAC CREDOMATIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _mantenimiento.verificarAlertaLimiteFallas();

                Mensaje.mostrarMensaje("MensajeCartuchoConfirmacionActualizacion");

                this.Close();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de cancelar.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    private void clbFallas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                FallaCartucho f = (FallaCartucho)clbFallas.Items[e.Index];
                if (f.NoRecuperable == true)
                    cboEstado.Text = "No Recuperable";

            }
            else if (e.NewValue == CheckState.Unchecked & clbFallas.CheckedItems.Count == 1)
                cboEstado.Text = txtEstadoActual.Text;// "Bueno";
         }


        #endregion Eventos



    }

}
