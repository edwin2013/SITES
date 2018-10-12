//
//  @ Project : 
//  @ File Name : frmRegistroTulas.cs
//  @ Date : 19/04/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Media;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using System.ComponentModel;
using CommonObjects.Clases;

namespace GUILayer
{

    public partial class frmRegistroTulas : Form
    {

        #region Constantes

        // Filas de la lista

        private const int DESCRIPCION = 0;
        private const int CAJA_ACTUAL = 1;
        private const int CAJERO_ASIGNADO = 2;
        private const int TOTAL_CAJAS = 3;
        private const int MANIFIESTOS_CAJA = 4;
        private const int TOTAL_MANIFIESTOS = 5;
        private const int POSICION_LECTOR = 6;

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

        List<Grupo> _grupos = null;
        private BindingList<Colaborador> _colaboradores = new BindingList<Colaborador>();
        private BindingList<Colaborador> _nuevos_colaboradores = new BindingList<Colaborador>();
        BindingList<ManifiestoColaborador> _relaciones = null;
        BindingList<ManifiestoColaborador> _relaciones_nuevas = null;
        Colaborador _receptor = null;
        EmpresaTransporte _empresa = null;

        private string _anterior = string.Empty;
        private string codigo_manifiesto = string.Empty;
        private string _codigo_tula = string.Empty;

        private bool _lectura_manifiesto = true;
        private bool _cambio_grupo = true;

        private int _posicion = 1;
        private int _total_manifiestos = 0;
        private int _total_cajas = 1;

        private bool _verificar_etapa = false;

        private bool _eliminada = false;

        SoundPlayer reproductor = new SoundPlayer();

        private List<Stack<Tula>> _tulas = new List<Stack<Tula>>();

        #endregion Atributos

        #region Constructor

