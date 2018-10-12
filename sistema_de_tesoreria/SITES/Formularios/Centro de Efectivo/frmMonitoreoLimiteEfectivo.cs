using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriaMensajes;
using CommonObjects;
using BussinessLayer;
using CommonObjects.Clases;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmMonitoreoLimiteEfectivo : Form
    {
                

        #region Atributos
        /// <summary>
        /// Atributos: instancia a clase de SeguridadBL y para llenar lista de colaboradores.
        /// </summary>
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private BindingList<Colaborador> listacajero = new BindingList<Colaborador>();        
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private Colaborador _colaborador;

        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Constructor del formulario de Monitoreo de Limite de Efectivo. Carga los cajeros en el combobox respectivo.
        /// </summary>
        public frmMonitoreoLimiteEfectivo(Colaborador c)
        {
            InitializeComponent();
            //listacajero = _seguridad.listarColaboradores("");
            cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB, Puestos.CajeroC, Puestos.CajeroD, Puestos.CajeroE);
            //cboCajero.ListaMostrada = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB, Puestos.CajeroC, Puestos.CajeroD, Puestos.CajeroE, Puestos.CajeroF);
            cboCajero.SelectedIndex = 0;
            _colaborador = c;
        }

        #endregion Constructor       

        #region Eventos

        private void frmMonitoreoLimiteEfectivo_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Evento botón Buscar. Verifica que haya seleccionado un cajero del combo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable listalimiteefectivo = new DataTable();
                if (cboCajero.SelectedIndex > -1)
                {
                    if (cboCajero.SelectedItem.ToString() == "Todos")
                    {
                        listalimiteefectivo = _mantenimiento.listarMonitoreoLimiteEfectivo(0);
                    }
                    else
                    {
                        Colaborador cajero = (Colaborador)cboCajero.SelectedItem;
                        listalimiteefectivo = _mantenimiento.listarMonitoreoLimiteEfectivo(cajero.ID);
                    }
                    dgvcajeros.DataSource = listalimiteefectivo;
                    dgvcajeros.Refresh();
                }
                else
                {
                    MessageBox.Show("No ha seleccionado ninguna opción del combo de cajero");
                }
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        #endregion Eventos                                        

        private void btnmantenimiento_Click(object sender, EventArgs e)
        {
            frmLimiteEfectivo limite = new frmLimiteEfectivo(_colaborador);
            limite.ShowDialog();
        }



        #region Métodos Privados



        #endregion Métodos Privados

        private void btnLimpiarMontos_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro que desea limpiar los montos actuales que llevan todos los cajeros?", "Confirmación de limpieza de montos de cajeros", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    _mantenimiento.actualizarLimpiarDenominacionesBV();
                    MessageBox.Show("El proceso de actualizar finalizó su ejecución de forma correcta.");
                }                    
            }
            catch (Excepcion ex)
            {
                MessageBox.Show("Error btnLimpiarMontos: " + ex.Message);
            }
        }
    }
}
