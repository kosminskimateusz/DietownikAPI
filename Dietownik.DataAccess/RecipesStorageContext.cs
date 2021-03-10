namespace Dietownik.DataAccess
{
    using Dietownik.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;

    public class RecipeStorageContext : DbContext
    {
        public RecipeStorageContext(DbContextOptions<RecipeStorageContext> opt) : base(opt)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}