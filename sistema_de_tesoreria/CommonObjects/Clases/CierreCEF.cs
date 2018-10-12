//
//  @ Project : 
//  @ File Name : CierreCEF.cs
//  @ Date : 27/07/2011
//  @ Author : Erick Chavarría 

using System;

using LibreriaAccesoDatos;

namespace CommonObjects
{

    public class CierreCEF : ObjetoIndexado
    {

        #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }

        private Colaborador _cajero;

        public Colaborador Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }

        private Colaborador _digitador;

        public Colaborador Digitador
        {
            get { return _digitador; }
            set { _digitador = value; }
        }

        private Colaborador _coordinador;

        public Colaborador Coordinador
        {
            get { return _coordinador; }
            set { _coordinador = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private string _observaciones;

        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }


        private short _tulas;

        public short Tulas
        {
            get { return _tulas; }
            set { _tulas = value; }
        }

        private short _manifiestos;

        public short Manifiestos
        {
            get { return _manifiestos; }
            set { _manifiestos = value; }
        }

        private short _depositos;

        public short Depositos
        {
            get { return _depositos; }
            set { _depositos = value; }
        }

        private short _cheques;

        public short Cheques
        {
            get { return _cheques; }
            set { _cheques = value; }
        }

        private short _sobres;

        public short Sobres
        {
            get { return _sobres; }
            set { _sobres = value; }
        }

        private short _disconformidades;

        public short Disconformidades
        {
            get { return _disconformidades; }
            set { _disconformidades = value; }
        }

        #region Colones

        private decimal _saldo_dia_anterior_colones;

        public decimal Saldo_dia_anterior_colones
        {
            get { return _saldo_dia_anterior_colones; }
            set { _saldo_dia_anterior_colones = value; }
        }

        private decimal _ingreso_clientes_colones;

        public decimal Ingreso_clientes_colones
        {
            get { return _ingreso_clientes_colones; }
            set { _ingreso_clientes_colones = value; }
        }

        private decimal _reporte_cajero_colones;

        public decimal Reporte_cajero_colones
        {
            get { return _reporte_cajero_colones; }
            set { _reporte_cajero_colones = value; }
        }

        private decimal _otros_ingresos_colones;

        public decimal Otros_ingresos_colones
        {
            get { return _otros_ingresos_colones; }
            set { _otros_ingresos_colones = value; }
        }

        private decimal _otros_egresos_colones;

        public decimal Otros_egresos_colones
        {
            get { return _otros_egresos_colones; }
            set { _otros_egresos_colones = value; }
        }

        private decimal _cheques_locales_colones;

        public decimal Cheques_locales_colones
        {
            get { return _cheques_locales_colones; }
            set { _cheques_locales_colones = value; }
        }

        private decimal _cheques_exterior_colones;

        public decimal Cheques_exterior_colones
        {
            get { return _cheques_exterior_colones; }
            set { _cheques_exterior_colones = value; }
        }

        private decimal _cheques_bac_colones;

        public decimal Cheques_bac_colones
        {
            get { return _cheques_bac_colones; }
            set { _cheques_bac_colones = value; }
        }

        private decimal _salidas_niquel_colones;

        public decimal Salidas_niquel_colones
        {
            get { return _salidas_niquel_colones; }
            set { _salidas_niquel_colones = value; }
        }

        private decimal _niquel_pendiente_colones;

        public decimal Niquel_pendiente_colones
        {
            get { return _niquel_pendiente_colones; }
            set { _niquel_pendiente_colones = value; }
        }

        private decimal _niquel_pendiente_dia_anterior_colones;

        public decimal Niquel_pendiente_dia_anterior_colones
        {
            get { return _niquel_pendiente_dia_anterior_colones; }
            set { _niquel_pendiente_dia_anterior_colones = value; }
        }


        private decimal _faltante_cliente_niquel_colones;

        public decimal Faltante_cliente_niquel_colones
        {
            get { return _faltante_cliente_niquel_colones; }
            set { _faltante_cliente_niquel_colones = value; }
        }


        private decimal _sobrante_cliente_niquel_colones;

        public decimal Sobrante_cliente_niquel_colones
        {
            get { return _sobrante_cliente_niquel_colones; }
            set { _sobrante_cliente_niquel_colones = value; }
        }

        private decimal _entregas_boveda_colones;

        public decimal Entregas_boveda_colones
        {
            get { return _entregas_boveda_colones; }
            set { _entregas_boveda_colones = value; }
        }

        private decimal _entregas_pendientes_colones;

        public decimal Entregas_pendientes_colones
        {
            get { return _entregas_pendientes_colones; }
            set { _entregas_pendientes_colones = value; }
        }

        private decimal _faltante_clientes_colones;

        public decimal Faltante_clientes_colones
        {
            get { return _faltante_clientes_colones; }
            set { _faltante_clientes_colones = value; }
        }

        private decimal _sobrante_clientes_colones;

        public decimal Sobrante_clientes_colones
        {
            get { return _sobrante_clientes_colones; }
            set { _sobrante_clientes_colones = value; }
        }

        private decimal _faltante_quinientos_colones;

        public decimal Faltante_quinientos_colones
        {
            get { return _faltante_quinientos_colones; }
            set { _faltante_quinientos_colones = value; }
        }

        private decimal _sobrante_quinientos_colones;

        public decimal Sobrante_quinientos_colones
        {
            get { return _sobrante_quinientos_colones; }
            set { _sobrante_quinientos_colones = value; }
        }

        private decimal _efectivo_cajero_colones;

        public decimal Efectivo_cajero_colones
        {
            get { return _efectivo_cajero_colones; }
            set { _efectivo_cajero_colones = value; }
        }

        private decimal _saldo_cierre_colones;

        public decimal Saldo_cierre_colones
        {
            get { return _saldo_cierre_colones; }
            set { _saldo_cierre_colones = value; }
        }

        private decimal _compra_dolares;

        public decimal Compra_dolares
        {
            get { return _compra_dolares; }
            set { _compra_dolares = value; }
        }

        #endregion Colones

        #region Dolares

        private decimal _saldo_dia_anterior_dolares;

        public decimal Saldo_dia_anterior_dolares
        {
            get { return _saldo_dia_anterior_dolares; }
            set { _saldo_dia_anterior_dolares = value; }
        }

        private decimal _ingreso_clientes_dolares;

        public decimal Ingreso_clientes_dolares
        {
            get { return _ingreso_clientes_dolares; }
            set { _ingreso_clientes_dolares = value; }
        }

        private decimal _reporte_cajero_dolares;

        public decimal Reporte_cajero_dolares
        {
            get { return _reporte_cajero_dolares; }
            set { _reporte_cajero_dolares = value; }
        }

        private decimal _otros_ingresos_dolares;

        public decimal Otros_ingresos_dolares
        {
            get { return _otros_ingresos_dolares; }
            set { _otros_ingresos_dolares = value; }
        }

        private decimal _otros_egresos_dolares;

        public decimal Otros_egresos_dolares
        {
            get { return _otros_egresos_dolares; }
            set { _otros_egresos_dolares = value; }
        }

        private decimal _cheques_locales_dolares;

        public decimal Cheques_locales_dolares
        {
            get { return _cheques_locales_dolares; }
            set { _cheques_locales_dolares = value; }
        }

        private decimal _cheques_exterior_dolares;

        public decimal Cheques_exterior_dolares
        {
            get { return _cheques_exterior_dolares; }
            set { _cheques_exterior_dolares = value; }
        }

        private decimal _cheques_bac_dolares;

        public decimal Cheques_bac_dolares
        {
            get { return _cheques_bac_dolares; }
            set { _cheques_bac_dolares = value; }
        }

        private decimal _salidas_niquel_dolares;

        public decimal Salidas_niquel_dolares
        {
            get { return _salidas_niquel_dolares; }
            set { _salidas_niquel_dolares = value; }
        }

        private decimal _niquel_pendiente_dolares;

        public decimal Niquel_pendiente_dolares
        {
            get { return _niquel_pendiente_dolares; }
            set { _niquel_pendiente_dolares = value; }
        }

        private decimal _entregas_boveda_dolares;

        public decimal Entregas_boveda_dolares
        {
            get { return _entregas_boveda_dolares; }
            set { _entregas_boveda_dolares = value; }
        }

        private decimal _entregas_pendientes_dolares;

        public decimal Entregas_pendientes_dolares
        {
            get { return _entregas_pendientes_dolares; }
            set { _entregas_pendientes_dolares = value; }
        }

        private decimal _niquel_pendiente_dia_anterior_dolares;

        public decimal Niquel_pendiente_dia_anterior_dolares
        {
            get { return _niquel_pendiente_dia_anterior_dolares; }
            set { _niquel_pendiente_dia_anterior_dolares = value; }
        }


        private decimal _faltante_cliente_niquel_dolares;

        public decimal Faltante_cliente_niquel_dolares
        {
            get { return _faltante_cliente_niquel_dolares; }
            set { _faltante_cliente_niquel_dolares = value; }
        }


        private decimal _sobrante_cliente_niquel_dolares;

        public decimal Sobrante_cliente_niquel_dolares
        {
            get { return _sobrante_cliente_niquel_dolares; }
            set { _sobrante_cliente_niquel_dolares = value; }
        }

        private decimal _faltante_clientes_dolares;

        public decimal Faltante_clientes_dolares
        {
            get { return _faltante_clientes_dolares; }
            set { _faltante_clientes_dolares = value; }
        }

        private decimal _sobrante_clientes_dolares;

        public decimal Sobrante_clientes_dolares
        {
            get { return _sobrante_clientes_dolares; }
            set { _sobrante_clientes_dolares = value; }
        }

        private decimal _faltante_quinientos_dolares;

        public decimal Faltante_quinientos_dolares
        {
            get { return _faltante_quinientos_dolares; }
            set { _faltante_quinientos_dolares = value; }
        }

        private decimal _sobrante_quinientos_dolares;

        public decimal Sobrante_quinientos_dolares
        {
            get { return _sobrante_quinientos_dolares; }
            set { _sobrante_quinientos_dolares = value; }
        }

        private decimal _efectivo_cajero_dolares;

        public decimal Efectivo_cajero_dolares
        {
            get { return _efectivo_cajero_dolares; }
            set { _efectivo_cajero_dolares = value; }
        }

        private decimal _saldo_cierre_dolares;

        public decimal Saldo_cierre_dolares
        {
            get { return _saldo_cierre_dolares; }
            set { _saldo_cierre_dolares = value; }
        }

        private decimal _venta_dolares;

        public decimal Venta_dolares
        {
            get { return _venta_dolares; }
            set { _venta_dolares = value; }
        }

        #endregion Dolares

        #region Euros

        private decimal _saldo_dia_anterior_euros;

        public decimal Saldo_dia_anterior_euros
        {
            get { return _saldo_dia_anterior_euros; }
            set { _saldo_dia_anterior_euros = value; }
        }

        private decimal _ingreso_clientes_euros;

        public decimal Ingreso_clientes_euros
        {
            get { return _ingreso_clientes_euros; }
            set { _ingreso_clientes_euros = value; }
        }

        private decimal _reporte_cajero_euros;

        public decimal Reporte_cajero_euros
        {
            get { return _reporte_cajero_euros; }
            set { _reporte_cajero_euros = value; }
        }

        private decimal _otros_ingresos_euros;

        public decimal Otros_ingresos_euros
        {
            get { return _otros_ingresos_euros; }
            set { _otros_ingresos_euros = value; }
        }

        private decimal _otros_egresos_euros;

        public decimal Otros_egresos_euros
        {
            get { return _otros_egresos_euros; }
            set { _otros_egresos_euros = value; }
        }

        private decimal _cheques_locales_euros;

        public decimal Cheques_locales_euros
        {
            get { return _cheques_locales_euros; }
            set { _cheques_locales_euros = value; }
        }

        private decimal _cheques_exterior_euros;

        public decimal Cheques_exterior_euros
        {
            get { return _cheques_exterior_euros; }
            set { _cheques_exterior_euros = value; }
        }

        private decimal _cheques_bac_euros;

        public decimal Cheques_bac_euros
        {
            get { return _cheques_bac_euros; }
            set { _cheques_bac_euros = value; }
        }

        private decimal _salidas_niquel_euros;

        public decimal Salidas_niquel_euros
        {
            get { return _salidas_niquel_euros; }
            set { _salidas_niquel_euros = value; }
        }

        private decimal _niquel_pendiente_euros;

        public decimal Niquel_pendiente_euros
        {
            get { return _niquel_pendiente_euros; }
            set { _niquel_pendiente_euros = value; }
        }

        private decimal _niquel_pendiente_dia_anterior_euros;

        public decimal Niquel_pendiente_dia_anterior_euros
        {
            get { return _niquel_pendiente_dia_anterior_euros; }
            set { _niquel_pendiente_dia_anterior_euros = value; }
        }


        private decimal _faltante_cliente_niquel_euros;

        public decimal Faltante_cliente_niquel_euros
        {
            get { return _faltante_cliente_niquel_euros; }
            set { _faltante_cliente_niquel_euros = value; }
        }


        private decimal _sobrante_cliente_niquel_euros;

        public decimal Sobrante_cliente_niquel_euros
        {
            get { return _sobrante_cliente_niquel_euros; }
            set { _sobrante_cliente_niquel_euros = value; }
        }

        private decimal _entregas_boveda_euros;

        public decimal Entregas_boveda_euros
        {
            get { return _entregas_boveda_euros; }
            set { _entregas_boveda_euros = value; }
        }

        private decimal _entregas_pendientes_euros;

        public decimal Entregas_pendientes_euros
        {
            get { return _entregas_pendientes_euros; }
            set { _entregas_pendientes_euros = value; }
        }

        private decimal _faltante_clientes_euros;

        public decimal Faltante_clientes_euros
        {
            get { return _faltante_clientes_euros; }
            set { _faltante_clientes_euros = value; }
        }

        private decimal _sobrante_clientes_euros;

        public decimal Sobrante_clientes_euros
        {
            get { return _sobrante_clientes_euros; }
            set { _sobrante_clientes_euros = value; }
        }

        private decimal _faltante_quinientos_euros;

        public decimal Faltante_quinientos_euros
        {
            get { return _faltante_quinientos_euros; }
            set { _faltante_quinientos_euros = value; }
        }

        private decimal _sobrante_quinientos_euros;

        public decimal Sobrante_quinientos_euros
        {
            get { return _sobrante_quinientos_euros; }
            set { _sobrante_quinientos_euros = value; }
        }

        private decimal _efectivo_cajero_euros;

        public decimal Efectivo_cajero_euros
        {
            get { return _efectivo_cajero_euros; }
            set { _efectivo_cajero_euros = value; }
        }

        private decimal _saldo_cierre_euros;

        public decimal Saldo_cierre_euros
        {
            get { return _saldo_cierre_euros; }
            set { _saldo_cierre_euros = value; }
        }

        private decimal _compra_euros;

        public decimal Compra_euros
        {
            get { return _compra_euros; }
            set { _compra_euros = value; }
        }



        private decimal _venta_euros;

        public decimal Venta_euros
        {
            get { return _venta_euros; }
            set { _venta_euros = value; }
        }

        #endregion Colones

        #endregion Atributos Privados

        #region Constructor de Clase

        public CierreCEF(int id = 0,
                         Colaborador cajero = null,
                         Colaborador digitador = null,
                         Colaborador coordinador = null,
                         DateTime? fecha = null,
                         short cheques = 0,
                         short sobres = 0,
                         short disconformidades = 0,
                         string observaciones = "")
        {
            this.DB_ID = id;

            _cajero = cajero;
            _digitador = digitador;
            _coordinador = coordinador;
            _fecha = fecha  ?? DateTime.Now;
            _cheques = cheques;
            _sobres = sobres;
            _disconformidades = disconformidades;
            _observaciones = observaciones;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _cajero.Nombre + " " + _cajero.Primer_apellido + " - " + _digitador.Nombre + " " + _digitador.Primer_apellido;
        }

        #endregion Overrides

    }

}
