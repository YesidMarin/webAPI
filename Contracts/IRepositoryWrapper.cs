﻿using System;
namespace Contracts
{
    public interface IRepositoryWrapper
    {
        ICityRepository City { get; }
    }
}
