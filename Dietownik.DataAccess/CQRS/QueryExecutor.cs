using System.Threading.Tasks;
using Dietownik.DataAccess.CQRS.Queries;

namespace Dietownik.DataAccess.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly RecipeStorageContext context;

        public QueryExecutor(RecipeStorageContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this.context);
        }
    }
}