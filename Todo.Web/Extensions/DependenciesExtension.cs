using System.Data.SqlClient;
using Todo.Repository.Repositories;
using Todo.Repository.Repositories.Contracts;

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
    }
}
