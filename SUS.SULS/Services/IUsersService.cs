using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.SULS.Services
{
    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);
        bool isEmailAvailable(string email);
        bool isUserNameAvailable(string username);
        string GetUserId(string username,string password);
    }
}
