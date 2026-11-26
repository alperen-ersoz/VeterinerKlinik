using VeterinerKlinik.Models;
using Microsoft.EntityFrameworkCore;

namespace VeterinerKlinik.Data;

public static class DbInitializer
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (!await context.Clinics.AnyAsync())
        {
            context.Clinics.Add(new Clinic
            {
                Name = "Veteriner Kliniği",
                Address = "Örnek Klinik Adresi",
                PhoneNumber = "0000000000"
            });

            await context.SaveChangesAsync();
        }

        var clinic = await context.Clinics.FirstAsync();

        if (!await context.Services.AnyAsync())
        {
            context.Services.AddRange(
                new Service
                {
                    ClinicId = clinic.Id,
                    Name = "Genel Muayene",
                    DurationMinutes = 30,
                    Price = 500m
                },
                new Service
                {
                    ClinicId = clinic.Id,
                    Name = "Aşı Uygulaması",
                    DurationMinutes = 15,
                    Price = 750m
                },
                new Service
                {
                    ClinicId = clinic.Id,
                    Name = "Kısırlaştırma",
                    DurationMinutes = 60,
                    Price = 3000m
                },
                new Service
                {
                    ClinicId = clinic.Id,
                    Name = "Diş Temizliği",
                    DurationMinutes = 45,
                    Price = 1500m
                },
                new Service
                {
                    ClinicId = clinic.Id,
                    Name = "Tüy Bakımı",
                    DurationMinutes = 30,
                    Price = 600m
                }
            );

            await context.SaveChangesAsync();
        }
    }
}