using System.Collections.Generic;

namespace Dietownik.ApplicationServices.API.Domain.Models
{
    public class ModelUser : ModelBase
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public bool SpecialUser { get; set; }
        // public int UserProfileId { get; set; }
        // public List<SavedRecipe> SavedRecipes { get; set; }
    }
}