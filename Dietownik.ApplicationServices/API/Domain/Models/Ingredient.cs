namespace Dietownik.ApplicationServices.API.Domain.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public decimal Weigth { get; set; }
        public int ProductId { get; set; }
        public int RecipeId { get; set; }
    }
}