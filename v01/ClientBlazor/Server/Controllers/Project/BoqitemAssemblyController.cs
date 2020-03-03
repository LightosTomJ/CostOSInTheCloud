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
    public class BoqitemAssemblyController : ControllerBase
    {
        private readonly projectContext _context;

        public BoqitemAssemblyController(projectContext context)
        {
            _context = context;
        }

        // GET: api/BoqitemAssembly
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoqitemAssembly>>> GetBoqitemAssembly()
        {
            return await _context.BoqitemAssembly.ToListAsync();
        }

        // GET: api/BoqitemAssembly/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoqitemAssembly>> GetBoqitemAssembly(long id)
        {
            var boqitemAssembly = await _context.BoqitemAssembly.FindAsync(id);

            if (boqitemAssembly == null)
            {
                return NotFound();
            }

            return boqitemAssembly;
        }

        // PUT: api/BoqitemAssembly/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoqitemAssembly(long id, BoqitemAssembly boqitemAssembly)
        {
            if (id != boqitemAssembly.Boqitemassemblyid)
            {
                return BadRequest();
            }

            _context.Entry(boqitemAssembly).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoqitemAssemblyExists(id))
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

        // POST: api/BoqitemAssembly
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BoqitemAssembly>> PostBoqitemAssembly(BoqitemAssembly boqitemAssembly)
        {
            _context.BoqitemAssembly.Add(boqitemAssembly);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoqitemAssembly", new { id = boqitemAssembly.Boqitemassemblyid }, boqitemAssembly);
        }

        // DELETE: api/BoqitemAssembly/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BoqitemAssembly>> DeleteBoqitemAssembly(long id)
        {
            var boqitemAssembly = await _context.BoqitemAssembly.FindAsync(id);
            if (boqitemAssembly == null)
            {
                return NotFound();
            }

            _context.BoqitemAssembly.Remove(boqitemAssembly);
            await _context.SaveChangesAsync();

            return boqitemAssembly;
        }

        private bool BoqitemAssemblyExists(long id)
        {
            return _context.BoqitemAssembly.Any(e => e.Boqitemassemblyid == id);
        }
    }
}
