//
//  @ Project : 
//  @ File Name : frmMantenimientoColaboradores.cs
//  @ Date : 01/02/2011
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
using CommonObjects.Clases;

namespace GUILayer
{

    public partial class frmMantenimientoColaboradores : Form
    {

        #region Atributos

        private SeguridadBL _seguridad = SeguridadBL.Instancia;

        private Colaborador _colaborador = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoColaboradores(Colaborador administrador)
        {
            InitializeComponent();

            dgvTelefonos.AutoGenerateColumns = false;
            dgvTelefonos.DataSource = new BindingList<Telefono>();

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

        public frmMantenimientoColaboradores(Colaborador administrador, Colaborador colaborador)
        {
            InitializeComponent();

            _colaborador = colaborador;

            txtNombre.Text = _colaborador.Nombre;
            txtPrimerApellido.Text = _colaborador.Primer_apellido;
            txtSegundoApellido.Text = _colaborador.Segundo_apellido;
            txtIdentificador.Text = _colaborador.Identificacion;
            txtCuenta.Text = _colaborador.Cuenta;
            dtpFechaIngreso.Value = _colaborador.Fecha_ingreso;
            txtClaveCEF.Text = _colaborador.ClaveCEF;
            txtEmail.Text = _colaborador.Correo;
            txtBaseCorreo.Text = _colaborador.BaseDatosCorreo;
            txtServidorCorreo.Text = _colaborador.ServidorCorreo;
            chkAdministradorGeneral.Checked = _colaborador.Administrador_general;

            chkAdministradorGeneral.Enabled = administrador.Administrador_general;

            dgvTelefonos.AutoGenerateColumns = false;
            dgvTelefonos.DataSource = _colaborador.Telefonos;

            //// Marcar los puestos actuales del colaborador

            //foreach (Puestos puesto in _colaborador.Puestos)
            //    clbPuestos.SetItemChecked((byte)puesto, true);


            // Seleccionar el área del colaborador

            cboAreas.SelectedIndex = (byte)_colaborador.Area;

            try
            {
                // LOS PERFILES SE VAN A MANEJAR POR PUESTOS NO POR COLABORADOR
                // Cargar los perfiles

                //this.cargarDatos();

                this.cargarDatos();

                // Marcar los perfiles del colaborador

                //for (int contador = 0; contador < clbPerfiles.Items.Count; contador++)
                //{
                //    Perfil perfil = (Perfil)clbPerfiles.Items[contador];

                //    clbPerfiles.SetItemChecked(contador, _colaborador.Perfiles.Contains(perfil));
                //}

                // Marcar los puestos del colaborador

                for (int contador = 0; contador < clbPuestosColaborador.Items.Count; contador++)
                {
                    PuestoColaborador puesto = (PuestoColaborador)clbPuestosColaborador.Items[contador];

                    clbPuestosColaborador.SetItemChecked(contador, _colaborador.PuestosColaborador.Contains(puesto));
                }

            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }

        }

        /// <summary>
        /// Mostrar la lista de perfiles.
        /// </summary>
        private void cargarDatos()
        {

            try
            {
                // Cargar la lista de perfiles

                //BindingList<Perfil> perfiles = _seguridad.listarPerfiles();

                //foreach (Perfil perfil in perfiles)
                //    clbPerfiles.Items.Add(perfil);

                BindingList<PuestoColaborador> puestos = _seguridad.listarPuestos();

                foreach (PuestoColaborador puesto in puestos)
                    clbPuestosColaborador.Items.Add(puesto);

            }
            catch (Exception ex)
            {
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
            // Verificar que se hayan seleccionado los datos

            if (txtNombre.Text.Equals(string.Empty) || txtIdentificador.Text.Equals(string.Empty) ||
                txtPrimerApellido.Text.Equals(string.Empty) || txtSegundoApellido.Text.Equals(string.Empty) ||
                clbPuestosColaborador.CheckedItems.Count == 0 || cboAreas.SelectedItem == null ||
                txtCuenta.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorColaboradorDatosRegistro");
                return;
            }

            try
            {
                frmAdministracionColaboradores padre = (frmAdministracionColaboradores)this.Owner;

                string nombre = txtNombre.Text;
                string primer_apellido = txtPrimerApellido.Text;
                string segundo_apellido = txtSegundoApellido.Text;
                string identificacion = txtIdentificador.Text;
                string cuenta = txtCuenta.Text;
                string clave_cef = txtClaveCEF.Text;
                string base_correo = txtBaseCorreo.Text;
                string servidor_correo = txtServidorCorreo.Text;
                string email = txtEmail.Text;
                bool administrador_general = chkAdministradorGeneral.Checked;
                DateTime fecha_ingreso = dtpFechaIngreso.Value;
                Areas area = (Areas)cboAreas.SelectedIndex;

                BindingList<Telefono> telefonos = (BindingList<Telefono>)dgvTelefonos.DataSource;

                // Verificar si el colaborador es nuevo

                if (_colaborador == null)
                {
                    // Agregar los datos del nuevo colaborador

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeColaboradorRegistro") == DialogResult.Yes)
                    {
                        Colaborador nuevo = new Colaborador(nombre: nombre, primer_apellido: primer_apellido, segundo_apellido: segundo_apellido,
                                                            identificacion: identificacion, fecha_ingreso: fecha_ingreso, cuenta: cuenta,
                                                            area: area, administrador_general: administrador_general, basedatoscorreo: base_correo, servidorcorreo:servidor_correo, correo: email, clave_cef: clave_cef);

                        foreach (Telefono telefono in telefonos)
                            nuevo.agregarTelefono(telefono);

                        foreach (PuestoColaborador puesto in clbPuestosColaborador.CheckedItems)
                            nuevo.agregarPuestoColaborador((PuestoColaborador)puesto);

                        //LOS PERFILES SE VAN A MANEJAR POR PUESTOS NO POR COLABORADOR
                        //foreach (Perfil perfil in clbPerfiles.CheckedItems)
                        //    nuevo.agregarPerfil(perfil);

                        _seguridad.agregarColaborador(ref nuevo);

                        padre.agregarColaborador(nuevo);
                        Mensaje.mostrarMensaje("MensajeColaboradorConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    Colaborador copia = new Colaborador(id: _colaborador.ID, nombre: nombre, primer_apellido: primer_apellido,
                                                        segundo_apellido: segundo_apellido, identificacion: identificacion,
                                                        fecha_ingreso: fecha_ingreso, cuenta: cuenta, area: area,
                                                        administrador_general: administrador_general, basedatoscorreo: base_correo, servidorcorreo: servidor_correo, correo: email, clave_cef: clave_cef);

                    foreach (Telefono telefono in telefonos)
                        copia.agregarTelefono(telefono);


                    foreach (PuestoColaborador puesto in clbPuestosColaborador.CheckedItems)
                    {
                        copia.agregarPuestoColaborador((PuestoColaborador)puesto);
                    }
                        

                    //foreach (int puesto in clbPuestos.CheckedIndices)
                    //    copia.agregarPuesto((Puestos)puesto);

                    //foreach (Perfil perfil in clbPerfiles.CheckedItems)
                    //    copia.agregarPerfil(perfil);

                    // Actualizar los datos del colaborador

                    _seguridad.actualizarColaborador(copia);

                    _colaborador.Nombre = nombre;
                    _colaborador.Primer_apellido = primer_apellido;
                    _colaborador.Segundo_apellido = segundo_apellido;
                    _colaborador.Identificacion = identificacion;
                    _colaborador.Cuenta = cuenta;
                    _colaborador.Area = area;
                    _colaborador.Administrador_general = administrador_general;
                    _colaborador.Puestos = copia.Puestos;
                    _colaborador.Telefonos = copia.Telefonos;
                    _colaborador.Perfiles = copia.Perfiles;
                    _colaborador.Correo = copia.Correo;
                    _colaborador.ServidorCorreo = copia.ServidorCorreo;
                    _colaborador.BaseDatosCorreo = copia.BaseDatosCorreo;
                    _colaborador.ClaveCEF = copia.ClaveCEF;
                    _colaborador.PuestosColaborador = copia.PuestosColaborador;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeColaboradorConfirmacionActualizacion");
                    this.Close();
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
            
        }

        /// <summary>
        /// Clic en el botón de asignar un código al colaborador.
        /// </summary>
        private void btnAsignarCodigo_Click(object sender, EventArgs e)
        {

            try
            {
                string[] datos = _seguridad.actualizarColaboradorCodigo(_colaborador);

                frmGeneracionCodigo formulario = new frmGeneracionCodigo(datos);

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de agregar teléfono.
        /// </summary>
        private void btnAgregarTelefono_Click(object sender, EventArgs e)
        {
            Telefono telefono = new Telefono(txtNumero.Text);

            BindingList<Telefono> telefonos = (BindingList<Telefono>)dgvTelefonos.DataSource;

            telefonos.Add(telefono);
        }

        /// <summary>
        /// Clic en el botón de quitar teléfono.
        /// </summary>
        private void btnQuitarTelefono_Click(object sender, EventArgs e)
        {
            dgvTelefonos.Rows.Remove(dgvTelefonos.SelectedRows[0]);
        }

        /// <summary>
        /// Clic en el botón de salir.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se agrega un teléfono.
        /// </summary>
        private void dgvTelefonos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnQuitarTelefono.Enabled = true;
        }

        /// <summary>
        /// Se quita un teléfono.
        /// </summary>
        private void dgvTelefonos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            btnQuitarTelefono.Enabled = dgvTelefonos.RowCount > 0;
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            btnAgregarTelefono.Enabled = txtNumero.Text.Length > 0;
        }

        private void clbPuestos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < clbPuestos.Items.Count - 1; i++)
            {
                if (i != e.Index)
                {
                    clbPuestos.SetItemChecked(i, false);
                }
            }
        }

        private void clbPuestosColaborador_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < clbPuestosColaborador.Items.Count - 1; i++)
            {
                if (i != e.Index)
                {
                    clbPuestosColaborador.SetItemChecked(i, false);
                }
            }
        }


        private void btnImpresionCodigo_Click(object sender, EventArgs e)
        {

        }

        private void gbContacto_Enter(object sender, EventArgs e)
        {

        }

        #endregion Eventos


    }

}
