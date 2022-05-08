using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Services.Models;
using System.Text.Json;

// written by Owen Ravelo

namespace Services.WebRequest
{
    public class APICall
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string ApiKey = "ZMpNcnWQUGAsyf66QC2ntk46VFFUfKTL";
        private readonly string ApiUrl = "https://localhost:7259/api/";

        public APICall() 
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Asp-Net MVC");
        }


        /// <summary>
        /// Makes request to an api and returns a string with json
        /// </summary>
        /// <param name="url">Api endpoint</param>
        /// <param name="verb">The http verb to use</param>
        /// <param name="body">The json content as a string</param>
        /// <returns>Json object string</returns>
        private async Task<string?> MakeRequest(string url, HttpMethod verb, object requestBody) 
        {
            string body = JsonSerializer.Serialize(requestBody);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = verb,
                RequestUri = new Uri(url),
                Content = new StringContent(body, Encoding.UTF8, "application/json"),
            };

            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            return result ?? null;
        }

        public async Task<AuthResponseModel?> Signup(string username, string password) 
        {
            string url = ApiUrl + "auth/signup";
            AuthRequestModel model = new AuthRequestModel() {
                ApiKey = ApiKey,
                Username = username,
                Password = password
            };
            string? result = await MakeRequest(url, HttpMethod.Post, model);
            AuthResponseModel? response = result != null ? JsonSerializer.Deserialize<AuthResponseModel>(result) : null;
            return response;
        }

        public async Task<AuthResponseModel?> Login(string username, string password)
        {
            string url = ApiUrl + "auth/login";
            AuthRequestModel model = new AuthRequestModel()
            {
                ApiKey = ApiKey,
                Username = username,
                Password = password
            };
            string? result = await MakeRequest(url, HttpMethod.Post, model);
            AuthResponseModel? response = result != null ? JsonSerializer.Deserialize<AuthResponseModel>(result) : null;
            return response;
        }

        public async Task<GameResponseModel?> NewGame(string AuthToken)
        {
            string url = ApiUrl + "game/new";
            GameRequestModel model = new GameRequestModel()
            {
                ApiKey = ApiKey,
                AuthToken = AuthToken,
            };
            string? result = await MakeRequest(url, HttpMethod.Post, model);
            GameResponseModel? response = result != null ? JsonSerializer.Deserialize<GameResponseModel>(result) : null;
            return response;
        }
        public async Task<GameResponseModel?> StartGame(string AuthToken, Guid GameId, string Color)
        {
            string url = ApiUrl + "game/start";
            GameRequestModel model = new GameRequestModel()
            {
                ApiKey = ApiKey,
                AuthToken = AuthToken,
                GameID = GameId,
                Color = Color,
            };
            string? result = await MakeRequest(url, HttpMethod.Post, model);
            GameResponseModel? response = result != null ? JsonSerializer.Deserialize<GameResponseModel>(result) : null;
            return response;
        }
        public async Task<GameResponseModel?> Guess(string AuthToken, Guid GameId, string Color, float Distance, bool isCorrect, bool isEnd)
        {
            string url = ApiUrl + "game/guess";
            GameRequestModel model = new GameRequestModel()
            {
                ApiKey = ApiKey,
                AuthToken = AuthToken,
                GameID = GameId,
                Color = Color,
                Distance = Distance,
                isCorrect = isCorrect,
                isEnd = isEnd,
            };
            string? result = await MakeRequest(url, HttpMethod.Post, model);
            GameResponseModel? response = result != null ? JsonSerializer.Deserialize<GameResponseModel>(result) : null;
            return response;
        }

        public async Task<HistoryResponseModel?> Guess(string AuthToken)
        {
            string url = ApiUrl + "history/all";
            HistoryRequestModel model = new HistoryRequestModel()
            {
                ApiKey = ApiKey,
                AuthToken = AuthToken
            };
            string? result = await MakeRequest(url, HttpMethod.Get, model);
            HistoryResponseModel? response = result != null ? JsonSerializer.Deserialize<HistoryResponseModel>(result) : null;
            return response;
        }
    }
}
