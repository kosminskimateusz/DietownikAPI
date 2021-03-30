using System.Threading.Tasks;
using Dietownik.DataAccess.CQRS.Commands;

namespace Dietownik.DataAccess.CQRS
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TParameter, TResult>(CommandBase<TParameter, TResult> command);
    }
}