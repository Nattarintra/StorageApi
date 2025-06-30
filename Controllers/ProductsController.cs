using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorageApi.Controllers.Services;
using StorageApi.Data;
using StorageApi.DTOs;
using StorageApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static StorageApi.DTOs.ProductDtoSearch;

namespace StorageApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StorageApiContext _context;
        private readonly ProductService _productService;
        private readonly ProductStatsService _productStatsService;

        public ProductsController(StorageApiContext context, ProductService productService, ProductStatsService productStatsService)
        {
            _context = context;
            _productService = productService;
            _productStatsService = productStatsService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        // GET: api/Products/1/calc 
        [HttpGet("{id}/calc")]

        public async Task<ActionResult<ProductDtoCalc>> GetCalculatedProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product == null) return NotFound();
            
            var result = _productService.GetCalculatedProduct(product);

            return Ok(result);

        }

        [HttpGet("stats")]
        public async Task<ActionResult<ProductDtoStats>> GetStatsProduct()
            
        {
            var products = await _context.Products.ToListAsync();
            var productStats = _productStatsService.GetProductStats(products);
            return Ok(productStats);
        }

        [HttpGet("search")]
      
        public async Task<ActionResult<IEnumerable<ProductDtoSearch>>> SearchProduct(string? category, string? name)
        {
            var query = _context.Products.AsQueryable();
            
            
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category.ToLower().Contains(category.ToLower()));
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.ToLower().Contains(name.ToLower()));
            }
            
            var products = await query
                .Select(p => new SearchProduct(p.Category, p.Name))              
                .ToListAsync();
           
            if (products.Count == 0) { return NotFound("No products found"); }

            return Ok(products);
        }


        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
