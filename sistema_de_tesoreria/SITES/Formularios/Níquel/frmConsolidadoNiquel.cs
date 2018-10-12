using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects;
using BussinessLayer;
using CommonObjects.Clases;
using LibreriaReportesOffice;
using LibreriaMensajes;

namespace GUILayer.Formularios.Níquel
{
    public partial class frmConsolidadoNiquel : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private LibroMayor _libro_mayor_pedidos = new LibroMayor();
        private LibroMayor _libro_mayor_entrega = new LibroMayor();
        private SaldoLibroBoveda _saldo_entregas = new SaldoLibroBoveda();
        private SaldoLibroNiquel _saldo_pedido = new SaldoLibroNiquel();
        private BindingList<LibroMayor> _lista_entrega = new BindingList<LibroMayor>();
        private BindingList<LibroMayor> _lista_pedidos = new BindingList<LibroMayor>();

        private decimal _total_50000_colones = 0;
        private decimal _total_20000_colones = 0;
        private decimal _total_10000_colones = 0;
        private decimal _total_5000_colones = 0;
        private decimal _total_2000_colones = 0;
        private decimal _total_1000_colones = 0;
        private decimal _total_500_colones = 0;
        private decimal _total_100_colones = 0;
        private decimal _total_50_colones = 0;
        private decimal _total_25_colones = 0;
        private decimal _total_10_colones = 0;
        private decimal _total_5_colones = 0;
        private decimal _total_cola = 0;
        private decimal _total_mutilado = 0;


        private decimal _total_100_dolares = 0;
        private decimal _total_50_dolares = 0;
        private decimal _total_20_dolares = 0;
        private decimal _total_10_dolares = 0;
        private decimal _total_5_dolares = 0;
        private decimal _total_1_dolares = 0;
        private decimal _total_cola_dolares = 0;
        private decimal _total_mutilado_dolares = 0;


        private decimal _total_500_euros = 0;
        private decimal _total_200_euros = 0;
        private decimal _total_100_euros = 0;
        private decimal _total_50_euros = 0;
        private decimal _total_20_euros = 0;
        private decimal _total_10_euros = 0;
        private decimal _total_5_euros = 0;
        private decimal _total_cola_euros = 0;
        private decimal _total_mutilado_euros = 0;



        private decimal _total_50000_colones_pedidos = 0;
        private decimal _total_20000_colones_pedidos = 0;
        private decimal _total_10000_colones_pedidos = 0;
        private decimal _total_5000_colones_pedidos = 0;
        private decimal _total_2000_colones_pedidos = 0;
        private decimal _total_1000_colones_pedidos = 0;
        private decimal _total_500_colones_pedidos = 0;
        private decimal _total_100_colones_pedidos = 0;
        private decimal _total_50_colones_pedidos = 0;
        private decimal _total_25_colones_pedidos = 0;
        private decimal _total_10_colones_pedidos = 0;
        private decimal _total_5_colones_pedidos = 0;
        private decimal _total_cola_pedidos = 0;
        private decimal _total_mutilado_pedidos = 0;


        private decimal _total_100_dolares_pedidos = 0;
        private decimal _total_50_dolares_pedidos = 0;
        private decimal _total_20_dolares_pedidos = 0;
        private decimal _total_10_dolares_pedidos = 0;
        private decimal _total_5_dolares_pedidos = 0;
        private decimal _total_1_dolares_pedidos = 0;
        private decimal _total_coladolares_pedidos = 0;
        private decimal _total_mutiladodolares_pedidos = 0;


        private decimal _total_500_euros_pedidos = 0;
        private decimal _total_200_euros_pedidos = 0;
        private decimal _total_100_euros_pedidos = 0;
        private decimal _total_50_euros_pedidos = 0;
        private decimal _total_20_euros_pedidos = 0;
        private decimal _total_10_euros_pedidos = 0;
        private decimal _total_5_euros_pedidos = 0;
        private decimal _total_colaeuros_pedidos = 0;
        private decimal _total_mutiladoeuros_pedidos = 0;


        /// <summary>
        /// Rubros ///
        /// </summary>


        private decimal _sucursales_entregas_colones = 0;
        private decimal _sucursales_entregas_dolares = 0;
        private decimal _sucursales_entregas_euros = 0;

        private decimal _cef1_entregas_colones = 0;
        private decimal _cef1_entregas_dolares = 0;
        private decimal _cef1_entregas_euros = 0;

        private decimal _cef2_entregas_colones = 0;
        private decimal _cef2_entregas_dolares = 0;
        private decimal _cef2_entregas_euros = 0;

        private decimal _cef3_entregas_colones = 0;
        private decimal _cef3_entregas_dolares = 0;
        private decimal _cef3_entregas_euros = 0;

        private decimal _cef4_entregas_colones = 0;
        private decimal _cef4_entregas_dolares = 0;
        private decimal _cef4_entregas_euros = 0;

