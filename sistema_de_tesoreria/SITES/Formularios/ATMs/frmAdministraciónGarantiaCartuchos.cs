using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUILayer.Formularios.ATMs;
using BussinessLayer;
using CommonObjects.Clases;
using CommonObjects;

namespace GUILayer.Formularios.Níquel
{
    public partial class frmAdministraciónGarantiaCartuchos : Form
    {
        #region Atributos
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private Colaborador _usuario = new Colaborador();
        private BindingList<GarantiaCartucho> _garantias = new BindingList<GarantiaCartucho>();

        #endregion Atributos

        #region Constructor
        public frmAdministraciónGarantiaCartuchos()
        {
            InitializeComponent();

            // Generar la lista de garantias

            _garantias = _mantenimiento.listarGarantiaCartucho();

            if (_garantias == null)
                _garantias = new BindingList<GarantiaCartucho>();


            dgvGarantíaCartuchos.AutoGenerateColumns = false;
            dgvGarantíaCartuchos.DataSource = _garantias;
        }

        public frmAdministraciónGarantiaCartuchos(Colaborador us)
        {
            InitializeComponent();

            try
            {
                _usuario = us;

                // Generar la lista de garantias

                _garantias = _mantenimiento.listarGarantiaCartucho();

                if (_garantias == null)
                    _garantias = new BindingList<GarantiaCartucho>();

           
                dgvGarantíaCartuchos.AutoGenerateColumns = false;
                dgvGarantíaCartuchos.DataSource = _garantias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Constructor

        #region Eventos
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmMantenimientoGarantiaCartucho formulario = new frmMantenimientoGarantiaCartucho(_usuario);

            formulario.ShowDialog(this);
        }

        #endregion Eventos

        #region Metodos Privados

        public void agregarGarantiaCartucho(GarantiaCartucho garantia)
        {
            BindingList<GarantiaCartucho> garantias = (BindingList<GarantiaCartucho>)dgvGarantíaCartuchos.DataSource;
            garantias.Add(garantia);
        }


        public void actualizarLista()
        {
            dgvGarantíaCartuchos.Refresh();
            dgvGarantíaCartuchos.AutoResizeColumns();
        }

        #endregion Metodos Privados
    }
}
