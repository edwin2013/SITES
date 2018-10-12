using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriaAccesoDatos;
using CommonObjects.Clases;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using LibreriaMensajes;

namespace DataLayer.Clases
{
    public class FichaTecnicaDL : ObjetoIndexado
    {
        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static FichaTecnicaDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static FichaTecnicaDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new FichaTecnicaDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public FichaTecnicaDL() { }

        #endregion Constructor

        #region Métodos Públicos

        public void agregarFichaTecnica(ref FichaTecnica d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertFichaTecnica");

            _manejador.agregarParametro(comando, "@boleta", d.Boleta, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@costo", d.Costo, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@periodicidad", d.Periodicidad, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@observaciones", d.Observaciones, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@mantenimiento", d.Mantenimiento, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", d.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@equipo", d.Equipo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@estado", d.Estatus, SqlDbType.Int);

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

        public void actualizarFichaTecnica(FichaTecnica d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateFichaTecnica");

            _manejador.agregarParametro(comando, "@boleta", d.Boleta, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@costo", d.Costo, SqlDbType.Decimal);
            _manejador.agregarParametro(comando, "@periodicidad", d.Periodicidad, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@observaciones", d.Observaciones, SqlDbType.NVarChar);
            _manejador.agregarParametro(comando, "@mantenimiento", d.Mantenimiento, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", d.Fecha, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@equipo", d.Equipo, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@estado", d.Estatus, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@ficha", d, SqlDbType.Int);

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

        public void eliminarFichaTecnica(FichaTecnica d)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteFichaTecnica");

            _manejador.agregarParametro(comando, "@ficha", d, SqlDbType.Int);

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

        public bool verificarFichaTecnica(FichaTecnica d)
        {
            bool existe = false;
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectExisteFichaTecnica");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@ficha", d, SqlDbType.Int);

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

        public BindingList<FichaTecnica> listarFichasTecnicas(DateTime? inicio = null, DateTime? fin = null, ProveedorEquipo prov = null, EquipoTesoreria equipo=null)
        {
            BindingList<FichaTecnica> fichas = new BindingList<FichaTecnica>();

            SqlCommand comando = _manejador.obtenerProcedimiento("SelectFichasTecnicas");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@inicio", inicio, SqlDbType.DateTime);
            _manejador.agregarParametro(comando, "@fin", fin, SqlDbType.DateTime);
            if (prov != null)
            _manejador.agregarParametro(comando, "@proveedor", prov.ID, SqlDbType.Int); 
            if (equipo != null)
            _manejador.agregarParametro(comando, "@equipo", equipo.ID, SqlDbType.Int);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                while (datareader.Read())
                {
                    int id = (int)datareader["pk_ID"];
                    string boleta = (string)datareader["Boleta"];
                    Decimal costo = (decimal)datareader["Costo"];
                    DateTime periodicidad = (DateTime)datareader["Periodicidad"];
                    string observaciones = (string)datareader["Observaciones"];
                    TipoMantenimiento mantenimiento = (TipoMantenimiento)datareader["Mantenimiento"];
                    DateTime fecha = (DateTime)datareader["Fecha"];
                    EstadoEquipo estatus = (EstadoEquipo)datareader["Estado"];
                    
                    EquipoTesoreria p = new EquipoTesoreria();

                    if (datareader["fk_ID_Equipo"] != DBNull.Value)
                    {
                        p.ID = (int)datareader["fk_ID_Equipo"];
                        p.Nombre = (string)datareader["NombreEquipo"];
                    }

                    FichaTecnica ficha = new FichaTecnica(id: id, boleta: boleta, costo: costo, 
                        periodicidad: periodicidad, observaciones: observaciones, 
                        equipo: p, mantenimiento:mantenimiento, fecha:fecha, estado:estatus);

                    fichas.Add(ficha);
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

            return fichas;
        }

        #endregion Métodos Públicos
    }
}
