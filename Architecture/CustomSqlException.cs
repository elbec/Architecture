using System;

using System.Data.SqlClient;

namespace Architecture
{
    public class CustomSqlException : Exception
    {
        public CustomSqlException()
        {
        }

        public CustomSqlException(string message, SqlException innerException) : base(message, innerException)
        {
        }
    }
}

