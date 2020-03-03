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
    public class BoqitemConditionController : ControllerBase
    {
        private readonly projectContext _context;

        public BoqitemConditionController(projectContext context)
        {
            _context = context;
        }

        // GET: api/BoqitemCondition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoqitemCondition>>> GetBoqitemCondition()
        {
            return await _context.BoqitemCondition.ToListAsync();
        }

        // GET: api/BoqitemCondition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoqitemCondition>> GetBoqitemCondition(long id)
        {
            var boqitemCondition = await _context.BoqitemCondition.FindAsync(id);

            if (boqitemCondition == null)
            {
                return NotFound();
            }

            return boqitemCondition;
        }

        // PUT: api/BoqitemCondition/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoqitemCondition(long id, BoqitemCondition boqitemCondition)
        {
            if (id != boqitemCondition.Boqitemconditionid)
            {
                return BadRequest();
            }

            _context.Entry(boqitemCondition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoqitemConditionExists(id))
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

        // POST: api/BoqitemCondition
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BoqitemCondition>> PostBoqitemCondition(BoqitemCondition boqitemCondition)
        {
            _context.BoqitemCondition.Add(boqitemCondition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoqitemCondition", new { id = boqitemCondition.Boqitemconditionid }, boqitemCondition);
        }

        // DELETE: api/BoqitemCondition/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BoqitemCondition>> DeleteBoqitemCondition(long id)
        {
            var boqitemCondition = await _context.BoqitemCondition.FindAsync(id);
            if (boqitemCondition == null)
            {
                return NotFound();
            }

            _context.BoqitemCondition.Remove(boqitemCondition);
            await _context.SaveChangesAsync();

            return boqitemCondition;
        }

        private bool BoqitemConditionExists(long id)
        {
            return _context.BoqitemCondition.Any(e => e.Boqitemconditionid == id);
        }
    }
}
