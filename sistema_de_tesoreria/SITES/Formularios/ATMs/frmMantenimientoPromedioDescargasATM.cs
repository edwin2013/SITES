using BussinessLayer;
using CommonObjects.Clases;
using GUILayer.Formularios.ATMs;
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

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmMantenimientoPromedioDescargasATM : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private string _archivo = string.Empty;
        private BindingList<PromedioDescargaATM> _promedios = new BindingList<PromedioDescargaATM>();
        private PromedioDescargaATM _nivel = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoPromedioDescargasATM()
        {
            InitializeComponent();

            cboATM.ListaMostrada = _mantenimiento.listarATMs();
  
        }

        public frmMantenimientoPromedioDescargasATM(PromedioDescargaATM penalidad)
        {
            InitializeComponent();

            _nivel = penalidad;

            cboATM.ListaMostrada = _mantenimiento.listarATMs();

            cboATM.Text = penalidad.ATM.ToString();
            nudMonto.Value = penalidad.Monto;
          
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
                frmPromedioDescargasATM padre = (frmPromedioDescargasATM)this.Owner;

                CommonObjects.ATM ATM = (CommonObjects.ATM)cboATM.SelectedItem;
                decimal promedio = (decimal)nudMonto.Value;
                
                // Verificar si la nivel ya está registrada

                if (_nivel == null)
                {
                    // Agregar la nivel

                    if (Mensaje.mostrarMensajeConfirmacion("MensajePromedioDescargaATMRegistro") == DialogResult.Yes)
                    {
                        PromedioDescargaATM nueva = new PromedioDescargaATM(atm: ATM, monto: promedio);

                        _mantenimiento.agregarPromedioDescargaATM(ref nueva);
                        padre.agregarPromedioDescargaATM(nueva);

                        Mensaje.mostrarMensaje("MensajePromedioDescargaATMConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la nivel

                    PromedioDescargaATM copia = new PromedioDescargaATM(atm: ATM, monto: promedio, id: _nivel.ID);

                    _mantenimiento.actualizarPromedioDescargaATM(copia);

                  

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajePromedioDescargaATMConfirmacionActualizacion");
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

                    btnImportar.Enabled = _promedios.Count > 0;
                }
                else
                {
                    _archivo = string.Empty;

                    _promedios.Clear();

                    btnImportar.Enabled = false;
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }



        /// <summary>
        /// Importar Niveles de Servici
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_promedios.Count > 0)
                {
                    try
                    {
                        foreach (PromedioDescargaATM t in _promedios)
                        {
                            try
                            {
                                PromedioDescargaATM copia = t;

                                if (_mantenimiento.validarPromedioDescargaATM(ref copia))
                                {
                                    _mantenimiento.actualizarPromedioDescargaATM(copia);



                                }
                                else
                                {
                                    _mantenimiento.agregarPromedioDescargaATM(ref copia);

                                }
                            }
                            catch(Excepcion ex)
                            {
                                throw ex;
                            }
                        }

                        Mensaje.mostrarMensaje("MensajeImportacionPromedioDescargaATM");
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


                _promedios.Clear();


                archivo = new DocumentoExcel(_archivo, false);

                archivo.seleccionarHoja(1);

                Celda celda_id_atm = archivo.seleccionarCelda("A2");

                Celda celda_monto = archivo.seleccionarCelda("B2");



                this.generarCargasMoneda(archivo, celda_id_atm, celda_monto);



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
        private void generarCargasMoneda(DocumentoExcel archivo, Celda celda_id_atm, Celda celda_monto)
        {


            while (!celda_id_atm.Valor.Equals(string.Empty))
            {
                try
                {
                    
                    decimal monto =(decimal)Convert.ToInt32(celda_monto.Valor);

                    short numero_atm = short.Parse(celda_id_atm.Valor.Substring(0, 3));

                    CommonObjects.ATM atm = new CommonObjects.ATM(numero: numero_atm);

                    _mantenimiento.obtenerDatosATM(ref atm);

                    if (atm.ID != 0)
                    {

                        PromedioDescargaATM nueva = new PromedioDescargaATM(atm: atm, monto: monto);

                        _promedios.Add(nueva);
                    }

                    celda_id_atm = archivo.seleccionarCelda(celda_id_atm.Fila + 1, celda_id_atm.Columna);
                    celda_monto = archivo.seleccionarCelda(celda_monto.Fila + 1, celda_monto.Columna);
                   
                }
                catch (Excepcion ex)
                {
                    throw ex;
                }
            }

        }





        #endregion Metodos Privados
    }
}
