﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository.Interfaces
{
    public interface IProductRepository
    {
        List<Product> Get();
    }
}
