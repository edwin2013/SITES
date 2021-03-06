﻿using BussinessLayer;
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
    public partial class frmLibroMayorBoveda : Form
    {
        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private LibroMayor _libro_mayor = null;
        private Colaborador _usuario = null;
        
       BindingList<LibroMayor> _libros = new BindingList<LibroMayor>();
       BindingList<LibroMayor> _librosBase = new BindingList<LibroMayor>();   

            LibroMayor _sucursales = new LibroMayor(codigo:"Sucursales", tipoentrega: TipoClaseLibroMayorEntregas.Sucursales);
            LibroMayor _sucursalesmanual = new LibroMayor(codigo: "Sucursales Manual", tipoentrega: TipoClaseLibroMayorEntregas.SucursalesManual);

        LibroMayor _atm_descargas = new LibroMayor(codigo:"ATM Descargas", tipoentrega: TipoClaseLibroMayorEntregas.ATM_Descargas);
            LibroMayor _bna_proval = new LibroMayor(codigo:"BNA Proval", tipoentrega: TipoClaseLibroMayorEntregas.BNA_Proval);
            LibroMayor _entregas_cef = new LibroMayor(codigo:"Entregas CEF", tipoentrega: TipoClaseLibroMayorEntregas.Entregas_CEF);
            LibroMayor _cambio_denominacion = new LibroMayor(codigo: "Cambio de Denominación", tipoentrega: TipoClaseLibroMayorEntregas.Cambio_Denominacion);
            LibroMayor _diferencias = new LibroMayor(codigo: "Diferencias", tipoentrega: TipoClaseLibroMayorEntregas.Diferencias);
            LibroMayor _bps = new LibroMayor(codigo: "BPS", tipoentrega: TipoClaseLibroMayorEntregas.BPS);
            LibroMayor _bps_validacion = new LibroMayor(codigo: "BPS Validación", tipoentrega: TipoClaseLibroMayorEntregas.BPS_Validacion);
            LibroMayor _entrega_niquel = new LibroMayor(codigo: "Entrega Níquel", tipoentrega: TipoClaseLibroMayorEntregas.Entrega_Niquel);
            LibroMayor _bancos = new LibroMayor(codigo: "Bancos", tipoentrega: TipoClaseLibroMayorEntregas.Bancos);
            LibroMayor _can = new LibroMayor(codigo: "CAN", tipoentrega: TipoClaseLibroMayorEntregas.CAN);
            LibroMayor _total = new LibroMayor(codigo: "Total", tipoentrega: TipoClaseLibroMayorEntregas.Total);

            LibroMayor _sucursalesb = new LibroMayor(codigo: "Sucursales", tipoentrega: TipoClaseLibroMayorEntregas.Sucursales);
            LibroMayor _sucursalesmanualb = new LibroMayor(codigo: "Sucursales Manual", tipoentrega: TipoClaseLibroMayorEntregas.SucursalesManual);
            LibroMayor _atm_descargasb = new LibroMayor(codigo: "ATM Descargas", tipoentrega: TipoClaseLibroMayorEntregas.ATM_Descargas);
            LibroMayor _bna_provalb = new LibroMayor(codigo: "BNA Proval", tipoentrega: TipoClaseLibroMayorEntregas.BNA_Proval);
            LibroMayor _entregas_cefb = new LibroMayor(codigo: "Entregas CEF", tipoentrega: TipoClaseLibroMayorEntregas.Entregas_CEF);
            LibroMayor _cambio_denominacionb = new LibroMayor(codigo: "Cambio de Denominación", tipoentrega: TipoClaseLibroMayorEntregas.Cambio_Denominacion);
            LibroMayor _diferenciasb = new LibroMayor(codigo: "Diferencias", tipoentrega: TipoClaseLibroMayorEntregas.Diferencias);
            LibroMayor _bpsb = new LibroMayor(codigo: "BPS", tipoentrega: TipoClaseLibroMayorEntregas.BPS);
            LibroMayor _bps_validacionb = new LibroMayor(codigo: "BPS Validación", tipoentrega: TipoClaseLibroMayorEntregas.BPS_Validacion);
            LibroMayor _entrega_niquelb = new LibroMayor(codigo: "Entrega Níquel", tipoentrega: TipoClaseLibroMayorEntregas.Entrega_Niquel);
            LibroMayor _bancosb = new LibroMayor(codigo: "Bancos", tipoentrega: TipoClaseLibroMayorEntregas.Bancos);
            LibroMayor _canb = new LibroMayor(codigo: "CAN", tipoentrega: TipoClaseLibroMayorEntregas.CAN);
            LibroMayor _totalb = new LibroMayor(codigo: "Total", tipoentrega: TipoClaseLibroMayorEntregas.Total);
          
       
        #endregion Atributos

        #region Constructor

        public frmLibroMayorBoveda()
        {
            InitializeComponent();

        }

        public frmLibroMayorBoveda(Colaborador usuario)
        {
            InitializeComponent();

            _usuario = usuario;

           // int cantidad_cajeros = _coordinacion.cantidadCajerosCEF(dtpFecha.Value);

            dgvEntregasColones.AutoGenerateColumns = false;
            dgvDolaresEntregas.AutoGenerateColumns = false;
            dgvEurosEntregas.AutoGenerateColumns = false;


            _libros.Add(_sucursales);
            _libros.Add(_sucursalesmanual);
            _libros.Add(_atm_descargas);            
            _libros.Add(_bna_proval);            
            _libros.Add(_entregas_cef);
            _libros.Add(_cambio_denominacion);
            _libros.Add(_diferencias);
            _libros.Add(_bps);
            _libros.Add(_bps_validacion);
            _libros.Add(_entrega_niquel);
            _libros.Add(_bancos);
            _libros.Add(_can);
            //_libros.Add(_total);

            // CREACION DE UNA BASE ESTANDAR PARA LAS FILAS DE LA PANTALLA
            _librosBase.Add(_sucursalesb);
            _librosBase.Add(_sucursalesmanualb);
            _librosBase.Add(_atm_descargasb);
            _librosBase.Add(_bna_provalb);
            _librosBase.Add(_entregas_cefb);
            _librosBase.Add(_cambio_denominacionb);
            _librosBase.Add(_diferenciasb);
            _librosBase.Add(_bpsb);
            _librosBase.Add(_bps_validacionb);
            _librosBase.Add(_entrega_niquelb);
            _librosBase.Add(_bancosb);
            _librosBase.Add(_canb);
            //_librosBase.Add(_totalb);

            if (_coordinacion.listarLibroMayor(dtpFecha.Value).Count > 0)
            {
                _libros = _coordinacion.listarLibroMayor(dtpFecha.Value);
            }
            else
            {
                foreach (LibroMayor a in _libros)
                {
                    LibroMayor copia = a;
                    _coordinacion.agregarLibroMayor(ref copia, _usuario, dtpFecha.Value);
                }
                _libros = _coordinacion.listarLibroMayor(dtpFecha.Value);
            }
                

            _libros.Add(SumarTotales(_libros));


            dgvEntregasColones.DataSource = _libros;
            dgvDolaresEntregas.DataSource = _libros;
            dgvEurosEntregas.DataSource = _libros;

   
        }

        #endregion Constructor
        
        #region Eventos

        private void dgvEntregasColones_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _libros.RemoveAt(_libros.Count - 1);
            _libros.Add(SumarTotales(_libros));
            dgvEntregasColones.Refresh();
        }


        /// <summary>
        /// Actualiza los datos del formulario
        /// </summary>
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            BindingList <LibroMayor> libros = _coordinacion.listarLibroMayor(dtpFecha.Value);

            if (libros.Count > 0)
            {
                _libros = libros;
                _libros.Add(SumarTotales(_libros));

                dgvEntregasColones.DataSource = _libros;
                dgvDolaresEntregas.DataSource = _libros;
                dgvEurosEntregas.DataSource = _libros;

            }
            else
            {
                foreach (LibroMayor l in _librosBase)
                {
                    LibroMayor copia = l;
                    _coordinacion.agregarLibroMayor(ref copia, _usuario, dtpFecha.Value);
                }
                //_coordinacion.actualizarLibroMayorBovedaEntrega(dtpFecha.Value);

                _libros = _coordinacion.listarLibroMayor(dtpFecha.Value);

                _libros.Add(SumarTotales(_libros));
                
                dgvEntregasColones.DataSource = _libros;
                dgvDolaresEntregas.DataSource = _libros;
                dgvEurosEntregas.DataSource = _libros;
            }
                
        }


        /// <summary>
        /// Clic en el botón de guardar
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value;

            _libros.RemoveAt(_libros.Count - 1);
            foreach(LibroMayor l in _libros)
            {
                LibroMayor copia = l;
                if (copia.ID > 0)
                    _coordinacion.actualizarLibroMayor(copia);
                else
                    _coordinacion.agregarLibroMayor(ref copia, _usuario, dtpFecha.Value);
            }
            _libros.Add(SumarTotales(_libros));
        }


        /// <summary>
        /// Cambio en el valor de las celdas
        /// </summary>
        private void dgvCargas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            BindingList<LibroMayor> nuevo = _libros;

        }


        /// <summary>
        /// Imprime el formulario del cierre de ATMs
        /// </summary>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.imprimirHojaCarga();
        }


        /// <summary>
        /// Clic en el botón de actualizar datos. 
        /// </summary>
        private void btnActualizarDatos_Click(object sender, EventArgs e)
        {

            _coordinacion.actualizarLibroMayorSITES(dtpFecha.Value);

            BindingList<LibroMayor> libros = _coordinacion.listarLibroMayor(dtpFecha.Value);

            if (libros.Count > 0)
            {
                _libros = libros;
                _libros.Add(SumarTotales(_libros));
                dgvEntregasColones.DataSource = _libros;
                dgvDolaresEntregas.DataSource = _libros;
                dgvEurosEntregas.DataSource = _libros;
            }
        }

        private void dgvDolaresEntregas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _libros.RemoveAt(_libros.Count - 1);
            _libros.Add(SumarTotales(_libros));
            dgvDolaresEntregas.Refresh();
        }

        private void dgvEurosEntregas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _libros.RemoveAt(_libros.Count - 1);
            _libros.Add(SumarTotales(_libros));
            dgvEurosEntregas.Refresh();
        }

        #endregion Eventos

        #region Metodos Privados

        private LibroMayor SumarTotales(BindingList<LibroMayor> Libros)
        {
            LibroMayor b = new LibroMayor();
            b.Codigo = "Total";

            foreach (LibroMayor l in Libros)
            {
                b.Monto50000Colones = b.Monto50000Colones + l.Monto50000Colones;
                b.Monto5000Colones = b.Monto5000Colones + l.Monto5000Colones;
                b.Monto500Colones = b.Monto500Colones + l.Monto500Colones;
                b.Monto50Colones = b.Monto50Colones + l.Monto50Colones;
                b.Monto20000Colones = b.Monto20000Colones + l.Monto20000Colones;
                b.Monto2000Colones = b.Monto2000Colones + l.Monto2000Colones;
                b.Monto25Colones = b.Monto25Colones + l.Monto25Colones;
                b.Monto10000Colones = b.Monto10000Colones + l.Monto10000Colones;
                b.Monto1000Colones = b.Monto1000Colones + l.Monto1000Colones;
                b.Monto100Colones = b.Monto100Colones + l.Monto100Colones;
                b.Monto10Colones = b.Monto10Colones + l.Monto10Colones;

                b.Monto100Dolares = b.Monto100Dolares + l.Monto100Dolares;
                b.Monto50Dolares = b.Monto50Dolares + l.Monto50Dolares;
                b.Monto20Dolares = b.Monto20Dolares + l.Monto20Dolares;
                b.Monto10Dolares = b.Monto10Dolares + l.Monto10Dolares;
                b.Monto5Dolares = b.Monto5Dolares + l.Monto5Dolares; 
                b.Monto2Dolares = b.Monto2Dolares + l.Monto2Dolares;
                b.Monto1Dolares = b.Monto1Dolares + l.Monto1Dolares;

                b.Monto500Euros = b.Monto500Euros + l.Monto500Euros;
                b.Monto200Euros = b.Monto200Euros + l.Monto200Euros;
                b.Monto100Euros = b.Monto100Euros + l.Monto100Euros;
                b.Monto50Euros = b.Monto50Euros + l.Monto50Euros;
                b.Monto20Euros = b.Monto20Euros + l.Monto20Euros;
                b.Monto10Euros = b.Monto10Euros + l.Monto10Euros;
                b.Monto5Euros = b.Monto5Euros + l.Monto5Euros;

            }

            b.TipoLibroEntregas = TipoClaseLibroMayorEntregas.Total;            

            return b;
        }
        /// <summary>
        /// Proteger las celdas para evitar su edición.
        /// </summary>
        private void protegerCeldas(DataGridView tabla)
        {

            //this.formatoCeldaSoloLecturaColumna(tabla, MontoColones.Index, 0, 1, 2, 3, 4, 5, 6);


            this.formatoCeldaSeparador(tabla, 12);


            //this.formatoCeldaSoloLecturaColumna(tabla, MontoColones.Index, 30);
            //this.formatoCeldaSoloLecturaColumna(tabla, MontoDolares.Index, 31);

           // this.formatoCeldaFormato(tabla, MontoColones.Index, "N0", 0, 1, 2, 3, 4, 5, 6);



            this.formatoCeldaSoloLecturaColumna(tabla, 1, 0);
         
        }

        /// <summary>
        /// Dar formato de solo lectura a las filas que lo requieran.
        /// </summary>
        private void formatoCeldaSoloLectura(DataGridView tabla, params int[] filas)
        {

            foreach (int fila in filas)
            {
                tabla.Rows[fila].ReadOnly = true;
              //  tabla.Rows[fila].DefaultCellStyle.BackColor = clmDescripcion.DefaultCellStyle.BackColor;
            }

        }

        /// <summary>
        /// Dar formato de solo lectura a las filas que lo requieran.
        /// </summary>
        private void formatoCeldaSoloLecturaColumna(DataGridView tabla, int columna, int fila)
        {

           
                //tabla[columna, fila].ReadOnly = true;
                //tabla[columna, fila].Style.BackColor = Color.LightBlue;


                
                //  tabla.Rows[fila].DefaultCellStyle.BackColor = clmDescripcion.DefaultCellStyle.BackColor;
        }

        /// <summary>
        /// Dar formato  de solo lectura a las filas que lo requieran.
        /// </summary>
        private void formatoCeldaSoloLecturaColumna(DataGridView tabla, int columna, params int[] filas)
        {

            foreach (int fila in filas)
                tabla[columna, fila].ReadOnly = true;
            {
               // tabla[columna, fila].Style.BackColor = clmDescripcion.DefaultCellStyle.BackColor;
            }

        }

        /// <summary>
        /// Dar formato a las celdas que lo requieran.
        /// </summary>
        private void formatoCeldaFormato(DataGridView tabla, int columna, string formato, params int[] filas)
        {

            foreach (int fila in filas) tabla[columna, fila].Style.Format = "N0";

        }

        /// <summary>
        /// Dar formato a las celdas que son separadoras.
        /// </summary>
        private void formatoCeldaSeparador(DataGridView tabla, params int[] filas)
        {

            foreach (int fila in filas)
            {
                tabla.Rows[fila].ReadOnly = true;
                tabla.Rows[fila].DefaultCellStyle.BackColor = tabla.GridColor;
            }

        }

        /// <summary>
        /// Metodo que valida que no se digiten numeros
        /// </summary>
        private void txtNumeroA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48 && e.KeyChar != 8 && e.KeyChar != 44) || e.KeyChar > 57)
            {
                MessageBox.Show("Sólo se permiten Números");
                e.Handled = true;
            }
        }

        /// <summary>
        /// Llena los datos de la Facturacion en la tabla
        /// </summary>
        /// <param name="f">Objeto Facturacion con los datos a pintar</param>
        private void llenarDatos(FacturacionTransportadora f)
        {


            //foreach (CategoriaFacturacionTransportadora c in f.ListaCategoria)
            //{
            //    switch (c.Categoria)
            //    {

            //        case CategoriasFacturacion.Cuenta_Corriente_Entrantes:

            //            dgvCargas[1, 0].Value = c.Modelo;
            //            dgvCargas[2, 0].Value = c.CentroCostos;
            //            dgvCargas[3, 0].Value = c.Factura;
            //            dgvCargas[4, 0].Value = c.Monto;
            //            dgvCargas[5, 0].Value = c.MontoCreditoDebito;

            //            break;

            //        case (CategoriasFacturacion.Cuenta_Corriente_Salientes):

            //            dgvCargas[1, 1].Value = c.Modelo;
            //            dgvCargas[2, 1].Value = c.CentroCostos;
            //            dgvCargas[3, 1].Value = c.Factura;
            //            dgvCargas[4, 1].Value = c.Monto;
            //            dgvCargas[5, 1].Value = c.MontoCreditoDebito;

            //            break;

            //        case (CategoriasFacturacion.Sucursales):

            //            dgvCargas[1, 2].Value = c.Modelo;
            //            dgvCargas[2, 2].Value = c.CentroCostos;
            //            dgvCargas[3, 2].Value = c.Factura;
            //            dgvCargas[4, 2].Value = c.Monto;
            //            dgvCargas[5, 2].Value = c.MontoCreditoDebito;

            //            break;



            //        case (CategoriasFacturacion.Material_Operativo):

            //            dgvCargas[1, 3].Value = c.Modelo;
            //            dgvCargas[2, 3].Value = c.CentroCostos;
            //            dgvCargas[3, 3].Value = c.Factura;
            //            dgvCargas[4, 3].Value = c.Monto;
            //            dgvCargas[5, 3].Value = c.MontoCreditoDebito;

            //            break;



            //        case (CategoriasFacturacion.Procesamiento):

            //            dgvCargas[1, 4].Value = c.Modelo;
            //            dgvCargas[2, 4].Value = c.CentroCostos;
            //            dgvCargas[3, 4].Value = c.Factura;
            //            dgvCargas[4, 4].Value = c.Monto;
            //            dgvCargas[5, 4].Value = c.MontoCreditoDebito;

            //            break;

            //        case (CategoriasFacturacion.Servicios_Especiales):

            //            dgvCargas[1, 5].Value = c.Modelo;
            //            dgvCargas[2, 5].Value = c.CentroCostos;
            //            dgvCargas[3, 5].Value = c.Factura;
            //            dgvCargas[4, 5].Value = c.Monto;
            //            dgvCargas[5, 5].Value = c.MontoCreditoDebito;

            //            break;


            //        case (CategoriasFacturacion.Eticket):

            //            dgvCargas[1, 6].Value = c.Modelo;
            //            dgvCargas[2, 6].Value = c.CentroCostos;
            //            dgvCargas[3, 6].Value = c.Factura;
            //            dgvCargas[4, 6].Value = c.Monto;
            //            dgvCargas[5, 6].Value = c.MontoCreditoDebito;

            //            break;

            //    }
            //}

        }

        /// <summary>
        /// Actualiza los datos de 
        /// </summary>
        private void actualizarDatos()
        {
 
            //dgvCargas[MontoColones.Index, 1].Value = _libro_mayor.Saldo_AnteriorColones;
            //dgvCargas[MontoColones.Index, 2].Value = _libro_mayor.PedidoBovedaColones;
            //dgvCargas[MontoColones.Index, 3].Value = _libro_mayor.DescargaATMsColones;
            //dgvCargas[MontoColones.Index, 4].Value = _libro_mayor.PedidoBovedaAdicionalColones;
            //dgvCargas[MontoColones.Index, 5].Value = _libro_mayor.DescargaCompletaColones;
            //dgvCargas[MontoColones.Index, 6].Value = _libro_mayor.DevolucionATMsColones;
            //dgvCargas[MontoColones.Index, 7].Value = _libro_mayor.DevolucionEmergenciasColones;
            //dgvCargas[MontoColones.Index, 8].Value = _libro_mayor.EntregaBovedaColones;
            //dgvCargas[MontoColones.Index, 9].Value = _libro_mayor.CargasEmergenciaColones;
            //dgvCargas[MontoColones.Index, 10].Value = _libro_mayor.CargasATMsColones;
            //dgvCargas[MontoColones.Index, 11].Value = _libro_mayor.SaldoLibroColones;
            //dgvCargas[MontoColones.Index, 13].Value = _libro_mayor.SaldoColaColones;
            //dgvCargas[MontoColones.Index, 14].Value = _libro_mayor.SaldoCartuchosColones;
            //dgvCargas[MontoColones.Index, 15].Value = _libro_mayor.SaldoCola20000;
            //dgvCargas[MontoColones.Index, 16].Value = _libro_mayor.SaldoCola10000;
            //dgvCargas[MontoColones.Index, 17].Value = _libro_mayor.SaldoCola5000;
            //dgvCargas[MontoColones.Index, 18].Value = _libro_mayor.SaldoCola2000;
            //dgvCargas[MontoColones.Index, 19].Value = _libro_mayor.SaldoCola1000;
            //dgvCargas[MontoColones.Index, 20].Value = _libro_mayor.SaldoEfectivoColones;
            //dgvCargas[MontoColones.Index, 21].Value = _libro_mayor.DiferenciaColones;





            //dgvCargas[MontoDolares.Index, 1].Value = _libro_mayor.Saldo_AnteriorDolares;
            //dgvCargas[MontoDolares.Index, 2].Value = _libro_mayor.PedidoBovedaDolares;
            //dgvCargas[MontoDolares.Index, 3].Value = _libro_mayor.DescargaATMsDolares;
            //dgvCargas[MontoDolares.Index, 4].Value = _libro_mayor.PedidoBovedaAdicionalDolares;
            //dgvCargas[MontoDolares.Index, 5].Value = _libro_mayor.DescargaCompletaDolares;
            //dgvCargas[MontoDolares.Index, 6].Value = _libro_mayor.DevolucionATMsDolares;
            //dgvCargas[MontoDolares.Index, 7].Value = _libro_mayor.DevolucionEmergenciasDolares;
            //dgvCargas[MontoDolares.Index, 8].Value = _libro_mayor.EntregaBovedaDolares;
            //dgvCargas[MontoDolares.Index, 9].Value = _libro_mayor.CargasEmergenciaDolares;
            //dgvCargas[MontoDolares.Index, 10].Value = _libro_mayor.CargasATMsDolares;
            //dgvCargas[MontoDolares.Index, 11].Value = _libro_mayor.SaldoLibroDolares;
            //dgvCargas[MontoDolares.Index, 13].Value = _libro_mayor.SaldoColaDolares;
            //dgvCargas[MontoDolares.Index, 14].Value = _libro_mayor.SaldoCartuchosDolares;
            //dgvCargas[MontoDolares.Index, 15].Value = _libro_mayor.SaldoCola20000;
            //dgvCargas[MontoDolares.Index, 16].Value = _libro_mayor.SaldoCola10000;
            //dgvCargas[MontoDolares.Index, 17].Value = _libro_mayor.SaldoCola5000;
            //dgvCargas[MontoDolares.Index, 18].Value = _libro_mayor.SaldoCola2000;
            //dgvCargas[MontoDolares.Index, 19].Value = _libro_mayor.SaldoCola1000;
            //dgvCargas[MontoDolares.Index, 20].Value = _libro_mayor.SaldoEfectivoDolares;
            //dgvCargas[MontoDolares.Index, 21].Value = _libro_mayor.DiferenciaDolares;



        }


        /// <summary>
        /// Imprimir los datos de la hoja de la carga seleccionada.
        /// </summary>
        private void imprimirHojaCarga()
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla libro mayor boveda.xltx", true);

                DateTime fecha = dtpFecha.Value;


                LibroMayor cierre = new LibroMayor(
                    );

                LibroMayor suc = new LibroMayor();
                LibroMayor sucman = new LibroMayor();

                documento.seleccionarHoja(1);

                foreach (LibroMayor l in _libros)
                {
                    if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.Sucursales)
                    {
                        suc = l;
                       // this.llenarArchivo(l, 3, documento);
                    }
                    if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.SucursalesManual)
                    {
                        sucman = l;
                        //this.llenarArchivo(l, 3, documento);
                    }
                    if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.ATM_Descargas)
                    {
                        this.llenarArchivo(l, 4, documento);
                    }
                    if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.BNA_Proval)
                    {
                        this.llenarArchivo(l, 5, documento);
                    }
                    if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.Entregas_CEF)
                    {
                        this.llenarArchivo(l, 6, documento);
                    }
                    if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.Cambio_Denominacion)
                    {
                        this.llenarArchivo(l, 7, documento);
                    }
                    if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.Diferencias)
                    {
                        this.llenarArchivo(l, 8, documento);
                    }
                    if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.BPS)
                    {
                        this.llenarArchivo(l, 9, documento);
                    }
                    if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.BPS_Validacion)
                    {
                        this.llenarArchivo(l, 10, documento);
                    }
                    if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.Entrega_Niquel)
                    {
                        this.llenarArchivo(l, 11, documento);
                    }
                    if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.Bancos)
                    {
                        this.llenarArchivo(l, 12, documento);
                    }
                    if (l.TipoLibroEntregas == TipoClaseLibroMayorEntregas.CAN)
                    {
                        this.llenarArchivo(l, 13, documento);
                    }
                    

                }

                //Llenar la fila de sucursales con la suma de Sucursales en SITES y sucursales ingresado manualmente a los libros
                LibroMayor Suma = new LibroMayor();
                Suma.Monto10000Colones = suc.Monto10000Colones + sucman.Monto10000Colones;
                Suma.Monto1000Colones = suc.Monto1000Colones + sucman.Monto1000Colones;
                Suma.Monto100Colones = suc.Monto100Colones + sucman.Monto100Colones;
                Suma.Monto100Dolares = suc.Monto100Dolares + sucman.Monto100Dolares;
                Suma.Monto100Euros = suc.Monto100Euros + sucman.Monto100Euros;
                Suma.Monto10Colones = suc.Monto10Colones + sucman.Monto10Colones;
                Suma.Monto10Dolares = suc.Monto10Dolares + sucman.Monto10Dolares;
                Suma.Monto10Euros = suc.Monto10Euros + sucman.Monto10Euros;
                Suma.Monto1Dolares = suc.Monto1Dolares + sucman.Monto1Dolares;
                Suma.Monto20000Colones = suc.Monto20000Colones + sucman.Monto20000Colones;
                Suma.Monto2000Colones = suc.Monto2000Colones + sucman.Monto2000Colones;
                Suma.Monto200Euros = suc.Monto200Euros + sucman.Monto200Euros;
                Suma.Monto20Dolares = suc.Monto20Dolares + sucman.Monto20Dolares;
                Suma.Monto20Euros = suc.Monto20Euros + sucman.Monto20Euros;
                Suma.Monto25Colones = suc.Monto25Colones + sucman.Monto25Colones;
                Suma.Monto2Dolares = suc.Monto2Dolares + sucman.Monto2Dolares;
                Suma.Monto50000Colones = suc.Monto50000Colones + sucman.Monto50000Colones;
                Suma.Monto5000Colones = suc.Monto5000Colones + sucman.Monto5000Colones;
                Suma.Monto500Colones = suc.Monto500Colones + sucman.Monto500Colones;
                Suma.Monto500Euros = suc.Monto500Euros + sucman.Monto500Euros;
                Suma.Monto50Colones = suc.Monto50Colones + sucman.Monto50Colones;
                Suma.Monto50Dolares = suc.Monto50Dolares + sucman.Monto50Dolares;
                Suma.Monto50Euros = suc.Monto50Euros + sucman.Monto50Euros;
                Suma.Monto5Colones = suc.Monto5Colones + sucman.Monto5Colones;
                Suma.Monto5Dolares = suc.Monto5Dolares + sucman.Monto5Dolares;
                Suma.Monto5Euros = suc.Monto5Euros + sucman.Monto5Euros;
                Suma.Mutilado = suc.Mutilado + sucman.Mutilado;
                Suma.MutiladoDolares = suc.MutiladoDolares + sucman.MutiladoDolares;
                Suma.MutiladoDolares = suc.MutiladoEuros + sucman.MutiladoEuros;
                Suma.Cola = suc.Cola + sucman.Cola;
                Suma.ColaDolares = suc.ColaDolares + sucman.ColaDolares;
                Suma.ColaEuros = suc.ColaEuros + sucman.ColaEuros;

                this.llenarArchivo(Suma,3,documento);
                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Excepcion ex)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }


        /// <summary>
        /// Permite llenar el excel basado en un rubro de los libros. 
        /// </summary>
        /// <param name="l">Libro Mayor con los datos</param>
        /// <param name="fila">Fila donde inicia</param>
        private void llenarArchivo(LibroMayor l, int fila, DocumentoExcel documento)
        {
            documento.seleccionarCelda(fila, 2);
            documento.actualizarValorCelda(l.Monto50000Colones);

            documento.seleccionarCelda(fila, 3);
            documento.actualizarValorCelda(l.Monto20000Colones);

            documento.seleccionarCelda(fila, 4);
            documento.actualizarValorCelda(l.Monto10000Colones);

            documento.seleccionarCelda(fila, 5);
            documento.actualizarValorCelda(l.Monto5000Colones);

            documento.seleccionarCelda(fila, 6);
            documento.actualizarValorCelda(l.Monto2000Colones);

            documento.seleccionarCelda(fila, 7);
            documento.actualizarValorCelda(l.Monto1000Colones);

            documento.seleccionarCelda(fila, 8);
            documento.actualizarValorCelda(l.Monto500Colones);

            documento.seleccionarCelda(fila, 9);
            documento.actualizarValorCelda(l.Monto100Colones);

            documento.seleccionarCelda(fila, 10);
            documento.actualizarValorCelda(l.Monto50Colones);

            documento.seleccionarCelda(fila, 11);
            documento.actualizarValorCelda(l.Monto25Colones);

            documento.seleccionarCelda(fila, 12);
            documento.actualizarValorCelda(l.Monto10Colones);

            documento.seleccionarCelda(fila, 13);
            documento.actualizarValorCelda(l.Monto5Colones);

            documento.seleccionarCelda(fila, 14);
            documento.actualizarValorCelda(l.Cola);

            documento.seleccionarCelda(fila, 15);
            documento.actualizarValorCelda(l.Mutilado);

            documento.seleccionarCelda(fila, 2);
            documento.actualizarValorCelda(l.Monto50000Colones);

         
            // Dólares

            documento.seleccionarCelda((fila +16), 2);
            documento.actualizarValorCelda(l.Monto100Dolares);

            documento.seleccionarCelda((fila +16), 3);
            documento.actualizarValorCelda(l.Monto50Dolares);

           documento.seleccionarCelda((fila +16), 4);
            documento.actualizarValorCelda(l.Monto20Dolares);

           documento.seleccionarCelda((fila +16), 5);
            documento.actualizarValorCelda(l.Monto10Dolares);

            documento.seleccionarCelda((fila +16), 6);
            documento.actualizarValorCelda(l.Monto5Dolares);

            documento.seleccionarCelda((fila +16), 7);
            documento.actualizarValorCelda(l.Monto1Dolares);

            documento.seleccionarCelda((fila +16), 8);
            documento.actualizarValorCelda(l.ColaDolares);

            documento.seleccionarCelda((fila +16), 9);
            documento.actualizarValorCelda(l.MutiladoDolares);

     

            //Euros

            documento.seleccionarCelda((fila +30), 2);
            documento.actualizarValorCelda(l.Monto500Euros);

            documento.seleccionarCelda((fila +30), 3);
            documento.actualizarValorCelda(l.Monto200Euros);

            documento.seleccionarCelda((fila +30), 4);
            documento.actualizarValorCelda(l.Monto100Euros);

            documento.seleccionarCelda((fila +30), 5);
            documento.actualizarValorCelda(l.Monto50Euros);

            documento.seleccionarCelda((fila +30), 6);
            documento.actualizarValorCelda(l.Monto20Euros);

            documento.seleccionarCelda((fila +30), 7);
            documento.actualizarValorCelda(l.Monto10Euros);

            documento.seleccionarCelda((fila +30), 8);
            documento.actualizarValorCelda(l.Monto5Euros);

            documento.seleccionarCelda((fila +30), 9);
            documento.actualizarValorCelda(l.ColaEuros);

            documento.seleccionarCelda((fila + 30), 10);
            documento.actualizarValorCelda(l.MutiladoEuros);
        }
     

        #endregion Metodos Privados

   


    }
}
