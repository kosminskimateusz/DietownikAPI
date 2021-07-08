using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess
{

    public class RecipeStorageContext : DbContext
    {
        public RecipeStorageContext(DbContextOptions<RecipeStorageContext> opt) : base(opt)
        {
        }

        public DbSet<EntityIngredient> Ingredients { get; set; }
        public DbSet<EntityProduct> Products { get; set; }
        public DbSet<EntityRecipe> Recipes { get; set; }
        public DbSet<EntityUser> Users { get; set; }
        public DbSet<EntitySavedRecipe> SavedRecipes { get; set; }
        // public DbSet<UserProfile> UsersProfiles { get; set; }
        // public DbSet<Message> Messages { get; set; }

    }
}