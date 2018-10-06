using FileHubBackendV2.Models;
using FileHubBackendV2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FileHubBackendV2.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        private ICitiesService _citiesService;

        public CitiesController(ICitiesService citiesService)
        {
            _citiesService = citiesService;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            // Use IAction result for returning objects in xml or json. JSONresult is only for json
            IEnumerable<CityFeDto> cities = _citiesService.GetAllCities();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCityById(int id)
        {
            // find city
            CityFeDto cityToReturn = _citiesService.GetCityById(id);

            if (cityToReturn == null)
            {
                return NotFound();

            }

            return Ok(cityToReturn);
        }

        [HttpPost()]
        public IActionResult AddCity(CityFeDto city)
        {
            CityFeDto cityToReturn = _citiesService.AddCity(city);
            return Ok(cityToReturn);
        }
    }
}