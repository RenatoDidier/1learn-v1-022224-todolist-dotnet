using Todo.Shared.ViewModel;

namespace Todo.Shared.Repositories
{
    public interface ITodoRepository
    {
        Task<List<AtividadeViewModel?>> ListarTodasAtividadesAsync(string titulo, bool? conclusao);
        Task<AtividadeViewModel?> ListarAtividadePorIdAsync(int id);
        Task<bool> CriarAtividadeAsync(string titulo);
        Task<bool> EditarAtividadeAsync(int id, string titulo, bool conclusao);
        Task<bool> ExcluirAtividadeAsync(int id);
    }
}
