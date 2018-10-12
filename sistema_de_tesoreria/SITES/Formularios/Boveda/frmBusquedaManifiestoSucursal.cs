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
using CommonObjects.Clases;

namespace GUILayer.Formularios.Boveda
{
    public partial class frmBusquedaManifiestoSucursal : Form
    {

        #region Atributos

        private AtencionBL _atencion = AtencionBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _usuario = null;

        private Bolsa _bolsa = null;

        private ManifiestoSucursalCarga _manifiesto = null;

        private BindingList<Bolsa> _bolsas = null;

        private bool _coordinador = false;

        #endregion Atributos


        #region Constructor

        public frmBusquedaManifiestoSucursal(Colaborador usuario)
        {
            InitializeComponent();
            _usuario = usuario;

            try
            {
                dgvManifiestos.AutoGenerateColumns = false;
                dgvTulasManifiesto.AutoGenerateColumns = false;
                cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.Boveda, Puestos.CajeroA, Puestos.CajeroB);

                _coordinador = _usuario.Puestos.Contains(Puestos.Coordinador) || _usuario.Puestos.Contains(Puestos.Supervisor);

                if (_coordinador)
                {
                    cboCajero.Enabled = true;
                }
                else
                {
                    cboCajero.Text = _usuario.ToString();

                }

            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        #endregion Constructor

        #region Metodos Públicos

        // Realiza la busqueda del manifiesto
        public void busqueda()
        {
            try
            {

                dgvManifiestos.DataSource = null;


                DateTime fecha = dtpFechaCierre.Value;

                Colaborador colaborador = cboCajero.SelectedIndex == 0 ?
                    null : (Colaborador)cboCajero.SelectedItem;

                if (_atencion.listarManifiestosSucursalporColaborador(fecha, colaborador).Count == 0)
                {
                    MessageBox.Show(" No se encontro manifiesto ");
                    dgvManifiestos.DataSource = _manifiesto;
                }
                else
                {
                    dgvManifiestos.DataSource = _atencion.listarManifiestosSucursalporColaborador(fecha, colaborador);
                    _manifiesto = (ManifiestoSucursalCarga)dgvManifiestos.SelectedRows[0].DataBoundItem;
                    listartulas();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Lista la tulas que corresponden al manifiesto buscado
        /// </summary>
        public void listartulas()
        {

            try
            {
                // _manifiesto = (ManifiestoSucursalCarga)dgvManifiestos.SelectedRows[0].DataBoundItem;

                Bolsa nuevabolsa = new Bolsa();
                BindingList<Bolsa> nuevalista = _atencion.listarBolsasSucursalPorManifiesto(_manifiesto);
                nuevalista.Add(nuevabolsa);
                dgvTulasManifiesto.DataSource = nuevalista;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion

        
        #region Eventos

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.busqueda();
        }

        private void cboCajero_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvManifiestos.DataSource = null;
            dgvTulasManifiesto.DataSource = null;
            btnBuscar.Enabled = true;
        }

        private void dgvManifiestos_SelectionChanged(object sender, EventArgs e)
        {
            _manifiesto = (ManifiestoSucursalCarga)dgvManifiestos.SelectedRows[0].DataBoundItem;
            this.listartulas();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        
        #endregion Eventos 

       

     
      


    }
}
