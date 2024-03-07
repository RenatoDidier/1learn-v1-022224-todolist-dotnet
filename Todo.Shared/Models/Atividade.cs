namespace Todo.Shared.Models
{
    public class Atividade
    {
        public Atividade()
        {
            Id = 0;
            Titulo = string.Empty;
            Conclusao = false;
            ByteBanco = Array.Empty<byte>();
        }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Conclusao { get; set; }
        public byte[] ByteBanco { get; set; }

    }
}
