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
using LibreriaMensajes;
using CommonObjects.Clases;
using System.Collections;

namespace GUILayer.Formularios.Boveda
{
    public partial class frmMutilado : Form
    {

        #region Atributos

        private AtencionBL _atencion = AtencionBL.Instancia;

        private CoordinacionBL _coordinacion = CoordinacionBL.Instancia;

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private BindingList<CargaSucursal> _mutilados = new BindingList<CargaSucursal>();
        BindingList<Bolsa> tulas = new BindingList<Bolsa>();
        

        private Colaborador _colaborador = null;

        private ArrayList _numeros_colones = new ArrayList();
        private ArrayList _numeros_dolares = new ArrayList();
        private ArrayList _numeros_euros = new ArrayList();
        decimal _total_colones = 0;

        bool aux50000colones = true, aux20000colones = true, aux10000colones = true, aux5000colones = true, aux2000colones = true, 
          aux1000colones = true, aux500colones = true,aux100colones = true, aux50colones = true, aux25colones = true, aux10colones = true,
          aux5colones = true,aux100dolares = true, aux50dolares = true, aux20dolares = true, aux10dolares = true, aux5dolares = true,
          aux1dolares = true, aux500euros = true, aux200euros = true, aux100euros = true, aux50euros = true, aux20euros = true,
          aux10euros = true, aux5euros = true, aux2dolares = true;

        #endregion Atributos

        #region Constructor
        public frmMutilado(Colaborador coordinador)
        {
            InitializeComponent();

            _colaborador = coordinador;

            try
            {
                cboSucursal.ListaMostrada = _mantenimiento.listarSucursalesRecientes();
                cboTransportadora.ListaMostrada = _mantenimiento.listarEmpresasTransporte();

                tulas = _coordinacion.listarTulasSucursales();

                foreach (Bolsa bolsa in tulas)
                {
                    if (bolsa.SerieBolsa != null)
                    {

                        cbSerietula.Items.Add(bolsa.SerieBolsa);
                        
                    }
                }
                txtNumeroManifiesto.Enabled = true;
            }
            catch (Exception)
            {
                throw new Excepcion("ErrorDatosConexion");
            }
        }

        #endregion Constructor


        #region Eventos

       /// <summary>
       /// Selecciona los datos de la carga segun el numero de tula asignado.
       /// </summary>
       
