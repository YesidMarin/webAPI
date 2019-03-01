using System;
using Entities.Models;

namespace Entities.Extensions
{
    public static class CustomerExtensions
    {
        public static void Map(this Customer dbCustomer, Customer customer)
        {
            dbCustomer.GuidCity = customer.GuidCity;
            dbCustomer.Name = customer.Name;
            dbCustomer.LastName = customer.LastName;
            dbCustomer.Telephone = customer.Telephone;
            dbCustomer.Address = customer.Address;
            dbCustomer.Email = customer.Email;
        }
    }
}
