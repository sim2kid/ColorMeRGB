using Services.Data_Access_Layers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Written by Owen Ravelo

namespace Services
{
    public class AuthenticationService
    {
        UsersDataAccessLayer uDal = new UsersDataAccessLayer();

        public bool DoesUserExist(string username) 
        {
            var users = uDal.UsersGetByUserName(username);
            return users.Count > 0;
        }

        public (string hash, string salt) GeneratePassword(string input) 
        {
            string salt = Services.Utilities.HashUtil.GenerateSalt();
            string preHashedPassword = input;
            string hash = Services.Utilities.HashUtil.HashPassword(preHashedPassword, salt);

            return (hash, salt);
        }

        public void AddUser(UserRecordModel model) 
        {
            uDal.UsersInsertRecords(model);
        }

        public bool isValidLogin(string username, string password, out Guid id) 
        {
            var users = uDal.UsersGetByUserName(username);
            id = new Guid();
            if (users.Count < 0) 
            {
                return false;
            }
            var user = users[0];
            id = user.Id;
            return Services.Utilities.HashUtil.CheckPassword(user.Password, password, user.Salt);
        }
    }
}
