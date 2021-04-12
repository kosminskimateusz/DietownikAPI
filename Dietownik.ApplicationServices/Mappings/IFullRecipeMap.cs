using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain.Models;

namespace Dietownik.ApplicationServices.Mappings
{
    public interface IFullRecipeMap
    {
        Task<Recipe> Map(DataAccess.Entities.Recipe recipe);
    }
}