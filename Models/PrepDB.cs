using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ColourAPI.Models
{
    public static class PrepDB
    {
        public static void PrePopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ColourContext>());
            }
        }

        public static void SeedData(ColourContext context)
        {

            context.Database.Migrate();

            if (!context.ColourItems.Any())
            {
                System.Console.WriteLine("Adding data, seeding....");
                context.ColourItems.AddRange(
                    new Colour() { ColourName = "Red" },
                    new Colour() { ColourName = "Orange" },
                    new Colour() { ColourName = "Green" },
                    new Colour() { ColourName = "Blue" }
                );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already has data");
            }
        }
    }
}