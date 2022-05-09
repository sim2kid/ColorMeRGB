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
    //Author: Sebastian Pedersen
    //Creation Date: April 22, 2022
    public class UsersDataAccessLayer
    {
        private string sqlConnectString = string.Empty;
        private DataBaseConnectionSingleton connectionSingleton;

        //Establish a connection to the database
        public UsersDataAccessLayer()
        {
            connectionSingleton = DataBaseConnectionSingleton.Instance();
            this.sqlConnectString = connectionSingleton.PrepareDBConnection();
        }

        /// <summary>
        /// Insert records into the users table
        /// </summary>
        /// <param name="record"></param>
        /// <returns>The id of the user record inserted</returns>
        public Guid UsersInsertRecords(UserRecordModel record)
        {
            //Make sure we reference the proper connection
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                //Use this to reference the Stored Proceure that we are using for this operation
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[UsersInsertRecords]", conn))
                {
                    //Specify the interpretation of the command string
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    //Pass the proper values into the parameters of the stored procedure
                    sqlCommand.Parameters.AddWithValue("@Username", record.Username).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Password", record.Password).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Salt", record.Salt).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@SignupTime", record.SignupTime).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.Add("@ReturnValue", SqlDbType.UniqueIdentifier).Direction = ParameterDirection.Output;


                    conn.Open(); //open the connection with the previously established reference
                    sqlCommand.ExecuteNonQuery(); //execute the stored procedure
                    var result = (Guid)sqlCommand.Parameters["@ReturnValue"].Value; //return the id of the row that was inserted
                    conn.Close(); //close the connection
                    return result;

                }
            }
        }

        /// <summary>
        /// Update a row that corresponds to the passed in id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        public string UsersUpdateRecordById(Guid id, UserRecordModel record)
        {
            //Make sure we reference the proper connection
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                //Use this to reference the Stored Proceure that we are using for this operation
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[UsersUpdateRecordById]", conn))
                {
                    //Specify the interpretation of the command string
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    //Pass the proper values into the parameters of the stored procedure
                    sqlCommand.Parameters.AddWithValue("@Username", record.Username).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Password", record.Password).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Salt", record.Salt).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@SignUpTime", record.SignupTime).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@UserID", id).Direction = ParameterDirection.Input;


                    conn.Open(); //open the connection with the previously established reference
                    string result = sqlCommand.ExecuteNonQuery() == 0 ? $"Update {id} Failed" : $"Update {id} Success"; //Respond as to whether the update failed or succeeded
                    conn.Close(); //close the connection
                    return result;
                }
            }
        }

        /// <summary>
        /// Get all rows in the Users table
        /// </summary>
        /// <returns>List of all the rows</returns>
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
        /// <returns>List of all the rows corresponding to ID</returns>
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
        /// Get the row corresponding to passed in username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>List of all the rows corresponding to username</returns>
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
        /// <returns>string that declares success or failure</returns>
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

        //Map to the model in Services.Models so it can be used and referenced by this C# solution
        private UserRecordModel MapToModel(SqlDataReader? result)
        {
            UserRecordModel model = new UserRecordModel();

            model.Id = (Guid)result["id"];
            model.Username = (string)result["username"];
            model.Password = (string)result["password"];
            model.Salt = (string)result["salt"];
            model.SignupTime = (DateTime)result["signup_time"];

            return model;
        }
    }
}
