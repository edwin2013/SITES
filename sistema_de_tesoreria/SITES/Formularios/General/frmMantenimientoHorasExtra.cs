//
//  @ Project : 
//  @ File Name : frmMantenimientoHorasExtra.cs
//  @ Date : 05/08/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;
using System.Globalization;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmMantenimientoHorasExtra : Form
    {

        #region Atributos

        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private SupervisionBL _supervision = SupervisionBL.Instancia;

        private RegistroHorasExtra _registro = null;
        private Colaborador _coordinador = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoHorasExtra(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            txtCoordinador.Text = coordinador.ToString();

            try
            {
                this.cargarDatos();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
                this.Close();
            }

        }

        public frmMantenimientoHorasExtra(RegistroHorasExtra registro, Colaborador coordinador)
        {
            InitializeComponent();

            _registro = registro;
            _coordinador = coordinador;

            txtCoordinador.Text = _registro.Coordinador.ToString();
            dtpHoraIngreso.Value = _registro.Hora_ingreso;
            dtpHoraSalida.Value = _registro.Hora_salida;

            nudHoraDoble.Value = _registro.Horas_dobles;
            nudHorasExtra.Value = _registro.Horas_extra;
            nudExtraDoble.Value = _registro.Horas_dobles_extra;
            nudTransporte.Value = _registro.Transporte;
            nudAlimentacion.Value = _registro.Alimentacion;

            txtObservacionesConceptos.Text = _registro.Observaciones_conceptos;
            txtObservacionesGastos.Text = _registro.Observaciones_gastos;

            foreach (Motivos motivo in _registro.Motivos)
                clbConceptos.SetItemChecked((byte)motivo, true);

            if ((!_coordinador.Puestos.Contains(Puestos.Supervisor) &&
                _registro.Coordinador != _coordinador)
                || _registro.Estado != Estados.NoRevisado)
            {
                //btnGuardar.Enabled = false;
                gbDatos.Enabled = false;
                gbConceptos.Enabled = false;
               // gbTipoGasto.Enabled = false;
                pnlHoras.Enabled = false;
                txtObservacionesGastos.Enabled = false;

            }

            try
            {
                this.cargarDatos();

                cboColaborador.Text = _registro.Colaborador.ToString();

                lstPuestos.SelectedIndices.Clear();

                foreach (Puestos puesto in _registro.Puestos)
                    lstPuestos.SetSelected((byte)puesto, true);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
                this.Close();
            }

        }

        /// <summary>
        /// Cargar los datos de las listas.
        /// </summary>
        private void cargarDatos()
        {

            try
            {
                // Cargar las listas

                cboColaborador.ListaMostrada = _seguridad.listarColaboradores(string.Empty);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (cboColaborador.SelectedItem == null || clbConceptos.CheckedItems.Count == 0 ||
                lstPuestos.SelectedIndices.Count == 0)
            {
                Excepcion.mostrarMensaje("ErrorRegistroHorasExtraDatosRegistro");
                return;
            }

            try
            {
                frmAdministracionHorasExtra padre = (frmAdministracionHorasExtra)this.Owner;

                Colaborador colaborador = (Colaborador)cboColaborador.SelectedItem;
                DateTime hora_ingreso = dtpHoraIngreso.Value;
                DateTime hora_salida = dtpHoraSalida.Value;

                decimal horas_dobles = (decimal)nudHoraDoble.Value;
                decimal horas_extra = (decimal)nudHorasExtra.Value;
                decimal horas_dobles_extra = (decimal)nudExtraDoble.Value;
                decimal transporte = (decimal)nudTransporte.Value;
                decimal alimentacion = (decimal)nudAlimentacion.Value;

                string observaciones_conceptos = txtObservacionesConceptos.Text;
                string observaciones_gastos = txtObservacionesGastos.Text;

                // Verificar si el registro es nuevo

                if (_registro == null)
                {
                    // Agregar los datos del nuevo registro

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeRegistroHorasExtraRegistro") == DialogResult.Yes)
                    {
                        RegistroHorasExtra nuevo = new RegistroHorasExtra(colaborador: colaborador, coordinador: _coordinador, hora_ingreso: hora_ingreso,
                                                                          hora_salida: hora_salida, horas_extra: horas_extra, horas_dobles: horas_dobles,
                                                                          horas_dobles_extra: horas_dobles_extra, alimentacion: alimentacion,
                                                                          transporte: transporte, observaciones_conceptos: observaciones_conceptos,
                                                                          observaciones_gastos: observaciones_gastos);

                        foreach (int motivo in clbConceptos.CheckedIndices)
                            nuevo.agregarMotivo((Motivos)motivo);

                        foreach (int puesto in lstPuestos.SelectedIndices)
                            nuevo.agregarPuesto((Puestos)puesto);

                        _supervision.agregarRegistroHorasExtra(ref nuevo);

                        padre.agregarRegistro(nuevo);
                        Mensaje.mostrarMensaje("MensajeRegistroHorasExtraConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    RegistroHorasExtra copia = new RegistroHorasExtra(id: _registro.Id, colaborador: colaborador, coordinador: _registro.Coordinador,
                                                                      hora_ingreso: hora_ingreso, hora_salida: hora_salida, horas_extra: horas_extra,
                                                                      horas_dobles: horas_dobles, horas_dobles_extra: horas_dobles_extra,
                                                                      alimentacion: alimentacion, transporte: transporte,
                                                                      observaciones_conceptos: observaciones_conceptos,
                                                                      observaciones_gastos: observaciones_gastos);

                    foreach (int motivo in clbConceptos.CheckedIndices)
                        copia.agregarMotivo((Motivos)motivo);

                    foreach (int puesto in lstPuestos.SelectedIndices)
                        copia.agregarPuesto((Puestos)puesto);

                    // Actualizar los datos del registro

                    _supervision.actualizarRegistroHorasExtra(copia);

                    _registro.Colaborador = colaborador;
                    _registro.Hora_ingreso = hora_ingreso;
                    _registro.Hora_salida = hora_salida;

                    _registro.Horas_dobles_extra = horas_dobles_extra;
                    _registro.Horas_extra = horas_extra;
                    _registro.Horas_dobles = horas_dobles;
                    _registro.Transporte = transporte;
                    _registro.Alimentacion = alimentacion;

                    _registro.Observaciones_conceptos = observaciones_conceptos;
                    _registro.Observaciones_gastos = observaciones_gastos;

                    _registro.Motivos = copia.Motivos;
                    _registro.Puestos = copia.Puestos;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeRegistroHorasExtraConfirmacionActualizacion");
                    this.Close();
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
        /// Selección de un colaborador.
        /// </summary>
        private void cboColaborador_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboColaborador.SelectedItem != null)
            {
                Colaborador colaborador = (Colaborador)cboColaborador.SelectedItem;

                string area = string.Empty;

                switch (colaborador.Area)
                {
                    case Areas.ATMs:
                        area = "ATM's";
                        break;
                    case Areas.Boveda:
                        area = "Bóveda";
                        break;
                    case Areas.CentroEfectivo:
                        area = "Centro de Efectivo";
                        break;
                    case Areas.Tesoreria:
                        area = "Tesorería";
                        break;
                }

                txtArea.Text = area;
                txtIdentificacion.Text = colaborador.Identificacion;
            }

        }

        #endregion Eventos

        private void dtpHoraIngreso_ValueChanged(object sender, EventArgs e)
        {
            this.calcularHoras();
        }

        private void dtpHoraSalida_ValueChanged(object sender, EventArgs e)
        {
            this.calcularHoras();
        }



        private void chkDiaLibre_CheckedChanged(object sender, EventArgs e)
        {
            this.calcularHoras();
        }

        private void nudHorasJornada_ValueChanged(object sender, EventArgs e)
        {
            this.calcularHoras();
        }


        private void nudMinutosJornada_ValueChanged(object sender, EventArgs e)
        {
            this.calcularHoras();
        }

        private void calcularHoras()
        {
            DateTime hora_ingreso = dtpHoraIngreso.Value;
            DateTime hora_salida = dtpHoraSalida.Value;

            if (hora_ingreso > hora_salida)
                dtpHoraSalida.Value = hora_ingreso;

            TimeSpan total_horas = hora_salida - hora_ingreso;

            if (chkCalculoAutomatico.Checked)
            {
                int horas_jornada = (int)nudHorasJornada.Value;
                int minutos_jornada = (int)nudMinutosJornada.Value;

                TimeSpan jornada = new TimeSpan(horas_jornada, minutos_jornada, 0);
                TimeSpan extra = total_horas - jornada;

                if (extra.Ticks < 0) extra = TimeSpan.Zero;

                TimeSpan horas_extra = TimeSpan.Zero;
                TimeSpan horas_dobles = TimeSpan.Zero;
                TimeSpan horas_extras_dobles = TimeSpan.Zero;

                if (chkDiaLibre.Checked)
                {
                    horas_dobles = jornada;
                    horas_extras_dobles = extra;
                }
                else 
                {
                    horas_extra = extra;
                }

                nudHorasExtra.Value = (decimal)horas_extra.TotalHours;
                nudHoraDoble.Value = (decimal)horas_dobles.TotalHours;
                nudExtraDoble.Value = (decimal)horas_extras_dobles.TotalHours;
            }

        }

        private void chkCalculoAutomatico_CheckedChanged(object sender, EventArgs e)
        {
            pnlHoras.Enabled = !chkCalculoAutomatico.Checked;
        }

    }

}
