
namespace Todo.Shared.ViewModel
{
    public struct NovaAtividadeViewModel
    {
        public NovaAtividadeViewModel(string titulo)
        {
            Titulo = titulo;
        }
        public string Titulo { get; set; }
        public bool Conclusao = false;
        public DateTime DataCriacao = DateTime.Now;
    }
}
