using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using CommonObjects.Clases;
using CommonObjects;
using LibreriaMensajes;

namespace GUILayer.Formularios.Recepcion_de_Tulas
{
    public partial class frmRecepcionDocumentos : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;

        private BindingList<Carga> cargas = new BindingList<Carga>();
        private BindingList<Carga> cargasentrega = new BindingList<Carga>();
        private List<Color> _colores = new List<Color>();
        private Colaborador _usuario = new Colaborador();
        private BindingList<Manifiesto> manifiestos= new BindingList<Manifiesto>();
        private BindingList<Tula> tulas = new BindingList<Tula>();

        private Manifiesto _manifiesto = new Manifiesto();
        private Tula _tula = new Tula();
        
        #endregion Atributos

        #region Constructor
        public frmRecepcionDocumentos(Colaborador usuario)
        {
            InitializeComponent();
            _usuario = usuario;

            txtReceptor.Text = _usuario.Nombre + " " + _usuario.Primer_apellido + " " + _usuario.Segundo_apellido;

            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();

            dgvManifiestos.AutoGenerateColumns = false;
            dgvManifiestos.DataSource = manifiestos;
            dgvTulas.AutoGenerateColumns = false;
        }

        #endregion Constructor

        #region Eventos
     
        private void btnGuardarManifiestos_Click(object sender, EventArgs e)
        {
            try
            {
                if (_manifiesto.ID == 0)
                {
                    Manifiesto nuevo = new Manifiesto();
                    nuevo.Codigo = txtManifiesto.Text;
                    nuevo.Empresa = (EmpresaTransporte)cboTransportadora.SelectedItem;
                    nuevo.Receptor = _usuario;

                    if (!_atencion.verificarDocumento(ref nuevo))
                    {
                        _atencion.agregarDocumento(ref nuevo);
                        manifiestos.Add(nuevo);
                        txtManifiesto.Text = "";
                    }
                    else
                        Mensaje.mostrarMensaje("ManifiestoDuplicado");
                 }
                else
                {
                    _manifiesto.Codigo = txtManifiesto.Text;
                    _atencion.actualizarDocumento(_manifiesto);
                    txtManifiesto.Text = "";
                }
                dgvManifiestos.Refresh();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardarTula_Click(object sender, EventArgs e)
        {
            if (_tula.ID == 0)
            {
                    Manifiesto manif = (Manifiesto)dgvManifiestos.SelectedRows[0].DataBoundItem;
                    Tula t = new Tula();
                    t.Codigo = txtTula.Text;
                    t.Manifiesto = manif;

                    if (!_atencion.verificarTulaDocumento(ref t))
                    {
                        _atencion.agregarTulaDocumento(ref t);
                        manif.AgregarTula(t);
                        tulas.Add(t);
                        txtTula.Text = "";
                    }
            }
            else
            {
                _tula.Codigo = txtTula.Text;
                _atencion.actualizarTulaDocumento(_tula);
                txtTula.Text = "";
            }
            dgvTulas.Refresh();
        }

        private void dgvManifiestos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvManifiestos.SelectedRows.Count > 0 || dgvTulas.SelectedRows.Count > 0)
            {
                txtTula.Enabled = true;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;

                Manifiesto m = (Manifiesto)dgvManifiestos.SelectedRows[0].DataBoundItem;
                dgvTulas.DataSource = m.Tulas;
                dgvTulas.Refresh();
            }
            else
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                txtTula.Enabled = false;
            }
        }

        private void txtManifiesto_TextChanged(object sender, EventArgs e)
        {
            if (txtManifiesto.Text != "")
            {
                btnGuardarManifiestos.Enabled = true;
            }
            else
            {
                btnGuardarManifiestos.Enabled = false;
            }
        }

        private void txtTula_TextChanged(object sender, EventArgs e)
        {
            if (txtTula.Text != "")
            {
                btnGuardarTula.Enabled = true;
            }
            else
            {
                btnGuardarTula.Enabled = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTulas.SelectedRows.Count > 0)
            {
                Tula t = (Tula)dgvTulas.SelectedRows[0].DataBoundItem;
                Manifiesto m = t.Manifiesto;
                _atencion.eliminarTulaDocumento(t);
                m.EliminarTula(t);
                dgvTulas.Refresh();
            }
            else if (dgvManifiestos.SelectedRows.Count > 0)
            {
                Manifiesto m = (Manifiesto)dgvManifiestos.SelectedRows[0].DataBoundItem; ;
                _atencion.eliminarDocumento(m);
                manifiestos.Remove(m);
                dgvManifiestos.Refresh();
                dgvTulas.DataSource = null;
                dgvTulas.Refresh();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvTulas.SelectedRows.Count > 0)
            {
                Tula t = (Tula)dgvTulas.SelectedRows[0].DataBoundItem;
                Manifiesto m = t.Manifiesto;
                _tula = t;
                txtTula.Text = t.Codigo;
                //_atencion.eliminarTulaDocumento(t);
                //m.EliminarTula(t);
                //dgvTulas.Refresh();
            }
            else if (dgvManifiestos.SelectedRows.Count > 0)
            {
                Manifiesto m = (Manifiesto)dgvManifiestos.SelectedRows[0].DataBoundItem;
                txtManifiesto.Text = m.Codigo;
                _manifiesto = m;
                //_atencion.eliminarDocumento(m);
                // manifiestos.Remove(m);
                //dgvManifiestos.Refresh();
                //dgvTulas.DataSource = null;
                //dgvTulas.Refresh();
            }
        }

        #endregion Eventos

    }
}
