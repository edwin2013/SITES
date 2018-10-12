//
//  @ Project : 
//  @ File Name : frmListaDescargas.cs
//  @ Date : 16/01/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using LibreriaReportesOffice;
using GUILayer.Formularios.Boveda;

namespace GUILayer
{

    public partial class frmListaDescargas : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmListaDescargas()
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
                byte? ruta = chkRuta.Checked ?
                    (byte?)nudRuta.Value : null;

                dgvDescargas.DataSource = _coordinacion.listarDescargasATMs(cajero, atm, fecha, ruta);
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
            BindingList<DescargaATM> descargas = (BindingList<DescargaATM>)dgvDescargas.DataSource;
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
        /// Se agrega una descarga a la lista de descargas.
        /// </summary>
        private void dgvDescargas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvDescargas.Rows[e.RowIndex + contador];
                DescargaATM descarga = (DescargaATM)fila.DataBoundItem;

                fila.Cells[Cajero.Index].Value = descarga.Cierre.Cajero;
            }

        }

        /// <summary>
        /// Se selecciona otra descarga de la lista de descargas.
        /// </summary>
        private void dgvDescargas_SelectionChanged(object sender, EventArgs e)
        {

            btnManifiestoGeneral.Enabled = dgvDescargas.SelectedRows.Count > 0;

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

        /// <summary>
        /// Se marca o desmarca la opción de filtrar por ruta.
        /// </summary>
        private void chkRuta_CheckedChanged(object sender, EventArgs e)
        {
            nudRuta.Enabled = chkRuta.Checked;
        }


        /// <summary>
        /// Genera el manifiesto digital con las descargas realizadas
        /// </summary>
        private void btnManifiestoGeneral_Click(object sender, EventArgs e)
        {
            try
            {

                DescargaATM descarga = (DescargaATM)dgvDescargas.SelectedRows[0].DataBoundItem;

               
              
                frmManifiestoGeneral formulario = new frmManifiestoGeneral(descarga);
                formulario.ShowDialog();
               // formulario.mostrarDatosCargaATM();

               
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
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
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla descarga.xlt", true);
                DescargaATM descarga = (DescargaATM)dgvDescargas.SelectedRows[0].DataBoundItem;
                CierreATMs cierre = descarga.Cierre;

                // Escribir los valores generales

                documento.seleccionarHoja(1);

                string fecha = cierre.Fecha.ToShortDateString();

                documento.seleccionarCelda("B8");
                documento.actualizarValorCelda(fecha);

                documento.seleccionarCelda("D8");
                documento.actualizarValorCelda(cierre.Camara.Identificador);

                documento.seleccionarCelda("A45");
                documento.actualizarValorCelda(cierre.Cajero.ToString() + " " + fecha);

                documento.seleccionarCelda("E45");
                documento.actualizarValorCelda(cierre.Coordinador.ToString() + " " + fecha);

                // Escribir los valores de la descarga

                documento.seleccionarCelda("B9");
                documento.actualizarValorCelda(descarga.Hora_inicio.ToShortTimeString());

                documento.seleccionarCelda("D9");
                documento.actualizarValorCelda(descarga.Hora_finalizacion.ToShortTimeString());

                documento.seleccionarCelda("B10");
                documento.actualizarValorCelda(descarga.ATM.Numero);

                documento.seleccionarCelda("D10");
                documento.actualizarValorCelda(descarga.ATM.Codigo);

                documento.seleccionarCelda("B11");
                documento.actualizarValorCelda(Enum.GetName(typeof(TiposCartucho), descarga.Tipo));

                // Mostrar los datos del manifiesto

                documento.seleccionarCelda("F37");
                documento.actualizarValorCelda(descarga.Codigo_manifiesto);

                documento.seleccionarCelda("F39");
                documento.actualizarValorCelda(descarga.Codigo_marchamo);

                // Imprimir los montos descargados

                this.escribirValoresCartuchoImpresion(documento, descarga.Cartuchos_Colones, 15);
                this.escribirValoresCartuchoImpresion(documento, descarga.Cartuchos_Dolares, 34);

                // Imprimir los montos de los rechazos

                this.escribirValoresRechazoImpresion(documento, descarga.Rechazos_Colones, 23);
                this.escribirValoresRechazoImpresion(documento, descarga.Rechazos_Dolares, 35);

                // Imprimir los montos de los contadores

                this.escribirValoresContadorImpresion(documento, descarga.Contadores_Colones, 55);
                this.escribirValoresContadorImpresion(documento, descarga.Contadores_Dolares, 66);

                // Imprimir los montos de carga

                this.escribirValoresCargaImpresion(documento, descarga.Cartuchos_Colones, 96);
                this.escribirValoresCargaImpresion(documento, descarga.Cartuchos_Dolares, 111);

                // Imprimir las denominaciones de las diferencias

                this.escribirValoresDiferenciaImpresion(documento, descarga.Detalles_Colones, 77);
                this.escribirValoresDiferenciaImpresion(documento, descarga.Detalles_Dolares, 89);
                this.escribirValoresDiferenciaImpresion(documento, descarga.Detalles_Colones, 121);
                this.escribirValoresDiferenciaImpresion(documento, descarga.Detalles_Dolares, 133);

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
        /// Escribir en un documento de impresión los datos de un cartucho de una descarga.
        /// </summary>
        private void escribirValoresCartuchoImpresion(DocumentoExcel documento, BindingList<CartuchoCargaATM> cartuchos, int fila)
        {

            foreach (CartuchoCargaATM cartucho in cartuchos)
            {
                documento.seleccionarCelda(fila, 1);
                documento.actualizarValorCelda(cartucho.Denominacion.Valor);

                documento.seleccionarCelda(fila, 3);
                documento.actualizarValorCelda(cartucho.Cantidad_descarga);

                documento.seleccionarCelda(fila, 5);
                documento.actualizarValorCelda(cartucho.Cartucho.Numero);

                documento.seleccionarCelda(fila, 6);
                documento.actualizarValorCelda(cartucho.Marchamo);

                fila++;
            }

        }

        /// <summary>
        /// Escribir en un documento de impresión los datos de un rechazo de una descarga.
        /// </summary>
        private void escribirValoresRechazoImpresion(DocumentoExcel documento, BindingList<RechazoDescargaATM> rechazos, int fila)
        {

            foreach (RechazoDescargaATM rechazo in rechazos)
            {
                documento.seleccionarCelda(fila, 1);
                documento.actualizarValorCelda(rechazo.Denominacion.Valor);

                documento.seleccionarCelda(fila, 3);
                documento.actualizarValorCelda(rechazo.Cantidad_descarga);

                fila++;
            }

        }

        /// <summary>
        /// Escribir en un documento de impresión los datos de un contador de una descarga.
        /// </summary>
        private void escribirValoresContadorImpresion(DocumentoExcel documento, BindingList<ContadorDescargaATM> contadores, int fila)
        {

            foreach (ContadorDescargaATM contador in contadores)
            {
                documento.seleccionarCelda(fila, 1);
                documento.actualizarValorCelda(contador.Denominacion.Valor);

                documento.seleccionarCelda(fila, 2);
                documento.actualizarValorCelda(contador.Denominacion.Codigo);

                // Cantidades dispensadas y remanentes

                documento.seleccionarCelda(fila, 8);
                documento.actualizarValorCelda(contador.Cantidad_dispensada_a);

                documento.seleccionarCelda(fila, 10);
                documento.actualizarValorCelda(contador.Cantidad_remanente_a);

                documento.seleccionarCelda(fila, 11);
                documento.actualizarValorCelda(contador.Cantidad_dispensada_b);

                documento.seleccionarCelda(fila, 12);
                documento.actualizarValorCelda(contador.Cantidad_remanente_b);

                documento.seleccionarCelda(fila, 13);
                documento.actualizarValorCelda(contador.Cantidad_dispensada_c);

                documento.seleccionarCelda(fila, 14);
                documento.actualizarValorCelda(contador.Cantidad_remanente_c);

                fila++;
            }

        }

        /// <summary>
        /// Escribir en un documento de impresión los datos de carga de una descarga.
        /// </summary>
        private void escribirValoresCargaImpresion(DocumentoExcel documento, BindingList<CartuchoCargaATM> cartuchos, int fila)
        {

            foreach (CartuchoCargaATM cartucho in cartuchos)
            {
                documento.seleccionarCelda(fila, 1);
                documento.actualizarValorCelda(cartucho.Denominacion.Valor);

                documento.seleccionarCelda(fila, 3);
                documento.actualizarValorCelda(cartucho.Cantidad_carga);

                fila++;
            }

        }

        /// <summary>
        /// Escribir en un documento de impresión los datos de las diferencias.
        /// </summary>
        private void escribirValoresDiferenciaImpresion(DocumentoExcel documento, BindingList<DetalleDescargaATM> detalles, int fila)
        {

            foreach (DetalleDescargaATM detalle in detalles)
            {
                documento.seleccionarCelda(fila, 1);
                documento.actualizarValorCelda(detalle.Denominacion.Valor);

                fila++;
            }

        }

        #endregion Métodos Privados

        

    }

}
