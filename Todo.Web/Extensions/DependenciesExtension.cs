using System.Data.SqlClient;
using Todo.Repository.Repositories;
using Todo.Repository.Repositories.Contracts;
using Todo.Web.Commands;
using Todo.Web.Handlers;
using Todo.Web.Handlers.Interfaces;

namespace Todo.Web.Extensions
{
    public static class DependenciesExtension
    {
        public static void AddSqlConnection(
                this IServiceCollection services,
                string connectionString
            )
        {
            services.AddScoped<SqlConnection>(x
                => new SqlConnection(connectionString));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITodoRepository, TodoRepository>();
        }

        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<IHandler<CriarAtividadeCommand>, AtividadeHandler>();
        }
    }
}
