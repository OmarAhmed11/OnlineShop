using AutoMapper;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Entities;
using OnlineShop.Dtos;
using OnlineShop.Errors;
using OnlineShop.Helpers;
using OnlineShop.Infrastructure.Data;

namespace OnlineShop.Controllers
{

    public class ProductsController : BaseApiController
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
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecificationsParameters PSP)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(PSP);
            var CountSpec = new ProductWithFiltersForCountSpecification(PSP);
            var totalItems =  await _repo.CountAsync(CountSpec);
            var Products = await _repo.ListAllAsync(spec);
            var Data = _mapper.Map<IReadOnlyList<Product>,
                IReadOnlyList<ProductToReturnDto>>(Products);
            return Ok( new Pagination<ProductToReturnDto> (
                PSP.PageIndex, PSP.PageSize, totalItems, Data
                ));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var Product = await _repo.GetEntityWithSpec(spec);
            if (Product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return _mapper.Map<Product, ProductToReturnDto>(Product);

        }
    }
}
