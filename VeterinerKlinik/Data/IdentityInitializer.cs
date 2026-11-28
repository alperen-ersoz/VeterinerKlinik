using Microsoft.AspNetCore.Identity;
using VeterinerKlinik.Models;


namespace VeterinerKlinik.Data;

public static class IdentityInitializer
{
    public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
    {
        string[] roles = { "Admin", "Veterinarian", "Member" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                var result = await roleManager.CreateAsync(
                    new IdentityRole(role));

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException(
                        $"Role could not be created: {role}");
                }
            }
        }
    }
    public static async Task SeedAdminAsync(
    UserManager<ApplicationUser> userManager,
    IConfiguration configuration)
    {
        var email = configuration["AdminSettings:Email"];
        var password = configuration["AdminSettings:Password"];

        if (string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password))
        {
            return;
        }

        var existingUser = await userManager.FindByEmailAsync(email);

        if (existingUser != null)
        {
            if (!await userManager.IsInRoleAsync(existingUser, "Admin"))
            {
                throw new InvalidOperationException(
                    "Admin email is already in use.");
            }

            return;
        }

        var admin = new ApplicationUser
        {
            UserName = email,
            Email = email,
            FirstName = "System",
            LastName = "Admin",
            EmailConfirmed = true
        };

        admin.PasswordHash =
            userManager.PasswordHasher.HashPassword(admin, password);

        var result = await userManager.CreateAsync(admin);

        if (!result.Succeeded)
        {
            throw new InvalidOperationException(
                "Admin account could not be created.");
        }

        var roleResult = await userManager.AddToRoleAsync(admin, "Admin");

        if (!roleResult.Succeeded)
        {
            throw new InvalidOperationException(
                "Admin role could not be assigned.");
        }
    }

}