using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using CommonObjects;
using LibreriaMensajes;
using LibreriaReportesOffice;

namespace GUILayer
{
    public partial class frmActualizacionProveedoresATMS : Form
    {


        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<CargaATM> _cargas = new BindingList<CargaATM>();
        private Dictionary<int, Denominacion> _denominaciones = new Dictionary<int, Denominacion>();


        private string _archivo = string.Empty;


        #endregion Atributos

        #region Constructor
        public frmActualizacionProveedoresATMS()
        {
            InitializeComponent();
        }

        #endregion Constructor


        #region Eventos

        /// <summary>
        /// Abrir el archivo de Excel para la importación de los datos
        /// </summary>
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {

                if (ofdArchivoCargas.ShowDialog() == DialogResult.OK)
                {
                    _archivo = ofdArchivoCargas.FileName;

                    this.leerCargas();


                }
                else
                {
                    _archivo = string.Empty;

                    _cargas.Clear();

                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorActualizacionProveedoresATMs");
            }
        }


       

        /// <summary>
        /// Clic en el boton salir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion Eventos


        #region Metodos Privados

        /// <summary>
        /// Leer los datos de los ATM´s
        /// </summary>
        private void leerCargas()
        {
            DocumentoExcel archivo = null;

            try
            {
              

                _cargas.Clear();
                _denominaciones.Clear();

                archivo = new DocumentoExcel(_archivo, false);

                archivo.seleccionarHoja(1);

                // Leer las denominaciones

                //Celda celda_a = archivo.seleccionarCelda(mtbPrimeraCelda.Text);
                //Celda celda_b = archivo.seleccionarCelda(mtbSegundaCelda.Text);



                // Leer la fecha y la primera celda de los número de ATM

                Celda celda_atm = archivo.seleccionarCelda("A2");
                Celda celda_codigo_transportadora = archivo.seleccionarCelda(mtbSegundaCelda.Text);
             
                while (!celda_atm.Valor.Equals(string.Empty))
                {
                    CommonObjects.ATM atm = new ATM();
                    atm.Empresa_encargada = new EmpresaTransporte();
                   
                    //string tipo_cartucho = celda_tipo_atm.Valor.ToLower();
                    string numero_atm = celda_atm.Valor.ToLower();


                    atm.Numero = short.Parse(celda_atm.Valor.ToLower());
                    atm.Empresa_encargada.DB_ID = Convert.ToInt32(celda_codigo_transportadora.Valor.ToLower());

                    if (atm.Empresa_encargada.DB_ID != 5)
                        atm.Externo = true;
                    else
                        atm.Externo = false;
                  
                       
                      //  short numero = short.Parse(celda_atm.Valor);

                       // atm = new CommonObjects.ATM(numero: numero);

                        _mantenimiento.actualizarProveedorATM(ref atm);

                      
                    celda_atm = archivo.seleccionarCelda(celda_atm.Fila + 1, celda_atm.Columna);
                    celda_codigo_transportadora = archivo.seleccionarCelda(celda_atm.Fila, celda_codigo_transportadora.Columna);
                }

                dgvATMs.DataSource = _mantenimiento.listarATMs();

                archivo.mostrar();
                archivo.cerrar();

                // Dar formato a las cargas

                //foreach (DataGridViewRow fila in dgvATMs.Rows)
                //    this.validarCarga(fila);
            }
            catch (Exception ex)
            {
                archivo.mostrar();
                archivo.cerrar();

                throw ex;
            }

        }


        #endregion Metodos Privados

        private void frmActualizacionProveedoresATMS_Load(object sender, EventArgs e)
        {

        }

      


    }
}