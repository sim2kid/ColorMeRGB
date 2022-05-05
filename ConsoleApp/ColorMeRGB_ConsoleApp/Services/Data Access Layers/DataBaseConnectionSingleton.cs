using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Data_Access_Layers
{
    //Author: Sebastian Pedersen
    //Date Created: April 29, 2022
    public class DataBaseConnectionSingleton
    {
        private static DataBaseConnectionSingleton instance;

        //use this to reference the DB connection
        private static SqlConnectionStringBuilder connectionBuilder;

        public static DataBaseConnectionSingleton Instance()
        {
            if (instance == null)
            {
                instance = new DataBaseConnectionSingleton();
                connectionBuilder = new SqlConnectionStringBuilder();
            }
            return instance;
        }

        private DataBaseConnectionSingleton() { }

        public string PrepareDBConnection()
        {
            connectionBuilder.DataSource = $"(localdb)\\MSSQLLocalDB";
            connectionBuilder.IntegratedSecurity = true;
            connectionBuilder.InitialCatalog = $"ColorMeRGB";

            //The string that is associated and will be used to reference/represent the DB connection
            return connectionBuilder.ConnectionString;
        }
    }
}
