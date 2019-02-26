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

        public CustomerController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customers = _repositoryWrapper.Customer.GetAllCustomers();
                return Ok(customers);
            } catch (Exception ex)
            {
                return StatusCode(500, "Interal Error");
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
                    return NotFound();
                }
                else
                {
                    return Ok(customer);
                }

            } catch (Exception ex)
            {
                return StatusCode(500, "Error Internal");
            }
        }
    }
}
