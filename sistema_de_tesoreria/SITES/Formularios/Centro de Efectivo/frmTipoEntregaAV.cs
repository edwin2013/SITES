using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmTipoEntregaAV : Form
    {
        #region Atributos

        private ProcesamientoBajoVolumen _procesoBV;
        private ProcesamientoAltoVolumen _procesoAV;
        private ProcesamientoAltoVolumenDetalle _procesoAVDet;
        private BindingList<Camara> listacamara = new BindingList<Camara>();
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private Colaborador col = null;

        #endregion Atributos

        #region Constructor

        #endregion Constructor

        public frmTipoEntregaAV(ref ProcesamientoBajoVolumen procesoBV, ref Colaborador c)
        {
            InitializeComponent();
            col = c;
            _procesoBV = procesoBV;
            listacamara = _mantenimiento.listarCamarasPorArea(Areas.CentroEfectivo);
            cbotipoentregaAV.ListaMostrada = listartipoentrega();            
        }

        private BindingList<String> listartipoentrega()
        {
            BindingList<String> listaentrega = new BindingList<String>();
            try
            {
                listaentrega.Add("Entrega Alta Denominación");
                listaentrega.Add("Entrega Baja Denominación");
                listaentrega.Add("Entrega Dólares");
                listaentrega.Add("Entrega Colones Ambas Denominaciones");
                listaentrega.Add("Entrega Euros");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listaentrega;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbotipoentregaAV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboCamara.ListaMostrada = listacamara;
                cboCamara.SelectedItem = _procesoBV.Camara;                
                txtColaborador.Text = _procesoBV.ColaboradorAsociado.Nombre + " " + _procesoBV.ColaboradorAsociado.Primer_apellido + " " + _procesoBV.ColaboradorAsociado.Segundo_apellido;                
                switch (cbotipoentregaAV.SelectedIndex)
                {
                    case 1:
                        cboTipoEntrega.SelectedIndex = 0;
                        nudMonto.Value = _procesoBV.MontoAD;
                        _procesoBV.ExcedelimiteAD = true;
                        gbDatosEntrega.Visible = true;
                        break;
                    case 2:
                        cboTipoEntrega.SelectedIndex = 1;
                        nudMonto.Value = _procesoBV.MontoBD;
                        _procesoBV.ExcedelimiteBD = true;
                        gbDatosEntrega.Visible = true;
                        break;                    
                    case 3:
                        cboTipoEntrega.SelectedIndex = 2;
                        nudMonto.Value = _procesoBV.MontoDOL;
                        _procesoBV.ExcedelimiteDOL = true;
                        gbDatosEntrega.Visible = true;
                        break;
                    case 4:
                        cboTipoEntrega.SelectedIndex = 3;
                        nudMonto.Value = _procesoBV.MontoCOL;
                        _procesoBV.ExcedelimiteAD = true;
                        _procesoBV.ExcedelimiteBD = true;
                        gbDatosEntrega.Visible = true;
                        break;
                    case 5: //euros falta
                        cboTipoEntrega.SelectedIndex = 4;
                        _procesoBV.ExcedelimiteEUR = true;
                        nudMonto.Value = _procesoBV.MontoEUR;
                        gbDatosEntrega.Visible = true;
                        break;
                    default:
                        gbDatosEntrega.Visible = false;
                        break;
                }                               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Boolean validacampos()
        {
            try
            {
                if (cboTipoEntrega.SelectedIndex == -1)
                {
                    epError.SetError(cboTipoEntrega, "Falta seleccionar el tipo de entrega");
                    return false;
                    //MessageBox.Show("Falta seleccionar el cajero para realizar la búsqueda", "Selección de cajero");
                }
                if (txtHeadercard.Text == "")
                {
                    epError.SetError(txtHeadercard, "Favor indicar el código de la headercard");
                    return false;
                }
                if (cboCamara.SelectedIndex < 1)
                {
                    epError.SetError(cboCamara, "Favor seleccionar una cámara");
                    return false;
                }
                if (nudMonto.Value == 0)
                {
                    epError.SetError(nudMonto, "No se puede ingresar ese monto");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void cboCamara_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                epError.SetError(cboCamara, "");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudMonto_ValueChanged(object sender, EventArgs e)
        {
            epError.SetError(nudMonto, "");
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validacampos())
                {
                    // Inicia cambios GZH 23/08/2017
                    _procesoAV = new ProcesamientoAltoVolumen(); 
                    _procesoAVDet = new ProcesamientoAltoVolumenDetalle("");
                    _procesoAV.Cajero = _procesoBV.ColaboradorAsociado;
                    _procesoAV.Camara = (Camara)cboCamara.SelectedItem;                    
                    if ((cboTipoEntrega.SelectedIndex < 2) || (cboTipoEntrega.SelectedIndex == 3))
                    {
                        _procesoAV.Moneda = Monedas.Colones;
                        _procesoAVDet.Moneda = Monedas.Colones;
                    }
                    else
                    {
                        if (cboTipoEntrega.SelectedIndex == 2)
                        {
                            _procesoAV.Moneda = Monedas.Dolares;
                            _procesoAVDet.Moneda = Monedas.Dolares;
                        }                            
                        else
                        {
                            _procesoAV.Moneda = Monedas.Euros;
                            _procesoAVDet.Moneda = Monedas.Euros;
                        }                            
                    }
                    _procesoAV.Monto = nudMonto.Value;
                    if (cboTipoEntrega.SelectedIndex > 2)
                        _procesoAV.Tipo = (byte)(cboTipoEntrega.SelectedIndex + 1);
                    else
                        _procesoAV.Tipo = (byte)cboTipoEntrega.SelectedIndex;
                    _procesoAVDet.Headercard = txtHeadercard.Text;
                    _procesoAVDet.Cajero = _procesoBV.ColaboradorAsociado;                    
                    _procesoAVDet.Monto = nudMonto.Value;
                    _procesoAV.Detalle = new BindingList<ProcesamientoAltoVolumenDetalle>();
                    _procesoAV.Detalle.Add(_procesoAVDet);

                    //Finaliza cambios GZH 23/08/2017

                    _mantenimiento.agregarProcesamientoAltoVolumen(ref _procesoAV, _procesoBV);
                    _mantenimiento.agregarProcesamientoAltoVolumenDetalle(ref _procesoAVDet, _procesoAV);
                    _procesoBV = _mantenimiento.listarProcesamientoBajoVolumenCajero(ref col);
                    //_procesoBV.Excedelimite = false;
                    MessageBox.Show("Se procesó correctamente la entrega de bajo volumen a alto volumen");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
