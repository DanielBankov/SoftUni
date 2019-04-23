using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data
{
    using Models;

    public class HospitalContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<PatientMedicament> patientMedicaments { get; set; }

        /// <summary>
        /// Database configure method
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-SUIN9FI\SQLEXPRESS;Database=Hospital;Integrated Security=True;");
        }

        /// <summary>
        /// Relations and constraints method
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PatientEntity(modelBuilder);
            VisitationEntity(modelBuilder);
            DiagnoseEntity(modelBuilder);
            MedicamentEntity(modelBuilder);
            PatientMedicamentEntity(modelBuilder);
        }

        private void PatientMedicamentEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<PatientMedicament>()
                 .HasKey(pm => new {pm.MedicamentId, pm.PatientId});

            modelBuilder
                .Entity<PatientMedicament>()
                .HasOne(pm => pm.Patient)
                .WithMany(pm => pm.Prescriptions)
                .HasForeignKey(pm => pm.PatientId);

            modelBuilder
                .Entity<PatientMedicament>()
                .HasOne(pm => pm.Medicament)
                .WithMany(pm => pm.Prescriptions)
                .HasForeignKey(pm => pm.MedicamentId);
                
        }

        private void MedicamentEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Medicament>()
                .HasKey(k => k.MedicamentId);

            modelBuilder
                .Entity<Medicament>()
                .Property(n => n.Name)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode();
        }

        private void DiagnoseEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Diagnose>()
                .HasKey(k => k.DiagnoseId);

            modelBuilder
                .Entity<Diagnose>()
                .Property(n => n.Name)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode();

            modelBuilder
                 .Entity<Diagnose>()
                 .Property(c => c.Comments)
                 .HasMaxLength(250)
                 .IsUnicode();
        }

        private void VisitationEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Visitation>()
                .HasKey(k => k.VisitationId);

            modelBuilder
                .Entity<Visitation>()
                .Property(c => c.Comments)
                .HasMaxLength(250)
                .IsUnicode();
        }

        private static void PatientEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Patient>()
                .HasKey(k => k.PatientId);

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.LastName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.Email)
                .IsUnicode()
                .HasMaxLength(80);

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.Address)
                .IsUnicode()
                .HasMaxLength(250);

            modelBuilder
                .Entity<Patient>()
                .HasMany(v => v.Visitations)
                .WithOne(p => p.Patient);

            modelBuilder
                .Entity<Patient>()
                .HasMany(d => d.Diagnoses)
                .WithOne(p => p.Patient);
        }
    }
}
