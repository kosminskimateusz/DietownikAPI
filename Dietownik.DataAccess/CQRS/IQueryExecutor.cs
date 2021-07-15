using System.Threading.Tasks;
using Dietownik.DataAccess.CQRS.Queries;

namespace Dietownik.DataAccess.CQRS
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}