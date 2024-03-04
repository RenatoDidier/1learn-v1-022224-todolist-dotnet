using Todo.Repository.Repositories.Contracts;
using Todo.Shared.Commands;
using Todo.Shared.Models;
using Todo.Web.Commands;
using Todo.Web.Handlers.Interfaces;

namespace Todo.Web.Handlers
{
    public class AtividadeHandler
        : IHandler<CriarAtividadeCommand>
    {
        private readonly ITodoRepository _repository;

        public AtividadeHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CriarAtividadeCommand command)
        {
            // 0 - Fail Fast validation
            try
            {
                command.ValidarEnvioDados();

                if (command.IsValid)
                {
                    return new CommandResult("Requisição inválida", 400, command.Notifications);
                
                }
            } catch
            {
                return new CommandResult("Erro interno no servidor", 500);
            }
            // 1 - Criar o Usuário

            List<Atividade> listaFinal = new List<Atividade>();

            try
            {
                listaFinal = _repository.ListarTodasAtividades();
            } catch
            {
                return new CommandResult("Erro ao acessar o banco", 400);
            }

            // 2 - Retorna o resultado
            return new CommandResult("Criação de atividade com sucesso");
        }
    }
}
