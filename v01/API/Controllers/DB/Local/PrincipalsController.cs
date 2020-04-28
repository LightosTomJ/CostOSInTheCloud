using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;

namespace API.Controllers.DB.Local
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrincipalsController : ControllerBase
    {
        private readonly LocalContext _context;

        public PrincipalsController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Principals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Principals>>> GetPrincipals()
        {
            return await _context.Principals.ToListAsync();
        }

        // GET: api/Principals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Principals>> GetPrincipals(string id)
        {
            var principals = await _context.Principals.FindAsync(id);

            if (principals == null)
            {
                return NotFound();
            }

            return principals;
        }

        // PUT: api/Principals/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrincipals(string id, Principals principals)
        {
            if (id != principals.Principalid)
            {
                return BadRequest();
            }

            _context.Entry(principals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrincipalsExists(id))
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

        // POST: api/Principals
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Principals>> PostPrincipals(Principals principals)
        {
            _context.Principals.Add(principals);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PrincipalsExists(principals.Principalid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPrincipals", new { id = principals.Principalid }, principals);
        }

        // DELETE: api/Principals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Principals>> DeletePrincipals(string id)
        {
            var principals = await _context.Principals.FindAsync(id);
            if (principals == null)
            {
                return NotFound();
            }

            _context.Principals.Remove(principals);
            await _context.SaveChangesAsync();

            return principals;
        }

        private bool PrincipalsExists(string id)
        {
            return _context.Principals.Any(e => e.Principalid == id);
        }
    }
}
