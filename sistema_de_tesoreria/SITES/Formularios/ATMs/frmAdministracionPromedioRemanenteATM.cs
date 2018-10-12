using BussinessLayer;
using CommonObjects.Clases;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUILayer.Formularios.ATMs
{
    public partial class frmAdministracionPromedioRemanenteATM : Form
    {
        #region Atributos

        private MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;
        private string _archivo = string.Empty;
        private BindingList<PromedioRemanenteATM> _promedios = new BindingList<PromedioRemanenteATM>();
        private PromedioRemanenteATM _nivel = null;

        #endregion Atributos

        #region Constructor

        public frmAdministracionPromedioRemanenteATM()
        {
            InitializeComponent();

            _nivel = _mantenimiento.listarPromedioRemanenteATM();

            if (_nivel != null)
            {
                nudMonto.Value = _nivel.Monto;
                nudMontoQuincena.Value = _nivel.MontoQuincena;
                nudMontoDolares.Value = _nivel.MontoDolares;
                nudMontoDolaresQuincena.Value = _nivel.MontoQuincenaDolares;
            }

  
        }

        public frmAdministracionPromedioRemanenteATM(PromedioRemanenteATM promedio)
        {
            InitializeComponent();

           
          
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Clic en el botón de guardar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan seleccionado los datos



            try
            {
                

                decimal promedio = (decimal)nudMonto.Value;
                decimal promedio_quincea = (decimal)nudMontoQuincena.Value;
                decimal promedio_dolares = (decimal)nudMontoDolares.Value;
                decimal promedio_quincena_dolares = (decimal)nudMontoDolaresQuincena.Value;
                
                // Verificar si la nivel ya está registrada

                if (_nivel.ID == 0)
                {
                    // Agregar la nivel

                    if (Mensaje.mostrarMensajeConfirmacion("MensajePromedioRemanenteATMRegistro") == DialogResult.Yes)
                    {
                        PromedioRemanenteATM nueva = new PromedioRemanenteATM(monto: promedio, montoquincena:promedio_quincea, montodolares: promedio_dolares, montodolaresq: promedio_quincena_dolares);

                        _mantenimiento.agregarRemanenteDescargaATM (ref nueva);
                        
                        Mensaje.mostrarMensaje("MensajePromedioRemanenteATMConfirmacionRegistro");
                        this.Close();
                    }

                }
                else
                {
                    // Actualizar los datos de la nivel

                    PromedioRemanenteATM copia = new PromedioRemanenteATM(monto: promedio, id: _nivel.ID, montoquincena: promedio_quincea, montodolares: promedio_dolares, montodolaresq: promedio_quincena_dolares);

                    _mantenimiento.actualizarRemanenteATM(copia);

                    Mensaje.mostrarMensaje("MensajePromedioRemanenteATMConfirmacionActualizacion");
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

        #region Metodos Privados

      



        #endregion Metodos Privados
    }
}
