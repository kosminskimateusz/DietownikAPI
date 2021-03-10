namespace Dietownik.DataAccess.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public decimal Kcal { get; set; }
        public decimal FatsPerHundredGrams { get; set; }
        public decimal CarbsPerHundredGrams { get; set; }
        public decimal ProteinsPerHundredGrams { get; set; }

    }
}