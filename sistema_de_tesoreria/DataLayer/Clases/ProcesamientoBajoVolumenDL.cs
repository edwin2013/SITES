using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.Data.SqlClient;
using CommonObjects.Clases;
using System.Data;
using LibreriaMensajes;
using System.ComponentModel;
using CommonObjects;

namespace DataLayer.Clases
{
    public class ProcesamientoBajoVolumenDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ProcesamientoBajoVolumenDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ProcesamientoBajoVolumenDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ProcesamientoBajoVolumenDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ProcesamientoBajoVolumenDL() { }

        #endregion Constructor

        #region Métodos Públicos
        
        public void actualizarConsultaProaCierreCajero(int iD)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateConsultaProaCierreCajero");
            _manejador.agregarParametro(comando, "@cajero", iD, SqlDbType.Int);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("UpdateConsultaProaCierreCajero");
            }

        }

        public void actualizarConsultaProaCierreCajeroNiquel(int iD)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateConsultaProaCierreCajeroNiquel");
            _manejador.agregarParametro(comando, "@cajero", iD, SqlDbType.Int);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("UpdateConsultaProaCierreCajero");
            }
        }

        public void DeleteInconsistenciaDepositoProa(Deposito _depositoNuevo, int id_colaborador)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteInconsistenciaDepositosProa");
            _manejador.agregarParametro(comando, "@idDep", _depositoNuevo.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@idCol", id_colaborador, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
            }
            catch (Excepcion ex)
            {
                comando.Connection.Close();
                throw new Excepcion("DeleteInconsistenciaDepositosProa." + ex.Message);
            }

        }

        public void eliminaInfoFormularioBoletaNiquelEntregaCajeroNiquel(int iD)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteInfoFormularioBoletaNiquelEntregaCajeroNiquel");
            _manejador.agregarParametro(comando, "@idBajoVolDep", iD, SqlDbType.Int);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception EX)
            {
                comando.Connection.Close();
                throw new Excepcion("UpdateMontoNiquel " + EX.Message);
            }
        }

        public void updateMontoMesa(decimal montoNiquel, Colaborador cajero)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateMontoNiquel");
            _manejador.agregarParametro(comando, "@montoNiquel", montoNiquel, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@idCajero", cajero.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception EX)
            {
                comando.Connection.Close();
                throw new Excepcion("UpdateMontoNiquel " + EX.Message);
            }
        }
        public DataTable procesamientoBVPendiente(int idPBVM)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("ProcesamientoBVPendiente");
            _manejador.agregarParametro(comando, "@idPBVM", idPBVM, SqlDbType.Int);
            SqlDataReader datareader = null;
            DataTable datos = new DataTable();
            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                datos.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion(ex.Message);
            }
            return datos;
        }

        /// <summary>
        /// Registrar una nueva cámara.
        /// </summary>
        /// <param name="c">Objeto Camara con los datos de la nueva cámara</param>
        public void agregarProcesamientoBajoVolumen(ref ProcesamientoBajoVolumen c) //Cambio GZH 10092017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertProcesamientoBajoVolumen");

            _manejador.agregarParametro(comando, "@cajero", c.ColaboradorAsociado.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@camara", c.Camara.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@montoAD", c.MontoAD, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@montoBD", c.MontoBD, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@montoCOL", c.MontoCOL, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@montoDOL", c.MontoDOL, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@montoEUR", c.MontoEUR, SqlDbType.Decimal);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion(ex.Message);
            }

        }

        public void agregarConteoBilleteProcesamientoBajoVolumen(ref ConteoBillete billete)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InserttblInfoConteoBilleteBajoVolumen");

            _manejador.agregarParametro(comando, "@fk_ID_ProcesamientoBajoVolumenDeposito", billete.id_PBV, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@1000CRC", billete.CRC1000, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@2000CRC", billete.CRC2000, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@5000CRC", billete.CRC5000, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@10000CRC", billete.CRC10000, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@20000CRC", billete.CRC20000, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@50000CRC", billete.CRC50000, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@1USD", billete.USD1, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@5USD", billete.USD5, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@10USD", billete.USD10, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@20USD", billete.USD20, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@50USD", billete.USD50, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@100USD", billete.USD100, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@5EUR", billete.EUR5, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@10EUR", billete.EUR10, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@20EUR", billete.EUR20, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@50EUR", billete.EUR50, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@100EUR", billete.EUR100, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@200EUR", billete.EUR200, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@500EUR", billete.EUR500, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Total_Billete", billete.conteototal, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@moneda", (byte)billete.Moneda, SqlDbType.TinyInt);


            try
            {
                billete.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorProcesamientoBajoVolumenRegistro");
            }

        }

        public void agregarPendienteProcesamientoBajoVolumenManifiesto(ref ProcesamientoBajoVolumenManifiesto c, ref Colaborador d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertPendienteProcesamientoBajoVolumenManifiesto");

            _manejador.agregarParametro(comando, "@idmanifiesto", c.ID, SqlDbType.Int);           
            _manejador.agregarParametro(comando, "@idCajero", d.ID, SqlDbType.Int);                                

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);                
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorProcesamientoBajoVolumenRegistro");
            }

        }        

        public void agregarPendienteProcesamientoBajoVolumenTula(ref ProcesamientoBajoVolumenManifiesto c, ref Tula d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertPendienteProcesamientoBajoVolumenTula");

            _manejador.agregarParametro(comando, "@idmanifiesto", c.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@idTula", d.ID, SqlDbType.Int);            

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);                
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorPendienteProcesamientoBajoVolumenTula");
            }

        }

        public void eliminarPendienteProcesamientoBajoVolumenTula(ref Tula d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeletePendienteProcesamientoBajoVolumenTula");
            
            _manejador.agregarParametro(comando, "@idTula", d.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDeletePendienteProcesamientoBajoVolumenTula");
            }

        }

        /// <summary>
        /// Actualizar los datos de un procesamiento de bajo volumen.
        /// </summary>
        /// <param name="c">Objeto ProcesamientoBajoVolumen con los datos del procesamiento a actualizar</param>
        public void actualizarProcesamientoBajoVolumen(ref ProcesamientoBajoVolumen c) //Cambio GZH 11092017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateProcesamientoBajoVolumen");
            
            _manejador.agregarParametro(comando, "@cajero", c.ColaboradorAsociado, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@camara", c.Camara, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@montoAD", c.MontoAD, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@montoBD", c.MontoBD, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@montoCOL", c.MontoCOL, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@montoDOL", c.MontoDOL, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@montoEUR", c.MontoEUR, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@ID_Procesamiento", c.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception ex)
            {                
                comando.Connection.Close();
                throw new Excepcion(ex.Message);
            }

        }

        public void actualizarLimpiarDenominaciones()
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateLimpiarDenominaciones");
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch(Exception EX)
            {
                comando.Connection.Close();
                throw new Exception("UpdateLimpiarDenominaciones"+ EX.Message);
            }
        }
        public void agregarManifiestoProcesamientoBajoVolumenManifiesto(ref ProcesamientoBajoVolumenManifiesto c, Colaborador col)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertProcesamientoBajoVolumenManifiesto");

            _manejador.agregarParametro(comando, "@idmanifiesto", c.IDManifiesto, SqlDbType.Int);            
            _manejador.agregarParametro(comando, "@idcliente", c.Cliente.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@idpuntoventa", c.PuntoVenta.Id, SqlDbType.SmallInt);            
            _manejador.agregarParametro(comando, "@monto_declarado_colones", c.Monto_Colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_declarado_dolares", c.Monto_Dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_declarado_euros", c.Monto_Euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@camara", c.Camara.ID, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cajero", col.ID, SqlDbType.Int);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);                
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("AgregaManifiestoProcesoBajoVolumen");
            }

        }

        public void actualizarManifiestoProcesamientoBajoVolumenManifiesto(ref ProcesamientoBajoVolumenManifiesto c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateProcesamientoBajoVolumenManifiesto2");

            _manejador.agregarParametro(comando, "@id", c.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@idmanifiesto", c.IDManifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@idcliente", c.Cliente.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@idpuntoventa", c.PuntoVenta.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@monto_declarado_colones", c.Monto_Colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_declarado_dolares", c.Monto_Dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_declarado_euros", c.Monto_Euros, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@camara", c.Camara.ID, SqlDbType.TinyInt);            
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("AgregaManifiestoProcesoBajoVolumen");
            }

        }

        public void cerrarManifiestoProcesamientoBajoVolumenManifiesto(ProcesamientoBajoVolumenManifiesto c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateProcesamientoBajoVolumenManifiesto");

            _manejador.agregarParametro(comando, "@id", c.ID, SqlDbType.Int);            
            _manejador.agregarParametro(comando, "@monto_contado_colones", c.Monto_Colones, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_contado_dolares", c.Monto_Dolares, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@monto_contado_euros", c.Monto_Euros, SqlDbType.Money);            

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("cerrarManifiestoProcesoBajoVolumen");
            }

        }

        public int agregarDepositoProcesamientoBajoVolumen(ProcesamientoBajoVolumenManifiesto c, ProcesamientoBajoVolumen d, Tula t, Deposito e, Monedas m, int coordinador)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertProcesamientoBajoVolumenDeposito");
            _manejador.agregarParametro(comando, "@idprocesamiento", d.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@idprocesomanifiesto", c.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@idmanifiesto", c.IDManifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@idTula", t.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@numero_deposito", e.NumeroDeposito, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@Codigo_VD", e.CodigoVD, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@Codigo_Transaccion", e.CodigoTransaccion, SqlDbType.VarChar);            
            _manejador.agregarParametro(comando, "@Cuenta_Referencia", e.CuentaReferencia, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@Cedula", e.Cedula, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@Moneda", (byte)e.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@TipoMesa_Niquel", (int)e.TipomesaNiquel, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Monto_Niquel", e.MontoNiquel, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Monto_Declarado", e.MontoDeclarado, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Monto_Contado", e.Monto, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@diferencia", e.MontoDiferencia, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@coordinador", coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Depositante", e.Depositante, SqlDbType.VarChar);


            try
            {
                e.ID = Convert.ToInt32(_manejador.ejecutarEscalar(comando));                
                comando.Connection.Close();
                return e.ID;
            }
            catch (Excepcion ex)
            {
                comando.Connection.Close();
                //throw new Excepcion("AgregarDepositoProcesoBajoVolumen");
                ex.mostrarMensaje();
                return 0;
            }

        }

        public void agregarInconsistenciaProcesamientoBajoVolumenDeposito(ProcesamientoBajoVolumenManifiesto c, Tula t, Deposito e, Monedas m, byte origendiferencia, DateTime finconsistencia)
        {
            string datosbilletesfalsos = "";
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertPROAInconsistenciasDeposito");
            _manejador.agregarParametro(comando, "@fk_tblProcesamientoBajoVolumenDeposito", e.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fk_ID_Camara", c.Camara.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fk_ID_Manifiesto", c.IDManifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fk_ID_Tula", t.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Cuenta", e.CuentaReferencia, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@numero_deposito", e.NumeroDeposito, SqlDbType.VarChar);
            if (e.MontoDiferencia > 0)
            {
                _manejador.agregarParametro(comando, "@Tipo_Diferencia", 1, SqlDbType.TinyInt);
            }
            else
            {
                _manejador.agregarParametro(comando, "@Tipo_Diferencia", 0, SqlDbType.TinyInt);
            }
            _manejador.agregarParametro(comando, "@Origen_Diferencia", origendiferencia, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@Tipo_Moneda", (byte)e.Moneda, SqlDbType.TinyInt);                        
            _manejador.agregarParametro(comando, "@Monto_Diferencia", e.MontoDiferencia, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@Monto_Declarado", e.MontoDeclarado, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Monto_Recibido", e.Monto, SqlDbType.Money);            
            _manejador.agregarParametro(comando, "@Fecha", finconsistencia, SqlDbType.DateTime);
            if (e.BilletesFalsos != null)
            {
                if (e.BilletesFalsos.Count > 0)
                {
                    for (int i = 0; i < e.BilletesFalsos.Count; i++)
                    {
                        int j = 38;
                        if (i > 2)
                        {                            
                            break;
                        }
                        else
                        {
                            datosbilletesfalsos += e.BilletesFalsos[i].SerieBillete;
                            if (i != (e.BilletesFalsos.Count - 1))
                            {
                                datosbilletesfalsos += ",";
                            }
                        }
                    }
                }
            }
            _manejador.agregarParametro(comando, "@Series_Billetes_Falsos", datosbilletesfalsos, SqlDbType.VarChar);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);                
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("AgregarDepositoProcesoBajoVolumen");
            }

        }

        public void agregarInconsistenciaInfoProcesamientoBajoVolumenDeposito(Deposito e, Monedas m, DateTime finconsistencia) //CAMBIO GZH 11092017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertPROAInconsistenciasInfoDeposito");
            _manejador.agregarParametro(comando, "@fk_tblProcesamientoBajoVolumenDeposito", e.ID, SqlDbType.Int);
            if (e.NumeroDeposito.Equals(string.Empty))
            {
                _manejador.agregarParametro(comando, "@Num_Deposito", 1, SqlDbType.TinyInt);
            }
            else
            {
                _manejador.agregarParametro(comando, "@Num_Deposito", 0, SqlDbType.TinyInt);
            }
            if (e.CuentaReferencia.Equals(string.Empty))
            {
                _manejador.agregarParametro(comando, "@Cuenta", 1, SqlDbType.TinyInt);
            }
            else
            {
                _manejador.agregarParametro(comando, "@Cuenta", 0, SqlDbType.TinyInt);
            }
            if (e.Cedula.Equals(string.Empty))
            {
                _manejador.agregarParametro(comando, "@cedula", 1, SqlDbType.TinyInt);
            }
            else
            {
                _manejador.agregarParametro(comando, "@cedula", 0, SqlDbType.TinyInt);
            }
            _manejador.agregarParametro(comando, "@Codigo_VD", 0, SqlDbType.TinyInt); //CAMBIO GZH 11092017
            /*if (e.CodigoVD.Equals(string.Empty))
            {
                _manejador.agregarParametro(comando, "@Codigo_VD", 1, SqlDbType.TinyInt); 
            }
            else
            {
                _manejador.agregarParametro(comando, "@Codigo_VD", 0, SqlDbType.TinyInt); //CAMBIO GZH 11092017
            }*/ //FIN CAMBIO GZH 11092017
            if (e.CodigoTransaccion.Equals(string.Empty))
            {
                _manejador.agregarParametro(comando, "@Codigo_Transaccion", 1, SqlDbType.TinyInt);
            }
            else
            {
                _manejador.agregarParametro(comando, "@Codigo_Transaccion", 0, SqlDbType.TinyInt);
            }
            if (e.MontoDiferencia != 0) //CAMBIO GZH 11092017
            {
                _manejador.agregarParametro(comando, "@Moneda", 1, SqlDbType.TinyInt);
            }
            else
            {
                _manejador.agregarParametro(comando, "@Moneda", 0, SqlDbType.TinyInt);
            }

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("AgregarInconsistenciaInfoProcesamientoBajoVolumenDeposito");
            }

        }

        public DateTime obtenerProcesamientoBajoVolumenDeposito(int iddeposito)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("ObtenerFechaProcesamientoBajoVolumenDeposito");            
            _manejador.agregarParametro(comando, "@iddeposito", iddeposito, SqlDbType.Int);            

            try
            {
                DateTime fecha;
                fecha = Convert.ToDateTime(_manejador.ejecutarEscalar(comando));
                comando.Connection.Close();
                return fecha;
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("AgregarDepositoProcesoBajoVolumen");
            }

        }

        public int agregarProaInconsistenciaManifiesto(ProcesamientoBajoVolumenManifiesto c, Colaborador e, Monedas moneda, string Detalle)
        {          
            //Decimal MontoRecibido = c.Monto + Diferencia;
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertProaInconsistenciaManifiesto");
            _manejador.agregarParametro(comando, "@fk_ID_Cajero", e.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fk_ID_Manifiesto", c.IDManifiesto, SqlDbType.Int);
            switch (moneda)
            {
                case Monedas.Colones:
                    if (c.Monto_Diferencia_Colones > 0)
                    {
                        _manejador.agregarParametro(comando, "@Tipo_Diferencia", 1, SqlDbType.Decimal);
                    }
                    else
                    {
                        _manejador.agregarParametro(comando, "@Tipo_Diferencia", 0, SqlDbType.Decimal);
                    }
                    _manejador.agregarParametro(comando, "@Monto_Diferencia", c.Monto_Diferencia_Colones, SqlDbType.Decimal);
                    _manejador.agregarParametro(comando, "@Monto_Declarado", c.Monto_Colones, SqlDbType.Decimal);
                    _manejador.agregarParametro(comando, "@Monto_Recibido", c.Monto_Contado_Colones, SqlDbType.Decimal);
                    break;
                case Monedas.Dolares:
                    if (c.Monto_Diferencia_Dolares > 0)
                    {
                        _manejador.agregarParametro(comando, "@Tipo_Diferencia", 1, SqlDbType.Decimal);
                    }
                    else
                    {
                        _manejador.agregarParametro(comando, "@Tipo_Diferencia", 0, SqlDbType.Decimal);
                    }
                    _manejador.agregarParametro(comando, "@Monto_Diferencia", c.Monto_Diferencia_Dolares, SqlDbType.Decimal);
                    _manejador.agregarParametro(comando, "@Monto_Declarado", c.Monto_Dolares, SqlDbType.Decimal);
                    _manejador.agregarParametro(comando, "@Monto_Recibido", c.Monto_Contado_Dolares, SqlDbType.Decimal);
                    break;
                case Monedas.Euros:
                    if (c.Monto_Diferencia_Euros > 0)
                    {
                        _manejador.agregarParametro(comando, "@Tipo_Diferencia", 1, SqlDbType.Decimal);
                    }
                    else
                    {
                        _manejador.agregarParametro(comando, "@Tipo_Diferencia", 0, SqlDbType.Decimal);
                    }
                    _manejador.agregarParametro(comando, "@Monto_Diferencia", c.Monto_Diferencia_Euros, SqlDbType.Decimal);
                    _manejador.agregarParametro(comando, "@Monto_Declarado", c.Monto_Euros, SqlDbType.Decimal);
                    _manejador.agregarParametro(comando, "@Monto_Recibido", c.Monto_Contado_Euros, SqlDbType.Decimal);
                    break;
            }
            /*if (Diferencia > 0)
            {
                _manejador.agregarParametro(comando, "@Tipo_Diferencia", 1, SqlDbType.Decimal);
            }
            else
            {
                _manejador.agregarParametro(comando, "@Tipo_Diferencia", 0, SqlDbType.Decimal);
            }
            _manejador.agregarParametro(comando, "@Monto_Diferencia", Diferencia, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@Monto_Declarado", c.Monto, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@Monto_Recibido", MontoRecibido, SqlDbType.Decimal);*/
            _manejador.agregarParametro(comando, "@Detalle", Detalle, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@tipomoneda", (byte)moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@idproceso", c.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
                return 1;
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("InsertProaInconsistenciaManifiesto");
            }

        }

        public DataTable ObtenerInformacionCorteAcreditacionIBS(Colaborador col) //Cambio GZH 13092017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCorteAcreditacionIBS");
            _manejador.agregarParametro(comando, "@idcolaborador", col.ID, SqlDbType.Int);
            SqlDataReader datareader = null;
            DataTable datos = new DataTable();

            try
            {

                datareader = _manejador.ejecutarConsultaDatos(comando);
                //comando.Connection.Close();
                datos.Load(datareader);

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion(ex.Message);
            }
            return datos;
        }
        public int VerificaCuentaReferenciaDeposito(String Cuenta, Monedas m, ProcesamientoBajoVolumenManifiesto ma)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectValidacionPuntoVentaCuenta");
            _manejador.agregarParametro(comando, "@fk_ID_PuntoVenta", ma.PuntoVenta.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@Cuenta", Cuenta, SqlDbType.BigInt);
            _manejador.agregarParametro(comando, "@moneda", (byte)m, SqlDbType.TinyInt);

            try
            {
                int id = Convert.ToInt32(_manejador.ejecutarEscalar(comando));
                comando.Connection.Close();
                return id;
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("SelectValidacionPuntoVentaCuenta");
            }

        }


        public int agregarCompraVentaDeposito(CompraVenta c, Deposito d) //cambio GZH 14/12/2017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCompraVentaDeposito");
            _manejador.agregarParametro(comando, "@ID_ProcesamientoBajoVolumenDeposito", d.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tipotransaccion", (int)c.TipoTransaccion, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@MontoTransaccion", c.MontoTransaccion, SqlDbType.Money);
            switch ((int)c.TipoTransaccion)
            {
                case 0:
                    _manejador.agregarParametro(comando, "@TipoCambio", c.TipoCambio.Compra, SqlDbType.Money);
                    break;
                case 1:
                    _manejador.agregarParametro(comando, "@TipoCambio", c.TipoCambio.Venta, SqlDbType.Money);
                    break;
                case 2:
                    _manejador.agregarParametro(comando, "@TipoCambio", c.TipoCambio.CompraEuros, SqlDbType.Money);
                    break;
                case 3:
                    _manejador.agregarParametro(comando, "@TipoCambio", c.TipoCambio.VentaEuros, SqlDbType.Money);
                    break;
            }
            /*if ((int)c.TipoTransaccion == 0)
            {
                _manejador.agregarParametro(comando, "@TipoCambio", c.TipoCambio.Compra, SqlDbType.Money);
            }
            else
            {
                _manejador.agregarParametro(comando, "@TipoCambio", c.TipoCambio.Venta, SqlDbType.Money);
            }*/
            _manejador.agregarParametro(comando, "@MontoCambio", c.MontoCambio, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@MontoBillete", c.MontoBillete, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@MontoNiquel", c.MontoNiquel, SqlDbType.Money);


            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
                return 1;
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("agregarCompraVentaDeposito");
            }

        }

        public int agregarBilleteFalsoDeposito(BilleteFalso c, Deposito d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertBilleteFalsoDeposito");
            _manejador.agregarParametro(comando, "@ID_ProcesamientoBajoVolumenDeposito", d.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@serie", c.SerieBillete, SqlDbType.VarChar);            
            _manejador.agregarParametro(comando, "@Moneda", (int)c.Moneda, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Denominacion", c.denominacion.Valor, SqlDbType.Decimal);            

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
                return 1;
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("agregarBilleteFalsoDeposito");
            }

        }

        public int agregarChequeDeposito(ChequeDeposito c, Deposito d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertChequeDeposito");
            _manejador.agregarParametro(comando, "@ID_ProcesamientoBajoVolumenDeposito", d.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tipocheque", (int)c.TipoCheque, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Moneda", (int)c.Moneda, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Monto", c.Monto, SqlDbType.Decimal);
            
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
                return 1;
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("agregarChequeDeposito");
            }

        }

        public int verificaTulasManifiesto(ProcesamientoBajoVolumenManifiesto c)
        {
            int conteotulas;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectVerificaCantidadTulas");            
            _manejador.agregarParametro(comando, "@ID", c.IDManifiesto, SqlDbType.Int);            


            try
            {
                conteotulas = Convert.ToInt32(_manejador.ejecutarEscalar(comando));
                comando.Connection.Close();
                return conteotulas;
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("AgregarDepositoProcesoBajoVolumen");
            }

        }


        public ProcesamientoBajoVolumenManifiesto verificaManifiestoPendiente(int cajero)
        {
            ProcesamientoBajoVolumenManifiesto man = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("VerificaPendienteProcesamientoBajoVolumenManifiesto");
            _manejador.agregarParametro(comando, "@idcajero", cajero, SqlDbType.Int);
            SqlDataReader datareader = null;

            try
            {

                datareader = _manejador.ejecutarConsultaDatos(comando);
                //comando.Connection.Close();
                
                if (datareader != null)
                {
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            int idproceso = (int)datareader["pk_ID"];
                            string codigo = (string)datareader["Codigo"];
                            int idmanifiesto = (int)datareader["fk_ID_Manifiesto"];
                            byte idcamara = (byte)datareader["fk_ID_Camara"];
                            Camara cam = new Camara("");
                            cam.ID = idcamara;
                            short idpuntoventa = (short)datareader["fk_ID_PuntoVenta"];
                            PuntoVenta pv = new PuntoVenta();
                            pv.Id = idpuntoventa;                           
                            short idcliente = (short)datareader["fk_ID_Cliente"];
                            Colaborador col = new Colaborador();
                            col.ID = (int)datareader["fk_ID_Cajero"];
                            Cliente cli = new Cliente();
                            cli.Id = idcliente;
                            Decimal montocolones = Convert.ToDecimal(datareader["MontoColones"]);
                            Decimal montodolares = Convert.ToDecimal(datareader["MontoDolares"]);
                            Decimal montoeuros = Convert.ToDecimal(datareader["MontoEuros"]);
                            man = new ProcesamientoBajoVolumenManifiesto();
                            man.Codigo = codigo;
                            man.Monto_Colones = montocolones;
                            man.Monto_Dolares = montodolares;
                            man.Monto_Euros = montoeuros;
                            man.Cliente = cli;
                            man.PuntoVenta = pv;
                            man.Cajero = col;
                            man.Camara = cam;
                            man.ID = idproceso;
                            man.IDManifiesto = idmanifiesto;

                            
                        }
                    }
                }
                comando.Connection.Close();
                return man;
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("AgregarDepositoProcesoBajoVolumen");
            }

        }


        public int verificaTulaPendiente(int idmanifiesto)
        {            
            SqlCommand comando = _manejador.obtenerProcedimiento("VerificaPendienteProcesamientoBajoVolumenTula");
            _manejador.agregarParametro(comando, "@idmanifiesto", idmanifiesto, SqlDbType.Int);


            try
            {

                int idtula = Convert.ToInt32(_manejador.ejecutarEscalar(comando));
                comando.Connection.Close();                
                return idtula;
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("VerificaPendienteProcesamientoBajoVolumenTula");
            }

        }

        public bool VerificaNumeroDeposito(string NumeroDeposito)
        {
            bool verificador = false;
            SqlCommand comando = _manejador.obtenerProcedimiento("VerificaNumeroDepositoProcesamiento");
            _manejador.agregarParametro(comando, "@numdeposito", NumeroDeposito, SqlDbType.VarChar);


            try
            {

                int idtula = Convert.ToInt32(_manejador.ejecutarEscalar(comando));
                comando.Connection.Close();
                if (idtula == 0)
                {
                    verificador = true;
                }
                else
                {
                    verificador = false;
                }
                
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("VerificaNumeroDepositoProcesamiento");
            }
            return verificador;

        }



        /// <summary>
        /// Listar todos los procesamientos de bajo volumen.
        /// </summary>
        /// <returns>Lista de procesamiento de bajo volumen registrados en el sistema</returns>
        public BindingList<ProcesamientoBajoVolumen> listarProcesamientoBajoVolumen()
        {
            BindingList<ProcesamientoBajoVolumen> procesamientosBV = new BindingList<ProcesamientoBajoVolumen>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectProcesamientoBajoVolumen");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    byte id = (byte)datareader["pk_ID"];
                    string identificador = (string)datareader["Identificador"];
                    Colaborador colaborador = null;
                    int idColaborador = (int)datareader["idColaborador"];
                    string nombreColaborador = (string)datareader["nombreColaborador"];
                    string primerapellidoColaborador = (string)datareader["primerAPColaborador"];
                    string segundoapellidoColaborador = (string)datareader["segundoAPColaborador"];
                    colaborador = new Colaborador(id: idColaborador, nombre: nombreColaborador, primer_apellido: primerapellidoColaborador, segundo_apellido: segundoapellidoColaborador);
                    Camara camara = null;
                    byte idcamara = (byte)datareader["idCamara"];
                    camara = new Camara(identificador, idcamara);
                    decimal montoBD = (decimal)datareader["MontoBD"];
                    decimal montoCOL = (decimal)datareader["MontoCOL"];
                    decimal montoDOL = (decimal)datareader["MontoDOL"];
                    decimal montoAD = (decimal)datareader["MontoAD"];
                    decimal montoEUR = (decimal)datareader["MontoEUR"]; //Cambio GZH PROA 23/08/2017
                    ProcesamientoBajoVolumen procesamiento = new ProcesamientoBajoVolumen(cajero: colaborador, camara: camara, montoBD: montoBD, montoCOL: montoCOL,
                        montoDOL: montoDOL, montoAD: montoAD, montoEUR: montoEUR); //Cambio GZH PROA 11092017
                    procesamientosBV.Add(procesamiento);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return procesamientosBV;
        }


        public ProcesamientoBajoVolumen listarProcesamientoBajoVolumenCajero(ref Colaborador c)
        {
            ProcesamientoBajoVolumen procesamiento = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectProcesamientoBajoVolumenCajero");
            _manejador.agregarParametro(comando, "@cajero", c.ID, SqlDbType.Int);
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string identificador = (string)datareader["Identificador"];
                    Colaborador colaborador = null;
                    int idColaborador = (int)datareader["idColaborador"];
                    string nombreColaborador = (string)datareader["nombreColaborador"];
                    string primerapellidoColaborador = (string)datareader["primerAPColaborador"];
                    string segundoapellidoColaborador = (string)datareader["segundoAPColaborador"];
                    colaborador = new Colaborador(id: idColaborador, nombre: nombreColaborador, primer_apellido: primerapellidoColaborador, segundo_apellido: segundoapellidoColaborador);
                    Camara camara = null;
                    byte idcamara = (byte)datareader["idCamara"];
                    camara = new Camara(identificador, idcamara);
                    decimal montoBD = (decimal)datareader["MontoBD"];
                    decimal montoCOL = (decimal)datareader["MontoCOL"]; //Cambio GZH 11092017
                    decimal montoDOL = (decimal)datareader["MontoDOL"];
                    decimal montoAD = (decimal)datareader["MontoAD"];
                    decimal montoEUR = (decimal)datareader["MontoEUR"]; //Cambio GZH 23/08/2017
                    int excedelimite = (int)datareader["Excedelimite"];
                    int excedelimiteBD = (int)datareader["ExcedelimiteBD"];
                    int excedelimiteAD = (int)datareader["ExcedelimiteAD"];
                    int excedelimiteCOL = (int)datareader["ExcedelimiteCOL"];
                    int excedelimiteDOL = (int)datareader["ExcedelimiteDOL"];
                    int excedelimiteEUR = (int)datareader["ExcedelimiteEUR"]; //Cambio GZH 23/08/2017
                    procesamiento = new ProcesamientoBajoVolumen(ID: id, cajero: colaborador, camara: camara, montoBD: montoBD, montoCOL: montoCOL, montoDOL: montoDOL, montoAD: montoAD, montoEUR: montoEUR,
                        excedelimite: (excedelimite > 0) ? true : false, excedelimiteAD: (excedelimiteAD > 0) ? true : false, excedelimiteBD: (excedelimiteBD > 0) ? true : false,
                        excedelimiteCOL: (excedelimiteCOL > 0) ? true : false, excedelimiteDOL: (excedelimiteDOL > 0) ? true : false, excedelimiteEUR: (excedelimiteEUR > 0) ? true : false); //Cambio GZH 11092017
                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return procesamiento;
        }



        public BindingList<ProcesamientoBajoVolumenDeposito> listarProcesamientoBajoVolumenDeposito(ref ProcesamientoBajoVolumenManifiesto man)
        {
            BindingList<ProcesamientoBajoVolumenDeposito> listaprocesamientobajovolumendeposito = new BindingList<ProcesamientoBajoVolumenDeposito>();
            ProcesamientoBajoVolumen procesamiento = null;
            ProcesamientoBajoVolumenDeposito procesamientodeposito = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("ObtienePendienteProcesamientoBajoVolumenDeposito");
            _manejador.agregarParametro(comando, "@idmanifiesto", man.ID, SqlDbType.Int);
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    int idprocesamientobajovolumen = (int)datareader["fk_ID_ProcesamientoBajoVolumen"];                    
                    string numerodeposito = (string)datareader["Numero_deposito"];
                    ProcesamientoBajoVolumenManifiesto manifiesto = new ProcesamientoBajoVolumenManifiesto();
                    manifiesto.DB_ID = (int)datareader["fk_ID_Manifiesto"];
                    manifiesto.ID = (int)datareader["fk_ID_Manifiesto"];
                    manifiesto.Codigo = (string)datareader["Codigomanifiesto"];
                    Tula tula = new Tula((string)datareader["CodigoTula"], id: (int)datareader["fk_ID_Tula"]);
                    int tipomesaniquel = (int)datareader["TipoMesa_Niquel"];                    
                    DateTime fechaprocesamiento = (DateTime)datareader["Fecha_Procesamiento"];
                    string codigoVD = (string)datareader["Codigo_VD"];
                    string codigotransaccion = (string)datareader["Codigo_Transaccion"];
                    string cuentareferencia = (string)datareader["Cuenta_Referencia"];
                    string cedula = (string)datareader["Cedula"];
                    Monedas moneda = (Monedas)(byte)datareader["Moneda"];
                    decimal montoNiquel = (decimal)datareader["Monto_Niquel"];
                    decimal montoContado = (decimal)datareader["Monto_Contado"];
                    decimal montoDeclarado = (decimal)datareader["Monto_Declarado"];
                    decimal diferencia = (decimal)datareader["Diferencia"];
                    string depositante = (string)datareader["Depositante"];                    
                    procesamiento = new ProcesamientoBajoVolumen(ID: idprocesamientobajovolumen);
                    procesamientodeposito = new ProcesamientoBajoVolumenDeposito(ID: id, procesamientobajovolumen: procesamiento, tula: tula, manifiesto: manifiesto, moneda: moneda, 
                        fecha_procesamiento: fechaprocesamiento, numero_deposito: numerodeposito, codigo_VD: codigoVD, codigo_transaccion: codigotransaccion, cedula: cedula, cuenta: cuentareferencia,
                        tipomesa: tipomesaniquel, MontoNiquel: montoNiquel, MontoContado: montoContado, MontoDeclarado: montoDeclarado, Diferencia: diferencia, Depositante: depositante);                    
                    listaprocesamientobajovolumendeposito.Add(procesamientodeposito);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return listaprocesamientobajovolumendeposito;
        }

        public DataTable ObtenerInformacionPantallaResumenManifiesto(ProcesamientoBajoVolumenManifiesto man) //Cambio GZH 25082017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDatosPantallaResumen");
            _manejador.agregarParametro(comando, "@idPROCmanifiesto", man.ID, SqlDbType.Int);
            SqlDataReader datareader = null;
            DataTable datos = new DataTable();

            try
            {

                datareader = _manejador.ejecutarConsultaDatos(comando);
                //comando.Connection.Close();
                datos.Load(datareader);

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion(ex.Message);
            }
            return datos;
        }

        //ddrc
        public void actualizarDeposito(Deposito _deposito, Colaborador _coordinador)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateProcBajoVolDepositov3");
            _manejador.agregarParametro(comando, "@colaborador", _coordinador.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@idDeposito", _deposito.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@codigoTansaccion", _deposito.CodigoTransaccion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@numDeposito", _deposito.NumeroDeposito, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@cuentaReferencia", _deposito.CuentaReferencia, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@moneda", _deposito.Moneda, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tipoMesaNiquel", _deposito.TipomesaNiquel, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cedula", _deposito.Cedula, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@montoDeclarado", _deposito.MontoDeclarado, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@montoNiquel", _deposito.MontoNiquel, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@codigoTransaccion", _deposito.CodigoTransaccion, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@montoContado", _deposito.Monto, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@diferencia", _deposito.MontoDiferencia, SqlDbType.Money);


            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception EX)
            {
                comando.Connection.Close();
                throw new Excepcion(EX.Message);
            }

        }


        //ddrc
        public DataTable SelectProaMontosDepositos(int iD)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectProaMontosDepositos");
            _manejador.agregarParametro(comando, "@idPVBM", iD, SqlDbType.Int);
            SqlDataReader datareader = null;
            DataTable datos = new DataTable();
            try
            {

                datareader = _manejador.ejecutarConsultaDatos(comando);
                datos.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion(ex.Message);
            }
            return datos;
        }

        public DataTable SelectTipoCambio(DateTime fecha_Procesamiento)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectProaMontosDepositos");
            _manejador.agregarParametro(comando, "@fecha", fecha_Procesamiento, SqlDbType.Date);
            SqlDataReader datareader = null;
            DataTable datos = new DataTable();
            try
            {

                datareader = _manejador.ejecutarConsultaDatos(comando);
                datos.Load(datareader);
                comando.Connection.Close();
            }
            catch (Excepcion ex)
            {
                throw new Excepcion(ex.Message);
            }
            return datos;
        }

        public bool VerificaInconsistencia(int iD)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("VerificaInconsistencia");
            _manejador.agregarParametro(comando, "@idPVBM", iD, SqlDbType.Int);
            SqlDataReader datareader = null;
            DataTable datos = new DataTable();
            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                datos.Load(datareader);
                comando.Connection.Close();
            }
            catch (Excepcion ex)
            {
                throw new Excepcion(ex.Message);
            }
            return (datos.Rows.Count == 0 ? false : true);
        }

        public void EliminaInconsistenciaBajoVolumenManifiesto(ref ProcesamientoBajoVolumenManifiesto _manifiesto)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteProaInconsistenciaManifiesto");
            _manejador.agregarParametro(comando, "@idPVBM", _manifiesto.ID, SqlDbType.Int);
            DataTable datos = new DataTable();
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion(ex.Message);
            }
        }

        public void ActualizaInconsistenciaBajoVolumenManifiesto(ref ProcesamientoBajoVolumenManifiesto _pvbm, ref Colaborador col, string detalle, Monedas moneda)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateProaInconsistenciaManifiestoConsulta");
            _manejador.agregarParametro(comando, "@idPBVM", _pvbm.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fk_ID_Cajero", col.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fk_ID_Manifiesto", _pvbm.IDManifiesto, SqlDbType.Int);
            switch (moneda)
            {
                case Monedas.Colones:
                    if (_pvbm.Monto_Diferencia_Colones > 0)
                    {
                        _manejador.agregarParametro(comando, "@Tipo_Diferencia", 1, SqlDbType.Decimal);
                    }
                    else
                    {
                        _manejador.agregarParametro(comando, "@Tipo_Diferencia", 0, SqlDbType.Decimal);
                    }
                    _manejador.agregarParametro(comando, "@Monto_Diferencia", _pvbm.Monto_Diferencia_Colones, SqlDbType.Decimal);
                    _manejador.agregarParametro(comando, "@Monto_Declarado", _pvbm.Monto_Colones, SqlDbType.Decimal);
                    _manejador.agregarParametro(comando, "@Monto_Recibido", _pvbm.Monto_Contado_Colones, SqlDbType.Decimal);
                    break;
                case Monedas.Dolares:
                    if (_pvbm.Monto_Diferencia_Dolares > 0)
                    {
                        _manejador.agregarParametro(comando, "@Tipo_Diferencia", 1, SqlDbType.Decimal);
                    }
                    else
                    {
                        _manejador.agregarParametro(comando, "@Tipo_Diferencia", 0, SqlDbType.Decimal);
                    }
                    _manejador.agregarParametro(comando, "@Monto_Diferencia", _pvbm.Monto_Diferencia_Dolares, SqlDbType.Decimal);
                    _manejador.agregarParametro(comando, "@Monto_Declarado", _pvbm.Monto_Dolares, SqlDbType.Decimal);
                    _manejador.agregarParametro(comando, "@Monto_Recibido", _pvbm.Monto_Contado_Dolares, SqlDbType.Decimal);
                    break;
                case Monedas.Euros:
                    if (_pvbm.Monto_Diferencia_Euros > 0)
                    {
                        _manejador.agregarParametro(comando, "@Tipo_Diferencia", 1, SqlDbType.Decimal);
                    }
                    else
                    {
                        _manejador.agregarParametro(comando, "@Tipo_Diferencia", 0, SqlDbType.Decimal);
                    }
                    _manejador.agregarParametro(comando, "@Monto_Diferencia", _pvbm.Monto_Diferencia_Euros, SqlDbType.Decimal);
                    _manejador.agregarParametro(comando, "@Monto_Declarado", _pvbm.Monto_Euros, SqlDbType.Decimal);
                    _manejador.agregarParametro(comando, "@Monto_Recibido", _pvbm.Monto_Contado_Euros, SqlDbType.Decimal);
                    break;
            }
            _manejador.agregarParametro(comando, "@Detalle", detalle, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@tipomoneda", (byte)moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@idproceso", _pvbm.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();

            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("InsertProaInconsistenciaManifiesto");
            }
        }

        public void UpdateInconsistenciasDepositoProa(ProcesamientoBajoVolumenManifiesto _manifiesto, Tula tula, Deposito _dep, Monedas moneda, byte origenDiferencia, DateTime fprocesobajovolumendeposito, Colaborador col)
        {
            string datosbilletesfalsos = "";
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateInconsistenciasDepositosProa");
            _manejador.agregarParametro(comando, "@fk_tblProcesamientoBajoVolumenDeposito", _dep.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Cuenta", _dep.CuentaReferencia, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@numero_deposito", _dep.NumeroDeposito, SqlDbType.VarChar);
            if (_dep.MontoDiferencia > 0)
            {
                _manejador.agregarParametro(comando, "@Tipo_Diferencia", 1, SqlDbType.TinyInt);
            }
            else
            {
                _manejador.agregarParametro(comando, "@Tipo_Diferencia", 0, SqlDbType.TinyInt);
            }
            _manejador.agregarParametro(comando, "@Origen_Diferencia", origenDiferencia, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@Tipo_Moneda", (byte)_dep.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@Monto_Diferencia", _dep.MontoDiferencia, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@Monto_Declarado", _dep.MontoDeclarado, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Monto_Recibido", _dep.Monto, SqlDbType.Money);
            if (_dep.BilletesFalsos != null)
            {
                if (_dep.BilletesFalsos.Count > 0)
                {
                    for (int i = 0; i < _dep.BilletesFalsos.Count; i++)
                    {
                        int j = 38;
                        if (i > 2)
                        {
                            break;
                        }
                        else
                        {
                            datosbilletesfalsos += _dep.BilletesFalsos[i].SerieBillete;
                            if (i != (_dep.BilletesFalsos.Count - 1))
                            {
                                datosbilletesfalsos += ",";
                            }
                        }
                    }
                }
            }
            _manejador.agregarParametro(comando, "@Series_Billetes_Falsos", datosbilletesfalsos, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@idCol", col, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Excepcion ex)
            {
                comando.Connection.Close();
                throw new Excepcion(ex.Message);
            }
        }

        public void updateInconsistenciaInfoProcesamientoBajoVolumenDeposito(Deposito e, int Tipo)
        {
            int estado = 1;
            SqlCommand comando = (Tipo == 0) ? _manejador.obtenerProcedimiento("UpdatePROAInconsistenciasInfoDepositoConsulta") : _manejador.obtenerProcedimiento("InsertPROAInconsistenciasInfoDepositoConsulta"); ;
            _manejador.agregarParametro(comando, "@fk_tblProcesamientoBajoVolumenDeposito", e.ID, SqlDbType.Int);
            if (e.NumeroDeposito.Equals(string.Empty))
            {
                _manejador.agregarParametro(comando, "@Num_Deposito", 1, SqlDbType.TinyInt);
                estado = 0;
            }
            else
            {
                _manejador.agregarParametro(comando, "@Num_Deposito", 0, SqlDbType.TinyInt);

            }
            if (e.CuentaReferencia.Equals(string.Empty))
            {
                _manejador.agregarParametro(comando, "@Cuenta", 1, SqlDbType.TinyInt);
                estado = 0;
            }
            else
            {
                _manejador.agregarParametro(comando, "@Cuenta", 0, SqlDbType.TinyInt);
            }
            if (e.Cedula.Equals(string.Empty))
            {
                _manejador.agregarParametro(comando, "@cedula", 1, SqlDbType.TinyInt);
                estado = 0;
            }
            else
            {
                _manejador.agregarParametro(comando, "@cedula", 0, SqlDbType.TinyInt);
            }
            if (e.CodigoVD.Equals(string.Empty))
            {
                _manejador.agregarParametro(comando, "@Codigo_VD", 1, SqlDbType.TinyInt);
                estado = 0;
            }
            else
            {
                _manejador.agregarParametro(comando, "@Codigo_VD", 0, SqlDbType.TinyInt);
            }
            if (e.CodigoTransaccion.Equals(string.Empty))
            {
                _manejador.agregarParametro(comando, "@Codigo_Transaccion", 1, SqlDbType.TinyInt);
                estado = 0;
            }
            else
            {
                _manejador.agregarParametro(comando, "@Codigo_Transaccion", 0, SqlDbType.TinyInt);
            }
            if (e.MontoDiferencia > 0)
            {
                _manejador.agregarParametro(comando, "@Moneda", 1, SqlDbType.TinyInt);
                estado = 0;
            }
            else
            {
                _manejador.agregarParametro(comando, "@Moneda", 0, SqlDbType.TinyInt);
            }
            _manejador.agregarParametro(comando, "@Estado", estado, SqlDbType.Int);
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
            }
            catch (Exception es)
            {
                comando.Connection.Close();
                throw new Excepcion(es.Message);
            }
        }

        public bool puedeModificarManifiesto(int idManifiesto)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("puedeModificarManfiesto");
            _manejador.agregarParametro(comando, "@idManifiesto", idManifiesto, SqlDbType.Int);
            SqlDataReader datareader = null;
            bool puede = false;
            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                if (datareader != null)
                {
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            puede = (bool)datareader["Puede"];
                        }
                        comando.Connection.Close();
                    }
                }

                return puede;
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Exception(ex.Message);
            }
        }
        #endregion Métodos Públicos
    }
}
