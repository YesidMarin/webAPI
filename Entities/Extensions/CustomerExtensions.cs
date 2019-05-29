using System;
using Entities.Models;

namespace Entities.Extensions
{
    public static class CustomerExtensions
    {
        public static void Map(this Customer dbCustomer, Customer customer)
        {
            dbCustomer.GuidCity = customer.GuidCity.IsEmptyGuid() ? dbCustomer.GuidCity : customer.GuidCity;
            dbCustomer.Name = customer.Name.IsNullOrEmpty() ? dbCustomer.Name : customer.Name.CapitalizeLetters().Trim();

            dbCustomer.LastName = customer.LastName.IsNullOrEmpty() ? dbCustomer.LastName : customer.LastName.CapitalizeLetters().Trim();
            dbCustomer.Identification = customer.Identification.IsNullOrEmpty() ? dbCustomer.Identification : customer.Identification;
            dbCustomer.Telephone = customer.Telephone.IsNullOrEmpty() ? dbCustomer.Telephone : customer.Telephone;
            dbCustomer.Address = customer.Address.IsNullOrEmpty() ? dbCustomer.Address : customer.Address.Trim();
            dbCustomer.Email = customer.Email.IsNullOrEmpty() ? dbCustomer.Email : customer.Email.Trim();
        }

    }
}
