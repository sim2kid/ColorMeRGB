using Services.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Data_Access_Layers
{
    public class UsersDataAccessLayer
    {
        private string sqlConnectString = string.Empty;
        private DataBaseConnectionSingleton connectionSingleton;
        public UsersDataAccessLayer()
        {
            connectionSingleton = DataBaseConnectionSingleton.Instance();
            this.sqlConnectString = connectionSingleton.PrepareDBConnection();
        }
        
        /// <summary>
        /// Get all rows in the Games table
        /// </summary>
        /// <returns></returns>
        public List<UserRecordModel> UsersGetAll()
        {
            //List to store the rows that are retrieved by this stored procedure
            List<UserRecordModel> statList = new List<UserRecordModel>();

            //Make sure we reference the proper connection
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                //Use this to reference the Stored Proceure that we are using for this operation
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[UsersGetAll]", conn))
                {
                    //Specify the interpretation of the command string
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    //Open the connection
                    conn.Open();
                    //used to read the records that are retrieved
                    var result = sqlCommand.ExecuteReader();

                    //basically foreach row in the table
                    while (result.Read())
                    {
                        //map to a model
                        //add the model to the list
                        statList.Add(MapToModel(result));
                    }

                    conn.Close(); //Close the connection
                }
            }

            return statList;
        }

        /// <summary>
        /// Get the row corresponding to passed in ID (good for testing update)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UserRecordModel> UsersGetById(Guid id)
        {
            List<UserRecordModel> statList = new List<UserRecordModel>();

            //Make sure we reference the proper connection
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                //Use this to reference the Stored Proceure that we are using for this operation
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[UsersGetById]", conn))
                {
                    //Specify the interpretation of the command string
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    //the parameter used to find the rows that are associated with the specified name
                    sqlCommand.Parameters.AddWithValue("@ID", id).Direction = ParameterDirection.Input;

                    conn.Open();
                    var result = sqlCommand.ExecuteReader();

                    //foreach row where @PlayerName = name
                    while (result.Read())
                    {
                        statList.Add(MapToModel(result));
                    }

                    conn.Close();
                }
            }

            return statList;
        }

        /// <summary>
        /// Get the row corresponding to passed in ID (good for testing update)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UserRecordModel> UsersGetByUserName(string username)
        {
            List<UserRecordModel> statList = new List<UserRecordModel>();

            //Make sure we reference the proper connection
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                //Use this to reference the Stored Proceure that we are using for this operation
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[UsersGetByUserName]", conn))
                {
                    //Specify the interpretation of the command string
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    //the parameter used to find the rows that are associated with the specified name
                    sqlCommand.Parameters.AddWithValue("@UserName", username).Direction = ParameterDirection.Input;

                    conn.Open();
                    var result = sqlCommand.ExecuteReader();

                    //foreach row where @PlayerName = name
                    while (result.Read())
                    {
                        statList.Add(MapToModel(result));
                    }

                    conn.Close();
                }
            }

            return statList;
        }

        /// <summary>
        /// Delete the row with corresponding "id" parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string UsersDeleteByID(Guid id)
        {
            //Make sure we reference the proper connection
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                //Use this to reference the Stored Proceure that we are using for this operation
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[UsersDeleteByID]", conn))
                {
                    //Specify the interpretation of the command string
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    //the parameter used to find the row with the corresponding ID that was passed in
                    sqlCommand.Parameters.AddWithValue("@ID", id).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.Output;

                    conn.Open();
                    //if the stored procedure executed properly, then return a string that declared success. Else, return a string that declares failure
                    string result = sqlCommand.ExecuteNonQuery() == 0 ? "Operation Failed" : "Operation Success";
                    conn.Close();
                    return result;
                }
            }
        }

        private UserRecordModel MapToModel(SqlDataReader? result)
        {
            UserRecordModel model = new UserRecordModel();

            model.Id = (Guid)result["id"];
            model.Username = (string)result["username"];
            model.Password = (string)result["password"];
            model.Salt = (int)result["salt"];

            return model;
        }
    }
}
