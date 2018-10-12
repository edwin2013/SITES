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
using CommonObjects.Clases;
using System.IO;
using System.Diagnostics;

namespace GUILayer.Formularios.Control_Interno
{
    public partial class frmAdministracionArqueos : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private Colaborador _usuario = null;

        private string _archivo = "";
        
        #endregion Atributos

        #region Constructor

        public frmAdministracionArqueos(Colaborador usuario)
        {
            InitializeComponent();

            _usuario = usuario;

            dgvArqueos.AutoGenerateColumns = false;
            dgvArqueos.DataSource = _mantenimiento.listarArqueos(null, null);
        }

        #endregion Constructor

        #region Eventos

        private void dgvArqueos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var senderGrid = (DataGridView)sender;

            //if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            //{
            //}
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvArqueos.DataSource = _mantenimiento.listarArqueos(dtpInicio.Value, dtpFin.Value);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoArqueos formulario = new frmMantenimientoArqueos(_usuario);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostarVentanaModificacion();
        }

        private void dgvArqueos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArqueos.SelectedRows.Count > 0)
            {
                btnModificar.Enabled = true;
                btnVer.Enabled = true;
                btnSubir.Enabled = true;
            }
            else
            {
                btnModificar.Enabled = false;
                btnVer.Enabled = false;
                btnSubir.Enabled = false;
            }
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            if (ofdArchivo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _archivo = ofdArchivo.FileName;
                    Arqueo nuevo = (Arqueo)dgvArqueos.SelectedRows[0].DataBoundItem;
                    string ruta = "\\\\10.120.131.100\\Compartida_Control_Interno\\Arqueo-" + nuevo.ID + ".pdf";
                    File.Copy(ofdArchivo.FileName, ruta, true);
                    ofdArchivo.Dispose();
                    Mensaje.mostrarMensaje("MensajeArqueoConfirmacionAdjunto");
                }
                catch (Excepcion ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            Arqueo nuevo = (Arqueo)dgvArqueos.SelectedRows[0].DataBoundItem;
            string ruta = "\\\\10.120.131.100\\Compartida_Control_Interno\\Arqueo-" + nuevo.ID + ".pdf";
            if (File.Exists(ruta))
            {
                Process.Start(ruta); 
            }
            else
            {
                Mensaje.mostrarMensaje("MensajeArqueoAdjuntoNoExiste");
            }
        }


        #endregion Eventos

        #region Métodos Públicos

        /// <summary>
        /// Actualizar las lista de calidad de billetes.
        /// </summary>
        public void actualizarLista()
        {
            dgvArqueos.Refresh();
            dgvArqueos.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un arqueo a la lista.
        /// </summary>
        public void agregarArqueos(Arqueo arqueo)
        {
            BindingList<Arqueo> arqueos = (BindingList<Arqueo>)dgvArqueos.DataSource;
            arqueos.Add(arqueo);
        }

        #endregion Métodos Públicos

        #region Métodos Privados

        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        public void mostarVentanaModificacion()
        {
            try
            {
                if (dgvArqueos.SelectedRows.Count > 0)
                {
                    Arqueo arqueo = (Arqueo)dgvArqueos.SelectedRows[0].DataBoundItem;
                    frmMantenimientoArqueos formulario = new frmMantenimientoArqueos(_usuario, arqueo);
                    formulario.ShowDialog(this);
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Métodos Privados
       
    }
}
