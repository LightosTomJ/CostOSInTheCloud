using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Results;

namespace ClientBlazor.Server.Controllers.Results
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParamItemPartialController : ControllerBase
    {
        private readonly resultsContext _context;

        public ParamItemPartialController(resultsContext context)
        {
            _context = context;
        }

        // GET: api/ParamItemPartial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParamItemPartial>>> GetParamItemPartial()
        {
            return await _context.ParamItemPartial.ToListAsync();
        }

        // GET: api/ParamItemPartial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParamItemPartial>> GetParamItemPartial(int id)
        {
            var paramItemPartial = await _context.ParamItemPartial.FindAsync(id);

            if (paramItemPartial == null)
            {
                return NotFound();
            }

            return paramItemPartial;
        }

        // PUT: api/ParamItemPartial/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParamItemPartial(int id, ParamItemPartial paramItemPartial)
        {
            if (id != paramItemPartial.Id)
            {
                return BadRequest();
            }

            _context.Entry(paramItemPartial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamItemPartialExists(id))
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

        // POST: api/ParamItemPartial
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ParamItemPartial>> PostParamItemPartial(ParamItemPartial paramItemPartial)
        {
            _context.ParamItemPartial.Add(paramItemPartial);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ParamItemPartialExists(paramItemPartial.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetParamItemPartial", new { id = paramItemPartial.Id }, paramItemPartial);
        }

        // DELETE: api/ParamItemPartial/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ParamItemPartial>> DeleteParamItemPartial(int id)
        {
            var paramItemPartial = await _context.ParamItemPartial.FindAsync(id);
            if (paramItemPartial == null)
            {
                return NotFound();
            }

            _context.ParamItemPartial.Remove(paramItemPartial);
            await _context.SaveChangesAsync();

            return paramItemPartial;
        }

        private bool ParamItemPartialExists(int id)
        {
            return _context.ParamItemPartial.Any(e => e.Id == id);
        }
    }
}
