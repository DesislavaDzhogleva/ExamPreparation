using MyPanda.Data;
using MyPanda.Data.Models;
using MyPanda.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPanda.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly MyPandaDbContext db;

        public ReceiptService(MyPandaDbContext db)
        {
            this.db = db;
        }

        public void CreateFromPackage(decimal weight, string packageId, string recipientId)
        {
            var receipt = new Receipt
            {
                PackageId = packageId,
                RecipientId = recipientId,
                Fee = weight*2.67m,
                IssuedOn = DateTime.UtcNow,
            };

            this.db.Receipts.Add(receipt);
            this.db.SaveChanges();
        }

        public IQueryable<Receipt> GetAll()
        {
            return this.db.Receipts;
        }
    }
}
