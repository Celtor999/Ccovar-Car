using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccovar.Helper
{
    class SQLHelper
    {
        private static string CadenaConexion = "server=DESKTOP-CKJVMFG;database=Ccovar;user id=sa1;password=sa1; min pool size=200;max pool size=200;";
        private static SqlConnection ConexionSQLSERVER = new SqlConnection(CadenaConexion);
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());
        public static void ConectarServidor()
        {
            try
            {
                if (ConexionSQLSERVER.State != ConnectionState.Open)
                {
                    ConexionSQLSERVER.Open();
                }
            }
            catch { }
        }
        public static void DesconectarServidor()
        {
            try
            {
                if (ConexionSQLSERVER.State == ConnectionState.Open)
                {
                    ConexionSQLSERVER.Close();
                }
            }
            catch { }
        }
        public static SqlDataReader ExecuteReaderSingleParm(SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter singleParm)
        {
            SqlCommand cmd = new SqlCommand();
            ConectarServidor();
            cmd.Connection = ConexionSQLSERVER;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = 3600;
            cmd.Parameters.Add(singleParm);
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleResult);
            return rdr;
        }
        public static SqlDataReader ExecuteReaderSingleRowSingleParm(SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter singleParm)
        {
            ConectarServidor();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConexionSQLSERVER;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = 3600;
            cmd.Parameters.Add(singleParm);
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);
            return rdr;
        }
        public static SqlDataReader ExecuteReaderSingleRow(SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            ConectarServidor();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConexionSQLSERVER;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = 3600;
            PrepareCommand(cmd, cmdParms);
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);
            return rdr;
        }
        public static SqlDataReader ExecuteReaderNoParm(SqlTransaction trans, CommandType cmdType, string cmdText)
        {
            ConectarServidor();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConexionSQLSERVER;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = 3600;
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleResult);
            return rdr;
        }
        public static SqlDataReader ExecuteReader(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            ConectarServidor();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConexionSQLSERVER;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = 3600;
            PrepareCommand(cmd, cmdParms);
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleResult);
            return rdr;
        }
        public static int ExecuteScalar(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            ConectarServidor();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = 3600;
            //  cmd.CommandType = cmdType;
            cmd.Connection = ConexionSQLSERVER;
            if (trans != null)
                cmd.Transaction = trans;
            PrepareCommand(cmd, cmdParms);
            int val = Convert.ToInt32(cmd.ExecuteScalar());
            return val;
        }

        public static SqlDataReader ExecuteScalarProc2(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            ConectarServidor();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            cmd.Connection = ConexionSQLSERVER;
            cmd.CommandTimeout = 60000;
            if (trans != null)
                cmd.Transaction = trans;
            PrepareCommand(cmd, cmdParms);
            SqlParameter returnValue = new SqlParameter("@Return_Value", DbType.Int32);
            returnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnValue);
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleResult);
            return rdr;
        }
        public static int ExecuteScalarProc(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            ConectarServidor();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = 3600;
            cmd.CommandType = cmdType;
            cmd.Connection = ConexionSQLSERVER;
            if (trans != null)
                cmd.Transaction = trans;
            PrepareCommand(cmd, cmdParms);

            SqlParameter returnValue = new SqlParameter("@Return_Value", DbType.Int32);
            returnValue.Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add(returnValue);

            cmd.ExecuteNonQuery();
            int val = Int32.Parse(cmd.Parameters["@Return_Value"].Value.ToString());

            //   int val = Convert.ToInt32(cmd.ExecuteScalar());
            return val;
        }
        public static SqlDataReader ExecuteReaderProc(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            ConectarServidor();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 3600;
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            cmd.Connection = ConexionSQLSERVER;
            if (trans != null)
                cmd.Transaction = trans;
            PrepareCommand(cmd, cmdParms);

            SqlDataReader rdr = cmd.ExecuteReader();

            return rdr;
        }
        public static SqlDataReader ExecuteReaderSingleParmProc(SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter singleParm)
        {
            SqlCommand cmd = new SqlCommand();
            ConectarServidor();
            cmd.Connection = ConexionSQLSERVER;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = 3600;
            cmd.CommandType = cmdType;
            cmd.Parameters.Add(singleParm);
            SqlDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        public static int ExecuteScalarSingleParm(SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter singleParm)
        {
            ConectarServidor();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = 3600;
            cmd.Connection = ConexionSQLSERVER;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.Parameters.Add(singleParm);
            int val = Convert.ToInt32(cmd.ExecuteScalar());
            return val;
        }
        public static object ExecuteScalarNoParm(SqlTransaction trans, CommandType cmdType, string cmdText)
        {
            ConectarServidor();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = 3600;
            cmd.Connection = ConexionSQLSERVER;
            if (trans != null)
                cmd.Transaction = trans;
            object val = cmd.ExecuteScalar();
            return val;
        }
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            ConectarServidor();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConexionSQLSERVER;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = 3600;
            PrepareCommand(cmd, cmdParms);
            int val = cmd.ExecuteNonQuery();
            return val;
        }
        public static int ExecuteNonQuerySingleParm(SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter singleParam)
        {
            ConectarServidor();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConexionSQLSERVER;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = 3600;
            cmd.Parameters.Add(singleParam);
            int val = cmd.ExecuteNonQuery();
            return val;
        }
        public static int ExecuteNonQueryNoParm(SqlTransaction trans, CommandType cmdType, string cmdText)
        {
            ConectarServidor();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConexionSQLSERVER;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = 3600;
            int val = cmd.ExecuteNonQuery();
            return val;
        }
        public static void CacheParameters(string cacheKey, params SqlParameter[] cmdParms)
        {
            parmCache[cacheKey] = cmdParms;
        }
        public static SqlParameter[] GetCacheParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }
        private static void PrepareCommand(SqlCommand cmd, SqlParameter[] cmdParms)
        {
            if (cmdParms != null)
            {
                for (int i = 0; i < cmdParms.Length; i++)
                {
                    SqlParameter parm = (SqlParameter)cmdParms[i];
                    cmd.Parameters.Add(parm);
                }
            }
        }
    }
}
