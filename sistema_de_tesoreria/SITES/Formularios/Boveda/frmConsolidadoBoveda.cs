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

namespace GUILayer.Formularios.Boveda
{
    public partial class frmConsolidadoBoveda : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private LibroMayor _libro_mayor_pedidos = new LibroMayor();
        private LibroMayor _libro_mayor_entrega = new LibroMayor();
        private SaldoLibroBoveda _saldo_entregas = new SaldoLibroBoveda();
        private SaldoLibroBoveda _saldo_pedido = new SaldoLibroBoveda();
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
        private decimal _total_cola_colones = 0;
        private decimal _total_mutilado_colones = 0;


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
        private decimal _total_cola_pedidosC = 0;
        private decimal _total_mutilado_pedidosC = 0;


        private decimal _total_100_dolares_pedidos = 0;
        private decimal _total_50_dolares_pedidos = 0;
        private decimal _total_20_dolares_pedidos = 0;
        private decimal _total_10_dolares_pedidos = 0;
        private decimal _total_5_dolares_pedidos = 0;
        private decimal _total_1_dolares_pedidos = 0;
        private decimal _total_cola_pedidosD = 0;
        private decimal _total_mutilado_pedidosD = 0;


        private decimal _total_500_euros_pedidos = 0;
        private decimal _total_200_euros_pedidos = 0;
        private decimal _total_100_euros_pedidos = 0;
        private decimal _total_50_euros_pedidos = 0;
        private decimal _total_20_euros_pedidos = 0;
        private decimal _total_10_euros_pedidos = 0;
        private decimal _total_5_euros_pedidos = 0;
        private decimal _total_cola_pedidosE = 0;
        private decimal _total_mutilado_pedidosE = 0;

        //CAN Entregas
        private decimal _entregasCAN = 0;

        //CAN Pedidos
        private decimal _pedidosCAN = 0;

        /// <summary>
        /// Rubros ///
        /// </summary>


        private decimal _sucursales_entregas_colones = 0;
        private decimal _sucursales_entregas_dolares = 0;
        private decimal _sucursales_entregas_euros = 0;

        private decimal _atm_descargas_entregas_colones = 0;
        private decimal _atm_descargas_entregas_dolares = 0;
        private decimal _atm_descargas_entregas_euros = 0;

        private decimal _atm_full_colones = 0;
        private decimal _atm_full_dolares = 0;
        private decimal _atm_full_euros = 0;

        private decimal _bna_proval_entregas_colones = 0;
        private decimal _bna_proval_entregas_dolares = 0;
        private decimal _bna_proval_entregas_euros = 0;

        private decimal _proval_kfc_entregas_colones = 0;
        private decimal _proval_kfc_entregas_dolares = 0;
        private decimal _proval_kfc_entregas_euros = 0;

        private decimal _proval_ampm_entregas_colones = 0;
        private decimal _proval_ampm_entregas_dolares = 0;
        private decimal _proval_ampm_entregas_euros = 0;

        private decimal _cef_grande_entregas_colones = 0;
        private decimal _cef_grande_entregas_dolares = 0;
        private decimal _cef_grande_entregas_euros = 0;

        private decimal _cambio_denominacion_entregas_colones = 0;
        private decimal _cambio_denominacion_entregas_dolares = 0;
        private decimal _cambio_denominacion_entregas_euros = 0;

        private decimal _diferencias_entregas_colones = 0;
        private decimal _diferencias_entregas_dolares = 0;
        private decimal _diferencias_entregas_euros = 0;

        private decimal _cef_peq_entregas_colones = 0;
        private decimal _cef_peq_entregas_dolares = 0;
        private decimal _cef_peq_entregas_euros = 0;

        private decimal _bps_entregas_colones = 0;
        private decimal _bps_entregas_dolares = 0;
        private decimal _bps_entregas_euros = 0;

        private decimal _bps_validacion_entregas_colones = 0;
        private decimal _bps_validacion_entregas_dolares = 0;
        private decimal _bps_validacion_entregas_euros = 0;

        private decimal _entrega_niquel_entregas_colones = 0;
        private decimal _entrega_niquel_entregas_dolares = 0;
        private decimal _entrega_niquel_entregas_euros = 0;

        private decimal _can_entregas_colones = 0;
        private decimal _can_entregas_dolares = 0;
        private decimal _can_entregas_euros = 0;

