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
using BussinessLayer.Clases;

namespace GUILayer
{
    public partial class frmAsignarTripulacion : Form
    {


        #region Atributos

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;
        private SeguridadBL _seguridad = SeguridadBL.Instancia;
        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private DateTime _fecha = DateTime.Today;
        private Colaborador _usuario = null;
        
  

        #endregion Atributos

        #region Constructor
        public frmAsignarTripulacion(DateTime fecha, Colaborador usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            _fecha = fecha;
         

            try
            {
                this.actualizarListaChoferes(_seguridad.listarColaboradoresPorPuestoArea(Areas.Blindados, Puestos.Chofer));
                this.actualizarListaCustodios(_seguridad.listarColaboradoresPorPuestoArea(Areas.Blindados, Puestos.Custodio));
                this.actualizarListaPortavalores(_seguridad.listarColaboradoresPorPuestoArea(Areas.Blindados, Puestos.Portavalor));


                this.marcarDatos(clbChoferes);
                this.marcarDatos(clbCustodios);
                this.marcarDatos(clbPortavalores);
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
        /// Actuailza la lista de portavalores
        /// </summary>
        /// <param name="portavalores">Lista con los colaboradores con rol de portavalor</param>
        private void actualizarListaPortavalores(BindingList<Colaborador> portavalores)
        {
            try
            {
                //DateTime fecha = dtpFecha.Value;
               
                clbPortavalores.Items.Clear();

                foreach (Colaborador colaborador in portavalores)
                    clbPortavalores.Items.Add(colaborador);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualiza la lista de custodios
        /// </summary>
        /// <param name="custodios">Lista con los colaboradores con rol de custodio</param>
        private void actualizarListaCustodios(BindingList<Colaborador> custodios)
        {
            try
            {
                //DateTime fecha = dtpFecha.Value;

                clbCustodios.Items.Clear();

                foreach (Colaborador colaborador in custodios)
                    clbCustodios.Items.Add(colaborador);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Actualiza la lista de los choferes
        /// </summary>
        /// <param name="choferes">Lista con los colaboradores con rol de chofer</param>
        private void actualizarListaChoferes(BindingList<Colaborador> choferes)
        {
            try
            {
                //DateTime fecha = dtpFecha.Value;

                clbChoferes.Items.Clear();

                foreach (Colaborador colaborador in choferes)
                {
                    clbChoferes.Items.Add(colaborador);
                }

               
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

     

        /// <summary>
        /// Eliminar la seleccion de los la lista
        /// </summary>
        /// <param name="auxiliar">indice que se encuentra checked</param>
        private void Unchecked_Items(int auxiliar)
        {
            try
            {
                //int indexChecked = 0;
                //int final = clbChoferes.Items.Count;

                //foreach (object itemChecked in clbChoferes.CheckedItems)
                //{

                //    if (clbChoferes.GetItemCheckState(clbChoferes.Items.IndexOf(itemChecked)) == CheckState.Checked)
                //    {
                //        clbChoferes.SetItemCheckState(clbChoferes.Items.IndexOf(itemChecked), CheckState.Unchecked);
                //    }
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        /// <summary>
        /// Marca Todos los datos de un checkedlistbox
        /// </summary>
        /// <param name="lista">CheckedListBox con los datos a marcar</param>
        private void marcarDatos(CheckedListBox lista)
        {
            try
            {
                for (int i = 0; i < lista.Items.Count; i++)
                    lista.SetItemChecked(i, true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        /// <summary>
        /// Guarda los datos de las tripulaciones
        /// </summary>
        /// <param name="tripulaciones">Lista de Tripulaciones con los datos de las Tripulaciones</param>
        private void Guardar(List<Tripulacion> tripulaciones)
        {
            Tripulacion nuevo = new Tripulacion();
            int i = 1;
            foreach (Tripulacion tripulacion in tripulaciones)
            {
                nuevo = tripulacion;
                nuevo.OrdenSalida = i;
                _mantenimiento.agregarTripulaciones(ref nuevo, _fecha);
                i++;
            }
        }

        private void Generar()
        {
            
        }
        #endregion Metodos Privados





        #region Eventos

        private void clbPortavalores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //foreach (int indexChecked in clbPortavalores.CheckedIndices)
                //{
                //   if (clbPortavalores.GetItemCheckState(indexChecked) == CheckState.Checked)
                //    {
                //        clbPortavalores.SetItemCheckState(indexChecked, CheckState.Unchecked);
                //    }
                //}

                //_portavalor = (Colaborador)clbPortavalores.SelectedItem;
                //txtPortavalor.Text = _portavalor.ToString();
                //txtPortavalor.BackColor = Color.LightGreen;
                //clbPortavalores.SetItemCheckState(clbPortavalores.SelectedIndex,CheckState.Checked);
            

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void clbChoferes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //foreach (int indexChecked in clbChoferes.CheckedIndices)
                //{
                //    if (clbChoferes.GetItemCheckState(indexChecked) == CheckState.Checked)
                //    {
                //        clbChoferes.SetItemCheckState(indexChecked, CheckState.Unchecked);
                //    }
                //}

                //_chofer = (Colaborador)clbChoferes.SelectedItem;
                //txtChofer.Text = _chofer.ToString();
                //txtChofer.BackColor = Color.LightGreen;
                //clbChoferes.SetItemCheckState(clbChoferes.SelectedIndex, CheckState.Checked);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void clbCustodios_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    foreach (int indexChecked in clbCustodios.CheckedIndices)
            //    {
            //        if (clbCustodios.GetItemCheckState(indexChecked) == CheckState.Checked)
            //        {
            //            clbCustodios.SetItemCheckState(indexChecked, CheckState.Unchecked);
            //        }
            //    }

            //    _custodio = (Colaborador)clbCustodios.SelectedItem;
            //    txtCustodio.Text = _custodio.ToString();
            //    txtCustodio.BackColor = Color.LightGreen;
            //    clbCustodios.SetItemCheckState(clbCustodios.SelectedIndex, CheckState.Checked);


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            List<Colaborador> choferes = new List<Colaborador>();
            List<Colaborador> custodios = new List<Colaborador>();
            List<Colaborador> portavalores = new List<Colaborador>();



            List<Colaborador> choferesnueva = new List<Colaborador>();
            List<Colaborador> custodiosnueva = new List<Colaborador>();
            List<Colaborador> portavaloresnueva = new List<Colaborador>();


            MersenneTwister randGen = new MersenneTwister();



            foreach (object chofer in clbChoferes.CheckedItems)
                choferes.Add((Colaborador)chofer);

            foreach (object custodio in clbCustodios.CheckedItems)
                custodios.Add((Colaborador)custodio);

            foreach (object portavalor in clbPortavalores.CheckedItems)
                portavalores.Add((Colaborador)portavalor);



            int cantidadchofer = choferes.Count;
            int cantidadcustodio = custodios.Count;
            int cantidadportavalor = portavalores.Count;


          

            for(int i = 0; i < cantidadchofer; i++)
            {
                // inicializar el objeto para manejar numeros aleatorios
                //Random random = new Random();
                //// obtener un numero aleatorio entre los existentes en el array
                //int randchof = random.Next(0, choferes.Count - 1);

                int randchof = randGen.Next(choferes.Count - 1);

                choferesnueva.Add(choferes[randchof]);

                choferes.RemoveAt(randchof);



            }

            for(int i = 0; i < cantidadcustodio; i++)
            {
                // inicializar el objeto para manejar numeros aleatorios
                Random random = new Random();
                // obtener un numero aleatorio entre los existentes en el array
                int randcus = randGen.Next(custodios.Count - 1); //random.Next(0, custodios.Count - 1);
                
                custodiosnueva.Add(custodios[randcus]);
                custodios.RemoveAt(randcus);
            }

            for (int i = 0; i < cantidadportavalor; i++)
            {
                // inicializar el objeto para manejar numeros aleatorios
                Random random = new Random();
                // obtener un numero aleatorio entre los existentes en el array
                int randport = randGen.Next(portavalores.Count - 1); //random.Next(0, portavalores.Count - 1);

                portavaloresnueva.Add(portavalores[randport]);
                portavalores.RemoveAt(randport);
            }

           
            //  _cargas_asignadas = _coordinacion.autoAsignarCargas(cajeros, cargas);

            //List<Tripulacion> tripulaciones = _coordinacion.autoAsignarTripulaciones(choferes, portavalores, custodios, Convert.ToInt32(nudRutas.Value),_usuario);
            List<Tripulacion> tripulaciones = _coordinacion.getRandom(choferesnueva, portavaloresnueva, custodiosnueva, Convert.ToInt32(nudRutas.Value), _usuario);

            ////Guarda los datos de las tripulaciones a la base de datos
            this.Guardar(tripulaciones);
            this.Close();

        }

        #endregion Eventos
    }
}
