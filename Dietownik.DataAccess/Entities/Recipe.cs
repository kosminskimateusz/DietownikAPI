using System.Collections.Generic;

namespace Dietownik.DataAccess.Entities
{
    public class Recipe : EntityBase
    {
        public string Name {get;set;}
        public List<Ingredient> Ingredients {get;set;}
        
    }
}