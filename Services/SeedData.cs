using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Services
{
    // A static class to seed initial data into the system
    public static class SeedData
    {
        // Method to seed roles into the application
        // It ensures that predefined roles exist in the system
        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            // Retrieve the RoleManager service from the service provider
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Check if the "Employee" role already exists
            if (!await roleManager.RoleExistsAsync("Employee"))
            {
                // Create the "Employee" role if it does not exist
                await roleManager.CreateAsync(new IdentityRole("Employee"));
            }

            // Check if the "Admin" role already exists
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                // Create the "Admin" role if it does not exist
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
        }
    }
}
