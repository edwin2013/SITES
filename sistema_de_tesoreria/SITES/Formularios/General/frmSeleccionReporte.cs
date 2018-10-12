//
//  @ Project : 
//  @ File Name : frmSeleccionReporte.cs
//  @ Date : 21/01/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmSeleccionReporte : Form
    {

        #region Atributos

        private SupervisionBL _supervision = SupervisionBL.Instancia;

        private Colaborador _colaborador = null;

        private BindingList<CategoriaReporte> _categorias_reportes = null;

        #endregion Atributos

        #region Constructor

        public frmSeleccionReporte(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;

            try
            {
                // Agregar la lista de categorías de reporte

                _categorias_reportes = _supervision.listarCategoriasReportes(_colaborador);

                if (_categorias_reportes.Count > 0)
                {
                    tcCategorias.TabPages.Clear();

                    foreach (CategoriaReporte categoria in _categorias_reportes)
                    {
                        TabPage pestana = new TabPage(categoria.Nombre);

                        pestana.BackColor = Color.White;
                        tcCategorias.TabPages.Add(pestana);
                    }

                    this.filtrarPorCategoria();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Selección de otro reporte en la lista de reportes.
        /// </summary>
        private void lstReportes_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstReportes.SelectedItems.Count > 0)
            {
                Reporte reporte = (Reporte)lstReportes.SelectedItems[0].Tag;

                lblDescripcion.Text = reporte.Descripcion;
            }
            else
            {
                lblDescripcion.Text = "No hay reportes registrados en el sistema";
            }

        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Clic en el botón de aceptar para mostrar el reporte seleccionado.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.mostrarReporte();
        }

        /// <summary>
        /// Doble clic en un elemento de la lista.
        /// </summary>
        private void lstReportes_DoubleClick(object sender, EventArgs e)
        {
            if (lstReportes.SelectedItems.Count > 0) this.mostrarReporte();
        }

        /// <summary>
        /// Seleccion de otra Categoria.
        /// </summary>
        private void tcCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filtrarPorCategoria();
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Mostrar el reporte.
        /// </summary>
        private void mostrarReporte()
        {

            try
            {
                Reporte reporte = (Reporte)lstReportes.SelectedItems[0].Tag;
                frmReportes formulario = new frmReportes(reporte, _colaborador);

                formulario.ShowDialog();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Filtrar los reportes por Categoria.
        /// </summary>
        private void filtrarPorCategoria()
        {
            pnlLista.Parent = tcCategorias.SelectedTab;
            lstReportes.Items.Clear();

            // Filtrar los reportes por categoría

            CategoriaReporte categoria = _categorias_reportes[tcCategorias.SelectedIndex];

            foreach (Reporte reporte in categoria.Reportes)
            {
                ListViewItem item = new ListViewItem(reporte.Nombre);

                item.ImageIndex = reporte.Graficos.Count > 0 ? 1 : 0;
                item.Tag = reporte;

                lstReportes.Items.Add(item);
            }

            // Revisar si existen reportes en la categoría seleccionada

            if (lstReportes.Items.Count > 0)
            {
                lstReportes.SelectedIndices.Add(0);
                btnAceptar.Enabled = true;
            }
            else
            {
                btnAceptar.Enabled = false;
            }

        }

        #endregion Métodos Privados

        private void frmSeleccionReporte_Load(object sender, EventArgs e)
        {

        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // frmSeleccionReporte
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 262);
        //    this.Name = "frmSeleccionReporte";
        //    this.Load += new System.EventHandler(this.frmSeleccionReporte_Load_1);
        //    this.ResumeLayout(false);

        //}

        private void frmSeleccionReporte_Load_1(object sender, EventArgs e)
        {

        }

    }

}

