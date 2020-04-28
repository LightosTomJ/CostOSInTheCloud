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
    public class FiltroController : ControllerBase
    {
        private readonly LocalContext _context;

        public FiltroController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Filtro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filtro>>> GetFiltro()
        {
            return await _context.Filtro.ToListAsync();
        }

        // GET: api/Filtro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Filtro>> GetFiltro(long id)
        {
            var filtro = await _context.Filtro.FindAsync(id);

            if (filtro == null)
            {
                return NotFound();
            }

            return filtro;
        }

        // PUT: api/Filtro/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFiltro(long id, Filtro filtro)
        {
            if (id != filtro.Filtroid)
            {
                return BadRequest();
            }

            _context.Entry(filtro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FiltroExists(id))
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

        // POST: api/Filtro
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Filtro>> PostFiltro(Filtro filtro)
        {
            _context.Filtro.Add(filtro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFiltro", new { id = filtro.Filtroid }, filtro);
        }

        // DELETE: api/Filtro/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Filtro>> DeleteFiltro(long id)
        {
            var filtro = await _context.Filtro.FindAsync(id);
            if (filtro == null)
            {
                return NotFound();
            }

            _context.Filtro.Remove(filtro);
            await _context.SaveChangesAsync();

            return filtro;
        }

        private bool FiltroExists(long id)
        {
            return _context.Filtro.Any(e => e.Filtroid == id);
        }
    }
}
