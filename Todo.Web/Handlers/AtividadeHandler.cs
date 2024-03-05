using Todo.Repository.Repositories.Contracts;
using Todo.Shared.Commands;
using Todo.Web.Commands;
using Todo.Web.Handlers.Interfaces;
using Todo.Shared.ViewModel;

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

                if (!command.IsValid)
                {
                    return new CommandResult("Requisição inválida", 400, command.Notifications);
                
                }
            } catch
            {
                return new CommandResult("Erro interno no servidor", 500);
            }
            // 1 - Criar o Usuário

            NovaAtividadeViewModel novaAtividade = new NovaAtividadeViewModel(command.Titulo);

            try
            {
                var resultadoCriacao = _repository.CriarAtividade(novaAtividade);

                if (!resultadoCriacao)
                {
                    return new CommandResult("Não foi possível inserir a atividade", 400);
                }

            } catch
            {
                return new CommandResult("Erro ao acessar o banco", 400);
            }

            // 2 - Retorna o resultado
            RespostaDados retornoDados = new RespostaDados();
            retornoDados.Titulo = novaAtividade.Titulo;
            //retornoDados.Conclusao = (novaAtividade.Conclusao == 1) ? true : false;
            //retornoDados.Conclusao = novaAtividade.Conclusao;
            retornoDados.DataCriacao = novaAtividade.DataCriacao;

            return new CommandResult("Criação de atividade com sucesso", retornoDados);
        }
    }
}
