using BussinessLayer;
using CommonObjects;
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

namespace GUILayer.Formularios.Sucursales
{
    public partial class frmRecepcionEntregaTulasSucursal : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _colaborador = null;

        private bool _coordinador = false;
        private bool _analista = false;

        private String _comentario = String.Empty;

        private DateTime _desde;
        private DateTime _hasta;

        #endregion Atributos

        #region Constructor

        public frmRecepcionEntregaTulasSucursal(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;

            cboColaboradorAlistaRemesa.ListaMostrada = _seguridad.listarColaboradoresPorPuestoSucural(_colaborador.Sucursal, Puestos.Coordinador, Puestos.Receptor, Puestos.Tesorero, Puestos.Gerente);
            cboColaboradorApruebaRemesa.ListaMostrada = _seguridad.listarColaboradoresPorPuestoSucural(_colaborador.Sucursal, Puestos.Coordinador, Puestos.Receptor, Puestos.Tesorero, Puestos.Gerente);
            cboPortavalor.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.Blindados, Puestos.Portavalor);

            try
            {
                
               
               
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

                Sucursal sucursal = _colaborador.Sucursal;

                Colaborador colaborador_asigna = cboColaboradorAlistaRemesa.SelectedIndex == 0 ?
                    null : (Colaborador)cboColaboradorAlistaRemesa.SelectedItem;

                Colaborador colaborador_aprueba = cboColaboradorApruebaRemesa.SelectedIndex == 0 ?
                   null : (Colaborador)cboColaboradorApruebaRemesa.SelectedItem;

                //Colaborador portavalor = cboPortavalor.SelectedIndex == 0 ?
                //   null : (Colaborador)cboPortavalor.SelectedItem;

                int tipocarga = cboTipoRemesa.SelectedIndex;
               
                dgvCargas.DataSource = _coordinacion.listarPedidoEnvioRemesas(fecha,fecha_fin, _colaborador.Sucursal,colaborador_asigna,colaborador_aprueba, tipocarga);


                foreach (DataGridViewColumn columna in dgvCargas.Columns)
                    if (columna.ValueType == typeof(decimal))
                        columna.DefaultCellStyle.Format = "N2";

                // Habilitar los botones de exportar a excel y graficar el reporte si el mismo tiene datos

                if (dgvCargas.RowCount > 0)
                {
                    btnExportarExcel.Enabled = true;
   
                }
                else
                {
                    btnExportarExcel.Enabled = false;
     

                }

                _desde = dtpFecha.Value;
                _hasta = dtpFechaFin.Value;
               
               
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
        /// Clic en el boton de exportar a Excel
        /// </summary>
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.exportar();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }
        }
       
        #endregion Eventos

        #region Métodos Privados
        /// <summary>
        /// Exportar el reporte.
        /// </summary>
        private void exportar()
        {

            try
            {

                if (dgvCargas.RowCount > 0)
                {
                    DocumentoExcel documento = new DocumentoExcel();
                    DataTable datos = (DataTable)dgvCargas.DataSource;
                    documento.seleccionarHoja(1);

                    int fila = 8;

                    // Dar formato al encabezado del reporte

                    documento.seleccionarCelda("B2");
                    documento.actualizarValorCelda("");
                    documento.formatoCelda(subrayado: true, negrita: true, color_fuente: Color.Red);
                    documento.seleccionarSegundaCelda("F2");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    documento.seleccionarCelda("B3");
                    documento.actualizarValorCelda("Reporte de Pedidos y Envios de Remesas por parte de Sucursales");
                    documento.seleccionarSegundaCelda("F3");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);
                    documento.cambiarAjusteLinea(true);
                    documento.cambiarTamanoFila(50);
                    documento.cambiarAlineacionTexto(AlineacionVertical.Centro, AlineacionHorizontal.Centro);

                    documento.seleccionarCelda("B4");
                    documento.actualizarValorCelda("Desde:");
                    documento.formatoCelda(negrita: true);
                    documento.seleccionarSegundaCelda("F4");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    documento.seleccionarCelda("B5");
                    documento.actualizarValorCelda(_desde.ToString());
                    documento.seleccionarSegundaCelda("F5");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    documento.seleccionarCelda("B6");
                    documento.actualizarValorCelda("Hasta:");
                    documento.formatoCelda(negrita: true);
                    documento.seleccionarSegundaCelda("F6");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    documento.seleccionarCelda("B7");
                    documento.actualizarValorCelda(_hasta.ToString());
                    documento.seleccionarSegundaCelda("F7");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    //foreach (Parametro parametro in _reporte.Parametros)
                    //{
                    //    string etiqueta = parametro.Nombre;

                    //    documento.seleccionarCelda(fila, 2);
                    //    documento.actualizarValorCelda(etiqueta);
                    //    documento.formatoCelda(negrita: true);
                    //    documento.seleccionarCelda(fila, 6);
                    //    documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    //    fila += 2;
                    //}

                    fila = 9;

                    //foreach (ComboBox lista in _controles)
                    //{
                    //    string valor = lista.Text;

                    //    documento.seleccionarCelda(fila, 2);
                    //    documento.actualizarValorCelda(valor);
                    //    documento.seleccionarCelda(fila, 6);
                    //    documento.ajustarCeldas(AlineacionHorizontal.Centro);

                    //    fila += 2;
                    //}

                    documento.seleccionarCelda("B2");
                    documento.seleccionarSegundaCelda(fila - 2, 6);
                    documento.formatoTabla(false);

                    // Copiar los valores

                    int filas = dgvCargas.Rows.Count;

                    foreach (DataGridViewColumn columna in dgvCargas.Columns)
                    {
                        int numero_columna = columna.Index + 2;

                        documento.seleccionarCelda(fila, numero_columna);
                        documento.actualizarValorCelda(columna.HeaderText);
                        documento.formatoCelda(subrayado: true, color_fondo: Color.LightGray);
                        documento.seleccionarSegundaCelda(fila + filas, numero_columna);
                        documento.autoajustarTamanoColumnas();
                    }

                    documento.seleccionarCelda(fila + 1, 2);
                    documento.actualizarValoresTabla(datos);

                    documento.seleccionarCelda(fila, 2);
                    documento.seleccionarSegundaCelda(fila + filas, dgvCargas.Columns.Count + 1);
                    documento.formatoTabla(false);

                    // Mostrar el libro y cerrarlo

                    documento.mostrar();
                    documento.cerrar();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       

        #endregion Métodos Privados

       
        #region Metodos Publicos
        
        
        
        #endregion Metodos Publicos
    }
}
