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

        public TodoController(ITodoRepository todoRepository, IHandler<CriarAtividadeCommand> handlerCriarAtividade)
        {
            _todoRepository = todoRepository;
            _handlerCriarAtividade = handlerCriarAtividade;
        }

        [HttpGet("/")]
        public string ChamarApi()
        {
            Console.WriteLine("Chamou aqui");

            return "Está funcionando";
        }

        [HttpGet("v1/atividades/listar")]
        public List<Atividade> ListarAtividade()
        {
            var listaFinal = _todoRepository.ListarTodasAtividades();

            return listaFinal;

        }

        [HttpPost("v1/atividades/criar")]
        public ICommandResult CriarAtividade(
                [FromBody] CriarAtividadeCommand atividade
            )
        {
            var acaoCriarAtividade = _handlerCriarAtividade.Handle(atividade);

            return acaoCriarAtividade;

        }
    }
}
