using Dapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Todo.Shared.Models;
using Todo.Repository.Repositories.Contracts;
using Todo.Web.ViewModel.Todo;

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
            string connectionString = "Server=localhost, 1433;Database=TodoList;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;Connection Timeout=30";
            var listaFinal = _todoRepository.ListarTodasAtividades();

            return listaFinal;

        }

        [HttpPost("v1/atividades/criar")]
        public string CriarAtividade(
                [FromBody] AtividadeViewModel atividade
            )
        {
            string connectionString = "Server=localhost, 1433;Database=TodoList;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;Connection Timeout=30";

            var parametros = new
            {
                titulo = atividade.Titulo,
                conclusao = true,
                dataCriacao = DateTime.Now
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.Execute(
                    "PRC_CRIAR_ATIVIDADE",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );

                connection.Close();
            };

            return "Chamou";
        }
    }
}
