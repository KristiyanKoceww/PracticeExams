using Microsoft.EntityFrameworkCore;
using SUS.HTTP;
using SUS.MvcFramework;
using SUS.SULS.Data;
using SUS.SULS.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.SULS
{
    public class StartUp : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProblemsService, ProblemsService>();
            serviceCollection.Add<ISubmissonService, SubmissonsService>();
        }
    }
}
