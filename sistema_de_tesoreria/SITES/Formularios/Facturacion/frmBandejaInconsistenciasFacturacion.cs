﻿using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Facturacion
{
    public partial class frmBandejaInconsistenciasFacturacion : Form
    {
         #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _colaborador = null;

        private bool _coordinador = false;
        private bool _analista = false;

        #endregion Atributos

        #region Constructor

        public frmBandejaInconsistenciasFacturacion(Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;
            _coordinador = _colaborador.Puestos.Contains(Puestos.Coordinador) || _colaborador.Puestos.Contains(Puestos.Supervisor);
            _analista = _colaborador.Puestos.Contains(Puestos.Analista);
            cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();

            

            try
            {
                dgvCargas.AutoGenerateColumns = false;

                
                cboInconsistencias.ListaMostrada = _mantenimiento.listarInconsistenciaFacturacion();
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de actualizar.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha = dtpFecha.Value;
                DateTime fecha_fin = dtpFechaFin.Value;

                EmpresaTransporte empresa = cboTransportadora.SelectedIndex == 0 ?
                    null : (EmpresaTransporte)cboTransportadora.SelectedItem;

                InconsistenciaFacturacion inconsistencia = cboInconsistencias.SelectedIndex == 0 ?
                    null : (InconsistenciaFacturacion)cboInconsistencias.SelectedItem;

                dgvCargas.DataSource = _coordinacion.obtenerPuntoAtencionInconsistencia(fecha, fecha_fin, empresa, inconsistencia);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

      

        

        /// <summary>
        /// Clic en el botón de modificar.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostrarVentanaModificacion();
        }

       

      
        

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Doble clic en la lista de cargas.
        /// </summary>
        private void dgvCargas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                DataGridViewRow fila = dgvCargas.SelectedRows[0];
                PuntoAtencion carga = (PuntoAtencion)fila.DataBoundItem;

                
                    this.mostrarVentanaRevision();
                

            }

        }

        /// <summary>
        /// Se agrega una carga a la lista de cargas.
        /// </summary>
        private void dgvCargas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int contador = 0; contador < e.RowCount; contador++)
            {
                DataGridViewRow fila = dgvCargas.Rows[e.RowIndex + contador];
                PuntoAtencion carga = (PuntoAtencion)fila.DataBoundItem;

                
            }

        }

        /// <summary>
        /// Se selecciona otra carga de la lista de cargas.
        /// </summary>
        private void dgvCargas_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvCargas.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvCargas.SelectedRows[0];
              //  PuntoAtencion carga = (PuntoAtencion)fila.DataBoundItem;

                

                btnModificar.Enabled = true;

              

            }
            else
            {
              
 
                btnModificar.Enabled = false;


            }

        }

       

        #endregion Eventos
     
        #region Métodos Privados

       

        /// <summary>
        /// Mostrar la ventana de revisión de la carga.
        /// </summary>
        private void mostrarVentanaRevision()
        {
            PuntoAtencion carga = (PuntoAtencion)dgvCargas.SelectedRows[0].DataBoundItem;
            frmModificacionInconsistencia formulario = new frmModificacionInconsistencia(ref carga);

            formulario.ShowDialog(this);
        }

        /// <summary>
        /// Mostrar la ventana de modificación de la carga.
        /// </summary>
        private void mostrarVentanaModificacion()
        {
            PuntoAtencion carga = (PuntoAtencion)dgvCargas.SelectedRows[0].DataBoundItem;
            frmAsignacionInconsistenciasFacturacion formulario = new frmAsignacionInconsistenciasFacturacion(ref carga, _colaborador);

            formulario.ShowDialog(this);

          

            dgvCargas.Refresh();
        }

        #endregion Métodos Privados
    }
}
