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
using Panda.Models.Packages;

namespace Panda.Controllers
{
    public class PackagesController : Controller
    {
        private readonly PandaDbContext context;

        public PackagesController(PandaDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            this.ViewData["Recipients"] = this.context.Users.ToList();

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(PackageCreateBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(bindingModel ); // ?? new PackageCreateBindingModel()
            }

            //Must be in Service!
            Package package = new Package
            {
                Description = bindingModel.Description,
                Weight = bindingModel.Weight,
                ShippingAddress = bindingModel.ShippingAddress,
                Recipient = context.Users.SingleOrDefault(user => user.UserName == bindingModel.Recipient),
                Status = context.PackageStatuses.SingleOrDefault(ps => ps.Name == "Pending") // TODO: Global constants
            };

            this.context.Packages.Add(package);
            this.context.SaveChanges();

            return this.Redirect("/Packages/Pending");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Pending()
        {
            return this.View(context
                .Packages
                .Include(p => p.Recipient)
                .Where(p => p.Status.Name == "Pending")
                .Select(package =>
                 new PackagePendingViewModel
                 {
                     Id = package.Id,
                     Description = package.Description,
                     Weight = package.Weight,
                     ShippingAddress = package.ShippingAddress,
                     Recipient = package.Recipient.UserName,
                 }
            ).ToList());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Shipped()
        {
            // if null can be returned
            return this.View(context
                .Packages
                .Include(p => p.Recipient)
                .Where(p => p.Status.Name == "Shipped")
                .ToList()
                .Select(package =>
                {
                    return new PackageShippedViewModel
                    {
                        Id = package.Id,
                        Description = package.Description,
                        Weight = package.Weight,
                        EstimatedDeliveryDate = package.EstimatedDeliveryDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Recipient = package.Recipient.UserName,
                    };
                })
                .ToList());
        }

        [HttpGet("/Packages/Ship/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Ship(string id)
        {
            Package package = context.Packages.Find(id);
            package.Status = context.PackageStatuses.SingleOrDefault(ps => ps.Name == "Shipped"); //Global constants
            package.EstimatedDeliveryDate = DateTime.Now.AddDays(new Random().Next(20, 40));

            this.context.Packages.Update(package);
            this.context.SaveChanges();

            return this.Redirect("/Packages/Shipped");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delivered()
        {
            return this.View(context
                .Packages
                .Include(p => p.Recipient)
                .Where(p => p.Status.Name == "Delivered")
                .Select(package =>
                 new PackageDeliveredViewModel
                 {
                     Id = package.Id,
                     Description = package.Description,
                     Weight = package.Weight,
                     ShippingAddress = package.ShippingAddress,
                     Recipient = package.Recipient.UserName,
                 }
            ).ToList());
        }

        [HttpGet("/Packages/Deliver/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Deliver(string id)
        {
            Package package = context.Packages.Find(id);
            package.Status = context.PackageStatuses
                .FirstOrDefault(ps => ps.Name == "Delivered" || ps.Name == "Acquired");

            this.context.Packages.Update(package);
            this.context.SaveChanges();

            return this.Redirect("/Packages/Delivered");
        }

        [HttpGet("/Packages/Acquire/{id}")]
        [Authorize]
        public IActionResult Acquire(string id)
        {
            Package package = context.Packages.Find(id);
            package.Status = context.PackageStatuses.SingleOrDefault(ps => ps.Name == "Acquired"); //Global constants
            this.context.Packages.Update(package);

            //When package is acquired, user receives receipt
            Receipt receipt = new Receipt
            {
                Fee = (decimal)(2.67 * package.Weight),
                IssuedOn = DateTime.Now,
                Package = package,
                Recipient = this.context.Users.SingleOrDefault(user => user.UserName == this.User.Identity.Name)
            };

            context.Receipts.Add(receipt);
            this.context.SaveChanges();

            return this.Redirect("/Home/Index");
        }

        [HttpGet("/Packages/Details/{id}")]
        [Authorize]
        public IActionResult Details(string id)
        {
            Package package = context.Packages.Where(p => p.Id == id)
                .Include(p => p.Recipient)
                .Include(p => p.Status)
                .SingleOrDefault();

            var viewModel = new PackageDetailsViewModel
            {
                Description = package.Description,
                Recipient = package.Recipient.UserName,
                ShippingAddress = package.ShippingAddress,
                Weight = package.Weight,
                Status = package.Status.Name,
            };

            if(package.Status.Name == "Pending")
            {
                viewModel.EstimatedDeliveryDate = "N/A";
            }
            else if(package.Status.Name == "Shipped")
            {
                viewModel.EstimatedDeliveryDate = package.EstimatedDeliveryDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                viewModel.EstimatedDeliveryDate = "Delivered";
            }

            return this.View(viewModel);
        }
    }
}