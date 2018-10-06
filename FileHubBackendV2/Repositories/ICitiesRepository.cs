using FileHubBackendV2.Models;
using System.Collections.Generic;

namespace FileHubBackendV2.Repositories
{
    public interface ICitiesRepository
    {
        IEnumerable<CityFeDto> GetAllCities();
        CityFeDto GetCityById(int id);
        CityFeDto AddCity(CityFeDto city);
    }
}
