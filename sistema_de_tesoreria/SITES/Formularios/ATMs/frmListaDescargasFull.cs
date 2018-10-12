//
//  @ Project : 
//  @ File Name : frmListaDescargasFull.cs
//  @ Date : 08/03/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using LibreriaReportesOffice;

namespace GUILayer
{

    public partial class frmListaDescargasFull : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmListaDescargasFull()
        {
            InitializeComponent();

            try
            {
                dgvDescargas.AutoGenerateColumns = false;

                cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.ATMs, Puestos.CajeroA, Puestos.CajeroB);
                cboATM.ListaMostrada = _mantenimiento.listarATMs();
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
                Colaborador cajero = cboCajero.SelectedItem is Colaborador ?
                    (Colaborador)cboCajero.SelectedItem : null;
                ATM atm = cboATM.SelectedItem is ATM ?
                    (ATM)cboATM.SelectedItem : null;

                dgvDescargas.DataSource = _coordinacion.listarDescargasATMsFull(cajero, atm, fecha);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de imprimir.
        /// </summary>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.imprimirDescarga();
        }

        /// <summary>
        /// Mostrar los montos descargados por denominación.
        /// </summary
        private void btnMontos_Click(object sender, EventArgs e)
        {
            BindingList<DescargaATMFull> descargas = (BindingList<DescargaATMFull>)dgvDescargas.DataSource;
            frmMontosDenominacionDescargas formulario = new frmMontosDenominacionDescargas(descargas);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se agrega una descarga a la lista de descargas full.
        /// </summary>
        private void dgvDescargas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvDescargas.Rows[e.RowIndex + contador];
                DescargaATMFull descarga = (DescargaATMFull)fila.DataBoundItem;

                fila.Cells[Cajero.Index].Value = descarga.Cierre.Cajero;
            }

        }

        /// <summary>
        /// Se selecciona otra descarga de la lista de descargas full.
        /// </summary>
        private void dgvDescargas_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvDescargas.SelectedRows.Count > 0)
            {
                btnMontos.Enabled = true;
                btnImprimir.Enabled = true;
            }
            else
            {
                btnMontos.Enabled = true;
                btnImprimir.Enabled = false;
            }

        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Imprimir los datos de una descarga.
        /// </summary>
        private void imprimirDescarga()
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla descarga full.xlt", true);
                DescargaATMFull descarga = (DescargaATMFull)dgvDescargas.SelectedRows[0].DataBoundItem;
                CierreATMs cierre = descarga.Cierre;

                // Escribir los valores generales

                documento.seleccionarHoja(1);

                string fecha = cierre.Fecha.ToShortDateString();

                documento.seleccionarCelda("D6");
                documento.actualizarValorCelda(cierre.Cajero.ToString());

                documento.seleccionarCelda("D7");
                documento.actualizarValorCelda(cierre.Coordinador.ToString());

                documento.seleccionarCelda("C7");
                documento.actualizarValorCelda(fecha);

                documento.seleccionarCelda("C10");
                documento.actualizarValorCelda(cierre.Camara.Identificador);

                documento.seleccionarCelda("B44");
                documento.actualizarValorCelda(cierre.Cajero.ToString() + " " + fecha);

                documento.seleccionarCelda("E44");
                documento.actualizarValorCelda(cierre.Coordinador.ToString() + " " + fecha);

                // Escribir los valores de la descarga

                documento.seleccionarCelda("C8");
                documento.actualizarValorCelda(descarga.Hora_inicio.ToShortTimeString());

                documento.seleccionarCelda("C9");
                documento.actualizarValorCelda(descarga.Hora_finalizacion.ToShortTimeString());

                documento.seleccionarCelda("C11");
                documento.actualizarValorCelda(descarga.ATM.Numero);

                documento.seleccionarCelda("B41");
                documento.actualizarValorCelda(descarga.Observaciones);

                // Mostrar los datos del manifiesto

                documento.seleccionarCelda("C12");
                documento.actualizarValorCelda(descarga.Codigo_manifiesto);

                documento.seleccionarCelda("C13");
                documento.actualizarValorCelda(descarga.Codigo_marchamo);

                // Imprimir los montos de la descarga

                this.escribirMontosFullImpresion(documento, descarga.Montos_colones, 17);
                this.escribirMontosFullImpresion(documento, descarga.Montos_dolares, 29);

                // Imprimir los montos de los contadores

                this.escribirContadoresFullImpresion(documento, descarga.Contadores_Colones, 54);
                this.escribirContadoresFullImpresion(documento, descarga.Contadores_Dolares, 64);

                // Imprimir las denominaciones de las diferencias

                this.escribirDiferenciasFullImpresion(documento, descarga.Detalles_Colones, 80);
                this.escribirDiferenciasFullImpresion(documento, descarga.Detalles_Dolares, 92);

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
        /// Escribir en un documento de impresión los montos de una descarga full.
        /// </summary>
        private void escribirMontosFullImpresion(DocumentoExcel documento, BindingList<MontoDescargaATMFull> montos, int fila)
        {

            foreach (MontoDescargaATMFull monto in montos)
            {
                documento.seleccionarCelda(fila, 2);
                documento.actualizarValorCelda(monto.Denominacion.Valor);

                documento.seleccionarCelda(fila, 4);
                documento.actualizarValorCelda(monto.Cantidad);

                fila++;
            }

        }

        /// <summary>
        /// Escribir en un documento de impresión los datos de los contadores de una descarga full.
        /// </summary>
        private void escribirContadoresFullImpresion(DocumentoExcel documento, BindingList<ContadorDescargaATMFull> contadores, int fila)
        {

            foreach (ContadorDescargaATMFull contador in contadores)
            {
                documento.seleccionarCelda(fila, 2);
                documento.actualizarValorCelda(contador.Denominacion.Valor);

                // Cantidades dispensadas y remanentes

                documento.seleccionarCelda(fila, 4);
                documento.actualizarValorCelda(contador.Cantidad_depositada);

                fila++;
            }

        }

        /// <summary>
        /// Escribir en un documento de impresión los datos de las diferencias de una descarga full.
        /// </summary>
        private void escribirDiferenciasFullImpresion(DocumentoExcel documento, BindingList<DetalleDescargaATMFull> detalles, int fila)
        {

            foreach (DetalleDescargaATMFull detalle in detalles)
            {
                documento.seleccionarCelda(fila, 2);
                documento.actualizarValorCelda(detalle.Denominacion.Valor);

                fila++;
            }

        }
        
        #endregion Métodos Privados

    }

}
