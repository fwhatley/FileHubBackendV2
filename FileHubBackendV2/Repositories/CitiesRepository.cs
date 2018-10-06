using FileHubBackendV2.Models;
using System.Collections.Generic;
using System.Linq;

namespace FileHubBackendV2.Repositories
{
    public class CitiesRepository: ICitiesRepository
    {
        public static IEnumerable<CityFeDto> _citiesList;

        public CitiesRepository()
        {
            _citiesList = new List<CityFeDto>()
            {
                new CityFeDto()
                {
                    Id = 1,
                    Description = "Description 1",
                    Name = "name 1",
                },
                new CityFeDto()
                {
                    Id = 2,
                    Description = "Description 2",
                    Name = "name 2"
                },
                new CityFeDto()
                {
                    Id = 3,
                    Description = "Description 3",
                    Name = "name 3"
                },
                new CityFeDto()
                {
                    Id = 4,
                    Description = "Description 4",
                    Name = "name 4"
                },
                new CityFeDto()
                {
                    Id = 5,
                    Description = "Description 5",
                    Name = "name 5"
                }
            };
        }

        public IEnumerable<CityFeDto> GetAllCities()
        {
            return _citiesList;
        }

        public CityFeDto GetCityById(int id)
        {
            var city = _citiesList.FirstOrDefault(c => c.Id == id);
            return city;
        }

        public CityFeDto AddCity(CityFeDto city)
        {
            _citiesList.Append(city);
            return city;
        }
    }
}
