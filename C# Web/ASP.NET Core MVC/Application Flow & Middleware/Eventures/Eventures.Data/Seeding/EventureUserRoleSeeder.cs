using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Data.Seeding
{
    public class EventureUserRoleSeeder : ISeeder
    {
        private readonly EventureDbContext context;

        public EventureUserRoleSeeder(EventureDbContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            if (!context.Roles.Any())
            {
                context.Roles.Add(new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });
                context.Roles.Add(new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                });
            }

            context.SaveChanges();
        }
    }
}
