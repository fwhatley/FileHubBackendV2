using FileHubBackendV2.Models;
using System.Collections.Generic;

namespace FileHubBackendV2.DataStore
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get;  } = new CitiesDataStore();
        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Description = "Description 1",
                    Name = "name 1",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "point interest 1 name",
                            Description = "point interest 1 description"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "point interest 2 name",
                            Description = "point interest 2 description"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Description = "Description 2",
                    Name = "name 2",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "point interest 1name",
                            Description = "point interest 1 description"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "point interest 2 name",
                            Description = "point interest 2 description"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Description = "Description 3",
                    Name = "name 3",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "point interest 1 name",
                            Description = "point interest 1 description"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "point interest 2 name",
                            Description = "point interest 2 description"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 4,
                    Description = "Description 4",
                    Name = "name 4",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "point interest 1 name",
                            Description = "point interest 1 description"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "point interest 2 name",
                            Description = "point interest 2 description"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 5,
                    Description = "Description 5",
                    Name = "name 5",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "point interest 1 name",
                            Description = "point interest 1 description"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "point interest 2 name",
                            Description = "point interest 2 description"
                        }
                    }
                }
            };
        }

    }
}
