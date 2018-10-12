//
//  @ Project : 
//  @ File Name : PlanillaCEF.cs
//  @ Date : 16/11/2011
//  @ Author : Erick Chavarría 
//

using System;

namespace CommonObjects
{

    public interface PlanillaCEF
    {

        #region Atributos

        Colaborador Cajero
        {
            get;
            set;
        }

        Colaborador Digitador
        {
            get;
            set;
        }

        Colaborador Coordinador
        {
            get;
            set;
        }

        PuntoVenta Punto_venta
        {
            get;
            set;
        }

        decimal Monto_colones
        {
            get;
            set;
        }

        decimal Monto_dolares
        {
            get;
            set;
        }



        decimal Monto_Euros
        {
            get;
            set;
        }

        short Depositos
        {
            get;
            set;
        }

        DateTime Fecha_procesamiento
        {
            get;
            set;
        }

        #endregion Atributos

    }

}
