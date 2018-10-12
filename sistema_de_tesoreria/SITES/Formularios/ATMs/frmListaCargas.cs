//
//  @ Project : 
//  @ File Name : frmListaCargas.cs
//  @ Date : 13/06/2012
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

    public partial class frmListaCargas : Form
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

        public frmListaCargas(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;
            _coordinador = _colaborador.Puestos.Contains(Puestos.Coordinador) || _colaborador.Puestos.Contains(Puestos.Supervisor);
            _analista = _colaborador.Puestos.Contains(Puestos.Analista);
            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();

            if (_coordinador || _analista)
            {
                pnlOpcionesCoordinacion.Enabled = true;
                //pnlOpcionesCoordinacion.Enabled = _coordinador;
                //pnlOpcionesCoordinacion.Enabled = _analista;
            }
           
            if (_coordinador)
            {
               // btnEliminar.Enabled = true;
                //cboTransportadora.Enabled = true;
                //btnActualizar.Enabled = false;
                //btnActualizarEspecial.Enabled = true;
                btnActualizar.Enabled = true;
            }
            if (_analista)
            {
                cboTransportadora.Enabled = true;
                btnActualizar.Enabled = false;
                btnActualizarEspecial.Enabled = true;
            }

            try
            {
                dgvCargas.AutoGenerateColumns = false;

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
                Colaborador cajero = cboCajero.SelectedIndex == 0 ?
                    null : (Colaborador)cboCajero.SelectedItem;
                ATM atm = cboATM.SelectedIndex == 0 ?
                    null : (ATM)cboATM.SelectedItem;
                byte? ruta = chkRuta.Checked ?
                    (byte?)nudRuta.Value : null;

                dgvCargas.DataSource = _coordinacion.listarCargasATMs(cajero, atm, fecha, ruta);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de asignar ruta.
        /// </summary>
        private void btnAsignarRuta_Click(object sender, EventArgs e)
        {

            try
            {
                BindingList<CargaATM> cargas = new BindingList<CargaATM>();

                foreach (DataGridViewRow fila in dgvCargas.SelectedRows)
                    cargas.Add((CargaATM)fila.DataBoundItem);

                frmAsignacionRutas formulario = new frmAsignacionRutas(cargas);

                formulario.ShowDialog(this);

                dgvCargas.Refresh();
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
            CargaATM carga = (CargaATM)dgvCargas.SelectedRows[0].DataBoundItem;

            this.imprimirHojaCarga(carga);
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
        /// Clic en el botón de eliminar carga.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {

                if (Mensaje.mostrarMensajeConfirmacion("MensajeCargaATMEliminacion") == DialogResult.Yes)
                {

                    foreach (DataGridViewRow fila in dgvCargas.SelectedRows)
                    {
                        CargaATM carga = (CargaATM)fila.DataBoundItem;

                        _coordinacion.eliminarCargaATM(carga, _colaborador);

                        BindingList<CargaATM> _carguita = new BindingList<CargaATM>();
                        _carguita.Add(carga);

                        _coordinacion.guardarDatosATMINFO(_carguita, "E");

                        dgvCargas.Rows.Remove(fila);
                    }

                    Mensaje.mostrarMensaje("MensajeCargaATMConfirmacionEliminacion");
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de revisar los cartuchos por denominación y tipo.
        /// </summary>
        private void btnCartuchos_Click(object sender, EventArgs e)
        {
            BindingList<CargaATM> cargas = (BindingList<CargaATM>)dgvCargas.DataSource;
            frmCartuchosCarga formulario = new frmCartuchosCarga(cargas);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de revisar los montos por denominación de todas las cargas.
        /// </summary>
        private void btnMontos_Click(object sender, EventArgs e)
        {
            BindingList<CargaATM> cargas = (BindingList<CargaATM>)dgvCargas.DataSource;
            frmMontosCajeroCargas formulario = new frmMontosCajeroCargas(cargas);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Clic en el botón de ordenar ruta.
        /// </summary>
        private void btnOrdenRutas_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value;

            frmOrdenRuta formulario = new frmOrdenRuta(fecha);

            formulario.ShowDialog();
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
                Colaborador cajero = cboCajero.SelectedIndex == 0 ?
                    null : (Colaborador)cboCajero.SelectedItem;
                ATM atm = cboATM.SelectedIndex == 0 ?
                    null : (ATM)cboATM.SelectedItem;
                byte? ruta = chkRuta.Checked ?
                    (byte?)nudRuta.Value : null;
                EmpresaTransporte transportadora = cboTransportadora.SelectedIndex == 0 ?
                    null : (EmpresaTransporte)cboTransportadora.SelectedItem;
                //_coordinacion.ActualizarCargasATMRoadnet(fecha);
                dgvCargas.DataSource = _coordinacion.listarCargasATMsEspeciales(cajero, atm, fecha, ruta,transportadora);
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
                DataGridViewRow fila = dgvCargas.SelectedRows[0];
                CargaATM carga = (CargaATM)fila.DataBoundItem;

                if (_coordinador)
                {

                    if (carga.Cierre == null)
                        this.mostrarVentanaModificacion();
                    else
                        this.mostrarVentanaRevision();

                }
                else
                {
                    this.mostrarVentanaRevision();
                }

            }

        }

        /// <summary>
        /// Se agrega una carga a la lista de cargas.
        /// </summary>
        private void dgvCargas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCargas.Rows[e.RowIndex + contador];
                CargaATM carga = (CargaATM)fila.DataBoundItem;

                fila.Cells[ATMCarga.Index].Value = carga.ToString();

                if (carga.Colaborador_verificador != null)
                {

                    if (carga.Modificada)
                        fila.DefaultCellStyle.BackColor = Color.Green;
                    else
                        fila.DefaultCellStyle.BackColor = Color.LightGreen;

                }
                else if (carga.Cierre != null)
                {
                    fila.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (carga.Cajero != null)
                {
                    fila.DefaultCellStyle.BackColor = Color.LightCoral;
                }


                //Marca la carga según el tipo de visita. 

                if (carga.TipoVisita == TipoVisitas.Carga_Descarga)
                {
                    fila.Cells["clmCarga"].Value = true;
                    fila.Cells["clmDescarga"].Value = true; 

                }
                if (carga.TipoVisita == TipoVisitas.Descarga)
                {
                    fila.Cells["clmDescarga"].Value = true;
                }
                if (carga.TipoVisita == TipoVisitas.Carga_Descarga_Papel)
                {
                    fila.Cells["clmCarga"].Value = true;
                    fila.Cells["clmDescarga"].Value = true;
                    fila.Cells["clmPapel"].Value = true; 
                }
                if (carga.TipoVisita == TipoVisitas.Descarga_Papel)
                {
                    fila.Cells["clmDescarga"].Value = true;
                    fila.Cells["clmPapel"].Value = true; 
                }
                if (carga.TipoVisita == TipoVisitas.Papel)
                {
                    fila.Cells["clmPapel"].Value = true; 
                }


            }

        }

        /// <summary>
        /// Se selecciona otra carga de la lista de cargas.
        /// </summary>
        private void dgvCargas_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCargas.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvCargas.SelectedRows[0];
                CargaATM carga = (CargaATM)fila.DataBoundItem;

                btnAsignarRuta.Enabled = true;
                btnMontos.Enabled = true;
                btnCartuchos.Enabled = true;
                btnRevisar.Enabled = true;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;

                if (carga.Cierre == null)
                {
                    btnEliminar.Enabled = true;
                    btnModificar.Enabled = true;
                    btnImprimir.Enabled = false;
                }
                else
                {
                    btnEliminar.Enabled = true;
                    btnModificar.Enabled = true;
                    btnImprimir.Enabled = true;
                }

            }
            else
            {
                btnMontos.Enabled = false;
                btnCartuchos.Enabled = false;
                btnAsignarRuta.Enabled = false;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnRevisar.Enabled = false;
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
                            documento.actualizarValorCelda(cartucho.Denominacion.Valor);

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
                            documento.actualizarValorCelda(cartucho.Denominacion.Valor);

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

        #endregion Métodos Privados


       
        
    }

}
