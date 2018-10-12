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
using CommonObjects.Clases;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmInconsistenciasPorResolver : Form
    {
        

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;        
        private InconsistenciaDepositoBajoVolumen infoinconsistencia;
        private Colaborador usuario;

        #endregion Atributos

        #region Constructor

        public frmInconsistenciasPorResolver(Colaborador _usuario)
        {
            InitializeComponent();
            cboCliente.ListaMostrada = _mantenimiento.listarClientes(string.Empty);
            cboCliente.ListaMostrada.Insert(0, new Cliente(0, "Todos"));
            usuario = _usuario;
        }

        #endregion Constructor               

        #region Eventos

        private void btnSalir_Click(object sender, EventArgs e)
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

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (validarseleccion()) {                
                //dgvInconsistencias.DataSource = _mantenimiento.ObtenerPROAInconsistenciaporResolver(cliente, estado);
                //for (int i = 0; i < dgvInconsistencias.Rows.Count; i++)
                //{
                //    switch (dgvInconsistencias.Rows[i].Cells["TipoInconsistencia"].Value.ToString())
                //    {
                //        case "0":
                //            dgvInconsistencias.Rows[i].DefaultCellStyle.BackColor = Color.PapayaWhip;
                //            break;
                //        case "1":
                //            dgvInconsistencias.Rows[i].DefaultCellStyle.BackColor = Color.LightSeaGreen;
                //            break;
                //        case "2":
                //            dgvInconsistencias.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
                //            break;
                //    }
                //}
                //if (cboEstadoInconsistencia.SelectedIndex == 1)
                //{
                //    btnModificar.Enabled = false;
                //    btnResolver.Enabled = false;
                //}
                //else
                //{
                //    btnModificar.Enabled = true;
                //    btnResolver.Enabled = true;
                //}
                obtenerdatosInconsistenciasPROA();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                frmModificarInconsistenciaPorResolver formulario = new frmModificarInconsistenciaPorResolver(Convert.ToInt32(dgvInconsistencias.SelectedRows[0].Cells["ID"].Value));
                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        private void btnResolver_Click(object sender, EventArgs e)
        {
            if (dgvInconsistencias.SelectedRows[0].Cells["TipoInconsistencia"].Value.Equals(1))
            {
                infoinconsistencia = _mantenimiento.ObtenerDetallePROAInconsistenciaporResolver(Convert.ToInt32(dgvInconsistencias.SelectedRows[0].Cells["ID"].Value));
                if (MessageBox.Show("Está seguro de que desea resolver la inconsistencia", "Resolución de Inconsistencia", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    _mantenimiento.ResolverPROAInconsistencia(ref infoinconsistencia, ref usuario);
                    MessageBox.Show("Inconsistencia resuelta");
                    infoinconsistencia = null;
                    obtenerdatosInconsistenciasPROA();
                }
            }
            else
            {
                if (infoinconsistencia != null)
                {
                    if ((infoinconsistencia.procesamiento.Cedula.Equals(string.Empty) == false) && (infoinconsistencia.procesamiento.CodigoTransaccion.Equals(string.Empty) == false) &&
                        (infoinconsistencia.procesamiento.Cuenta.Equals(string.Empty) == false) && (infoinconsistencia.procesamiento.NumeroDeposito.Equals(string.Empty) == false))
                    {
                        if (MessageBox.Show("Está seguro de que desea resolver la inconsistencia", "Resolución de Inconsistencia", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            _mantenimiento.ResolverPROAInconsistencia(ref infoinconsistencia, ref usuario);
                            MessageBox.Show("Inconsistencia resuelta");
                            infoinconsistencia = null;
                            obtenerdatosInconsistenciasPROA();
                        }
                    }
                    else
                    {
                        MessageBox.Show("La inconsistencia no se puede resolver debido a que tiene información incompleta en algun(os) campo(s)");
                    }
                }
                else
                {
                    MessageBox.Show("La inconsistencia no se puede resolver debido a que tiene información incompleta en algun(os) campo(s)");
                }
            }
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedIndex != -1)
            {
                epError.SetError(cboCliente, "");
            }
        }

        private void cboEstadoInconsistencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedIndex != -1)
            {
                epError.SetError(cboEstadoInconsistencia, "");
            }
        }

        #endregion Eventos                                


        #region Métodos Privados

        private Boolean validarseleccion()
        {
            if (cboCliente.SelectedIndex == -1)
            {
                epError.SetError(cboCliente, "Falta seleccionar el cliente para realizar la búsqueda");
                return false;
            }
            if (cboEstadoInconsistencia.SelectedIndex == -1)
            {
                epError.SetError(cboEstadoInconsistencia, "Falta seleccionar el estado de inconsistencia para realizar la búsqueda");
                return false;
            }
            return true;
        }

        public void procesarinconsistencia(InconsistenciaDepositoBajoVolumen infomodinconsistencia) 
        {
            infoinconsistencia = infomodinconsistencia;
            dgvInconsistencias.SelectedRows[0].Tag = infoinconsistencia;
            if (!infoinconsistencia.procesamiento.NumeroDeposito.Equals(string.Empty))
                dgvInconsistencias.SelectedRows[0].Cells[7].Value = infoinconsistencia.procesamiento.NumeroDeposito;
            if (!infoinconsistencia.procesamiento.NumeroDeposito.Equals(string.Empty))
                dgvInconsistencias.SelectedRows[0].Cells[8].Value = infoinconsistencia.procesamiento.Cuenta;
        }

        private void obtenerdatosInconsistenciasPROA()
        {
            int cliente = ((Cliente)cboCliente.SelectedItem).Id;
            byte estado = Convert.ToByte(cboEstadoInconsistencia.SelectedIndex);
            dgvInconsistencias.DataSource = _mantenimiento.ObtenerPROAInconsistenciaporResolver(cliente, estado);
            for (int i = 0; i < dgvInconsistencias.Rows.Count; i++)
            {
                switch (dgvInconsistencias.Rows[i].Cells["TipoInconsistencia"].Value.ToString())
                {
                    case "0":
                        dgvInconsistencias.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                        break;
                    case "1":
                        dgvInconsistencias.Rows[i].DefaultCellStyle.BackColor = Color.LightSeaGreen;
                        break;
                    case "2":
                        dgvInconsistencias.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
                        break;
                }                
            }
            dgvInconsistencias.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvInconsistencias.Columns["Hora"].DefaultCellStyle.Format = "hh:mm:ss";
            if (cboEstadoInconsistencia.SelectedIndex == 1)
                {
                    btnModificar.Enabled = false;
                    btnResolver.Enabled = false;
                }
                else
                {                    
                    btnResolver.Enabled = true;
                }
        }

        #endregion Métodos Privados

        private void dgvInconsistencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1)
            {
                if (e.RowIndex > -1)
                {
                    if (dgvInconsistencias.Rows[e.RowIndex].Cells["TipoInconsistencia"].Value.Equals(1))
                    {
                        btnModificar.Enabled = false;
                    }
                    else
                    {
                        btnModificar.Enabled = true;
                    }
                }
            }
        }

        private void dgvInconsistencias_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvInconsistencias.SelectedRows.Count > 0)
                {
                    if (dgvInconsistencias.SelectedRows[0].Cells["TipoInconsistencia"].Value.Equals(1))
                    {
                        btnModificar.Enabled = false;
                    }
                    else
                    {
                        btnModificar.Enabled = true;
                    }
                }                
            }
            catch(Excepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
