

using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool IsProduction)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(),IsProduction);
            }
        }
            private static void SeedData(AppDbContext context,bool IsProduction){
                if(IsProduction){
                    Console.WriteLine("Attempting to apply migration");
                    try{
                    context.Database.Migrate();
                    }
                    catch{
                        Console.WriteLine("Could not run migration");
                    }
                }
                if(!context.Platforms.Any())
                    {
                        System.Console.WriteLine("Seeding");
                        context.Platforms.AddRange(
                            new Platform(){Name = " DotNet",Publisher = "MS",Cost="Free"},
                            new Platform(){Name = " SQl Server",Publisher = "MS",Cost="Free"},
                            new Platform(){Name = " OracleDB",Publisher = "Oracle",Cost="Free"}
                        );
                        context.SaveChanges();
                    }
                else
                    Console.WriteLine("Have Data");
            }
    }
}