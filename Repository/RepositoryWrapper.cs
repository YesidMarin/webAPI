using System;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private ICityRepository _cityRepository;

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
    }
}
