using Todo.Repository.Repositories.Contracts;
using Todo.Shared.Commands;
using Todo.Web.Commands;
using Todo.Web.Handlers.Interfaces;

namespace Todo.Web.Handlers
{
    public class AtividadeHandler
        : IHandler<CriarAtividadeCommand>, 
            IHandler<EditarAtividadeCommand>,
            IHandler<ExcluirAtividadeCommand>

    {
        private readonly ITodoRepository _repository;

        public AtividadeHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(EditarAtividadeCommand command)
        {
            try
            {
                command.ValidarEnvioDados();

                if (!command.IsValid)
                {
                    return new CommandResult("Requisição inválida", 400, command.Notifications);

                }
            }
            catch
            {
                return new CommandResult("Erro interno no servidor", 500);
            }

            try
            {
                object parametro = new
                {
                    command.Id,
                    command.Titulo,
                    command.Conclusao,
                    DataUltimaModificacao = DateTime.Now,
                };

                var resultado = _repository.EditarAtividade(parametro);

                if (!resultado)
                {
                    return new CommandResult("Erro ao editar atividade", 500);
                }
            } catch
            {
                return new CommandResult("Erro ao conectar no banco", 500);
            }

            return new CommandResult("Atividade alterada com sucesso");

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

            try
            {
                object parametro = new
                {
                    command.Titulo,
                    Conclusao = false,
                    DataCriacao = DateTime.Now
                };

                var resultadoCriacao = _repository.CriarAtividade(parametro);

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
            retornoDados.Titulo = command.Titulo;
            retornoDados.Conclusao = false;

            return new CommandResult("Criação de atividade com sucesso", retornoDados);
        }

        public ICommandResult Handle(ExcluirAtividadeCommand command)
        {
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

            try
            {
                var parametros = new
                {
                    command.Id,
                    DataExclusao = DateTime.Now
                };

                var resultado = _repository.ExcluirAtividade(parametros);

                if (!resultado)
                {
                    return new CommandResult("Erro ao excluir Atividade", 400);
                }

            } catch
            {
                return new CommandResult("Problema ao acessar o banco", 400);
            }

            return new CommandResult("Atividade excluída com sucesso");
        }
    }
}
