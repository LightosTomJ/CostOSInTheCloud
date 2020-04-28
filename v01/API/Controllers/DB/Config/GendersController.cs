using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Config;

namespace API.Controllers.DB.Config
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly ConfigContext _context;

        public GendersController(ConfigContext context)
        {
            _context = context;
        }

        // GET: api/Genders
        [HttpGet]
        public async Task<List<Genders>> GetGenders()
        {
            return await _context.Genders.ToListAsync();
        }

        // GET: api/Genders/5
        [HttpGet("{id}")]
        public async Task<Genders> GetGender(byte id)
        {
            var genders = await _context.Genders.FindAsync(id);

            return genders;
        }

        // PUT: api/Genders/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenders(byte id, Genders genders)
        {
            if (id != genders.GenderId)
            {
                return BadRequest();
            }

            _context.Entry(genders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GendersExists(id))
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

        // POST: api/Genders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Genders>> PostGenders(Genders genders)
        {
            _context.Genders.Add(genders);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GendersExists(genders.GenderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGenders", new { id = genders.GenderId }, genders);
        }

        // DELETE: api/Genders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Genders>> DeleteGenders(byte id)
        {
            var genders = await _context.Genders.FindAsync(id);
            if (genders == null)
            {
                return NotFound();
            }

            _context.Genders.Remove(genders);
            await _context.SaveChangesAsync();

            return genders;
        }

        private bool GendersExists(byte id)
        {
            return _context.Genders.Any(e => e.GenderId == id);
        }
    }
}
