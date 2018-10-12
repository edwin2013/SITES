using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
using LibreriaMensajes;
using LibreriaReportesOffice;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Níquel
{
    public partial class frmMantenimientoArqueoNiquel : Form
    {
        #region Atributos
        
        private ArrayList _numeros_colones = new ArrayList();
        private ArrayList _numeros_monedas = new ArrayList();
        private ArrayList _numeros_dolares = new ArrayList();
        private ArrayList _numeros_euros = new ArrayList();

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private Colaborador _usuario = null;
        private BindingList<Arqueo> _arqueos = new BindingList<Arqueo>();

        private Arqueo _arqueo = null;

        private decimal _colas = 0;
        private decimal _mutilado = 0;
        #endregion Atributos

        #region Constructor

        public frmMantenimientoArqueoNiquel(Colaborador usuario)
        {
            InitializeComponent();
            _usuario = usuario;
        }

        //public frmMantenimientoArqueoNiquel(Colaborador usuario, Arqueo arqueo)
        //{
        //    InitializeComponent();
        //    _usuario = usuario;

        //    _arqueo = arqueo;

        //    cargarArqueo();
        //}


        #endregion Constructor

        #region Eventos

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (cboTipoMoneda.Text != "")
            {
                BindingList<Arqueo> arqueo = _mantenimiento.listarArqueosNiquel(dtpFecha.Value);

                if (arqueo.Count > 0)
                {
                    _arqueo = arqueo[0];
                    cargarArqueo();
                }
            }
        }

        private void nudTotalMoneda_ValueChanged(object sender, EventArgs e)
        {
            calcularResumen();
        }

        private void nudTotalResumen_ValueChanged(object sender, EventArgs e)
        {
            nudSaldoArqueo.Value = nudTotalResumen.Value;
        }

        private void nudSaldoContable_ValueChanged(object sender, EventArgs e)
        {
            calcularDiferencia();
        }

        private void nudSaldoArqueo_ValueChanged(object sender, EventArgs e)
        {
            calcularDiferencia();
        }

        private void cboTipoArqueo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoMoneda.Text != "")
            { 
                pnlArqueo.Enabled = true;
                habilitar();
            }
            else 
            {
                //pnlArqueo.Enabled = false;
            }
        }

        private void cboTipoMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoMoneda.Text != "")
            {
                pnlArqueo.Enabled = true;
                limpiar();
                //habilitar();
            }
            else
            {
                pnlArqueo.Enabled = false;
            }
        }

        private void nud1billete_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nud5billete_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nud10billete_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nud20billete_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nud50billete_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nud100billete_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nud200billete_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nud500billete_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nud1000billete_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nud2000billete_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nud5000billete_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nud10000billete_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nud20000billete_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nud50000billete_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudColasBillete_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudMutiladoBillete_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudTotalBillete_ValueChanged(object sender, EventArgs e)
        {
            calcularResumen();
        }

        private void nud5moneda_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nud10moneda_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nud20moneda_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nud25moneda_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nud50moneda_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nud100moneda_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nud500moneda_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nud1billete_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud1billete.Value, 1, nud1billete);
        }

        private void nud5billete_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud5billete.Value, 5, nud5billete);
        }

        private void nud10billete_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud10billete.Value, 10, nud10billete);
        }

        private void nud20billete_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud20billete.Value, 20, nud20billete);
        }

        private void nud50billete_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud50billete.Value, 50, nud50billete);
        }

        private void nud100billete_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud100billete.Value, 100, nud100billete);
        }

        private void nud200billete_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud200billete.Value, 200, nud200billete);
        }

        private void nud500billete_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud500billete.Value, 500, nud500billete);
        }

        private void nud1000billete_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud1000billete.Value, 1000, nud1000billete);
        }

        private void nud2000billete_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud2000billete.Value, 2000, nud2000billete);
        }

        private void nud5000billete_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud5000billete.Value, 5000, nud5000billete);
        }

        private void nud10000billete_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud10000billete.Value, 10000, nud10000billete);
        }

        private void nud20000billete_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud20000billete.Value, 20000, nud20000billete);
        }

        private void nud50000billete_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud50000billete.Value, 50000, nud50000billete);
        }

        private void nud5moneda_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud5moneda.Value, 5, nud5moneda);
        }

        private void nud10moneda_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud10moneda.Value, 10, nud10moneda);
        }

        private void nud20moneda_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud20moneda.Value, 20, nud20moneda);
        }

        private void nud25moneda_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud25moneda.Value, 25, nud25moneda);
        }

        private void nud50moneda_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud50moneda.Value, 50, nud50moneda);
        }

        private void nud100moneda_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud100moneda.Value, 100, nud100moneda);
        }

        private void nud500moneda_Leave(object sender, EventArgs e)
        {
            ValidarMontos(nud500moneda.Value, 500, nud500moneda);
        }


        private void nudColasMoneda_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudMutiladoMoneda_ValueChanged(object sender, EventArgs e)
        {
            sumarTotales();
        }

        private void nudBillete_ValueChanged(object sender, EventArgs e)
        {
            nudTotalResumen.Value = nudMoneda.Value + nudBillete.Value;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //frmAdministracionArqueoNiquel _padre = (frmAdministracionArqueoNiquel)this.Owner; 
            try
            {
                //if (epError.ToString() == "")
                //{
                    _arqueos.Clear();

                    Dictionary<double, decimal> denominaciones_colones = this.obtenerDenominacionesColonesBilletes();
                    Dictionary<double, decimal> denominaciones_colonesMonedas = this.obtenerDenominacionesColonesMonedas();
                    Dictionary<double, decimal> denominaciones_dolares = this.obtenerDenominacionesDolares();
                    Dictionary<double, decimal> denominaciones_euros = this.obtenerDenominacionesEuros();

                    Arqueo nuevo = new Arqueo();
                    nuevo = new Arqueo(id: 0, fecha_ingreso: dtpFecha.Value, colaborador: _usuario, comentario: txtComentario.Text, inicio: dtpInicio.Value, fin: dtpFin.Value,
                        faltante: nudFaltante.Value, sobrante: nudSobrante.Value, saldocontable: nudSaldoContable.Value, saldoarqueo: nudSaldoArqueo.Value,
                        codigocajero: txtCodigoCajero.Text, cuentacontable: Convert.ToDecimal(txtCuenta.Text), colas:_colas, mutilado:_mutilado);

                    generarCargasMoneda(Monedas.Colones, DateTime.Today, denominaciones_colones, _numeros_colones, nuevo);
                    generarCargasMoneda(Monedas.Colones, DateTime.Today, denominaciones_colonesMonedas, _numeros_monedas, nuevo);
                    generarCargasMoneda(Monedas.Dolares, DateTime.Today, denominaciones_dolares, _numeros_dolares, nuevo);
                    generarCargasMoneda(Monedas.Euros, DateTime.Today, denominaciones_euros, _numeros_euros, nuevo);

                    _mantenimiento.importarArqueo(nuevo, _usuario);

                    Mensaje.mostrarMensaje("MensajeArqueoConfirmacionRegistro");

                    //_padre.agregarArqueos(nuevo);
                    this.Close();
                //}

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                MonedaArqueo moneda = (MonedaArqueo)cboTipoMoneda.SelectedIndex;
                exportarArqueo(moneda);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudColasBillete_Leave(object sender, EventArgs e)
        {
            if (nudColasBillete.Value > 0)
                _colas = nudColasBillete.Value;
        }

        private void nudColasMoneda_Leave(object sender, EventArgs e)
        {
            if (nudColasMoneda.Value > 0)
                _colas = nudColasMoneda.Value;
        }

        private void nudMutiladoBillete_Leave(object sender, EventArgs e)
        {
            if (nudMutiladoBillete.Value > 0)
                _mutilado = nudMutiladoBillete.Value;
        }

        private void nudMutiladoMoneda_Leave(object sender, EventArgs e)
        {
            if (nudMutiladoMoneda.Value > 0)
                _mutilado = nudMutiladoMoneda.Value;
        } 

        #endregion Eventos

        #region Metodos Privados

        private void cargarArqueo()
        {
           
            txtComentario.Text = _arqueo.Comentario;
            txtCuenta.Text = _arqueo.CuentaContable.ToString();

            nudSobrante.Value = _arqueo.Sobrante;
            nudFaltante.Value = _arqueo.Faltante;
            nudSaldoArqueo.Value = _arqueo.SaldoArqueo;
            nudSaldoContable.Value = _arqueo.SaldoContable;

            dtpFecha.Value = _arqueo.Fecha;
            dtpInicio.Value = _arqueo.Inicio;
            dtpFin.Value = _arqueo.Fin;


            foreach (DenominacionArqueo a in _arqueo.Denominaciones)
            {
                if (a.Denominacion.Moneda == Monedas.Colones)
                {
                    if (cboTipoMoneda.Text == "Colones Billetes")
                    {
                        if (a.Denominacion.Valor == 1000)
                            nud1000billete.Value = a.MontoTotal;
                        if (a.Denominacion.Valor == 10000)
                            nud10000billete.Value = a.MontoTotal;
                        if (a.Denominacion.Valor == 20000)
                            nud20000billete.Value = a.MontoTotal;
                        if (a.Denominacion.Valor == 2000)
                            nud2000billete.Value = a.MontoTotal;
                        if (a.Denominacion.Valor == 50000)
                            nud50000billete.Value = a.MontoTotal;
                        if (a.Denominacion.Valor == 5000)
                            nud5000billete.Value = a.MontoTotal;
                    }

                    if (cboTipoMoneda.Text == "Colones Monedas")
                    {

                        if (a.Denominacion.Valor == 5)
                            nud5moneda.Value = a.MontoTotal;
                        if (a.Denominacion.Valor == 10)
                            nud10moneda.Value = a.MontoTotal;
                        if (a.Denominacion.Valor == 20)
                            nud20moneda.Value = a.MontoTotal;
                        if (a.Denominacion.Valor == 25)
                            nud25moneda.Value = a.MontoTotal;
                        if (a.Denominacion.Valor == 50)
                            nud50moneda.Value = a.MontoTotal;
                        if (a.Denominacion.Valor == 100)
                            nud100moneda.Value = a.MontoTotal;
                        if (a.Denominacion.Valor == 500)
                            nud500moneda.Value = a.MontoTotal;
                    }
                }
                if (a.Denominacion.Moneda == Monedas.Dolares && cboTipoMoneda.Text == "Dólares")
                {
                    if (a.Denominacion.Valor == 1)
                        nud1billete.Value = a.MontoTotal;
                    if (a.Denominacion.Valor == 5)
                        nud5billete.Value = a.MontoTotal;
                    if (a.Denominacion.Valor == 10)
                        nud10billete.Value = a.MontoTotal;
                    if (a.Denominacion.Valor == 20)
                        nud20billete.Value = a.MontoTotal;
                    if (a.Denominacion.Valor == 50)
                        nud50billete.Value = a.MontoTotal;
                    if (a.Denominacion.Valor == 100)
                        nud100billete.Value = a.MontoTotal;
                }
                if (a.Denominacion.Moneda == Monedas.Euros && cboTipoMoneda.Text == "Euros")
                {
                    if (a.Denominacion.Valor == 5)
                        nud5billete.Value = a.MontoTotal;
                    if (a.Denominacion.Valor == 10)
                        nud10billete.Value = a.MontoTotal;
                    if (a.Denominacion.Valor == 20)
                        nud20billete.Value = a.MontoTotal;
                    if (a.Denominacion.Valor == 50)
                        nud50billete.Value = a.MontoTotal;
                    if (a.Denominacion.Valor == 100)
                        nud100billete.Value = a.MontoTotal;
                    if (a.Denominacion.Valor == 200)
                        nud200billete.Value = a.MontoTotal;
                    if (a.Denominacion.Valor == 500)
                        nud500billete.Value = a.MontoTotal;
                }
            }

   
            
            //cboTipoMoneda.SelectedIndex = (int)_arqueo.Moneda;
            //cboTipoArqueo.SelectedIndex = (int)_arqueo.Tipo;

            //txtComentario.Text = _arqueo.Comentario;
            //txtCodigoCajero.Text = _arqueo.CodigoCajero.ToString();
            //txtCuenta.Text = _arqueo.CuentaContable.ToString();

            //nudSobrante.Value = _arqueo.Sobrante;
            //nudFaltante.Value = _arqueo.Faltante;
            //nudSaldoArqueo.Value = _arqueo.SaldoArqueo;
            //nudSaldoContable.Value = _arqueo.SaldoContable;

            //dtpFecha.Value = _arqueo.Fecha;
            //dtpInicio.Value = _arqueo.Inicio;
            //dtpFin.Value = _arqueo.Fin;

            //switch (_arqueo.Moneda)
            //{
            //    case MonedaArqueo.ColonesBilletes:
            //        nudMutiladoBillete.Value = _arqueo.Mutilado;
            //        nudColasBillete.Value = _arqueo.Colas;
            //        foreach(DenominacionArqueo a in _arqueo.Denominaciones)
            //        {
            //            if (a.Denominacion.Valor == 1000)
            //                    nud1000billete.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 10000)
            //                    nud10000billete.Value= a.MontoTotal;
            //            if (a.Denominacion.Valor == 20000)
            //                    nud20000billete.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 2000)
            //                    nud2000billete.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 50000)
            //                    nud50000billete.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 5000)
            //                    nud5000billete.Value = a.MontoTotal;
            //        }
            //        break;
            //    case MonedaArqueo.ColonesMonedas:
            //        nudMutiladoMoneda.Value = _arqueo.Mutilado;
            //        nudColasMoneda.Value = _arqueo.Colas;

            //        foreach (DenominacionArqueo a in _arqueo.Denominaciones)
            //        {
            //            if (a.Denominacion.Valor == 5)
            //                nud5moneda.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 10)
            //                nud10moneda.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 20)
            //                nud20moneda.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 25)
            //                nud25moneda.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 50)
            //                nud50moneda.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 100)
            //                nud100moneda.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 500)
            //                nud500moneda.Value = a.MontoTotal;
            //        }

            //        break;
            //    case MonedaArqueo.Dolares:
            //        nudMutiladoBillete.Value = _arqueo.Mutilado;
            //        nudColasBillete.Value = _arqueo.Colas;

            //        foreach (DenominacionArqueo a in _arqueo.Denominaciones)
            //        {
            //            if (a.Denominacion.Valor == 1)
            //                nud1billete.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 5)
            //                nud5billete.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 10)
            //                nud10billete.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 20)
            //                nud20billete.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 50)
            //                nud50billete.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 100)
            //                nud100billete.Value = a.MontoTotal;
            //         }
            //        break;
            //    case MonedaArqueo.Euros:
            //        nudMutiladoBillete.Value = _arqueo.Mutilado;
            //        nudColasBillete.Value = _arqueo.Colas;

            //        foreach (DenominacionArqueo a in _arqueo.Denominaciones)
            //        {
            //            if (a.Denominacion.Valor == 5)
            //                nud5billete.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 10)
            //                nud10billete.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 20)
            //                nud20billete.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 50)
            //                nud50billete.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 100)
            //                nud100billete.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 200)
            //                nud200billete.Value = a.MontoTotal;
            //            if (a.Denominacion.Valor == 500)
            //                nud500billete.Value = a.MontoTotal;
            //        }
            //        break;
            //    default:
            //        break;
            

        }
        
        private void exportarArqueo(MonedaArqueo moneda)
        {
            try
            {

                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla arqueo.xlt", true);

                documento.seleccionarHoja(1);

                // Escribir los datos

                int fila = 0;

                documento.seleccionarCelda(6, 17);
                documento.actualizarValorCelda("   Colones");
                documento.seleccionarCelda(7, 17);
                documento.actualizarValorCelda("   Dólares");
                documento.seleccionarCelda(8, 17);
                documento.actualizarValorCelda("   Euros");

                documento.seleccionarCelda(24, 3);
                documento.actualizarValorCelda(nudColasBillete.Value);
                documento.seleccionarCelda(25, 3);
                documento.actualizarValorCelda(nudMutiladoBillete.Value);
                documento.seleccionarCelda(26, 3);
                documento.actualizarValorCelda(nudTotalBillete.Value);

                documento.seleccionarCelda(10, 16);
                documento.actualizarValorCelda(txtCuenta.Text);
                documento.seleccionarCelda(12, 16);
                documento.actualizarValorCelda(txtCodigoCajero.Text);
                documento.seleccionarCelda(17, 16);
                documento.actualizarValorCelda(nudSaldoContable.Value);

                documento.seleccionarCelda(29, 16);
                documento.actualizarValorCelda(nudSobrante.Value);
                documento.seleccionarCelda(31, 16);
                documento.actualizarValorCelda(nudFaltante.Value);

                documento.seleccionarCelda(45, 10);
                documento.actualizarValorCelda(_usuario.Nombre);

                documento.seleccionarCelda(47, 12);
                documento.actualizarValorCelda(dtpInicio.Value);

                documento.seleccionarCelda(47, 16);
                documento.actualizarValorCelda(dtpFin.Value);

                documento.seleccionarCelda(54, 2);
                documento.actualizarValorCelda(txtComentario.Text);

                switch (moneda)
                {
                    case MonedaArqueo.ColonesBilletes:
                         documento.seleccionarCelda(6, 17);
                         documento.actualizarValorCelda("X  Colones");
                         documento.seleccionarCelda(18, 3);
                         documento.actualizarValorCelda(nud1000billete.Value);
                         documento.seleccionarCelda(19, 3);
                         documento.actualizarValorCelda(nud2000billete.Value);
                         documento.seleccionarCelda(20, 3);
                         documento.actualizarValorCelda(nud5000billete.Value);
                         documento.seleccionarCelda(21, 3);
                         documento.actualizarValorCelda(nud10000billete.Value);
                         documento.seleccionarCelda(22, 3);
                         documento.actualizarValorCelda(nud20000billete.Value);
                         documento.seleccionarCelda(23, 3);
                         documento.actualizarValorCelda(nud50000billete.Value);
                         break;
                      case MonedaArqueo.ColonesMonedas:
                         documento.seleccionarCelda(6, 17);
                         documento.actualizarValorCelda("X  Colones");
                         documento.seleccionarCelda(28, 3);
                         documento.actualizarValorCelda(nud500moneda.Value);
                         documento.seleccionarCelda(29, 3);
                         documento.actualizarValorCelda(nud100moneda.Value);
                         documento.seleccionarCelda(30, 3);
                         documento.actualizarValorCelda(nud50moneda.Value);
                         documento.seleccionarCelda(31, 3);
                         documento.actualizarValorCelda(nud25moneda.Value);
                         documento.seleccionarCelda(32, 3);
                         documento.actualizarValorCelda(nud20moneda.Value);
                         documento.seleccionarCelda(33, 3);
                         documento.actualizarValorCelda(nud10moneda.Value);
                         documento.seleccionarCelda(34, 3);
                         documento.actualizarValorCelda(nud5moneda.Value);

                         documento.seleccionarCelda(35, 3);
                         documento.actualizarValorCelda(nudColasMoneda.Value);
                         documento.seleccionarCelda(36, 3);
                         documento.actualizarValorCelda(nudMutiladoMoneda.Value);
                         documento.seleccionarCelda(37, 3);
                         documento.actualizarValorCelda(nudTotalMoneda.Value);
                        break;
                    case MonedaArqueo.Dolares:
                         documento.seleccionarCelda(7, 17);
                         documento.actualizarValorCelda("X  Dólares");
                         documento.seleccionarCelda(10, 3);
                         documento.actualizarValorCelda(nud1billete.Value);
                         documento.seleccionarCelda(11, 3);
                         documento.actualizarValorCelda(nud5billete.Value);
                         documento.seleccionarCelda(12, 3);
                         documento.actualizarValorCelda(nud10billete.Value);
                         documento.seleccionarCelda(13, 3);
                         documento.actualizarValorCelda(nud20billete.Value);
                         documento.seleccionarCelda(14, 3);
                         documento.actualizarValorCelda(nud50billete.Value);
                         documento.seleccionarCelda(15, 3);
                         documento.actualizarValorCelda(nud100billete.Value);
                         break;
                    case MonedaArqueo.Euros:
                         documento.seleccionarCelda(8, 17);
                         documento.actualizarValorCelda("X  Euros");
                         documento.seleccionarCelda(11, 3);
                         documento.actualizarValorCelda(nud5billete.Value);
                         documento.seleccionarCelda(12, 3);
                         documento.actualizarValorCelda(nud10billete.Value);
                         documento.seleccionarCelda(13, 3);
                         documento.actualizarValorCelda(nud20billete.Value);
                         documento.seleccionarCelda(14, 3);
                         documento.actualizarValorCelda(nud50billete.Value);
                         documento.seleccionarCelda(15, 3);
                         documento.actualizarValorCelda(nud100billete.Value);
                         documento.seleccionarCelda(16, 3);
                         documento.actualizarValorCelda(nud200billete.Value);
                         documento.seleccionarCelda(17, 3);
                         documento.actualizarValorCelda(nud500billete.Value);
                         break;
                    default:
                    break;
                }

                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }
        }

        private bool ValidarMontos(Decimal monto, Decimal denominacion, NumericUpDown t)
        {
            bool bStatus = true;
            if ((monto % denominacion)!= 0)
            {
                epError.SetError(t, "No se puede ingresar ese monto");
                bStatus = false;
            }
            else
                epError.SetError(t, "");


            return bStatus;

        }


        private void habilitar()
        {
             switch  (cboTipoMoneda.Text)
                {
                    case "Colones Monedas":
                        pnlMoneda.Enabled = true;
                        pnlBillete.Enabled = false;
                    break;
                    case "Colones Billetes":

                    pnlMoneda.Enabled = false;

                    pnlBillete.Enabled = true;
                    nud1000billete.Enabled = true;
                    nud10000billete.Enabled = true;
                    nud20000billete.Enabled = true;
                    nud2000billete.Enabled = true;
                    nud50000billete.Enabled = true;
                    nud5000billete.Enabled = true;
                    nudColasBillete.Enabled = true;
                    nudMutiladoBillete.Enabled = true;
                    nudTotalBillete.Enabled = true;

                    nud1billete.Enabled = false;
                    nud5billete.Enabled = false;
                    nud10billete.Enabled = false;
                    nud20billete.Enabled = false;
                    nud50billete.Enabled = false;
                    nud100billete.Enabled = false;
                    nud200billete.Enabled = false;
                    nud500billete.Enabled = false;
                    break;
                    case "Dólares":

                    pnlMoneda.Enabled = false;

                    pnlBillete.Enabled = true;
                    nud1000billete.Enabled = false;
                    nud10000billete.Enabled = false;
                    nud20000billete.Enabled = false;
                    nud2000billete.Enabled = false;
                    nud50000billete.Enabled = false;
                    nud5000billete.Enabled = false;
                    
                    nud200billete.Enabled = false;
                    nud500billete.Enabled = false;

                    nud1billete.Enabled = true;
                    nud5billete.Enabled = true;
                    nud10billete.Enabled = true;
                    nud20billete.Enabled = true;
                    nud50billete.Enabled = true;
                    nud100billete.Enabled = true;
                    
                    nudColasBillete.Enabled = true;
                    nudMutiladoBillete.Enabled = true;
                    nudTotalBillete.Enabled = true;

                    break;
                    case "Euros":

                    pnlMoneda.Enabled = false;
                    pnlBillete.Enabled = true;

                    nud1billete.Enabled = false;
                    nud1000billete.Enabled = false;
                    nud10000billete.Enabled = false;
                    nud20000billete.Enabled = false;
                    nud2000billete.Enabled = false;
                    nud50000billete.Enabled = false;
                    nud5000billete.Enabled = false;

                    nud5billete.Enabled = true;
                    nud10billete.Enabled = true;
                    nud20billete.Enabled = true;
                    nud50billete.Enabled = true;
                    nud100billete.Enabled = true;
                    nud200billete.Enabled = true;
                    nud500billete.Enabled = true;

                    nudColasBillete.Enabled = true;
                    nudMutiladoBillete.Enabled = true;
                    nudTotalBillete.Enabled = true;

                    break;
                    default:
                    break;
                }
        }

        private void sumarTotales()
        {
            switch (cboTipoMoneda.Text)
            {
                case "Colones Monedas":
                    decimal totalMoneda = nud5moneda.Value + nud10moneda.Value + nud20moneda.Value + nud25moneda.Value + 
                        nud50moneda.Value + nud100moneda.Value + nud500moneda.Value + nudColasMoneda.Value + nudMutiladoMoneda.Value;

                    nudTotalMoneda.Value = totalMoneda;


                    break;
                case "Colones Billetes":

                    decimal totalbilletes = nud1000billete.Value + nud10000billete.Value + nud20000billete.Value + nud2000billete.Value +
                    nud50000billete.Value + nud5000billete.Value + nudColasBillete.Value + nudMutiladoBillete.Value;
                                                          
                    nudTotalBillete.Value = totalbilletes;
                    break;
                case "Dólares":
                                        
                    decimal totalDolares = nud1billete.Value + nud5billete.Value + nud10billete.Value +
                        nud20billete.Value+nud50billete.Value + nud100billete.Value + nudColasBillete.Value + 
                        nudMutiladoBillete.Value;
                    
                        nudTotalBillete.Value = totalDolares;

                    break;
                case "Euros":

                    decimal totalEuros = nud5billete.Value + nud10billete.Value + nud20billete.Value + nud50billete.Value +
                    nud100billete.Value + nud200billete.Value + nud500billete.Value + nudColasBillete.Value +
                    nudMutiladoBillete.Value;

                    nudTotalBillete.Value = totalEuros;

                    break;
                default:
                    break;
            }
        }

        private void limpiar()
        {
            nud1billete.Value = 0;
            nud5billete.Value  = 0;
            nud10billete.Value  = 0;
            nud20billete.Value  = 0;
            nud50billete.Value  = 0;
            nud100billete.Value  = 0;
            nud200billete.Value  = 0;
            nud500billete.Value  = 0;
            nud1000billete.Value  = 0;
            nud2000billete.Value  = 0;
            nud5000billete.Value  = 0;
            nud10000billete.Value  = 0;
            nud20000billete.Value  = 0;
            nud50000billete.Value  = 0;

            nud5moneda.Value = 0;
            nud10moneda.Value = 0;
            nud20moneda.Value = 0;
            nud25moneda.Value = 0;
            nud50moneda.Value = 0;
            nud100moneda.Value = 0;
            nud500moneda.Value = 0;

            nudColasBillete.Value = 0;
            nudMutiladoBillete.Value = 0;
            nudTotalBillete.Value = 0;
            nudTotalMoneda.Value = 0;
        }

        private void calcularDiferencia()
        {
            decimal diferencia  = nudSaldoContable.Value - nudSaldoArqueo.Value;
            if (diferencia > 0)
            {
                nudFaltante.Value = diferencia;
                nudSobrante.Value = 0;
            }
            else
            {
                nudSobrante.Value = diferencia;
                nudFaltante.Value = 0;
            }

        }

        private void calcularResumen()
        {
            nudBillete.Value = nudTotalBillete.Value;
            nudMoneda.Value = nudTotalMoneda.Value;
            nudTotalResumen.Value = nudBillete.Value + nudMoneda.Value;
        }

        private Dictionary<double, decimal> obtenerDenominacionesColonesBilletes()
        {
            _numeros_colones.Clear();
            decimal valor = 0;
            Dictionary<double, decimal> denominaciones_colones = new Dictionary<double, decimal>();

            if (nud1000billete.Value > 0)
            {
                denominaciones_colones.Add(1000, nud1000billete.Value);
                valor = 1000;
                _numeros_colones.Add(valor);
            }
            if (nud10000billete.Value > 0)
            {
                denominaciones_colones.Add(10000, nud10000billete.Value);
                valor = 10000;
                _numeros_colones.Add(valor);
            }
            if (nud20000billete.Value > 0)
            {
                denominaciones_colones.Add(20000, nud20000billete.Value);
                valor = 20000;
                _numeros_colones.Add(valor);
            }
            if (nud2000billete.Value > 0)
            {
                denominaciones_colones.Add(2000, nud2000billete.Value);
                valor = 2000;
                _numeros_colones.Add(valor);
            }

            if (nud50000billete.Value > 0)
            {
                denominaciones_colones.Add(50000, nud50000billete.Value);
                valor = 50000;
                _numeros_colones.Add(valor);
            }
            if (nud5000billete.Value > 0)
            {
                denominaciones_colones.Add(5000, nud5000billete.Value);
                valor = 5000;
                _numeros_colones.Add(valor);
            }

            return denominaciones_colones;
        }

        private Dictionary<double, decimal> obtenerDenominacionesColonesMonedas()
        {
            _numeros_monedas.Clear();
            decimal valor = 0;
            Dictionary<double, decimal> denominaciones_colonesMonedas = new Dictionary<double, decimal>();

            if (nud5moneda.Value > 0)
            {
                denominaciones_colonesMonedas.Add(5, nud5moneda.Value);
                valor = 5;
                _numeros_monedas.Add(valor);
            }
            if (nud10moneda.Value > 0)
            {
                denominaciones_colonesMonedas.Add(10, nud10moneda.Value);
                valor = 10;
                _numeros_monedas.Add(valor);
            }
            if (nud20moneda.Value > 0)
            {
                denominaciones_colonesMonedas.Add(20, nud20moneda.Value);
                valor = 20;
                _numeros_monedas.Add(valor);
            }
            if (nud25moneda.Value > 0)
            {
                denominaciones_colonesMonedas.Add(25, nud25moneda.Value);
                valor = 25;
                _numeros_monedas.Add(valor);
            }
            if (nud50moneda.Value > 0)
            {
                denominaciones_colonesMonedas.Add(50, nud50moneda.Value);
                valor = 50;
                _numeros_monedas.Add(valor);
            }
            if (nud100moneda.Value > 0)
            {
                denominaciones_colonesMonedas.Add(100, nud100moneda.Value);
                valor = 100;
                _numeros_monedas.Add(valor);
            }

            if (nud500moneda.Value > 0)
            {
                denominaciones_colonesMonedas.Add(500, nud500moneda.Value);
                valor = 500;
                _numeros_monedas.Add(valor);
            }

            return denominaciones_colonesMonedas;
        }

        private Dictionary<double, decimal> obtenerDenominacionesDolares()
        {
            _numeros_dolares.Clear();
            decimal valor = 0;
            Dictionary<double, decimal> denominaciones_dolares = new Dictionary<double, decimal>();

            if (nud1billete.Value > 0)
            {
                denominaciones_dolares.Add(1, nud1billete.Value);
                valor = 1;
                _numeros_dolares.Add(valor);
            }
            if (nud5billete.Value > 0)
            {
                denominaciones_dolares.Add(5, nud5billete.Value);
                valor = 5;
                _numeros_dolares.Add(valor);
            }
            if (nud10billete.Value > 0)
            {
                denominaciones_dolares.Add(10, nud10billete.Value);
                valor = 10;
                _numeros_dolares.Add(valor);
            }
            if ( nud20billete.Value > 0)
            {
                denominaciones_dolares.Add(20,  nud20billete.Value);
                valor = 20;
                _numeros_dolares.Add(valor);
            }
            
            if (nud50billete.Value> 0)
            {
                denominaciones_dolares.Add(50, nud50billete.Value);
                valor = 50;
                _numeros_dolares.Add(valor);

            }
            if (nud100billete.Value > 0)
            {
                denominaciones_dolares.Add(100, nud100billete.Value);
                valor = 100;
                _numeros_dolares.Add(valor);

            }

            return denominaciones_dolares;
        }

        private Dictionary<double, decimal> obtenerDenominacionesEuros()
        {
            _numeros_euros.Clear();
            decimal valor = 0;
            Dictionary<double, decimal> denominaciones_euros = new Dictionary<double, decimal>();

            if (nud5billete.Value > 0)
            {
                denominaciones_euros.Add(5, nud5billete.Value);
                valor = 5;
                _numeros_euros.Add(valor);
            }
            if (nud10billete.Value > 0)
            {
                denominaciones_euros.Add(10, nud10billete.Value);
                valor = 10;
                _numeros_euros.Add(valor);
            }
            if (nud20billete.Value > 0)
            {
                denominaciones_euros.Add(20, nud20billete.Value);
                valor = 20;
                _numeros_euros.Add(valor);
            }
            if (nud50billete.Value > 0)
            {
                denominaciones_euros.Add(50, nud50billete.Value);
                valor = 50;
                _numeros_euros.Add(valor);
            }
            if (nud100billete.Value > 0)
            {
                denominaciones_euros.Add(100, nud100billete.Value);
                valor = 100;
                _numeros_euros.Add(valor);
            }
            if (nud200billete.Value > 0)
            {
                denominaciones_euros.Add(200, nud200billete.Value);
                valor = 200;
                _numeros_euros.Add(valor);
            }
            if (nud500billete.Value > 0)
            {
                denominaciones_euros.Add(500, nud500billete.Value);
                valor = 500;
                _numeros_euros.Add(valor);
            }

            return denominaciones_euros;
        }

        private void generarCargasMoneda(Monedas moneda, DateTime fecha,
                                       Dictionary<double, decimal> denominaciones,
                                       ArrayList numeros, Arqueo arqueo)
        {              
            foreach (Decimal d in numeros)
            {
                Denominacion denominacion = new Denominacion(valor: Convert.ToDecimal(d), moneda: moneda);

                _mantenimiento.verificarDenominacion(ref denominacion);

                this.asignarDenominaciones(Convert.ToDouble(denominacion.Valor), ref arqueo, denominaciones, moneda);
            }

        }


        private void asignarDenominaciones(double p_monto, ref Arqueo arqueo, Dictionary<double, decimal> denominaciones, Monedas moneda)
        {
            decimal monto = 0;
            monto = denominaciones[p_monto];

            Denominacion denominacion = new Denominacion(valor: Convert.ToDecimal(p_monto), moneda: moneda);

            _mantenimiento.verificarDenominacion(ref denominacion);

            double cantidad_total = (double)Math.Ceiling(monto / denominacion.Valor);

            double cantidad_cartucho = (double)(monto / denominacion.Valor);

            DenominacionArqueo denominacionArqueo = new DenominacionArqueo(monto_total: (decimal)monto,
                                                                denominacion: denominacion);

            arqueo.agregarDenominacion(denominacionArqueo);

            //switch (denominacion.Moneda)
            //{
            //    case Monedas.Colones: carga.Monto_pedido_colones += monto; break;
            //    case Monedas.Dolares: carga.Monto_pedido_dolares += monto; break;
            //    case Monedas.Euros: carga.Monto_pedido_euros += monto; break;
            //}

        }


        #endregion Metodos Privados       

       
    }
}
