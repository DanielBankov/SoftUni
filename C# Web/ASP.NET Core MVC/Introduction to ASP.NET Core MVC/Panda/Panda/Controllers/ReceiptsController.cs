using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Panda.Data;
using Panda.Domain;
using Panda.Models.Receipts;

namespace Panda.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly PandaDbContext context;

        public ReceiptsController(PandaDbContext context)
        {
            this.context = context;
        }

        [Authorize]
        public IActionResult My()
        {
            List<ReceiptMyViewModel> receipts = context.Receipts
                .Include(user => user.Recipient)
                .Where(user => user.Recipient.UserName == this.User.Identity.Name)
                .Select(receipt =>
                    new ReceiptMyViewModel
                    {
                        Id = receipt.Id,
                        Fee = receipt.Fee,
                        IssuedOn = receipt.IssuedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Recipient = receipt.Recipient.UserName
                    })
                .ToList();

            return this.View(receipts);
        }

        [HttpGet("/Receipts/Details/{id}")]
        [Authorize]
        public IActionResult Details(string id)
        {
            Receipt receiptFromDb = context.Receipts
                .Where(receipt => receipt.Id == id)
                .Include(receipt => receipt.Recipient)
                .Include(receipt => receipt.Package)
                .SingleOrDefault();

            ReceiptDetailsViewModel viewModel = new ReceiptDetailsViewModel
            {
                Id = receiptFromDb.Id,
                DeliveryAddress = receiptFromDb.Package.ShippingAddress,
                Description = receiptFromDb.Package.Description,
                Recipient = receiptFromDb.Recipient.UserName,
                IssuedOn = receiptFromDb.IssuedOn.ToString("dd/MM/yyy", CultureInfo.CurrentCulture),
                Weight = receiptFromDb.Package.Weight,
                Total = receiptFromDb.Fee
            };

            return this.View(viewModel);
        }
    }
}