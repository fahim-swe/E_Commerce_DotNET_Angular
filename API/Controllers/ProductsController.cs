using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Base.Specifications;
using API.Dtos;
using API.Entities;
using API.Helper;
using API.Interface;
using E_Commerce_App_Practices_1.Data.Base;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _productRepo;
        public ProductsController( IProductRepository productRepo
            )
        {
            _productRepo = productRepo;
        }


        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParams param)
        {
           
            var products = await _productRepo.GetProductsAsync(param);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productRepo.GetProductByIdAsync(id);
            return Ok(product);
        }

         [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var products = await _productRepo.GetProductBrandsAsync();
            return Ok(products);
        }

         [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var products = await _productRepo.GetProductTypesAsync();
            return Ok(products);
        }
    }
}