using System;
using System.Collections.Generic;
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

        public IEnumerable<City> GetAllCities()
        {
            return FindAll().OrderBy(cw => cw.CityName);
        }
    }
}
