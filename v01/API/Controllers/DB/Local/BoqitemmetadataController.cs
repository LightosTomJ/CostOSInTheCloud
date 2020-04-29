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
    public class BoqitemmetadataController : ControllerBase
    {
        private readonly LocalContext _context;

        public BoqitemmetadataController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Boqitemmetadata
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BOQItemMetadata>>> GetBoqitemmetadata()
        {
            return await _context.BOQItemMetadata.ToListAsync();
        }

        // GET: api/Boqitemmetadata/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BOQItemMetadata>> GetBoqitemmetadata(long id)
        {
            var boqitemmetadata = await _context.BOQItemMetadata.FindAsync(id);

            if (boqitemmetadata == null)
            {
                return NotFound();
            }

            return boqitemmetadata;
        }

        // PUT: api/Boqitemmetadata/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoqitemmetadata(long id, BOQItemMetadata boqitemmetadata)
        {
            if (id != boqitemmetadata.Id)
            {
                return BadRequest();
            }

            _context.Entry(boqitemmetadata).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoqitemmetadataExists(id))
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

        // POST: api/Boqitemmetadata
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BOQItemMetadata>> PostBoqitemmetadata(BOQItemMetadata boqitemmetadata)
        {
            _context.BOQItemMetadata.Add(boqitemmetadata);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoqitemmetadata", new { id = boqitemmetadata.Id }, boqitemmetadata);
        }

        // DELETE: api/Boqitemmetadata/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BOQItemMetadata>> DeleteBoqitemmetadata(long id)
        {
            var boqitemmetadata = await _context.BOQItemMetadata.FindAsync(id);
            if (boqitemmetadata == null)
            {
                return NotFound();
            }

            _context.BOQItemMetadata.Remove(boqitemmetadata);
            await _context.SaveChangesAsync();

            return boqitemmetadata;
        }

        private bool BoqitemmetadataExists(long id)
        {
            return _context.BOQItemMetadata.Any(e => e.Id == id);
        }
    }
}
