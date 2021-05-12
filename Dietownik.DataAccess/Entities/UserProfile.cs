// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
// using System.Diagnostics.CodeAnalysis;

// namespace Dietownik.DataAccess.Entities
// {
//     public class UserProfile : EntityBase
//     {
//         [Required]
//         [NotNull]
//         [MaxLength(50)]
//         public string Name { get; set; }

//         [Required]
//         [NotNull]
//         [MaxLength(50)]
//         public string LastName { get; set; }

//         [Required]
//         [NotNull]
//         public int Age { get; set; }

//         [Required]
//         [NotNull]
//         [Column(TypeName = "decimal(18,1)")]
//         public decimal Height { get; set; }

//         [Required]
//         [NotNull]
//         [Column(TypeName = "decimal(18,1)")]
//         public decimal Weight { get; set; }

//         [Required]
//         [NotNull]
//         public int UserId { get; set; }
//     }
// }