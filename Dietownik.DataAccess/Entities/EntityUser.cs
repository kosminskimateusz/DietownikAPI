using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Dietownik.DataAccess.Entities
{
    public class EntityUser : EntityBase
    {
        [Required]
        [NotNull]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [NotNull]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [NotNull]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public bool Role { get; set; }

        // public UserProfile UserProfile { get; set; }

        // public List<EntityMessage> Messages { get; set; }
        public List<EntitySavedRecipe> EntitySavedRecipes { get; set; }
    }

    public enum Role
    {
        User =0,
        Admin = 1
    }
}