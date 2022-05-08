using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// written by Owen Ravelo

namespace Services
{
    public class AuthService
    {
        WebRequest.APICall api = new WebRequest.APICall();
        
        /// <summary>
        /// Grabs the response for a login request
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<AuthResponseModel> Login(string username, string password) 
        {
            string hashword = Utilities.HashUtil.HashPassword(password);
            var response = await api.Login(username, password);
            return response ?? new AuthResponseModel() { Authorized = false, Success = false };
        }

        public async Task<AuthResponseModel> Signup(string username, string password) 
        {
            string hashword = Utilities.HashUtil.HashPassword(password);
            var response = await api.Signup(username, password);
            return response ?? new AuthResponseModel() { Authorized = false, Success = false };
        }
    }
}
