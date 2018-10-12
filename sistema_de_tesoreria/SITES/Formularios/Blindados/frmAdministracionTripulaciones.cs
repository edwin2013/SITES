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
using LibreriaMensajes;
using GUILayer.Formularios.Mantenimiento;
using CommonObjects.Clases;

namespace GUILayer
{
    public partial class frmAdministracionTripulaciones : Form
    {

        #region Atributos

        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private Tripulacion _tripulacionauxiliar = null;
        private BindingList<Tripulacion> _tripulacioneseliminar = new BindingList<Tripulacion>();
        private Colaborador _usuario = new Colaborador();
        private String _comentario = String.Empty;
     
        #endregion Atributos

        #region Constructor


        public frmAdministracionTripulaciones(Colaborador usuario)
        {
            _usuario = usuario;
            InitializeComponent();
            ComboBoxBusqueda nuevo = new ComboBoxBusqueda();
            cboChofer.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.Blindados, Puestos.Chofer);
            cboCustodio.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.Blindados, Puestos.Custodio);
            cboPortavalor.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.Blindados, Puestos.Portavalor);
            cboVehiculo.ListaMostrada = _mantenimiento.listarVehiculo(string.Empty);
            cboDispositivo.ListaMostrada = _mantenimiento.listarDispositivos();
            //dgvTripulaciones.DataSource = new BindingList<Tripulacion>();

            if (usuario.Puestos.Contains(Puestos.Coordinador) || usuario.Puestos.Contains(Puestos.Supervisor))
            {
                this.ColumnUsuario.Visible = true;
                this.ColumnObservaciones.Visible = true;
            }

            dgvTripulaciones.DataSource = _mantenimiento.listarTripulacion(string.Empty,dtpFecha.Value);
            
        }

        public frmAdministracionTripulaciones()
        {
            InitializeComponent();
            ComboBoxBusqueda nuevo = new ComboBoxBusqueda();
            cboChofer.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.Blindados, Puestos.Chofer);
            cboCustodio.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.Blindados, Puestos.Custodio);
            cboPortavalor.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.Blindados, Puestos.Portavalor);
            cboVehiculo.ListaMostrada = _mantenimiento.listarVehiculo(string.Empty);
            dgvTripulaciones.DataSource = _mantenimiento.listarTripulacion(string.Empty, dtpFecha.Value);

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
               this.actualizarDatos();

               if (dgvTripulaciones.RowCount > 0)
                   btnAsignar.Enabled = false;
               else
                   btnAsignar.Enabled = true;
           }
           catch (Excepcion ex)
           {
               ex.mostrarMensaje();
           }
       }


       /// <summary>
       /// Clic en el botón de arriba para cambiar el orden de las cargas.
       /// </summary>
       private void btnArriba_Click(object sender, EventArgs e)
       {
           this.cambiarOrdenCarga(-1);
       }

       /// <summary>
       /// Clic en el botón de abajo para cambiar el orden de las cargas.
       /// </summary>
       private void btnAbajo_Click(object sender, EventArgs e)
       {
           this.cambiarOrdenCarga(1);
       }
    

        /// <summary>
        /// Agrega la tripulación al datagridview
        /// </summary>
       
        private void btnAgregarTripulacion_Click(object sender, EventArgs e)
        {
            if (ValidateEspacios())
            {

                Tripulacion tripulacion = new Tripulacion();

                tripulacion.Ruta = Convert.ToInt32(numRuta2.Value);
                tripulacion.Descripcion = txtNombre.Text;
                

                //tripulacion.Chofer = cboChofer.SelectedIndex == 0 ?
                //    null : (Colaborador)cboChofer.SelectedItem;


                tripulacion.Chofer = (Colaborador)cboChofer.SelectedItem;


                tripulacion.Custodio = (Colaborador)cboCustodio.SelectedItem;


                tripulacion.Portavalor = (Colaborador)cboPortavalor.SelectedItem;

                tripulacion.Vehiculo = (Vehiculo)cboVehiculo.SelectedItem;

                tripulacion.Usuario = _usuario;

                tripulacion.Dispostivo = (Dispositivo)cboDispositivo.SelectedItem;

                tripulacion.Observaciones = _comentario;

                BindingList<Tripulacion> tripulaciones = new BindingList<Tripulacion>();

                tripulaciones = (BindingList<Tripulacion>)dgvTripulaciones.DataSource;

                tripulaciones.Add(tripulacion);

                dgvTripulaciones.Refresh();
            }
        }


        /// <summary>
        /// Eliminar Tripulación del datagridview
        /// </summary>
        private void btnQuitarTripulacion_Click(object sender, EventArgs e)
        {
            //Tripulacion tripulacion = (Tripulacion)dgvTripulaciones.SelectedRows[0].DataBoundItem;
            //dgvTripulaciones.Rows.Remove(dgvTripulaciones.SelectedRows[0]);
            //_tripulacioneseliminar.Add(tripulacion);
            MessageBox.Show("Hola");
        }

        /// <summary>
        /// Habilita o deshabilita el botón de eliminar dependiendo de si existen o no registros en el datagridview
        /// </summary>
        private void dgvTripulaciones_SelectionChanged(object sender, EventArgs e)
        {
            btnQuitarTripulacion.Enabled = dgvTripulaciones.RowCount > 0;
            btnModificar.Enabled = dgvTripulaciones.RowCount > 0;
            btnGuardar.Enabled = dgvTripulaciones.RowCount > 0;
            btnArriba.Enabled = dgvTripulaciones.RowCount > 0;
            btnAbajo.Enabled = dgvTripulaciones.RowCount > 0;
            btnReinicioValores.Enabled = dgvTripulaciones.RowCount > 0;
            btnEliminarTodos.Enabled = dgvTripulaciones.RowCount > 0;

            this.validaBotonesDesplazamientos();

            if (dgvTripulaciones.RowCount > 0)
                btnAsignar.Enabled = false;
            else
                btnAsignar.Enabled = true;
            


        }


        /// <summary>
        /// Agrega una tripulación con sus rutas a la base de datos
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {      
            try
            {               
                string descripcion = txtNombre.Text;
                Colaborador chofer = (Colaborador) cboChofer.SelectedItem;
                Colaborador custodio = (Colaborador)cboCustodio.SelectedItem;
                Colaborador portavalor = (Colaborador)cboPortavalor.SelectedItem;
                Vehiculo vehiculo = (Vehiculo)cboVehiculo.SelectedItem;
                Dispositivo dispositivo = (Dispositivo)cboDispositivo.SelectedItem;
                int ruta = (int)numRuta2.Value;
                DateTime fecha = dtpFecha.Value;
                Colaborador lusuario = _usuario;
                string observarciones = _comentario;

           
                BindingList<Tripulacion> tripulaciones = (BindingList<Tripulacion>)dgvTripulaciones.DataSource;


            
                    if (Mensaje.mostrarMensajeConfirmacion("MensajeTripulacionRegistro") == DialogResult.Yes)
                    {
                        Tripulacion nuevo = new Tripulacion();  //(nombre:descripcion,ruta:ruta,chofer:chofer,custodio:custodio,portavalor:portavalor);

                        foreach (Tripulacion tripulacion in tripulaciones)
                        {
                            nuevo = tripulacion;
                            _mantenimiento.agregarTripulaciones(ref nuevo,dtpFecha.Value);
                        }

                        foreach (Tripulacion tripulacion in _tripulacioneseliminar)
                        {
                            nuevo = tripulacion;
                            _mantenimiento.eliminarTripulacion(ref nuevo);
                        }

                        //padre.agregarCliente(nuevo);

                        Mensaje.mostrarMensaje("MensajeTripulacionConfirmacionRegistro");
                        this.Close();
                    }

                

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Clic en alguna de las filas del listado de tripulaciones
        /// </summary>
        private void dgvTripulaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _tripulacionauxiliar = (Tripulacion)dgvTripulaciones.SelectedRows[0].DataBoundItem;

                txtNombre.Text = _tripulacionauxiliar.Descripcion;
                numRuta2.Value = _tripulacionauxiliar.Ruta;
                cboChofer.Text = _tripulacionauxiliar.Chofer.ToString();
                cboCustodio.Text = _tripulacionauxiliar.Custodio.ToString();
                cboPortavalor.Text = _tripulacionauxiliar.Portavalor.ToString();
                cboVehiculo.Text = _tripulacionauxiliar.Vehiculo.ToString();
                cboDispositivo.Text = _tripulacionauxiliar.Dispostivo.ToString();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje(); 
            }

        }


        /// <summary>
        /// Actualiza los datos en el datagridview de Tripulaciones
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {

            try
            {


                Tripulacion nueva = new Tripulacion();

                

                string descripcion = txtNombre.Text;
                Colaborador chofer = (Colaborador)cboChofer.SelectedItem;
                Colaborador custodio = (Colaborador)cboCustodio.SelectedItem;
                Colaborador portavalor = (Colaborador)cboPortavalor.SelectedItem;
                Vehiculo vehiculo = (Vehiculo)cboVehiculo.SelectedItem;
                Dispositivo dipositivo = (Dispositivo)cboDispositivo.SelectedItem;
                int ruta = (int)numRuta2.Value;

                nueva = (Tripulacion)dgvTripulaciones.SelectedRows[0].DataBoundItem;

                nueva.Descripcion = descripcion;
                nueva.Chofer = chofer;
                nueva.Custodio = custodio;
                nueva.Portavalor = portavalor;
                nueva.Ruta = ruta;
                nueva.Observaciones = _comentario;
                nueva.Usuario = _usuario;
                nueva.Vehiculo = vehiculo;
                nueva.Dispostivo = dipositivo;

                dgvTripulaciones.Rows.Remove(dgvTripulaciones.SelectedRows[0]);

                BindingList<Tripulacion> tripulaciones = (BindingList<Tripulacion>)dgvTripulaciones.DataSource;
                tripulaciones.Add(nueva);
                dgvTripulaciones.DataSource = tripulaciones;

                frmObservaciones formulario = new frmObservaciones();
                formulario.Padre = this;
                formulario.ShowDialog();

                nueva.Observaciones = _comentario;

                dgvTripulaciones.Refresh();

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Tripulacion nueva = new Tripulacion();
                nueva = (Tripulacion)dgvTripulaciones.SelectedRows[0].DataBoundItem;
                _tripulacioneseliminar.Add(nueva);
                dgvTripulaciones.Rows.Remove(dgvTripulaciones.SelectedRows[0]);

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
                mostrarVentanaAsignacion();
            }
            catch(Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }



        /// <summary>
        /// Inactiva todas las tripulaciones
        /// </summary>
        private void btnEliminarTodos_Click(object sender, EventArgs e)
        {

            try
            {

                BindingList<Tripulacion> tripulaciones = (BindingList<Tripulacion>)dgvTripulaciones.DataSource;


                Tripulacion nuevo = new Tripulacion();  //(nombre:descripcion,ruta:ruta,chofer:chofer,custodio:custodio,portavalor:portavalor);

                foreach (Tripulacion tripulacion in tripulaciones)
                {
                    nuevo = tripulacion;
                    _mantenimiento.eliminarTripulacion(ref nuevo);
                }

                foreach (Tripulacion tripulacion in _tripulacioneseliminar)
                {
                    nuevo = tripulacion;
                    _mantenimiento.eliminarTripulacion(ref nuevo);
                }

                //padre.agregarCliente(nuevo);

                Mensaje.mostrarMensaje("MensajeTripulacionConfirmacionRegistro");
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// Reinicia los valores de HH a no Sincronizado
        /// </summary>
        private void btnReinicioValores_Click(object sender, EventArgs e)
        {
            try
            {
                Tripulacion t = (Tripulacion)dgvTripulaciones.SelectedRows[0].DataBoundItem;

                _mantenimiento.actualizarDatosSincronizadosHH(ref t);

                Mensaje.mostrarMensaje("MensajeActualizacionValoresHH");
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }


        #endregion Eventos


        #region Metodos Privados

        /// <summary>
        /// Actualiza los datos de las tripulaciones
        /// </summary>
        private void actualizarDatos()
        {
            string buscar = txtBuscar.Text;
            dgvTripulaciones.DataSource = _mantenimiento.listarTripulacion(buscar, dtpFecha.Value);
        }


        /// <summary>
        /// Valida los espacios que deben registrarse
        /// </summary>
        /// <returns>Un booleano si la validacion fue correcta o no</returns>
        private bool ValidateEspacios()
        {
            bool bStatus = true;
            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "Debe ingresar el nombre de la ruta");
                bStatus = false;
            }
            else
                errorProvider1.SetError(txtNombre, "");

            if (String.IsNullOrEmpty(cboChofer.Text))
            {
                errorProvider1.SetError(cboChofer, "Debe ingresar el chofer");
                bStatus = false;
            }
            else
                errorProvider1.SetError(cboChofer, "");

            if (String.IsNullOrEmpty(cboCustodio.Text))
            {
                errorProvider1.SetError(cboCustodio, "Debe ingresar el custodio");
                bStatus = false;
            }
            else
                errorProvider1.SetError(cboCustodio, "");

            if (String.IsNullOrEmpty(cboPortavalor.Text))
            {
                errorProvider1.SetError(cboPortavalor, "Debe ingresar el Portavalor");
                bStatus = false;
            }
            else
                errorProvider1.SetError(cboPortavalor, "");
            return bStatus;
        }

        /// <summary>
        /// Muestra la venta de autosignacion de tripulaciones
        /// </summary>
        private void mostrarVentanaAsignacion()
        {
            try
            {
                frmAsignarTripulacion formulario = new frmAsignarTripulacion(dtpFecha.Value, _usuario);
                formulario.ShowDialog();
                this.actualizarDatos();                
            }
            catch (Excepcion exc)
            {
                exc.mostrarMensaje();
            }
        }



        /// <summary>
        /// Cambiar el orden de una carga en la lista de carga.
        /// </summary>
        private void cambiarOrdenCarga(int desplazamiento)
        {
            BindingList<Tripulacion> cargas = (BindingList<Tripulacion>)dgvTripulaciones.DataSource;
            DataGridViewRow fila = dgvTripulaciones.SelectedRows[0];
            Tripulacion carga = (Tripulacion)fila.DataBoundItem;
            int posicion = fila.Index + desplazamiento;

            cargas.Remove(carga);
            cargas.Insert(posicion, carga);

            dgvTripulaciones.Rows[posicion].Selected = true;



            try
            {
                BindingList<Tripulacion> lista = (BindingList<Tripulacion>)dgvTripulaciones.DataSource;

                for (byte orden = 1; orden <= lista.Count; orden++)
                {
                    Tripulacion trip = lista[orden-1];

                    trip.OrdenSalida = orden;
                }

                _mantenimiento.actualizarTripulacoinesOrdenSalida(lista);

                Mensaje.mostrarMensaje("MensajeTripulacionConfirmacionActualizacionOrden");
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Mostrar u ocultar los botones de desplazamiento dependiendo de la selección de una fila.
        /// </summary>
        private void validaBotonesDesplazamientos()
        {

            if (dgvTripulaciones.SelectedRows.Count > 0)
            {
                BindingList<Tripulacion> cargas = (BindingList<Tripulacion>)dgvTripulaciones.DataSource;
                DataGridViewRow fila = dgvTripulaciones.SelectedRows[0];

                btnArriba.Enabled = fila.Index != 0;
                btnAbajo.Enabled = fila.Index != cargas.Count - 1;
                btnGuardar.Enabled = true;
            }
            else
            {
                btnArriba.Enabled = false;
                btnAbajo.Enabled = false;
                btnGuardar.Enabled = false;
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
