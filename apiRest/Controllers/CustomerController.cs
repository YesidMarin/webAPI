using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Extensions;
using Entities.Models;
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

                if (customers.Where((arg) => arg.IsEmptyObject()).Any())
                {
                    return NotFound();
                }

                //_logger.LogInfo("Returned all customers inside: CustomerController -> GetAllCustomers from database.");
                return Ok(customers);
            } catch (Exception ex)
            {
                _logger.LogError($"Somenthing went wrong inside: CustomerController -> GetAllCustomers. Message error: {ex.Message}");
                return StatusCode(500, "Internal error server");
            }
        }

        [HttpGet("{id}", Name = "CustomerById")]
        public IActionResult GetCustomerById(int id)
        {
            try
            {
                var customer = _repositoryWrapper.Customer.GetCustomerById(id);

                if (customer.IsEmptyObject())
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

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    _logger.LogError("Customer object sent from client is null");
                    return BadRequest("Customer object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid customer object sent from client.");
                    return BadRequest(ModelState);
                }

                _repositoryWrapper.Customer.CreateCustomer(customer);

                return CreatedAtRoute("CustomerById", new { id = customer.Identification}, customer);
            } catch (Exception ex)
            {
                _logger.LogError($"Somenthing went wrong inside: CustomerController -> CreateCustomer. Message error: {ex}");
                return StatusCode(500, $"Internal error server {ex.InnerException.InnerException.Message}");
            }
        }

        [HttpPut("{id}")]
        
        public IActionResult UpdateCustomer(int id, [FromBody] Customer customer)
        {
            try
            {
          
                if (customer == null)
                {
                    _logger.LogError("Customer object sent from client is null");
                    return BadRequest("Customer object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid customer object sent from client.");
                    return BadRequest(ModelState);
                }

                var dbCustomer = _repositoryWrapper.Customer.GetCustomerById(id);
                if (dbCustomer.IsEmptyObject())
                {
                    _logger.LogWarn($"Not found register inside: CustomerController -> UpdateCustomer with id: {id}");
                    return NotFound();
                }
                _repositoryWrapper.Customer.UpdateCustomer(dbCustomer, customer);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Somenthing went wrong inside: CustomerController -> UpdateCustomer. Message error: {ex}");
                return StatusCode(500, "Internal error server");
            }
        }
    }
}
