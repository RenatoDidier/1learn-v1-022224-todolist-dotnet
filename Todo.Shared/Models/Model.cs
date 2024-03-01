namespace Todo.Shared.Models
{
    public abstract class Model
    {
        public Model()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
    }
}
