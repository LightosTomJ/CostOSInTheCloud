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
    public class ParamitemController : ControllerBase
    {
        private readonly localContext _context;

        public ParamitemController(localContext context)
        {
            _context = context;
        }

        // GET: api/Paramitem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paramitem>>> GetParamitem()
        {
            return await _context.Paramitem.ToListAsync();
        }

        // GET: api/Paramitem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paramitem>> GetParamitem(long id)
        {
            var paramitem = await _context.Paramitem.FindAsync(id);

            if (paramitem == null)
            {
                return NotFound();
            }

            return paramitem;
        }

        // PUT: api/Paramitem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParamitem(long id, Paramitem paramitem)
        {
            if (id != paramitem.Paramitemid)
            {
                return BadRequest();
            }

            _context.Entry(paramitem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamitemExists(id))
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

        // POST: api/Paramitem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Paramitem>> PostParamitem(Paramitem paramitem)
        {
            _context.Paramitem.Add(paramitem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParamitem", new { id = paramitem.Paramitemid }, paramitem);
        }

        // DELETE: api/Paramitem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Paramitem>> DeleteParamitem(long id)
        {
            var paramitem = await _context.Paramitem.FindAsync(id);
            if (paramitem == null)
            {
                return NotFound();
            }

            _context.Paramitem.Remove(paramitem);
            await _context.SaveChangesAsync();

            return paramitem;
        }

        private bool ParamitemExists(long id)
        {
            return _context.Paramitem.Any(e => e.Paramitemid == id);
        }
    }
}
