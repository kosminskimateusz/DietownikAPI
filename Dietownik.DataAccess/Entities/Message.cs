using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Dietownik.DataAccess.Entities
{
    public class Message : EntityBase
    {
        [Required]
        [NotNull]
        [MaxLength(250)]
        public string Content { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        [Required]
        [NotNull]
        public int UserId { get; set; }
    }
}