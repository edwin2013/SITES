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

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmEntregaBajoAltoVolumen : Form
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

        public frmEntregaBajoAltoVolumen(ref ProcesamientoBajoVolumen procesoBV, ref Colaborador c) //Cambios GZH 11092017
        {
            InitializeComponent();
            _procesoBV = procesoBV;
            listacamara = _mantenimiento.listarCamarasPorArea(Areas.CentroEfectivo);
            cboCamara.ListaMostrada = listacamara;
            cboCamara.SelectedItem = _procesoBV.Camara;
            col = c;
            txtColaborador.Text = _procesoBV.ColaboradorAsociado.Nombre + " " + _procesoBV.ColaboradorAsociado.Primer_apellido + " " + _procesoBV.ColaboradorAsociado.Segundo_apellido;
            if (_procesoBV.ExcedelimiteCOL)
            {
                cboTipoEntrega.SelectedIndex = 3;
                nudMonto.Value = _procesoBV.MontoCOL;
            }
            else
            {
                if (_procesoBV.ExcedelimiteAD)
                {
                    cboTipoEntrega.SelectedIndex = 0;
                    nudMonto.Value = _procesoBV.MontoAD;
                }
                if (_procesoBV.ExcedelimiteBD)
                {
                    cboTipoEntrega.SelectedIndex = 1;
                    nudMonto.Value = _procesoBV.MontoBD;
                }
            }            
            if (_procesoBV.ExcedelimiteDOL)
            {
                cboTipoEntrega.SelectedIndex = 2;
                nudMonto.Value = _procesoBV.MontoDOL;
            }
            if (_procesoBV.ExcedelimiteEUR)
            {
                cboTipoEntrega.SelectedIndex = 4;
                nudMonto.Value = _procesoBV.MontoEUR;
            }
        }

        #endregion Constructor       

        #region Eventos

        private void frmEntregaBajoAltoVolumen_Load(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void frmProcesamientoAltoVolumen_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
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

        private void btnProcesar_Click(object sender, EventArgs e) //CAMBIOS GZH 11092017
        {
            try
            {
                if (validacampos()) {
                    _procesoAV = new ProcesamientoAltoVolumen();
                    _procesoAVDet = new ProcesamientoAltoVolumenDetalle("");
                    _procesoAV.Detalle = new BindingList<ProcesamientoAltoVolumenDetalle>();
                    _procesoAVDet.Headercard = txtHeadercard.Text;
                    _procesoAVDet.Cajero = _procesoBV.ColaboradorAsociado;                    
                    _procesoAV.Cajero = _procesoBV.ColaboradorAsociado;
                    _procesoAV.Camara = (Camara)cboCamara.SelectedItem;                    
                    _procesoAVDet.Monto = nudMonto.Value;                                        
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
                    _procesoAV.Detalle.Add(_procesoAVDet);
                    _procesoAV.Monto = nudMonto.Value;
                    _procesoAV.Tipo = (byte)cboTipoEntrega.SelectedIndex;
                    if (_procesoAV.Tipo > 2)
                        _procesoAV.Tipo += 1;
                    _mantenimiento.agregarProcesamientoAltoVolumen(ref _procesoAV, _procesoBV);                    
                    _mantenimiento.agregarProcesamientoAltoVolumenDetalle(ref _procesoAVDet, _procesoAV);
                    _procesoBV =  _mantenimiento.listarProcesamientoBajoVolumenCajero(ref col);
                    //_procesoBV.Excedelimite = false;
                    this.Close();
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        #endregion Eventos                                                                               
        
        
        #region Métodos Privados

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

        #endregion Métodos Privados
    }
}
