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
    public class ChequesProcesadosDL : ObjetoIndexado
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static ChequesProcesadosDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static ChequesProcesadosDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ChequesProcesadosDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public ChequesProcesadosDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo ChequesProcesados.
        /// </summary>
        /// <param name="d">Objeto ChequesProcesados con los datos del ChequesProcesados</param>
        public void agregarChequesProcesados(ref ChequesProcesados d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertChequeProcesamiento");

            _manejador.agregarParametro(comando, "@digitador", d.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@oficial_camara", d.OficialCamara, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", d.FechaRegistro, SqlDbType.Date);
            _manejador.agregarParametro(comando, "@cheques_locales_colones", d.ChequesLocalesColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cheques_locales_dolares", d.ChequesLocalesDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cheques_exterior_colones", d.ChequesExteriorColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cheques_exterior_dolares", d.ChequesExteriorDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cheques_nuestros_colones", d.ChequesNuestrosColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cheques_nuestros_dolares", d.ChequesNuestrosDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cupones_combustible", d.CuponesCombustible, SqlDbType.Decimal);


            try
            {
                d.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorChequesProcesadosRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un ChequesProcesados.
        /// </summary>
        /// <param name="d">Objeto ChequesProcesados con los datos del ChequesProcesados a actualizar</param>
        public void actualizarChequesProcesados(ChequesProcesados d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateChequesProcesados");

            _manejador.agregarParametro(comando, "@digitador", d.Digitador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@oficial_camara", d.OficialCamara, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cheques_locales_colones", d.ChequesLocalesColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cheques_locales_dolares", d.ChequesLocalesDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cheques_exterior_colones", d.ChequesExteriorColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cheques_exterior_dolares", d.ChequesExteriorDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cheques_nuestros_colones", d.ChequesNuestrosColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cheques_nuestros_dolares", d.ChequesNuestrosDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@cupones_combustible", d.CuponesCombustible, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@corte_cheque", d.ID, SqlDbType.Decimal);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorChequesProcesadosActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un ChequesProcesados.
        /// </summary>
        /// <param name="d">Objeto ChequesProcesados con los datos del ChequesProcesados a eliminar</param>
        public void eliminarChequesProcesados(ChequesProcesados d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteChequesProcesados");

            _manejador.agregarParametro(comando, "@chequesprocesados", d, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorChequesProcesadosEliminacion");
            }

        }

       
        /// <summary>
        /// Obtener una lista de los ChequesProcesadoss que tienen un determinado número de referencia o parte del mismo.
        /// </summary>
        /// <param name="r">Referencia o parte de la misma de los ChequesProcesadoss que se listarán</param>
        /// <returns>Lista de ChequesProcesadoss que cumplen con el criterio de búsqueda</returns>
        public BindingList<ChequesProcesados> listarChequesProcesadossPorReferencia(DateTime fecha, DateTime fecha_fin, Colaborador oficial, Colaborador digitador)
        {
            BindingList<ChequesProcesados> ChequesProcesadoss = new BindingList<ChequesProcesados>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectChequesProcesados");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha_inicio", fecha , SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha_fin", fecha_fin, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@oficial", oficial, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@digitador", digitador, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["ID_ChequesProcesados"];
                    decimal cheques_locales_colones = (decimal)datareader["Cheques_Locales_Colones"];
                    decimal cheques_locales_dolares = (decimal)datareader["Cheques_Locales_Dolares"];
                    decimal cheques_externos_dolares = (decimal)datareader["Cheques_Exterior_Dolares"];
                    decimal cheques_externos_colones = (decimal)datareader["Cheques_Exterior_Colones"];
                    decimal cheques_nuestros_colones = (decimal)datareader["Cheques_Nuestros_Colones"];
                    decimal cheques_nuestros_dolares = (decimal)datareader["Cheques_Nuestros_Dolares"];
                    decimal cupones_combustibles = (decimal)datareader["Cheques_Combustible"];
                    DateTime fecha_registro = (DateTime)datareader["Fecha"];

                    Colaborador digitador_res = null;

                    if(datareader["Digitador"]!=DBNull.Value)
                    {
                        int id_digitador = (int)datareader["id_digitador"];
                        string nombre_digitador = (string)datareader["nombre_digitador"];
                        string primer_apellido_digitador = (string)datareader["primer_apellido_digitador"];
                        string segundo_apellido_digitador = (string)datareader["segundo_apellido_digitador"];
                        string clave_cef = (string)datareader["Clave_IBS"];

                        digitador_res = new Colaborador(id: id_digitador, nombre: nombre_digitador, primer_apellido: primer_apellido_digitador, segundo_apellido: segundo_apellido_digitador, clave_cef: clave_cef);

                    }


                    Colaborador oficial_res = null; 
                    if (datareader["OficialCamara"] != DBNull.Value)
                    {
                        int id_oficial = (int)datareader["id_oficial"];
                        string nombre_oficial = (string)datareader["nombre_oficial"];
                        string primer_apellido_oficial = (string)datareader["primer_apellido_oficial"];
                        string segundo_apellido_oficial = (string)datareader["segundo_apellido_oficial"];

                        oficial_res = new Colaborador(id: id_oficial, nombre: nombre_oficial, primer_apellido: primer_apellido_oficial, segundo_apellido: segundo_apellido_oficial);
                    }


                    ChequesProcesados ChequesProcesados = new ChequesProcesados(id: id, cheques_exterior_colones: cheques_externos_colones, cheques_exterior_dolares: cheques_externos_dolares,
                        cheques_locales_colones: cheques_locales_colones, cheques_locales_dolares: cheques_locales_dolares, cheques_nuestros_colones: cheques_nuestros_colones, cheques_nuestros_dolares:cheques_nuestros_dolares,
                        cupones_combustible: cupones_combustibles, fecha: fecha_registro, digitador: digitador_res, oficial_camara: oficial_res);

                    ChequesProcesadoss.Add(ChequesProcesados);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return ChequesProcesadoss;
        }




        #region Cortes Cheques

        /// <summary>
        /// Permite consultar el cuadre de depósitos de un día
        /// </summary>
        /// <param name="c">Objeto Cliente con los datos del Cliente</param>
        /// <param name="p">Objeto PuntoVenta con los datos del punto de venta</param>
        /// <param name="f">Fecha del cuadre</param>
        /// <returns>Una lista de cuadres por cuenta de la fecha seleccionada</returns>
        public void listarCortesCheque(ref ChequesProcesados ch)
        {
            BindingList<CorteCheque> cargas = new BindingList<CorteCheque>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCorteCheque");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cheque_procesamiento", ch, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_corte = (int)datareader["pk_ID"];
                    int numero = (int)datareader["Numero"];


                    CorteCheque carga = new CorteCheque(id: id_corte, numero: numero);

                    ch.agregarCorteCheque(carga);
                        
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }


        }



      


        /// <summary>
        /// Inserta o actualiza un cuadre de depósito
        /// </summary>
        /// <param name="d">Objeto CuadreChequesProcesados con los datos del cuadre</param>
        public void agregarCorteCheque(ref CorteCheque c, ChequesProcesados ch)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCorteCheque");

            _manejador.agregarParametro(comando, "@numero", c.NumeroCorte, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@chequeprocesado", ch, SqlDbType.Int);

            try
            {
                c.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorChequesProcesadosRegistro");
            }

        }



        /// <summary>
        /// Inserta o actualiza un cuadre de depósito
        /// </summary>
        /// <param name="d">Objeto CuadreChequesProcesados con los datos del cuadre</param>
        public void eliminarCorteCheque(ref CorteCheque c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCorteCheque");

            _manejador.agregarParametro(comando, "@corte", c, SqlDbType.Int);


            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorChequesProcesadosRegistro");
            }

        }


        #endregion Cortes Cheques


        #region Cheques


        /// <summary>
        /// Permite consultar el cuadre de depósitos de un día
        /// </summary>
        /// <param name="c">Objeto Cliente con los datos del Cliente</param>
        /// <param name="p">Objeto PuntoVenta con los datos del punto de venta</param>
        /// <param name="f">Fecha del cuadre</param>
        /// <returns>Una lista de cuadres por cuenta de la fecha seleccionada</returns>
        public void listarCheque(ref CorteCheque ch)
        {
            BindingList<Cheque> cargas = new BindingList<Cheque>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCheque");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@corte", ch, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_cheque = (int)datareader["pk_ID"];
                    DateTime hora = (DateTime)datareader["Hora"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    decimal monto = (decimal)datareader["Monto"];
                    TipoCheque tipo = (TipoCheque)datareader["Tipo"];

                    Colaborador entregadoa = null; 


                    if(datareader["EntregadoA"]!= DBNull.Value)
                    {
                        int id_entregado = (int)datareader["EntregadoA"];
                        string nombre_entregado = (string)datareader["Nombre_Entregado"];
                        string primer_apellido = (string)datareader["Primer_Apellido_Entregado"];
                        string segundo_apellido_entregado = (string)datareader["Segundo_Apellido_Entregado"];

                        entregadoa = new Colaborador(id: id_entregado, nombre: nombre_entregado, primer_apellido: primer_apellido, segundo_apellido: segundo_apellido_entregado);

                    }


                    Cheque carga = new Cheque(id: id_cheque,fecha:hora,tipoc:tipo,rechazo: false, moneda:moneda, monto: monto, usuario_entrega: entregadoa);

                    ch.agregarDatos(carga);

                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }


        }





        /// <summary>
        /// Inserta o actualiza un cuadre de depósito
        /// </summary>
        /// <param name="d">Objeto CuadreChequesProcesados con los datos del cuadre</param>
        public void agregarCheque(ref Cheque cheque, CorteCheque corte)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCheque");

            _manejador.agregarParametro(comando, "@entregado", cheque.UsuarioEntrega, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@hora", cheque.HoraRegistro, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@monto", cheque.Monto, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@moneda", cheque.Moneda, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@tipo", cheque.TipoCheque, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@rechazo", cheque.Rechazo, SqlDbType.Bit);
            _manejador.agregarParametro(comando, "@corte", corte, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cantidad", cheque.Cantidad, SqlDbType.Int);

            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorChequesProcesadosRegistro");
            }

        }



        /// <summary>
        /// Inserta o actualiza un cuadre de depósito
        /// </summary>
        /// <param name="d">Objeto CuadreChequesProcesados con los datos del cuadre</param>
        public void eliminarCorteCheque(ref Cheque c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCheque");

            _manejador.agregarParametro(comando, "@cheque", c, SqlDbType.Int);


            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorChequesProcesadosRegistro");
            }

        }



        #endregion Cheques




        #region Cheques Rechazo


        /// <summary>
        /// Permite consultar el cuadre de depósitos de un día
        /// </summary>
        /// <param name="c">Objeto Cliente con los datos del Cliente</param>
        /// <param name="p">Objeto PuntoVenta con los datos del punto de venta</param>
        /// <param name="f">Fecha del cuadre</param>
        /// <returns>Una lista de cuadres por cuenta de la fecha seleccionada</returns>
        public void listarChequeRechazo(ref ChequesProcesados ch)
        {
            BindingList<Cheque> cargas = new BindingList<Cheque>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectChequesRechazo");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@corte", ch, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_cheque = (int)datareader["pk_ID"];
                    Monedas moneda = (Monedas)datareader["Moneda"];
                    decimal monto = (decimal)datareader["Monto"];
                    int numero = (int)datareader["Cantidad"];

                    
                    Cheque carga = new Cheque(id: id_cheque, rechazo: true, moneda: moneda, monto: monto, cantidad:numero);

                    ch.agregarChequeRechazado(carga);

                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }


        }





        /// <summary>
        /// Inserta o actualiza un cuadre de depósito
        /// </summary>
        /// <param name="d">Objeto CuadreChequesProcesados con los datos del cuadre</param>
        public void agregarChequeRechazo(ref Cheque cheque, ChequesProcesados ch)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertChequeRechazo");

            _manejador.agregarParametro(comando, "@monto", cheque.Monto, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@moneda", cheque.Moneda, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@numero", cheque.Cantidad, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cheque", ch, SqlDbType.Int);
            


            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorChequesProcesadosRegistro");
            }

        }



        /// <summary>
        /// Inserta o actualiza un cuadre de depósito
        /// </summary>
        /// <param name="d">Objeto CuadreChequesProcesados con los datos del cuadre</param>
        public void eliminarCorteChequeRechazo(ref Cheque c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCheque");

            _manejador.agregarParametro(comando, "@cheque", c, SqlDbType.Int);


            try
            {
                _manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorChequesProcesadosRegistro");
            }

        }



        #endregion Cheques Rechazo


        #endregion Métodos Públicos
    }
}
