using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Dietownik.DataAccess
{
    public class RecipeStorageContextFactory : IDesignTimeDbContextFactory<RecipeStorageContext>
    {
        public RecipeStorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RecipeStorageContext>();
            optionsBuilder.UseSqlServer("Data Source=M-KOSMINSKI\\KOSMI;Initial Catalog=Dietownik;Integrated Security=True");
            // Linux: Data Source=localhost;Initial Catalog=RecipeStorage;User=SA;Password=Strabane2020;
            return new RecipeStorageContext(optionsBuilder.Options);
        }
    }
}