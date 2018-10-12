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
using CommonObjects.Clases;
using LibreriaMensajes;

namespace GUILayer.Formularios.ATMs
{
    public partial class frmMantenimientoInventarios : Form
    {
        #region Atributos

        private Colaborador _usuario = new Colaborador();
        MantenimientoBL _mantenimiento = MantenimientoBL.Instancia;

        private Inventario _rechazo = new Inventario();
        private Inventario _ENA = new Inventario();
        private Inventario _dispensador = new Inventario();

        private BindingList<Inventario> lista = new BindingList<Inventario>();

        #endregion Atributos
        
        #region Constructor
        public frmMantenimientoInventarios(Colaborador usuario)
        {
            _usuario = usuario;
            InitializeComponent();

            lista = _mantenimiento.listarInventarioCartuchos();
            Cargar();
        }

        #endregion Constructor
        
        #region Eventos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
          
                try
                {
                    if (validarCamposRec() == " ")
                        GuardarRechazo();
                    if (validarCamposENA() == " ")
                        GuardarENA();
                    if (validarCamposDisp() == " ")
                        GuardarDispensador();

                    Mensaje.mostrarMensaje("MensajeInventariosConfirmacion");
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                    

        }

        private void nudPerMaximoDisp_ValueChanged(object sender, EventArgs e)
        {
            int seguridad = ((int)nudPerMaximoDisp.Value - (int)nudPerEntregaDisp.Value) * (int)nudDemandaDisp.Value;
            nudStockDisp.Value = seguridad;
        }

        private void nudPerEntregaDisp_ValueChanged(object sender, EventArgs e)
        {
            int seguridad = ((int)nudPerMaximoDisp.Value - (int)nudPerEntregaDisp.Value) * (int)nudDemandaDisp.Value;
            nudStockDisp.Value = seguridad;
        }

        private void nudDemandaDisp_ValueChanged(object sender, EventArgs e)
        {
            int seguridad = ((int)nudPerMaximoDisp.Value - (int)nudPerEntregaDisp.Value) *(int)nudDemandaDisp.Value;
            nudStockDisp.Value = seguridad;
        }
 
        private void nudCantATMDisp_ValueChanged(object sender, EventArgs e)
        {
            int reorden = (int)nudCantATMDisp.Value * (int)nudCantCartuchosDisp.Value;
            nudReordenDisp.Value = reorden;
        } 
        
        private void nudCantCartuchosDisp_ValueChanged(object sender, EventArgs e)
        {
            int reorden = (int)nudCantATMDisp.Value * (int)nudCantCartuchosDisp.Value;
            nudReordenDisp.Value = reorden;
        }

        private void nudPerMaximoENA_ValueChanged(object sender, EventArgs e)
        {
            int seguridad = (int)nudPerMaximoENA.Value * (int)nudPerEntregaENA.Value * (int)nudDemandaENA.Value;
            nudStockENA.Value = seguridad;
        }

        private void nudPerEntregaENA_ValueChanged(object sender, EventArgs e)
        {
            int seguridad = (int)nudPerMaximoENA.Value * (int)nudPerEntregaENA.Value * (int)nudDemandaENA.Value;
            nudStockENA.Value = seguridad;
        }

        private void nudDemandaENA_ValueChanged(object sender, EventArgs e)
        {
            int seguridad = (int)nudPerMaximoENA.Value * (int)nudPerEntregaENA.Value * (int)nudDemandaENA.Value;
            nudStockENA.Value = seguridad;
        }

        private void nudCantATMENA_ValueChanged(object sender, EventArgs e)
        {
            int reorden = (int)nudCantCartuchosENA.Value * (int)nudCantATMENA.Value;
            nudReordenENA.Value = reorden;
        }

        private void nudCantCartuchosENA_ValueChanged(object sender, EventArgs e)
        {
            int reorden = (int)nudCantCartuchosENA.Value * (int)nudCantATMENA.Value;
            nudReordenENA.Value = reorden;
        }

        private void nudCantATMRec_ValueChanged(object sender, EventArgs e)
        {
            int reorden = (int)nudCantCartuchosRec.Value * (int)nudCantATMRec.Value;
            nudReordenRec.Value = reorden;
        }

        private void nudCantCartuchosRec_ValueChanged(object sender, EventArgs e)
        {
            int reorden = (int)nudCantCartuchosRec.Value * (int)nudCantATMRec.Value;
            nudReordenRec.Value = reorden;
        }

