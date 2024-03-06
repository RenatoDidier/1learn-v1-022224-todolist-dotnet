using Flunt.Notifications;
using Flunt.Validations;
using System.Diagnostics.Contracts;
using Todo.Shared.Commands;

namespace Todo.Web.Commands
{
    public class EditarAtividadeCommand : Notifiable<Notification>, ICommand
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public bool Conclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; } = DateTime.Now;

        public void ValidarEnvioDados()
        {
            if (Titulo != null)
            {
                AddNotifications(
                        new Contract<EditarAtividadeCommand>()
                            .Requires()
                            .IsGreaterThan(Titulo.Length, 4, "Titulo", "A atividade precisa ter, no mínimo, 4 caracteres")
                            .IsLowerThan(Titulo.Length, 300, "Titulo", "A atividade precisa ter menos do que 300 caracteres")
                            .IsGreaterOrEqualsThan(Id, 0, "Id", "É necessário passar o Id da Atividade")
                    );
            }
        }
    }
}
