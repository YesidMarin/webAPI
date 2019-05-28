using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.DTO;
using Entities.Models;

namespace Repository
{
    public class CityRepository: RepositoryBase<City>, ICityRepository
    {
        public CityRepository(RepositoryContext repositoryContext) :base(repositoryContext)
        {
        }

        public void CreateCity(City city)
        {
            city.Id = new Guid();
            Create(city);
            Save();
        }

        public IEnumerable<City> GetAllCities()
        {
            return (FindAll().OrderBy(ob => ob.Name)).DefaultIfEmpty(new City());
        }

        public City GetCityById(Guid id)
        {
            return FindByCondition(city => city.Id.Equals(id))
                .DefaultIfEmpty(new City())
                .FirstOrDefault();
        }

        public CityDTO GetCityByIdWithCustomers(Guid id)
        {
            return new CityDTO(GetCityById(id))
            {
                Customers = RepositoryContext.Customers
                .Where(customer => customer.GuidCity == id)
                .DefaultIfEmpty(new Customer())
            };
        }
    }
}
