//
//  @ Project : 
//  @ File Name : frmMantenimientoHorasExtra.cs
//  @ Date : 05/08/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmMantenimientoRegistroErrores : Form
    {
        #region Atributos

        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private BindingList<TipoErrorCierre> _tipos_errores = null;

        private RegistroErroresCierre _registro = null;
        private Colaborador _coordinador = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoRegistroErrores(Colaborador coordinador)
        {
            InitializeComponent();

            _coordinador = coordinador;

            txtCoordinador.Text = coordinador.ToString();

            try
            {
                this.cargarDatos();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
                this.Close();
            }

        }

        public frmMantenimientoRegistroErrores(RegistroErroresCierre registro, Colaborador coordinador)
        {
            InitializeComponent();

            _registro = registro;
            _coordinador = coordinador;

            txtCoordinador.Text = _registro.Colaborador.ToString();
            dtpFecha.Value = _registro.Fecha;
            chkSinErrores.Checked = registro.Sin_errores;
            pnlErrores.Enabled = !registro.Sin_errores;

            txtObservaciones.Text = _registro.Observaciones;
            txtOtrosErrores.Text = _registro.Otros_errores;

            if (_registro.Colaborador == _coordinador)
            {
                btnGuardar.Enabled = false;
                gbDatos.Enabled = false;
            }

            try
            {
                this.cargarDatos();

                cboColaborador.Text = _registro.Colaborador.ToString();

                for (int contador = 0; contador < _tipos_errores.Count; contador++)
                    clbErrores.SetItemChecked(contador, _registro.Errores.Contains(_tipos_errores[contador]));

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
                this.Close();
            }

        }

        /// <summary>
        /// Cargar los datos de las listas.
        /// </summary>
        private void cargarDatos()
        {

            try
            {
                // Cargar las listas

                _tipos_errores = _mantenimiento.listarTiposErrores();

                clbErrores.DataSource = _tipos_errores;
                cboColaborador.ListaMostrada = _seguridad.listarColaboradores(string.Empty);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
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

            if (cboColaborador.SelectedItem == null || (!chkSinErrores.Checked && clbErrores.CheckedItems.Count == 0))
            {
                Excepcion.mostrarMensaje("ErrorRegistroErroresCierreDatosRegistro");
                return;
            }

            try
            {
                frmAdministracionRegistroErrores padre = (frmAdministracionRegistroErrores)this.Owner;

                Colaborador colaborador = (Colaborador)cboColaborador.SelectedItem;
                DateTime fecha = dtpFecha.Value;
                bool sin_errores = chkSinErrores.Checked;
                string otros_errores = chkSinErrores.Checked ? string.Empty : txtOtrosErrores.Text;
                string observaciones = txtObservaciones.Text;

                // Verificar si el registro es nuevo

                if (_registro == null)
                {
                    // Agregar los datos del nuevo registro

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeRegistroErroresCierreRegistro") == DialogResult.Yes)
                    {
                        RegistroErroresCierre nuevo = new RegistroErroresCierre(colaborador, _coordinador, fecha, sin_errores,
                                                                                otros_errores, observaciones);

                        if (!chkSinErrores.Checked)
                        {

                            foreach (TipoErrorCierre tipo in clbErrores.CheckedItems)
                                nuevo.agregarError(tipo);

                        }

                        _coordinacion.agregarRegistroErroresCierre(ref nuevo);

                        padre.agregarRegistro(nuevo);
                        Mensaje.mostrarMensaje("MensajeRegistroErroresCierreConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    RegistroErroresCierre copia = new RegistroErroresCierre(_registro.Id, colaborador, _registro.Coordinador, fecha,
                                                                            sin_errores, otros_errores, observaciones);

                    if (!chkSinErrores.Checked)
                    {

                        foreach (TipoErrorCierre tipo in clbErrores.CheckedItems)
                            copia.agregarError(tipo);

                    }

                    // Actualizar los datos del registro

                    _coordinacion.actualizarRegistroErroresCierre(copia);

                    _registro.Colaborador = colaborador;
                    _registro.Fecha = fecha;
                    _registro.Sin_errores = sin_errores;
                    _registro.Otros_errores = otros_errores;
                    _registro.Observaciones = observaciones;

                    _registro.Errores = copia.Errores;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeRegistroErroresCierreConfirmacionActualizacion");
                    this.Close();
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
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
        /// Se marca o desmarca la opción que indica su hubieron errores.
        /// </summary>
        private void chkSinErrores_CheckedChanged(object sender, EventArgs e)
        {
            pnlErrores.Enabled = !chkSinErrores.Checked;
        }

        #endregion Eventos

    }

}
