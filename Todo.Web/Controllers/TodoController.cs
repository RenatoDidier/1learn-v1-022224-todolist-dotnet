using Dapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Todo.Web.Models;
using Todo.Web.ViewModel.Todo;

namespace Todo.Web.Controllers
{
    [ApiController]
    public class TodoController : ControllerBase
    {
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
            var listaFinal = new List<Atividade>();

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var resultado = connection.Query(
                    "PRC_LISTAR_ATIVIDADES",
                    commandType: CommandType.StoredProcedure
                    );

                foreach (var item in resultado)
                {
                    Atividade atividadeItem = new Atividade();

                    atividadeItem.Id = item.Id;
                    atividadeItem.Titulo = item.Titulo;
                    atividadeItem.Conclusao = BitConverter.ToBoolean((byte[])item.Conclusao, 0);
                    atividadeItem.DataCriacao = item.DataCriacao;
                    atividadeItem.DataUltimaModificacao = item.DataUltimaModificacao;

                    listaFinal.Add(atividadeItem);
                }
            }
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
