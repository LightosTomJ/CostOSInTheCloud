using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;

namespace ClientBlazor.Server.Controllers.Local
{
    [Route("api/[controller]")]
    [ApiController]
    public class LayoutcpanelController : ControllerBase
    {
        private readonly localContext _context;

        public LayoutcpanelController(localContext context)
        {
            _context = context;
        }

        // GET: api/Layoutcpanel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Layoutcpanel>>> GetLayoutcpanel()
        {
            return await _context.Layoutcpanel.ToListAsync();
        }

        // GET: api/Layoutcpanel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Layoutcpanel>> GetLayoutcpanel(long id)
        {
            var layoutcpanel = await _context.Layoutcpanel.FindAsync(id);

            if (layoutcpanel == null)
            {
                return NotFound();
            }

            return layoutcpanel;
        }

        // PUT: api/Layoutcpanel/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLayoutcpanel(long id, Layoutcpanel layoutcpanel)
        {
            if (id != layoutcpanel.Layoutcpanelid)
            {
                return BadRequest();
            }

            _context.Entry(layoutcpanel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LayoutcpanelExists(id))
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

        // POST: api/Layoutcpanel
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Layoutcpanel>> PostLayoutcpanel(Layoutcpanel layoutcpanel)
        {
            _context.Layoutcpanel.Add(layoutcpanel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLayoutcpanel", new { id = layoutcpanel.Layoutcpanelid }, layoutcpanel);
        }

        // DELETE: api/Layoutcpanel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Layoutcpanel>> DeleteLayoutcpanel(long id)
        {
            var layoutcpanel = await _context.Layoutcpanel.FindAsync(id);
            if (layoutcpanel == null)
            {
                return NotFound();
            }

            _context.Layoutcpanel.Remove(layoutcpanel);
            await _context.SaveChangesAsync();

            return layoutcpanel;
        }

        private bool LayoutcpanelExists(long id)
        {
            return _context.Layoutcpanel.Any(e => e.Layoutcpanelid == id);
        }
    }
}
