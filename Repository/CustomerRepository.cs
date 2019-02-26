using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {

        public CustomerRepository(RepositoryContext repositoryContext): base(repositoryContext) { }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return FindAll().OrderBy(ob => ob.Name);
        }

        public Customer GetCustomerById(int id)
        {
            return FindByCondition(ob => ob.Identification.Equals(id))
                .DefaultIfEmpty(new Customer())
                .FirstOrDefault();
        }
    }
}
