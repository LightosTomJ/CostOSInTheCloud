using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Results;

namespace ClientBlazor.Server.Controllers.Results
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentPartialController : ControllerBase
    {
        private readonly resultsContext _context;

        public EquipmentPartialController(resultsContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentPartial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentPartial>>> GetEquipmentPartial()
        {
            return await _context.EquipmentPartial.ToListAsync();
        }

        // GET: api/EquipmentPartial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentPartial>> GetEquipmentPartial(int id)
        {
            var equipmentPartial = await _context.EquipmentPartial.FindAsync(id);

            if (equipmentPartial == null)
            {
                return NotFound();
            }

            return equipmentPartial;
        }

        // PUT: api/EquipmentPartial/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentPartial(int id, EquipmentPartial equipmentPartial)
        {
            if (id != equipmentPartial.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipmentPartial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentPartialExists(id))
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

        // POST: api/EquipmentPartial
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EquipmentPartial>> PostEquipmentPartial(EquipmentPartial equipmentPartial)
        {
            _context.EquipmentPartial.Add(equipmentPartial);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EquipmentPartialExists(equipmentPartial.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEquipmentPartial", new { id = equipmentPartial.Id }, equipmentPartial);
        }

        // DELETE: api/EquipmentPartial/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EquipmentPartial>> DeleteEquipmentPartial(int id)
        {
            var equipmentPartial = await _context.EquipmentPartial.FindAsync(id);
            if (equipmentPartial == null)
            {
                return NotFound();
            }

            _context.EquipmentPartial.Remove(equipmentPartial);
            await _context.SaveChangesAsync();

            return equipmentPartial;
        }

        private bool EquipmentPartialExists(int id)
        {
            return _context.EquipmentPartial.Any(e => e.Id == id);
        }
    }
}
