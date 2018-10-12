using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using LibreriaAccesoDatos;

namespace SiSincData
{
    public partial class frmSincronizacion : Form
    {


        #region Atributos

        CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        #endregion Atributos

        #region Constructor
        public frmSincronizacion()
        {
            InitializeComponent();

            
        }
        #endregion Constructor

        #region Eventos

        private void frmSincronizacion_Load(object sender, EventArgs e)
        {
            try
            {


                string usuario_base = Properties.Settings.Default.UsuarioBD;
                string password_base = Properties.Settings.Default.PassBD;
                string base_datos = Properties.Settings.Default.BaseDatos;
                string servidor = Properties.Settings.Default.Server;

                // Realizar la conexión con la base de datos y verificar que el usuario este registrado

                ManejadorBD.Instancia.conectarse(servidor, base_datos, usuario_base, password_base);
                _coordinacion.ActualizarCargasATMRoadnet(DateTime.Now);
                _coordinacion.ActualizarCargasSucursalesRoadnet(DateTime.Now);
                _coordinacion.ActualizarCargasBancosRoadnet(DateTime.Now);


                DateTime manana = DateTime.Today.AddDays(1);


                // Actualiza los datos del día de mañana

                _coordinacion.ActualizarCargasATMRoadnet(manana);
                _coordinacion.ActualizarCargasSucursalesRoadnet(manana);
                _coordinacion.ActualizarCargasBancosRoadnet(manana);


  


                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion Eventos


    }
}
