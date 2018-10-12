using BussinessLayer;
using CommonObjects;
using CommonObjects.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.Mantenimiento
{
    public partial class frmMantenimientoPerfilesRoles : Form
    {

        #region Atributos

        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _colaborador = null;

        #endregion Atributos

        #region Constructor
        public frmMantenimientoPerfilesRoles()
        {
            InitializeComponent();


            try
            {
                // Cargar los perfiles

                this.cargarDatos();
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }
        }

        #endregion Constructor

        #region Metodos Privados

        private void cargarDatos()
        {

            try
            {
                // Cargar la lista de perfiles

                BindingList<Perfil> perfiles = _seguridad.listarPerfiles();

                foreach (Perfil perfil in perfiles)
                    clbPerfiles.Items.Add(perfil);


                BindingList<PuestoColaborador> puestos = _seguridad.listarPuestos();

                foreach (PuestoColaborador puesto in puestos)
                    clbPuestosColaborador.Items.Add(puesto);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Metodos Privados

        #region Eventos
        private void clbPuestosColaborador_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < clbPuestosColaborador.Items.Count - 1; i++)
            {
                if (i != e.Index)
                {
                    clbPuestosColaborador.SetItemChecked(i, false);
                }
            }

            // Marcar los perfiles del puesto
            BindingList<Perfil> perfilespuesto = _seguridad.listarPerfilesPuesto((PuestoColaborador)clbPuestosColaborador.Items[e.Index]);

            for (int contador = 0; contador < clbPerfiles.Items.Count; contador++)
            {
                Perfil perfil = (Perfil)clbPerfiles.Items[contador];

                clbPerfiles.SetItemChecked(contador, perfilespuesto.Contains(perfil));
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            BindingList<Perfil> perfiles = new BindingList<Perfil>();

            foreach (Perfil p in clbPerfiles.CheckedItems)
            {
                perfiles.Add((Perfil)p);
            }

            _seguridad.actualizarPuesto((PuestoColaborador)clbPuestosColaborador.CheckedItems[0], perfiles);

        }

        #endregion Eventos


    }
}
