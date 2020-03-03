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
    public class PrjuserpropController : ControllerBase
    {
        private readonly projectContext _context;

        public PrjuserpropController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Prjuserprop
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prjuserprop>>> GetPrjuserprop()
        {
            return await _context.Prjuserprop.ToListAsync();
        }

        // GET: api/Prjuserprop/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prjuserprop>> GetPrjuserprop(long id)
        {
            var prjuserprop = await _context.Prjuserprop.FindAsync(id);

            if (prjuserprop == null)
            {
                return NotFound();
            }

            return prjuserprop;
        }

        // PUT: api/Prjuserprop/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrjuserprop(long id, Prjuserprop prjuserprop)
        {
            if (id != prjuserprop.Id)
            {
                return BadRequest();
            }

            _context.Entry(prjuserprop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrjuserpropExists(id))
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

        // POST: api/Prjuserprop
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Prjuserprop>> PostPrjuserprop(Prjuserprop prjuserprop)
        {
            _context.Prjuserprop.Add(prjuserprop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrjuserprop", new { id = prjuserprop.Id }, prjuserprop);
        }

        // DELETE: api/Prjuserprop/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Prjuserprop>> DeletePrjuserprop(long id)
        {
            var prjuserprop = await _context.Prjuserprop.FindAsync(id);
            if (prjuserprop == null)
            {
                return NotFound();
            }

            _context.Prjuserprop.Remove(prjuserprop);
            await _context.SaveChangesAsync();

            return prjuserprop;
        }

        private bool PrjuserpropExists(long id)
        {
            return _context.Prjuserprop.Any(e => e.Id == id);
        }
    }
}
