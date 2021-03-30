using System.Threading.Tasks;
using Dietownik.DataAccess.CQRS.Commands;

namespace Dietownik.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly RecipeStorageContext context;

        public CommandExecutor(RecipeStorageContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TParameter, TResult>(CommandBase<TParameter, TResult> command)
        {
            return command.Execute(this.context);
        }
    }
}