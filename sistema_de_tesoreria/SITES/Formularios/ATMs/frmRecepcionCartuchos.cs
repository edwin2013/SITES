using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects;
using BussinessLayer;
using CommonObjects.Clases;
using LibreriaReportesOffice;
using LibreriaMensajes;

namespace GUILayer.Formularios.ATMs
{
    public partial class frmRecepcionCartuchos : Form
    {
        #region Atributos
        Colaborador _usuario = new Colaborador();
        MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        int _pedidoDispensador = 0;
        int _pedidoENA = 0;
        int _pedidoRechazo = 0;

        BindingList<Cartucho> _malosTesoreria = new BindingList<Cartucho>();
        BindingList<Cartucho> _malosTaller = new BindingList<Cartucho>();
        BindingList<Cartucho> _NoRecuperable = new BindingList<Cartucho>();

        BindingList<RecepcionCartucho> _Tesoreria = new BindingList<RecepcionCartucho>();
        BindingList<RecepcionCartucho> _Taller = new BindingList<RecepcionCartucho>();
        BindingList<RecepcionCartucho> _NRecup = new BindingList<RecepcionCartucho>();

        #endregion Atributos

        #region Constructor
        
        public frmRecepcionCartuchos()
        {
            InitializeComponent();
        }



        public frmRecepcionCartuchos(Colaborador usuario)
        {
            InitializeComponent();
            _usuario = usuario;

            dgvNoRecuperable.AutoGenerateColumns = false;
            dgvRecibir.AutoGenerateColumns = false;
            dgvEntregar.AutoGenerateColumns = false;

            _malosTaller = _mantenimiento.listarCartuchosEstado(EstadosCartuchos.EntregadoTaller, string.Empty);
            _malosTesoreria = _mantenimiento.listarCartuchosEstado(EstadosCartuchos.Malo, string.Empty);
            _NoRecuperable = _mantenimiento.listarCartuchosEstado(EstadosCartuchos.NoRecuperable, string.Empty);

            _Taller = _mantenimiento.listarCartuchosMaloTaller(_malosTaller);
            _Tesoreria = _mantenimiento.listarCartuchosMaloTesoreria(_malosTesoreria);
            _NRecup = _mantenimiento.listarCartuchosNoRecuperable(_NoRecuperable);

            dgvEntregar.DataSource = _Tesoreria;
            dgvRecibir.DataSource = _Taller;
            dgvNoRecuperable.DataSource = _NRecup;

            dgvNoRecuperable.AutoGenerateColumns = false;
            dgvRecibir.AutoGenerateColumns = false;
            dgvEntregar.AutoGenerateColumns = false;
            
        }

        #endregion Constructor

        #region Eventos

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            _NoRecuperable.Clear();
            _NRecup.Clear();
           _NoRecuperable = _mantenimiento.listarCartuchosEstado(EstadosCartuchos.NoRecuperable, cboCartucho.Text);
           _NRecup = _mantenimiento.listarCartuchosNoRecuperable(_NoRecuperable);
            dgvNoRecuperable.DataSource = _NRecup;
        }

