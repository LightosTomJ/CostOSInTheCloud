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
    public class BoqitemConsumableController : ControllerBase
    {
        private readonly projectContext _context;

        public BoqitemConsumableController(projectContext context)
        {
            _context = context;
        }

        // GET: api/BoqitemConsumable
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoqitemConsumable>>> GetBoqitemConsumable()
        {
            return await _context.BoqitemConsumable.ToListAsync();
        }

        // GET: api/BoqitemConsumable/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoqitemConsumable>> GetBoqitemConsumable(long id)
        {
            var boqitemConsumable = await _context.BoqitemConsumable.FindAsync(id);

            if (boqitemConsumable == null)
            {
                return NotFound();
            }

            return boqitemConsumable;
        }

        // PUT: api/BoqitemConsumable/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoqitemConsumable(long id, BoqitemConsumable boqitemConsumable)
        {
            if (id != boqitemConsumable.Boqitemconsumableid)
            {
                return BadRequest();
            }

            _context.Entry(boqitemConsumable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoqitemConsumableExists(id))
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

        // POST: api/BoqitemConsumable
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BoqitemConsumable>> PostBoqitemConsumable(BoqitemConsumable boqitemConsumable)
        {
            _context.BoqitemConsumable.Add(boqitemConsumable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoqitemConsumable", new { id = boqitemConsumable.Boqitemconsumableid }, boqitemConsumable);
        }

        // DELETE: api/BoqitemConsumable/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BoqitemConsumable>> DeleteBoqitemConsumable(long id)
        {
            var boqitemConsumable = await _context.BoqitemConsumable.FindAsync(id);
            if (boqitemConsumable == null)
            {
                return NotFound();
            }

            _context.BoqitemConsumable.Remove(boqitemConsumable);
            await _context.SaveChangesAsync();

            return boqitemConsumable;
        }

        private bool BoqitemConsumableExists(long id)
        {
            return _context.BoqitemConsumable.Any(e => e.Boqitemconsumableid == id);
        }
    }
}
