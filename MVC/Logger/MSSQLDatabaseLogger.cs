using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

// Written by Owen Ravelo

namespace Logger
{
    public class MSSQLDatabaseLogger : BaseLogger
    {
        private SqlConnectionStringBuilder connection;
        
        public MSSQLDatabaseLogger() 
        {
            connection = new SqlConnectionStringBuilder();
            connection.DataSource = $"(localdb)\\MSSQLLocalDB";
            connection.IntegratedSecurity = true;
            connection.InitialCatalog = $"ColorMeRGB";
        }

        public override void Log(ILogger.LogLevel level, string message, Guid? user = null, string? exception = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connection.ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[dbo].[Log]", conn))
                    {
                        //Specify the interpretation of the command string
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        //Pass the proper values into the parameters of the stored procedure
                        sqlCommand.Parameters.AddWithValue("@source", "").Direction = ParameterDirection.Input; // Left blank for now
                        sqlCommand.Parameters.AddWithValue("@level", level.ToString()).Direction = ParameterDirection.Input;
                        sqlCommand.Parameters.AddWithValue("@userid", user).Direction = ParameterDirection.Input;
                        sqlCommand.Parameters.AddWithValue("@message", message).Direction = ParameterDirection.Input;
                        sqlCommand.Parameters.AddWithValue("@@exception", exception).Direction = ParameterDirection.Input;


                        conn.Open(); //open the connection with the previously established reference
                        sqlCommand.ExecuteNonQuery(); //execute the stored procedure
                        conn.Close(); //close the connection
                    }
                }
            }
            catch { }
        }
    }
}
