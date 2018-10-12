using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{
    public partial class frmMantenimientoRecepcionBolsas : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private Bolsa _bolsa = null;
        Colaborador _coordinador = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoRecepcionBolsas()
        {
           
            cboDenominacion.SelectedIndex = (byte)Areas.CentroEfectivo;
        }

        public frmMantenimientoRecepcionBolsas(Bolsa bolsa)
        {
            

            _bolsa = bolsa;

      
           /// cboDenominacion.Text = bolsa.Denominacion.ToString();
        }

        public frmMantenimientoRecepcionBolsas(Bolsa bolsa, Colaborador coordinador)
        {
           

            _bolsa = bolsa;
            _coordinador = coordinador;

            try{

            //cboDenominacion.Text = _bolsa.Denominacion.ToString();

           
                btnGuardar.Enabled = false;
                gbDatos.Enabled = false;
              

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
                this.Close();
            }

        }
       
        #endregion Constructor



        private void frmMantenimientoRecepcionBolsas_Load(object sender, EventArgs e)
        {

        }
    }
}
