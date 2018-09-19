using FileHubBackendV2.DataStore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FileHubBackendV2.Controllers
{
    [Route("api/cities")]
    public class PointsOfInterestController : Controller
    {

        [HttpGet("{id}/pointsofinterest")]
        public IActionResult GetPointsOfinterest(int id)
        {
            // find city
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

            if (cityToReturn == null)
            {
                return NotFound();

            }

            return Ok(cityToReturn.PointsOfInterest);
        }

        [HttpGet("{cityId}/pointsofinterest/{id}")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            // find city
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (cityToReturn == null)
            {
                return NotFound();

            }

            var pointOfInterest = cityToReturn.PointsOfInterest.FirstOrDefault(p => p.Id == id);
            if (pointOfInterest == null)
            {
                return NotFound();
            }


            return Ok(pointOfInterest);
        }
    }
}