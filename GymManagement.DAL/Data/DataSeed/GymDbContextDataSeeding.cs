using GymManagement.DAL.Data.Context;
using GymManagement.DAL.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GymManagement.DAL.Data.DataSeed
{
    public static class GymDbContextDataSeeding
    {
        public static void SeedData(GymDbContext context)
        {
            // Seed initial data here if needed
            try
            {
                if (context.Plans.Any() && context.Categories.Any())
                {
                    return; // Data already seeded
                }
                var webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                var planFilePath = Path.Combine(webRootPath, "Files", "Plans.json");
                var CatFilePath = Path.Combine(webRootPath, "Files", "Categories.json");

                // Ensure the folder exists
                Directory.CreateDirectory(Path.GetDirectoryName(planFilePath)!);
                Directory.CreateDirectory(Path.GetDirectoryName(CatFilePath)!);


                var plans = JsonSerializer.Deserialize<List<Plan>>(File.ReadAllText(planFilePath));
                var categories = JsonSerializer.Deserialize<List<Category>>(File.ReadAllText(CatFilePath));

                if (plans is null || categories is null)
                {
                    throw new Exception("Failed to deserialize JSON data.");
                }
                if (!context.Plans.Any())
                {
                    context.Plans.AddRange(plans!);
                }
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(categories!);
                }

                context.SaveChanges();


            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error)
                Console.WriteLine($"Error seeding data: {ex.Message}");
            }
        }
    }
}
