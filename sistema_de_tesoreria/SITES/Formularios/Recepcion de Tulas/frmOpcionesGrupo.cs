//
//  @ Project : 
//  @ File Name : frmOpcionesGrupo.cs
//  @ Date : 20/06/2011
//  @ Author : Erick Chavarría 
//

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
using GUILayer.Formularios.Recepcion_de_Tulas;

namespace GUILayer
{

    public partial class frmOpcionesGrupo : Form
    {

        #region Atributos

        private frmOpcionesRegistro _padre = null;

        private AtencionBL _atencion = AtencionBL.Instancia;

        private Grupo _grupo = null;

        Colaborador _usuario = null;

        public BindingList<Colaborador> _cajas_cajeros = null;
           
        #endregion Atributos

        #region Constructor

        public frmOpcionesGrupo(Colaborador usuario,Grupo grupo, frmOpcionesRegistro padre)
        {
            InitializeComponent();

            _grupo = grupo;
            _padre = padre;
            _usuario = usuario;
        
            nudNumeroCajas.Enabled = !grupo.Caja_unica;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                byte total_cajas = (byte)nudNumeroCajas.Value;

                _grupo.Numero_cajas = total_cajas;
                _grupo.Total_manifiestos = 0;
                _grupo.Caja_actual = 0;

                _atencion.actualizarGrupoTotales(_grupo);
                _padre.actualizarLista();

                frmOpcionesGrupoCajero formulario = new frmOpcionesGrupoCajero(_usuario, _grupo, _cajas_cajeros);
               
                formulario.ShowDialog();
                
                if (formulario._cajas_cajeros == null)
                {
                    MessageBox.Show("Debe asignar los cajeros a los grupos!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    _cajas_cajeros = formulario._cajas_cajeros;
                    Mensaje.mostrarMensaje("MensajeGrupoConfirmacionActualizacion");
                    this.Close();
                }

              
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        #endregion Eventos

    }

}
