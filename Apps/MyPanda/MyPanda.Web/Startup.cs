using MyPanda.Data;
using MyPanda.Services;
using MyPanda.Services.Interfaces;
using SIS.MvcFramework;
using SIS.MvcFramework.DependencyContainer;
using SIS.MvcFramework.Routing;
using System.Collections.Generic;
using System.Text;

namespace MyPanda.Web
{
    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            //Once on start
            using (var db = new MyPandaDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            //why do we do this
            serviceProvider.Add<IUsersService, UsersService>();
            serviceProvider.Add<IPackagesService, PackagesService>();
            serviceProvider.Add<IReceiptService, ReceiptService>();
        }
    }
}
