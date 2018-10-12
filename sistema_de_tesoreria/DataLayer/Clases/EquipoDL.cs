using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using CommonObjects.Clases;
using System.Data.SqlClient;
using System.Data;
using LibreriaMensajes;
using System.ComponentModel;
using CommonObjects;

namespace DataLayer.Clases
{
    public class EquipoDL : ObjetoIndexado
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static EquipoDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static EquipoDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new EquipoDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public EquipoDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Registrar un nuevo tipo de equpio.
        /// </summary>
        /// <param name="d">Objeto Equipo con los datos del deposito</param>
        public void agregarEquipo(ref Equipo d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertEquipo");

            _manejador.agregarParametro(comando, "@atm", d.ATM, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@codigobarras", d.CodigoBarras, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@idasignacion", d.IdAsignacion, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@manojo", d.Manojo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@serie", d.Serie, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@tipoequipo", d.TipoEquipo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@colaboradoregistro", d.ColaboradorRegistro, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@colaborador", d.Asginado, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@puesto", d.Puestos, SqlDbType.TinyInt);

            try
            {
                d.ID = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEquipoRegistro");
            }

        }

        /// <summary>
        /// Actualizar los datos de un deposito.
        /// </summary>
        /// <param name="d">Objeto Equipo con los datos del deposito a actualizar</param>
        public void actualizarEquipo(Equipo d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateEquipo");

            _manejador.agregarParametro(comando, "@atm", d.ATM, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@codigobarras", d.CodigoBarras, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@idasignacion", d.IdAsignacion, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@manojo", d.Manojo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@serie", d.Serie, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@tipoequipo", d.TipoEquipo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@colaboradoregistro", d.ColaboradorRegistro, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@colaborador", d.Asginado, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@equipo", d, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@puesto", d.Puestos, SqlDbType.TinyInt);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEquipoActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un deposito.
        /// </summary>
        /// <param name="d">Objeto Equipo con los datos del deposito a eliminar</param>
        public void eliminarEquipo(Equipo d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteEquipo");

            _manejador.agregarParametro(comando, "@equipo", d, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorEquipoEliminacion");
            }

        }

        /// <summary>
        /// Verificar si un deposito ya está registrado en el sistema.
        /// </summary>
        /// <param name="d">Objeto Equipo con los datos del equipo</param>
        /// <returns>Valor que indica si el equipo existe</returns>
        public bool verificarEquipo(Equipo d)
        {
            bool existe = false;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteEquipo");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@serie", d.Serie, SqlDbType.NVarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];

                    existe = id != d.ID;

                    d.ID = id;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorVerificarEquipo");
            }

            return existe;
        }

        /// <summary>
        /// Obtener una lista de los depositos que tienen un determinado número de referencia o parte del mismo.
        /// </summary>
        /// <param name="r">Referencia o parte de la misma de los depositos que se listarán</param>
        /// <returns>Lista de depositos que cumplen con el criterio de búsqueda</returns>
        public BindingList<Equipo> listarEquipos(string r)
        {
            BindingList<Equipo> equipos = new BindingList<Equipo>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectEquipos");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@serie", r, SqlDbType.NVarChar);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string serie = (string)datareader["Serie"];
                    string codigobarras = (string)datareader["Codigo_Barras"];
                    string idasignacion = (string)datareader["Codigo_Asignado"];
                    
                    Puestos p = 0;

                    if (datareader["Puesto"] != DBNull.Value)
                    {
                        p = (Puestos)datareader["Puesto"];
                    }

                    
                    ATM atm = null;


                    if (datareader["ID_ATM"] != DBNull.Value)
                    {
                        short id_atm = (short)datareader["ID_ATM"];
                        short numero = (short)datareader["Numero"];
                        TiposCartucho tipo = (TiposCartucho)datareader["Tipo"];
                        byte cartuchos = (byte)datareader["Cartuchos"];
                        bool externo = (bool)datareader["Externo"];
                        bool full = (bool)datareader["ATM_Full"];
                        bool ena = (bool)datareader["ENA"];
                        bool vip = (bool)datareader["VIP"];
                        bool cartucho_rechazo = (bool)datareader["Cartucho_Rechazo"];
                        string codigo = (string)datareader["Codigo"];
                        string oficinas = (string)datareader["Oficinas"];
                        byte? periodo_carga = datareader["Periodo_Carga"] as byte?;

                        EmpresaTransporte empresa_encargada = null;

                        if (datareader["ID_Transportadora"] != DBNull.Value)
                        {
                            byte id_empresa_encargada = (byte)datareader["ID_Transportadora"];
                            string nombre = (string)datareader["Nombre_Transportadora"];

                            empresa_encargada = new EmpresaTransporte(nombre, id: id_empresa_encargada);
                        }

                        Sucursal sucursal = null;

                        

                        Ubicacion ubicacion = null;

                        if (datareader["ID_Ubicacion"] != DBNull.Value)
                        {
                            short id_ubicacion = (short)datareader["ID_Ubicacion"];
                            string oficina = (string)datareader["Oficina"];
                            string direccion = (string)datareader["Direccion"];

                            ubicacion = new Ubicacion(oficina, direccion, id: id_ubicacion);
                        }

                         atm = new ATM(id: id_atm, numero: numero, empresa_encargada: empresa_encargada, tipo: tipo,
                                          cartuchos: cartuchos, externo: externo, full: full, ena: ena,
                                          vip: vip, cartucho_rechazo: cartucho_rechazo, codigo: codigo,
                                          oficinas: oficinas, periodo_carga: periodo_carga, sucursal: sucursal,
                                          ubicacion: ubicacion);
                    }




