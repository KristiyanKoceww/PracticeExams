﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.ViewModels.Trips
{
    public class TripDetailsViewModel : AllTripsViewModel
    {
       
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string DepartureTimeFormatted => this.DepartureTime.ToString("s");
    }
}
