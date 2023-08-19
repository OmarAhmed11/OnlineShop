﻿using AutoMapper;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Entities;
using OnlineShop.Dtos;
using OnlineShop.Infrastructure.Data;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _repo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> Repo,
            IMapper mapper)
        {
            _repo = Repo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var Products = await _repo.ListAllAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>,
                IReadOnlyList<ProductToReturnDto>>(Products));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var Product = await _repo.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductToReturnDto>(Product);
        }
    }
}
