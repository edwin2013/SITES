using CommonObjects.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Blindados
{
    public partial class frmVisualizacionImagenRevisionVehiculo : Form
    {
        public frmVisualizacionImagenRevisionVehiculo(RevisionVehiculo r)
        {
          

            InitializeComponent();

            try
            {

                Image imagen = System.Drawing.Image.FromFile(@"\\10.120.9.20\\Blindados\\Fotos\\" + r.RutaImagen);
                pbFotoVehiculo.Image = System.Drawing.Image.FromFile(@"\\10.120.9.20\\Blindados\\Fotos\\" + r.RutaImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show("La imagen no pudo se localizada");
                //this.Close();
            }
        }



        public frmVisualizacionImagenRevisionVehiculo(RevisionFinalPortavalor r)
        {


            InitializeComponent();

            try
            {

                Image imagen = System.Drawing.Image.FromFile(@"\\10.120.9.20\\Blindados\\Fotos\\" + r.RutaImagen);
                pbFotoVehiculo.Image = System.Drawing.Image.FromFile(@"\\10.120.9.20\\Blindados\\Fotos\\" + r.RutaImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show("La imagen no pudo se localizada");
                //this.Close();
            }
        }
        private void pbFotoVehiculo_Click(object sender, EventArgs e)
        {

        }
    }
}
