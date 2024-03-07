using Todo.Shared.Commands;
using Todo.Web.Commands;

namespace Todo.Web.Handlers.Interfaces
{
    public interface IHandler<T> where T : ICommand
    {
        Task<CommandResult> Handle(T command);
    }
}
