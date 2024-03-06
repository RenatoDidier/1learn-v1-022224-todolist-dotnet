using Flunt.Notifications;
using Flunt.Validations;
using System.Diagnostics.Contracts;
using Todo.Shared.Commands;

namespace Todo.Web.Commands
{
    public class ListarAtividadeCommand : Notifiable<Notification>, ICommand
    {
        public string Titulo { get; set; } = string.Empty;
        public void ValidarEnvioDados()
        {
            AddNotifications(new Contract<ListarAtividadeCommand>()
                    .Requires()
                    .IsNotNull(Titulo, "Titulo", "O título não pode ser nulo")
                );
        }
    }
}
