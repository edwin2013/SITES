using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using System.Data.SqlClient;
using System.Data;
using CommonObjects;
using LibreriaMensajes;
using CommonObjects.Clases;
using System.ComponentModel;

namespace DataLayer.Clases
{
    public class CajeroNiquel_DL: ObjetoIndexado
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static CajeroNiquel_DL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static CajeroNiquel_DL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CajeroNiquel_DL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;
        SucursalesDL _sucursales = SucursalesDL.Instancia;

        #endregion Atributos

        #region Constructor

        public CajeroNiquel_DL() { }

        #endregion Constructor

        #region Métodos Públicos

        public int ObtenerverificacionCodigoBoletaNiquelEnMesa(String codigo)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectVerificaCodigoBoletaNiquel");            
            _manejador.agregarParametro(comando, "@codigo", codigo, SqlDbType.VarChar);
            int verificador = 0;
            try
            {
                verificador = Convert.ToInt32(_manejador.ejecutarEscalar(comando));
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                verificador = 1;
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoRegistro");
            }
            return verificador;
        }

        public int DeleteCodigoBoletaNiquelEnMesa(String codigo)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCodigoBoletaNiquel");
            _manejador.agregarParametro(comando, "@codigo", codigo, SqlDbType.VarChar);
            int verificador = 0;
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
                verificador = 1;
            }
            catch (Exception ex)
            {
                verificador = 0;
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoRegistro");
            }
            return verificador;
        }

        public BoletaCajeroNiquel ObtenerBoletaCajeroNiquel(ref Colaborador c, DateTime i, DateTime f)
        {
            BoletaCajeroNiquel boleta = new BoletaCajeroNiquel();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectInfoFormularioBoletaNiquelEntregaCajeroNiquel");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha_inicio", i, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha_fin", f, SqlDbType.DateTime);            

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string cajero = (string)datareader["Cajero"];
                    string tula = (string)datareader["Tula"];
                    string manifiesto = (string)datareader["Manifiesto"];
                    string cliente = (string)datareader["Cliente"];
                    string Numero_deposito = (string)datareader["Numero_deposito"];
                    string Cuenta = (string)datareader["Cuenta"];
                    decimal Monto_Niquel = (decimal)datareader["Monto_Niquel"];
                    decimal Monto_Deposito = (decimal)datareader["Monto_Deposito"];
                    DateTime Fecha_Generacion = (DateTime)datareader["Fecha_Generacion"];
                    decimal Faltante = (decimal)datareader["Faltante"];
                    decimal Sobrante = (decimal)datareader["Sobrante"];

                    //c.ColaboradorRecibidoBoveda = new Colaborador(id, nombre: nombre, primer_apellido: primer_apellido,
                     //                                            segundo_apellido: segundo_apellido, identificacion: identificacion);                    
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                return null;
                throw new Excepcion("ErrorDatosConexion");
            }
            return null;
        }

        public void agregarBoletaCajeroNiquel(ref BoletaCajeroNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertInfoFormularioBoletaNiquelEntregaCajeroNiquel");

            _manejador.agregarParametro(comando, "@ID_ProcesamientoBajoVolumenDeposito", c.Procesobajovolumendeposito, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Manifiesto", c.Manifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Tula", c.Tula, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Cliente", c.Cliente, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@deposito", c.Numero_Deposito, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@Cuenta", c.Cuenta, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@Monto_Niquel", c.MontoNiquel, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Monto_Deposito", c.MontoDeposito, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Faltante", c.Faltante, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@Sobrante", c.Sobrante, SqlDbType.Money);

            try
            {
                c.ID = Convert.ToInt32(_manejador.ejecutarEscalar(comando));
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoRegistro");
            }

        }


        public BindingList<BoletaMesaNiquel> ObtenerInfoBoletaNiquelEnMesa(ref Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectInfoFormularioBoletaNiquelEntregaCola");
            BoletaMesaNiquel boleta;
            SqlDataReader datareader = null;
            BindingList<BoletaMesaNiquel> listaboletas = new BindingList<BoletaMesaNiquel>();

            
            _manejador.agregarParametro(comando, "@Cajero", c.ID, SqlDbType.Int);            

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {                    
                    int cajero = (int)datareader["IdCajero"];                    
                    decimal Monto_Niquel = (decimal)datareader["Monto_Niquel"];                    
                    DateTime Fecha_Generacion = (DateTime)datareader["Fecha_Generacion"];
                    int iddeposito = (int)datareader["pk_ID"];                    
                    boleta = new BoletaMesaNiquel(cajero: cajero, montoniquel: Monto_Niquel, fecha: Fecha_Generacion, procesobajovolumendeposito: iddeposito);
                    listaboletas.Add(boleta);

                    //c.ColaboradorRecibidoBoveda = new Colaborador(id, nombre: nombre, primer_apellido: primer_apellido,
                    //                                            segundo_apellido: segundo_apellido, identificacion: identificacion);                    
                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoRegistro");
            }
            return listaboletas;
        }

        public DataTable ObtenerInfoFormularioInconsistenciasManifiesto(ref Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SELECTProaInconsistenciaManifiesto");            
            SqlDataReader datareader = null;
            DataTable listainconsistencias = new DataTable();


            _manejador.agregarParametro(comando, "@fk_ID_Cajero", c.ID, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                listainconsistencias.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoRegistro");
            }
            return listainconsistencias;
        }

        public int CerrarInfoFormularioInconsistenciasManifiesto(DataTable d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateProaInconsistenciaManifiesto");            
            DataTable listainconsistencias = new DataTable();


            _manejador.agregarParametro(comando, "@fk_ID_Cajero", d.Rows[0]["ID_Cajero"], SqlDbType.Int);
            int result = 0;
            try
            {
                result = Convert.ToInt32(_manejador.ejecutarEscalar(comando));                
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoRegistro");
            }
            return result;
        }

        public void agregarBoletaMesaNiquel(ref BoletaMesaNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertInfoFormularioBoletaNiquelEntregaCola");

            _manejador.agregarParametro(comando, "@ID_ProcesamientoBajoVolumenDeposito", c.Procesobajovolumendeposito, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@codigo", c.CodigoEntrega, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@Monto_Niquel", c.MontoNiquel, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@estado", c.Estado, SqlDbType.TinyInt); 

            try
            {
                c.ID = Convert.ToInt32(_manejador.ejecutarEscalar(comando));
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoRegistro");
            }

        }

        public void agregarInfoEnMesaNiquel(ref BoletaMesaNiquel c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertProaInfoNiquelenMesa");

            //_manejador.agregarParametro(comando, "@ID_ProcesamientoBajoVolumenDeposito", c.Procesobajovolumendeposito, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@Cajero", c.Cajero, SqlDbType.Int);
            //_manejador.agregarParametro(comando, "@codigo", c.CodigoEntrega, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@Monto_Niquel", c.MontoNiquel, SqlDbType.Money);
            //_manejador.agregarParametro(comando, "@estado", c.Estado, SqlDbType.TinyInt);

            try
            {
                c.ID = Convert.ToInt32(_manejador.ejecutarEscalar(comando));
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorManifiestoRegistro");
            }

        }


        #endregion Métodos Públicos        
    }
}
