using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace Eventures.Domain
{
    public class EventuresUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UCN { get; set; }
    }
}
