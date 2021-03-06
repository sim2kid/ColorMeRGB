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
    public class GuessesDataAccessLayer
    {
        private string sqlConnectString = string.Empty;
        private DataBaseConnectionSingleton connectionSingleton;

        //Establish a connection to the database
        public GuessesDataAccessLayer()
        {
            connectionSingleton = DataBaseConnectionSingleton.Instance();
            this.sqlConnectString = connectionSingleton.PrepareDBConnection();
        }


        /// <summary>
        /// Insert records into the guesses database
        /// </summary>
        /// <param name="record"></param>
        /// <returns>The id of the stored record</returns>
        public Guid GuessesInsertRecords(GuessRecordModel record)
        {
            //Make sure we reference the proper connection
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                //Use this to reference the Stored Proceure that we are using for this operation
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[GuessesInsertRecords]", conn))
                {
                    //Specify the interpretation of the command string
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    //Pass the proper values into the parameters of the stored procedure
                    sqlCommand.Parameters.AddWithValue("@GameID", record.GameId).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@GuessColor", record.Guess).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Distance", record.Distance).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Timestamp", record.Timestamp).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@IsCorrect", record.IsCorrect).Direction = ParameterDirection.Input;
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
        public string GuessesUpdateRecordById(Guid id, GuessRecordModel record)
        {
            //Make sure we reference the proper connection
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                //Use this to reference the Stored Proceure that we are using for this operation
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[GuessesUpdateRecordById]", conn))
                {
                    //Specify the interpretation of the command string
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    //Pass the proper values into the parameters of the stored procedure
                    sqlCommand.Parameters.AddWithValue("@Timestamp", record.Timestamp).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Distance", record.Distance).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@GuessColor", record.Guess == null ? "ffffff" : record.Guess).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@IsCorrect", record.IsCorrect).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@GuessID", id).Direction = ParameterDirection.Input;


                    conn.Open(); //open the connection with the previously established reference
                    string result = sqlCommand.ExecuteNonQuery() == 0 ? $"Update {id} Failed" : $"Update {id} Success"; //Respond as to whether the update failed or succeeded
                    conn.Close(); //close the connection
                    return result;
                }
            }
        }

        /// <summary>
        /// Get all rows in the Guesses table
        /// </summary>
        /// <returns>List of all rows</returns>
        public List<GuessRecordModel> GuessesGetAll()
        {
            //List to store the rows that are retrieved by this stored procedure
            List<GuessRecordModel> statList = new List<GuessRecordModel>();

            //Make sure we reference the proper connection
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                //Use this to reference the Stored Proceure that we are using for this operation
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[GuessesGetAll]", conn))
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
        public List<GuessRecordModel> GuessesGetById(Guid id)
        {
            List<GuessRecordModel> statList = new List<GuessRecordModel>();

            //Make sure we reference the proper connection
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                //Use this to reference the Stored Proceure that we are using for this operation
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[GuessesGetById]", conn))
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
        /// <returns>List of all rows corresponding to Game ID</returns>
        public List<GuessRecordModel> GuessessGetByGameId(Guid id)
        {
            List<GuessRecordModel> statList = new List<GuessRecordModel>();

            //Make sure we reference the proper connection
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                //Use this to reference the Stored Proceure that we are using for this operation
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[GuessesGetByGameId]", conn))
                {
                    //Specify the interpretation of the command string
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    //the parameter used to find the rows that are associated with the specified name
                    sqlCommand.Parameters.AddWithValue("@GameID", id).Direction = ParameterDirection.Input;

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

        //Map to the model in Services.Models so it can be used and referenced by this C# solution
        private GuessRecordModel MapToModel(SqlDataReader? result)
        {
            GuessRecordModel model = new GuessRecordModel();

            model.Id = (Guid)result["id"];
            model.GameId = (Guid)result["game_id"];
            model.Guess = (string)result["guess_color"];
            model.Distance = (float)(double)result["distance"];
            model.Timestamp = (DateTime)result["timestamp"];
            model.IsCorrect = (bool)result["is_correct"];

            return model;
        }
    }
}
