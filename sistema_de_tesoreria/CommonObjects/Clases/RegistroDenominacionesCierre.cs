//
//  @ Project : 
//  @ File Name : RegistroDenominacionesCierre.cs
//  @ Date : 11/10/2011
//  @ Author : Erick Chavarría 
//

using System;

namespace CommonObjects
{

    public class RegistroDenominacionesCierre
    {

        #region Atributos Privados

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Colaborador _cajero;

        public Colaborador Cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
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

        private decimal _colones_quinientos;

        public decimal Colones_quinientos
        {
            get { return _colones_quinientos; }
            set { _colones_quinientos = value; }
        }

        private decimal _colones_cien;

        public decimal Colones_cien
        {
            get { return _colones_cien; }
            set { _colones_cien = value; }
        }

        private decimal _colones_cincuenta;

        public decimal Colones_cincuenta
        {
            get { return _colones_cincuenta; }
            set { _colones_cincuenta = value; }
        }

        private decimal _colones_veinticinco;

        public decimal Colones_veinticinco
        {
            get { return _colones_veinticinco; }
            set { _colones_veinticinco = value; }
        }

        private decimal _colones_diez;

        public decimal Colones_diez
        {
            get { return _colones_diez; }
            set { _colones_diez = value; }
        }

        private decimal _colones_cinco;

        public decimal Colones_cinco
        {
            get { return _colones_cinco; }
            set { _colones_cinco = value; }
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

        private EmpresaTransporte _transportadora;
        public EmpresaTransporte Transportadora
        {
            get { return _transportadora; }
            set { _transportadora = value;  }
        }

        private Cliente _cliente;
        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }


        private bool _procesamiento_externo;
        public bool ProcesamientoExterno
        { 
            set { _procesamiento_externo = value; }
            get { return _procesamiento_externo; }
        }
        #endregion Atributos Privados

        #region Constructor de Clase

        public RegistroDenominacionesCierre(int id, Colaborador cajero, Colaborador coordinador, DateTime fecha,
                                            decimal colones_cincuenta_mil, decimal colones_veinte_mil,
                                            decimal colones_diez_mil, decimal colones_cinco_mil,
                                            decimal colones_dos_mil, decimal colones_mil, decimal colones_quinientos,
                                            decimal colones_cien, decimal colones_cincuenta, decimal colones_veinticinco,
                                            decimal colones_diez, decimal colones_cinco, decimal dolares_cien,
                                            decimal dolares_cincuenta, decimal dolares_veinte, decimal dolares_diez, 
                                            decimal dolares_cinco, decimal dolares_uno)
        {
            _id = id;
            _cajero = cajero;
            _coordinador = coordinador;
            _fecha = fecha;
            _colones_cincuenta_mil = colones_cincuenta_mil;
            _colones_veinte_mil = colones_veinte_mil;
            _colones_diez_mil = colones_diez_mil;
            _colones_cinco_mil = colones_cinco_mil;
            _colones_dos_mil = colones_dos_mil;
            _colones_mil = colones_mil;
            _colones_quinientos = colones_quinientos;
            _colones_cien = colones_cien;
            _colones_cincuenta = colones_cincuenta;
            _colones_veinticinco = colones_veinticinco;
            _colones_diez = colones_diez;
            _colones_cinco = colones_cinco;
            _dolares_cien = dolares_cien;
            _dolares_cincuenta = dolares_cincuenta;
            _dolares_veinte = dolares_veinte;
            _dolares_diez = dolares_diez; 
            _dolares_cinco = dolares_cinco;
            _dolares_uno = dolares_uno;
        }

        public RegistroDenominacionesCierre(Colaborador cajero, Colaborador coordinador, DateTime fecha,
                                            decimal colones_cincuenta_mil, decimal colones_veinte_mil,
                                            decimal colones_diez_mil, decimal colones_cinco_mil,
                                            decimal colones_dos_mil, decimal colones_mil, decimal colones_quinientos,
                                            decimal colones_cien, decimal colones_cincuenta, decimal colones_veinticinco,
                                            decimal colones_diez, decimal colones_cinco, decimal dolares_cien,
                                            decimal dolares_cincuenta, decimal dolares_veinte, decimal dolares_diez,
                                            decimal dolares_cinco, decimal dolares_uno)
        {
            _cajero = cajero;
            _coordinador = coordinador;
            _fecha = fecha;
            _colones_cincuenta_mil = colones_cincuenta_mil;
            _colones_veinte_mil = colones_veinte_mil;
            _colones_diez_mil = colones_diez_mil;
            _colones_cinco_mil = colones_cinco_mil;
            _colones_dos_mil = colones_dos_mil;
            _colones_mil = colones_mil;
            _colones_quinientos = colones_quinientos;
            _colones_cien = colones_cien;
            _colones_cincuenta = colones_cincuenta;
            _colones_veinticinco = colones_veinticinco;
            _colones_diez = colones_diez;
            _colones_cinco = colones_cinco;
            _dolares_cien = dolares_cien;
            _dolares_cincuenta = dolares_cincuenta;
            _dolares_veinte = dolares_veinte;
            _dolares_diez = dolares_diez;
            _dolares_cinco = dolares_cinco;
            _dolares_uno = dolares_uno;
        }

        public RegistroDenominacionesCierre(Colaborador cajero, Colaborador coordinador, DateTime fecha)
        {
            _cajero = cajero;
            _coordinador = coordinador;
            _fecha = fecha;
        }

        public RegistroDenominacionesCierre() { }

        #endregion Constructor de Clase

        #region Métodos Públicos

        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _cajero.Nombre;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            RegistroDenominacionesCierre registro = (RegistroDenominacionesCierre)obj;

            if (_id != registro.Id) return false;

            return true;
        }

        #endregion Overrides

    }

}
