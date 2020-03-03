using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;

namespace ClientBlazor.Server.Controllers.Local
{
    [Route("api/[controller]")]
    [ApiController]
    public class FnctonArgumentController : ControllerBase
    {
        private readonly localContext _context;

        public FnctonArgumentController(localContext context)
        {
            _context = context;
        }

        // GET: api/FnctonArgument
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FnctonArgument>>> GetFnctonArgument()
        {
            return await _context.FnctonArgument.ToListAsync();
        }

        // GET: api/FnctonArgument/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FnctonArgument>> GetFnctonArgument(long id)
        {
            var fnctonArgument = await _context.FnctonArgument.FindAsync(id);

            if (fnctonArgument == null)
            {
                return NotFound();
            }

            return fnctonArgument;
        }

        // PUT: api/FnctonArgument/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFnctonArgument(long id, FnctonArgument fnctonArgument)
        {
            if (id != fnctonArgument.Fargid)
            {
                return BadRequest();
            }

            _context.Entry(fnctonArgument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FnctonArgumentExists(id))
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

        // POST: api/FnctonArgument
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<FnctonArgument>> PostFnctonArgument(FnctonArgument fnctonArgument)
        {
            _context.FnctonArgument.Add(fnctonArgument);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFnctonArgument", new { id = fnctonArgument.Fargid }, fnctonArgument);
        }

        // DELETE: api/FnctonArgument/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FnctonArgument>> DeleteFnctonArgument(long id)
        {
            var fnctonArgument = await _context.FnctonArgument.FindAsync(id);
            if (fnctonArgument == null)
            {
                return NotFound();
            }

            _context.FnctonArgument.Remove(fnctonArgument);
            await _context.SaveChangesAsync();

            return fnctonArgument;
        }

        private bool FnctonArgumentExists(long id)
        {
            return _context.FnctonArgument.Any(e => e.Fargid == id);
        }
    }
}
