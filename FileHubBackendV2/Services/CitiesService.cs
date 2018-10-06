using FileHubBackendV2.Models;
using FileHubBackendV2.Repositories;
using System.Collections.Generic;

namespace FileHubBackendV2.Services
{
    public class CitiesService: ICitiesService
    {
        private ICitiesRepository _citiesRepository;

        public CitiesService(ICitiesRepository citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }

        public IEnumerable<CityFeDto> GetAllCities()
        {
            return _citiesRepository.GetAllCities();
        }

        public CityFeDto GetCityById(int id)
        {
            return _citiesRepository.GetCityById(id);
        }

        public CityFeDto AddCity(CityFeDto city)
        {
            return _citiesRepository.AddCity(city);
        }
    }
}
