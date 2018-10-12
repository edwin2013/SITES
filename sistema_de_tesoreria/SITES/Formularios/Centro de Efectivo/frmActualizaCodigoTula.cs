using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmActualizaCodigoTula : Form
    {
        public frmActualizaCodigoTula()
        {
            InitializeComponent();
            //button2.BackColor = System.Drawing.Color.red;
        }

        private void frmActualizaCodigoTula_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCodigoTulaNuevo.Text != "")
            {
                DialogResult = MessageBox.Show("Seguro que desea asignar este código","Confirmación", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes )
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("Digíte un código por favor", "Error", MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
