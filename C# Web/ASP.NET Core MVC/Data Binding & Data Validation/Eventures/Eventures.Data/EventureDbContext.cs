﻿using Eventures.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eventures.Data
{
    public class EventureDbContext : IdentityDbContext<EventuresUser, IdentityRole, string>
    {
        public DbSet<Event> Events { get; set; }

        public EventureDbContext(DbContextOptions<EventureDbContext> options) : base(options)
        {
        }
    }
}
