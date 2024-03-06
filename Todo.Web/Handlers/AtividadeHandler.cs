using Todo.Repository.Repositories.Contracts;
using Todo.Shared.Commands;
using Todo.Shared.Models;
using Todo.Shared.ViewModel;
using Todo.Web.Commands;
using Todo.Web.Handlers.Interfaces;

namespace Todo.Web.Handlers
{
    public class AtividadeHandler
        : IHandler<CriarAtividadeCommand>, 
            IHandler<EditarAtividadeCommand>,
            IHandler<ExcluirAtividadeCommand>,
            IHandler<ListarAtividadeCommand>

    {
        private readonly ITodoRepository _repository;

        public AtividadeHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(ListarAtividadeCommand command)
        {

            #region Fail Fast Validation
            try
            {
                command.ValidarEnvioDados();

                if (!command.IsValid)
                    return new CommandResult("Erro no envio dos dados", 401, command.Notifications);
            } catch
            {
                return new CommandResult("Erro interno no servidor", 500);
            }
            #endregion

            #region Executar a consulta no banco e retornar dados
            try
            {
                var parametros = new
                {
                    command.Titulo,
                    command.Conclusao
                };

                List<AtividadeViewModel?> resultado = await _repository.ListarTodasAtividadesAsync(parametros);

                if (resultado == null)
                    return new CommandResult(201);

                return new CommandResult(resultado);

            } catch
            {
                return new CommandResult("Erro ao conectar no banco", 500);
            }
            #endregion
        }

        #region EditarAtividade
        public async Task<ICommandResult> Handle(EditarAtividadeCommand command)
        {
            #region Fail Fast Validation
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
            #endregion

            AtividadeViewModel? retornoAtividade;
            #region Validar Existência de Atividade
            try
            {
                var parametros = new
                {
                    command.Id
                };

                retornoAtividade = await _repository.ListarAtividadePorIdAsync(parametros);

                if (retornoAtividade == null)
                    return new CommandResult("EEE01 - Não foi possível executar a sua ação", 400);


            } catch
            {
                return new CommandResult("Problema ao acessar o banco", 500);
            }
            #endregion

            #region Executar Edição de Atividade
            try
            {
                object parametro = new
                {
                    command.Id,
                    Titulo = command.Titulo ?? retornoAtividade.Titulo,
                    command.Conclusao,
                    DataUltimaModificacao = DateTime.Now,
                };

                var resultado = await _repository.EditarAtividadeAsync(parametro);

                if (!resultado)
                {
                    return new CommandResult("EEE02 - Erro ao editar atividade", 500);
                }
            } catch
            {
                return new CommandResult("Erro ao conectar no banco", 500);
            }
            #endregion

            #region Retorno da requisição
            return new CommandResult("Atividade alterada com sucesso");
            #endregion

        }
        #endregion

        #region CriarAtividade
        public async Task<ICommandResult> Handle(CriarAtividadeCommand command)
        {
            #region Fail Fast validation
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
            #endregion

            #region Criar o usuário
            try
            {
                object parametro = new
                {
                    command.Titulo,
                    Conclusao = false,
                    DataCriacao = DateTime.Now
                };

                var resultadoCriacao = await _repository.CriarAtividadeAsync(parametro);

                if (!resultadoCriacao)
                {
                    return new CommandResult("Não foi possível inserir a atividade", 400);
                }

            } catch
            {
                return new CommandResult("Erro ao acessar o banco", 400);
            }
            #endregion

            #region Retorna o resultado
            AtividadeViewModel retornoDados = new AtividadeViewModel();
            retornoDados.Titulo = command.Titulo;
            retornoDados.Conclusao = false;

            return new CommandResult("Criação de atividade com sucesso", retornoDados);
            #endregion
        }
        #endregion

        #region ExcluirAtividade
        public async Task<ICommandResult> Handle(ExcluirAtividadeCommand command)
        {
            #region Fail Fast Validation
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
            #endregion

            #region Validar se Atividade existe no banco

            try
            {
                var parametros = new
                {
                    command.Id
                };

                var atividade = await _repository.ListarAtividadePorIdAsync(parametros);

                if (atividade == null)
                    return new CommandResult("EEA01 - Erro ao excluir Atividade", 400);

            } catch
            {
                return new CommandResult("Erro ao acessar o banco", 500);
            }

            #endregion

            #region Executar ação de exclusão
            try
            {
                var parametros = new
                {
                    command.Id,
                    DataExclusao = DateTime.Now
                };

                var resultado = await _repository.ExcluirAtividadeAsync(parametros);

                if (!resultado)
                {
                    return new CommandResult("EEA02 - Erro ao excluir Atividade", 400);
                }

            } catch
            {
                return new CommandResult("Problema ao acessar o banco", 400);
            }
            #endregion

            #region Retornar dados
            return new CommandResult("Atividade excluída com sucesso");
            #endregion
        }
        #endregion
    }
}
