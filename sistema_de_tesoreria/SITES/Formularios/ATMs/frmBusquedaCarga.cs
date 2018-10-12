//
//  @ Project : 
//  @ File Name : frmRegistroCierreATM.cs
//  @ Date : 04/05/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using LibreriaReportesOffice;

namespace GUILayer
{

    public partial class frmBusquedaCarga : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmBusquedaCarga()
        {
            InitializeComponent();

            try
            {
                dgvCargas.AutoGenerateColumns = false;
                dgvMontosCarga.AutoGenerateColumns = false;

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
                ATM atm = cboATM.SelectedItem is ATM ?
                    (ATM)cboATM.SelectedItem : null;
                string marchamo = txtMarchamoBusqueda.Text;

                dgvCargas.DataSource = _coordinacion.listarCargasATMsPorATMMarchamo(atm, marchamo);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de imprimir carga.
        /// </summary>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.imprimirHojaCarga();
        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se selecciona otra carga en la lista de cargas.
        /// </summary
        private void dgvCargas_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCargas.SelectedRows.Count > 0)
            {
                CargaATM carga = (CargaATM)dgvCargas.SelectedRows[0].DataBoundItem;

                this.mostrarDatosCargaATM(carga);

                btnImprimir.Enabled = true;
            }
            else
            {
                this.limpiarDatos();

                btnImprimir.Enabled = false;
            }

        }