        private decimal _bancos_entregas_colones = 0;
        private decimal _bancos_entregas_dolares = 0;
        private decimal _bancos_entregas_euros = 0;


        /// <summary>
        /// ////////////////////////////////////////// PEDIDOS /////////////////////////////////////////////////////
        /// </summary>

        private decimal _sucursales_pedidos_colones = 0;
        private decimal _sucursales_pedidos_dolares = 0;
        private decimal _sucursales_pedidos_euros = 0;

        private decimal _cambio_denominacion_pedidos_colones1 = 0;
        private decimal _cambio_denominacion_pedidos_dolares1 = 0;
        private decimal _cambio_denominacion_pedidos_euros1 = 0;

        private decimal _cambio_denominacion_pedidos_colones2 = 0;
        private decimal _cambio_denominacion_pedidos_dolares2 = 0;
        private decimal _cambio_denominacion_pedidos_euros2 = 0;

        private decimal _cambio_denominacion_pedidos_colones3 = 0;
        private decimal _cambio_denominacion_pedidos_dolares3 = 0;
        private decimal _cambio_denominacion_pedidos_euros3 = 0;

        private decimal _faltante_general_pedidos_colones = 0;
        private decimal _faltante_general_pedidos_dolares = 0;
        private decimal _faltante_general_pedidos_euros = 0;

        private decimal _faltante_cef_pedidos_colones = 0;
        private decimal _faltante_cef_pedidos_dolares = 0;
        private decimal _faltante_cef_pedidos_euros = 0;

        private decimal _pedidos_varios_pedidos_colones = 0;
        private decimal _pedidos_varios_pedidos_dolares = 0;
        private decimal _pedidos_varios_pedidos_euros = 0;     

        private decimal _pedidos_clientes_pedidos_colones = 0;
        private decimal _pedidos_clientes_pedidos_dolares = 0;
        private decimal _pedidos_clientes_pedidos_euros = 0;

        private Colaborador _usuario = null; 
        #endregion Atributos

        #region Constructor

        public frmConsolidadoBoveda(Colaborador usuario)
        {
            _usuario = usuario; 
            InitializeComponent();
        }


        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botó exportar
        /// </summary>
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value;
            _lista_entrega = _coordinacion.listarLibroMayor(fecha);
            _lista_pedidos = _coordinacion.listarLibroMayorPedido(fecha);
            _saldo_entregas = _coordinacion.listarSaldosBoveda(fecha);

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
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla libro boveda.xlt", true);

                documento.seleccionarHoja(1);

                // Escribir los datos
                //Colones 
                documento.seleccionarCelda("A2");
                documento.actualizarValorCelda(fecha);

                documento.seleccionarCelda("B5");
                documento.actualizarValorCelda(_saldo_entregas.MontoColones);

                documento.seleccionarCelda("C5");
                documento.actualizarValorCelda(_saldo_entregas.MontoDolares);

                documento.seleccionarCelda("D5");
                documento.actualizarValorCelda(_saldo_entregas.MontoEuros);

                documento.seleccionarCelda("D53");
                documento.actualizarValorCelda(_saldo_entregas.CustodiaAuxiliar);

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
                documento.actualizarValorCelda(_total_cola_pedidosC);
                documento.seleccionarCelda("B25");
                documento.actualizarValorCelda(_total_mutilado_pedidosC);



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
                documento.actualizarValorCelda(_total_cola_pedidosD);
                documento.seleccionarCelda("C25");
                documento.actualizarValorCelda(_total_mutilado_pedidosD);


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
                documento.actualizarValorCelda(_total_cola_pedidosE);
                documento.seleccionarCelda("D25");
                documento.actualizarValorCelda(_total_mutilado_pedidosE);

            

                ////////////////////////////////////////////////////////////ENTREGAS//////////////////////////////////////////////////////////////


