﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repository.Interfaces
{
    public interface IRepositoryFactory
    {
        IProductRepository CreateProductRepository();
        IProviderRepository CreateProviderRepository();
        IProductCategoryRepository CreateProductCategoryRepository();
    }
}
