using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dietownik.DataAccess.Entities
{
    public class Recipe : EntityBase
    {
        [Required]
        [MaxLength(250)]
        public string Name {get;set;}
        public List<Ingredient> Ingredients {get;set;}
        
    }
}