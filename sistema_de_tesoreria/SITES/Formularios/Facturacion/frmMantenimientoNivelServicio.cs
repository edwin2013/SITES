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
    public partial class frmMantenimientoNivelServicio : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private string _archivo = string.Empty;
        private BindingList<NivelServicio> _puntos = new BindingList<NivelServicio>();
        private NivelServicio _nivel = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoNivelServicio()
        {
            InitializeComponent();

            cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);
            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
        }

        public frmMantenimientoNivelServicio(NivelServicio penalidad)
        {
            InitializeComponent();

            _nivel = penalidad;
            cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);
            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();
            cboCliente.Text = penalidad.Cliente.ToString();
            nudPorcenajeCumplimiento.Value = (decimal)penalidad.PorcentajeNivelCumplimiento;
            nudPorcentajeEfectividad.Value = (decimal)penalidad.PorcentajeNivelEfectividad;
            dtpFechaInicio.Value = penalidad.FechaInicio;
            dtpFechaFin.Value = penalidad.FechaFin;
            cboTransportadora.Text = penalidad.Transportadora.ToString();
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos



            try
            {
                frmAdministracionNivelServicio padre = (frmAdministracionNivelServicio)this.Owner;

                Cliente cliente = (Cliente)cboCliente.SelectedItem;
                double porcentaje_cumplimiento = (double)nudPorcenajeCumplimiento.Value;
                double porcentaje_efectividad = (double)nudPorcentajeEfectividad.Value;
                DateTime fecha_inicio = dtpFechaInicio.Value;
                DateTime fecha_fin = dtpFechaFin.Value;
                EmpresaTransporte transportadora = (EmpresaTransporte)cboTransportadora.SelectedItem;

                // Verificar si la nivel ya está registrada

                if (_nivel == null)
                {
                    // Agregar la nivel

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeNivelServicioRegistro") == DialogResult.Yes)
                    {
                        NivelServicio nueva = new NivelServicio(cliente: cliente, porcentaje_cumplimiento: porcentaje_cumplimiento, porcentaje_efectividad: porcentaje_efectividad, fechainicio: fecha_inicio, fechafin: fecha_fin, transp: transportadora);

                        _mantenimiento.agregarNivelServicio(ref nueva);
                        padre.agregarNivelServicio(nueva);

                        Mensaje.mostrarMensaje("MensajeNivelServicioConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la nivel

                    NivelServicio copia = new NivelServicio(cliente: cliente, porcentaje_cumplimiento: porcentaje_cumplimiento, porcentaje_efectividad: porcentaje_efectividad, fechainicio: fecha_inicio, fechafin: fecha_fin, id: _nivel.Id, transp: transportadora);

                    _mantenimiento.actualizarNivelServicio(copia);

                    _nivel.Cliente = cliente;
                    _nivel.FechaInicio = fecha_inicio;
                    _nivel.FechaFin = fecha_fin;
                    _nivel.PorcentajeNivelCumplimiento = porcentaje_cumplimiento;
                    _nivel.PorcentajeNivelEfectividad = porcentaje_efectividad;


                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeNivelServicioConfirmacionActualizacion");
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



        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {

                if (ofdMontosCargas.ShowDialog() == DialogResult.OK)
                {
                    _archivo = ofdMontosCargas.FileName;
                    txtArchivo.Text = _archivo;
                    this.generarCargas();

                    btnImportar.Enabled = _puntos.Count > 0;
                }
                else
                {
                    _archivo = string.Empty;

                    _puntos.Clear();

                    btnImportar.Enabled = false;
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        #endregion Eventos


        #region Metodos Privados

        /// <summary>
        /// Leer los montos del archivo y generar las cargas.
        /// </summary>
        private void generarCargas()
        {
            DocumentoExcel archivo = null;

            try
            {


                _puntos.Clear();


                archivo = new DocumentoExcel(_archivo, false);

                archivo.seleccionarHoja(1);

                Celda celda_id_punto = archivo.seleccionarCelda("A3");

                Celda celda_id_transportadora = archivo.seleccionarCelda("D3");
                Celda celda_nivel_efectividad = archivo.seleccionarCelda("F3");
                Celda celda_fecha_inicio = archivo.seleccionarCelda("G3");
                Celda celda_fecha_fin = archivo.seleccionarCelda("H3");
               



                this.generarCargasMoneda(archivo, celda_id_punto, celda_id_transportadora, celda_nivel_efectividad, celda_fecha_inicio, celda_fecha_fin);



                archivo.mostrar();
                archivo.cerrar();


            }
            catch (Excepcion ex)
            {
                archivo.mostrar();
                archivo.cerrar();

                ex.mostrarMensaje();
            }

        }



        /// <summary>
        /// Generar las cargas para una moneda específica.
        /// </summary>
        private void generarCargasMoneda(DocumentoExcel archivo, Celda celda_id_cliente, Celda celda_id_transportadora, Celda celda_nivel_efectividad,
            Celda celda_fecha_inicio, Celda celda_fecha_fin)
        {


            while (!celda_id_cliente.Valor.Equals(string.Empty))
            {
                try
                {
                    short numero_punto = (short)Convert.ToInt32(celda_id_cliente.Valor);
                    byte numero_transportadora = (byte)Convert.ToInt32(celda_id_transportadora.Valor);
                    double nivel_efectividad =(double) Convert.ToDecimal(celda_nivel_efectividad.Valor);
                    DateTime fecha_inicio = Convert.ToDateTime(celda_fecha_inicio.Valor);
                    DateTime fecha_fin = Convert.ToDateTime(celda_fecha_fin.Valor);


                    Cliente cliente = new Cliente(id: numero_punto);
                    EmpresaTransporte transportadora = new EmpresaTransporte(id: numero_transportadora);


                    NivelServicio nueva = new NivelServicio(cliente: cliente, porcentaje_cumplimiento: 0, porcentaje_efectividad: nivel_efectividad * 100, fechainicio: fecha_inicio, fechafin: fecha_fin, transp: transportadora);

                    _puntos.Add(nueva);

                    celda_id_cliente = archivo.seleccionarCelda(celda_id_cliente.Fila + 1, celda_id_cliente.Columna);
                    celda_id_transportadora = archivo.seleccionarCelda(celda_id_transportadora.Fila + 1, celda_id_transportadora.Columna);
                    celda_nivel_efectividad = archivo.seleccionarCelda(celda_nivel_efectividad.Fila + 1, celda_nivel_efectividad.Columna);
                    celda_fecha_inicio = archivo.seleccionarCelda(celda_fecha_inicio.Fila + 1, celda_fecha_inicio.Columna);
                    celda_fecha_fin = archivo.seleccionarCelda(celda_fecha_fin.Fila + 1, celda_fecha_fin.Columna);
                    
                }
                catch (Excepcion ex)
                {
                    throw ex;
                }
            }

        }





        #endregion Metodos Privados


        /// <summary>
        /// Importar Niveles de Servici
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_puntos.Count > 0)
                {
                    try
                    {
                        foreach (NivelServicio t in _puntos)
                        {
                            NivelServicio copia = t;

                            if (_mantenimiento.validarNivelServicio(ref copia))
                            {
                                _mantenimiento.actualizarNivelServicio(copia);

                            }
                            else
                            {
                                _mantenimiento.agregarNivelServicio(ref copia);

                               
                            }
                        }
                        Mensaje.mostrarMensaje("MensajeImportacionNivelServicio");
                    }
                    catch (Excepcion ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


    }
}
