using MyPanda.Services.Interfaces;
using MyPanda.Web.ViewModels.Receipts;
using SIS.MvcFramework;
using SIS.MvcFramework.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPanda.Web.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IReceiptService receiptService;

        public ReceiptsController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }

        public IActionResult Index()
        {
            var viewModel = this.receiptService.GetAll().Select(x=> new ReceiptViewModel 
            { 
                Id = x.Id,
                Fee = x.Fee,
                IssuedOn = x.IssuedOn,
                RecipientName = x.Recipient.Username
            }).ToList();

            return this.View(viewModel);
        }
    }
}