        private void nudPerMaximoRec_ValueChanged(object sender, EventArgs e)
        {
            int seguridad = (int)nudPerMaximoRec.Value * (int)nudPerEntregaRec.Value * (int)nudDemandaRec.Value;
            nudStockRec.Value = seguridad;
        }

        private void nudPerEntregaRec_ValueChanged(object sender, EventArgs e)
        {
            int seguridad = (int)nudPerMaximoRec.Value * (int)nudPerEntregaRec.Value * (int)nudDemandaRec.Value;
            nudStockRec.Value = seguridad;
        }

        private void nudDemandaRec_ValueChanged(object sender, EventArgs e)
        {
            int seguridad = (int)nudPerMaximoRec.Value * (int)nudPerEntregaRec.Value * (int)nudDemandaRec.Value;
            nudStockRec.Value = seguridad;
        }

        #endregion Eventos

        #region Métodos Privados
        private void Cargar()
        {
               foreach (Inventario inv in lista)
                {
                    switch (inv.Tipo)
                    {
                        case TiposCartucho.ENA:
                            CargarENA(inv);
                            _ENA = inv;
                            break;
                        case TiposCartucho.Rechazo:
                            CargarRechazo(inv);
                            _rechazo = inv;
                            break;
                        case TiposCartucho.Dispensador:
                            CargarDispensador(inv);
                            _dispensador = inv;
                            break;
                        default:
                            break;
                    }
                }
        }

        private void CargarENA(Inventario inv)
        {
            nudInvInicialENA.Value = inv.Inicial;
            nudInvIngresoENA.Value = inv.Ingreso;
            nudInvTotalENA.Value = inv.Total;
            nudCantPedidoENA.Value = inv.Pedido;
            nudReordenENA.Value = inv.Reorden;
            nudStockENA.Value = inv.Stock;
            nudCantATMENA.Value = inv.CantATM;
            nudCantCartuchosENA.Value = inv.CantCartuchos;
            nudPerMaximoENA.Value = inv.PeriodoMaximo;
            nudPerEntregaENA.Value = inv.PeriodoEntrega;
            nudDemandaENA.Value = inv.Demanda;
        }

        private void CargarRechazo(Inventario inv)
        {
            nudInvInicialRec.Value = inv.Inicial;
            nudInvIngresoRec.Value = inv.Ingreso;
            nudInvTotalRec.Value = inv.Total;
            nudCantPedidoRec.Value = inv.Pedido;
            nudReordenRec.Value = inv.Reorden;
            nudStockRec.Value = inv.Stock;
            nudCantATMRec.Value = inv.CantATM;
            nudCantCartuchosRec.Value = inv.CantCartuchos;
            nudPerMaximoRec.Value = inv.PeriodoMaximo;
            nudPerEntregaRec.Value = inv.PeriodoEntrega;
            nudDemandaRec.Value = inv.Demanda;
        }

        private void CargarDispensador(Inventario inv)
        {
            nudInvInicialDisp.Value = inv.Inicial;
            nudInvIngresoDisp.Value = inv.Ingreso;
            nudInvTotalDisp.Value = inv.Total;
            nudCantPedidoDisp.Value = inv.Pedido;
            nudReordenDisp.Value = inv.Reorden;
            nudStockDisp.Value = inv.Stock;
            nudCantATMDisp.Value = inv.CantATM;
            nudCantCartuchosDisp.Value = inv.CantCartuchos;
            nudPerMaximoDisp.Value = inv.PeriodoMaximo;
            nudPerEntregaDisp.Value = inv.PeriodoEntrega;
            nudDemandaDisp.Value = inv.Demanda;
        }

