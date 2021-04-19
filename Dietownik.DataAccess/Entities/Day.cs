using System;
using System.Collections.Generic;

namespace Dietownik.DataAccess.Entities
{
    public class Day
    {
        public DateTime Date { get; set; }
        public List<SavedRecipe> SavedRecipes { get; set; } // maximum 5 recipes
    }
}