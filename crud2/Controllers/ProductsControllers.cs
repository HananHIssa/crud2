using System.Net.Http.Headers;
using crud2.Data;
using crud2.Dtos;
using crud2.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProductsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost("AddNewProduct")]
        public async Task<IActionResult> Create(CreateProduct_dtos product)
        {
            var res = product.Adapt<Product>();
            await context.Products.AddAsync(res); 
            await context.SaveChangesAsync();
            return Ok("Done");
        }

        [HttpGet("AllProducts")]
        public async Task<IActionResult> GetAll()
        {
            var res = await context.Products.ToListAsync();
            var result = res.Adapt<List<AllProduct>>();
            return Ok(result);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await context.Products.FindAsync(id);
            if (res == null) return NotFound("Product not found"); 
            context.Products.Remove(res);
            await context.SaveChangesAsync();
            return Ok("Deleted successfully");
        }
        [HttpPut("EditProduct/{id}")]
        public async Task<IActionResult> Edit(int id, UpdateProduct_dtoscs updatedProduct)
        {
            var prod = await context.Products.FindAsync(id);
            if (prod == null)
            return NotFound("Product not found");
            updatedProduct.Adapt(prod);
            context.Products.Update(prod);
            await context.SaveChangesAsync();
            return Ok("Updated successfully");
        }
    }
}