        /// <summary>
        /// Se cambia el valor del selector del tamaño de las fuentes.
        /// </summary
        private void tbTamanoFuente_Scroll(object sender, EventArgs e)
        {
            Font fuente = new Font("Microsoft Sans Serif", 8f);

            switch (tbTamanoFuente.Value)
            {
                case 2: fuente = new Font("Microsoft Sans Serif", 12f); break;
                case 3: fuente = new Font("Microsoft Sans Serif", 14f); break;
                case 4: fuente = new Font("Microsoft Sans Serif", 20f); break;
            }

            DenominacionCartuchoCarga.DefaultCellStyle.Font = fuente;
            CantidadCartuchoCarga.DefaultCellStyle.Font = fuente;
            MontoCartuchoCarga.DefaultCellStyle.Font = fuente;
            NumeroCartuchoCarga.DefaultCellStyle.Font = fuente;
            NumeroMarchamoCarga.DefaultCellStyle.Font = fuente;
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Limpiar los datos del cierre.
        /// </summary>
        private void limpiarDatos()
        {
            txtHoraInicio.Text = string.Empty;
            txtHoraFinalizacion.Text = string.Empty;
            txtRuta.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            txtManifiesto.Text = string.Empty;
            txtMarchamo.Text = string.Empty;
            txtCamara.Text = string.Empty;

            dgvMontosCarga.DataSource = null;
        }


        /// <summary>
        /// Mostrar los datos de la carga de ATM.
        /// </summary
        private void mostrarDatosCargaATM(CargaATM carga)
        {
            dgvMontosCarga.DataSource = carga.Cartuchos;

            txtHoraInicio.Text = carga.Hora_inicio.ToString("dd-MM-yy hh:mm");
            txtHoraFinalizacion.Text = carga.Hora_finalizacion.ToString("dd-MM-yy hh:mm");
            txtRuta.Text = carga.Ruta.ToString();
            txtObservaciones.Text = carga.Observaciones;

            if (carga.Manifiesto == null)
            {
                txtManifiesto.Text = string.Empty;
                txtMarchamo.Text = string.Empty;
            }
            else
            {
                txtManifiesto.Text = carga.Manifiesto.Codigo;
                txtMarchamo.Text = carga.Manifiesto.Marchamo;
            }

            btnImprimir.Enabled = true;
        }

        /// <summary>
        /// Imprimir los datos de la hoja de la carga seleccionada.
        /// </summary>
        private void imprimirHojaCarga()
        {

            try
            {
                CargaATM carga = (CargaATM)dgvCargas.SelectedRows[0].DataBoundItem;
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla cargas.xls", true);

                documento.seleccionarHoja(1);
                
                // Escribir los datos

                documento.seleccionarCelda("C7");
                documento.actualizarValorCelda(carga.Hora_inicio.ToShortDateString());

                documento.seleccionarCelda("C9");
                documento.actualizarValorCelda(carga.Hora_inicio.ToShortTimeString());

                documento.seleccionarCelda("C11");
                documento.actualizarValorCelda(Enum.GetName(typeof(TiposCartucho), carga.Tipo));

                documento.seleccionarCelda("C13");
                documento.actualizarValorCelda(carga.ATM.Full ? "Sí" : "No");

                documento.seleccionarCelda("C15");
                documento.actualizarValorCelda(carga.Cierre.Camara.ToString());

                documento.seleccionarCelda("H7");
                documento.actualizarValorCelda(carga.ToString());

                documento.seleccionarCelda("H9");
                documento.actualizarValorCelda(carga.Codigo);

                documento.seleccionarCelda("H13");
                documento.actualizarValorCelda(carga.Ruta.ToString());

                documento.seleccionarCelda("H15");
                documento.actualizarValorCelda(carga.ATM.Cartucho_rechazo ? "Sí" : "No");

                // Mostrar los datos del manifiesto

                documento.seleccionarCelda("C37");
                documento.actualizarValorCelda(carga.Manifiesto.Codigo);

                documento.seleccionarCelda("C39");
                documento.actualizarValorCelda(carga.Manifiesto.Marchamo);

                documento.seleccionarCelda("H39");
                documento.actualizarValorCelda(carga.Manifiesto.Marchamo_adicional);

                if (carga.Bolsa_Rechazo)
                {
                    documento.seleccionarCelda("H41");
                    documento.actualizarValorCelda(carga.Manifiesto.Bolsa_rechazo);
                }

                if (carga.ATM_full)
                {
                    documento.seleccionarCelda("C41");
                    documento.actualizarValorCelda(carga.Manifiesto_full.Marchamo);

                    documento.seleccionarCelda("H37");
                    documento.actualizarValorCelda(carga.Manifiesto_full.Codigo);

                    if (carga.ENA)
                    {
                        documento.seleccionarCelda("C43");
                        documento.actualizarValorCelda(carga.Manifiesto_full.Marchamo_ena_a);

                        documento.seleccionarCelda("C45");
                        documento.actualizarValorCelda(carga.Manifiesto_full.Marchamo_ena_b);

                        documento.seleccionarCelda("H43");
                        documento.actualizarValorCelda(carga.Manifiesto_full.Marchamo_adicional_ena);
                    }

                }

                // Imprimir los montos

                int fila_colones = 0;
                int fila_dolares = 0;

                foreach (CartuchoCargaATM cartucho in carga.Cartuchos)
                {

                    switch (cartucho.Denominacion.Moneda)
                    {
                        case Monedas.Colones:
                            documento.seleccionarCelda(19 + fila_colones, 1);
                            documento.actualizarValorCelda(cartucho.Denominacion.Valor.ToString());

                            documento.seleccionarCelda(19 + fila_colones, 4);
                            documento.actualizarValorCelda(cartucho.Denominacion.Codigo);

                            documento.seleccionarCelda(19 + fila_colones, 5);
                            documento.actualizarValorCelda(cartucho.Cantidad_carga.ToString());

                            documento.seleccionarCelda(19 + fila_colones, 6);
                            documento.actualizarValorCelda(cartucho.Cartucho.Numero.ToString());

                            documento.seleccionarCelda(19 + fila_colones, 7);
                            documento.actualizarValorCelda(cartucho.Marchamo);

                            fila_colones++;
                            break;
                        case Monedas.Dolares:
                            documento.seleccionarCelda(33 + fila_dolares, 1);
                            documento.actualizarValorCelda(cartucho.Denominacion.Valor.ToString());

                            documento.seleccionarCelda(33 + fila_dolares, 4);
                            documento.actualizarValorCelda(cartucho.Denominacion.Codigo);

                            documento.seleccionarCelda(33 + fila_dolares, 5);
                            documento.actualizarValorCelda(cartucho.Cantidad_carga.ToString());

                            documento.seleccionarCelda(33 + fila_dolares, 6);
                            documento.actualizarValorCelda(cartucho.Cartucho.Numero.ToString());

                            documento.seleccionarCelda(33 + fila_dolares, 7);
                            documento.actualizarValorCelda(cartucho.Marchamo);

                            fila_dolares++;
                            break;
                    }

                }

                // Imprimir el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        #endregion Métodos Privados

        private void lblTamanoFuente_Click(object sender, EventArgs e)
        {

        }

    }

}
