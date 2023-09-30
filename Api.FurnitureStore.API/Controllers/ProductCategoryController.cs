using Api.FurnitureStore.Data;
using Api.FurnitureStore.Share;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.FurnitureStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly APIFunitureStoreContext _context;


        public ProductCategoryController(APIFunitureStoreContext context)
        {
             _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<ProductCategory>> Get()
        {
            return await _context.ProductCategories.ToListAsync();
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var category = await _context.ProductCategories.FirstOrDefaultAsync(p =>p.Id == id );


            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(ProductCategory productCategory)
        {
            await _context.ProductCategories.AddAsync(productCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Post", productCategory.Id, productCategory);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductCategory productCategory)
        {
            _context.ProductCategories.Update(productCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(ProductCategory productCategory)
        {
            if (productCategory == null)
            {
                return NotFound();
            }
            else
            {
                _context.ProductCategories.Remove(productCategory);
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }

    }
}
