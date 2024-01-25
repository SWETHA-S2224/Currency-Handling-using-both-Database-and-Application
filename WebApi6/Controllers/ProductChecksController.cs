using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi6.Models;

namespace WebApi6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductChecksController : ControllerBase
    {
        private readonly PropContext _context;

        public ProductChecksController(PropContext context)
        {
            _context = context;
        }

        // GET: api/ProductChecks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCheck>>> GetProductcheck()
        {
            return await _context.Productcheck.ToListAsync();
        }

        // GET: api/ProductChecks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCheck>> GetProductCheck(int id)
        {
            var productCheck = await _context.Productcheck.FindAsync(id);

            if (productCheck == null)
            {
                return NotFound();
            }

            return productCheck;
        }

        // PUT: api/ProductChecks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCheck(int id, ProductCheck productCheck)
        {
            if (id != productCheck.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(productCheck).State = EntityState.Modified;

            try
            {
                productCheck.Version=Guid.NewGuid();
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCheckExists(id))
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

        // POST: api/ProductChecks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductCheck>> PostProductCheck(ProductCheck productCheck)
        {
            productCheck.Version=Guid.NewGuid();
            _context.Productcheck.Add(productCheck);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductCheck", new { id = productCheck.ProductId }, productCheck);
        }

        // DELETE: api/ProductChecks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCheck(int id)
        {
            var productCheck = await _context.Productcheck.FindAsync(id);
            if (productCheck == null)
            {
                return NotFound();
            }

            _context.Productcheck.Remove(productCheck);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductCheckExists(int id)
        {
            return _context.Productcheck.Any(e => e.ProductId == id);
        }
    }
}
