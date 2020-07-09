using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SQLHelper
{
    static public class Connection
    {
        public static SqlConnection Get_DB_Connetion(string connectionString)
        {
            SqlConnection cn_connection = new SqlConnection(connectionString);
            if (cn_connection.State != System.Data.ConnectionState.Open)
                cn_connection.Open();
            Debug.WriteLine("ServerVersion: {0}", cn_connection.ServerVersion);
            Debug.WriteLine("{0} Connection:{1}", cn_connection.State, cn_connection.ConnectionString);
            return cn_connection;
        }

        public static void Close_DB_Connection(string connectionString)
        {
            SqlConnection cn_connection = new SqlConnection(connectionString);
            if (cn_connection.State != ConnectionState.Closed)
            {
                cn_connection.Close();
                Debug.WriteLine("ServerVersion: {0}", cn_connection.ServerVersion);
                Debug.WriteLine("{0} Connection:{1}", cn_connection.State, cn_connection.ConnectionString);
            }
        }
    }

    static public class Data
    { 
        /// <summary>
        /// Returns a dataTable of the requested sql string
        /// </summary>
        /// <param name="SQL_Text"></param>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable(string connectionString, string sqlCommand)
        {
            SqlConnection sqlConn = Connection.Get_DB_Connetion(connectionString);
            using (SqlCommand cmd = new SqlCommand(sqlCommand, sqlConn))
            {
                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                Debug.WriteLine("Returned dataTable for statement: " + sqlCommand);
                return dataTable;
            }
        }

        /// <summary>
        /// Execute the sql string (e.g. DELETE)
        /// </summary>
        /// <param name="SQL_Text"></param>
        public static void Execute_SQL(string connectionString, string SQL_Text)
        {
            SqlConnection sqlConn = Connection.Get_DB_Connetion(connectionString);
            SqlCommand cmd_Command = new SqlCommand(SQL_Text, sqlConn);
            cmd_Command.ExecuteNonQuery();
            cmd_Command.Dispose();
        }
    }
}
