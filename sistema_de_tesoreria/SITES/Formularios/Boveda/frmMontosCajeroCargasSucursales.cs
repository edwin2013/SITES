using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects.Clases;
using CommonObjects;

namespace GUILayer.Formularios.Boveda
{
    public partial class frmMontosCajeroCargasSucursales : Form
    {
         #region Atributos

        #endregion Atributos

        #region Constructor

        public frmMontosCajeroCargasSucursales(BindingList<CargaSucursal> cargas)
        {
            InitializeComponent();

            Dictionary<string, decimal> montos = new Dictionary<string, decimal>();
            Dictionary<string, int> cantidades = new Dictionary<string, int>();

            dgvMontos.AutoGenerateColumns = false;
            dgvMontos.DataSource = cargas;


            foreach (CargaSucursal carga in cargas)
            {

                foreach (CartuchoCargaSucursal cartucho in carga.Cartuchos)
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

            foreach (string denominacion in montos.Keys)
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
    }
}
