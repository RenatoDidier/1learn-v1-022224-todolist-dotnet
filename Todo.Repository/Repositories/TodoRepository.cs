using System.Data.SqlClient;
using Todo.Shared.Models;
using Todo.Repository.Repositories.Contracts;
using Dapper;
using System.Data;
using Todo.Shared.ViewModel;

namespace Todo.Repository.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly SqlConnection _connection;

        private readonly string PRC_LISTAR_ATIVIDADES = "PRC_LISTAR_ATIVIDADES";
        private readonly string PRC_LISTAR_ATIVIDADE_POR_ID = "PRC_LISTAR_ATIVIDADE_POR_ID";
        private readonly string PRC_CRIAR_ATIVIDADE = "PRC_CRIAR_ATIVIDADE";
        private readonly string PRC_EDITAR_ATIVIDADE = "PRC_EDITAR_ATIVIDADE";
        private readonly string PRC_EXCLUIR_ATIVIDADE = "PRC_EXCLUIR_ATIVIDADE";

        public TodoRepository(SqlConnection connection)
            => _connection = connection;


        public async Task<List<AtividadeViewModel?>> ListarTodasAtividadesAsync(object parametros)
        {
            List<AtividadeViewModel> listaFinal = new List<AtividadeViewModel>();

            var resultado = await _connection.QueryAsync<Atividade>(
                    PRC_LISTAR_ATIVIDADES,
                    parametros,
                    commandType: CommandType.StoredProcedure
                );

            if (resultado == null)
                return null;

            foreach (var item in resultado)
            {
                AtividadeViewModel atividadeItem = new AtividadeViewModel(
                    item.Id, 
                    item.Titulo,
                    BitConverter.ToBoolean(item.ByteBanco, 0)
                    );

                listaFinal.Add(atividadeItem);
            }

            return listaFinal;
        }

        public async Task<AtividadeViewModel?> ListarAtividadePorIdAsync(object parametros)
        {
            var resultado = await _connection.QueryFirstOrDefaultAsync<Atividade>(
                    PRC_LISTAR_ATIVIDADE_POR_ID,
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            if (resultado == null)
                return null;


            AtividadeViewModel resultadoFinal = new AtividadeViewModel();

            resultadoFinal.Id = resultado.Id;
            resultadoFinal.Titulo = resultado.Titulo;
            resultadoFinal.Conclusao = BitConverter.ToBoolean(resultado.ByteBanco, 0);

            return resultadoFinal;
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
