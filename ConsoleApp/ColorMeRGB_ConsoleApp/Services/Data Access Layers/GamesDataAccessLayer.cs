using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Models;

namespace Services.Data_Access_Layers
{
    public class GamesDataAccessLayer
    {
        private string sqlConnectString = string.Empty;
        private DataBaseConnectionSingleton connectionSingleton;

        public GamesDataAccessLayer()
        {
            connectionSingleton = DataBaseConnectionSingleton.Instance();
            this.sqlConnectString = connectionSingleton.PrepareDBConnection();
        }

        /// <summary>
        /// Insert a record into the table
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public Guid GamesInsertRecords(GameRecordModel record)
        {
            //Make sure we reference the proper connection
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                //Use this to reference the Stored Proceure that we are using for this operation
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[GamesInsertRecords]", conn))
                {
                    //Specify the interpretation of the command string
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    //Pass the proper values into the parameters of the stored procedure
                    sqlCommand.Parameters.AddWithValue("@UserID", record.UserId).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@AnswerColor", record.Answer).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Timestamp", record.Timestamp).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Completed", record.Completed).Direction = ParameterDirection.Input;
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
        /// Get all rows in the Games table
        /// </summary>
        /// <returns>List of all rows</returns>
        public List<GameRecordModel> GamesGetAll()
        {
            //List to store the rows that are retrieved by this stored procedure
            List<GameRecordModel> statList = new List<GameRecordModel>();

            //Make sure we reference the proper connection
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                //Use this to reference the Stored Proceure that we are using for this operation
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[GamesGetAll]", conn))
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
        /// <returns>List of all rows corresponding to ID</returns>
        public List<GameRecordModel> GamesGetById(Guid id)
        {
            List<GameRecordModel> statList = new List<GameRecordModel>();

            //Make sure we reference the proper connection
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                //Use this to reference the Stored Proceure that we are using for this operation
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[GamesGetById]", conn))
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
        /// Get the row corresponding to passed in User ID (good for testing update)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of all rows corresponding to User ID</returns>
        public List<GameRecordModel> GamesGetByUserId(Guid id)
        {
            List<GameRecordModel> statList = new List<GameRecordModel>();

            //Make sure we reference the proper connection
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                //Use this to reference the Stored Proceure that we are using for this operation
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[GamesGetByUserId]", conn))
                {
                    //Specify the interpretation of the command string
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    //the parameter used to find the rows that are associated with the specified name
                    sqlCommand.Parameters.AddWithValue("@UserID", id).Direction = ParameterDirection.Input;

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
        /// <returns>String that declares failure or success</returns>
        public string GamesDeleteByID(Guid id)
        {
            //Make sure we reference the proper connection
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                //Use this to reference the Stored Proceure that we are using for this operation
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[GamesDeleteByID]", conn))
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

        private GameRecordModel MapToModel(SqlDataReader? result)
        {
            GameRecordModel model = new GameRecordModel();

            model.Id = (Guid)result["id"];
            model.UserId = (Guid)result["user_id"];
            model.Timestamp = (DateTime)result["timestamp"];
            model.Answer = (string?)result["answer_color"];
            model.Completed = (bool)result["completed"];

            return model;
        }

    }
}
