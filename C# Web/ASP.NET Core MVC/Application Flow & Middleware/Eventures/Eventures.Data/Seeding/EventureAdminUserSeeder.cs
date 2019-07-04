using Eventures.Domain;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Eventures.Data.Seeding
{
    public class EventureAdminUserSeeder : ISeeder
    {
        private readonly UserManager<EventuresUser> userManager;

        public EventureAdminUserSeeder(UserManager<EventuresUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task Seed()
        {
            var user = new EventuresUser
            {
                UserName = "root",
                Email = "root@eventures.com",
                FirstName = "Root",
                LastName = "Root",
                UCN = "ROOT"
            };

            var result = await this.userManager.CreateAsync(user, "root");
        }
    }
}
