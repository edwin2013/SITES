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
using Microsoft.VisualBasic;
using CommonObjects.Clases;
namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmConsultaInfoManifiesto : Form
    {

        #region Atributos
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private Colaborador _colaborador = null;
        private int idManifiesto = 0;
        private Tula tulaActual = null;
        private ProcesamientoBajoVolumenManifiesto _manifiesto;
        private bool puedeModificar = false;
        #endregion Atributos


        #region Constructor

        public frmConsultaInfoManifiesto(Colaborador c)
        {
            InitializeComponent();
            this._colaborador = c;
            cboCliente.ValueMember = "pk_ID";
            cboCliente.DisplayMember = "Nombre";
            cboPuntoVenta.ValueMember = "pk_ID";
            cboPuntoVenta.DisplayMember = "Nombre";
            cboCliente.DataSource = _mantenimiento.listarClientesDT();
            cboCliente.SelectedIndex = -1;
        }

        #endregion Constructor       

        #region Eventos

        private void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDepositos.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Eliminar este depósito?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    eliminarDeposito();
                    actualizarCierreCajero();
                    _mantenimiento.actualizarCierreCajero(_manifiesto);
                    //si aún no se ha terminado de ingresar el manifiesto, no hacer nada relacionado con inconsistencias
                    DataTable dt = _mantenimiento.procesamientoBVPendiente(_manifiesto.ID);
                    if (dt.Rows.Count == 0)
                    {
                        _mantenimiento.updateProaInconsistenciasManifiesto(_manifiesto, _colaborador);
                    }
                }
            }
        }

        private void eliminarDeposito()
        {
            try
            {
                DataGridViewRow row = dgvDepositos.SelectedRows[0];
                int depId = Int32.Parse(row.Cells["id2"].Value.ToString());
                ConteoBillete conteoBillete = _mantenimiento.selectConteoBillete(depId);
                _mantenimiento.eliminarDeposto(depId, _colaborador.ID);

                dgvDepositos.Rows.Remove(row);
                // _mantenimiento.updateProcesamientoBajoVolumen(new ConteoBillete(),conteoBillete);
                MessageBox.Show("Deposito Eliminado Correctamente", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                throw new Exception("ErrorEliminandoDeposito");
            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            if (dgvDepositos.SelectedRows.Count > 0)
            {

                DataGridViewRow row = dgvDepositos.SelectedRows[0];
                int depositoId = Int32.Parse(row.Cells[0].Value.ToString());
                frmActualizarBajoVolumen deposito = new frmActualizarBajoVolumen(depositoId, _colaborador, _manifiesto, tulaActual, puedeModificar);
                deposito.ShowDialog();
                barredora();
                if (txtManifiesto.Text != "")
                    try
                    {
                        cargarManfiesto();
                    }
                    catch (Excepcion ex)
                    {
                        throw new Excepcion(ex.Message);
                    }
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            barredora();
            if (txtManifiesto.Text != "")
                try
                {
                    cargarManfiesto();
                }
                catch (Excepcion ex)
                {
                    throw new Excepcion(ex.Message);
                }
            else
                MessageBox.Show("Escriba el código por favor", "Noficación", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void barredora()
        {
            for (int i = dgvTulas.Rows.Count - 1; i >= 0; i--)
            {
                dgvTulas.Rows.RemoveAt(i);
            }
            for (int i = dgvDepositos.Rows.Count - 1; i >= 0; i--)
            {
                dgvDepositos.Rows.RemoveAt(i);
            }
            numColones.Value = 0;
            numDolares.Value = 0;
            numEuros.Value = 0;
            cboCliente.SelectedIndex = -1;
            cboPuntoVenta.SelectedIndex = -1;
            _manifiesto = null;
        }

        private void cargarManfiesto()
        {
            try
            {
                string code = txtManifiesto.Text;
                idManifiesto = _mantenimiento.selectManifiestoId(code);
                if (idManifiesto != 0)
                {
                    _manifiesto = _mantenimiento.obtnProcesamientoBajoVolumenDeposito(idManifiesto);
                    if (_manifiesto != null)
                    {
                        _manifiesto.Codigo = code;
                        puedeModificar =_mantenimiento.puedeModificarManifiesto(idManifiesto); 
                        if (!puedeModificar)
                            MessageBox.Show("El manifiesto solo se puede consultar, puesto que fue ingresado un día anterior.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        enableButtons(puedeModificar);
                        cargarComponentes();
                    }
                    else
                    {
                        MessageBox.Show("El manifiesto no se encuentra registrado en procesamiento de bajo volumen, valide por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("El manifiesto no se encuentra registrado en la base de datos, valide por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Excepcion e) { throw new Excepcion(e.Message); }

        }

        private void cargarComponentes()
        {
            txtManifiesto.ReadOnly = true;
            numDolares.ReadOnly = true;
            numEuros.ReadOnly = true;
            numColones.Value = _manifiesto.Monto_Colones;
            numDolares.Value = _manifiesto.Monto_Dolares;
            numEuros.Value = _manifiesto.Monto_Euros;
            cargarTula();
        }

        private void enableButtons(bool enable)
        {
            btnEditarManifiesto.Enabled = enable;
            btnQuitarCorte.Enabled = enable;
            btnEliminarDeposito.Enabled = enable;
            btnEditarTulaCodigo.Enabled = enable;
            pnlManifiesto.Enabled = enable;
        }

        private void cargarTula()
        {
            DataTable dt = _mantenimiento.selectTulas(idManifiesto);
            if (dt.Rows.Count > 0)
            {
                dgvTulas.DataSource = dt;
                cboCliente.SelectedValue = dt.Rows[0][3].ToString();
                cboPuntoVenta.SelectedValue = dt.Rows[0][4].ToString();
                dgvTulas.ClearSelection();
            }
            else
            {
                MessageBox.Show("El manifiesto no posee tulas asociadas, validar por favor", "Nota", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

        }



        #endregion Eventos    

        private void clearComponents()
        {
            dgvDepositos.DataSource = null;
            dgvTulas.DataSource = null;
            cboCliente.SelectedIndex = -1;
            cboPuntoVenta.SelectedIndex = -1;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvTulas.SelectedRows.Count > 0)
                mostrarfrmTulaCode();
        }

        private void mostrarfrmTulaCode()
        {
            try
            {
                frmActualizaCodigoTula frmCodTula = new frmActualizaCodigoTula();
                if (frmCodTula.ShowDialog(this) == DialogResult.OK)
                {
                    DataGridViewRow row = dgvTulas.SelectedRows[0];
                    int tulaId = Int32.Parse(row.Cells["Id"].Value.ToString());
                    _mantenimiento.modificarCodigoTula(frmCodTula.txtCodigoTulaNuevo.Text, tulaId, _colaborador);
                    frmCodTula.Close();
                    MessageBox.Show("El código de la Tula fue cambiado de forma satisfactoria");
                }
                frmCodTula.Dispose();
            }
            catch
            {
                throw new Excepcion("Error al modificar el codigo de tula");
            }
        }


        private void btnQuitarCorte_Click(object sender, EventArgs e)
        {
            if (dgvTulas.SelectedRows.Count > 0)
                try
                {
                    if (MessageBox.Show("¿Eliminar esta tula y sus depósitos?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        DataGridViewRow row = dgvTulas.SelectedRows[0];
                        int tulaId = Int32.Parse(row.Cells["Id"].Value.ToString());
                        _mantenimiento.eliminarTula(tulaId, _colaborador.ID);
                        DataTable dt = _mantenimiento.procesamientoBVPendiente(_manifiesto.ID);
                        if (dt.Rows.Count == 0)
                        {
                            _mantenimiento.updateProaInconsistenciasManifiesto(_manifiesto, _colaborador);
                        }
                        MessageBox.Show("Tula eliminada satisfactoriamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvDepositos.DataSource = null;
                        cargarTula();
                    }
                }
                catch (Excepcion ex)
                {
                    throw new Exception(ex.Message);
                }
        }


        private void dgvTulas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvTulas.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvTulas.SelectedRows[0];
                    tulaActual = new Tula();
                    tulaActual.ID = Int32.Parse(row.Cells["Id"].Value.ToString());
                    tulaActual.Codigo = row.Cells["Tula"].Value.ToString();
                    dgvDepositos.DataSource = _mantenimiento.SelectDepositos(tulaActual.ID);
                }
            }
            catch
            {
                MessageBox.Show("Error al seleccionar el registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }




        #region Métodos Privados

        #endregion Métodos Privados


        private void btnEditarManifiesto_Click(object sender, EventArgs e)
        {
            if (_manifiesto != null && txtManifiesto.Text != "")
            {
                if (cboCliente.SelectedIndex != -1 && cboPuntoVenta.SelectedIndex != -1)
                {
                    if (DialogResult.Yes == MessageBox.Show("¿Seguro que desea actualizar los datos del manifiesto?", "Alerta", MessageBoxButtons.YesNo))
                    {
                        try
                        {
                            DataRowView row1 = (DataRowView)cboCliente.SelectedItem;
                            int cliente = Int32.Parse(row1["pk_ID"].ToString());
                            DataRowView row2 = (DataRowView)cboPuntoVenta.SelectedItem;
                            int puntoV = Int32.Parse(row2["pk_ID"].ToString());
                            _mantenimiento.actualizarManifiesto(_colaborador.ID, _manifiesto.ID, cliente, puntoV, numColones.Value, numDolares.Value, numEuros.Value);
                            cargarManfiesto();
                            DataTable dt = _mantenimiento.procesamientoBVPendiente(_manifiesto.ID);
                            if (dt.Rows.Count == 0)
                            {
                                _mantenimiento.updateProaInconsistenciasManifiesto(_manifiesto, _colaborador);
                            }
                            MessageBox.Show("Datos Actualizados Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Excepcion ex)
                        {
                            MessageBox.Show("Error al actualizar los datos. Detalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Es necesarios seleccionar tanto el punto de venta como el cliente", "Alerta", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Es necesarios buscar primero el manifiesto", "Alerta", MessageBoxButtons.OK);
            }


        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPuntoVenta.SelectedIndex = -1;
            if (cboCliente.SelectedIndex != -1)
            {
                DataRowView row = (DataRowView)cboCliente.SelectedItem;
                String cliente = row["pk_ID"].ToString();
                cboPuntoVenta.DataSource = _mantenimiento.obtenerPuntosVentaClienteID(cliente);
                cboPuntoVenta.SelectedIndex = -1;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            barredora();
            txtManifiesto.Text = "";
            txtManifiesto.ReadOnly = false;
        }

        private void frmConsultaInfoManifiesto_Load(object sender, EventArgs e)
        {

        }

        private void dgvTulas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void actualizarCierreCajero()
        {

            //necesito el cajero que procesó manifiesto
        }

        private void gbDepositos_Enter(object sender, EventArgs e)
        {

        }
    }
}


