using MyPanda.Data.Models;
using MyPanda.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPanda.Services.Interfaces
{
    public interface IPackagesService
    {
        void Create(string description, decimal weight, string shippingAddress, string recipientName);

        IQueryable<Package> GetAllByStatus(PackageStatus status);

        void Deliver(string id);
    }
}
