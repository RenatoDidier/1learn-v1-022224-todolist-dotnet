using Todo.Shared.Models;
using Todo.Shared.ViewModel;

namespace Todo.Repository.Repositories.Contracts
{
    public interface ITodoRepository
    {
        List<Atividade> ListarTodasAtividades();

        bool CriarAtividade(object parametros);
        bool EditarAtividade(object parametros);
        bool ExcluirAtividade(object parametros);
    }
}
