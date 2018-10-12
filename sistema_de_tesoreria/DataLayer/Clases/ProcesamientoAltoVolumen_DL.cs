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
    public class ProcesamientoAltoVolumen_DL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ProcesamientoAltoVolumen_DL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ProcesamientoAltoVolumen_DL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ProcesamientoAltoVolumen_DL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ProcesamientoAltoVolumen_DL() { }

        #endregion Constructor

        #region Métodos Públicos

        public void actualizarProcesamientoAltoVolumen(ProcesamientoAltoVolumen c, Colaborador d) //Cambios GZH 02/11/2017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateProcesamientoAltoVolumen");

            _manejador.agregarParametro(comando, "@idprocesoAltoVolumen", c.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@idcolaborador", d.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@camara", c.Camara.ID, SqlDbType.TinyInt);
            if (c.Manifiesto == null)
            {
                _manejador.agregarParametro(comando, "@manifiesto", c.Manifiesto, SqlDbType.Int);
            }
            else
            {
                _manejador.agregarParametro(comando, "@manifiesto", c.Manifiesto.ID, SqlDbType.Int);
            }
            if (c.Cliente == null)
            {
                _manejador.agregarParametro(comando, "@cliente", c.Cliente, SqlDbType.Int);
            }
            else
            {
                _manejador.agregarParametro(comando, "@cliente", c.Cliente.Id, SqlDbType.Int);
            }
            if (c.PuntoVenta == null)
            {
                _manejador.agregarParametro(comando, "@puntoventa", c.PuntoVenta, SqlDbType.Int);
            }
            else
            {
                _manejador.agregarParametro(comando, "@puntoventa", c.PuntoVenta.Id, SqlDbType.Int);
            }
            _manejador.agregarParametro(comando, "@monto", c.Monto, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@moneda", (byte)c.Moneda, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorProcesamientoAltoVolumenRegistro");
            }

        }


        public void actualizarProcesamientoAltoVolumenDetalle(ProcesamientoAltoVolumenDetalle c, Colaborador d) //Cambios GZH 02/11/2017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateProcesamientoAltoVolumenDetalle");

            _manejador.agregarParametro(comando, "@idprocesoAltoVolumenDetalle", c.ID, SqlDbType.Int);
            if (c.Tula == null)
            {
                _manejador.agregarParametro(comando, "@tula", null, SqlDbType.Int);
            }
            else
            {
                if (c.Tula.ID == 0)
                {
                    _manejador.agregarParametro(comando, "@tula", null, SqlDbType.Int);
                }
                else
                {
                    _manejador.agregarParametro(comando, "@tula", c.Tula.ID, SqlDbType.Int);
                }
            }
            _manejador.agregarParametro(comando, "@headercard", c.Headercard, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@mixta", c.Tipo, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda", (byte)c.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@monto", c.Monto, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@idcolaborador", d.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorProcesamientoDetalleAltoVolumenRegistro");
            }

        }


        public ProcesamientoAltoVolumen ObtenerInfoProcesoAltoVolumenManifiesto(string manifiesto) //Cambios GZH 01/11/2017
        {
            ProcesamientoAltoVolumen proceso = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectInfoProcesoAltoVolumen2");
            _manejador.agregarParametro(comando, "@manifiesto", manifiesto, SqlDbType.VarChar);
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
                            int idprocesoAV = (int)datareader["ID_ProcesoAV"];
                            string codigo = manifiesto;
                            int idmanifiesto = (int)datareader["fk_ID_Manifiesto"];
                            byte idcamara = (byte)datareader["fk_ID_Camara"];
                            string headercard = (string)datareader["Headercard"];
                            Camara cam = new Camara("");
                            cam.ID = idcamara;
                            short idpuntoventa = (short)datareader["fk_ID_PuntoVenta"];
                            PuntoVenta pv = new PuntoVenta();
                            pv.Id = idpuntoventa;
                            Tula tula = new Tula("");
                            tula.ID = (int)datareader["fk_ID_Tula"];
                            tula.Codigo = (string)datareader["Tula"];
                            short idcliente = (short)datareader["fk_ID_Cliente"];
                            Monedas monAV = (Monedas)datareader["MonedaAV"];
                            Monedas mon = (Monedas)datareader["Moneda"];
                            Colaborador col = new Colaborador();
                            col.ID = (int)datareader["fk_ID_Cajero"];
                            col.Nombre = (string)datareader["Nombre"];
                            col.Primer_apellido = (string)datareader["Primer_Apellido"];
                            col.Segundo_apellido = (string)datareader["Segundo_Apellido"];
                            Cliente cli = new Cliente();
                            cli.Id = idcliente;
                            cli.Nombre = (string)datareader["Cliente"];
                            Decimal montodeclarado = Convert.ToDecimal(datareader["Monto_Declarado"]);
                            Decimal montotula = Convert.ToDecimal(datareader["Monto_Tula"]);
                            Manifiesto man = new Manifiesto();
                            man.Codigo = codigo;
                            man.ID = idmanifiesto;
                            byte tipoprocesamiento = (byte)datareader["Tipo_Procesamiento"];
                            byte mixta = (byte)datareader["Mixta"];
                            ProcesamientoAltoVolumenDetalle procesodetalle = new ProcesamientoAltoVolumenDetalle(codigo: "", id: idproceso, idtula: tula, cajero_receptor: col, headercard: headercard,
                                tipo: mixta, moneda: mon, monto: montotula);
                            if (proceso == null)
                            {
                                proceso = new ProcesamientoAltoVolumen();
                                proceso.ID = idprocesoAV;
                                proceso.Detalle = new BindingList<ProcesamientoAltoVolumenDetalle>();
                                proceso.Cajero = col;
                                proceso.Camara = cam;
                                proceso.Cliente = cli;
                                proceso.Manifiesto = man;
                                proceso.PuntoVenta = pv;
                                proceso.Tipo = tipoprocesamiento;
                                proceso.Moneda = monAV;
                                proceso.Monto = montodeclarado;
                            }
                            proceso.agregarDetalle(procesodetalle);
                        }
                    }
                }
                comando.Connection.Close();
                return proceso;
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("AgregarDepositoProcesoBajoVolumen");
            }

        }

        public int verificaTulaAltoVolumen(ProcesamientoAltoVolumenDetalle c) //Cambio GZH 23/11/2017
        {
            int conteotulas;
            SqlCommand comando = _manejador.obtenerProcedimiento("VerificaTulaAltoVolumen");
            _manejador.agregarParametro(comando, "@ID", c.ID, SqlDbType.Int);


            try
            {
                conteotulas = Convert.ToInt32(_manejador.ejecutarEscalar(comando));
                comando.Connection.Close();
                return conteotulas;
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("VerificaTulaAltoVolumen");
            }

        }

        public int verificaTulasManifiesto(Manifiesto c) //Cambio GZH 27/10/2017
        {
            int conteotulas;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectVerificaCantidadTulas");
            _manejador.agregarParametro(comando, "@ID", c.ID, SqlDbType.Int);


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

        public void eliminarProcesamientoAltoVolumen(ProcesamientoAltoVolumen d, Colaborador e) //Cambios GZH 02/11/2017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteProcesamientoAltoVolumen");

            _manejador.agregarParametro(comando, "@idprocesoAltoVolumen", d.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@idcolaborador", e.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDeleteProcesamientoDetalleAltoVolumen");
            }

        }


        /// <summary>
        /// Registrar una nueva cámara.
        /// </summary>
        /// <param name="c">Objeto Camara con los datos de la nueva cámara</param>
        public void agregarProcesamientoAltoVolumen(ref ProcesamientoAltoVolumen c, ProcesamientoBajoVolumen d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertProcesamientoAltoVolumen");

            _manejador.agregarParametro(comando, "@idprocesoBajoVolumen", d.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cajero", c.Cajero.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@camara", c.Camara.ID, SqlDbType.TinyInt);
            if (c.Manifiesto == null)
            {
                _manejador.agregarParametro(comando, "@manifiesto", c.Manifiesto, SqlDbType.Int);
            }
            else
            {
                _manejador.agregarParametro(comando, "@manifiesto", c.Manifiesto.ID, SqlDbType.Int);
            }
            if (c.Cliente == null)
            {
                _manejador.agregarParametro(comando, "@cliente", c.Cliente, SqlDbType.Int);
            }
            else
            {
                _manejador.agregarParametro(comando, "@cliente", c.Cliente.Id, SqlDbType.Int);
            }
            if (c.PuntoVenta == null)
            {
                _manejador.agregarParametro(comando, "@puntoventa", c.PuntoVenta, SqlDbType.Int);
            }
            else
            {
                _manejador.agregarParametro(comando, "@puntoventa", c.PuntoVenta.Id, SqlDbType.Int);
            }
            _manejador.agregarParametro(comando, "@monto", c.Monto, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tipoprocesamiento", c.Tipo, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda", (byte)c.Moneda, SqlDbType.TinyInt);            

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorProcesamientoAltoVolumenRegistro");
            }

        }

        public void agregarProcesamientoAltoVolumenDetalle(ref ProcesamientoAltoVolumenDetalle c, ProcesamientoAltoVolumen d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertProcesamientoAltoVolumenDetalle");

            _manejador.agregarParametro(comando, "@idprocesoAltoVolumen", d.ID, SqlDbType.Int);
            if (c.Tula == null)
            {
                _manejador.agregarParametro(comando, "@tula", null, SqlDbType.Int);
            }
            else
            {
                if (c.Tula.ID == 0)
                {
                    _manejador.agregarParametro(comando, "@tula", null, SqlDbType.Int);
                }
                else
                {
                    _manejador.agregarParametro(comando, "@tula", c.Tula.ID, SqlDbType.Int);
                }
            }
            _manejador.agregarParametro(comando, "@headercard", c.Headercard, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@mixta", c.Tipo, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda", (byte)c.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@monto", c.Monto, SqlDbType.Money);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorProcesamientoDetalleAltoVolumenRegistro");
            }

        }

        public void agregarValidacionAltoVolumen(ref ValidacionAltoVolumen v) //Cambio GZH 13092017
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertValidacionAltoVolumen");

            _manejador.agregarParametro(comando, "@idprocesoAltoVolumen", v.Proceso.Detalle[0].ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@validador", v.Validador.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@montocontado", v.MontoContado, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@montodeclarado", v.MontoDeclarado, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@montodiferencia", v.MontoDiferencia, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@TipoValidacion", v.TipoValidacion, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@TipoConteo", v.TipoConteo, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@moneda", (byte)v.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@camara", v.Camara.ID, SqlDbType.TinyInt);


            try
            {
                v.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorValidacionAltoVolumenRegistro");
            }

        }

        public void agregarBilleteRechazadoAltoVolumen(ref ValidacionAltoVolumen v)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertInfoRechazadosBilleteAltoVolumen");

            _manejador.agregarParametro(comando, "@idValidacionAltoVolumen", v.ID, SqlDbType.Int);                        
            _manejador.agregarParametro(comando, "@1000CRC", v.BilleteRechazado.M1000CRC, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@2000CRC", v.BilleteRechazado.M2000CRC, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@5000CRC", v.BilleteRechazado.M5000CRC, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@10000CRC", v.BilleteRechazado.M10000CRC, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@20000CRC", v.BilleteRechazado.M20000CRC, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@50000CRC", v.BilleteRechazado.M50000CRC, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@1USD", v.BilleteRechazado.M1USD, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@5USD", v.BilleteRechazado.M5USD, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@10USD", v.BilleteRechazado.M10USD, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@20USD", v.BilleteRechazado.M20USD, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@50USD", v.BilleteRechazado.M50USD, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@100USD", v.BilleteRechazado.M100USD, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@5EUR", v.BilleteRechazado.M5EUR, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@10EUR", v.BilleteRechazado.M10EUR, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@20EUR", v.BilleteRechazado.M20EUR, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@50EUR", v.BilleteRechazado.M50EUR, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@100EUR", v.BilleteRechazado.M100EUR, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@200EUR", v.BilleteRechazado.M200EUR, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@500EUR", v.BilleteRechazado.M500EUR, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@F1000CRC", v.BilleteRechazado.C1000CRC, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@F2000CRC", v.BilleteRechazado.C2000CRC, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@F5000CRC", v.BilleteRechazado.C5000CRC, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@F10000CRC", v.BilleteRechazado.C10000CRC, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@F20000CRC", v.BilleteRechazado.C20000CRC, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@F50000CRC", v.BilleteRechazado.C50000CRC, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@F1USD", v.BilleteRechazado.C1USD, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@F5USD", v.BilleteRechazado.C5USD, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@F10USD", v.BilleteRechazado.C10USD, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@F20USD", v.BilleteRechazado.C20USD, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@F50USD", v.BilleteRechazado.C50USD, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@F100USD", v.BilleteRechazado.C100USD, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@F5EUR", v.BilleteRechazado.C5EUR, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@F10EUR", v.BilleteRechazado.C10EUR, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@F20EUR", v.BilleteRechazado.C20EUR, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@F50EUR", v.BilleteRechazado.C50EUR, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@F100EUR", v.BilleteRechazado.C100EUR, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@F200EUR", v.BilleteRechazado.C200EUR, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@F500EUR", v.BilleteRechazado.C500EUR, SqlDbType.Money); 
            _manejador.agregarParametro(comando, "@Total_Billete", v.BilleteRechazado.MontoTotal, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@moneda", (byte)v.Moneda, SqlDbType.TinyInt);

            try
            {
                v.BilleteRechazado.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorValidacionAltoVolumenRegistro");
            }

        }

        public void agregarBilleteConteoAltoVolumen(ref ValidacionAltoVolumen v)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertInfoConteoBilleteAltoVolumen");

            _manejador.agregarParametro(comando, "@idValidacionAltoVolumen", v.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@1000CRC", v.BilleteContado.M1000CRC, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@2000CRC", v.BilleteContado.M2000CRC, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@5000CRC", v.BilleteContado.M5000CRC, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@10000CRC", v.BilleteContado.M10000CRC, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@20000CRC", v.BilleteContado.M20000CRC, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@50000CRC", v.BilleteContado.M50000CRC, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@1USD", v.BilleteContado.M1USD, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@5USD", v.BilleteContado.M5USD, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@10USD", v.BilleteContado.M10USD, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@20USD", v.BilleteContado.M20USD, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@50USD", v.BilleteContado.M50USD, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@100USD", v.BilleteContado.M100USD, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@5EUR", v.BilleteContado.M5EUR, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@10EUR", v.BilleteContado.M10EUR, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@20EUR", v.BilleteContado.M20EUR, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@50EUR", v.BilleteContado.M50EUR, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@100EUR", v.BilleteContado.M100EUR, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@200EUR", v.BilleteContado.M200EUR, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@500EUR", v.BilleteContado.M500EUR, SqlDbType.Money);            
            _manejador.agregarParametro(comando, "@Total_Billete", v.BilleteContado.MontoTotal, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@moneda", (byte)v.Moneda, SqlDbType.TinyInt);

            try
            {
                v.BilleteContado.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorValidacionAltoVolumenRegistro");
            }

        }

        public ProcesamientoAltoVolumen ObtenerInfoProcesoAltoVolumen(string headercard)
        {
            ProcesamientoAltoVolumen proceso = null;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectInfoProcesoAltoVolumen");
            _manejador.agregarParametro(comando, "@headercard", headercard, SqlDbType.VarChar);
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
                            int idprocesoAV = (int)datareader["ID_ProcesoAV"];
                            string codigo = (string)datareader["Manifiesto"];
                            int idmanifiesto = (int)datareader["fk_ID_Manifiesto"];
                            byte idcamara = (byte)datareader["fk_ID_Camara"];
                            Camara cam = new Camara("");
                            cam.ID = idcamara;
                            short idpuntoventa = (short)datareader["fk_ID_PuntoVenta"];
                            PuntoVenta pv = new PuntoVenta();
                            pv.Id = idpuntoventa;
                            Tula tula = new Tula("");
                            tula.ID = (int)datareader["fk_ID_Tula"];
                            tula.Codigo = (string)datareader["Tula"];
                            short idcliente = (short)datareader["fk_ID_Cliente"];
                            Monedas mon = (Monedas)datareader["Moneda"];
                            Colaborador col = new Colaborador();
                            col.ID = (int)datareader["fk_ID_Cajero"];
                            col.Nombre = (string)datareader["Nombre"];
                            col.Primer_apellido = (string)datareader["Primer_Apellido"];                            
                            col.Segundo_apellido = (string)datareader["Segundo_Apellido"];
                            Cliente cli = new Cliente();
                            cli.Id = idcliente;
                            cli.Nombre = (string)datareader["Cliente"];
                            Decimal montodeclarado = Convert.ToDecimal(datareader["Monto_Declarado"]);                            
                            Manifiesto man = new Manifiesto();
                            man.Codigo = codigo;                            
                            man.ID = idmanifiesto;
                            byte tipoprocesamiento = (byte)datareader["Tipo_Procesamiento"];
                            byte mixta = (byte)datareader["Mixta"];
                            ProcesamientoAltoVolumenDetalle procesodetalle = new ProcesamientoAltoVolumenDetalle(codigo: "", id: idproceso, idtula: tula, cajero_receptor: col, headercard: headercard, 
                                tipo: mixta, moneda: mon, monto: montodeclarado);
                            proceso = new ProcesamientoAltoVolumen();
                            proceso.ID = idprocesoAV;
                            proceso.Detalle = new BindingList<ProcesamientoAltoVolumenDetalle>();
                            proceso.agregarDetalle(procesodetalle);
                            proceso.Cajero = col;
                            proceso.Camara = cam;
                            proceso.Cliente = cli;
                            proceso.Manifiesto = man;
                            proceso.PuntoVenta = pv;
                            proceso.Tipo = tipoprocesamiento;
                            proceso.Moneda = mon;
                        }
                    }
                }
                comando.Connection.Close();
                return proceso;
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("AgregarDepositoProcesoBajoVolumen");
            }

        }

        public string ObtenerArchivosBPS_Headercard(string headercard)
        {
            string archivo = "";
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectArchivoBPS_Headercard");
            _manejador.agregarParametro(comando, "@headercard", headercard, SqlDbType.VarChar);
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
                            archivo = (string)datareader["Archivo"];                            
                        }
                    }
                }
                comando.Connection.Close();
                return archivo;
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ObtenerArchivosBPS_Headercard");
            }

        }

        public void agregarInconsistenciaAltoVolumen(ValidacionAltoVolumen c, Colaborador col)
        {            
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertPROAInconsistenciasAltoVolumen");
            _manejador.agregarParametro(comando, "@fk_ID_ValidacionAltoVolumen", c.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fk_ID_Cajero", col, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Monto_Diferencia", c.MontoDiferencia, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@Monto_Declarado", c.MontoDeclarado, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Monto_Recibido", c.MontoContado, SqlDbType.Money);
            if (c.MontoDiferencia > 0)
            {
                _manejador.agregarParametro(comando, "@tipo", 1, SqlDbType.TinyInt);
            }
            else
            {
                _manejador.agregarParametro(comando, "@tipo", 0, SqlDbType.TinyInt);
            }            

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("AgregarPROAInconsistenciasAltoVolumen");
            }

        }

        #endregion Métodos Públicos
    }
}

