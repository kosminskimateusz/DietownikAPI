namespace Dietownik.ApplicationServices.API.Domain.Models
{
    public class ModelIngredient : ModelBase
    {
        public decimal Weigth { get; set; }
        public int ProductId { get; set; }
        public int RecipeId { get; set; }
    }
}