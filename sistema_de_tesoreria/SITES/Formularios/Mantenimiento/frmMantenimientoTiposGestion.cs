//
//  @ Project : 
//  @ File Name : frmMantenimientoTiposGestion.cs
//  @ Date : 18/08/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;

namespace GUILayer
{

    public partial class frmMantenimientoTiposGestion : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private TipoGestion _tipo = null;

        #endregion Atributos

        #region Constructor

        public frmMantenimientoTiposGestion()
        {
            InitializeComponent();
        }

        public frmMantenimientoTiposGestion(TipoGestion tipo)
        {
            InitializeComponent();

            _tipo = tipo;

            txtNombre.Text = _tipo.Nombre;
            nudTiempoEsperado.Value = _tipo.Tiempo_esperado;
            nudTiempoAviso.Value = _tipo.Tiempo_aviso;
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos

            if (txtNombre.Text.Equals(string.Empty))
            {
                Excepcion.mostrarMensaje("ErrorTipoGestionDatosRegistro");
                return;
            }

            try
            {
                string nombre = txtNombre.Text;
                short tiempo_esperado = (short)nudTiempoEsperado.Value;
                short tiempo_aviso = (short)nudTiempoAviso.Value;

                frmAdministracionTiposGestion padre = (frmAdministracionTiposGestion)this.Owner;

                // Verificar si el tipo de gestión ya está registrado

                if (_tipo == null)
                {
                    // Agregar los datos del tipo de gestión

                    if (Mensaje.mostrarMensajeConfirmacion("MensajeTipoGestionRegistro") == DialogResult.Yes)
                    {
                        TipoGestion nuevo = new TipoGestion(nombre, tiempo_esperado, tiempo_aviso);

                        _mantenimiento.agregarTipoGestion(ref nuevo);

                        padre.agregarTipoGestion(nuevo);
                        Mensaje.mostrarMensaje("MensajeTipoGestionConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos del tipo de gestión

                    TipoGestion copia = new TipoGestion(_tipo.Id, nombre, tiempo_esperado, tiempo_aviso);

                    _mantenimiento.actualizarTipoGestion(copia);

                    _tipo.Nombre = nombre;
                    _tipo.Tiempo_esperado = tiempo_esperado;
                    _tipo.Tiempo_aviso = tiempo_aviso;

                    padre.actualizarLista();
                    Mensaje.mostrarMensaje("MensajeTipoGestionConfirmacionActualizacion");
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

        #endregion Eventos

    }

}
