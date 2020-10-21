using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services
{
    public interface ITripService
    {
        void Add(string startPoint, string endPoint, DateTime departureTime, int seats, string description, string imagePath);
        IEnumerable<AllTripsViewModel> GetAll();
        TripDetailsViewModel GetDetails(string tripId);
        bool HasAvailableSeats(string tripId);
        bool AddUserToTrip(string userId, string tripId);

    }
}
