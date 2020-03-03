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
    public class BoqitemController : ControllerBase
    {
        private readonly projectContext _context;

        public BoqitemController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Boqitem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boqitem>>> GetBoqitem()
        {
            return await _context.Boqitem.ToListAsync();
        }

        // GET: api/Boqitem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Boqitem>> GetBoqitem(long id)
        {
            var boqitem = await _context.Boqitem.FindAsync(id);

            if (boqitem == null)
            {
                return NotFound();
            }

            return boqitem;
        }

        // PUT: api/Boqitem/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoqitem(long id, Boqitem boqitem)
        {
            if (id != boqitem.Boqitemid)
            {
                return BadRequest();
            }

            _context.Entry(boqitem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoqitemExists(id))
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

        // POST: api/Boqitem
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Boqitem>> PostBoqitem(Boqitem boqitem)
        {
            _context.Boqitem.Add(boqitem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoqitem", new { id = boqitem.Boqitemid }, boqitem);
        }

        // DELETE: api/Boqitem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Boqitem>> DeleteBoqitem(long id)
        {
            var boqitem = await _context.Boqitem.FindAsync(id);
            if (boqitem == null)
            {
                return NotFound();
            }

            _context.Boqitem.Remove(boqitem);
            await _context.SaveChangesAsync();

            return boqitem;
        }

        private bool BoqitemExists(long id)
        {
            return _context.Boqitem.Any(e => e.Boqitemid == id);
        }
    }
}
