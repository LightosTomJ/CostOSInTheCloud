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
    public class IfcelementController : ControllerBase
    {
        private readonly projectContext _context;

        public IfcelementController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Ifcelement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ifcelement>>> GetIfcelement()
        {
            return await _context.Ifcelement.ToListAsync();
        }

        // GET: api/Ifcelement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ifcelement>> GetIfcelement(long id)
        {
            var ifcelement = await _context.Ifcelement.FindAsync(id);

            if (ifcelement == null)
            {
                return NotFound();
            }

            return ifcelement;
        }

        // PUT: api/Ifcelement/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIfcelement(long id, Ifcelement ifcelement)
        {
            if (id != ifcelement.Elemid)
            {
                return BadRequest();
            }

            _context.Entry(ifcelement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IfcelementExists(id))
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

        // POST: api/Ifcelement
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Ifcelement>> PostIfcelement(Ifcelement ifcelement)
        {
            _context.Ifcelement.Add(ifcelement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIfcelement", new { id = ifcelement.Elemid }, ifcelement);
        }

        // DELETE: api/Ifcelement/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ifcelement>> DeleteIfcelement(long id)
        {
            var ifcelement = await _context.Ifcelement.FindAsync(id);
            if (ifcelement == null)
            {
                return NotFound();
            }

            _context.Ifcelement.Remove(ifcelement);
            await _context.SaveChangesAsync();

            return ifcelement;
        }

        private bool IfcelementExists(long id)
        {
            return _context.Ifcelement.Any(e => e.Elemid == id);
        }
    }
}
