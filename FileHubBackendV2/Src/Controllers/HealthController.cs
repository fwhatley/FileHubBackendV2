using Microsoft.AspNetCore.Mvc;

namespace FileHubBackendV2.Src.Controllers
{

    /// <summary>
    /// Controller's job
    ///     - validate data
    ///         - return right away if data is invalid. eg., return badRequest if filename is required and not provided
    ///     - initilize required data. eg., initilize DeleteUtc to date.maxValue
    /// </summary>
    [Route("api/health")]
    public class HealthController : Controller
    {

        [HttpGet]
        public IActionResult GetHealth()
        {
            var msg = new
            {
                msg = "System is alive and kicking."
            };

            // Use IAction result for returning objects in xml or json. JSONresult is only for json
            return Ok(msg);
        }
    }
}