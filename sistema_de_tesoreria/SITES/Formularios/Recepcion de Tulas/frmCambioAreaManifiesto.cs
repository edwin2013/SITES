//
//  @ Project : 
//  @ File Name : frmCambioAreaManifiesto.cs
//  @ Date : 28/05/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using System.ComponentModel;

namespace GUILayer
{

    public partial class frmCambioAreaManifiesto : Form
    {
        #region Atributos

        private AtencionBL _atencion = AtencionBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _colaborador = null;

        #endregion Atributos

        #region Constructor

        public frmCambioAreaManifiesto(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;

            cboAreas.Items.Add(AreasManifiestos.Boveda);
            cboAreas.Items.Add(AreasManifiestos.CentroEfectivo);
            cboAreas.Items.Add(AreasManifiestos.ProcesoExterno);
            dgvManifiestos.AutoGenerateColumns = false;

            cboCajeros.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB, Puestos.Digitador, Puestos.Coordinador);
            BindingList<Colaborador> listacoordinador = _seguridad.listarColaboradoresPorPuestoArea(Areas.Boveda, Puestos.CajeroA, Puestos.CajeroB, Puestos.Coordinador);
            
            foreach (Colaborador cajeroboveda in listacoordinador)
            {
                cboCajeros.ListaMostrada.Add(cajeroboveda);
            }
            
           

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de buscar.
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                string manifiesto_buscado = txtCodigoBuscado.Text;

                dgvManifiestos.DataSource = _atencion.listarManifiestosPorCodigo(manifiesto_buscado);

                txtCodigoBuscado.Text = string.Empty;

                this.dgvManifiestos_SelectionChanged(sender, e);
            
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Se selecciona otro manifiesto en la lista de manifiestos.
        /// </summary>
        private void dgvManifiestos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvManifiestos.SelectedRows.Count > 0)
            {
                Manifiesto manifiesto = (Manifiesto)dgvManifiestos.SelectedRows[0].DataBoundItem;

                txtCodigoManifiesto.Text = manifiesto.Codigo;
                txtReceptor.Text = manifiesto.Receptor.ToString();
                txtEmpresa.Text = manifiesto.Empresa.Nombre;
                txtCaja.Text = manifiesto.Caja.ToString();
                txtGrupo.Text = manifiesto.Grupo.Nombre;
                cboAreas.Text = manifiesto.Area.ToString();

                if (manifiesto.Cajero_Receptor == null)
                {
                    txtCajeroAsignado.Text = string.Empty;
                    txtCajeroReceptor.Text = string.Empty;
                    
                }
                else
                {
                    txtCajeroReceptor.Text = manifiesto.Cajero_Receptor.ToString();
                    if (manifiesto.Cajero_Reasignado == null)
                        txtCajeroAsignado.Text = string.Empty;
                    else
                    {
                        txtCajeroAsignado.Text = manifiesto.Cajero_Reasignado.ToString();
                    }
                }
                cboCajeros.Focus();
    
                gbDatosManifiesto.Enabled = true;
            }
            else
            {
                this.Limpiar();              
            }

        }

        /// <summary>
        /// Se escribe en el texto de búsqueda.
        /// </summary>
        private void txtCodigoBuscado_TextChanged(object sender, EventArgs e)
        {
            btnBuscar.Enabled = txtCodigoBuscado.Text.Length >= 4;
        }

        #endregion Eventos

        #region Metodos Privados

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvManifiestos.SelectedRows.Count > 0)
                {
                    if (cboCajeros.SelectedItem != null)
                    {
                        Manifiesto manifiesto = (Manifiesto)dgvManifiestos.SelectedRows[0].DataBoundItem;

                        if (manifiesto.Cajero_Receptor == null)
                            manifiesto.Cajero_Receptor = (Colaborador)cboCajeros.SelectedValue;

                        manifiesto.Area = (AreasManifiestos)cboAreas.SelectedItem;
                        manifiesto.Cajero_Reasignado = (Colaborador)cboCajeros.SelectedItem;

                        _atencion.actualizarAreaManifiesto(manifiesto);

                        this.Limpiar();
                        dgvManifiestos.DataSource = null;

                        MessageBox.Show("Manifiesto actualizado correctamente!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCodigoBuscado.Focus();
                    }
                    else MessageBox.Show("Seleccione el Cajero Asignado!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
 
             }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

           

        }
         #endregion Metodos Privados

        #region Metodos Publicos

        public void Limpiar()
        {
            txtCodigoManifiesto.Text = string.Empty;
            txtReceptor.Text = string.Empty;
            txtEmpresa.Text = string.Empty;
            txtCaja.Text = string.Empty;
            txtGrupo.Text = string.Empty;
            cboAreas.SelectedIndex = 0;
            txtCajeroReceptor.Text = string.Empty;
            txtCajeroAsignado.Text = string.Empty;
            cboCajeros.Text = string.Empty;

            gbDatosManifiesto.Enabled = false;

           
        }


        #endregion Metodos Publicos
    }

}
