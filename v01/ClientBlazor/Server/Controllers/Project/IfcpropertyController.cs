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
    public class IfcpropertyController : ControllerBase
    {
        private readonly projectContext _context;

        public IfcpropertyController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Ifcproperty
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ifcproperty>>> GetIfcproperty()
        {
            return await _context.Ifcproperty.ToListAsync();
        }

        // GET: api/Ifcproperty/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ifcproperty>> GetIfcproperty(long id)
        {
            var ifcproperty = await _context.Ifcproperty.FindAsync(id);

            if (ifcproperty == null)
            {
                return NotFound();
            }

            return ifcproperty;
        }

        // PUT: api/Ifcproperty/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIfcproperty(long id, Ifcproperty ifcproperty)
        {
            if (id != ifcproperty.Propid)
            {
                return BadRequest();
            }

            _context.Entry(ifcproperty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IfcpropertyExists(id))
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

        // POST: api/Ifcproperty
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Ifcproperty>> PostIfcproperty(Ifcproperty ifcproperty)
        {
            _context.Ifcproperty.Add(ifcproperty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIfcproperty", new { id = ifcproperty.Propid }, ifcproperty);
        }

        // DELETE: api/Ifcproperty/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ifcproperty>> DeleteIfcproperty(long id)
        {
            var ifcproperty = await _context.Ifcproperty.FindAsync(id);
            if (ifcproperty == null)
            {
                return NotFound();
            }

            _context.Ifcproperty.Remove(ifcproperty);
            await _context.SaveChangesAsync();

            return ifcproperty;
        }

        private bool IfcpropertyExists(long id)
        {
            return _context.Ifcproperty.Any(e => e.Propid == id);
        }
    }
}
