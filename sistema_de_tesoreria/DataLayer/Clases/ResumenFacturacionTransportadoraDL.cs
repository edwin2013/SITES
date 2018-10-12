using CommonObjects;
using CommonObjects.Clases;
using LibreriaAccesoDatos;
using LibreriaMensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataLayer.Clases
{
    public class ResumenFacturacionTransportadoraDL : ObjetoIndexado
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ResumenFacturacionTransportadoraDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ResumenFacturacionTransportadoraDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ResumenFacturacionTransportadoraDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ResumenFacturacionTransportadoraDL() { }

        #endregion Constructor

        #region Métodos Públicos

       



        /// <summary>
        /// Registrar en el sistema la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto FacturacionTransportadora con los datos de la carga/param>
        public void agregarFacturacionTransportadora(ref FacturacionTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertResumenFacturacion");

            _manejador.agregarParametro(comando, "@fecha_fin", c.FechaFin, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@transportadora", c.Empresa_encargada, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cliente", c.Cliente.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@colaborador", c.ColaboradoRegistro, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@observaciones", c.Observaciones, SqlDbType.NVarChar);


            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorFacturacionTransportadoraRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de la carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto FacturacionTransportadora con los datos de la carga</param>
        public void actualizarFacturacionTransportadora(ref FacturacionTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateFacturacionTransportadora");

            _manejador.agregarParametro(comando, "@fecha_fin", c.Fecha, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fecha", c.FechaFin, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@transportadora", c.Empresa_encargada, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@cliente", c.Cliente, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@colaborador", c.ColaboradoRegistro, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@observaciones", c.Observaciones, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@id", c.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorFacturacionTransportadoraActualizacion");
            }

        }




       
       

       
        /// <summary>
        /// Eliminar los datos de una carga de un ATM.
        /// </summary>
        /// <param name="c">Objeto FacturacionTransportadora con los datos de la carga</param>
        public void eliminarFacturacionTransportadora(FacturacionTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteFacturacionTransportadora");

            _manejador.agregarParametro(comando, "@carga", c, SqlDbType.Int);
          
            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorFacturacionTransportadoraEliminacion");
            }

        }



        /// <summary>
        /// Lista los datos de la tarifa a cobrar a las transportadoras
        /// </summary>
        /// <param name="c">Cliente de la Facturacion</param>
        /// <param name="t">Transportadora a Facturar</param>
        /// <param name="fechai">Fecha de Inicio del calculo de la facturación</param>
        /// <param name="fechaf">Fecha Fin del Cálculo de la Facturación</param>
        /// <returns>Objeto FacturacionTransportadora con los cálculos del resumen de la transportadora</returns>
        public FacturacionTransportadora listarFacturacionTransportadora(Cliente c, EmpresaTransporte t, DateTime fechai, DateTime fechaf)
        {
           FacturacionTransportadora resumen = null;


            SqlCommand comando = _manejador.obtenerProcedimiento("SelectResumenFacturacion");
            SqlDataReader datareader = null;

            if(c == null)
                _manejador.agregarParametro(comando, "@cliente", null, SqlDbType.Int);
            else
                _manejador.agregarParametro(comando, "@cliente", c.Id, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@transportadora", t, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", fechai, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fecha_fin", fechaf, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string observaciones = (string)datareader["Observaciones"];

                    DateTime fecha = (DateTime)datareader["Fecha_Inicio"];
                    DateTime fecha_fin = (DateTime)datareader["Fecha_Fin"];


                    EmpresaTransporte empresa = null;

                    if (datareader["fk_ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_transportadora = (byte)datareader["fk_ID_Transportadora"];
                        string nombre_transportadora = (string)datareader["Nombre_Transportadora"];

                        empresa = new EmpresaTransporte(id: id_transportadora, nombre: nombre_transportadora);
                    }

                    Cliente cliente = null;

                    if (datareader["fk_ID_Cliente"] != DBNull.Value)
                    {
                        short id_cliente = (short)datareader["fk_ID_Cliente"];
                        string nombre_cliente = (string)datareader["Nombre_Cliente"];

                        cliente = new Cliente(id: id_cliente, nombre: nombre_cliente);
                    }
                    
                    

                   

                     resumen = new FacturacionTransportadora(cliente: cliente, transportadora: empresa,fecha:fecha,fecha_fin:fecha_fin, id: id, observaciones: observaciones);


                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }
            return resumen;
        }



        /// <summary>
        /// Lista los datos de la tarifa a cobrar a las transportadoras
        /// </summary>
        /// <param name="c">Cliente de la Facturacion</param>
        /// <param name="t">Transportadora a Facturar</param>
        /// <param name="fechai">Fecha de Inicio del calculo de la facturación</param>
        /// <param name="fechaf">Fecha Fin del Cálculo de la Facturación</param>
        /// <returns>Objeto Decimal con los cálculos del resumen de la transportadora</returns>
        public Decimal listarCalculoFacturacion(Cliente c, EmpresaTransporte t, DateTime fechai, DateTime fechaf)
        {
            Decimal resumen = 0;


            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCalculoFacturacionTransportadora");
            SqlDataReader datareader = null;

           
            if(c == null)
                _manejador.agregarParametro(comando, "@cliente", null, SqlDbType.SmallInt);
            else
                _manejador.agregarParametro(comando, "@cliente", c.Id, SqlDbType.SmallInt);

            _manejador.agregarParametro(comando, "@transportadora", t, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha_inicial", fechai, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fecha_final", fechaf, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    if(datareader["Calculo Recargo"]!=DBNull.Value)
                        resumen = (decimal)datareader["Calculo Recargo"];
                  
                }

                comando.Connection.Close();
            }
            catch (Exception e)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }
            return resumen;
        }




        /// <summary>
        /// Lista los datos de la tarifa a cobrar a las transportadoras
        /// </summary>
        /// <param name="c">Cliente de la Facturacion</param>
        /// <param name="t">Transportadora a Facturar</param>
        /// <param name="fechai">Fecha de Inicio del calculo de la facturación</param>
        /// <param name="fechaf">Fecha Fin del Cálculo de la Facturación</param>
        /// <returns>Objeto Decimal con los cálculos del resumen de la transportadora</returns>
        public Decimal listarCalculoFacturacionSalientes(Cliente c, EmpresaTransporte t, DateTime fechai, DateTime fechaf)
        {
            Decimal resumen = 0;


            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCalculoFacturacionTransportadoraSaliente");
            SqlDataReader datareader = null;


            if (c == null)
                _manejador.agregarParametro(comando, "@cliente", null, SqlDbType.SmallInt);
            else
                _manejador.agregarParametro(comando, "@cliente", c.Id, SqlDbType.SmallInt);

            _manejador.agregarParametro(comando, "@transportadora", t, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha_inicial", fechai, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fecha_final", fechaf, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    if (datareader["Calculo Recargo"] != DBNull.Value)
                        resumen = (decimal)datareader["Calculo Recargo"];

                }

                comando.Connection.Close();
            }
            catch (Exception e)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }
            return resumen;
        }




        /// <summary>
        /// Lista los datos de la tarifa a cobrar a las transportadoras
        /// </summary>
        /// <param name="c">Cliente de la Facturacion</param>
        /// <param name="t">Transportadora a Facturar</param>
        /// <param name="fechai">Fecha de Inicio del calculo de la facturación</param>
        /// <param name="fechaf">Fecha Fin del Cálculo de la Facturación</param>
        /// <returns>Objeto Decimal con los cálculos del resumen de la transportadora</returns>
        public Decimal listarCalculoFacturacionSucursales(Cliente c, EmpresaTransporte t, DateTime fechai, DateTime fechaf)
        {
            Decimal resumen = 0;


            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCalculoFacturacionTransportadoraSucursales");
            SqlDataReader datareader = null;


            if (c == null)
                _manejador.agregarParametro(comando, "@cliente", null, SqlDbType.SmallInt);
            else
                _manejador.agregarParametro(comando, "@cliente", c.Id, SqlDbType.SmallInt);

            _manejador.agregarParametro(comando, "@transportadora", t, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha_inicial", fechai, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fecha_final", fechaf, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    if (datareader["Calculo Recargo"] != DBNull.Value)
                        resumen = (decimal)datareader["Calculo Recargo"];

                }

                comando.Connection.Close();
            }
            catch (Exception e)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }
            return resumen;
        }





        /// <summary>
        /// Lista los datos de la tarifa a cobrar a las transportadoras
        /// </summary>
        /// <param name="c">Cliente de la Facturacion</param>
        /// <param name="t">Transportadora a Facturar</param>
        /// <param name="fechai">Fecha de Inicio del calculo de la facturación</param>
        /// <param name="fechaf">Fecha Fin del Cálculo de la Facturación</param>
        /// <returns>Objeto Decimal con los cálculos del resumen de la transportadora</returns>
        public Decimal listarCalculoFacturacionProcesamiento(Cliente c, EmpresaTransporte t, DateTime fechai, DateTime fechaf)
        {
            Decimal resumen = 0;


            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCalculoFacturacionTransportadoraProcesamiento");
            SqlDataReader datareader = null;


            if (c == null)
                _manejador.agregarParametro(comando, "@cliente", null, SqlDbType.SmallInt);
            else
                _manejador.agregarParametro(comando, "@cliente", c.Id, SqlDbType.SmallInt);

            _manejador.agregarParametro(comando, "@transportadora", t, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha_inicial", fechai, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fecha_final", fechaf, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    if (datareader["Calculo Recargo"] != DBNull.Value)
                        resumen = (decimal)datareader["Calculo Recargo"];

                }

                comando.Connection.Close();
            }
            catch (Exception e)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }
            return resumen;
        }



        /// <summary>
        /// Lista los datos de la tarifa a cobrar a las transportadoras
        /// </summary>
        /// <param name="c">Cliente de la Facturacion</param>
        /// <param name="t">Transportadora a Facturar</param>
        /// <param name="fechai">Fecha de Inicio del calculo de la facturación</param>
        /// <param name="fechaf">Fecha Fin del Cálculo de la Facturación</param>
        /// <returns>Objeto Decimal con los cálculos del resumen de la transportadora</returns>
        public Decimal listarCreditosFacturacionClientes(Cliente c, EmpresaTransporte t, DateTime fechai, DateTime fechaf)
        {
            Decimal resumen = 0;


            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCalculoCreditosFacturacionTransportadora");
            SqlDataReader datareader = null;

            if(c == null)
                _manejador.agregarParametro(comando, "@cliente", null, SqlDbType.Int);
            else
                _manejador.agregarParametro(comando, "@cliente", c.Id, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@transportadora", t, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", fechai, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@fechafin", fechaf, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    if (datareader["Tarifa"] != DBNull.Value)
                        resumen = (decimal)datareader["Tarifa"];

                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }
            return resumen;
        }

        #region Categorias Facturacion Transportadora


        /// <summary>
        /// Registrar una categoria para una facturacion
        /// </summary>
        /// <param name="n">Objeto CategoriaFacturacio con los datos del nombre</param>
        /// <param name="c">FacturacionTransportadora al cual pertenece la Categoría </param>
        public void agregarCategoriaFacturacionTransportadora(ref CategoriaFacturacionTransportadora n, FacturacionTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCategoriaResumenFacturacion");

            _manejador.agregarParametro(comando, "@centro_costos", n.CentroCostos, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@modelo", n.Modelo, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@factura", n.Factura, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@monto", n.Monto, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@creditos_debitos", n.MontoCreditoDebito, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@resumen",c.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tipo", n.Categoria, SqlDbType.Int);

            try
            {
                n.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorNombreJuridicoClienteActualizacion");
            }

        }

        /// <summary>
        /// Eliminar la categoria de un resumen de facturación
        /// </summary>
        /// <param name="n">Objeto CategoriaFacturacionTransportadora con los datos del nombre a eliminar</param>
        public void eliminarCategoriaResumenFacturacion(CategoriaFacturacionTransportadora n)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCategoriaResumenFacturacion");

            _manejador.agregarParametro(comando, "@categoria_facturacion", n.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorNombreJuridicoClienteActualizacion");
            }

        }

        /// <summary>
        /// Obtener los nombres jurídicos de un cliente.
        /// </summary>
        /// <param name="c">Cliente para el cual se obtiene la lista de nombres</param>
        public void obtenerCategoriaResumenFacturacion(ref FacturacionTransportadora c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCategoriaResumenFacturacion");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@resumen", c.ID, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string centro_costos = (string)datareader["CentroCostos"];
                    string modelo = (string)datareader["Modelo"];
                    string factura = (string)datareader["Factura"];
                    CategoriasFacturacion categoria = (CategoriasFacturacion)datareader["Tipo"];
                    decimal monto = Convert.ToDecimal(datareader["Monto"]);
                    decimal creditos_debitos = Convert.ToDecimal(datareader["CreditosDebitos"]);

                    CategoriaFacturacionTransportadora categoria_facturacion = new CategoriaFacturacionTransportadora(id: id, centro_costos:centro_costos,modelo:modelo,
                        factura:factura,monto:monto,creditosdebitos: creditos_debitos, categoria : categoria);

                    
                    c.agregarCategoria(categoria_facturacion);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }

        #endregion Categorias Facturacion Transportadora

        #endregion Métodos Públicos
    }
}
