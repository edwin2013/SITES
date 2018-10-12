using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

namespace CommonObjects.Clases
{
    public class CierreCajeroPROA: ObjetoIndexado
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
        private short _tulas;

        public short Tulas
        {
            get { return _tulas; }
            set { _tulas = value; }
        }
        private short _cheques;

        public short Cheques
        {
            get { return _cheques; }
            set { _cheques = value; }
        }

        private byte _tipocierre; //para saber si es de Niquel o Normal

        public byte TipoCierre
        {
            get { return _tipocierre; }
            set { _tipocierre = value; }
        }

        private string _comentarios; //para saber si es de Niquel o Normal

        public string Comentarios
        {
            get { return _comentarios; }
            set { _comentarios = value; }
        }


        #region Colones

        private decimal _compra_euros_col; //cajero normal

        public decimal Compra_euros_col
        {
            get { return _compra_euros_col; }
            set { _compra_euros_col = value; }
        }

        private decimal _venta_euros_col;

        public decimal Venta_euros_col
        {
            get { return _venta_euros_col; }
            set { _venta_euros_col = value; }
        }

        private decimal _saldo_inicial_colones; //ambos

        public decimal Saldo_inicial_colones
        {
            get { return _saldo_inicial_colones; }
            set { _saldo_inicial_colones = value; }
        }

        private decimal _total_clientes_Directos_colones; //cajero niquel

        public decimal Total_clientes_Directos_colones
        {
            get { return _total_clientes_Directos_colones; }
            set { _total_clientes_Directos_colones = value; }
        }

        private decimal _niquel_cola_cajeros_colones; //cajero niquel

        public decimal Niquel_cola_Cajeros_colones
        {
            get { return _niquel_cola_cajeros_colones; }
            set { _niquel_cola_cajeros_colones = value; }
        }

        private decimal _niquel_entrega_cajeros_colones; //cajero niquel

        public decimal Niquel_entrega_Cajeros_colones
        {
            get { return _niquel_entrega_cajeros_colones; }
            set { _niquel_entrega_cajeros_colones = value; }
        }

        private decimal _niquel_enmesa_colones; //cajero niquel y cajero normal

        public decimal Niquel_enmesa_colones
        {
            get { return _niquel_enmesa_colones; }
            set { _niquel_enmesa_colones = value; }
        }

        private decimal _niquel_procesamiento_colones; //cajero niquel

        public decimal Niquel_procesamiento_colones
        {
            get { return _niquel_procesamiento_colones; }
            set { _niquel_procesamiento_colones = value; }
        }        

        private decimal _total_suma_manifiestos_colones; //cajero normal

        public decimal Total_Suma_Manifiestos_Colones
        {
            get { return _total_suma_manifiestos_colones; }
            set { _total_suma_manifiestos_colones = value; }
        }        

        private decimal _cheques_locales_colones; //ambos

        public decimal Cheques_locales_colones
        {
            get { return _cheques_locales_colones; }
            set { _cheques_locales_colones = value; }
        }

        private decimal _cheques_exterior_colones; //ambos

        public decimal Cheques_exterior_colones
        {
            get { return _cheques_exterior_colones; }
            set { _cheques_exterior_colones = value; }
        }

        private decimal _cheques_bac_colones; //ambos

        public decimal Cheques_bac_colones
        {
            get { return _cheques_bac_colones; }
            set { _cheques_bac_colones = value; }
        }

        private decimal _niquel_total_colones; //cajero normal (niquel total) y cajero niquel (total niquel)

        public decimal Niquel_Total_colones
        {
            get { return _niquel_total_colones; }
            set { _niquel_total_colones = value; }
        }

        private decimal _total_entregas_niquel_colones; //cajero niquel y cajero normal

        public decimal Total_Entregas_Niquel_colones
        {
            get { return _total_entregas_niquel_colones; }
            set { _total_entregas_niquel_colones = value; }
        }

        private decimal _total_entregas_colones; //cajero normal

        public decimal Total_Entregas_colones
        {
            get { return _total_entregas_colones; }
            set { _total_entregas_colones = value; }
        }

