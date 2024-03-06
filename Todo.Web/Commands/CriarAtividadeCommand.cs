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
                    .IsGreaterThan(Titulo.Length, 4, "Titulo", "A atividade precisa ter, no mínimo, 4 caracteres")
                    .IsLowerThan(Titulo.Length, 300, "Titulo", "A atividade precisa ter menos do que 300 caracteres")
                );
        }
    }
}
