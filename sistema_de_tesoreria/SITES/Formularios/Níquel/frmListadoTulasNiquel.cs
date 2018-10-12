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
    public partial class frmListadoTulasNiquel : Form
    {
        
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;
        DataGridView dgvTulas = new DataGridView();
        private BindingList<Tula> _tulas_grupo = null;

        private BindingList<Tula> _tulas_total = null;

        private Colaborador _colaborador = null;

        private int _total_manifiestos = 0;
        private int _total_tulas = 0;

        private int _top = 180;
        private int _fila = 0;
        private bool _nuevo = true;

        #endregion Atributos

        #region Constructor

        public frmListadoTulasNiquel(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;

            try
            {
                dtpFechaInicio.Value = dtpFechaFinal.Value.AddHours(-8);

               
                dgvTulasImpresion.AutoGenerateColumns = false;

                // Cargar los grupos

                cboGrupo.ListaMostrada = _mantenimiento.listarGrupos();
                cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();

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

        /// <summary>
        /// Clic en el botón de imprimir.
        /// </summary
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                this.imprimirHoja();
                //pdDocumento.Print();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorImpresion");
            }

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
                EmpresaTransporte transporte = (EmpresaTransporte)cboTransportadora.SelectedItem;
                
                //dgvTulasImpresion.DataSource = _atencion.listarTulasNiquel(fecha_inicio, fecha_final);
                _tulas_total = _atencion.listarTulasNiquel(fecha_inicio, fecha_final);
                
                dgvTulasImpresion.DataSource = _tulas_total;
                // Filtrar las tulas para impresión

                this.seleccionarTransportadora();
            }
            catch(Excepcion ex) {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Se selecciona otra caja.
        /// </summary
        private void nudCaja_ValueChanged(object sender, EventArgs e)
        {
            this.actualizarLista();
        }

        /// <summary>
        /// Se selecciona otro grupo.
        /// </summary
        private void cboGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.seleccionarGrupo();
        }

        /// <summary>
        /// Se selecciona otra transportadora
        /// </summary>
        private void cboTransportadora_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.seleccionarTransportadora();
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

                    if (manifiesto.Grupo.Equals(grupo))
                    {
                        maximo_cajas = Math.Max(maximo_cajas, manifiesto.Caja);
                        _tulas_grupo.Add(tula);
                    }

                }

                this.actualizarLista();
            }

        }




        /// <summary>
        /// Se selecciona Tranposrtadora
        /// </summary>
        private void seleccionarTransportadora()
        {

            if ((cboTransportadora.SelectedIndex > 0) && dgvTulasImpresion.DataSource != null)
            {
                int maximo_cajas = 1;
                EmpresaTransporte transporte = (EmpresaTransporte)cboTransportadora.SelectedItem;

                _tulas_grupo = new BindingList<Tula>();

                // foreach (Tula tula in (BindingList<Tula>)dgvTulasImpresion.DataSource)
                foreach (Tula tula in _tulas_total)
                {
                    Manifiesto manifiesto = tula.Manifiesto;

                    if (manifiesto.Empresa.Equals(transporte))
                    {
                        maximo_cajas = Math.Max(maximo_cajas, manifiesto.Caja);
                        _tulas_grupo.Add(tula);
                    }

                }
                this.actualizarLista();
            }
            else if (cboTransportadora.SelectedIndex == 0)
            {
                int tulas = 0;
                BindingList<Manifiesto> manifiestos = new BindingList<Manifiesto>();

                foreach (Tula tula in _tulas_total)
                {
                    Manifiesto manifiesto = tula.Manifiesto;
                    
                    tulas +=1;

                    if (!manifiestos.Contains(manifiesto))
                        manifiestos.Add(manifiesto);
                }

                dgvTulasImpresion.DataSource = _tulas_total;
                txtTotalTulas.Text = tulas.ToString();
                txtTotalManifiestos.Text = manifiestos.Count.ToString();

            }           
        }

        /// <summary>
        /// Clic en el botón de cambiar grupo.
        /// </summary
        private void btnCambioGrupo_Click(object sender, EventArgs e)
        {

            //if (dgvTulasImpresion.SelectedRows.Count > 0)
            //{
            //    Tula tula = (Tula)dgvTulasImpresion.SelectedRows[0].DataBoundItem;
            //    Manifiesto manifiesto = tula.Manifiesto;

            //    frmCambioGrupo formulario = new frmCambioGrupo(manifiesto, this);

            //    formulario.ShowDialog();
            //}

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
                btnImprimir.Enabled = true;
            }
            else
            {
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

            //for (int contador = 0; contador < e.RowCount; contador++)
            //{
            //    DataGridViewRow fila = dgvTulas.Rows[e.RowIndex + contador];
            //    Tula tula = (Tula)fila.DataBoundItem;

            //    fila.Cells[Grupo.Index].Value = tula.Manifiesto.Grupo;

            //}

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


                e.Graphics.DrawString("F-BAC-Detalle de Remesas por Enviar-CRI-0001334 Versión 1", fuente, Brushes.Red, 100, 80);
                e.Graphics.DrawString("Inicio: " + fecha_inicio, fuente, Brushes.Black, 100, 100);
                e.Graphics.DrawString("Final: " + fecha_final, fuente, Brushes.Black, 100, 120);

                string titulo_grupo = "Grupo: " + grupo;

               
                int posicion_totales = 120 + (int)e.Graphics.MeasureString(titulo_grupo, fuente).Width;

                e.Graphics.DrawString("Total de Manifiestos: " + _total_manifiestos, fuente, Brushes.Black, posicion_totales, 140);
                e.Graphics.DrawString("Total de Tulas: " + _total_tulas, fuente, Brushes.Black, posicion_totales, 160);
            }

            // Crear los encabezados

            this.agregarEncabezado(e.Graphics);

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
        }
       
        #endregion Eventos

        #region Métodos Privados

        private void imprimirHoja()
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla Lista Tulas Niquel.xlt", true);

                documento.seleccionarHoja(1);

                // Escribir los datos

                documento.seleccionarCelda("F3");
                documento.actualizarValorCelda(txtTotalTulas.Text);

                documento.seleccionarCelda("F4");
                documento.actualizarValorCelda(txtTotalManifiestos.Text);

                // Imprimir los montos

                int fila = 6;


                foreach (DataGridViewRow r in dgvTulasImpresion.Rows)
                {

                    Tula datos = (Tula)r.DataBoundItem;

                    documento.seleccionarCelda(fila, 1);
                    documento.actualizarValorCelda(datos.Manifiesto.Codigo);

                    documento.seleccionarCelda(fila, 2);
                    documento.actualizarValorCelda(datos.Codigo);

                    documento.seleccionarCelda(fila, 3);
                    documento.actualizarValorCelda(datos.Fecha_ingreso);

                    documento.seleccionarCelda(fila, 4);
                    documento.actualizarValorCelda(datos.Cliente.Nombre);

                    documento.seleccionarCelda(fila, 5);
                    documento.actualizarValorCelda(datos.Receptor.ToString());

                    documento.seleccionarCelda(fila, 6);
                    documento.actualizarValorCelda(datos.Empresa.Nombre);

                    fila++;
                }



                // Imprimir el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }

        /// <summary>
        /// Actualizar la lista de tulas a imprimir.
        /// </summary
        private void actualizarLista()
        {
            List<Manifiesto> manifiestos = new List<Manifiesto>();

            if (_tulas_grupo != null && _tulas_grupo.Count > 0)
            {
                
                BindingList<Tula> tulas = new BindingList<Tula>();

                foreach (Tula tula in _tulas_grupo)
                {
                    Manifiesto manifiesto = tula.Manifiesto;
                   
                    
                        tulas.Add(tula);

                        if (!manifiestos.Contains(manifiesto))
                            manifiestos.Add(manifiesto);

                    

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

            DataGridViewRow primera = dgvTulasImpresion.Rows[0];
            int x = 100;

            foreach (DataGridViewColumn columna in dgvTulasImpresion.Columns)
            {
                if (columna.Visible == false) continue;

                Rectangle area_columna = new Rectangle(x, _top, columna.Width, primera.Height);

                g.FillRectangle(Brushes.LightGray, area_columna);
                g.DrawRectangle(Pens.Black, area_columna);
                g.DrawString(columna.HeaderText, dgvTulas.Font, Brushes.Black, area_columna);

                x += columna.Width;
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
