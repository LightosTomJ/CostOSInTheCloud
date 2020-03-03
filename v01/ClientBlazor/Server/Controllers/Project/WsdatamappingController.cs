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
    public class WsdatamappingController : ControllerBase
    {
        private readonly projectContext _context;

        public WsdatamappingController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Wsdatamapping
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wsdatamapping>>> GetWsdatamapping()
        {
            return await _context.Wsdatamapping.ToListAsync();
        }

        // GET: api/Wsdatamapping/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wsdatamapping>> GetWsdatamapping(long id)
        {
            var wsdatamapping = await _context.Wsdatamapping.FindAsync(id);

            if (wsdatamapping == null)
            {
                return NotFound();
            }

            return wsdatamapping;
        }

        // PUT: api/Wsdatamapping/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWsdatamapping(long id, Wsdatamapping wsdatamapping)
        {
            if (id != wsdatamapping.Id)
            {
                return BadRequest();
            }

            _context.Entry(wsdatamapping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WsdatamappingExists(id))
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

        // POST: api/Wsdatamapping
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Wsdatamapping>> PostWsdatamapping(Wsdatamapping wsdatamapping)
        {
            _context.Wsdatamapping.Add(wsdatamapping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWsdatamapping", new { id = wsdatamapping.Id }, wsdatamapping);
        }

        // DELETE: api/Wsdatamapping/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Wsdatamapping>> DeleteWsdatamapping(long id)
        {
            var wsdatamapping = await _context.Wsdatamapping.FindAsync(id);
            if (wsdatamapping == null)
            {
                return NotFound();
            }

            _context.Wsdatamapping.Remove(wsdatamapping);
            await _context.SaveChangesAsync();

            return wsdatamapping;
        }

        private bool WsdatamappingExists(long id)
        {
            return _context.Wsdatamapping.Any(e => e.Id == id);
        }
    }
}
