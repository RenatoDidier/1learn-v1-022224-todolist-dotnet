using Flunt.Notifications;
using Todo.Shared.Commands;
using Todo.Shared.Models;
using Todo.Shared.ViewModel;
using Todo.Web.UseCases;

namespace Todo.Web.Commands
{
    public class CommandResult : Response, ICommandResult
    {
        public CommandResult()
        {
            
        }
        public CommandResult(string mensagem)
        {
            Mensagem = mensagem;
            Status = 201;
            Notifications = null;
        }        
        public CommandResult(List<AtividadeViewModel?> listaDados)
        {
            ListaDados = listaDados;
            Status = 201;
            Notifications = null;
        }        
        public CommandResult(int status)
        {
            ListaDados = new List<AtividadeViewModel?>();
            Status = status;
            Notifications = null;
        }        
        public CommandResult(int status, AtividadeViewModel dados)
        {
            Dados = dados;
            Status = status;
            Notifications = null;
        }        
        public CommandResult(int status, JokeModel dados)
        {
            DadosJoke = dados;
            Status = status;
            Notifications = null;
        }
        public CommandResult(string mensagem, AtividadeViewModel dados)
        {
            Mensagem = mensagem;
            Status = 201;
            Notifications = null;
            Dados = dados;

        }
        public CommandResult(string mensagem, int status, IEnumerable<Notification>? notifications = null)
        {
            Mensagem = mensagem;
            Status = status;
            Notifications = notifications;
        }

        public List<AtividadeViewModel?> ListaDados { get; set; } = new List<AtividadeViewModel?>();
        public AtividadeViewModel? Dados { get; set; }
        public JokeModel? DadosJoke { get; set; }


    }
}
