using Todo.Shared.Models;
using Todo.Shared.ViewModel;

namespace Todo.Repository.Repositories.Contracts
{
    public interface ITodoRepository
    {
        Task<List<AtividadeViewModel?>> ListarTodasAtividadesAsync(object parametros);
        Task<AtividadeViewModel?> ListarAtividadePorIdAsync(object parametros);
        Task<bool> CriarAtividadeAsync(object parametros);
        Task<bool> EditarAtividadeAsync(object parametros);
        Task<bool> ExcluirAtividadeAsync(object parametros);
    }
}
