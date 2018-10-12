//
//  @ Project : 
//  @ File Name : frmValidacionCoordinador.cs
//  @ Date : 03/12/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using GUILayer.Formularios.Centro_de_Efectivo;
using CommonObjects.Clases;

namespace GUILayer
{

    public partial class frmValidacionCoordinadorCE : Form
    {

        #region Atributos

        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _colaborador = null;
        private int _formnew = 0;
        private Colaborador _cajero = null;
        private ProcesamientoBajoVolumenManifiesto _manifiesto = null;
        private ProcesamientoBajoVolumen _procesoBAV = null;

        #endregion Atributos

        #region Constructor

        public frmValidacionCoordinadorCE(int formnew, Colaborador colaborador, ProcesamientoBajoVolumenManifiesto manifiesto = null, ProcesamientoBajoVolumen procesoBAV = null)
        {
            InitializeComponent();
            _formnew = formnew;
            _cajero = colaborador;
            _manifiesto = manifiesto;
            _procesoBAV = procesoBAV;

        }
         
        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de verificar el código del colaborador.
        /// </summary>
        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Equals(string.Empty) || txtContrasena.Text.Equals(string.Empty))
                return;

            try
            {
                string codigo = txtCodigo.Text;
                string contrasena = txtContrasena.Text;

                _colaborador = _seguridad.validarCodigoColaborador(codigo, contrasena);

                txtNombre.Text = _colaborador.ToString();
                txtIdentificacion.Text = _colaborador.Identificacion;

                /*btnAceptar.Enabled = _colaborador.Puestos.Contains(Puestos.Coordinador) ||
                                     _colaborador.Puestos.Contains(Puestos.Supervisor);*/
                btnAceptar.Enabled = (_colaborador == null) ? false : true; //Cambio GZH 21/11/2017

                if (btnAceptar.Enabled == true)
                {
                    if (_formnew == 9)
                    {
                        grpcomentarios.Visible = true;
                        txtcomentario.Focus();
                    }
                    else
                    {
                        btnAceptar.Focus();
                    }                      
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();

                _colaborador = null;

                txtNombre.Text = string.Empty;
                txtIdentificacion.Text = string.Empty;

                btnAceptar.Enabled = false;
            }

            txtCodigo.Text = string.Empty;
            txtContrasena.Text = string.Empty;
        }

        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (_formnew)
            {
                case 1:
                    this.Hide();
                    frmBajoVolumenIngresoManifiesto padre = (frmBajoVolumenIngresoManifiesto)this.Owner; //MANIFIESTO
                    padre.actualizarmanifiesto(_colaborador);
                    break;
                case 2:
                    this.Hide();
                    frmModificarTula formulario2 = new frmModificarTula(_cajero, _colaborador, _manifiesto); //TULA
                    formulario2.ShowDialog();
                    this.Close();
                    break;
                case 3:
                    this.Hide();
                    frmCierreCajero padre2 = (frmCierreCajero)this.Owner; //Cierre de Cajero
                    padre2.permisocoordinador(_colaborador.ID);
                    break;
                case 4:
                    this.Hide();
                    frmEntregaBajoAltoVolumen formulario = new frmEntregaBajoAltoVolumen(ref _procesoBAV, ref _colaborador);
                    formulario.ShowDialog();
                    this.Close();
                    break;
                case 5: //Proceso Bajo Volumen Ingreso Depósitos
                    this.Hide();
                    frmBajoVolumenIngresoDepositos padre3 = (frmBajoVolumenIngresoDepositos)this.Owner;
                    padre3.permisocoordinador(_colaborador.ID);
                    this.Close();
                    break;
                case 6:
                    this.Hide();
                    frmBajoVolumenIngresoManifiesto padre4 = (frmBajoVolumenIngresoManifiesto)this.Owner;
                    padre4.permisocoordinador(_colaborador.ID);
                    this.Close();
                    break;
                case 7:
                    this.Hide();
                    frmCierreCajero padre5 = (frmCierreCajero)this.Owner;
                    padre5.permisocoordinador(_colaborador.ID);
                    this.Close();
                    break;
                case 8:
                    this.Hide();
                    frmValidacionAltoVolumen formulario3 = (frmValidacionAltoVolumen)this.Owner;
                    formulario3.permisocoordinador(_colaborador.ID);
                    this.Close();
                    break;
                case 9:
                    this.Hide();
                    frmPantallaResumenManifiestoPBV padre6 = (frmPantallaResumenManifiestoPBV)this.Owner;
                    padre6.permisocoordinadorinconsistencia(_colaborador.ID, txtcomentario.Text);
                    break;
                case 10:
                    this.Hide();
                    frmTipoEntregaAV formulario4 = new frmTipoEntregaAV(ref _procesoBAV, ref _colaborador);
                    formulario4.ShowDialog();
                    this.Close();
                    break;
                case 11:
                    this.Hide();
                    frmProcesamientoAltoVolumen padre7 = (frmProcesamientoAltoVolumen)this.Owner;
                    padre7.permisocoordinador(_colaborador.ID);
                    this.Close();
                    break;
                case 12:
                    this.Hide();
                    frmConsultaAltoVolumen padre8 = (frmConsultaAltoVolumen)this.Owner;
                    padre8.permisocoordinador(_colaborador.ID);
                    this.Close();
                    break;
                case 13:
                    this.Hide();
                    frmValidacionCajeroNiquel padre9 = (frmValidacionCajeroNiquel)this.Owner;
                    padre9.permisocoordinador(_colaborador.ID);
                    this.Close();
                    break;
            }            
        }

        /// <summary>
        /// Clic en el botón de cancelar.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //danilo--
            if(_formnew == 9)
            {
                frmPantallaResumenManifiestoPBV padre = (frmPantallaResumenManifiestoPBV)this.Owner;
                padre.mostrarResumenManifiesto = true;
            }
            if (_formnew == 11)
            {
                frmProcesamientoAltoVolumen padre = (frmProcesamientoAltoVolumen)this.Owner;
                padre.insertarPAV = false;
            }
            //---
            this.Close();
        }

        #endregion Eventos

        private void frmValidacionCoordinador_Load(object sender, EventArgs e)
        {

        }

    }

}
