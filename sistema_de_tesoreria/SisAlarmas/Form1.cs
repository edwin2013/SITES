using BussinessLayer;
using LibreriaAccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisAlarmas
{
    public partial class Form1 : Form
    {
        #region Atributos

        CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        #endregion Atributos

        #region Constructor
        public Form1()
        {
            InitializeComponent();


        }
        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Sincroniza los datos 
        /// </summary>
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
                _coordinacion.ActualizarAlarmasPapel(DateTime.Now);



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