        private void cbSerietula_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Bolsa bolsa in tulas)
            {
                if (cbSerietula.Text == bolsa.SerieBolsa.ToString())
                {
                    txtNumeroManifiesto.Text = bolsa.Manifiesto.ID.ToString();
                    //cboSucursal.Text = bolsa.Sucursal.ToString();
                    //cboTransportadora.Text = bolsa.Transportadora.ToString();
                }
            }


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            guardarCargaSucursal();

        }
        
        /// <summary>
        /// Habilita los datos billetes de Colones
        /// </summary>
        private void chkColones_CheckedChanged(object sender, EventArgs e)
        {
            if (chkColones.Checked == true)
            {
                this.HabilitarCamposBilletesColones();
                tpColonesBillete.Show();
            }
            else
            {
                this.DesHabiitarCamposBilletesColones();
             }
        }

        /// <summary>
        /// Habilita los datos de Niquel
        /// </summary>
        private void chkNiquel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNiquel.Checked == true)
            {
                this.HabilitarCamposNiquel();
                tpNiquelColones.Show();
            }
            else
            {
                this.DesHabilitarCamposNiquel();
            }


        }

        /// <summary>
        /// Habilita los datos de billetes de dolares
        /// </summary>
        private void chkDolares_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDolares.Checked == true)
            {
                this.HabilitarCamposDolares();
                tpDolares.Show();
            }
            else
                this.DesHabilitarCamposDolares();

        }

        /// <summary>
        /// Habilita los datos de billetes de dolares
        /// </summary>
        private void chkEuros_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEuros.Checked == true)
            {
                this.HabilitarCamposEuros();
                tpEuros.Show();
            }
            else
                this.DesHabiitarCamposEuros();
        }


        #region Colones

        /// <summary>
        /// Salir del campo de colones
        /// </summary>
        private void txt50000colonesmut_Leave(object sender, EventArgs e)
        {

            if (txt50000colonesmut.Text == string.Empty || txt50000colonesmut.Text == "0")
                txt50000colonesmut.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt50000colonesmut.Text);

                if (ValidarMontos(auxiliar, 50000, txt50000colonesmut, ref aux50000colones))
                {
                    this.CalcularMontoBilletesColones();
                }
                
            }
        }

        /// <summary>
        /// Salir del campo de colones
        /// </summary>
       private void txt20000colonesmut_Leave(object sender, EventArgs e)
        {

            if (txt20000colonesmut.Text == string.Empty || txt20000colonesmut.Text == "0")
                txt20000colonesmut.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt20000colonesmut.Text);

                if (ValidarMontos(auxiliar, 20000, txt20000colonesmut, ref aux20000colones))
                {
                    this.CalcularMontoBilletesColones();
                }
            }
        }

        /// <summary>
        /// Salir del campo de colones
        /// </summary>
       private void txt10000colonesmut_Leave(object sender, EventArgs e)
        {

            if (txt10000colonesmut.Text == string.Empty || txt10000colonesmut.Text == "0")
                txt10000colonesmut.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt10000colonesmut.Text);

                if (ValidarMontos(auxiliar, 10000, txt10000colonesmut, ref aux10000colones))
                {
                    this.CalcularMontoBilletesColones();
                }
               
            }
        }

        /// <summary>
        /// Salir del campo de colones
        /// </summary>
        private void txt5000colonesmut_Leave(object sender, EventArgs e)
        {

            if (txt5000colonesmut.Text == string.Empty || txt5000colonesmut.Text == "0")
                txt5000colonesmut.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt5000colonesmut.Text);

                if (ValidarMontos(auxiliar, 5000, txt5000colonesmut, ref aux5000colones))
                {
                    this.CalcularMontoBilletesColones();
                }
                
            }
        }

        /// <summary>
        /// Salir del campo de colones
        /// </summary>
        private void txt2000colonesmut_Leave(object sender, EventArgs e)
        {

            if (txt2000colonesmut.Text == string.Empty || txt2000colonesmut.Text == "0")
                txt2000colonesmut.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt2000colonesmut.Text);

                if (ValidarMontos(auxiliar, 2000, txt2000colonesmut, ref aux2000colones))
                {
                    this.CalcularMontoBilletesColones();
                }
               
            }
        }


        /// <summary>
        /// Salir del campo de colones
        /// </summary>
        private void txt1000colonesmut_Leave(object sender, EventArgs e)
        {

            if (txt1000colonesmut.Text == string.Empty || txt1000colonesmut.Text == "0")
                txt1000colonesmut.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt1000colonesmut.Text);

                if (ValidarMontos(auxiliar, 1000, txt1000colonesmut, ref aux1000colones))
                {
                    this.CalcularMontoBilletesColones();
                }
               
            }
        }
        
  
        /// <summary>
        /// Salir del campo de niquel
        /// </summary>
        private void nud500colonesmut_Leave(object sender, EventArgs e)
        {
            txt500colonesmut.Text = (500 * nud500colonesmut.Value).ToString();
            
            if (txt500colonesmut.Text == string.Empty || txt500colonesmut.Text == "0")
                txt500colonesmut.Text = "0";
            else
            {
                
                
                Decimal auxiliar = Convert.ToDecimal(txt500colonesmut.Text);
               
                if (ValidarMontos(auxiliar, 500, txt500colonesmut, ref aux500colones))
                {
                    this.CalcularMontoMonedas();
                }
                
            }
        }

        /// <summary>
        /// Salir del campo de niquel
        /// </summary>
        private void nud100colonesmut_Leave(object sender, EventArgs e)
        {
            
             txt100colonesmut.Text = (100 * nud100colonesmut.Value).ToString();
             
               
            if (txt100colonesmut.Text == string.Empty || txt100colonesmut.Text == "0")
                txt100colonesmut.Text = "0";
            else
            {
                Decimal auxiliar = Convert.ToDecimal(txt100colonesmut.Text);
                 if (ValidarMontos(auxiliar, 100, txt100colonesmut, ref aux100colones))
                {
                    this.CalcularMontoMonedas();
                }
                
            }
        }

        /// <summary>
        /// Salir del campo de niquel
        /// </summary>
        private void nud50colonesmut_Leave(object sender, EventArgs e)
        {
            txt50colonesmut.Text = (50 * nud50colonesmut.Value).ToString();

            if (txt50colonesmut.Text == string.Empty || txt50colonesmut.Text == "0")
                txt50colonesmut.Text = "0";
            else
            {
                Decimal auxiliar = Convert.ToDecimal(txt50colonesmut.Text);

                if (ValidarMontos(auxiliar, 50, txt50colonesmut, ref aux50colones))
                {
                    this.CalcularMontoMonedas();
                }
             
            }
        }

        /// <summary>
        /// Salir del campo de niquel
        /// </summary>
        private void nud25colonesmut_Leave(object sender, EventArgs e)
        {
             txt25colonesmut.Text = (25 * nud25colonesmut.Value).ToString();

            if (txt25colonesmut.Text == string.Empty || txt25colonesmut.Text == "0")
                txt25colonesmut.Text = "0";
            else
            {
                Decimal auxiliar = Convert.ToDecimal(txt25colonesmut.Text);
                
                if (ValidarMontos(auxiliar, 25, txt25colonesmut, ref aux25colones))
                {
                    this.CalcularMontoMonedas();
                }
               
            }
        }


        /// <summary>
        /// Salir del campo de niquel
        /// </summary>
        private void nud10colonesmut_Leave(object sender, EventArgs e)
        {
           txt10colonesmut.Text = (10 * nud10colonesmut.Value).ToString();
            
            if (txt10colonesmut.Text == string.Empty || txt10colonesmut.Text == "0")
                txt10colonesmut.Text = "0";
            else
            {
                
                Decimal auxiliar = Convert.ToDecimal(txt1000colonesmut.Text);

                if (ValidarMontos(auxiliar, 10, txt10colonesmut, ref aux10colones))
                {
                    this.CalcularMontoMonedas();
                }

            }
        }

        /// <summary>
        /// Salir del campo de niquel
        /// </summary>
        private void nud5colonesmut_Leave(object sender, EventArgs e)
        {
            txt5colonesmut.Text = (5 * nud5colonesmut.Value).ToString();
                
            if (txt5colonesmut.Text == string.Empty || txt5colonesmut.Text == "0")
                txt5colonesmut.Text = "0";
            else
            {
                
                Decimal auxiliar = Convert.ToDecimal(txt1000colonesmut.Text);

                if (ValidarMontos(auxiliar, 5, txt5colonesmut, ref aux5colones))
                {
                    this.CalcularMontoMonedas();
                }
            }
        }

        #endregion Colones


        #region Dólares
        
        /// <summary>
        /// Salir del campo de dolares
        /// </summary>
        private void txt100dolaresmut_Leave(object sender, EventArgs e)
        {
            if (txt100dolaresmut.Text == string.Empty || txt100dolaresmut.Text == "0")
                txt100dolaresmut.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt100dolaresmut.Text);

                if (ValidarMontos(auxiliar, 100, txt100dolaresmut, ref aux100dolares))
                {
                   this.CalcularMontoBilletesDolares();
                }

            }
        }


        /// <summary>
        /// Salir del campo de dolares
        /// </summary>
        private void txt50dolaresmut_Leave(object sender, EventArgs e)
        {
            if (txt50dolaresmut.Text == string.Empty || txt50dolaresmut.Text == "0")
                txt50dolaresmut.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt50dolaresmut.Text);

                if (ValidarMontos(auxiliar, 50, txt50dolaresmut, ref aux50dolares))
                {
                    this.CalcularMontoBilletesDolares();
                }
            }
        }


        /// <summary>
        /// Salir del campo de dolares
        /// </summary>
        private void txt20dolaresmut_Leave(object sender, EventArgs e)
        {
            if (txt20dolaresmut.Text == string.Empty || txt20dolaresmut.Text == "0")
                txt20dolaresmut.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt20dolaresmut.Text);

                if (ValidarMontos(auxiliar, 20, txt20dolaresmut, ref aux20dolares))
                {
                    this.CalcularMontoBilletesDolares();
                }

            }
        }


        /// <summary>
        /// Salir del campo de dolares
        /// </summary>
        private void txt10dolaresmut_Leave(object sender, EventArgs e)
        {
            if (txt10dolaresmut.Text == string.Empty || txt10dolaresmut.Text == "0")
                txt10dolaresmut.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt10dolaresmut.Text);

                if (ValidarMontos(auxiliar, 10, txt10dolaresmut, ref aux10dolares))
                {
                    this.CalcularMontoBilletesDolares();
                }

               
            }
        }


        /// <summary>
        /// Salir del campo de dolares
        /// </summary>
        private void txt5dolaresmut_Leave(object sender, EventArgs e)
        {
            if (txt5dolaresmut.Text == string.Empty || txt5dolaresmut.Text == "0")
                txt5dolaresmut.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt5dolaresmut.Text);

                if (ValidarMontos(auxiliar, 5, txt5dolaresmut, ref aux5dolares))
                {
                    this.CalcularMontoBilletesDolares();
                }

              
            }
        }
        /// <summary>
        /// Salir del campo de dolares
        /// </summary>
        private void txt2dolaresmut_Leave(object sender, EventArgs e)
        {
            if (txt2dolaresmut.Text == string.Empty || txt2dolaresmut.Text == "0")
                txt2dolaresmut.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt2dolaresmut.Text);

                if (ValidarMontos(auxiliar, 2, txt2dolaresmut, ref aux2dolares))
                {
                    this.CalcularMontoBilletesDolares();
                }
               
            }

        }

        /// <summary>
        /// Salir del campo de dolares
        /// </summary>
        private void txt1dolaresmut_Leave(object sender, EventArgs e)
        {
            if (txt1dolaresmut.Text == string.Empty || txt1dolaresmut.Text == "0")
                txt1dolaresmut.Text = "0";
            else
            {

                Decimal auxiliar = Convert.ToDecimal(txt1dolaresmut.Text);

                if (ValidarMontos(auxiliar, 1, txt1dolaresmut, ref aux1dolares))
                {
                    this.CalcularMontoBilletesDolares();
                }

               
            }

        }

       #endregion Dólares

        #region Euros

         /// <summary>
        /// Salir del campo de niquel
        /// </summary>
        private void nud500eurosmut_Leave(object sender, EventArgs e)
        {
            txt500eurosmut.Text = (500 * nud500eurosmut.Value).ToString();

            if (txt500eurosmut.Text == string.Empty || txt500eurosmut.Text == "0")
                txt500eurosmut.Text = "0";
            else
            {
                Decimal auxiliar = Convert.ToDecimal(txt500eurosmut.Text);

               
                if (ValidarMontos(auxiliar, 500, txt500eurosmut, ref aux500euros))
                {
                    CalcularMontoBilletesEuros();

                }

               
            }
        }

        /// <summary>
        /// Salir del campo de niquel
        /// </summary>
        private void nud200eurosmut_Leave(object sender, EventArgs e)
        {
           txt200eurosmut.Text = (200 * nud200eurosmut.Value).ToString();
                
            if (txt200eurosmut.Text == string.Empty || txt200eurosmut.Text == "0")
                txt200eurosmut.Text = "0";
            else
            {
                Decimal auxiliar = Convert.ToDecimal(txt200eurosmut.Text);

               if (ValidarMontos(auxiliar, 200, txt200eurosmut, ref aux200euros))
                {
                    CalcularMontoBilletesEuros();

                }

               }
        }

        /// <summary>
        /// Salir del campo de niquel
        /// </summary>
        private void nud100eurosmut_Leave(object sender, EventArgs e)
        {
             txt100eurosmut.Text = (100 * nud100eurosmut.Value).ToString();
            
            if (txt100eurosmut.Text == string.Empty || txt100eurosmut.Text == "0")
                txt100eurosmut.Text = "0";
            else
            {
                Decimal auxiliar = Convert.ToDecimal(txt100eurosmut.Text);

              
                if (ValidarMontos(auxiliar, 100, txt100eurosmut, ref aux100euros))
                {
                    CalcularMontoBilletesEuros();

                }

            }
        }

        /// <summary>
        /// Salir del campo de niquel
        /// </summary>
        private void nud50eurosmut_Leave(object sender, EventArgs e)
        {
            txt50eurosmut.Text = (50 * nud50eurosmut.Value).ToString();
            
            if (txt50eurosmut.Text == string.Empty || txt50eurosmut.Text == "0")
                txt50eurosmut.Text = "0";
            else
            {
                Decimal auxiliar = Convert.ToDecimal(txt50eurosmut.Text);

                if (ValidarMontos(auxiliar, 50, txt50eurosmut, ref aux50euros))
                {
                    CalcularMontoBilletesEuros();

                }

            }
        }

        /// <summary>
        /// Salir del campo de niquel
        /// </summary>
        private void nud20eurosmut_Leave(object sender, EventArgs e)
        {
            txt20eurosmut.Text = (20 * nud20eurosmut.Value).ToString();
                
            if (txt20eurosmut.Text == string.Empty || txt20eurosmut.Text == "0")
                txt20eurosmut.Text = "0";
            else
            {
                Decimal auxiliar = Convert.ToDecimal(txt20eurosmut.Text);

                if (ValidarMontos(auxiliar, 20, txt20eurosmut, ref aux20euros))
                {
                    CalcularMontoBilletesEuros();

                }

            }
        }

        /// <summary>
        /// Salir del campo de niquel
        /// </summary>
        private void nud10eurosmut_Leave(object sender, EventArgs e)
        {
             txt10eurosmut.Text = (10 * nud10eurosmut.Value).ToString();
                
            if (txt10eurosmut.Text == string.Empty || txt10eurosmut.Text == "0")
                txt10eurosmut.Text = "0";
            else
            {
                Decimal auxiliar = Convert.ToDecimal(txt10eurosmut.Text);

                if (ValidarMontos(auxiliar, 10, txt10eurosmut, ref aux10euros))
                {
                    CalcularMontoBilletesEuros();

                }

            }
        }

        /// <summary>
        /// Salir del campo de niquel
        /// </summary>
        private void nud5eurosmut_Leave(object sender, EventArgs e)
        {
            txt5eurosmut.Text = (5 * nud5eurosmut.Value).ToString();
                
            if (txt5eurosmut.Text == string.Empty || txt5eurosmut.Text == "0")
                txt5eurosmut.Text = "0";
            else
            {
                Decimal auxiliar = Convert.ToDecimal(txt5eurosmut.Text);

                if (ValidarMontos(auxiliar, 5, txt5eurosmut, ref aux5euros))
                {
                    CalcularMontoBilletesEuros();

                }

            }
        }


        #endregion Euros

        #endregion Eventos

        #region Métodos Publicos

        public void guardarCargaSucursal()
        {
            try
            {
                if (ValidarCampos() && ValidaErroneos())
                {
                    _mutilados.Clear();

                    Dictionary<double, decimal> denominaciones_colones = this.obtenerDenominacionesColones();
                    Dictionary<double, decimal> denominaciones_dolares = this.obtenerDenominacionesDolares();
                    Dictionary<double, decimal> denominaciones_euros = this.obtenerDenominacionesEuros();

                    generarCargasMoneda(Monedas.Colones, DateTime.Today, denominaciones_colones, _numeros_colones);
                    generarCargasMoneda(Monedas.Dolares, DateTime.Today, denominaciones_dolares, _numeros_dolares);
                    generarCargasMoneda(Monedas.Euros, DateTime.Today, denominaciones_euros, _numeros_euros);

                    foreach (CargaSucursal c in _mutilados)
                    {
                        CargaSucursal copia = c;
                        _coordinacion.importarCargasSucursales(ref copia, _colaborador);
                    }

                    MessageBox.Show("Carga Ingresada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();

                }
                else
                {
                    MessageBox.Show("Verifique los datos ingresados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                      
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }



        }

        #endregion Métodos Públicos

        #region Métodos Privados

        /// <summary>
        /// Generar las cargas para una moneda específica.
        /// </summary>
        private void generarCargasMoneda(Monedas moneda, DateTime fecha,
                                         Dictionary<double, decimal> denominaciones, ArrayList numeros)
        {
            // Leer las denominaciones

            // this.identificarDenominaciones(numeros, moneda);

            Sucursal sucursal = (Sucursal)cboSucursal.SelectedItem;

            CargaSucursal mutilado = this.buscarCargaSucursal(sucursal, fecha);

            foreach (Decimal d in numeros)
            {
                Denominacion denominacion = new Denominacion(valor: Convert.ToDecimal(d), moneda: moneda);

                _mantenimiento.verificarDenominacion(ref denominacion);

                this.asignarCartuchos(Convert.ToDouble(denominacion.Valor), ref mutilado, denominaciones, moneda);
            }

        }



        /// <summary>
        /// Buscar si ya se registro la carga para una Sucursal.
        /// </summary>
        private CargaSucursal buscarCargaSucursal(Sucursal sucursal, DateTime fecha)
        {
            CargaSucursal nuevo = new CargaSucursal();


            foreach (CargaSucursal mutilado in _mutilados)
            {
                if (mutilado.Sucursal != null)
                {
                    if (mutilado.Sucursal.Codigo == sucursal.Codigo)
                        return mutilado;
                }
                else
                {
                    mutilado.Sucursal = sucursal;
                }
            }
           
            Bolsa bolsita = new Bolsa();
            bolsita.SerieBolsa = cbSerietula.Text;

            BindingList<Bolsa> bolsas = new BindingList<Bolsa>();
            bolsas.Add(bolsita);

            ManifiestoSucursalCarga manifiesto = new ManifiestoSucursalCarga(bolsas);
            _atencion.agregarManifiestoSucursalCarga(ref manifiesto);
            txtNumeroManifiesto.Text = manifiesto.ID.ToString();
            //nuevo = new CargaSucursal(sucursal:sucursal, transportadora: sucursal.Empresa, fecha_asignada: dtpFecha.Value, cajero: _colaborador, manifiesto: manifiesto, estado: EstadosCargasSucursales.Entrega_Boveda);
            nuevo = new CargaSucursal(sucursal: sucursal, transportadora: sucursal.Empresa, fecha_asignada:dtpFecha.Value, cajero:_colaborador, estado:EstadosCargasSucursales.Entrega_Boveda, mutilado: true);
            nuevo.Mutilado = true;
            nuevo.Manifiesto = new BindingList<ManifiestoSucursalCarga>();
            nuevo.Manifiesto.Add(manifiesto);
            

            if(nuevo.Sucursal != null)
                _mutilados.Add(nuevo);

            return nuevo;
        }

        /// <summary>
        /// Asignar los cartuchos de una carga y determinar si el monto erra correcto.
        /// </summary>
        private void asignarCartuchos(double p_monto, ref CargaSucursal mutilado, Dictionary<double, decimal> denominaciones, Monedas moneda)
        {
            decimal monto = 0;


            monto = denominaciones[p_monto];

            Denominacion denominacion = new Denominacion(valor: Convert.ToDecimal(p_monto), moneda: moneda);

            _mantenimiento.verificarDenominacion(ref denominacion);

            double cantidad_total = (double)Math.Ceiling(monto / denominacion.Valor);

            double cantidad_cartucho = (double)(monto / denominacion.Valor);

            //CartuchoCargaSucursal cartucho = new CartuchoCargaSucursal(mutilado, cantidad_asignada: cantidad_cartucho,
            //                                                 denominacion: denominacion);


            CartuchoCargaSucursal cartucho = new CartuchoCargaSucursal(movimiento:mutilado,cantidad_asignada:cantidad_cartucho,denominacion:denominacion);

            mutilado.agregarCartucho(cartucho);

            switch (denominacion.Moneda)
            {
                case Monedas.Colones: mutilado.Monto_pedido_colones += monto; break;
                case Monedas.Dolares: mutilado.Monto_pedido_dolares += monto; break;
                case Monedas.Euros: mutilado.Monto_pedido_euros += monto; break;
            }

        }


        /// <summary>
        /// Obtiene las denominaciones que se llenaron en los campos de textos
        /// </summary>
        /// <returns>Un objeto ArrayList con las denominaciones</returns>
        private Dictionary<double, decimal> obtenerDenominacionesColones()
        {
            _numeros_colones.Clear();
            decimal valor = 0;
            Dictionary<double, decimal> denominaciones_colones = new Dictionary<double, decimal>();


            if (Convert.ToDecimal(txt50000colonesmut.Text) > 0)
            {
                denominaciones_colones.Add(50000, Convert.ToDecimal(txt50000colonesmut.Text));
                valor = 50000;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt20000colonesmut.Text) > 0)
            {
                denominaciones_colones.Add(20000, Convert.ToDecimal(txt20000colonesmut.Text));
                valor = 20000;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt10000colonesmut.Text) > 0)
            {
                denominaciones_colones.Add(10000, Convert.ToDecimal(txt10000colonesmut.Text));
                valor = 10000;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt5000colonesmut.Text) > 0)
            {
                denominaciones_colones.Add(5000, Convert.ToDecimal(txt5000colonesmut.Text));
                valor = 5000;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt2000colonesmut.Text) > 0)
            {
                denominaciones_colones.Add(2000, Convert.ToDecimal(txt2000colonesmut.Text));
                valor = 2000;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt1000colonesmut.Text) > 0)
            {
                denominaciones_colones.Add(1000, Convert.ToDecimal(txt1000colonesmut.Text));
                valor = 1000;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt500colonesmut.Text) > 0)
            {
                denominaciones_colones.Add(500, Convert.ToDecimal(txt500colonesmut.Text));
                valor = 500;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt100colonesmut.Text) > 0)
            {
                denominaciones_colones.Add(100, Convert.ToDecimal(txt100colonesmut.Text));
                valor = 100;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt50colonesmut.Text) > 0)
            {
                denominaciones_colones.Add(50, Convert.ToDecimal(txt50colonesmut.Text));
                valor = 50;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt25colonesmut.Text) > 0)
            {

                denominaciones_colones.Add(25, Convert.ToDecimal(txt25colonesmut.Text));
                valor = 25;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt10colonesmut.Text) > 0)
            {
                denominaciones_colones.Add(10, Convert.ToDecimal(txt10colonesmut.Text));
                valor = 10;
                _numeros_colones.Add(valor);
            }
            if (Convert.ToDecimal(txt5colonesmut.Text) > 0)
            {
                denominaciones_colones.Add(5, Convert.ToDecimal(txt5colonesmut.Text));
                valor = 5;
                _numeros_colones.Add(valor);
            }

            return denominaciones_colones;
        }


        /// <summary>
        /// Obtiene las denominaciones que se llenaron en los campos de textos de dolares
        /// </summary>
        /// <returns>Un objeto ArrayList con las denominaciones</returns>
        private Dictionary<double, decimal> obtenerDenominacionesDolares()
        {
            _numeros_dolares.Clear();
            decimal valor = 0;
            Dictionary<double, decimal> denominaciones_dolares = new Dictionary<double, decimal>();

            if (Convert.ToDecimal(txt100dolaresmut.Text) > 0)
            {
                denominaciones_dolares.Add(100, Convert.ToDecimal(txt100dolaresmut.Text));
                valor = 100;
                _numeros_dolares.Add(valor);
            }
            if (Convert.ToDecimal(txt50dolaresmut.Text) > 0)
            {
                denominaciones_dolares.Add(50, Convert.ToDecimal(txt50dolaresmut.Text));
                valor = 50;
                _numeros_dolares.Add(valor);
            }
            if (Convert.ToDecimal(txt20dolaresmut.Text) > 0)
            {
                denominaciones_dolares.Add(20, Convert.ToDecimal(txt20dolaresmut.Text));
                valor = 20;
                _numeros_dolares.Add(valor);
            }
            if (Convert.ToDecimal(txt10dolaresmut.Text) > 0)
            {
                denominaciones_dolares.Add(10, Convert.ToDecimal(txt10dolaresmut.Text));
                valor = 10;
                _numeros_dolares.Add(valor);
            }
            if (Convert.ToDecimal(txt5dolaresmut.Text) > 0)
            {
                denominaciones_dolares.Add(5, Convert.ToDecimal(txt5dolaresmut.Text));
                valor = 5;
                _numeros_dolares.Add(valor);

            }

            if (Convert.ToDecimal(txt2dolaresmut.Text) > 0)
            {
                denominaciones_dolares.Add(1, Convert.ToDecimal(txt2dolaresmut.Text));
                valor = 1;
                _numeros_dolares.Add(valor);

            }

            if (Convert.ToDecimal(txt1dolaresmut.Text) > 0)
            {
                denominaciones_dolares.Add(1, Convert.ToDecimal(txt1dolaresmut.Text));
                valor = 1;
                _numeros_dolares.Add(valor);

            }

            return denominaciones_dolares;
        }


        /// <summary>
        /// Obtiene las denominaciones que se llenaron en los campos de textos de euros
        /// </summary>
        /// <returns>Un objeto ArrayList con las denominaciones</returns>
        private Dictionary<double, decimal> obtenerDenominacionesEuros()
        {
            _numeros_euros.Clear();
            decimal valor = 0;
            Dictionary<double, decimal> denominaciones_euros = new Dictionary<double, decimal>();

            if (Convert.ToDecimal(txt500eurosmut.Text) > 0)
            {
                denominaciones_euros.Add(500, Convert.ToDecimal(txt500eurosmut.Text));
                valor = 500;
                _numeros_euros.Add(valor);
            }
            if (Convert.ToDecimal(txt200eurosmut.Text) > 0)
            {
                denominaciones_euros.Add(200, Convert.ToDecimal(txt200eurosmut.Text));
                valor = 200;
                _numeros_euros.Add(valor);
            }
            if (Convert.ToDecimal(txt100eurosmut.Text) > 0)
            {
                denominaciones_euros.Add(100, Convert.ToDecimal(txt100eurosmut.Text));
                valor = 100;
                _numeros_euros.Add(valor);
            }
            if (Convert.ToDecimal(txt50eurosmut.Text) > 0)
            {
                denominaciones_euros.Add(50, Convert.ToDecimal(txt50eurosmut.Text));
                valor = 50;
                _numeros_euros.Add(valor);
            }
            if (Convert.ToDecimal(txt20eurosmut.Text) > 0)
            {
                denominaciones_euros.Add(20, Convert.ToDecimal(txt20eurosmut.Text));
                valor = 20;
                _numeros_euros.Add(valor);
            }
            if (Convert.ToDecimal(txt10eurosmut.Text) > 0)
            {
                denominaciones_euros.Add(10, Convert.ToDecimal(txt10eurosmut.Text));
                valor = 10;
                _numeros_euros.Add(valor);
            }
            if (Convert.ToDecimal(txt5eurosmut.Text) > 0)
            {
                denominaciones_euros.Add(5, Convert.ToDecimal(txt5eurosmut.Text));
                valor = 5;
                _numeros_euros.Add(valor);
            }

            return denominaciones_euros;
        }

        /// <summary>
        /// Valida si alguno de los campos de los montos tiene algun error
        /// </summary>
        /// <returns>Retorna si existe algun error o no en un bool</returns>
        private bool ValidaErroneos()
        {
            bool variable = true;

            if (aux50000colones == false || aux20000colones == false || aux10000colones == false || aux5000colones == false || aux2000colones == false || aux1000colones == false || aux500colones == false
            || aux100colones == false || aux50colones == false || aux25colones == false || aux10colones == false || aux5colones == false ||
            aux100dolares == false || aux50dolares == false || aux20dolares == false || aux10dolares == false || aux5dolares == false || aux2dolares == false || aux1dolares == false || aux500euros == false ||
            aux200euros == false || aux100euros == false || aux50euros == false || aux20euros == false || aux10euros == false || aux5euros == false)
            {
                variable = false;
            }

            return variable;
        }
        
        private bool ValidarCampos()
        {
            bool bStatus = true;

            if (cboSucursal.Text == "")
            {
                epError.SetError(cboSucursal, "Debe ingresar una Sucursal ");
                bStatus = false;
            }
            else
                epError.SetError(cboSucursal, "");

            //if (cboTransportadora.Text == "")
            // {
            //     epError.SetError(cboTransportadora, "Debe ingresar una Transportadora ");
            //    bStatus = false;
            //}
            //else
            //    epError.SetError(cboTransportadora, "");

            if ( cbSerietula.Text == "")
            {
                epError.SetError(cbSerietula, "Debe ingresar la serie de la tula ");
                bStatus = false;
            }
            else
                epError.SetError(cbSerietula, "");

            if (chkColones.Checked == false && chkDolares.Checked == false && chkEuros.Checked == false)
            {
                epError.SetError(gpbMonedas, "El pedido debe estar en alguna moneda");
                bStatus = false;
            }
            else
                epError.SetError(gpbMonedas, "");
            return bStatus;

            if (cboTransportadora.Text == "")
            {
                epError.SetError(cboTransportadora, "Debe ingresar una Transportadora ");
                bStatus = false;
            }
            else
                epError.SetError(cboTransportadora, "");
        
        }


        /// <summary>
        /// Calcula el monto total en billetes de euros
        /// </summary>
        private void CalcularMontoBilletesEuros()
        {
           
            txtTotalEurosMutilados.Text = (Convert.ToDecimal(txt500eurosmut.Text) + Convert.ToDecimal(txt200eurosmut.Text) + Convert.ToDecimal(txt100eurosmut.Text) +
                Convert.ToDecimal(txt50eurosmut.Text) + Convert.ToDecimal(txt20eurosmut.Text) + Convert.ToDecimal(txt10eurosmut.Text) +
                Convert.ToDecimal(txt20eurosmut.Text)).ToString("N2");

            //txtMontoBilleteEuros.Text = _total_euros.ToString("C", CultureInfo.CreateSpecificCulture("fr-FR"));

        }


        /// <summary>
        /// Calcula el monto total en billetes de dolares
        /// </summary>
        private void CalcularMontoBilletesDolares()
        {
            //_total_dolares = 0;

            txtTotalDolaresMutilados.Text = (Convert.ToDecimal(txt100dolaresmut.Text) + Convert.ToDecimal(txt50dolaresmut.Text) + Convert.ToDecimal(txt20dolaresmut.Text) +
                Convert.ToDecimal(txt10dolaresmut.Text) + Convert.ToDecimal(txt5dolaresmut.Text) + Convert.ToDecimal(txt2dolaresmut.Text) + Convert.ToDecimal(txt1dolaresmut.Text)).ToString("N2");

            //txtMontoBilletesDolares.Text = _total_dolares.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));


        }


        /// <summary>
        /// Calcula el monto total en billetes de colones
        /// </summary>
        private void CalcularMontoBilletesColones()
        {
            try
            {
                decimal montobillete = 0;

                montobillete = Convert.ToDecimal(txt50000colonesmut.Text) + Convert.ToDecimal(txt20000colonesmut.Text) + Convert.ToDecimal(txt10000colonesmut.Text) +
                 Convert.ToDecimal(txt5000colonesmut.Text) + Convert.ToDecimal(txt2000colonesmut.Text) + Convert.ToDecimal(txt1000colonesmut.Text);

                txtTotalColonesMutilado.Text = montobillete.ToString("N2");
                 
                _total_colones = montobillete + Convert.ToDecimal(txtTotalMoneda.Text);
                 
                txtMontoGeneral.Text = _total_colones.ToString("N2");

                //= _total_colones.ToString("C", CultureInfo.CreateSpecificCulture("es-CR"));

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }
/// <summary>
        /// Calcula el monto de las monedas en colones
        /// </summary>
        private void CalcularMontoMonedas()
        {
            try
            {
                decimal montomoneda = 0;
                 montomoneda = Convert.ToDecimal(txt500colonesmut.Text) + Convert.ToDecimal(txt100colonesmut.Text) + Convert.ToDecimal(txt50colonesmut.Text) +
                 Convert.ToDecimal(txt10colonesmut.Text) + Convert.ToDecimal(txt25colonesmut.Text) + Convert.ToDecimal(txt5colonesmut.Text);

                 txtTotalMoneda.Text = montomoneda.ToString("N2");
                
                _total_colones = montomoneda + Convert.ToDecimal(txtTotalColonesMutilado.Text);
                
                txtMontoGeneral.Text = _total_colones.ToString("N2");

               

                // = _total_colones.ToString("C", CultureInfo.CreateSpecificCulture("es-CR"));
  
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


         /// <summary>
        /// Habilita los campos de la denominacion de colones
        /// </summary>
        private void HabilitarCamposBilletesColones()
        {
            this.gbbilletemutiladocolones.Enabled = true;
            txtTotalColonesMutilado.Enabled = true;
            txtMontoGeneral.Enabled = true;

        }

         /// <summary>
        /// Habilita los campos de las denominaciones de niquel colones
        /// </summary>
        private void HabilitarCamposNiquel()
        {
            this.gbmonedamutilada.Enabled = true;
            txtTotalMoneda.Enabled = true;
            txtMontoGeneral.Enabled = true;
        }

         /// <summary>
        /// Habilita los campos de la denominacion de dolares
        /// </summary>
        private void HabilitarCamposDolares()
        {
            this.gbbilletemutiladodolares.Enabled = true;
            txtTotalDolaresMutilados.Enabled = true;
            
        }

         /// <summary>
        /// Habilita los campos de la denominacion de euros
        /// </summary>
        private void HabilitarCamposEuros()
        {
            this.gbbilletemutiladoEuros.Enabled = true;
            txtTotalEurosMutilados.Enabled = true;
        }

        /// <summary>
        /// Inhabilita los campos de colones
        /// </summary>
        private void DesHabiitarCamposBilletesColones()
        {
            this.gbbilletemutiladocolones.Enabled = false;
            txtTotalColonesMutilado.Enabled = false;
            this.LimpiarCamposColones();
        }

        /// <summary>
        /// Inhabilita los campos de niquel
        /// </summary>
        private void DesHabilitarCamposNiquel()
       {
            this.gbmonedamutilada.Enabled = false;
            txtTotalMoneda.Enabled = false;
            
            this.LimpiarCamposNiquel(); 
        }


        /// <summary>
        /// Inhabilita los campos en dolares
        /// </summary>
        private void DesHabilitarCamposDolares()
        {
            this.gbbilletemutiladodolares.Enabled = false;
            txtTotalDolaresMutilados.Enabled = false;
            this.LimpiarCamposDolares();
        }


        /// <summary>
        /// Inhabilita los campos de Euros
        /// </summary>
        private void DesHabiitarCamposEuros()
        {
            this.gbbilletemutiladoEuros.Enabled = false;
            txtTotalEurosMutilados.Enabled = false;
            this.LimpiarCamposEuros();
        }

        /// <summary>
        /// Limpia los datos de Colones
        /// </summary>
        private void LimpiarCamposColones()
        {
            try
            {
                this.txt50000colonesmut.Text = "0";
                this.txt20000colonesmut.Text = "0";
                this.txt10000colonesmut.Text = "0";
                this.txt5000colonesmut.Text = "0";
                this.txt2000colonesmut.Text = "0";
                this.txt1000colonesmut.Text = "0";
                this.txtTotalColonesMutilado.Text = "0";

            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Limpia los datos de Niquel
        /// </summary>
        private void LimpiarCamposNiquel()
        {
            try
            {
                this.txt500colonesmut.Text = "0";
                this.txt100colonesmut.Text = "0";
                this.txt50colonesmut.Text = "0";
                this.txt25colonesmut.Text = "0";
                this.txt10colonesmut.Text = "0";
                this.txtTotalMoneda.Text ="0";
             }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }

        /// <summary>
        /// Limpia los datos de Dolares
        /// </summary>
        private void LimpiarCamposDolares()
        {
            try
            {
                this.txt100dolaresmut.Text = "0";
                this.txt50dolaresmut.Text = "0";
                this.txt20dolaresmut.Text = "0";
                this.txt10dolaresmut.Text = "0";
                this.txt5dolaresmut.Text = "0";
                this.txt1dolaresmut.Text = "0";
                this.txtTotalDolaresMutilados.Text = "0";
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        }


        /// <summary>
        /// Limpia los datos de Euros
        /// </summary>
        private void LimpiarCamposEuros()
        {
            try
            {
                this.txt500eurosmut.Text = "0";
                this.txt200eurosmut.Text = "0";
                this.txt100eurosmut.Text = "0";
                this.txt50eurosmut.Text = "0";
                this.txt20eurosmut.Text = "0";
                this.txt10eurosmut.Text = "0";
                this.txt5eurosmut.Text = "0";
                this.txtTotalEurosMutilados.Text = "0";
            }
            catch (Excepcion ex)
            {
                ex.mostrarMensaje();
            }
        

        
        }


        /// <summary>
        /// Verifica si un monto se puede aceptar debido a la denominacion correspondiente
        /// </summary>
        /// <param name="monto">Monto digitado</param>
        /// <param name="denominacion">Denominacion correspondiente del pedido</param>
        /// <param name="t">Objeto Textbox donde se encuentra el monto</param>
        /// <returns></returns>
        private bool ValidarMontos(Decimal monto,Decimal denominacion, TextBox t, ref bool aux)
        {
            bool bStatus = true;

                if (monto  % denominacion != 0)
                {
                    epError.SetError(t, "No se puede ingresar ese monto");
                    bStatus = false;
                }
                else
                    epError.SetError(t, "");

              
            aux = bStatus;
           
            return bStatus;
        }
       #endregion Métodos Privados

       
        private void txt50000colonesmut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                }
        }

        private void gbgeneral_Enter(object sender, EventArgs e)
        {

        }

        private void gbbilletemutiladocolones_Enter(object sender, EventArgs e)
        {

        }

        private void gbmonedamutilada_Enter(object sender, EventArgs e)
        {

        }

















    }
}



    