using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
using LibreriaReportesOffice;
using LibreriaMensajes;

namespace GUILayer.Formularios.Níquel
{
    public partial class frmSaldoLibroNiquel : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private Colaborador _usuario = null;
        private BindingList<SaldoLibroBoveda> _saldos = new BindingList<SaldoLibroBoveda>();
        private BindingList<SaldoLibroBoveda> _saldos_final = new BindingList<SaldoLibroBoveda>();



        #endregion Atributos

        #region Constructor

        public frmSaldoLibroNiquel(Colaborador usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            Cargar();
        }

        #endregion Constructor

        #region Metodos Privados

        private void Cargar()
        {
            _saldos_final = _mantenimiento.listarSaldosLibrosFinalNiquel(dtpFecha.Value, _usuario);
            _saldos = _mantenimiento.listarSaldosLibrosNiquel(dtpFecha.Value);

            BindingList<Denominacion> denominaciones = _mantenimiento.listarDenominaciones();
            SaldoLibroBoveda saldo = null;

            if (_saldos.Count == 0)
            {
                foreach (Denominacion d in denominaciones)
                {
                    saldo = new SaldoLibroBoveda(d: d, colaborador: _usuario, fecha_asignada: dtpFecha.Value);
                    _saldos.Add(saldo);

                }

            }
            if (_saldos_final.Count == 0)
            {
                foreach (Denominacion d in denominaciones)
                {
                    saldo = new SaldoLibroBoveda(d: d, colaborador: _usuario, fecha_asignada: dtpFecha.Value);
                    _saldos_final.Add(saldo);

                }
            }

            nudColaColones.Value = _saldos[0].ColaColones;
            nudColaDolares.Value = _saldos[0].ColaDolares;
            nudColaEuros.Value = _saldos[0].ColaEuros;
            nudMutiladoColones.Value = _saldos[0].MutiladoColones;
            nudMutiladoDolares.Value = _saldos[0].MutiladoDolares;
            nudMutiladoEuros.Value = _saldos[0].MutiladoEuros;

            nudColaColonesFinal.Value = _saldos_final[0].ColaColones;
            nudColaDolaresFinal.Value = _saldos_final[0].ColaDolares;
            nudColaEurosFinal.Value = _saldos_final[0].ColaEuros;
            nudMutiladoColonesfinal.Value = _saldos_final[0].MutiladoColones;
            nudMutiladoDolaresFinal.Value = _saldos_final[0].MutiladoDolares;
            nudMutiladoEurosFinal.Value = _saldos_final[0].MutiladoEuros;

            dgvSaldos.AutoGenerateColumns = false;
            dgvSaldoFinal.AutoGenerateColumns = false;
            dgvSaldos.DataSource = _saldos;
            dgvSaldoFinal.DataSource = _saldos_final;
        }

