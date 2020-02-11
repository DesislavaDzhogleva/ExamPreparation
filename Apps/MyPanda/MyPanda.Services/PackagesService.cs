using MyPanda.Data;
using MyPanda.Data.Models;
using MyPanda.Data.Models.Enum;
using MyPanda.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPanda.Services
{
    public class PackagesService : IPackagesService
    {
        private readonly MyPandaDbContext db;
        private readonly IReceiptService receiptService;

        public PackagesService(MyPandaDbContext db, IReceiptService receiptService)
        {
            this.db = db;
            this.receiptService = receiptService;
        }

        public void Create(string description, decimal weight, string shippingAddress, string recipientName)
        {
            var userId = this.db.Users.Where(x => x.Username == recipientName).Select(x => x.Id).FirstOrDefault();
            
            if(userId == null)
            {
                return;
            }

            var package = new Package
            {
                Description = description,
                Weight = weight,
                Status = PackageStatus.Pending,
                Address = shippingAddress,
                RecipientId = userId

            };

            this.db.Packages.Add(package);
            this.db.SaveChanges();
        }

        public void Deliver(string id)
        {
            var package = this.db.Packages.FirstOrDefault(x => x.Id == id);

            if(package == null)
            {
                return;
            }

            package.Status = PackageStatus.Delivered;
            this.db.SaveChanges();

            this.receiptService.CreateFromPackage(package.Weight, package.Id, package.RecipientId);
        }

        public IQueryable<Package> GetAllByStatus(PackageStatus status)
        {
            var packages = this.db.Packages.Where(x => x.Status == status);
            return packages;
        }
    }
}
