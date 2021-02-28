using Microsoft.AspNetCore.Mvc;

namespace rcLogApiNetCore.Controllers
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
        [HttpGet("Autenticado")]
        public IActionResult Autenticado()
        {
            return Ok("Autenticado OK");
        }
    }
}
