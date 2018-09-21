using FileHubBackendV2.DataStore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FileHubBackendV2.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {

        [HttpGet]
        public IActionResult GetCities()
        {
            // Use IAction result for returning objects in xml or json. JSONresult is only for json
            return Ok(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            // find city
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

            if (cityToReturn == null)
            {
                return NotFound();

            }

            return Ok(cityToReturn);
        }
    }
}