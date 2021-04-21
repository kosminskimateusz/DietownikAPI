using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Dietownik.DataAccess.Entities
{
    public class User : EntityBase
    {
        [Required]
        [NotNull]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [NotNull]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [NotNull]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        public bool SpecialUser { get; set; }
        // public int UserProfileId { get; set; }
        [Required]
        public int UserProfileId { get; set; }
        public List<Day> Days { get; set; }
        public List<Message> Messages { get; set; }
    }
}