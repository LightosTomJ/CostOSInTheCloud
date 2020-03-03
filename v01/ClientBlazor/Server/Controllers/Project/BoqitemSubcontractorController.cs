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
    public class BoqitemSubcontractorController : ControllerBase
    {
        private readonly projectContext _context;

        public BoqitemSubcontractorController(projectContext context)
        {
            _context = context;
        }

        // GET: api/BoqitemSubcontractor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoqitemSubcontractor>>> GetBoqitemSubcontractor()
        {
            return await _context.BoqitemSubcontractor.ToListAsync();
        }

        // GET: api/BoqitemSubcontractor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoqitemSubcontractor>> GetBoqitemSubcontractor(long id)
        {
            var boqitemSubcontractor = await _context.BoqitemSubcontractor.FindAsync(id);

            if (boqitemSubcontractor == null)
            {
                return NotFound();
            }

            return boqitemSubcontractor;
        }

        // PUT: api/BoqitemSubcontractor/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoqitemSubcontractor(long id, BoqitemSubcontractor boqitemSubcontractor)
        {
            if (id != boqitemSubcontractor.Boqitemsubcontractorid)
            {
                return BadRequest();
            }

            _context.Entry(boqitemSubcontractor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoqitemSubcontractorExists(id))
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

        // POST: api/BoqitemSubcontractor
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BoqitemSubcontractor>> PostBoqitemSubcontractor(BoqitemSubcontractor boqitemSubcontractor)
        {
            _context.BoqitemSubcontractor.Add(boqitemSubcontractor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoqitemSubcontractor", new { id = boqitemSubcontractor.Boqitemsubcontractorid }, boqitemSubcontractor);
        }

        // DELETE: api/BoqitemSubcontractor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BoqitemSubcontractor>> DeleteBoqitemSubcontractor(long id)
        {
            var boqitemSubcontractor = await _context.BoqitemSubcontractor.FindAsync(id);
            if (boqitemSubcontractor == null)
            {
                return NotFound();
            }

            _context.BoqitemSubcontractor.Remove(boqitemSubcontractor);
            await _context.SaveChangesAsync();

            return boqitemSubcontractor;
        }

        private bool BoqitemSubcontractorExists(long id)
        {
            return _context.BoqitemSubcontractor.Any(e => e.Boqitemsubcontractorid == id);
        }
    }
}
