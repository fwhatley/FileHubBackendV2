using Microsoft.AspNetCore.Mvc;

namespace FileHubBackendV2.Controllers
{
    [Route("api/health")]
    public class HealthController : Controller
    {

        [HttpGet]
        public IActionResult GetHealth()
        {
            // Use IAction result for returning objects in xml or json. JSONresult is only for json
            return Ok("System is alive and kicking.");
        }
    }
}