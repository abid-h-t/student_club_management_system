using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StudentClubManagement.DataAccess
{
    /// <summary>
    /// Central ADO.NET helper. Every database call in the application goes
    /// through one of the three Execute methods below, and every call is a
    /// stored procedure (CommandType.StoredProcedure) - there is no inline SQL.
    /// </summary>
    public static class DBHelper
    {
        /// <summary>Name of the connection string entry in App.config.</summary>
        private const string ConnectionName = "StudentClubDB";

        /// <summary>
        /// Reads the connection string from App.config (never hard-coded).
        /// </summary>
        public static string GetConnectionString()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[ConnectionName];

            if (settings == null || string.IsNullOrWhiteSpace(settings.ConnectionString))
            {
                throw new ConfigurationErrorsException(
                    "The connection string '" + ConnectionName + "' is missing from the application's .config file.");
            }

            return settings.ConnectionString;
        }

        /// <summary>
        /// Builds a stored-procedure parameter. A null value (or a blank
        /// string) is sent to SQL Server as NULL.
        /// </summary>
        public static SqlParameter Param(string name, object value)
        {
            string text = value as string;
            if (value == null || (text != null && text.Trim().Length == 0))
            {
                return new SqlParameter(name, DBNull.Value);
            }

            return new SqlParameter(name, value);
        }

        /// <summary>
        /// Runs a stored procedure that returns rows (GetAll, GetByID, Search,
        /// reports) and returns them as a DataTable for grid binding.
        /// </summary>
        public static DataTable ExecuteDataTable(string procedureName, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            using (SqlCommand command = CreateCommand(connection, procedureName, parameters))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable table = new DataTable();
                adapter.Fill(table); // Fill opens and closes the connection itself
                return table;
            }
        }

        /// <summary>
        /// Runs a stored procedure that changes data (Update, Delete, ...) and
        /// returns the procedure's RETURN value, which is the number of rows
        /// affected. Business-rule failures arrive as a SqlException.
        /// </summary>
        public static int ExecuteNonQuery(string procedureName, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            using (SqlCommand command = CreateCommand(connection, procedureName, parameters))
            {
                SqlParameter returnValue = command.Parameters.Add("@ReturnValue", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;

                connection.Open();
                command.ExecuteNonQuery();

                return returnValue.Value == null || returnValue.Value == DBNull.Value
                    ? 0
                    : Convert.ToInt32(returnValue.Value);
            }
        }

        /// <summary>
        /// Runs a stored procedure and returns the first column of the first
        /// row (used by the Insert procedures, which SELECT the new identity).
        /// </summary>
        public static object ExecuteScalar(string procedureName, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            using (SqlCommand command = CreateCommand(connection, procedureName, parameters))
            {
                connection.Open();
                object result = command.ExecuteScalar();
                return result == DBNull.Value ? null : result;
            }
        }

        /// <summary>
        /// Creates the SqlCommand for a stored procedure and attaches its parameters.
        /// </summary>
        private static SqlCommand CreateCommand(SqlConnection connection, string procedureName, SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(procedureName, connection);
            command.CommandType = CommandType.StoredProcedure;

            if (parameters != null && parameters.Length > 0)
            {
                command.Parameters.AddRange(parameters);
            }

            return command;
        }
    }
}
