using Microsoft.AspNetCore.Mvc;

namespace rcLogWebApi.Controllers
{
    [Route("[controller]")]
    public class TesteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Testar OK");
        }

        // [Authorize]
        [HttpGet("autenticado")]
        public IActionResult Autenticado()
        {
            return Ok("Autenticado OK");
        }
    }
}