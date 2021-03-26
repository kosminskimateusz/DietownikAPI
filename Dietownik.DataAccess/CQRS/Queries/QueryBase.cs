using System.Threading.Tasks;

namespace Dietownik.DataAccess.CQRS.Queries
{
    public abstract class QueryBase<TResult>
    {
        public abstract Task<TResult> Execute(RecipeStorageContext context);
    }
}