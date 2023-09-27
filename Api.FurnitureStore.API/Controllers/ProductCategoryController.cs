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


    }
}
