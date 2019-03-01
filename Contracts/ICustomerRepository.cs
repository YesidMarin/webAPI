using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer dbCustomer, Customer customer);
    }
}
