using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Architecture
{
    public class SQL
    {
        public void LoadDataTable(ref DataTable dataTable, string connectionString, string sqlStatement)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(sqlStatement, connection);

                        dataTable.Load(cmd.ExecuteReader());
                        connection.Close();
                    }
                    catch (SqlException ex)
                    {
                        throw new CustomSqlException("Execption thrown by LoadDataTable() in Architecture: ", ex);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                errorMessages.Append("ERROR: Index #\n" +
                    "Message: " + ex.Message + "\n");
                throw new ArgumentException(errorMessages.ToString());
            }
        }

        public void RunSqlStatement(string connectionString, string sqlStatement)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(sqlStatement, connection);

                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (SqlException ex)
                    {
                        throw new CustomSqlException("Execption thrown by RunSqlStatement() in Architecture: ", ex);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                errorMessages.Append("ERROR: Index #\n" +
                    "Message: " + ex.Message + "\n");
                throw new ArgumentException(errorMessages.ToString());
            }
        }
    }
}
