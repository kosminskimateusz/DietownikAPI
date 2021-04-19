using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dietownik.DataAccess.Entities
{
    public class Recipe : EntityBase
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public int AuthorId { get; set; } // Profile
        public List<Ingredient> Ingredients { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,1")]
        public decimal KcalFull { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,1")]
        public decimal FatsFull { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,1")]
        public decimal CarbsFull { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,1")]
        public decimal ProteinsFull { get; set; }

    }
}