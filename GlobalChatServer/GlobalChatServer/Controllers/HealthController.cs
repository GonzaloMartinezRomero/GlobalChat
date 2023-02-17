using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GlobalChatServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet("IsServerOnline")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Boolean))]
        public IActionResult IsServerOnline()
        {
            return Ok(true);
        }
    }
}
