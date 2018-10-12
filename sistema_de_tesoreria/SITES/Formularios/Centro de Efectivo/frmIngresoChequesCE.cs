using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriaMensajes;
using CommonObjects;
using CommonObjects.Clases;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmIngresoChequesCE : Form
    {

        #region Atributos

        private ChequeDeposito cheque = null;
        private BindingList<ChequeDeposito> _listachequedeposito = null;
        private Monedas _monedadeposito;

        #endregion Atributos

        #region Constructor

        public frmIngresoChequesCE(ref BindingList<ChequeDeposito> listachequedeposito, ref Colaborador colaborador, ref Monedas monedadeposito)
        {
            InitializeComponent();
            /*dgvcheques.Enabled = false;*/
            dgvcheques.ReadOnly = true;
            dgvcheques.AutoGenerateColumns = false;
            //dgvcheques.DataSource = new BindingList<ChequeDeposito>();
            _listachequedeposito = listachequedeposito;
            _monedadeposito = monedadeposito;
            if (listachequedeposito != null)
            {
                dgvcheques.DataSource = listachequedeposito;
            }
            else
            {
                dgvcheques.DataSource = new BindingList<ChequeDeposito>();
            }
            this.formatoVentana();
        }

        private void formatoVentana()
        {
            cboMoneda.SelectedIndex = (byte)Monedas.Colones;
            this.ActiveControl = nudMonto;
            /*gbregistrocheque.Focus();
            nudMonto.Focus();*/
                       
            //cboTipoMesaNiquel.SelectedIndex = (byte)Monedas.Colones;
        }

        #endregion Constructor         

        #region Eventos

        private void nudMonto_ValueChanged(object sender, EventArgs e)
        {
            epError.SetError(nudMonto, "");
        }

      private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                //frmBajoVolumenIngresoDepositos formulario = new frmBajoVolumenIngresoDepositos();
                //formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void frmBajoVolumenIngresoManifiesto_Load(object sender, EventArgs e)
        {

        }

         private void frmIngresoChequesCE_Load(object sender, EventArgs e)
        {
            /*gbregistrocheque.Focus();
            nudMonto.Focus();*/
            this.ActiveControl = nudMonto;
            //nudMonto.Select(0, nudMonto.Value.ToString().Length);
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

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvcheques.Rows.Count > 0)
                {
                    frmBajoVolumenIngresoDepositos padre = (frmBajoVolumenIngresoDepositos)this.Owner; //Ingreso de depositos
                    padre.actualizarlistachequesDeposito(_listachequedeposito);
                    this.Close();
                }
                else
                {
                    epError.SetError(dgvcheques, "No hay cheques registrados en la bandeja");
                }           
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarcamposagregar())
                {
                    epError.SetError(dgvcheques, "");
                    _listachequedeposito = (BindingList<ChequeDeposito>)dgvcheques.DataSource;
                    cheque = new ChequeDeposito(id:0, tipoc:(TipoChequeDeposito)cboTipoCheque.SelectedIndex, rechazo:false, monto:nudMonto.Value, moneda:(Monedas)cboMoneda.SelectedIndex);
                    if (dgvcheques.SelectedRows.Count != 0)
                    {                        
                        //cheque = (ChequeDeposito)dgvcheques.SelectedRows[0].DataBoundItem;
                        _listachequedeposito[dgvcheques.SelectedRows[0].Index] = cheque;                        
                        /*dgvcheques.Rows[dgvcheques.SelectedRows[0].Index].Cells["TipoCheque"].Value = cheque.TipoCheque;
                        dgvcheques.Rows[dgvcheques.SelectedRows[0].Index].Cells["Moneda"].Value = cheque.Moneda;
                        dgvcheques.Rows[dgvcheques.SelectedRows[0].Index].Cells["Monto"].Value = cheque.Monto;*/
                        dgvcheques.Refresh();
                        dgvcheques.ClearSelection();
                        sumartotales();
                        //billete.Moneda = (Monedas)cboMoneda.SelectedValue;
                        //billete.SerieBillete = txtCodigo.Text;
                        //billete.Monto = decimal.Parse(cboDenominacion.SelectedValue);
                    }
                    else
                    {                        
                        _listachequedeposito.Add(cheque);
                        //dgvcheques.Rows.Add(cheque.TipoCheque, cheque.Moneda, cheque.Monto);
                        dgvcheques.Refresh();
                        sumartotales();
                        limpiarcampos();
                    }
                    nudMonto.Focus();
                    nudMonto.Select(0, nudMonto.Text.Length);
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void dgvcheques_MouseClick(object sender, MouseEventArgs e)
        {
            var ht = dgvcheques.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                limpiarcampos();
            }
        }

        private void dgvcheques_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvcheques.SelectedRows.Count > 0)
            {
                cboMoneda.SelectedIndex = (Byte)(Monedas)dgvcheques.SelectedRows[0].Cells["Moneda"].Value;
                cboTipoCheque.SelectedIndex = (Byte)(TipoChequeDeposito)dgvcheques.SelectedRows[0].Cells["TipoCheque"].Value;
                nudMonto.Value = Int64.Parse(dgvcheques.SelectedRows[0].Cells["Monto"].Value.ToString());
            }
            else
            {
                limpiarcampos();
                dgvcheques.ClearSelection();
            }
        }

        private void btnQuitarCheque_Click(object sender, EventArgs e)
        {
            if (dgvcheques.SelectedRows.Count > 0)
            {
                //_listachequedeposito.Remove((ChequeDeposito)dgvcheques.SelectedRows[0].DataBoundItem);
                _listachequedeposito.RemoveAt(dgvcheques.SelectedRows[0].Index);
                dgvcheques.Refresh();
                sumartotales();
                limpiarcampos();
            }
        }

        #endregion Eventos                     

        #region Métodos Privados

        private void sumartotales() {
            int i;
            long totalChequeCompensadoUSD = 0;
            long totalChequeCompensadoCRC = 0;
            long totalChequeLocalUSD = 0;
            long totalChequeLocalCRC = 0;
            long totalChequeExtranjeroUSD = 0;
            long totalChequeExtranjeroCRC = 0;
            long totalChequeUSD = 0;
            long totalChequeCRC = 0;
            try
            {
                for (i = 0; i < dgvcheques.Rows.Count; i++)
                {
                    cheque = (ChequeDeposito)dgvcheques.Rows[i].DataBoundItem;
                    switch ((TipoChequeDeposito)cheque.TipoCheque)
                    {
                        case TipoChequeDeposito.Cheques_Compensados:
                            if ((Monedas)cheque.Moneda == Monedas.Colones)
                            {
                                totalChequeCompensadoCRC += Convert.ToInt64(cheque.Monto);
                                totalChequeCRC += Convert.ToInt64(cheque.Monto);
                            }
                            else
                            {
                                totalChequeCompensadoUSD += Convert.ToInt64(cheque.Monto);
                                totalChequeUSD += Convert.ToInt64(cheque.Monto);
                            }
                            break;
                        case TipoChequeDeposito.Cheques_Extranjero:
                            if ((Monedas)cheque.Moneda == Monedas.Colones)
                            {
                                totalChequeExtranjeroCRC += Convert.ToInt64(cheque.Monto);
                                totalChequeCRC += Convert.ToInt64(cheque.Monto);
                            }
                            else
                            {
                                totalChequeExtranjeroUSD += Convert.ToInt64(cheque.Monto);
                                totalChequeUSD += Convert.ToInt64(cheque.Monto);
                            }
                            break;
                        case TipoChequeDeposito.Cheques_Locales:
                            if ((Monedas)cheque.Moneda == Monedas.Colones)
                            {
                                totalChequeLocalCRC += Convert.ToInt64(cheque.Monto);
                                totalChequeCRC += Convert.ToInt64(cheque.Monto);
                            }
                            else
                            {
                                totalChequeLocalUSD += Convert.ToInt64(cheque.Monto);
                                totalChequeUSD += Convert.ToInt64(cheque.Monto);
                            }
                            break;
                    }
                    txtChequeCompensadoCRC.Text = totalChequeCompensadoCRC.ToString();
                    txtChequeCompensadoUSD.Text = totalChequeCompensadoUSD.ToString();
                    txtChequeExtranjeroCRC.Text = totalChequeExtranjeroCRC.ToString();
                    txtChequeExtranjeroUSD.Text = totalChequeExtranjeroUSD.ToString();
                    txtChequeLocalCRC.Text = totalChequeLocalCRC.ToString();
                    txtChequeLocalUSD.Text = totalChequeLocalUSD.ToString();
                    txtChequesCRC.Text = totalChequeCRC.ToString();
                    txtChequesUSD.Text = totalChequeUSD.ToString();
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }                        
        }

        private void limpiarcampos()
        {
            //cboTipoCheque.SelectedIndex = -1;
            //cboMoneda.SelectedIndex = 0;
            nudMonto.Value = 0;
            dgvcheques.ClearSelection();
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
            if (cboTipoCheque.SelectedIndex == -1)
            {
                epError.SetError(cboTipoCheque, "No ha seleccionado un tipo de cheque");
                return false;
            }
            if (nudMonto.Value == 0)
            {
                epError.SetError(nudMonto, "No ha indicado la serie del cheque.");
                return false;
            }
            return true;
        }   

        #endregion Métodos Privados                 

        private void nudMonto_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                epError.SetError(nudMonto, "");
                if (e.KeyValue == 13) btnGuardar_Click(sender, e);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            epError.SetError(cboMoneda, "");
        }

        private void nudMonto_Enter(object sender, EventArgs e)
        {
            nudMonto.Select(0, nudMonto.Text.Length);
        }

        private void nudMonto_Click(object sender, EventArgs e)
        {
            nudMonto.Select(0, nudMonto.Text.Length);
        }
    }
}
