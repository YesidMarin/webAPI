using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private IRepositoryWrapper _repositoryWrapper;
        private ILoggerManager _logger;

        public CustomerController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper)
        {
            _logger = logger;
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customers = _repositoryWrapper.Customer.GetAllCustomers();
                _logger.LogInfo("Returned all customers inside: CustomerController -> GetAllCustomers from database.");
                return Ok(customers);
            } catch (Exception ex)
            {
                _logger.LogError($"Somenthing went wrong inside: CustomerController -> GetAllCustomers. Message error: {ex.Message}");
                return StatusCode(500, "Internal error server");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            try
            {
                var customer = _repositoryWrapper.Customer.GetCustomerById(id);

                if (customer.GuidCustomer.Equals(Guid.Empty))
                {
                    _logger.LogWarn($"Not found register inside: CustomerController -> GetCustomerById with id: {id}");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned customer inside: CustomerController -> GetCustomerById with id: {id}");
                    return Ok(customer);
                }

            } catch (Exception ex)
            {
                _logger.LogError($"Somenthing went wrong inside: CustomerController -> GetCustomerById. Message error: {ex.Message}");
                return StatusCode(500, "Internal error server");
            }
        }
    }
}
