using Flunt.Notifications;

namespace Todo.Web.UseCases
{
    public abstract class Response
    {
        public string Mensagem { get; set; } = string.Empty;
        public int Status { get; set; } = 400;
        public bool TransicaoValida => Status is >= 200 and <= 299;
        public IEnumerable<Notification>? Notifications { get; set; }
    }
}