                // Escribir los datos
                //Colones 
                documento.seleccionarCelda("B31");
                documento.actualizarValorCelda(_total_50000_colones);
                documento.seleccionarCelda("B32");
                documento.actualizarValorCelda(_total_20000_colones);
                documento.seleccionarCelda("B33");
                documento.actualizarValorCelda(_total_10000_colones);
                documento.seleccionarCelda("B34");
                documento.actualizarValorCelda(_total_5000_colones);
                documento.seleccionarCelda("B35");
                documento.actualizarValorCelda(_total_2000_colones);
                documento.seleccionarCelda("B36");
                documento.actualizarValorCelda(_total_1000_colones);
                documento.seleccionarCelda("B37");
                documento.actualizarValorCelda(_total_500_colones);
                documento.seleccionarCelda("B39");
                documento.actualizarValorCelda(_total_100_colones);
                documento.seleccionarCelda("B40");
                documento.actualizarValorCelda(_total_50_colones);
                documento.seleccionarCelda("B41");
                documento.actualizarValorCelda(_total_25_colones);
                documento.seleccionarCelda("B43");
                documento.actualizarValorCelda(_total_10_colones);
                documento.seleccionarCelda("B44");
                documento.actualizarValorCelda(_total_5_colones);

                //Cola y Mutilados
                documento.seleccionarCelda("B46");
                documento.actualizarValorCelda(_total_cola_colones);
                documento.seleccionarCelda("B47");
                documento.actualizarValorCelda(_total_mutilado_colones);



                //Dólares
                documento.seleccionarCelda("C39");
                documento.actualizarValorCelda(_total_100_dolares);
                documento.seleccionarCelda("C40");
                documento.actualizarValorCelda(_total_50_dolares);
                documento.seleccionarCelda("C42");
                documento.actualizarValorCelda(_total_20_dolares);
                documento.seleccionarCelda("C43");
                documento.actualizarValorCelda(_total_10_dolares);
                documento.seleccionarCelda("C44");
                documento.actualizarValorCelda(_total_5_dolares);
                documento.seleccionarCelda("C45");
                documento.actualizarValorCelda(_total_1_dolares);

                //Cola y Mutilado
                documento.seleccionarCelda("C46");
                documento.actualizarValorCelda(_total_cola_dolares);
                documento.seleccionarCelda("C47");
                documento.actualizarValorCelda(_total_mutilado_dolares);


                //Euros
                documento.seleccionarCelda("D37");
                documento.actualizarValorCelda(_total_500_euros);
                documento.seleccionarCelda("D38");
                documento.actualizarValorCelda(_total_200_euros);
                documento.seleccionarCelda("D39");
                documento.actualizarValorCelda(_total_100_euros);
                documento.seleccionarCelda("D40");
                documento.actualizarValorCelda(_total_50_euros);
                documento.seleccionarCelda("D42");
                documento.actualizarValorCelda(_total_20_euros);
                documento.seleccionarCelda("D43");
                documento.actualizarValorCelda(_total_10_euros);
                documento.seleccionarCelda("D44");
                documento.actualizarValorCelda(_total_5_euros);

                //Cola y Mutilados
                documento.seleccionarCelda("D46");
                documento.actualizarValorCelda(_total_cola_euros);
                documento.seleccionarCelda("D47");
                documento.actualizarValorCelda(_total_mutilado_euros);


                //////////////////////////////////////////////////////////////////////////RUBROS//////////////////////////////////////////////////////////////////////////////////////////

                //Entregas Colones

                documento.seleccionarCelda("G6");
                documento.actualizarValorCelda(_sucursales_entregas_colones);
                documento.seleccionarCelda("G7");
                documento.actualizarValorCelda(_atm_descargas_entregas_colones);
                documento.seleccionarCelda("G8");
                documento.actualizarValorCelda(_bna_proval_entregas_colones);
                documento.seleccionarCelda("G9");
                documento.actualizarValorCelda(_cef_grande_entregas_colones);
                documento.seleccionarCelda("G10");
                documento.actualizarValorCelda(_cambio_denominacion_entregas_colones);
                documento.seleccionarCelda("G11");
                documento.actualizarValorCelda(_diferencias_entregas_colones);
                documento.seleccionarCelda("G12");
                documento.actualizarValorCelda(_bps_entregas_colones);
                documento.seleccionarCelda("G13");
                documento.actualizarValorCelda(_bps_validacion_entregas_colones);
                documento.seleccionarCelda("G14");
                documento.actualizarValorCelda(_entrega_niquel_entregas_colones);
                documento.seleccionarCelda("G15");
                documento.actualizarValorCelda(_bancos_entregas_colones);
                documento.seleccionarCelda("G16");
                documento.actualizarValorCelda(_can_entregas_colones);


                //Pedidos Colones

