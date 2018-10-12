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
using System.Globalization;
using CommonObjects.Clases;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmModificarTula : Form
    {                

        #region Atributos

        private Colaborador _colaborador = null;
        private Colaborador _coordinador = null;
        private ProcesamientoBajoVolumenManifiesto _manifiesto = null;
        private AtencionBL _atencion = AtencionBL.Instancia;
        private Tula _tula = null;
        private BindingList<Tula> _listatulas = null;

        #endregion Atributos

        #region Constructor

        public frmModificarTula(Colaborador colaborador, Colaborador coordinador, ProcesamientoBajoVolumenManifiesto manifiesto)
        {
            InitializeComponent();
            _colaborador = colaborador;
            _coordinador = coordinador;
            _manifiesto = manifiesto;
            /*if (_listatulas != null)
            {
                dgvTulas.DataSource = _listatulas;
            }
            else
            {
                dgvTulas.DataSource = new BindingList<Tula>();
            }*/            
        }

        #endregion Constructor       

        #region Eventos

        private void frmModificarTula_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {

                listarDatos();
            }
            catch (Exception ex)
            {
                //falta agregar excepción
            }
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                _tula = (Tula)dgvTulas.SelectedRows[0].DataBoundItem;
                _tula.Codigo = txtCodigoTulaNuevo.Text;
                _atencion.actualizarTulaCodigo(_tula, _coordinador);
                MessageBox.Show("El código de la Tula fue cambiado de forma satisfactoria");
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvTulas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTulas.SelectedRows.Count > 0)
            {
                gbCambioCodigoTula.Enabled = true;

            }
            else
            {
                gbCambioCodigoTula.Enabled = false;
            }
        }

        private void dgvTulas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTulas.SelectedRows.Count > 0)
            {
                gbCambioCodigoTula.Enabled = true;

            }
            else
            {
                gbCambioCodigoTula.Enabled = false;
            }
        }

        #endregion Eventos                                                

        
        #region Métodos Privados

        /// <summary>
        /// Mostrar la lista de Tulas por periodo de tiempo.
        /// </summary>
        private void listarDatos()
        {

            try
            {
                DateTime inicio = dtpFecha.Value;
                DateTime finalizacion = dtpFecha.Value;
                _listatulas = _atencion.listarTulasPorFecha(DateTime.Parse(inicio.ToShortDateString()).AddDays(-3), DateTime.Parse(inicio.ToShortDateString()).AddDays(1));
                dgvTulas.DataSource = _listatulas;
                for (int i = 0; i < dgvTulas.Columns.Count; i++)
                {
                    if (!dgvTulas.Columns[i].Name.Equals("ID") && !dgvTulas.Columns[i].Name.Equals("Tula"))
                    {
                        dgvTulas.Columns[i].Visible = false;
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
