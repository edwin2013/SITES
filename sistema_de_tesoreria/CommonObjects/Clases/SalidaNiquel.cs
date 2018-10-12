//
//  @ Project : 
//  @ File Name : MovimientoNiquel.cs
//  @ Date : 22/08/2011
//  @ Author : Erick Chavarría 

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonObjects
{

    public abstract class SalidaNiquel : MovimientoNiquel
    {

        #region Atributos Privados

        private Cliente _cliente;

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        #endregion Atributos Privados

        #region Constructor de Clase

        public SalidaNiquel(int id, Cliente cliente, decimal colones_cincuenta_mil, decimal colones_veinte_mil, decimal colones_diez_mil,
                            decimal colones_cinco_mil, decimal colones_dos_mil, decimal colones_mil, decimal colones_quinientos,
                            decimal colones_cien, decimal colones_cincuenta, decimal colones_veinticinco, decimal colones_diez,
                            decimal colones_cinco, decimal dolares_cien, decimal dolares_cincuenta, decimal dolares_veinte,
                            decimal dolares_diez,  decimal dolares_cinco, decimal dolares_uno)
        {

            //Id = id;
            //Cliente = cliente;

            //Colones_cincuenta_mil = colones_cincuenta_mil;
            //Colones_veinte_mil = colones_veinte_mil;
            //Colones_diez_mil = colones_diez_mil;
            //Colones_cinco_mil = colones_cinco_mil;
            //Colones_dos_mil = colones_dos_mil;
            //Colones_mil = colones_mil;
            //Colones_quinientos = colones_quinientos;
            //Colones_cien = colones_cien;
            //Colones_veinticinco = colones_veinticinco;
            //Colones_diez = colones_diez;
            //Colones_cinco = colones_cinco;

            //Dolares_cien = dolares_cien;
            //Dolares_cincuenta = dolares_cincuenta;
            //Dolares_veinte = dolares_veinte;
            //Dolares_diez = dolares_diez;
            //Dolares_cinco = dolares_cinco;
        }

        public SalidaNiquel(Cliente cliente, decimal colones_cincuenta_mil, decimal colones_veinte_mil, decimal colones_diez_mil,
                            decimal colones_cinco_mil, decimal colones_dos_mil, decimal colones_mil, decimal colones_quinientos,
                            decimal colones_cien, decimal colones_cincuenta, decimal colones_veinticinco, decimal colones_diez,
                            decimal colones_cinco, decimal dolares_cien, decimal dolares_cincuenta, decimal dolares_veinte,
                            decimal dolares_diez, decimal dolares_cinco, decimal dolares_uno)
        {
            Cliente = cliente;

            //Colones_cincuenta_mil = colones_cincuenta_mil;
            //Colones_veinte_mil = colones_veinte_mil;
            //Colones_diez_mil = colones_diez_mil;
            //Colones_cinco_mil = colones_cinco_mil;
            //Colones_dos_mil = colones_dos_mil;
            //Colones_mil = colones_mil;
            //Colones_quinientos = colones_quinientos;
            //Colones_cien = colones_cien;
            //Colones_veinticinco = colones_veinticinco;
            //Colones_diez = colones_diez;
            //Colones_cinco = colones_cinco;

            //Dolares_cien = dolares_cien;
            //Dolares_cincuenta = dolares_cincuenta;
            //Dolares_veinte = dolares_veinte;
            //Dolares_diez = dolares_diez;
            //Dolares_cinco = dolares_cinco;
        }

        #endregion Constructor de Clase

        #region Métodos Públicos
 
        #endregion Métodos Públicos

        #region Overrides

        public override string ToString()
        {
            return _cliente.Nombre;
        }

        #endregion Overrides

    }

}
