namespace Todo.Web.Models
{
    public class Atividade
    {
        public Atividade()
        {

        }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool? Conclusao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataUltimaModificacao { get; set; }
        public DateTime? DataExclusao { get; set; }

    }
}
