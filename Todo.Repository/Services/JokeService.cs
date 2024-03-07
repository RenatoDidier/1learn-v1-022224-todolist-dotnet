using Dapper;
using Newtonsoft.Json;
using Todo.Shared.Models;
using Todo.Shared.Services;

namespace Todo.Repository.Services
{
    public class JokeService : IJokeService
    {
        public async Task<JokeModel?> ChamarJoke()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "My Library (https://github.com/RenatoDidier)");
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                HttpResponseMessage response = await client.GetAsync("https://icanhazdadjoke.com/");

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();

                    JokeModel piada = JsonConvert.DeserializeObject<JokeModel>(jsonContent);

                    return piada;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
