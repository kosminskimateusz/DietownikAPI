using System.Collections.Generic;

namespace Dietownik.DataAccess.Entities
{
    public class Day : EntityBase
    {
        public int Number { get; set; }
        public List<Recipe> Recipes { get; set; }
        public int CallendarId { get; set; }
    }
}