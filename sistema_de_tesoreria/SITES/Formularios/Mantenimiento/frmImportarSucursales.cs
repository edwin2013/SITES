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
using LibreriaReportesOffice;
using LibreriaMensajes;

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmImportarSucursales : Form
    {
        
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private BindingList<Sucursal> _sucursales = new BindingList<Sucursal>();
        private Dictionary<int, Denominacion> _denominaciones = new Dictionary<int, Denominacion>();

        private string _archivo = string.Empty;

        private List<int> _filas_incorrectas = new List<int>();

        #endregion Atributos

        #region Contructor

        public frmImportarSucursales()
        {
            InitializeComponent();


            dgvCargas.AutoGenerateColumns = false;
        }

        #endregion Contructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de abrir.
        /// </summary>
        private void btnAbrir_Click(object sender, EventArgs e)
        {

            try
            {

                if (ofdMontosCargas.ShowDialog() == DialogResult.OK)
                {
                    _archivo = ofdMontosCargas.FileName;

                    this.generarSucursales();

                    btnAceptar.Enabled = _sucursales.Count > 0 && _filas_incorrectas.Count == 0;
                }
                else
                {
                    _archivo = string.Empty;

                    _sucursales.Clear();

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

        /// <summary>
        /// Clic en el botón de aceptar.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                _coordinacion.importarSucursales(_sucursales);

                Mensaje.mostrarMensaje("MensajeCargasATMsConfirmacionGeneracion");

                dgvCargas.DataSource = null;

                btnAceptar.Enabled = false;
             
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

       

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        

        #endregion Eventos

        #region Métodos Privados

        
        /// <summary>
        /// Leer los montos del archivo y generar las cargas.
        /// </summary>
        private void generarSucursales()
        {
            DocumentoExcel archivo = null;

            try
            {
                _filas_incorrectas.Clear();

                _sucursales.Clear();
                _denominaciones.Clear();

                archivo = new DocumentoExcel(_archivo, false);

                archivo.seleccionarHoja(1);

                Celda celda_sucursal = archivo.seleccionarCelda(mtbSucursalCelda.Text);
                Celda celda_provincia = archivo.seleccionarCelda(mtbProvinciaCelda.Text);
                Celda celda_ciudad= archivo.seleccionarCelda(mtbCiudadCelda.Text);
                Celda celda_tipo = archivo.seleccionarCelda(mtbceldaTipSucursal.Text);
                Celda celda_transportadora = archivo.seleccionarCelda(mtbTransportadoraCelda.Text);
                Celda celda_entidad = archivo.seleccionarCelda(mtbEntidad.Text);
                

                this.generarSucursalesDatos(archivo, celda_sucursal,celda_provincia,celda_ciudad,celda_tipo,celda_transportadora,celda_entidad);
               

                dgvCargas.DataSource = _sucursales;

                archivo.mostrar();
                archivo.cerrar();

                // Dar formato a las cargas

                foreach (DataGridViewRow fila in dgvCargas.Rows)
                    this.validarCarga(fila);
            }
            catch (Exception ex)
            {
                archivo.mostrar();
                archivo.cerrar();

                throw ex;
            }

        }

        /// <summary>
        /// Validar una carga.
        /// </summary>
        private void validarCarga(DataGridViewRow fila)
        {
            //CargaATM carga = (CargaATM)fila.DataBoundItem;
            //ATM atm = carga.ATM;

            //_filas_incorrectas.Remove(fila.Index);

            //fila.Cells[CantidadColones.Index].Style.BackColor = SystemColors.Window;

            //foreach (CartuchoCargaATM cartucho in carga.Cartuchos_Colones)
            //{
            //    Denominacion denominacion = cartucho.Denominacion;

            //    if (denominacion.ID_Invalido || !denominacion.Carga_atm)
            //        this.mostrarError(MontoColones, fila, pbErrorDenominacion.BackColor);
            //    else if (cartucho.Cantidad_asignada < denominacion.Formulas_minimas)
            //        this.mostrarError(CantidadColones, fila, pbErrorMínimoFormulas.BackColor);

            //}

            //fila.Cells[CantidadDolares.Index].Style.BackColor = SystemColors.Window;

            //foreach (CartuchoCargaATM cartucho in carga.Cartuchos_Dolares)
            //{
            //    Denominacion denominacion = cartucho.Denominacion;

            //    if (denominacion.ID_Invalido || !denominacion.Carga_atm)
            //        this.mostrarError(MontoDolares, fila, pbErrorDenominacion.BackColor);
            //    else if (cartucho.Cantidad_asignada < denominacion.Formulas_minimas)
            //        this.mostrarError(CantidadDolares, fila, pbErrorMínimoFormulas.BackColor);

            //}

            //if (atm.ID_Invalido)
            //    this.mostrarError(ATM, fila, pbATMDesconocido.BackColor);
            //else if (carga.Cartuchos.Count > atm.Cartuchos)
            //    this.mostrarError(CantidadCartuchos, fila, pbErrorCantidadCartuchos.BackColor);

            //if (carga.Cantidad_denominaciones > 4)
            //    this.mostrarError(Denominaciones, fila, pbErrorCantidadDenominaciones.BackColor);

            //fila.Cells[Tipo.Index].Value = carga.Tipo;
            //fila.Cells[CantidadCartuchos.Index].Value = carga.Cartuchos.Count;
        }

        /// <summary>
        /// Generar las cargas para una moneda específica.
        /// </summary>
        private void generarSucursalesDatos(DocumentoExcel archivo, Celda celda_sucursal,Celda celda_provincia,Celda celda_ciudad,Celda celda_tipo,Celda celda_transportadora, Celda celda_entidad)
        {
            // Leer las denominaciones

       
            while (!celda_sucursal.Valor.Equals(string.Empty))
            {
                if (celda_entidad.Valor == "Branch")
                {
                    Sucursal sucursal = null;
                    short numero_sucursal = short.Parse(celda_sucursal.Valor.Substring(0, 3));
                    string nombre = celda_sucursal.Valor;
                    Provincias provincia = (Provincias)short.Parse(celda_provincia.Valor.Substring(0, 2));
                    string direccion = celda_ciudad.Valor;
                    byte numero_transportadora = byte.Parse(celda_transportadora.Valor.Substring(0, 2));
                    TipoSucursal tipo_sucursal = (TipoSucursal)short.Parse(celda_tipo.Valor.Substring(0, 2));
                    EmpresaTransporte transportadora = new EmpresaTransporte(id: numero_transportadora);
                    bool externa = false;
                    transportadora = _mantenimiento.obtenerDatosEmpresa(ref transportadora);

                    if (transportadora.ID != 5)
                        externa = true;

                    sucursal = new Sucursal(codigo: numero_sucursal, nombre: nombre, provincia: provincia, direccion: direccion, transporte: transportadora, externo: externa, sucursal: tipo_sucursal);

                    _sucursales.Add(sucursal);
                }

                    celda_sucursal = archivo.seleccionarCelda(celda_sucursal.Fila + 1, celda_sucursal.Columna);
                    celda_provincia = archivo.seleccionarCelda(celda_provincia.Fila + 1, celda_provincia.Columna);
                    celda_ciudad = archivo.seleccionarCelda(celda_ciudad.Fila + 1, celda_ciudad.Columna);
                    celda_tipo = archivo.seleccionarCelda(celda_tipo.Fila + 1, celda_tipo.Columna);
                    celda_transportadora = archivo.seleccionarCelda(celda_transportadora.Fila + 1, celda_transportadora.Columna);
                    celda_entidad = archivo.seleccionarCelda(celda_entidad.Fila + 1, celda_entidad.Columna);
                
            }

        }

       

       

        #endregion Métodos Privados
    }
}
