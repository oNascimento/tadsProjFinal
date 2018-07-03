using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projFinal.Models;

namespace projFinal.Controllers
{
    [Produces("application/json")]
    [Route("api/Borrows")]
    public class BorrowsController : Controller
    {
        private readonly projFinalContext _context;

        public BorrowsController(projFinalContext context)
        {
            _context = context;
        }

        // GET: api/Borrows
        [HttpGet]
        public IEnumerable<Borrow> GetBorrow()
        {
            return _context.Borrow;
        }

        // GET: api/Borrows/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBorrow([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var borrow = await _context.Borrow.SingleOrDefaultAsync(m => m.id == id);

            if (borrow == null)
            {
                return NotFound();
            }

            return Ok(borrow);
        }

        // PUT: api/Borrows/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBorrow([FromRoute] int id, [FromBody] Borrow borrow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != borrow.id)
            {
                return BadRequest();
            }

            _context.Entry(borrow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowExists(id))
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

        // POST: api/Borrows
        [HttpPost]
        public async Task<IActionResult> PostBorrow([FromBody] Borrow borrow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Borrow.Add(borrow);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBorrow", new { id = borrow.id }, borrow);
        }

        // DELETE: api/Borrows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrow([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var borrow = await _context.Borrow.SingleOrDefaultAsync(m => m.id == id);
            if (borrow == null)
            {
                return NotFound();
            }

            _context.Borrow.Remove(borrow);
            await _context.SaveChangesAsync();

            return Ok(borrow);
        }

        private bool BorrowExists(int id)
        {
            return _context.Borrow.Any(e => e.id == id);
        }
    }
}