        private string validarCamposENA()
        {
            string mensaje = " ";

            if (nudInvInicialENA.Value == 0) mensaje = mensaje +" Inventario Inicial ENA  \n"  ;
           // if (nudInvIngresoENA.Value == 0) mensaje = mensaje +" Ingreso de Inventario ENA  \n";
            if (nudInvTotalENA.Value == 0) mensaje = mensaje +" Inventario Total ENA  \n";
            if (nudCantPedidoENA.Value == 0) mensaje = mensaje +" Cantidad de Pedido ENA  \n";
            if (nudReordenENA.Value == 0) mensaje = mensaje + " Punto de Reorden ENA  \n";
            if (nudStockENA.Value == 0) mensaje = mensaje + " Stock de Seguridad ENA  \n";
            if (nudCantATMENA.Value == 0) mensaje = mensaje + " Cantidad de ATMs ENA  \n";
            if (nudCantCartuchosENA.Value == 0) mensaje = mensaje + " Cantidad de Cartuchos ENA  \n";
            if (nudPerMaximoENA.Value == 0) mensaje = mensaje + " Periodo Maximo ENA  \n";
            if (nudPerEntregaENA.Value == 0) mensaje = mensaje + " Periodo Entrega ENA  \n";
            if (nudDemandaENA.Value == 0) mensaje = mensaje + " Demanda ENA \n";

            return mensaje;
           
            //if (mensaje == "Debe Corregir los siguientes campos: \n")
            //    return true;
            //else
            //{
            //    MessageBox.Show(mensaje,"BAC CREDOMATIC");
            //    return false;
            //}
        }

        private string validarCamposRec()
        {
            string mensaje = " ";

            if (nudInvInicialRec.Value == 0) mensaje = mensaje + " Inventario Inicial Rechazo  \n";
            //if (nudInvIngresoRec.Value == 0) mensaje = mensaje + " Ingreso de Inventario Rechazo  \n";
            if (nudInvTotalRec.Value == 0) mensaje = mensaje + " Inventario Total Rechazo  \n";
            if (nudCantPedidoRec.Value == 0) mensaje = mensaje + " Cantidad de Pedido Rechazo  \n";
            if (nudReordenRec.Value == 0) mensaje = mensaje + " Punto de Reorden Rechazo  \n";
            if (nudStockRec.Value == 0) mensaje = mensaje + " Stock de Seguridad Rechazo  \n";
            if (nudCantATMRec.Value == 0) mensaje = mensaje + " Cantidad de ATMs Rechazo  \n";
            if (nudCantCartuchosRec.Value == 0) mensaje = mensaje + " Cantidad de Cartuchos Rechazo  \n";
            if (nudPerMaximoRec.Value == 0) mensaje = mensaje + " Periodo Maximo Rechazo  \n";
            if (nudPerEntregaRec.Value == 0) mensaje = mensaje + " Periodo Entrega Rechazo  \n";
            if (nudDemandaRec.Value == 0) mensaje = mensaje + " Demanda Rechazo \n";

            return mensaje;
            //if (mensaje == "Debe Corregir los siguientes campos: \n")
            //    return true;
            //else
            //{
            //    //MessageBox.Show(mensaje, "BAC CREDOMATIC");
            //    return false;
            //}
        }

        private string validarCamposDisp()
        {
            string mensaje = " ";

            if (nudInvInicialDisp.Value == 0) mensaje = mensaje + " Inventario Inicial Dispensador  \n";
           // if (nudInvIngresoDisp.Value == 0) mensaje = mensaje + " Ingreso de Inventario Dispensador  \n";
            if (nudInvTotalDisp.Value == 0) mensaje = mensaje + " Inventario Total Dispensador  \n";
            if (nudCantPedidoDisp.Value == 0) mensaje = mensaje + " Cantidad de Pedido Dispensador  \n";
            if (nudReordenDisp.Value == 0) mensaje = mensaje + " Punto de Reorden Dispensador  \n";
            if (nudStockDisp.Value == 0) mensaje = mensaje + " Stock de Seguridad Dispensador  \n";
            if (nudCantATMDisp.Value == 0) mensaje = mensaje + " Cantidad de ATMs Dispensador  \n";
            if (nudCantCartuchosDisp.Value == 0) mensaje = mensaje + " Cantidad de Cartuchos Dispensador  \n";
            if (nudPerMaximoDisp.Value == 0) mensaje = mensaje + " Periodo Maximo Dispensador  \n";
            if (nudPerEntregaDisp.Value == 0) mensaje = mensaje + " Periodo Entrega Dispensador  \n";
            if (nudDemandaDisp.Value == 0) mensaje = mensaje + " Demanda Dispensador \n";

            return mensaje;
            //if (mensaje == "Debe Corregir los siguientes campos: \n")
            //    return true;
            //else
            //{
            //    MessageBox.Show(mensaje, "BAC CREDOMATIC");
            //    return false;
            //}
        }