        /// <summary>
        /// Metodo que valida que no se digiten numeros
        /// </summary>
        private void txtNumeroA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48 && e.KeyChar != 8 && e.KeyChar != 44) || e.KeyChar > 57)
            {
                MessageBox.Show("Sólo se permiten Números");
                e.Handled = true;
            }
        }

        /// <summary>
        /// Imprimir los datos de la hoja de la carga seleccionada.
        /// </summary>
        private void imprimirHojaCarga()
        {

            try
            {

                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla saldo libros.xltx", true);

                DateTime fecha = dtpFecha.Value;

                documento.seleccionarHoja(1);

                documento.seleccionarCelda("B2");
                documento.actualizarValorCelda(fecha.ToShortDateString());


                documento.seleccionarCelda("C21");
                documento.actualizarValorCelda(nudColaColones.Value);
                documento.seleccionarCelda("D21");
                documento.actualizarValorCelda(nudColaDolares.Value);
                documento.seleccionarCelda("E21");
                documento.actualizarValorCelda(nudColaEuros.Value);
                documento.seleccionarCelda("C22");
                documento.actualizarValorCelda(nudMutiladoColones.Value);
                documento.seleccionarCelda("D22");
                documento.actualizarValorCelda(nudMutiladoDolares.Value);
                documento.seleccionarCelda("E22");
                documento.actualizarValorCelda(nudMutiladoEuros.Value);

                foreach (SaldoLibroBoveda saldo in _saldos)
                {
                    if (saldo.Denominacion.Valor == 50000)
                    {
                        documento.seleccionarCelda("C6");
                        documento.actualizarValorCelda(saldo.MontoColones);
                        documento.seleccionarCelda("F6");
                        documento.actualizarValorCelda(saldo.CustodiaAuxiliar);
                    }


                    if (saldo.Denominacion.Valor == 20000)
                    {
                        documento.seleccionarCelda("C7");
                        documento.actualizarValorCelda(saldo.MontoColones);
                        documento.seleccionarCelda("F7");
                        documento.actualizarValorCelda(saldo.CustodiaAuxiliar);
                    }

                    if (saldo.Denominacion.Valor == 10000)
                    {
                        documento.seleccionarCelda("C8");
                        documento.actualizarValorCelda(saldo.MontoColones);
                        documento.seleccionarCelda("F8");
                        documento.actualizarValorCelda(saldo.CustodiaAuxiliar);
                    }

                    if (saldo.Denominacion.Valor == 5000)
                    {
                        documento.seleccionarCelda("C9");
                        documento.actualizarValorCelda(saldo.MontoColones);
                        documento.seleccionarCelda("F9");
                        documento.actualizarValorCelda(saldo.CustodiaAuxiliar);
                    }

                    if (saldo.Denominacion.Valor == 2000)
                    {
                        documento.seleccionarCelda("C10");
                        documento.actualizarValorCelda(saldo.MontoColones);
                        documento.seleccionarCelda("F10");
                        documento.actualizarValorCelda(saldo.CustodiaAuxiliar);
                    }

                    if (saldo.Denominacion.Valor == 1000)
                    {
                        documento.seleccionarCelda("C11");
                        documento.actualizarValorCelda(saldo.MontoColones);
                        documento.seleccionarCelda("F11");
                        documento.actualizarValorCelda(saldo.CustodiaAuxiliar);
                    }

                    if (saldo.Denominacion.Valor == 500)
                    {
                        documento.seleccionarCelda("E12");
                        documento.actualizarValorCelda(saldo.MontoEuros);
                    }

                    if (saldo.Denominacion.Valor == 200)
                    {
                        documento.seleccionarCelda("E13");
                        documento.actualizarValorCelda(saldo.MontoEuros);
                    }

                    if (saldo.Denominacion.Valor == 100 & saldo.Denominacion.Moneda == Monedas.Euros)
                    {
                        documento.seleccionarCelda("E14");
                        documento.actualizarValorCelda(saldo.MontoEuros);
                    }

                    if (saldo.Denominacion.Valor == 100 & saldo.Denominacion.Moneda == Monedas.Dolares)
                    {
                        documento.seleccionarCelda("D14");
                        documento.actualizarValorCelda(saldo.MontoDolares);
                    }

                    if (saldo.Denominacion.Valor == 50 & saldo.Denominacion.Moneda == Monedas.Euros)
                    {
                        documento.seleccionarCelda("E15");
                        documento.actualizarValorCelda(saldo.MontoEuros);
                    }

                    if (saldo.Denominacion.Valor == 50 & saldo.Denominacion.Moneda == Monedas.Dolares)
                    {
                        documento.seleccionarCelda("D15");
                        documento.actualizarValorCelda(saldo.MontoDolares);
                    }

                    if (saldo.Denominacion.Valor == 20 & saldo.Denominacion.Moneda == Monedas.Euros)
                    {
                        documento.seleccionarCelda("E17");
                        documento.actualizarValorCelda(saldo.MontoEuros);
                    }

                    if (saldo.Denominacion.Valor == 20 & saldo.Denominacion.Moneda == Monedas.Dolares)
                    {
                        documento.seleccionarCelda("D17");
                        documento.actualizarValorCelda(saldo.MontoDolares);
                    }

                    if (saldo.Denominacion.Valor == 10 & saldo.Denominacion.Moneda == Monedas.Euros)
                    {
                        documento.seleccionarCelda("E18");
                        documento.actualizarValorCelda(saldo.MontoEuros);
                    }

                    if (saldo.Denominacion.Valor == 10 & saldo.Denominacion.Moneda == Monedas.Dolares)
                    {
                        documento.seleccionarCelda("D18");
                        documento.actualizarValorCelda(saldo.MontoDolares);
                    }

                    if (saldo.Denominacion.Valor == 5 & saldo.Denominacion.Moneda == Monedas.Euros)
                    {
                        documento.seleccionarCelda("E19");
                        documento.actualizarValorCelda(saldo.MontoEuros);
                    }

                    if (saldo.Denominacion.Valor == 5 & saldo.Denominacion.Moneda == Monedas.Dolares)
                    {
                        documento.seleccionarCelda("D19");
                        documento.actualizarValorCelda(saldo.MontoDolares);
                    }

                    if (saldo.Denominacion.Valor == 1)
                    {
                        documento.seleccionarCelda("D20");
                        documento.actualizarValorCelda(saldo.MontoDolares);
                    }
                    ////////////////////////////////////////PAra la impresion del saldo final //////////////////////////////

                    documento.seleccionarCelda("C48");
                    documento.actualizarValorCelda(nudColaColonesFinal.Value);
                    documento.seleccionarCelda("D48");
                    documento.actualizarValorCelda(nudColaDolaresFinal.Value);
                    documento.seleccionarCelda("E48");
                    documento.actualizarValorCelda(nudColaEurosFinal.Value);
                    documento.seleccionarCelda("C49");
                    documento.actualizarValorCelda(nudMutiladoColonesfinal.Value);
                    documento.seleccionarCelda("D49");
                    documento.actualizarValorCelda(nudMutiladoDolaresFinal.Value);
                    documento.seleccionarCelda("E49");
                    documento.actualizarValorCelda(nudMutiladoEurosFinal.Value);



                    foreach (SaldoLibroBoveda saldof in _saldos_final)
                    {
                        if (saldof.Denominacion.Valor == 50000)
                        {
                            documento.seleccionarCelda("C33");
                            documento.actualizarValorCelda(saldof.MontoColones);

                            documento.seleccionarCelda("F33");
                            documento.actualizarValorCelda(saldof.CustodiaAuxiliar);
                        }


                        if (saldof.Denominacion.Valor == 20000)
                        {
                            documento.seleccionarCelda("C34");
                            documento.actualizarValorCelda(saldof.MontoColones);

                            documento.seleccionarCelda("F34");
                            documento.actualizarValorCelda(saldof.CustodiaAuxiliar);
                        }

                        if (saldof.Denominacion.Valor == 10000)
                        {
                            documento.seleccionarCelda("C35");
                            documento.actualizarValorCelda(saldof.MontoColones);

                            documento.seleccionarCelda("F35");
                            documento.actualizarValorCelda(saldof.CustodiaAuxiliar);
                        }

                        if (saldof.Denominacion.Valor == 5000)
                        {
                            documento.seleccionarCelda("C36");
                            documento.actualizarValorCelda(saldof.MontoColones);

                            documento.seleccionarCelda("F36");
                            documento.actualizarValorCelda(saldof.CustodiaAuxiliar);
                        }

                        if (saldof.Denominacion.Valor == 2000)
                        {
                            documento.seleccionarCelda("C37");
                            documento.actualizarValorCelda(saldof.MontoColones);

                            documento.seleccionarCelda("F37");
                            documento.actualizarValorCelda(saldof.CustodiaAuxiliar);
                        }

                        if (saldof.Denominacion.Valor == 1000)
                        {
                            documento.seleccionarCelda("C38");
                            documento.actualizarValorCelda(saldof.MontoColones);

                            documento.seleccionarCelda("F38");
                            documento.actualizarValorCelda(saldof.CustodiaAuxiliar);
                        }

                        if (saldof.Denominacion.Valor == 500)
                        {
                            documento.seleccionarCelda("E39");
                            documento.actualizarValorCelda(saldof.MontoEuros);
                        }

                        if (saldof.Denominacion.Valor == 200)
                        {
                            documento.seleccionarCelda("E40");
                            documento.actualizarValorCelda(saldof.MontoEuros);
                        }

                        if (saldof.Denominacion.Valor == 100 & saldof.Denominacion.Moneda == Monedas.Euros)
                        {
                            documento.seleccionarCelda("E41");
                            documento.actualizarValorCelda(saldof.MontoEuros);
                        }

                        if (saldof.Denominacion.Valor == 100 & saldof.Denominacion.Moneda == Monedas.Dolares)
                        {
                            documento.seleccionarCelda("D41");
                            documento.actualizarValorCelda(saldof.MontoDolares);
                        }

                        if (saldof.Denominacion.Valor == 50 & saldof.Denominacion.Moneda == Monedas.Euros)
                        {
                            documento.seleccionarCelda("E42");
                            documento.actualizarValorCelda(saldof.MontoEuros);
                        }
                        if (saldof.Denominacion.Valor == 50 & saldof.Denominacion.Moneda == Monedas.Dolares)
                        {
                            documento.seleccionarCelda("D42");
                            documento.actualizarValorCelda(saldof.MontoDolares);
                        }

                        if (saldof.Denominacion.Valor == 20 & saldof.Denominacion.Moneda == Monedas.Euros)
                        {
                            documento.seleccionarCelda("E44");
                            documento.actualizarValorCelda(saldof.MontoEuros);
                        }
                        if (saldof.Denominacion.Valor == 20 & saldof.Denominacion.Moneda == Monedas.Dolares)
                        {
                            documento.seleccionarCelda("D44");
                            documento.actualizarValorCelda(saldof.MontoDolares);
                        }


                        if (saldof.Denominacion.Valor == 10 & saldof.Denominacion.Moneda == Monedas.Euros)
                        {
                            documento.seleccionarCelda("E45");
                            documento.actualizarValorCelda(saldof.MontoEuros);
                        }
                        if (saldof.Denominacion.Valor == 10 & saldof.Denominacion.Moneda == Monedas.Dolares)
                        {
                            documento.seleccionarCelda("D45");
                            documento.actualizarValorCelda(saldof.MontoDolares);
                        }

                        if (saldof.Denominacion.Valor == 5 & saldof.Denominacion.Moneda == Monedas.Euros)
                        {
                            documento.seleccionarCelda("E46");
                            documento.actualizarValorCelda(saldof.MontoEuros);
                        }
                        if (saldof.Denominacion.Valor == 5 & saldof.Denominacion.Moneda == Monedas.Dolares)
                        {
                            documento.seleccionarCelda("D46");
                            documento.actualizarValorCelda(saldof.MontoDolares);
                        }

                        if (saldof.Denominacion.Valor == 1)
                        {
                            documento.seleccionarCelda("D47");
                            documento.actualizarValorCelda(saldof.MontoDolares);
                        }
                    }



                }



                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Excepcion ex)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        #endregion Metodos Privados

        #region Eventos
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.imprimirHojaCarga();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion Eventos
    }
}