                documento.seleccionarCelda("J6");
                documento.actualizarValorCelda(_sucursales_pedidos_colones);
                documento.seleccionarCelda("J7");
                documento.actualizarValorCelda(_cambio_denominacion_pedidos_colones1);
                documento.seleccionarCelda("J8");
                documento.actualizarValorCelda(_cambio_denominacion_pedidos_colones2);
                documento.seleccionarCelda("J9");
                documento.actualizarValorCelda(_cambio_denominacion_pedidos_colones3);
                documento.seleccionarCelda("J10");
                documento.actualizarValorCelda(_faltante_general_pedidos_colones);
                documento.seleccionarCelda("J11");
                documento.actualizarValorCelda(_faltante_cef_pedidos_colones);
                documento.seleccionarCelda("J12");
                documento.actualizarValorCelda(_pedidos_varios_pedidos_colones);
                documento.seleccionarCelda("J13");
                documento.actualizarValorCelda(_pedidos_clientes_pedidos_colones);


                //Entregas Dolares

                documento.seleccionarCelda("M6");
                documento.actualizarValorCelda(_sucursales_entregas_dolares);
                documento.seleccionarCelda("M7");
                documento.actualizarValorCelda(_atm_descargas_entregas_dolares);
                documento.seleccionarCelda("M8");
                documento.actualizarValorCelda(_bna_proval_entregas_dolares);
                documento.seleccionarCelda("M9");
                documento.actualizarValorCelda(_cef_grande_entregas_dolares);
                documento.seleccionarCelda("M10");
                documento.actualizarValorCelda(_cambio_denominacion_entregas_dolares);
                documento.seleccionarCelda("M11");
                documento.actualizarValorCelda(_diferencias_entregas_dolares);
                documento.seleccionarCelda("M12");
                documento.actualizarValorCelda(_bps_entregas_dolares);
                documento.seleccionarCelda("M13");
                documento.actualizarValorCelda(_bps_validacion_entregas_dolares);
                documento.seleccionarCelda("M14");
                documento.actualizarValorCelda(_entrega_niquel_entregas_dolares);
                documento.seleccionarCelda("M15");
                documento.actualizarValorCelda(_bancos_entregas_dolares);
                documento.seleccionarCelda("M16");
                documento.actualizarValorCelda(_can_entregas_dolares);




                //Pedidos Dolares

                documento.seleccionarCelda("P6");
                documento.actualizarValorCelda(_sucursales_pedidos_dolares);
                documento.seleccionarCelda("P7");
                documento.actualizarValorCelda(_cambio_denominacion_pedidos_dolares1);
                documento.seleccionarCelda("P8");
                documento.actualizarValorCelda(_cambio_denominacion_pedidos_dolares2);
                documento.seleccionarCelda("P9");
                documento.actualizarValorCelda(_cambio_denominacion_pedidos_dolares3);
                documento.seleccionarCelda("P10");
                documento.actualizarValorCelda(_faltante_general_pedidos_dolares);
                documento.seleccionarCelda("P11");
                documento.actualizarValorCelda(_faltante_cef_pedidos_dolares);
                documento.seleccionarCelda("P12");
                documento.actualizarValorCelda(_pedidos_varios_pedidos_dolares);
                documento.seleccionarCelda("P13");
                documento.actualizarValorCelda(_pedidos_clientes_pedidos_dolares);





                //Entregas Euros

                documento.seleccionarCelda("S6");
                documento.actualizarValorCelda(_sucursales_entregas_euros);
                documento.seleccionarCelda("S7");
                documento.actualizarValorCelda(_atm_descargas_entregas_euros);
                documento.seleccionarCelda("S8");
                documento.actualizarValorCelda(_bna_proval_entregas_euros);
                documento.seleccionarCelda("S9");
                documento.actualizarValorCelda(_cef_grande_entregas_euros);
                documento.seleccionarCelda("S10");
                documento.actualizarValorCelda(_cambio_denominacion_entregas_euros);
                documento.seleccionarCelda("S11");
                documento.actualizarValorCelda(_diferencias_entregas_euros);
                documento.seleccionarCelda("S12");
                documento.actualizarValorCelda(_bps_entregas_euros);
                documento.seleccionarCelda("S13");
                documento.actualizarValorCelda(_bps_validacion_entregas_euros);
                documento.seleccionarCelda("S14");
                documento.actualizarValorCelda(_entrega_niquel_entregas_euros);
                documento.seleccionarCelda("S15");
                documento.actualizarValorCelda(_bancos_entregas_euros);
                documento.seleccionarCelda("S16");
                documento.actualizarValorCelda(_can_entregas_euros);


