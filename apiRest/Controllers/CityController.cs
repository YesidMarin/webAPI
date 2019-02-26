using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Contracts;

namespace apiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController: Controller
    {

        private IRepositoryWrapper _repositoryWrapper;

        public CityController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }


        [HttpGet]
        public IActionResult GetAllCities()
        {
            try
            {
                var cities = _repositoryWrapper.City.GetAllCities();
                return Ok(cities);
            } catch (Exception ex)
            {
                return StatusCode(500, "Interal Error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCityById(Guid id)
        {
            try
            {

                var city = _repositoryWrapper.City.GetCityById(id);
                if (city.Id.Equals(Guid.Empty))
                {
                    return NotFound();
                }
                else
                {
                    return Ok(city);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
