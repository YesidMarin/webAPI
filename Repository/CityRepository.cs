using System;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class CityRepository: RepositoryBase<City>, ICityRepository
    {
        public CityRepository(RepositoryContext repositoryContext) :base(repositoryContext)
        {
        }

        public Cities GetAllCities()
        {
            Cities cities = new Cities();
            cities.ListCities = (FindAll().OrderBy(ob => ob.Name));
            return cities;
        }

        public City GetCityById(Guid id)
        {
            return FindByCondition(city => city.Id.Equals(id))
                .DefaultIfEmpty(new City())
                .FirstOrDefault();
        }
    }
}
