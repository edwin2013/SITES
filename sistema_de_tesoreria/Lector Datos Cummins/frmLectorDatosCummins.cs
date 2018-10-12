using System;
using System.Windows.Forms;
using System.IO.Ports;

using LibreriaMensajes;

namespace Lector_Datos_Cummins
{

    public partial class frmLectorDatosCummins : Form
    {

        private string _buffer = string.Empty;

        public frmLectorDatosCummins()
        {
            InitializeComponent();

            try
            {
                cboParidad.Items.AddRange(Enum.GetNames(typeof(Parity)));
                cboBitsParada.Items.AddRange(Enum.GetNames(typeof(StopBits)));

                cboNombre.Items.Clear();
                cboNombre.Items.AddRange(SerialPort.GetPortNames());

                // Abrir el puerto

                spPuerto.Open();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorPuertoConexion");
            }
            
        }

        private void spPuerto_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            try
            {
                _buffer += spPuerto.ReadExisting();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorPuertoConexion");
            }

        }

        private void spPuerto_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {

            try
            {
                _buffer += spPuerto.ReadExisting();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorPuertoConexion");
            }

        }

        /// <summary>
        /// Clic en el botón de pesar.
        /// </summary>
        private void btnLeer_Click(object sender, EventArgs e)
        {
            txtDatos.Text = _buffer;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                spPuerto.Close();

                spPuerto.BaudRate = int.Parse(cboBaudrate.Text);
                spPuerto.DataBits = int.Parse(cboBitsDatos.Text);
                spPuerto.Parity = (Parity)Enum.Parse(typeof(Parity), cboParidad.Text);
                spPuerto.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cboBitsParada.Text);
                spPuerto.PortName = cboNombre.Text;

                spPuerto.Open();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorPuertoConexion");
            }

        }

    }

    public class LecturaCummins
    {
        private decimal cantidad_billetes;
        private int total_billetes;

        private decimal cantidad_billetes_cincuenta_mil_colones = 0;
        private decimal cantidad_billetes_veinte_mil_colones = 0;
        private decimal cantidad_billetes_diez_mil_colones = 0;
        private decimal cantidad_billetes_cinco_mil_colones = 0;
        private decimal cantidad_billetes_dos_mil_colones = 0;
        private decimal cantidad_billetes_mil_colones = 0;

        private decimal cantidad_billetes_cien_dolare = 0;
        private decimal cantidad_billetes_veinte_dolares = 0;
        private decimal cantidad_billetes_diez_dolares = 0;
        private decimal cantidad_billetes_cinco_dolares = 0;
        private decimal cantidad_billetes_un_dolares = 0;

        private decimal total_billetes_cincuenta_mil_colones = 0;
        private decimal total_billetes_veinte_mil_colones = 0;
        private decimal total_billetes_diez_mil_colones = 0;
        private decimal total_billetes_cinco_mil_colones = 0;
        private decimal total_billetes_dos_mil_colones = 0;
        private decimal total_billetes_mil_colones = 0;

        private decimal total_billetes_cien_dolare = 0;
        private decimal total_billetes_veinte_dolares = 0;
        private decimal total_billetes_diez_dolares = 0;
        private decimal total_billetes_cinco_dolares = 0;
        private decimal total_billetes_un_dolares = 0;
    }

}
