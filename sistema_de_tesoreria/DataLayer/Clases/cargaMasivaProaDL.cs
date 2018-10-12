using CommonObjects;
using LibreriaAccesoDatos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer.Clases
{
    public class cargaMasivaProaDL
    {
        private static cargaMasivaProaDL _instancia;
        private ManejadorBD _manejador = ManejadorBD.Instancia;

        public static cargaMasivaProaDL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new cargaMasivaProaDL();
                return _instancia;
            }
        }

        public int getPuntoVentaID(int cliente, string nombre)
        {
            int id = 0;
            SqlConnection connection = _manejador.DBConexion;
            SqlDataReader datareader = null;
            SqlCommand comando = new SqlCommand("SelectIDPuntoVenta", connection);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@nombre", SqlDbType.NVarChar);
            param.Value = nombre;
            comando.Parameters.Add(param);
            SqlParameter param2 = new SqlParameter("@cliente", SqlDbType.NVarChar);
            param2.Value = cliente;
            comando.Parameters.Add(param2);

            try
            {
                comando.Connection.Open();
                datareader = comando.ExecuteReader();
                while (datareader.Read())
                {
                    id = Int32.Parse(datareader["ID"].ToString());
                    comando.Connection.Close();
                    return id;
                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Exception(ex.Message);
            }
            return id;
        }

        public int verificaCamara(string camara)
        {
            int id = 0;
            SqlConnection connection = _manejador.DBConexion;
            SqlDataReader datareader = null;
            SqlCommand comando = new SqlCommand("SeleccionaCamaraCEF", connection);
            try
            {
                Decimal cam = Decimal.Parse(camara);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@camara", SqlDbType.Int);
                param.Value = cam;
                comando.Parameters.Add(param);
                comando.Connection.Open();
                datareader = comando.ExecuteReader();
                while (datareader.Read())
                {
                    comando.Connection.Close();
                    return 1;
                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Exception(ex.Message);
            }
            return id;
        }

        public DataTable insertaCargaMasiva(DataTable dtDeposit, DataTable dtInconsist, Colaborador c)
        {
            DataTable dt2 = new DataTable();
            IDataReader datareader = null;
            SqlConnection connection = _manejador.DBConexion;

            SqlCommand comando = new SqlCommand("InsertDepositoCargaMasiva", connection);
            comando.CommandTimeout = 3000;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@tblDepositos", dtDeposit);
            comando.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@tblInconsistencia", dtInconsist);
            comando.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@cajero", c.ID);
            comando.Parameters.Add(p3);
            try
            {
                comando.Connection.Open();
                datareader = comando.ExecuteReader();
                dt2.Load(datareader);

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Exception(ex.Message);
            }
            return dt2;
        }

        public void insertProcesamientoNiquel(int id_niquel, string id_pvb, string id_manifiesto, Colaborador c, string numero_deposito, string monto)
        {

            SqlConnection connection = _manejador.DBConexion;
            SqlCommand comando = new SqlCommand("InsertProcesamientoNiquel", connection);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@fk_ID_Cajero", SqlDbType.Int);
            param.Value = c.ID;
            comando.Parameters.Add(param);

            SqlParameter param2 = new SqlParameter("@fk_ID_ProcesamientoBajoVolumenDeposito", SqlDbType.Int);
            param2.Value = id_pvb;
            comando.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter("@fk_ID_EmpresaTransporte", SqlDbType.Int);
            param3.Value = DBNull.Value;
            comando.Parameters.Add(param3);

            SqlParameter param4 = new SqlParameter("@ID_TipoProcesamiento", SqlDbType.SmallInt);
            param4.Value = 3;
            comando.Parameters.Add(param4);

            SqlParameter param5 = new SqlParameter("@fk_ID_Manifiesto", SqlDbType.Int);
            param5.Value = id_manifiesto;
            comando.Parameters.Add(param5);

            SqlParameter param6 = new SqlParameter("@fk_ID_InfoConteoNiquel", SqlDbType.Int);
            param6.Value = id_niquel;
            comando.Parameters.Add(param6);

            SqlParameter param7 = new SqlParameter("@Identificador", SqlDbType.NVarChar);
            param7.Value = numero_deposito;
            comando.Parameters.Add(param7);

            SqlParameter param8 = new SqlParameter("@Total_Niquel", SqlDbType.Money);
            param8.Value = monto;
            comando.Parameters.Add(param8);

            SqlParameter param10 = new SqlParameter("@Monto_Contado", SqlDbType.Money);
            param10.Value = monto;
            comando.Parameters.Add(param10);

            SqlParameter param9 = new SqlParameter("@Diferencia", SqlDbType.Money);
            param9.Value = 0;
            comando.Parameters.Add(param9);
            try
            {
                comando.Connection.Open();
                comando.ExecuteNonQuery();
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Exception(ex.Message);
            }
        }

        public int insertaNiquel(string monto)
        {
            int id = 0;
            SqlConnection connection = _manejador.DBConexion;
            SqlCommand comando = new SqlCommand("InsertInfoConteoNiquel", connection);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@denominacion5", SqlDbType.Money);
            param.Value = monto;
            comando.Parameters.Add(param);

            SqlParameter param2 = new SqlParameter("@denominacion10", SqlDbType.Money);
            param2.Value = 0;
            comando.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter("@denominacion25", SqlDbType.Money);
            param3.Value = 0;
            comando.Parameters.Add(param3);

            SqlParameter param4 = new SqlParameter("@denominacion50", SqlDbType.Money);
            param4.Value = 0;
            comando.Parameters.Add(param4);

            SqlParameter param5 = new SqlParameter("@denominacion100", SqlDbType.Money);
            param5.Value = 0;
            comando.Parameters.Add(param5);

            SqlParameter param6 = new SqlParameter("@denominacion500", SqlDbType.Money);
            param6.Value = 0;
            comando.Parameters.Add(param6);

            SqlParameter param7 = new SqlParameter("@Total_Niquel", SqlDbType.Money);
            param7.Value = monto;
            comando.Parameters.Add(param7);

            try
            {
                comando.Connection.Open();
                id = (int)comando.ExecuteScalar();
                comando.Connection.Close();
                return id;
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Exception(ex.Message);
            }
            return id;

        }



        public int getClienteID(string nombre)
        {
            int id = 0;
            SqlConnection connection = _manejador.DBConexion;
            SqlDataReader datareader = null;
            SqlCommand comando = new SqlCommand("SelectIDCliente", connection);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@nombre", SqlDbType.NVarChar);
            param.Value = nombre;
            comando.Parameters.Add(param);

            try
            {
                comando.Connection.Open();
                datareader = comando.ExecuteReader();
                while (datareader.Read())
                {
                    id = Int32.Parse(datareader["ID"].ToString());
                    comando.Connection.Close();
                    return id;
                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Exception(ex.Message);
            }
            return id;
        }

        public bool existeCajero(string pk)
        {
            int id = 0;
            SqlConnection connection = _manejador.DBConexion;
            SqlDataReader datareader = null;
            SqlCommand comando = new SqlCommand("ExisteCajero", connection);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@pk", SqlDbType.Int);
            param.Value = pk;
            comando.Parameters.Add(param);
            try
            {
                comando.Connection.Open();
                datareader = comando.ExecuteReader();
                while (datareader.Read())
                {
                    id = Int32.Parse(datareader["pk_ID"].ToString());
                    comando.Connection.Close();
                    return true;
                }

                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Exception("Error de base de datos. Detalles: " + ex.Message);
                return false;
            }
            return false;
        }

        public void insertaBillete(int denominacion, int moneda, int id_deposito)
        {
            DataTable dt2 = new DataTable();
            IDataReader datareader = null;
            SqlConnection connection = _manejador.DBConexion;
            SqlCommand comando = new SqlCommand("InsertBilleteFalsoDeposito", connection);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@ID_ProcesamientoBajoVolumenDeposito", id_deposito);
            comando.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@serie", "");
            comando.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@Moneda", moneda);
            comando.Parameters.Add(p3);
            SqlParameter p5 = new SqlParameter("@Denominacion", denominacion);
            comando.Parameters.Add(p5);
            try
            {
                comando.Connection.Open();
                datareader = comando.ExecuteReader();
                dt2.Load(datareader);
                comando.Connection.Close();
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                throw new Exception (ex.Message);
            }
        }
    }
}
