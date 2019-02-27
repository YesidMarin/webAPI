using System;
using System.Collections.Generic;
using Entities.Models;

namespace Entities.DTO
{
    public class CityDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Customer> Customers { get; set; }

        public CityDTO()
        {
        }

        public CityDTO(City city)
        {
            Id = city.Id;
            Name = city.Name;
        }

    }
}