        public frmRegistroTulas(List<Grupo> grupos, EmpresaTransporte empresa, Colaborador receptor, BindingList<Colaborador> cajas_cajeros)
        {
            
            InitializeComponent();
            dgvTulasNiquel.AutoGenerateColumns = false;
            this.cboDenominaciones.ListaMostrada = _mantenimiento.listarDenominacionesMonedas();
            this.dgvTulasNiquel.DataSource = new BindingList<TulaNiquel>();
           

            try
            {
                _grupos = grupos;
                _empresa = empresa;
                _receptor = receptor;
                
                
                frmOpcionesRegistro formulario = new frmOpcionesRegistro(_receptor);
                formulario._cajas_cajeros = cajas_cajeros;

                _colaboradores = _mantenimiento.listarCajerosAsignados();
                _nuevos_colaboradores = _colaboradores;

                txtReceptor.Text = _receptor.ToString();
                txtEmpresa.Text = _empresa.Nombre;

                // Agregar las filas

                dgvDistribucion.Rows.Add("Descripción");
                dgvDistribucion.Rows.Add("Caja Actual");
                dgvDistribucion.Rows.Add("Cajero Asignado");
                dgvDistribucion.Rows.Add("Total del Cajas");
                dgvDistribucion.Rows.Add("Manifiestos por Caja");
                dgvDistribucion.Rows.Add("Total de Manifiestos");
                dgvDistribucion.Rows.Add("Posición Lector");

                dgvDistribucion.Rows[CAJA_ACTUAL].Height = 120;
                dgvDistribucion.Rows[CAJA_ACTUAL].DefaultCellStyle.Font = fuente_grande;
                dgvDistribucion[0, CAJA_ACTUAL].Style.Font = fuente_normal;

                dgvDistribucion.Rows[CAJERO_ASIGNADO].Height = 70;
                dgvDistribucion.Rows[CAJERO_ASIGNADO].DefaultCellStyle.Font = fuente_mediana;
                dgvDistribucion[0, CAJERO_ASIGNADO].Style.Font = fuente_normal;

                dgvDistribucion.Rows[TOTAL_CAJAS].Height = 70;
                dgvDistribucion.Rows[TOTAL_CAJAS].DefaultCellStyle.Font = fuente_mediana;
                dgvDistribucion[0, TOTAL_CAJAS].Style.Font = fuente_normal;

                dgvDistribucion.Rows[MANIFIESTOS_CAJA].Height = 70;
                dgvDistribucion.Rows[MANIFIESTOS_CAJA].DefaultCellStyle.Font = fuente_mediana;
                dgvDistribucion[0, MANIFIESTOS_CAJA].Style.Font = fuente_normal;

                dgvDistribucion.Rows[TOTAL_MANIFIESTOS].Height = 70;

                dgvDistribucion.Rows[TOTAL_MANIFIESTOS].DefaultCellStyle.Font = fuente_mediana;
                dgvDistribucion[0, TOTAL_MANIFIESTOS].Style.Font = fuente_normal;

                dgvDistribucion.Rows[POSICION_LECTOR].Height = 70;
            
                //Agregar las columnas

                foreach (Grupo grupo in _grupos)
                {
                    // Agregar la columna

                    DataGridViewColumn columna = new DataGridViewColumn();

                    columna.HeaderText = grupo.Nombre;
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    columna.CellTemplate = new DataGridViewTextBoxCell();
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvDistribucion.Columns.Add(columna);

                    //Lista los registros de cajeros asignados

                    try
                    {
                         _relaciones_nuevas = _mantenimiento.listarRegistrosCajerosAsignados(grupo);
                        
                        _relaciones = _relaciones_nuevas;
                        _nuevos_colaboradores = new BindingList<Colaborador>();
                        _relaciones_nuevas = new BindingList<ManifiestoColaborador>();
                        Colaborador cajrecep = new Colaborador();
                                
                        foreach (ManifiestoColaborador relacion in _relaciones)
                        {
                            if (relacion.Grupo.Id == grupo.Id)
                            {
                                if (grupo.Caja_unica == true)
                                {
                                    grupo.Colaborador = Convert.ToString(relacion.Cajero_Receptor);
                                    _nuevos_colaboradores.Add(relacion.Cajero_Receptor);
                                }
                                else
                                {
                                    foreach (Colaborador c in _colaboradores)
                                    {
                                        if (c.ID == relacion.Cajero_Receptor.ID)
                                        {
                                            relacion.Cajero_Receptor.Caja = relacion.Posicion;
                                            _nuevos_colaboradores.Add(relacion.Cajero_Receptor);
                                        }

                                    }
                                }
                                            
                                if (relacion.Posicion == grupo.Caja_actual)
                                {
                                    cajrecep = relacion.Cajero_Receptor;
                                }
                                          
                                grupo.Grupo_Colaboradores = _nuevos_colaboradores;
                                _relaciones_nuevas.Add(relacion);

                                _total_cajas = relacion.Posicion;
                                }
                        }
                                
                        if (grupo.Total_manifiestos > 0)
                            grupo.Colaborador = cajrecep.ToString();

                        else
                            grupo.Colaborador = string.Empty;
                         
                        grupo.Relaciones = _relaciones_nuevas;
                        
                    }
                    catch (Exception)
                    {
                        throw new Excepcion("ErrorDatosConexion");
                    }

                    // Actualizar las filas
                   
                    dgvDistribucion.Rows[DESCRIPCION].Cells[columna.Index].Value = grupo.Descripcion;
                    dgvDistribucion.Rows[CAJA_ACTUAL].Cells[columna.Index].Value = grupo.Caja_actual;
                    dgvDistribucion.Rows[CAJERO_ASIGNADO].Cells[columna.Index].Value = grupo.Colaborador;
                    dgvDistribucion.Rows[TOTAL_CAJAS].Cells[columna.Index].Value = grupo.Numero_cajas;
                    dgvDistribucion.Rows[TOTAL_MANIFIESTOS].Cells[columna.Index].Value = grupo.Total_manifiestos;
                    dgvDistribucion.Rows[MANIFIESTOS_CAJA].Cells[columna.Index].Value = grupo.Total_manifiestos / grupo.Numero_cajas;

                    _tulas.Add(new Stack<Tula>());

                    _total_manifiestos = grupo.Total_manifiestos + _total_manifiestos;

                }

                // Seleccionar el primer grupo

                this.seleccionarGrupo(_posicion);

                // Mostrar la ventana en toda la pantalla

                Screen pantalla = Screen.PrimaryScreen;

                this.Location = pantalla.Bounds.Location;
                txtManifiesto.Focus();
                //Cursor.Hide();
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

        /// <summary>
        /// Agrega una bolsa de niquel a un manifiesto especifico
        /// </summary>
        private void btnAgregarTulaNiquel_Click(object sender, EventArgs e)
        {
            try
            {
                if (nudCantidadBolsas.Value > 0 && cboDenominaciones.SelectedIndex > 0)
                {

                    BindingList<TulaNiquel> tulas = (BindingList<TulaNiquel>)dgvTulasNiquel.DataSource;
                    TulaNiquel tula = new TulaNiquel();
                    tula.CantidadBolsa = (int)nudCantidadBolsas.Value;
                    tula.Denominacion = (Denominacion)cboDenominaciones.SelectedItem;
                    tulas.Add(tula);

                    cboDenominaciones.SelectedIndex = 0;
                    nudCantidadBolsas.Value = 0;
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }


        }

        /// <summary>
        /// Elimina una bolsa de un manifiesto especifico
        /// </summary>
        private void btnQuitarTulaNiquel_Click(object sender, EventArgs e)
        {
            try
            {

                dgvTulasNiquel.Rows.Remove(dgvTulasNiquel.SelectedRows[0]);

            }
            catch (Excepcion ex)
            {
 
            }
        }



        /// <summary>
        /// Cambio en la tabla de bolsas
        /// </summary>
        private void dgvTulasNiquel_SelectionChanged(object sender, EventArgs e)
        {
            //btnAgregarTulaNiquel.Enabled = dgvTulasNiquel.Rows.Count > 0;
            btnQuitarTulaNiquel.Enabled = dgvTulasNiquel.SelectedRows.Count > 0;
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

                Grupo grupo_actual = _grupos[grupo];
               
                 seleccionarGrupo(grupo);

                byte caja = grupo_actual.Caja_actual;
                byte cajanueva = caja;
                bool nuevo = false;
                
                _relaciones_nuevas = grupo_actual.Relaciones;
                _nuevos_colaboradores = grupo_actual.Grupo_Colaboradores;

                if (grupo_actual.Numero_cajas == grupo_actual.Caja_actual)
                {
                    _nuevos_colaboradores = grupo_actual.Grupo_Colaboradores;
                    caja = 0;
                    cajanueva = 0;
                    nuevo = true;
                }

                Colaborador cajero = new Colaborador();
                 _relaciones = _relaciones_nuevas;
                
                if (_eliminada == false)
                {
                   Colaborador cajero_nuevo = new Colaborador();

                    if (nuevo == true)
                    {
                        cajanueva = Convert.ToByte(caja + 1);
                        
                    }
                    else
                        cajanueva = Convert.ToByte(grupo_actual.Caja_actual);

                   foreach (ManifiestoColaborador relacion in _relaciones)
                    {
                        if (nuevo == true)
                        {
                            if (relacion.Posicion == (cajanueva))
                            {

                                cajero_nuevo = relacion.Cajero_Receptor;
                                grupo_actual.Colaborador = cajero_nuevo.ToString();
                                cajero_nuevo.Caja = cajanueva;
                                cajero = cajero_nuevo;
                            }
                        }
                        else
                        {
                            if (relacion.Posicion == (cajanueva + 1))
                            {

                                cajero_nuevo = relacion.Cajero_Receptor;
                                grupo_actual.Colaborador = cajero_nuevo.ToString();
                                cajero_nuevo.Caja = cajanueva + 1;
                                cajero = cajero_nuevo;
                            }
                        }
                        
                            
                    }

                    _eliminada = false;

                }
                else
                {
                    if (caja == 0)
                    {
                        foreach (ManifiestoColaborador relacion in _relaciones)
                        {
                            if (relacion.Posicion == 1)
                            {
                                cajero = relacion.Cajero_Receptor;
                                cajero.Caja = 1;
                            }
                            else
                            {
                                if ((cajanueva) == relacion.Posicion)
                                {
                                    cajero = relacion.Cajero_Receptor;
                                    cajero.Caja = relacion.Posicion;
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (ManifiestoColaborador relacion in _relaciones)
                        {
                            if ((cajanueva + 1)  == relacion.Posicion)
                            {
                                cajero = relacion.Cajero_Receptor;
                                cajero.Caja = relacion.Posicion;
                            }
                        }
                    
                    }   
                }
          
                
                _total_cajas = Convert.ToInt16(cajero.Caja);

                if (_total_cajas == 0)
                {
                    cajero.Caja = 1;
                    _total_cajas = 1;
                }

                caja = Convert.ToByte(cajero.Caja);

                bool nuevo_manifiesto = false;
                
                
                Manifiesto manifiesto = new Manifiesto(codigo_manifiesto, grupo: grupo_actual, caja: caja, empresa: _empresa,
                                                          receptor: _receptor,cajero_receptor: cajero, area: grupo_actual.Area);
                
                Tula tula = new Tula(_codigo_tula, manifiesto: manifiesto);

                tula.Manifiesto = manifiesto;

                this.verificarTula(tula);

                tula.Niquel = (BindingList<TulaNiquel>)dgvTulasNiquel.DataSource;

                nuevo_manifiesto = _atencion.agregarTula(ref tula);

                // Actualizar la pila de tulas del CEF

                Stack<Tula> tulas_grupo = _tulas[grupo];

                tulas_grupo.Push(tula);
                
                //Carga informacion de nueva relacion manifiesto colaborador
                ManifiestoColaborador manifcolaborador = new ManifiestoColaborador(posicion: caja, manifiesto: manifiesto, cajero_receptor: cajero);

                manifcolaborador.Cajero_Receptor = cajero;
                manifcolaborador.Manifiesto = manifiesto;
                manifcolaborador.Posicion = caja;
                manifcolaborador.Grupo = grupo_actual;

                _mantenimiento.actualizarManfiestoCajero(ref manifcolaborador);
                

                // Verificar si el manifiesto es nuevo
                
                if (nuevo_manifiesto)
                {
                    short numero_manifiestos = (short)(grupo_actual.Total_manifiestos + 1);
                    byte numero_cajas = grupo_actual.Numero_cajas;

                    dgvDistribucion[grupo + 1, CAJA_ACTUAL].Value = caja;
                    dgvDistribucion[grupo + 1, TOTAL_MANIFIESTOS].Value = numero_manifiestos;
                    dgvDistribucion[grupo + 1, MANIFIESTOS_CAJA].Value = numero_manifiestos / numero_cajas;
                    dgvDistribucion[grupo + 1, CAJERO_ASIGNADO].Value = cajero;
                    
                    // Actualizar la información del grupo

                    grupo_actual.Caja_actual = caja;
                    grupo_actual.Total_manifiestos = numero_manifiestos;
                    grupo_actual.Colaborador = Convert.ToString(cajero);
                    
                     _atencion.actualizarGrupoTotales(grupo_actual);

                    // Actualizar el indicador del total de manifiestos

                    _total_manifiestos++;

                    lblTotalManifiestos.Text = string.Format("Total de Manifiestos: {0}", _total_manifiestos);
                }

                if (grupo_actual.Caja_unica)
                    this.reproducirSonido(SONIDO_TULA_REGISTRADA);
                else
                    this.reproducirSonido(String.Format(SONIDO_CAJA, grupo_actual.Caja_actual));

                // Mostrar un mensaje indicando que la tula fue agregada

                txtUltimaTula.Text = tula.Codigo;

                txtMensaje.Text = TULA_AGREGADA;
                txtMensaje.BackColor = Color.LightGreen;
            }
            catch (Excepcion ex)
            {
                txtMensaje.Text = ex.Message;
                txtMensaje.BackColor = Color.Tomato;
                this.Refresh();
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

                    Tula tula = tulas_grupo.Pop();  // Quita y devuelve el valor de situado al principio de la Lista

                    bool manifiesto_eliminado = _atencion.eliminarTula(tula);

                    _eliminada = true;

                    // Verificar si se elimino el manifiesto

                    if (manifiesto_eliminado)
                    {
                        Grupo grupo = tula.Manifiesto.Grupo;
                        int posicion = _grupos.IndexOf(grupo);
                        short numero_manifiestos = (short)(grupo.Total_manifiestos - 1);
                        byte numero_cajas = grupo.Numero_cajas;
                        byte caja = grupo.Caja_actual;
                        
                        caja = (byte)(caja == 1 ? grupo.Numero_cajas : caja - 1);



                        Colaborador cajeronuevo = new Colaborador(); //   _nuevos_colaboradores[caja-1]; 
                        
                        _relaciones = _mantenimiento.listarRegistrosCajerosAsignados(grupo);

                        foreach (ManifiestoColaborador relacion in _relaciones)  /////?????
                        {
                            if (relacion.Posicion == caja)
                            {
                                cajeronuevo = relacion.Cajero_Receptor;
                                grupo.Colaborador = cajeronuevo.ToString();
                                cajeronuevo.Caja = relacion.Posicion;
                            }
                        }



                        dgvDistribucion[_posicion, CAJA_ACTUAL].Value = caja;
                        dgvDistribucion[_posicion, TOTAL_MANIFIESTOS].Value = numero_manifiestos;
                        dgvDistribucion[_posicion, MANIFIESTOS_CAJA].Value = numero_manifiestos / numero_cajas;
                        dgvDistribucion[_posicion, CAJERO_ASIGNADO].Value = cajeronuevo;

                        dgvDistribucion.Refresh();

                        // Actualizar la información del grupo

                        grupo.Caja_actual = caja;
                        grupo.Total_manifiestos = numero_manifiestos;

                        _atencion.actualizarGrupoTotales(grupo);

                        // Actualizar el indicador numero de manifiestos

                        _total_manifiestos--;
                        _total_cajas = caja;

                        lblTotalManifiestos.Text = string.Format("Total de Manifiestos: {0}", numero_manifiestos);
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
            _anterior = codigo_manifiesto;

            codigo_manifiesto = string.Empty;
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

                txtFuncion.Text = _cambio_grupo ? "Cambio de grupo" : "Ingreso manual de códigos";

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
                frmOpcionesRegistro formulario = new frmOpcionesRegistro(_receptor);
                this.Close();
            }
            else if (tecla.KeyCode == Keys.Enter)
            {
                if(!_verificar_etapa)
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
                codigo_manifiesto = _anterior;

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

             if (_lectura_manifiesto && codigo_manifiesto != string.Empty)
            {
                _lectura_manifiesto = false;

                txtManifiesto.Text = codigo_manifiesto;

                txtManifiesto.BackColor = Color.White;
                txtTula.BackColor = Color.Yellow; 
            }
            else if (_codigo_tula != string.Empty)
            {
                txtTula.Text = _codigo_tula;
                if (_verificar_etapa != true)
                {
                    int _posicionaux = 0;
                    this.seleccionarGrupo(_posicion);
                    _posicionaux = _posicion;
                    this.agregarTula();
                    this.seleccionarGrupo(_posicionaux);
                    
                }
                this.reiniciar();
            }

            
        }

        /// <summary>
        /// Construir el código de la tula o el manifiesto.
        /// </summary>
        private void construirCodigo(string caracter)
        {

            if (_lectura_manifiesto)
                codigo_manifiesto += caracter;
            else
                _codigo_tula += caracter;

        }

        /// <summary>
        /// Seleccionar un grupo.
        /// </summary>
        private void seleccionarGrupo(int posicion)
        {

            if ((posicion < dgvDistribucion.Columns.Count) && (posicion > 0))
            {
                dgvDistribucion[_posicion, POSICION_LECTOR].Style.BackColor = Color.White;
                dgvDistribucion[posicion, POSICION_LECTOR].Style.BackColor = Color.Coral;

                _posicion = posicion;

                // Mostrar un mensaje indicando que la tula se elimino

                Stack<Tula> tulas_grupo = _tulas[_posicion - 1];

                txtUltimaTula.Text = tulas_grupo.Count > 0 ? tulas_grupo.Peek().Codigo : LISTA_TULAS_VACIA;
                
            }

        }

        /// <summary>
        /// Reproducir un sonido un grupo.
        /// </summary>
        private void reproducirSonido(string sonido)
        {
            string nuevosonido = sonido.ToLower();
            reproductor.SoundLocation = Application.StartupPath + String.Format("\\sonidos\\{0}", nuevosonido);
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




        #endregion Métodos Privados

        /// <summary>
        /// Agrega las monedas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarMonedas_Click(object sender, EventArgs e)
        {
            try
            {

                int grupo = _posicion - 1;

                Grupo grupo_actual = _grupos[grupo];

                seleccionarGrupo(grupo);

                byte caja = grupo_actual.Caja_actual;
                byte cajanueva = caja;
                bool nuevo = false;

                _relaciones_nuevas = grupo_actual.Relaciones;
                _nuevos_colaboradores = grupo_actual.Grupo_Colaboradores;

                if (grupo_actual.Numero_cajas == grupo_actual.Caja_actual)
                {
                    _nuevos_colaboradores = grupo_actual.Grupo_Colaboradores;
                    caja = 0;
                    nuevo = true;
                }

                Colaborador cajero = new Colaborador();
                _relaciones = _relaciones_nuevas;

                if (_eliminada == false)
                {
                    Colaborador cajero_nuevo = new Colaborador();

                    if (nuevo == true)
                    {
                        cajanueva = Convert.ToByte(caja + 1);

                    }
                    else
                        cajanueva = Convert.ToByte(grupo_actual.Caja_actual);

                    foreach (ManifiestoColaborador relacion in _relaciones)
                    {
                        if (nuevo == true)
                        {
                            if (relacion.Posicion == (cajanueva))
                            {

                                cajero_nuevo = relacion.Cajero_Receptor;
                                grupo_actual.Colaborador = cajero_nuevo.ToString();
                                cajero_nuevo.Caja = cajanueva;
                                cajero = cajero_nuevo;
                            }
                        }
                        else
                        {
                            if (relacion.Posicion == (cajanueva + 1))
                            {

                                cajero_nuevo = relacion.Cajero_Receptor;
                                grupo_actual.Colaborador = cajero_nuevo.ToString();
                                cajero_nuevo.Caja = cajanueva + 1;
                                cajero = cajero_nuevo;
                            }
                        }


                    }

                    _eliminada = false;

                }
                else
                {
                    if (caja == 0)
                    {
                        foreach (ManifiestoColaborador relacion in _relaciones)
                        {
                            if (relacion.Posicion == 1)
                            {
                                cajero = relacion.Cajero_Receptor;
                                cajero.Caja = 1;
                            }
                            else
                            {
                                if ((cajanueva) == relacion.Posicion)
                                {
                                    cajero = relacion.Cajero_Receptor;
                                    cajero.Caja = relacion.Posicion;
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (ManifiestoColaborador relacion in _relaciones)
                        {
                            if ((cajanueva + 1) == relacion.Posicion)
                            {
                                cajero = relacion.Cajero_Receptor;
                                cajero.Caja = relacion.Posicion;
                            }
                        }

                    }
                }


                _total_cajas = Convert.ToInt16(cajero.Caja);

                if (_total_cajas == 0)
                {
                    cajero.Caja = 1;
                    _total_cajas = 1;
                }

                caja = Convert.ToByte(cajero.Caja);

                bool nuevo_manifiesto = false;


                switch (codigo_manifiesto.Substring(0,2)){
                
                    case "V0":
                        _empresa.ID = 2; 
                        break;
                    case "DV":
                        _empresa.ID = 10;
                        break;
                    case "VM":
                        _empresa.ID = 1;
                        break;
                   case "G4":
                        _empresa.ID = 3;
                        break;
                    default:
                        _empresa.ID = 5;
                        break;

                }


                Manifiesto manifiesto = new Manifiesto(codigo_manifiesto, grupo: grupo_actual, caja: caja, empresa: _empresa,
                                                          receptor: _receptor, cajero_receptor: cajero, area: grupo_actual.Area);



                Tula tula = new Tula("", manifiesto: manifiesto);

                tula.Manifiesto = manifiesto;

                //this.verificarTula(tula);

                tula.Niquel = (BindingList<TulaNiquel>)dgvTulasNiquel.DataSource;

                nuevo_manifiesto = _atencion.agregarTula(ref tula);

                // Actualizar la pila de tulas del CEF

                Stack<Tula> tulas_grupo = _tulas[grupo];

                tulas_grupo.Push(tula);

                ////Carga informacion de nueva relacion manifiesto colaborador
                //ManifiestoColaborador manifcolaborador = new ManifiestoColaborador(posicion: caja, manifiesto: manifiesto, cajero_receptor: cajero);

                //manifcolaborador.Cajero_Receptor = cajero;
                //manifcolaborador.Manifiesto = manifiesto;
                //manifcolaborador.Posicion = caja;
                //manifcolaborador.Grupo = grupo_actual;

                //_mantenimiento.actualizarManfiestoCajero(ref manifcolaborador);


                // Verificar si el manifiesto es nuevo

                if (nuevo_manifiesto)
                {
                    short numero_manifiestos = (short)(grupo_actual.Total_manifiestos + 1);
                    byte numero_cajas = grupo_actual.Numero_cajas;

                    dgvDistribucion[grupo + 1, CAJA_ACTUAL].Value = caja;
                    dgvDistribucion[grupo + 1, TOTAL_MANIFIESTOS].Value = numero_manifiestos;
                    dgvDistribucion[grupo + 1, MANIFIESTOS_CAJA].Value = numero_manifiestos / numero_cajas;
                    dgvDistribucion[grupo + 1, CAJERO_ASIGNADO].Value = cajero;

                    // Actualizar la información del grupo

                    grupo_actual.Caja_actual = caja;
                    grupo_actual.Total_manifiestos = numero_manifiestos;
                    grupo_actual.Colaborador = Convert.ToString(cajero);

                    _atencion.actualizarGrupoTotales(grupo_actual);

                    // Actualizar el indicador del total de manifiestos

                    _total_manifiestos++;

                    lblTotalManifiestos.Text = string.Format("Total de Manifiestos: {0}", _total_manifiestos);
                }

                if (grupo_actual.Caja_unica)
                    this.reproducirSonido(SONIDO_TULA_REGISTRADA);
                else
                    this.reproducirSonido(String.Format(SONIDO_CAJA, grupo_actual.Caja_actual));

                // Mostrar un mensaje indicando que la tula fue agregada

                
                txtMensaje.Text = TULA_AGREGADA;
                txtMensaje.BackColor = Color.LightGreen;
            }
            catch (Excepcion ex)
            {
                txtMensaje.Text = ex.Message;
                txtMensaje.BackColor = Color.Tomato;
                this.Refresh();
            }
        }

        

       

       
    }

}
