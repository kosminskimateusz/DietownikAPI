using System.ComponentModel.DataAnnotations;

namespace Dietownik.DataAccess.Entities
{
    public class Ingredient : Product
    {
        [Required]
        public decimal Weigth { get; set; }
    }
}