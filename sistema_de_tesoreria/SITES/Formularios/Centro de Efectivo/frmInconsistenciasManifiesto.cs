using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonObjects;
using BussinessLayer;
using LibreriaMensajes;
using GUILayer.Formularios.Centro_de_Efectivo;
using CommonObjects.Clases;
using LibreriaReportesOffice;

namespace GUILayer.Formularios.Centro_de_Efectivo
{
    public partial class frmInconsistenciasManifiesto : Form
    {

        #region Atributos

        private AtencionBL _atencion = AtencionBL.Instancia;
        private Colaborador _usuario = null;
        DataTable datos = new DataTable();

        #endregion Atributos

        public frmInconsistenciasManifiesto(Colaborador colaborador)
        {
            InitializeComponent();
            _usuario = colaborador;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            datos = _atencion.ObtenerInfoFormularioInconsistenciasManifiesto(_usuario);
            int conteoregistros = 0;
            //int CantExcel = datos.Rows.Count / 11;
            if (datos.Rows.Count > 0)
            {
                while (conteoregistros < datos.Rows.Count)
                {
                    conteoregistros = imprimirBoletaEntregaNiquel(conteoregistros);
                }                
                _atencion.CerrarInfoFormularioInconsistenciasManifiesto(datos);
                MessageBox.Show("Fin de proceso de impresión de inconsistencias por manifiesto con diferencia mayor a 1000 colones o su equivalente");
            }
            else
            {
                MessageBox.Show("No hay inconsistencias por manifiesto para generar el formulario respectivo.");
            }

        }

        private int imprimirBoletaEntregaNiquel(int reg)
        {

            try
            {
                DocumentoExcel documento = new DocumentoExcel(Application.StartupPath + "\\Plantillas\\Planillas Inconsistencias clientes_manifiesto.xlsx", false);
                DateTime fecha = Convert.ToDateTime(datos.Rows[0]["Fecha_Inconsistencia"]);
                int registrosimpresion = 0;
                int procesoregistros = 0;
                string Cajero = datos.Rows[0]["Cajero"].ToString();
                DateTime thisDay = DateTime.Today;

                documento.seleccionarHoja(1);

                documento.seleccionarCelda("B5");
                documento.actualizarValorCelda("Fecha: " + thisDay.ToShortDateString());

                documento.seleccionarCelda("B6");
                documento.actualizarValorCelda(Cajero);


                for (int i = reg; i < datos.Rows.Count; i++)
                {
                    if ((Convert.ToInt32(datos.Rows[i]["Monto_Diferencia"]) <= -1000) || (Convert.ToInt32(datos.Rows[i]["Monto_Diferencia"]) >= 1000))
                    {
                        DateTime hora = Convert.ToDateTime(datos.Rows[i]["Fecha_Inconsistencia"]);
                        documento.seleccionarCelda("B" + Convert.ToString(registrosimpresion + 10));
                        documento.actualizarValorCelda(datos.Rows[i]["Cliente"]);

                        documento.seleccionarCelda("C" + Convert.ToString(registrosimpresion + 10));
                        documento.actualizarValorCelda(datos.Rows[i]["Manifiesto"]);

                        if (Convert.ToByte(datos.Rows[i]["Tipo_Diferencia"]) == 1)
                        {
                            documento.seleccionarCelda("H" + Convert.ToString(registrosimpresion + 10));
                        }
                        else
                        {
                            documento.seleccionarCelda("G" + Convert.ToString(registrosimpresion + 10));
                        }

                        documento.actualizarValorCelda(datos.Rows[i]["Monto_Diferencia"]);

                        documento.seleccionarCelda("I" + Convert.ToString(registrosimpresion + 10));
                        documento.actualizarValorCelda(datos.Rows[i]["Monto_Declarado"]);
                        documento.seleccionarCelda("J" + Convert.ToString(registrosimpresion + 10));
                        documento.actualizarValorCelda(datos.Rows[i]["Monto_Recibido"]);
                        documento.seleccionarCelda("K" + Convert.ToString(registrosimpresion + 10));
                        documento.actualizarValorCelda(hora.ToShortTimeString());
                        documento.seleccionarCelda("L" + Convert.ToString(registrosimpresion + 10));
                        documento.actualizarValorCelda(datos.Rows[i]["Detalle"]);
                        registrosimpresion += 1;
                    }                    
                 
                    if (registrosimpresion == 11)
                    {
                        break;
                    }
                    procesoregistros = i;
                }

                // Mostrar el archivo

                documento.mostrar();
                documento.cerrar();
                return (procesoregistros + 1);
            }
            catch (Exception ex)
            {

                Excepcion.mostrarMensaje(ex.Message);
                return reg;
            }

        }
    }
}
