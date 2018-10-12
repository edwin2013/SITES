//
//  @ Project : 
//  @ File Name : frmGeneracionLibroMayorATMs.cs
//  @ Date : 27/02/2013
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using LibreriaReportesOffice;


namespace GUILayer
{

    public partial class frmGeneracionLibroMayorATMs : Form
    {

        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmGeneracionLibroMayorATMs()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de exportar.
        /// </summary>
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            DocumentoExcel documento = null;

            try
            {
                documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\plantilla libro mayor atm's.xltx", true);
                
                DateTime fecha = dtpFecha.Value;
                DataTable cargas = _coordinacion.listarCargasATMsLibroMayor(fecha);
                DataTable descargas = _coordinacion.listarDescargasATMsLibroMayor(fecha);

                documento.seleccionarHoja(4);
                documento.seleccionarCelda("B3");
                documento.actualizarValoresTabla(cargas);

                documento.seleccionarHoja(3);
                documento.seleccionarCelda("B3");
                documento.actualizarValoresTabla(descargas);

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }

            if (documento != null)
            {
                documento.mostrar();
                documento.cerrar();
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
