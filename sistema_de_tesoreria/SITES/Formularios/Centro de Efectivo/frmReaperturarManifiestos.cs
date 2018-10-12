using BussinessLayer;
using CommonObjects;
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
    public partial class frmReaperturarManifiestos : Form
    {

        #region Atributos

        private Colaborador _colaborador = null;
        private String _codigomanifiesto = "";
        private AtencionBL _atencion_BL = AtencionBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmReaperturarManifiestos(Colaborador colaborador)
        {
            InitializeComponent();
            _colaborador = colaborador;
        }

        #endregion Constructor 

        #region Eventos

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCodigoManifiesto.Text.Equals(String.Empty))
                {
                    if (_atencion_BL.VerificarManifiestoProcesado(txtCodigoManifiesto.Text))
                    {
                        if (MessageBox.Show("¿Desea aplicar la acción seleccionada sobre el manifiesto?", "Confirmación de acción sobre manifiesto", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            _codigomanifiesto = txtCodigoManifiesto.Text;
                            if (rdbReaperturarManifiesto.Checked)
                            {
                                _atencion_BL.PROAReaperturarManifiesto(_codigomanifiesto);
                                if (_atencion_BL.VerificarManifiestoProcesado(txtCodigoManifiesto.Text) == false)
                                    MessageBox.Show("No se pudo reaperturar el manifiesto");
                                else
                                    MessageBox.Show("Se reaperturar el manifiesto solicitado.");
                            }
                            else
                            {
                                string msg = _atencion_BL.PROABorrarManifiesto(_codigomanifiesto, _colaborador.ID);
                                if (!msg.Equals(string.Empty))
                                    MessageBox.Show(msg);
                                if (_atencion_BL.VerificarManifiestoProcesado(txtCodigoManifiesto.Text))                                
                                    MessageBox.Show("No se pudo eliminar el manifiesto procesado.");                                
                                else
                                    MessageBox.Show("Se eliminó el manifiesto procesado.");
                            }
                            txtCodigoManifiesto.Text = "";
                            txtCodigoManifiesto.Focus();
                        }
                    }
                    else
                    {
                        epError.SetError(txtCodigoManifiesto, "No se encontró ningún manifiesto procesado con el código indicado");
                    }                    
                }
                else
                {
                    epError.SetError(txtCodigoManifiesto, "El campo del código del manifiesto se encuentra en blanco");                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }                            
        }

        #endregion Eventos

        private void txtCodigoManifiesto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                epError.SetError(txtCodigoManifiesto, "");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReaperturarManifiestos_Load(object sender, EventArgs e)
        {

        }
    }
}
