using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using LibreriaMensajes;
using CommonObjects;
using CommonObjects.Clases;

namespace GUILayer.Formularios.Blindados
{
    public partial class frmAsignarEquiposaTripulacion : Form
    {
        #region Atributos

        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private AtencionBL _atencion = AtencionBL.Instancia;
        private Tripulacion _tripulacionauxiliar = new Tripulacion();
        private Colaborador _usuario = new Colaborador();
        private Colaborador _colaborador_actual;
        private String _comentario = String.Empty;
        BindingList<Equipo> _equipos = new BindingList<Equipo>();
     
        #endregion Atributos

        #region Constructor


        public frmAsignarEquiposaTripulacion(Colaborador usuario)
        {
            _usuario = usuario;
            InitializeComponent();
            cboTripulacion.ListaMostrada = _mantenimiento.listarTripulacion(string.Empty, dtpFecha.Value);
            _equipos = _mantenimiento.listarEquipo(string.Empty);

            foreach (Equipo e in _equipos)
            {
                chkListEquipo.Items.Add(e);
            }

        }

        public frmAsignarEquiposaTripulacion()
        {
            InitializeComponent();
           

        }
       

        #endregion Constructor

        #region Eventos
 
       
       /// <summary>
       /// Clic en el boton de actualizar la lista de tripulaciones
       /// </summary>
       private void btnActualizar_Click(object sender, EventArgs e)
       {
           try
           {
               cboTripulacion.ListaMostrada = _mantenimiento.listarTripulacion(string.Empty, dtpFecha.Value);
               limpiarDatos();
           }
           catch (Excepcion ex)
           {
               ex.mostrarMensaje();
           }
       }


        /// <summary>
        /// Clic en el boton de Autoasignar Tripulacion
        /// </summary>
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try 
            {
              
            }
            catch(Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }



        /// <summary>
        /// Escogencia de la tripulacion en el combo box
        /// </summary>
        private void cboTripulacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cargarDatos();
        }



        /// <summary>
        /// Escoger el Custodio para asignar el equipo
        /// </summary>
        private void rbtnCustodio_CheckedChanged(object sender, EventArgs e)
        {
            _colaborador_actual = _tripulacionauxiliar.Custodio;

            limpiarListaEquipos();
            cargarEquiposColaborador();
        }


        /// <summary>
        /// Escoger el Portavalor para asignar el equipo
        /// </summary>
        private void rbtnPortavalor_CheckedChanged(object sender, EventArgs e)
        {
            _colaborador_actual = _tripulacionauxiliar.Portavalor;

            limpiarListaEquipos();
            cargarEquiposColaborador();
        }


        /// <summary>
        /// Escoger el Chofer para asignar el equipo
        /// </summary>
        private void rbtnChofer_CheckedChanged(object sender, EventArgs e)
        {
            _colaborador_actual = _tripulacionauxiliar.Chofer;

            limpiarListaEquipos();
            cargarEquiposColaborador();
        }


        /// <summary>
        /// Clic en el boton de asignar equipos a un usuario especifico
        /// </summary>
        private void btnAsignar_Click_1(object sender, EventArgs e)
        {
            try
            {

                int ruta = (int)numRuta2.Value;
                DateTime fecha = dtpFecha.Value;
                Colaborador lusuario = _usuario;
                string observarciones = _comentario;
                Colaborador asignado = _colaborador_actual;
                Tripulacion tripulacion = _tripulacionauxiliar;


                if (Mensaje.mostrarMensajeConfirmacion("MensajeTripulacionRegistro") == DialogResult.Yes)
                {

                    asignado.Equipos = new BindingList<Equipo>();

                    foreach (Equipo equipo in chkListEquipo.CheckedItems)
                    {
                        Equipo copia = equipo;


                        asignado.agregarEquipo(copia);

                    }


                    if (_tripulacionauxiliar.Asignaciones.ID == 0)
                    {
                        _tripulacionauxiliar.Asignaciones = new AsignacionEquipo(usuarioasignado: asignado, usuarioregistro: _usuario, tripulacion: tripulacion, fecha: fecha);

                        _atencion.agregarAsignacionEquipo(ref _tripulacionauxiliar);
                    }
                    else
                    {
                        _tripulacionauxiliar.Asignaciones.ColaboradorAsignado = asignado;
                        _tripulacionauxiliar.Asignaciones.ColaboradorRegistro = _usuario;
                        _tripulacionauxiliar.Asignaciones.Fecha = fecha;

                        _atencion.actualizarAsignacionEquipo(_tripulacionauxiliar);
                    }


       

                    Mensaje.mostrarMensaje("MensajeTripulacionConfirmacionRegistro");

                    //this.limpiarDatos();
                    //this.limpiarListaEquipos();
                }



            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        #endregion Eventos


        #region Metodos Privados


        /// <summary>
        /// Carga los datos de las tripulaciones en el resto de 
        /// </summary>
        private void cargarDatos()
        {
            try
            {
                _tripulacionauxiliar = (Tripulacion)cboTripulacion.SelectedItem;

                txtCustodio.Text = _tripulacionauxiliar.Custodio.ToString();
                txtPortavalor.Text = _tripulacionauxiliar.Portavalor.ToString();
                txtChofer.Text = _tripulacionauxiliar.Chofer.ToString();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Limpia los datos del formulario
        /// </summary>
        private void limpiarDatos()
        {

            // Desmarca los radiobotones
            rbtnChofer.Checked = false;
            rbtnCustodio.Checked = false;
            rbtnPortavalor.Checked = false;


            // Coloca los text box vacios
            txtChofer.Text = "";
            txtCustodio.Text = "";
            txtPortavalor.Text = "";


            cboTripulacion.Text = "";

            chkListEquipo.Items.Clear();


            foreach (Equipo e in _equipos)
            {
                chkListEquipo.Items.Add(e);
            }


        }

        /// <summary>
        /// Marca los equipos que posee un determinado colaborador
        /// </summary>
        private void cargarEquiposColaborador()
        {
            for (int contador = 0; contador < chkListEquipo.Items.Count; contador++)
            {
                Equipo equipo = (Equipo)chkListEquipo.Items[contador];

                chkListEquipo.SetItemChecked(contador, _colaborador_actual.Equipos.Contains(equipo));
            }
            
        }

        /// <summary>
        /// Desmarca los check en la lista de equipos
        /// </summary>
        private void limpiarListaEquipos()
        {
            for (int contador = 0; contador < chkListEquipo.Items.Count; contador++)
            {

                chkListEquipo.SetItemChecked(contador, false);
            }
        }


        #endregion Metodos Privados


        #region Metodos Publicos
        
        /// <summary>
        /// Define el comentario de la modificacion 
        /// </summary>
        /// <param name="comentario"></param>
        public void asignarComentario(String comentario)
        {
            _comentario = comentario;
        }

        #endregion Metodos Publicos

    }
}
