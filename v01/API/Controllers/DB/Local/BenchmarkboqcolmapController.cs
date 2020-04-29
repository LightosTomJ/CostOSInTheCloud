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
    public class BenchmarkboqcolmapController : ControllerBase
    {
        private readonly LocalContext _context;

        public BenchmarkboqcolmapController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Benchmarkboqcolmap
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BenchmarkBOQColMap>>> GetBenchmarkboqcolmap()
        {
            return await _context.BenchmarkBOQColMap.ToListAsync();
        }

        // GET: api/Benchmarkboqcolmap/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BenchmarkBOQColMap>> GetBenchmarkboqcolmap(long id)
        {
            var benchmarkboqcolmap = await _context.BenchmarkBOQColMap.FindAsync(id);

            if (benchmarkboqcolmap == null)
            {
                return NotFound();
            }

            return benchmarkboqcolmap;
        }

        // PUT: api/Benchmarkboqcolmap/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBenchmarkboqcolmap(long id, BenchmarkBOQColMap benchmarkboqcolmap)
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BenchmarkBOQColMap>> PostBenchmarkboqcolmap(BenchmarkBOQColMap benchmarkboqcolmap)
        {
            _context.BenchmarkBOQColMap.Add(benchmarkboqcolmap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBenchmarkboqcolmap", new { id = benchmarkboqcolmap.Id }, benchmarkboqcolmap);
        }

        // DELETE: api/Benchmarkboqcolmap/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BenchmarkBOQColMap>> DeleteBenchmarkboqcolmap(long id)
        {
            var benchmarkboqcolmap = await _context.BenchmarkBOQColMap.FindAsync(id);
            if (benchmarkboqcolmap == null)
            {
                return NotFound();
            }

            _context.BenchmarkBOQColMap.Remove(benchmarkboqcolmap);
            await _context.SaveChangesAsync();

            return benchmarkboqcolmap;
        }

        private bool BenchmarkboqcolmapExists(long id)
        {
            return _context.BenchmarkBOQColMap.Any(e => e.Id == id);
        }
    }
}
