using Flunt.Notifications;
using Flunt.Validations;
using System.Diagnostics.Contracts;
using Todo.Shared.Commands;

namespace Todo.Web.Commands
{
    public class ExcluirAtividadeCommand : Notifiable<Notification>, ICommand
    {
        public ExcluirAtividadeCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public DateTime DataExclusao { get; set;}

        public void ValidarEnvioDados()
        {
            AddNotifications(new Contract<ExcluirAtividadeCommand>()
                    .Requires()
                    .IsGreaterOrEqualsThan(Id, 0, "Id", "Id passado inválido")
                );
        }
    }
}
