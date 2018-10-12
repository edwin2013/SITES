using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriaMensajes;
using CommonObjects;
using BussinessLayer;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmModificarManifiesto : Form
    {

        #region Atributos

        private Colaborador _colaborador = null;
        private Colaborador _coordinador = null;
        private Manifiesto _manifiesto = null;
        private AtencionBL _atencion = AtencionBL.Instancia;        
        private BindingList<Manifiesto> _listamanifiesto = null;

        #endregion Atributos

        #region Constructor

        public frmModificarManifiesto(Colaborador colaborador, Colaborador coordinador)
        {
            InitializeComponent();
            _colaborador = colaborador;
            _coordinador = coordinador;
        }

        #endregion Constructor       

        #region Eventos

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _manifiesto = (Manifiesto)dgvManifiestos.SelectedRows[0].DataBoundItem;
            _manifiesto.Codigo = txtCodigoManifiestoNuevo.Text;
            _atencion.actualizarManifiestoCodigo(ref _manifiesto, _coordinador);
            MessageBox.Show("El código de manifiesto fue cambiado de forma satisfactoria");
            this.Close();
        }
       

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            listarDatos();
        }

        private void frmModificarManifiesto_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                //falta agregar excepción
            }
        }

        #endregion Eventos                        

        private void dgvManifiestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvManifiestos.SelectedRows.Count > 0)
            {
                gbCambioCodigoManifiesto.Enabled = true;

            }
            else
            {
                gbCambioCodigoManifiesto.Enabled = false;
            }
        }
        
        #region Métodos Privados

        private void listarDatos()
        {

            try
            {
                DateTime inicio = dtpFecha.Value;
                DateTime finalizacion = dtpFecha.Value;
                _listamanifiesto = _atencion.listarManifiestosPorFecha(DateTime.Parse(inicio.ToShortDateString()).AddDays(-3), DateTime.Parse(inicio.ToShortDateString()).AddDays(1));
                dgvManifiestos.DataSource = _listamanifiesto;
                for (int i = 0; i < dgvManifiestos.Columns.Count; i++)
                {
                    if (!dgvManifiestos.Columns[i].Name.Equals("ID") && !dgvManifiestos.Columns[i].Name.Equals("Codigo"))
                    {
                        dgvManifiestos.Columns[i].Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Métodos Privados
    }
}
