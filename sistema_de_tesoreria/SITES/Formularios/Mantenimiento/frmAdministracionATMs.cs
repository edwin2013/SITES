//
//  @ Project : 
//  @ File Name : frmAdministracionATMs.cs
//  @ Date : 09/05/2012
//  @ Author : Erick Chavarría 
//

using System;
using System.ComponentModel;
using System.Windows.Forms;

using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using LibreriaReportesOffice;
using System.Data;
using System.Drawing;
using System.Reflection;


namespace GUILayer
{

    public partial class frmAdministracionATMs : Form
    {

        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        #endregion Atributos

        #region Constructor

        public frmAdministracionATMs()
        {
            InitializeComponent();

            try
            {
                // Cargar la lista de ATM's

                dgvATMs.AutoGenerateColumns = false;
                dgvATMs.DataSource = _mantenimiento.listarATMs();
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
        /// Clic en el botón de agregar ATM.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoATMs formulario = new frmMantenimientoATMs();

                formulario.ShowDialog(this);
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }

        /// <summary>
        /// Clic en el botón de modificar ATM.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.mostrarVentanaModificacion();
        }

        /// <summary>
        /// Clic en el botón de eliminar ATM.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Mensaje.mostrarMensajeConfirmacion("MensajeATMEliminacion") == DialogResult.Yes)
                {
                    ATM atm = (ATM)dgvATMs.SelectedRows[0].DataBoundItem;

                    _mantenimiento.eliminarATM(atm);

                    dgvATMs.Rows.Remove(dgvATMs.SelectedRows[0]);
                    Mensaje.mostrarMensaje("MensajeATMConfirmacionEliminacion");
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
        /// Doble clic en la lista de ATM's.
        /// </summary>
        private void dgvATMs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.mostrarVentanaModificacion();
        }

        /// <summary>
        /// Se selecciona otro ATM de la lista de ATM's.
        /// </summary>
        private void dgvATMs_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvATMs.SelectedRows.Count > 0)
            {
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }

        }


        /// <summary>
        /// Clic en el boton de Exportar
        /// </summary>
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.exportar();
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
            catch (Exception)
            {
                Excepcion.mostrarMensaje("ErrorExcel");
            }
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Mostrar la ventana de modificación.
        /// </summary>
        public void mostrarVentanaModificacion()
        {

            try
            {
                if (dgvATMs.SelectedRows.Count > 0)
                {
                    ATM atm = (ATM)dgvATMs.SelectedRows[0].DataBoundItem;
                    frmMantenimientoATMs formulario = new frmMantenimientoATMs(atm);

                    formulario.ShowDialog(this);
                }

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }

        }



        /// <summary>
        /// Exportar el reporte.
        /// </summary>
        private void exportar()
        {

            try
            {

                if (dgvATMs.RowCount > 0)
                {
                    DocumentoExcel documento = new DocumentoExcel();
                    DataTable datos = (DataTable)_mantenimiento.listarATMsExportar();
                    documento.seleccionarHoja(1);

                    int fila = 8;

                    // Dar formato al encabezado del reporte

                    documento.seleccionarCelda("B2");
                    documento.actualizarValorCelda("Exportacion de ATMs");
                    documento.formatoCelda(subrayado: true, negrita: true, color_fuente: Color.Red);
                    documento.seleccionarSegundaCelda("F2");
                    documento.ajustarCeldas(AlineacionHorizontal.Centro);

                                  

                    fila = 9;


                    documento.seleccionarCelda("B2");
                    documento.seleccionarSegundaCelda(fila - 2, 6);
                    documento.formatoTabla(false);

                    // Copiar los valores

                    int filas = datos.Rows.Count;

                    foreach (DataColumn columna in datos.Columns)
                    {
                        int numero_columna = columna.Ordinal + 2;

                        documento.seleccionarCelda(fila, numero_columna);
                        documento.actualizarValorCelda(columna.ColumnName);
                        documento.formatoCelda(subrayado: true, color_fondo: Color.LightGray);
                        documento.seleccionarSegundaCelda(fila + filas, numero_columna);
                        documento.autoajustarTamanoColumnas();
                    }

                    documento.seleccionarCelda(fila + 1, 2);
                    documento.actualizarValoresTabla(datos);

                    documento.seleccionarCelda(fila, 2);
                    documento.seleccionarSegundaCelda(fila + filas, datos.Columns.Count + 1);
                    documento.formatoTabla(false);

                    // Mostrar el libro y cerrarlo

                    documento.mostrar();
                    documento.cerrar();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Converts Current Generic Collection to a DataTable
        /// </summary>
        /// <returns>DataTable Corresponding to the current collection.</returns>
        public DataTable ConvertToDataTable(BindingList<ATM> atm)
        {

            DataTable dt = new DataTable();
            //Main Collection Loop
            for (int i = 0; i < atm.Count; i++)
            {

                //Define property object to list Columns by field name
                PropertyDescriptorCollection Classproperties = TypeDescriptor.GetProperties(atm[i]);

                if (i.Equals(0)) //Create Table Header
                {
                    //Create Columns
                    for (int x = 0; x < Classproperties.Count; x++)
                    {
                        DataColumn dtc = new DataColumn();
                        dtc.ColumnName = Classproperties[x].Name;

                        dt.Columns.Add(dtc);

                    }
                }
                DataRow dr = dt.NewRow(); //new datatable row
                //Fill in DataTable
                for (int x = 0; x < 10; x++)
                {
                    Type fieldtype = atm[i].GetType();
                    string fldname = Classproperties[x].Name.ToString();
                    PropertyInfo prtinf = fieldtype.GetProperty(fldname) as PropertyInfo;
                    dr[x] = prtinf.GetValue(atm[i], null);
                }

                dt.Rows.Add(dr);

            }
            //Return the datatable object
            return dt;
        }

        #endregion Métodos Privados

        #region Métodos Públicos

        /// <summary>
        /// Actualizar las lista de ATM's.
        /// </summary>
        public void actualizarLista()
        {
            dgvATMs.Refresh();
            dgvATMs.AutoResizeColumns();
        }

        /// <summary>
        /// Agregar un ATM a la lista.
        /// </summary>
        public void agregarATM(ATM atm)
        {
            BindingList<ATM> atms = (BindingList<ATM>)dgvATMs.DataSource;

            atms.Add(atm);
        }

        #endregion Métodos Públicos

        private void frmAdministracionATMs_Load(object sender, EventArgs e)
        {

        }

       

    }

}