        private decimal _cef5_entregas_colones = 0;
        private decimal _cef5_entregas_dolares = 0;
        private decimal _cef5_entregas_euros = 0;

        private decimal _bancos1_entregas_colones = 0;
        private decimal _bancos1_entregas_dolares = 0;
        private decimal _bancos1_entregas_euros = 0;

        private decimal _bancos2_entregas_colones = 0;
        private decimal _bancos2_entregas_dolares = 0;
        private decimal _bancos2_entregas_euros = 0;

        private decimal _bancos3_entregas_colones = 0;
        private decimal _bancos3_entregas_dolares = 0;
        private decimal _bancos3_entregas_euros = 0;

        private decimal _bancos4_entregas_colones = 0;
        private decimal _bancos4_entregas_dolares = 0;
        private decimal _bancos4_entregas_euros = 0;

        private decimal _bancos5_entregas_colones = 0;
        private decimal _bancos5_entregas_dolares = 0;
        private decimal _bancos5_entregas_euros = 0;

        private decimal _bancos6_entregas_colones = 0;
        private decimal _bancos6_entregas_dolares = 0;
        private decimal _bancos6_entregas_euros = 0;

        private decimal _bancos7_entregas_colones = 0;
        private decimal _bancos7_entregas_dolares = 0;
        private decimal _bancos7_entregas_euros = 0;

        private decimal _bancos8_entregas_colones = 0;
        private decimal _bancos8_entregas_dolares = 0;
        private decimal _bancos8_entregas_euros = 0;

        private decimal _bancos9_entregas_colones = 0;
        private decimal _bancos9_entregas_dolares = 0;
        private decimal _bancos9_entregas_euros = 0;
        
        private decimal _pedido_boveda_entregas_colones = 0;
        private decimal _pedido_boveda_entregas_dolares = 0;
        private decimal _pedido_boveda_entregas_euros = 0;

        private decimal _pedido_varios_entregas_colones = 0;
        private decimal _pedido_varios_entregas_dolares = 0;
        private decimal _pedido_varios_entregas_euros = 0;

        private decimal _cambio_denominacion_entregas_colones = 0;
        private decimal _cambio_denominacion_entregas_dolares = 0;
        private decimal _cambio_denominacion_entregas_euros = 0;

        private decimal _cambio_denominacion_entregas_colones1 = 0;
        private decimal _cambio_denominacion_entregas_dolares1 = 0;
        private decimal _cambio_denominacion_entregas_euros1 = 0;
        
        private decimal _cambio_denominacion_entregas_colones2 = 0;
        private decimal _cambio_denominacion_entregas_dolares2 = 0;
        private decimal _cambio_denominacion_entregas_euros2 = 0;


        private decimal _cola_cef_entregas_colones = 0;
        private decimal _cola_cef_entregas_dolares = 0;
        private decimal _cola_cef_entregas_euros = 0;




        /// <summary>
        /// ////////////////////////////////////////// PEDIDOS /////////////////////////////////////////////////////
        /// </summary>

        private decimal _sucursales_pedidos_colones = 0;
        private decimal _sucursales_pedidos_dolares = 0;
        private decimal _sucursales_pedidos_euros = 0;

        private decimal _cambiodenominacion_pedidos_colones = 0;
        private decimal _cambiodenominacion_pedidos_dolares = 0;
        private decimal _cambiodenominacion_pedidos_euros = 0;

        private decimal _cambiodenominacion_pedidos_colones1 = 0;
        private decimal _cambiodenominacion_pedidos_dolares1 = 0;
        private decimal _cambiodenominacion_pedidos_euros1 = 0;

        private decimal _cambiodenominacion_pedidos_colones2 = 0;
        private decimal _cambiodenominacion_pedidos_dolares2 = 0;
        private decimal _cambiodenominacion_pedidos_euros2 = 0;       

        private decimal _faltanteGeneral_pedidos_colones = 0;
        private decimal _faltanteGeneral_pedidos_dolares = 0;
        private decimal _faltanteGeneral_pedidos_euros = 0;

        private decimal _faltanteCEF_pedidos_colones = 0;
        private decimal _faltanteCEF_pedidos_dolares = 0;
        private decimal _faltanteCEF_pedidos_euros = 0;

        private decimal _pedidosvarios_pedidos_colones = 0;
        private decimal _pedidosvarios_pedidos_dolares = 0;
        private decimal _pedidosvarios_pedidos_euros = 0;

        private decimal _pedidosClientes_pedidos_colones = 0;
        private decimal _pedidosClientes_pedidos_dolares = 0;
        private decimal _pedidosClientes_pedidos_euros = 0;

        private Colaborador _usuario = null;
        #endregion Atributos

        #region Constructor
        public frmConsolidadoNiquel(Colaborador usuario)
        {
            InitializeComponent();
            _usuario = usuario;

        }

