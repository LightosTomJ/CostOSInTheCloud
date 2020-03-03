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
    public class BoqitemLaborController : ControllerBase
    {
        private readonly projectContext _context;

        public BoqitemLaborController(projectContext context)
        {
            _context = context;
        }

        // GET: api/BoqitemLabor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoqitemLabor>>> GetBoqitemLabor()
        {
            return await _context.BoqitemLabor.ToListAsync();
        }

        // GET: api/BoqitemLabor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoqitemLabor>> GetBoqitemLabor(long id)
        {
            var boqitemLabor = await _context.BoqitemLabor.FindAsync(id);

            if (boqitemLabor == null)
            {
                return NotFound();
            }

            return boqitemLabor;
        }

        // PUT: api/BoqitemLabor/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoqitemLabor(long id, BoqitemLabor boqitemLabor)
        {
            if (id != boqitemLabor.Boqitemlaborid)
            {
                return BadRequest();
            }

            _context.Entry(boqitemLabor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoqitemLaborExists(id))
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

        // POST: api/BoqitemLabor
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BoqitemLabor>> PostBoqitemLabor(BoqitemLabor boqitemLabor)
        {
            _context.BoqitemLabor.Add(boqitemLabor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoqitemLabor", new { id = boqitemLabor.Boqitemlaborid }, boqitemLabor);
        }

        // DELETE: api/BoqitemLabor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BoqitemLabor>> DeleteBoqitemLabor(long id)
        {
            var boqitemLabor = await _context.BoqitemLabor.FindAsync(id);
            if (boqitemLabor == null)
            {
                return NotFound();
            }

            _context.BoqitemLabor.Remove(boqitemLabor);
            await _context.SaveChangesAsync();

            return boqitemLabor;
        }

        private bool BoqitemLaborExists(long id)
        {
            return _context.BoqitemLabor.Any(e => e.Boqitemlaborid == id);
        }
    }
}
