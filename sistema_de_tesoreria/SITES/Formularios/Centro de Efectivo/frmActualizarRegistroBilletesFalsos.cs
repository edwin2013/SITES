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
using CommonObjects;
using CommonObjects.Clases;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmActualizarRegistroBilletesFalsos : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private BilleteFalso billete = null;
        private BindingList<BilleteFalso> _listabilletefalso = null;
        private Monedas _monedadeposito;

        #endregion Atributos

        #region Constructor

        public frmActualizarRegistroBilletesFalsos(ref BindingList<BilleteFalso> listabilletefalso, ref Colaborador colaborador, ref Monedas monedadeposito, Boolean readOnly)
        {
            InitializeComponent();
            dgvbilletes.ReadOnly = true;
            dgvbilletes.AutoGenerateColumns = false;
            //dgvcheques.DataSource = new BindingList<ChequeDeposito>();
            _listabilletefalso = listabilletefalso;
            _monedadeposito = monedadeposito;
            if (listabilletefalso != null)
            {
                dgvbilletes.DataSource = listabilletefalso;
            }
            else
            {
                dgvbilletes.DataSource = new BindingList<BilleteFalso>();
            }
            enableButtons(readOnly);

        }

        private void enableButtons(bool readOnly)
        {
            gbregistroBilleteFalso.Enabled = readOnly;
            btnQuitarBillete.Enabled = readOnly;
            btnConfirmar.Enabled = readOnly;
        }

        private void formatoVentana()
        {
            cboMoneda.SelectedIndex = (byte)Monedas.Colones;
            //cboTipoMesaNiquel.SelectedIndex = (byte)Monedas.Colones;
        }

        #endregion Constructor         

        #region Eventos

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarcamposagregar())
                {
                    epError.SetError(dgvbilletes, "");
                    _listabilletefalso = (BindingList<BilleteFalso>)dgvbilletes.DataSource;
                    billete = new BilleteFalso(serie_billete: txtCodigo.Text, moneda: (Monedas)cboMoneda.SelectedIndex, denominacion: (Denominacion)cboDenominacion.SelectedItem);
                    if (dgvbilletes.SelectedRows.Count != 0)
                    {
                        billete.ID = Int32.Parse(dgvbilletes.SelectedRows[0].Cells["ID"].Value.ToString());
                        _listabilletefalso[dgvbilletes.SelectedRows[0].Index] = billete;
                        /*dgvbilletes.Rows[dgvbilletes.SelectedRows[0].Index].Cells["Serie"].Value = billete.SerieBillete;
                        dgvbilletes.Rows[dgvbilletes.SelectedRows[0].Index].Cells["Denominacion"].Value = billete.denominacion;
                        dgvbilletes.Rows[dgvbilletes.SelectedRows[0].Index].Cells["Moneda"].Value = billete.Moneda;*/
                        dgvbilletes.Refresh();
                        dgvbilletes.ClearSelection();
                        //billete.Moneda = (Monedas)cboMoneda.SelectedValue;
                        //billete.SerieBillete = txtCodigo.Text;
                        //billete.Monto = decimal.Parse(cboDenominacion.SelectedValue);
                    }
                    else
                    {
                        _listabilletefalso.Add(billete);
                        /*dgvbilletes.Rows.Add(billete.Moneda, billete.denominacion, billete.SerieBillete);                        */
                        dgvbilletes.Refresh();
                        limpiarcampos();
                    }
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {

                frmActualizarBajoVolumen padre = (frmActualizarBajoVolumen)this.Owner; //Ingreso de depositos
                padre.actualizarbilletesfalsos(_listabilletefalso);
                this.Close();
                this.Close();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMoneda.SelectedIndex != -1)
            {

                cboDenominacion.ListaMostrada = _mantenimiento.listarDenominacionesxMonedas((byte)(Monedas)cboMoneda.SelectedIndex);
                cboDenominacion.Items.RemoveAt(0);
                epError.SetError(cboMoneda, "");
            }
        }

        private void cboDenominacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDenominacion.SelectedIndex != -1)
            {
                epError.SetError(cboDenominacion, "");
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                epError.SetError(txtCodigo, "");
            }
        }

        #endregion Eventos                                        


        #region Métodos Privados

        private void limpiarcampos()
        {
            cboDenominacion.SelectedIndex = -1;
            cboMoneda.SelectedIndex = -1;
            txtCodigo.Text = "";
            dgvbilletes.ClearSelection();
        }

        private Boolean validarcamposagregar()
        {
            if (cboMoneda.SelectedIndex == -1)
            {
                epError.SetError(cboMoneda, "No ha seleccionado una moneda asociada al cheque.");
                return false;
            }
            if (_monedadeposito != (Monedas)cboMoneda.SelectedIndex)
            {
                epError.SetError(cboMoneda, "No se puede ingresar un cheque con una moneda distinta a la declarada en el depósito.");
                return false;
            }
            if (cboDenominacion.SelectedIndex == -1)
            {
                epError.SetError(cboDenominacion, "No ha seleccionado una denominación para el cheque.");
                return false;
            }
            if (txtCodigo.Text == "")
            {
                epError.SetError(txtCodigo, "No ha indicado la serie del cheque.");
                return false;
            }
            return true;
        }

        #endregion Métodos Privados 

        private void dgvbilletes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvbilletes.SelectedRows.Count > 0)
            {
                cboMoneda.SelectedIndex = (Byte)(Monedas)dgvbilletes.SelectedRows[0].Cells["Moneda"].Value;
                cboDenominacion.SelectedItem = (Denominacion)dgvbilletes.SelectedRows[0].Cells["Denominacion"].Value;
                txtCodigo.Text = dgvbilletes.SelectedRows[0].Cells["Serie"].Value.ToString();
            }
            else
            {
                limpiarcampos();
                dgvbilletes.ClearSelection();
            }
        }

        private void dgvbilletes_MouseClick(object sender, MouseEventArgs e)
        {
            var ht = dgvbilletes.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                limpiarcampos();
            }
        }

        private void btnQuitarBillete_Click(object sender, EventArgs e)
        {
            if (dgvbilletes.SelectedRows.Count > 0)
            {
                //_listachequedeposito.Remove((ChequeDeposito)dgvcheques.SelectedRows[0].DataBoundItem);
                _listabilletefalso.RemoveAt(dgvbilletes.SelectedRows[0].Index);
                dgvbilletes.Refresh();
                limpiarcampos();
            }
        }

        private void frmRegistroBilletesFalsos_Load(object sender, EventArgs e)
        {

        }

    }
}
