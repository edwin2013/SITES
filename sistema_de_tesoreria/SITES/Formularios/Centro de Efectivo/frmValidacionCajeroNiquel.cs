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
using LibreriaReportesOffice;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmValidacionCajeroNiquel : Form
    {                

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;
        private DataTable _datos = null;
        private byte estatuslimpia = 0;
        private byte chkdiferencia = 0;
        decimal valornud1 = 0;
        decimal valornud2 = 0;
        decimal valornud3 = 0;
        private byte datachange = 0;
        private Colaborador _colaborador;
        private int _coordinador;
        private Boolean permisosup = false;


        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Constructor de formulario validacion Cajero Niquel. Inicializa los numeric updown, y cargar la lista de transportadoras.
        /// </summary>
        public frmValidacionCajeroNiquel(Colaborador colaborador)
        {
            InitializeComponent();
            _colaborador = colaborador;
            txtMontoContado.Text = "0";
            txtDiferencia.Text = "0";
            nudCien.Tag = nudCien.Value;
            nudCinco.Tag = nudCinco.Value;
            nudCincuenta.Tag = nudCincuenta.Value;
            nudDiez.Tag = nudDiez.Value;
            nudQuinientos.Tag = nudQuinientos.Value;
            nudVeintiCinco.Tag = nudVeintiCinco.Value;
            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();

        }        

        #endregion Constructor       

        #region Eventos
        /// <summary>
        /// Evento para el boton buscar. Habilitar los groupbox de tipo de procesamiento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtIdentificador.Text != "") && (cboTipoProcesamiento.SelectedIndex != -1))
                {                    
                    _datos = new DataTable();
                    _datos = _atencion.BusquedaInformacionNiquel((byte)cboTipoProcesamiento.SelectedIndex, txtIdentificador.Text);
                    if (_datos.Rows.Count > 0)
                    {
                        gbProcesamientoExterno.Enabled = true;
                        gbEnMesa.Enabled = true;
                        gbEntregaNiquel.Enabled = true;
                        gbMontosContados.Enabled = true;
                        txtMontoContado.Enabled = true;
                        txtDiferencia.Enabled = true;
                        btnProcesar.Enabled = true;
                        switch (cboTipoProcesamiento.SelectedIndex)
                        {
                            case 0:
                                gbEnMesa.Enabled = true;
                                gbEntregaNiquel.Enabled = false;
                                gbProcesamientoExterno.Enabled = false;
                                txtCajero.Text = _datos.Rows[0]["Cajero"].ToString();
                                txtCajero.Tag = _datos.Rows[0]["fk_ID_Cajero"];
                                datachange = 1;
                                nudTotalNiquel.Value = (decimal)_datos.Rows[0]["Total_Niquel"];
                                datachange = 0;
                                valornud1 = nudTotalNiquel.Value;
                                sumarTotales();
                                break;
                            case 1:
                                gbEnMesa.Enabled = false;
                                gbEntregaNiquel.Enabled = true;
                                gbProcesamientoExterno.Enabled = false;
                                txtCodigoManifiesto.Text = _datos.Rows[0]["Manifiesto"].ToString();
                                txtCodigoManifiesto.Tag = _datos.Rows[0]["fk_ID_Manifiesto"].ToString();
                                txtCodigoTula.Text = _datos.Rows[0]["Tula"].ToString();
                                txtCodigoTula.Tag = _datos.Rows[0]["fk_ID_Tula"].ToString();
                                txtCuenta.Text = _datos.Rows[0]["Cuenta"].ToString();
                                txtCliente.Text = _datos.Rows[0]["Cliente"].ToString();
                                txtCliente.Tag = _datos.Rows[0]["fk_ID_Cliente"].ToString();
                                txtNumDeposito.Text = _datos.Rows[0]["Numero_Deposito"].ToString();
                                txtNumDeposito.Tag = _datos.Rows[0]["fk_ID_ProcesamientoBajoVolumenDeposito"].ToString();
                                datachange = 1;
                                nudTotalNiquelCaj.Value = (decimal)_datos.Rows[0]["Monto_Niquel"];
                                nudTotalDeposito.Value = (decimal)_datos.Rows[0]["Monto_Deposito"];
                                datachange = 0;
                                valornud2 = nudTotalNiquelCaj.Value;
                                valornud3 = nudTotalDeposito.Value;
                                sumarTotales();
                                break;
                            case 2:
                                txtIdentificador.Tag = _datos.Rows[0]["pk_ID"].ToString();
                                gbEnMesa.Enabled = false;
                                gbEntregaNiquel.Enabled = false;
                                gbProcesamientoExterno.Enabled = true;
                                break;
                        }
                        txtIdentificador.ReadOnly = true;
                        cboTipoProcesamiento.Enabled = false;
                        btnBuscar.Enabled = false;
                    }
                    else
                    {
                        epError.SetError(txtIdentificador, "No se encontró información con el identificador especificado y el el tipo de procesamiento seleccionado.");
                    }                    
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }
        /// <summary>
        /// Evento botón cancelar. Cierra pantalla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        public void permisocoordinador(int ID_Coordinador)
        {
            try
            {
                permisosup = true;
                _coordinador = ID_Coordinador;
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Evento botón procesar. Se encarga de procesar la validación de Niquel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcesar_Click(object sender, EventArgs e) //cambio GZH 28/12/2017
        {
            try
            {
                if (Convert.ToDecimal(txtMontoContado.Text) != 0)
                {
                    if ((Convert.ToDecimal(txtDiferencia.Text) == 0) || (((Convert.ToDecimal(txtDiferencia.Text) != 0)) && (chkdiferencia == 1)))
                    {
                        if (Verificamontos())
                        {
                            if (MessageBox.Show("¿Está seguro que desea procesar la validación de Niquel?", "Confirmación de procesamiento", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {
                                ConteoNiquel _conteoNiquel = new ConteoNiquel(c500: nudQuinientos.Value, c100: nudCien.Value, c50: nudCincuenta.Value, c25: nudVeintiCinco.Value, c10: nudDiez.Value, c5: nudCinco.Value);
                                //insertar conteo
                                _atencion.registrarConteoNiquel(ref _conteoNiquel);
                                ProcesamientoNiquel proceso = new ProcesamientoNiquel();
                                frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(13, _colaborador);
                                switch (cboTipoProcesamiento.SelectedIndex)
                                {
                                    case 0:                                        
                                        proceso.Cajero = _colaborador.ID;
                                        proceso.conteoNiquel = _conteoNiquel;
                                        proceso.TotalNiquel = nudTotalNiquel.Value;
                                        proceso.MontoContado = _conteoNiquel.conteototal;
                                        proceso.Deposito = null;
                                        proceso.Diferencia = _conteoNiquel.conteototal - nudTotalNiquel.Value;
                                        proceso.TipoProcesamiento = cboTipoProcesamiento.SelectedIndex;
                                        proceso.Transportadora = null;
                                        proceso.Manifiesto = null;
                                        proceso.Fecha = new DateTime();
                                        proceso.Identificador = txtIdentificador.Text;                                        
                                        //_atencion.registrarProcesamientoNiquel(ref proceso);
                                        if ((proceso.Diferencia < -500) || (proceso.Diferencia > 500))
                                        {
                                            
                                            /*while (permisosup == false)
                                            {
                                                formulario.ShowDialog(this);
                                            }*/
                                            formulario.ShowDialog(this);
                                            if (permisosup == true)
                                            {
                                                imprimirInconsistenciaNiquel(proceso, txtCajero.Text);
                                                _atencion.registrarProcesamientoNiquel(ref proceso);
                                            }                                                
                                        }
                                        else
                                            _atencion.registrarProcesamientoNiquel(ref proceso);
                                        //danilo agregar parámetro
                                        //imprimirInconsistenciaNiquel(proceso, _colaborador.Nombre + ' ' + _colaborador.Primer_apellido + ' ' + _colaborador.Segundo_apellido);                                                                                                                                    
                                        //MessageBox.Show("Proceso de verificación de Niquel finalizado correctamente");
                                        break;
                                    case 1:
                                        ProcesamientoBajoVolumenManifiesto man = new ProcesamientoBajoVolumenManifiesto();
                                        man.Codigo = txtCodigoManifiesto.Text;
                                        man.IDManifiesto = Convert.ToInt32(txtCodigoManifiesto.Tag);
                                        ProcesamientoBajoVolumenDeposito pbv = new ProcesamientoBajoVolumenDeposito(ID: Convert.ToInt32(txtNumDeposito.Tag), tula:new Tula(txtCodigoTula.Text), numero_deposito: txtNumDeposito.Text, cuenta:txtCuenta.Text);
                                        proceso.Cajero = _colaborador.ID;
                                        proceso.conteoNiquel = _conteoNiquel;
                                        proceso.MontoContado = _conteoNiquel.conteototal;
                                        proceso.TotalNiquel = nudTotalNiquelCaj.Value;

                                        
                                        proceso.Manifiesto = man;
                                        proceso.Deposito = pbv;
                                        proceso.TipoProcesamiento = cboTipoProcesamiento.SelectedIndex;
                                        proceso.Diferencia = _conteoNiquel.conteototal - nudTotalNiquelCaj.Value;
                                        proceso.Transportadora = null;
                                        proceso.Fecha = new DateTime();
                                        proceso.Identificador = txtIdentificador.Text;
                                        //_atencion.registrarProcesamientoNiquel(ref proceso);
                                        if ((proceso.Diferencia < -500) || (proceso.Diferencia > 500))
                                        {
                                            /*while (permisosup == false)
                                            {
                                                formulario.ShowDialog(this);
                                            } */
                                            formulario.ShowDialog(this);
                                            if (permisosup == true)
                                            {
                                                imprimirInconsistenciaNiquel(proceso, txtCliente.Text + " " + (String)_datos.Rows[0]["PuntoVenta"]);
                                                _atencion.registrarProcesamientoNiquel(ref proceso);
                                            }                                            
                                        }
                                        else
                                            _atencion.registrarProcesamientoNiquel(ref proceso);
                                        //danilo agregar parámetro                                            
                                        //MessageBox.Show("Proceso de verificación de Niquel finalizado correctamente");
                                        break;
                                    case 2:
                                        EmpresaTransporte etr = new EmpresaTransporte();
                                        etr = (EmpresaTransporte)cboTransportadora.SelectedItem;
                                        proceso.Cajero = _colaborador.ID;
                                        proceso.conteoNiquel = _conteoNiquel;
                                        proceso.TotalNiquel = nudTotNiquelPE.Value;
                                        proceso.MontoContado = _conteoNiquel.conteototal;
                                        proceso.Deposito = null;
                                        proceso.Diferencia = _conteoNiquel.conteototal - nudTotNiquelPE.Value;
                                        proceso.TipoProcesamiento = cboTipoProcesamiento.SelectedIndex;
                                        proceso.Transportadora = etr;
                                        proceso.Manifiesto = new ProcesamientoBajoVolumenManifiesto();
                                        proceso.Manifiesto.IDManifiesto = Convert.ToInt32(txtIdentificador.Tag);
                                        proceso.Manifiesto.Codigo = txtIdentificador.Text;
                                        proceso.Fecha = new DateTime();
                                        proceso.Identificador = txtIdentificador.Text;                                        
                                        //_atencion.registrarProcesamientoNiquel(ref proceso);
                                        if ((proceso.Diferencia < -500) || (proceso.Diferencia > 500))
                                        {
                                            /*while (permisosup == false)
                                            {
                                                formulario.ShowDialog(this);
                                            }*/
                                            formulario.ShowDialog(this);
                                            if (permisosup == true)
                                            {
                                                imprimirInconsistenciaNiquel(proceso, etr.Nombre);
                                                _atencion.registrarProcesamientoNiquel(ref proceso);
                                            }                                                                                     
                                        }
                                        else
                                            _atencion.registrarProcesamientoNiquel(ref proceso);
                                        //danilo agregar parámetro                                            
                                        //MessageBox.Show("Proceso de verificación de Niquel finalizado correctamente");
                                        break;
                                }
                                if (((proceso.Diferencia > -500) && (proceso.Diferencia < 500)) || (permisosup == true))
                                {
                                    MessageBox.Show("Proceso de verificación de Niquel finalizado correctamente");
                                    limpiardatos();
                                }
                                    //insertar procesamiento Niquel.
                                    
                                /*chkdiferencia = 0;
                                //this.Close();
                                gbProcesamientoExterno.Enabled = false;
                                gbEnMesa.Enabled = false;
                                gbEntregaNiquel.Enabled = false;
                                gbMontosContados.Enabled = false;
                                txtMontoContado.Enabled = false;
                                txtDiferencia.Enabled = false;
                                btnProcesar.Enabled = false;*/
                            }
                        }
                    }
                    else
                    {
                        epError.SetError(txtDiferencia, "Existe una diferencia entre el monto contado y el monto declarado de Niquel.");
                        chkdiferencia += 1;
                    }
                }
                else
                {
                    epError.SetError(txtMontoContado, "El monto contado de Niquel no puede ser igual a cero.");
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private bool Verificamontos()
        {
            bool checkmonto = true;
            foreach (Control control in gbMontosContados.Controls)
            {
                NumericUpDown numControls = control as NumericUpDown;
                if (numControls != null)
                {
                    if (epError.GetError(numControls).Equals("") == false)
                    {
                        checkmonto = false;
                        break;
                    }                    
                }
            }
            return checkmonto;

        }
        /// <summary>
        /// Evento de selección del combo de tipo de procesamiento. Se encarga de hacer visible un groupbox asociado al tipo de procesamiento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTipoProcesamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cboTipoProcesamiento.SelectedIndex)
                {
                    case 0:
                        gbEnMesa.Visible = true;
                        gbEntregaNiquel.Visible = false;
                        gbProcesamientoExterno.Visible = false;
                        break;
                    case 1:
                        gbEnMesa.Visible = false;
                        gbEntregaNiquel.Visible = true;
                        gbProcesamientoExterno.Visible = false;
                        break;
                    case 2:
                        gbEnMesa.Visible = false;
                        gbEntregaNiquel.Visible = false;
                        gbProcesamientoExterno.Visible = true;
                        break;                    
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }
        /// <summary>
        /// Evento para validar el monto para el numeric updown de quinientos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudQuinientos_Leave(object sender, EventArgs e)
        {            
            ValidarMontos(nudQuinientos.Value, 500, nudQuinientos);            
        }
        /// <summary>
        /// Evento para validar el monto para el numeric updown de veinticinco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudVeintiCinco_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nudVeintiCinco.Value, 25, nudVeintiCinco);
        }

        /// <summary>
        /// Evento para validar el monto para el numeric updown de cien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudCien_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nudCien.Value, 100, nudCien);
        }
        /// <summary>
        /// Evento para validar el monto para el numeric updown de Diez
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudDiez_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nudDiez.Value, 10, nudDiez);
        }

        /// <summary>
        /// Evento para validar el monto para el numeric updown de cincuenta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudCincuenta_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nudCincuenta.Value, 50, nudCincuenta);
        }

        /// <summary>
        /// Evento para validar el monto para el numeric updown de cinco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudCinco_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nudCinco.Value, 5, nudCinco);
        }
        /// <summary>
        /// Evento para realizar la suma de totales cuando cambia el valor del numeric updown de quinientos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudQuinientos_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
            /*decimal mValuePre = (decimal)nudQuinientos.Tag;
            if (mValuePre >= nudQuinientos.Value)
            {
                epError.SetError(nudQuinientos, "No se puede ingresar ese monto");
            }
            else
            {
                nudCien.Tag = nudQuinientos.Value;
                sumarTotales();
            }*/
        }
        /// <summary>
        /// Evento para realizar la suma de totales cuando cambia el valor del numeric updown de Veinticinco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudVeintiCinco_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
            /*decimal mValuePre = (decimal)nudVeintiCinco.Tag;            
            if (mValuePre >= nudVeintiCinco.Value)
            {
                epError.SetError(nudVeintiCinco, "No se puede ingresar ese monto");
            }
            else
            {
                nudVeintiCinco.Tag = nudVeintiCinco.Value;
                sumarTotales();
            }*/
        }
        /// <summary>
        /// Evento para realizar la suma de totales cuando cambia el valor del numeric updown de cien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudCien_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
            /*decimal mValuePre = (decimal)nudCien.Tag;
            if (mValuePre >= nudCien.Value)
            {
                epError.SetError(nudCien, "No se puede ingresar ese monto");
            }
            else
            {
                nudCien.Tag = nudCien.Value;
                sumarTotales();
            }*/
        }
        /// <summary>
        /// Evento para realizar la suma de totales cuando cambia el valor del numeric updown de diez
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudDiez_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
            /*decimal mValuePre = (decimal)nudDiez.Tag;
            if (mValuePre >= nudDiez.Value)
            {
                epError.SetError(nudDiez, "No se puede ingresar ese monto");
            }
            else
            {
                nudDiez.Tag = nudDiez.Value;
                sumarTotales();
            }*/
        }
        /// <summary>
        /// Evento para realizar la suma de totales cuando cambia el valor del numeric updown de cincuenta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudCincuenta_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
            /*decimal mValuePre = (decimal)nudCincuenta.Tag;
            if (mValuePre >= nudCincuenta.Value)
            {
                epError.SetError(nudCincuenta, "No se puede ingresar ese monto");
            }
            else
            {
                nudCincuenta.Tag = nudCincuenta.Value;
                sumarTotales();
            }*/
        }
        /// <summary>
        /// Evento para realizar la suma de totales cuando cambia el valor del numeric updown de cinco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudCinco_ValueChanged(object sender, EventArgs e)
        {
            /*decimal mValuePre = (decimal)nudCinco.Tag;
            if (mValuePre >= nudCinco.Value)
            {
                epError.SetError(nudCinco, "No se puede ingresar ese monto");
            }
            else
            {
                nudCinco.Tag = nudCinco.Value;
                sumarTotales();
            }*/
            sumarTotales();
        }

        #endregion Eventos                                

        #region Métodos Privados
        /// <summary>
        /// Método privado para realizar la suma de totales de los valores que hay en los numeric updown y se calcula el monto contado y la diferencia con respecto al monto declarado.
        /// </summary>
        private void sumarTotales()
        {
            decimal totalMoneda = nudCien.Value + nudCinco.Value + nudCincuenta.Value + nudDiez.Value +
                        nudQuinientos.Value + nudVeintiCinco.Value;

            decimal totalDiferencia = 0;

            switch (cboTipoProcesamiento.SelectedIndex)
            {
                case 0:
                    totalDiferencia = totalMoneda - nudTotalNiquel.Value;
                    break;
                case 1:
                    totalDiferencia = totalMoneda - nudTotalNiquelCaj.Value;
                    break;
                case 2:
                    totalDiferencia = totalMoneda - nudTotNiquelPE.Value;
                    break;

            }            
            /*txtMontoContado.Text = System.Convert.ToString(totalMoneda);
            txtDiferencia.Text = System.Convert.ToString(totalDiferencia);*/
            txtMontoContado.Text = totalMoneda.ToString("n2");
            txtDiferencia.Text = totalDiferencia.ToString("n2");
        }
        /// <summary>
        /// Metodo que valida los montos de acuerdo a la denominación indicada.
        /// </summary>
        /// <param name="monto">Monto de Niquel</param>
        /// <param name="denominacion">Valor de denominación</param>
        /// <param name="t">objeto de numeric updown asociado al monto y denominación</param>
        /// <returns></returns>
        private bool ValidarMontos(Decimal monto, Decimal denominacion, NumericUpDown t)
        {
            bool bStatus = true;
            if ((monto % denominacion) != 0)
            {
                epError.SetError(t, "No se puede ingresar ese monto");
                bStatus = false;
            }
            else
                epError.SetError(t, "");


            return bStatus;

        }

        private Boolean validacampos(int tipoprocesamiento)
        {
            switch (tipoprocesamiento)
            {
                case 0:
                    if (nudTotalNiquel.Value == 0)
                    {
                        epError.SetError(nudTotalNiquel, "No se puede ingresar ese monto");
                        return false;
                    }                    
                    break;
                case 1:
                    if (txtNumDeposito.Text == "")
                    {
                        epError.SetError(txtNumDeposito, "El numero de depósito no se puede dejar en blanco");
                        return false;
                    }
                    if (txtCodigoManifiesto.Text == "")
                    {
                        epError.SetError(txtCodigoManifiesto, "El codigo de manifiesto no se puede dejar en blanco");
                        return false;
                    }
                    if (txtCliente.Text == "")
                    {
                        epError.SetError(txtCliente, "El cliente no se puede dejar en blanco");
                        return false;
                    }
                    if (txtCodigoTula.Text == "")
                    {
                        epError.SetError(txtCodigoTula, "El codigo de Tula no se puede dejar en blanco");
                        return false;
                    }
                    if (txtCuenta.Text == "")
                    {
                        epError.SetError(txtCuenta, "El número de cuenta no se puede dejar en blanco");
                        return false;
                    }
                    if (nudTotalNiquelCaj.Value == 0)
                    {
                        epError.SetError(nudTotalNiquelCaj, "No se puede ingresar ese monto");
                        return false;
                    }
                    if (nudTotalDeposito.Value == 0)
                    {
                        epError.SetError(nudTotalDeposito, "No se puede ingresar ese monto");
                        return false;
                    }
                    break;
                case 2:
                    if (nudTotNiquelPE.Value == 0)
                    {
                        epError.SetError(nudTotNiquelPE, "No se puede ingresar ese monto");
                        return false;
                    }
                    if (cboTransportadora.SelectedIndex == -1)
                    {
                        epError.SetError(cboTransportadora, "Favor seleccione una transportadora");
                        return false;
                    }
                    break;                
            }
            return true;
        }

        private void limpiardatos() {
            try
            {
                estatuslimpia = 1;
                txtCajero.Text = "";
                txtCliente.Text = "";
                txtCodigoManifiesto.Text = "";
                txtCodigoTula.Text = "";
                txtCuenta.Text = "";
                txtDiferencia.Text = "";
                txtIdentificador.Text = "";
                txtMontoContado.Text = "";
                txtNumDeposito.Text = "";
                datachange = 1;
                nudTotalDeposito.Value = 0;
                nudTotalNiquel.Value = 0;
                nudTotalNiquelCaj.Value = 0;
                nudTotNiquelPE.Value = 0;
                datachange = 0;
                nudCien.Value = 0;
                nudCinco.Value = 0;
                nudCincuenta.Value = 0;
                nudDiez.Value = 0;
                nudQuinientos.Value = 0;
                nudVeintiCinco.Value = 0;
                gbEnMesa.Enabled = false;
                gbEntregaNiquel.Enabled = false;
                gbMontosContados.Enabled = false;
                gbProcesamientoExterno.Enabled = false;
                txtIdentificador.ReadOnly = false;
                cboTipoProcesamiento.Enabled = true;
                btnBuscar.Enabled = true;
                estatuslimpia = 0;
                chkdiferencia = 0;
                permisosup = false;
                foreach (Control control in gbMontosContados.Controls)
                {
                    NumericUpDown numControls = control as NumericUpDown;
                    if (numControls != null)
                    {
                        numControls.Value = 0;
                        epError.SetError(numControls, "");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error limpiardatos: " + ex.Message);
            }
        }

        #endregion Métodos Privados        

        private void frmValidacionCajeroNiquel_Load(object sender, EventArgs e)
        {
            
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiardatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error btnlimpiar: " + ex.Message);
            }
        }

        private void nudTotalNiquel_ValueChanged(object sender, EventArgs e)
        {
            if (datachange == 0)
            {
                if (nudTotalNiquel.Value != valornud1)
                {
                    nudTotalNiquel.Value = valornud1;
                    sumarTotales();
                }
            }
            else valornud1 = nudTotalNiquel.Value;
        }

        private void nudTotalDeposito_ValueChanged(object sender, EventArgs e)
        {
            if (datachange == 0)
            {
                if (nudTotalDeposito.Value != valornud3)
                {
                    nudTotalDeposito.Value = valornud3;
                    sumarTotales();
                }
            }
            else valornud3 = nudTotalDeposito.Value;
        }

        private void nudTotalNiquelCaj_ValueChanged(object sender, EventArgs e)
        {
            if (datachange == 0)
            {
                if (nudTotalNiquelCaj.Value != valornud2)
                {
                    nudTotalNiquelCaj.Value = valornud2;
                    sumarTotales();
                }
            }
            else valornud2 = nudTotalNiquelCaj.Value;
        }

        private void txtIdentificador_TextChanged(object sender, EventArgs e)
        {
            epError.SetError(txtIdentificador, "");
        }

        private void nudTotNiquelPE_Leave(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudTotalNiquel_Leave(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudTotNiquelPE_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudTotalNiquelCaj_Leave(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void txtMontoContado_TextChanged(object sender, EventArgs e)
        {
            epError.SetError(txtMontoContado, "");
        }

        private void txtDiferencia_TextChanged(object sender, EventArgs e)
        {
            if (!txtDiferencia.Text.Equals(""))
            {
                if (Convert.ToDecimal(txtDiferencia.Text) == 0)
                {
                    epError.SetError(txtDiferencia, "");
                }
            }
        }

        //danilo agregar parámetro
        private void imprimirInconsistenciaNiquel(ProcesamientoNiquel pbv, String cliente)
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla Detalle_Inconsistencias_Tesoreria.xlsx", false);
                TimeSpan time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second); // hours, minutes, seconds
                //TimeSpan time = new TimeSpan(12, 20, 20); // hours, minutes, seconds
                DateTime fecha = DateTime.Today + time;

                documento.seleccionarHoja(1);
                if (pbv.Diferencia < 0)
                {
                    documento.seleccionarCelda("D9");
                }
                else
                {
                    //danilo---
                    documento.seleccionarCelda("I9");
                    //---
                }
                documento.actualizarValorCelda("X");
                documento.seleccionarCelda("D11");
                documento.actualizarValorCelda("X");

                //documento.seleccionarCelda("E15");
                //danilo
                documento.llenarcuadrodetexto("Rectangle 13", cliente);
             

                if (pbv.Deposito != null)
                {
                    //documento.seleccionarCelda("L15");
                    documento.llenarcuadrodetexto("Rectangle 14", pbv.Deposito.NumeroDeposito);
                    //documento.actualizarValorCelda(pbv.Deposito.NumeroDeposito);
                    //documento.seleccionarCelda("D19");
                    documento.llenarcuadrodetexto("Rectangle 18", pbv.Deposito.Cuenta);
                    //documento.actualizarValorCelda(pbv.Deposito.Cuenta);
                    if (pbv.Deposito.Tula != null)
                    {
                        //documento.seleccionarCelda("L17");
                        documento.llenarcuadrodetexto("Rectangle 15", pbv.Deposito.Tula.Codigo);
                        //documento.actualizarValorCelda(pbv.Deposito.Tula.Codigo);
                    }
                }

                if (pbv.Manifiesto != null)
                {
                    //documento.seleccionarCelda("E17");
                    documento.llenarcuadrodetexto("Rectangle 17", pbv.Manifiesto.Codigo);
                    //documento.actualizarValorCelda(pbv.Manifiesto.Codigo);
                }

                documento.llenarcuadrodetexto("Rectangle 16", "NIQUEL CEF");

                /*documento.seleccionarCelda("H19");
                documento.actualizarValorCelda(m.Camara.ToString());*/

                //documento.seleccionarCelda("N19");
                documento.llenarcuadrodetexto("Rectangle 19", fecha.ToLongTimeString());
                //documento.actualizarValorCelda(fecha.ToLongTimeString());

                documento.seleccionarCelda("G33");
                documento.actualizarValorCelda(pbv.Diferencia);

                documento.seleccionarCelda("C36");
                documento.actualizarValorCelda("Monto declarado por cliente: " + pbv.TotalNiquel);

                documento.seleccionarCelda("C37");
                documento.actualizarValorCelda("Monto recibido: " + pbv.MontoContado);

                documento.seleccionarCelda("H26");
                documento.actualizarValorCelda("X");

                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        private void nudQuinientos_Click(object sender, EventArgs e)
        {
            try
            {
                nudQuinientos.Select(0, nudQuinientos.Text.Length);
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudQuinientos_Enter(object sender, EventArgs e)
        {
            try
            {
                nudQuinientos.Select(0, nudQuinientos.Text.Length);
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudCien_Click(object sender, EventArgs e)
        {
            try
            {
                nudCien.Select(0, nudCien.Text.Length);
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudCien_Enter(object sender, EventArgs e)
        {
            try
            {
                nudCien.Select(0, nudCien.Text.Length);
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudCincuenta_Click(object sender, EventArgs e)
        {
            try
            {
                nudCincuenta.Select(0, nudCincuenta.Text.Length);
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudCincuenta_Enter(object sender, EventArgs e)
        {
            try
            {
                nudCincuenta.Select(0, nudCincuenta.Text.Length);
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudVeintiCinco_Click(object sender, EventArgs e)
        {
            try
            {
                nudVeintiCinco.Select(0, nudVeintiCinco.Text.Length);
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudVeintiCinco_Enter(object sender, EventArgs e)
        {
            try
            {
                nudVeintiCinco.Select(0, nudVeintiCinco.Text.Length);
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudDiez_Click(object sender, EventArgs e)
        {
            try
            {
                nudDiez.Select(0, nudDiez.Text.Length);
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudDiez_Enter(object sender, EventArgs e)
        {
            try
            {
                nudDiez.Select(0, nudDiez.Text.Length);
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudCinco_Click(object sender, EventArgs e)
        {
            try
            {
                nudCinco.Select(0, nudCinco.Text.Length);
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudCinco_Enter(object sender, EventArgs e)
        {
            try
            {
                nudCinco.Select(0, nudCinco.Text.Length);
            }
            catch (Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
