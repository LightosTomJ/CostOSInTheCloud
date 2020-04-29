using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;

namespace API.Controllers.DB.Local
{
    [Route("api/[controller]")]
    [ApiController]
    public class LayoutcpanelController : ControllerBase
    {
        private readonly LocalContext _context;

        public LayoutcpanelController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Layoutcpanel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LayoutCPanel>>> GetLayoutcpanel()
        {
            return await _context.LayoutCPanel.ToListAsync();
        }

        // GET: api/Layoutcpanel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LayoutCPanel>> GetLayoutcpanel(long id)
        {
            var layoutcpanel = await _context.LayoutCPanel.FindAsync(id);

            if (layoutcpanel == null)
            {
                return NotFound();
            }

            return layoutcpanel;
        }

        // PUT: api/Layoutcpanel/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLayoutcpanel(long id, LayoutCPanel layoutcpanel)
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LayoutCPanel>> PostLayoutcpanel(LayoutCPanel layoutcpanel)
        {
            _context.LayoutCPanel.Add(layoutcpanel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLayoutcpanel", new { id = layoutcpanel.Layoutcpanelid }, layoutcpanel);
        }

        // DELETE: api/Layoutcpanel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LayoutCPanel>> DeleteLayoutcpanel(long id)
        {
            var layoutcpanel = await _context.LayoutCPanel.FindAsync(id);
            if (layoutcpanel == null)
            {
                return NotFound();
            }

            _context.LayoutCPanel.Remove(layoutcpanel);
            await _context.SaveChangesAsync();

            return layoutcpanel;
        }

        private bool LayoutcpanelExists(long id)
        {
            return _context.LayoutCPanel.Any(e => e.Layoutcpanelid == id);
        }
    }
}
