using System.Data.SqlClient;
using Todo.Shared.Models;
using Todo.Repository.Repositories.Contracts;
using Dapper;
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


        public async Task<List<Atividade>> ListarTodasAtividadesAsync(object parametros)
        {
            List<Atividade> listaFinal = new List<Atividade>();

            var resultado = await _connection.QueryAsync<Atividade>(
                    PRC_LISTAR_ATIVIDADES,
                    parametros,
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


        public async Task<bool> CriarAtividadeAsync(object parametros)
        {

            var resultado = await _connection.ExecuteAsync(
                    PRC_CRIAR_ATIVIDADE,
                    parametros,
                    commandType: CommandType.StoredProcedure
                );

            return resultado > 0;
        }

        public async Task<bool> EditarAtividadeAsync(object parametros)
        {

            var resultado = await _connection.ExecuteAsync(
                    PRC_EDITAR_ATIVIDADE,
                    parametros,
                    commandType: CommandType.StoredProcedure
                );

            return resultado > 0;
        }

        public async Task<bool> ExcluirAtividadeAsync(object parametros)
        {

            var resultado = await _connection.ExecuteAsync(
                    PRC_EXCLUIR_ATIVIDADE,
                    parametros,
                    commandType: CommandType.StoredProcedure
                );

            return resultado > 0;
        }


    }
}
