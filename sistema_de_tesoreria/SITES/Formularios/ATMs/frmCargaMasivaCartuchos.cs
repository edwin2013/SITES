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
using LibreriaReportesOffice;
using CommonObjects.Clases;

namespace GUILayer.Formularios.ATMs
{
    public partial class frmCargaMasivaCartuchos : Form
    {
        #region Atributos

        private Colaborador _usuario = new Colaborador();
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private string _archivo = string.Empty;
        private BindingList<Cartucho> _cartuchos = new BindingList<Cartucho>();
        private List<int> _filas_incorrectas = new List<int>();

        #endregion Atributos

        #region Cartuchos
        public frmCargaMasivaCartuchos()
        {
            InitializeComponent();
        }


        #endregion Cartuchos

        #region Eventos
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {

                if (ofdMontosCargas.ShowDialog() == DialogResult.OK)
                {
                    _archivo = ofdMontosCargas.FileName;

                    this.generarCargas();

                    btnAceptar.Enabled = dgvCartuchos.Rows.Count > 0;
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

        private void dgvCartuchos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnAceptar.Enabled = true;
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

                Celda celda_Tipo = archivo.seleccionarCelda(mtbCeldaTipo.Text);
                Celda celda_Cartucho = archivo.seleccionarCelda(mtbCeldaCartucho.Text);
                Celda celda_Estado = archivo.seleccionarCelda(mtbCeldaEstado.Text);
                Celda celda_Transportadora = archivo.seleccionarCelda(mtbCeldaTransportadora.Text);
                Celda celda_Proveedor = archivo.seleccionarCelda(mtbCeldaProveedor.Text);

                this.generarFallas(archivo, celda_Tipo, celda_Cartucho, celda_Estado, celda_Transportadora, celda_Proveedor);

                dgvCartuchos.AutoGenerateColumns = false;
                dgvCartuchos.DataSource = _cartuchos;

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

        private void generarFallas(DocumentoExcel archivo, Celda celda_tipo, Celda celda_cartucho, Celda celda_Estado, Celda celda_Transportadora, Celda celda_Proveedor)
        {
            while (!celda_cartucho.Valor.Equals(string.Empty))
            {
                string numero_cartucho = (string)celda_cartucho.Valor;
                Cartucho cartucho = new Cartucho(numero: numero_cartucho);

                byte numero_transportadora = byte.Parse(celda_Transportadora.Valor);
                EmpresaTransporte transp = new EmpresaTransporte(id: numero_transportadora);
                transp = _mantenimiento.obtenerDatosEmpresa(ref transp);

                byte numero_proveedor = byte.Parse(celda_Proveedor.Valor);
                ProveedorCartucho prov = new ProveedorCartucho(id: numero_proveedor);
                prov = _mantenimiento.obtenerDatosProveedor(ref prov);

                cartucho.Proveedor = prov;
                cartucho.Transportadora = transp;
                switch(celda_tipo.Valor)
                {
                    case "Dispensador":
                        cartucho.Tipo = TiposCartucho.Dispensador;
                        break;
                    case "ENA":
                        cartucho.Tipo = TiposCartucho.ENA;
                        break;
                    case "Rechazo":
                        cartucho.Tipo = TiposCartucho.Rechazo;
                        break;
                    default:
                        cartucho.Tipo = TiposCartucho.Dispensador;
                        break;
                }

                switch (celda_Estado.Valor)
                {
                    case "Bueno":
                        cartucho.Estado = EstadosCartuchos.Bueno;
                        break;
                    case "Malo en Tesorería":
                        cartucho.Estado = EstadosCartuchos.Malo;
                        break;
                    case "Malo en Taller":
                        cartucho.Estado = EstadosCartuchos.EntregadoTaller;
                        break;
                    case "No Recuperable":
                        cartucho.Estado = EstadosCartuchos.NoRecuperable;
                        break;
                    default:
                        cartucho.Estado = EstadosCartuchos.Bueno;
                        break;
                }

                if (cartucho.Transportadora.Nombre != null && cartucho.Proveedor.Nombre != null)
                {
                    _cartuchos.Add(cartucho);
                    btnAceptar.Enabled = true;
                }
                else
                {
                    lbInconrrectas.Items.Add(celda_cartucho.Fila.ToString());
                    _filas_incorrectas.Add(celda_cartucho.Fila);
                }

                celda_Transportadora = archivo.seleccionarCelda(celda_Transportadora.Fila + 1, celda_Transportadora.Columna);
                celda_cartucho = archivo.seleccionarCelda(celda_cartucho.Fila + 1, celda_cartucho.Columna);
                celda_tipo = archivo.seleccionarCelda(celda_tipo.Fila + 1, celda_tipo.Columna);
                celda_Estado = archivo.seleccionarCelda(celda_Estado.Fila+1, celda_Estado.Columna);
                celda_Proveedor = archivo.seleccionarCelda(celda_Proveedor.Fila + 1, celda_Proveedor.Columna);
            }
        }


        #endregion Metodos Publicos     

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Cartucho cart in _cartuchos)
                {
                    Cartucho nuevo = new Cartucho();
                    nuevo = cart;
                    _mantenimiento.agregarCartuchoMasivo(ref nuevo);
                }

                Mensaje.mostrarMensaje("MensajeCartuchoConfirmacionRegistro");
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
