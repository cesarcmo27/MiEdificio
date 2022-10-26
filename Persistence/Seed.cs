using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.Buildings.Any())
            {
                var building = new Building
                {
                    Id = Guid.NewGuid(),
                    Name = "Condominio Hawai",
                    Address = "Calle 123",
                    District = "Pueblo Libre"

                };
                await context.Buildings.AddAsync(building);
            }

            if (!context.Groups.Any())
            {

                var groups = new List<Group>{
                     new Group {
                       Id = Guid.NewGuid(),
                    Name = "Gasto Mantenimiento",
                    Status = 1
                    },
                    new Group {
                       Id = Guid.NewGuid(),
                    Name = "Servicios",
                    Status = 1
                    },
                    new Group {
                       Id = Guid.NewGuid(),
                    Name = "Gasto Administrativos",
                    Status = 1
                    },

                };
                await context.Groups.AddRangeAsync(groups);
            }


            /*if (!context.Categories.Any())
            {
                var listCategories = new List<Category>{
                    new Category {
                        Id = Guid.NewGuid(),
                        Name = "Enel Bomba",

                        Status = 1
                    },
                     new Category {
                        Id = Guid.NewGuid(),
                        Name = "Enel Comun",

                        Status = 1
                    },
                     new Category {
                        Id = Guid.NewGuid(),
                        Name = "Sedapal",
                        Status = 1
                    },
                     new Category {
                        Id = Guid.NewGuid(),
                        Name = "Sedapal",
                        Status = 1
                    },
                }
            }*/

            await context.SaveChangesAsync();

        }
    }
}