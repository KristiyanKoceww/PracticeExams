﻿namespace SharedTrip
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Services;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class Startup : IMvcApplication
    {
     
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUserService, UserService>();
            serviceCollection.Add<ITripService, TripService>();
            serviceCollection.Add<IUserTripService, UserTripService>();
        }
    }
}
