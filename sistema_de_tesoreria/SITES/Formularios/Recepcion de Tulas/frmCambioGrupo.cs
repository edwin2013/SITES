using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmCambioGrupo : Form
    {

        #region Atributos

        private frmListaTulas _padre = null;

        private AtencionBL _atencion = AtencionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private Manifiesto _manifiesto = null;

        #endregion Atributos

        #region Constructor

        public frmCambioGrupo(Manifiesto manifiesto, frmListaTulas padre)
        {
            InitializeComponent();

            _manifiesto = manifiesto;
            _padre = padre;

            try
            {
                // Cargar los grupos

                cboGrupo.ListaMostrada = _mantenimiento.listarGrupos();

                if (cboGrupo.Items.Count > 0)
                    cboGrupo.SelectedIndex = 0;
            }
            catch (Excepcion ex)
            {
                this.Close();
                throw ex;
            }

        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {


            if (cboGrupo.SelectedItem != null)
            {
                try
                {
                    Grupo grupo = (Grupo)cboGrupo.SelectedItem;
                    byte caja = (byte)nudCaja.Value;

                    _manifiesto.Grupo = grupo;
                    _manifiesto.Caja = caja;

                    _atencion.actualizarGrupoManifiesto(_manifiesto);

                    Mensaje.mostrarMensaje("MensajeManifiestoConfirmacionActualizacion");
                    _padre.actualizarListaTulasImpresion();
                    this.Close();
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }

        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Seleccion de otro grupo.
        /// </summary>
        private void cboGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboGrupo.SelectedItem != null)
            {
                try
                {
                    Grupo grupo = (Grupo)cboGrupo.SelectedItem;

                    nudCaja.Value = 1;
                    nudCaja.Enabled = !grupo.Caja_unica;
                }
                catch (Excepcion ex)
                {
                    ex.mostrarMensaje();
                }

            }
            
        }

        #endregion Eventos

    }

}