        private decimal _total_entregas_billetes_colones; //cajero niquel

        public decimal Total_Entregas_billetes_colones
        {
            get { return _total_entregas_billetes_colones; }
            set { _total_entregas_billetes_colones = value; }
        }
        

        private decimal _faltante_clientes_colones; //ambos

        public decimal Faltante_clientes_colones
        {
            get { return _faltante_clientes_colones; }
            set { _faltante_clientes_colones = value; }
        }

        private decimal _sobrante_clientes_colones;//ambos

        public decimal Sobrante_clientes_colones
        {
            get { return _sobrante_clientes_colones; }
            set { _sobrante_clientes_colones = value; }
        }

        private decimal _faltante_quinientos_colones;//ambos

        public decimal Faltante_quinientos_colones
        {
            get { return _faltante_quinientos_colones; }
            set { _faltante_quinientos_colones = value; }
        }

        private decimal _sobrante_quinientos_colones;//ambos

        public decimal Sobrante_quinientos_colones
        {
            get { return _sobrante_quinientos_colones; }
            set { _sobrante_quinientos_colones = value; }
        }

        private decimal _saldo_final_colones;//ambos

        public decimal Saldo_final_colones
        {
            get { return _saldo_final_colones; }
            set { _saldo_final_colones = value; }
        }

        private decimal _compra_dolares_col; //cajero normal

        public decimal Compra_dolares_col
        {
            get { return _compra_dolares_col; }
            set { _compra_dolares_col = value; }
        }

        private decimal _venta_dolares_col;

        public decimal Venta_dolares_col
        {
            get { return _venta_dolares_col; }
            set { _venta_dolares_col = value; }
        }

        #endregion Colones

        #region Dolares

        private decimal _saldo_inicial_dolares;

        public decimal Saldo_inicial_dolares
        {
            get { return _saldo_inicial_dolares; }
            set { _saldo_inicial_dolares = value; }
        }

        private decimal _total_clientes_Directos_dolares;

        public decimal Total_clientes_Directos_dolares
        {
            get { return _total_clientes_Directos_dolares; }
            set { _total_clientes_Directos_dolares = value; }
        }

        private decimal _niquel_cola_cajeros_dolares;

        public decimal Niquel_cola_Cajeros_dolares
        {
            get { return _niquel_cola_cajeros_dolares; }
            set { _niquel_cola_cajeros_dolares = value; }
        }

        private decimal _niquel_entrega_cajeros_dolares;

        public decimal Niquel_entrega_Cajeros_dolares
        {
            get { return _niquel_entrega_cajeros_dolares; }
            set { _niquel_entrega_cajeros_dolares = value; }
        }

        private decimal _niquel_enmesa_dolares;

        public decimal Niquel_enmesa_dolares
        {
            get { return _niquel_enmesa_dolares; }
            set { _niquel_enmesa_dolares = value; }
        }

        private decimal _niquel_procesamiento_dolares;

        public decimal Niquel_procesamiento_dolares
        {
            get { return _niquel_procesamiento_dolares; }
            set { _niquel_procesamiento_dolares = value; }
        }        

        private decimal _total_suma_manifiestos_dolares;

