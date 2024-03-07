using Microsoft.AspNetCore.Mvc;
using Todo.Shared.Repositories;
using Todo.Web.Commands;
using Todo.Shared.Commands;
using Todo.Web.Handlers.Interfaces;

namespace Todo.Web.Controllers
{
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IHandler<CriarAtividadeCommand> _handlerCriarAtividade;
        private readonly IHandler<EditarAtividadeCommand> _handlerEditarAtividade;
        private readonly IHandler<ExcluirAtividadeCommand> _handlerExcluirAtividade;
        private readonly IHandler<ListarAtividadeCommand> _handlerListarAtividade;

        public TodoController(
                ITodoRepository todoRepository, 
                IHandler<CriarAtividadeCommand> handlerCriarAtividade,
                IHandler<EditarAtividadeCommand> handlerEditarAtividade,
                IHandler<ExcluirAtividadeCommand> handlerExcluirAtividade,
                IHandler<ListarAtividadeCommand> handlerListarAtividade
            )
        {
            _todoRepository = todoRepository;
            _handlerCriarAtividade = handlerCriarAtividade;
            _handlerEditarAtividade = handlerEditarAtividade;
            _handlerExcluirAtividade = handlerExcluirAtividade;
            _handlerListarAtividade = handlerListarAtividade;
        }

        [HttpGet("/")]
        public string ChamarApi()
        {
            Console.WriteLine("Chamou aqui");

            return "Está funcionando";
        }

        [HttpPost("v1/atividades/listar")]
        public async Task<CommandResult> ListarAtividade(
                [FromBody] ListarAtividadeCommand atividade
            )
        {
            var acaoListarAtividade = await _handlerListarAtividade.Handle(atividade);

            var teste = acaoListarAtividade.Status;

            return acaoListarAtividade;

        }

        [HttpGet("v1/atividades/listar/{id}")]
        public async Task<ICommandResult?> ListarAtividadePorId(
                [FromRoute] int id
            )
        {

            var retornoRepository = await _todoRepository.ListarAtividadePorIdAsync(id);

            if (retornoRepository == null)
                return new CommandResult(201);


            return new CommandResult(201, retornoRepository);
        }

        [HttpPost("v1/atividades/criar")]
        public async Task<ICommandResult> CriarAtividade(
                [FromBody] CriarAtividadeCommand atividade
            )
        {
            var acaoCriarAtividade = await _handlerCriarAtividade.Handle(atividade);

            return acaoCriarAtividade;

        }

        [HttpPut("v1/atividades/editar")]
        public async Task<ICommandResult> EditarAtividade(
                [FromBody] EditarAtividadeCommand atividade
            )
        {
            var acaoEditarAtividade = await _handlerEditarAtividade.Handle(atividade);

            return acaoEditarAtividade;
        }

        [HttpDelete("v1/atividades/excluir")]
        public async Task<ICommandResult> ExcluirAtividade(
                [FromBody] ExcluirAtividadeCommand atividade
            )
        {
            var acaoExcluirAtividade = await _handlerExcluirAtividade.Handle(atividade);

            return acaoExcluirAtividade;
        }
    }
}
