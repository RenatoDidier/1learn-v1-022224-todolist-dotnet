using Dapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Todo.Shared.Models;
using Todo.Repository.Repositories.Contracts;
using Todo.Web.ViewModel.Todo;
using Todo.Web.Commands;
using Todo.Web.Handlers;
using Todo.Repository.Repositories;
using Todo.Shared.Commands;

namespace Todo.Web.Controllers
{
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
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
                [FromBody] AtividadeViewModel atividade
            )
        {

            var command = new CriarAtividadeCommand(atividade.Titulo);

            var handler = new AtividadeHandler(_todoRepository);

            return handler.Handle(command);

        }
    }
}
