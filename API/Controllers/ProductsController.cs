
using Core.Entity;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
      [Route("api/[controller]")]
    public class ProductsController :ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Product>>> GetProducts (){
          var products= await _context.Products.ToListAsync();
          return Ok(products);
        }
           [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProductById ( int id ){
            return Ok(await _context.Products.FindAsync(id));
        }
    }
}