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
    public class ParamoutputController : ControllerBase
    {
        private readonly localContext _context;

        public ParamoutputController(localContext context)
        {
            _context = context;
        }

        // GET: api/Paramoutput
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paramoutput>>> GetParamoutput()
        {
            return await _context.Paramoutput.ToListAsync();
        }

        // GET: api/Paramoutput/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paramoutput>> GetParamoutput(long id)
        {
            var paramoutput = await _context.Paramoutput.FindAsync(id);

            if (paramoutput == null)
            {
                return NotFound();
            }

            return paramoutput;
        }

        // PUT: api/Paramoutput/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParamoutput(long id, Paramoutput paramoutput)
        {
            if (id != paramoutput.Paramoutputid)
            {
                return BadRequest();
            }

            _context.Entry(paramoutput).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamoutputExists(id))
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

        // POST: api/Paramoutput
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Paramoutput>> PostParamoutput(Paramoutput paramoutput)
        {
            _context.Paramoutput.Add(paramoutput);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParamoutput", new { id = paramoutput.Paramoutputid }, paramoutput);
        }

        // DELETE: api/Paramoutput/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Paramoutput>> DeleteParamoutput(long id)
        {
            var paramoutput = await _context.Paramoutput.FindAsync(id);
            if (paramoutput == null)
            {
                return NotFound();
            }

            _context.Paramoutput.Remove(paramoutput);
            await _context.SaveChangesAsync();

            return paramoutput;
        }

        private bool ParamoutputExists(long id)
        {
            return _context.Paramoutput.Any(e => e.Paramoutputid == id);
        }
    }
}
