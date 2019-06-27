﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Panda.Domain;

namespace Panda.Data
{
    public class PandaDbContext : IdentityDbContext<PandaUser, PandaUserRole, string>
    {
        public DbSet<PackageStatus> PackageStatuses { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Package> Packages { get; set; }

        public PandaDbContext(DbContextOptions<PandaDbContext> dbContextOptions)
            :base(dbContextOptions)
        {
        }

        public PandaDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PandaWeb;Trusted_Connection=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PandaUser>()
                .HasKey(user => user.Id);

            builder.Entity<PandaUser>()
                .HasMany(user => user.Packages)
                .WithOne(package => package.Recipient)
                .HasForeignKey(package => package.RecipientId);

            builder.Entity<PandaUser>()
                .HasMany(user => user.Receipts)
                .WithOne(receipts => receipts.Recipient)
                .HasForeignKey(receipts => receipts.RecipientId);

            builder.Entity<Receipt>()
                .HasOne(receipt => receipt.Package)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
