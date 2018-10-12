//
//  @ Project : 
//  @ File Name : RegistrosDenominacionesCierreDL.cs
//  @ Date : 19/10/2011
//  @ Author : Erick Chavarría 
//

using System;
using System.Data;
using System.Data.SqlClient;

using CommonObjects;
using LibreriaAccesoDatos;
using LibreriaMensajes;

namespace DataLayer
{

    /// <summary>
    /// Clase de la capa de datos que maneja los registros de la denominaciones de un cajero en el cierre de caja.
    /// </summary>
    public class RegistrosDenominacionesCierreDL
    {

        #region Atributos

        /// <summary>
        /// Instancia única del manejador.
        /// </summary>
        private static RegistrosDenominacionesCierreDL _instancia;

        /// <summary>
        /// Obtener la instancia única del manejador.
        /// </summary>
        public static RegistrosDenominacionesCierreDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new RegistrosDenominacionesCierreDL();
                return _instancia;
            }
        }

        private ManejadorBD _manejador = ManejadorBD.Instancia;

        #endregion Atributos

        #region Constructor

        public RegistrosDenominacionesCierreDL() { }

        #endregion Constructor

        #region Métodos Públicos

        /// <summary>
        /// Agregar un registro de los montos por denominación del cierre de un cajero.
        /// </summary>
        /// <param name="r">Objeto RegistroDenominacionesCierre con los montos por denominacion</param>
        public void agregarRegistroDenominacionesCierre(ref RegistroDenominacionesCierre r)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCierreDenominaciones");

            _manejador.agregarParametro(comando, "@cajero", r.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@coordinador", r.Coordinador, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", r.Fecha, SqlDbType.Date);

            _manejador.agregarParametro(comando, "@colones_cincuenta_mil", r.Colones_cincuenta_mil, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_veinte_mil", r.Colones_veinte_mil, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_diez_mil", r.Colones_diez_mil, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_cinco_mil", r.Colones_cinco_mil, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_dos_mil", r.Colones_dos_mil, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_mil", r.Colones_mil, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_quinientos", r.Colones_quinientos, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_cien", r.Colones_cien, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_cincuenta", r.Colones_cincuenta, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_veinticinco", r.Colones_veinticinco, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_diez", r.Colones_diez, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_cinco", r.Colones_cinco, SqlDbType.Money);
		
            _manejador.agregarParametro(comando, "@dolares_cien", r.Dolares_cien, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@dolares_cincuenta", r.Dolares_cincuenta, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@dolares_veinte", r.Dolares_veinte, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@dolares_diez", r.Dolares_diez, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@dolares_cinco", r.Dolares_cinco, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@dolares_uno", r.Dolares_uno, SqlDbType.Money);

            if(r.Cliente != null)
                _manejador.agregarParametro(comando, "@cliente", r.Cliente.Id, SqlDbType.SmallInt);
            else
                _manejador.agregarParametro(comando, "@cliente", r.Cliente, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@transportadora", r.Transportadora, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@externo", r.ProcesamientoExterno, SqlDbType.Bit);

            try
            {
                r.Id = (int)_manejador.ejecutarEscalar(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroDenominacionesCierreRegistro");
            }

        }

        /// <summary>
        /// Agregar un corte de los montos por denominación del cierre de un cajero.
        /// </summary>
        /// <param name="r">Objeto RegistroDenominacionesCierre con los montos por denominacion</param>
        public void agregarCorteRegistroDenominacionesCierre(RegistroDenominacionesCierre r)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("InsertCierreDenominacionesCorte");

            _manejador.agregarParametro(comando, "@cierre", r.Id, SqlDbType.Int);

            _manejador.agregarParametro(comando, "@colones_cincuenta_mil", r.Colones_cincuenta_mil, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_veinte_mil", r.Colones_veinte_mil, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_diez_mil", r.Colones_diez_mil, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_cinco_mil", r.Colones_cinco_mil, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_dos_mil", r.Colones_dos_mil, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_mil", r.Colones_mil, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_quinientos", r.Colones_quinientos, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_cien", r.Colones_cien, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_cincuenta", r.Colones_cincuenta, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_veinticinco", r.Colones_veinticinco, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_diez", r.Colones_diez, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_cinco", r.Colones_cinco, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@dolares_cien", r.Dolares_cien, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@dolares_cincuenta", r.Dolares_cincuenta, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@dolares_veinte", r.Dolares_veinte, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@dolares_diez", r.Dolares_diez, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@dolares_cinco", r.Dolares_cinco, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@dolares_uno", r.Dolares_uno, SqlDbType.Money);


            if (r.Cliente != null)
                _manejador.agregarParametro(comando, "@cliente", r.Cliente.Id, SqlDbType.SmallInt);
            else
                _manejador.agregarParametro(comando, "@cliente", r.Cliente, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@transportadora", r.Transportadora, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@externo", r.ProcesamientoExterno, SqlDbType.Bit);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorCierreDenominacionesCorteRegistro");
            }

        }

        /// <summary>
        /// Actualizar los gastos del registro de los montos por denominación del cierre de un cajero.
        /// </summary>
        /// <param name="r">Objeto RegistroDenominacionesCierre con los montos a actualizar</param>
        public void actualizarRegistroDenominacionesCierre(RegistroDenominacionesCierre r)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("UpdateCierreDenominaciones");

            _manejador.agregarParametro(comando, "@colones_cincuenta_mil", r.Colones_cincuenta_mil, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_veinte_mil", r.Colones_veinte_mil, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_diez_mil", r.Colones_diez_mil, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_cinco_mil", r.Colones_cinco_mil, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_dos_mil", r.Colones_dos_mil, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_mil", r.Colones_mil, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_quinientos", r.Colones_quinientos, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_cien", r.Colones_cien, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_cincuenta", r.Colones_cincuenta, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_veinticinco", r.Colones_veinticinco, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_diez", r.Colones_diez, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@colones_cinco", r.Colones_cinco, SqlDbType.Money);

            _manejador.agregarParametro(comando, "@dolares_cien", r.Dolares_cien, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@dolares_cincuenta", r.Dolares_cincuenta, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@dolares_veinte", r.Dolares_veinte, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@dolares_diez", r.Dolares_diez, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@dolares_cinco", r.Dolares_cinco, SqlDbType.Money);
            _manejador.agregarParametro(comando, "@dolares_uno", r.Dolares_uno, SqlDbType.Money);

            if (r.Cliente != null)
                _manejador.agregarParametro(comando, "@cliente", r.Cliente.Id, SqlDbType.SmallInt);
            else
                _manejador.agregarParametro(comando, "@cliente", r.Cliente, SqlDbType.SmallInt);
            _manejador.agregarParametro(comando, "@transportadora", r.Transportadora, SqlDbType.TinyInt);
            _manejador.agregarParametro(comando, "@externo", r.ProcesamientoExterno, SqlDbType.Bit);

            _manejador.agregarParametro(comando, "@registro", r.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroDenominacionesCierreActualizacion");
            }

        }

        /// <summary>
        /// Eliminar los datos de un registro de montos por denominación del cierre de un cajero.
        /// </summary>
        /// <param name="r">Objeto RegistroDenominacionesCierre con los datos del registro a eliminar</param>
        public void eliminarRegistroDenominacionesCierre(RegistroDenominacionesCierre r)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("DeleteCierreDenominaciones");

            _manejador.agregarParametro(comando, "@registro", r.Id, SqlDbType.Int);

            try
            {
                _manejador.ejecutarConsultaActualizacion(comando);
                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorRegistroDenominacionesCierreEliminacion");
            }

        }

        /// <summary>
        /// Obtener los montos de las denominaciones del cierre de un cajero.
        /// </summary>
        /// <param name="c">Objeto RegistroDenominacionesCierre con los datos del cierre</param>
        public void obtenerDatosRegistroDenominacionesCierre(ref RegistroDenominacionesCierre c)
        {
            SqlCommand comando = _manejador.obtenerProcedimiento("SelectCierreDenominaciones");
            SqlDataReader datareader = null;

            _manejador.agregarParametro(comando, "@cajero", c.Cajero, SqlDbType.Int);
            _manejador.agregarParametro(comando, "@fecha", c.Fecha, SqlDbType.Date);

            try
            {
                datareader = _manejador.ejecutarConsultaDatos(comando);

                if (datareader.Read())
                {
                    c.Id = (int)datareader["ID_Cierre"];
                    c.Colones_cincuenta_mil = (decimal)datareader["Colones_Cincuenta_Mil"];
                    c.Colones_veinte_mil = (decimal)datareader["Colones_Veinte_Mil"];
                    c.Colones_diez_mil = (decimal)datareader["Colones_Diez_Mil"];
                    c.Colones_cinco_mil = (decimal)datareader["Colones_Cinco_Mil"];
                    c.Colones_dos_mil = (decimal)datareader["Colones_Dos_Mil"];
                    c.Colones_mil = (decimal)datareader["Colones_Mil"];
                    c.Colones_quinientos = (decimal)datareader["Colones_Quinientos"];
                    c.Colones_cien = (decimal)datareader["Colones_Cien"];
                    c.Colones_cincuenta = (decimal)datareader["Colones_Cincuenta"];
                    c.Colones_veinticinco = (decimal)datareader["Colones_Veinticinco"];
                    c.Colones_diez = (decimal)datareader["Colones_Diez"];
                    c.Colones_cinco = (decimal)datareader["Colones_Cinco"];

                    c.Dolares_cien = (decimal)datareader["Dolares_Cien"];
                    c.Dolares_cincuenta = (decimal)datareader["Dolares_Cincuenta"];
                    c.Dolares_veinte = (decimal)datareader["Dolares_Veinte"];
                    c.Dolares_diez = (decimal)datareader["Dolares_Diez"];
                    c.Dolares_cinco = (decimal)datareader["Dolares_Cinco"];
                    c.Dolares_uno = (decimal)datareader["Dolares_Uno"];

                    int id_coordinador = (int)datareader["ID_Coordinador"];
                    string nombre_coordinador = (string)datareader["Nombre_Coordinador"];
                    string primer_apellido_coordinador = (string)datareader["Primer_Apellido_Coordinador"];
                    string segundo_apellido_coordinador = (string)datareader["Segundo_Apellido_Coordinador"];


                    EmpresaTransporte transportadora = null; 

                    if(datareader["ID_Transportadora"]!= DBNull.Value)
                    {
                        byte id_transportadora = (byte)datareader["ID_Transportadora"];
                        string nombre_transportadora = (string)datareader["Nombre_Transportadora"];

                        transportadora = new EmpresaTransporte(id: id_transportadora, nombre: nombre_transportadora);
                    }


                    Cliente cliente = null;

                    if (datareader["ID_Cliente"] != DBNull.Value)
                    {
                        short id_cliente = (short)datareader["ID_Cliente"];
                        string nombre_cliente = (string)datareader["Nombre_Cliente"];

                        cliente = new Cliente(id: id_cliente, nombre: nombre_cliente);
                    }

                    Colaborador coordinador = new Colaborador(id_coordinador, nombre_coordinador,
                                                              primer_apellido_coordinador,
                                                              segundo_apellido_coordinador);

                    c.Coordinador = coordinador;
                    c.Transportadora = transportadora;
                    c.Cliente = cliente;
                }

                comando.Connection.Close();
            }
            catch (Exception)
            {
                comando.Connection.Close();
                throw new Excepcion("ErrorDatosConexion");
            }

        }
        
        #endregion Métodos Públicos

    }

}
