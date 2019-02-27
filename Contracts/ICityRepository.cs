using System;
using System.Collections.Generic;
using Entities.DTO;
using Entities.Models;

namespace Contracts
{
    public interface ICityRepository : IRepositoryBase<City>
    {
        Cities GetAllCities();

        City GetCityById(Guid id);

        CityDTO GetCityByIdWithCustomers(Guid id);
    }
}
