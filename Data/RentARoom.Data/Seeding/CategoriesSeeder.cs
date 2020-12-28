namespace RentARoom.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using RentARoom.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "House" });
            await dbContext.Categories.AddAsync(new Category { Name = "Hotel" });
            await dbContext.Categories.AddAsync(new Category { Name = "Apartament" });

            await dbContext.SaveChangesAsync();
        }
    }
}
