using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messages.App.Models;
using Messages.Data;
using Messages.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Messages.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly MessageDbContext context;

        public MessagesController(MessageDbContext context)
        {
            this.context = context;
        }

        //TODO: create messages get user token

        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<Message>> All()
        {
            return this.context.Messages.OrderBy(message => message.CreatedOn).ToList();
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<string>> Create(MessageCreateBindingModel model)
        {
            var dbUser = await this.context.Users.SingleOrDefaultAsync(user => user.Username == model.User);

            Message message = new Message
            {
                Content = model.Content,
                User = dbUser,
                CreatedOn = DateTime.UtcNow
            };

            await context.Messages.AddAsync(message);
            await context.SaveChangesAsync();

            return this.Ok();
        }
    }
}
