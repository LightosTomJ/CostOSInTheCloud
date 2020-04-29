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
    public class ParamreturnController : ControllerBase
    {
        private readonly LocalContext _context;

        public ParamreturnController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Paramreturn
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParamReturn>>> GetParamreturn()
        {
            return await _context.ParamReturn.ToListAsync();
        }

        // GET: api/Paramreturn/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParamReturn>> GetParamreturn(long id)
        {
            var paramreturn = await _context.ParamReturn.FindAsync(id);

            if (paramreturn == null)
            {
                return NotFound();
            }

            return paramreturn;
        }

        // PUT: api/Paramreturn/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParamreturn(long id, ParamReturn paramreturn)
        {
            if (id != paramreturn.Paramreturnid)
            {
                return BadRequest();
            }

            _context.Entry(paramreturn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamreturnExists(id))
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

        // POST: api/Paramreturn
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ParamReturn>> PostParamreturn(ParamReturn paramreturn)
        {
            _context.ParamReturn.Add(paramreturn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParamreturn", new { id = paramreturn.Paramreturnid }, paramreturn);
        }

        // DELETE: api/Paramreturn/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ParamReturn>> DeleteParamreturn(long id)
        {
            var paramreturn = await _context.ParamReturn.FindAsync(id);
            if (paramreturn == null)
            {
                return NotFound();
            }

            _context.ParamReturn.Remove(paramreturn);
            await _context.SaveChangesAsync();

            return paramreturn;
        }

        private bool ParamreturnExists(long id)
        {
            return _context.ParamReturn.Any(e => e.Paramreturnid == id);
        }
    }
}
