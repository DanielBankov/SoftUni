using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Data;
using Eventures.Domain;
using Eventures.Models.BindingModels;
using Eventures.Models.ViewModels.Events;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventureDbContext context;

        public EventsController(EventureDbContext context)
        {
            this.context = context;
        }

        //TODO: Extend with services!

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EventCreateBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            Event dbEvent = new Event
            {
                Name = model.Name,
                Price = model.Place,
                Start = model.Start,
                End = model.End,
                TotalTickets = model.TotalTickets,
                PricePerTicket = model.PricePerTicket
            };

            context.Events.Add(dbEvent);
            context.SaveChanges();

            return this.Redirect("/Events/All/");
        }

        public IActionResult All()
        {
            List<EventsAllViewMorel> allEvents = context.Events
                .Select(e => new EventsAllViewMorel
                {
                    Name = e.Name,
                    Start = e.Start.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
                    End = e.End.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
                    Place = e.Price
                })
                .ToList();

            return View(allEvents);
        }
    }
}