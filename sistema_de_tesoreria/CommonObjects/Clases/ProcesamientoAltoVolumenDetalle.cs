using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;

namespace CommonObjects.Clases
{
    public class ProcesamientoAltoVolumenDetalle: ObjetoIndexado
    {
         #region Atributos Privados

        public int ID
        {
            get { return this.DB_ID; }
            set { this.DB_ID = value; }
        }        

        protected Colaborador _cajero;

        public Colaborador Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }                

        protected Tula _tula;

        public Tula Tula
        {
            get { return _tula; }
            set { _tula = value; }
        }       
        

        protected DateTime _fecha_procesamiento;

        public DateTime Fecha_Procesamiento
        {
            get { return _fecha_procesamiento; }
            set { _fecha_procesamiento = value; }
        }        

        protected string _headercard;
        public string Headercard
        {
            get { return _headercard; }
            set { _headercard = value; }
        }
       

        protected byte _tipo;

        public byte Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        protected Monedas _moneda;

        public Monedas Moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }

        protected decimal _monto;

        public decimal Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public ProcesamientoAltoVolumenDetalle(string codigo,
            int id = 0,            
            Tula idtula = null,                        
            DateTime? fecha_procesamiento = null,            
            Colaborador cajero_receptor = null, string headercard = "", byte tipo = 0, Monedas moneda = Monedas.Colones, decimal monto = 0)
        {
            this.ID = id;
            _tipo = tipo;            
            _fecha_procesamiento = fecha_procesamiento ?? DateTime.MinValue;
            _cajero = cajero_receptor;
            _tula = idtula;
            _headercard = headercard;
            _moneda = moneda;
            _monto = monto;
        }
        
        public ProcesamientoAltoVolumenDetalle() { }               

        #endregion Constructor de Clase

        #region Métodos Públicos       

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return ID.ToString();
        }

        #endregion Overrides
    }
}
