namespace Dietownik.DataAccess.Entities
{
    public class SavedRecipe : EntityBase
    {
        public int RecipeId { get; set; }
        public int DayId { get; set; }
        public int PreferedKcal { get; set; }
    }
}