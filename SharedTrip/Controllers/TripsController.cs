using SharedTrip.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService tripService;

        public TripsController(ITripService tripService)
        {
            this.tripService = tripService;
        }
        public HttpResponse Add()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }
        [HttpPost]
        public HttpResponse Add(string startPoint, string endPoint, DateTime departureTime, string imagePath, int seats, string description)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            if (seats < 2 || seats > 6)
            {
                return this.Error("Seats must be between 2 and 6!");
            }
            if (string.IsNullOrEmpty(startPoint))
            {
                return this.Error("Please enter startPoint");
            }
            if (string.IsNullOrEmpty(endPoint))
            {
                return this.Error("Please enter endPoint");
            }
            if (string.IsNullOrEmpty(description) || description.Length > 80)
            {
                return this.Error("Description max lenght is 80 characters!");
            }
            //if (!DateTime.TryParseExact(departureTime, "dd.MM.yyyy HH:mm",CultureInfo.InvariantCulture,DateTimeStyles.None ,out _))
            //{
            //    return this.Error("Please enter valid format");
            //}
            //if (string.IsNullOrEmpty(imagePath))
            //{
            //    return this.Error("Please enter image path!");
            //}

            this.tripService.Add(startPoint, endPoint, departureTime, seats, description, imagePath);
            return this.Redirect("/Trips/All");

        }

        public HttpResponse All()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var viewModel = tripService.GetAll();
            return this.View(viewModel);
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var viewModel = tripService.GetDetails(tripId);
            return this.View(viewModel);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            if (!this.tripService.HasAvailableSeats(tripId))
            {
                return this.Error("No seats available.");
            }

            var userId = this.GetUserId();

            if (!this.tripService.AddUserToTrip(userId, tripId))
            {
                return this.Redirect("/Trips/Details?tripId=" + tripId);
            }
            

            return this.Redirect("/");
        }
    }
}
