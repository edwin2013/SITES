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

namespace GUILayer.Formularios.Facturacion
{
    public partial class frmFacturacionProcesamiento : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _colaborador = null;

        private bool _coordinador = false;
        private bool _analista = false;

        #endregion Atributos

        #region Constructor

        public frmFacturacionProcesamiento(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;
           
            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();

            cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);
            

            try
            {
                dgvCargas.AutoGenerateColumns = false;

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
                
                Cliente cliente = cboCliente.SelectedIndex == 0 ?
                    null : (Cliente)cboCliente.SelectedItem;

                EmpresaTransporte empresa = cboTransportadora.SelectedIndex == 0 ?
                    null : (EmpresaTransporte)cboTransportadora.SelectedItem;

                BindingList<FacturacionProcesamiento> lista = _coordinacion.listarResumenFacturacionProcesamiento(cliente, empresa, fecha, fecha_fin);
                


                dgvCargas.DataSource = lista;

                btnImprimir.Enabled = dgvCargas.Rows.Count > 0 ? true : false;
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
        /// Clic en el botón de revisar.
        /// </summary>
        private void btnRevisar_Click(object sender, EventArgs e)
        {
            this.mostrarVentanaRevision();
        }


        /// <summary>
        /// Clic en el boton de Actualizar para coordinadores.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualizarEspecial_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha = dtpFecha.Value;
     
                Cliente cliente = cboCliente.SelectedIndex == 0 ?
                    null : (Cliente)cboCliente.SelectedItem;

                EmpresaTransporte transportadora = cboTransportadora.SelectedIndex == 0 ?
                    null : (EmpresaTransporte)cboTransportadora.SelectedItem;
                //_coordinacion.ActualizarCargasATMRoadnet(fecha);
                //dgvCargas.DataSource = _coordinacion.listarCargasATMsEspeciales(cajero, cliente, fecha, ruta,transportadora);
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
        /// Se selecciona otra carga de la lista de cargas.
        /// </summary>
        private void dgvCargas_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCargas.SelectedRows.Count > 0)
            {
                //DataGridViewRow fila = dgvCargas.SelectedRows[0];
                //CargaATM carga = (CargaATM)fila.DataBoundItem;

            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.imprimirHoja();
        }

        #endregion Eventos
     
        #region Métodos Privados

        /// <summary>
        /// Imprimir los datos de una hoja de carga.
        /// </summary>
        private void imprimirHojaCarga(CargaATM carga)
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla carga.xlt", true);

                documento.seleccionarHoja(1);

                // Escribir los datos

                documento.seleccionarCelda("C7");
                documento.actualizarValorCelda(carga.Hora_inicio.ToShortDateString());

                documento.seleccionarCelda("C9");
                documento.actualizarValorCelda(carga.Hora_inicio.ToShortTimeString());

                documento.seleccionarCelda("C11");
                documento.actualizarValorCelda(Enum.GetName(typeof(TiposCartucho), carga.Tipo));

                documento.seleccionarCelda("C13");
                documento.actualizarValorCelda(carga.ATM_full ? "Sí" : "No");

                if (carga.Cierre.Camara != null)
                {
                    documento.seleccionarCelda("C15");
                    documento.actualizarValorCelda(carga.Cierre.Camara.ToString());
                }

                documento.seleccionarCelda("H7");
                documento.actualizarValorCelda(carga.ToString());

                documento.seleccionarCelda("H9");
                documento.actualizarValorCelda(carga.Codigo);

                documento.seleccionarCelda("H13");
                documento.actualizarValorCelda(carga.Ruta.ToString());

                documento.seleccionarCelda("H15");
                documento.actualizarValorCelda(carga.Cartucho_rechazo ? "Sí" : "No");

                documento.seleccionarCelda("A47");
                documento.actualizarValorCelda(carga.Cierre.Cajero.ToString() + " " + carga.Fecha_asignada.ToShortDateString());

                documento.seleccionarCelda("F47");
                documento.actualizarValorCelda(carga.Cierre.Coordinador.ToString() + " " + carga.Fecha_asignada.ToShortDateString());

                // Mostrar los datos de los manifiestos

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

                            documento.seleccionarCelda(19 + fila_colones,6);
                            documento.actualizarValorCelda(cartucho.Cartucho.Numero.ToString());

                            documento.seleccionarCelda(19 + fila_colones,7);
                            documento.actualizarValorCelda(cartucho.Marchamo);

                            fila_colones++;
                            break;
                        case Monedas.Dolares:
                            documento.seleccionarCelda(33 + fila_dolares, 1);
                            documento.actualizarValorCelda(cartucho.Denominacion.Valor.ToString());

                            documento.seleccionarCelda(19 + fila_colones, 4);
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

        /// <summary>
        /// Mostrar la ventana de revisión de la carga.
        /// </summary>
        private void mostrarVentanaRevision()
        {
            CargaATM carga = (CargaATM)dgvCargas.SelectedRows[0].DataBoundItem;
            frmModificacionCarga formulario = new frmModificacionCarga(carga, _colaborador, true);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Mostrar la ventana de modificación de la carga.
        /// </summary>
        private void mostrarVentanaModificacion()
        {
            CargaATM carga = (CargaATM)dgvCargas.SelectedRows[0].DataBoundItem;
            frmModificacionCarga formulario = new frmModificacionCarga(carga, _colaborador, false);

            formulario.ShowDialog(this);

            carga.recalcularMontosCarga();

            dgvCargas.Refresh();
        }

        private void imprimirHoja()
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla Facturacion ProcesamientoExterno.xlt", true);

                documento.seleccionarHoja(1);

                // Escribir los datos

                //documento.seleccionarCelda("E5");
                //documento.actualizarValorCelda(dgvCargas.Rows.Count);

                //documento.seleccionarCelda("E6");
                //documento.actualizarValorCelda(lblMontoTipoCambio.Text);

                //documento.seleccionarCelda("C11");
                //documento.actualizarValorCelda(Enum.GetName(typeof(TiposCartucho), carga.Tipo));

                //documento.seleccionarCelda("C13");
                //documento.actualizarValorCelda(carga.ATM_full ? "Sí" : "No");


                // Imprimir los montos

                int fila = 5;


                foreach (DataGridViewRow r in dgvCargas.Rows)
                {

                    FacturacionProcesamiento datos = (FacturacionProcesamiento)r.DataBoundItem;

                    documento.seleccionarCelda(fila, 1);
                    documento.actualizarValorCelda(datos.Fecha);

                    documento.seleccionarCelda(fila, 2);
                    documento.actualizarValorCelda(datos.Cliente.Nombre);

                    documento.seleccionarCelda(fila, 3);
                    documento.actualizarValorCelda(datos.MontoTotalColones);

                    documento.seleccionarCelda(fila, 4);
                    documento.actualizarValorCelda(datos.MontoTotalDolares);

                    documento.seleccionarCelda(fila, 5);
                    documento.actualizarValorCelda(datos.MontoTotalNiquel);

                    documento.seleccionarCelda(fila, 6);
                    documento.actualizarValorCelda(datos.TarifaColones);

                    documento.seleccionarCelda(fila, 7);
                    documento.actualizarValorCelda(datos.TarifaDolares);

                    documento.seleccionarCelda(fila, 8);
                    documento.actualizarValorCelda(datos.TarifaNiquel);

                  
                    fila++;
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

        

    }
}
