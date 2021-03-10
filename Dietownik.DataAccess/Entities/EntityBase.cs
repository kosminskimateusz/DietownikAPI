using System.ComponentModel.DataAnnotations;

namespace Dietownik.DataAccess.Entities
{

    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}