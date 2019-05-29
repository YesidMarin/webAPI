using System;
using Contracts;
using Entities;
using Entities.Extensions;
using Microsoft.Extensions.Options;

namespace Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private ICityRepository _cityRepository;
        private ICustomerRepository _customerRepository;
        private IUserService _userService;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ICityRepository City
        {
            get
            {
                if (_cityRepository == null)
                {
                    _cityRepository = new CityRepository(_repositoryContext);
                }
                return _cityRepository;
            }
        }

        public ICustomerRepository Customer
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(_repositoryContext);
                }
                return _customerRepository;
            }
        }
    }
}
