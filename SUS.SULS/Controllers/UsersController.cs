using SUS.HTTP;
using SUS.MvcFramework;
using SUS.SULS.Data;
using SUS.SULS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SUS.SULS.Controllers
{
    public class UsersController : Controller
    {
        
        private readonly IUsersService userService;

        public UsersController( IUsersService userService)
        {
            this.userService = userService;
        }
        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            var userId = this.userService.GetUserId(username, password);
            if (userId == null)
            {
                return this.Error("Invalid username or password");
            }
            this.SignIn(userId);
            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse Register(string username, string email, string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(username) || username.Length < 5 || username.Length > 20)
            {
                return this.Error("Username must be between 5 and 20 characters long");
            }
            if (!userService.isUserNameAvailable(username))
            {
                return this.Error("Username is already taken.Please insert other username!");
            }
            if (!userService.isEmailAvailable(email))
            {
                return this.Error("Email is already taken.Please insert other Email!");
            }
            if (string.IsNullOrEmpty(email) || !new EmailAddressAttribute().IsValid(email))
            {
                return this.Error("Invalid email address.");
            }
            if (string.IsNullOrEmpty(password) || password.Length < 6 || password.Length > 20)
            {
                return this.Error("Password must be between 6 and 20 characters long");
            }
            if (password != confirmPassword)
            {
                return this.Error("Password doesnt macht!Please check.");
            }

            this.userService.CreateUser(username, email, password);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
