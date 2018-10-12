//
//  @ Project : 
//  @ File Name : frmSeleccionGrafico.cs
//  @ Date : 07/06/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CommonObjects;
using CommonObjects.Graficos;

namespace GUILayer
{

    public partial class frmSeleccionGrafico : Form
    {

        #region Atributos

        private Grafico _grafico;

        public Grafico Grafico
        {
            get { return _grafico; }
            set { _grafico = value; }
        }

        #endregion Atributos

        #region Contructor

        public frmSeleccionGrafico(Reporte reporte)
        {
            InitializeComponent();

            lstGraficos.DataSource = reporte.Graficos;
            lstGraficos.SelectedIndex = 0;
        }

        #endregion Contructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _grafico = (Grafico)lstGraficos.SelectedItem;
        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Doble clic en la lista de gráficos.
        /// </summary>
        private void lstGraficos_DoubleClick(object sender, EventArgs e)
        {
            this.AcceptButton.PerformClick();
        }

        #endregion Eventos

    }

}
