using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services
{
   public interface IUserService
    {
        void CreateUser(string username, string emailHelp, string password);
        bool IsUsernameAvailable(string username);
        bool IsEmailAvailable(string emailHelp);
        string GetUserId(string username, string password);
       
    }
}
