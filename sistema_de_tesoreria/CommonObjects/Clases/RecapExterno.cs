//
//  @ Project : 
//  @ File Name : RecapInterno.cs
//  @ Date : 29/03/2012
//  @ Author : Erick Chavarría 
//

using System;

namespace CommonObjects
{

    public class RecapExterno 
    {

        #region Atributos Privados

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Monedas _moneda;

        public Monedas Moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }

        private int _referencia;

        public int Referencia
        {
            get { return _id; }
            set { _id = value; }
        }

        private long? _cuenta;

        public long? Cuenta
        {
            get { return _cuenta; }
            set { _cuenta = value; }
        }

        private bool _atm;

        public bool ATM
        {
            get { return _atm; }
            set { _atm = value; }
        }

        private bool _matriz;

        public bool Matriz
        {
            get { return _matriz; }
            set { _matriz = value; }
        }

        private Manifiesto _manifiesto;

        public Manifiesto Manifiesto
        {
            get { return _manifiesto; }
            set { _manifiesto = value; }
        }

        private decimal _colones_cincuenta_mil;

        public decimal Colones_cincuenta_mil
        {
            get { return _colones_cincuenta_mil; }
            set { _colones_cincuenta_mil = value; }
        }

        private decimal _colones_veinte_mil;

        public decimal Colones_veinte_mil
        {
            get { return _colones_veinte_mil; }
            set { _colones_veinte_mil = value; }
        }

        private decimal _colones_diez_mil;

        public decimal Colones_diez_mil
        {
            get { return _colones_diez_mil; }
            set { _colones_diez_mil = value; }
        }

        private decimal _colones_cinco_mil;

        public decimal Colones_cinco_mil
        {
            get { return _colones_cinco_mil; }
            set { _colones_cinco_mil = value; }
        }

        private decimal _colones_dos_mil;

        public decimal Colones_dos_mil
        {
            get { return _colones_dos_mil; }
            set { _colones_dos_mil = value; }
        }

        private decimal _colones_mil;

        public decimal Colones_mil
        {
            get { return _colones_mil; }
            set { _colones_mil = value; }
        }
        
        private decimal _dolares_cien;

        public decimal Dolares_cien
        {
            get { return _dolares_cien; }
            set { _dolares_cien = value; }
        }

        private decimal _dolares_cincuenta;

        public decimal Dolares_cincuenta
        {
            get { return _dolares_cincuenta; }
            set { _dolares_cincuenta = value; }
        }

        private decimal _dolares_veinte;

        public decimal Dolares_veinte
        {
            get { return _dolares_veinte; }
            set { _dolares_veinte = value; }
        }

        private decimal _dolares_diez;

        public decimal Dolares_diez
        {
            get { return _dolares_diez; }
            set { _dolares_diez = value; }
        }

        private decimal _dolares_cinco;

        public decimal Dolares_cinco
        {
            get { return _dolares_cinco; }
            set { _dolares_cinco = value; }
        }

        private decimal _dolares_uno;

        public decimal Dolares_uno
        {
            get { return _dolares_uno; }
            set { _dolares_uno = value; }
        }

        private decimal _euros_cien;

        public decimal Euros_cien
        {
            get { return _euros_cien; }
            set { _euros_cien = value; }
        }

        private decimal _euros_cincuenta;

        public decimal Euros_cincuenta
        {
            get { return _euros_cincuenta; }
            set { _euros_cincuenta = value; }
        }

        private decimal _euros_veinte;

        public decimal Euros_veinte
        {
            get { return _euros_veinte; }
            set { _euros_veinte = value; }
        }

        private decimal _euros_diez;

        public decimal Euros_diez
        {
            get { return _euros_diez; }
            set { _euros_diez = value; }
        }

        private decimal _euros_cinco;

        public decimal Euros_cinco
        {
            get { return _euros_cinco; }
            set { _euros_cinco = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public RecapExterno(int id, Monedas moneda, int referencia, long? cuenta,
                            Manifiesto manifiesto, bool atm, bool matriz,
                            decimal colones_cincuenta_mil, decimal colones_veinte_mil,
                            decimal colones_diez_mil, decimal colones_cinco_mil,
                            decimal colones_dos_mil, decimal colones_mil, decimal dolares_cien,
                            decimal dolares_cincuenta, decimal dolares_veinte, decimal dolares_diez,
                            decimal dolares_cinco, decimal dolares_uno, decimal euros_cien,
                            decimal euros_cincuenta, decimal euros_veinte, decimal euros_diez,
                            decimal euros_cinco)
        {
            _id = id;
            _moneda = moneda;
            _referencia = referencia;
            _cuenta = cuenta;
            _manifiesto = manifiesto;
            _atm = atm;
            _matriz = matriz;

            _colones_cincuenta_mil = colones_cincuenta_mil;
            _colones_veinte_mil = colones_veinte_mil;
            _colones_diez_mil = colones_diez_mil;
            _colones_cinco_mil = colones_cinco_mil;
            _colones_dos_mil = colones_dos_mil;
            _colones_mil = colones_mil;
            _dolares_cien = dolares_cien;
            _dolares_cincuenta = dolares_cincuenta;
            _dolares_veinte = dolares_veinte;
            _dolares_diez = dolares_diez; 
            _dolares_cinco = dolares_cinco;
            _dolares_uno = dolares_uno;
            _euros_cien = euros_cien;
            _euros_cincuenta = euros_cincuenta;
            _euros_veinte = euros_veinte;
            _euros_diez = euros_diez;
            _euros_cinco = euros_cinco;
        }

        public RecapExterno(Monedas moneda, int referencia, long? cuenta, Manifiesto manifiesto,
                            bool atm, bool matriz,
                            decimal colones_cincuenta_mil, decimal colones_veinte_mil,
                            decimal colones_diez_mil, decimal colones_cinco_mil,
                            decimal colones_dos_mil, decimal colones_mil, decimal dolares_cien,
                            decimal dolares_cincuenta, decimal dolares_veinte, decimal dolares_diez,
                            decimal dolares_cinco, decimal dolares_uno, decimal euros_cien,
                            decimal euros_cincuenta, decimal euros_veinte, decimal euros_diez,
                            decimal euros_cinco)
        {
            _moneda = moneda;
            _referencia = referencia;
            _cuenta = cuenta;
            _manifiesto = manifiesto;
            _atm = atm;
            _matriz = matriz;

            _colones_cincuenta_mil = colones_cincuenta_mil;
            _colones_veinte_mil = colones_veinte_mil;
            _colones_diez_mil = colones_diez_mil;
            _colones_cinco_mil = colones_cinco_mil;
            _colones_dos_mil = colones_dos_mil;
            _colones_mil = colones_mil;
            _dolares_cien = dolares_cien;
            _dolares_cincuenta = dolares_cincuenta;
            _dolares_veinte = dolares_veinte;
            _dolares_diez = dolares_diez;
            _dolares_cinco = dolares_cinco;
            _dolares_uno = dolares_uno;
            _euros_cien = euros_cien;
            _euros_cincuenta = euros_cincuenta;
            _euros_veinte = euros_veinte;
            _euros_diez = euros_diez;
            _euros_cinco = euros_cinco;
        }

        public RecapExterno() { }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _referencia.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            RecapExterno recap = (RecapExterno)obj;

            if (this.Id != recap.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