        #endregion Constructor

        #region Eventos
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value;
            _lista_entrega = _coordinacion.listarLibroMayorNiquelEntrega(fecha);
            _lista_pedidos = _coordinacion.listarLibroMayorNiquelPedido(fecha);
            _saldo_pedido = _coordinacion.listarSaldosNiquel(fecha);

            this.calcularMontosEntregas();
            this.calcularRubrosEntregas();
            this.calcularRubrosPedidos();

            this.imprimirHojaCarga(fecha);
        }

        #endregion Eventos

        #region Métodos Privados
        /// <summary>
        /// Imprimir los datos de la hoja de la carga seleccionada.
        /// </summary>
        private void imprimirHojaCarga(DateTime fecha)
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla libro niquel.xlt", true);

                documento.seleccionarHoja(1);

                //fecha
                documento.seleccionarCelda("A2");
                documento.actualizarValorCelda(fecha);


                //saldo anterior
                documento.seleccionarCelda("B5");
                documento.actualizarValorCelda(_saldo_pedido.MontoColones);

                documento.seleccionarCelda("C5");
                documento.actualizarValorCelda(_saldo_pedido.MontoDolares);

                documento.seleccionarCelda("D5");
                documento.actualizarValorCelda(_saldo_pedido.MontoEuros);

                //documento.seleccionarCelda("D53");
                //documento.actualizarValorCelda(_saldo_entregas.CustodiaAuxiliar);


                // Escribir los datos
                //Colones 
                documento.seleccionarCelda("B9");
                documento.actualizarValorCelda(_total_50000_colones_pedidos);
                documento.seleccionarCelda("B10");
                documento.actualizarValorCelda(_total_20000_colones_pedidos);
                documento.seleccionarCelda("B11");
                documento.actualizarValorCelda(_total_10000_colones_pedidos);
                documento.seleccionarCelda("B12");
                documento.actualizarValorCelda(_total_5000_colones_pedidos);
                documento.seleccionarCelda("B13");
                documento.actualizarValorCelda(_total_2000_colones_pedidos);
                documento.seleccionarCelda("B14");
                documento.actualizarValorCelda(_total_1000_colones_pedidos);
                documento.seleccionarCelda("B15");
                documento.actualizarValorCelda(_total_500_colones_pedidos);
                documento.seleccionarCelda("B17");
                documento.actualizarValorCelda(_total_100_colones_pedidos);
                documento.seleccionarCelda("B18");
                documento.actualizarValorCelda(_total_50_colones_pedidos);
                documento.seleccionarCelda("B19");
                documento.actualizarValorCelda(_total_25_colones_pedidos);
                documento.seleccionarCelda("B21");
                documento.actualizarValorCelda(_total_10_colones_pedidos);
                documento.seleccionarCelda("B22");
                documento.actualizarValorCelda(_total_5_colones_pedidos);

                //Cola y Mutilados
                documento.seleccionarCelda("B24");
                documento.actualizarValorCelda(_total_cola_pedidos);
                documento.seleccionarCelda("B25");
                documento.actualizarValorCelda(_total_mutilado_pedidos);



                //Dólares
                documento.seleccionarCelda("C17");
                documento.actualizarValorCelda(_total_100_dolares_pedidos);
                documento.seleccionarCelda("C18");
                documento.actualizarValorCelda(_total_50_dolares_pedidos);
                documento.seleccionarCelda("C20");
                documento.actualizarValorCelda(_total_20_dolares_pedidos);
                documento.seleccionarCelda("C21");
                documento.actualizarValorCelda(_total_10_dolares_pedidos);
                documento.seleccionarCelda("C22");
                documento.actualizarValorCelda(_total_5_dolares_pedidos);
                documento.seleccionarCelda("C23");
                documento.actualizarValorCelda(_total_1_dolares_pedidos);

                //Cola y Mutilado
                documento.seleccionarCelda("C24");
                documento.actualizarValorCelda(_total_coladolares_pedidos);
                documento.seleccionarCelda("C25");
                documento.actualizarValorCelda(_total_mutiladodolares_pedidos);


                //Euros
                documento.seleccionarCelda("D15");
                documento.actualizarValorCelda(_total_500_euros_pedidos);
                documento.seleccionarCelda("D16");
                documento.actualizarValorCelda(_total_200_euros_pedidos);
                documento.seleccionarCelda("D17");
                documento.actualizarValorCelda(_total_100_euros_pedidos);
                documento.seleccionarCelda("D18");
                documento.actualizarValorCelda(_total_50_euros_pedidos);
                documento.seleccionarCelda("D20");
                documento.actualizarValorCelda(_total_20_euros_pedidos);
                documento.seleccionarCelda("D21");
                documento.actualizarValorCelda(_total_10_euros_pedidos);
                documento.seleccionarCelda("D22");
                documento.actualizarValorCelda(_total_5_euros_pedidos);

                //Cola y Mutilados
                documento.seleccionarCelda("D24");
                documento.actualizarValorCelda(_total_colaeuros_pedidos);
                documento.seleccionarCelda("D25");
                documento.actualizarValorCelda(_total_mutiladoeuros_pedidos);



                ////////////////////////////////////////////////////////////ENTREGAS//////////////////////////////////////////////////////////////


                // Escribir los datos
                //Colones 
                documento.seleccionarCelda("B30");
                documento.actualizarValorCelda(_total_50000_colones);
                documento.seleccionarCelda("B31");
                documento.actualizarValorCelda(_total_20000_colones);
                documento.seleccionarCelda("B32");
                documento.actualizarValorCelda(_total_10000_colones);
                documento.seleccionarCelda("B33");
                documento.actualizarValorCelda(_total_5000_colones);
                documento.seleccionarCelda("B34");
                documento.actualizarValorCelda(_total_2000_colones);
                documento.seleccionarCelda("B35");
                documento.actualizarValorCelda(_total_1000_colones);
                documento.seleccionarCelda("B36");
                documento.actualizarValorCelda(_total_500_colones);
                documento.seleccionarCelda("B38");
                documento.actualizarValorCelda(_total_100_colones);
                documento.seleccionarCelda("B39");
                documento.actualizarValorCelda(_total_50_colones);
                documento.seleccionarCelda("B40");
                documento.actualizarValorCelda(_total_25_colones);
                documento.seleccionarCelda("B42");
                documento.actualizarValorCelda(_total_10_colones);
                documento.seleccionarCelda("B43");
                documento.actualizarValorCelda(_total_5_colones);

                //Cola y Mutilados
                documento.seleccionarCelda("B45");
                documento.actualizarValorCelda(_total_cola);
                documento.seleccionarCelda("B46");
                documento.actualizarValorCelda(_total_mutilado);



                //Dólares
                documento.seleccionarCelda("C38");
                documento.actualizarValorCelda(_total_100_dolares);
                documento.seleccionarCelda("C39");
                documento.actualizarValorCelda(_total_50_dolares);
                documento.seleccionarCelda("C41");
                documento.actualizarValorCelda(_total_20_dolares);
                documento.seleccionarCelda("C42");
                documento.actualizarValorCelda(_total_10_dolares);
                documento.seleccionarCelda("C43");
                documento.actualizarValorCelda(_total_5_dolares);
                documento.seleccionarCelda("C44");
                documento.actualizarValorCelda(_total_1_dolares);

                //Cola y Mutilado
                documento.seleccionarCelda("C45");
                documento.actualizarValorCelda(_total_cola_dolares);
                documento.seleccionarCelda("C46");
                documento.actualizarValorCelda(_total_mutilado_dolares);


                //Euros
                documento.seleccionarCelda("D36");
                documento.actualizarValorCelda(_total_500_euros);
                documento.seleccionarCelda("D37");
                documento.actualizarValorCelda(_total_200_euros);
                documento.seleccionarCelda("D38");
                documento.actualizarValorCelda(_total_100_euros);
                documento.seleccionarCelda("D39");
                documento.actualizarValorCelda(_total_50_euros);
                documento.seleccionarCelda("D41");
                documento.actualizarValorCelda(_total_20_euros);
                documento.seleccionarCelda("D42");
                documento.actualizarValorCelda(_total_10_euros);
                documento.seleccionarCelda("D43");
                documento.actualizarValorCelda(_total_5_euros);

                //Cola y Mutilados
                documento.seleccionarCelda("D45");
                documento.actualizarValorCelda(_total_cola_euros);
                documento.seleccionarCelda("D46");
                documento.actualizarValorCelda(_total_mutilado_euros);


                //////////////////////////////////////////////////////////////////////////RUBROS//////////////////////////////////////////////////////////////////////////////////////////

                //Entregas Colones

                documento.seleccionarCelda("G6");
                documento.actualizarValorCelda(_sucursales_entregas_colones);
                documento.seleccionarCelda("G7");
                documento.actualizarValorCelda(_cef1_entregas_colones);
                documento.seleccionarCelda("G8");
                documento.actualizarValorCelda(_cef2_entregas_colones);
                documento.seleccionarCelda("G9");
                documento.actualizarValorCelda(_cef3_entregas_colones);
                documento.seleccionarCelda("G10");
                documento.actualizarValorCelda(_cef4_entregas_colones);
                documento.seleccionarCelda("G11");
                documento.actualizarValorCelda(_cef5_entregas_colones);
                documento.seleccionarCelda("G12");
                documento.actualizarValorCelda(_bancos1_entregas_colones);
                documento.seleccionarCelda("G13");
                documento.actualizarValorCelda(_bancos2_entregas_colones);
                documento.seleccionarCelda("G14");
                documento.actualizarValorCelda(_bancos3_entregas_colones);
                documento.seleccionarCelda("G15");
                documento.actualizarValorCelda(_bancos4_entregas_colones);
                documento.seleccionarCelda("G16");
                documento.actualizarValorCelda(_bancos5_entregas_colones);
                documento.seleccionarCelda("G17");
                documento.actualizarValorCelda(_bancos6_entregas_colones);
                documento.seleccionarCelda("G18");
                documento.actualizarValorCelda(_bancos7_entregas_colones);
                documento.seleccionarCelda("G19");
                documento.actualizarValorCelda(_bancos8_entregas_colones);
                documento.seleccionarCelda("G21");
                documento.actualizarValorCelda(_pedido_boveda_entregas_colones);
                documento.seleccionarCelda("G22");
                documento.actualizarValorCelda(_pedido_varios_entregas_colones);
                documento.seleccionarCelda("G23");
                documento.actualizarValorCelda(_cambio_denominacion_entregas_colones);
                documento.seleccionarCelda("G24");
                documento.actualizarValorCelda(_cambio_denominacion_entregas_colones1);
                documento.seleccionarCelda("G25");
                documento.actualizarValorCelda(_cambio_denominacion_entregas_colones2);
                documento.seleccionarCelda("G26");
                documento.actualizarValorCelda(_cola_cef_entregas_colones);




                //Pedidos Colones

                documento.seleccionarCelda("J6");
                documento.actualizarValorCelda(_sucursales_pedidos_colones);
                documento.seleccionarCelda("J7");
                documento.actualizarValorCelda(_cambiodenominacion_pedidos_colones);
                documento.seleccionarCelda("J8");
                documento.actualizarValorCelda(_cambiodenominacion_pedidos_colones1);
                documento.seleccionarCelda("J9");
                documento.actualizarValorCelda(_cambiodenominacion_pedidos_colones2);
                documento.seleccionarCelda("J10");
                documento.actualizarValorCelda(_faltanteGeneral_pedidos_colones);
                documento.seleccionarCelda("J11");
                documento.actualizarValorCelda(_faltanteCEF_pedidos_colones);
                documento.seleccionarCelda("J12");
                documento.actualizarValorCelda(_pedidosvarios_pedidos_colones);
                documento.seleccionarCelda("J13");
                documento.actualizarValorCelda(_pedidosClientes_pedidos_colones);


                //Entregas Dolares

                documento.seleccionarCelda("M6");
                documento.actualizarValorCelda(_sucursales_entregas_dolares);
                documento.seleccionarCelda("M7");
                documento.actualizarValorCelda(_cef1_entregas_dolares);
                documento.seleccionarCelda("M8");
                documento.actualizarValorCelda(_cef2_entregas_dolares);
                documento.seleccionarCelda("M9");
                documento.actualizarValorCelda(_cef3_entregas_dolares);
                documento.seleccionarCelda("M10");
                documento.actualizarValorCelda(_cef4_entregas_dolares);
                documento.seleccionarCelda("M11");
                documento.actualizarValorCelda(_cef5_entregas_dolares);
                documento.seleccionarCelda("M12");
                documento.actualizarValorCelda(_bancos1_entregas_dolares);
                documento.seleccionarCelda("M13");
                documento.actualizarValorCelda(_bancos2_entregas_dolares);
                documento.seleccionarCelda("M14");
                documento.actualizarValorCelda(_bancos3_entregas_dolares);
                documento.seleccionarCelda("M15");
                documento.actualizarValorCelda(_bancos4_entregas_dolares);
                documento.seleccionarCelda("M16");
                documento.actualizarValorCelda(_bancos5_entregas_dolares);
                documento.seleccionarCelda("M17");
                documento.actualizarValorCelda(_bancos6_entregas_dolares);
                documento.seleccionarCelda("M18");
                documento.actualizarValorCelda(_bancos7_entregas_dolares);
                documento.seleccionarCelda("M19");
                documento.actualizarValorCelda(_bancos8_entregas_dolares);
                documento.seleccionarCelda("M21");
                documento.actualizarValorCelda(_pedido_boveda_entregas_dolares);
                documento.seleccionarCelda("M22");
                documento.actualizarValorCelda(_pedido_varios_entregas_dolares);
                documento.seleccionarCelda("M23");
                documento.actualizarValorCelda(_cambio_denominacion_entregas_dolares);
                documento.seleccionarCelda("M24");
                documento.actualizarValorCelda(_cambio_denominacion_entregas_dolares1);
                documento.seleccionarCelda("M25");
                documento.actualizarValorCelda(_cambio_denominacion_entregas_dolares2);
                documento.seleccionarCelda("M26");
                documento.actualizarValorCelda(_cola_cef_entregas_dolares);



                //Pedidos Dolares

                documento.seleccionarCelda("P6");
                documento.actualizarValorCelda(_sucursales_pedidos_dolares);
                documento.seleccionarCelda("P7");
                documento.actualizarValorCelda(_cambiodenominacion_pedidos_dolares);
                documento.seleccionarCelda("P8");
                documento.actualizarValorCelda(_cambiodenominacion_pedidos_dolares1);
                documento.seleccionarCelda("P9");
                documento.actualizarValorCelda(_cambiodenominacion_pedidos_dolares2);
                documento.seleccionarCelda("P10");
                documento.actualizarValorCelda(_faltanteGeneral_pedidos_dolares);
                documento.seleccionarCelda("P11");
                documento.actualizarValorCelda(_faltanteCEF_pedidos_dolares);
                documento.seleccionarCelda("P12");
                documento.actualizarValorCelda(_pedidosvarios_pedidos_dolares);
                documento.seleccionarCelda("P13");
                documento.actualizarValorCelda(_pedidosClientes_pedidos_dolares);





                //Entregas Euros

                documento.seleccionarCelda("S6");
                documento.actualizarValorCelda(_sucursales_entregas_euros);
                documento.seleccionarCelda("S7");
                documento.actualizarValorCelda(_cef1_entregas_euros);
                documento.seleccionarCelda("S8");
                documento.actualizarValorCelda(_cef2_entregas_euros);
                documento.seleccionarCelda("S9");
                documento.actualizarValorCelda(_cef3_entregas_euros);
                documento.seleccionarCelda("S10");
                documento.actualizarValorCelda(_cef4_entregas_euros);
                documento.seleccionarCelda("S11");
                documento.actualizarValorCelda(_cef5_entregas_euros);
                documento.seleccionarCelda("S12");
                documento.actualizarValorCelda(_bancos1_entregas_euros);
                documento.seleccionarCelda("S13");
                documento.actualizarValorCelda(_bancos2_entregas_euros);
                documento.seleccionarCelda("S14");
                documento.actualizarValorCelda(_bancos3_entregas_euros);
                documento.seleccionarCelda("S15");
                documento.actualizarValorCelda(_bancos4_entregas_euros);
                documento.seleccionarCelda("S16");
                documento.actualizarValorCelda(_bancos5_entregas_euros);
                documento.seleccionarCelda("S17");
                documento.actualizarValorCelda(_bancos6_entregas_euros);
                documento.seleccionarCelda("S18");
                documento.actualizarValorCelda(_bancos7_entregas_euros);
                documento.seleccionarCelda("S19");
                documento.actualizarValorCelda(_bancos8_entregas_euros);
                documento.seleccionarCelda("S21");
                documento.actualizarValorCelda(_pedido_boveda_entregas_euros);
                documento.seleccionarCelda("S22");
                documento.actualizarValorCelda(_pedido_varios_entregas_euros);
                documento.seleccionarCelda("S23");
                documento.actualizarValorCelda(_cambio_denominacion_entregas_euros);
                documento.seleccionarCelda("S24");
                documento.actualizarValorCelda(_cambio_denominacion_entregas_euros1);
                documento.seleccionarCelda("S25");
                documento.actualizarValorCelda(_cambio_denominacion_entregas_euros2);
                documento.seleccionarCelda("S26");
                documento.actualizarValorCelda(_cola_cef_entregas_euros);



                //Pedidos Euros

                documento.seleccionarCelda("V6");
                documento.actualizarValorCelda(_sucursales_pedidos_euros);
                documento.seleccionarCelda("V7");
                documento.actualizarValorCelda(_cambiodenominacion_pedidos_euros);
                documento.seleccionarCelda("V8");
                documento.actualizarValorCelda(_cambiodenominacion_pedidos_euros1);
                documento.seleccionarCelda("V9");
                documento.actualizarValorCelda(_cambiodenominacion_pedidos_euros2);
                documento.seleccionarCelda("V10");
                documento.actualizarValorCelda(_faltanteGeneral_pedidos_euros);
                documento.seleccionarCelda("V11");
                documento.actualizarValorCelda(_faltanteCEF_pedidos_euros);
                documento.seleccionarCelda("V12");
                documento.actualizarValorCelda(_pedidosvarios_pedidos_euros);
                documento.seleccionarCelda("V13");
                documento.actualizarValorCelda(_pedidosClientes_pedidos_euros);


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
        /// Calculas los montos por denominación de las entregas
        /// </summary>
        private void calcularMontosEntregas()
        {
            foreach (LibroMayor l in _lista_entrega)
            {
                _total_50000_colones = _total_50000_colones + l.Monto50000Colones;
                _total_20000_colones = _total_20000_colones + l.Monto20000Colones;
                _total_10000_colones = _total_10000_colones + l.Monto10000Colones;
                _total_5000_colones = _total_5000_colones + l.Monto5000Colones;
                _total_2000_colones = _total_2000_colones + l.Monto2000Colones;
                _total_1000_colones = _total_1000_colones + l.Monto1000Colones;
                _total_500_colones = _total_500_colones + l.Monto500Colones;
                _total_100_colones = _total_100_colones + l.Monto100Colones;
                _total_50_colones = _total_50_colones + l.Monto50Colones;
                _total_25_colones = _total_25_colones + l.Monto25Colones;
                _total_10_colones = _total_10_colones + l.Monto10Colones;
                _total_5_colones = _total_5_colones + l.Monto5Colones;
                _total_cola = _total_cola + l.Cola;
                _total_mutilado = _total_mutilado + l.Mutilado;


                _total_100_dolares = _total_100_dolares + l.Monto100Dolares;
                _total_50_dolares = _total_50_dolares + l.Monto50Dolares;
                _total_20_dolares = _total_20_dolares + l.Monto20Dolares;
                _total_10_dolares = _total_10_dolares + l.Monto10Dolares;
                _total_5_dolares = _total_5_dolares + l.Monto5Dolares;
                _total_1_dolares = _total_1_dolares + l.Monto1Dolares;
                _total_cola_dolares = _total_cola_dolares + l.ColaDolares;
                _total_mutilado_dolares = _total_mutilado_dolares + l.MutiladoDolares;


                _total_500_euros = _total_500_euros + l.Monto500Euros;
                _total_200_euros = _total_200_euros + l.Monto200Euros;
                _total_100_euros = _total_100_euros + l.Monto100Euros;
                _total_50_euros = _total_50_euros + l.Monto50Euros;
                _total_20_euros = _total_20_euros + l.Monto20Euros;
                _total_10_euros = _total_10_euros + l.Monto10Euros;
                _total_5_euros = _total_5_euros + l.Monto5Euros;
                _total_cola_euros = _total_cola_euros + l.ColaEuros;
                _total_mutilado_euros= _total_mutilado_euros + l.MutiladoEuros;


            }



            foreach (LibroMayor l in _lista_pedidos)
            {
                _total_50000_colones_pedidos = _total_50000_colones_pedidos + l.Monto50000Colones;
                _total_20000_colones_pedidos = _total_20000_colones_pedidos + l.Monto20000Colones;
                _total_10000_colones_pedidos = _total_10000_colones_pedidos + l.Monto10000Colones;
                _total_5000_colones_pedidos = _total_5000_colones_pedidos + l.Monto5000Colones;
                _total_2000_colones_pedidos = _total_2000_colones_pedidos + l.Monto2000Colones;
                _total_1000_colones_pedidos = _total_1000_colones_pedidos + l.Monto1000Colones;
                _total_500_colones_pedidos = _total_500_colones_pedidos + l.Monto500Colones;
                _total_100_colones_pedidos = _total_100_colones_pedidos + l.Monto100Colones;
                _total_50_colones_pedidos = _total_50_colones_pedidos + l.Monto50Colones;
                _total_25_colones_pedidos = _total_25_colones_pedidos + l.Monto25Colones;
                _total_10_colones_pedidos = _total_10_colones_pedidos + l.Monto10Colones;
                _total_5_colones_pedidos = _total_5_colones_pedidos + l.Monto5Colones;
                _total_cola_pedidos = _total_cola_pedidos + l.Cola;
                _total_mutilado_pedidos = _total_mutilado_pedidos + l.Mutilado;


                _total_100_dolares_pedidos = _total_100_dolares_pedidos + l.Monto100Dolares;
                _total_50_dolares_pedidos = _total_50_dolares_pedidos + l.Monto50Dolares;
                _total_20_dolares_pedidos = _total_20_dolares_pedidos + l.Monto20Dolares;
                _total_10_dolares_pedidos = _total_10_dolares_pedidos + l.Monto10Dolares;
                _total_5_dolares_pedidos = _total_5_dolares_pedidos + l.Monto5Dolares;
                _total_1_dolares_pedidos = _total_1_dolares_pedidos + l.Monto1Dolares;
                _total_coladolares_pedidos = _total_coladolares_pedidos + l.ColaDolares;
                _total_mutiladodolares_pedidos = _total_mutiladodolares_pedidos + l.MutiladoDolares;


                _total_500_euros_pedidos = _total_500_euros_pedidos + l.Monto500Euros;
                _total_200_euros_pedidos = _total_200_euros_pedidos + l.Monto200Euros;
                _total_100_euros_pedidos = _total_100_euros_pedidos + l.Monto100Euros;
                _total_50_euros_pedidos = _total_50_euros_pedidos + l.Monto50Euros;
                _total_20_euros_pedidos = _total_20_euros_pedidos + l.Monto20Euros;
                _total_10_euros_pedidos = _total_10_euros_pedidos + l.Monto10Euros;
                _total_5_euros_pedidos = _total_5_euros_pedidos + l.Monto5Euros;
                _total_colaeuros_pedidos = _total_colaeuros_pedidos + l.ColaEuros;
                _total_mutiladoeuros_pedidos = _total_mutiladoeuros_pedidos + l.MutiladoEuros;


            }
        }

        /// <summary>
        /// Calcula el total por rubros
        /// </summary>
        private void calcularRubrosEntregas()
        {
            foreach (LibroMayor l in _lista_entrega)
            {
                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.Sucursales)
                {
                    _sucursales_entregas_colones = _sucursales_entregas_colones + l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _sucursales_entregas_dolares = _sucursales_entregas_dolares + l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _sucursales_entregas_euros = _sucursales_entregas_euros + l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.CEF1)
                {
                    _cef1_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _cef1_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _cef1_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.CEF2)
                {
                    _cef2_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _cef2_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _cef2_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.CEF3)
                {
                    _cef3_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _cef3_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _cef3_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.CEF4)
                {
                    _cef4_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _cef4_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _cef4_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.CEF5)
                {
                    _cef5_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _cef5_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _cef5_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.BANCO1)
                {
                    _bancos1_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _bancos1_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _bancos1_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.BANCO2)
                {
                    _bancos2_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _bancos2_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _bancos2_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.BANCO3)
                {
                    _bancos3_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _bancos3_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _bancos3_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.BANCO4)
                {
                    _bancos4_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _bancos4_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _bancos4_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.BANCO5)
                {
                    _bancos5_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _bancos5_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _bancos5_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.BANCO6)
                {
                    _bancos6_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _bancos6_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _bancos6_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.BANCO7)
                {
                    _bancos7_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _bancos7_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _bancos7_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.BANCO8)
                {
                    _bancos8_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _bancos8_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _bancos8_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.Pedido_Boveda)
                {
                    _pedido_boveda_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _pedido_boveda_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _pedido_boveda_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.Pedidos_Varios)
                {
                    _pedido_varios_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _pedido_varios_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _pedido_varios_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.Cambio_Denominacion1)
                {
                    _cambio_denominacion_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _cambio_denominacion_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _cambio_denominacion_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.Cambio_Denominacion2)
                {
                    _cambio_denominacion_entregas_colones1 = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _cambio_denominacion_entregas_dolares1 = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _cambio_denominacion_entregas_euros1 = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }



                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.Cambio_Denominacion3)
                {
                    _cambio_denominacion_entregas_colones2 = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _cambio_denominacion_entregas_dolares2 = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _cambio_denominacion_entregas_euros2 = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.ColaCEF)
                {
                    _cola_cef_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _cola_cef_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _cola_cef_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
            }
        }

        /// <summary>
        /// Calcular el total por rubros en pedidos. 
        /// </summary>
        private void calcularRubrosPedidos()
        {
            foreach (LibroMayor l in _lista_pedidos)
            {
                if (l.TipoLibroPedido == TipoClaseLibroMayorPedidos.Sucursales)
                {
                    _sucursales_pedidos_colones = _sucursales_pedidos_colones + l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _sucursales_pedidos_dolares = _sucursales_pedidos_dolares + l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _sucursales_pedidos_euros = _sucursales_pedidos_euros + l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
                if (l.TipoLibroPedido == TipoClaseLibroMayorPedidos.Cambio_Denominacion)
                {
                    _cambiodenominacion_pedidos_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _cambiodenominacion_pedidos_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _cambiodenominacion_pedidos_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
                if (l.TipoLibroPedido == TipoClaseLibroMayorPedidos.cambio_denominacion1)
                {
                    _cambiodenominacion_pedidos_colones1 = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _cambiodenominacion_pedidos_dolares1 = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _cambiodenominacion_pedidos_euros1 = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
                if (l.TipoLibroPedido == TipoClaseLibroMayorPedidos.cambio_denominacion2)
                {
                    _cambiodenominacion_pedidos_colones2 = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _cambiodenominacion_pedidos_dolares2 = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _cambiodenominacion_pedidos_euros2 = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
                if (l.TipoLibroPedido == TipoClaseLibroMayorPedidos.FaltanteGeneral)
                {
                    _faltanteGeneral_pedidos_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _faltanteGeneral_pedidos_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _faltanteGeneral_pedidos_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroPedido == TipoClaseLibroMayorPedidos.FaltanteCEF)
                {
                    _faltanteCEF_pedidos_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _faltanteCEF_pedidos_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _faltanteCEF_pedidos_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroPedido == TipoClaseLibroMayorPedidos.PedidosVarios)
                {
                    _pedidosvarios_pedidos_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _pedidosvarios_pedidos_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _pedidosvarios_pedidos_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroPedido == TipoClaseLibroMayorPedidos.PedidosClientes)
                {
                    _pedidosClientes_pedidos_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _pedidosClientes_pedidos_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _pedidosClientes_pedidos_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
            }
        }

        #endregion Métodos Privados
    }
}
