using System;
using System.Collections.Generic;
using Entities.DTO;
using Entities.Models;

namespace Contracts
{
    public interface ICityRepository : IRepositoryBase<City>
    {
        IEnumerable<City> GetAllCities();
        City GetCityById(Guid id);
        CityDTO GetCityByIdWithCustomers(Guid id);
        void CreateCity(City city);
    }
}
