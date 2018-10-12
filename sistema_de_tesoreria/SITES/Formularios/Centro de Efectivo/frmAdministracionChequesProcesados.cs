using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
using LibreriaMensajes;
using LibreriaReportesOffice;
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
    public partial class frmAdministracionChequesProcesados : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _colaborador = null;

        private bool _coordinador = false;
        private bool _analista = false;

        #endregion Atributos

        #region Constructor

        public frmAdministracionChequesProcesados(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;
            _coordinador = _colaborador.Puestos.Contains(Puestos.Coordinador) || _colaborador.Puestos.Contains(Puestos.Supervisor);
            _analista = _colaborador.Puestos.Contains(Puestos.Analista);

   
            try
            {
                dgvCheques.AutoGenerateColumns = false;

                cboOficialCamara.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Oficial);
                cboDigitador.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Digitador);
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime fecha = dtpFecha.Value;
                DateTime fecha_fin = dtpFechaFin.Value;
                Colaborador oficial = cboOficialCamara.SelectedIndex == 0 ?
                    null : (Colaborador)cboOficialCamara.SelectedItem;
                Colaborador digitador = cboDigitador.SelectedIndex == 0 ?
                    null : (Colaborador)cboDigitador.SelectedItem;


                dgvCheques.DataSource = _atencion.listarChequesProcesadoss(fecha, fecha_fin, oficial, digitador);


            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }


        /// <summary>
        /// Clic en el botón de modificar.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostrarVentanaModificacion();
        }

       

        /// <summary>
        /// Clic en el botón de eliminar carga.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeChequeProcesadoEliminacion") == DialogResult.Yes)
                {

                    foreach (DataGridViewRow fila in dgvCheques.SelectedRows)
                    {
                        ChequesProcesados carga = (ChequesProcesados)fila.DataBoundItem;

                        _atencion.eliminarChequesProcesados(carga);

                        dgvCheques.Rows.Remove(fila);
                    }

                    Mensaje.mostrarMensaje("MensajeChequeProcesadoConfirmacionEliminacion");
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

        /// <summary>
        /// Doble clic en la lista de cargas.
        /// </summary>
        private void dgvCargas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                DataGridViewRow fila = dgvCheques.SelectedRows[0];
                ChequesProcesados carga = (ChequesProcesados)fila.DataBoundItem;


                 this.mostrarVentanaModificacion();

            }

        }

      
        /// <summary>
        /// Se selecciona otra carga de la lista de cargas.
        /// </summary>
        private void dgvCargas_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCheques.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvCheques.SelectedRows[0];
                ChequesProcesados carga = (ChequesProcesados)fila.DataBoundItem;

                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                btnBoletaCanje.Enabled = true;
                btnBoletaTraspaso.Enabled = true;
            }
            else
            {

                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnBoletaCanje.Enabled = false;
                btnBoletaTraspaso.Enabled = false;

            }

        }



        /// <summary>
        /// Actualiza las alarmas de papel
        /// </summary>
        private void btnAlarmasPapel_Click(object sender, EventArgs e)
        {
            try
            {
                _coordinacion.ActualizarAlarmasPapel(DateTime.Now);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Clic en el botón de agregar
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmChequesProcesados formulario = new frmChequesProcesados(_colaborador);

            formulario.ShowDialog();


        }


        /// <summary>
        /// Exporta el reporte de boleta de traspaso
        /// </summary>
        private void btnBoletaTraspaso_Click(object sender, EventArgs e)
        {
            imprimirBoletaTraspaso();
        }


        /// <summary>
        /// Exporta la boleta de canje
        /// </summary>
        private void btnBoletaCanje_Click(object sender, EventArgs e)
        {
            imprimirBoletaCanje();
        }


        #endregion Eventos

        #region Métodos Privados

      

        /// <summary>
        /// Mostrar la ventana de modificación de la carga.
        /// </summary>
        private void mostrarVentanaModificacion()
        {
            ChequesProcesados carga = (ChequesProcesados)dgvCheques.SelectedRows[0].DataBoundItem;
            frmChequesProcesados formulario = new frmChequesProcesados(carga, _colaborador);

            formulario.ShowDialog(this);

            dgvCheques.Refresh();
        }



        /// <summary>
        /// Imprimir los datos de las descargas.
        /// </summary>
        private void imprimirBoletaTraspaso()
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla boleta traspaso.xltx", true);

                // Escribir los valores generales

                ChequesProcesados cheque = (ChequesProcesados)dgvCheques.SelectedRows[0].DataBoundItem;

                documento.seleccionarHoja(1);

                documento.seleccionarCelda("H6");
                documento.actualizarValorCelda("FECHA:" + cheque.FechaRegistro.ToShortTimeString());

                documento.seleccionarCelda("H8");
                documento.actualizarValorCelda("DIGITADOR:" + cheque.Digitador.ClaveCEF.ToString());


                int fila = 0; 

                foreach(CorteCheque corte in cheque.Cheques)
                {
                    foreach(Cheque cheques in corte.Cheques)
                    {
                        if(cheques.TipoCheque == TipoCheque.Cheques_Locales)
                        {
                            documento.seleccionarCelda(11 + fila, 5);
                            documento.actualizarValorCelda(cheques.Cantidad);

                            documento.seleccionarCelda(11 + fila, 6);
                            documento.actualizarValorCelda(cheques.UsuarioEntrega.ToString());

                            documento.seleccionarCelda(11 + fila, 7);
                            documento.actualizarValorCelda(cheques.HoraRegistro.ToShortTimeString());

                        }

                        if (cheques.TipoCheque == TipoCheque.Cheques_BAC)
                        {
                            documento.seleccionarCelda(12 + fila, 5);
                            documento.actualizarValorCelda(cheques.Cantidad);

                            documento.seleccionarCelda(12 + fila, 6);
                            documento.actualizarValorCelda(cheques.UsuarioEntrega.ToString());

                            documento.seleccionarCelda(12 + fila, 7);
                            documento.actualizarValorCelda(cheques.HoraRegistro.ToShortTimeString());
                        }


                        if (cheques.TipoCheque == TipoCheque.Cheques_Exterior)
                        {
                            documento.seleccionarCelda(13 + fila, 5);
                            documento.actualizarValorCelda(cheques.Cantidad);

                            documento.seleccionarCelda(13 + fila, 6);
                            documento.actualizarValorCelda(cheques.UsuarioEntrega.ToString());

                            documento.seleccionarCelda(13 + fila, 7);
                            documento.actualizarValorCelda(cheques.HoraRegistro.ToShortTimeString());
                        }


                        if (cheques.TipoCheque == TipoCheque.Otros)
                        {
                            documento.seleccionarCelda(14 + fila, 5);
                            documento.actualizarValorCelda(cheques.Cantidad);

                            documento.seleccionarCelda(14 + fila, 6);
                            documento.actualizarValorCelda(cheques.UsuarioEntrega.ToString());

                            documento.seleccionarCelda(14 + fila, 7);
                            documento.actualizarValorCelda(cheques.HoraRegistro.ToShortTimeString());
                        }
                    }

                    fila = fila + 4;
                }




                int fila_rechazo = 0;


                    foreach (Cheque cheques in cheque.ChequesRechazados)
                    {
                        
                            documento.seleccionarCelda(30 + fila, 8);
                            documento.actualizarValorCelda(cheques.Cantidad.ToString() + " / " +cheques.Monto.ToString("N2"));

                            fila_rechazo = fila_rechazo + 1;
                    }

                documento.seleccionarCelda("B29");
                documento.actualizarValorCelda("¢" + cheque.ChequesLocalesColones.ToString("N0"));

                documento.seleccionarCelda("B32");
                documento.actualizarValorCelda("$" + cheque.ChequesLocalesDolares.ToString("N0"));

                documento.seleccionarCelda("B36");
                documento.actualizarValorCelda("$" + cheque.ChequesExteriorDolares.ToString("N0"));


                documento.seleccionarCelda("E29");
                documento.actualizarValorCelda("¢" + cheque.ChequesNuestrosColones.ToString("N0"));


                documento.seleccionarCelda("E32");
                documento.actualizarValorCelda("$" + cheque.ChequesNuestrosDolares.ToString("N0"));


                documento.seleccionarCelda("E36");
                documento.actualizarValorCelda("¢" + cheque.CuponesCombustible.ToString("N0"));

                // Escribir los datos para cada descarga

               

                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }





        /// <summary>
        /// Imprimir los datos de las descargas.
        /// </summary>
        private void imprimirBoletaCanje()
        {

           try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla boleta canje.xltx", true);

                // Escribir los valores generales

                ChequesProcesados cheque = (ChequesProcesados)dgvCheques.SelectedRows[0].DataBoundItem;

                documento.seleccionarHoja(1);

                documento.seleccionarCelda("J5");
                documento.actualizarValorCelda("FECHA:" + cheque.FechaRegistro.ToShortTimeString());

                documento.seleccionarCelda("H8");
                documento.actualizarValorCelda("DIGITADOR:" + cheque.Digitador.ToString());


                int fila = 0; 

                foreach(CorteCheque corte in cheque.Cheques)
                {

                    decimal monto_local_colones = 0;
                    decimal monto_local_dolares = 0;
                    decimal monto_cupones_colones = 0;
                    decimal monto_cupones_dolares = 0;
                    decimal monto_exterior = 0;
                    decimal monto_americhek = 0;
                    decimal cantidad_locales_colones = 0;
                    decimal cantidad_locales_dolares = 0;
                    decimal cantidad_cupones_colones = 0;
                    decimal cantidad_cupones_dolares = 0;
                    decimal cantidad_exterior = 0;
                    decimal cantidad_americheck = 0;
                    foreach(Cheque cheques in corte.Cheques)
                    {

                        if(cheques.TipoCheque == TipoCheque.Cheques_Locales && cheques.Moneda == Monedas.Colones)
                        {

                            monto_local_colones = monto_local_colones + cheques.Monto;
                            cantidad_locales_colones++;

                        }

                        if (cheques.TipoCheque == TipoCheque.Cheques_Locales && cheques.Moneda == Monedas.Dolares)
                        {

                            monto_local_dolares= monto_local_dolares + cheques.Monto;
                            cantidad_locales_dolares++;

                        }


                        if (cheques.TipoCheque == TipoCheque.Cupones && cheques.Moneda == Monedas.Colones)
                        {

                            monto_cupones_colones = monto_cupones_colones + cheques.Monto;
                            cantidad_cupones_colones++;

                        }

                        if (cheques.TipoCheque == TipoCheque.Cupones && cheques.Moneda == Monedas.Dolares)
                        {

                            monto_cupones_dolares = monto_cupones_dolares + cheques.Monto;
                            cantidad_cupones_dolares++;

                        }

                        if (cheques.TipoCheque == TipoCheque.Cheques_Exterior)
                        {

                            monto_exterior = monto_exterior + cheques.Monto;
                            cantidad_exterior++;

                        }

                        if (cheques.TipoCheque == TipoCheque.Americheck )
                        {

                            monto_americhek = monto_americhek + cheques.Monto;
                            cantidad_americheck++;

                        }


           

                      
                    }

                    //Cheques bancos locales

                    documento.seleccionarCelda(9 + fila, 1);
                    documento.actualizarValorCelda(corte.NumeroCorte);

                    documento.seleccionarCelda(9 + fila, 2);
                    documento.actualizarValorCelda(cheque.FechaRegistro.ToShortDateString());

                    documento.seleccionarCelda(9 + fila, 3);
                    documento.actualizarValorCelda(monto_local_colones.ToString("N0"));

                    documento.seleccionarCelda(9 + fila, 4);
                    documento.actualizarValorCelda(cantidad_locales_colones);


                    //Cheques bancos locales dolares

                    documento.seleccionarCelda(9 + fila, 5);
                    documento.actualizarValorCelda(corte.NumeroCorte);

                    documento.seleccionarCelda(9 + fila, 6);
                    documento.actualizarValorCelda(cheque.FechaRegistro.ToShortDateString());

                    documento.seleccionarCelda(9 + fila, 7);
                    documento.actualizarValorCelda(monto_local_colones.ToString("N0"));

                    documento.seleccionarCelda(9 + fila, 8);
                    documento.actualizarValorCelda(cantidad_locales_colones);


                    //Cheques Exterior

                    documento.seleccionarCelda(9 + fila, 9);
                    documento.actualizarValorCelda(corte.NumeroCorte);

                    documento.seleccionarCelda(9 + fila, 10);
                    documento.actualizarValorCelda(cheque.FechaRegistro.ToShortDateString());

                    documento.seleccionarCelda(9 + fila, 11);
                    documento.actualizarValorCelda(monto_local_colones.ToString("N0"));

                    documento.seleccionarCelda(9 + fila, 12);
                    documento.actualizarValorCelda(cantidad_locales_colones);


                    //Cupones Colones

                    documento.seleccionarCelda(17 + fila, 1);
                    documento.actualizarValorCelda(corte.NumeroCorte);

                    documento.seleccionarCelda(17 + fila, 2);
                    documento.actualizarValorCelda(cheque.FechaRegistro.ToShortDateString());

                    documento.seleccionarCelda(17 + fila, 3);
                    documento.actualizarValorCelda(monto_local_colones.ToString("N0"));

                    documento.seleccionarCelda(17 + fila, 4);
                    documento.actualizarValorCelda(cantidad_locales_colones);



                    //Cupones Dolares

                    documento.seleccionarCelda(17 + fila, 5);
                    documento.actualizarValorCelda(corte.NumeroCorte);

                    documento.seleccionarCelda(17 + fila, 6);
                    documento.actualizarValorCelda(cheque.FechaRegistro.ToShortDateString());

                    documento.seleccionarCelda(17 + fila, 7);
                    documento.actualizarValorCelda(monto_local_colones.ToString("N0"));

                    documento.seleccionarCelda(17 + fila, 8);
                    documento.actualizarValorCelda(cantidad_locales_colones);


                    //Americheck

                    documento.seleccionarCelda(17 + fila, 9);
                    documento.actualizarValorCelda(corte.NumeroCorte);

                    documento.seleccionarCelda(17 + fila, 10);
                    documento.actualizarValorCelda(cheque.FechaRegistro.ToShortDateString());

                    documento.seleccionarCelda(17 + fila, 11);
                    documento.actualizarValorCelda(monto_local_colones.ToString("N0"));

                    documento.seleccionarCelda(17 + fila, 12);
                    documento.actualizarValorCelda(cantidad_locales_colones);
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

        #endregion Métodos Privados


      




       

      
    }
}
