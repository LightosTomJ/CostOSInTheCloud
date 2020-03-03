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
    public class AssemblyEquipmentController : ControllerBase
    {
        private readonly localContext _context;

        public AssemblyEquipmentController(localContext context)
        {
            _context = context;
        }

        // GET: api/AssemblyEquipment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssemblyEquipment>>> GetAssemblyEquipment()
        {
            return await _context.AssemblyEquipment.ToListAsync();
        }

        // GET: api/AssemblyEquipment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssemblyEquipment>> GetAssemblyEquipment(long id)
        {
            var assemblyEquipment = await _context.AssemblyEquipment.FindAsync(id);

            if (assemblyEquipment == null)
            {
                return NotFound();
            }

            return assemblyEquipment;
        }

        // PUT: api/AssemblyEquipment/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssemblyEquipment(long id, AssemblyEquipment assemblyEquipment)
        {
            if (id != assemblyEquipment.Assemblyequipmentid)
            {
                return BadRequest();
            }

            _context.Entry(assemblyEquipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssemblyEquipmentExists(id))
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

        // POST: api/AssemblyEquipment
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AssemblyEquipment>> PostAssemblyEquipment(AssemblyEquipment assemblyEquipment)
        {
            _context.AssemblyEquipment.Add(assemblyEquipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssemblyEquipment", new { id = assemblyEquipment.Assemblyequipmentid }, assemblyEquipment);
        }

        // DELETE: api/AssemblyEquipment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AssemblyEquipment>> DeleteAssemblyEquipment(long id)
        {
            var assemblyEquipment = await _context.AssemblyEquipment.FindAsync(id);
            if (assemblyEquipment == null)
            {
                return NotFound();
            }

            _context.AssemblyEquipment.Remove(assemblyEquipment);
            await _context.SaveChangesAsync();

            return assemblyEquipment;
        }

        private bool AssemblyEquipmentExists(long id)
        {
            return _context.AssemblyEquipment.Any(e => e.Assemblyequipmentid == id);
        }
    }
}