        private void GuardarRechazo()
        {
            try
            {
                Inventario rec = new Inventario();
                rec.Inicial = (int)nudInvInicialRec.Value;
                rec.Ingreso = (int)nudInvIngresoRec.Value;
                rec.Total = (int)nudInvTotalRec.Value;
                rec.Pedido = (int)nudCantPedidoRec.Value;
                rec.Reorden = (int)nudReordenRec.Value;
                rec.Stock = (int)nudStockRec.Value;

                rec.CantATM = (int)nudCantATMRec.Value;
                rec.CantCartuchos = (int)nudCantCartuchosRec.Value;

                rec.PeriodoMaximo = (int)nudPerMaximoRec.Value;
                rec.PeriodoEntrega = (int)nudPerEntregaRec.Value;
                rec.Demanda = (int)nudDemandaRec.Value;
                rec.Tipo = TiposCartucho.Rechazo;

                //if (_rechazo.ID != 0)
                //{
                //  //  if (_rechazo != rec)
                //    _mantenimiento.actualizarInventarioCartucho(_rechazo, _usuario);
                //}
                //else
                if(!Comparacion(rec,_rechazo))
                    _mantenimiento.agregarInventarioCartucho(rec, _usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

        private void GuardarENA()
        {
            try
            {
                Inventario ena = new Inventario();

                ena.Inicial = (int)nudInvInicialENA.Value;
                ena.Ingreso = (int)nudInvIngresoENA.Value;
                ena.Total = (int)nudInvTotalENA.Value;
                ena.Pedido = (int)nudCantPedidoENA.Value;
                ena.Reorden = (int)nudReordenENA.Value;
                ena.Stock = (int)nudStockENA.Value;

                ena.CantATM = (int)nudCantATMENA.Value;
                ena.CantCartuchos = (int)nudCantCartuchosENA.Value;

                ena.PeriodoMaximo = (int)nudPerMaximoENA.Value;
                ena.PeriodoEntrega = (int)nudPerEntregaENA.Value;
                ena.Demanda = (int)nudDemandaENA.Value;
                ena.Tipo = TiposCartucho.ENA;


                //if (_ENA.ID != 0)
                //{
                //   // if (_ENA != ena)
                //        _mantenimiento.actualizarInventarioCartucho(_ENA, _usuario);
                //}
                //else
                if (!Comparacion(ena,_ENA))
                    _mantenimiento.agregarInventarioCartucho(ena, _usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private void GuardarDispensador()
        {
            try
            {
                Inventario disp = new Inventario();
                disp.Inicial = (int)nudInvInicialDisp.Value;
                disp.Ingreso = (int)nudInvIngresoDisp.Value;
                disp.Total = (int)nudInvTotalDisp.Value;
                disp.Pedido = (int)nudCantPedidoDisp.Value;
                disp.Reorden = (int)nudReordenDisp.Value;
                disp.Stock = (int)nudStockDisp.Value;

                disp.CantATM = (int)nudCantATMDisp.Value;
                disp.CantCartuchos = (int)nudCantCartuchosDisp.Value;

                disp.PeriodoMaximo = (int)nudPerMaximoDisp.Value;
                disp.PeriodoEntrega = (int)nudPerEntregaDisp.Value;
                disp.Demanda = (int)nudDemandaDisp.Value;
                disp.Tipo = TiposCartucho.Dispensador;

                //if (_dispensador.ID != 0)
                //{
                //    //if (_dispensador != disp)
                //     _mantenimiento.actualizarInventarioCartucho(_dispensador, _usuario);
                //}
                //else
                if (!Comparacion(disp,_dispensador))
                    _mantenimiento.agregarInventarioCartucho(disp, _usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private bool Comparacion(Inventario a, Inventario b)
        {
            bool iguales = true;
            if ((a.Inicial != b.Inicial)|| (a.Ingreso != a.Ingreso)||(a.Total != b.Total)
                ||(a.Pedido != b.Pedido)|| (a.Reorden != b.Reorden)|| (a.Stock != b.Stock)
                || (a.CantATM !=b.CantATM)|| (a.CantCartuchos != b.CantCartuchos)||(a.PeriodoMaximo != b.PeriodoMaximo)
                || (a.PeriodoEntrega != b.PeriodoEntrega) || (a.Demanda != b.Demanda) || (a.Tipo != b.Tipo))
                iguales = false;
            return iguales;
            
        }
        #endregion Métodos Privados

       
        

        

        

      
    }
}
