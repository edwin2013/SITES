using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
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
    public partial class frmPantallaResumenManifiestoPBV : Form
    {
        String datos = "";
        private Boolean permisosup = false;
        //danilo--
        public Boolean mostrarResumenManifiesto = false;
        //--
        ProcesamientoBajoVolumenManifiesto _manifiesto = null;
        Colaborador _colaborador = null;
        string comentarioincons = "";
        private int _coordinador = 0;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        public frmPantallaResumenManifiestoPBV(ProcesamientoBajoVolumenManifiesto manifiesto, Colaborador colaborador)
        {
            InitializeComponent();
            _manifiesto = manifiesto;
            _colaborador = colaborador;
        }

        private void frmPantallaResumenManifiestoPBV_Load(object sender, EventArgs e)
        {
            datos = (string)this.Tag;
            String[] datossplit = datos.Split('\n');
            for (int i = 0; i < datossplit.Length; i++)
            {
                if (datossplit[i].Equals(""))
                {
                    txtmensaje.AppendText(Environment.NewLine);                    
                }
                else
                {
                    txtmensaje.AppendText(datossplit[i].ToString());
                    txtmensaje.AppendText(Environment.NewLine);
                }
            }
        }

        public void permisocoordinadorinconsistencia(int ID_Coordinador, string comentarios)
        {
            permisosup = true;
            _coordinador = ID_Coordinador;
            comentarioincons = comentarios;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_manifiesto.Monto_Diferencia_Colones != 0)
                {
                    if (Math.Abs(_manifiesto.Monto_Diferencia_Colones) > 1000)
                    {
                        permisosup = false;
                        //danilo-- 
                        mostrarResumenManifiesto = false;
                        //--
                        while (permisosup==false)
                        {
                            frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(9, _colaborador);
                            formulario.ShowDialog(this);
                            //danilo-- 
                            if (mostrarResumenManifiesto) return;
                            //--
                        }
                        //break;
                        _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, comentarioincons, Monedas.Colones);
                    }
                    else
                    {
                        _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, "", Monedas.Colones);
                    }
                    //errmanifiesto = 1;
                }

                if (_manifiesto.Monto_Diferencia_Dolares != 0)
                {
                    if (Math.Abs(_manifiesto.Monto_Diferencia_Dolares) > 2)
                    {
                        permisosup = false;
                        while (permisosup == false)
                        {
                            frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(9, _colaborador);
                            formulario.ShowDialog(this);
                        }
                        _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, comentarioincons, Monedas.Dolares);
                    }
                    else
                    {
                        _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, "", Monedas.Dolares);
                    }
                    //errmanifiesto = 1;
                }

                if (_manifiesto.Monto_Diferencia_Euros != 0)
                {
                    if (Math.Abs(_manifiesto.Monto_Diferencia_Euros) > 2)
                    {
                        permisosup = false;
                        while (permisosup == false)
                        {
                            frmValidacionCoordinadorCE formulario = new frmValidacionCoordinadorCE(9, _colaborador);
                            formulario.ShowDialog(this);
                        }
                        _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, comentarioincons, Monedas.Euros);
                    }
                    else
                    {
                        _mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, "", Monedas.Euros);
                    }
                    //_mantenimiento.RegistrarInconsistenciaBajoVolumenManifiesto(ref _manifiesto, ref _colaborador, "", Monedas.Euros);
                    //errmanifiesto = 1;
                }                
            }
            catch(Exception ex)
            {
                MessageBox.Show("botoncerrar error:" + ex.Message);
            }
            this.Close();
        }
    }
}