        private void cbTodosEntTaller_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTodosEntTaller.Checked == true)
            {
                foreach (DataGridViewRow row in dgvEntregar.Rows)
                 {
                     DataGridViewCheckBoxCell select = (DataGridViewCheckBoxCell)row.Cells[0];
                     select.Value = 1;
                 }      
            }
            else
            {
                foreach (DataGridViewRow row in dgvEntregar.Rows)
                {
                    DataGridViewCheckBoxCell select = (DataGridViewCheckBoxCell)row.Cells[0];
                    select.Value = select.FalseValue;
                }    
            }
        }

        private void cbTodosRecibir_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTodosRecibir.Checked == true)
            {
                foreach (DataGridViewRow row in dgvRecibir.Rows)
                {
                    DataGridViewCheckBoxCell select = (DataGridViewCheckBoxCell)row.Cells[0];
                    select.Value = 1;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvRecibir.Rows)
                {
                    DataGridViewCheckBoxCell select = (DataGridViewCheckBoxCell)row.Cells[0];
                    select.Value = select.FalseValue;
                }
            }
        }

        private void cbTodosRecuperables_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTodosRecuperables.Checked == true)
            {
                foreach (DataGridViewRow row in dgvNoRecuperable.Rows)
                {
                    DataGridViewCheckBoxCell select = (DataGridViewCheckBoxCell)row.Cells[0];
                    select.Value = 1;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvNoRecuperable.Rows)
                {
                    DataGridViewCheckBoxCell select = (DataGridViewCheckBoxCell)row.Cells[0];
                    select.Value = select.FalseValue;
                }
            }
        }

        private void btnExportarMalosTesoreria_Click(object sender, EventArgs e)
        {
            if (Mensaje.mostrarMensajeConfirmacion("MensajeMalosTesoreriaEliminacion") == DialogResult.Yes)
            {
                BindingList<Cartucho> c = new BindingList<Cartucho>();
                BindingList<RecepcionCartucho> recepcion = new BindingList<RecepcionCartucho>();

                //cambiar estado a Malo en Taller
                foreach (DataGridViewRow row in dgvEntregar.Rows)
                {
                    DataGridViewCheckBoxCell select = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(select.Value))
                    {
                        RecepcionCartucho entregado = (RecepcionCartucho)dgvEntregar.Rows[row.Index].DataBoundItem;

                        entregado.Cartucho.Estado = EstadosCartuchos.EntregadoTaller;

                        if (!_Taller.Contains(entregado))
                        {
                            _Taller.Add(entregado);
                        }
                        if (!c.Contains(entregado.Cartucho))
                        {
                            c.Add(entregado.Cartucho);
                        }

                        recepcion.Add(entregado);
                    }
                }

                foreach (Cartucho cart in c)
                {

                    _mantenimiento.actualizarCartuchoEstado(cart, _usuario);
                    if (!_malosTaller.Contains(cart))
                    {
                        _malosTaller.Add(cart);
                    }
                    _malosTesoreria.Remove(cart);
                }
                foreach (RecepcionCartucho r in recepcion)
                {
                    _Tesoreria.Remove(r);
                }

                ExportarMalosTesoreria(recepcion);

                dgvEntregar.Refresh();
                dgvRecibir.Refresh();
            }
            
        }

        private void btnExportarMalosTaller_Click(object sender, EventArgs e)
        {
            if (Mensaje.mostrarMensajeConfirmacion("MensajeNoRecuperablesEliminacion") == DialogResult.Yes)
            {

                BindingList<Cartucho> c = new BindingList<Cartucho>();
                BindingList<RecepcionCartucho> recepcion = new BindingList<RecepcionCartucho>();

                //cambiar estado a No Recuperable
                foreach (DataGridViewRow row in dgvRecibir.Rows)
                {
                    DataGridViewCheckBoxCell select = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(select.Value))
                    {
                        RecepcionCartucho entregado = (RecepcionCartucho)dgvRecibir.Rows[row.Index].DataBoundItem;
                        entregado.Cartucho.Estado = EstadosCartuchos.NoRecuperable;
                        //entregado.Cartucho.Fallas.Clear();

                        if (!_NRecup.Contains(entregado))
                        {
                            _NRecup.Add(entregado);
                        }
                        if (!c.Contains(entregado.Cartucho))
                        {
                            c.Add(entregado.Cartucho);
                        }

                        recepcion.Add(entregado);
                    }
                }

                foreach (Cartucho cart in c)
                {
                    _mantenimiento.actualizarCartuchoEstado(cart, _usuario);
                    if (!_NoRecuperable.Contains(cart))
                    {
                        _NoRecuperable.Add(cart);
                    }
                    _malosTaller.Remove(cart);

                    switch(cart.Tipo)
                    {
                        case TiposCartucho.Dispensador:
                            _pedidoDispensador = _mantenimiento.seleccionarAlertasInventario(TiposCartucho.Dispensador);
                            break;
                        case TiposCartucho.ENA:
                            _pedidoENA = _mantenimiento.seleccionarAlertasInventario(TiposCartucho.ENA);
                            break;
                        case TiposCartucho.Rechazo:
                            _pedidoRechazo = _mantenimiento.seleccionarAlertasInventario(TiposCartucho.Rechazo);
                            break;
                    }
                }
                foreach (RecepcionCartucho r in recepcion)
                {
                    _Taller.Remove(r);
                }
                dgvNoRecuperable.Refresh();
                dgvRecibir.Refresh();

                AlertasInventario();
            }
        }

        private void btnExportarNoRecuperables_Click(object sender, EventArgs e)
        {
            BindingList<Cartucho> c = new BindingList<Cartucho>();
            BindingList<RecepcionCartucho> recepcion = new BindingList<RecepcionCartucho>();

            //cambiar estado del cartucho a inactivo
            foreach (DataGridViewRow row in dgvNoRecuperable.Rows)
            {
                DataGridViewCheckBoxCell select = row.Cells[0] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(select.Value))
                {
                    RecepcionCartucho nrec = (RecepcionCartucho)dgvNoRecuperable.Rows[row.Index].DataBoundItem;

                    if (!c.Contains(nrec.Cartucho)){
                        c.Add(nrec.Cartucho);
                    }

                    recepcion.Add(nrec);
                }
            }

            foreach (Cartucho cart in c)
            {
                _mantenimiento.eliminarCartucho(cart);
                _NoRecuperable.Remove(cart);
            }
            foreach (RecepcionCartucho r in recepcion)
            {
                _NRecup.Remove(r);
            }
            dgvNoRecuperable.Refresh();

            ExportarMalosTesoreria(recepcion);
           
        }

        private void txtCartucho_Enter(object sender, EventArgs e)
        {
            string cartucho = txtCartucho.Text;
            if (cartucho != "")
                this.Marcar(cartucho);
        }

        private void btnEliminarRecibidos_Click(object sender, EventArgs e)
        {
            BindingList<RecepcionCartucho> recepcion = new BindingList<RecepcionCartucho>();
            BindingList<Cartucho> cartuchos = new BindingList<Cartucho>();
            
            //cambiar estado a Bueno
            foreach (DataGridViewRow row in dgvRecibir.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.Green)
                {
                    RecepcionCartucho taller = (RecepcionCartucho)dgvRecibir.Rows[row.Index].DataBoundItem;
                    taller.Cartucho.Estado = EstadosCartuchos.Bueno;
                    if (!cartuchos.Contains(taller.Cartucho))
                    {
                        cartuchos.Add(taller.Cartucho);
                    }
                    recepcion.Add(taller);
                }
            }

            //actualiza los cartuchos en la BD
            foreach(Cartucho a in cartuchos)
            {
                 a.Fallas.Clear();
                 _mantenimiento.actualizarCartuchoEstado(a, _usuario);
                 _mantenimiento.agregarCartuchoRecibido(a, _usuario);
            }
            //Actualiza la bandeja de los malos en taller
            foreach (RecepcionCartucho r in recepcion)
            {
                _Taller.Remove(r);
            }

            dgvEntregar.Refresh();
            dgvRecibir.Refresh();
        }

        private void txtCartucho_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter & txtCartucho.Text != "")
            {
                this.Marcar(txtCartucho.Text);
            }
        }

        private void btnActualizarTesoreria_Click(object sender, EventArgs e)
        {
            _malosTesoreria.Clear();
            _Tesoreria.Clear();
            _malosTesoreria = _mantenimiento.listarCartuchosEstado(EstadosCartuchos.Malo, cboCartuchoMalo.Text);
            _Tesoreria = _mantenimiento.listarCartuchosMaloTesoreria(_malosTesoreria);
            dgvEntregar.DataSource = _Tesoreria;
        }

        private void btnActualizarTaller_Click(object sender, EventArgs e)
        {
            _malosTaller.Clear();
            _Taller.Clear();
            _malosTaller = _mantenimiento.listarCartuchosEstado(EstadosCartuchos.EntregadoTaller, cboMalosTaller.Text);
            _Taller = _mantenimiento.listarCartuchosMaloTaller(_malosTaller);
            dgvRecibir.DataSource = _Taller;
        }
        #endregion Eventos   
                     
        #region Metodos Privados
        
        private void CargarMalosTaller()
        {
            dgvRecibir.DataSource = null;
            dgvRecibir.DataSource = _Taller;
        }

        private void CargarMalosTesoreria()
        {
            dgvEntregar.DataSource = null;
            
        }

        private void CargarNoRecuperable()
        {
            dgvNoRecuperable.DataSource = null;
            dgvNoRecuperable.DataSource = _NRecup;
        }

        private void Marcar(string c)
        {
            foreach (DataGridViewRow row in dgvRecibir.Rows)
            {
                RecepcionCartucho recep = new RecepcionCartucho();
                recep = (RecepcionCartucho)dgvRecibir.Rows[row.Index].DataBoundItem;

                if (recep.Cartucho.Numero == c)
                {
                    dgvRecibir.Rows[row.Index].DefaultCellStyle.BackColor = Color.Green;
                }


            }
        }

        private void ExportarMalosTesoreria(BindingList<RecepcionCartucho> listaimprimir)
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla cartuchos.xlt", true);

                documento.seleccionarHoja(1);

                // Escribir los datos

                int fila = 0;

                foreach (RecepcionCartucho recepcion in listaimprimir)
                {
                    documento.seleccionarCelda(8 + fila, 2);
                    documento.actualizarValorCelda(recepcion.Cartucho.Numero);

                    documento.seleccionarCelda(8 + fila, 3);
                    documento.actualizarValorCelda(System.DateTime.Now);

                    documento.seleccionarCelda(8 + fila, 4);
                    documento.actualizarValorCelda(recepcion.Cartucho.Tipo.ToString());

                    documento.seleccionarCelda(8 + fila, 5);
                    documento.actualizarValorCelda(recepcion.Falla.Nombre);

                    documento.seleccionarCelda(8 + fila, 6);
                    documento.actualizarValorCelda(recepcion.Cartucho.Proveedor.ToString());

                    fila++;
                }

                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

        }


        private void AlertasInventario()
        {
            string mensaje = "Realizar pedido de ";
            if (_pedidoDispensador > 0)
                mensaje = mensaje + Convert.ToString(_pedidoDispensador) + " Cartuchos de Tipo Dispensador \n";
            if (_pedidoENA > 0)
                mensaje = mensaje + Convert.ToString(_pedidoENA) + " Cartuchos de Tipo ENA \n";
            if (_pedidoRechazo > 0)
                mensaje = mensaje + Convert.ToString(_pedidoRechazo) + " Cartuchos de Tipo Rechazo \n";

            if (mensaje != "Realizar pedido de ")
                MessageBox.Show(mensaje, "BAC CREDOMATIC");
        }

        #endregion Metodos Privados
                  
    }
}
