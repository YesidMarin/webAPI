﻿using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.DTO;
using Entities.Extensions;
using Entities.Models;

namespace Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {

        public CustomerRepository(RepositoryContext repositoryContext): base(repositoryContext) { }

        public void CreateCustomer(Customer customer)
        {
            customer.Id = Guid.NewGuid();
            customer.GuidCity = RepositoryContext.Cities.Where(obj => obj.Id == customer.GuidCity).FirstOrDefault().Id;
            Create(customer);
            Save();
        }

        public void DeleteCustomer(Customer customer)
        {
            Delete(customer);
            Save();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return FindAll().OrderBy(ob => ob.Name).DefaultIfEmpty(new Customer());
        }

        public Customer GetCustomerById(Guid id)
        {
            return FindByCondition(ob => ob.Id.Equals(id))
                .DefaultIfEmpty(new Customer())
                .FirstOrDefault();
        }

        public void UpdateCustomer(Customer dbCustomer, Customer customer)
        {
            dbCustomer.Map(customer);
            Update(dbCustomer);
            Save();
        }
    }
}
