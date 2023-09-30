using Api.FurnitureStore.Data;
using Api.FurnitureStore.Share;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.FurnitureStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly APIFunitureStoreContext _context;

        public ProductController(APIFunitureStoreContext context)
        {
                _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
           return await _context.Products.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return BadRequest();
            }

            return Ok(product); 
        }


        [HttpGet("GetByCategory/{productCategoryId}")]
        public async Task<IEnumerable<Product>> GetByCategory(int productCategoryId)
        {
            return await _context.Products.Where(p => p.ProductCategoryId == productCategoryId).ToListAsync();
        }





        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            if (product == null)
            {
                return NotFound();
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Post",product.Id,product);
        }


        [HttpPut]
        public async Task<IActionResult> Put(Product product)
        {
            if(product == null)
                NotFound();

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Product product)
        {
            if( product == null)
                NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
