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
using System.Media;
using LibreriaMensajes;

namespace GUILayer
{
    public partial class frmRegistroTulasNiquel : Form
    {
                #region Constantes

        // Filas de la lista

        private const int DESCRIPCION = 0;
        private const int CAJA_ACTUAL = 1;
        private const int TOTAL_CAJAS = 2;
        private const int MANIFIESTOS_CAJA = 3;
        private const int TOTAL_MANIFIESTOS = 4;
        private const int POSICION_LECTOR = 5;

        // Mensajes

        private const string TULA_AGREGADA = "Tula Registrada";
        private const string TULA_ELIMINADA = "Tula Eliminada";
        private const string LISTA_TULAS_VACIA = "Ninguna";

        // Fuentes

        private Font fuente_normal = new Font("Microsoft Sans Serif", (float)8.25);
        private Font fuente_mediana = new Font("Microsoft Sans Serif", (float)18);
        private Font fuente_grande = new Font("Microsoft Sans Serif", (float)36);

        private const string SONIDO_CAJA = "Caja_{0}.wav";
        private const string SONIDO_TULA_ELIMINADA = "tula_eliminada.wav";
        private const string SONIDO_TULA_REGISTRADA = "tula_registrada.wav";
        private const string SONIDO_TULA_DUPLICADA = "tula_duplicada.wav";
        private const string SONIDO_MANIFIESTO_ANTERIOR = "manifiesto_anterior.wav";
        private const string SONIDO_REINICIANDO_LECTURA = "reiniciando_lectura.wav";

        #endregion Constantes

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;

        List<Cliente> _grupos = null;
        
        Colaborador _receptor = null;
        EmpresaTransporte _empresa = null;

        private string _anterior = string.Empty;
        private string _codigo_manifiesto = string.Empty;
        private string _codigo_tula = string.Empty;

        private bool _lectura_manifiesto = true;
        private bool _cambio_grupo = true;

        private int _posicion = 1;
        private int _total_manifiestos = 0;

        SoundPlayer reproductor = new SoundPlayer();

        private List<Stack<Tula>> _tulas = new List<Stack<Tula>>();

        #endregion Atributos

        #region Constructor

