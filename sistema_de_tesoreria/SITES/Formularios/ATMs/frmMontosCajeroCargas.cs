//
//  @ Project : 
//  @ File Name : frmMontosCajeroCargas.cs
//  @ Date : 05/10/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;

using CommonObjects;

namespace GUILayer
{

    public partial class frmMontosCajeroCargas : Form
    {

        #region Atributos

        #endregion Atributos

        #region Constructor

        public frmMontosCajeroCargas(BindingList<CargaATM> cargas)
        {
            InitializeComponent();

            Dictionary<string, decimal> montos = new Dictionary<string, decimal>();
            Dictionary<string, int> cantidades = new Dictionary<string, int>();

            foreach (CargaATM carga in cargas)
            {

                foreach (CartuchoCargaATM cartucho in carga.Cartuchos)
                {
                    Denominacion denominacion = cartucho.Denominacion;
                    string nombre_denominacion = denominacion.ToString();
                    decimal monto_cartucho = cartucho.Cantidad_carga * denominacion.Valor;

                    if (montos.ContainsKey(nombre_denominacion))
                    {
                        montos[nombre_denominacion] += monto_cartucho;
                        cantidades[nombre_denominacion] += cartucho.Cantidad_carga;
                    }
                    else
                    {
                        montos.Add(nombre_denominacion, monto_cartucho);
                        cantidades.Add(nombre_denominacion, cartucho.Cantidad_carga);
                    }

                }

            }

            foreach(string denominacion in montos.Keys)
            {
                decimal monto = montos[denominacion];
                int cantidad = cantidades[denominacion];

                dgvMontos.Rows.Add(denominacion, monto, cantidad);
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Eventos

        private void pbLogo_Click(object sender, EventArgs e)
        {

        }

    }

}
