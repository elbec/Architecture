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
                        WriteSqlExceptionToConsole(ex);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                errorMessages.Append("ERROR: Index #\n" +
                    "Message: " + ex.Message + "\n");
                Console.WriteLine(errorMessages.ToString());
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
                        WriteSqlExceptionToConsole(ex);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                errorMessages.Append("ERROR: Index #\n" +
                    "Message: " + ex.Message + "\n");
                Console.WriteLine(errorMessages.ToString());
            }
        }

        private void WriteSqlExceptionToConsole(SqlException ex)
        {
            StringBuilder errorMessages = new StringBuilder();
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                errorMessages.Append("ERROR: Index #" + i + "\n" +
                    "Source: " + ex.Errors[i].Source + "\n" +
                    "Number: " + ex.Errors[i].Number.ToString() + "\n" +
                    "State: " + ex.Errors[i].State.ToString() + "\n" +
                    "Class: " + ex.Errors[i].Class.ToString() + "\n" +
                    "Server: " + ex.Errors[i].Server + "\n" +
                    "Message: " + ex.Errors[i].Message + "\n" +
                    "Procedure: " + ex.Errors[i].Procedure + "\n" +
                    "LineNumber: " + ex.Errors[i].LineNumber.ToString());
            }
            Console.WriteLine(errorMessages.ToString());
        }
    }
}
