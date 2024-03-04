using Flunt.Notifications;
using Flunt.Validations;
using System.Diagnostics.Contracts;
using Todo.Shared.Commands;

namespace Todo.Web.Commands
{
    public class CriarAtividadeCommand : Notifiable<Notification>, ICommand
    {
        public CriarAtividadeCommand()
        {
            
        }        
        public CriarAtividadeCommand(string titulo)
        {
            Titulo = titulo;
        }
        public string Titulo { get; set; }
        public void ValidarEnvioDados()
        {
            AddNotifications(
                new Contract<CriarAtividadeCommand>()
                    .Requires()
                    .IsLowerThan(Titulo.Length, 3, "A atividade precisa ter mais do que 3 caracteres")
                    .IsGreaterThan(Titulo.Length, 300, "A atividade precisa ter, no máximo, 300 caracteres")
                );
        }
    }
}
