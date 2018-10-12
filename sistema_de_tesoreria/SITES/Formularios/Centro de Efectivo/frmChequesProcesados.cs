using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
using LibreriaMensajes;
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
    public partial class frmChequesProcesados : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        

        private ChequesProcesados _cheques_procesados = null;
        private Colaborador _colaborador = null; 


        #endregion Atributos

        #region Constructor

        public frmChequesProcesados(Colaborador colaborador)
        {
            InitializeComponent();
            _colaborador = colaborador;
            dgvChequesRechazo.AutoGenerateColumns = false;
            dgvCheques.AutoGenerateColumns = false;
            dgvCortes.AutoGenerateColumns = false;
            txtOficialCamara.Text = colaborador.ToString();

            dgvCortes.DataSource = new BindingList<CorteCheque>();
            dgvCheques.DataSource = new BindingList<Cheque>();
            dgvChequesRechazo.DataSource = new BindingList<Cheque>();

            cboEntregado.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Oficial);
            cboDigitador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Digitador);
  
           
        }

        public frmChequesProcesados(ChequesProcesados chequesprocesado, Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;
            _cheques_procesados = chequesprocesado;
            dgvChequesRechazo.AutoGenerateColumns = false;
            dgvCheques.AutoGenerateColumns = false;
            dgvCortes.AutoGenerateColumns = false;

            _cheques_procesados = chequesprocesado;
            txtOficialCamara.Text = chequesprocesado.OficialCamara.ToString();



            dgvChequesRechazo.DataSource = _cheques_procesados.ChequesRechazados;
            dgvCortes.DataSource = _cheques_procesados.Cheques;
            dgvChequesRechazo.DataSource = _cheques_procesados.ChequesRechazados;

            nudChequesExteriorColones.Value = _cheques_procesados.ChequesExteriorColones;
            nudChequesExteriorDolares.Value = _cheques_procesados.ChequesExteriorDolares;
            nudChequesNuestrosDolares.Value = _cheques_procesados.ChequesNuestrosDolares;
            nudChequesNuestrosColones.Value = _cheques_procesados.ChequesNuestrosDolares;
            nudMontoChequesLocalesColones.Value = _cheques_procesados.ChequesLocalesColones;
            nudMontoChequesLocalesDolares.Value = _cheques_procesados.ChequesLocalesDolares;
            nudCuponesCombustible.Value = _cheques_procesados.CuponesCombustible;
            nudCuponesCombustibleDolares.Value = _cheques_procesados.CuponesCombustibleDolares;


            cboEntregado.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Oficial);
            cboDigitador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Digitador);



        }

      

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Cambio en la 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCortes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCortes.SelectedRows.Count > 0)
                {
                    CorteCheque corte = (CorteCheque)dgvCortes.SelectedRows[0].DataBoundItem;
                    gbCheques.Enabled = true;
                    dgvCheques.DataSource = corte.Cheques;
                }
                else
                {
                    gbCheques.Enabled = false;
                }
            }
            catch (Excepcion ex)
            {

            }
        }

        private void pnlFondo_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
      


        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            try
            {
                frmAdministracionChequesProcesados padre = (frmAdministracionChequesProcesados)this.Owner;

             


                if (_cheques_procesados == null)
                {
                    Colaborador oficialcamara = _colaborador;
                    Colaborador digitador = (Colaborador)cboDigitador.SelectedItem;
                    decimal cheques_exterior_colones = nudChequesExteriorColones.Value;
                    decimal cheques_exterior_dolares = nudChequesExteriorDolares.Value;
                    decimal cheques_locales_colones = nudMontoChequesLocalesColones.Value;
                    decimal cheques_locales_dolares = nudMontoChequesLocalesDolares.Value;
                    decimal cheques_nustros_colones = nudChequesNuestrosColones.Value;
                    decimal cheques_nuestros_dolares = nudChequesNuestrosDolares.Value;
                    decimal cheques_cupones_colones = nudCuponesCombustible.Value;
                    decimal cheques_cupones_dolares = nudCuponesCombustibleDolares.Value; 

                    DateTime fecha = dtpFecha.Value;
                    _cheques_procesados = new ChequesProcesados(oficial_camara: oficialcamara, digitador:digitador, cheques_exterior_colones: cheques_exterior_colones, cheques_exterior_dolares: cheques_exterior_dolares, 
                        cheques_locales_colones: cheques_locales_colones, cheques_locales_dolares: cheques_locales_dolares, cheques_nuestros_colones: cheques_nustros_colones, cheques_nuestros_dolares: cheques_nuestros_dolares,
                        cupones_combustible: cheques_cupones_colones,cupones_combustible_dolares: cheques_cupones_dolares);
                    _cheques_procesados.Cheques = (BindingList<CorteCheque>)dgvCortes.DataSource;
                    _cheques_procesados.ChequesRechazados = (BindingList<Cheque>)dgvChequesRechazo.DataSource;
                    

                    _atencion.agregarChequesProcesados(ref _cheques_procesados);
                    limpiarDatos();
                    Mensaje.mostrarMensaje("MensajeChequesConfirmacionActualizacion");
                }
                else
                {
                    Colaborador oficialcamara = _colaborador;
                    Colaborador digitador = (Colaborador)cboDigitador.SelectedItem;
                    decimal cheques_exterior_colones = nudChequesExteriorColones.Value;
                    decimal cheques_exterior_dolares = nudChequesExteriorDolares.Value;
                    decimal cheques_locales_colones = nudMontoChequesLocalesColones.Value;
                    decimal cheques_locales_dolares = nudMontoChequesLocalesDolares.Value;
                    decimal cheques_nustros_colones = nudChequesNuestrosColones.Value;
                    decimal cheques_nuestros_dolares = nudChequesNuestrosDolares.Value;
                    decimal cheques_cupones_colones = nudCuponesCombustible.Value;
                    decimal cheques_cupones_dolares = nudCuponesCombustibleDolares.Value;
                    ChequesProcesados copia_cheques = new ChequesProcesados(id:_cheques_procesados.ID, oficial_camara: oficialcamara, digitador: digitador, cheques_exterior_colones: cheques_exterior_colones, cheques_exterior_dolares: cheques_exterior_dolares,
                        cheques_locales_colones: cheques_locales_colones, cheques_locales_dolares: cheques_locales_dolares, cheques_nuestros_colones: cheques_nustros_colones, cheques_nuestros_dolares: cheques_nuestros_dolares,
                        cupones_combustible: cheques_cupones_colones, cupones_combustible_dolares: cheques_cupones_dolares);

                    _cheques_procesados.Cheques = (BindingList<CorteCheque>)dgvCortes.DataSource;
                    _cheques_procesados.ChequesRechazados = (BindingList<Cheque>)dgvChequesRechazo.DataSource;

                    _atencion.actualizarChequesProcesados(_cheques_procesados);
                    limpiarDatos();
                    Mensaje.mostrarMensaje("MensajeChequesConfirmacionActualizacion");
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


        /// Clic en agregar Corte de cheques. 
        /// </summary>
        private void btnAgregarCorte_Click(object sender, EventArgs e)
        {
           
            int numero = (int)nudCorte.Value;
            CorteCheque corte_cheque = new CorteCheque(numero: numero);

            BindingList<CorteCheque> cortes = (BindingList<CorteCheque>)dgvCortes.DataSource;

            cortes.Add(corte_cheque);

            dgvCortes.Refresh();
        }



        /// <summary>
        /// Clic en quitar corte de cheques. 
        /// </summary>
        private void btnQuitarCorte_Click(object sender, EventArgs e)
        {
            BindingList<CorteCheque> cortes = (BindingList<CorteCheque>)dgvCortes.DataSource;
            CorteCheque corte = (CorteCheque)dgvCortes.SelectedRows[0].DataBoundItem;

            cortes.Remove(corte);

            dgvCortes.Refresh();
        }



        /// <summary>
        /// Agregar Cheque
        /// </summary>
        private void btnAgregarCheque_Click(object sender, EventArgs e)
        {

            CorteCheque corte_cheque = (CorteCheque)dgvCortes.SelectedRows[0].DataBoundItem;


            Colaborador entregado = (Colaborador)cboEntregado.SelectedItem;
            TipoCheque tipo = (TipoCheque)cboTipoCheque.SelectedIndex;
            DateTime hora = dtpHora.Value;
            int cantidad = (int)nudCantidadCheques.Value;
            decimal monto = nudMontoCheque.Value;
            Monedas moneda = (Monedas)cboMoneda.SelectedIndex;


            Cheque ch = new Cheque(usuario_entrega: entregado, cantidad: cantidad, fecha: hora, tipoc: tipo, rechazo: false, monto: monto, moneda: moneda);

            corte_cheque.agregarDatos(ch);

            dgvCheques.DataSource = corte_cheque.Cheques;

            dgvCheques.Refresh();
        }


        /// <summary>
        /// Quitar Cheques
        /// </summary>
        private void btnQuitarCheque_Click(object sender, EventArgs e)
        {
            if(dgvCheques.SelectedRows.Count>0)
            {
                Cheque ch = (Cheque)dgvCheques.SelectedRows[0].DataBoundItem;

                CorteCheque corte_cheque = (CorteCheque)dgvCortes.SelectedRows[0].DataBoundItem;


                corte_cheque.Cheques.Remove(ch);

                dgvCheques.Refresh();
            }

           
        }


        /// <summary>
        /// Agregar cheque rechazo
        /// </summary>
        private void btnAgregarChequeRechazo_Click(object sender, EventArgs e)
        {

            BindingList<Cheque> _rechazados = (BindingList<Cheque>)dgvChequesRechazo.DataSource;

            int cantidad = Convert.ToInt32(txtNumeroChequeRechazo.Text);
            decimal monto = nudMontoChequeRechazo.Value;
            Monedas moneda = (Monedas)cboMonedaRechazo.SelectedIndex;

            Cheque ch = new Cheque(cantidad: cantidad, rechazo: true, monto: monto, moneda: moneda);

            _rechazados.Add(ch);

            dgvChequesRechazo.DataSource = _rechazados;

            dgvCheques.Refresh();
        }


        /// <summary>
        /// Eliminar cheque rechazo
        /// </summary>
        private void btnQuitarChequeRechazo_Click(object sender, EventArgs e)
        {

            if(dgvChequesRechazo.SelectedRows.Count > 0)
            {
                BindingList<Cheque> cheques = (BindingList<Cheque>)dgvChequesRechazo.DataSource;
                Cheque ch = (Cheque)dgvChequesRechazo.SelectedRows[0].DataBoundItem;
                cheques.Remove(ch);
    
                dgvCheques.Refresh();

            }
            
        }


      

        #endregion Eventos

        #region Métodos Privados


        public void limpiarDatos()
        {
            dgvCortes.DataSource = new BindingList<CorteCheque>();
            dgvCheques.DataSource = new BindingList<Cheque>();
            dgvChequesRechazo.DataSource = new BindingList<Cheque>();
            nudCantidadCheques.Value = 0;
            nudChequesExteriorColones.Value = 0;
            nudChequesExteriorDolares.Value = 0;
            nudChequesNuestrosColones.Value = 0;
            nudChequesNuestrosDolares.Value = 0;
            nudCorte.Value = 0;
            nudCuponesCombustible.Value = 0;
            nudCuponesCombustibleDolares.Value = 0;
            nudMontoCheque.Value = 0;
            nudMontoChequeRechazo.Value = 0;
            nudMontoChequesLocalesColones.Value = 0;
            nudMontoChequesLocalesDolares.Value = 0;
            txtNumeroChequeRechazo.Text = "";
            txtOficialCamara.Text = "";
        
        }

        #endregion Métodos Privados


    }
}
