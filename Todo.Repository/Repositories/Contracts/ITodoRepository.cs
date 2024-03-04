using Todo.Shared.Models;

namespace Todo.Repository.Repositories.Contracts
{
    public interface ITodoRepository
    {
        List<Atividade> ListarTodasAtividades();
    }
}
