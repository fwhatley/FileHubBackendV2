using FileHubBackendV2.Models;
using System.Collections.Generic;

namespace FileHubBackendV2.Services
{
    public interface ICitiesService
    {
        IEnumerable<CityFeDto> GetAllCities();
        CityFeDto GetCityById(int id);
        CityFeDto AddCity(CityFeDto city);
    }
}
