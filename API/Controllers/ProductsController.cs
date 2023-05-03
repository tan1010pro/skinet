
using Core.Entity;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
      [Route("api/[controller]")]
    public class ProductsController :ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
           _repository= repository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Product>>> GetProducts (){
          var products= await _repository.GetProductAsync();
          return Ok(products);
        }
           [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProductById ( int id ){
          var result= await _repository.GetProductByIdAsync(id);
            return Ok(result);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProdcutBrands()
        {
             return Ok (await _repository.GetProductBrandAsync());
        }

         [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType()
        {
             return Ok (await _repository.GetProductTypeAsync());
        }
    }
}