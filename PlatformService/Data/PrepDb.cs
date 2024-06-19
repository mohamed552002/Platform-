

using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
            private static void SeedData(AppDbContext context){
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