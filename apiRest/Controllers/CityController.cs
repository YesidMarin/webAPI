using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Contracts;

namespace apiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : Controller
    {

        private IRepositoryWrapper _repositoryWrapper;
        private ILoggerManager _logger;

        public CityController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper)
        {
            _logger = logger;
            _repositoryWrapper = repositoryWrapper;
        }


        [HttpGet]
        public IActionResult GetAllCities()
        {
            try
            {
                var cities = _repositoryWrapper.City.GetAllCities();

                foreach (var city in cities.ListCities)
                {
                    if (city.Id.Equals(Guid.Empty)){
                        return NotFound();
                    }
                }

                _logger.LogInfo("Return all cities inside: CityController -> GetAllCities from database.");
                return Ok(cities);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside: CityController -> GetAllCities. Message error: {ex.Message}");
                return StatusCode(500, "Internal server error");
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
                    _logger.LogWarn($"Not found register inside: CityController -> GetCityById with id: {id}");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Return city with id: {id}");
                    return Ok(city);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside: CityController -> GetCityById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/customers")]
        public IActionResult GetCityByIdWithCustomers(Guid id)
        {
            try
            {
                var city = _repositoryWrapper.City.GetCityByIdWithCustomers(id);
                if (city.Id.Equals(Guid.Empty))
                {
                    _logger.LogWarn($"Not found register inside: CityController -> GetCityByIdWithCustomers with id: {id}");
                    return NotFound();
                }
                else
                {
                    foreach (var customer in city.Customers)
                    {
                        if (customer.Id.Equals(Guid.Empty)){
                            return NotFound();
                        }
                    }
                    _logger.LogInfo($"Return customers in city with id: {id}");
                    return Ok(city);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside: CityController -> GetCityByIdWithCustomers action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
