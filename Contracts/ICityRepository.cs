using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface ICityRepository : IRepositoryBase<City>
    {
        Cities GetAllCities();
    }
}
