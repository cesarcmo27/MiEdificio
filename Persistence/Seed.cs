using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context){
            if (context.Buildings.Any())
                return;
            
            var building = new Building{
                Name = "Condominio Hawai",
                Address = "Calle 123",
                District = "Pueblo Libre"

            };

            await context.Buildings.AddAsync(building);
            await context.SaveChangesAsync();
             
        }
    }
}