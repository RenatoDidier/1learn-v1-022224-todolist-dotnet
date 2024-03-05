using Dapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Todo.Shared.Models;
using Todo.Repository.Repositories.Contracts;
using Todo.Web.Commands;
using Todo.Web.Handlers;
using Todo.Repository.Repositories;
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

        public TodoController(
                ITodoRepository todoRepository, 
                IHandler<CriarAtividadeCommand> handlerCriarAtividade,
                IHandler<EditarAtividadeCommand> handlerEditarAtividade,
                IHandler<ExcluirAtividadeCommand> handlerExcluirAtividade
            )
        {
            _todoRepository = todoRepository;
            _handlerCriarAtividade = handlerCriarAtividade;
            _handlerEditarAtividade = handlerEditarAtividade;
            _handlerExcluirAtividade = handlerExcluirAtividade;
        }

        [HttpGet("/")]
        public string ChamarApi()
        {
            Console.WriteLine("Chamou aqui");

            return "Está funcionando";
        }

        [HttpGet("v1/atividades/listar")]
        public async Task<List<Atividade>> ListarAtividade()
        {
            var listaFinal = await _todoRepository.ListarTodasAtividadesAsync();

            return listaFinal;

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
