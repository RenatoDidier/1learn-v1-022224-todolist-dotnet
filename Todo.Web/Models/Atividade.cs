namespace Todo.Web.Models
{
    public class Atividade
    {
        public Atividade()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Titulo { get; set; }
        public bool Concluido { get; set; }

    }
}
