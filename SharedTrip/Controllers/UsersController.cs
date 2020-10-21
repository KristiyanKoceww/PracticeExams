using SharedTrip.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        public HttpResponse Login()
        {
            if (IsUserSignedIn())
            {
                return this.Redirect("/Trips/All");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse Login(string username,string password)
        {
            if (IsUserSignedIn())
            {
                return this.Redirect("/Trips/All");
            }
            var userId = this.userService.GetUserId(username, password);
            if (userId == null)
            {
                this.Redirect("/Users/Login");
            }

            this.SignIn(userId);
            return this.Redirect("/Trips/All");
        }

        public HttpResponse Register()
        {
            if (IsUserSignedIn())
            {
                return this.Redirect("/Trips/All");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse Register(string username,string email,string password,string confirmPassword)
        {
            if (IsUserSignedIn())
            {
                return this.Redirect("/Trips/All");
            }
            if (string.IsNullOrEmpty(username) || username.Length < 5 || username.Length >20)
            {
                return this.Error("Username must be between 5 and 20 characters!");
            }
            if (!userService.IsUsernameAvailable(username))
            {
                return this.Error("Username is taken! Please, choose other username");
            }
            if (string.IsNullOrEmpty(email) || !new EmailAddressAttribute().IsValid(email))
            {
                return this.Error("Insert valid email!");
            }
            if (!userService.IsEmailAvailable(email))
            {
                return this.Error("Email is taken!");
            }
            if (string.IsNullOrEmpty(password) || password.Length <6 || password.Length > 20)
            {
                return this.Error("Password must be between 6 and 20 characters");
            }
            if (password != confirmPassword)
            {
                return this.Error("Passwords doest not match!");
            }

            this.userService.CreateUser(username, email, password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
