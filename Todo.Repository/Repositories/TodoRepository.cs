using System.Data.SqlClient;
using Todo.Repository.Configuration;
using Todo.Shared.Models;
using Todo.Repository.Repositories.Contracts;
using Dapper;
using Todo.Shared.ViewModel;
using System.Data;

namespace Todo.Repository.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly SqlConnection _connection;

        private readonly string PRC_LISTAR_ATIVIDADES = "PRC_LISTAR_ATIVIDADES";
        private readonly string PRC_CRIAR_ATIVIDADE = "PRC_CRIAR_ATIVIDADE";
        private readonly string PRC_EDITAR_ATIVIDADE = "PRC_EDITAR_ATIVIDADE";
        private readonly string PRC_EXCLUIR_ATIVIDADE = "PRC_EXCLUIR_ATIVIDADE";

        public TodoRepository(SqlConnection connection)
            => _connection = connection;


        public List<Atividade> ListarTodasAtividades()
        {
            var listaFinal = new List<Atividade>();

            var resultado = _connection.Query<Atividade>(
                    PRC_LISTAR_ATIVIDADES,
                    commandType: CommandType.StoredProcedure
                );

            foreach (var item in resultado)
            {
                Atividade atividadeItem = new Atividade();

                atividadeItem.Id = item.Id;
                atividadeItem.Titulo = item.Titulo;
                atividadeItem.Conclusao = BitConverter.ToBoolean(item.ByteBanco, 0);
                atividadeItem.DataCriacao = item.DataCriacao;
                atividadeItem.DataUltimaModificacao = item.DataUltimaModificacao;

                listaFinal.Add(atividadeItem);
            }

            return listaFinal;
        }


        public bool CriarAtividade(object parametros)
        {

            var resultado = _connection.Execute(
                    PRC_CRIAR_ATIVIDADE,
                    parametros,
                    commandType: CommandType.StoredProcedure
                );

            return resultado > 0;
        }

        public bool EditarAtividade(object parametros)
        {

            var resultado = _connection.Execute(
                    PRC_EDITAR_ATIVIDADE,
                    parametros,
                    commandType: CommandType.StoredProcedure
                );

            return resultado > 0;
        }

        public bool ExcluirAtividade(object parametros)
        {

            var resultado = _connection.Execute(
                    PRC_EXCLUIR_ATIVIDADE,
                    parametros,
                    commandType: CommandType.StoredProcedure
                );

            return resultado > 0;
        }


    }
}
