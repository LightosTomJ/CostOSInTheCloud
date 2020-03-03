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
    public class XchangerateController : ControllerBase
    {
        private readonly projectContext _context;

        public XchangerateController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Xchangerate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Xchangerate>>> GetXchangerate()
        {
            return await _context.Xchangerate.ToListAsync();
        }

        // GET: api/Xchangerate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Xchangerate>> GetXchangerate(long id)
        {
            var xchangerate = await _context.Xchangerate.FindAsync(id);

            if (xchangerate == null)
            {
                return NotFound();
            }

            return xchangerate;
        }

        // PUT: api/Xchangerate/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutXchangerate(long id, Xchangerate xchangerate)
        {
            if (id != xchangerate.Xchangerateid)
            {
                return BadRequest();
            }

            _context.Entry(xchangerate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!XchangerateExists(id))
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

        // POST: api/Xchangerate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Xchangerate>> PostXchangerate(Xchangerate xchangerate)
        {
            _context.Xchangerate.Add(xchangerate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetXchangerate", new { id = xchangerate.Xchangerateid }, xchangerate);
        }

        // DELETE: api/Xchangerate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Xchangerate>> DeleteXchangerate(long id)
        {
            var xchangerate = await _context.Xchangerate.FindAsync(id);
            if (xchangerate == null)
            {
                return NotFound();
            }

            _context.Xchangerate.Remove(xchangerate);
            await _context.SaveChangesAsync();

            return xchangerate;
        }

        private bool XchangerateExists(long id)
        {
            return _context.Xchangerate.Any(e => e.Xchangerateid == id);
        }
    }
}
