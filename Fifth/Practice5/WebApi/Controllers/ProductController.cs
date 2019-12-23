using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repository.Interfaces;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IEnumerable<ProductDTO> GetAll()
        {
            return productRepository.Get().Select(product=> mapper.Map<ProductDTO>(product));
        }

    }
}