using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace Todo.Repository.Configuration
{
    public class DapperConnection<TModel> where TModel : class
    {
        private readonly SqlConnection _connection;

        public DapperConnection(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<TModel> ListarTodosAsync(string procedure)
        {
            var valoresCarregados = _connection.Query<TModel>
                (
                    procedure,
                    commandType: CommandType.StoredProcedure
                );

            return valoresCarregados;
        }

        public bool Criar(string procedure, object parametros)
        {
            int linhasAfetadas = _connection.Execute(
                    procedure,
                    parametros,
                    commandType: CommandType.StoredProcedure
                );

            return linhasAfetadas > 0;
        }

    }
}
