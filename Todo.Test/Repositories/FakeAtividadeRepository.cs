using Todo.Shared.Repositories;
using Todo.Shared.ViewModel;

namespace Todo.Test.Repositories
{
    public class FakeAtividadeRepository : ITodoRepository
    {
        public Task<bool> CriarAtividadeAsync(string titulo)
        {
            return Task.FromResult(true);
        }

        public Task<bool> EditarAtividadeAsync(int id, string titulo, bool conclusao)
        {
            return Task.FromResult(true);
        }

        public Task<bool> ExcluirAtividadeAsync(int id)
        {
            return Task.FromResult(true);
        }

        public Task<AtividadeViewModel?> ListarAtividadePorIdAsync(int id)
        {
            if (id == 0)
                return Task.FromResult<AtividadeViewModel?>(null);

            AtividadeViewModel atividade = new AtividadeViewModel();
            atividade.Id = 1;
            atividade.Titulo = "Teste Atividade Fake Repository";
            atividade.Conclusao = false;

            return Task.FromResult<AtividadeViewModel?>(atividade);
        }

        public Task<List<AtividadeViewModel?>> ListarTodasAtividadesAsync(string titulo, bool? conclusao)
        {
            if (titulo == "atividade inexistente")
                return Task.FromResult<List<AtividadeViewModel?>>(null);

            List<AtividadeViewModel?> atividades = new List<AtividadeViewModel?>();

            AtividadeViewModel atividade = new AtividadeViewModel();
            atividade.Id = 1;
            atividade.Titulo = "Teste Atividade Fake Repository";
            atividade.Conclusao = false;

            atividades.Add(atividade);

            return Task.FromResult<List<AtividadeViewModel?>>(atividades);
        }
    }
}