        public frmRegistroTulasNiquel(List<Cliente> grupos, EmpresaTransporte empresa, Colaborador receptor)
        {
            InitializeComponent();

            try
            {
                _grupos = grupos;
                _empresa = empresa;
                _receptor = receptor;

                txtReceptor.Text = _receptor.ToString();
                txtEmpresa.Text = _empresa.Nombre;

                // Agregar las filas

                
            
                //Agregar las columnas

                foreach (Cliente grupo in _grupos)
                {
                    // Agregar la columna


                    _tulas.Add(new Stack<Tula>());
                }

                // Seleccionar el primer grupo

                this.seleccionarGrupo(_posicion);

                // Mostrar la ventana en toda la pantalla

                Screen pantalla = Screen.PrimaryScreen;

                this.Location = pantalla.Bounds.Location;
                Cursor.Hide();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Cierre del formulario.
        /// </summary>
        private void frmRegistroTulas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cursor.Show();
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Se presiona una tecla en el formulario.
        /// </summary>
        private void frmRegistroTulas_KeyDown(object sender, KeyEventArgs e)
        {
            this.interpretarComando(e);
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Agregar la tula a la lista de tulas.
        /// </summary>
        private void agregarTula ()
        {

            try
            {
                int grupo = _posicion - 1;

                // Actualizar la base de datos

                Cliente grupo_actual = _grupos[grupo];
                //byte caja = grupo_actual.Caja_actual;
                //caja = (byte)(caja == grupo_actual.Numero_cajas ? 1 : caja + 1);

                bool nuevo_manifiesto = false;

                Manifiesto manifiesto = new Manifiesto(_codigo_manifiesto, cliente:grupo_actual, empresa: _empresa,
                                                       receptor: _receptor);
                Tula tula = new Tula(_codigo_tula, manifiesto: manifiesto);

                this.verificarTulaNiquel(tula);

                nuevo_manifiesto = _atencion.agregarTulaNiquel(ref tula);

                // Actualizar la pila de tulas del CEF

                Stack<Tula> tulas_grupo = _tulas[grupo];

                tulas_grupo.Push(tula);

                // Verificar si el manifiesto es nuevo
                
                if (nuevo_manifiesto)
                {
                    //short numero_manifiestos = (short)(grupo_actual.Total_manifiestos + 1);
                    //byte numero_cajas = grupo_actual.Numero_cajas;

                    //dgvDistribucion[_posicion, CAJA_ACTUAL].Value = caja;
                    //dgvDistribucion[_posicion, TOTAL_MANIFIESTOS].Value = numero_manifiestos;
                    //dgvDistribucion[_posicion, MANIFIESTOS_CAJA].Value = numero_manifiestos / numero_cajas;

                    // Actualizar la información del grupo

                    //grupo_actual.Caja_actual = caja;
                    //grupo_actual.Total_manifiestos = numero_manifiestos;

                  //  _atencion.actualizarGrupoTotales(grupo_actual);

                    // Actualizar el indicador del total de manifiestos

                    _total_manifiestos++;

                    lblTotalManifiestos.Text = string.Format("Total de Manifiestos: {0}", _total_manifiestos);
                }

               // if (grupo_actual.)
                    this.reproducirSonido(SONIDO_TULA_REGISTRADA);
                //else
                //    this.reproducirSonido(String.Format(SONIDO_CAJA, grupo_actual.Caja_actual));

                // Mostrar un mensaje indicando que la tula fue agregada

                txtUltimaTula.Text = tula.Codigo;

                txtMensaje.Text = TULA_AGREGADA;
                txtMensaje.BackColor = Color.LightGreen;
            }
            catch (Excepcion ex)
            {
                txtMensaje.Text = ex.Message;
                txtMensaje.BackColor = Color.Tomato;
            }

        }

        /// <summary>
        /// Cancelar el registro de una tula.
        /// </summary>
        private void cancelar()
        {

            try
            {
                int posicion_grupo = _posicion - 1;

                Stack<Tula> tulas_grupo = _tulas[posicion_grupo];

                if (tulas_grupo.Count > 0)
                {
                    // Actualizar la base de datos

                    Tula tula = tulas_grupo.Pop();

                    bool manifiesto_eliminado = _atencion.eliminarTulaNiquel(tula);

                    // Verificar si se elimino el manifiesto

                    if (manifiesto_eliminado)
                    {
                        Cliente grupo = tula.Manifiesto.Cliente;
                        int posicion = _grupos.IndexOf(grupo) + 1;

                        //short numero_manifiestos = (short)(grupo.Total_manifiestos - 1);
                        //byte numero_cajas = grupo.Numero_cajas;
                        //byte caja = grupo.Caja_actual;


                        //caja = (byte)(caja == 1 ? grupo.Numero_cajas : caja - 1);

                        //dgvDistribucion[posicion, CAJA_ACTUAL].Value = caja;
                        //dgvDistribucion[posicion, TOTAL_MANIFIESTOS].Value = numero_manifiestos;
                        //dgvDistribucion[posicion, MANIFIESTOS_CAJA].Value = numero_manifiestos / numero_cajas;

                        //dgvDistribucion.Refresh();

                        // Actualizar la información del grupo

                        //grupo.Caja_actual = caja;
                        //grupo.Total_manifiestos = numero_manifiestos;

                        //_atencion.actualizarGrupoTotales(grupo);

                        // Actualizar el indicador del total de manifiestos

                        _total_manifiestos--;

                        lblTotalManifiestos.Text = string.Format("Total de Manifiestos: {0}", _total_manifiestos);
                    }

                    // Reiniciar los datos

                    this.reiniciar();

                    // Mostrar un mensaje indicando que la tula se elimino

                    txtUltimaTula.Text = tulas_grupo.Count > 0 ? tulas_grupo.Peek().Codigo : LISTA_TULAS_VACIA;

                    txtMensaje.Text = TULA_ELIMINADA;
                    txtMensaje.BackColor = Color.LightGreen;

                    this.reproducirSonido(SONIDO_TULA_ELIMINADA);
                }

            }
            catch (Excepcion ex)
            {
                txtMensaje.Text = ex.Message;
                txtMensaje.BackColor = Color.Tomato;
            }

        }

        /// <summary>
        /// Reiniciar el registro de una tula.
        /// </summary>
        private void reiniciar()
        {
            _anterior = _codigo_manifiesto;

            _codigo_manifiesto = string.Empty;
            _codigo_tula = string.Empty;

            _lectura_manifiesto = true;

            txtTula.BackColor = Color.White;
            txtManifiesto.BackColor = Color.LightBlue;
        }

        /// <summary>
        /// Interpretar una instruccion basado en una tecla presionada.
        /// </summary>
        private void interpretarComando(KeyEventArgs tecla)
        {

            if (tecla.KeyCode >= Keys.NumPad0 && tecla.KeyCode <= Keys.NumPad9)
            {
                if (_cambio_grupo) this.seleccionarGrupo(tecla.KeyValue - 96);
                else this.construirCodigo((tecla.KeyValue - 96).ToString());
            }
            else if (tecla.KeyCode == Keys.Divide)
            {
                this.recordarManifiesto();
            }
            else if (tecla.KeyCode == Keys.Decimal)
            {
                _cambio_grupo = !_cambio_grupo;

                txtFuncion.Text = _cambio_grupo ? "Cambio de cliente" : "Ingreso manual de códigos";

                txtFuncion.BackColor = _cambio_grupo ? Color.Cyan : Color.BlueViolet;
            }
            else if (tecla.KeyCode == Keys.Subtract)
            {
                this.cancelar();
            }
            else if (tecla.KeyCode == Keys.Add)
            {
                this.reproducirSonido(SONIDO_REINICIANDO_LECTURA);
                this.reiniciar();
            }
            else if (tecla.KeyCode == Keys.Multiply)
            {
                this.Close();
            }
            else if (tecla.KeyCode == Keys.Enter)
            {
                this.siguienteEtapa();
            }
            else if (tecla.KeyCode >= Keys.D0 && tecla.KeyCode <= Keys.D9)
            {
                this.construirCodigo((tecla.KeyValue - 48).ToString());
            }
            else if (tecla.KeyCode >= Keys.A && tecla.KeyCode <= Keys.Z)
            {
                this.construirCodigo(Convert.ToChar(tecla.KeyValue).ToString());
            }
        }

        /// <summary>
        /// Continuar con un mismo código de manifiesto.
        /// </summary>
        private void recordarManifiesto()
        {

            if (_lectura_manifiesto)
            {
                _codigo_manifiesto = _anterior;

                _lectura_manifiesto = false;

                txtManifiesto.BackColor = Color.White;
                txtTula.BackColor = Color.LightBlue;

                this.reproducirSonido(SONIDO_MANIFIESTO_ANTERIOR);
            }

        }

        /// <summary>
        /// Continuar con la siguiente etapa de la lectura de la información.
        /// </summary>
        private void siguienteEtapa()
        {

            if (_lectura_manifiesto && _codigo_manifiesto != string.Empty)
            {
                _lectura_manifiesto = false;

                txtManifiesto.Text = _codigo_manifiesto;

                txtManifiesto.BackColor = Color.White;
                txtTula.BackColor = Color.Yellow; 
            }
            else if (_codigo_tula != string.Empty)
            {
                txtTula.Text = _codigo_tula;

                this.agregarTula();
                this.reiniciar();
            }

            
        }

        /// <summary>
        /// Construir el código de la tula o el manifiesto.
        /// </summary>
        private void construirCodigo(string caracter)
        {

            if (_lectura_manifiesto)
                _codigo_manifiesto += caracter;
            else
                _codigo_tula += caracter;

        }

        /// <summary>
        /// Seleccionar un grupo.
        /// </summary>
        private void seleccionarGrupo(int posicion)
        {

            //if ((posicion < dgvDistribucion.Columns.Count) && (posicion > 0))
            //{
            //    dgvDistribucion[_posicion, POSICION_LECTOR].Style.BackColor = Color.White;
            //    dgvDistribucion[posicion, POSICION_LECTOR].Style.BackColor = Color.Coral;

                _posicion = posicion;

                // Mostrar un mensaje indicando que la tula se elimino

                Stack<Tula> tulas_grupo = _tulas[_posicion - 1];

                txtUltimaTula.Text = tulas_grupo.Count > 0 ? tulas_grupo.Peek().Codigo : LISTA_TULAS_VACIA;
            //}

        }

        /// <summary>
        /// Reproducir un sonido un grupo.
        /// </summary>
        private void reproducirSonido(string sonido)
        {
            reproductor.SoundLocation = Application.StartupPath + String.Format("\\Sonidos\\{0}", sonido);
            reproductor.Play();
        }

        /// <summary>
        /// Verificar si la tula está duplicada.
        /// </summary>
        private void verificarTula(Tula tula)
        {

            try
            {
                bool existe = false;

                existe = _atencion.verificarTula(ref tula);

                if (existe)
                {
                    this.reproducirSonido(SONIDO_TULA_DUPLICADA);
                    throw new Excepcion("ErrorTulaDuplicada");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Verificar si la tula está duplicada.
        /// </summary>
        private void verificarTulaNiquel(Tula tula)
        {

            try
            {
                bool existe = false;

                existe = _atencion.verificarTulaNiquel(ref tula);

                if (existe)
                {
                    this.reproducirSonido(SONIDO_TULA_DUPLICADA);
                    throw new Excepcion("ErrorTulaDuplicada");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Métodos Privados

        private void frmRegistroTulasNiquel_Load(object sender, EventArgs e)
        {

        }
    }
}
