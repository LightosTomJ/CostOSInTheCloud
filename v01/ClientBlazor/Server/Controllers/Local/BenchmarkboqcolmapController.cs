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
    public class BenchmarkboqcolmapController : ControllerBase
    {
        private readonly localContext _context;

        public BenchmarkboqcolmapController(localContext context)
        {
            _context = context;
        }

        // GET: api/Benchmarkboqcolmap
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Benchmarkboqcolmap>>> GetBenchmarkboqcolmap()
        {
            return await _context.Benchmarkboqcolmap.ToListAsync();
        }

        // GET: api/Benchmarkboqcolmap/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Benchmarkboqcolmap>> GetBenchmarkboqcolmap(long id)
        {
            var benchmarkboqcolmap = await _context.Benchmarkboqcolmap.FindAsync(id);

            if (benchmarkboqcolmap == null)
            {
                return NotFound();
            }

            return benchmarkboqcolmap;
        }

        // PUT: api/Benchmarkboqcolmap/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBenchmarkboqcolmap(long id, Benchmarkboqcolmap benchmarkboqcolmap)
        {
            if (id != benchmarkboqcolmap.Id)
            {
                return BadRequest();
            }

            _context.Entry(benchmarkboqcolmap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BenchmarkboqcolmapExists(id))
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

        // POST: api/Benchmarkboqcolmap
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Benchmarkboqcolmap>> PostBenchmarkboqcolmap(Benchmarkboqcolmap benchmarkboqcolmap)
        {
            _context.Benchmarkboqcolmap.Add(benchmarkboqcolmap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBenchmarkboqcolmap", new { id = benchmarkboqcolmap.Id }, benchmarkboqcolmap);
        }

        // DELETE: api/Benchmarkboqcolmap/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Benchmarkboqcolmap>> DeleteBenchmarkboqcolmap(long id)
        {
            var benchmarkboqcolmap = await _context.Benchmarkboqcolmap.FindAsync(id);
            if (benchmarkboqcolmap == null)
            {
                return NotFound();
            }

            _context.Benchmarkboqcolmap.Remove(benchmarkboqcolmap);
            await _context.SaveChangesAsync();

            return benchmarkboqcolmap;
        }

        private bool BenchmarkboqcolmapExists(long id)
        {
            return _context.Benchmarkboqcolmap.Any(e => e.Id == id);
        }
    }
}