        public decimal Total_Suma_Manifiestos_dolares
        {
            get { return _total_suma_manifiestos_dolares; }
            set { _total_suma_manifiestos_dolares = value; }
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

        private decimal _niquel_total_dolares;

        public decimal Niquel_Total_dolares
        {
            get { return _niquel_total_dolares; }
            set { _niquel_total_dolares = value; }
        }

        private decimal _total_entregas_niquel_dolares;

        public decimal Total_Entregas_Niquel_dolares
        {
            get { return _total_entregas_niquel_dolares; }
            set { _total_entregas_niquel_dolares = value; }
        }

        private decimal _total_entregas_dolares;

        public decimal Total_Entregas_dolares
        {
            get { return _total_entregas_dolares; }
            set { _total_entregas_dolares = value; }
        }


        private decimal _total_entregas_billetes_dolares;

        public decimal Total_Entregas_billetes_dolares
        {
            get { return _total_entregas_billetes_dolares; }
            set { _total_entregas_billetes_dolares = value; }
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

        private decimal _saldo_final_dolares;

        public decimal Saldo_final_dolares
        {
            get { return _saldo_final_dolares; }
            set { _saldo_final_dolares = value; }
        }

        private decimal _venta_dolares_dol;

        public decimal Venta_dolares_dol
        {
            get { return _venta_dolares_dol; }
            set { _venta_dolares_dol = value; }
        }

        private decimal _compra_dolares_dol; //cajero normal

        public decimal Compra_dolares_dol
        {
            get { return _compra_dolares_dol; }
            set { _compra_dolares_dol = value; }
        }

        #endregion Dolares

        #region Euros

        private decimal _venta_euros_eur;

        public decimal Venta_euros_eur
        {
            get { return _venta_euros_eur; }
            set { _venta_euros_eur = value; }
        }

        private decimal _compra_euros_eur; //cajero normal

        public decimal Compra_euros_eur
        {
            get { return _compra_euros_eur; }
            set { _compra_euros_eur = value; }
        }

            private decimal _saldo_inicial_euros;

        public decimal Saldo_inicial_euros
        {
            get { return _saldo_inicial_euros; }
            set { _saldo_inicial_euros = value; }
        }

        private decimal _total_clientes_Directos_euros;

        public decimal Total_clientes_Directos_euros
        {
            get { return _total_clientes_Directos_euros; }
            set { _total_clientes_Directos_euros = value; }
        }

        private decimal _niquel_cola_cajeros_euros;

        public decimal Niquel_cola_Cajeros_euros
        {
            get { return _niquel_cola_cajeros_euros; }
            set { _niquel_cola_cajeros_euros = value; }
        }

        private decimal _niquel_entrega_cajeros_euros;

        public decimal Niquel_entrega_Cajeros_euros
        {
            get { return _niquel_entrega_cajeros_euros; }
            set { _niquel_entrega_cajeros_euros = value; }
        }

        private decimal _niquel_enmesa_euros;

        public decimal Niquel_enmesa_euros
        {
            get { return _niquel_enmesa_euros; }
            set { _niquel_enmesa_euros = value; }
        }

        private decimal _niquel_procesamiento_euros;

        public decimal Niquel_procesamiento_euros
        {
            get { return _niquel_procesamiento_euros; }
            set { _niquel_procesamiento_euros = value; }
        }
       
        private decimal _total_suma_manifiestos_euros;

        public decimal Total_Suma_Manifiestos_euros
        {
            get { return _total_suma_manifiestos_euros; }
            set { _total_suma_manifiestos_euros = value; }
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

        private decimal _niquel_total_euros;

        public decimal Niquel_Total_euros
        {
            get { return _niquel_total_euros; }
            set { _niquel_total_euros = value; }
        }

        private decimal _total_entregas_niquel_euros;

        public decimal Total_Entregas_Niquel_euros
        {
            get { return _total_entregas_niquel_euros; }
            set { _total_entregas_niquel_euros = value; }
        }

        private decimal _total_entregas_euros;

        public decimal Total_Entregas_euros
        {
            get { return _total_entregas_euros; }
            set { _total_entregas_euros = value; }
        }


        private decimal _total_entregas_billetes_euros;

        public decimal Total_Entregas_billetes_euros
        {
            get { return _total_entregas_billetes_euros; }
            set { _total_entregas_billetes_euros = value; }
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

        private decimal _saldo_final_euros;

        public decimal Saldo_final_euros
        {
            get { return _saldo_final_euros; }
            set { _saldo_final_euros = value; }
        }

        #endregion Euros

        #endregion Atributos Privados

        #region Constructor de Clase

        public CierreCajeroPROA(int id = 0,
                         Colaborador cajero = null,                         
                         Colaborador coordinador = null,
                         Colaborador digitador = null,
                         DateTime? fecha = null,
                         byte tipocierre = 0)
        {
            this.DB_ID = id;

            _cajero = cajero;            
            _coordinador = coordinador;
            _fecha = fecha  ?? DateTime.Now;
            _digitador = digitador;
            _tipocierre = tipocierre;
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