                //Pedidos Euros

                documento.seleccionarCelda("V6");
                documento.actualizarValorCelda(_sucursales_pedidos_euros);
                documento.seleccionarCelda("V7");
                documento.actualizarValorCelda(_cambio_denominacion_pedidos_euros1);
                documento.seleccionarCelda("V8");
                documento.actualizarValorCelda(_cambio_denominacion_pedidos_euros2);
                documento.seleccionarCelda("V9");
                documento.actualizarValorCelda(_cambio_denominacion_pedidos_euros3);
                documento.seleccionarCelda("V10");
                documento.actualizarValorCelda(_faltante_general_pedidos_euros);
                documento.seleccionarCelda("V11");
                documento.actualizarValorCelda(_faltante_cef_pedidos_euros);
                documento.seleccionarCelda("V12");
                documento.actualizarValorCelda(_pedidos_varios_pedidos_euros);
                documento.seleccionarCelda("V13");
                documento.actualizarValorCelda(_pedidos_clientes_pedidos_euros);
                //documento.seleccionarCelda("V14");
                //documento.actualizarValorCelda(_bancos_pedidos_euros);
                //documento.seleccionarCelda("V15");
                //documento.actualizarValorCelda(_can_pedidos_euros);


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
            foreach(LibroMayor l in _lista_entrega)
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
                _total_cola_colones = _total_cola_colones + l.Cola;
                _total_mutilado_colones = _total_mutilado_colones + l.Mutilado;

                _total_100_dolares = _total_100_dolares + l.Monto100Dolares;
                _total_50_dolares = _total_100_dolares + l.Monto100Dolares;
                _total_20_dolares = _total_20_dolares + l.Monto100Dolares;
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
                _total_mutilado_euros = _total_mutilado_euros + l.MutiladoEuros;

                
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
                _total_cola_pedidosC = _total_cola_pedidosC + l.Cola;
                _total_mutilado_pedidosC = _total_mutilado_pedidosC + l.Mutilado;


                _total_100_dolares_pedidos = _total_100_dolares_pedidos + l.Monto100Dolares;
                _total_50_dolares_pedidos = _total_50_dolares_pedidos + l.Monto50Dolares;
                _total_20_dolares_pedidos = _total_20_dolares_pedidos + l.Monto20Dolares;
                _total_10_dolares_pedidos = _total_10_dolares_pedidos + l.Monto10Dolares;
                _total_5_dolares_pedidos = _total_5_dolares_pedidos + l.Monto5Dolares;
                _total_1_dolares_pedidos = _total_1_dolares_pedidos + l.Monto1Dolares;
                _total_cola_pedidosD = _total_cola_pedidosD + l.ColaDolares;
                _total_mutilado_pedidosD = _total_mutilado_pedidosD + l.MutiladoDolares;


