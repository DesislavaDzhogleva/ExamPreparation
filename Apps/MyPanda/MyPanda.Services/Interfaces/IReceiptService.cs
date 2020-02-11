using MyPanda.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPanda.Services.Interfaces
{
    public interface IReceiptService
    {
        void CreateFromPackage(decimal weight, string packageId, string recipientId);

        IQueryable<Receipt> GetAll();
    }
}
