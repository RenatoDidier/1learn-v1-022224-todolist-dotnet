using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Web.Controllers
{
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpGet("/")]
        public string ChamarApi()
        {
            Console.WriteLine("Chamou aqui");

            return "Está funcionando";
        }
    }
}
