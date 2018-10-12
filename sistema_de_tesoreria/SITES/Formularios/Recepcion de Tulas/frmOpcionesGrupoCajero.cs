using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using CommonObjects;


namespace GUILayer.Formularios.Recepcion_de_Tulas
{
    public partial class frmOpcionesGrupoCajero : Form
    {

        #region Atributos

        private AtencionBL _atencion = AtencionBL.Instancia;
        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        
        private Colaborador _usuario = null;
        
        private frmOpcionesRegistro _padre = null;
        
        public BindingList<Colaborador> _cajas_cajeros = null;

        private Grupo _grupo = null;

        int numero_cajas = 0;
        
        #endregion Atributos

        #region Constructor
        
        public frmOpcionesGrupoCajero(Colaborador usuario, Grupo grupo, BindingList<Colaborador> cajas_cajeros)
        {
            InitializeComponent();

            _grupo = grupo;
            _cajas_cajeros = cajas_cajeros;
            _usuario = usuario;

            numero_cajas = Convert.ToInt32(_grupo.Numero_cajas);
            
            
            try
            {
                if (_grupo.Area == AreasManifiestos.CentroEfectivo)
                {

                    if (!_grupo.Caja_unica == true)
                    {
                        this.actualizarListaCajeros(_seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB, Puestos.Digitador));
                    }
                    else
                    {
                        this.actualizarListaCajeros(_seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB, Puestos.Digitador));
                  
                        //this.actualizarListaCajeros(_seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Coordinador,Puestos.CoordinadorOperativo));
                    }
                }
                else
                {
                    if (_grupo.Area == AreasManifiestos.Boveda)
                    {
                        this.actualizarListaCajeros(_seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.CajeroA, Puestos.CajeroB, Puestos.Digitador));
                  
                        //this.actualizarListaCajeros(_seguridad.listarColaboradoresPorPuestoArea(Areas.Boveda, Puestos.CajeroA,Puestos.CajeroB, Puestos.CoordinadorOperativo, Puestos.Coordinador));
                    }

                    else
                    {
                        if (_grupo.Area == AreasManifiestos.ProcesoExterno)
                        {
                            BindingList<Colaborador> Colaboradores = _seguridad.listarColaboradoresPorPuestoArea(Areas.Boveda,Puestos.CajeroA,Puestos.CajeroB, Puestos.Coordinador,Puestos.CoordinadorOperativo);
                            BindingList<Colaborador> colaboradorestemp = _seguridad.listarColaboradoresPorPuestoArea(Areas.CentroEfectivo, Puestos.Coordinador);
                            foreach (Colaborador colaborador in colaboradorestemp)
                            { Colaboradores.Add(colaborador); }

                            this.actualizarListaCajeros(Colaboradores);
                        }
                    }
                }
                    
            }
             catch (Exception ex)
            {
                this.Close();
                throw ex;
            }
            
        
        }

        #endregion Constructor

        #region Metodos Privados

        /// <summary>
        /// Actualiza la lista de los cajeros
        /// </summary>
        /// <param name="cajeros">Lista con los colaboradores de Centro Efectivo</param>
        private void actualizarListaCajeros(BindingList<Colaborador> cajeros)
        {
            try
            {
                clbCajeros.Items.Clear();

                foreach (Colaborador colaborador in cajeros)
                {
                    clbCajeros.Items.Add(colaborador); 
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion Metodos Privados
       
        #region Eventos

        private void btnGenerar_Click(object sender, EventArgs e)
        {
           
            List<Colaborador> cajeros = new List<Colaborador>();
            
            foreach (Colaborador cajero in clbCajeros.CheckedItems)
                     cajeros.Add(cajero);

            numero_cajas = _grupo.Numero_cajas;
            
            _mantenimiento.reiniciarAsignacionManifiestoCajero(_grupo); 
            
            _cajas_cajeros = _coordinacion.getRandomCajerosCEF(cajeros,numero_cajas);
           
            foreach (Colaborador cajero in _cajas_cajeros)  
            { 
                ManifiestoColaborador manifiestocolaborador = new ManifiestoColaborador(posicion: cajero.Caja, grupo: _grupo,
                                                                            manifiesto: null, cajero_receptor: cajero);

                _mantenimiento.agregarAsignacionManifiestoCajero(ref manifiestocolaborador);
            }
                
            //Guarda los datos de los cajeros a la base de datos

             frmOpcionesRegistro _padre = new frmOpcionesRegistro(_usuario);
             _padre.Close();
           
             this.Close();
            
        }

        private void clbCajeros_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (clbCajeros.CheckedItems.Count >= (numero_cajas -1))
            {
                MessageBox.Show("Se han seleccionado " + numero_cajas.ToString() + " cajeros.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clbCajeros.Enabled = false;
                btnGenerar.Enabled = true;
            }    
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            _cajas_cajeros = null;
            this.Close();

        }

        #endregion Eventos


    }
}
