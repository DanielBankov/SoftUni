using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Panda.Data;
using Panda.Domain;
using Panda.Models.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.Controllers
{
    public class HomeController : Controller
    {
        private readonly PandaDbContext context;

        public HomeController(PandaDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var package = this.context.Packages
                    .Where(p => p.Recipient.UserName == this.User.Identity.Name)
                    .Include(p => p.Status)
                    .Select(pack => new PackageHomeViewModel
                    {
                        Id = pack.Id,
                        Description = pack.Description,
                        Status = pack.Status.Name
                    })
                    .ToList();

                return this.View(package);
            }

            return this.View();
        }
    }
}
