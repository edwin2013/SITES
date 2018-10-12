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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.ATMs
{
    public partial class frmGenerarRecaptFinal : Form
    {
        
        #region Atributos

        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private RecaptFinal _recapt_pedido_colones;
        private RecaptFinal _recapt_pedido_dolares;
        private RecaptFinal _recapt_envio_colones;
        private RecaptFinal _recapt_envio_dolares;
        private RecaptFinal _recapt_auxiliar;

        private Colaborador _coordinador = null;

        private bool _supervisor = false;

        #endregion Atributos

        #region Constructor

        public frmGenerarRecaptFinal(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            dgvEnvioColones.AutoGenerateColumns = false;
            dgvEnvioDolares.AutoGenerateColumns = false;
            dgvPedidoColones.AutoGenerateColumns = false;
            dgvPedidoDolares.AutoGenerateColumns = false;

           

            CultureInfo anterior = System.Threading.Thread.CurrentThread.CurrentCulture;
            CultureInfo nueva = (CultureInfo)anterior.Clone();

            nueva.NumberFormat.NumberDecimalSeparator = ".";
            nueva.NumberFormat.NumberGroupSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture = nueva;

            CultureInfo cultura = System.Threading.Thread.CurrentThread.CurrentCulture;
        }



        public frmGenerarRecaptFinal(Colaborador coordinador, RecaptFinal recapt)
        {
            InitializeComponent();

            _coordinador = coordinador;

            dgvEnvioColones.AutoGenerateColumns = false;
            dgvEnvioDolares.AutoGenerateColumns = false;
            dgvPedidoColones.AutoGenerateColumns = false;
            dgvPedidoDolares.AutoGenerateColumns = false;



            CultureInfo anterior = System.Threading.Thread.CurrentThread.CurrentCulture;
            CultureInfo nueva = (CultureInfo)anterior.Clone();

            nueva.NumberFormat.NumberDecimalSeparator = ".";
            nueva.NumberFormat.NumberGroupSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture = nueva;

            CultureInfo cultura = System.Threading.Thread.CurrentThread.CurrentCulture;
        }

        /// <summary>
        /// Crear las filas de los DataGridView's.
        /// </summary>
        private void crearTablaDolares(DataGridView tabla)
        {
            
            tabla.Rows.Add("100", 0);
            tabla.Rows.Add("50", 0);
            tabla.Rows.Add("20", 0);
            tabla.Rows.Add("10", 0);
            tabla.Rows.Add("5", 0);
            tabla.Rows.Add("1", 0);
            tabla.Rows.Add(string.Empty, string.Empty);
            tabla.Rows.Add("Total", 0);
        }


        /// <summary>
        /// Crear las filas de los DataGridView's.
        /// </summary>
        private void crearTablaColones(DataGridView tabla)
        {
            tabla.Rows.Add("50.000", 0);
            tabla.Rows.Add("20.000", 0);
            tabla.Rows.Add("10.000", 0);
            tabla.Rows.Add("5.000", 0);
            tabla.Rows.Add("2.000", 0);
            tabla.Rows.Add("1.000", 0);
            tabla.Rows.Add("500", 0);
            tabla.Rows.Add("100", 0);
            tabla.Rows.Add("50", 0);
            tabla.Rows.Add("25", 0);
            tabla.Rows.Add("10", 0);
            tabla.Rows.Add("5", 0);
            tabla.Rows.Add(string.Empty, string.Empty);
            tabla.Rows.Add("Total", 0);
           
        }

        /// <summary>
        /// Dar formato de solo lectura a las filas que lo requieran.
        /// </summary>
        private void formatoCeldaSoloLectura(DataGridView tabla, params int[] filas)
        {

            foreach (int fila in filas)
            {
                tabla.Rows[fila].ReadOnly = true;
                tabla.Rows[fila].DefaultCellStyle.BackColor = tabla.Columns[0].DefaultCellStyle.BackColor;
            }

        }

        /// <summary>
        /// Dar formato a las celdas que son separadoras.
        /// </summary>
        private void formatoCeldaSeparador(DataGridView tabla, params int[] filas)
        {

            foreach (int fila in filas)
            {
                tabla.Rows[fila].ReadOnly = true;
                tabla.Rows[fila].DefaultCellStyle.BackColor = Color.DarkBlue;
            }

        }

        #endregion Constructor

        #region Eventos
        /// <summary>
        /// Botón de Generar Recapt Preliminar
        /// </summary>
        private void btnGenear_Click(object sender, EventArgs e)
        {
            BindingList<Recap> lista_recaps = new BindingList<Recap>();

            lista_recaps = _coordinacion.listarRecap(DateTime.Now);


            _recapt_auxiliar = new RecaptFinal();

            _recapt_auxiliar.Cartuchos =_coordinacion.listarRecaptFinal(DateTime.Now);

            marcarDenominaciones(_recapt_auxiliar);


        }


        private void dgvPedidoDolares_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Clic en el botón de Exportar
        /// </summary>
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            this.imprimirHojaCarga();
        }

        /// <summary>
        /// Guarda los recapt de pedido y envío
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                RecaptFinal recapt_pedido = new RecaptFinal();

                BindingList<MontosRecaptFinal> montos_dolares_pedido = (BindingList<MontosRecaptFinal>)dgvPedidoDolares.DataSource;
                BindingList<MontosRecaptFinal> montos_colones_pedido = (BindingList<MontosRecaptFinal>)dgvPedidoColones.DataSource;

                montos_colones_pedido.Union(montos_dolares_pedido);

                recapt_pedido.Cartuchos = montos_colones_pedido;
                recapt_pedido.Estado = EstadoRecapt.Por_Aprobar;
                recapt_pedido.Colaborador = _coordinador;
                recapt_pedido.TipoRecap = TipoRecapt.Pedido_Colones;


                RecaptFinal recapt_envio = new RecaptFinal();

                BindingList<MontosRecaptFinal> montos_dolares_envio = (BindingList<MontosRecaptFinal>)dgvEnvioDolares.DataSource;
                BindingList<MontosRecaptFinal> montos_colones_envio = (BindingList<MontosRecaptFinal>)dgvEnvioColones.DataSource;

                montos_colones_envio.Union(montos_dolares_envio);

                //foreach(MontosRecaptFinal m in montos_dolares_envio)
                //{
                //    montos_colones_envio.Add(m);
                //}

                // BindingList<MontosRecaptFinal> _ultima_envio = (BindingList<MontosRecaptFinal>)montos_colones_envio.Union(montos_dolares_envio);

                recapt_envio.Cartuchos = montos_colones_envio;
                recapt_envio.Estado = EstadoRecapt.Por_Aprobar;
                recapt_envio.Colaborador = _coordinador;
                recapt_envio.TipoRecap = TipoRecapt.Envio_Colones;


                _coordinacion.agregarRecaptFinal(recapt_pedido);

                _coordinacion.agregarRecaptFinal(recapt_envio);


            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        #endregion Eventos

        #region Métodos Públicos

        /// <summary>
        /// Permite dividir los montos en cada recuadre
        /// </summary>
        /// <param name="rec">Objeto RecatpPreliminiar con los datos de Recapt</param>
        public void marcarDenominaciones(RecaptFinal rec)
        {
            BindingList<MontosRecaptFinal> envios_colones = new BindingList<MontosRecaptFinal>();
            BindingList<MontosRecaptFinal> envios_dolares = new BindingList<MontosRecaptFinal>();
            BindingList<MontosRecaptFinal> pedido_colones = new BindingList<MontosRecaptFinal>();
            BindingList<MontosRecaptFinal> pedido_dolares = new BindingList<MontosRecaptFinal>();

            try
            {
                foreach (MontosRecaptFinal m in rec.Cartuchos)
                {

                    if (m.Denominacion.Moneda == Monedas.Colones)
                    {
                        if (m.Monto_asignado > 0)
                        {
                            pedido_colones.Add(m);
                        }
                        else
                        {
                            envios_colones.Add(m);
                        }
                    }
                    else
                    {
                        if (m.Monto_asignado > 0)
                        {
                            pedido_dolares.Add(m);
                        }
                        else
                        {
                            envios_dolares.Add(m);
                        }
                    }
                }

                dgvEnvioColones.DataSource = envios_colones;
                dgvEnvioDolares.DataSource = envios_dolares;
                dgvPedidoColones.DataSource = pedido_colones;
                dgvPedidoDolares.DataSource = pedido_dolares;
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }



        /// <summary>
        /// Imprimir los datos de la hoja de la carga seleccionada.
        /// </summary>
        private void imprimirHojaCarga()
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla recap atm's.xlt", true);

                RecaptFinal _pedido = new RecaptFinal();
                RecaptFinal _envio = new RecaptFinal();

                BindingList<MontosRecaptFinal> _pedidos_colones = (BindingList<MontosRecaptFinal>)dgvPedidoColones.DataSource;
                BindingList<MontosRecaptFinal> _pedidos_dolares = (BindingList<MontosRecaptFinal>)dgvPedidoDolares.DataSource;
                BindingList<MontosRecaptFinal> _envios_colones = (BindingList<MontosRecaptFinal>)dgvEnvioColones.DataSource;
                BindingList<MontosRecaptFinal> _envios_dolares = (BindingList<MontosRecaptFinal>)dgvEnvioDolares.DataSource;

                documento.seleccionarHoja(1);

                // Escribir los datos
                // Pedidos en Colones
                foreach (MontosRecaptFinal monto in _pedidos_colones)
                {
                    switch (Convert.ToInt32( monto.Denominacion.Valor))
                    {
                        case 50000:
                            documento.seleccionarCelda("B13");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                        break;

                        case 20000:
                        documento.seleccionarCelda("B14");
                        documento.actualizarValorCelda(monto.Cantidad_asignada);
                        break;


                        case 10000:
                        documento.seleccionarCelda("B15");
                        documento.actualizarValorCelda(monto.Cantidad_asignada);
                        break;

                        case 5000:
                        documento.seleccionarCelda("B16");
                        documento.actualizarValorCelda(monto.Cantidad_asignada);
                        break;


                        case 2000:
                        documento.seleccionarCelda("B17");
                        documento.actualizarValorCelda(monto.Cantidad_asignada);
                        break;

                        case 1000:
                        documento.seleccionarCelda("B18");
                        documento.actualizarValorCelda(monto.Cantidad_asignada);
                        break;

                    }
                           
                }

                documento.seleccionarCelda("B39");
                documento.actualizarValorCelda("Ref. pedido atm "+ DateTime.Now.ToShortDateString());

                //Pedidos en Dólares
                documento.seleccionarHoja(2);


                foreach (MontosRecaptFinal monto in _pedidos_dolares)
                {
                    switch (Convert.ToInt32(monto.Denominacion.Valor))
                    {
                        case 500:
                            documento.seleccionarCelda("O14");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                            break;

                        case 100:
                            documento.seleccionarCelda("O15");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                            break;


                        case 50:
                            documento.seleccionarCelda("O16");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                            break;

                        case 20:
                            documento.seleccionarCelda("O17");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                            break;


                        case 10:
                            documento.seleccionarCelda("O18");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                            break;

                        case 5:
                            documento.seleccionarCelda("O19");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                            break;


                        case 1:
                            documento.seleccionarCelda("O21");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                            break;

                    }

                }


                documento.seleccionarCelda("B39");
                documento.actualizarValorCelda("Ref. pedido atm " + DateTime.Now.ToShortDateString());


                //Entregas colones
                documento.seleccionarHoja(3);

                foreach (MontosRecaptFinal monto in _envios_colones)
                {
                    switch (Convert.ToInt32(monto.Denominacion.Valor))
                    {
                        case 50000:
                            documento.seleccionarCelda("B13");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                            break;

                        case 20000:
                            documento.seleccionarCelda("B14");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                            break;


                        case 10000:
                            documento.seleccionarCelda("B15");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                            break;

                        case 5000:
                            documento.seleccionarCelda("B16");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                            break;


                        case 2000:
                            documento.seleccionarCelda("B17");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                            break;

                        case 1000:
                            documento.seleccionarCelda("B18");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                            break;

                    }

                }


                documento.seleccionarCelda("B39");
                documento.actualizarValorCelda("Ref. pedido atm " + DateTime.Now.ToShortDateString());
                //Entregas Dolares
                documento.seleccionarHoja(4);

                foreach (MontosRecaptFinal monto in _envios_dolares)
                {
                    switch (Convert.ToInt32(monto.Denominacion.Valor))
                    {
                        case 500:
                            documento.seleccionarCelda("O14");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                            break;

                        case 100:
                            documento.seleccionarCelda("O15");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                            break;


                        case 50:
                            documento.seleccionarCelda("O16");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                            break;

                        case 20:
                            documento.seleccionarCelda("O17");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                            break;


                        case 10:
                            documento.seleccionarCelda("O18");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                            break;

                        case 5:
                            documento.seleccionarCelda("O19");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                            break;


                        case 1:
                            documento.seleccionarCelda("O21");
                            documento.actualizarValorCelda(monto.Cantidad_asignada);
                            break;

                    }

                }

                documento.seleccionarCelda("B39");
                documento.actualizarValorCelda("Ref. pedido atm " + DateTime.Now.ToShortDateString());

                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }



        #endregion Métodos Públicos
    }
}
