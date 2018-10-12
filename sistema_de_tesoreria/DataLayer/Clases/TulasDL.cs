//
//  @ Project : 
//  @ Date : 29/04/2011
//  @ Author : Erick Chavarría 

using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;
using CommonObjects.Clases;

namespace DataLayer
{

    /// <summary>
    /// Clase de la capa de datos que maneja las tulas.
    /// </summary>
    public class TulasDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static TulasDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static TulasDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new TulasDL();
                return _instancia;
            }
        }

        // Comunicación con la capa de datos

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public TulasDL() { }

        #endregion Constructor

        #region Métodos Públicos

        #region SITES
       
        /// <summary>
        /// Actualiza los datos de Compass a SITES
        /// </summary>
        /// <param name="f">Fecha de la recepción</param>
        public void actualizarDatosCompass(DateTime f)
        {

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectSincronizacionCompassSITES");

            _manejador.agregarParametro(comando, "@fecha", f, SqlDbType.Date);
            comando.CommandTimeout = 600;


            try
            {

                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaATMActualizacion");
            }



        }


        /// <summary>
        /// Actualiza los datos de Compass a SITES
        /// </summary>
        /// <param name="f">Fecha de la recepción</param>
        public void actualizarAlarmasPapel(DateTime f)
        {

            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateAlarmasPapel");

            comando.CommandTimeout = 600;


            try
            {

                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCargaATMActualizacion");
            }



        }

        #region Bolsas 

        /// <summary>
        /// Listar todos las tulas de un manifiesto de sucursal.
        /// </summary>
        /// <param name="m">Manifiesto para el cual se desean listar las tulas</param>
        /// <returns>Lista de tulas registrados para el manifiesto indicado</returns>
        public BindingList<Bolsa> listarBolsasSucursales()
        {
            BindingList<Bolsa> bolsas = new BindingList<Bolsa>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTulasSucursales");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["ID_Tula"];
                    string serie = (string)datareader["Serie_Bolsa"];
                    DateTime fecha_ingreso = (DateTime)datareader["Fecha"];

                    ManifiestoSucursalCarga manifiesto = new ManifiestoSucursalCarga();

                    if (datareader["ID_Manifiesto"] != DBNull.Value)
                    {
                        int id_manifiesto = (int)datareader["ID_Manifiesto"];
                        string codigo = "";
                        if (datareader["Codigo"] != DBNull.Value)
                        { codigo = (string)datareader["Codigo"]; }

                        manifiesto = new ManifiestoSucursalCarga(id: id_manifiesto, codigo: codigo);
                    }
                    Colaborador colaborador = new Colaborador();
                    if (datareader["ID_Colaborador"] != DBNull.Value)
                    {
                        int id_colaborador = (int)datareader["ID_Colaborador"];
                        string nombre = (string)datareader["Nombre"];
                        string primer_apellido = (string)datareader["Primer_Apellido"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido"];

                        colaborador = new Colaborador(id: id_colaborador, nombre: nombre,
                             primer_apellido: primer_apellido, segundo_apellido: segundo_apellido);
                    }

                    Sucursal sucursal = new Sucursal();
                    if (datareader["ID_Sucursal"] != DBNull.Value)
                    {
                        short id_sucursal = (short)datareader["ID_Sucursal"];
                        string nombre_surcursal = (string)datareader["Nombre_Sucursal"];

                        sucursal.DB_ID = id_sucursal;
                        sucursal.Nombre = nombre_surcursal;
                    }

                    EmpresaTransporte transportadora = new EmpresaTransporte();
                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_transportadora = (byte)datareader["ID_Transportadora"];
                        string nombre_transportadora = (string)datareader["Nombre_Transportadora"];

                        transportadora.DB_ID = id_transportadora;
                        transportadora.Nombre = nombre_transportadora;
                    }

                    Bolsa bolsa = new Bolsa(serie: serie, id: id, fecha_ingreso: fecha_ingreso);
                    bolsa.SerieBolsa = serie;
                    bolsa.Colaborador = colaborador;
                    bolsa.Manifiesto = manifiesto;
                    bolsa.Sucursal = sucursal;
                    bolsa.Transportadora = transportadora;
                    bolsas.Add(bolsa);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return bolsas;
        }


        /// <summary>
        /// Registrar una tula en el sistema.
        /// </summary>
        /// <param name="b">Objeto Bolsa con los datos de la tula</param>
        public void agregarBolsaSucursal(ref Bolsa b)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertBolsaSucursal");

            _manejador.agregarParametro(comando, "@Serie_Tula", b.SerieBolsa, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@manifiesto", b.Manifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@colaborador", b.Colaborador, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@montocolones", b.MontoColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@montodolares", b.MontoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@montoeuros", b.MontoEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@idcargasucursal", b.IDCargaSucursal, SqlDbType.Decimal);
            
            try
            {
                b.DB_ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaRegistro");
            }

        }

        /// <summary>
        /// Verifica la existencia de una tula sucursal en el sistema.
        /// </summary>
        /// <param name="b">Objeto Bolsa con los datos de la tula a buscar</param>
         public bool verificarBolsaSucursal(ref Bolsa b)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteBolsaSucursal");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@serie_tula", b.SerieBolsa, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@manifiesto", b.Manifiesto, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.HasRows)
                {
                    datareader.Read();
                    int id = (int)datareader["Pk_ID"];
                    DateTime fecha = (DateTime)datareader["Fecha"];
                    
                    b.DB_ID = id;
                    b.Fecha_ingreso = fecha;

                    existe = true;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarTulaDuplicada");
            }

            return existe;
        }

         /// <summary>
         /// Elimina tula sucursal del sistema.
         /// </summary>
         /// <param name="b">Objeto Bolsa con los datos de la tula a eliminar</param>

         public void eliminarBolsa(Bolsa b)
         {
             SqlCommand comando = _manejador.obtenerProcedimiento("DeleteBolsaSucursal");

             _manejador.agregarParametro(comando, "@bolsa", b, SqlDbType.Int);

             try
             {
                 _manejador.ejecutarConsultaActualizacion(comando);
                 comando.Connection.Close();
             }
             catch (Exception)
             {
                 comando.Connection.Close();
                 throw new Excepcion("ErrorTulaEliminacion");
             }
         }


         /// <summary>
         /// Listar todos las tulas de un manifiesto de sucursal.
         /// </summary>
         /// <param name="m">Manifiesto para el cual se desean listar las tulas</param>
         /// <returns>Lista de tulas registrados para el manifiesto indicado</returns>
         public BindingList<Bolsa> listarBolsasSucursalPorManifiesto(ref ManifiestoSucursalCarga m)
         {
             BindingList<Bolsa> bolsas = new BindingList<Bolsa>();

             SqlCommand comando = _manejador.obtenerProcedimiento("SelectBolsaSucursal");
             SqlDataReader datareader = null;

             _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.VarChar);

             try
             {
                 datareader = _manejador.ejecutarConsultaDatos(comando);

                 while (datareader.Read())
                 {
                     int id = (int)datareader["Pk_ID"];
                     string serie = (string)datareader["Serie_Bolsa"];
                     DateTime fecha_ingreso = (DateTime)datareader["Fecha"];

                     Decimal montocolones = 0;
                     Decimal montodolares = 0;
                     Decimal montoeuros = 0;

                     if (datareader["MontoColones"] != DBNull.Value)
                         montocolones = (Decimal)datareader["MontoColones"];

                     if (datareader["MontoDolares"] != DBNull.Value)
                         montodolares = (Decimal)datareader["MontoDolares"];

                     if (datareader["MontoEuros"] != DBNull.Value)
                         montoeuros = (Decimal)datareader["MontoEuros"];

                     Bolsa bolsa = new Bolsa(id:id, serie:serie, fecha_ingreso: fecha_ingreso, montocoloes:montocolones,montodolares:montodolares, montoeuros:montoeuros);
                     bolsa.SerieBolsa = serie;
                     bolsas.Add(bolsa);
                 }

                 comando.Connection.Close();
             }
             catch (Exception)
             {
                 comando.Connection.Close();
                 throw new Excepcion("ErrorDatosConexion");
             }

             return bolsas;
         }





         /// <summary>
         /// Registrar una tula en el sistema.
         /// </summary>
         /// <param name="b">Objeto Bolsa con los datos de la tula</param>
         public void actualizarBolsaSucursal(ref Bolsa b)
         {
             SqlCommand comando = _manejador.obtenerProcedimiento("UpdateBolsaSucursal");

             _manejador.agregarParametro(comando, "@Serie_Tula", b.SerieBolsa, SqlDbType.VarChar);
             _manejador.agregarParametro(comando, "@montocolones", b.MontoColones, SqlDbType.Decimal);
             _manejador.agregarParametro(comando, "@montodolares", b.MontoDolares, SqlDbType.Decimal);
             _manejador.agregarParametro(comando, "@montoeuros", b.MontoEuros, SqlDbType.Decimal);
             _manejador.agregarParametro(comando, "@tula", b, SqlDbType.Int);

             try
             {
                 _manejador.ejecutarConsultaActualizacion(comando);
                 comando.Connection.Close();
             }
             catch (Exception)
             {
                 comando.Connection.Close();
                 throw new Excepcion("ErrorTulaRegistro");
             }

         }

        #endregion Bolsas

        #region BolsasBanco



         /// <summary>
         /// Listar todos las tulas de un manifiesto de sucursal.
         /// </summary>
         /// <param name="m">Manifiesto para el cual se desean listar las tulas</param>
         /// <returns>Lista de tulas registrados para el manifiesto indicado</returns>
         public BindingList<BolsaBanco> listarBolsasBancos()
         {
             BindingList<BolsaBanco> bolsas = new BindingList<BolsaBanco>();

             SqlCommand comando = _manejador.obtenerProcedimiento("SelectTulasSucursales");
             SqlDataReader datareader = null;

             try
             {
                 datareader = _manejador.ejecutarConsultaDatos(comando);

                 while (datareader.Read())
                 {
                     int id = (int)datareader["ID_Tula"];
                     string serie = (string)datareader["Serie_Bolsa"];
                     DateTime fecha_ingreso = (DateTime)datareader["Fecha"];

                     ManifiestoSucursalCarga manifiesto = new ManifiestoSucursalCarga();

                     
                     Colaborador colaborador = new Colaborador();
                     if (datareader["ID_Colaborador"] != DBNull.Value)
                     {
                         int id_colaborador = (int)datareader["ID_Colaborador"];
                         string nombre = (string)datareader["Nombre"];
                         string primer_apellido = (string)datareader["Primer_Apellido"];
                         string segundo_apellido = (string)datareader["Segundo_Apellido"];

                         colaborador = new Colaborador(id: id_colaborador, nombre: nombre,
                              primer_apellido: primer_apellido, segundo_apellido: segundo_apellido);
                     }

                     Canal sucursal = new Canal();
                     if (datareader["ID_Canal"] != DBNull.Value)
                     {
                         short id_sucursal = (short)datareader["ID_Canal"];
                         string nombre_surcursal = (string)datareader["Nombre_Canal"];

                         sucursal.Id = id_sucursal;
                         sucursal.Nombre = nombre_surcursal;
                     }

                     EmpresaTransporte transportadora = new EmpresaTransporte();
                     if (datareader["ID_Transportadora"] != DBNull.Value)
                     {
                         byte id_transportadora = (byte)datareader["ID_Transportadora"];
                         string nombre_transportadora = (string)datareader["Nombre_Transportadora"];

                         transportadora.DB_ID = id_transportadora;
                         transportadora.Nombre = nombre_transportadora;
                     }

                     BolsaBanco bolsa = new BolsaBanco(serie: serie, id: id, fecha_ingreso: fecha_ingreso);
                     bolsa.SerieBolsa = serie;
                     bolsa.Colaborador = colaborador;
                     bolsa.Canal = sucursal;
                     bolsa.Transportadora = transportadora;
                     bolsas.Add(bolsa);
                 }

                 comando.Connection.Close();
             }
             catch (Exception)
             {
                 comando.Connection.Close();
                 throw new Excepcion("ErrorDatosConexion");
             }

             return bolsas;
         }


         /// <summary>
         /// Registrar una tula en el sistema.
         /// </summary>
         /// <param name="b">Objeto BolsaBanco con los datos de la tula</param>
         public void agregarBolsaBanco(ref BolsaBanco b)
         {
             SqlCommand comando = _manejador.obtenerProcedimiento("InsertBolsaBanco");

             _manejador.agregarParametro(comando, "@Serie_Tula", b.SerieBolsa, SqlDbType.VarChar);
             _manejador.agregarParametro(comando, "@manifiesto", b.Manifiesto, SqlDbType.Int);
             _manejador.agregarParametro(comando, "@montocolones", b.MontoColones, SqlDbType.Decimal);
             _manejador.agregarParametro(comando, "@montodolares", b.MontoDolares, SqlDbType.Decimal);
             _manejador.agregarParametro(comando, "@montoeuros", b.MontoEuros, SqlDbType.Decimal);

             try
             {
                 b.DB_ID = (int)_manejador.ejecutarEscalar(comando);
                 comando.Connection.Close();
             }
             catch (Exception)
             {
                 comando.Connection.Close();
                 throw new Excepcion("ErrorTulaRegistro");
             }

         }


         /// <summary>
         /// Registrar una tula en el sistema.
         /// </summary>
         /// <param name="b">Objeto BolsaBanco con los datos de la tula</param>
         public void actualizarBolsaBanco(ref BolsaBanco b)
         {
             SqlCommand comando = _manejador.obtenerProcedimiento("UpdateBolsaBanco");

             _manejador.agregarParametro(comando, "@Serie_Tula", b.SerieBolsa, SqlDbType.VarChar);
             _manejador.agregarParametro(comando, "@montocolones", b.MontoColones, SqlDbType.Decimal);
             _manejador.agregarParametro(comando, "@montodolares", b.MontoDolares, SqlDbType.Decimal);
             _manejador.agregarParametro(comando, "@montoeuros", b.MontoEuros, SqlDbType.Decimal);
             _manejador.agregarParametro(comando, "@tula", b, SqlDbType.Int);

             try
             {
                 _manejador.ejecutarConsultaActualizacion(comando);
                 comando.Connection.Close();
             }
             catch (Exception)
             {
                 comando.Connection.Close();
                 throw new Excepcion("ErrorTulaRegistro");
             }

         }


         /// <summary>
         /// Verifica la existencia de una tula sucursal en el sistema.
         /// </summary>
         /// <param name="b">Objeto Bolsa con los datos de la tula a buscar</param>
         public bool verificarBolsaBanco(ref BolsaBanco b)
         {
             bool existe = false;

             SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteBolsaBanco");
             SqlDataReader datareader = null;

             _manejador.agregarParametro(comando, "@serie_tula", b.SerieBolsa, SqlDbType.VarChar);
             _manejador.agregarParametro(comando, "@manifiesto", b.Manifiesto, SqlDbType.Int);

             try
             {
                 datareader = _manejador.ejecutarConsultaDatos(comando);

                 if (datareader.HasRows)
                 {
                     datareader.Read();
                     int id = (int)datareader["Pk_ID"];
                     DateTime fecha = (DateTime)datareader["Fecha"];

                     b.DB_ID = id;
                     b.Fecha_ingreso = fecha;

                     existe = true;
                 }

                 comando.Connection.Close();
             }
             catch (Exception)
             {
                 comando.Connection.Close();
                 throw new Excepcion("ErrorVerificarTulaDuplicada");
             }

             return existe;
         }

         /// <summary>
         /// Elimina tula sucursal del sistema.
         /// </summary>
         /// <param name="b">Objeto Bolsa con los datos de la tula a eliminar</param>

         public void eliminarBolsaBanco(BolsaBanco b)
         {
             SqlCommand comando = _manejador.obtenerProcedimiento("DeleteBolsaBanco");

             _manejador.agregarParametro(comando, "@bolsa", b, SqlDbType.Int);

             try
             {
                 _manejador.ejecutarConsultaActualizacion(comando);
                 comando.Connection.Close();
             }
             catch (Exception)
             {
                 comando.Connection.Close();
                 throw new Excepcion("ErrorTulaEliminacion");
             }
         }


         /// <summary>
         /// Listar todos las tulas de un manifiesto de sucursal.
         /// </summary>
         /// <param name="m">Manifiesto para el cual se desean listar las tulas</param>
         /// <returns>Lista de tulas registrados para el manifiesto indicado</returns>
         public void listarBolsasBancoPorManifiesto(ref ManifiestoPedidoBanco m)
         {
              SqlCommand comando = _manejador.obtenerProcedimiento("SelectBolsaBanco");
             SqlDataReader datareader = null;

             _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.VarChar);

             try
             {
                 datareader = _manejador.ejecutarConsultaDatos(comando);

                 while (datareader.Read())
                 {
                     int id = (int)datareader["Pk_ID"];
                     string serie = (string)datareader["Serie_Bolsa"];
                     DateTime fecha_ingreso = (DateTime)datareader["Fecha"];
                     Decimal montocolones = 0;
                     Decimal montodolares = 0;
                     Decimal montoeuros = 0;

                     //if (datareader["MontoColones"] != DBNull.Value)
                     //    montocolones = (Decimal)datareader["MontoColones"];

                     //if (datareader["MontoDolares"] != DBNull.Value)
                     //    montodolares = (Decimal)datareader["MontoDolares"];

                     //if (datareader["MontoEuros"] != DBNull.Value)
                     //    montoeuros = (Decimal)datareader["MontoEuros"];


                     BolsaBanco bolsa = new BolsaBanco(id:id, serie: serie, fecha_ingreso: fecha_ingreso, montocolones: montocolones, montodolares: montodolares, montoeuros: montoeuros);
                     bolsa.SerieBolsa = serie;
                     if (m.Serie_Tula == null)
                         m.Serie_Tula = new BindingList<BolsaBanco>();
                     m.agregarBolsa(bolsa);
                 }

                 comando.Connection.Close();
             }
             catch (Exception)
             {
                 comando.Connection.Close();
                 throw new Excepcion("ErrorDatosConexion");
             }


         }

            


         #endregion BolsasBanco

        #region Tulas

        public void agregarTulaDocumento(ref Tula t)
         {
             SqlCommand comando = _manejador.obtenerProcedimiento("InsertTulaDocumento");

             _manejador.agregarParametro(comando, "@codigo", t.Codigo, SqlDbType.VarChar);
             _manejador.agregarParametro(comando, "@manifiesto", t.Manifiesto.ID, SqlDbType.Int);

             try
             {
                 t.ID = (int)_manejador.ejecutarEscalar(comando);
                 comando.Connection.Close();
             }
             catch (Exception)
             {
                 comando.Connection.Close();
                 throw new Excepcion("ErrorTulaRegistro");
             }

         }
         /// <summary>
        /// Registrar una tula en el sistema.
        /// </summary>
        /// <param name="t">Objeto Tula con los datos de la tula</param>
        public void agregarTula(ref Tula t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertTula");

            _manejador.agregarParametro(comando, "@codigo", t.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@manifiesto", t.Manifiesto, SqlDbType.Int);

            try
            {
                t.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaRegistro");
            }

        }
        

        /// <summary>
        /// Registrar una tula en el sistema.
        /// </summary>
        /// <param name="t">Objeto Tula con los datos de la tula</param>
        public void agregarTulaNiquel(ref Tula t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertTulaNiquel");

            _manejador.agregarParametro(comando, "@codigo", t.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@manifiesto", t.Manifiesto, SqlDbType.Int);

            try
            {
                t.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaRegistro");
            }

        }

        /// <summary>
        /// Agregar una tula no registrada por un receptor en el sistema.
        /// </summary>
        /// <param name="t">Objeto Tula con los datos de la tula</param>
        /// <param name="c">Coordinador que registra la tula</param>
        public void agregarTula(ref Tula t, Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertTulaTardia");

            _manejador.agregarParametro(comando, "@codigo", t.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@manifiesto", t.Manifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", t.Fecha_ingreso, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@coordinador", c, SqlDbType.Int);

            try
            {
                t.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaRegistro");
            }

        }

        /// <summary>
        /// Cambiar el manifiesto al cual pertenece una tula.
        /// </summary>
        /// <param name="t">Objeto Tula con los datos de la tula que se actualizará</param>
        /// <param name="c">Coordinador que actualiza la tula</param>
        public void actualizarTulaManifiesto(Tula t, Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateTulaManifiesto");

            _manejador.agregarParametro(comando, "@manifiesto", t.Manifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tula", t, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaActualizacion");
            }

        }

        public void actualizarTulaDocumento(Tula t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateTulaDocumento");

            _manejador.agregarParametro(comando, "@codigo", t.Codigo, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@tula", t.ID, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaActualizacion");
            }

        }

        /// <summary>
        /// Eliminar una tula de la base de datos.
        /// </summary>
        /// <param name="c">Objeto Tula con los datos de la tula a eliminar</param>
        public void eliminarTula(Tula t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteTula");

            _manejador.agregarParametro(comando, "@tula", t, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaEliminacion");
            }

        }

        public void eliminarTulaDocumento(Tula t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteTulaDocumento");

            _manejador.agregarParametro(comando, "@tula", t, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaEliminacion");
            }

        }




        /// <summary>
        /// Eliminar una tula de la base de datos, del area de entrega de niquel
        /// </summary>
        /// <param name="c">Objeto Tula con los datos de la tula a eliminar</param>
        public void eliminarTulaNiquel(Tula t)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteTulaNiquel");

            _manejador.agregarParametro(comando, "@tula", t, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaEliminacion");
            }

        }

        /// <summary>
        /// Verificar si existe una tula registrada.
        /// </summary>
        /// <param name="t">Objeto Tula con los datos de la tula</param>
        /// <returns>Valor que indica si la tula existe</returns>
        public bool verificarTula(ref Tula t)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteTula");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", t.Codigo, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.HasRows)
                {
                    datareader.Read();
                    int id = (int)datareader["pk_ID"];
                    DateTime fecha_ingreso = (DateTime)datareader["Fecha_Ingreso"];

                    t.ID = id;
                    t.Fecha_ingreso = fecha_ingreso;

                    existe = true;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarTulaDuplicada");
            }

            return existe;
        }

        public bool verificarTulaProcesamiento(ref Tula t)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteTulaProcesamiento");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", t.Codigo, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.HasRows)
                {
                    //datareader.Read();
                    //int id = (int)datareader["pk_ID"];
                    //DateTime fecha_ingreso = (DateTime)datareader["Fecha_Ingreso"];

                    //t.ID = id;
                    //t.Fecha_ingreso = fecha_ingreso;

                    existe = true;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarTulaProcesada");
            }

            return existe;
        }
        public bool verificarTulaDocumento(ref Tula t)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteTulaDocumento");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", t.Codigo, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.HasRows)
                {
                    datareader.Read();
                    int id = (int)datareader["pk_ID"];
                    DateTime fecha_ingreso = (DateTime)datareader["Fecha_Ingreso"];

                    t.ID = id;
                    t.Fecha_ingreso = fecha_ingreso;

                    existe = true;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarTulaDuplicada");
            }

            return existe;
        }

        /// <summary>
        /// Verificar si existe una tula registrada.
        /// </summary>
        /// <param name="t">Objeto Tula con los datos de la tula</param>
        /// <returns>Valor que indica si la tula existe</returns>
        public bool verificarTulaNiquel(ref Tula t)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteTulaNiquel");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", t.Codigo, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.HasRows)
                {
                    datareader.Read();
                    int id = (int)datareader["pk_ID"];
                    DateTime fecha_ingreso = (DateTime)datareader["Fecha_Ingreso"];

                    t.ID = id;
                    t.Fecha_ingreso = fecha_ingreso;

                    existe = true;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarTulaDuplicada");
            }

            return existe;
        }

        /// <summary>
        /// Listar todos las tulas de un manifiesto.
        /// </summary>
        /// <param name="m">Manifiesto para el cual se desean listar las tulas</param>
        /// <returns>Lista de tulas registrados para el manifiesto indicado</returns>
        public BindingList<Tula> listarTulasPorManifiesto(Manifiesto m)
        {
            BindingList<Tula> tulas = new BindingList<Tula>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTulasManifiesto");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string codigo = (string)datareader["Codigo"];
                    DateTime fecha_ingreso = (DateTime)datareader["Fecha_Ingreso"];

                    Tula tula = new Tula(codigo, id: id, fecha_ingreso: fecha_ingreso);

                    tulas.Add(tula);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return tulas;
        }



        /// <summary>
        /// Listar todos las tulas de un manifiesto.
        /// </summary>
        /// <param name="m">Manifiesto para el cual se desean listar las tulas</param>
        /// <returns>Lista de tulas registrados para el manifiesto indicado</returns>
        public BindingList<Tula> listarTulasPorManifiestoNiquel(Manifiesto m)
        {
            BindingList<Tula> tulas = new BindingList<Tula>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTulasManifiestoNiquel");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string codigo = (string)datareader["Codigo"];
                    DateTime fecha_ingreso = (DateTime)datareader["Fecha_Ingreso"];

                    Tula tula = new Tula(codigo, id: id, fecha_ingreso: fecha_ingreso);

                    tulas.Add(tula);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return tulas;
        }


        /// <summary>
        /// Listar todas las tulas registradas entre dos determinadas fecha.
        /// </summary>
        /// <param name="i">Fecha inicial para la cual se genera la lista</param>
        /// <param name="f">Fecha final para la cual se genera la lista</param>
        /// <returns>Lista de tulas registradas entre las fechas indicadas</returns>
        public BindingList<Tula> listarTulas(DateTime i, DateTime f)
        {
            BindingList<Tula> tulas = new BindingList<Tula>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTulas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha_inicio", i, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha_final", f, SqlDbType.DateTime);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_tula = (int)datareader["ID_Tula"];
                    string codigo_tula = (string)datareader["Codigo_Tula"];
                    DateTime fecha_ingreso = (DateTime)datareader["Fecha_Ingreso"];

                    Tula tula = new Tula(codigo_tula, id: id_tula, fecha_ingreso: fecha_ingreso);

                    tulas.Add(tula);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return tulas;
        }



        /// <summary>
        /// Listar todas las tulas registradas entre dos determinadas fecha, para el area de boveda
        /// </summary>
        /// <param name="i">Fecha inicial para la cual se genera la lista</param>
        /// <param name="f">Fecha final para la cual se genera la lista</param>
        /// <returns>Lista de tulas registradas entre las fechas indicadas</returns>
        public BindingList<Tula> listarTulasNiquel(DateTime i, DateTime f)
        {
            BindingList<Tula> tulas = new BindingList<Tula>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTulasNiquel");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha_inicio", i, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha_final", f, SqlDbType.DateTime);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_tula = (int)datareader["ID_Tula"];
                    string codigo_tula = (string)datareader["Codigo_Tula"];
                    DateTime fecha_ingreso = (DateTime)datareader["Fecha_Ingreso"];

                    Colaborador receptor = new Colaborador();
                    receptor.ID =  (int)datareader["ID_Receptor"];
                    receptor.Nombre = (string)datareader["Nombre_Receptor"];

                    Manifiesto m = new Manifiesto();
                    m.ID = (int)datareader["ID_Manifiesto"];
                    m.Codigo = (string)datareader["Codigo_Manifiesto"];

                    Cliente c = new Cliente();
                    c.Id = (short)datareader["ID_Cliente"];
                    c.Nombre = (string)datareader["Nombre_Cliente"];                         
	
                    Tula tula = new Tula(codigo_tula, id: id_tula, fecha_ingreso: fecha_ingreso);
                    Tula t = new Tula(codigo_tula, id: id_tula, manifiesto: m, fecha_ingreso: fecha_ingreso, receptor: receptor, cliente: c);

                    tulas.Add(t);
                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return tulas;
        }

        /// <summary>
        /// Obtener una lista de las tulas que tienen un determinado código o parte del mismo.
        /// </summary>
        /// <param name="c">Código o parte del mismo de las tulas que se listarán</param>
        /// <returns>Lista de tulas que cumplen con el criterio de búsqueda</returns>
        public BindingList<Tula> listarTulasPorCodigo(string c)
        {
            BindingList<Tula> tulas = new BindingList<Tula>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTulasCodigo");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", c, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string codigo = (string)datareader["Codigo"];
                    DateTime fecha_ingreso = (DateTime)datareader["Fecha_Ingreso"];

                    Tula tula = new Tula(codigo, id: id, fecha_ingreso: fecha_ingreso);

                    tulas.Add(tula);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return tulas;
        }

        #endregion Tulas

        #region Tulas Niquel


        /// <summary>
        /// Registrar una tula en el sistema.
        /// </summary>
        /// <param name="t">Objeto Tula con los datos de la tula</param>
        public void agregarCantidadBolsasNiquel(ref TulaNiquel t, Tula tula)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCantidadBolsaNiquel");

            _manejador.agregarParametro(comando, "@denominacion", t.Denominacion, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@cantidadbolsa", t.CantidadBolsa, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@tula", tula, SqlDbType.Int);

            try
            {
                t.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaRegistro");
            }

        }

        #endregion Tulas Niquel

        #region Bolsas Niquel

     

        /// <summary>
        /// Listar todos las tulas de un manifiesto de sucursal.
        /// </summary>
        /// <param name="m">Manifiesto para el cual se desean listar las tulas</param>
        /// <returns>Lista de tulas registrados para el manifiesto indicado</returns>
        public BindingList<BolsaNiquel> listarBolsasNiquel()
        {
            BindingList<BolsaNiquel> bolsas = new BindingList<BolsaNiquel>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTulasSucursales");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["ID_Tula"];
                    string serie = (string)datareader["Serie_Bolsa"];
                    DateTime fecha_ingreso = (DateTime)datareader["Fecha"];

                    ManifiestoNiquelPedido manifiesto = new ManifiestoNiquelPedido();

                    if (datareader["ID_Manifiesto"] != DBNull.Value)
                    {
                        int id_manifiesto = (int)datareader["ID_Manifiesto"];
                        string codigo = "";
                        if (datareader["Codigo"] != DBNull.Value)
                        { codigo = (string)datareader["Codigo"]; }

                        manifiesto = new ManifiestoNiquelPedido(id: id_manifiesto, codigo: codigo);
                    }
                    Colaborador colaborador = new Colaborador();
                    if (datareader["ID_Colaborador"] != DBNull.Value)
                    {
                        int id_colaborador = (int)datareader["ID_Colaborador"];
                        string nombre = (string)datareader["Nombre"];
                        string primer_apellido = (string)datareader["Primer_Apellido"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido"];

                        colaborador = new Colaborador(id: id_colaborador, nombre: nombre,
                             primer_apellido: primer_apellido, segundo_apellido: segundo_apellido);
                    }

                    Sucursal sucursal = new Sucursal();
                    if (datareader["ID_Sucursal"] != DBNull.Value)
                    {
                        short id_sucursal = (short)datareader["ID_Sucursal"];
                        string nombre_surcursal = (string)datareader["Nombre_Sucursal"];

                        sucursal.DB_ID = id_sucursal;
                        sucursal.Nombre = nombre_surcursal;
                    }

                    EmpresaTransporte transportadora = new EmpresaTransporte();
                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_transportadora = (byte)datareader["ID_Transportadora"];
                        string nombre_transportadora = (string)datareader["Nombre_Transportadora"];

                        transportadora.DB_ID = id_transportadora;
                        transportadora.Nombre = nombre_transportadora;
                    }

                    BolsaNiquel bolsa = new BolsaNiquel(serie: serie, id: id, fecha_ingreso: fecha_ingreso);
                    bolsa.SerieBolsa = serie;
                    bolsa.Colaborador = colaborador;
                    bolsa.Manifiesto = manifiesto;
                    bolsa.Sucursal = sucursal;
                    bolsa.Transportadora = transportadora;
                    bolsas.Add(bolsa);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return bolsas;
        }


        /// <summary>
        /// Registrar una tula en el sistema.
        /// </summary>
        /// <param name="b">Objeto Bolsa con los datos de la tula</param>
        public void agregarBolsaNiquel(ref BolsaNiquel b)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertBolsaPedidoNiquel");

            _manejador.agregarParametro(comando, "@Serie_Tula", b.SerieBolsa, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@manifiesto", b.Manifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@colaborador", b.Colaborador, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@montocolones", b.MontoColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@montodolares", b.MontoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@montoeuros", b.MontoEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@idcarganiquel", b.IDCargaSucursal, SqlDbType.Decimal);

            try
            {
                b.DB_ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaRegistro");
            }

        }

        /// <summary>
        /// Verifica la existencia de una tula sucursal en el sistema.
        /// </summary>
        /// <param name="b">Objeto Bolsa con los datos de la tula a buscar</param>
        public bool verificarBolsaNiquel(ref BolsaNiquel b)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteBolsaPedidoNiquel");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@serie_tula", b.SerieBolsa, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@manifiesto", b.Manifiesto, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.HasRows)
                {
                    datareader.Read();
                    int id = (int)datareader["Pk_ID"];
                    DateTime fecha = (DateTime)datareader["Fecha"];

                    b.DB_ID = id;
                    b.Fecha_ingreso = fecha;

                    existe = true;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarTulaDuplicada");
            }

            return existe;
        }

        /// <summary>
        /// Elimina tula sucursal del sistema.
        /// </summary>
        /// <param name="b">Objeto Bolsa con los datos de la tula a eliminar</param>

        public void eliminarBolsaNiquel(BolsaNiquel b)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteBolsaPedidoNiquel");

            _manejador.agregarParametro(comando, "@bolsa", b, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaEliminacion");
            }
        }


        /// <summary>
        /// Listar todos las tulas de un manifiesto de sucursal.
        /// </summary>
        /// <param name="m">Manifiesto para el cual se desean listar las tulas</param>
        /// <returns>Lista de tulas registrados para el manifiesto indicado</returns>
        public BindingList<BolsaNiquel> listarBolsasNiquelPorManifiesto(ref ManifiestoNiquelPedido m)
        {
            BindingList<BolsaNiquel> bolsas = new BindingList<BolsaNiquel>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectBolsaPedidoNiquel");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@manifiesto", m.ID, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["Pk_ID"];
                    string serie = (string)datareader["Serie_Bolsa"];
                    DateTime fecha_ingreso = (DateTime)datareader["Fecha"];

                    Decimal montocolones = 0;
                    Decimal montodolares = 0;
                    Decimal montoeuros = 0;

                    if (datareader["MontoColones"] != DBNull.Value)
                        montocolones = (Decimal)datareader["MontoColones"];

                    if (datareader["MontoDolares"] != DBNull.Value)
                        montodolares = (Decimal)datareader["MontoDolares"];

                    if (datareader["MontoEuros"] != DBNull.Value)
                        montoeuros = (Decimal)datareader["MontoEuros"];

                    BolsaNiquel bols = new BolsaNiquel(id: id, serie: serie, fecha_ingreso: fecha_ingreso, montocoloes: montocolones, montodolares: montodolares, montoeuros: montoeuros);
                    bols.SerieBolsa = serie;
                    bolsas.Add(bols);
                    
                }
                m.ListaBolsas = bolsas;
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return bolsas;
        }





        /// <summary>
        /// Registrar una tula en el sistema.
        /// </summary>
        /// <param name="b">Objeto Bolsa con los datos de la tula</param>
        public void actualizarBolsaNiquel(ref BolsaNiquel b)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateBolsaPedidoNiquel");

            _manejador.agregarParametro(comando, "@Serie_Tula", b.SerieBolsa, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@montocolones", b.MontoColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@montodolares", b.MontoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@montoeuros", b.MontoEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tula", b, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaRegistro");
            }

        }

 

        #endregion Bolsas Niquel

        #region Bolsas Transportadoras

        /// <summary>
        /// Listar todos las tulas de un manifiesto de Transportadora.
        /// </summary>
        /// <param name="m">Manifiesto para el cual se desean listar las tulas</param>
        /// <returns>Lista de tulas registrados para el manifiesto indicado</returns>
        public BindingList<BolsaTransportadora> listarBolsasTransportadora()
        {
            BindingList<BolsaTransportadora> bolsas = new BindingList<BolsaTransportadora>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTulasTransportadora");
            SqlDataReader datareader = null;

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["ID_Tula"];
                    string serie = (string)datareader["Serie_Bolsa"];
                    DateTime fecha_ingreso = (DateTime)datareader["Fecha"];

                    ManfiestoTransportadoraCarga manifiesto = new ManfiestoTransportadoraCarga();

                    if (datareader["ID_Manifiesto"] != DBNull.Value)
                    {
                        int id_manifiesto = (int)datareader["ID_Manifiesto"];
                        string codigo = "";
                        if (datareader["Codigo"] != DBNull.Value)
                        { codigo = (string)datareader["Codigo"]; }

                        manifiesto = new ManfiestoTransportadoraCarga(id: id_manifiesto, codigo: codigo);
                    }
                    Colaborador colaborador = new Colaborador();
                    if (datareader["ID_Colaborador"] != DBNull.Value)
                    {
                        int id_colaborador = (int)datareader["ID_Colaborador"];
                        string nombre = (string)datareader["Nombre"];
                        string primer_apellido = (string)datareader["Primer_Apellido"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido"];

                        colaborador = new Colaborador(id: id_colaborador, nombre: nombre,
                             primer_apellido: primer_apellido, segundo_apellido: segundo_apellido);
                    }

                   

                    EmpresaTransporte transportadora = new EmpresaTransporte();
                    if (datareader["ID_Transportadora"] != DBNull.Value)
                    {
                        byte id_transportadora = (byte)datareader["ID_Transportadora"];
                        string nombre_transportadora = (string)datareader["Nombre_Transportadora"];

                        transportadora.DB_ID = id_transportadora;
                        transportadora.Nombre = nombre_transportadora;
                    }

                    BolsaTransportadora BolsaTransportadora = new BolsaTransportadora(serie: serie, id: id, fecha_ingreso: fecha_ingreso);
                    BolsaTransportadora.SerieBolsa = serie;
                    BolsaTransportadora.Colaborador = colaborador;
                    BolsaTransportadora.Manifiesto = manifiesto;
                    BolsaTransportadora.Transportadora = transportadora;
                    bolsas.Add(BolsaTransportadora);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return bolsas;
        }


        /// <summary>
        /// Registrar una tula en el sistema.
        /// </summary>
        /// <param name="b">Objeto BolsaTransportadora con los datos de la tula</param>
        public void agregarBolsaTransportadora(ref BolsaTransportadora b)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertBolsaTransportadora");

            _manejador.agregarParametro(comando, "@Serie_Tula", b.SerieBolsa, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@manifiesto", b.Manifiesto, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@colaborador", b.Colaborador, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@montocolones", b.MontoColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@montodolares", b.MontoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@montoeuros", b.MontoEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@idcargaTransportadora", b.IDCargaSucursal, SqlDbType.Decimal);

            try
            {
                b.DB_ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaRegistro");
            }

        }

        /// <summary>
        /// Verifica la existencia de una tula Transportadora en el sistema.
        /// </summary>
        /// <param name="b">Objeto BolsaTransportadora con los datos de la tula a buscar</param>
        public bool verificarBolsaTransportadora(ref BolsaTransportadora b)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteBolsaTransportadora");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@serie_tula", b.SerieBolsa, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@manifiesto", b.Manifiesto, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.HasRows)
                {
                    datareader.Read();
                    int id = (int)datareader["Pk_ID"];
                    DateTime fecha = (DateTime)datareader["Fecha"];

                    b.DB_ID = id;
                    b.Fecha_ingreso = fecha;

                    existe = true;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarTulaDuplicada");
            }

            return existe;
        }

        /// <summary>
        /// Elimina tula Transportadora del sistema.
        /// </summary>
        /// <param name="b">Objeto BolsaTransportadora con los datos de la tula a eliminar</param>

        public void eliminarBolsaTransportadora(BolsaTransportadora b)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteBolsaTransportadora");

            _manejador.agregarParametro(comando, "@BolsaTransportadora", b, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaEliminacion");
            }
        }


        /// <summary>
        /// Listar todos las tulas de un manifiesto de Transportadora.
        /// </summary>
        /// <param name="m">Manifiesto para el cual se desean listar las tulas</param>
        /// <returns>Lista de tulas registrados para el manifiesto indicado</returns>
        public BindingList<BolsaTransportadora> listarBolsasTransportadoraPorManifiesto(ref ManfiestoTransportadoraCarga m)
        {
            BindingList<BolsaTransportadora> bolsas = new BindingList<BolsaTransportadora>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectBolsaTransportadora");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@manifiesto", m, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["Pk_ID"];
                    string serie = (string)datareader["Serie_Bolsa"];
                    DateTime fecha_ingreso = (DateTime)datareader["Fecha"];

                    Decimal montocolones = 0;
                    Decimal montodolares = 0;
                    Decimal montoeuros = 0;

                    if (datareader["MontoColones"] != DBNull.Value)
                        montocolones = (Decimal)datareader["MontoColones"];

                    if (datareader["MontoDolares"] != DBNull.Value)
                        montodolares = (Decimal)datareader["MontoDolares"];

                    if (datareader["MontoEuros"] != DBNull.Value)
                        montoeuros = (Decimal)datareader["MontoEuros"];

                    BolsaTransportadora BolsaTransportadora = new BolsaTransportadora(id: id, serie: serie, fecha_ingreso: fecha_ingreso, montocoloes: montocolones, montodolares: montodolares, montoeuros: montoeuros);
                    BolsaTransportadora.SerieBolsa = serie;
                    bolsas.Add(BolsaTransportadora);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return bolsas;
        }





        /// <summary>
        /// Registrar una tula en el sistema.
        /// </summary>
        /// <param name="b">Objeto BolsaTransportadora con los datos de la tula</param>
        public void actualizarBolsaTransportadora(ref BolsaTransportadora b)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateBolsaTransportadora");

            _manejador.agregarParametro(comando, "@Serie_Tula", b.SerieBolsa, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@montocolones", b.MontoColones, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@montodolares", b.MontoDolares, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@montoeuros", b.MontoEuros, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@tula", b, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaRegistro");
            }

        }

        #endregion Bolsas Transportadoras

        #endregion SITES

        #region PROA

        public bool verificarTula3(ref Tula t, Manifiesto m)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteTula3");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@tula", t.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@manifiesto", m.Codigo, SqlDbType.VarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.HasRows)
                {
                    datareader.Read();
                    int id = (int)datareader["pk_ID"];
                    t.ID = id;
                    DateTime fecha_ingreso = (DateTime)datareader["Fecha_Ingreso"];

                    existe = true;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarTulaDuplicada");
            }

            return existe;
        }
        public bool verificarTula2(ref Tula t, ref ProcesamientoBajoVolumenManifiesto m)
        {
            bool existe = false;

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteTula2");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@codigo", t.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@manifiesto", m.IDManifiesto, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.HasRows)
                {
                    datareader.Read();
                    int id = (int)datareader["pk_ID"];
                    DateTime fecha_ingreso = (DateTime)datareader["Fecha_Ingreso"];

                    t.ID = id;
                    t.Fecha_ingreso = fecha_ingreso;

                    existe = true;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarTulaDuplicada");
            }

            return existe;
        }

        public BindingList<Tula> listarTulasPorFecha(DateTime i, DateTime f)
        {
            BindingList<Tula> tulas = new BindingList<Tula>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectTulas2");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha_inicio", i, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha_final", f, SqlDbType.DateTime);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id_tula = (int)datareader["ID_Tula"];
                    string codigo_tula = (string)datareader["Codigo_Tula"];
                    DateTime fecha_ingreso = (DateTime)datareader["Fecha_Ingreso"];

                    Tula tula = new Tula(codigo_tula, id: id_tula, fecha_ingreso: fecha_ingreso);

                    tulas.Add(tula);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return tulas;
        }

        public void actualizarCodigoTula(Tula t, Colaborador c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateTulaProa");

            _manejador.agregarParametro(comando, "@tula", t.ID, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@codigo", t.Codigo, SqlDbType.VarChar);
            _manejador.agregarParametro(comando, "@coordinador", c, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorTulaActualizacion");
            }

        }

        #endregion PROA

        #endregion Métodos Públicos

    }

}
