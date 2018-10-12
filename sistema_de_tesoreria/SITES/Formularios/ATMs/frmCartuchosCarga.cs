//
//  @ Project : 
//  @ File Name : frmCartuchosCarga.cs
//  @ Date : 01/08/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using CommonObjects.Clases;

namespace GUILayer
{

    public struct Tupla<T1, T2>
    {
        public readonly T1 Item1;
        public readonly T2 Item2;
        public Tupla(T1 item1, T2 item2) { Item1 = item1; Item2 = item2; }
    }

    public partial class frmCartuchosCarga : Form
    {

        #region Atributos

        #endregion Atributos

        #region Constructor

        public frmCartuchosCarga(BindingList<CargaATM> cargas)
        {
            InitializeComponent();

            Dictionary<Tupla<string, TiposCartucho>, int> cantidades = new Dictionary<Tupla<string, TiposCartucho>, int>();

            foreach (CargaATM carga in cargas)
            {
                TiposCartucho tipo = carga.Tipo;

                foreach (CartuchoCargaATM cartucho in carga.Cartuchos)
                {
                    string denominacion = cartucho.Denominacion.ToString();

                    Tupla<string, TiposCartucho> valores = new Tupla<string, TiposCartucho>(denominacion, tipo);

                    if (cantidades.ContainsKey(valores))
                        cantidades[valores]++;
                    else
                        cantidades.Add(valores, 1);

                }

            }

            foreach (Tupla<string, TiposCartucho> valor in cantidades.Keys)
            {
                string denominacion = valor.Item1;
                string tipo = Enum.GetName(typeof(TiposCartucho), valor.Item2);
                int cantidad = cantidades[valor];

                dgvCantidadCartuchos.Rows.Add(denominacion, tipo, cantidad);
            }
        }



        public frmCartuchosCarga(BindingList<CargaSucursal> cargas)
        {
            InitializeComponent();

            Dictionary<Tupla<string, EstadosCargasSucursales>, int> cantidadessucursales = new Dictionary<Tupla<string, EstadosCargasSucursales>, int>();

            foreach (CargaSucursal carga in cargas)
            {
                EstadosCargasSucursales tipo = carga.Estado;

                foreach (CartuchoCargaSucursal cartucho in carga.Cartuchos)
                {
                    string denominacion = cartucho.Denominacion.ToString();

                    Tupla<string, EstadosCargasSucursales> valores = new Tupla<string, EstadosCargasSucursales>(denominacion, tipo);

                    if (cantidadessucursales.ContainsKey(valores))
                        cantidadessucursales[valores]++;
                    else
                        cantidadessucursales.Add(valores, 1);

                }

            }

            foreach (Tupla<string, EstadosCargasSucursales> valor in cantidadessucursales.Keys)
            {
                string denominacion = valor.Item1;
                string tipo = Enum.GetName(typeof(EstadosCargasSucursales), valor.Item2);
                int cantidad = cantidadessucursales[valor];

                dgvCantidadCartuchos.Rows.Add(denominacion, tipo, cantidad);
            }
        }


        public frmCartuchosCarga(BindingList<PedidoBancos> cargas)
        {
            InitializeComponent();

            Dictionary<Tupla<string, EstadosPedidoBanco>, int> cantidades = new Dictionary<Tupla<string, EstadosPedidoBanco>, int>();

            foreach (PedidoBancos carga in cargas)
            {
                EstadosPedidoBanco tipo = carga.Estado;

                foreach (BolsaCargaBanco cartucho in carga.Bolsas)
                {
                    string denominacion = cartucho.Denominacion.ToString();

                    Tupla<string, EstadosPedidoBanco> valores = new Tupla<string, EstadosPedidoBanco>(denominacion, tipo);

                    if (cantidades.ContainsKey(valores))
                        cantidades[valores]++;
                    else
                        cantidades.Add(valores, 1);

                }

            }

            foreach (Tupla<string, EstadosPedidoBanco> valor in cantidades.Keys)
            {
                string denominacion = valor.Item1;
                string tipo = Enum.GetName(typeof(TiposCartucho), valor.Item2);
                int cantidad = cantidades[valor];

                dgvCantidadCartuchos.Rows.Add(denominacion, tipo, cantidad);
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