                    Colaborador colaborador = null;

                    if (datareader["Colaborador"] != DBNull.Value)
                    {
                        int id_colaborador = (int)datareader["ID_Colaborador"];
                        string nombre = (string)datareader["Nombre"];
                        string primer_apellido = (string)datareader["Primer_Apellido"];
                        string segundo_apellido = (string)datareader["Segundo_Apellido"];
                        string identificacion = (string)datareader["Identificacion"];
                        string cuenta = datareader["Cuenta"] as string;


                        colaborador = new Colaborador(id: id, nombre: nombre, primer_apellido: primer_apellido,
                                                                  segundo_apellido: segundo_apellido, identificacion: identificacion,
                                                                  cuenta: cuenta);
                    }
                    


                    Manojo manojo = null;

                    if (datareader["Manojo"] != DBNull.Value)
                    {
                        int id_manojo = (int)datareader["ID_Manojo"];
                        string descripcion_manojo = (string)datareader["Descripcion_Manojo"];

                        manojo = new Manojo(id: id_manojo, descripcion: descripcion_manojo);
                    }

                    TipoEquipo tipoequipo = null;

                    if (datareader["TipoEquipo"] != DBNull.Value)
                    {
                        int tipoequipoid = (int)datareader["TipoEquipo"];
                        string tipoequipo_descripcion = (string)datareader["TipoEquipoDescripcion"];
                        bool obligatorio = (bool)datareader["TipoEquipoObligatorio"];

                        tipoequipo = new TipoEquipo(id: tipoequipoid, descripcion: tipoequipo_descripcion, obligatorio: obligatorio);

                    }

                    Equipo equipo = new Equipo(id: id, serie: serie, idasignacion: idasignacion, atm: atm, col: colaborador, man: manojo, codigobarras: codigobarras, tipoequipo: tipoequipo, p: p);

                    equipos.Add(equipo);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return equipos;
        }


        #region Revision Portavalor

        public BindingList<RevisionFinalPortavalor> listarRevisionPortavalor(DateTime fi, DateTime ff, Colaborador ch, int r)
        {
            BindingList<RevisionFinalPortavalor> revisionvehiculos = new BindingList<RevisionFinalPortavalor>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectReporteRevisionPortavalor");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@fecha_inicio", fi, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fecha_fin", ff, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@portavalor", ch, SqlDbType.Int);

            if (r == 0)
                _manejador.agregarParametro(comando, "@ruta", null, SqlDbType.TinyInt);
            else
                _manejador.agregarParametro(comando, "@ruta", r, SqlDbType.TinyInt);


            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {

                    DateTime fecha = (DateTime)datareader["Fecha"];
                    int rutita = (int)datareader["Ruta"];
                    short id_tripulacion = (short)datareader["ID_Tripulacion"];

                    string descripcion_tripulacion = (string)datareader["DescripcionTripulacion"];

                    int id = (int)datareader["ID_Equipo"];
                    string serie = (string)datareader["Serie_Equipo"];
                    string idasignacion = (string)datareader["Codigo_Equipo"];

                    TipoEquipo tipoequipo = null;

                    if (datareader["TipoEquipo"] != DBNull.Value)
                    {
                        int tipoequipoid = (int)datareader["TipoEquipo"];
                        string tipoequipo_descripcion = (string)datareader["TipoEquipoDescripcion"];
                        bool obligatorio = (bool)datareader["TipoEquipoObligatorio"];

                        tipoequipo = new TipoEquipo(id: tipoequipoid, descripcion: tipoequipo_descripcion, obligatorio: obligatorio);

                    }

                    Equipo equipo = new Equipo(id: id, serie: serie, idasignacion: idasignacion,  tipoequipo: tipoequipo);



                    int id_colaborador = (int)datareader["ID_Chofer"];
                    string chofer_nombre = (string)datareader["Chofer_Nombre"];
                    string chofer_primerapellido = (string)datareader["Chofer_Primer_Apellido"];
                    string chofer_segundoapellido = (string)datareader["Chofer_Segundo_Apellido"];

                    Colaborador chof = new Colaborador(id: id_colaborador, nombre: chofer_nombre, primer_apellido: chofer_primerapellido, segundo_apellido: chofer_segundoapellido);

                    string imagen = (string)datareader["NombreImagen"];

                    RevisionFinalPortavalor revision = new RevisionFinalPortavalor(fecha: fecha,ruta:rutita,v:equipo,chofer:chof,idtrip:id_tripulacion,imagen:imagen,descripciontrip:descripcion_tripulacion);

                    revisionvehiculos.Add(revision);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return revisionvehiculos;
        }

        #endregion Revision Portavalor

        #endregion Métodos Públicos
    }
}
