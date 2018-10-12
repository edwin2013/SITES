using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmListaTulas : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private BindingList<Tula> _tulas_grupo = null;

        private Colaborador _colaborador = null;

        private int _total_manifiestos = 0;
        private int _total_tulas = 0;

        private int _top = 180;
        private int _fila = 0;
        private bool _nuevo = true;

        private int maxcajas = 0;
        private int numcaja = 0;

        private byte _caja = 0;

        #endregion Atributos

        #region Constructor

        public frmListaTulas(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;

            try
            {
                dtpFechaInicio.Value = dtpFechaFinal.Value.AddHours(-8);

                dgvTulas.AutoGenerateColumns = false;
                dgvTulasImpresion.AutoGenerateColumns = false;

                // Cargar los grupos

                cboGrupo.ListaMostrada = _mantenimiento.listarGrupos();
                cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB, Puestos.Digitador);
                
                if (cboGrupo.Items.Count > 0)
                    cboGrupo.SelectedIndex = 0;

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Constructor

        #region Eventos


        private void nudCaja_ValueChanged(object sender, EventArgs e)
        {
            cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB, Puestos.Digitador);
            this.actualizarLista();
        }


        /// <summary>
        /// Clic en el botón de imprimir.
        /// </summary
        private void btnImprimir_Click(object sender, EventArgs e)
        {

            try
            {
                pdDocumento.Print();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorImpresion");
            }

        }
      
        /// <summary>
        /// Actualiza la lista deacuerdo con el cajero seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboCajero_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.actualizarLista();
        }
        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary
        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime fecha_inicio = dtpFechaInicio.Value;
                DateTime fecha_final = dtpFechaFinal.Value;

                dgvTulas.DataSource = _atencion.listarTulas(fecha_inicio, fecha_final);

                // Filtrar las tulas para impresión

                this.seleccionarGrupo();
            }
            catch(Excepcion ex) {
                ex.mostrarMensaje();
            }

        }

   
        
        /// <summary>
        /// Se selecciona otro grupo.
        /// </summary
        private void cboGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.seleccionarGrupo();
        }

        /// <summary>
        /// Se selecciona otro grupo.
        /// </summary>
        private void seleccionarGrupo()
        {

            if ((cboGrupo.SelectedItem != null) && dgvTulas.DataSource != null)
            {
                int maximo_cajas = 1;
            
                Grupo grupo = (Grupo)cboGrupo.SelectedItem;
                _tulas_grupo = new BindingList<Tula>();

                foreach (Tula tula in (BindingList<Tula>)dgvTulas.DataSource)
                {
                    Manifiesto manifiesto = tula.Manifiesto;
                    Colaborador cajero_receptor = tula.Manifiesto.Cajero_Receptor;
                    
                    if (manifiesto.Grupo.Nombre == grupo.Nombre)
                    {
                        maximo_cajas = Math.Max(maximo_cajas, manifiesto.Caja);
                        _tulas_grupo.Add(tula);
                    }

                }


                nudCaja.Maximum = maximo_cajas;
                nudCaja.Value = 1;

                maxcajas = maximo_cajas;
                numcaja = 1;
                this.actualizarLista();
            }

        }

        /// <summary>
        /// Clic en el botón de cambiar grupo.
        /// </summary
        private void btnCambioGrupo_Click(object sender, EventArgs e)
        {

            if (dgvTulasImpresion.SelectedRows.Count > 0)
            {
                Tula tula = (Tula)dgvTulasImpresion.SelectedRows[0].DataBoundItem;
                Manifiesto manifiesto = tula.Manifiesto;

                frmCambioGrupo formulario = new frmCambioGrupo(manifiesto, this);

                formulario.ShowDialog();
            }

        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se agrega una fila a la lista de tulas para impresión.
        /// </summary
        private void dgvTulasImpresion_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvTulasImpresion.Rows[e.RowIndex + contador];
                Tula tula = (Tula)fila.DataBoundItem;
                Manifiesto manifiesto = tula.Manifiesto;

                fila.Cells[ManifiestoImpresionCodigo.Index].Value = manifiesto.Codigo;
                fila.Cells[Transportadora.Index].Value = manifiesto.Empresa;
                fila.Cells[Receptor.Index].Value = manifiesto.Receptor;
            }

        }

        /// <summary>
        /// Se selecciona otra tula de la lista de tulas para impresión.
        /// </summary
        private void dgvTulasImpresion_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvTulasImpresion.SelectedRows.Count > 0)
            {
                btnCambioGrupo.Enabled = true;
                btnImprimir.Enabled = true;
            }
            else
            {
                btnCambioGrupo.Enabled = false;
                btnImprimir.Enabled = false;
            }

        }

        /// <summary>
        /// Edición del código.
        /// </summary
        private void dgvTulasImpresion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                string codigo = (string)dgvTulasImpresion[e.ColumnIndex, e.RowIndex].Value;

                Tula tula = (Tula)dgvTulasImpresion.Rows[e.RowIndex].DataBoundItem;
                Manifiesto manifiesto = tula.Manifiesto;

                if (codigo != null)
                {
                    manifiesto.Codigo = codigo;

                    _atencion.actualizarCodigoManifiesto(manifiesto, _colaborador);

                    dgvTulas.Refresh();
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

            dgvTulasImpresion.AutoResizeColumns();
        }

        /// <summary>
        /// Se agregan tulas a la lista de tulas.
        /// </summary
        private void dgvTulas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = null;
                fila = dgvTulas.Rows[e.RowIndex + contador];
                
                Tula tula = (Tula)fila.DataBoundItem;
              
                fila.Cells[Grupo.Index].Value = tula.Manifiesto.Grupo;
                fila.Cells[Caja.Index].Value = tula.Manifiesto.Caja;

            }

        }

        /// <summary>
        /// Impresión del documento.
        /// </summary
        private void pdDocumento_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DataGridViewRow primera = dgvTulasImpresion.Rows[0];
            Font fuente_celdas = dgvTulasImpresion.DefaultCellStyle.Font;
            Font fuente = new Font(fuente_celdas.Name, fuente_celdas.Size - 1);

            // Imprimir los datos del informe

            if (_nuevo)
            {
                DateTime fecha_inicio = dtpFechaInicio.Value;
                DateTime fecha_final = dtpFechaFinal.Value;
                Grupo grupo = (Grupo)cboGrupo.SelectedItem;
                byte caja = _caja;
                Colaborador cajero = (Colaborador)cboCajero.SelectedItem;

                e.Graphics.DrawString("F-BAC-Control Interno de Tulas_SITES-CRI0004336 Versión 1", fuente, Brushes.Red, 100, 80);
                e.Graphics.DrawString("Inicio: " + fecha_inicio, fuente, Brushes.Black, 100, 100);
                e.Graphics.DrawString("Final: " + fecha_final, fuente, Brushes.Black, 100, 120);

                string titulo_grupo = "Grupo: " + grupo;

                e.Graphics.DrawString(titulo_grupo, fuente, Brushes.Black, 100, 140);
                e.Graphics.DrawString("Caja: " + caja, fuente, Brushes.Black, 100, 160);

                int posicion_totales = 120 + (int)e.Graphics.MeasureString(titulo_grupo, fuente).Width;

                e.Graphics.DrawString("Cajero: " + cajero, fuente, Brushes.Black, posicion_totales, 160);
                e.Graphics.DrawString("Total de Manifiestos: " + _total_manifiestos, fuente, Brushes.Black, posicion_totales, 140);
                e.Graphics.DrawString("Total de Tulas: " + _total_tulas, fuente, Brushes.Black, posicion_totales +120, 140);
            }

            // Crear los encabezados

            this.agregarEncabezado(e.Graphics);

            // Oculta la columna Cajero
            foreach (DataGridViewColumn columna in dgvTulasImpresion.Columns)
            {
                if (columna.Index == 3)
                {
                    columna.Visible = false;
                }
            }

            // Agregar las filas

            int y = _top + primera.Height;

            foreach (DataGridViewRow fila in dgvTulasImpresion.Rows)
            {
                // Saltar las filas que ya fueron impresas

                if (fila.Index < _fila) continue;

                // Agregar los valores de las celdas

                int x = 100;

                foreach (DataGridViewCell celda in fila.Cells)
                {
                    if (celda.Visible == false) continue;

                    Rectangle area_celda = new Rectangle(x, y, celda.Size.Width, celda.Size.Height);
                    string valor = celda.Value.ToString();

                    e.Graphics.DrawRectangle(Pens.Black, area_celda);
                    e.Graphics.DrawString(valor, fuente, Brushes.Black, area_celda);

                    x += celda.Size.Width;
                }

                y += fila.Height;

                // Agregar una pagina nueva si es necesario

                if (y > e.PageBounds.Height - 80)
                {
                    e.HasMorePages = true;
                    _fila = fila.Index;
                    _nuevo = false;
                    _top = 80;

                    return;
                }

            }

            // Reiniciar el documento

            _top = 180;
            _fila = 0;
            _nuevo = true;


            foreach (DataGridViewColumn mostrarcolumna in dgvTulasImpresion.Columns)
            {
                if (mostrarcolumna.Visible == false)
                    mostrarcolumna.Visible = true;
            }

            foreach (DataGridViewColumn ocultarcolumna in dgvTulasImpresion.Columns)
            {
                if (ocultarcolumna.Index == 1)
                    ocultarcolumna.Visible = false;
            }
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Actualizar la lista de tulas a imprimir.
        /// </summary
        private void actualizarLista()
        {
            List<Manifiesto> manifiestos = new List<Manifiesto>();
                
            if (_tulas_grupo != null && _tulas_grupo.Count > 0)
            {
                byte caja = (byte)nudCaja.Value;
                Colaborador cajero = (Colaborador)cboCajero.SelectedItem;
                BindingList<Tula> tulas = new BindingList<Tula>();

                foreach (Tula tula in _tulas_grupo)
                {
                    Manifiesto manifiesto = tula.Manifiesto;

                    if (cajero == null)
                    {
                        if (manifiesto.Caja == caja)
                        {
                            tulas.Add(tula);

                            if (!manifiestos.Contains(manifiesto))
                                manifiestos.Add(manifiesto);

                            cboCajero.Text = Convert.ToString(manifiesto.Cajero_Receptor);
                            _caja = manifiesto.Caja;

                        }

                    }
                    else
                    {
                        string cajero_receptor = Convert.ToString(manifiesto.Cajero_Receptor);

                        if (cajero_receptor != string.Empty)
                        {
                            if (manifiesto.Cajero_Receptor.DB_ID == cajero.DB_ID)
                            {
                                tulas.Add(tula);

                                if (!manifiestos.Contains(manifiesto))
                                    manifiestos.Add(manifiesto);

                                _caja = manifiesto.Caja;
                                nudCaja.Value = manifiesto.Caja;
                            }
                        }

                    }

                }

                dgvTulasImpresion.DataSource = tulas;
                dgvTulasImpresion.AutoResizeColumns();
            }
            else
            {
                dgvTulasImpresion.DataSource = new BindingList<Tula>();
            }

            // Agregar los totales

            _total_tulas = dgvTulasImpresion.RowCount;
            _total_manifiestos = manifiestos.Count;

            txtTotalManifiestos.Text = _total_manifiestos.ToString();
            txtTotalTulas.Text = _total_tulas.ToString();
        }

        /// <summary>
        /// Agregar el encabezado de las columnas a la lista que se imprime.
        /// </summary
        private void agregarEncabezado(Graphics g)
        {
            // Crear los encabezados

            DataGridViewRow primera = dgvTulas.Rows[0];
            int x = 100;

            foreach (DataGridViewColumn columna in dgvTulasImpresion.Columns)
            {
                if (columna.Visible == false) continue;
                {
                    if (columna.Index != 3)
                    {
                        Rectangle area_columna = new Rectangle(x, _top, columna.Width, primera.Height);

                        g.FillRectangle(Brushes.LightGray, area_columna);
                        g.DrawRectangle(Pens.Black, area_columna);
                        g.DrawString(columna.HeaderText, dgvTulas.Font, Brushes.Black, area_columna);

                        x += columna.Width;
                    }
                }
            }

        }

        #endregion Métodos Privados

        #region Métodos Públicos

        /// <summary>
        /// Actualizar la lista de tulas a imprimir.
        /// </summary>
        public void actualizarListaTulasImpresion()
        {
            dgvTulasImpresion.AutoResizeColumns();

            this.seleccionarGrupo();
        }


        #endregion Métodos Públicos



  

   

    }

}
