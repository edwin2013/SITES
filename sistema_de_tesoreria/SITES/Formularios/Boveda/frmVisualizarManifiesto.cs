using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects;
using CommonObjects.Clases;

namespace GUILayer.Formularios.Boveda
{
    public partial class frmVisualizarManifiesto : Form
    {

        #region Constructor
        public frmVisualizarManifiesto(DescargaATM carga)
        {
            InitializeComponent();

            axAcroPDF1.src = @"\\10.120.131.100\Manifiestos\ATM-"+carga.Manifiesto+".pdf";
        }


        public frmVisualizarManifiesto(CargaSucursal carga)
        {
            InitializeComponent();

            axAcroPDF1.src = @"\\10.120.131.100\ECARD\Final_Validacion\FINALSUCURSAL-" + carga.ID + ".pdf";
        }

        public frmVisualizarManifiesto(PedidoBancos carga)
        {
            InitializeComponent();

            axAcroPDF1.src = @"\\10.120.131.100\ECARD\Final_Validacion\FINALBANCO-" + carga.ID + ".pdf";
        }

        #endregion Constructor

    }
}
