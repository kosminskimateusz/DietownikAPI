namespace Dietownik.DataAccess
{
    using Dietownik.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;

    public class RecipeStorageContext : DbContext
    {
        public RecipeStorageContext(DbContextOptions<RecipeStorageContext> opt) : base(opt)
        {
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}