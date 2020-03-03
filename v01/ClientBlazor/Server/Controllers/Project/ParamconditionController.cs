using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Project;

namespace ClientBlazor.Server.Controllers.Project
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParamconditionController : ControllerBase
    {
        private readonly projectContext _context;

        public ParamconditionController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Paramcondition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paramcondition>>> GetParamcondition()
        {
            return await _context.Paramcondition.ToListAsync();
        }

        // GET: api/Paramcondition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paramcondition>> GetParamcondition(long id)
        {
            var paramcondition = await _context.Paramcondition.FindAsync(id);

            if (paramcondition == null)
            {
                return NotFound();
            }

            return paramcondition;
        }

        // PUT: api/Paramcondition/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParamcondition(long id, Paramcondition paramcondition)
        {
            if (id != paramcondition.Conditionid)
            {
                return BadRequest();
            }

            _context.Entry(paramcondition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamconditionExists(id))
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

        // POST: api/Paramcondition
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Paramcondition>> PostParamcondition(Paramcondition paramcondition)
        {
            _context.Paramcondition.Add(paramcondition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParamcondition", new { id = paramcondition.Conditionid }, paramcondition);
        }

        // DELETE: api/Paramcondition/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Paramcondition>> DeleteParamcondition(long id)
        {
            var paramcondition = await _context.Paramcondition.FindAsync(id);
            if (paramcondition == null)
            {
                return NotFound();
            }

            _context.Paramcondition.Remove(paramcondition);
            await _context.SaveChangesAsync();

            return paramcondition;
        }

        private bool ParamconditionExists(long id)
        {
            return _context.Paramcondition.Any(e => e.Conditionid == id);
        }
    }
}
