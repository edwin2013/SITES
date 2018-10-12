using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects;
using LibreriaMensajes;
using LibreriaReportesOffice;
using BussinessLayer;
using CommonObjects.Clases;

namespace GUILayer.Formularios.ATMs
{
    public partial class frmCargaMasivaFallas : Form
    {
        #region Atributos

        private Colaborador _usuario = new Colaborador();
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private string _archivo = string.Empty;
        private BindingList<Cartucho> _cartuchos = new BindingList<Cartucho>();
        private List<int> _filas_incorrectas = new List<int>();

        #endregion Atributos

        #region Constructor
        public frmCargaMasivaFallas(Colaborador usuario)
        {

            _usuario = usuario;
            InitializeComponent();
        }


        #endregion Constructor

        #region Eventos
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {

                if (ofdMontosCargas.ShowDialog() == DialogResult.OK)
                {
                    _archivo = ofdMontosCargas.FileName;

                    this.generarCargas();

                    btnAceptar.Enabled = dgvCargas.Rows.Count > 0;
                }
                else
                {
                    _archivo = string.Empty;

                    _cartuchos.Clear();

                    btnAceptar.Enabled = false;
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorCargasGeneracionFormatoArchivo");
            }

            txtArchivo.Text = _archivo;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow reg in dgvCargas.Rows){
                    string n = reg.Cells[1].Value.ToString();
                    Cartucho c = new Cartucho(numero:n);
                    _mantenimiento.verificarCartucho(ref c);

                    FallaCartucho _falla = new FallaCartucho();
                    _falla.Nombre = reg.Cells[0].Value.ToString();;

                    _mantenimiento.verificarFallaCartucho(ref _falla);
                    
                    _mantenimiento.agregarFallaPorCartucho(ref _falla, ref c, _usuario);
                }

                Mensaje.mostrarMensaje("MensajeFallasConfirmacionGeneracion");

                dgvCargas.DataSource = null;
                dgvCargas.Refresh();
                txtArchivo.Text = "";

                btnAceptar.Enabled = false;
                lbInconrrectas.Items.Clear();
                
               
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }
        #endregion Eventos

        #region Metodos Publicos

        private void generarCargas()
        {
            DocumentoExcel archivo = null;

            try
            {
                _filas_incorrectas.Clear();
          
                archivo = new DocumentoExcel(_archivo, false);

                archivo.seleccionarHoja(1);

                Celda celda_Falla = archivo.seleccionarCelda(mtbCeldaFalla.Text);
                Celda celda_Cartucho = archivo.seleccionarCelda(mtbCeldaCartucho.Text);

                this.generarFallas(archivo, celda_Falla, celda_Cartucho);

                archivo.mostrar();
                archivo.cerrar();

            }
            catch (Exception ex)
            {
                archivo.mostrar();
                archivo.cerrar();

                throw ex;
            }

        }

        private void generarFallas(DocumentoExcel archivo, Celda celda_falla, Celda celda_cartucho)
        {
            while (!celda_falla.Valor.Equals(string.Empty))
            {
                string numero_cartucho = (string)celda_cartucho.Valor;
                string falla = (string)celda_falla.Valor;

                Cartucho cartucho = new Cartucho(numero: numero_cartucho);
                FallaCartucho _falla = new FallaCartucho();
                _falla.Nombre = falla;

                _mantenimiento.verificarFallaCartucho(ref _falla);
                bool cartuchovalido = _mantenimiento.verificarCartucho(ref cartucho);

                if (_falla.ID != 0 & cartuchovalido == true)
                    dgvCargas.Rows.Add(falla, numero_cartucho);
                else
                {
                    lbInconrrectas.Items.Add(celda_falla.Fila.ToString());
                    _filas_incorrectas.Add(celda_falla.Fila);
                }

                celda_falla = archivo.seleccionarCelda(celda_falla.Fila + 1, celda_falla.Columna);
                celda_cartucho = archivo.seleccionarCelda(celda_cartucho.Fila + 1, celda_cartucho.Columna);
            }



        }


        #endregion Metodos Publicos

        
    }
}
