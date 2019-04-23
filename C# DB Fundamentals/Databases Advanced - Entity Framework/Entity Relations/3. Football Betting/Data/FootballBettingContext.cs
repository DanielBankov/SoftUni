using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BetEntity(modelBuilder);
            ColorEntity(modelBuilder);
            CountryEntity(modelBuilder);
            GameEntity(modelBuilder);
            PlayerEntity(modelBuilder);
            PositionEntity(modelBuilder);
            TeamEntity(modelBuilder);
            TownEntity(modelBuilder);
            UserEntity(modelBuilder);
            PlayerStatisticEntity(modelBuilder);
        }

        private void PlayerStatisticEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PlayerStatistic>()
                .HasKey(e => new { e.GameId, e.PlayerId });

            modelBuilder
                .Entity<PlayerStatistic>()
                .HasOne(ps => ps.Game)
                .WithMany(g => g.PlayerStatistics)
                .HasForeignKey(ps => ps.GameId);

            modelBuilder
                .Entity<PlayerStatistic>()
                .HasOne(ps => ps.Player)
                .WithMany(p => p.PlayerStatistics)
                .HasForeignKey(ps => ps.PlayerId);
        }

        private void UserEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasKey(u => u.UserId);
        }

        private void TownEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Town>()
                .HasKey(t => t.TownId);

            modelBuilder
                .Entity<Town>()
                .HasOne(t => t.Country)
                .WithMany(c => c.Towns)
                .HasForeignKey(t => t.CountryId);
        }

        private void TeamEntity(ModelBuilder modelBuilder)
        {
            /////////////////////
            
            modelBuilder
                .Entity<Team>()
                .HasKey(t => t.TeamId);

            modelBuilder
                .Entity<Team>()
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Team>()
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder
               .Entity<Team>()
               .HasOne(t => t.Town)
               .WithMany(t => t.Teams)
               .HasForeignKey(t => t.TownId);
        }

        private void PositionEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Position>()
                .HasKey(p => p.PositionId);
        }

        private void PlayerEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Player>()
                .HasKey(p => p.PlayerId);

            modelBuilder
                .Entity<Player>()
               .HasOne(p => p.Team)
               .WithMany(t => t.Players)
               .HasForeignKey(p => p.TeamId);

            modelBuilder
                .Entity<Player>()
                .HasOne(p => p.Position)
                .WithMany(p => p.Players)
                .HasForeignKey(p => p.PositionId);
        }

        private void GameEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Game>()
                .HasKey(g => g.GameId);

            modelBuilder
                .Entity<Game>()
                .HasOne(g => g.HomeTeam)
                .WithMany(ht => ht.HomeGames)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder
                .Entity<Game>()
                .HasOne(g => g.AwayTeam)
                .WithMany(at => at.AwayGames)
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        private void CountryEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Country>()
                .HasKey(c => c.CountryId);
        }

        private static void ColorEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Color>()
                .HasKey(c => c.ColorId);
        }

        private void BetEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Bet>()
                .HasKey(b => b.BetId);

            modelBuilder
                .Entity<Bet>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(b => b.UserId);

            modelBuilder
               .Entity<Bet>()
               .HasOne(b => b.Game)
               .WithMany(g => g.Bets)
               .HasForeignKey(b => b.GameId);
        }
    }
}
