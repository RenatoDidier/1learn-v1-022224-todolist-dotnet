using Todo.Shared.Models;

namespace Todo.Shared.Services
{
    public interface IJokeService
    {
        Task<JokeModel?> ChamarJoke();
    }
}
