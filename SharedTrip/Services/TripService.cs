using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly ApplicationDbContext db;

        public TripService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Add(string startPoint, string endPoint, DateTime departureTime, int seats, string description, string imagePath)
        {
            var trip = new Trip()
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
                DepartureTime = departureTime,
                Seats = seats,
                Description = description,
                ImagePath = imagePath,
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public bool AddUserToTrip(string userId, string tripId)
        {
            
            var userInTrip = this.db.UserTrips.Any(x => x.UserId == userId && x.TripId == tripId);
            if (userInTrip)
            {
                return false;
            }
            var userTrip = new UserTrip()
            {
                TripId = tripId,
                UserId = userId
            };
            this.db.UserTrips.Add(userTrip);
            this.db.SaveChanges();
            return true;
        }

        public IEnumerable<AllTripsViewModel> GetAll()
        {
            var trips = this.db.Trips.Select(x => new AllTripsViewModel
            {
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                DepartureTime = x.DepartureTime,
                Id = x.Id,
                Seats = x.Seats,
                UsedSeats = x.UserTrips.Count()
            }).ToList();

            return trips;
        }

        public TripDetailsViewModel GetDetails(string tripId)
        {
            var trip = this.db.Trips.Where(x => x.Id == tripId).Select(a => new TripDetailsViewModel
            {
                StartPoint = a.StartPoint,
                EndPoint = a.EndPoint,
                DepartureTime = a.DepartureTime,
                Description = a.Description,
                Id = a.Id,
                ImagePath = a.ImagePath,
                Seats = a.Seats,
                UsedSeats = a.UserTrips.Count()

            }).FirstOrDefault();

            return trip;
        }

        public bool HasAvailableSeats(string tripId)
        {
            var trip = this.db.Trips.Where(x => x.Id == tripId).Select(x => new { x.Seats, TakenSeats = x.UserTrips.Count() }).FirstOrDefault();

            var availableSeats = trip.Seats - trip.TakenSeats;
            return availableSeats > 0;
        }
    }
}
