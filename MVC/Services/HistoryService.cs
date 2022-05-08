using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Written by Owen Ravelo

namespace Services
{
    public class HistoryService
    {
        WebRequest.APICall api = new WebRequest.APICall();

        public async Task<HistoryResponseModel> GetPastGames(string token) 
        {
            var response = await api.History(token);
            return response ?? new HistoryResponseModel() { Authorized = false, Authenticated = false, Success = false };
        }
    }
}
