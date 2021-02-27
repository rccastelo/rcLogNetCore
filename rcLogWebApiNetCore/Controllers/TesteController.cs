using Microsoft.AspNetCore.Mvc;

namespace rcLogWebApiNetCore.Controllers
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