using MyPanda.Data.Models;
using MyPanda.Data.Models.Enum;
using MyPanda.Services.Interfaces;
using MyPanda.Web.ViewModels.Packages;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPanda.Web.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IPackagesService packageService;
        private readonly IUsersService usersService;

        public PackagesController(IPackagesService packageService, IUsersService usersService)
        {
            this.packageService = packageService;
            this.usersService = usersService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var list = this.usersService.GetUsernames();
            return this.View(list);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Packages/Create");
            }

            this.packageService.Create(input.Description, input.Weight, input.ShippingAddress, input.RecipientName);
            return this.Redirect("/Packages/Pending");

        }

        [Authorize]
        public IActionResult Delivered()
        {
            var packages = this.packageService.GetAllByStatus(PackageStatus.Delivered)
                    .Select(x=> new PackageViewModel
                    { 
                        Description = x.Description,
                        Id = x.Id,
                        Weight = x.Weight,
                        ShippingAddress = x.Address,
                        RecipientName = x.Recipient.Username
                    }).ToList();
            return this.View(new PackagesListViewModel { Packages = packages });
        }

        [Authorize]
        public IActionResult Pending()
        {
            var packages = this.packageService.GetAllByStatus(PackageStatus.Pending)
                .Select(x => new PackageViewModel
                {
                    Description = x.Description,
                    Id = x.Id,
                    Weight = x.Weight,
                    ShippingAddress = x.Address,
                    RecipientName = x.Recipient.Username
                }).ToList();
            return this.View(new PackagesListViewModel { Packages = packages });
        }

        [Authorize]
        public IActionResult Deliver(string id)
        {
            this.packageService.Deliver(id);
            return this.Redirect("/Packages/Delivered");
        }
    }
}
