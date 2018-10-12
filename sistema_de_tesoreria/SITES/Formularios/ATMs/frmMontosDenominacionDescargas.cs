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

    public partial class frmMontosDenominacionDescargas : Form
    {

        #region Constructor

        public frmMontosDenominacionDescargas(BindingList<DescargaATM> descargas)
        {
            InitializeComponent();

            Dictionary<Denominacion, decimal> montos = new Dictionary<Denominacion, decimal>();
            Dictionary<Denominacion, int> cantidades = new Dictionary<Denominacion, int>();

            foreach (DescargaATM descarga in descargas)
            {

                foreach (DetalleDescargaATM detalle in descarga.Detalles)
                {
                    Denominacion denominacion = detalle.Denominacion;
                    decimal monto_cartucho = detalle.Cantidad_descargada * denominacion.Valor;

                    if (montos.ContainsKey(denominacion))
                    {
                        montos[denominacion] += monto_cartucho;
                        cantidades[denominacion] += detalle.Cantidad_descargada;
                    }
                    else
                    {
                        montos.Add(denominacion, monto_cartucho);
                        cantidades.Add(denominacion, detalle.Cantidad_descargada);
                    }

                }

            }

            foreach (Denominacion denominacion in montos.Keys)
            {
                decimal monto = montos[denominacion];
                int cantidad = cantidades[denominacion];

                dgvMontos.Rows.Add(denominacion, monto, cantidad);
            }

        }

        public frmMontosDenominacionDescargas(BindingList<DescargaATMFull> descargas)
        {
            InitializeComponent();

            Dictionary<Denominacion, decimal> montos = new Dictionary<Denominacion, decimal>();
            Dictionary<Denominacion, int> cantidades = new Dictionary<Denominacion, int>();

            foreach (DescargaATMFull descarga in descargas)
            {

                foreach (DetalleDescargaATMFull detalle in descarga.Detalles)
                {
                    Denominacion denominacion = detalle.Denominacion;
                    decimal monto_cartucho = detalle.Cantidad_descargada * denominacion.Valor;

                    if (montos.ContainsKey(denominacion))
                    {
                        montos[denominacion] += monto_cartucho;
                        cantidades[denominacion] += detalle.Cantidad_descargada;
                    }
                    else
                    {
                        montos.Add(denominacion, monto_cartucho);
                        cantidades.Add(denominacion, detalle.Cantidad_descargada);
                    }

                }

            }

            foreach (Denominacion denominacion in montos.Keys)
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

        /// <summary>
        /// Se agrega un monto.
        /// </summary>
        private void dgvMontos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvMontos.Rows[e.RowIndex + contador];
                Denominacion denominacion = (Denominacion)fila.Cells[Denominacion.Index].Value;
                int cantidad = (int)fila.Cells[Formulas.Index].Value;

                int cantidad_mesa = 100 * (int)Math.Floor((decimal)(cantidad / 100));
                int cantidad_cola = cantidad - cantidad_mesa;

                decimal monto_cola = cantidad_cola * denominacion.Valor;
                decimal monto_mesa = cantidad_mesa * denominacion.Valor;

                fila.Cells[CantidadCola.Index].Value = cantidad_cola;
                fila.Cells[CantidadMesa.Index].Value = cantidad_mesa;
                fila.Cells[MontosCola.Index].Value = monto_cola;
                fila.Cells[MontosMesa.Index].Value = monto_mesa;
            }

        }

        #endregion Eventos

    }

}
