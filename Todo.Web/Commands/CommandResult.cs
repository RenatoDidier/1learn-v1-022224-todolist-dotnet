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
        public CommandResult(List<AtividadeViewModel> listaDados)
        {
            ListaDados = listaDados;
            Status = 201;
            Notifications = null;
        }        
        public CommandResult(int status)
        {
            ListaDados = new List<AtividadeViewModel>();
            Status = status;
            Notifications = null;
        }
        public CommandResult(string mensagem, RespostaDados dados)
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

        public List<AtividadeViewModel> ListaDados { get; set; } = new List<AtividadeViewModel>();
        public RespostaDados? Dados { get; set; }


    }
    public class RespostaDados
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Conclusao { get; set; }
    }
}
