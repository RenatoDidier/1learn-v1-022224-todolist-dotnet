
namespace Todo.Shared.ViewModel
{
    public class AtividadeViewModel
    {
        public AtividadeViewModel()
        {
            
        }
        public AtividadeViewModel(int id, string titulo, bool conclusao)
        {
            Id = id;
            Titulo = titulo;
            Conclusao = conclusao;
        }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Conclusao { get; set; }
    }
}
