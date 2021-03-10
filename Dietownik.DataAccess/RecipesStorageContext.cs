using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess
{

    public class RecipeStorageContext : DbContext
    {
        public RecipeStorageContext(DbContextOptions<RecipeStorageContext> opt) : base(opt)
        {
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Recipe> Recipes { get; set; }
    }
}