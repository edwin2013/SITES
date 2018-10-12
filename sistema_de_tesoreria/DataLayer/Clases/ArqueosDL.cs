using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using CommonObjects;
using CommonObjects.Clases;
using System.Data.SqlClient;
using LibreriaMensajes;
using System.ComponentModel;
using System.Data;

namespace DataLayer.Clases
{
    public class ArqueosDL
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ArqueosDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ArqueosDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ArqueosDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ArqueosDL() { }

        #endregion Constructor

        #region Métodos Públicos

        public void agregarArqueo(ref Arqueo c, Colaborador usuario)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertArqueoNiquel");

            _manejador.agregarParametro(comando, "@tipo", c.Tipo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@moneda", c.Moneda, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cuenta", c.CuentaContable, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@codigo", c.CodigoCajero, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@saldocontable", c.SaldoContable, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldoarqueo", c.SaldoArqueo, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@sobrante", c.Sobrante, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@faltante", c.Faltante, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@inicio", c.Inicio, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fin", c.Fin, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@colaborador", c.Usuario.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@comentario", c.Comentario, SqlDbType.NVarChar);

            _manejador.agregarParametro(comando, "@colas", c.Colas, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado", c.Mutilado, SqlDbType.Decimal);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorArqueoRegistro");
            }

        }

        public void agregarDenominacion(ref DenominacionArqueo c, Arqueo arqueo)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertDenominacionArqueo");

            _manejador.agregarParametro(comando, "@fk_ID_Arqueo", arqueo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fk_ID_Denominacion", c.Denominacion.Id, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto", c.MontoTotal, SqlDbType.Decimal);
            
            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorArqueoRegistro");
            }

        }

        ///// <summary>
        ///// Actualizar los datos de una caja.
        ///// </summary>
        ///// <param name="c">Objeto Caja con los datos de la caja a actualizar</param>
        //public void actualizarCaja(Caja c)
        //{
        //    SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCaja");

        //    _manejador.agregarParametro(comando, "@numero", c.Numero, SqlDbType.Decimal);
        //    _manejador.agregarParametro(comando, "@descripcion", c.Descripcion, SqlDbType.NVarChar);
        //    _manejador.agregarParametro(comando, "@caja", c, SqlDbType.Int);

        //    try
        //    {
        //        _manejador.ejecutarConsultaActualizacion(comando);
        //        comando.Connection.Close();
        //    }
        //    catch (Exception)
        //    {
        //        comando.Connection.Close();
        //        throw new Excepcion("ErrorCajaActualizacion");
        //    }

        //}

        ///// <summary>
        ///// Eliminar los datos de una caja.
        ///// </summary>
        ///// <param name="c">Objeto Caja con los datos de la caja a eliminar</param>
        //public void eliminarCaja(Caja c)
        //{
        //    SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCaja");

        //    _manejador.agregarParametro(comando, "@caja", c, SqlDbType.TinyInt);

        //    try
        //    {
        //        _manejador.ejecutarConsultaActualizacion(comando);
        //        comando.Connection.Close();
        //    }
        //    catch (Exception)
        //    {
        //        comando.Connection.Close();
        //        throw new Excepcion("ErrorCajaEliminacion");
        //    }

        //}
        
        public BindingList<Arqueo> listarArqueos(DateTime? inicio = null, DateTime? fin=null)
        {
            BindingList<Arqueo> Arqueos = new BindingList<Arqueo>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectArqueos");
            SqlDataReader datareader = null;

            if (inicio != null)
            {
                _manejador.agregarParametro(comando, "@inicio", inicio, SqlDbType.DateTime);
                _manejador.agregarParametro(comando, "@fin", fin, SqlDbType.DateTime);
            }

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    DateTime Fecha = (DateTime)datareader["Fecha"];
                    string comentario = (string)datareader["Comentario"];
                    Colaborador usuario = null;
                    if (datareader["fk_ID_Colaborador"] != DBNull.Value)
                    {
                        int fk_ID_Colaborabor = (int)datareader["fk_ID_Colaborador"];
                        string nombre = (string)datareader["NombreColaborador"];

                        usuario = new Colaborador(id:fk_ID_Colaborabor, nombre:nombre);
                    }

                    MonedaArqueo moneda = (MonedaArqueo)datareader["Moneda"];
                    TipoArqueo tipo = (TipoArqueo)datareader["Tipo"];
                    DateTime Inicio = (DateTime)datareader["Inicio"];
                    DateTime Fin = (DateTime)datareader["Fin"];

                    decimal Cuenta =(decimal)datareader["CuentaContable"];
                    string Codigo = (string)datareader["CodigoCajero"];
                    decimal SaldoContable = (decimal)datareader["SaldoContable"];
                    decimal SaldoArqueo = (decimal)datareader["SaldoArqueo"];
                    decimal Sobrante = (decimal)datareader["Sobrante"];
                    decimal Faltante = (decimal)datareader["Faltante"];

                    decimal Colas = (decimal)datareader["Colas"];
                    decimal Mutilado = (decimal)datareader["Mutilado"];
                   
                    Arqueo arqueo = new Arqueo(id: id, fecha_ingreso: Fecha, comentario: comentario, colaborador: usuario,
                        inicio:Inicio, fin:Fin, cuentacontable:Cuenta, codigocajero:Codigo, saldocontable:SaldoContable,saldoarqueo:SaldoArqueo,
                        sobrante:Sobrante, faltante:Faltante, colas:Colas, mutilado:Mutilado);

                    Arqueos.Add(arqueo);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return Arqueos;
        }

        public Arqueo buscarDenominaciones(ref Arqueo a)
        {
            BindingList<DenominacionArqueo> denominaciones = new BindingList<DenominacionArqueo>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDenominacionesArqueos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@arqueo", a, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                while (datareader.Read())
                {
                    byte id = (byte)datareader["fk_ID_Denominacion"];
                    decimal monto = (decimal)datareader["Monto"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                   
                    decimal valor = (decimal)datareader["Valor"];

                    Denominacion den = new Denominacion();
                    den.Id= id;
                    den.Moneda=moneda;
                    den.Valor = valor;

                    DenominacionArqueo denominacion = new DenominacionArqueo(denominacion: den, monto_total: monto);

                    denominaciones.Add(denominacion);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }
            a.Denominaciones = denominaciones;
            return a;
        }


        #region Arqueo Bóveda
        public void agregarArqueoBoveda(ref Arqueo c, Colaborador usuario)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertArqueoBoveda");

            _manejador.agregarParametro(comando, "@tipo", c.Tipo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@moneda", c.Moneda, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cuenta", c.CuentaContable, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@codigo", c.CodigoCajero, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@saldocontable", c.SaldoContable, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldoarqueo", c.SaldoArqueo, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@sobrante", c.Sobrante, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@faltante", c.Faltante, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@inicio", c.Inicio, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fin", c.Fin, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@colaborador", c.Usuario.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@comentario", c.Comentario, SqlDbType.NVarChar);

            _manejador.agregarParametro(comando, "@colas", c.Colas, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado", c.Mutilado, SqlDbType.Decimal);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorArqueoRegistro");
            }

        }

        public void agregarDenominacionBoveda(ref DenominacionArqueo c, Arqueo arqueo)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertDenominacionArqueoBoveda");

            _manejador.agregarParametro(comando, "@fk_ID_Arqueo", arqueo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fk_ID_Denominacion", c.Denominacion.Id, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto", c.MontoTotal, SqlDbType.Decimal);

            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorArqueoRegistro");
            }

        }


        public BindingList<Arqueo> listarArqueosBoveda(DateTime fecha)
        {
            BindingList<Arqueo> Arqueos = new BindingList<Arqueo>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectArqueosBoveda");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.DateTime);
            
            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    DateTime Fecha = (DateTime)datareader["Fecha"];
                    string comentario = "";
                    if (datareader["Comentario"] != DBNull.Value)
                    {
                        comentario = (string)datareader["Comentario"];
                    }
                    Colaborador usuario = null;
                    if (datareader["fk_ID_Colaborador"] != DBNull.Value)
                    {
                        int fk_ID_Colaborabor = (int)datareader["fk_ID_Colaborador"];
                        string nombre = (string)datareader["NombreColaborador"];

                        usuario = new Colaborador(id: fk_ID_Colaborabor, nombre: nombre);
                    }
                    DateTime Inicio = System.DateTime.Now;
                    DateTime Fin = System.DateTime.Now;
                    if (datareader["Inicio"] != DBNull.Value)
                    {
                        Inicio = (DateTime)datareader["Inicio"];
                        Fin = (DateTime)datareader["Fin"];
                    }
                   
                    decimal Cuenta = (decimal)datareader["CuentaContable"];
                    string Codigo = (string)datareader["CodigoCajero"];
                    decimal SaldoContable = (decimal)datareader["SaldoContable"];
                    decimal SaldoArqueo = (decimal)datareader["SaldoArqueo"];
                    decimal Sobrante = (decimal)datareader["Sobrante"];
                    decimal Faltante = (decimal)datareader["Faltante"];

                    decimal Colas = (decimal)datareader["Colas"];
                    decimal Mutilado = (decimal)datareader["Mutilado"];

                    Arqueo arqueo = new Arqueo(id: id, fecha_ingreso: Fecha, comentario: comentario, colaborador: usuario,
                        inicio: Inicio, fin: Fin, cuentacontable: Cuenta, codigocajero: Codigo, saldocontable: SaldoContable, saldoarqueo: SaldoArqueo,
                        sobrante: Sobrante, faltante: Faltante, colas: Colas, mutilado: Mutilado);

                    Arqueos.Add(arqueo);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return Arqueos;
        }

        public Arqueo buscarDenominacionesBoveda(ref Arqueo a, DateTime fecha)
        {
            BindingList<DenominacionArqueo> denominaciones = new BindingList<DenominacionArqueo>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDenominacionesArqueosBoveda");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@arqueo", a, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.DateTime);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                while (datareader.Read())
                {
                    byte id = (byte)datareader["fk_ID_Denominacion"];
                    decimal monto = (decimal)datareader["Monto"];
                    Monedas moneda = (Monedas)datareader["Moneda"];

                    decimal valor = (decimal)datareader["Valor"];

                    Denominacion den = new Denominacion();
                    den.Id = id;
                    den.Moneda = moneda;
                    den.Valor = valor;

                    DenominacionArqueo denominacion = new DenominacionArqueo(denominacion: den, monto_total: monto);

                    denominaciones.Add(denominacion);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }
            a.Denominaciones = denominaciones;
            return a;
        }
        #endregion Arqueo Bóveda

        #region Arqueo Níquel

        public void agregarArqueoNiquel(ref Arqueo c, Colaborador usuario)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertArqueoNiquel");

            _manejador.agregarParametro(comando, "@tipo", c.Tipo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@moneda", c.Moneda, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cuenta", c.CuentaContable, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@codigo", c.CodigoCajero, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@saldocontable", c.SaldoContable, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@saldoarqueo", c.SaldoArqueo, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@sobrante", c.Sobrante, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@faltante", c.Faltante, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@inicio", c.Inicio, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fin", c.Fin, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@colaborador", c.Usuario.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@comentario", c.Comentario, SqlDbType.NVarChar);

            _manejador.agregarParametro(comando, "@colas", c.Colas, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@mutilado", c.Mutilado, SqlDbType.Decimal);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorArqueoRegistro");
            }

        }

        public void agregarDenominacionNiquel(ref DenominacionArqueo c, Arqueo arqueo)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertDenominacionArqueoNiquel");

            _manejador.agregarParametro(comando, "@fk_ID_Arqueo", arqueo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fk_ID_Denominacion", c.Denominacion.Id, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@monto", c.MontoTotal, SqlDbType.Decimal);

            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorArqueoRegistro");
            }

        }


        public BindingList<Arqueo> listarArqueosNiquel(DateTime fecha)
        {
            BindingList<Arqueo> Arqueos = new BindingList<Arqueo>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectArqueosNiquel");
            SqlDataReader datareader = null;


            if (fecha != null)
            {
                _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.DateTime);
            }

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {

                    int id = (int)datareader["pk_ID"];
                    DateTime Fecha = (DateTime)datareader["Fecha"];
                    string comentario = "";
                    if (datareader["Comentario"] != DBNull.Value)
                    {
                        comentario = (string)datareader["Comentario"];
                    }
                    Colaborador usuario = null;
                    if (datareader["fk_ID_Colaborador"] != DBNull.Value)
                    {
                        int fk_ID_Colaborabor = (int)datareader["fk_ID_Colaborador"];
                        string nombre = (string)datareader["NombreColaborador"];

                        usuario = new Colaborador(id: fk_ID_Colaborabor, nombre: nombre);
                    }
                    DateTime Inicio = System.DateTime.Now;
                    DateTime Fin = System.DateTime.Now;
                    if (datareader["Inicio"] != DBNull.Value)
                    {
                        Inicio = (DateTime)datareader["Inicio"];
                        Fin = (DateTime)datareader["Fin"];
                    }

                    decimal Cuenta = (decimal)datareader["CuentaContable"];
                    string Codigo = (string)datareader["CodigoCajero"];
                    decimal SaldoContable = (decimal)datareader["SaldoContable"];
                    decimal SaldoArqueo = (decimal)datareader["SaldoArqueo"];
                    decimal Sobrante = (decimal)datareader["Sobrante"];
                    decimal Faltante = (decimal)datareader["Faltante"];

                    decimal Colas = (decimal)datareader["Colas"];
                    decimal Mutilado = (decimal)datareader["Mutilado"];

                 
                    Arqueo arqueo = new Arqueo(id: id, fecha_ingreso: Fecha, comentario: comentario, colaborador: usuario,
                        inicio: Inicio, fin: Fin, cuentacontable: Cuenta, codigocajero: Codigo, saldocontable: SaldoContable, saldoarqueo: SaldoArqueo,
                        sobrante: Sobrante, faltante: Faltante, colas: Colas, mutilado: Mutilado);

                    Arqueos.Add(arqueo);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return Arqueos;
        }

        public Arqueo buscarDenominacionesNiquel(ref Arqueo a, DateTime fecha)
        {
            BindingList<DenominacionArqueo> denominaciones = new BindingList<DenominacionArqueo>();
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectDenominacionesArqueosNiquel");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@arqueo", a, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.DateTime);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);
                while (datareader.Read())
                {
                    byte id = (byte)datareader["fk_ID_Denominacion"];
                    decimal monto = (decimal)datareader["Monto"];
                    Monedas moneda = (Monedas)datareader["Moneda"];

                    decimal valor = (decimal)datareader["Valor"];

                    Denominacion den = new Denominacion();
                    den.Id = id;
                    den.Moneda = moneda;
                    den.Valor = valor;

                    DenominacionArqueo denominacion = new DenominacionArqueo(denominacion: den, monto_total: monto);

                    denominaciones.Add(denominacion);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }
            a.Denominaciones = denominaciones;
            return a;
        }

        #endregion Arqueo Níquel
      #endregion Métodos Públicos
    }
}
