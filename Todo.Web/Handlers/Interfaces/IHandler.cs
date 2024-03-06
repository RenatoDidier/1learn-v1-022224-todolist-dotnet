using Todo.Shared.Commands;

namespace Todo.Web.Handlers.Interfaces
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
