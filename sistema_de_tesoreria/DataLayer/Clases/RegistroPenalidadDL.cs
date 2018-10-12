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
    public class RegistroPenalidadDL 
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static RegistroPenalidadDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static RegistroPenalidadDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new RegistroPenalidadDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public RegistroPenalidadDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar una nueva cámara.
        /// </summary>
        /// <param name="c">Objeto RegistroPenalidad con los datos de la nueva cámara</param>
        public void agregarRegistroPenalidad(ref RegistroPenalidad c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertRegistroPenalidad");

            _manejador.agregarParametro(comando, "@colaborador", c.Colaborador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@punto_venta", c.Punto_Venta.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@penalidad", c.Penalidad.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@transportadora", c.Transportadora, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@prontoaviso", c.Pronto_Aviso, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha_Registro, SqlDbType.DateTime);

            try
            {
                c.Id = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroPenalidadRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de una cámara.
        /// </summary>
        /// <param name="c">Objeto RegistroPenalidad con los datos de la cámara a actualizar</param>
        public void actualizarRegistroPenalidad(RegistroPenalidad c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateRegistroPenalidad");

            _manejador.agregarParametro(comando, "@colaborador", c.Colaborador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@punto_venta", c.Punto_Venta.Id, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@penalindad", c.Penalidad.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@transportadora", c.Transportadora, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@prontoaviso", c.Pronto_Aviso, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha_Registro, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@registro", c.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroPenalidadActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de una cámara.
        /// </summary>
        /// <param name="c">Objeto RegistroPenalidad con los datos de la cámara a eliminar</param>
        public void eliminarRegistroPenalidad(RegistroPenalidad c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteRegistroPenalidad");

            _manejador.agregarParametro(comando, "@registro", c.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroPenalidadEliminacion");
            }

        }

        /// <summary>
        /// Listar todas las registros registradas.
        /// </summary>
        /// <returns>Lista de registros registradas en el sistema</returns>
        public BindingList<RegistroPenalidad> listarRegistroPenalidades(DateTime fecha, DateTime fechafin, PuntoVenta p, EmpresaTransporte emp)
        {
            BindingList<RegistroPenalidad> camaras = new BindingList<RegistroPenalidad>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectRegistroPenalidades");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@transportadora", emp, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@fecha", fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fechafin", fechafin, SqlDbType.DateTime);
            if(p!= null)
                _manejador.agregarParametro(comando, "@punto", p.Id, SqlDbType.SmallInt);
            else
                _manejador.agregarParametro(comando, "@punto", p, SqlDbType.SmallInt);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["ID_Registro"];

                    DateTime fecha_registro = (DateTime)datareader["Fecha"];


                    int id_penalidad = (int)datareader["ID_Penalidad"];
                    string descripcion_penalidad = (string)datareader["Descripcion_Penalidad"];

                    int id_tipo_penalidad = (int)datareader["ID_TipoPenalidad"];
                    string descripcion_tipo_penalidad = (string)datareader["Descripcion_TipoPenalidad"];

                    TipoPenalidad tipo = new TipoPenalidad(id:(short)id_tipo_penalidad,nombre:descripcion_tipo_penalidad);

                    Penalidad penalidad = new Penalidad(id:id_penalidad,descripcion:descripcion_penalidad, tipopenalidad : tipo);


                    short id_punto = (short)datareader["ID_Punto"];
                    string nombre_punto = (string)datareader["Nombre_Punto"];


                    short id_cliente = (short)datareader["ID_Cliente"];
                    string nombre_cliente = (string)datareader["Nombre_Cliente"];
                    string centrocostos = "";

                    if (datareader["CentroCostos"] != DBNull.Value)
                    {
                        centrocostos = (string)datareader["CentroCostos"];
                    }

                    decimal entrega_niquel = 0;

                    if (datareader["Tarifa_Niquel"] != DBNull.Value)
                    {
                        entrega_niquel = (decimal)datareader["Tarifa_Niquel"];
                    }
                    
                    //Monedas moneda_niquel = (Monedas)datareader["MonedaEntregaNiquel"];

                    Monedas moneda_feriado = Monedas.Colones;

                    if (datareader["Moneda_Tarifa_Feriado"] != DBNull.Value)
                    {
                        moneda_feriado = (Monedas)datareader["Moneda_Tarifa_Feriado"];
                    }

                    


                    Monedas moneda_tarifa = Monedas.Colones;

                    if (datareader["Moneda_Tarifa_Regular"] != DBNull.Value)
                    {
                        moneda_tarifa = (Monedas)datareader["Moneda_Tarifa_Regular"];
                    }




                    decimal recargo = 0;
                    if (datareader["Recargo"] != DBNull.Value)
                    {
                        recargo = (decimal)datareader["Recargo"];
                    }

                    decimal tarifa_feriado = 0;

                    if (datareader["Tarifa_Feriados"] != DBNull.Value) 
                    {
                        tarifa_feriado = (decimal)datareader["Tarifa_Feriados"];
                    }


                    decimal tarifa_regular = 0;

                    if (datareader["Tarifa_Regular"] != DBNull.Value)
                    {
                        tarifa_regular = (decimal)datareader["Tarifa_Regular"];
                    }


                    decimal tope = 0;

                    if (datareader["Tope"] != DBNull.Value)
                    {
                        tope = (decimal)datareader["Tope"];
                    }


                    double tarifa = 0;

                    if (datareader["Tarifa"] != DBNull.Value)
                    {
                        tarifa = (double)datareader["Tarifa"];
                    }

                    double nivel_servicio = 0;

                    if (datareader["Nivel Servicio"] != DBNull.Value)
                    {
                        nivel_servicio = (double)datareader["Nivel Servicio"];
                    }

                    Cliente cliente = new Cliente(id: (short)id_cliente,nombre:nombre_cliente);

                    PuntoVenta punto = new PuntoVenta(id: (short)id_punto, nombre: nombre_punto, cliente: cliente);
                    punto.CentroCostos = centrocostos;
                    punto.EntregaNiquel = entrega_niquel;
                    punto.MonedaTarifaFeriados = moneda_feriado;
                    punto.MonedaTarifaRegular = moneda_tarifa;
                    punto.TarifaFeriado = tarifa_feriado;
                    punto.TarifaRegular = tarifa_regular;
                    punto.Tope = tope;
                    punto.Recargo = recargo;
                   


                    byte id_transportadora = (byte)datareader["ID_Transportadora"];
                    string nombre_transportadora = (string)datareader["Nombre_Transportadora"];


                    bool pronto_aviso = (bool)datareader["Pronto_Aviso"];

                    EmpresaTransporte empresa = new EmpresaTransporte(id: id_transportadora, nombre: nombre_transportadora);


                    RegistroPenalidad camara = new RegistroPenalidad(id: id, transportadora: empresa, penalidad: penalidad, punto: punto, pronto_aviso: pronto_aviso, fecha_registro: fecha_registro, nivel_s: nivel_servicio);
                    camara.Tarifa = Convert.ToDecimal(tarifa);

                    camaras.Add(camara);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return camaras;
        }

        
   
        #endregion Métodos Públicos
    }
}
