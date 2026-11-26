using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VeterinerKlinik.Models;

namespace VeterinerKlinik.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :  IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Clinic> Clinics => Set<Clinic>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<Veterinarian> Veterinarians => Set<Veterinarian>();
        public DbSet<VeterinarianService> VeterinarianServices => Set<VeterinarianService>();
        public DbSet<VeterinarianAvailability> VeterinarianAvailabilities => Set<VeterinarianAvailability>();
        public DbSet<Pet> Pets => Set<Pet>();
        public DbSet<VaccinationRecord> VaccinationRecords => Set<VaccinationRecord>();
        public DbSet<Appointment> Appointments => Set<Appointment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VeterinarianService>()
    .HasKey(vs => new { vs.VeterinarianId, vs.ServiceId });

            modelBuilder.Entity<Veterinarian>()
    .HasOne(v => v.User)
    .WithOne()
    .HasForeignKey<Veterinarian>(v => v.UserId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pet>()
    .HasOne(p => p.Owner)
    .WithMany()
    .HasForeignKey(p => p.OwnerId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
    .HasOne(a => a.Pet)
    .WithMany()
    .HasForeignKey(a => a.PetId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Veterinarian)
                .WithMany()
                .HasForeignKey(a => a.VeterinarianId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Service)
                .WithMany()
                .HasForeignKey(a => a.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VaccinationRecord>()
    .HasOne(v => v.Pet)
    .WithMany()
    .HasForeignKey(v => v.PetId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Service>()
                .HasOne(s => s.Clinic)
                .WithMany()
                .HasForeignKey(s => s.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