                _total_500_euros_pedidos = _total_500_euros_pedidos + l.Monto500Euros;
                _total_200_euros_pedidos = _total_200_euros_pedidos + l.Monto200Euros;
                _total_100_euros_pedidos = _total_100_euros_pedidos + l.Monto100Euros;
                _total_50_euros_pedidos = _total_50_euros_pedidos + l.Monto50Euros;
                _total_20_euros_pedidos = _total_20_euros_pedidos + l.Monto20Euros;
                _total_10_euros_pedidos = _total_10_euros_pedidos + l.Monto10Euros;
                _total_5_euros_pedidos = _total_5_euros_pedidos + l.Monto5Euros;
                _total_cola_pedidosE = _total_cola_pedidosE + l.ColaEuros;
                _total_mutilado_pedidosE = _total_mutilado_pedidosE + l.MutiladoEuros;
                                
            }
        }

        /// <summary>
        /// Calcula el total por rubros
        /// </summary>
        private void calcularRubrosEntregas()
        {
            foreach(LibroMayor l in _lista_entrega)
            {
                if(l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.Sucursales || l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.SucursalesManual)
                {
                    _sucursales_entregas_colones = _sucursales_entregas_colones + l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _sucursales_entregas_dolares = _sucursales_entregas_dolares + l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _sucursales_entregas_euros = _sucursales_entregas_euros + l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.ATM_Descargas)
                {
                    _atm_descargas_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _atm_descargas_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _atm_descargas_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
               
                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.BNA_Proval)
                {
                    _bna_proval_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _bna_proval_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _bna_proval_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
                              
                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.Entregas_CEF)
                {
                    _cef_grande_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _cef_grande_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _cef_grande_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.Cambio_Denominacion)
                {
                    _cambio_denominacion_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _cambio_denominacion_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _cambio_denominacion_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.Diferencias)
                {
                    _diferencias_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _diferencias_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _diferencias_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
                
                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.BPS)
                {
                    _bps_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _bps_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _bps_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.BPS_Validacion)
                {
                    _bps_validacion_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _bps_validacion_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _bps_validacion_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.Entrega_Niquel)
                {
                    _entrega_niquel_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _entrega_niquel_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _entrega_niquel_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.Bancos)
                {
                    _bancos_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _bancos_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _bancos_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.CAN)
                {
                    _can_entregas_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _can_entregas_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _can_entregas_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
            }
        }

        /// <summary>
        /// Calcular el total por rubros en pedidos. 
        /// </summary>
        private void calcularRubrosPedidos()
        {
            foreach(LibroMayor l in _lista_pedidos)
            {
                if (l.TipoLibroPedido == TipoClaseLibroMayorPedidos.Sucursales || l.TipoLibroPedido == TipoClaseLibroMayorPedidos.SucursalesManual)
                {
                    _sucursales_pedidos_colones = _sucursales_pedidos_colones + l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _sucursales_pedidos_dolares = _sucursales_pedidos_dolares + l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _sucursales_pedidos_euros = _sucursales_pedidos_euros + l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroPedido == TipoClaseLibroMayorPedidos.Cambio_Denominacion)
                {
                    _cambio_denominacion_pedidos_colones1 = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _cambio_denominacion_pedidos_dolares1 = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _cambio_denominacion_pedidos_euros1 = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroPedido == TipoClaseLibroMayorPedidos.cambio_denominacion1)
                {
                    _cambio_denominacion_pedidos_colones2 = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                       l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _cambio_denominacion_pedidos_dolares2 = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _cambio_denominacion_pedidos_euros2 = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroPedido == TipoClaseLibroMayorPedidos.cambio_denominacion2)
                {
                    _cambio_denominacion_pedidos_colones3 = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                       l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _cambio_denominacion_pedidos_dolares3 = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _cambio_denominacion_pedidos_euros3 = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }


                if (l.TipoLibroPedido == TipoClaseLibroMayorPedidos.FaltanteGeneral)
                {
                    _faltante_general_pedidos_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _faltante_general_pedidos_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _faltante_general_pedidos_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                if (l.TipoLibroPedido == TipoClaseLibroMayorPedidos.FaltanteCEF)
                {
                    _faltante_cef_pedidos_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _faltante_cef_pedidos_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _faltante_cef_pedidos_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
                if (l.TipoLibroPedido == TipoClaseLibroMayorPedidos.PedidosVarios)
                {
                    _pedidos_varios_pedidos_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _pedidos_varios_pedidos_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _pedidos_varios_pedidos_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }

                 if (l.TipoLibroPedido == TipoClaseLibroMayorPedidos.PedidosClientes)
                {
                    _pedidos_clientes_pedidos_colones = l.Monto50000Colones + l.Monto20000Colones + l.Monto10000Colones + l.Monto5000Colones + l.Monto2000Colones + l.Monto1000Colones + l.Monto500Colones +
                        l.Monto100Colones + l.Monto50Colones + l.Monto25Colones + l.Monto10Colones + l.Monto5Colones;

                    _pedidos_clientes_pedidos_dolares = l.Monto100Dolares + l.Monto50Dolares + l.Monto20Dolares + l.Monto10Dolares + l.Monto5Dolares + l.Monto1Dolares;

                    _pedidos_clientes_pedidos_euros = l.Monto500Euros + l.Monto200Euros + l.Monto100Euros + l.Monto50Euros + l.Monto20Euros + l.Monto10Euros + l.Monto5Euros;
                }
            }
        }

        #endregion Métodos Privados
    }
}
