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
    public class ParaminputController : ControllerBase
    {
        private readonly LocalContext _context;

        public ParaminputController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Paraminput
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParamInput>>> GetParaminput()
        {
            return await _context.ParamInput.ToListAsync();
        }

        // GET: api/Paraminput/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParamInput>> GetParaminput(long id)
        {
            var paraminput = await _context.ParamInput.FindAsync(id);

            if (paraminput == null)
            {
                return NotFound();
            }

            return paraminput;
        }

        // PUT: api/Paraminput/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParaminput(long id, ParamInput paraminput)
        {
            if (id != paraminput.Paraminputid)
            {
                return BadRequest();
            }

            _context.Entry(paraminput).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParaminputExists(id))
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

        // POST: api/Paraminput
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ParamInput>> PostParaminput(ParamInput paraminput)
        {
            _context.ParamInput.Add(paraminput);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParaminput", new { id = paraminput.Paraminputid }, paraminput);
        }

        // DELETE: api/Paraminput/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ParamInput>> DeleteParaminput(long id)
        {
            var paraminput = await _context.ParamInput.FindAsync(id);
            if (paraminput == null)
            {
                return NotFound();
            }

            _context.ParamInput.Remove(paraminput);
            await _context.SaveChangesAsync();

            return paraminput;
        }

        private bool ParaminputExists(long id)
        {
            return _context.ParamInput.Any(e => e.Paraminputid == id);
        }
    }
}
