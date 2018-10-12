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
using BussinessLayer;
using CommonObjects.Clases;


namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmLimiteEfectivo : Form
    {

        #region Atributos
        /// <summary>
        /// Atributos: instancia de seguridad, lista de cajeros y manifiesto.
        /// </summary>
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private BindingList<Colaborador> listacajero = new BindingList<Colaborador>();
        private BindingList<LimiteEfectivo> listalimiteefectivo = new BindingList<LimiteEfectivo>();
        private Manifiesto _manifiesto = null;
        private Colaborador _colaborador = null;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private LimiteEfectivo limiteefectivo = null;

        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Constructor del formulario Limite de efectivo.
        /// </summary>
        public frmLimiteEfectivo(Colaborador colaborador)
        {
            InitializeComponent();
            listacajero = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo,Puestos.CajeroA,Puestos.CajeroB,Puestos.CajeroD,Puestos.CajeroE);//Puestos.CajeroF
            cboCajeroDatos.ListaMostrada = listacajero;
            cboCajero.ListaMostrada = listacajero;
            listalimiteefectivo = _mantenimiento.listarLimiteEfectivos(0);
            dgvcajeros.AutoGenerateColumns = false;
            dgvcajeros.DataSource = listalimiteefectivo;
            _colaborador = colaborador;
            dgvcajeros.ClearSelection();

        }

        #endregion Constructor         

        #region Eventos

        private void frmLimiteEfectivo_Load(object sender, EventArgs e)
        {
            try
            {
                dgvcajeros.ClearSelection();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e) //Cambio GZH 11092017
        {
            try
            {
                byte checklimiteefectivo = 0;
                Colaborador cajero;
                Decimal limiteAD;
                Decimal limiteBD;
                Decimal limiteCOL;
                Decimal limiteDOL;
                Decimal limiteEUR; //Cambio GZH 23/08/2017
                if (cboCajeroDatos.SelectedIndex != -1)
                {
                    if (cboCajeroDatos.SelectedItem == "Todos")
                    {                        
                        limiteAD = nudMonto.Value;
                        limiteBD = nudlimiteBD.Value;
                        limiteCOL = nudlimiteCOL.Value;
                        limiteDOL = nudlimiteDOL.Value;
                        limiteEUR = nudlimiteEUR.Value; //Cambio GZH 23/08/2017
                        limiteefectivo = new LimiteEfectivo(usuario_creacion: _colaborador, limiteAD: limiteAD, limiteBD: limiteBD, limiteDOL: limiteDOL, limiteEUR: limiteEUR, limiteCOL: limiteCOL);
                        _mantenimiento.actualizarLimiteEfectivo2(limiteefectivo);
                    }
                    else
                    {
                        cajero = (Colaborador)cboCajeroDatos.SelectedItem;
                        limiteAD = nudMonto.Value;
                        limiteBD = nudlimiteBD.Value;
                        limiteCOL = nudlimiteCOL.Value;
                        limiteDOL = nudlimiteDOL.Value;
                        limiteEUR = nudlimiteEUR.Value; //Cambio GZH 23/08/2017
                        if (limiteefectivo == null)
                        {
                            foreach (LimiteEfectivo limite_efectivo in listalimiteefectivo)
                            {
                                if (limite_efectivo.Cajero.ID == cajero.ID)
                                {
                                    limiteefectivo = limite_efectivo;
                                    limiteefectivo.LimiteAD = limiteAD;
                                    limiteefectivo.LimiteBD = limiteBD;
                                    limiteefectivo.LimiteCOL = limiteCOL;
                                    limiteefectivo.LimiteDOL = limiteDOL;
                                    limiteefectivo.LimiteEUR = limiteEUR; //Cambio GZH 23/08/2017
                                    _mantenimiento.actualizarLimiteEfectivo(limiteefectivo);
                                    checklimiteefectivo = 1;
                                    break;
                                }
                            }
                            if (checklimiteefectivo == 0)
                            {
                                limiteefectivo = new LimiteEfectivo(cajero: cajero, usuario_creacion: _colaborador, limiteAD: limiteAD, limiteBD: limiteBD, limiteCOL: limiteCOL, limiteDOL: limiteDOL, limiteEUR: limiteEUR);
                                _mantenimiento.agregarLimiteEfectivo(ref limiteefectivo);
                                listalimiteefectivo.Add(limiteefectivo);
                            }
                        }
                        else
                        {
                            limiteefectivo.Cajero = cajero;
                            limiteefectivo.LimiteAD = limiteAD;
                            limiteefectivo.LimiteBD = limiteBD;
                            limiteefectivo.LimiteCOL = limiteCOL;
                            limiteefectivo.LimiteDOL = limiteDOL;
                            limiteefectivo.LimiteEUR = limiteEUR;
                            _mantenimiento.actualizarLimiteEfectivo(limiteefectivo);
                        }
                    }
                }
                else
                {       
                    epError.SetError(cboCajeroDatos, "Falta seleccionar el cajero para aplicar el límite");
                        //MessageBox.Show("Falta seleccionar el cajero para aplicar el límite", "Selección de cajero para límite de efectivo");                                                                                
                }
                listalimiteefectivo = _mantenimiento.listarLimiteEfectivos(0);
                dgvcajeros.DataSource = listalimiteefectivo;
                dgvcajeros.Refresh();
                dgvcajeros.ClearSelection();
                limpiarcampos();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnAplicarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboCajeroDatos.SelectedIndex == -1)
                {
                    epError.SetError(cboCajeroDatos, "Falta seleccionar el cajero para aplicar el límite");
                    //MessageBox.Show("Falta seleccionar el cajero para aplicar el límite", "Selección de cajero para límite de efectivo");
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboCajero.SelectedIndex == -1)
                {
                    epError.SetError(cboCajero, "Falta seleccionar el cajero para realizar la búsqueda");
                    //MessageBox.Show("Falta seleccionar el cajero para realizar la búsqueda", "Selección de cajero");
                }
                else
                {
                    if (cboCajero.SelectedIndex == 0)
                    {
                        listalimiteefectivo = _mantenimiento.listarLimiteEfectivos(0);
                    }
                    else
                    {
                        Colaborador cajero = (Colaborador)cboCajero.SelectedItem;
                        listalimiteefectivo = _mantenimiento.listarLimiteEfectivos(cajero.ID);
                    }                    
                    dgvcajeros.DataSource = listalimiteefectivo;
                    dgvcajeros.Refresh();
                    limpiarcampos();
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void dgvcajeros_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (dgvcajeros.SelectedRows.Count > 0)
            {
                limiteefectivo = (LimiteEfectivo)dgvcajeros.SelectedRows[0].DataBoundItem;
                Colaborador cajero = (Colaborador)limiteefectivo.Cajero;
                Decimal limiteAD = limiteefectivo.LimiteAD;
                Decimal limiteBD = limiteefectivo.LimiteBD;
                Decimal limiteCOL = limiteefectivo.LimiteCOL;
                Decimal limiteDOL = limiteefectivo.LimiteDOL;
                Decimal limiteEUR = limiteefectivo.LimiteEUR; //Cambios GZH 23/08/2017
                cboCajeroDatos.SelectedItem = cajero;
                nudMonto.Value = limiteAD;
                nudlimiteBD.Value = limiteBD;
                nudlimiteDOL.Value = limiteDOL;
                nudlimiteCOL.Value = limiteCOL;
                nudlimiteEUR.Value = limiteEUR; //Cambios GZH 23/08/2017
            }
            else
            {
                dgvcajeros.ClearSelection();
            }

        }

        #endregion Eventos                                                        
       

        #region Métodos Privados

        private void limpiarcampos()
        {
            cboCajeroDatos.SelectedIndex = -1;
            cboCajero.SelectedIndex = -1;
            nudMonto.Value = 0;
            nudlimiteBD.Value = 0;
            nudlimiteCOL.Value = 0;
            nudlimiteDOL.Value = 0;
            nudlimiteEUR.Value = 0; //Cambios GZH 23/08/2017
            limiteefectivo = null;
            dgvcajeros.ClearSelection();
        }

        #endregion Métodos Privados 

        private void dgvcajeros_MouseClick(object sender, MouseEventArgs e)
        {
            var ht = dgvcajeros.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                limpiarcampos();
                dgvcajeros.ClearSelection();
            }
        }

        private void cboCajeroDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCajeroDatos.SelectedIndex != -1)
            {
                limiteefectivo = null;
                epError.SetError(cboCajeroDatos, "");
            }
        }

        private void cboCajero_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCajero.SelectedIndex != -1)
            {
                epError.SetError(cboCajero, "");
            }
        }
                
    }
}
